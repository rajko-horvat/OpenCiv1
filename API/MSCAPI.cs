using System;
using System.IO;
using System.Text;
using System.Threading;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class MSCAPI
	{
		private OpenCiv1 oParent;
		private CPU oCPU;
		private RandomMT19937 oRNG = new RandomMT19937();

		public MSCAPI(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void exit(short code)
		{
			this.oCPU.Log.WriteLine($"exit({code})");
			this.oCPU.Exit(code);
		}

		public void perror()
		{
			this.oCPU.Log.EnterBlock("'perror'(Cdecl) at 0x3045:0x200e");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = 0x2;
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L204c;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
			if (this.oCPU.Flags.E) goto L204c;

			// Instruction uiAddress 0x3045:0x2026, size: 5
			strlen(this.oCPU.SI.Word);

			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2037); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x2032, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5baa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2049); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x2044, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L204c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x58fb), 0x0);
			if (this.oCPU.Flags.L) goto L205c;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5dbc);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x58fb), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L2062;

		L205c:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5dbc);
			goto L2066;

		L2062:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x58fb);

		L2066:
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x5d70));
			// Instruction uiAddress 0x3045:0x206d, size: 5
			strlen(this.oCPU.SI.Word);

			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x207d); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x2078, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5bad;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x208e); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x2089, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'perror'");
		}

		#region Keyboard operations
		public short kbhit()
		{
			this.oCPU.AX.Word = (ushort)((this.oParent.VGADriver.Keys.Count > 0) ? 0xffff : 0);

			return (short)this.oCPU.AX.Word;
		}

		public short getch()
		{
			while (this.oParent.VGADriver.Keys.Count == 0)
			{
				Thread.Sleep(200);
				this.oCPU.DoEvents();
			}

			lock (this.oParent.VGADriver.VGALock)
			{
				this.oCPU.AX.Word = (ushort)this.oParent.VGADriver.Keys.Dequeue();
			}

			return (short)this.oCPU.AX.Word;
		}
		#endregion

		#region Memory operations
		public ushort memcpy(ushort destination, ushort source, ushort count)
		{
			this.oCPU.Log.EnterBlock($"memcpy(0x{destination:x4}, 0x{source:x4}, {count})");

			// function body
			int iDirection = 1;
			uint uiDestination = CPU.ToLinearAddress(this.oCPU.DS.Word, destination);
			uint uiSource = CPU.ToLinearAddress(this.oCPU.DS.Word, source);
			int iCount = count;

			if (uiDestination > uiSource && (uiSource + iCount) >= uiDestination)
			{
				uiSource = (uint)(uiSource + iCount - 1);
				uiDestination = (uint)(uiDestination + iCount - 1);
				iDirection = -1;
			}

			while (iCount > 0)
			{
				this.oCPU.Memory.WriteUInt8(uiDestination, this.oCPU.Memory.ReadUInt8(uiSource));
				uiDestination = (uint)((long)uiDestination + iDirection);
				uiSource = (uint)((long)uiSource + iDirection);
				iCount--;
			}

			// Far return
			this.oCPU.Log.ExitBlock("memcpy");
			this.oCPU.AX.Word = destination; // for compatibility reasons
			return destination;
		}

		public ushort memset(ushort destination, byte value, ushort count)
		{
			this.oCPU.Log.EnterBlock($"memset(0x{destination:x4}, 0x{value:x2}, {count})");

			// function body
			uint uiDestination = CPU.ToLinearAddress(this.oCPU.DS.Word, destination);
			int iCount = count;

			while (iCount > 0)
			{
				this.oCPU.Memory.WriteUInt8(uiDestination, value);
				uiDestination++;
				iCount--;
			}

			this.oCPU.Log.ExitBlock("memset");
			this.oCPU.AX.Word = destination; // for compatibility reasons
			return destination;
		}

		public void movedata(ushort sourceSegment, ushort sourceOffset, ushort destinationSegment, ushort destinationOffset, ushort count)
		{
			this.oCPU.Log.EnterBlock($"movedata(0x{sourceSegment:x4}, 0x{sourceOffset:x4}, 0x{destinationSegment:x4}, 0x{destinationOffset:x4}, {count})");

			// function body
			int iDirection = 1;
			uint uiDestination = CPU.ToLinearAddress(destinationSegment, destinationOffset);
			uint uiSource = CPU.ToLinearAddress(sourceSegment, sourceOffset);
			int iCount = count;

			if (uiDestination > uiSource && (uiSource + iCount) >= uiDestination)
			{
				uiSource = (uint)(uiSource + iCount - 1);
				uiDestination = (uint)(uiDestination + iCount - 1);
				iDirection = -1;
			}

			while (iCount > 0)
			{
				this.oCPU.Memory.WriteUInt8(uiDestination, this.oCPU.Memory.ReadUInt8(uiSource));
				uiDestination = (uint)((long)uiDestination + iDirection);
				uiSource = (uint)((long)uiSource + iDirection);
				iCount--;
			}

			this.oCPU.Log.ExitBlock("movedata");
		}

		public void _dos_freemem(ushort segment)
		{
			this.oCPU.Log.EnterBlock($"_dos_freemem(0x{segment:x4})");

			// function body
			if (segment >= 0xb000)
			{
				// this is a graphics bitmap
				if (this.oParent.VGADriver.Bitmaps.ContainsKey(segment))
				{
					this.oParent.VGADriver.Bitmaps.RemoveByKey(segment);

					this.oCPU.Flags.C = false;
					this.oCPU.AX.Word = 0;
				}
				else
				{
					throw new Exception($"The bitmap 0x{segment:x4} is not allocated");
				}
			}
			else
			{
				if (this.oCPU.Memory.FreeMemoryBlock(segment))
				{
					this.oCPU.Flags.C = false;
					this.oCPU.AX.Word = 0x0;
				}
				else
				{
					this.oCPU.Flags.C = true;
					this.oCPU.AX.Word = 9; // Invalid memory block uiAddress
				}
			}

			this.oCPU.Log.ExitBlock("_dos_freemem");
		}
		#endregion

		#region File operations
		public static string GetDOSFileName(string path)
		{
			string sPath = path;

			if (sPath.IndexOf(':') == 1)
			{
				sPath = sPath.Substring(2);
			}

			if (sPath.IndexOf('\\') > 0)
			{
				sPath = sPath.Substring(sPath.LastIndexOf('\\') + 1);
			}

			return sPath;
		}

		public short fopen(ushort filenamePtr, ushort modePtr)
		{
			return fopen(this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr)),
				this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, modePtr)));
		}

		public short fopen(string filename, ushort modePtr)
		{
			return fopen(filename,
				this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, modePtr)));
		}

		public short fopen(ushort filenamePtr, string mode)
		{
			return fopen(this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr)), mode);
		}

		public short fopen(string filename, string mode)
		{
			FileMode eMode = FileMode.Open;
			FileAccess eAccess = FileAccess.Write;
			FileStreamTypeEnum eType = FileStreamTypeEnum.Binary;

			mode = mode.Trim().ToLower();
			for (int i = 0; i < mode.Length; i++)
			{
				switch (mode[i])
				{
					case 'r':
						eMode = FileMode.Open;
						eAccess = FileAccess.Read;
						break;
					case 'w':
						eMode = FileMode.Create;
						eAccess = FileAccess.Write;
						break;
					case 'a':
						eMode = FileMode.Append;
						eAccess = FileAccess.Write;
						break;
					case '+':
						eAccess = FileAccess.ReadWrite;
						break;
					case 't':
						eType = FileStreamTypeEnum.Text;
						break;
					case 'b':
						eType = FileStreamTypeEnum.Binary;
						break;
					default:
						throw new Exception($"Unknown file mode '{mode}'");
				}
			}

			short sHandle = -1;
			string sPath = Path.Combine(this.oCPU.DefaultDirectory, GetDOSFileName(filename.ToUpper()));
			this.oCPU.Log.WriteLine($"Opening file '{sPath}', with file handle {this.oCPU.FileHandleCount}");

			try
			{
				this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream($"{sPath}", eMode, eAccess), eType));
				sHandle = this.oCPU.FileHandleCount;
				this.oCPU.FileHandleCount++;
			}
			catch
			{
				sHandle = -1;
			}

			this.oCPU.AX.Word = (ushort)sHandle; // preserve compatibility
			return sHandle;
		}

		public short fclose(short handle)
		{
			return this.close(handle);
		}

		public ushort fread(ushort ptr, ushort itemSize, ushort itemCount, short handle)
		{
			ushort usItemCount = 0;
			uint uiAddress = CPU.ToLinearAddress(this.oCPU.DS.Word, ptr);

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				byte[] aBuffer = new byte[itemSize];

				for (int i = 0; i < itemCount; i++)
				{
					int iLength = 0;

					if (fileItem.Type == FileStreamTypeEnum.Binary)
					{
						short sUnGetC = fileItem.UnGetC;
						if (sUnGetC != -1)
						{
							aBuffer[0] = (byte)(sUnGetC & 0xff);
							if (itemSize - 1 > 0)
							{
								iLength = fileItem.Stream.Read(aBuffer, 1, itemSize - 1);
								if (iLength != itemSize - 1)
									break;
							}
						}
						else
						{
							iLength = fileItem.Stream.Read(aBuffer, 0, itemSize);
							if (iLength != itemSize)
								break;
						}

						this.oCPU.Memory.WriteBlock(uiAddress, aBuffer, 0, itemSize);
						uiAddress += itemSize;
					}
					else
					{
						iLength = 0;
						for (int j = 0; j < itemSize; j++)
						{
							short ch = fileItem.ReadChar();
							if (ch < 0)
								break;
							aBuffer[j] = (byte)ch;
							iLength++;
						}

						if (iLength != itemSize)
							break;

						this.oCPU.Memory.WriteBlock(uiAddress, aBuffer, 0, itemSize);
						uiAddress += itemSize;
					}
				}
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = usItemCount; // preserve compatibility
			return usItemCount;
		}

		public short fscanf(short handle, ushort formatPtr, ushort varPtr)
		{
			return fscanf(handle, this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, formatPtr)), varPtr);
		}

		public short fscanf(short handle, string format, ushort varPtr)
		{
			short sCount = -1;
			uint uiVarAddress = CPU.ToLinearAddress(this.oCPU.DS.Word, varPtr);

			if (this.oCPU.Files.ContainsKey(handle))
			{
				sCount = 0;
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				StringBuilder sbResult = new StringBuilder();

				switch (format.ToLower())
				{
					case "%[^\n]\n":
						short ch;
						while ((ch = fileItem.ReadChar()) != -1 && ch != (short)'\n')
						{
							if (ch != (short)'\r')
							{
								sbResult.Append((char)ch);
							}
						}
						if (ch != -1 && sbResult.Length > 0)
						{
							this.oCPU.WriteString(uiVarAddress, sbResult.ToString(), sbResult.Length);
							sCount = 1;
						}
						else
						{
							this.oCPU.WriteString(uiVarAddress, "", 1);
							sCount = -1;
						}
						break;

					default:
						throw new Exception($"fscanf has undefined format '{format}'");
				}

				this.oCPU.Log.WriteLine($"fscanf('%[^\\n]\\n') = '{sbResult.ToString()}'");
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = (ushort)sCount; // preserve compatibility
			return sCount;
		}

		public ushort fwrite(ushort ptr, ushort itemSize, ushort itemCount, short handle)
		{
			ushort usItemCount = 0;
			uint uiAddress = CPU.ToLinearAddress(this.oCPU.DS.Word, ptr);

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				byte[] aBuffer = new byte[itemSize];

				if (fileItem.Type == FileStreamTypeEnum.Binary)
				{
					for (int i = 0; i < itemCount; i++)
					{
						for (int j = 0; j < itemSize; j++)
						{
							aBuffer[j] = this.oCPU.Memory.ReadUInt8(uiAddress);
							uiAddress++;
						}

						fileItem.Stream.Write(aBuffer, 0, itemSize);
						usItemCount++;
					}
				}
				else
				{
					bool bLF = false;

					for (int i = 0; i < itemCount; i++)
					{
						for (int j = 0; j < itemSize; j++)
						{
							aBuffer[j] = this.oCPU.Memory.ReadUInt8(uiAddress);
							if (aBuffer[j] == (byte)'\n')
							{
								if (!bLF)
								{
									aBuffer[j] = (byte)'\r';
									bLF = true;
								}
								else
								{
									uiAddress++;
								}
							}
							else
							{
								uiAddress++;
							}
						}

						fileItem.Stream.Write(aBuffer, 0, itemSize);
						usItemCount++;
					}
					if (bLF)
					{
						fileItem.Stream.WriteByte((byte)'\n');
					}
				}
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = usItemCount; // preserve compatibility
			return usItemCount;
		}

		public short fseek(short handle, int offset, short whence)
		{
			short sRetVal = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				if (whence >= 0 && whence < 3)
				{
					FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
					short sTemp = fileItem.UnGetC;
					SeekOrigin origin = SeekOrigin.Begin;

					switch (whence)
					{
						case 0:
							origin = SeekOrigin.Begin;
							break;
						case 1:
							origin = SeekOrigin.Current;
							break;
						case 2:
							origin = SeekOrigin.End;
							break;
					}

					fileItem.Stream.Seek(offset, origin);
					sRetVal = 0;
				}
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = (ushort)sRetVal; // preserve compatibility
			return sRetVal;
		}

		public int ftell(short handle)
		{
			int iPosition = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				short sTemp = fileItem.UnGetC;
				iPosition = (int)fileItem.Stream.Position;
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, (uint)iPosition); // preserve compatibility
			return iPosition;
		}

		public int lseek(short handle, int offset, short whence)
		{
			int iRetVal = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				if (whence >= 0 && whence < 3)
				{
					FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
					short sTemp = fileItem.UnGetC;
					SeekOrigin origin = SeekOrigin.Begin;

					switch (whence)
					{
						case 0:
							origin = SeekOrigin.Begin;
							break;
						case 1:
							origin = SeekOrigin.Current;
							break;
						case 2:
							origin = SeekOrigin.End;
							break;
					}

					fileItem.Stream.Seek(offset, origin);
					iRetVal = offset;
				}
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, (uint)iRetVal); // preserve compatibility
			return iRetVal;
		}

		public short open(ushort filenamePtr, ushort access)
		{
			return open(filenamePtr, access, 0);
		}

		public short open(ushort filenamePtr, ushort access, ushort mode)
		{
			return open(this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr)), access, mode);
		}

		public short open(string filename, ushort access, ushort mode)
		{
			FileMode eMode = FileMode.Open;
			FileAccess eAccess = FileAccess.Read;
			FileStreamTypeEnum eType = FileStreamTypeEnum.Binary;

			if ((access & 0x1) == 0x1)
			{
				// open for writing only
				eAccess = FileAccess.Write;
			}
			else if ((access & 0x2) == 0x2)
			{
				// open for reading and writing
				eAccess = FileAccess.ReadWrite;
			}

			if ((access & 0x8) == 0x8)
			{
				// append file
				eMode = FileMode.Append;
			}
			else if ((access & 0x100) == 0x100)
			{
				// create and open file
				eMode = FileMode.OpenOrCreate;
			}
			else if ((access & 0x200) == 0x200)
			{
				// open and truncate
				eMode = FileMode.Truncate;
			}
			else if ((access & 0x400) == 0x400)
			{
				// open only if file doesn't already exist
				eMode = FileMode.Open;
			}

			if ((access & 0x4000) == 0x4000)
			{
				// file mode is text (translated)
				eType = FileStreamTypeEnum.Text;
			}
			else if ((access & 0x8000) == 0x8000)
			{
				// file mode is binary (untranslated)
				eType = FileStreamTypeEnum.Binary;
			}

			short sHandle = -1;
			string sPath = Path.Combine(this.oCPU.DefaultDirectory, GetDOSFileName(filename.ToUpper()));

			this.oCPU.Log.WriteLine($"Opening file '{sPath}', with file handle {this.oCPU.FileHandleCount}");
			try
			{
				this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream($"{sPath}", eMode, eAccess), eType));
				sHandle = this.oCPU.FileHandleCount;
				this.oCPU.FileHandleCount++;
			}
			catch
			{
				sHandle = -1;
			}

			this.oCPU.AX.Word = (ushort)sHandle; // preserve compatibility
			return sHandle;
		}

		public short close(short handle)
		{
			short sTemp = 0;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				this.oCPU.Log.WriteLine($"Closing file handle {handle}");
				this.oCPU.Files.GetValueByKey(handle).Stream.Close();
				this.oCPU.Files.RemoveByKey(handle);
			}
			else
			{
				this.oCPU.Log.WriteLine($"Trying to close unknown handle {handle}");
				sTemp = -1;
			}

			this.oCPU.AX.Word = (ushort)sTemp; // preserve compatibility
			return sTemp;
		}

		public short read(short handle, ushort bufferPtr, ushort length)
		{
			uint address = CPU.ToLinearAddress(this.oCPU.DS.Word, bufferPtr);
			short sItemCount = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);

				for (int i = 0; i < length; i++)
				{
					short ch = fileItem.ReadChar();
					if (ch >= 0)
					{
						this.oCPU.Memory.WriteUInt8(address, (byte)ch);
						address++;
						sItemCount++;
					}
					else
					{
						break;
					}
				}
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = (ushort)sItemCount; // preserve compatibility
			return sItemCount;
		}

		public short write(short handle, ushort bufferPtr, ushort length)
		{
			uint address = CPU.ToLinearAddress(this.oCPU.DS.Word, bufferPtr);
			short sItemCount = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);

				if (fileItem.Type == FileStreamTypeEnum.Binary)
				{
					for (int i = 0; i < length; i++)
					{
						fileItem.Stream.WriteByte(this.oCPU.Memory.ReadUInt8(address));
						address++;
						sItemCount++;
					}
				}
				else
				{
					for (int i = 0; i < length; i++)
					{
						byte ch = this.oCPU.Memory.ReadUInt8(address);
						if (ch == (byte)'\n')
						{
							fileItem.Stream.WriteByte((byte)'\r');
						}
						fileItem.Stream.WriteByte(ch);
						address++;
						sItemCount++;
					}
				}
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = (ushort)sItemCount; // preserve compatibility
			return sItemCount;
		}

		public short _dos_open(ushort filenamePtr, ushort flags, ushort handlePtr)
		{
			uint uiHandleAddress = CPU.ToLinearAddress(this.oCPU.DS.Word, handlePtr);
			short sRetVal = -1;

			string sName = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr));
			FileMode eMode = FileMode.Open;
			FileAccess eAccess = FileAccess.Read;
			FileStreamTypeEnum eType = FileStreamTypeEnum.Binary;

			if ((flags & 0x1) == 0x1)
			{
				// open for writing only
				eAccess = FileAccess.Write;
			}
			if ((flags & 0x2) == 0x2)
			{
				// open for reading and writing
				eAccess = FileAccess.ReadWrite;
			}
			if ((flags & 0x8) == 0x8)
			{
				// append file
				eMode = FileMode.Append;
			}
			if ((flags & 0x100) == 0x100)
			{
				// create and open file
				eMode = FileMode.OpenOrCreate;
			}
			if ((flags & 0x200) == 0x200)
			{
				// open and truncate
				eMode = FileMode.Truncate;
			}
			if ((flags & 0x400) == 0x400)
			{
				// open only if file doesn't already exist
				eMode = FileMode.Open;
			}

			string sPath = Path.Combine(this.oCPU.DefaultDirectory, GetDOSFileName(sName.ToUpper()));
			if (File.Exists(sPath))
			{
				this.oCPU.Log.WriteLine($"Opening file '{sPath}', with file handle {this.oCPU.FileHandleCount}");
				this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream(sPath, eMode, eAccess), eType));
				short sHandle = this.oCPU.FileHandleCount;
				this.oCPU.FileHandleCount++;
				this.oCPU.Memory.WriteUInt16(CPU.ToLinearAddress(this.oCPU.DS.Word, handlePtr), (ushort)sHandle);
				sRetVal = 0;
			}

			this.oCPU.AX.Word = (ushort)sRetVal; // preserve compatibility
			return sRetVal;
		}

		public ushort _dos_close(short handle)
		{
			ushort usRetVal = (ushort)this.close(handle);

			this.oCPU.AX.Word = usRetVal; // preserve compatibility
			return usRetVal;
		}

		public ushort _dos_read(short handle, ushort bufferPtr, ushort length, ushort nreadPtr)
		{
			uint uiBufferAddress = CPU.ToLinearAddress(this.oCPU.DS.Word, bufferPtr);
			ushort usRetVal = 1;
			ushort usItemCount = 0;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);

				for (int i = 0; i < length; i++)
				{
					short ch = fileItem.ReadChar();
					if (ch >= 0)
					{
						this.oCPU.Memory.WriteUInt8(uiBufferAddress, (byte)ch);
						uiBufferAddress++;
						usItemCount++;
					}
					else
					{
						break;
					}
				}

				this.oCPU.Memory.WriteUInt16(CPU.ToLinearAddress(this.oCPU.DS.Word, nreadPtr), usItemCount);
				usRetVal = 0;
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = usRetVal; // preserve compatibility
			return usRetVal;
		}

		public void _bios_disk(ushort command, ushort diskInfoPtr)
		{
			this.oCPU.Log.EnterBlock("'_bios_disk'(Cdecl) at 0x3045:0x3062");

			// function body
			DriveInfo[] driveInfo = DriveInfo.GetDrives();
			uint uiAddress = CPU.ToLinearAddress(this.oCPU.DS.Word, diskInfoPtr);
			int iDrive = this.oCPU.Memory.ReadUInt16(uiAddress);
			char chDrive = (char)((iDrive >= 0x80) ? (iDrive - 0x80 + 'C') : ('A' + iDrive));

			switch (command)
			{
				case 0:
					// reset disk system
					this.oCPU.AX.High = 0;
					this.oCPU.Flags.C = false;
					this.oCPU.Log.ExitBlock("'_bios_disk'");
					return;

				case 4:
					// Verify disk sectors

					for (int i = 0; i < driveInfo.Length; i++)
					{
						if (driveInfo[i].Name[0] == chDrive)
						{
							if (driveInfo[i].IsReady)
							{
								this.oCPU.AX.High = 0;
								this.oCPU.Flags.C = false;
								this.oCPU.Log.ExitBlock("'_bios_disk'");
								return;
							}
							else
							{
								break;
							}
						}
					}
					break;
			}

			this.oCPU.AX.High = 0x80;
			this.oCPU.Flags.C = true;

			this.oCPU.Log.ExitBlock("'_bios_disk'");
		}

		public void _dos_getdrive(ushort valuePtr)
		{
			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, valuePtr, 3);
		}
		#endregion

		#region String operations
		/// <summary>
		/// Join two strings together
		/// </summary>
		/// <param name="destinationPtr">The destination string ptr</param>
		/// <param name="sourcePtr">The source string ptr</param>
		/// <returns></returns>
		public ushort strcat(ushort destinationPtr, ushort sourcePtr)
		{
			string sDest = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, destinationPtr));
			string sSource = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, sourcePtr));

			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, destinationPtr), sDest + sSource, sDest.Length + sSource.Length);

			this.oCPU.AX.Word = destinationPtr; // preserve compatibility
			return destinationPtr;
		}

		public ushort strcat(ushort destinationPtr, string sourceString)
		{
			string sDest = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, destinationPtr));

			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, destinationPtr), sDest + sourceString, 
				sDest.Length + sourceString.Length);

			this.oCPU.AX.Word = destinationPtr; // preserve compatibility
			return destinationPtr;
		}

		public ushort strcpy(ushort destinationPtr, ushort sourcePtr)
		{
			string sSource = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, sourcePtr));

			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, destinationPtr), sSource, sSource.Length);

			this.oCPU.AX.Word = destinationPtr; // preserve compatibility
			return destinationPtr;
		}

		public ushort strcpy(ushort destinationPtr, string source)
		{
			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, destinationPtr), source, source.Length);

			this.oCPU.AX.Word = destinationPtr; // preserve compatibility
			return destinationPtr;
		}

		public ushort strlen(ushort stringPtr)
		{
			string sSource = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			this.oCPU.AX.Word = (ushort)sSource.Length; // preserve compatibility
			return (ushort)sSource.Length;
		}

		public short stricmp(ushort string1Ptr, ushort string2Ptr)
		{
			string sS1 = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, string1Ptr));
			string sS2 = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, string2Ptr));

			short sRetVal = (short)string.Compare(sS1, sS2, StringComparison.CurrentCultureIgnoreCase);

			this.oCPU.AX.Word = (ushort)sRetVal; // preserve compatibility
			return sRetVal;
		}

		public short strnicmp(ushort string1Ptr, ushort string2Ptr, ushort maxLength)
		{
			string sS1 = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, string1Ptr));
			string sS2 = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, string2Ptr));

			if (sS1.Length > maxLength)
				sS1 = sS1.Substring(0, maxLength);

			if (sS2.Length > maxLength)
				sS2 = sS2.Substring(0, maxLength);

			short sRetVal = (short)string.Compare(sS1, sS2, StringComparison.CurrentCultureIgnoreCase);

			this.oCPU.AX.Word = (ushort)sRetVal; // preserve compatibility
			return sRetVal;
		}

		public ushort strupr(ushort stringPtr)
		{
			string sTemp = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr)).ToUpper();

			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr), sTemp, sTemp.Length);

			this.oCPU.AX.Word = stringPtr; // preserve compatibility
			return stringPtr;
		}

		public int strstr(ushort string1Ptr, ushort string2Ptr)
		{
			string sS1 = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, string1Ptr));
			string sS2 = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, string2Ptr));

			short sRetVal = (short)sS1.IndexOf(sS2);

			if (sRetVal >= 0) // preserve compatibility
			{
				this.oCPU.AX.Word = (ushort)(string1Ptr + sRetVal);
			}
			else
			{
				this.oCPU.AX.Word = 0;
			}

			return sRetVal;
		}

		public ushort itoa(int value, ushort stringPtr, short radix)
		{
			string sValue = Convert.ToString(value, radix);

			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr), sValue, sValue.Length);

			this.oCPU.AX.Word = stringPtr; // preserve compatibility
			return stringPtr;
		}

		public string itoa(int value, short radix)
		{
			string sValue = Convert.ToString(value, radix);

			return sValue;
		}
		#endregion

		#region Time operations
		public void time()
		{
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, 
				(uint)time(CPU.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4)))));
		}

		public int time(uint timePtr)
		{
			int iTotalSeconds = (int)Math.Floor((DateTime.Now - (new DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds);

			if (timePtr != 0)
				this.oCPU.Memory.WriteUInt32(timePtr, (uint)iTotalSeconds);

			return iTotalSeconds;
		}
		#endregion

		#region Math operations
		public short abs(short value)
		{
			short retval = Math.Abs(value);
			this.oCPU.AX.Word = (ushort)retval; // for compatibility

			return retval;
		}
		#endregion

		#region Random number generator operations
		public void srand()
		{
			srand(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4)));
		}

		public void srand(ushort value)
		{
			this.oRNG = new RandomMT19937(value);
		}

		public short rand()
		{
			this.oCPU.AX.Word = (ushort)(this.oRNG.UNext() & 0x7fff);
			return (short)this.oCPU.AX.Word;
		}

		public RandomMT19937 RNG
		{
			get { return this.oRNG; }
		}
		#endregion
	}
}
