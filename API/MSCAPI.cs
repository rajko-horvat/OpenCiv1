using Disassembler;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace Civilization1
{
	public class MSCAPI
	{
		private Civilization oParent;
		private CPU oCPU;
		private RandomMT19937 oRNG = new RandomMT19937();

		public MSCAPI(Civilization parent)
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
										// Instruction uiAddress 0x3045:0x003c, size: 5
			this.oParent.MSCAPI._FF_MSGBANNER();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0049); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x0044, size: 5
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
										// Instruction uiAddress 0x3045:0x008c, size: 5
			this.oParent.MSCAPI._cinit();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0098); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x0093, size: 5
			this.oParent.Segment_11a8.F0_11a8_01c1();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x009d); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x0098, size: 5
			this.oParent.MSCAPI._setargv();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.BP.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5922));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5920));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x591e));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00b0); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x00ab, size: 5
			this.oParent.Segment_11a8.F0_11a8_0008_Main();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment

			this.oParent.MSCAPI.exit((short)this.oCPU.AX.Word);
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
										// Instruction uiAddress 0x3045:0x0237, size: 2
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
										// Instruction uiAddress 0x3045:0x2fc7, size: 3
			F0_3045_2b12();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DX.Word = 0x63cc;
			this.oCPU.PushWord(0x2fd0); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x2fcd, size: 3
			F0_3045_2b12();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DX.Word = 0x629a;
			this.oCPU.PushWord(0x2fd6); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x2fd3, size: 3
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

		public void DivisionByZero()
		{
			this.oCPU.Log.EnterBlock("'DivisionByZero'(Cdecl) at 0x0000:0x0000");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.Log.ExitBlock("'DivisionByZero'");
		}

		public void _cinit()
		{
			this.oCPU.Log.EnterBlock("'_cinit'(Cdecl) at 0x3045:0x00da");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L00da;

		L00c5:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x00cb); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x00c6, size: 5
			_FF_MSGBANNER();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x00d0); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x00cb, size: 5
			_NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.Exit(0xff);

		L00da:
			this.oCPU.AX.High = 0x30;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5903, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3500;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x58ef, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x58f1, this.oCPU.ES.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = 0x2500;
			this.oCPU.DX.Word = 0xb6;
			this.oCPU.INT(0x21);
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6306);
			if (this.oCPU.CX.Word == 0) goto L012e;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5901);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2c);
			// LDS
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6308);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(0x6308 + 2));
			this.oCPU.DX.Word = this.oCPU.DS.Word;
			this.oCPU.BX.Word = 0x0;
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0116); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x0111, size: 5
			this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.SS.Word, 0x6304));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			if (this.oCPU.Flags.AE) goto L011d;
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			goto L0260;

		L011d:
			// LDS
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, 0x630c);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(0x630c + 2));
			this.oCPU.DX.Word = this.oCPU.DS.Word;
			this.oCPU.BX.Word = 0x3;
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x012c); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x0127, size: 5
			this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.SS.Word, 0x6304));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();

		L012e:
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5901);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2c);
			if (this.oCPU.CX.Word == 0) goto L016f;
			this.oCPU.ES.Word = this.oCPU.CX.Word;
			this.oCPU.DI.Word = 0x0;

		L013d:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, this.oCPU.DI.Word), 0x0);
			if (this.oCPU.Flags.E) goto L016f;
			this.oCPU.CX.Word = 0xc;
			this.oCPU.SI.Word = 0x58e2;
			this.oCPU.REPECMPSByte(this.oCPU.ES, this.oCPU.DI, this.oCPU.DS, this.oCPU.SI);
			if (this.oCPU.Flags.E) goto L0158;
			this.oCPU.CX.Word = 0x7fff;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.REPNESCASByte();
			if (this.oCPU.Flags.NE) goto L016f;
			goto L013d;

		L0158:
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = 0x590a;
			this.oCPU.LODSByte();
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.Temp.Word;

		L0164:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.INCByte(this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L016a;
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);

		L016a:
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L0164;
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();

		L016f:
			this.oCPU.BX.Word = 0x4;

		L0172:
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0xbf));
			this.oCPU.AX.Word = 0x4400;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L0188;
			this.oCPU.TESTByte(this.oCPU.DX.Low, 0x80);
			if (this.oCPU.Flags.E) goto L0188;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x40));

		L0188:
			this.oCPU.BX.Word = this.oCPU.DECWord(this.oCPU.BX.Word);
			if (this.oCPU.Flags.NS) goto L0172;
			this.oCPU.SI.Word = 0x6310;
			this.oCPU.DI.Word = 0x6310;
			this.oCPU.PushWord(0x0194); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x0191, size: 3
			F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset and segment
			this.oCPU.SI.Word = 0x6310;
			this.oCPU.DI.Word = 0x6310;
			this.oCPU.PushWord(0x019d); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x019a, size: 3
			F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset and segment
			this.oCPU.Log.ExitBlock("'_cinit'");
			return;

		L0260:
			this.oCPU.AX.Word = 0x2;
			goto L00c5;
		}

		public void exit(short code)
		{
			this.oCPU.Log.WriteLine($"exit({code})");
			this.oCPU.Exit(code);
		}

		public void _FF_MSGBANNER()
		{
			this.oCPU.Log.EnterBlock("'_FF_MSGBANNER'(Cdecl) at 0x3045:0x023c");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = 0xfc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0248); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x0243, size: 5
			_NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5934), 0x0);
			if (this.oCPU.Flags.E) goto L0253;
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0253); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x024f, size: 4
			this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.DS.Word, 0x5932));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment

		L0253:
			this.oCPU.AX.Word = 0xff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x025c); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x0257, size: 5
			_NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'_FF_MSGBANNER'");
		}

		public void _setargv()
		{
			this.oCPU.Log.EnterBlock("'_setargv'(Cdecl) at 0x3045:0x02b0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x593c, this.oCPU.PopWord());
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x593e, this.oCPU.PopWord());
			this.oCPU.DX.Word = 0x2;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5903), this.oCPU.DX.Low);
			if (this.oCPU.Flags.E) goto L02ea;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5901);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, 0x2c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5926, this.oCPU.ES.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x8000;
			this.oCPU.DI.Word = 0x0;

		L02d6:
			this.oCPU.REPNESCASByte();
			this.oCPU.SCASByte();
			if (this.oCPU.Flags.NE) goto L02d6;
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5924, this.oCPU.DI.Word);
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.CX.Word;

		L02ea:
			this.oCPU.DI.Word = 0x1;
			this.oCPU.SI.Word = 0x81;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5901);

		L02f4:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L02f4;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x9);
			if (this.oCPU.Flags.E) goto L02f4;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xd);
			if (this.oCPU.Flags.E) goto L0370;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0370;
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);

		L0306:
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);

		L0307:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L02f4;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x9);
			if (this.oCPU.Flags.E) goto L02f4;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xd);
			if (this.oCPU.Flags.E) goto L0370;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0370;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L0340;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L0323;
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			goto L0307;

		L0323:
			this.oCPU.CX.Word = 0x0;

		L0325:
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L0325;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L0333;
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			goto L0306;

		L0333:
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0307;
			goto L0340;

		L033f:
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);

		L0340:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xd);
			if (this.oCPU.Flags.E) goto L0370;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0370;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L0307;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L0354;
			this.oCPU.DX.Word = this.oCPU.INCWord(this.oCPU.DX.Word);
			goto L0340;

		L0354:
			this.oCPU.CX.Word = 0x0;

		L0356:
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L0356;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L0364;
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			goto L033f;

		L0364:
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0340;
			goto L0307;

		L0370:
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x591e, this.oCPU.DI.Word);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.DI.Word);
			this.oCPU.DX.Low = this.oCPU.ANDByte(this.oCPU.DX.Low, 0xfe);
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SP.Word;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5920, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.WriteWord(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			// LDS
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5924);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(0x5924 + 2));

		L0396:
			this.oCPU.LODSByte();
			this.oCPU.STOSByte();
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L0396;
			this.oCPU.SI.Word = 0x81;
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, 0x5901);
			goto L03a9;

		L03a6:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.STOSByte();

		L03a9:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L03a9;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x9);
			if (this.oCPU.Flags.E) goto L03a9;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xd);
			if (this.oCPU.Flags.NE) goto L03b9;
			goto L0438;

		L03b9:
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L03c0;
			goto L0438;

		L03c0:
			this.oCPU.WriteWord(this.oCPU.SS.Word, this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);

		L03c5:
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);

		L03c6:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L03a6;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x9);
			if (this.oCPU.Flags.E) goto L03a6;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xd);
			if (this.oCPU.Flags.E) goto L0435;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0435;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L0402;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L03e2;
			this.oCPU.STOSByte();
			goto L03c6;

		L03e2:
			this.oCPU.CX.Word = 0x0;

		L03e4:
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L03e4;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L03f4;
			this.oCPU.AX.Low = 0x5c;
			this.oCPU.REPESTOSByte();
			goto L03c5;

		L03f4:
			this.oCPU.AX.Low = 0x5c;
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPESTOSByte();
			if (this.oCPU.Flags.AE) goto L0402;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.STOSByte();
			goto L03c6;

		L0401:
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);

		L0402:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xd);
			if (this.oCPU.Flags.E) goto L0435;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L0435;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L03c6;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L0416;
			this.oCPU.STOSByte();
			goto L0402;

		L0416:
			this.oCPU.CX.Word = 0x0;

		L0418:
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5c);
			if (this.oCPU.Flags.E) goto L0418;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x22);
			if (this.oCPU.Flags.E) goto L0428;
			this.oCPU.AX.Low = 0x5c;
			this.oCPU.REPESTOSByte();
			goto L0401;

		L0428:
			this.oCPU.AX.Low = 0x5c;
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPESTOSByte();
			if (this.oCPU.Flags.AE) goto L03c6;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.STOSByte();
			goto L0402;

		L0435:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.STOSByte();

		L0438:
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
			// Instruction uiAddress 0x3045:0x043e, size: 4
			//this.oCPU.JmpF(this.oCPU.ReadDWord(this.oCPU.DS.Word, 0x593c));
			this.oCPU.PushDWord(0); // preserve stack integrity
			this.oCPU.Log.ExitBlock("'_setargv'");
			return;
		}

		public void getenv()
		{
			this.oCPU.Log.EnterBlock("'getenv'(Cdecl) at 0x3045:0x1f86");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5922);
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L1fe2;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L1fe2;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x1fa4); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x1f9f, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			goto L1faf;

		L1fac:
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x2);

		L1faf:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
			if (this.oCPU.Flags.E) goto L1fe2;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x1fbb); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x1fb6, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.LE) goto L1fac;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word)), 0x3d);
			if (this.oCPU.Flags.NE) goto L1fac;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x1fd3); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x1fce, size: 5
			strncmp();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1fac;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x1);
			goto L1fe4;

		L1fe2:
			this.oCPU.AX.Word = 0;

		L1fe4:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'getenv'");
		}

		public void _NMSG_TEXT()
		{
			this.oCPU.Log.EnterBlock("'_NMSG_TEXT'(Pascal) at 0x3045:0x04b0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = 0x645c;

		L04bd:
			this.oCPU.LODSWord();
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L04d2;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.Temp.Word;
			if (this.oCPU.Flags.E) goto L04d2;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.SI.Word = this.oCPU.DI.Word;
			goto L04bd;

		L04d2:
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.Temp.Word;
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'_NMSG_TEXT'");
		}

		public void _NMSG_WRITE()
		{
			this.oCPU.Log.EnterBlock("'_NMSG_WRITE'(Pascal) at 0x3045:0x04db");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x04e7); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x04e2, size: 5
			_NMSG_TEXT();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04ff;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.BX.Word = 0x2;
			this.oCPU.AX.High = 0x40;
			this.oCPU.INT(0x21);

		L04ff:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'_NMSG_WRITE'");
		}

		public void _maperror()
		{
			this.oCPU.Log.EnterBlock("'_maperror'(Cdecl) at 0x3045:0x0568");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.AX.High = 0x0;
			this.oCPU.PushWord(0x056d); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x056a, size: 3
			F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset and segment
			this.oCPU.Log.ExitBlock("'_maperror'");
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
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = 0x2;
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L204c;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
			if (this.oCPU.Flags.E) goto L204c;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x202b); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x2026, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, this.oCPU.DI.Word);
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
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x58fb), 0x0);
			if (this.oCPU.Flags.L) goto L205c;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5dbc);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x58fb), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L2062;

			L205c:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5dbc);
			goto L2066;

			L2062:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x58fb);

			L2066:
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x5d70));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2072); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x206d, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
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
			uint uiDestination = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, destination);
			uint uiSource = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, source);
			int iCount = count;

			if (uiDestination > uiSource && (uiSource + iCount) >= uiDestination)
			{
				uiSource = (uint)(uiSource + iCount - 1);
				uiDestination = (uint)(uiDestination + iCount - 1);
				iDirection = -1;
			}

			while (iCount > 0)
			{
				this.oCPU.Memory.WriteByte(uiDestination, this.oCPU.Memory.ReadByte(uiSource));
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
			uint uiDestination = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, destination);
			int iCount = count;

			while (iCount > 0)
			{
				this.oCPU.Memory.WriteByte(uiDestination, value);
				uiDestination++;
				iCount--;
			}

			this.oCPU.Log.ExitBlock("memset");
			this.oCPU.AX.Word = destination; // for compatibility reasons
			return destination;
		}

		public void movedata(ushort sourceSegment, ushort sourceOffset, ushort destinationSegment, ushort destinationOffset, ushort count)
		{
			this.oCPU.Log.EnterBlock($"memset(0x{sourceSegment:x4}, 0x{sourceOffset:x4}, 0x{destinationSegment:x4}, 0x{destinationOffset:x4}, {count})");

			// function body
			int iDirection = 1;
			uint uiDestination = CPUMemory.ToLinearAddress(destinationSegment, destinationOffset);
			uint uiSource = CPUMemory.ToLinearAddress(sourceSegment, sourceOffset);
			int iCount = count;

			if (uiDestination > uiSource && (uiSource + iCount) >= uiDestination)
			{
				uiSource = (uint)(uiSource + iCount - 1);
				uiDestination = (uint)(uiDestination + iCount - 1);
				iDirection = -1;
			}

			while (iCount > 0)
			{
				this.oCPU.Memory.WriteByte(uiDestination, this.oCPU.Memory.ReadByte(uiSource));
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
		public short fopen(ushort filenameAddress, ushort modeAddress)
		{
			string sName = this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filenameAddress));
			string sMode = this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, modeAddress));
			FileMode eMode = FileMode.Open;
			FileAccess eAccess = FileAccess.Write;
			FileStreamTypeEnum eType = FileStreamTypeEnum.Binary;

			sMode = sMode.Trim().ToLower();
			for (int i = 0; i < sMode.Length; i++)
			{
				switch (sMode[i])
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
						throw new Exception($"Unknown file mode '{sMode}'");
				}
			}

			short sHandle = -1;
			string sPath = $"{this.oCPU.DefaultDirectory}{sName}";
			if (File.Exists(sPath))
			{
				this.oCPU.Log.WriteLine($"Opening file '{sPath}', with file handle {this.oCPU.FileHandleCount}");
				this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream($"{sPath}", eMode, eAccess), eType));
				sHandle = this.oCPU.FileHandleCount;
				this.oCPU.FileHandleCount++;
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
			uint uiAddress = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, ptr);

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
			short sCount = -1;
			uint uiFormatAddress = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, formatPtr);
			uint uiVarAddress = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, varPtr);

			if (this.oCPU.Files.ContainsKey(handle))
			{
				sCount = 0;
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				string sFormat = this.oCPU.ReadString(uiFormatAddress);
				StringBuilder sbResult = new StringBuilder();

				switch (sFormat)
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
						throw new Exception($"fscanf has undefined format '{sFormat}'");
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
			uint uiAddress = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, ptr);

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
							aBuffer[j] = this.oCPU.Memory.ReadByte(uiAddress);
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
							aBuffer[j] = this.oCPU.Memory.ReadByte(uiAddress);
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
			string sName = Path.GetFileName(this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filenamePtr)));
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
			string sPath = $"{this.oCPU.DefaultDirectory}{sName}";
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

		public short read(short handle, ushort buf, ushort length)
		{
			uint address = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, buf);
			short sItemCount = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);

				for (int i = 0; i < length; i++)
				{
					short ch = fileItem.ReadChar();
					if (ch >= 0)
					{
						this.oCPU.Memory.WriteByte(address, (byte)ch);
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

		public short write(short handle, ushort buf, ushort length)
		{
			uint address = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, buf);
			short sItemCount = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);

				if (fileItem.Type == FileStreamTypeEnum.Binary)
				{
					for (int i = 0; i < length; i++)
					{
						fileItem.Stream.WriteByte(this.oCPU.Memory.ReadByte(address));
						address++;
						sItemCount++;
					}
				}
				else
				{
					for (int i = 0; i < length; i++)
					{
						byte ch = this.oCPU.Memory.ReadByte(address);
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

		public short _dos_open(ushort filename, ushort flags, ushort handlePtr)
		{
			uint uiHandleAddress = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, handlePtr);
			short sRetVal = -1;

			string sName = this.oCPU.ReadString(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, filename));
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

			string sPath = $"{this.oCPU.DefaultDirectory}{sName}";
			if (File.Exists(sPath))
			{
				this.oCPU.Log.WriteLine($"Opening file '{sPath}', with file handle {this.oCPU.FileHandleCount}");
				this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream(sPath, eMode, eAccess), eType));
				short sHandle = this.oCPU.FileHandleCount;
				this.oCPU.FileHandleCount++;
				this.oCPU.Memory.WriteWord(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, handlePtr), (ushort)sHandle);
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
			uint uiBufferAddress = CPUMemory.ToLinearAddress(this.oCPU.DS.Word, bufferPtr);
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
						this.oCPU.Memory.WriteByte(uiBufferAddress, (byte)ch);
						uiBufferAddress++;
						usItemCount++;
					}
					else
					{
						break;
					}
				}

				this.oCPU.Memory.WriteWord(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, nreadPtr), usItemCount);
				usRetVal = 0;
			}
			else
			{
				this.oCPU.Log.WriteLine($"Can't find file handle {handle}");
			}

			this.oCPU.AX.Word = usRetVal; // preserve compatibility
			return usRetVal;
		}

		public void _bios_disk()
		{
			this.oCPU.Log.EnterBlock("'_bios_disk'(Cdecl) at 0x3045:0x3062");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.CMPByte(this.oCPU.AX.High, 0x2);
			if (this.oCPU.Flags.B) goto L308a;
			this.oCPU.DX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.Temp.Low = this.oCPU.CX.Low;
			this.oCPU.CX.Low = this.oCPU.CX.High;
			this.oCPU.CX.High = this.oCPU.Temp.Low;
			this.oCPU.CX.Low = this.oCPU.RORByte(this.oCPU.CX.Low, 0x1);
			this.oCPU.CX.Low = this.oCPU.RORByte(this.oCPU.CX.Low, 0x1);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0xc0);
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6)));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x8));
			// LES
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xa));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)((ushort)(this.oCPU.BX.Word + 0xa) + 2));

			L308a:
			this.oCPU.INT(0x13);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'_bios_disk'");
		}

		public void _dos_getdrive()
		{
			this.oCPU.Log.EnterBlock("'_dos_getdrive'(Cdecl) at 0x3045:0x312e");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.High = 0x19;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.High = 0x0;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'_dos_getdrive'");
		}
		#endregion

		#region String operations
		public void strcat()
		{
			ushort usDestSeg = this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4));

			strcat(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, usDestSeg),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x6))));

			this.oCPU.AX.Word = usDestSeg;
		}

		public void strcat(uint destinationAddress, uint sourceAddress)
		{
			string sDest = this.oCPU.ReadString(destinationAddress);
			string sSource = this.oCPU.ReadString(sourceAddress);

			this.oCPU.Log.WriteLine($"strcat('{sDest}', '{sSource}')");

			this.oCPU.WriteString(destinationAddress, sDest + sSource, sDest.Length + sSource.Length);
		}

		public void strcpy()
		{
			ushort usDestSeg = this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4));

			strcpy(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, usDestSeg),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x6))));

			this.oCPU.AX.Word = usDestSeg;
		}

		public void strcpy(uint destinationAddress, uint sourceAddress)
		{
			string sSource = this.oCPU.ReadString(sourceAddress);

			this.oCPU.Log.WriteLine($"strcpy('{sSource}')");

			this.oCPU.WriteString(destinationAddress, sSource, sSource.Length);
		}

		public void strlen()
		{
			this.oCPU.AX.Word = (ushort)strlen(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4))));
		}

		public int strlen(uint sourcePtr)
		{
			string sSource = this.oCPU.ReadString(sourcePtr);

			this.oCPU.Log.WriteLine($"strlen('{sSource}') = {sSource.Length}");

			return sSource.Length;
		}

		public void strncmp()
		{
			this.oCPU.AX.Word = (ushort)strncmp(
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4))),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x6))),
				this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x8)));
		}

		public short strncmp(uint s1Ptr, uint s2Ptr, ushort maxlen)
		{
			string sS1 = this.oCPU.ReadString(s1Ptr);
			string sS2 = this.oCPU.ReadString(s2Ptr);

			if (sS1.Length > maxlen)
				sS1 = sS1.Substring(0, maxlen);

			if (sS2.Length > maxlen)
				sS2 = sS2.Substring(0, maxlen);

			return (short)string.Compare(sS1, sS2, StringComparison.CurrentCulture);
		}

		public void stricmp()
		{
			this.oCPU.AX.Word = (ushort)stricmp(
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4))),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x6))));
		}

		public short stricmp(uint s1Ptr, uint s2Ptr)
		{
			string sS1 = this.oCPU.ReadString(s1Ptr);
			string sS2 = this.oCPU.ReadString(s2Ptr);

			return (short)string.Compare(sS1, sS2, StringComparison.CurrentCultureIgnoreCase);
		}

		public void strnicmp()
		{
			this.oCPU.AX.Word = (ushort)strnicmp(
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4))),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x6))),
				this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x8)));
		}

		public short strnicmp(uint s1Ptr, uint s2Ptr, ushort maxlen)
		{
			string sS1 = this.oCPU.ReadString(s1Ptr);
			string sS2 = this.oCPU.ReadString(s2Ptr);

			if (sS1.Length > maxlen)
				sS1 = sS1.Substring(0, maxlen);

			if (sS2.Length > maxlen)
				sS2 = sS2.Substring(0, maxlen);

			return (short)string.Compare(sS1, sS2, StringComparison.CurrentCultureIgnoreCase);
		}

		public void strupr()
		{
			ushort usS1 = this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4));

			strupr(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, usS1));

			this.oCPU.AX.Word = usS1;
		}

		public void strupr(uint sAddress)
		{
			string sTemp = this.oCPU.ReadString(sAddress).ToUpper();

			this.oCPU.Log.WriteLine($"strupr('{sTemp}')");

			this.oCPU.WriteString(sAddress, sTemp, sTemp.Length);
		}

		public void strstr()
		{
			ushort usS1 = this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4));

			int iPos = strstr(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, usS1),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x6))));
			if (iPos >= 0)
			{
				this.oCPU.AX.Word = (ushort)(usS1 + iPos);
			}
			else
			{
				this.oCPU.AX.Word = 0;
			}
		}

		public int strstr(uint s1Address, uint s2Address)
		{
			string sS1 = this.oCPU.ReadString(s1Address);
			string sS2 = this.oCPU.ReadString(s2Address);

			this.oCPU.Log.WriteLine($"strstr('{sS1}', '{sS2}') = {sS1.IndexOf(sS2)}");

			return sS1.IndexOf(sS2);
		}

		public void itoa()
		{
			ushort usDestination = this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x6));

			itoa((short)this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4)),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, usDestination),
				(short)this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x8)));

			this.oCPU.AX.Word = usDestination;
		}

		public void itoa(short value, uint stringAddress, short radix)
		{
			string sValue = Convert.ToString(value, radix);

			this.oCPU.Log.WriteLine($"itoa({value}, {radix}) = '{sValue}'");

			this.oCPU.WriteString(stringAddress, sValue, sValue.Length);
		}
		#endregion

		#region Time operations
		public void time()
		{
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, 
				(uint)time(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4)))));
		}

		public int time(uint timePtr)
		{
			int iTotalSeconds = (int)Math.Floor((DateTime.Now - (new DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds);

			if (timePtr != 0)
				this.oCPU.Memory.WriteDWord(timePtr, (uint)iTotalSeconds);

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
			srand(this.oCPU.Memory.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.SP.Word + 0x4)));
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

		#region Shifting operations
		public void _aFlshl()
		{
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);
		}

		public void _aFlshr()
		{
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) >> this.oCPU.CX.Low);
		}
		#endregion

		#region Interrupt and vector operations
		public void int86()
		{
			this.oCPU.Log.EnterBlock("'int86'(Cdecl) at 0x3045:0x20c4");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0xcd);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x9), this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x25);
			if (this.oCPU.Flags.E) goto L20e4;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x26);
			if (this.oCPU.Flags.E) goto L20e4;
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0xcb);
			goto L20f0;

			L20e4:
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xcb);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x7), 0x44);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x44);

			L20f0:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.SS.Word);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BP.Word - 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xa));
			this.oCPU.PushWord(this.oCPU.BP.Word);
			//this.oCPU.PushWord(0x3045); // stack management - push return segment
			//this.oCPU.PushWord(0x2111); // stack management - push return offset
			// Instruction uiAddress 0x3045:0x210e, size: 3
			//this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			//this.oCPU.PopDWord(); // stack management - pop return offset and segment
			//this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.INT((byte)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)) & 0xff));
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Flags.D = false;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4), this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6), this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x8), this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xa), this.oCPU.PopWord());
			if (this.oCPU.Flags.B) goto L212e;
			this.oCPU.SI.Word = 0x0;
			goto L2138;

			L212e:
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2133); // stack management - push return offset
										// Instruction uiAddress 0x3045:0x212e, size: 5
			_maperror();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SI.Word = 0x1;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);

			L2138:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xc), this.oCPU.SI.Word);
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'int86'");
		}

		public void _dos_getvect()
		{
			this.oCPU.Log.EnterBlock("'_dos_getvect'(Cdecl) at 0x3045:0x30bc");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.High = 0x35;
			this.oCPU.INT(0x21);
			this.oCPU.DX.Word = this.oCPU.ES.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'_dos_getvect'");
		}

		public void _dos_setvect()
		{
			this.oCPU.Log.EnterBlock("'_dos_setvect'(Cdecl) at 0x3045:0x310a");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.PushWord(this.oCPU.DS.Word);
			// LDS
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)((ushort)(this.oCPU.BP.Word + 0x8) + 2));
			this.oCPU.AX.High = 0x25;
			this.oCPU.INT(0x21);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = 0x0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oCPU.Log.ExitBlock("'_dos_setvect'");
		}
		#endregion
	}
}
