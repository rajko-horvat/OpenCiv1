using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IRB.VirtualCPU.MZ
{
	public struct MZRelocationItem
	{
		private ushort usSegment;
		private ushort usOffset;

		public MZRelocationItem(ushort segment, ushort offset)
		{
			this.usSegment = segment;
			this.usOffset = offset;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
		}

		public ushort Offset
		{
			get { return this.usOffset; }
		}

		public override string ToString()
		{
			return $"0x{this.usSegment:x4}:0x{this.usOffset:x4}";
		}
	}

	public class MZExecutable
	{
		// 0x00 - Signature, word (0x5A4D (ASCII for 'M' and 'Z'))
		protected ushort usSignature = 0;
		// 0x0A - Minimum allocation, word (The number of paragraphs required by the program, excluding the PSP and program image. If no free block is big enough, the loading stops.)
		protected ushort usMinimumAllocation = 0;
		// 0x0C - Maximum allocation, word (The number of paragraphs requested by the program. If no free block is big enough, the biggest one possible is allocated.)
		protected ushort usMaximumAllocation = 0;
		// 0x0E - Initial SS, word (Relocatable segment address for SS.)
		protected ushort usInitialSS = 0;
		// 0x10 - Initial SP, word (Initial value for SP.)
		protected ushort usInitialSP = 0;
		// 0x14 - Initial IP, word (Initial value for IP.)
		protected ushort usInitialIP = 0;
		// 0x16 - Initial CS, word (Relocatable segment address for CS.)
		protected ushort usInitialCS = 0;
		// 0x1A - Overlay, word (Value used for overlay management. If zero, this is the main executable.)
		protected ushort usOverlayIndex = 0;
		// 0x1C - Overlay information, word (Files sometimes contain extra information for the main's program overlay management.)
		// always 1 in thiscase
		protected ushort usOverlayID = 0;
		// actual code or data
		protected byte[] aData = new byte[0];
		// relocation data
		protected List<MZRelocationItem> aRelocations = new List<MZRelocationItem>();
		// overlays
		protected List<MZExecutable> aOverlays = new List<MZExecutable>();

		protected MZExecutable()
		{ }

		public MZExecutable(string path)
			: this(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
		{ }

		public MZExecutable(Stream stream)
		{
			int iFilePosition = 0;
			iFilePosition += ReadHeader(stream, iFilePosition, this);

			// load overlays
			while (iFilePosition < stream.Length)
			{
				MZExecutable overlay = new MZExecutable();
				stream.Seek(iFilePosition, SeekOrigin.Begin);
				iFilePosition += ReadHeader(stream, iFilePosition, overlay);

				this.aOverlays.Add(overlay);
			}
		}

		private static int ReadHeader(Stream stream, int position, MZExecutable exe)
		{
			// load header
			exe.usSignature = ReadUInt16(stream);
			if (exe.usSignature != 0x5a4d)
			{
				throw new Exception("Not an MS-DOS executable file");
			}

			// 0x02 - Extra bytes, word (Number of bytes in the last page.)
			int iExtraBytes = ReadUInt16(stream);
			// 0x04 - Pages, word (Number of whole/partial pages.)
			int iPages = ReadUInt16(stream);
			// 0x06 - Relocation items, word (Number of entries in the relocation table.)
			int iRelocationItems = ReadUInt16(stream);
			// 0x08 - Header size, word (The number of paragraphs taken up by the header. It can be any value, as the loader just uses it to find where the actual executable data starts. It may be larger than what the "standard" fields take up, and you may use it if you want to include your own header metadata, or put the relocation table there, or use it for any other purpose.)
			int iHeaderSize = ReadUInt16(stream);
			exe.usMinimumAllocation = ReadUInt16(stream);
			exe.usMaximumAllocation = ReadUInt16(stream);
			exe.usInitialSS = ReadUInt16(stream);
			exe.usInitialSP = ReadUInt16(stream);
			// 0x12 - Checksum, word (When added to the sum of all other words in the file, the result should be zero.)
			int iChecksum = ReadUInt16(stream);
			exe.usInitialIP = ReadUInt16(stream);
			exe.usInitialCS = ReadUInt16(stream);
			// 0x18 - Relocation table, word (The (absolute) offset to the relocation table.)
			int iRelocationTableOffset = ReadUInt16(stream);
			exe.usOverlayIndex = ReadUInt16(stream);
			exe.usOverlayID = ReadUInt16(stream);

			// read relocations
			if (iRelocationItems > 0)
			{
				stream.Seek(position + iRelocationTableOffset, SeekOrigin.Begin);
				for (int i = 0; i < iRelocationItems; i++)
				{
					ushort usOffset = ReadUInt16(stream);
					ushort usSegment = ReadUInt16(stream);
					exe.aRelocations.Add(new MZRelocationItem(usSegment, usOffset));
				}

				stream.Seek(position + iHeaderSize << 4, SeekOrigin.Begin);
			}

			// read data
			int iDataSize = (iExtraBytes > 0) ? (((iPages - 1) << 9) + iExtraBytes) - (iHeaderSize << 4) : (iPages << 9) - (iHeaderSize << 4);
			stream.Seek(position + (iHeaderSize << 4), SeekOrigin.Begin);
			byte[] buffer = new byte[iDataSize];
			stream.Read(buffer, 0, iDataSize);
			exe.aData = buffer;

			return (iPages << 9);
		}

		public void WriteToFile(string path)
		{
			FileStream writer = new FileStream(path, FileMode.Create);
			this.WriteToFile(writer);
			writer.Close();
		}

		public void WriteToFile(Stream stream)
		{
			MemoryStream writer = new MemoryStream();
			WriteUInt16(writer, this.usSignature);
			uint uiLength = (uint)this.aData.Length;
			uint uiHeaderSize = (uint)(0x1e + this.aRelocations.Count * 4);
			VCPU.AlignToSegment(ref uiHeaderSize);
			uiLength += uiHeaderSize;
			uint uiPages = uiLength / 512;
			uint uiExtraBytes = uiLength - (uiPages * 512);
			if (uiExtraBytes > 0)
				uiPages++;
			WriteUInt16(writer, uiExtraBytes);
			WriteUInt16(writer, uiPages);
			WriteUInt16(writer, (uint)this.aRelocations.Count);
			uiHeaderSize >>= 4;
			WriteUInt16(writer, uiHeaderSize);
			WriteUInt16(writer, this.usMinimumAllocation);
			WriteUInt16(writer, this.usMaximumAllocation);
			WriteUInt16(writer, this.usInitialSS);
			WriteUInt16(writer, this.usInitialSP);
			uint uiChecksum = 0;
			WriteUInt16(writer, uiChecksum);
			WriteUInt16(writer, this.usInitialIP);
			WriteUInt16(writer, this.usInitialCS);
			WriteUInt16(writer, 0x1e);
			WriteUInt16(writer, this.usOverlayIndex);
			WriteUInt16(writer, this.usOverlayID);

			// write relocations
			for (int i = 0; i < this.aRelocations.Count; i++)
			{
				MZRelocationItem relocation = this.aRelocations[i];
				WriteUInt16(writer, relocation.Offset);
				WriteUInt16(writer, relocation.Segment);
			}

			// append to 16 byte boundary
			uint uiAppend = (uint)((uiHeaderSize << 4) - (0x1e + this.aRelocations.Count * 4));
			for (int i = 0; i < uiAppend; i++)
			{
				writer.WriteByte(0);
			}

			// write data
			writer.Write(this.aData, 0, this.aData.Length);

			// append to full 512 byte page
			uiAppend = 512 - uiExtraBytes;
			for (int i = 0; i < uiAppend; i++)
			{
				writer.WriteByte(0);
			}
			writer.Flush();

			// calculate checksum
			byte[] buffer = writer.ToArray();
			writer.Seek(0, SeekOrigin.Begin);
			for (int i = 0; i < buffer.Length; i += 2)
			{
				uiChecksum += ReadUInt16(writer);
			}
			uiChecksum &= 0xffff;
			uiChecksum = 0x10000 - uiChecksum;
			writer.Seek(0x12, SeekOrigin.Begin);
			WriteUInt16(writer, uiChecksum);

			writer.Seek(buffer.Length, SeekOrigin.Begin);

			// write overlays
			for (int i = 0; i < this.aOverlays.Count; i++)
			{
				this.aOverlays[i].WriteToFile(writer);
			}

			writer.Flush();

			buffer = writer.ToArray();
			stream.Write(buffer, 0, buffer.Length);

			writer.Dispose();
		}

		public void ApplyRelocations(ushort segment)
		{
			for (int i = 0; i < this.aRelocations.Count; i++)
			{
				MZRelocationItem relocation = this.aRelocations[i];
				uint uiAddress = VCPU.ToLinearAddress((ushort)relocation.Segment, (ushort)relocation.Offset);
				ushort usWord1 = (ushort)((ushort)this.aData[uiAddress] | (ushort)((ushort)this.aData[uiAddress + 1] << 8));
				usWord1 += segment;
				this.aData[uiAddress] = (byte)(usWord1 & 0xff);
				this.aData[uiAddress + 1] = (byte)((usWord1 & 0xff00) >> 8);
			}

			for (int i = 0; i < this.aOverlays.Count; i++)
			{
				MZExecutable overlay = this.aOverlays[i];

				for (int j = 0; j < overlay.Relocations.Count; j++)
				{
					MZRelocationItem relocation = overlay.Relocations[j];
					uint uiAddress = relocation.Offset;
					ushort usWord1 = (ushort)((ushort)overlay.aData[uiAddress] | (ushort)((ushort)overlay.aData[uiAddress + 1] << 8));
					//usWord1 += relocation.Segment;
					usWord1 += segment;
					overlay.aData[uiAddress] = (byte)(usWord1 & 0xff);
					overlay.aData[uiAddress + 1] = (byte)((usWord1 & 0xff00) >> 8);
				}
			}
		}

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

		public static uint ReadUInt32(Stream stream)
		{
			int b0 = stream.ReadByte();
			int b1 = stream.ReadByte();
			int b2 = stream.ReadByte();
			int b3 = stream.ReadByte();

			if (b0 < 0 || b1 < 0 || b2 < 0 || b3 < 0)
			{
				throw new Exception("Unexpected end of stream");
			}

			return (uint)((uint)((uint)b0 & 0xff) | (uint)(((uint)b1 & 0xff) << 8) |
				(uint)(((uint)b2 & 0xff) << 16) | (uint)(((uint)b3 & 0xff) << 24));
		}

		public static byte[] ReadBlock(Stream stream, int size)
		{
			byte[] abTemp = new byte[size];

			if (stream.Read(abTemp, 0, size) != size)
			{
				throw new Exception("Unexpected end of stream");
			}

			return abTemp;
		}

		public static string? ReadString(Stream stream)
		{
			int iLength = ReadByte(stream);
			byte[] abTemp = new byte[iLength];

			if (iLength == 0)
				return null;

			if (stream.Read(abTemp, 0, iLength) != iLength)
			{
				throw new Exception("Unexpected end of stream");
			}

			return Encoding.ASCII.GetString(abTemp);
		}

		public void WriteUInt16(Stream stream, uint value)
		{
			stream.WriteByte((byte)(value & 0xff));
			stream.WriteByte((byte)((value & 0xff00) >> 8));
		}
		#endregion

		public ushort Signature
		{
			get { return this.usSignature; }
		}

		public ushort MinimumAllocation
		{
			get { return this.usMinimumAllocation; }
			set { this.usMinimumAllocation = value; }
		}

		public ushort MaximumAllocation
		{
			get { return this.usMaximumAllocation; }
			set { this.usMaximumAllocation = value; }
		}

		public ushort InitialSS
		{
			get { return this.usInitialSS; }
			set { this.usInitialSS = value; }
		}

		public ushort InitialSP
		{
			get { return this.usInitialSP; }
			set { this.usInitialSP = value; }
		}

		public ushort InitialIP
		{
			get { return this.usInitialIP; }
			set { this.usInitialIP = value; }
		}

		public ushort InitialCS
		{
			get { return this.usInitialCS; }
			set { this.usInitialCS = value; }
		}

		public ushort OverlayIndex
		{
			get { return this.usOverlayIndex; }
			set { this.usOverlayIndex = value; }
		}

		public ushort OverlayID
		{
			get { return this.usOverlayID; }
			set { this.usOverlayID = value; }
		}

		public byte[] Data
		{
			get { return this.aData; }
			set { this.aData = value; }
		}

		public List<MZRelocationItem> Relocations
		{
			get { return this.aRelocations; }
		}

		public List<MZExecutable> Overlays
		{
			get { return this.aOverlays; }
		}
	}
}
