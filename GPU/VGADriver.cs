using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.IO.Compression;
using IRB.VirtualCPU;
using OpenCiv1.GPU;
using IRB.Collections.Generic;
using System.Runtime.InteropServices;
using OpenCiv1.Properties;

namespace OpenCiv1
{
	public class VGADriver
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		private MainForm? oMainForm = null;
		public object VGALock = new object();
		private BDictionary<int, VGABitmap> aScreens = new BDictionary<int, VGABitmap>();
		private int iBitmapNextID = 0xb000;
		private BDictionary<int, VGABitmap> aBitmaps = new BDictionary<int, VGABitmap>();
		private Queue<int> aKeys = new Queue<int>();
		private CivFonts aFonts;

		private ushort Var_89e = 0;
		private ushort Var_8a0 = 0;
		private ushort Var_8a2 = 0;
		private ushort Var_8a4 = 0;
		private ushort Var_8a6 = 0;
		private ushort Var_8a8 = 0;
		private ushort Var_8aa = 0;
		private ushort Var_8ac = 0;
		private ushort Var_8ae = 0;
		private ushort Var_8b0 = 0;

		private ushort Var_15c0 = 0;
		private short Var_15c2_xPos = 0;
		private short Var_15c4_yPos = 0;
		private ushort Var_15ca_BufferX = 0;
		private ushort Var_15cc_BufferY = 0;
		private ushort Var_15ce_BufferWidth = 0;
		private ushort Var_15d0_BufferHeight = 0;
		private ushort Var_15d2_BufferFlag = 0;
		private ushort Var_15d4_ScreenID = 0;

		private byte[] Var_15d6_Buffer = new byte[512];

		public VGADriver(OpenCiv1 parent, MainForm form)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oMainForm = form;

			this.aScreens.Add(0, new VGABitmap()); // our Main screen

			byte[]? fonts = (byte[]?)Resources.ResourceManager.GetObject("Fonts_xml");

			if (fonts == null)
			{
				MessageBox.Show($"OpenCiv1 resource Fonts is missing.",
					"Resource missing", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				this.oCPU.Exit(-1);

				throw new Exception("Embedded resource missing"); // Fool compiler as Exit already throws an exception
			}

			Stream fonts1 = new GZipStream(new MemoryStream(fonts), CompressionMode.Decompress);
			this.aFonts = CivFonts.Deserialize(fonts1);
			fonts1.Close();
		}

		public CPU CPU
		{
			get { return this.oCPU; }
		}

		public BDictionary<int, VGABitmap> Screens
		{
			get { return this.aScreens; }
		}

		public BDictionary<int, VGABitmap> Bitmaps
		{
			get { return this.aBitmaps; }
		}

		public Queue<int> Keys
		{
			get { return this.aKeys; }
		}

		public Point ScreenMouseLocation
		{
			get
			{
				if (this.oMainForm != null)
					return this.oMainForm.ScreenMouseLocation;
				else
					return Point.Empty;
			}
		}

		public ushort ScreenMouseButtons
		{
			get
			{
				if (this.oMainForm != null)
				{
					ushort usTemp = 0;
					usTemp |= (ushort)(((this.oMainForm.ScreenMouseButtons & MouseButtons.Left) == MouseButtons.Left) ? 1 : 0);
					usTemp |= (ushort)(((this.oMainForm.ScreenMouseButtons & MouseButtons.Right) == MouseButtons.Right) ? 2 : 0);
					return usTemp;
				}
				else
					return 0;
			}
		}

		#region Memory and Initialization functions
		public ushort F0_VGA_0492_GetFreeMemory()
		{
			// function body
			this.oCPU.AX.Word = (ushort)((this.oCPU.Memory.FreeMemory.Size >> 4) & 0xffff);
			this.oCPU.Flags.C = true;

			return this.oCPU.AX.Word;
		}

		public ushort F0_VGA_04ae_AllocateScreen(ushort screenID)
		{
			// function body
			if (!this.aScreens.ContainsKey(screenID))
			{
				lock (this.VGALock)
				{
					VGABitmap bitmap = new VGABitmap();
					bitmap.Visible = false; // additional screens are not shown by default
					this.aScreens.Add(screenID, bitmap);
				}
				if (this.oMainForm != null)
					this.oMainForm.OnScreenCountChange();
			}

			this.oCPU.AX.Word = 0xa000; // return something to make underlying code happy

			return this.oCPU.AX.Word;
		}
		#endregion

