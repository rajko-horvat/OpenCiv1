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

		#region Old Image loading functions
		public void F0_2fa1_044c_LoadIcon(ushort filenamePtr)
		{
			this.oCPU.Log.EnterBlock($"F0_2fa1_044c_LoadIcon('{this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, filenamePtr))}')");
			/*
			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x045d); // stack management - push return offset
										// Instruction address 0x2fa1:0x045a, size: 3
			F0_2fa1_000a_OpenFile(filenamePtr, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			short sHandle = (short)this.oCPU.AX.Word;
			//this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68da, usHandle);
			this.oParent.Var_b26e = OpenCiv1.Constant_5528;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0473); // stack management - push return offset
										// Instruction address 0x2fa1:0x046e, size: 5
			F0_1000_108e_LoadPalette1(0, sHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x2fa1:0x047e, size: 5
			this.oParent.VGADriver.F0_VGA_0a78(this.oParent.Var_68e2, this.oParent.Var_68e4);

			this.oCPU.SI.Word = 0;
			goto L04a3;

		L048a:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0493); // stack management - push return offset
										// Instruction address 0x2fa1:0x048e, size: 5
			F0_1000_1208_1(0xe17e, sHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.AX.Word = 0xe17e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x049f); // stack management - push return offset
			// Instruction address 0x2fa1:0x049a, size: 5
			this.oParent.VGADriver.F0_VGA_0ae3();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);

		L04a3:
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oParent.Var_68e4);
			if (this.oCPU.Flags.L) goto L048a;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x04b3); // stack management - push return offset
										// Instruction address 0x2fa1:0x04b0, size: 3
			F0_2fa1_009e_CloseFile(sHandle);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			//this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x04bb); // stack management - push return offset
			// Instruction address 0x2fa1:0x04b6, size: 5
			this.oParent.VGADriver.F0_VGA_0ac6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			this.oCPU.AX.Word = 0xffff; // !!! Or zero perhaps?

			// Far return
			this.oCPU.Log.ExitBlock("F0_2fa1_044c_LoadIcon");
		}
		#endregion
	}
}
