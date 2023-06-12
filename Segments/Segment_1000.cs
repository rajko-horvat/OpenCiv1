using Disassembler;
using Microsoft.Win32;
using System;

namespace Civilization1
{
	public class Segment_1000
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_1000(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_1000_0000()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0000'(Cdecl, Far) at 0x1000:0x0000");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Low = 0x1;
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5a);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5a, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L004f;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c, 0x1); // Segment
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x54, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x42, 0x0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x44, 0x0);
			this.oCPU.AX.Low = 0x36;
			this.oCPU.OUTByte(0x43, this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTByte(0x40, this.oCPU.AX.Low);
			this.oCPU.OUTByte(0x40, this.oCPU.AX.Low);
			this.oCPU.PushWord(0x0034); // stack management - push return offset
			// Instruction address 0x1000:0x0031, size: 3
			F0_1000_0276();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.High = 0x35;
			this.oCPU.AX.Low = 0x8;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x211, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x213, this.oCPU.ES.Word);
			this.oCPU.AX.High = 0x25;
			this.oCPU.AX.Low = 0x8;
			// LDS
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x1a3);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x1a3 + 2));
			this.oCPU.INT(0x21);
			this.oCPU.EnableTimer = true;

		L004f:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0000'");
		}

		public void F0_1000_0051()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0051'(Cdecl, Far) at 0x1000:0x0051");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Low = 0x0;
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5a);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5a, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0075;
			this.oCPU.AX.Low = 0x36;
			this.oCPU.OUTByte(0x43, this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTByte(0x40, this.oCPU.AX.Low);
			this.oCPU.OUTByte(0x40, this.oCPU.AX.Low);
			this.oCPU.AX.High = 0x25;
			this.oCPU.AX.Low = 0x8;
			// LDS
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x211);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, (ushort)(0x211 + 2));
			this.oCPU.INT(0x21);

		L0075:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0051'");
		}

		public void F0_1000_01a7_Timer()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_01a7_Timer'");
			this.oCPU.CS.Word = 0x1000; // set this function segment

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
			this.oCPU.CX.Word = 0x1000;
			this.oCPU.SS.Word = this.oCPU.CX.Word;
			this.oCPU.SP.Word = 0x1a1;
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3b01;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x48);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x42, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x42), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x44, this.oCPU.ADCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x44), 0x0));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x54, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x54)));
			if (this.oCPU.Flags.NE) goto L01e0;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x54, this.oCPU.AX.Word);
			this.oCPU.PushWord(0x01db); // stack management - push return offset
			// Instruction address 0x1000:0x01d8, size: 3
			F0_1000_0215();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01e0); // stack management - push return offset
			// Instruction address 0x1000:0x01db, size: 5
			F0_1000_0345();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment

		L01e0:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c), 0x1);
			if (this.oCPU.Flags.E) goto L01ec;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01ec); // stack management - push return offset
			// Instruction address 0x1000:0x01e7, size: 5
			F0_1000_0a47();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment

		L01ec:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x44), 0x0);
			if (this.oCPU.Flags.NE) goto L0202;
			this.oCPU.AX.Low = 0x20;
			this.oCPU.OUTByte(0x20, this.oCPU.AX.Low);

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

		L0202:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x44, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x44)));
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
			// Instruction address 0x1000:0x0210, size: 5
			//this.oParent.MSCAPI.DivisionByZero();
			this.oCPU.Log.ExitBlock("'F0_1000_01a7_Timer'");
			return;
		}

		public void F0_1000_0215()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0215'(Cdecl, Near) at 0x1000:0x0215");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x59, this.oCPU.DECByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x59)));
			if (this.oCPU.Flags.NE) goto L0274;
			this.oCPU.AX.Low = 0x14;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x59, this.oCPU.AX.Low);
			this.oCPU.BX.Low = 0x0;
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = 0x3da;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x58), 0x0);
			if (this.oCPU.Flags.E) goto L0248;

		L022e:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.NE) goto L0248;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.BX.Low);
			if (this.oCPU.Flags.E) goto L022e;
			this.oCPU.BX.Low = this.oCPU.XORByte(this.oCPU.BX.Low, 0x1);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L022e;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x58, 0x0);
			goto L0274;

		L0248:
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x46);
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x48));
			if (this.oCPU.Flags.NE) goto L0254;
			if (this.oCPU.CX.Word == 0) goto L0274;

		L0254:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x48, this.oCPU.DX.Word);
			this.oCPU.AX.Low = 0x36;
			this.oCPU.OUTByte(0x43, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.DX.Low;
			this.oCPU.OUTByte(0x40, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.DX.High;
			this.oCPU.OUTByte(0x40, this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4a, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4a)));
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x56, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L0274;

		L0274:
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0215'");
		}

		public void F0_1000_0276()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0276'(Cdecl, Near) at 0x1000:0x0276");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushF();
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x59, 0x1);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x58, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x50, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x52, this.oCPU.AX.Word);
			this.oCPU.PushWord(0x028d); // stack management - push return offset
			// Instruction address 0x1000:0x028a, size: 3
			F0_1000_030b();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = 0x10;

		L0292:
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(0x0296); // stack management - push return offset
			// Instruction address 0x1000:0x0293, size: 3
			F0_1000_030b();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x50, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x50), this.oCPU.BX.Word));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x52, this.oCPU.ADCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x52), 0x0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0292;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x50);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x52);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x42, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x42), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x44, this.oCPU.ADCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x44), this.oCPU.DX.Word));
			this.oCPU.CX.Word = 0x10;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x50, this.oCPU.AX.Word);
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
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x58, 0x0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x50, 0x4dae);
			this.oCPU.AX.Word = 0x5;

		L02ed:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4e, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c), 0x1);
			if (this.oCPU.Flags.E) goto L02fa;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c, this.oCPU.AX.Word);

		L02fa:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x50);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4c));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x48, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.PopF();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0276'");
		}

		public void F0_1000_030b()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_030b'(Cdecl, Near) at 0x1000:0x030b");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushF();
			this.oCPU.CLI();
			this.oCPU.DX.Word = 0x3da;
			this.oCPU.BX.Word = 0x0;

		L0312:
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0336;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.NE) goto L0312;
			this.oCPU.BX.Word = 0x0;

		L031c:
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0336;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L031c;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTByte(0x43, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.INByte(0x40);
			this.oCPU.BX.Low = this.oCPU.AX.Low;
			this.oCPU.AX.Low = this.oCPU.INByte(0x40);
			this.oCPU.BX.High = this.oCPU.AX.Low;

		L0336:
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.STI();
			this.oCPU.PopF();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_030b'");
		}

		public void F0_1000_033e()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_033e'(Cdecl, Far) at 0x1000:0x033e");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5c, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_033e'");
		}

		public void F0_1000_0345()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0345'(Cdecl, Far) at 0x1000:0x0345");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5c, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5c)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x034e); // stack management - push return offset
			// Instruction address 0x1000:0x0349, size: 5
			F0_1000_0631();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0353); // stack management - push return offset
			// Instruction address 0x1000:0x034e, size: 5
			F0_1000_044a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0358); // stack management - push return offset
			// Instruction address 0x1000:0x0353, size: 5
			this.oParent.VGADriver.F0_VGA_10bb_ScrollLeft();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4e), 0x4);
			if (this.oCPU.Flags.NE) goto L036c;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5e, this.oCPU.SUBByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5e), 0x1));
			if (this.oCPU.Flags.G) goto L036c;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5e, 0x7);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;

		L036c:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0371); // stack management - push return offset
			// Instruction address 0x1000:0x036c, size: 5
			F0_1000_0a40();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.S) goto L0378;
			if (this.oCPU.Flags.NE) goto L037d;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;

		L0378:
			// Instruction address 0x1000:0x0378, size: 5
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x50);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x59, 0x1);

			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;

		L037d:
			// Instruction address 0x1000:0x037d, size: 5
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x4e);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x4c, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x50);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x46, this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x59, 0x1);

			this.oCPU.Log.ExitBlock("'F0_1000_0345'");
			return;
		}

		public void F0_1000_0382()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0382'(Cdecl, Far) at 0x1000:0x0382");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x35cf;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.CX.Low = 0x20;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x0, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0x8);
			if (this.oCPU.Flags.AE) goto L03f5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L03f5;
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0x10);
			if (this.oCPU.Flags.BE) goto L03b9;
			this.oCPU.DX.Word = 0x10;

		L03b9:
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4), this.oCPU.CX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6), this.oCPU.AX.Low);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			// LEA
			this.oCPU.DI.Word = (ushort)(this.oCPU.BX.Word + 0x9);
			this.oCPU.CLI();
			this.oCPU.DX.Word = 0x3c7;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6));
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Low = 0xc9;

		L03d6:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L03d6;
			this.oCPU.STI();
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, 0x3);
			// LEA
			this.oCPU.SI.Word = (ushort)(this.oCPU.BX.Word + 0x9);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7), this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), 0x0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), 0x0);

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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x35cf;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.AE) goto L0428;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.AX.Word = 0x3;
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), this.oCPU.AX.Low);

		L0428:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_03fa'");
		}

		public void F0_1000_042b()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_042b'(Cdecl, Far) at 0x1000:0x042b");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x35cf;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0x8);
			if (this.oCPU.Flags.AE) goto L0447;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), 0x0);

		L0447:
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_042b'");
		}

		public void F0_1000_044a()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_044a'(Cdecl, Far) at 0x1000:0x044a");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x35cf;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			// LEA
			this.oCPU.DI.Word = 0x2;

		L0456:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L04a5;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L0456;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), this.oCPU.DECByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8))));
			if (this.oCPU.Flags.NE) goto L0456;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8), this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.BX.Word));
			if (this.oCPU.Flags.GE) goto L047d;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.CX.Word);

		L047d:
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.L) goto L0484;
			this.oCPU.SI.Word = 0x0;

		L0484:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), this.oCPU.SI.Word);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BX.Word + 0x9);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = 0x3c8;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6));
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x0), 0x0);
			if (this.oCPU.Flags.E) goto L049f;
			this.oCPU.REPEOUTSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.CX);
			goto L0456;

		L049f:
			this.oCPU.LODSByte();
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L049f;
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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = 0x300;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x6);
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.PushWord(0x04c3); // stack management - push return offset
			// Instruction address 0x1000:0x04c0, size: 3
			F0_1000_0554();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(0x04c9); // stack management - push return offset
			// Instruction address 0x1000:0x04c6, size: 3
			F0_1000_050c();
			this.oCPU.PopWord(); // stack management - pop return offset

		L04c9:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68), 0x0);
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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);

			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.CX.Word = 0x100;

		L04eb:
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1), this.oCPU.AX.High);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.BX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x3);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L04eb;

			MainRegistersCheck registersCheck = new MainRegistersCheck(this.oCPU);
			this.oCPU.PushWord(0x04fb); // stack management - push return offset
			// Instruction address 0x1000:0x04f8, size: 3
			F0_1000_0554();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (!registersCheck.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");

			registersCheck = new MainRegistersCheck(this.oCPU);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(0x0501); // stack management - push return offset
			// Instruction address 0x1000:0x04fe, size: 3
			F0_1000_050c();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (!registersCheck.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");

		L0501:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68), 0x0);
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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);

			this.oCPU.AX.High = 0x6;
			this.oCPU.MULByte(this.oCPU.AX, this.oCPU.AX.High);
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x66);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L051f;

			MainRegistersCheck registersCheck = new MainRegistersCheck(this.oCPU);
			this.oCPU.PushWord(0x051c); // stack management - push return offset
			// Instruction address 0x1000:0x0519, size: 3
			F0_1000_0573();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (!registersCheck.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");

			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x66, this.oCPU.AX.Word);

		L051f:
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CX.Word = 0xe;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.E) goto L052d;
			this.oCPU.AX.Word = 0x100;

		L052d:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x64, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x62, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x62, this.oCPU.NEGWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x62)));
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.BP.Word);
			this.oCPU.CX.High = this.oCPU.DX.Low;
			this.oCPU.CX.Low = this.oCPU.AX.High;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6c, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6a, this.oCPU.AX.Word);

			registersCheck = new MainRegistersCheck(this.oCPU);
			this.oCPU.PushWord(0x054f); // stack management - push return offset
			// Instruction address 0x1000:0x054c, size: 3
			F0_1000_05b7();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (!registersCheck.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");

			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68, this.oCPU.BP.Word);

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_050c'");
		}

		public void F0_1000_0554()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0554'(Cdecl, Near) at 0x1000:0x0554");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.CLI();
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DX.Word = 0x3da;

		L0558:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L0558;

			// LEA
			this.oCPU.DI.Word = 0xbd06;
			this.oCPU.CX.Word = 0x300;
			this.oCPU.DX.Low = 0xc7;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Low = 0xc9;

		L056d:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L056d;

			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.STI();

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0554'");
		}

		public void F0_1000_0573()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0573'(Cdecl, Near) at 0x1000:0x0573");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.CX.Low = 0x20;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x60, this.oCPU.AX.Word);
			this.oCPU.BX.Word = 0x0;
			this.oCPU.CLI();
			this.oCPU.DX.Word = 0x3da;

		L0584:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L0584;

		L0589:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.NE) goto L0589;

		L058e:
			this.oCPU.DX.Low = 0xc8;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Low = 0xc9;
			// LEA
			this.oCPU.SI.Word = 0xbd06;
			this.oCPU.CX.Word = 0x1e;
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.E) goto L05a5;
			this.oCPU.REPEOUTSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.CX);
			goto L05a9;

		L05a5:
			this.oCPU.LODSByte();
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L05a5;

		L05a9:
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0xa);
			this.oCPU.DX.Low = 0xda;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L058e;
			// in real VGA BX.Word=0xc72e approximately
			this.oCPU.AX.Word = 0xa000; // this.oCPU.BX.Word;

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.STI();

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0573'");
		}

		public void F0_1000_05b7()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_05b7'(Cdecl, Near) at 0x1000:0x05b7");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.CLI();
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);

			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x62);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x64);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x62, this.oCPU.AX.Word);
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
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x42fa));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L05f7;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6a);
			this.oCPU.DX.Word = this.oCPU.NOTWord(this.oCPU.DX.Word);
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.DX.Word);
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

		L05f7:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x45fa));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0609;
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6a));
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
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6a, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6a), this.oCPU.AX.Word));
			if (this.oCPU.Flags.AE) goto L062a;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6a, 0xffff);

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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.CLI();
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);

			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x62);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x64);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x62, this.oCPU.AX.Word);
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
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x42fa));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L05f7;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6a);
			this.oCPU.DX.Word = this.oCPU.NOTWord(this.oCPU.DX.Word);
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.DX.Word);
			this.oCPU.BP.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;

		L05f7:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x45fa));
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0609;
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6a));
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
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6a, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6a), this.oCPU.AX.Word));
			if (this.oCPU.Flags.AE) goto L062a;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6a, 0xffff);

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
			this.oCPU.Log.EnterBlock("'F0_1000_0631'(Cdecl, Far) at 0x1000:0x0631");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68), 0x0);
			if (this.oCPU.Flags.E) goto L0667;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x62);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x64);
			this.oCPU.CX.Word = this.oCPU.BX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.BX.Word);
			// LEA
			this.oCPU.SI.Word = 0xc006;
			this.oCPU.DX.Word = 0x3c8;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x60), 0x0);
			if (this.oCPU.Flags.E) goto L065b;
			this.oCPU.REPEOUTSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.CX);
			goto L065f;

		L065b:
			this.oCPU.LODSByte();
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L065b;

		L065f:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68)));
			this.oCPU.PushWord(0x0666); // stack management - push return offset
			// Instruction address 0x1000:0x0663, size: 3
			F0_1000_05b7_Int();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SI.Word = this.oCPU.PopWord();

		L0667:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0631'");
		}

		public void F0_1000_066a()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_066a'(Cdecl, Far) at 0x1000:0x066a");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.AX.High = 0x35;
			this.oCPU.AX.Low = 0x24;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6e, this.oCPU.ES.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x70, this.oCPU.BX.Word);
			this.oCPU.AX.High = 0x25;
			this.oCPU.AX.Low = 0x24;
			this.oCPU.DX.Word = 0x718;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.INT(0x21);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = 0x3b01;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = 0x73;
			this.oCPU.AX.Word = 0x2900;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x668, 0x0);
			this.oCPU.AX.High = 0x11;
			this.oCPU.DX.Word = 0x73;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0700;
			this.oCPU.AX.High = 0xe;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x668, 0x0);
			this.oCPU.AX.High = 0x11;
			this.oCPU.DX.Word = 0x73;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L06ce;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x668), 0x0);
			if (this.oCPU.Flags.E) goto L0700;

		L06ce:
			this.oCPU.INT(0x11);
			this.oCPU.AX.Low = this.oCPU.ROLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.ROLByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x3);
			if (this.oCPU.Flags.NE) goto L06de;

		L06d8:
			this.oCPU.AX.Word = 0xffff;
			goto L0700;

		L06de:
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x668, 0x0);
			this.oCPU.AX.High = 0x19;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.XORByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.DX.Low = this.oCPU.AX.Low;
			this.oCPU.AX.High = 0xe;
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x11;
			this.oCPU.DX.Word = 0x73;
			this.oCPU.INT(0x21);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x668), 0x0);
			if (this.oCPU.Flags.NE) goto L06d8;

		L0700:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.High = 0x25;
			this.oCPU.AX.Low = 0x24;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x70);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6e);
			this.oCPU.INT(0x21);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_066a'");
		}

		public void F0_1000_0732(ushort offset)
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0732'(Undefined) at 0x1000:0x0732");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			if (this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5403) == 0)
			{
				switch (offset)
				{
					case 0x79a:
						this.oParent.VGADriver.F0_VGA_0c3e();
						break;
					case 0x7d9:
						this.oParent.VGADriver.F0_VGA_0224();
						break;
					case 0x842:
						this.oParent.VGADriver.F0_VGA_0270();
						break;
					case 0x849:
						this.oParent.VGADriver.F0_VGA_063c();
						break;
					case 0x850:
						this.oParent.VGADriver.F0_VGA_0d47();
						break;
					default:
						throw new Exception($"Unknown graphics jump address 0x{this.oCPU.ReadWord(this.oCPU.CS.Word, 0x743):x4}");
				}
				this.oCPU.CS.Word = 0x1000; // restore this function segment
			}
			else
			{
				this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5402, 0x1);

				switch (offset)
				{
					case 0x79a:
						this.oParent.VGADriver.F0_VGA_0c3e();
						break;
					case 0x7d9:
						this.oParent.VGADriver.F0_VGA_0224();
						break;
					case 0x842:
						this.oParent.VGADriver.F0_VGA_0270();
						break;
					case 0x849:
						this.oParent.VGADriver.F0_VGA_063c();
						break;
					case 0x850:
						this.oParent.VGADriver.F0_VGA_0d47();
						break;
					default:
						throw new Exception($"Unknown graphics jump address 0x{this.oCPU.ReadWord(this.oCPU.CS.Word, 0x743):x4}");
				}
				this.oCPU.CS.Word = 0x1000; // restore this function segment

			L075e:
				this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5402, this.oCPU.DECByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5402)));
				if (this.oCPU.Flags.E) goto L0769;

				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.DX.Word);
				this.oCPU.PushWord(this.oCPU.ES.Word);
				this.oCPU.AX.Word = 0x1000;
				this.oCPU.ES.Word = this.oCPU.AX.Word;
				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				this.oCPU.PushWord(0x17a7); // stack management - push return offset
				// Instruction address 0x1000:0x17a2, size: 5
				//this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.ES.Word, 0x7d9));
				this.oParent.VGADriver.F0_VGA_0224();
				this.oCPU.PopDWord(); // stack management - pop return offset, segment
				this.oCPU.CS.Word = 0x1000; // restore this function segment

				this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5876));
				this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5870);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x587a));
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x586e);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5878));
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = 0x1000;
				this.oCPU.ES.Word = this.oCPU.AX.Word;
				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				this.oCPU.PushWord(0x17c5); // stack management - push return offset
				// Instruction address 0x1000:0x17c0, size: 5
				//this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.ES.Word, 0x842));
				this.oParent.VGADriver.F0_VGA_0270();
				this.oCPU.PopDWord(); // stack management - pop return offset, segment
				this.oCPU.CS.Word = 0x1000; // restore this function segment
				this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

				this.oCPU.ES.Word = this.oCPU.PopWord();
				this.oCPU.DX.Word = this.oCPU.PopWord();
				this.oCPU.AX.Word = this.oCPU.PopWord();
				goto L075e;

			L0769:
				this.oCPU.AX.Word |= 0;
				//this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				// Instruction address 0x1000:0x0769, size: 4
				// return to caller
				//this.oCPU.JmpF(this.oCPU.ReadDWord(this.oCPU.DS.Word, 0x5404));
			}

			this.oCPU.Log.ExitBlock("'F0_1000_0732'");
		}

		public void F0_1000_0797()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0797'(Undefined) at 0x1000:0x0797");
			this.oCPU.CS.Word = 0x1000; // set this function segment
			MainRegistersCheck registers = new MainRegistersCheck(this.oCPU);
			// function body
			F0_1000_0732(0x079a);
			if (!registers.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");
			this.oCPU.Log.ExitBlock("'F0_1000_0797'");
		}

		public void F0_1000_07d6()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_07d6'(Undefined) at 0x1000:0x07d6");
			this.oCPU.CS.Word = 0x1000; // set this function segment
			MainRegistersCheck registers = new MainRegistersCheck(this.oCPU);
			// function body
			F0_1000_0732(0x07d9);
			if (!registers.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");
			this.oCPU.Log.ExitBlock("'F0_1000_07d6'");
		}

		public void F0_1000_083f()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_083f'(Undefined) at 0x1000:0x083f");
			this.oCPU.CS.Word = 0x1000; // set this function segment
			MainRegistersCheck registers = new MainRegistersCheck(this.oCPU);
			// function body
			F0_1000_0732(0x0842);
			if (!registers.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");
			this.oCPU.Log.ExitBlock("'F0_1000_083f'");
		}

		public void F0_1000_0846()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0846'(Undefined) at 0x1000:0x0846");
			this.oCPU.CS.Word = 0x1000; // set this function segment
			MainRegistersCheck registers = new MainRegistersCheck(this.oCPU);
			// function body
			F0_1000_0732(0x0849);
			if (!registers.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");
			this.oCPU.Log.ExitBlock("'F0_1000_0846'");
		}

		public void F0_1000_084d()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_084d'(Undefined) at 0x1000:0x084d");
			this.oCPU.CS.Word = 0x1000; // set this function segment
			MainRegistersCheck registers = new MainRegistersCheck(this.oCPU);
			// function body
			F0_1000_0732(0x0850);
			if (!registers.CheckMainRegisters(this.oCPU))
				throw new Exception("Return main registers doesn't match");
			this.oCPU.Log.ExitBlock("'F0_1000_084d'");
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

		public void F0_1000_0a76()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0a76'(Cdecl, Far) at 0x1000:0x0a76");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = 0xffff;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L0a89;
			// LEA
			this.oCPU.SI.Word = 0x5412;
			goto L0bdb;

		L0a89:
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x100);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x540c, this.oCPU.BX.Word);
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0a9e;
			// LEA
			this.oCPU.SI.Word = 0x542d;
			goto L0bdb;

		L0a9e:
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			// LEA
			this.oCPU.BX.Word = 0x5408;
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4b03;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(0x0ab2); // stack management - push return offset
			// Instruction address 0x1000:0x0aaf, size: 3
			F0_1000_0bba();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.AE) goto L0ad5;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L0ac0;
			// LEA
			this.oCPU.SI.Word = 0x5463;
			goto L0bdb;

		L0ac0:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.NE) goto L0acc;
			// LEA
			this.oCPU.SI.Word = 0x5476;
			goto L0bdb;

		L0acc:
			if (this.oCPU.Flags.E) goto L0ad5;
			// LEA
			this.oCPU.SI.Word = 0x5495;
			goto L0bdb;

		L0ad5:
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5408);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2a);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2c);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.AX.Word = this.oCPU.RCRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0af9;
			this.oCPU.PushWord(0x0af9); // stack management - push return offset
			// Instruction address 0x1000:0x0af6, size: 3
			F0_1000_0b1e();
			this.oCPU.PopWord(); // stack management - pop return offset

		L0af9:
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x540c));
			if (this.oCPU.Flags.BE) goto L0b0d;
			// LEA
			this.oCPU.SI.Word = 0x54b9;
			goto L0bdb;

		L0b0d:
			this.oCPU.AX.High = 0x4a;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0b1a;
			// LEA
			this.oCPU.SI.Word = 0x54de;
			goto L0bdb;

		L0b1a:
			this.oCPU.AX.Word = this.oCPU.ES.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0a76'");
			return;

		L0bdb:
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
			this.oCPU.AX.Word = 0x4c99;
			this.oCPU.INT(0x21);
		}

		public void F0_1000_0b1e()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0b1e'(Cdecl, Near) at 0x1000:0x0b1e");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
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
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L0b6c;
			// LEA
			this.oCPU.SI.Word = 0x5463;
			goto L0bdb;

		L0b6c:
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DS.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0b1e'");
			return;

		L0bdb:
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
			this.oCPU.AX.Word = 0x4c99;
			this.oCPU.INT(0x21);
		}

		public void F0_1000_0b70()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0b70'(Cdecl, Far) at 0x1000:0x0b70");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = 0x32;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2e);
			this.oCPU.DX.Low = 0x7;
			this.oCPU.MULByte(this.oCPU.AX, this.oCPU.DX.Low);
			// LEA
			this.oCPU.DI.Word = 0x76d;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1000;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x30);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x28);

		L0b95:
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x3);
			this.oCPU.MOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.STOSWord();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0b95;
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0b70'");
		}

		public void F0_1000_0bba()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0bba'(Cdecl, Near) at 0x1000:0x0bba");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			// DS:DX = pointer to an ASCIIZ filename
			// ES:BX = pointer to a parameter block
			string sFileName = this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.DX.Word));
			ushort usSegment = this.oCPU.Memory.ReadWord(CPUMemory.ToLinearAddress(this.oCPU.ES.Word, this.oCPU.BX.Word));

			switch (sFileName.ToLower())
			{
				case "misc.exe":
					this.oParent.MiscDriver.Segment = usSegment;
					break;

				case "mgraphic.exe":
					this.oParent.VGADriver.Segment = usSegment;
					break;

				case "nsound.cvl":
					this.oParent.SoundDriver.Segment = usSegment;
					break;

				default:
					throw new Exception("Unknown overlay name");
			}

			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0xbb8, this.oCPU.SS.Word);
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0xbb6, this.oCPU.SP.Word);
			this.oCPU.INT(0x21);
			this.oCPU.SS.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0xbb8);
			this.oCPU.SP.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0xbb6);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0bba'");
		}

		public void F0_1000_0bfa()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0bfa'(Cdecl, Far) at 0x1000:0x0bfa");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0c6d;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0c6d;
			this.oCPU.PushWord(0x0c0e); // stack management - push return offset
			// Instruction address 0x1000:0x0c0b, size: 3
			F0_1000_0c8e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0c18); // stack management - push return offset
			// Instruction address 0x1000:0x0c13, size: 5
			this.oParent.VGADriver.F0_VGA_0484();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4)));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5858, this.oCPU.SI.Word);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// LEA
			this.oCPU.DI.Word = 0x5534;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2)));
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.REPESTOSWord();
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			// LEA
			this.oCPU.DI.Word = 0x56c4;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.REPESTOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0c53); // stack management - push return offset
			// Instruction address 0x1000:0x0c4e, size: 5
			this.oParent.VGADriver.F0_VGA_020c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5858);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x585a, this.oCPU.CX.Word);
			this.oCPU.BX.Word = 0x5534;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0c68); // stack management - push return offset
			// Instruction address 0x1000:0x0c63, size: 5
			this.oParent.VGADriver.F0_VGA_040a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment

		L0c6d:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_0bfa'");
		}

		public void F0_1000_0c8e()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0c8e'(Cdecl, Near) at 0x1000:0x0c8e");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x3b01;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5858);
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.S) goto L0cc3;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x585a);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x5534);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.REPESTOSWord();
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5858, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.BX.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x56c4);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.REPESTOSWord();
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x585a, this.oCPU.AX.Word);

		L0cc3:
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0c8e'");
		}

		public void F0_1000_0e3c()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0e3c'(Cdecl, Near) at 0x1000:0x0e3c");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			// division by zero handler
			//this.oCPU.ES.Word = 0;
			//this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.ES.Word, 0x0));
			//this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2));
			//this.oCPU.WriteWord(this.oCPU.ES.Word, 0x0, 0xfe9);
			//this.oCPU.WriteWord(this.oCPU.ES.Word, 0x2, 0x1000);

			this.oCPU.ES.Word = this.oCPU.DS.Word;
			goto L0ec4;

		L0e5e:
			//this.oCPU.ES.Word = 0;
			//this.oCPU.WriteWord(this.oCPU.ES.Word, 0x2, this.oCPU.PopWord());
			//this.oCPU.WriteWord(this.oCPU.ES.Word, 0x0, this.oCPU.PopWord());

			this.oCPU.ES.Word = this.oCPU.DS.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552c);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5530);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552e);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5532);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0e82); // stack management - push return offset
			// Instruction address 0x1000:0x0e7d, size: 5
			this.oParent.VGADriver.F0_VGA_0599();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.Flags.C = false;

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0e3c'");
			return;

		L0e84:
			//this.oCPU.ES.Word = 0;
			//this.oCPU.WriteWord(this.oCPU.ES.Word, 0x2, this.oCPU.PopWord());
			//this.oCPU.WriteWord(this.oCPU.ES.Word, 0x0, this.oCPU.PopWord());

			this.oCPU.ES.Word = this.oCPU.DS.Word;
			this.oCPU.Flags.C = true;

			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0e3c'");
			return;

		L0e96:
			this.oCPU.Flags.C = !this.oCPU.Flags.C;
			this.oCPU.DX.Word = this.oCPU.RCRWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5861, this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.SARWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5865, this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.NO) goto L0eaf;
			this.oCPU.Flags.C = !this.oCPU.Flags.C;
			this.oCPU.DX.Word = this.oCPU.RCRWord(this.oCPU.DX.Word, 0x1);
			goto L0f1f;

		L0eaf:
			this.oCPU.DX.Word = this.oCPU.SARWord(this.oCPU.DX.Word, 0x1);
			goto L0f1f;

		L0eb4:
			this.oCPU.Flags.C = !this.oCPU.Flags.C;
			this.oCPU.DX.Word = this.oCPU.RCRWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5861, this.oCPU.SARWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5861), 0x1));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5865, this.oCPU.SARWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5865), 0x1));
			goto L0f1f;

		L0ec2:
			goto L0e84;

		L0ec4:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552c);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5530);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552e);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5532);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.BP.Word = this.oCPU.DX.Word;
			this.oCPU.PushWord(0x0edb); // stack management - push return offset
			// Instruction address 0x1000:0x0ed8, size: 3
			F0_1000_0fc8();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5860, this.oCPU.AX.Low);
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BP.Word = this.oCPU.DI.Word;
			this.oCPU.PushWord(0x0ee5); // stack management - push return offset
			// Instruction address 0x1000:0x0ee2, size: 3
			F0_1000_0fc8();
			this.oCPU.PopWord(); // stack management - pop return offset
			if (this.oCPU.Flags.NE) goto L0f01;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5860), 0x0);
			if (this.oCPU.Flags.NE) goto L0ef1;
			goto L0e5e;

		L0ef1:
			this.oCPU.Temp.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.Temp.Word;
			this.oCPU.Temp.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5860);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5860, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x552c, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5530, this.oCPU.DX.Word);

		L0f01:
			this.oCPU.TESTByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5860));
			if (this.oCPU.Flags.NE) goto L0ec2;
			this.oCPU.BP.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.SI.Word;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.O) goto L0e96;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5861, this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.SARWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5865, this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.O) goto L0eb4;

		L0f1f:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5863, this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.SARWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5867, this.oCPU.DX.Word);

		L0f29:
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x9);
			if (this.oCPU.Flags.E) goto L0f65;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.S) goto L0f37;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5869);

		L0f37:
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5863));
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5861));
			this.oCPU.BX.Low = this.oCPU.BX.High;
			this.oCPU.BX.Low = this.oCPU.XORByte(this.oCPU.BX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5862));
			if (this.oCPU.Flags.NS) goto L0f51;
			this.oCPU.DX.Word = this.oCPU.NEGWord(this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);

		L0f51:
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5865));
			this.oCPU.DX.High = this.oCPU.XORByte(this.oCPU.DX.High, this.oCPU.BX.High);
			if (this.oCPU.Flags.S) goto L0f5a;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);

		L0f5a:
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.S) goto L0f6d;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x586b));
			if (this.oCPU.Flags.LE) goto L0f9e;

		L0f65:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x586b);
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.G) goto L0f6f;

		L0f6d:
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.BX.Word);

		L0f6f:
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.BP.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5861));
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5863));
			this.oCPU.BX.Low = this.oCPU.BX.High;
			this.oCPU.BX.Low = this.oCPU.XORByte(this.oCPU.BX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5864));
			if (this.oCPU.Flags.NS) goto L0f89;
			this.oCPU.DX.Word = this.oCPU.NEGWord(this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);

		L0f89:
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5867));
			this.oCPU.DX.High = this.oCPU.XORByte(this.oCPU.DX.High, this.oCPU.BX.High);
			if (this.oCPU.Flags.S) goto L0f92;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);

		L0f92:
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L0faf;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5869));
			if (this.oCPU.Flags.G) goto L0faf;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;

		L0f9e:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5860), 0x0);
			if (this.oCPU.Flags.NE) goto L0fb2;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5532, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x552e, this.oCPU.BX.Word);
			goto L0e5e;

		L0faf:
			goto L0e84;

		L0fb2:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5530, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x552c, this.oCPU.BX.Word);
			this.oCPU.Temp.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.Temp.Word;
			this.oCPU.Temp.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5860);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5860, 0x0);
			goto L0f29;
		}

		public void F0_1000_0fc8()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_0fc8'(Cdecl, Near) at 0x1000:0x0fc8");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Low = 0xf;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.S) goto L0fd0;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xf7);

		L0fd0:
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5869));
			if (this.oCPU.Flags.G) goto L0fd8;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfe);

		L0fd8:
			this.oCPU.BP.Word = this.oCPU.ORWord(this.oCPU.BP.Word, this.oCPU.BP.Word);
			if (this.oCPU.Flags.S) goto L0fde;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfb);

		L0fde:
			this.oCPU.CMPWord(this.oCPU.BP.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x586b));
			if (this.oCPU.Flags.G) goto L0fe6;
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfd);

		L0fe6:
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_0fc8'");
		}

		public void F0_1000_100a()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_100a'(Cdecl, Far) at 0x1000:0x100a");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5869, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x586b, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1023); // stack management - push return offset
			// Instruction address 0x1000:0x101e, size: 5
			this.oParent.VGADriver.F0_VGA_046d();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x552c, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5530, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x552e, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5532, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1043); // stack management - push return offset
			// Instruction address 0x1000:0x103e, size: 5
			this.oParent.VGADriver.F0_VGA_020c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.PushWord(0x1046); // stack management - push return offset
			// Instruction address 0x1000:0x1043, size: 3
			F0_1000_0e3c();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_100a'");
		}

		public void F0_1000_104f()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_104f'(Cdecl, Far) at 0x1000:0x104f");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.S) goto L108a;
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6)));
			if (this.oCPU.Flags.G) goto L108a;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.S) goto L108a;
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8)));
			if (this.oCPU.Flags.G) goto L108a;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1074); // stack management - push return offset
			// Instruction address 0x1000:0x106f, size: 5
			this.oParent.VGADriver.F0_VGA_046d();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x107c); // stack management - push return offset
			// Instruction address 0x1000:0x1077, size: 5
			this.oParent.VGADriver.F0_VGA_020c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1085); // stack management - push return offset
			// Instruction address 0x1000:0x1080, size: 5
			this.oParent.VGADriver.F0_VGA_0550();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment

		L108a:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_104f'");
		}

		public void F0_1000_13c8()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_13c8'(Cdecl, Far) at 0x1000:0x13c8");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.High = 0x3c;
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6afe, this.oCPU.AX.Word);
			if (this.oCPU.Flags.B) goto L1411;
			this.oCPU.AX.High = 0x48;
			this.oCPU.BX.Word = 0x5ff;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b04, this.oCPU.AX.Word);
			if (this.oCPU.Flags.B) goto L1411;
			// LEA
			this.oCPU.DI.Word = 0xd936;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x3058;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = 0x0;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.STOSWord();
			this.oParent.Var_b26e = this.oCPU.DI.Word;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x6b08, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x6b09, this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, 0xffff);

		L1411:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_13c8'");
		}

		public void F0_1000_1414()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1414'(Cdecl, Far) at 0x1000:0x1414");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b02);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b04);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.PushWord(0x142a); // stack management - push return offset
			// Instruction address 0x1000:0x1427, size: 3
			F0_1000_15cd();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(0x142d); // stack management - push return offset
			// Instruction address 0x1000:0x142a, size: 3
			F0_1000_1620();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, 0x0);
			this.oCPU.AX.High = 0x49;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b04);
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L1440;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L1440:
			this.oCPU.AX.High = 0x42;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L1453;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L1453:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.High = 0x42;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = 0x2;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L146b;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L146b:
			this.oCPU.AX.High = 0x40;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.DX.Word = this.oCPU.SP.Word;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L147d;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L147d:
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.AX.High = 0x3e;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afe);
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L148b;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, this.oCPU.AX.Word);

		L148b:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b06);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1414'");
		}

		public void F0_1000_148f()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_148f'(Cdecl, Far) at 0x1000:0x148f");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BP.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b02);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b06), 0xffff);
			if (this.oCPU.Flags.E) goto L1500;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b00);
			this.oCPU.STOSByte();
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b00, this.oCPU.DI.Word);
			this.oCPU.PushWord(0x14b2); // stack management - push return offset
			// Instruction address 0x1000:0x14af, size: 3
			F0_1000_1565();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.CMPWord(this.oCPU.BX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L14bf;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b02, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_148f'");
			return;

		L14bf:
			// LEA
			this.oCPU.SI.Word = 0xba06;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b00, this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b02, this.oCPU.AX.Word);
			this.oCPU.PushWord(0x14d0); // stack management - push return offset
			// Instruction address 0x1000:0x14cd, size: 3
			F0_1000_1558();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = this.oCPU.BP.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.BP.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.BP.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.PushWord(0x14df); // stack management - push return offset
			// Instruction address 0x1000:0x14dc, size: 3
			F0_1000_15cd();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x6b0a);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afc), this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L14fc;
			this.oCPU.CX.Low = this.oCPU.INCByte(this.oCPU.CX.Low);
			this.oCPU.CMPByte(this.oCPU.CX.Low, 0xb);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x6b0a, this.oCPU.CX.Low);
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
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b06, 0x0);
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.STOSByte();
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b00, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6b02, this.oCPU.AX.Word);
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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b04);
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
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x6b0a, 0x9);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6afc, 0x101);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1524'");
		}

		public void F0_1000_1558()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1558'(Cdecl, Near) at 0x1000:0x1558");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.BP.Word;
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afc);
			this.oCPU.STOSWord();
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6afc, this.oCPU.AX.Word);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1558'");
		}

		public void F0_1000_1565()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1565'(Cdecl, Near) at 0x1000:0x1565");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.BX.Word = 0x0;
			// LEA
			this.oCPU.DI.Word = 0xba06;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b00);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.BX.Low);

		L1571:
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word));
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
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b04);

		L15a5:
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.AE) goto L15a5;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, this.oCPU.DI.Word), 0xffff);
			if (this.oCPU.Flags.NE) goto L15bd;
			this.oCPU.BX.Word = 0xffff;
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_1565'");
			return;

		L15bd:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, this.oCPU.DI.Word), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L15c9;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x2)), this.oCPU.BP.Word);
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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x6b0a);
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x6b08);
			this.oCPU.DX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x6b09);

		L15d9:
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			if (this.oCPU.Flags.S) goto L1617;
			this.oCPU.CMPByte(this.oCPU.DX.Low, 0x8);
			if (this.oCPU.Flags.B) goto L160f;
			this.oCPU.BX.Word = this.oParent.Var_b26e;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.DX.High);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CMPWord(this.oCPU.BX.Word, Civilization.Constant_5528);
			if (this.oCPU.Flags.B) goto L160b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.AX.High = 0x40;
			this.oCPU.CX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afe);
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
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x6b08, this.oCPU.DX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x6b09, this.oCPU.DX.High);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_15cd'");
		}

		public void F0_1000_1620()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1620'(Cdecl, Near) at 0x1000:0x1620");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x6b0a, 0x8);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.PushWord(0x162a); // stack management - push return offset
			// Instruction address 0x1000:0x1627, size: 3
			F0_1000_15cd();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.High = 0x40;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6afe);
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
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0xcc);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.ES.Word, 0xce));
			if (this.oCPU.Flags.E) goto L1683;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.INT(0x33);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1683;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.CX.Word = 0x1f;
			this.oCPU.DX.Word = this.oCPU.CS.Word;
			this.oCPU.ES.Word = this.oCPU.DX.Word;
			// LEA
			this.oCPU.DX.Word = 0x17db;
			this.oCPU.INT(0x33);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.INT(0x33);
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = this.oCPU.CX.High;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x587c, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x586e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5870, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5872, this.oCPU.BX.Word);
			this.oCPU.AX.Word = 0xffff;

		L1683:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x587d, this.oCPU.AX.Low);
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_163e_InitMouse'");
		}

		public void F0_1000_1687()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1687'(Cdecl, Far) at 0x1000:0x1687");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Low = 0x0;
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x587d);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x587d, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L1696;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.INT(0x33);

		L1696:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1687'");
		}

		public void F0_1000_1697()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_1697'(Cdecl, Far) at 0x1000:0x1697");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5878, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x587a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5876, this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_1697'");
		}

		public void F0_1000_16ae()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_16ae'(Cdecl, Far) at 0x1000:0x16ae");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x586e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5870, this.oCPU.DX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x587d), 0x0);
			if (this.oCPU.Flags.E) goto L16d2;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x587c);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x4;
			this.oCPU.INT(0x33);

		L16d2:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_16ae'");
		}

		public void F0_1000_16d4()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_16d4'(Cdecl, Far) at 0x1000:0x16d4");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oCPU.Temp.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5874);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5874, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.Temp.Word;
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_16d4'");
		}

		public void F0_1000_16db()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_16db'(Cdecl, Far) at 0x1000:0x16db");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L170a;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.NE) goto L170a;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5876));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5870);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x587a));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x586e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5878));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1702); // stack management - push return offset
			// Instruction address 0x1000:0x16fd, size: 5
			F0_1000_083f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5403, 0x1);

		L170a:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_16db'");
		}

		public void F0_1000_170b()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_170b'(Cdecl, Far) at 0x1000:0x170b");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5876), 0x0);
			if (this.oCPU.Flags.E) goto L1723;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5403), 0x0);
			if (this.oCPU.Flags.E) goto L1723;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5403, 0x0);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x1723); // stack management - push return offset
			// Instruction address 0x1000:0x171e, size: 5
			F0_1000_07d6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment

		L1723:
			// Far return
			this.oCPU.Log.ExitBlock("'F0_1000_170b'");
		}

		public void F0_1000_179a()
		{
			this.oCPU.Log.EnterBlock("'F0_1000_179a'(Cdecl, Near) at 0x1000:0x179a");
			this.oCPU.CS.Word = 0x1000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.AX.Word = 0x1000;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x17a7); // stack management - push return offset
			// Instruction address 0x1000:0x17a2, size: 5
			//this.oCPU.CallF(this.oCPU.ReadDWord(0x1000, 0x7d9));
			this.oParent.VGADriver.F0_VGA_0224();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5876));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5870);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x587a));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x586e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5878));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1000;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x17c5); // stack management - push return offset
			// Instruction address 0x1000:0x17c0, size: 5
			//this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.ES.Word, 0x842));
			this.oParent.VGADriver.F0_VGA_0270();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x1000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_1000_179a'");
		}
	}
}
