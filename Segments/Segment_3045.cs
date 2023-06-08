using Disassembler;

namespace Civilization1
{
	public class Segment_3045
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_3045(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_3045_0014()
		{
			this.oCPU.Log.EnterBlock("'F0_3045_0014'(Undefined) at 0x3045:0x0014");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.AX.High = 0x30;
			this.oCPU.INT(0x21);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x2);
			if (this.oCPU.Flags.AE) goto L001e;
			this.oCPU.INT(0x20);

		L001e:
			this.oCPU.DI.Word = 0x3b01;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x1000);
			if (this.oCPU.Flags.B) goto L0030;
			this.oCPU.SI.Word = 0x1000;

		L0030:
			this.oCPU.CLI();
			this.oCPU.SS.Word = this.oCPU.DI.Word;
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xe8be);
			this.oCPU.STI();
			if (this.oCPU.Flags.AE) goto L004e;
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0041); // stack management - push return offset
			// Instruction address 0x3045:0x003c, size: 5
			this.oParent.MSCAPI._FF_MSGBANNER();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0049); // stack management - push return offset
			// Instruction address 0x3045:0x0044, size: 5
			this.oParent.MSCAPI._NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = 0x4cff;
			this.oCPU.INT(0x21);

		L004e:
			this.oCPU.SP.Word = this.oCPU.ANDWord(this.oCPU.SP.Word, 0xfffe);
			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x5890, this.oCPU.SP.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x588c, this.oCPU.SP.Word);
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x588a, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.ES.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
			this.oCPU.AX.High = 0x4a;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.SS.Word, 0x5901, this.oCPU.DS.Word);
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.Flags.D = false;
			this.oCPU.DI.Word = 0x652e;
			this.oCPU.CX.Word = 0xe8c0;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.REPESTOSByte();
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0091); // stack management - push return offset
			// Instruction address 0x3045:0x008c, size: 5
			this.oParent.MSCAPI._cinit();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0098); // stack management - push return offset
			// Instruction address 0x3045:0x0093, size: 5
			this.oParent.Segment_11a8.F0_11a8_01c1();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x009d); // stack management - push return offset
			// Instruction address 0x3045:0x0098, size: 5
			this.oParent.MSCAPI._setargv();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.BP.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5922));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5920));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x591e));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00b0); // stack management - push return offset
			// Instruction address 0x3045:0x00ab, size: 5
			this.oParent.Segment_11a8.F0_11a8_0008_Main();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00b6); // stack management - push return offset
			// Instruction address 0x3045:0x00b1, size: 5
			// this.oCPU.Call(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x588e));
			this.oParent.MSCAPI.exit();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
		}

		public void F0_3045_0229()
		{
			this.oCPU.Log.EnterBlock("'F0_3045_0229'(Cdecl, Near) at 0x3045:0x0229");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body

		L0229:
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.AE) goto L023b;
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2)));
			if (this.oCPU.Flags.E) goto L0229;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0239); // stack management - push return offset
			// Instruction address 0x3045:0x0237, size: 2
			this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.DS.Word, this.oCPU.DI.Word));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			goto L0229;

		L023b:
			// Near return
			this.oCPU.Log.ExitBlock("'F0_3045_0229'");
		}

		public void F0_3045_056e()
		{
			this.oCPU.Log.EnterBlock("'F0_3045_056e'(Cdecl, Near) at 0x3045:0x056e");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x5906, this.oCPU.AX.Low);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.NE) goto L0598;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5903), 0x3);
			if (this.oCPU.Flags.B) goto L0589;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.AE) goto L058d;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.B) goto L0589;
			this.oCPU.AX.Low = 0x5;
			goto L058f;

		L0589:
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x13);
			if (this.oCPU.Flags.BE) goto L058f;

		L058d:
			this.oCPU.AX.Low = 0x13;

		L058f:
			this.oCPU.BX.Word = 0x5940;
			this.oCPU.XLAT(this.oCPU.AX, this.oCPU.DS, this.oCPU.BX);

		L0593:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x58fb, this.oCPU.AX.Word);
			// Near return
			this.oCPU.Log.ExitBlock("'F0_3045_056e'");
			return;

		L0598:
			this.oCPU.AX.Low = this.oCPU.AX.High;
			goto L0593;
		}

		public void F0_3045_2b12()
		{
			this.oCPU.Log.EnterBlock("'F0_3045_2b12'(Cdecl, Near) at 0x3045:0x2b12");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.AX.High = 0x2;

		L2b19:
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.DX.Low = this.oCPU.ORByte(this.oCPU.DX.Low, this.oCPU.DX.Low);
			if (this.oCPU.Flags.E) goto L2b24;
			this.oCPU.INT(0x21);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			goto L2b19;

		L2b24:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_3045_2b12'");
		}

		public void Start()
		{
			this.oCPU.Log.EnterBlock("'Start'(Cdecl, Far) at 0x3045:0x2e7f");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x3b01;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.AX.High = 0x30;
			this.oCPU.INT(0x21);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x2);
			if (this.oCPU.Flags.AE) goto L2e98;
			this.oCPU.DX.Word = 0x61a6;
			this.oCPU.PushWord(0x2e93); // stack management - push return offset
			// Instruction address 0x3045:0x2e90, size: 3
			F0_3045_2b12();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Far return
			this.oCPU.Log.ExitBlock("'Start'");
			return;

		L2e98:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x592c, 0x1);
			this.oCPU.DI.Word = 0x63db;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x592d, this.oCPU.AX.Low);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.AX.High = 0x35;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x592e, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5930, this.oCPU.ES.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.DX.Word = this.oCPU.CS.Word;
			this.oCPU.DS.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = 0x2d5a;
			this.oCPU.AX.High = 0x25;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = 0x3b01;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.PushWord(0x2ec8); // stack management - push return offset
			// Instruction address 0x3045:0x2ec5, size: 3
			F0_3045_2ed2();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			// Instruction address 0x3045:0x2ecd, size: 5
			F0_3045_0014();
			this.oCPU.Log.ExitBlock("'Start'");
			return;
		}

		public void F0_3045_2ed2()
		{
			this.oCPU.Log.EnterBlock("'F0_3045_2ed2'(Cdecl, Near) at 0x3045:0x2ed2");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.DX.Word = 0x63cc;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.AX.High = 0x3d;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L2f2e;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = 0x6156;
			this.oCPU.AX.High = 0x19;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61ee, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, 0x3a);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, 0x5c);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.High = 0x47;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.INT(0x21);

		L2f03:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2f13;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x2f);
			if (this.oCPU.Flags.NE) goto L2f10;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, 0x5c);

		L2f10:
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			goto L2f03;

		L2f13:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x1)), 0x5c);
			if (this.oCPU.Flags.E) goto L2f1d;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, 0x5c);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);

		L2f1d:
			this.oCPU.DI.Word = 0x63cc;

		L2f20:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L2f20;
			this.oCPU.Flags.C = false;
			goto L3043;

		L2f2e:
			this.oCPU.DI.Word = 0x2c;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.ES.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = 0x0;

		L2f38:
			this.oCPU.SI.Word = 0x62ee;

		L2f3b:
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.DX.Low = this.oCPU.ORByte(this.oCPU.DX.Low, this.oCPU.DX.Low);
			if (this.oCPU.Flags.E) goto L2f60;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2f56;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.DX.Low);
			if (this.oCPU.Flags.E) goto L2f3b;

		L2f4e:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L2f4e;

		L2f56:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L2f38;
			goto L2fc4;

		L2f60:
			this.oCPU.SI.Word = 0x6156;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x1)), 0x3a);
			if (this.oCPU.Flags.E) goto L2f77;
			this.oCPU.AX.High = 0x19;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, 0x3a);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);

		L2f77:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2f8e;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x3b);
			if (this.oCPU.Flags.E) goto L2f8e;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x2f);
			if (this.oCPU.Flags.NE) goto L2f88;
			this.oCPU.AX.Low = 0x5c;

		L2f88:
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			goto L2f77;

		L2f8e:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x1)), 0x5c);
			if (this.oCPU.Flags.E) goto L2f98;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, 0x5c);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);

		L2f98:
			this.oCPU.BX.Word = 0x63cc;

		L2f9b:
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.DX.Low);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.DX.Low = this.oCPU.ORByte(this.oCPU.DX.Low, this.oCPU.DX.Low);
			if (this.oCPU.Flags.NE) goto L2f9b;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x6156);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61ee, this.oCPU.AX.Low);
			this.oCPU.DX.Word = 0x6156;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.AX.High = 0x3d;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L2fbf;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word), 0x0);
			if (this.oCPU.Flags.E) goto L2fc4;
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			goto L2f60;

		L2fbf:
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			goto L3043;

		L2fc4:
			this.oCPU.DX.Word = 0x626a;
			this.oCPU.PushWord(0x2fca); // stack management - push return offset
			// Instruction address 0x3045:0x2fc7, size: 3
			F0_3045_2b12();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DX.Word = 0x63cc;
			this.oCPU.PushWord(0x2fd0); // stack management - push return offset
			// Instruction address 0x3045:0x2fcd, size: 3
			F0_3045_2b12();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DX.Word = 0x629a;
			this.oCPU.PushWord(0x2fd6); // stack management - push return offset
			// Instruction address 0x3045:0x2fd3, size: 3
			F0_3045_2b12();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DX.Word = 0x6054;
			this.oCPU.AX.High = 0xa;
			this.oCPU.INT(0x21);
			this.oCPU.DX.Low = 0xa;
			this.oCPU.AX.High = 0x2;
			this.oCPU.INT(0x21);
			this.oCPU.BX.High = 0x0;
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x6055);
			this.oCPU.BX.Low = this.oCPU.ORByte(this.oCPU.BX.Low, this.oCPU.BX.Low);
			if (this.oCPU.Flags.E) goto L2fc4;
			this.oCPU.SI.Word = 0x6056;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
			this.oCPU.DI.Word = 0x6156;
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1)), 0x3a);
			if (this.oCPU.Flags.E) goto L300d;
			this.oCPU.AX.High = 0x19;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, 0x3a);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);

		L300d:
			this.oCPU.Flags.D = false;
			this.oCPU.AX.High = 0x0;

		L3010:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L301b;
			this.oCPU.AX.High = this.oCPU.AX.Low;
			goto L3010;

		L301b:
			this.oCPU.DI.Word = this.oCPU.DECWord(this.oCPU.DI.Word);
			this.oCPU.CMPByte(this.oCPU.AX.High, 0x5c);
			if (this.oCPU.Flags.E) goto L3026;
			this.oCPU.CMPByte(this.oCPU.AX.High, 0x3a);
			if (this.oCPU.Flags.NE) goto L3030;

		L3026:
			this.oCPU.SI.Word = 0x63cc;

		L3029:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L3029;

		L3030:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0x6156);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x61ee, this.oCPU.AX.Low);
			this.oCPU.DX.Word = 0x6156;
			this.oCPU.AX.Low = 0x0;
			this.oCPU.AX.High = 0x3d;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L2fc4;
			this.oCPU.BX.Word = this.oCPU.AX.Word;

		L3043:
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.DX.Word = this.oCPU.PopWord();
			this.oCPU.BX.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.PopWord();
			// Near return
			this.oCPU.Log.ExitBlock("'F0_3045_2ed2'");
		}
	}
}
