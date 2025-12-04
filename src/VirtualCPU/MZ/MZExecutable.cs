namespace Disassembler.Formats.MZ
{
	public class MZExecutable
	{
		// 0x00 - Signature, word (0x5A4D (ASCII for 'M' and 'Z'))
		protected ushort MZsignature = 0;
		// 0x0A - Minimum allocation, word (The number of paragraphs required by the program, excluding the PSP and program image. If no free block is big enough, the loading stops.)
		protected ushort minimumAllocation = 0;
		// 0x0C - Maximum allocation, word (The number of paragraphs requested by the program. If no free block is big enough, the biggest one possible is allocated.)
		protected ushort maximumAllocation = 0;
		// 0x0E - Initial SS, word (Relocatable segment address for SS.)
		protected ushort initialSS = 0;
		// 0x10 - Initial SP, word (Initial value for SP.)
		protected ushort initialSP = 0;
		// 0x14 - Initial IP, word (Initial value for IP.)
		protected ushort initialIP = 0;
		// 0x16 - Initial CS, word (Relocatable segment address for CS.)
		protected ushort initialCS = 0;
		// 0x1A - Overlay, word (Value used for overlay management. If zero, this is the main executable.)
		protected ushort overlayIndex = 0;
		// 0x1C - Overlay information, word (Files sometimes contain extra information for the main's program overlay management.)
		// always 1 in this case
		protected ushort overlayFlag = 0;
		// Additional data in the header before Relocation table
		protected byte[] additionalHeaderDataBeforeRelocationTable = new byte[0];
		// Additional data in the header after Relocation table
		protected byte[] additionalHeaderDataAfterRelocationTable = new byte[0];
		// actual code or data
		protected byte[] mainData = new byte[0];
		// relocation data
		protected List<MZRelocationItem> relocations = new List<MZRelocationItem>();
		// overlays
		protected List<MZExecutable> overlays = new List<MZExecutable>();

		protected MZExecutable()
		{ }

		public MZExecutable(string path)
			: this(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
		}

		public MZExecutable(Stream stream)
		{
			int filePosition = Read(stream, 0, this);

			// load overlays
			while (filePosition < stream.Length)
			{
				MZExecutable overlay = new MZExecutable();
				stream.Seek(filePosition, SeekOrigin.Begin);
				filePosition += Read(stream, filePosition, overlay);

				this.overlays.Add(overlay);
			}

			stream.Close();
		}

		private static int Read(Stream stream, int position, MZExecutable exe)
		{
			// load header
			exe.MZsignature = ReadUInt16(stream);
			if (exe.MZsignature != 0x5a4d)
			{
				throw new Exception("Not an MS-DOS executable file");
			}

			// 0x02 - Extra bytes, word (Number of bytes in the last page.)
			int extraBytes = ReadUInt16(stream);
			// 0x04 - Pages, word (Number of whole/partial pages.)
			int pages = ReadUInt16(stream);
			// 0x06 - Relocation items, word (Number of entries in the relocation table.)
			int relocationItems = ReadUInt16(stream);
			// 0x08 - Header size, word (The number of paragraphs taken up by the header.
			// It can be any value, as the loader just uses it to find where the actual executable data starts.
			// It may be larger than what the "standard" fields take up, and you may use it if you want to include
			// your own header metadata, or put the relocation table there, or use it for any other purpose.)
			int headerSize = ReadUInt16(stream);
			// header size is less than 2 paragraphs
			if (headerSize < 0x2)
			{
				throw new Exception("The MS-DOS executable file header has invalid size");
			}
			exe.minimumAllocation = ReadUInt16(stream);
			exe.maximumAllocation = ReadUInt16(stream);
			exe.initialSS = ReadUInt16(stream);
			exe.initialSP = ReadUInt16(stream);
			// 0x12 - Checksum, word (When added to the sum of all other words in the file, the result should be zero.)
			int checksum = ReadUInt16(stream);
			exe.initialIP = ReadUInt16(stream);
			exe.initialCS = ReadUInt16(stream);
			// 0x18 - Relocation table, word (The absolute offset to the relocation table.)
			int relocationTableOffset = ReadUInt16(stream);
			exe.overlayIndex = ReadUInt16(stream);
			exe.overlayFlag = ReadUInt16(stream);

			// relocation table is before our overlay index and ID
			if (relocationItems > 0 && relocationTableOffset < 0x1e)
			{
				throw new Exception("The MS-DOS executable file header has invalid relocation table");
			}

			if (relocationItems > 0 && relocationTableOffset > 0x1e)
			{
				int additionalHeaderDataSizeBeforeRelocationTable = relocationTableOffset - 0x1e;

				exe.additionalHeaderDataBeforeRelocationTable = new byte[additionalHeaderDataSizeBeforeRelocationTable];
				stream.Read(exe.additionalHeaderDataBeforeRelocationTable, 0, additionalHeaderDataSizeBeforeRelocationTable);
			}

			// read relocations
			if (relocationItems > 0)
			{
				stream.Seek(position + relocationTableOffset, SeekOrigin.Begin);

				for (int i = 0; i < relocationItems; i++)
				{
					ushort relocationOffset = ReadUInt16(stream);
					ushort relocationSegment = ReadUInt16(stream);
					exe.relocations.Add(new MZRelocationItem(relocationSegment, relocationOffset));
				}
			}

			int additionalHeaderDataSizeAfterRelocationTable = headerSize * 16;

			if (relocationItems > 0)
			{
				additionalHeaderDataSizeAfterRelocationTable -= (relocationTableOffset + (relocationItems * 4));
			}
			else
			{
				additionalHeaderDataSizeAfterRelocationTable -= 0x1e;
			}

			if (additionalHeaderDataSizeAfterRelocationTable > 0)
			{
				stream.Seek(relocationTableOffset + (relocationItems * 4), SeekOrigin.Begin);

				exe.additionalHeaderDataAfterRelocationTable = new byte[additionalHeaderDataSizeAfterRelocationTable];
				stream.Read(exe.additionalHeaderDataAfterRelocationTable, 0, additionalHeaderDataSizeAfterRelocationTable);

				bool zeroes = true;

				for (int i = 0; i < additionalHeaderDataSizeAfterRelocationTable; i++)
				{
					if (exe.additionalHeaderDataAfterRelocationTable[i] != 0)
					{
						zeroes = false;
						break;
					}
				}

				if (zeroes && additionalHeaderDataSizeAfterRelocationTable < 16)
				{
					// we can safely assume that these are an paragraph padding zeroes
					exe.additionalHeaderDataAfterRelocationTable = new byte[0];
				}
			}

			// read data
			int dataSize = (extraBytes > 0) ? (((pages - 1) * 512) + extraBytes) - (headerSize * 16) : (pages * 512) - (headerSize * 16);
			stream.Seek(position + (headerSize * 16), SeekOrigin.Begin);

			exe.mainData = new byte[dataSize];
			stream.Read(exe.mainData, 0, dataSize);

			return (pages * 512);
		}

		public void Write(string path)
		{
			FileStream writer = new FileStream(path, FileMode.Create);
			this.Write(writer);
			writer.Close();
		}

		public void Write(Stream stream)
		{
			MemoryStream writer = new MemoryStream();

			WriteUInt16(writer, this.MZsignature);
			int dataLength = this.mainData.Length;
			int headerLength = 0x1e + this.additionalHeaderDataBeforeRelocationTable.Length +
				(this.relocations.Count * 4) + this.additionalHeaderDataAfterRelocationTable.Length;
			int appendHeaderData = 0;

			if ((headerLength & 0xf) != 0)
			{
				appendHeaderData = 16 - (headerLength & 0xf);
				headerLength += (ushort)appendHeaderData;
			}

			dataLength += headerLength;
			ushort pages = (ushort)(dataLength >> 9);
			ushort extraBytes = (ushort)(dataLength - (pages << 9));
			if (extraBytes > 0)
				pages++;

			WriteUInt16(writer, extraBytes);
			WriteUInt16(writer, pages);
			WriteUInt16(writer, (ushort)this.relocations.Count);
			WriteUInt16(writer, (ushort)(headerLength >> 4));
			WriteUInt16(writer, this.minimumAllocation);
			WriteUInt16(writer, this.maximumAllocation);
			WriteUInt16(writer, this.initialSS);
			WriteUInt16(writer, this.initialSP);
			ushort checksum = 0;
			WriteUInt16(writer, checksum);
			WriteUInt16(writer, this.initialIP);
			WriteUInt16(writer, this.initialCS);
			WriteUInt16(writer, (ushort)(0x1e + this.additionalHeaderDataBeforeRelocationTable.Length));
			WriteUInt16(writer, this.overlayIndex);
			WriteUInt16(writer, this.overlayFlag);

			for (int i = 0; i < this.additionalHeaderDataBeforeRelocationTable.Length; i++)
			{
				writer.WriteByte(this.additionalHeaderDataBeforeRelocationTable[i]);
			}

			// write relocations
			for (int i = 0; i < this.relocations.Count; i++)
			{
				MZRelocationItem relocation = this.relocations[i];
				WriteUInt16(writer, relocation.Offset);
				WriteUInt16(writer, relocation.Segment);
			}

			for (int i = 0; i < this.additionalHeaderDataAfterRelocationTable.Length; i++)
			{
				writer.WriteByte(this.additionalHeaderDataAfterRelocationTable[i]);
			}

			// append to 16 byte boundary
			for (int i = 0; i < appendHeaderData; i++)
			{
				writer.WriteByte(0);
			}

			// write data
			writer.Write(this.mainData, 0, this.mainData.Length);

			// append to full 512 byte page
			int appendData = (ushort)(512 - extraBytes);
			for (int i = 0; i < appendData; i++)
			{
				writer.WriteByte(0);
			}
			writer.Flush();

			// calculate checksum
			writer.Seek(0, SeekOrigin.Begin);
			for (int i = 0; i < pages * 512; i += 2)
			{
				checksum = (ushort)((checksum + ReadUInt16(writer)) & 0xffff);
			}
			checksum = (ushort)(0x10000 - checksum);
			writer.Seek(0x12, SeekOrigin.Begin);
			WriteUInt16(writer, checksum);

			writer.Seek(0, SeekOrigin.End);

			if (this.overlayFlag != 0)
			{
				// write overlays
				for (int i = 0; i < this.overlays.Count; i++)
				{
					MemoryStream overlayWriter = new MemoryStream();
					this.overlays[i].Write(overlayWriter);

					byte[] overlayBuffer = overlayWriter.ToArray();
					writer.Write(overlayBuffer, 0, overlayBuffer.Length);
				}
			}

			writer.Flush();

			byte[] buffer = writer.ToArray();
			stream.Write(buffer, 0, buffer.Length);

			writer.Dispose();
		}

		/// <summary>
		/// This function relocates all segments with relation to loading segment
		/// </summary>
		/// <param name="loadingSegment"></param>
		/*public void ApplyRelocations(ushort loadingSegment)
		{
			this.initialCS += loadingSegment;
			this.initialSS += loadingSegment;

			for (int i = 0; i < this.relocations.Count; i++)
			{
				MZRelocationItem relocation = this.relocations[i];
				int dataPosition = (int)(((int)relocation.Segment << 4) + relocation.Offset);
				ushort newCS = this.ReadUInt16(dataPosition);
				newCS += loadingSegment;
				this.WriteUInt16(dataPosition, newCS);
			}

			for (int i = 0; i < this.overlays.Count; i++)
			{
				MZExecutable overlay = this.overlays[i];

				for (int j = 0; j < overlay.Relocations.Count; j++)
				{
					MZRelocationItem relocation = overlay.Relocations[j];
					int dataPosition = relocation.Offset;
					ushort newCS = overlay.ReadUInt16(dataPosition);
					newCS += loadingSegment;
					overlay.WriteUInt16(dataPosition, newCS);
				}
			}
		}*/

		#region Helper functions
		public static byte ReadByte(Stream stream)
		{
			int b0 = stream.ReadByte();

			if (b0 < 0)
			{
				throw new Exception("Unexpected end of stream");
			}

			return (byte)(b0 & 0xff);
		}

		public static ushort ReadUInt16(Stream stream)
		{
			int b0 = stream.ReadByte();
			int b1 = stream.ReadByte();

			if (b0 < 0 || b1 < 0)
			{
				throw new Exception("Unexpected end of stream");
			}

			return (ushort)((b0 & 0xff) | ((b1 & 0xff) << 8));
		}

		public ushort ReadUInt16(int address)
		{
			return (ushort)((int)this.mainData[address] | ((int)this.mainData[address + 1] << 8));
		}

		public void WriteUInt16(Stream stream, ushort value)
		{
			stream.WriteByte((byte)(value & 0xff));
			stream.WriteByte((byte)((value & 0xff00) >> 8));
		}

		public void WriteUInt16(int address, ushort value)
		{
			this.mainData[address] = (byte)(value & 0xff);
			this.mainData[address + 1] = (byte)((value & 0xff00) >> 8);
		}
		#endregion

		public ushort Signature
		{
			get { return this.MZsignature; }
		}

		public ushort MinimumAllocation
		{
			get { return this.minimumAllocation; }
			set { this.minimumAllocation = value; }
		}

		public ushort MaximumAllocation
		{
			get { return this.maximumAllocation; }
			set { this.maximumAllocation = value; }
		}

		public ushort InitialSS
		{
			get { return this.initialSS; }
			set { this.initialSS = value; }
		}

		public ushort InitialSP
		{
			get { return this.initialSP; }
			set { this.initialSP = value; }
		}

		public ushort InitialIP
		{
			get { return this.initialIP; }
			set { this.initialIP = value; }
		}

		public ushort InitialCS
		{
			get { return this.initialCS; }
			set { this.initialCS = value; }
		}

		public ushort OverlayIndex
		{
			get { return this.overlayIndex; }
			set { this.overlayIndex = value; }
		}

		public ushort OverlayFlag
		{
			get { return this.overlayFlag; }
			set { this.overlayFlag = value; }
		}

		public byte[] Data
		{
			get { return this.mainData; }
			set { this.mainData = value; }
		}

		public byte[] AdditionalHeaderDataBeforeRelocationTable
		{
			get { return this.additionalHeaderDataBeforeRelocationTable; }
			set { this.additionalHeaderDataBeforeRelocationTable = value; }
		}

		public byte[] AdditionalHeaderDataAfterRelocationTable
		{
			get { return this.additionalHeaderDataAfterRelocationTable; }
			set { this.additionalHeaderDataAfterRelocationTable = value; }
		}

		public List<MZRelocationItem> Relocations
		{
			get { return this.relocations; }
		}

		public List<MZExecutable> Overlays
		{
			get { return this.overlays; }
		}
	}
}
