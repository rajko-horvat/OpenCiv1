using Disassembler;
using System;
using System.IO;

namespace Civilization1
{
	public class Segment_2fa1
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_2fa1(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_2fa1_000a_OpenFile(ushort filenamePtr, ushort flags)
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_000a_OpenFile'(Cdecl, Far)");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1a);

			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI._dos_open(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filenamePtr), flags, 
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			if (this.oCPU.AX.Word != 0)
			{
				this.oCPU.PushWord(filenamePtr);
				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				this.oCPU.PushWord(0x0065); // stack management - push return offset
											// Instruction address 0x2fa1:0x0062, size: 3
				F0_2fa1_066e_FileError();
				this.oCPU.PopDWord(); // stack management - pop return offset and segment
				this.oCPU.CS.Word = 0x2fa1; // restore this function segment
				this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			}
		
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_000a_OpenFile'");
		}

		public void F0_2fa1_009e_CloseFile(ushort handle)
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_009e'(Cdecl, Far) at 0x2fa1:0x009e");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			if (handle != 0xffff)
			{
				this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI._dos_close((short)handle);
				
				if (this.oCPU.AX.Word != 0)
				{
					this.oCPU.PushWord(0);
					this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
					this.oCPU.PushWord(0x00bf); // stack management - push return offset
												// Instruction address 0x2fa1:0x00bc, size: 3
					F0_2fa1_066e_FileError();
					this.oCPU.PopDWord(); // stack management - pop return offset and segment
					this.oCPU.CS.Word = 0x2fa1; // restore this function segment
					this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
				}
			}
		
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_009e'");
		}

		public void F0_2fa1_0644_FileRead(ushort handle)
		{
			this.oCPU.Log.EnterBlock($"'F0_2fa1_0644_FileRead'({handle})");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			this.oParent.MSCAPI._dos_read((short)handle,
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, 0xd936),
				0x200,
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oParent.Var_b26e = 0xd936;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_0644_FileRead'");
		}

		public void F0_2fa1_066e_FileError()
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_066e'(Cdecl, Far) at 0x2fa1:0x066e");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0679); // stack management - push return offset
										// Instruction address 0x2fa1:0x0676, size: 3
			F0_2fa1_0696();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0684); // stack management - push return offset
										// Instruction address 0x2fa1:0x067f, size: 5
			this.oParent.MSCAPI.perror();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oParent.MSCAPI.exit(0x63);

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_066e'");
		}

		private ushort ReadWordFromStream(FileStream stream)
		{
			int iByte0 = stream.ReadByte();
			int iByte1 = stream.ReadByte();

			if (iByte0 < 0 || iByte1 < 0)
			{
				// end of stream, return 0
				return 0;
			}

			return (ushort)(iByte0 | (iByte1 << 8));
		}

		public void F0_2fa1_01a2_LoadImageOrPalette(short page, ushort xPos, ushort yPos, ushort filenamePtr, ushort palettePtr)
		{
			this.oCPU.Log.EnterBlock($"'F0_2fa1_01a2_LoadImageOrPalette'(0x{page:x4}, 0x{xPos:x4}, 0x{yPos:x4}, " +
				$"'{this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filenamePtr))}', 0x{palettePtr:x4})");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			string filename = this.oCPU.DefaultDirectory + this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filenamePtr));
			FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
			
			F0_1000_108e_LoadPalette(stream, palettePtr);

			if (page < 0)
			{
				this.oParent.Var_68e4 = 0x0;
			}
			else
			{
				for (int i = 0; i < this.oParent.Var_68e4; i++)
				{
					// Instruction address 0x2fa1:0x01e4, size: 5
					F0_1000_1208(stream, 0xe17e);

					this.oParent.VGADriver.F0_VGA_03df_CopyLine(0xe17e, (ushort)page, xPos, (ushort)(yPos + i), this.oParent.Var_68e2);
				}
			}

			stream.Close();

			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_01a2_LoadImageOrPalette'");
		}

		public void F0_1000_108e_LoadPalette(FileStream stream, ushort palettePtr)
		{
			this.oCPU.Log.EnterBlock($"'F0_1000_108e_LoadPalette'(Cdecl, Far)(0x{palettePtr:x4})");

			// function body
			ushort usTemp;

			// This was intended to set default colours in some drivers, but in VGA driver it is not used
			//this.oParent.VGADriver.F0_VGA_0162_SetColorsFromStruct(0);

			while (((usTemp = ReadWordFromStream(stream)) & 0xff) != 0x58)
			{
				ushort usStartPtr = 0xba06;
				if (usTemp == 0x304d)
				{
					switch (palettePtr)
					{
						case 0:
							usStartPtr += 2;
							break;
						case 1:
							break;
						default:
							usStartPtr = palettePtr;
							break;
					}
				}

				ushort usTempPtr = usStartPtr;
				this.oCPU.Memory.WriteWord(this.oCPU.DS.Word, usTempPtr, usTemp);
				usTempPtr += 2;

				usTemp = ReadWordFromStream(stream);
				this.oCPU.Memory.WriteWord(this.oCPU.DS.Word, usTempPtr, usTemp);
				usTempPtr += 2;
				ushort usCount = (ushort)(usTemp >> 1);

				for (int i = 0; i < usCount; i++)
				{
					usTemp = ReadWordFromStream(stream);
					this.oCPU.Memory.WriteWord(this.oCPU.DS.Word, usTempPtr, usTemp);
					usTempPtr += 2;
				}

				if (usStartPtr == 0xba06)
				{
					// Instruction address 0x1000:0x112d, size: 5
					this.oParent.VGADriver.F0_VGA_0162_SetColorsFromStruct(0xba06);
				}
			}

			this.oParent.Var_68f7 = (byte)((usTemp & 0x100) >> 8);
			this.oParent.Var_68e6 = ReadWordFromStream(stream);
			this.oParent.Var_68e2 = ReadWordFromStream(stream);
			this.oParent.Var_68e4 = ReadWordFromStream(stream);

			F0_1000_1227_ReadHeader(stream);

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_108e_LoadPalette'");
		}

		public void F0_1000_1227_ReadHeader(FileStream stream)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1227'(Cdecl, Near) at 0x1000:0x1227");

			// function body
			ushort usTemp;

			if (this.oParent.Var_68e2 != 0 || this.oParent.Var_68e4 != 0)
			{
				this.oParent.Var_68ec = 0x0;
				this.oParent.Var_68ed = 0x0;
				this.oParent.Var_68e8 = 0x6afb;

				usTemp = Math.Min(ReadWordFromStream(stream), (ushort)0xb);
				this.oParent.Var_68ef = (byte)(usTemp & 0xff);
				this.oParent.Var_68f4 = usTemp;
				this.oParent.Var_68f6 = 0x8;
				this.oParent.Var_68ee = 0x9;
				this.oParent.Var_68f0 = 0x1ff;
				this.oParent.Var_68f2 = 0x100;

				for (int i = 0; i < 0x800; i++)
				{
					this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(0xba06 + (i * 3)), 0xffff);
				}

				for (int i = 0; i < 0x100; i++)
				{
					this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(0xba08 + (i * 3)), (byte)i);
				}
			}

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1227'");
		}

		public void F0_1000_1208(FileStream stream, ushort bufferPtr)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1208'(Cdecl, Far) at 0x1000:0x1208");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.ES.Word = this.oCPU.DS.Word;
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.DI.Word = bufferPtr;
			this.oParent.Var_68ea = this.oParent.Var_68e2;

			if (this.oParent.Var_68f7 != 0x0)
			{
				this.oParent.Var_68ea++;
				this.oParent.Var_68ea >>= 1;
			}

			this.oCPU.CX.Word = this.oParent.Var_68ea;

		L12bc:
			if (this.oParent.Var_68ec != 0) goto L12e4;

			// Instruction address 0x1000:0x12c3, size: 3
			F0_1000_1318(stream);

			if (this.oCPU.AX.Low == 0x90) goto L12d0;
			this.oParent.Var_68ed = this.oCPU.AX.Low;
			goto L12eb;

		L12d0:
			// Instruction address 0x1000:0x12d0, size: 3
			F0_1000_1318(stream);

			if (this.oCPU.AX.Low != 0) goto L12df;
			this.oCPU.AX.Low = 0x90;
			this.oParent.Var_68ed = this.oCPU.AX.Low;
			goto L12eb;

		L12df:
			this.oCPU.AX.Low--;
			this.oParent.Var_68ec = this.oCPU.AX.Low;

		L12e4:
			this.oCPU.AX.Low = this.oParent.Var_68ed;
			this.oParent.Var_68ec--;

		L12eb:
			if (this.oParent.Var_68f7 == 0) goto L1308;
			this.oCPU.AX.High = this.oCPU.AX.Low;
			this.oCPU.AX.Low &= 0xf;
			this.oCPU.AX.High >>= 4;
			this.oCPU.Memory.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.DI.Word += 2;
			this.oParent.Var_68ea--;
			if (this.oParent.Var_68ea != 0) goto L12bc;
			goto L130f;

		L1308:
			this.oCPU.Memory.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.DI.Word++;
			this.oParent.Var_68ea--;
			if (this.oParent.Var_68ea != 0) goto L12bc;

		L130f:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1208'");
		}

		public void F0_1000_1318(FileStream stream)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1318'(Undefined) at 0x1000:0x1318");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			if (this.oParent.Var_68e8 == 0x6afb)
			{
				// buffer is empty, fill it
				this.oCPU.BX.Word = this.oParent.Var_68f4;
				this.oCPU.CX.Low = 0x10;
				this.oCPU.CX.High = this.oParent.Var_68f6;
				this.oCPU.CX.Low -= this.oCPU.CX.High;
				this.oCPU.BX.Word >>= this.oCPU.CX.Low;
				this.oCPU.CX.Low = this.oCPU.CX.High;

				while (this.oCPU.CX.Low < this.oParent.Var_68ee)
				{
					this.oCPU.AX.Word = ReadWordFromStream(stream);
					this.oParent.Var_68f4 = this.oCPU.AX.Word;
					this.oCPU.AX.Word <<= this.oCPU.CX.Low;
					this.oCPU.BX.Word |= this.oCPU.AX.Word;
					this.oCPU.CX.Low += 0x10;
				}

				this.oCPU.CX.Low -= this.oParent.Var_68ee;
				this.oParent.Var_68f6 = this.oCPU.CX.Low;
				this.oCPU.AX.Word = this.oCPU.BX.Word;
				this.oCPU.AX.Word &= this.oParent.Var_68f0;
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				if (this.oCPU.AX.Word >= this.oParent.Var_68f2)
				{
					this.oCPU.CX.Word = this.oParent.Var_68f2;
					this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68f8);
					this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x68fa);

					this.oParent.Var_68e8 -= 2;
					this.oCPU.WriteWord(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.BX.Word);
				}

			L1377:
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word += this.oCPU.AX.Word;
				this.oCPU.BX.Word += this.oCPU.AX.Word;
				this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(0xba06 + this.oCPU.BX.Word));
				this.oCPU.AX.Word++;
				if (this.oCPU.AX.Word == 0) goto L138c;
				this.oCPU.AX.Word--;
				this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word));
				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteWord(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.BX.Word);
				goto L1377;

			L138c:
				this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word));
				this.oCPU.WriteByte(this.oCPU.DS.Word, 0x68fa, this.oCPU.AX.Low);
				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteWord(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.AX.Word);
				this.oCPU.BX.Word = this.oParent.Var_68f2;
				this.oCPU.BX.Word += this.oParent.Var_68f2;
				this.oCPU.BX.Word += this.oParent.Var_68f2;
				this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word), this.oCPU.AX.Low);
				this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68f8);
				this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(0xba06 + this.oCPU.BX.Word), this.oCPU.AX.Word);
				this.oParent.Var_68f2++;

				if (this.oParent.Var_68f2 <= this.oParent.Var_68f0) goto L13b5;
				this.oParent.Var_68ee++;

				this.oParent.Var_68f0 <<= 1;
				this.oParent.Var_68f0 |= 1;

			L13b5:
				this.oCPU.AX.Low = this.oParent.Var_68ee;
				if (this.oCPU.AX.Low <= this.oParent.Var_68ef) goto L13c1;

				// F0_1000_1270
				this.oParent.Var_68ee = 0x9;
				this.oParent.Var_68f0 = 0x1ff;
				this.oParent.Var_68f2 = 0x100;
				this.oCPU.AX.Word = 0xffff;
				this.oCPU.BX.Word = 0x0;
				this.oCPU.CX.Word = 0x800;

			L128a:
				this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(0xba06 + this.oCPU.BX.Word), this.oCPU.AX.Word);
				this.oCPU.BX.Word += 0x3;
				if (this.oCPU.Loop(this.oCPU.CX)) goto L128a;

				this.oCPU.AX.Low = 0x0;
				this.oCPU.BX.Word = 0x0;
				this.oCPU.CX.Word = 0x100;

			L129a:
				this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word), this.oCPU.AX.Low);
				this.oCPU.AX.Low++;
				this.oCPU.BX.Word += 0x3;
				if (this.oCPU.Loop(this.oCPU.CX)) goto L129a;

			L13c1:
				this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68f8, this.oCPU.CX.Word);
			}

			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oParent.Var_68e8);
			this.oParent.Var_68e8 += 2;

			this.oCPU.Log.ExitBlock("'F0_1000_1318'");
		}

		public void F0_2fa1_01a2_LoadImageOrPalette1(short page, ushort xPos, ushort yPos, ushort filenamePtr, ushort palettePtr)
		{
			this.oCPU.Log.EnterBlock($"'F0_2fa1_01a2_LoadImageOrPalette1'(0x{page:x4}, 0x{xPos:x4}, 0x{yPos:x4}, " +
				$"'{this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filenamePtr))}', 0x{palettePtr:x4})");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01b4); // stack management - push return offset
										// Instruction address 0x2fa1:0x01b1, size: 3
			F0_2fa1_000a_OpenFile(filenamePtr, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			ushort usHandle = this.oCPU.AX.Word;

			this.oParent.Var_b26e = Civilization.Constant_5528;

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01ca); // stack management - push return offset
										// Instruction address 0x2fa1:0x01c5, size: 5
			F0_1000_108e_LoadPalette1(palettePtr, usHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment

			if (page < 0)
			{
				this.oParent.Var_68e4 = 0x0;
			}
			else
			{
				for (int i = 0; i < this.oParent.Var_68e4; i++)
				{
					this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
					this.oCPU.PushWord(0x01e9); // stack management - push return offset
												// Instruction address 0x2fa1:0x01e4, size: 5
					F0_1000_1208_1(0xe17e, usHandle);
					this.oCPU.PopDWord(); // stack management - pop return offset and segment
					this.oCPU.CS.Word = 0x2fa1; // restore this function segment

					this.oParent.VGADriver.F0_VGA_03df_CopyLine(0xe17e, (ushort)page, xPos, (ushort)(yPos + i), this.oParent.Var_68e2);
				}
			}

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0217); // stack management - push return offset
										// Instruction address 0x2fa1:0x0214, size: 3
			F0_2fa1_009e_CloseFile(usHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_01a2_LoadImageOrPalette1'");
		}

		public void F0_2fa1_044c_LoadIcon(ushort filenamePtr)
		{
			this.oCPU.Log.EnterBlock($"'F0_2fa1_044c_LoadImage'('{this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filenamePtr))}')");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x045d); // stack management - push return offset
										// Instruction address 0x2fa1:0x045a, size: 3
			F0_2fa1_000a_OpenFile(filenamePtr, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
										//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			ushort usHandle = this.oCPU.AX.Word;
			//this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68da, usHandle);
			this.oParent.Var_b26e = Civilization.Constant_5528;

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0473); // stack management - push return offset
										// Instruction address 0x2fa1:0x046e, size: 5
			F0_1000_108e_LoadPalette1(0, usHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
										//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.PushWord(this.oParent.Var_68e4);
			this.oCPU.PushWord(this.oParent.Var_68e2);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0483); // stack management - push return offset
			// Instruction address 0x2fa1:0x047e, size: 5
			this.oParent.VGADriver.F0_VGA_0a78();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.SI.Word = 0;
			goto L04a3;

		L048a:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0493); // stack management - push return offset
										// Instruction address 0x2fa1:0x048e, size: 5
			F0_1000_1208_1(0xe17e, usHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
										//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.AX.Word = 0xe17e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x049f); // stack management - push return offset
			// Instruction address 0x2fa1:0x049a, size: 5
			this.oParent.VGADriver.F0_VGA_0ae3();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);

		L04a3:
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oParent.Var_68e4);
			if (this.oCPU.Flags.L) goto L048a;

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04b3); // stack management - push return offset
										// Instruction address 0x2fa1:0x04b0, size: 3
			F0_2fa1_009e_CloseFile(usHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
										//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04bb); // stack management - push return offset
			// Instruction address 0x2fa1:0x04b6, size: 5
			this.oParent.VGADriver.F0_VGA_0ac6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_044c_LoadImage'");
		}

		public void F0_1000_108e_LoadPalette1(ushort palettePtr, ushort handle)
		{
			this.oCPU.Log.EnterBlock($"'F0_1000_108e'(Cdecl, Far)({palettePtr}, {handle})");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			// Instruction address 0x1000:0x1096, size: 5
			this.oParent.VGADriver.F0_VGA_0162_SetColorsFromStruct(0);

		L109e:
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L10b6;

			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x10af); // stack management - push return offset
										// Instruction address 0x1000:0x10ab, size: 4
			this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;

		L10b6:
			this.oCPU.LODSWord();
			this.oParent.Var_b26e = this.oCPU.SI.Word;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x58);
			if (this.oCPU.Flags.E) goto L1138;

			this.oCPU.ES.Word = this.oCPU.DS.Word;

			this.oCPU.DI.Word = 0xba06;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x304d);
			if (this.oCPU.Flags.NE) goto L10dd;
			this.oCPU.CMPWord(palettePtr, 0x1);
			if (this.oCPU.Flags.B) goto L10da;
			if (this.oCPU.Flags.E) goto L10dd;
			this.oCPU.DI.Word = palettePtr;
			goto L10dd;

		L10da:
			this.oCPU.DI.Word += 2;

		L10dd:
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.STOSWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L10f7;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x10f0); // stack management - push return offset
										// Instruction address 0x1000:0x10ec, size: 4
			this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;

		L10f7:
			this.oCPU.LODSWord();
			this.oParent.Var_b26e = this.oCPU.SI.Word;
			this.oCPU.STOSWord();
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			if (this.oCPU.CX.Word == 0) goto L1123;

			L1103:
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L111b;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1114); // stack management - push return offset
										// Instruction address 0x1000:0x1110, size: 4
			this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;

		L111b:
			this.oCPU.LODSWord();
			this.oParent.Var_b26e = this.oCPU.SI.Word;
			this.oCPU.STOSWord();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L1103;

			L1123:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			// LEA
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NE) goto L1135;

			// Instruction address 0x1000:0x112d, size: 5
			this.oParent.VGADriver.F0_VGA_0162_SetColorsFromStruct(0xba06);

		L1135:
			goto L109e;

		L1138:
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, 0x1);
			this.oParent.Var_68f7 = this.oCPU.AX.High;
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L1157;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1150); // stack management - push return offset
										// Instruction address 0x1000:0x114c, size: 4
			this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;

		L1157:
			this.oCPU.LODSWord();
			this.oParent.Var_b26e = this.oCPU.SI.Word;
			this.oParent.Var_68e6 = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L1177;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1170); // stack management - push return offset
										// Instruction address 0x1000:0x116c, size: 4
			this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;

		L1177:
			this.oCPU.LODSWord();
			this.oParent.Var_b26e = this.oCPU.SI.Word;
			this.oParent.Var_68e2 = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L1197;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1190); // stack management - push return offset
										// Instruction address 0x1000:0x118c, size: 4
			this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;

		L1197:
			this.oCPU.LODSWord();
			this.oParent.Var_b26e = this.oCPU.SI.Word;
			this.oParent.Var_68e4 = this.oCPU.AX.Word;
			this.oCPU.PushWord(0x11a2); // stack management - push return offset
										// Instruction address 0x1000:0x119f, size: 3
			F0_1000_1227_1(handle);
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_108e'");
		}

		public void F0_1000_1227_1(ushort handle)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1227'(Cdecl, Near) at 0x1000:0x1227");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oParent.Var_68e2;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oParent.Var_68e4);
			if (this.oCPU.Flags.NE) goto L1231;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1227'");
			return;

		L1231:
			this.oParent.Var_68ec = 0x0;
			this.oParent.Var_68ed = 0x0;
			this.oParent.Var_68e8 = 0x6afb;
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L125a;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1253); // stack management - push return offset
										// Instruction address 0x1000:0x124f, size: 4
			this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oParent.Var_b26e;

		L125a:
			this.oCPU.LODSWord();
			this.oParent.Var_b26e = this.oCPU.SI.Word;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xb);
			if (this.oCPU.Flags.BE) goto L1265;
			this.oCPU.AX.Low = 0xb;

		L1265:
			this.oParent.Var_68ef = this.oCPU.AX.Low;
			this.oParent.Var_68f4 = this.oCPU.AX.Word;
			this.oParent.Var_68f6 = 0x8;
			this.oParent.Var_68ee = 0x9;
			this.oParent.Var_68f0 = 0x1ff;
			this.oCPU.DX.Word = 0x100;
			this.oParent.Var_68f2 = this.oCPU.DX.Word;
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.BX.Word = 0x0;
			this.oCPU.CX.Word = 0x800;

		L128a:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L128a;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.BX.Word = 0x0;
			this.oCPU.CX.Word = 0x100;

		L129a:
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f8), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.INCByte(this.oCPU.AX.Low);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L129a;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1227'");
		}

		public void F0_1000_1208_1(ushort param1, ushort handle)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1208'(Cdecl, Far) at 0x1000:0x1208");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.ES.Word = this.oCPU.DS.Word;
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.DI.Word = param1;
			this.oCPU.CX.Word = this.oParent.Var_68e2;

			if (this.oParent.Var_68f7 != 0x0)
			{
				this.oCPU.CX.Word++;
				this.oCPU.CX.Word >>= 1;
			}

			this.oParent.Var_68ea = this.oCPU.CX.Word;
			this.oCPU.DX.Word = this.oParent.Var_68f2;

		L12bc:
			this.oCPU.CMPByte(this.oParent.Var_68ec, 0x0);
			if (this.oCPU.Flags.NE) goto L12e4;

			this.oCPU.PushWord(0x12c6); // stack management - push return offset
										// Instruction address 0x1000:0x12c3, size: 3
			F0_1000_1318_1(0x12c6, handle);
			this.oCPU.PopWord(); // stack management - pop return offset

			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x90);
			if (this.oCPU.Flags.E) goto L12d0;
			this.oParent.Var_68ed = this.oCPU.AX.Low;
			goto L12eb;

		L12d0:
			this.oCPU.PushWord(0x12d3); // stack management - push return offset
										// Instruction address 0x1000:0x12d0, size: 3
			F0_1000_1318_1(0x12d3, handle);
			this.oCPU.PopWord(); // stack management - pop return offset

			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L12df;
			this.oCPU.AX.Low = 0x90;
			this.oParent.Var_68ed = this.oCPU.AX.Low;
			goto L12eb;

		L12df:
			this.oCPU.AX.Low = this.oCPU.DECByte(this.oCPU.AX.Low);
			this.oParent.Var_68ec = this.oCPU.AX.Low;

		L12e4:
			this.oCPU.AX.Low = this.oParent.Var_68ed;
			this.oParent.Var_68ec--;

		L12eb:
			this.oCPU.CMPByte(this.oParent.Var_68f7, 0x0);
			if (this.oCPU.Flags.E) goto L1308;
			this.oCPU.AX.High = this.oCPU.AX.Low;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xf);
			this.oCPU.AX.High = this.oCPU.SHRByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.SHRByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.SHRByte(this.oCPU.AX.High, 0x1);
			this.oCPU.AX.High = this.oCPU.SHRByte(this.oCPU.AX.High, 0x1);
			this.oCPU.STOSWord();
			this.oParent.Var_68ea = this.oCPU.DECWord(this.oParent.Var_68ea);
			if (this.oCPU.Flags.NE) goto L12bc;
			goto L130f;

		L1308:
			this.oCPU.STOSByte();
			this.oParent.Var_68ea = this.oCPU.DECWord(this.oParent.Var_68ea);
			if (this.oCPU.Flags.NE) goto L12bc;

			L130f:
			this.oParent.Var_68f2 = this.oCPU.DX.Word;
			this.oParent.Var_b26e = this.oCPU.SI.Word;

			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1208'");
		}

		public void F0_1000_1318_1(ushort value, ushort handle)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1318'(Undefined) at 0x1000:0x1318");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			if (this.oParent.Var_68e8 == 0x6afb)
			{
				// buffer is empty, fill it
				this.oCPU.BX.Word = this.oParent.Var_68f4;
				this.oCPU.CX.Low = 0x10;
				this.oCPU.CX.High = this.oParent.Var_68f6;
				this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.CX.High);
				this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
				this.oCPU.CX.Low = this.oCPU.CX.High;

			L1332:
				this.oCPU.CMPByte(this.oCPU.CX.Low, this.oParent.Var_68ee);
				if (this.oCPU.Flags.GE) goto L1359;

				this.oCPU.CMPWord(this.oCPU.SI.Word, Civilization.Constant_5528);
				if (this.oCPU.Flags.B) goto L134c;

				this.oCPU.PushWord(this.oCPU.BX.Word);
				this.oCPU.PushWord(this.oCPU.CX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);

				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				this.oCPU.PushWord(0x1345); // stack management - push return offset
											// Instruction address 0x1000:0x1341, size: 4
				this.oParent.Segment_2fa1.F0_2fa1_0644_FileRead(handle);
				this.oCPU.PopDWord(); // stack management - pop return offset and segment
				this.oCPU.CS.Word = 0x1000; // restore this function segment

				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.CX.Word = this.oCPU.PopWord();
				this.oCPU.BX.Word = this.oCPU.PopWord();

				this.oCPU.SI.Word = this.oParent.Var_b26e;

			L134c:
				this.oCPU.LODSWord();
				this.oParent.Var_68f4 = this.oCPU.AX.Word;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
				this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, 0x10);
				goto L1332;

			L1359:
				this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oParent.Var_68ee);
				this.oParent.Var_68f6 = this.oCPU.CX.Low;
				this.oCPU.AX.Word = this.oCPU.BX.Word;
				this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, this.oParent.Var_68f0);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				if (this.oCPU.Flags.L) goto L1377;
				this.oCPU.CX.Word = this.oCPU.DX.Word;
				this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68f8);
				this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x68fa);

				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteWord(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.BX.Word);

			L1377:
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa));
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L138c;
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
				this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f8));

				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteWord(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.BX.Word);

				goto L1377;

			L138c:
				this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f8));
				this.oCPU.WriteByte(this.oCPU.DS.Word, 0x68fa, this.oCPU.AX.Low);

				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteWord(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.AX.Word);

				this.oCPU.BX.Word = this.oCPU.DX.Word;
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
				this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f8), this.oCPU.AX.Low);
				this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68f8);
				this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), this.oCPU.AX.Word);
				this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
				this.oCPU.CMPWord(this.oCPU.DX.Word, this.oParent.Var_68f0);
				if (this.oCPU.Flags.LE) goto L13b5;
				this.oParent.Var_68ee++;
				this.oParent.Var_68f0 <<= 1;
				this.oParent.Var_68f0 |= 1;

			L13b5:
				this.oCPU.AX.Low = this.oParent.Var_68ee;
				this.oCPU.CMPByte(this.oCPU.AX.Low, this.oParent.Var_68ef);
				if (this.oCPU.Flags.LE) goto L13c1;

				// F0_1000_1270
				this.oParent.Var_68ee = 0x9;
				this.oParent.Var_68f0 = 0x1ff;
				this.oCPU.DX.Word = 0x100;
				this.oParent.Var_68f2 = this.oCPU.DX.Word;
				this.oCPU.AX.Word = 0xffff;
				this.oCPU.BX.Word = 0x0;
				this.oCPU.CX.Word = 0x800;

			L128a:
				this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), this.oCPU.AX.Word);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
				if (this.oCPU.Loop(this.oCPU.CX)) goto L128a;

				this.oCPU.AX.Low = 0x0;
				this.oCPU.BX.Word = 0x0;
				this.oCPU.CX.Word = 0x100;

			L129a:
				this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f8), this.oCPU.AX.Low);
				this.oCPU.AX.Low = this.oCPU.INCByte(this.oCPU.AX.Low);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
				if (this.oCPU.Loop(this.oCPU.CX)) goto L129a;

			L13c1:
				this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68f8, this.oCPU.CX.Word);
			}

			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oParent.Var_68e8);
			this.oParent.Var_68e8 += 2;

			this.oCPU.Log.ExitBlock("'F0_1000_1318'");
		}

		public void F0_2fa1_0696()
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_0696'(Cdecl, Far) at 0x2fa1:0x0696");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x58fb);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd), 0x0);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Low);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = 0x10;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06bd); // stack management - push return offset
			// Instruction address 0x2fa1:0x06b8, size: 5
			this.oParent.MSCAPI.int86();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x58fb, this.oCPU.AX.Word);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_0696'");
		}

		public void F0_2fa1_0728()
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_0728'(Cdecl, Far) at 0x2fa1:0x0728");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.AX.Word = 0;

			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_0728'");
		}

		public void F0_2fa1_085a()
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_085a'(Cdecl, Far) at 0x2fa1:0x085a");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xe);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x4200);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0884); // stack management - push return offset
			// Instruction address 0x2fa1:0x087f, size: 5
			this.oParent.MSCAPI.intdos();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0894;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_085a'");
			return;

		L0894:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_085a'");
		}
	}
}
