using System;
using IRB.VirtualCPU;

using OpenCiv1.Drawing;
using OpenCiv1.GPU;

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

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_0000()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0000()");

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

			F0_1000_0276();
			
			this.oCPU.EnableTimer = true;

		L004f:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_0051()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0051()");

			// function body
			this.oCPU.AX.Low = 0x0;
			this.oCPU.Temp.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5a);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5a, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0075;

		L0075:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0051");
		}

		/// <summary>
		/// Timer function, it should fire appoximately every 20-25 ms
		/// </summary>
		public void F0_1000_01a7_Timer()
		{
			this.oCPU.Log.EnterBlock("F0_1000_01a7_Timer()");

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

				// Instruction address 0x1000:0x01db, size: 5
				F0_1000_0345();
			}

			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4c) != 0x1)
			{
				// sound driver call
				// Instruction address 0x1000:0x01e7, size: 5
				F0_1000_0a47();
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

			this.oCPU.Log.ExitBlock("F0_1000_01a7_Timer");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_0276()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0276()");

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
			this.oCPU.Log.ExitBlock("F0_1000_0276");
		}

		/// <summary>
		/// Reset timer count
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_033e_ResetTimer()
		{
			this.oCPU.Log.EnterBlock("F0_1000_033e_ResetTimer()");

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5c, 0);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_033e_ResetTimer");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_0345()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0345()");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5c, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c)));

			// Instruction address 0x1000:0x0349, size: 5
			F0_1000_0631_SetPalette();

			// Instruction address 0x1000:0x034e, size: 5
			F0_1000_044a();

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4e), 0x4);
			if (this.oCPU.Flags.NE) goto L036c;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5e, this.oCPU.SUBByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5e), 0x1));
			if (this.oCPU.Flags.G) goto L036c;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5e, 0x7);

			goto ExitFn;

		L036c:
			// sound driver call
			// Instruction address 0x1000:0x036c, size: 5
			F0_1000_0a40();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.S) goto L0378;
			if (this.oCPU.Flags.NE) goto L037d;

			goto ExitFn;

		L0378:
			// Instruction address 0x1000:0x0378, size: 5
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4c, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x59, 0x1);

			goto ExitFn;

		L037d:
			// Instruction address 0x1000:0x037d, size: 5
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4e);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4c, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x50);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x59, 0x1);

		ExitFn:
			this.oCPU.Log.ExitBlock("F0_1000_0345");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <param name="param4"></param>
		/// <exception cref="Exception"></exception>
		public void F0_1000_0382(ushort param1, ushort param2, ushort param3, ushort param4)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0382({param1}, {param2}, {param3}, {param4})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);

			this.oCPU.DS.Word = 0x35cf;
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x0, this.oCPU.AX.Word);
			this.oCPU.BX.Word = param1;
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0x8);
			if (this.oCPU.Flags.AE) goto L03f5;

			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));

			this.oCPU.AX.Word = param3;
			this.oCPU.DX.Word = param4;
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
			if (this.oParent.Graphics.Screens.ContainsKey(0))
			{
				lock (this.oParent.Graphics.GLock)
				{
					GBitmap screen = this.oParent.Graphics.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x9));

					for (int i = 0; i < this.oCPU.DX.Word; i++)
					{
						Color color = GBitmap.ColorToColor18(screen.GetPaletteColor((byte)(i + this.oCPU.AX.Low)));

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
			this.oCPU.AX.Word = param2;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7), this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), 0x0);

		L03f5:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0382");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F0_1000_03fa(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_03fa({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);

			this.oCPU.DS.Word = 0x35cf;
			this.oCPU.AX.Word = param1;
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
			this.oCPU.Log.ExitBlock("F0_1000_03fa");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F0_1000_042b(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_042b({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = 0x35cf;
			this.oCPU.BX.Word = param1;
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
			this.oCPU.Log.ExitBlock("F0_1000_042b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void F0_1000_044a()
		{
			this.oCPU.Log.EnterBlock("F0_1000_044a()");

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

			if (this.oParent.Graphics.Screens.ContainsKey(0))
			{
				lock (this.oParent.Graphics.GLock)
				{
					GBitmap screen = this.oParent.Graphics.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.SI.Word);
					int iCount = this.oCPU.CX.Word / 3;

					for (int i = 0; i < iCount; i++)
					{
						byte red = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte green = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte blue = this.oCPU.Memory.ReadUInt8(uiBufferPos++);

						screen.SetPaletteColor((byte)(i + this.oCPU.AX.Low), GBitmap.Color18ToColor(red, green, blue));
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
			this.oCPU.Log.ExitBlock("F0_1000_044a");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="palettePtr"></param>
		public void F0_1000_04aa(ushort param1, ushort palettePtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_04aa({param1}, 0x{palettePtr:x4})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = 0x300;
			this.oCPU.SI.Word = palettePtr;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x6);
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);

			// Instruction address 0x1000:0x04c0, size: 3
			F0_1000_0554_ReadCurrentPalette();

			// Instruction address 0x1000:0x04c6, size: 3
			F0_1000_050c(param1);

		L04c9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68), 0x0);
			if (this.oCPU.Flags.NE) goto L04c9;

			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_04aa");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <param name="param4"></param>
		public void F0_1000_04d4(ushort param1, byte param2, byte param3, byte param4)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_04d4({param1}, {param2}, {param3}, {param4})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();

			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.CX.Word = 0x100;

		L04eb:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word, param2);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1), param3);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), param4);

			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x3);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L04eb;

			// Instruction address 0x1000:0x04f8, size: 3
			F0_1000_0554_ReadCurrentPalette();

			// Instruction address 0x1000:0x04fe, size: 3
			F0_1000_050c(param1);

		L0501:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68), 0x0);
			if (this.oCPU.Flags.NE) goto L0501;

			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_04d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F0_1000_050c(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_050c({param1})");

			// function body
			param1 *= 6;
			
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
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, param1);
			this.oCPU.CX.High = this.oCPU.DX.Low;
			this.oCPU.CX.Low = this.oCPU.AX.High;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6c, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6a, this.oCPU.AX.Word);

			F0_1000_05b7();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68, param1);

			// Near return
			this.oCPU.Log.ExitBlock("F0_1000_050c");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void F0_1000_0554_ReadCurrentPalette()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0554_ReadCurrentPalette()");

			// function body
			this.oCPU.CLI();
			if (this.oParent.Graphics.Screens.ContainsKey(0))
			{
				lock (this.oParent.Graphics.GLock)
				{
					GBitmap screen = this.oParent.Graphics.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, 0xbd06);

					for (int i = 0; i < 256; i++)
					{
						Color color = GBitmap.ColorToColor18(screen.GetPaletteColor((byte)i));

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

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public ushort F0_1000_0573_MeasurePalettePerformance()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0573_MeasurePalettePerformance()");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x60, 0xffff);

			this.oCPU.CLI();
			if (this.oParent.Graphics.Screens.ContainsKey(0))
			{
				lock (this.oParent.Graphics.GLock)
				{
					GBitmap screen = this.oParent.Graphics.Screens.GetValueByKey(0);
					uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, 0xbd06);

					for (int i = 0; i < 10; i++)
					{
						byte red = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte green = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
						byte blue = this.oCPU.Memory.ReadUInt8(uiBufferPos++);

						screen.SetPaletteColor((byte)i, GBitmap.Color18ToColor(red, green, blue));
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
			this.oCPU.Log.ExitBlock("F0_1000_0573_MeasurePalettePerformance");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_05b7()
		{
			this.oCPU.Log.EnterBlock("F0_1000_05b7()");

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
			this.oCPU.Log.ExitBlock("F0_1000_05b7");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_05b7_Int()
		{
			this.oCPU.Log.EnterBlock("F0_1000_05b7_Int()");

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
			this.oCPU.Log.ExitBlock("F0_1000_05b7_Int");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void F0_1000_0631_SetPalette()
		{
			this.oCPU.Log.EnterBlock("F0_1000_0631_SetPalette()");

			// function body
			if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68) != 0)
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x62);
				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x64);
				
				if (this.oParent.Graphics.Screens.ContainsKey(0))
				{
					lock (this.oParent.Graphics.GLock)
					{
						GBitmap screen = this.oParent.Graphics.Screens.GetValueByKey(0);
						uint uiBufferPos = CPU.ToLinearAddress(this.oCPU.DS.Word, 0xc006);

						for (int i = 0; i < this.oCPU.BX.Word; i++)
						{
							byte red = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
							byte green = this.oCPU.Memory.ReadUInt8(uiBufferPos++);
							byte blue = this.oCPU.Memory.ReadUInt8(uiBufferPos++);

							screen.SetPaletteColor((byte)(i + this.oCPU.AX.Low), GBitmap.Color18ToColor(red, green, blue));
						}
					}
				}
				else
				{
					throw new Exception($"The screen {0} is not allocated");
				}

				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68, 
					this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68)));

				// Instruction address 0x1000:0x0663, size: 3
				F0_1000_05b7_Int();
			}
			
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0631_SetPalette");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="fileNamePtr"></param>
		/// <returns></returns>
		public ushort F0_1000_066a_FileExists(ushort fileNamePtr)
		{
			string fileName = MSCAPI.GetDOSFileName(this.oParent.CPU.ReadString(CPU.ToLinearAddress(this.oParent.CPU.DS.Word, fileNamePtr)).ToUpper());

			this.oCPU.Log.EnterBlock($"F0_1000_066a_FileExists('{fileName}')");

			// function body
			if (File.Exists($"{this.oParent.CPU.DefaultDirectory}{fileName}"))
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_066a_FileExists");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_07d6()
		{
			this.oCPU.Log.EnterBlock("F0_1000_07d6()");

			// function body
			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_07d6");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		public void F0_1000_083f(short param1, short param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_083f({param1}, {param2}, {param3})");

			// function body
			//this.oParent.Graphics.F0_VGA_0270(param1, param2, param3);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_083f");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="screenID"></param>
		public void F0_1000_0846(ushort screenID)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0846({screenID})");

			// function body
			//this.oParent.Graphics.F0_VGA_063c(screenID);
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreen(screenID);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_0846");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapPtr"></param>
		public void F0_1000_0797_DrawBitmapToScreen(ushort rectPtr, int xPos, int yPos, ushort bitmapPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0797_DrawBitmapToScreen(0x{rectPtr:x4}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");

			// function body
			this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(rectPtr, xPos, yPos, bitmapPtr);

			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
			{
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0);
			}

			this.oCPU.Log.ExitBlock("F0_1000_0797_DrawBitmapToScreen");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapPtr"></param>
		public void F0_1000_084d_DrawBitmapToScreen(ushort rectPtr, int xPos, int yPos, ushort bitmapPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_084d_DrawBitmapToScreen(0x{rectPtr:x4}, {xPos}, {yPos}, 0x{bitmapPtr:x4})");

			// function body
			this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(rectPtr, xPos, yPos, bitmapPtr);

			/*if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403) != 0)
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
				this.oParent.Graphics.F0_VGA_0224_DrawBufferToScreen();

				this.oCPU.ES.Word = 0x1000;
				// Instruction address 0x1000:0x17c0, size: 5
				this.oParent.Graphics.F0_VGA_0270(
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5878)),
					(short)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870) - (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x587a)),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;
			}*/

			this.oCPU.Log.ExitBlock("F0_1000_084d_DrawBitmapToScreen");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_0a2b()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a2b'");

			// Instruction address 0x1000:0x0a2b, size: 5
			this.oParent.Sound.F0_0000_0048();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a2b'");
		}

		/// <summary>
		/// Sound function, possibly: Play Music
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F0_1000_0a32(ushort param1, ushort param2)
		{
			if ((this.oParent.GameState.GameSettingFlags & 0x10) != 0)
			{
				// Instruction address 0x1000:0x0a32, size: 5
				this.oParent.Sound.F0_0000_0062(param1, param2);
			}
		}

		/// <summary>
		/// Sound function
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_0a39()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a39'");

			// Instruction address 0x1000:0x0a39, size: 5
			this.oCPU.AX.Word =  this.oParent.Sound.F0_0000_006a();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a39'");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Sound function
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_0a40()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a40'");

			// Instruction address 0x1000:0x0a40, size: 5
			this.oCPU.AX.Word =  this.oParent.Sound.F0_0000_0055();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a40'");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Sound function, possibly advance sound buffer
		/// </summary>
		public void F0_1000_0a47()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a47'");

			// function body
			// Instruction address 0x1000:0x0a47, size: 5
			this.oParent.Sound.F0_0000_005c();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a47'");
		}

		/// <summary>
		/// Sound function
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_0a4e()
		{
			//this.oCPU.Log.EnterBlock("Sound overlay 'F0_1000_0a4e'");

			// Instruction address 0x1000:0x0a4e, size: 5
			this.oCPU.AX.Word = this.oParent.Sound.F0_0000_005d();
			//this.oCPU.Log.ExitBlock("Sound overlay 'F0_1000_0a4e'");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Fills the rectangle with color
		/// </summary>
		/// <param name="rectPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_1000_0bfa_FillRectangle(ushort rectPtr, int xPos, int yPos, int width, int height, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_0bfa_FillRectangle(0x{rectPtr:4}, {xPos}, {yPos}, {width}, {height}, 0x{mode:4})");

			// function body
			CivRectangle rect = new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, rectPtr));

			if (width > 0 && height > 0)
			{
				GRectangle rect1 = new GRectangle(rect.X + xPos, rect.Y + yPos, width, height);
				this.oParent.Graphics.F0_VGA_040a_FillRectangle(rect.ScreenID, rect1, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_0bfa_FillRectangle");
		}

		/// <summary>
		/// Sets a pixel on screen set by structure at 0xaa
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mode"></param>
		public void F0_1000_104f_SetPixel(int xPos, int yPos, ushort mode)
		{
			CivRectangle rect = new CivRectangle(this.oParent.CPU, CPU.ToLinearAddress(this.oParent.CPU.DS.Word, this.oParent.CPU.ReadUInt16(this.oParent.CPU.DS.Word, 0xaa)));

			this.oCPU.Log.EnterBlock($"F0_1000_104f_SetPixel({rect.ScreenID}, {xPos}, {yPos}, 0x{mode:x4})");

			// function body
			if (xPos >= 0 && xPos <= rect.Width && yPos >= 0 && yPos <= rect.Height)
			{
				// Instruction address 0x1000:0x1080, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(rect.ScreenID, rect.X + xPos, rect.Y + yPos, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_104f_SetPixel");
		}

		/// <summary>
		/// Sets a pixel on selected screen
		/// </summary>
		/// <param name="screenID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mode"></param>
		public void F0_1000_104f_SetPixel(ushort screenID, int xPos, int yPos, ushort mode)
		{
			CivRectangle rect = new CivRectangle(this.oParent.CPU, CPU.ToLinearAddress(this.oParent.CPU.DS.Word, this.oParent.CPU.ReadUInt16(this.oParent.CPU.DS.Word, 0xaa)));

			this.oCPU.Log.EnterBlock($"F0_1000_104f_SetPixel({screenID}, {xPos}, {yPos}, 0x{mode:x4})");

			// function body
			if (xPos >= 0 && xPos <= rect.Width && yPos >= 0 && yPos <= rect.Height)
			{
				// Instruction address 0x1000:0x1080, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(screenID, rect.X + xPos, rect.Y + yPos, (byte)(mode & 0xff), (byte)((mode & 0xff00) >> 8));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_104f_SetPixel");
		}

		/// <summary>
		/// Resets and inits the mouse subsystem
		/// </summary>
		/// <returns>true if mouse is detected</returns>
		public ushort F0_1000_163e_InitMouse()
		{
			this.oCPU.Log.EnterBlock("F0_1000_163e_InitMouse()");

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
			this.oCPU.AX.Word = (ushort)(this.oParent.Graphics.ScreenMouseLocation.X >> this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587c, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, (ushort)this.oParent.Graphics.ScreenMouseLocation.Y);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5872, this.oParent.Graphics.ScreenMouseButtons);
			this.oCPU.AX.Word = 0xffff;

		//L1683:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x587d, this.oCPU.AX.Low);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_163e_InitMouse");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_1687()
		{
			this.oCPU.Log.EnterBlock("F0_1000_1687()");

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
			this.oCPU.Log.ExitBlock("F0_1000_1687");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		public void F0_1000_1697(ushort param1, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_1697({param1}, {param2}, {param3})");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5878, param1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x587a, param2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5876, param3);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_1697");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F0_1000_16ae(ushort param1, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_1000_16ae({param1}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.AX.Word = param1;
			this.oCPU.DX.Word = param2;
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
			this.oCPU.Log.ExitBlock("F0_1000_16ae");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_1000_16d4()
		{
			// function body
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5874);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5874, 0);

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_16db()
		{
			this.oCPU.Log.EnterBlock("F0_1000_16db()");

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L170a;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.NE) goto L170a;

			// Instruction address 0x1000:0x16fd, size: 5
			F0_1000_083f((short)(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x586e) - this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5878)),
				(short)(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5870) - this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x587a)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5403, 0x1);

		L170a:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_16db");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_170b()
		{
			this.oCPU.Log.EnterBlock("F0_1000_170b()");

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L1723;

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.E) goto L1723;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5403, 0x0);

			// Instruction address 0x1000:0x171e, size: 5
			F0_1000_07d6();

		L1723:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1000_170b");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1000_179a()
		{
			this.oCPU.Log.EnterBlock("F0_1000_179a()");

			// function body
			// Near return
			this.oCPU.Log.ExitBlock("F0_1000_179a");
		}

		/// <summary>
		/// Handles mouse events
		/// </summary>
		public void F0_1000_17db_MouseEvent()
		{
			//this.oCPU.Log.EnterBlock("F0_1000_17db_MouseEvent()");

			// function body
			this.oCPU.DS.Word = 0x3b01;
			this.oCPU.BP.Word = this.oCPU.CX.Word;

			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x587c);
			this.oCPU.BP.Word = this.oCPU.SHRWord(this.oCPU.BP.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.BP.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5874, 
				this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5874), this.oCPU.BX.Word));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5872, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x586e, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5870, this.oCPU.DX.Word);

			this.oCPU.BP.Word = this.oCPU.AX.Word;
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

			// Instruction address 0x1000:0x1821, size: 3
			F0_1000_179a();

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x5402, 0x0);

		L1829:
			// Far return
			//this.oCPU.Log.ExitBlock("F0_1000_17db_MouseEvent");
			this.oCPU.AX.Low = this.oCPU.AX.Low;
		}
	}
}