		public void F0_VGA_0224_DrawBufferToScreen()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling: F0_VGA_0224_DrawBufferToScreen()");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("F0_VGA_0224_DrawBufferToScreen()");

			// function body
			if (this.Var_15d2_BufferFlag != 0)
			{
				lock (this.VGALock)
				{
					int iBufferPos = 0;
					VGABitmap mainScreen = this.aScreens.GetValueByKey(0);

					for (int i = 0; i < this.Var_15d0_BufferHeight; i++) // height
					{
						for (int j = 0; j < this.Var_15ce_BufferWidth; j++) // width
						{
							mainScreen.SetPixel(this.Var_15ca_BufferX + j, this.Var_15cc_BufferY + i, this.Var_15d6_Buffer[iBufferPos]);
							iBufferPos++;
						}
					}
				}
			}
			this.Var_15d2_BufferFlag = 0x0;

			// Far return
			this.oCPU.Log.ExitBlock("F0_VGA_0224_DrawBufferToScreen");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0270(short xPos, short yPos, ushort bufferPtr)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling: F0_VGA_0270({xPos}, {yPos}, 0x{bufferPtr:x4})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"F0_VGA_0270({xPos}, {yPos}, 0x{bufferPtr:x4})");

			// function body
			/*this.Var_15c0 = bitmapPtr;
			this.oCPU.AX.Word = xPos;
			this.Var_15c2_xPos = xPos;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(bitmapPtr, 0x0);
			this.Var_15c6 = this.oCPU.BX.Word;
			if (this.oCPU.BX.Word == 0) goto L0306;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L02a0;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.AX.Word = 0x0;

		L02a0:
			this.oCPU.CX.Word = 320;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L02ad;
			this.oCPU.BX.Word = this.oCPU.CX.Word;

		L02ad:
			this.Var_15ce_BufferWidth = this.oCPU.BX.Word;
			this.Var_15ca_BufferX = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x200;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = yPos;
			this.Var_15c4_yPos = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(bitmapPtr, 0x2);
			this.Var_15c8 = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0306;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NS) goto L02db;
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.AX.Word = 0x0;

		L02db:
			this.oCPU.CX.Word = 0xc8;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L0306;
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.BE) goto L02e8;
			this.oCPU.BX.Word = this.oCPU.CX.Word;

		L02e8:
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.BE) goto L02ee;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

		L02ee:
			this.Var_15d0_BufferHeight = this.oCPU.BX.Word;
			this.Var_15cc_BufferY = this.oCPU.AX.Word;
			this.Var_15d2_BufferFlag = 1;
			
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0303); // stack management - push return offset
			// Instruction address 0x0000:0x0300, size: 3
			F0_VGA_030e_FillBuffer(0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L0303:*/
			// Far return
			this.oCPU.Log.ExitBlock("F0_VGA_0270");
			this.oCPU.Log = oTempLog;
			return;

		/*L0306:
			this.Var_15d2_BufferFlag = 0;
			goto L0303;*/
		}

		public void F0_VGA_030e_FillBuffer(ushort screenID)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling: F0_VGA_030e_FillBuffer({screenID})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"F0_VGA_030e_FillBuffer({screenID})");

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);

			this.Var_15d4_ScreenID = screenID;

			if (this.Var_15d2_BufferFlag != 0)
			{
				if (this.aScreens.ContainsKey(screenID))
				{
					lock (this.VGALock)
					{
						VGABitmap screen = this.aScreens.GetValueByKey(screenID);

						int iBufferPos = 0;

						for (int i = 0; i < this.Var_15d0_BufferHeight; i++)
						{
							for (int j = 0; j < this.Var_15ce_BufferWidth; j++)
							{
								this.Var_15d6_Buffer[iBufferPos] = screen.GetPixel(this.Var_15ca_BufferX + j, this.Var_15cc_BufferY + i);
								iBufferPos++;
							}
						}
					}

					this.oCPU.PushWord(199);
					this.oCPU.PushWord(319);
					this.oCPU.PushWord(0);
					this.oCPU.PushWord(0);
					this.oCPU.PushWord(this.Var_15d4_ScreenID);
					ushort rectPtr = this.oCPU.SP.Word;

					// Instruction address 0x0000:0x0380, size: 3
					F0_VGA_0c3e_DrawBitmapToScreen(rectPtr, this.Var_15c2_xPos, this.Var_15c4_yPos, this.Var_15c0);

					// free Rect structure
					this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
				}
				else
				{
					throw new Exception($"The screen {screenID} is not allocated");
				}
			}
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_VGA_030e_FillBuffer");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_063c(ushort screenID)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling: F0_VGA_063c(0x{screenID:x4})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"F0_VGA_063c(0x{screenID:x4})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);

			if (screenID != 0)
			{
				this.oCPU.PushWord(0); // stack management - push return segment, ignored
				this.oCPU.PushWord(0x0650); // stack management - push return offset
				// Instruction address 0x0000:0x064d, size: 3
				F0_VGA_030e_FillBuffer(screenID);
				this.oCPU.PopDWord(); // stack management - pop return offset and segment

				if (this.aScreens.ContainsKey(0))
				{
					if (this.aScreens.ContainsKey(screenID))
					{
						lock (this.VGALock)
						{
							VGABitmap mainScreen = this.aScreens.GetValueByKey(0);
							VGABitmap screen = this.aScreens.GetValueByKey(screenID);

							mainScreen.DrawImage(Point.Empty, screen, new Rectangle(0, 0, 320, 100), false);
						}
					}
					else
					{
						throw new Exception($"The screen {screenID} is not allocated");
					}
				}
				else
				{
					throw new Exception($"The screen 0 is not allocated");
				}
			}

			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_063c'");
			this.oCPU.Log = oTempLog;
		}

		#region Icon functions
		public void F0_VGA_0a78(ushort param1, ushort param2)
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0a78'({param1}, {param2})");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock($"F0_VGA_0a78({param1}, {param2})");

			// function body
			if (this.Var_8a4 <= this.Var_8a0)
			{
				this.Var_89e = 0;
				this.Var_8a0 = 0;

				this.oCPU.AX.Word = 0x0;
			}
			else
			{
				this.Var_8a6 = (ushort)(this.Var_8a4 - this.Var_8a0);
				if (this.Var_8a6 >= 0x1000)
				{
					this.Var_8a6 = 0xfff;
				}

				this.Var_8a6 = this.oCPU.SHLWord(this.Var_8a6, 4);

				this.Var_8b0 = param1;
				this.oCPU.WriteUInt16(this.Var_8a0, this.Var_89e, param1);
				this.Var_89e += 2;

				this.Var_8ae = param2;
				this.oCPU.WriteUInt16(this.Var_8a0, this.Var_89e, param2);
				this.Var_89e += 2;

				this.oCPU.AX.Word = 1;
			}

			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0a78'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0ac6()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0ac6'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0ac6'");

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.Temp.Word = this.Var_89e;
			this.Var_89e = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 15);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 4);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.Var_8a0);
			this.oCPU.Temp.Word = this.Var_8a0;
			this.Var_8a0 = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0ac6'");
			this.oCPU.Log = oTempLog;
		}

		public void F0_VGA_0ae3()
		{
			LogWrapper oTempLog = this.oCPU.Log;
			this.oCPU.Log.WriteLine($"// Calling 'F0_VGA_0ae3'");
			this.oCPU.Log = this.oParent.VGADriverLog;
			this.oCPU.Log.EnterBlock("'F0_VGA_0ae3'");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			// LES
			this.oCPU.DI.Word = this.Var_89e;
			this.oCPU.ES.Word = this.Var_8a0;
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0af9;
			goto L0b81;

		L0af9:
			this.oCPU.AX.Word = this.Var_8b0;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.Var_8a6);
			if (this.oCPU.Flags.BE) goto L0b17;
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, 0x2, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0x2)));
			this.oCPU.AX.Word = 0x0;
			this.Var_8a4 = this.oCPU.AX.Word;
			goto L0b81;

		L0b17:
			this.oCPU.AX.Word = 0x0;
			this.Var_8a8 = this.oCPU.AX.Word;
			this.Var_8aa = this.oCPU.AX.Word;
			this.Var_8ac = this.oCPU.AX.Word;
			this.oCPU.BP.Word = this.oCPU.DI.Word;
			this.oCPU.STOSWord();
			this.oCPU.STOSWord();
			this.oCPU.CX.Word = this.Var_8b0;

		L0b2e:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0b3d;
			this.Var_8aa = 0;
			goto L0b54;

		L0b3d:
			this.oCPU.CMPWord(this.Var_8ac, 0x0);
			if (this.oCPU.Flags.NE) goto L0b4f;
			this.Var_8a8++;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0b2e;
			goto L0b5c;

		L0b4f:
			this.Var_8aa++;

		L0b54:
			this.Var_8ac++;
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0b2e;

			L0b5c:
			this.oCPU.AX.Word = this.Var_8ac;
			this.oCPU.BX.Word = this.Var_8a8;
			this.oCPU.CX.Word = this.Var_8aa;
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0b72;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.CX.Word);

		L0b72:
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.BP.Word + 0x0), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.BP.Word + 0x2), this.oCPU.BX.Word);
			this.Var_89e = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.ES.Word;

		L0b81:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_VGA_0ae3'");
			this.oCPU.Log = oTempLog;
		}
		#endregion

		#region Palette functions
		public void F0_VGA_010c_SetColorsByIndexArray(ushort indexArrayPtr)
		{
			// function body
			lock (this.VGALock)
			{
				Color[] aColors = new Color[16];

				for (int i = 0; i < 16; i++)
				{
					aColors[i] = VGABitmap.Palette1[this.oCPU.ReadUInt8(this.oCPU.DS.Word, indexArrayPtr)];

					indexArrayPtr++;
				}

				// set colors to all planes, as this is what original code does
				for (int i = 0; i < this.aScreens.Count; i++)
				{
					this.aScreens[i].Value.SetColorsFromArray(aColors, 0, 0, 16);
				}
			}
		}

		public void SetColor(int index, Color color)
		{
			lock (this.VGALock)
			{
				// set colors to all planes, as this is what original code does
				for (int i = 0; i < this.aScreens.Count; i++)
				{
					this.aScreens[i].Value.SetColor(index, color);
				}
			}
		}

		public void F0_VGA_0162_SetColorsFromColorStruct(ushort colorStructPtr)
		{
			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, colorStructPtr) == 0x304d)
			{
				int iFrom = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + 0x4));
				int iTo = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + 0x5));
				int iCount = (iTo - iFrom) + 1;
				colorStructPtr += 6;

				lock (this.VGALock)
				{
					Color[] aColors = new Color[iCount];

					for (int i = 0; i < iCount; i++)
					{
						aColors[i] = VGABitmap.Color18ToColor(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + (i * 3))),
							this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + (i * 3) + 1)),
						this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(colorStructPtr + (i * 3) + 2)));

						this.oCPU.Log.WriteLine($"Setting palette index {iFrom + i}, #{aColors[i].A:x2}{aColors[i].R:x2}{aColors[i].G:x2}{aColors[i].B:x2}");
					}

					// set colors to all planes, as this is what original code does
					for (int i = 0; i < this.aScreens.Count; i++)
					{
						this.aScreens[i].Value.SetColorsFromArray(aColors, iFrom, iFrom, iCount);
					}
				}
			}
		}

		public void SetColorsFromColorStruct(byte[] colorStruct)
		{
			int iStructPos = 0;

			if (colorStruct[iStructPos] == 0x4d && colorStruct[iStructPos + 1] == 0x30)
			{
				int iFrom = colorStruct[iStructPos + 4];
				int iTo = colorStruct[iStructPos + 5];
				int iCount = (iTo - iFrom) + 1;
				iStructPos += 6;

				lock (this.VGALock)
				{
					Color[] aColors = new Color[iCount];

					for (int i = 0; i < iCount; i++)
					{
						aColors[i] = VGABitmap.Color18ToColor(colorStruct[iStructPos + (i * 3)],
							colorStruct[iStructPos + (i * 3) + 1],
							colorStruct[iStructPos + (i * 3) + 2]);
					}

					// set colors to all screens, as this is what original code does
					for (int i = 0; i < this.aScreens.Count; i++)
					{
						this.aScreens[i].Value.SetColorsFromArray(aColors, iFrom, iFrom, iCount);
					}
				}
			}
		}
		#endregion

		#region Drawing functions
		public void F0_VGA_06b7_DrawScreenToMainScreen(ushort screenID, ushort param1)
		{
			// function body
			// this is either random fade in image, or a scrolling from right to left
			if (screenID != 0)
			{
				if (this.aScreens.ContainsKey(screenID))
				{
					lock (this.VGALock)
					{
						VGABitmap screen0 = this.aScreens.GetValueByKey(0);

						screen0.DrawImage(this.aScreens.GetValueByKey(screenID));
					}
				}
				else
				{
					throw new Exception($"The screen {screenID} is not allocated");
				}
			}
		}

		public void F0_VGA_07d8_DrawImage(ushort srcRectPtr, int xFrom, int yFrom, int width, int height, ushort destRectPtr, int xTo, int yTo)
		{
			CivRectangle rectFrom = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, srcRectPtr));
			int iXOffsetFrom = rectFrom.X + xFrom;
			int iYOffsetFrom = rectFrom.Y + yFrom;

			CivRectangle rectTo = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, destRectPtr));
			int iXOffsetTo = rectTo.X + xTo;
			int iYOffsetTo = rectTo.Y + yTo;

			// function body
			if (this.aScreens.ContainsKey(rectFrom.ScreenID))
			{
				VGABitmap srcBitmap = this.aScreens.GetValueByKey(rectFrom.ScreenID);

				if (this.aScreens.ContainsKey(rectTo.ScreenID))
				{
					lock (this.VGALock)
					{
						VGABitmap destBitmap = this.aScreens.GetValueByKey(rectTo.ScreenID);

						destBitmap.DrawImage(iXOffsetTo, iYOffsetTo, srcBitmap, new Rectangle(iXOffsetFrom, iYOffsetFrom, width, height), false);
					}
				}
				else
				{
					throw new Exception($"The screen {rectTo.ScreenID} is not allocated");
				}
			}
			else
			{
				throw new Exception($"The screen {rectFrom.ScreenID} is not allocated");
			}
		}

		public ushort F0_VGA_0b85_ScreenToBitmap(ushort screenID, ushort xPos, ushort yPos, ushort width, ushort height)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.VGALock)
				{
					VGABitmap screen = this.aScreens.GetValueByKey(screenID);
					VGABitmap bitmap = new VGABitmap(width, height);
					Rectangle rect = new Rectangle(xPos, yPos, width, height);
					screen.CopyPalette(bitmap);

					bitmap.DrawImage(Point.Empty, screen, rect, false);

					this.aBitmaps.Add(this.iBitmapNextID, bitmap);

					//bitmap.Bitmap.Save($"Bitmaps{Path.DirectorySeparatorChar}Image_{this.iBitmapNextID:x4}.png", ImageFormat.Png);

					this.oCPU.AX.Word = (ushort)this.iBitmapNextID;
					this.iBitmapNextID++;
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}

			return this.oCPU.AX.Word;
		}

		public void F0_VGA_0c3e_DrawBitmapToScreen(ushort rectPtr, int xPos, int yPos, ushort bitmapPtr)
		{
			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				if (this.aBitmaps.ContainsKey(bitmapPtr))
				{
					lock (this.VGALock)
					{
						VGABitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);
						VGABitmap bitmap = this.aBitmaps.GetValueByKey(bitmapPtr);

						screen.DrawImage(rect.X + xPos, rect.Y + yPos, bitmap, true);
					}
				}
				else
				{
					this.oCPU.Log.WriteLine($"The bitmap 0x{bitmapPtr:x4} is not allocated");
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}

		public void F0_VGA_0d47_DrawBitmapToScreen(ushort rectPtr, int xPos, int yPos, int bitmapPtr)
		{
			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				if (this.aBitmaps.ContainsKey(bitmapPtr))
				{
					lock (this.VGALock)
					{
						VGABitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);
						VGABitmap bitmap = this.aBitmaps.GetValueByKey(bitmapPtr);

						screen.DrawImage(rect.X + xPos, rect.Y + yPos, bitmap, true);
					}
				}
				else
				{
					this.oCPU.Log.WriteLine($"The bitmap 0x{bitmapPtr:x4} is not allocated");
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}

		public ushort LoadIcon(string filename)
		{
			byte[] aTemp;
			VGABitmap? bitmap = VGABitmap.FromFile(this.oCPU.DefaultDirectory + filename.ToUpper(), out aTemp);

			if (bitmap != null)
			{
				this.aBitmaps.Add(this.iBitmapNextID, bitmap);

				this.oCPU.AX.Word = (ushort)this.iBitmapNextID;
				this.iBitmapNextID++;
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}
			
			return this.oCPU.AX.Word;
		}

		public ushort F0_VGA_038c_GetPixel(ushort screenID, int xPos, int yPos)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.VGALock)
				{
					this.oCPU.AX.Word = this.aScreens.GetValueByKey(screenID).GetPixel(xPos, yPos);
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}

			return this.oCPU.AX.Word;
		}

		public void F0_VGA_0550_SetPixel(ushort screenID, int xPos, int yPos, byte frontColor, byte pixelMode)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.VGALock)
				{
					VGABitmap screen = this.aScreens.GetValueByKey(screenID);

					screen.SetPixel(xPos, yPos, frontColor, (PixelWriteModeEnum)pixelMode);
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}
		}

		public void F0_VGA_0599_DrawLine(ushort rectPtr, int x1, int y1, int x2, int y2, ushort mode)
		{
			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				lock (this.VGALock)
				{
					VGABitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);

					x1 += rect.X;
					y1 += rect.Y;
					x2 += rect.X;
					y2 += rect.Y;

					screen.DrawLine(x1, y1, x2, y2, (byte)(mode & 0xff), (PixelWriteModeEnum)((mode & 0xff00) >> 8));
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}

		public void F0_VGA_040a_FillRectangle(int screenID, Rectangle rect, byte frontColor, byte pixelMode)
		{
			// function body
			if (this.aScreens.ContainsKey(screenID))
			{
				lock (this.VGALock)
				{
					this.aScreens.GetValueByKey(screenID).FillRectangle(rect, frontColor, (PixelWriteModeEnum)pixelMode);
				}
			}
			else
			{
				throw new Exception($"The screen {screenID} is not allocated");
			}
		}

		public void F0_VGA_009a_ReplaceColor(ushort rectPtr, int xPos, int yPos, int width, int height, byte oldColor, byte newColor)
		{
			// function body
			lock (this.VGALock)
			{
				CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));
				int iTop = rect.X + xPos;
				int iLeft = rect.Y + yPos;

				if (this.aScreens.ContainsKey(rect.ScreenID))
				{
					this.aScreens.GetValueByKey(rect.ScreenID).ReplaceColor(new Rectangle(iTop, iLeft, width, height), oldColor, newColor);
				}
				else
				{
					throw new Exception($"The screen {rect.ScreenID} is not allocated");
				}
			}
		}
		#endregion

		#region Fonts
		public ushort F0_VGA_115d_GetCharWidth(ushort fontID, byte ch)
		{
			// function body
			this.oCPU.AX.Word = (ushort)GetDrawStringSize(fontID, new string((char)ch, 1)).Width;

			return this.oCPU.AX.Word;
		}

		public Size GetDrawStringSize(int fontID, string text)
		{
			int iWidth = 0;
			int iHeight = 0;

			if (!this.aFonts.ContainsKey(fontID))
			{
				fontID = 1; // default font
			}

			CivFont font = this.aFonts.GetValueByKey(fontID);

			for (int i = 0; i < text.Length; i++)
			{
				char ch = text[i];
				CivFontCharacter fontCh;

				//if (i > 0)
				iWidth += font.CharacterWidthSpacing;

				if (font.Characters.ContainsKey(ch))
				{
					fontCh = font.Characters.GetValueByKey(ch);
				}
				else
				{
					// unknown char, use '?'
					fontCh = font.Characters.GetValueByKey('?');
				}
				iWidth += fontCh.Width;
				iHeight = Math.Max(iHeight, fontCh.Height);
				iHeight += font.LineSpacing;
			}

			return new Size(iWidth, iHeight);
		}

		public ushort F0_VGA_11ae_GetTextHeight(ushort fontID)
		{
			// function body
			this.oCPU.AX.Word = (ushort)GetDrawStringSize(fontID, "?").Height;

			return this.oCPU.AX.Word;
		}

		public void F0_VGA_11d7_DrawString(ushort rectPtr, int xPos, int yPos, ushort stringPtr)
		{
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));
			string text = this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			if (!this.aFonts.ContainsKey(rect.FontID))
			{
				rect.FontID = 1; // default font
			}

			// function body
			CivFont font = this.aFonts.GetValueByKey(rect.FontID);

			if (this.aScreens.ContainsKey(rect.ScreenID))
			{
				lock (this.VGALock)
				{
					VGABitmap screen = this.aScreens.GetValueByKey(rect.ScreenID);
					Rectangle rect1 = new Rectangle(rect.X + xPos, rect.Y + yPos, rect.Width, rect.Height);

					screen.DrawString(text, font, rect1, rect.FrontColor, rect.BackColor, (PixelWriteModeEnum)rect.PixelMode);
				}
			}
			else
			{
				throw new Exception($"The screen {rect.ScreenID} is not allocated");
			}
		}
		#endregion
	}
}
