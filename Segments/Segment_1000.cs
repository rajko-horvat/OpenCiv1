using System;
using System.Drawing;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_1000
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Segment_1000(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_1000_0000()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0000'(Cdecl, Far) at 0x1000:0x0000");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.AX.Low = 0x1;
			this.oCPU.Temp.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5a);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5a, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L004f;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4c, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x54, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x42, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x44, 0x0);

			this.oCPU.PushWord(0x0034); // stack management - push return offset
			// Instruction address 0x1000:0x0031, size: 3
			F0_1000_0276();
			this.oCPU.PopWord(); // stack management - pop return offset
			
			this.oCPU.EnableTimer = true;

		L004f:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0000'");
		}

		public void F0_1000_0051()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0051'(Cdecl, Far) at 0x1000:0x0051");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.AX.Low = 0x0;
			this.oCPU.Temp.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5a);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5a, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0075;

		L0075:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0051'");
		}

		public void F0_1000_01a7_Timer()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_01a7_Timer'");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = this.oCPU.SP.Word;
			this.oCPU.BX.Word = this.oCPU.SS.Word;
			this.oCPU.SS.Word = 0x1000;
			this.oCPU.SP.Word = 0x1a1;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.DS.Word = 0x3b01;

			this.oCPU.WriteUInt32(this.oCPU.DS.Word, 0x42, (uint)(this.oCPU.ReadUInt32(this.oCPU.DS.Word, 0x42) +
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x48)));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x54, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x54)));
			if (this.oCPU.Flags.E)
			{
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x54, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4c));

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x59, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x59)));
				if (this.oCPU.Flags.E)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x59, 0x14);

					if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x58) != 0)
					{
						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x58, 0x0);
					}
					else
					{
						if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x46) != this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x48))
						{
							this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x48, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x46));
							this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4a, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4a)));
							this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x56, 0x20);
						}
					}
				}

				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return overlaySegment
				this.oCPU.PushWord(0x01e0); // stack management - push return offset
				// Instruction address 0x1000:0x01db, size: 5
				F0_1000_0345();
				this.oCPU.PopDWord(); // stack management - pop return offset and overlaySegment
				this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment
			}

			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4c) != 0x1)
			{
				// sound driver call
				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return overlaySegment
				this.oCPU.PushWord(0x01ec); // stack management - push return offset
				// Instruction address 0x1000:0x01e7, size: 5
				F0_1000_0a47();
				this.oCPU.PopDWord(); // stack management - pop return offset and overlaySegment
				this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment
			}

			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x44) != 0x0)
			{
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x44, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x44)));
			}

			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.SS.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.AX.Word;
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// IRET - Pop flags and Far return
			this.oCPU.Log.ExitBlock("'F0_1000_01a7_Timer'");
			return;
		}

		public void F0_1000_0276()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0276'(Cdecl, Near) at 0x1000:0x0276");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushF();
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x59, 0x1);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x58, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x50, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x52, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 100;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = 0x10;

		L0292:
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.AX.Word = 200;
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x50, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x50), this.oCPU.BX.Word));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x52, this.oCPU.ADCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x52), 0x0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0292;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x50);
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x52);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x42, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x42), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x44, this.oCPU.ADCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x44), this.oCPU.DX.Word));
			this.oCPU.CX.Word = 0x10;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x50, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.BX.Word = 0xf89;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.B) goto L02df;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x6);
			if (this.oCPU.Flags.A) goto L02df;
			goto L02ed;

		L02df:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x58, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x50, 0x4dae);
			this.oCPU.AX.Word = 0x5;

		L02ed:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4e, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4c), 0x1);
			if (this.oCPU.Flags.E) goto L02fa;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4c, this.oCPU.AX.Word);

		L02fa:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x50);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4c));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x48, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.PopF();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0276'");
		}

		public void F0_1000_033e()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_033e'(Cdecl, Far) at 0x1000:0x033e");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.Temp.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5c, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_033e'");
		}

		public void F0_1000_0345()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0345'(Cdecl, Far) at 0x1000:0x0345");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5c, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c)));

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return overlaySegment
			this.oCPU.PushWord(0x034e); // stack management - push return offset
			// Instruction address 0x1000:0x0349, size: 5
			F0_1000_0631();
			this.oCPU.PopDWord(); // stack management - pop return offset and overlaySegment
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return overlaySegment
			this.oCPU.PushWord(0x0353); // stack management - push return offset
			// Instruction address 0x1000:0x034e, size: 5
			F0_1000_044a();
			this.oCPU.PopDWord(); // stack management - pop return offset and overlaySegment
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4e), 0x4);
			if (this.oCPU.Flags.NE) goto L036c;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5e, this.oCPU.SUBByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5e), 0x1));
			if (this.oCPU.Flags.G) goto L036c;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5e, 0x7);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;

		L036c:
			// sound driver call
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return overlaySegment
			this.oCPU.PushWord(0x0371); // stack management - push return offset
			// Instruction address 0x1000:0x036c, size: 5
			F0_1000_0a40();
			this.oCPU.PopDWord(); // stack management - pop return offset and overlaySegment
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.S) goto L0378;
			if (this.oCPU.Flags.NE) goto L037d;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;

		L0378:
			// Instruction address 0x1000:0x0378, size: 5
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4c, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x59, 0x1);

			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;

		L037d:
			// Instruction address 0x1000:0x037d, size: 5
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4e);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4c, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x50);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x59, 0x1);

			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;
		}

		public void F0_1000_0382()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0382'(Cdecl, Far) at 0x1000:0x0382");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = 0x35cf;
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x0, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0x8);
			if (this.oCPU.Flags.AE) goto L03f5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L03f5;
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);

			if (this.oCPU.DX.Word > 0x10)
			{
				this.oCPU.DX.Word = 0x10;
			}

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4), (ushort)(this.oCPU.DX.Word * 3));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6), this.oCPU.AX.Low);

			this.oCPU.CLI();
			if (this.oParent.VGADriver.Screens.ContainsKey(0))
			{
				lock (this.oParent.VGADriver.VGALock)
				{
					VGABitmap screen = this.oParent.VGADriver.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x9));

					for (int i = 0; i < this.oCPU.DX.Word; i++)
					{
						Color color = VGABitmap.ColorToColor18(screen.GetColor(i + this.oCPU.AX.Low));

						this.oCPU.Memory.WriteUInt8(uiBufferPos++, color.R);
						this.oCPU.Memory.WriteUInt8(uiBufferPos++, color.G);
						this.oCPU.Memory.WriteUInt8(uiBufferPos++, color.B);
					}
				}
			}
			else
			{
				throw new Exception($"The screen {0} is not allocated");
			}
			this.oCPU.STI();

			this.oCPU.ES.Word = this.oCPU.DS.Word;
			this.oCPU.DI.Word = (ushort)(this.oCPU.BX.Word + 0x9 + (this.oCPU.DX.Word * 3));

			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, 0x3);
			// LEA
			this.oCPU.SI.Word = (ushort)(this.oCPU.BX.Word + 0x9);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7), this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), 0x0);

		L03f5:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0382'");
		}

		public void F0_1000_03fa()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_03fa'(Cdecl, Far) at 0x1000:0x03fa");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = 0x35cf;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.AE) goto L0428;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.AX.Word = 0x3;
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), this.oCPU.AX.Low);

		L0428:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_03fa'");
		}

		public void F0_1000_042b()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_042b'(Cdecl, Far) at 0x1000:0x042b");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = 0x35cf;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0x8);
			if (this.oCPU.Flags.AE) goto L0447;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), 0x0);

		L0447:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_042b'");
		}

		public void F0_1000_044a()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_044a'(Cdecl, Far) at 0x1000:0x044a");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = 0x35cf;
			// LEA
			this.oCPU.DI.Word = 0x2;

		L0456:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L04a5;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L0456;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8))));
			if (this.oCPU.Flags.NE) goto L0456;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word));
			if (this.oCPU.Flags.GE) goto L047d;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.CX.Word);

		L047d:
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.L) goto L0484;
			this.oCPU.SI.Word = 0x0;

		L0484:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), this.oCPU.SI.Word);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BX.Word + 0x9);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6));

			if (this.oParent.VGADriver.Screens.ContainsKey(0))
			{
				lock (this.oParent.VGADriver.VGALock)
				{
					VGABitmap screen = this.oParent.VGADriver.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.SI.Word);
					int iCount = this.oCPU.CX.Word / 3;

					for (int i = 0; i < iCount; i++)
					{
						byte red = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte green = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte blue = this.oCPU.Memory.ReadUInt8(uiBufferPos++);

						screen.SetColor(i + this.oCPU.AX.Low, VGABitmap.Color18ToColor(red, green, blue));
					}
				}
			}
			else
			{
				throw new Exception($"The screen {0} is not allocated");
			}
			/*this.oCPU.DX.Word = 0x3c8;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6));
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = 0x3c9;			
			this.oCPU.REPEOUTSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.CX);*/
			goto L0456;

		L04a5:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_044a'");
		}

		public void F0_1000_04aa()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_04aa'(Cdecl, Far) at 0x1000:0x04aa");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = 0x300;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x6);
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);

			// Instruction address 0x1000:0x04c0, size: 3
			F0_1000_0554_ReadCurrentPalette();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(0x04c9); // stack management - push return offset
			// Instruction address 0x1000:0x04c6, size: 3
			F0_1000_050c();
			this.oCPU.PopWord(); // stack management - pop return offset

		L04c9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68), 0x0);
			if (this.oCPU.Flags.NE) goto L04c9;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_04aa'");
		}

		public void F0_1000_04d4()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_04d4'(Cdecl, Far) at 0x1000:0x04d4");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.High = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.BX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.CX.Word = 0x100;

		L04eb:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1), this.oCPU.AX.High);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.BX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x3);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L04eb;

			// Instruction address 0x1000:0x04f8, size: 3
			F0_1000_0554_ReadCurrentPalette();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(0x0501); // stack management - push return offset
			// Instruction address 0x1000:0x04fe, size: 3
			F0_1000_050c();
			this.oCPU.PopWord(); // stack management - pop return offset

		L0501:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68), 0x0);
			if (this.oCPU.Flags.NE) goto L0501;

			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_04d4'");
		}

		public void F0_1000_050c()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_050c'(Cdecl, Near) at 0x1000:0x050c");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);

			this.oCPU.AX.High = 0x6;
			this.oCPU.MULByte(this.oCPU.AX, this.oCPU.AX.High);
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x66);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L051f;

			// Instruction address 0x1000:0x0519, size: 3
			F0_1000_0573_MeasurePalettePerformance();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x66, this.oCPU.AX.Word);

		L051f:
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Word = 0xe;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.E) goto L052d;
			this.oCPU.AX.Word = 0x100;

		L052d:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x64, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x62, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x62, this.oCPU.NEGWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x62)));
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.BP.Word);
			this.oCPU.CX.High = this.oCPU.DX.Low;
			this.oCPU.CX.Low = this.oCPU.AX.High;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6c, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6a, this.oCPU.AX.Word);

			this.oCPU.PushWord(0x054f); // stack management - push return offset
			// Instruction address 0x1000:0x054c, size: 3
			F0_1000_05b7();
			this.oCPU.PopWord(); // stack management - pop return offset

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68, this.oCPU.BP.Word);

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_050c'");
		}

		public void F0_1000_0554_ReadCurrentPalette()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0554_ReadCurrentPalette()");

			// function body
			this.oCPU.CLI();
			if (this.oParent.VGADriver.Screens.ContainsKey(0))
			{
				lock (this.oParent.VGADriver.VGALock)
				{
					VGABitmap screen = this.oParent.VGADriver.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, 0xbd06);

					for (int i = 0; i < 0x100; i++)
					{
						Color color = VGABitmap.ColorToColor18(screen.GetColor(i));

						this.oCPU.Memory.WriteUInt8(uiBufferPos++, color.R);
						this.oCPU.Memory.WriteUInt8(uiBufferPos++, color.G);
						this.oCPU.Memory.WriteUInt8(uiBufferPos++, color.B);
					}
				}
			}
			else
			{
				throw new Exception($"The screen {0} is not allocated");
			}
			this.oCPU.STI();

			// Near return
			this.oCPU.Log.ExitBlock("F0_1000_0554_ReadCurrentPalette");
		}

		public void F0_1000_0573_MeasurePalettePerformance()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0573'(Cdecl, Near) at 0x1000:0x0573");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x60, 0xffff);

			this.oCPU.CLI();
			if (this.oParent.VGADriver.Screens.ContainsKey(0))
			{
				lock (this.oParent.VGADriver.VGALock)
				{
					VGABitmap screen = this.oParent.VGADriver.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, 0xbd06);

					for (int i = 0; i < 10; i++)
					{
						byte red = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte green = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte blue = this.oCPU.Memory.ReadUInt8(uiBufferPos++);

						screen.SetColor(i, VGABitmap.Color18ToColor(red, green, blue));
					}
				}
			}
			else
			{
				throw new Exception($"The screen {0} is not allocated");
			}
			this.oCPU.STI();

			this.oCPU.AX.Word = 6553 * 10; // maximum performance

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0573'");
		}

		public void F0_1000_05b7()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_05b7'(Cdecl, Near) at 0x1000:0x05b7");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.CLI();
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x62);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x64);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x62, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			// LEA
			this.oCPU.DI.Word = 0xc006;

			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();

			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);

		L05db:
			this.oCPU.BX.Word = 0x0;
			this.oCPU.BP.Word = 0x0;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbd06));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L05f7;
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6a);
			this.oCPU.DX.Word = this.oCPU.NOTWord(this.oCPU.DX.Word);
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.DX.Word);
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

		L05f7:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xba06));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0609;
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6a));
			this.oCPU.BP.Word = this.oCPU.ADDWord(this.oCPU.BP.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADCWord(this.oCPU.BX.Word, this.oCPU.DX.Word);

		L0609:
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADCWord(this.oCPU.BX.Word, 0x0);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.STOSByte();
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x300);
			if (this.oCPU.Flags.B) goto L062a;
			this.oCPU.SI.Word = 0x0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6a, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6a), this.oCPU.AX.Word));
			if (this.oCPU.Flags.AE) goto L062a;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6a, 0xffff);

		L062a:
			if (this.oCPU.Loop(this.oCPU.CX)) goto L05db;

			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.STI();

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_05b7'");
		}

		public void F0_1000_05b7_Int()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_05b7'(Cdecl, Near) at 0x1000:0x05b7");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.CLI();
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x62);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x64);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x62, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			// LEA
			this.oCPU.DI.Word = 0xc006;

			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();

			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);

		L05db:
			this.oCPU.BX.Word = 0x0;
			this.oCPU.BP.Word = 0x0;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbd06));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L05f7;
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6a);
			this.oCPU.DX.Word = this.oCPU.NOTWord(this.oCPU.DX.Word);
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.DX.Word);
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

		L05f7:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xba06));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0609;
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6a));
			this.oCPU.BP.Word = this.oCPU.ADDWord(this.oCPU.BP.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADCWord(this.oCPU.BX.Word, this.oCPU.DX.Word);

		L0609:
			this.oCPU.BP.Word = this.oCPU.SHLWord(this.oCPU.BP.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADCWord(this.oCPU.BX.Word, 0x0);
			this.oCPU.AX.Low = this.oCPU.BX.Low;
			this.oCPU.STOSByte();
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x300);
			if (this.oCPU.Flags.B) goto L062a;
			this.oCPU.SI.Word = 0x0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6a, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6a), this.oCPU.AX.Word));
			if (this.oCPU.Flags.AE) goto L062a;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6a, 0xffff);

		L062a:
			if (this.oCPU.Loop(this.oCPU.CX)) goto L05db;

			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.STI();

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_05b7'");
		}

		public void F0_1000_0631()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0631()");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68) != 0)
			{
				this.oCPU.PushWord(this.oCPU.SI.Word);
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x62);
				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x64);
				
				if (this.oParent.VGADriver.Screens.ContainsKey(0))
				{
					lock (this.oParent.VGADriver.VGALock)
					{
						VGABitmap screen = this.oParent.VGADriver.Screens.GetValueByKey(0);
						uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, 0xc006);

						for (int i = 0; i < this.oCPU.BX.Word; i++)
						{
							byte red = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
							byte green = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
							byte blue = this.oCPU.Memory.ReadUInt8(uiBufferPos++);

							screen.SetColor(i + this.oCPU.AX.Low, VGABitmap.Color18ToColor(red, green, blue));
						}
					}
				}
				else
				{
					throw new Exception($"The screen {0} is not allocated");
				}

				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68)));
				this.oCPU.PushWord(0x0666); // stack management - push return offset
				// Instruction address 0x1000:0x0663, size: 3
				F0_1000_05b7_Int();
				this.oCPU.PopWord(); // stack management - pop return offset
				this.oCPU.SI.Word = this.oCPU.PopWord();
			}
			
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0631");
		}

		public void F0_1000_066a()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_066a'(Cdecl, Far) at 0x1000:0x066a");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);

			this.oCPU.ES.Word = 0x3b01;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = 0x73;
			this.oCPU.AX.Word = 0x2900;
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x11;
			this.oCPU.DX.Word = 0x73;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0700;
			this.oCPU.AX.High = 0xe;
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x11;
			this.oCPU.DX.Word = 0x73;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L06ce;
			goto L0700;

		L06ce:
			this.oCPU.INT(0x11);
			this.oCPU.AX.Low = this.oCPU.ROLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.ROLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x3);
			if (this.oCPU.Flags.NE) goto L06de;

			this.oCPU.AX.Word = 0xffff;
			goto L0700;

		L06de:
			this.oCPU.AX.High = 0x19;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.XORByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.AX.Low;
			this.oCPU.AX.High = 0xe;
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x11;
			this.oCPU.DX.Word = 0x73;
			this.oCPU.INT(0x21);

		L0700:
			this.oCPU.CBW(this.oCPU.AX);

			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_066a'");
		}

		public void F0_1000_07d6()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_07d6'(Undefined) at 0x1000:0x07d6");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oParent.VGADriver.F0_VGA_0224_DrawBufferToScreen();
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x1);

			L075e:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402)));
				if (this.oCPU.Flags.E) goto L0769;

				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);
				this.oCPU.PushWord(this.oCPU.ES.Word);

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17a2, size: 5
				this.oParent.VGADriver.F0_VGA_0224_DrawBufferToScreen();

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17c0, size: 5
				this.oParent.VGADriver.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));
				this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;
			}

			this.oCPU.Log.ExitBlock("'F0_1000_07d6'");
		}

		public void F0_1000_083f(short param1, short param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_083f'(Undefined) at 0x1000:0x083f");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oParent.VGADriver.F0_VGA_0270(param1, param2, param3);
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x1);

			L075e:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402)));
				if (this.oCPU.Flags.E) goto L0769;

				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);
				this.oCPU.PushWord(this.oCPU.ES.Word);

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17a2, size: 5
				this.oParent.VGADriver.F0_VGA_0224_DrawBufferToScreen();

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17c0, size: 5
				this.oParent.VGADriver.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));
				this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;
			}

			this.oCPU.Log.ExitBlock("'F0_1000_083f'");
		}

		public void F0_1000_0846(ushort screenID)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0846'(Undefined) at 0x1000:0x0846");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oParent.VGADriver.F0_VGA_063c(screenID);
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x1);

			L075e:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402)));
				if (this.oCPU.Flags.E) goto L0769;

				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);
				this.oCPU.PushWord(this.oCPU.ES.Word);
				
				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17a2, size: 5
				this.oParent.VGADriver.F0_VGA_0224_DrawBufferToScreen();

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17c0, size: 5
				this.oParent.VGADriver.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));
				this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;
			}

			this.oCPU.Log.ExitBlock("'F0_1000_0846'");
		}

		public void F0_1000_0797_DrawBitmapToScreen(ushort rectPtr, short xPos, short yPos, ushort bitmapPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0797_DrawBitmapToScreen(0x{rectPtr:x4}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oParent.VGADriver.F0_VGA_0c3e_DrawBitmapToScreen(rectPtr, xPos, yPos, bitmapPtr);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x1);

			L075e:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402)));
				if (this.oCPU.Flags.E) goto L0769;

				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);
				this.oCPU.PushWord(this.oCPU.ES.Word);
				
				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17a2, size: 5
				this.oParent.VGADriver.F0_VGA_0224_DrawBufferToScreen();

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17c0, size: 5
				this.oParent.VGADriver.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));
				this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;
			}

			this.oCPU.Log.ExitBlock("'F0_1000_0797_DrawBitmapToScreen'");
		}

		public void F0_1000_084d_DrawBitmapToScreen(ushort rectPtr, short xPos, short yPos, ushort bitmapPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_084d_DrawBitmapToScreen(0x{rectPtr:x4}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oParent.VGADriver.F0_VGA_0d47_DrawBitmapToScreen(rectPtr, xPos, yPos, bitmapPtr);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x1);

			L075e:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402)));
				if (this.oCPU.Flags.E) goto L0769;

				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);
				this.oCPU.PushWord(this.oCPU.ES.Word);
				
				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17a2, size: 5
				this.oParent.VGADriver.F0_VGA_0224_DrawBufferToScreen();

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17c0, size: 5
				this.oParent.VGADriver.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));
				this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;
			}

			this.oCPU.Log.ExitBlock("F0_1000_084d_DrawBitmapToScreen");
		}

		public void F0_1000_0a2b()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a2b'");

			// Instruction address 0x1000:0x0a2b, size: 5
			this.oParent.SoundDriver.F0_0000_0048();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a2b'");
		}

		public void F0_1000_0a32()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a32'");

			// Instruction address 0x1000:0x0a32, size: 5
			this.oParent.SoundDriver.F0_0000_0062();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a32'");
		}

		public void F0_1000_0a39()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a39'");

			// Instruction address 0x1000:0x0a39, size: 5
			this.oParent.SoundDriver.F0_0000_006a();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a39'");
		}

		public void F0_1000_0a40()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a40'");

			// Instruction address 0x1000:0x0a40, size: 5
			this.oParent.SoundDriver.F0_0000_0055();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a40'");
		}

		public void F0_1000_0a47()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a47'");

			// function body
			// Instruction address 0x1000:0x0a47, size: 5
			this.oParent.SoundDriver.F0_0000_005c();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a47'");
		}

		public void F0_1000_0a4e()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a4e'");

			// Instruction address 0x1000:0x0a4e, size: 5
			this.oParent.SoundDriver.F0_0000_005d();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a4e'");
		}

		public void F0_1000_0a76_LoadOverlay(string overlayName, string resourceName)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0a76_LoadOverlay('{overlayName}', '{resourceName}')");

			// we no longer have the need to load any overlays or resources

			// function body
			/*this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// get free memory
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L0a89;
			// LEA
			this.oCPU.SI.Word = 0x5412;
			goto L0bdb;

		L0a89:
			// allocate free memory - 0x100
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x100);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x540c, this.oCPU.BX.Word);
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0a9e;
			// LEA
			this.oCPU.SI.Word = 0x542d;
			goto L0bdb;

		L0a9e:
			this.oCPU.ES.Word = this.oCPU.DS.Word;
			this.oCPU.BX.Word = 0x5408;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), this.oCPU.AX.Word);
			ushort overlaySegment = this.oCPU.AX.Word;*/

			//this.oCPU.DX.Word = overlayName;
			// DS:DX = pointer to an ASCIIZ filename
			// ES:BX = pointer to a parameter block
			/*this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.WriteUInt16(this.oCPU.CS.Word, 0xbb8, this.oCPU.SS.Word);
			this.oCPU.WriteUInt16(this.oCPU.CS.Word, 0xbb6, this.oCPU.SP.Word);

			this.oCPU.INT(0x21);

			this.oCPU.SS.Word = this.oCPU.ReadUInt16(this.oCPU.CS.Word, 0xbb8);
			this.oCPU.SP.Word = this.oCPU.ReadUInt16(this.oCPU.CS.Word, 0xbb6);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			/*switch (overlayName.ToLower())
			{
				case "misc.exe":
					this.oParent.MiscDriver.Segment = overlaySegment;
					break;

				case "mgraphic.exe":
					this.oParent.VGADriver.Segment = overlaySegment;
					break;

				case "nsound.cvl":
					this.oParent.SoundDriver.Segment = overlaySegment;
					break;

				default:
					throw new Exception("Unknown overlay name");
			}*/

			// calculate overlay size
			/*this.oCPU.ES.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5408);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0x2a);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0x2c);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.AX.Word = this.oCPU.RCRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);

			this.oCPU.DX.Word = resourceName;
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0af9;

			this.oCPU.PushWord(this.oCPU.DS.Word);
			// open resource file
			this.oCPU.AX.Word = 0x3d00;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0b2d;
			// LEA
			this.oCPU.SI.Word = 0x5463;
			goto L0bdb;

		L0b2d:
			this.oCPU.DS.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.AX.Word;

		L0b31:
			// read resource file
			this.oCPU.AX.High = 0x3f;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Word = 0x8000;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0b43;
			// LEA
			this.oCPU.SI.Word = 0x5463;
			goto L0bdb;

		L0b43:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.B) goto L0b50;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x800);
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			goto L0b31;

		L0b50:
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.AX.Word = this.oCPU.RCRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.DS.Word;
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			// close resource file
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0b6c;
			// LEA
			this.oCPU.SI.Word = 0x5463;
			goto L0bdb;

		L0b6c:
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DS.Word = this.oCPU.PopWord();

		L0af9:
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x540c));
			if (this.oCPU.Flags.BE) goto L0b0d;
			// LEA
			this.oCPU.SI.Word = 0x54b9;
			goto L0bdb;*/

		/*L0b0d:
			// modify allocated memory block
			this.oCPU.AX.High = 0x4a;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0b1a;
			// LEA
			this.oCPU.SI.Word = 0x54de;
			goto L0bdb;*/

		/*L0bdb:
			this.oCPU.AX.High = 0x2;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xa);
			this.oCPU.AX.Low = this.oCPU.SBBByte(this.oCPU.AX.Low, 0x69);
			this.oCPU.DAS();
			this.oCPU.DX.Low = this.oCPU.AX.Low;
			this.oCPU.INT(0x21);
			// LEA
			this.oCPU.DX.Word = 0x540e;
			this.oCPU.AX.High = 0x9;
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x9;
			this.oCPU.DX.Word = this.oCPU.SI.Word;
			this.oCPU.INT(0x21);

			this.oParent.MSCAPI.exit(0x99);*/

		/*L0b1a:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			
			this.oCPU.DS.Word = overlaySegment;
			this.oCPU.SI.Word = 0x32;
			this.oCPU.DI.Word = (ushort)(0x76d + (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2e) * 7));
			
			this.oCPU.AX.Word = 0x1000;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x28);

		L0b95:
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x3);
			this.oCPU.MOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.STOSWord();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0b95;
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();

			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0a76_LoadOverlay");
		}

		public void F0_1000_0bfa_FillRectangle(ushort rectPtr, ushort xPos, ushort yPos, ushort width, ushort height, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0bfa_FillRectangle(0x{rectPtr:4}, {xPos}, {yPos}, {width}, {height}, 0x{mode:4})");

			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (width > 0 && height > 0)
			{
				Rectangle rect1 = new Rectangle(rect.X + xPos, rect.Y + yPos, width, height);
				this.oParent.VGADriver.F0_VGA_040a_FillRectangle(rect.ScreenID, rect1, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0bfa_FillRectangle");
		}

		public void F0_1000_0fc8()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0fc8'(Cdecl, Near) at 0x1000:0x0fc8");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.AX.Low = 0xf;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.S) goto L0fd0;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xf7);

		L0fd0:
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5869));
			if (this.oCPU.Flags.G) goto L0fd8;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfe);

		L0fd8:
			this.oCPU.BP.Word = this.oCPU.ORWord(this.oCPU.BP.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.S) goto L0fde;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfb);

		L0fde:
			this.oCPU.CMPWord(this.oCPU.BP.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586b));
			if (this.oCPU.Flags.G) goto L0fe6;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfd);

		L0fe6:
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0fc8'");
		}

		public void F0_1000_104f_SetPixel(int xPos, int yPos, ushort mode)
		{
			CivRectangle rect = new CivRectangle(this.oParent.CPU, CPU.ToLinearAddress(this.oParent.CPU.DS.Word, this.oParent.CPU.ReadUInt16(this.oParent.CPU.DS.Word, 0xaa)));

			this.oCPU.Log.EnterBlock($"F0_1000_104f_SetPixel({rect.ScreenID}, {xPos}, {yPos}, 0x{mode:x4})");

			// function body
			if (xPos >= 0 && xPos <= rect.Width && yPos >= 0 && yPos <= rect.Height)
			{
				// Instruction address 0x1000:0x1080, size: 5
				this.oParent.VGADriver.F0_VGA_0550_SetPixel(rect.ScreenID, rect.X + xPos, rect.Y + yPos, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_104f_SetPixel");
		}

		public void F0_1000_104f_SetPixel(ushort screenID, int xPos, int yPos, ushort mode)
		{
			CivRectangle rect = new CivRectangle(this.oParent.CPU, CPU.ToLinearAddress(this.oParent.CPU.DS.Word, this.oParent.CPU.ReadUInt16(this.oParent.CPU.DS.Word, 0xaa)));

			this.oCPU.Log.EnterBlock($"F0_1000_104f_SetPixel({screenID}, {xPos}, {yPos}, 0x{mode:x4})");

			// function body
			if (xPos >= 0 && xPos <= rect.Width && yPos >= 0 && yPos <= rect.Height)
			{
				// Instruction address 0x1000:0x1080, size: 5
				this.oParent.VGADriver.F0_VGA_0550_SetPixel(screenID, rect.X + xPos, rect.Y + yPos, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_104f_SetPixel");
		}

		public void F0_1000_13c8()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_13c8'(Cdecl, Far) at 0x1000:0x13c8");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.High = 0x3c;
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.INT(0x21);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6afe, this.oCPU.AX.Word);
			if (this.oCPU.Flags.B) goto L1411;
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = 0x5ff;
			this.oCPU.INT(0x21);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b04, this.oCPU.AX.Word);
			if (this.oCPU.Flags.B) goto L1411;
			// LEA
			this.oCPU.DI.Word = 0xd936;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x3058;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = 0x0;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.STOSWord();
			this.oParent.Var_b26e = this.oCPU.DI.Word;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x6b08, this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x6b09, this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, 0xffff);

		L1411:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_13c8'");
		}

		public void F0_1000_1414()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1414'(Cdecl, Far) at 0x1000:0x1414");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b02);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b04);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.PushWord(0x142a); // stack management - push return offset
			// Instruction address 0x1000:0x1427, size: 3
			F0_1000_15cd();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(0x142d); // stack management - push return offset
			// Instruction address 0x1000:0x142a, size: 3
			F0_1000_1620();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, 0x0);
			this.oCPU.AX.High = 0x49;
			this.oCPU.ES.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b04);
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L1440;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L1440:
			this.oCPU.AX.High = 0x42;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L1453;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L1453:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.High = 0x42;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = 0x2;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L146b;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L146b:
			this.oCPU.AX.High = 0x40;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.DX.Word = this.oCPU.SP.Word;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L147d;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L147d:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.AX.High = 0x3e;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L148b;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L148b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b06);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1414'");
		}

		public void F0_1000_148f()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_148f'(Cdecl, Far) at 0x1000:0x148f");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BP.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b02);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b06), 0xffff);
			if (this.oCPU.Flags.E) goto L1500;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b00);
			this.oCPU.STOSByte();
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b00, this.oCPU.DI.Word);
			this.oCPU.PushWord(0x14b2); // stack management - push return offset
			// Instruction address 0x1000:0x14af, size: 3
			F0_1000_1565();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L14bf;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b02, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_148f'");
			return;

		L14bf:
			// LEA
			this.oCPU.SI.Word = 0xba06;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b00, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b02, this.oCPU.AX.Word);
			this.oCPU.PushWord(0x14d0); // stack management - push return offset
			// Instruction address 0x1000:0x14cd, size: 3
			F0_1000_1558();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = this.oCPU.BP.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.BP.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.BP.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.PushWord(0x14df); // stack management - push return offset
			// Instruction address 0x1000:0x14dc, size: 3
			F0_1000_15cd();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x6b0a);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afc), this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L14fc;
			this.oCPU.CX.Low = this.oCPU.INCByte(this.oCPU.CX.Low);
			this.oCPU.CMPByte(this.oCPU.CX.Low, 0xb);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x6b0a, this.oCPU.CX.Low);
			if (this.oCPU.Flags.BE) goto L14fc;
			this.oCPU.PushWord(0x14fc); // stack management - push return offset
			// Instruction address 0x1000:0x14f9, size: 3
			F0_1000_1524();
			this.oCPU.PopWord(); // stack management - pop return offset

		L14fc:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_148f'");
			return;

		L1500:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b06, 0x0);
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.STOSByte();
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b00, this.oCPU.DI.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b02, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0xb;
			this.oCPU.DI.Word = this.oParent.Var_b26e;
			this.oCPU.STOSByte();
			this.oParent.Var_b26e = this.oCPU.DI.Word;
			this.oCPU.PushWord(0x1520); // stack management - push return offset
			// Instruction address 0x1000:0x151d, size: 3
			F0_1000_1524();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_148f'");
		}

		public void F0_1000_1524()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1524'(Cdecl, Near) at 0x1000:0x1524");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.ES.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b04);
			this.oCPU.DI.Word = 0x0;
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.CX.Word = 0x0;

		L152f:
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.STOSWord();
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0x100);
			if (this.oCPU.Flags.B) goto L152f;
			this.oCPU.AX.Word = this.oCPU.BX.Word;

		L1541:
			this.oCPU.STOSWord();
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x4);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0xffb);
			if (this.oCPU.Flags.B) goto L1541;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x6b0a, 0x9);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6afc, 0x101);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1524'");
		}

		public void F0_1000_1558()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1558'(Cdecl, Near) at 0x1000:0x1558");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.BP.Word;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afc);
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6afc, this.oCPU.AX.Word);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1558'");
		}

		public void F0_1000_1565()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1565'(Cdecl, Near) at 0x1000:0x1565");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.BX.Word = 0x0;
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b00);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.BX.Low);

		L1571:
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.B) goto L1571;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0x7fff);
			if (this.oCPU.Flags.NE) goto L1593;
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.DI.Word);
			this.oCPU.CX.Word = this.oCPU.SI.Word;
			this.oCPU.DX.Word = 0x25;

		L158b:
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L158b;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0x7fff);

		L1593:
			this.oCPU.DX.Word = this.oCPU.BX.Word;
			this.oCPU.SI.Word = 0xff9;

		L1598:
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.AE) goto L1598;
			this.oCPU.DX.Word = this.oCPU.NEGWord(this.oCPU.DX.Word);
			this.oCPU.SI.Word = 0xffb;
			this.oCPU.ES.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b04);

		L15a5:
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.AE) goto L15a5;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.ES.Word, this.oCPU.DI.Word), 0xffff);
			if (this.oCPU.Flags.NE) goto L15bd;
			this.oCPU.BX.Word = 0xffff;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1565'");
			return;

		L15bd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.ES.Word, this.oCPU.DI.Word), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L15c9;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x2)), this.oCPU.BP.Word);
			if (this.oCPU.Flags.NE) goto L15c9;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1565'");
			return;

		L15c9:
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			goto L15a5;
		}

		public void F0_1000_15cd()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_15cd'(Cdecl, Near) at 0x1000:0x15cd");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x6b0a);
			this.oCPU.DX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x6b08);
			this.oCPU.DX.High = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x6b09);

		L15d9:
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			if (this.oCPU.Flags.S) goto L1617;
			this.oCPU.CMPByte(this.oCPU.DX.Low, 0x8);
			if (this.oCPU.Flags.B) goto L160f;
			this.oCPU.BX.Word = this.oParent.Var_b26e;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.DX.High);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CMPWord(this.oCPU.BX.Word, OpenCiv1.Constant_5528);
			if (this.oCPU.Flags.B) goto L160b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.AX.High = 0x40;
			this.oCPU.CX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afe);
			// LEA
			this.oCPU.DX.Word = 0xd936;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.INT(0x21);
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.PopWord();
			// LEA
			this.oCPU.BX.Word = 0xd936;

		L160b:
			this.oParent.Var_b26e = this.oCPU.BX.Word;

		L160f:
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.DX.High = this.oCPU.RCRByte(this.oCPU.DX.High, 0x1);
			this.oCPU.DX.Low = this.oCPU.INCByte(this.oCPU.DX.Low);
			goto L15d9;

		L1617:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x6b08, this.oCPU.DX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x6b09, this.oCPU.DX.High);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_15cd'");
		}

		public void F0_1000_1620()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1620'(Cdecl, Near) at 0x1000:0x1620");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x6b0a, 0x8);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.PushWord(0x162a); // stack management - push return offset
			// Instruction address 0x1000:0x1627, size: 3
			F0_1000_15cd();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.High = 0x40;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.CX.Word = this.oParent.Var_b26e;
			// LEA
			this.oCPU.DX.Word = 0xd936;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.INT(0x21);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1620'");
		}

		public void F0_1000_163e_InitMouse()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_163e_InitMouse'");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			// assume our mouse is initialized

			//this.oCPU.ES.Word = 0;
			//this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0xcc);
			//this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0xce));
			//if (this.oCPU.Flags.E) goto L1683;
			//this.oCPU.AX.Word = 0x0;
			//this.oCPU.INT(0x33);
			//this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			//if (this.oCPU.Flags.E) goto L1683;
			//this.oCPU.AX.Word = 0xc;
			//this.oCPU.CX.Word = 0x1f;
			//this.oCPU.ES.Word = this.oCPU.CS.Word;
			//this.oCPU.DX.Word = 0x17db;
			//this.oCPU.INT(0x33);
			//this.oCPU.AX.Word = 0x3;
			//this.oCPU.INT(0x33);
			this.oCPU.CX.Low = 0;
			this.oCPU.AX.Word = (ushort)(this.oParent.VGADriver.ScreenMouseLocation.X >> this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587c, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, (ushort)this.oParent.VGADriver.ScreenMouseLocation.Y);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5872, this.oParent.VGADriver.ScreenMouseButtons);
			this.oCPU.AX.Word = 0xffff;

		//L1683:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587d, this.oCPU.AX.Low);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_163e_InitMouse'");
		}

		public void F0_1000_1687()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1687'(Cdecl, Far) at 0x1000:0x1687");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.AX.Low = 0x0;
			this.oCPU.Temp.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587d);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587d, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L1696;

			//this.oCPU.AX.Word = 0x0;
			//this.oCPU.INT(0x33);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.BX.Word = 2;

		L1696:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1687'");
		}

		public void F0_1000_1697()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1697'(Cdecl, Far) at 0x1000:0x1697");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5878, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x587a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5876, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1697'");
		}

		public void F0_1000_16ae()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_16ae'(Cdecl, Far) at 0x1000:0x16ae");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, this.oCPU.DX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587d), 0x0);
			if (this.oCPU.Flags.E) goto L16d2;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587c);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			
			//this.oCPU.AX.Word = 0x4;
			//this.oCPU.INT(0x33);

		L16d2:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_16ae'");
		}

		public void F0_1000_16d4()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_16d4'(Cdecl, Far) at 0x1000:0x16d4");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.Temp.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5874);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5874, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;

			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_16d4'");
		}

		public void F0_1000_16db()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_16db'(Cdecl, Far) at 0x1000:0x16db");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L170a;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.NE) goto L170a;

			// Instruction address 0x1000:0x16fd, size: 5
			F0_1000_083f((short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
				(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5403, 0x1);

		L170a:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_16db'");
		}

		public void F0_1000_170b()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_170b'(Cdecl, Far) at 0x1000:0x170b");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L1723;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.E) goto L1723;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5403, 0x0);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return overlaySegment
			this.oCPU.PushWord(0x1723); // stack management - push return offset
			// Instruction address 0x1000:0x171e, size: 5
			F0_1000_07d6();
			this.oCPU.PopDWord(); // stack management - pop return offset and overlaySegment
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

		L1723:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_170b'");
		}

		public void F0_1000_179a()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_179a'(Cdecl, Near) at 0x1000:0x179a");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);

			this.oCPU.ES.Word = 0x1000;
			// Instruction address 0x1000:0x17a2, size: 5
			this.oParent.VGADriver.F0_VGA_0224_DrawBufferToScreen();

			this.oCPU.ES.Word = 0x1000;
			// Instruction address 0x1000:0x17c0, size: 5
			this.oParent.VGADriver.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_179a'");
		}

		public void F0_1000_17db_MouseEvent()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_17db'(Cdecl, Far) at 0x1000:0x17db");
			this.oCPU.CS.Word = 0x1000; // set this function overlaySegment

			// function body
			this.oCPU.DS.Word = 0x3b01;
			this.oCPU.BP.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587c);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5874, this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5874), this.oCPU.BX.Word));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5872, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, this.oCPU.DX.Word);
			this.oCPU.BP.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587e);
			this.oCPU.BP.Word = this.oCPU.ORWord(this.oCPU.BP.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5880));
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			if (this.oCPU.Flags.E) goto L180a;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return overlaySegment
			this.oCPU.PushWord(0x180a); // stack management - push return offset
										// Instruction address 0x1000:0x1806, size: 4
			this.oCPU.CallF(this.oCPU.ReadUInt32(this.oCPU.DS.Word, 0x587e));
			this.oCPU.PopDWord(); // stack management - pop return offset and overlaySegment
			this.oCPU.CS.Word = 0x1000; // restore this function overlaySegment

		L180a:
			this.oCPU.TESTWord(this.oCPU.BP.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1829;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.E) goto L1829;
			this.oCPU.AX.Low = 0x2;
			this.oCPU.Temp.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5402);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L1829;
			this.oCPU.PushWord(0x1824); // stack management - push return offset
										// Instruction address 0x1000:0x1821, size: 3
			F0_1000_179a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x0);

		L1829:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_17db'");
		}
	}
}
