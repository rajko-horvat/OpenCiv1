using System;
using System.IO;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	/// <summary>
	/// Image loading functions - RLE and LZW compression was used
	/// </summary>
	public class ImageTools
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public ImageTools(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		#region New Image loading functions
		public void F0_2fa1_01a2_LoadBitmapOrPalette(short screenID, ushort xPos, ushort yPos, ushort filenamePtr, ushort palettePtr)
		{
			string filename = this.oCPU.DefaultDirectory +
				MSCAPI.GetDOSFileName(this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr)).ToUpper());
			this.oCPU.Log.EnterBlock($"F0_2fa1_01a2_LoadBitmapOrPalette(0x{screenID:x4}, 0x{xPos:x4}, 0x{yPos:x4}, " +
				$"'{filename}', 0x{palettePtr:x4})");

			if (screenID >= 0 && (Path.GetExtension(filename).Equals(".pic", StringComparison.InvariantCultureIgnoreCase) ||
				Path.GetExtension(filename).Equals(".map", StringComparison.InvariantCultureIgnoreCase)))
			{
				if (this.oParent.VGADriver.Screens.ContainsKey(screenID))
				{
					byte[] palette;
					ushort startPtr;
					this.oParent.VGADriver.Screens.GetValueByKey(screenID).LoadBitmap(filename, xPos, yPos, out palette);

					if (palette != null)
					{
						switch (palettePtr)
						{
							case 0:
								startPtr = 0xba08;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
								}
								break;
							case 1:
								startPtr = 0xba06;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
								}
								break;

							default:
								startPtr = palettePtr;
								for (int i = 0; i < palette.Length; i++)
								{
									this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
								}
								break;
						}
						if (palettePtr == 1 || palettePtr == 0xba06)
							this.oParent.VGADriver.SetColorsFromColorStruct(palette);
					}
				}
				else
				{
					throw new Exception($"The page {screenID} is not allocated");
				}
			}
			else
			{
				// function body
				byte[] palette;
				ushort startPtr;

				VGABitmap.PaletteFromFile(filename, out palette);
				if (palette != null)
				{
					switch (palettePtr)
					{
						case 0:
							startPtr = 0xba08;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
							}
							break;
						case 1:
							startPtr = 0xba06;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
							}
							break;

						default:
							startPtr = palettePtr;
							for (int i = 0; i < palette.Length; i++)
							{
								this.oCPU.WriteUInt8(this.oCPU.DS.Word, startPtr++, palette[i]);
							}
							break;
					}
					if (palettePtr == 1 || palettePtr == 0xba06)
						this.oParent.VGADriver.SetColorsFromColorStruct(palette);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2fa1_01a2_LoadBitmapOrPalette");
		}
		#endregion

		#region Old File management functions
		public void F0_2fa1_000a_OpenFile(ushort filenamePtr, ushort flags)
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_000a_OpenFile'(Cdecl, Far)");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1a);

			this.oParent.MSCAPI._dos_open(filenamePtr, flags,
				(ushort)(this.oCPU.BP.Word - 0x2));

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

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2fa1_000a_OpenFile'");
		}

		public void F0_2fa1_009e_CloseFile(short handle)
		{
			this.oCPU.Log.EnterBlock("'F0_2fa1_009e'(Cdecl, Far) at 0x2fa1:0x009e");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			if (handle != -1)
			{
				this.oParent.MSCAPI._dos_close(handle);

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

		public void F0_2fa1_0644_FileRead(short handle)
		{
			this.oCPU.Log.EnterBlock($"'F0_2fa1_0644_FileRead'({handle})");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			this.oParent.MSCAPI._dos_read(handle, 0xd936, 0x200, (ushort)(this.oCPU.BP.Word - 0x2));

			this.oParent.Var_b26e = 0xd936;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

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

			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
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
		#endregion

		#region Old Image loading functions
		public void F0_2fa1_044c_LoadIcon(ushort filenamePtr)
		{
			this.oCPU.Log.EnterBlock($"F0_2fa1_044c_LoadIcon('{this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr))}')");
			/*this.oCPU.CS.Word = 0x2fa1; // set this function segment

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

			short sHandle = (short)this.oCPU.AX.Word;
			//this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68da, usHandle);
			this.oParent.Var_b26e = OpenCiv1.Constant_5528;

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0473); // stack management - push return offset
										// Instruction address 0x2fa1:0x046e, size: 5
			F0_1000_108e_LoadPalette1(0, sHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
										//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x2fa1:0x047e, size: 5
			this.oParent.VGADriver.F0_VGA_0a78(this.oParent.Var_68e2, this.oParent.Var_68e4);

			this.oCPU.SI.Word = 0;
			goto L04a3;

		L048a:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0493); // stack management - push return offset
										// Instruction address 0x2fa1:0x048e, size: 5
			F0_1000_1208_1(0xe17e, sHandle);
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
			F0_2fa1_009e_CloseFile(sHandle);
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
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			this.oCPU.AX.Word = 0xffff; // !!! Or zero perhaps?

			// Far return
			this.oCPU.Log.ExitBlock("F0_2fa1_044c_LoadIcon");
		}

		public void F0_1000_108e_LoadPalette1(ushort palettePtr, short handle)
		{
			this.oCPU.Log.EnterBlock($"'F0_1000_108e'(Cdecl, Far)({palettePtr}, {handle})");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			// Instruction address 0x1000:0x1096, size: 5
			this.oParent.VGADriver.F0_VGA_0162_SetColorsFromColorStruct(0);

		L109e:
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L10b6;

			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x10af); // stack management - push return offset
										// Instruction address 0x1000:0x10ab, size: 4
			this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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
			this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L10f7;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x10f0); // stack management - push return offset
										// Instruction address 0x1000:0x10ec, size: 4
			this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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
			this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L111b;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1114); // stack management - push return offset
										// Instruction address 0x1000:0x1110, size: 4
			this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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
			this.oParent.VGADriver.F0_VGA_0162_SetColorsFromColorStruct(0xba06);

		L1135:
			goto L109e;

		L1138:
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, 0x1);
			this.oParent.Var_68f7 = this.oCPU.AX.High;
			this.oCPU.SI.Word = this.oParent.Var_b26e;
			this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L1157;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1150); // stack management - push return offset
										// Instruction address 0x1000:0x114c, size: 4
			this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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
			this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L1177;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1170); // stack management - push return offset
										// Instruction address 0x1000:0x116c, size: 4
			this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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
			this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L1197;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1190); // stack management - push return offset
										// Instruction address 0x1000:0x118c, size: 4
			this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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

		public void F0_1000_1227_1(short handle)
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
			this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L125a;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1253); // stack management - push return offset
										// Instruction address 0x1000:0x124f, size: 4
			this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(0xba06 + this.oCPU.BX.Word), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L128a;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.BX.Word = 0x0;
			this.oCPU.CX.Word = 0x100;

		L129a:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.INCByte(this.oCPU.AX.Low);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L129a;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1227'");
		}

		public void F0_1000_1208_1(ushort param1, short handle)
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

		public void F0_1000_1318_1(ushort value, short handle)
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

				this.oCPU.CMPWord(this.oCPU.SI.Word, OpenCiv1.Constant_5528);
				if (this.oCPU.Flags.B) goto L134c;

				this.oCPU.PushWord(this.oCPU.BX.Word);
				this.oCPU.PushWord(this.oCPU.CX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);

				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				this.oCPU.PushWord(0x1345); // stack management - push return offset
											// Instruction address 0x1000:0x1341, size: 4
				this.oParent.ImageTools.F0_2fa1_0644_FileRead(handle);
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
				this.oCPU.AX.Word = this.oParent.Var_68f8;
				this.oCPU.BX.Low = this.oParent.Var_68fa;

				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.BX.Word);

			L1377:
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xba06 + this.oCPU.BX.Word));
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L138c;
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
				this.oCPU.BX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word));

				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.BX.Word);

				goto L1377;

			L138c:
				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word));
				this.oParent.Var_68fa = this.oCPU.AX.Low;

				this.oParent.Var_68e8 -= 2;
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oParent.Var_68e8, this.oCPU.AX.Word);

				this.oCPU.BX.Word = this.oCPU.DX.Word;
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DX.Word);

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word), this.oCPU.AX.Low);
				this.oCPU.AX.Word = this.oParent.Var_68f8;
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(0xba06 + this.oCPU.BX.Word), this.oCPU.AX.Word);
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
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(0xba06 + this.oCPU.BX.Word), this.oCPU.AX.Word);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
				if (this.oCPU.Loop(this.oCPU.CX)) goto L128a;

				this.oCPU.AX.Low = 0x0;
				this.oCPU.BX.Word = 0x0;
				this.oCPU.CX.Word = 0x100;

			L129a:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(0xba08 + this.oCPU.BX.Word), this.oCPU.AX.Low);
				this.oCPU.AX.Low = this.oCPU.INCByte(this.oCPU.AX.Low);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x3);
				if (this.oCPU.Loop(this.oCPU.CX)) goto L129a;

			L13c1:
				this.oParent.Var_68f8 = this.oCPU.CX.Word;
			}

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oParent.Var_68e8);
			this.oParent.Var_68e8 += 2;

			this.oCPU.Log.ExitBlock("'F0_1000_1318'");
		}
		#endregion
	}
}
