using Disassembler;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;

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

		public void DivisionByZero()
		{
			this.oParent.LogWriteLine("Entering function 'DivisionByZero'(Cdecl) at 0x0000:0x0000, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
		}

		public void _cinit()
		{
			this.oParent.LogWriteLine("Entering function '_cinit'(Cdecl) at 0x3045:0x00da, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L00da;

		L00c5:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x00cb); // stack management - push return offset
			// Instruction address 0x3045:0x00c6, size: 5
			_FF_MSGBANNER();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x00d0); // stack management - push return offset
			// Instruction address 0x3045:0x00cb, size: 5
			_NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = 0xff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x00d9); // stack management - push return offset
			// Instruction address 0x3045:0x00d5, size: 4
			this.oCPU.Call(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x588e));
			this.oCPU.PopWord(); // stack management - pop return offset

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
			// Instruction address 0x3045:0x0111, size: 5
			this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.SS.Word, 0x6304));
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
			// Instruction address 0x3045:0x0127, size: 5
			this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.SS.Word, 0x6304));
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
			// Instruction address 0x3045:0x0191, size: 3
			this.oParent.Segment_3045.F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SI.Word = 0x6310;
			this.oCPU.DI.Word = 0x6310;
			this.oCPU.PushWord(0x019d); // stack management - push return offset
			// Instruction address 0x3045:0x019a, size: 3
			this.oParent.Segment_3045.F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oParent.LogWriteLine("Exiting function '_cinit'");
			return;

		L0260:
			this.oCPU.AX.Word = 0x2;
			goto L00c5;
		}

		public void exit(short code)
		{
			this.oParent.LogWriteLine("Entering function 'exit'(Cdecl) at 0x3045:0x019e, stack: 0x0");
			this.oCPU.Exit(code);

			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SI.Word = 0x6b2e;
			this.oCPU.DI.Word = 0x6b2e;
			this.oCPU.PushWord(0x01aa); // stack management - push return offset
			// Instruction address 0x3045:0x01a7, size: 3
			this.oParent.Segment_3045.F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SI.Word = 0x6310;
			this.oCPU.DI.Word = 0x6314;
			this.oCPU.PushWord(0x01b3); // stack management - push return offset
			// Instruction address 0x3045:0x01b0, size: 3
			this.oParent.Segment_3045.F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SI.Word = 0x6314;
			this.oCPU.DI.Word = 0x6314;
			this.oCPU.PushWord(0x01c1); // stack management - push return offset
			// Instruction address 0x3045:0x01be, size: 3
			this.oParent.Segment_3045.F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SI.Word = 0x6314;
			this.oCPU.DI.Word = 0x6314;
			this.oCPU.PushWord(0x01ca); // stack management - push return offset
			// Instruction address 0x3045:0x01c7, size: 3
			this.oParent.Segment_3045.F0_3045_0229();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x01cf); // stack management - push return offset
			// Instruction address 0x3045:0x01ca, size: 5
			_nullcheck();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L01de;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L01de;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), 0xff);

		L01de:
			this.oCPU.CX.Word = 0xf;
			this.oCPU.BX.Word = 0x5;

		L01e4:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x1);
			if (this.oCPU.Flags.E) goto L01ef;
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);

		L01ef:
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L01e4;
			this.oCPU.PushWord(0x01f5); // stack management - push return offset
			// Instruction address 0x3045:0x01f2, size: 3
			_ctermsub();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.High = 0x4c;
			this.oCPU.INT(0x21);*/
		}

		public void _FF_MSGBANNER()
		{
			this.oParent.LogWriteLine("Entering function '_FF_MSGBANNER'(Cdecl) at 0x3045:0x023c, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = 0xfc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0248); // stack management - push return offset
			// Instruction address 0x3045:0x0243, size: 5
			_NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5934), 0x0);
			if (this.oCPU.Flags.E) goto L0253;
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0253); // stack management - push return offset
			// Instruction address 0x3045:0x024f, size: 4
			this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.DS.Word, 0x5932));
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment

		L0253:
			this.oCPU.AX.Word = 0xff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x025c); // stack management - push return offset
			// Instruction address 0x3045:0x0257, size: 5
			_NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_FF_MSGBANNER'");
		}

		public void _setargv()
		{
			this.oParent.LogWriteLine("Entering function '_setargv'(Cdecl) at 0x3045:0x02b0, stack: 0x0");
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
			// Instruction address 0x3045:0x043e, size: 4
			//this.oCPU.JmpF(this.oCPU.ReadDWord(this.oCPU.DS.Word, 0x593c));
			this.oCPU.PushDWord(0); // preserve stack integrity
			this.oParent.LogWriteLine("Exiting function '_setargv'");
			return;
		}

		public void getenv()
		{
			this.oParent.LogWriteLine("Entering function 'getenv'(Cdecl) at 0x3045:0x1f86, stack: 0x0");
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
										// Instruction address 0x3045:0x1f9f, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
										// Instruction address 0x3045:0x1fb6, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
										// Instruction address 0x3045:0x1fce, size: 5
			strncmp();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1fac;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x1);
			goto L1fe4;

			L1fe2:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

			L1fe4:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'getenv'");
		}

		public void _NMSG_TEXT()
		{
			this.oParent.LogWriteLine("Entering function '_NMSG_TEXT'(Pascal) at 0x3045:0x04b0, stack: 0x0");
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
			this.oParent.LogWriteLine("Exiting function '_NMSG_TEXT'");
		}

		public void _NMSG_WRITE()
		{
			this.oParent.LogWriteLine("Entering function '_NMSG_WRITE'(Pascal) at 0x3045:0x04db, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x04e7); // stack management - push return offset
			// Instruction address 0x3045:0x04e2, size: 5
			_NMSG_TEXT();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
			this.oParent.LogWriteLine("Exiting function '_NMSG_WRITE'");
		}

		public void _maperror()
		{
			this.oParent.LogWriteLine("Entering function '_maperror'(Cdecl) at 0x3045:0x0568, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.AX.High = 0x0;
			this.oCPU.PushWord(0x056d); // stack management - push return offset
			// Instruction address 0x3045:0x056a, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oParent.LogWriteLine("Exiting function '_maperror'");
		}

		public void perror()
		{
			this.oParent.LogWriteLine("Entering function 'perror'(Cdecl) at 0x3045:0x200e, stack: 0x0");
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
										// Instruction address 0x3045:0x2026, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2037); // stack management - push return offset
										// Instruction address 0x3045:0x2032, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
										// Instruction address 0x3045:0x2044, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
										// Instruction address 0x3045:0x206d, size: 5
			strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x207d); // stack management - push return offset
										// Instruction address 0x3045:0x2078, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5bad;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x208e); // stack management - push return offset
										// Instruction address 0x3045:0x2089, size: 5
										//write();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'perror'");
		}

		#region Keyboard operations
		public short kbhit()
		{
			this.oParent.LogWriteLine("Entering function 'kbhit'(Cdecl) at 0x3045:0x2098, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5bb0);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.AX.Low = 0xff;
			if (this.oCPU.Flags.E) goto L20a7;
			this.oCPU.AX.High = 0xb;
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x0;

			L20a7:*/
			this.oParent.LogWriteLine("Exiting function 'kbhit'");

			return (short)(this.oCPU.VGA.Form.Keys.Count > 0 ? -1 : 0);
		}

		public short getch()
		{
			this.oParent.LogWriteLine("Entering function 'getch'(Cdecl) at 0x3045:0x20ac, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.DX.High = 0x8;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5bb0);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.NE) goto L20bd;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5bb0, 0xffff);
			goto L20c2;

			L20bd:
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x0;

			L20c2:*/

			while (this.oCPU.VGA.Form.Keys.Count == 0)
			{
				Thread.Sleep(200);
				System.Windows.Forms.Application.DoEvents();
			}

			this.oParent.LogWriteLine("Exiting function 'getch'");

			return (short)this.oCPU.VGA.Form.Keys.Dequeue();
		}
		#endregion

		#region Memory operations
		public void memcpy()
		{
			this.oParent.LogWriteLine("Entering function 'memcpy'(Cdecl) at 0x3045:0x2a08, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.CX.Word == 0) goto L2a2e;
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L2a26;
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);

			L2a26:
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.CX.Word = this.oCPU.ADCWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);

			L2a2e:
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'memcpy'");
		}

		public void memset()
		{
			this.oParent.LogWriteLine("Entering function 'memset'(Cdecl) at 0x3045:0x2a34, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.CX.Word == 0) goto L2a5c;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.High = this.oCPU.AX.Low;
			this.oCPU.TESTWord(this.oCPU.DI.Word, 0x1);
			if (this.oCPU.Flags.E) goto L2a54;
			this.oCPU.STOSByte();
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);

			L2a54:
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPESTOSWord();
			this.oCPU.CX.Word = this.oCPU.ADCWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.REPESTOSByte();

			L2a5c:
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'memset'");
		}

		public void movedata()
		{
			this.oParent.LogWriteLine("Entering function 'movedata'(Cdecl) at 0x3045:0x25c8, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'movedata'");
		}

		public void _dos_freemem()
		{
			this.oParent.LogWriteLine("Entering function '_dos_freemem'(Cdecl) at 0x3045:0x3120, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L3120;

			L054a:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_dos_freemem'");
			return;

			L0550:
			if (this.oCPU.Flags.AE) goto L054a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0556); // stack management - push return offset
										// Instruction address 0x3045:0x0553, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_dos_freemem'");
			return;

			L3120:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.High = 0x49;
			this.oCPU.INT(0x21);
			goto L0550;
		}
		#endregion

		#region File operations
		public short fclose(short handle)
		{
			this.oParent.LogWriteLine("Entering function 'fclose'(Cdecl) at 0x3045:0x059c, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = 0xffff;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x83);
			if (this.oCPU.Flags.NE) goto L05b3;
			goto L0658;

		L05b3:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x40);
			if (this.oCPU.Flags.E) goto L05bc;
			goto L0658;

		L05bc:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x05c2); // stack management - push return offset
			// Instruction address 0x3045:0x05bd, size: 5
			fflush();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fe));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x05e6); // stack management - push return offset
			// Instruction address 0x3045:0x05e1, size: 5
			_freebuf();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = (ushort)close((short)this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0655;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L0658;
			this.oCPU.AX.Word = 0x5954;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x060d); // stack management - push return offset
			// Instruction address 0x3045:0x0608, size: 5
			strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BP.Word - 0xc);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x2)), 0x5c);
			if (this.oCPU.Flags.E) goto L0630;
			this.oCPU.AX.Word = 0x5956;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x062b); // stack management - push return offset
			// Instruction address 0x3045:0x0626, size: 5
			strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			goto L0633;

		L0630:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0633:
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0642); // stack management - push return offset
			// Instruction address 0x3045:0x063d, size: 5
			itoa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x064e); // stack management - push return offset
			// Instruction address 0x3045:0x0649, size: 5
			remove();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0658;

		L0655:
			this.oCPU.DI.Word = 0xffff;

		L0658:
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6), 0x0);
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/
			this.oParent.LogWriteLine("Exiting function 'fclose'");

			return this.close(handle);
		}

		public short fopen(uint filenameAddress, uint modeAddress)
		{
			this.oParent.LogWriteLine("Entering function 'fopen'(Cdecl) at 0x3045:0x0698, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x06a4); // stack management - push return offset
			// Instruction address 0x3045:0x069f, size: 5
			_getstream();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L06bc;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x06b6); // stack management - push return offset
			// Instruction address 0x3045:0x06b1, size: 5
			_openfile();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			goto L06be;

		L06bc:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

		L06be:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'fopen'");*/

			string sName = this.oCPU.ReadString(filenameAddress);
			string sMode = this.oCPU.ReadString(modeAddress);
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

			this.oParent.LogWriteLine($"Opening file '{this.oCPU.DefaultDirectory}{sName}'");
			this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream($"{this.oCPU.DefaultDirectory}{sName}", eMode, eAccess), eType));
			short sHandle = this.oCPU.FileHandleCount;
			this.oCPU.FileHandleCount++;

			this.oParent.LogWriteLine("Exiting function 'fopen'");
			return sHandle;
		}

		public ushort fread(uint address, ushort itemSize, ushort itemCount, short handle)
		{
			this.oParent.LogWriteLine("Entering function 'fread'(Cdecl) at 0x3045:0x06c4, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L06e7;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x0);
			if (this.oCPU.Flags.NE) goto L06ee;

			L06e7:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			goto L08b0;

			L06ee:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0xc);
			if (this.oCPU.Flags.E) goto L06f7;
			goto L0799;

			L06f7:
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x1);
			if (this.oCPU.Flags.E) goto L0713;
			goto L0799;

			L0713:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x80);
			if (this.oCPU.Flags.NE) goto L0768;
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x1ff);
			if (this.oCPU.Flags.NE) goto L0768;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L0730;
			goto L07fc;

			L0730:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			L0734:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0742); // stack management - push return offset
										// Instruction address 0x3045:0x073d, size: 5
			read();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NE) goto L074e;
			goto L0891;

			L074e:
			this.oCPU.CMPWord(this.oCPU.DI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0756;
			goto L0891;

			L0756:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.DI.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.DI.Word));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L0765;
			goto L07fc;

			L0765:
			goto L0734;

			L0768:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2))));
			if (this.oCPU.Flags.S) goto L0778;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word)));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			goto L0781;

			L0778:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x077e); // stack management - push return offset
										// Instruction address 0x3045:0x0779, size: 5
			_filbuf();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			L0781:
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L078c;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			goto L08b0;

			L078c:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))));
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

			L0799:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x8);
			if (this.oCPU.Flags.E) goto L07a2;
			goto L082d;

			L07a2:
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x1);
			if (this.oCPU.Flags.NE) goto L07be;
			goto L0868;

			L07be:
			goto L082d;

			L07c0:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x200);
			if (this.oCPU.Flags.B) goto L0812;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x9;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x07e1); // stack management - push return offset
										// Instruction address 0x3045:0x07dc, size: 5
			read();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L07ef;
			this.oCPU.CMPWord(this.oCPU.DI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L080a;

			L07ef:
			this.oCPU.CMPWord(this.oCPU.DI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L07f7;
			goto L0899;

			L07f7:
			this.oCPU.AX.Low = 0x10;

			L07f9:
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6), this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), this.oCPU.AX.Low));

			L07fc:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			goto L08b0;

			L080a:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.DI.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.DI.Word));
			goto L082d;

			L0812:
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0818); // stack management - push return offset
										// Instruction address 0x3045:0x0813, size: 5
			_filbuf();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L07fc;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

			L082d:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L07fc;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L07c0;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CX.Word = this.oCPU.SBBWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0854); // stack management - push return offset
										// Instruction address 0x3045:0x084f, size: 5
			memcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)), this.oCPU.AX.Word));
			goto L082d;

			L0868:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L07fc;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			L0875:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0883); // stack management - push return offset
										// Instruction address 0x3045:0x087e, size: 5
			read();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L0891;
			this.oCPU.CMPWord(this.oCPU.DI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L089e;

			L0891:
			this.oCPU.CMPWord(this.oCPU.DI.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0899;
			goto L07f7;

			L0899:
			this.oCPU.AX.Low = 0x20;
			goto L07f9;

			L089e:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.DI.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.DI.Word));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L08ad;
			goto L07fc;

			L08ad:
			goto L0875;

			L08b0:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			ushort usItemCount = 0;

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

						this.oCPU.Memory.WriteBlock(address, aBuffer, 0, itemSize);
						address += itemSize;
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

						this.oCPU.Memory.WriteBlock(address, aBuffer, 0, itemSize);
						address += itemSize;
					}
				}
			}

			this.oParent.LogWriteLine("Exiting function 'fread'");
			return usItemCount;
		}

		public short fscanf(short handle, uint formatAddress, uint varAddress)
		{
			this.oParent.LogWriteLine("Entering function 'fscanf'(Cdecl) at 0x3045:0x08b6, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BP.Word + 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x08d1); // stack management - push return offset
			// Instruction address 0x3045:0x08cc, size: 5
			_input();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/
			short sCount = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				sCount = 0;
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				string sFormat = this.oCPU.ReadString(formatAddress);
				StringBuilder sbResult = new StringBuilder();

				switch (sFormat)
				{
					case "%[^\n]\n":
						short ch;
						while ((ch = fileItem.ReadChar()) != -1 && ch != (short)'\n')
						{
							sbResult.Append((char)ch);
						}
						this.oCPU.WriteString(varAddress, sbResult.ToString(), sbResult.Length);
						break;

					default:
						throw new Exception($"fscanf has undefined format '{sFormat}'");
				}
			}

			this.oParent.LogWriteLine("Exiting function 'fscanf'");

			return sCount;
		}

		public ushort fwrite(uint address, ushort itemSize, ushort itemCount, short handle)
		{
			this.oParent.LogWriteLine("Entering function 'fwrite'(Cdecl) at 0x3045:0x08d6, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L08fc;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x0);
			if (this.oCPU.Flags.NE) goto L0902;

		L08fc:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			goto L0a16;

		L0902:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6)), 0xc);
			if (this.oCPU.Flags.NE) goto L0971;
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x1);
			if (this.oCPU.Flags.NE) goto L0971;
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x1ff);
			if (this.oCPU.Flags.NE) goto L094a;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0936); // stack management - push return offset
			// Instruction address 0x3045:0x0931, size: 5
			write();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L08fc;

		L0941:
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			goto L0a16;

		L094a:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2))));
			if (this.oCPU.Flags.S) goto L095a;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word)));
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			goto L0967;

		L095a:
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0964); // stack management - push return offset
			// Instruction address 0x3045:0x095f, size: 5
			_flsbuf();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L0967:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6)), 0x20);
			if (this.oCPU.Flags.NE) goto L08fc;
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0971:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6)), 0x8);
			if (this.oCPU.Flags.NE) goto L09b9;
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x1);
			if (this.oCPU.Flags.E) goto L09f0;
			goto L09b9;

		L0992:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2))));
			if (this.oCPU.Flags.S) goto L09a2;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word)));
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			goto L09af;

		L09a2:
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x09ac); // stack management - push return offset
			// Instruction address 0x3045:0x09a7, size: 5
			_flsbuf();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L09af:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6)), 0x20);
			if (this.oCPU.Flags.NE) goto L0a0c;
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L09b9:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L0a0c;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0992;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CX.Word = this.oCPU.SBBWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x09de); // stack management - push return offset
			// Instruction address 0x3045:0x09d9, size: 5
			memcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word), this.oCPU.AX.Word));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2)), this.oCPU.AX.Word));
			goto L09b9;

		L09f0:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x09fe); // stack management - push return offset
			// Instruction address 0x3045:0x09f9, size: 5
			write();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0a0c;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L0a0c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			goto L0941;

		L0a16:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			ushort usItemCount = 0;

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
							aBuffer[j] = this.oCPU.ReadByte(address);
							address++;
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
							aBuffer[j] = this.oCPU.ReadByte(address);
							if (aBuffer[j] == (byte)'\n')
							{
								if (!bLF)
								{
									aBuffer[j] = (byte)'\r';
									bLF = true;
								}
								else
								{
									address++;
								}
							}
							else
							{
								address++;
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

			this.oParent.LogWriteLine("Exiting function 'fwrite'");

			return usItemCount;
		}

		public short fflush(short handle)
		{
			this.oParent.LogWriteLine("Entering function 'fflush'(Cdecl) at 0x3045:0x0dd4, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x3);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x2);
			if (this.oCPU.Flags.NE) goto L0e32;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x8);
			if (this.oCPU.Flags.NE) goto L0e09;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x1);
			if (this.oCPU.Flags.E) goto L0e32;

		L0e09:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0e32;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x0e23); // stack management - push return offset
			// Instruction address 0x3045:0x0e1e, size: 5
			write();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.E) goto L0e32;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6), this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x20));
			this.oCPU.DI.Word = 0xffff;

		L0e32:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), 0x0);
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			short sTemp = 0;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				fileItem.Stream.Flush();
				short sTemp1 = fileItem.UnGetC;
			}
			else
			{
				this.oParent.LogWriteLine($"Trying to flush unknown handle {handle}");
				sTemp = -1;
			}

			this.oParent.LogWriteLine("Exiting function 'fflush'");
			return sTemp;
		}

		public short fseek(short handle, int offset, short whence)
		{
			this.oParent.LogWriteLine("Entering function 'fseek'(Cdecl) at 0x3045:0x2144, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x16);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x83);
			if (this.oCPU.Flags.E) goto L2166;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x2);
			if (this.oCPU.Flags.G) goto L2166;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x0);
			if (this.oCPU.Flags.GE) goto L2170;

		L2166:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x58fb, 0x16);
			goto L21e9;

		L2170:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x59fa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6), this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0xef));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x82);
			if (this.oCPU.Flags.E) goto L21f0;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x1);
			if (this.oCPU.Flags.NE) goto L21b2;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x21a4); // stack management - push return offset
			// Instruction address 0x3045:0x219f, size: 5
			ftell();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa), this.oCPU.ADCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), this.oCPU.DX.Word));

		L21ad:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc), 0x0);

		L21b2:
			this.oCPU.AX.Word = (ushort)fflush((short)this.oCPU.SI.Word);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x80);
			if (this.oCPU.Flags.E) goto L21c5;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6), this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0xfc));

		L21c5:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x21d6); // stack management - push return offset
			// Instruction address 0x3045:0x21d1, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L21e1;
			goto L23f4;

		L21e1:
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L21e9;
			goto L23f4;

		L21e9:
			this.oCPU.AX.Word = 0xffff;
			goto L23f6;

		L21f0:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0xc);
			if (this.oCPU.Flags.NE) goto L2218;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x1);
			if (this.oCPU.Flags.NE) goto L2218;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x2213); // stack management - push return offset
			// Instruction address 0x3045:0x2210, size: 3
			_getbuf();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			goto L2228;

		L2218:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x4);
			if (this.oCPU.Flags.E) goto L2228;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0xfb));

		L2228:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2238); // stack management - push return offset
			// Instruction address 0x3045:0x2233, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L224b;
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L21e9;

		L224b:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x1);
			if (this.oCPU.Flags.NE) goto L2276;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			if (this.oCPU.Flags.NE) goto L2262;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L2262;
			goto L23f4;

		L2262:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SBBWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.CX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa), this.oCPU.ADCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), this.oCPU.BX.Word));

		L2276:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x2);
			if (this.oCPU.Flags.E) goto L2296;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x8);
			if (this.oCPU.Flags.NE) goto L2296;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), this.oCPU.DX.Word);
			if (this.oCPU.Flags.L) goto L22f6;
			if (this.oCPU.Flags.G) goto L2296;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.BE) goto L22f6;

		L2296:
			this.oCPU.AX.Word = 0x2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x22a6); // stack management - push return offset
			// Instruction address 0x3045:0x22a1, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x22c0); // stack management - push return offset
			// Instruction address 0x3045:0x22bb, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x2);
			if (this.oCPU.Flags.NE) goto L22d5;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa), this.oCPU.ADCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), this.oCPU.DX.Word));

		L22d5:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), this.oCPU.DX.Word);
			if (this.oCPU.Flags.G) goto L22f0;
			if (this.oCPU.Flags.L) goto L22e7;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.A) goto L22f0;

		L22e7:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0xf7));
			goto L22f6;

		L22f0:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x8));

		L22f6:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x0);
			if (this.oCPU.Flags.GE) goto L2305;
			goto L2166;

		L2305:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x8);
			if (this.oCPU.Flags.E) goto L230d;
			goto L21ad;

		L230d:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x4);
			if (this.oCPU.Flags.E) goto L2316;
			goto L21ad;

		L2316:
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2324); // stack management - push return offset
			// Instruction address 0x3045:0x231f, size: 5
			this.oParent.Segment_3045.F0_3045_3212();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SBBWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L2396;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L2396;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.SBBWord(this.oCPU.DX.Word, 0x0);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x235f); // stack management - push return offset
			// Instruction address 0x3045:0x235a, size: 5
			this.oParent.Segment_3045.F0_3045_3142();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2366); // stack management - push return offset
			// Instruction address 0x3045:0x2361, size: 5
			this.oParent.Segment_3045.F0_3045_31de();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.Flags.NE) goto L2396;
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.NE) goto L2396;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)), this.oCPU.AX.Word));

		L2378:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x80);
			if (this.oCPU.Flags.E) goto L23ea;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x4);
			if (this.oCPU.Flags.E) goto L238e;
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L238e;
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);

		L238e:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Word);
			goto L23e1;

		L2396:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x23a7); // stack management - push return offset
			// Instruction address 0x3045:0x23a2, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L23b7;
			this.oCPU.CMPWord(this.oCPU.DX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L23b7;
			goto L2166;

		L23b7:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x23c8); // stack management - push return offset
			// Instruction address 0x3045:0x23c3, size: 5
			read();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2378;
			goto L2166;

		L23d4:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0xa);
			if (this.oCPU.Flags.NE) goto L23dc;
			this.oCPU.DI.Word = this.oCPU.DECWord(this.oCPU.DI.Word);

		L23dc:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2))));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word)));

		L23e1:
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = this.oCPU.DECWord(this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L23f4;
			goto L23d4;

		L23ea:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)), this.oCPU.DI.Word));

		L23f4:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

		L23f6:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			short sRetVal = -1;

			if (this.oCPU.Files.ContainsKey(handle) && whence >= 0 && whence < 3)
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

			this.oParent.LogWriteLine("Exiting function 'fseek'");

			return sRetVal;
		}

		public int ftell(short handle)
		{
			this.oParent.LogWriteLine("Entering function 'ftell'(Cdecl) at 0x3045:0x23fc, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xe);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)), 0x0);
			if (this.oCPU.Flags.GE) goto L2412;
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2), 0x0);

		L2412:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2429); // stack management - push return offset
			// Instruction address 0x3045:0x2424, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.GE) goto L243e;

		L2436:
			this.oCPU.AX.Word = 0xffff;

		L2439:
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			goto L2578;

		L243e:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x8);
			if (this.oCPU.Flags.NE) goto L2472;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x1);
			if (this.oCPU.Flags.NE) goto L2472;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.SBBWord(this.oCPU.DX.Word, this.oCPU.BX.Word);
			goto L2578;

		L2472:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x3);
			if (this.oCPU.Flags.E) goto L24ae;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x80);
			if (this.oCPU.Flags.E) goto L24a0;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			goto L2499;

		L2492:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word), 0xa);
			if (this.oCPU.Flags.NE) goto L2498;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L2498:
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);

		L2499:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word), this.oCPU.DI.Word);
			if (this.oCPU.Flags.A) goto L2492;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.CX.Word);

		L24a0:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.NE) goto L24be;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			goto L2439;

		L24ae:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x80);
			if (this.oCPU.Flags.NE) goto L24a0;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x58fb, 0x16);
			goto L2436;

		L24be:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6)), 0x1);
			if (this.oCPU.Flags.NE) goto L24c7;
			goto L256e;

		L24c7:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L24d6;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L256e;

		L24d6:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x2)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x80);
			if (this.oCPU.Flags.E) goto L2564;
			this.oCPU.AX.Word = 0x2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x24f9); // stack management - push return offset
			// Instruction address 0x3045:0x24f4, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.Flags.NE) goto L252a;
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.NE) goto L252a;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4)));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			goto L2521;

		L251a:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word), 0xa);
			if (this.oCPU.Flags.NE) goto L2520;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);

		L2520:
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);

		L2521:
			this.oCPU.CMPWord(this.oCPU.DX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.A) goto L251a;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.CX.Word);
			goto L2564;

		L252a:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x253b); // stack management - push return offset
			// Instruction address 0x3045:0x2536, size: 5
			lseek();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x4);
			if (this.oCPU.Flags.E) goto L2564;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));

		L2564:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SBBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.DX.Word));

		L256e:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

		L2578:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			int iPosition = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				short sTemp = fileItem.UnGetC;
				iPosition = (int)fileItem.Stream.Position;
			}

			this.oParent.LogWriteLine("Exiting function 'ftell'");

			return iPosition;
		}

		public short ungetc(short ch, short handle)
		{
			this.oParent.LogWriteLine("Entering function 'ungetc'(Cdecl) at 0x3045:0x16dc, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6)), 0x1);
			if (this.oCPU.Flags.E) goto L16f2;
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L16f8;

		L16f2:
			this.oCPU.AX.Word = 0xffff; // Segment
			goto L1744;

		L16f8:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L1705;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(0x1702); // stack management - push return offset
			// Instruction address 0x3045:0x16ff, size: 3
			_getbuf();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L1705:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1714;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L16f2;
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word)));

		L1714:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2))));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word)));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6), this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6)), 0xef));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6)), 0x40);
			if (this.oCPU.Flags.NE) goto L1740;
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, 0x595a);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.BX.Word = this.oCPU.SARWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa), this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x59fa)), 0x4));

		L1740:
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);

		L1744:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			short sRetVal = -1;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				FileStreamItem fileItem = this.oCPU.Files.GetValueByKey(handle);
				fileItem.UnGetC = ch;
				sRetVal = ch;
			}

			this.oParent.LogWriteLine("Exiting function 'ungetc'");

			return sRetVal;
		}

		public short close(short handle)
		{
			this.oParent.LogWriteLine("Entering function 'close'(Cdecl) at 0x3045:0x1748, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L1748;

		L0548:
			if (this.oCPU.Flags.B) goto L055d;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'close'");
			return;

		L055d:
			this.oCPU.PushWord(0x0560); // stack management - push return offset
			// Instruction address 0x3045:0x055d, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/

			short sTemp = 0;

			if (this.oCPU.Files.ContainsKey(handle))
			{
				this.oCPU.Files.GetValueByKey(handle).Stream.Close();
				this.oCPU.Files.RemoveByKey(handle);
			}
			else
			{
				this.oParent.LogWriteLine($"Trying to close unknown handle {handle}");
				sTemp = -1;
			}

			this.oParent.LogWriteLine("Exiting function 'close'");
			return sTemp;

		/*L1748:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5908));
			if (this.oCPU.Flags.B) goto L175a;
			this.oCPU.AX.Word = 0x900;
			this.oCPU.Flags.C = true;
			goto L1765;

		L175a:
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L1765;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), 0x0);

		L1765:
			goto L0548;*/
		}

		public int lseek(short handle, int offset, short whence)
		{
			this.oParent.LogWriteLine("Entering function 'lseek'(Cdecl) at 0x3045:0x1768, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L1768;

		L055b:
			if (this.oCPU.Flags.AE) goto L0564;
			this.oCPU.PushWord(0x0560); // stack management - push return offset
			// Instruction address 0x3045:0x055d, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

		L0564:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'lseek'");
			return;

		L1768:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5908));
			if (this.oCPU.Flags.B) goto L177c;
			this.oCPU.AX.Word = 0x900;
			goto L17a6;

		L177c:
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x8000);
			if (this.oCPU.Flags.E) goto L17cb;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x0);
			if (this.oCPU.Flags.E) goto L17a3;
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = 0x4201;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L17df;
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x2);
			if (this.oCPU.Flags.NE) goto L17a9;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			if (this.oCPU.Flags.NS) goto L17cb;

		L17a3:
			this.oCPU.AX.Word = 0x1600;

		L17a6:
			this.oCPU.Flags.C = true;
			goto L17df;

		L17a9:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = 0x4202;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			if (this.oCPU.Flags.NS) goto L17cb;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = 0x4200;
			this.oCPU.INT(0x21);
			goto L17a3;

		L17cb:
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.AX.High = 0x42;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L17df;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0xfd));

		L17df:
			goto L055b;*/

			int iRetVal = -1;

			if (this.oCPU.Files.ContainsKey(handle) && whence >= 0 && whence < 3)
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

			this.oParent.LogWriteLine("Exiting function 'lseek'");

			return iRetVal;
		}

		public short open(uint filenameAddress, ushort flags)
		{
			this.oParent.LogWriteLine("Entering function 'open'(Cdecl) at 0x3045:0x17e2, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L17e2;

		L055b:
			if (this.oCPU.Flags.AE) goto L0564;
			this.oCPU.PushWord(0x0560); // stack management - push return offset
			// Instruction address 0x3045:0x055d, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

		L0564:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'open'");
			return;

		L17e2:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.High = 0x0;
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.BX.High);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x8000);
			if (this.oCPU.Flags.NE) goto L180b;
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x4000);
			if (this.oCPU.Flags.NE) goto L1807;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x5a77), 0x80);
			if (this.oCPU.Flags.NE) goto L180b;

		L1807:
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x80);

		L180b:
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x3);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			this.oCPU.AX.High = 0x3d;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L182a;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L1826;
			this.oCPU.TESTWord(this.oCPU.CX.Word, 0x100);
			if (this.oCPU.Flags.E) goto L1826;
			goto L18c7;

		L1826:
			this.oCPU.Flags.C = true;
			goto L055b;

		L182a:
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x500);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x500);
			if (this.oCPU.Flags.NE) goto L183e;
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = 0x1100;
			goto L1826;

		L183e:
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3), 0x1);
			this.oCPU.AX.Word = 0x4400;
			this.oCPU.INT(0x21);
			this.oCPU.TESTByte(this.oCPU.DX.Low, 0x80);
			if (this.oCPU.Flags.E) goto L1850;
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x40));

		L1850:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x40);
			if (this.oCPU.Flags.E) goto L1859;
			goto L192e;

		L1859:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x200);
			if (this.oCPU.Flags.E) goto L187e;
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.E) goto L186f;
			this.oCPU.CX.Word = 0x0;
			this.oCPU.AX.High = 0x40;
			this.oCPU.INT(0x21);
			goto L192e;

		L186f:
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = 0x4300;
			this.oCPU.INT(0x21);
			goto L18e4;

		L187e:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x80);
			if (this.oCPU.Flags.NE) goto L1887;
			goto L192e;

		L1887:
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L188f;
			goto L192e;

		L188f:
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = 0x4202;
			this.oCPU.INT(0x21);
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			// LEA
			this.oCPU.DX.Word = (ushort)(this.oCPU.BP.Word - 0x1);
			this.oCPU.AX.High = 0x3f;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L18bb;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1)), 0x1a);
			if (this.oCPU.Flags.NE) goto L18bb;
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = 0x4202;
			this.oCPU.INT(0x21);
			this.oCPU.CX.Word = 0x0;
			this.oCPU.AX.High = 0x40;
			this.oCPU.INT(0x21);

		L18bb:
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = 0x4200;
			this.oCPU.INT(0x21);
			goto L192e;

		L18c7:
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3), 0x0);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.PushWord(0x18d1); // stack management - push return offset
			// Instruction address 0x3045:0x18ce, size: 3
			_cXENIXtoDOSmode();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa), this.oCPU.CX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xff);
			if (this.oCPU.Flags.NE) goto L18e1;
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x2);
			if (this.oCPU.Flags.NE) goto L18e4;

		L18e1:
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0xfe);

		L18e4:
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.High = 0x3c;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L18f0;

		L18ed:
			goto L055b;

		L18f0:
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xff);
			if (this.oCPU.Flags.NE) goto L18fe;
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x2);
			if (this.oCPU.Flags.NE) goto L192e;

		L18fe:
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x3);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.High = 0x3d;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L18ed;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3)), 0x1);
			if (this.oCPU.Flags.NE) goto L192e;
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x1);
			if (this.oCPU.Flags.E) goto L192e;
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, 0x1);
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = 0x4301;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L18ed;

		L192e:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x40);
			if (this.oCPU.Flags.NE) goto L1971;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = 0x4300;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = 0x0;
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1947;
			this.oCPU.CX.Low = 0x10;

		L1947:
			this.oCPU.TESTWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x8);
			if (this.oCPU.Flags.E) goto L1951;
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, 0x20);

		L1951:
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5908));
			if (this.oCPU.Flags.B) goto L1961;
			this.oCPU.AX.High = 0x3e;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = 0x1800;
			goto L1826;

		L1961:
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CX.Low = this.oCPU.ORByte(this.oCPU.CX.Low, 0x1);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'open'");
			return;

		L1971:
			this.oCPU.CX.Low = 0x0;
			goto L1951;*/

			string sName = this.oCPU.ReadString(filenameAddress);
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
			if ((flags & 0x4000) == 0x4000)
			{
				// file mode is text (translated)
				eType = FileStreamTypeEnum.Text;
			}
			if ((flags & 0x8000) == 0x8000)
			{
				// file mode is binary (untranslated)
				eType = FileStreamTypeEnum.Binary;
			}

			this.oParent.LogWriteLine($"Opening file '{this.oCPU.DefaultDirectory}{sName}'");
			this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream($"{this.oCPU.DefaultDirectory}{sName}", eMode, eAccess), eType));
			short sHandle = this.oCPU.FileHandleCount;
			this.oCPU.FileHandleCount++;

			this.oParent.LogWriteLine("Exiting function 'open'");

			return sHandle;
		}

		public short read(short handle, uint address, ushort length)
		{
			this.oParent.LogWriteLine("Entering function 'read'(Cdecl) at 0x3045:0x1986, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L1986;

		L055b:
			if (this.oCPU.Flags.AE) goto L0564;
			this.oCPU.PushWord(0x0560); // stack management - push return offset
			// Instruction address 0x3045:0x055d, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

		L0564:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'read'");
			return;

		L1986:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5908));
			if (this.oCPU.Flags.B) goto L199b;
			this.oCPU.Flags.C = true;
			this.oCPU.AX.Word = 0x900;
			goto L19f7;

		L199b:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.CX.Word == 0) goto L19f7;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x2);
			if (this.oCPU.Flags.NE) goto L19f7;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.High = 0x3f;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L19b9;
			this.oCPU.AX.High = 0x9;
			goto L19f7;

		L19b9:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x80);
			if (this.oCPU.Flags.E) goto L19f7;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), this.oCPU.ANDByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0xfb));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.Flags.D = false;
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			if (this.oCPU.CX.Word == 0) goto L19f5;
			this.oCPU.AX.High = 0xd;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word), 0xa);
			if (this.oCPU.Flags.NE) goto L19dc;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x4));

		L19dc:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			if (this.oCPU.Flags.E) goto L19fa;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x1a);
			if (this.oCPU.Flags.NE) goto L19ec;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a), this.oCPU.ORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x2));
			goto L19f1;

		L19ec:
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);

		L19ef:
			if (this.oCPU.Loop(this.oCPU.CX)) goto L19dc;

		L19f1:
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);

		L19f5:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();

		L19f7:
			goto L055b;

		L19fa:
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1a06;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word), 0xa);
			if (this.oCPU.Flags.E) goto L19ef;
			goto L19ec;

		L1a06:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x40);
			if (this.oCPU.Flags.E) goto L1a25;
			this.oCPU.AX.Word = 0x4400;
			this.oCPU.INT(0x21);
			this.oCPU.TESTWord(this.oCPU.DX.Word, 0x20);
			if (this.oCPU.Flags.NE) goto L1a21;
			// LEA
			this.oCPU.DX.Word = (ushort)(this.oCPU.BP.Word - 0x1);
			this.oCPU.AX.High = 0x3f;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L19f5;

		L1a21:
			this.oCPU.AX.Low = 0xa;
			goto L1a51;

		L1a25:
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1), 0x0);
			// LEA
			this.oCPU.DX.Word = (ushort)(this.oCPU.BP.Word - 0x1);
			this.oCPU.AX.High = 0x3f;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L19f5;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1a4f;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x1);
			if (this.oCPU.Flags.E) goto L1a5b;

		L1a3c:
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.AX.Word = 0x4201;
			this.oCPU.INT(0x21);
			this.oCPU.CX.Word = 0x1;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1)), 0xa);
			if (this.oCPU.Flags.E) goto L1a56;

		L1a4f:
			this.oCPU.AX.Low = 0xd;

		L1a51:
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			goto L19ec;

		L1a56:
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			goto L19ef;

		L1a5b:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1)), 0xa);
			if (this.oCPU.Flags.NE) goto L1a3c;
			goto L1a21;*/

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

			this.oParent.LogWriteLine("Exiting function 'read'");
			return sItemCount;
		}

		public short write(short handle, uint address, ushort length)
		{
			this.oParent.LogWriteLine("Entering function 'write'(Cdecl) at 0x3045:0x1a64, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L1a64;

		L00c5:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x00cb); // stack management - push return offset
			// Instruction address 0x3045:0x00c6, size: 5
			_FF_MSGBANNER();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x00d0); // stack management - push return offset
			// Instruction address 0x3045:0x00cb, size: 5
			_NMSG_WRITE();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = 0xff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x00d9); // stack management - push return offset
			// Instruction address 0x3045:0x00d5, size: 4
			this.oCPU.Call(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x588e));
			this.oCPU.PopWord(); // stack management - pop return offset

		L055b:
			if (this.oCPU.Flags.AE) goto L0564;
			this.oCPU.PushWord(0x0560); // stack management - push return offset
			// Instruction address 0x3045:0x055d, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

		L0564:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'write'");
			return;

		L1a64:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5908));
			if (this.oCPU.Flags.B) goto L1a7a;
			this.oCPU.AX.Word = 0x900;
			this.oCPU.Flags.C = true;

		L1a77:
			goto L055b;

		L1a7a:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x20);
			if (this.oCPU.Flags.E) goto L1a8c;
			this.oCPU.AX.Word = 0x4202;
			this.oCPU.CX.Word = 0x0;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L1a77;

		L1a8c:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x80);
			if (this.oCPU.Flags.E) goto L1b03;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.Flags.D = false;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.SP.Word);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.CX.Word == 0) goto L1b05;
			this.oCPU.AX.Low = 0xa;
			this.oCPU.REPNESCASByte();
			if (this.oCPU.Flags.NE) goto L1b01;
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x1aba); // stack management - push return offset
			// Instruction address 0x3045:0x1ab5, size: 5
			stackavail();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa8);
			if (this.oCPU.Flags.BE) goto L1b07;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.BX.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = 0x200;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x228);
			if (this.oCPU.Flags.AE) goto L1acf;
			this.oCPU.DX.Word = 0x80;

		L1acf:
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, this.oCPU.DX.Word);
			this.oCPU.DX.Word = this.oCPU.SP.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.PushWord(this.oCPU.SS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));

		L1ada:
			this.oCPU.LODSByte();
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xa);
			if (this.oCPU.Flags.E) goto L1aeb;

		L1adf:
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L1afc;

		L1ae3:
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L1ada;
			this.oCPU.PushWord(0x1ae9); // stack management - push return offset
			// Instruction address 0x3045:0x1ae6, size: 3
			this.oParent.Segment_3045.F0_3045_1b0c();
			this.oCPU.PopWord(); // stack management - pop return offset
			goto L1b4c;

		L1aeb:
			this.oCPU.AX.Low = 0xd;
			this.oCPU.CMPWord(this.oCPU.DI.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L1af4;
			this.oCPU.PushWord(0x1af4); // stack management - push return offset
			// Instruction address 0x3045:0x1af1, size: 3
			this.oParent.Segment_3045.F0_3045_1b0c();
			this.oCPU.PopWord(); // stack management - pop return offset

		L1af4:
			this.oCPU.STOSByte();
			this.oCPU.AX.Low = 0xa;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			goto L1adf;

		L1afc:
			this.oCPU.PushWord(0x1aff); // stack management - push return offset
			// Instruction address 0x3045:0x1afc, size: 3
			this.oParent.Segment_3045.F0_3045_1b0c();
			this.oCPU.PopWord(); // stack management - pop return offset
			goto L1ae3;

		L1b01:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();

		L1b03:
			goto L1b5a;

		L1b05:
			goto L1b4c;

		L1b07:
			this.oCPU.AX.Word = 0x0;
			goto L00c5;

		L1b4c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SP.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();

		L1b57:
			goto L055b;

		L1b5a:
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L1b66;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			goto L055b;

		L1b66:
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.High = 0x40;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.AE) goto L1b73;
			this.oCPU.AX.High = 0x9;
			goto L1b57;

		L1b73:
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1b57;
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x590a)), 0x40);
			if (this.oCPU.Flags.E) goto L1b88;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x1a);
			if (this.oCPU.Flags.NE) goto L1b88;
			this.oCPU.Flags.C = false;
			goto L1b57;

		L1b88:
			this.oCPU.Flags.C = true;
			this.oCPU.AX.Word = 0x1c00;
			goto L1b57;*/

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

			this.oParent.LogWriteLine("Exiting function 'write'");
			return sItemCount;
		}

		public short _dos_open(uint filenameAddress, ushort flags, uint handleAddress)
		{
			this.oParent.LogWriteLine("Entering function '_dos_open'(Cdecl) at 0x3045:0x30ce, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L30ce;

		L054a:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_dos_open'");
			return;

		L0550:
			if (this.oCPU.Flags.AE) goto L054a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0556); // stack management - push return offset
			// Instruction address 0x3045:0x0553, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_dos_open'");
			return;

		L30ce:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.High = 0x3d;
			this.oCPU.INT(0x21);
			if (this.oCPU.Flags.B) goto L30e2;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L30e2:
			goto L0550;*/

			short sRetVal = -1;

			string sName = this.oCPU.ReadString(filenameAddress);
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

			this.oParent.LogWriteLine($"Opening file '{this.oCPU.DefaultDirectory}{sName}'");
			this.oCPU.Files.Add(this.oCPU.FileHandleCount, new FileStreamItem(new FileStream($"{this.oCPU.DefaultDirectory}{sName}", eMode, eAccess), eType));
			short sHandle = this.oCPU.FileHandleCount;
			this.oCPU.FileHandleCount++;
			this.oCPU.Memory.WriteWord(handleAddress, (ushort)sHandle);
			sRetVal = 0;

			this.oParent.LogWriteLine("Exiting function '_dos_open'");

			return sRetVal;
		}

		public short _dos_close(short handle)
		{
			this.oParent.LogWriteLine("Entering function '_dos_close'(Cdecl) at 0x3045:0x308e, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L308e;

		L054a:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_dos_close'");
			return;

		L0550:
			if (this.oCPU.Flags.AE) goto L054a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0556); // stack management - push return offset
			// Instruction address 0x3045:0x0553, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();*/
			short sTemp = this.close(handle);
			this.oParent.LogWriteLine("Exiting function '_dos_close'");
			return sTemp;

			/*L308e:
				this.oCPU.PushWord(this.oCPU.BP.Word);
				this.oCPU.BP.Word = this.oCPU.SP.Word;
				this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
				this.oCPU.AX.High = 0x3e;
				this.oCPU.INT(0x21);
				goto L0550;*/
		}

		public ushort _dos_read(short handle, uint address, ushort length, uint nreadAddress)
		{
			this.oParent.LogWriteLine("Entering function '_dos_read'(Cdecl) at 0x3045:0x30e6, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			goto L30e6;

		L054a:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_dos_read'");
			return;

		L0550:
			if (this.oCPU.Flags.AE) goto L054a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0556); // stack management - push return offset
			// Instruction address 0x3045:0x0553, size: 3
			this.oParent.Segment_3045.F0_3045_056e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function '_dos_read'");
			return;

		L30e6:
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.High = 0x3f;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.PushWord(this.oCPU.DS.Word);
			// LDS
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DS.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)((ushort)(this.oCPU.BP.Word + 0x8) + 2));
			this.oCPU.INT(0x21);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			if (this.oCPU.Flags.B) goto L3106;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L3106:
			goto L0550;*/

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
						this.oCPU.Memory.WriteByte(address, (byte)ch);
						address++;
						usItemCount++;
					}
					else
					{
						break;
					}
				}

				this.oCPU.Memory.WriteWord(nreadAddress, usItemCount);
				usRetVal = 0;
			}

			this.oParent.LogWriteLine("Exiting function '_dos_read'");

			return usRetVal;
		}

		public void _bios_disk()
		{
			this.oParent.LogWriteLine("Entering function '_bios_disk'(Cdecl) at 0x3045:0x3062, stack: 0x0");
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
			this.oParent.LogWriteLine("Exiting function '_bios_disk'");
		}

		public void _dos_getdrive()
		{
			this.oParent.LogWriteLine("Entering function '_dos_getdrive'(Cdecl) at 0x3045:0x312e, stack: 0x0");
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
			this.oParent.LogWriteLine("Exiting function '_dos_getdrive'");
		}
		#endregion

		#region String operations
		public void strcat()
		{
			this.oParent.LogWriteLine("Entering function 'strcat'(Cdecl) at 0x3045:0x1e22, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			// LEA
			this.oCPU.SI.Word = (ushort)(this.oCPU.DI.Word - 0x1);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.SUBWord(this.oCPU.DI.Word, this.oCPU.CX.Word);
			this.oCPU.Temp.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.DI.Word;
			this.oCPU.DI.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.TESTWord(this.oCPU.SI.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1e53;
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);

		L1e53:
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.CX.Word = this.oCPU.ADCWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strcat'");
		}

		public void strcpy()
		{
			this.oParent.LogWriteLine("Entering function 'strcpy'(Cdecl) at 0x3045:0x1e62, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.BX.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L1e86;
			this.oCPU.MOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);

		L1e86:
			this.oCPU.CX.Word = this.oCPU.SHRWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.REPEMOVSWord(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.CX.Word = this.oCPU.ADCWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.REPEMOVSByte(this.oCPU.DS, this.oCPU.SI, this.oCPU.ES, this.oCPU.DI, this.oCPU.CX);
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strcpy'");
		}

		public void strlen()
		{
			this.oParent.LogWriteLine("Entering function 'strlen'(Cdecl) at 0x3045:0x1e94, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Word = this.oCPU.Temp.Word;
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strlen'");
		}

		public void strncpy()
		{
			this.oParent.LogWriteLine("Entering function 'strncpy'(Cdecl) at 0x3045:0x1eb0, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.CX.Word == 0) goto L1ed0;

		L1ec4:
			this.oCPU.LODSByte();
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L1ecc;
			this.oCPU.STOSByte();
			if (this.oCPU.Loop(this.oCPU.CX)) goto L1ec4;

		L1ecc:
			this.oCPU.AX.Low = 0x0;
			this.oCPU.REPESTOSByte();

		L1ed0:
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strncpy'");
		}

		public void strncmp()
		{
			this.oParent.LogWriteLine("Entering function 'strncmp'(Cdecl) at 0x3045:0x1ed8, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.CX.Word == 0) goto L1f0a;
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.REPECMPSByte(this.oCPU.ES, this.oCPU.DI, this.oCPU.DS, this.oCPU.SI);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x1));
			this.oCPU.CX.Word = 0x0;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word - 0x1)));
			if (this.oCPU.Flags.A) goto L1f08;
			if (this.oCPU.Flags.E) goto L1f0a;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);

		L1f08:
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);

		L1f0a:
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strncmp'");
		}

		public void stricmp()
		{
			this.oParent.LogWriteLine("Entering function 'stricmp'(Cdecl) at 0x3045:0x28f0, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Low = 0xff;

			L28fd:
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L292d;
			this.oCPU.LODSByte();
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.CMPByte(this.oCPU.AX.High, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L28fd;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x1a);
			this.oCPU.CX.Low = this.oCPU.SBBByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x20);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.Temp.Low = this.oCPU.AX.Low;
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.AX.High = this.oCPU.Temp.Low;
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x1a);
			this.oCPU.CX.Low = this.oCPU.SBBByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x20);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.AX.High);
			if (this.oCPU.Flags.E) goto L28fd;
			this.oCPU.AX.Low = this.oCPU.SBBByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.SBBByte(this.oCPU.AX.Low, 0xff);

			L292d:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'stricmp'");
		}

		public void strnicmp()
		{
			this.oParent.LogWriteLine("Entering function 'strnicmp'(Cdecl) at 0x3045:0x2932, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.CX.Word == 0) goto L2981;
			this.oCPU.BX.High = 0x41;
			this.oCPU.BX.Low = 0x5a;
			this.oCPU.DX.High = 0x20;

			L294a:
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.AX.High = this.oCPU.ORByte(this.oCPU.AX.High, this.oCPU.AX.High);
			if (this.oCPU.Flags.E) goto L2972;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2972;
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.INCWord(this.oCPU.DI.Word);
			this.oCPU.CMPByte(this.oCPU.AX.High, this.oCPU.BX.High);
			if (this.oCPU.Flags.B) goto L2962;
			this.oCPU.CMPByte(this.oCPU.AX.High, this.oCPU.BX.Low);
			if (this.oCPU.Flags.A) goto L2962;
			this.oCPU.AX.High = this.oCPU.ADDByte(this.oCPU.AX.High, this.oCPU.DX.High);

			L2962:
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.BX.High);
			if (this.oCPU.Flags.B) goto L296c;
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.BX.Low);
			if (this.oCPU.Flags.A) goto L296c;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.DX.High);

			L296c:
			this.oCPU.CMPByte(this.oCPU.AX.High, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L2978;
			if (this.oCPU.Loop(this.oCPU.CX)) goto L294a;

			L2972:
			this.oCPU.CX.Word = 0x0;
			this.oCPU.CMPByte(this.oCPU.AX.High, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2981;

			L2978:
			this.oCPU.CX.Word = 0x0;
			if (this.oCPU.Flags.B) goto L297f;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);

			L297f:
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);

			L2981:
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strnicmp'");
		}

		public void strupr()
		{
			this.oParent.LogWriteLine("Entering function 'strupr'(Cdecl) at 0x3045:0x298a, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DX.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L29a9;

			L2998:
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, 0x61);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x1a);
			if (this.oCPU.Flags.AE) goto L29a2;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Low);

			L29a2:
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L2998;

			L29a9:
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strupr'");
		}

		public void strstr()
		{
			this.oParent.LogWriteLine("Entering function 'strstr'(Cdecl) at 0x3045:0x29ac, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			if (this.oCPU.CX.Word == 0) goto L29ff;
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.REPNESCASByte();
			this.oCPU.CX.Word = this.oCPU.NOTWord(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DECWord(this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			if (this.oCPU.Flags.BE) goto L29ff;
			this.oCPU.DI.Word = this.oCPU.BX.Word;

			L29e1:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.LODSByte();
			this.oCPU.DI.Word = this.oCPU.BX.Word;
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.REPNESCASByte();
			if (this.oCPU.Flags.NE) goto L29ff;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.BX.Word = this.oCPU.DI.Word;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			if (this.oCPU.CX.Word == 0) goto L29fa;
			this.oCPU.REPECMPSByte(this.oCPU.ES, this.oCPU.DI, this.oCPU.DS, this.oCPU.SI);
			if (this.oCPU.Flags.NE) goto L29e1;

			L29fa:
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BX.Word - 0x1);
			goto L2a01;

			L29ff:
			this.oCPU.AX.Word = 0x0;

			L2a01:
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'strstr'");
		}

		public void itoa()
		{
			this.oParent.LogWriteLine("Entering function 'itoa'(Cdecl) at 0x3045:0x1f6a, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.BX.Low = 0x1;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.DX.Word = 0x0;
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1f7f;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);

			L1f7f:
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.Flags.D = false;
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.E) goto L2a8a;
			this.oCPU.CMPWord(this.oCPU.CX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L2a8a;
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NS) goto L2a8a;
			this.oCPU.AX.Low = 0x2d;
			this.oCPU.STOSByte();
			this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, 0x0);
			this.oCPU.DX.Word = this.oCPU.NEGWord(this.oCPU.DX.Word);

			L2a8a:
			this.oCPU.SI.Word = this.oCPU.DI.Word;

			L2a8c:
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.DX.Word = 0x0;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2a95;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

			L2a95:
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.Temp.Word;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.Temp.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.Temp.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = this.oCPU.Temp.Word;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x39);
			if (this.oCPU.Flags.BE) goto L2aa3;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x27);

			L2aa3:
			this.oCPU.STOSByte();
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L2a8c;
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);

			L2aac:
			this.oCPU.DI.Word = this.oCPU.DECWord(this.oCPU.DI.Word);
			this.oCPU.LODSByte();
			this.oCPU.Temp.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.Temp.Low;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x1), this.oCPU.AX.Low);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.SI.Word + 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.B) goto L2aac;
			this.oCPU.AX.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'itoa'");
		}
		#endregion

		#region Time operations
		public int time(uint timeAddress)
		{
			this.oParent.LogWriteLine("Entering function 'time'(Cdecl) at 0x3045:0x25e6, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.High = 0x2a;
			this.oCPU.INT(0x21);
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.CX.Word;
			this.oCPU.AX.High = 0x2c;
			this.oCPU.INT(0x21);
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Low = this.oCPU.DX.High;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.CX.Low;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.CX.High;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.High = 0x2a;
			this.oCPU.INT(0x21);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.PopWord();
			if (this.oCPU.Flags.E) goto L2613;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x17);
			if (this.oCPU.Flags.NE) goto L2613;
			this.oCPU.DX.Word = this.oCPU.BX.Word;
			this.oCPU.CX.Word = this.oCPU.SI.Word;

		L2613:
			this.oCPU.AX.High = 0x0;
			this.oCPU.AX.Low = this.oCPU.DX.Low;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.DX.High;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, 0x7bc);
			this.oCPU.PushWord(this.oCPU.CX.Word);
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2625); // stack management - push return offset
			// Instruction address 0x3045:0x2620, size: 5
			_dtoxtime();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L2636;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2), this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L2636:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();*/
			this.oParent.LogWriteLine("Exiting function 'time'");

			int iTotalSeconds = (int)Math.Floor((DateTime.Now - (new DateTime(1970, 1, 1, 0, 0, 0))).TotalSeconds);

			if (timeAddress != 0)
				this.oCPU.Memory.WriteDWord(timeAddress, (uint)iTotalSeconds);

			return iTotalSeconds;
		}
		#endregion

		#region Math operations
		public short abs(short value)
		{
			this.oParent.LogWriteLine("Entering function 'abs'(Cdecl) at 0x3045:0x2ac2, stack: 0x0");

			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x0);
			if (this.oCPU.Flags.L) goto L2ad0;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			goto L2ad5;

		L2ad0:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);

		L2ad5:
			this.oCPU.BP.Word = this.oCPU.PopWord();*/
			this.oParent.LogWriteLine("Exiting function 'abs'");

			return Math.Abs(value);
		}

		public void _aFlmul()
		{
			this.oParent.LogWriteLine("Entering function 'F0_3045_31de'(Pascal) at 0x3045:0x31de, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			if (this.oCPU.Flags.NE) goto L31f9;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.BX.Word);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_3045_31de'");
			return;

			L31f9:
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.BX.Word);
			this.oCPU.DX.Word = this.oCPU.ADDWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_3045_31de'");
		}
		#endregion

		#region Random operations
		public void srand(ushort value)
		{
			this.oParent.LogWriteLine("Entering function 'srand'(Cdecl) at 0x3045:0x2ad8, stack: 0x0");

			this.oRNG = new RandomMT19937(value);
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5c38, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5c3a, 0x0);
			this.oCPU.BP.Word = this.oCPU.PopWord();*/
			this.oParent.LogWriteLine("Exiting function 'srand'");
		}

		public short rand()
		{
			this.oParent.LogWriteLine("Entering function 'rand'(Cdecl) at 0x3045:0x2aea, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x43fd;
			this.oCPU.DX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5c3a));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5c38));
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x2aff); // stack management - push return offset
			// Instruction address 0x3045:0x2afa, size: 5
			this.oParent.Segment_3045.F0_3045_31de();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x9ec3);
			this.oCPU.DX.Word = this.oCPU.ADCWord(this.oCPU.DX.Word, 0x26);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5c38, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5c3a, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.High = this.oCPU.ANDByte(this.oCPU.AX.High, 0x7f);*/
			this.oParent.LogWriteLine("Exiting function 'rand'");
			return (short)(this.oRNG.UNext() & 0x7fff);
		}
		#endregion

		#region Shifting operations
		public void _aFlshl()
		{
			this.oParent.LogWriteLine("Entering function '_aFlshl'(Cdecl) at 0x3045:0x32b4, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.CX.High = 0x0;
			if (this.oCPU.CX.Word == 0) goto L32be;

		L32b8:
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.DX.Word = this.oCPU.RCLWord(this.oCPU.DX.Word, 0x1);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L32b8;

		L32be:*/
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Word);
			this.oParent.LogWriteLine("Exiting function '_aFlshl'");
		}

		public void _aFlshr()
		{
			this.oParent.LogWriteLine("Entering function '_aFlshr'(Cdecl) at 0x3045:0x32c0, stack: 0x0");
			/*this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.CX.High = 0x0;
			if (this.oCPU.CX.Word == 0) goto L32ca;

		L32c4:
			this.oCPU.DX.Word = this.oCPU.SARWord(this.oCPU.DX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.RCRWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L32c4;

		L32ca:*/

			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) >> this.oCPU.CX.Word);
			this.oParent.LogWriteLine("Exiting function '_aFlshr'");
		}
		#endregion

		#region Interrupt and vector operations
		public void int86()
		{
			this.oParent.LogWriteLine("Entering function 'int86'(Cdecl) at 0x3045:0x20c4, stack: 0x0");
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
			// Instruction address 0x3045:0x210e, size: 3
			//this.oCPU.CallF(this.oCPU.ReadDWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			//this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
										// Instruction address 0x3045:0x212e, size: 5
			_maperror();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
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
			this.oParent.LogWriteLine("Exiting function 'int86'");
		}

		public void intdos()
		{
			this.oParent.LogWriteLine("Entering function 'intdos'(Cdecl) at 0x3045:0x257e, stack: 0x0");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2));
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4));
			this.oCPU.DX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xa));
			this.oCPU.INT(0x21);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x2), this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x4), this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x6), this.oCPU.DX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x8), this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xa), this.oCPU.PopWord());
			if (this.oCPU.Flags.B) goto L25b4;
			this.oCPU.SI.Word = 0x0;
			goto L25be;

			L25b4:
			this.oCPU.PushWord(0x3045); // stack management - push return segment
			this.oCPU.PushWord(0x25b9); // stack management - push return offset
										// Instruction address 0x3045:0x25b4, size: 5
			_maperror();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x3045; // restore this function segment
			this.oCPU.SI.Word = 0x1;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, this.oCPU.DI.Word);

			L25be:
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xc), this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'intdos'");
		}

		public void _dos_getvect()
		{
			this.oParent.LogWriteLine("Entering function '_dos_getvect'(Cdecl) at 0x3045:0x30bc, stack: 0x0");
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
			this.oParent.LogWriteLine("Exiting function '_dos_getvect'");
		}

		public void _dos_setvect()
		{
			this.oParent.LogWriteLine("Entering function '_dos_setvect'(Cdecl) at 0x3045:0x310a, stack: 0x0");
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
			this.oParent.LogWriteLine("Exiting function '_dos_setvect'");
		}
		#endregion
	}
}
