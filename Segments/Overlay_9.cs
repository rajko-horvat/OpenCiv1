using Disassembler;

namespace Civilization1
{
	public class Overlay_9
	{
		private Civilization oParent;
		private CPU oCPU;

		public Overlay_9(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F9_0000_0000()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0000'(Cdecl) at 0x0000:0x0000, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x24);
			this.oCPU.PushWord(this.oCPU.SI.Word);

		L0007:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680e), 0x0);
			if (this.oCPU.Flags.NE) goto L0027;
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3fb0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x001f); // stack management - push return offset
			// Instruction address 0x0000:0x001a, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x680a, this.oCPU.AX.Word);
			goto L002d;

		L0027:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x680a, 0x4);

		L002d:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x0);
			if (this.oCPU.Flags.G) goto L0037;
			goto L089e;

		L0037:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.NE) goto L0085;
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.open(CPUMemory.ToLinearAddress(this.oCPU.DS.Word,0x3ffd),
				0x8301);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x680c, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0081;
			this.oCPU.AX.Word = 0x4008;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0067); // stack management - push return offset
			// Instruction address 0x0000:0x0062, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x007b); // stack management - push return offset
			// Instruction address 0x0000:0x0076, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			goto L089e;

		L0081:
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0c30();

		L0085:
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x008a); // stack management - push return offset
			// Instruction address 0x0000:0x0085, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x008f); // stack management - push return offset
			// Instruction address 0x0000:0x008a, size: 5
			this.oParent.Segment_1866.F0_1866_25b6();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L0094:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6422);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0), 0xffff);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x80);
			if (this.oCPU.Flags.L) goto L0094;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);

		L00b3:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x280c));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.L) goto L00b3;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);
			goto L00e8;

		L00cf:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));

		L00d2:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x280c), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0d5d();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L00e5:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));

		L00e8:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.GE) goto L010c;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L00e5;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdf1e));
			if (this.oCPU.Flags.E) goto L00cf;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			goto L00d2;

		L010c:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.E) goto L0191;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x012b); // stack management - push return offset
			// Instruction address 0x0000:0x0126, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);
			goto L0184;

		L0135:
			this.oCPU.AX.Word = 0x8;

		L0138:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x015a); // stack management - push return offset
			// Instruction address 0x0000:0x0155, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0160:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x50);
			if (this.oCPU.Flags.GE) goto L0181;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0171); // stack management - push return offset
			// Instruction address 0x0000:0x016c, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0135;
			this.oCPU.AX.Word = 0x1;
			goto L0138;

		L0181:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L0184:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x31);
			if (this.oCPU.Flags.GE) goto L0191;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L0160;

		L0191:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0196:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x40dc);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L01a1;
			goto L083d;

		L01a1:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.CX.High = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CX.Low = this.oCPU.SUBByte(this.oCPU.CX.Low, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_097c();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, 0xffff); // Segment
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd80a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.abs((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x020c); // stack management - push return offset
			// Instruction address 0x0000:0x0207, size: 5
			this.oParent.MSCAPI.itoa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0219); // stack management - push return offset
			// Instruction address 0x0000:0x0214, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.GE) goto L0227;
			this.oCPU.AX.Word = 0x4014;
			goto L022a;

		L0227:
			this.oCPU.AX.Word = 0x4018;

		L022a:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0234); // stack management - push return offset
			// Instruction address 0x0000:0x022f, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x401c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0244); // stack management - push return offset
			// Instruction address 0x0000:0x023f, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xc);
			if (this.oCPU.Flags.BE) goto L0255;
			goto L0826;

		L0255:
			switch(this.oCPU.AX.Word)
			{
				case 0:
					goto L025d;
				case 1:
					goto L03ae;
				case 2:
					goto L0414;
				case 3:
					goto L0826;
				case 4:
					goto L0453;
				case 5:
					goto L04a8;
				case 6:
					goto L0826;
				case 7:
					goto L04fb;
				case 8:
					goto L025d;
				case 9:
					goto L054f;
				case 10:
					goto L05b9;
				case 11:
					goto L065c;
				case 12:
					goto L0779;
			}

		L025d:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810), 0xff);
			if (this.oCPU.Flags.NE) goto L02a6;
			goto L0336;

		L02a6:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x02b9); // stack management - push return offset
			// Instruction address 0x0000:0x02b4, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1);
			if (this.oCPU.Flags.NE) goto L02e2;
			this.oCPU.AX.Word = 0x401f;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x02cf); // stack management - push return offset
			// Instruction address 0x0000:0x02ca, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_09dc();
			goto L0300;

		L02e2:
			this.oCPU.AX.Word = 0x4033;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x02ef); // stack management - push return offset
			// Instruction address 0x0000:0x02ea, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0a22();

		L0300:
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = 0xd;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0310); // stack management - push return offset
			// Instruction address 0x0000:0x030b, size: 5
			this.oParent.MSCAPI.strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba06);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BX.Word + 0x0);
			this.oCPU.DX.Word = 0x3604;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x032d); // stack management - push return offset
			// Instruction address 0x0000:0x0328, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0500();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_08a3();
			goto L0388;

		L0336:
			this.oCPU.AX.Word = 0xd;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0343); // stack management - push return offset
			// Instruction address 0x0000:0x033e, size: 5
			this.oParent.MSCAPI.strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba06);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd; // Segment
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.BX.Word + 0x0);
			this.oCPU.DX.Word = 0x3604; // Segment
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0360); // stack management - push return offset
			// Instruction address 0x0000:0x035b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0500();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = 0x403d;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0370); // stack management - push return offset
			// Instruction address 0x0000:0x036b, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_08a3();
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0a22();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L0388:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0ac8();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x1);
			if (this.oCPU.Flags.E) goto L039f;
			goto L0826;

		L039f:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x03a8); // stack management - push return offset
			// Instruction address 0x0000:0x03a3, size: 5
			this.oParent.Segment_1182.F0_1182_0134();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			goto L0826;

		L03ae:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x03e5); // stack management - push return offset
			// Instruction address 0x0000:0x03e0, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x4048;

		L03eb:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x03f5); // stack management - push return offset
			// Instruction address 0x0000:0x03f0, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

		L0401:
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x040a); // stack management - push return offset
			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L040d:
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_08a3();
			goto L0826;

		L0414:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0xf);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x044b); // stack management - push return offset
			// Instruction address 0x0000:0x0446, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x4059; // Segment
			goto L03eb;

		L0453:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0488); // stack management - push return offset
			// Instruction address 0x0000:0x0483, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x406b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0498); // stack management - push return offset
			// Instruction address 0x0000:0x0493, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);

		L04a4:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			goto L0401;

		L04a8:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x04dd); // stack management - push return offset
			// Instruction address 0x0000:0x04d8, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x4076;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x04ed); // stack management - push return offset
			// Instruction address 0x0000:0x04e8, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x112a);
			goto L04a4;

		L04fb:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0530); // stack management - push return offset
			// Instruction address 0x0000:0x052b, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x4086;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0540); // stack management - push return offset
			// Instruction address 0x0000:0x053b, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1966)));
			goto L0401;

		L054f:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0584); // stack management - push return offset
			// Instruction address 0x0000:0x057f, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x408d;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0594); // stack management - push return offset
			// Instruction address 0x0000:0x058f, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x7);
			if (this.oCPU.Flags.G) goto L05ad;
			this.oCPU.AX.Word = 0x4095;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x05aa); // stack management - push return offset
			// Instruction address 0x0000:0x05a5, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L05ad:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xe6a);
			goto L04a4;

		L05b9:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0602); // stack management - push return offset
			// Instruction address 0x0000:0x05fd, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x409a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0612); // stack management - push return offset
			// Instruction address 0x0000:0x060d, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd80a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0625); // stack management - push return offset
			// Instruction address 0x0000:0x0620, size: 5
			this.oParent.MSCAPI.itoa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0632); // stack management - push return offset
			// Instruction address 0x0000:0x062d, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x409d;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0642); // stack management - push return offset
			// Instruction address 0x0000:0x063d, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.High = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.AX.Low = this.oCPU.SUBByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0653); // stack management - push return offset
			// Instruction address 0x0000:0x064e, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0337();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x40a7;
			goto L04a4;

		L065c:
			this.oCPU.AX.Word = 0x40b3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0669); // stack management - push return offset
			// Instruction address 0x0000:0x0664, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0671:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc)), 0xf0);
			if (this.oCPU.Flags.E) goto L06e8;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd80a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0694); // stack management - push return offset
			// Instruction address 0x0000:0x068f, size: 5
			this.oParent.MSCAPI.itoa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x06a1); // stack management - push return offset
			// Instruction address 0x0000:0x069c, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x40b8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x06b1); // stack management - push return offset
			// Instruction address 0x0000:0x06ac, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.BX.High = this.oCPU.SUBByte(this.oCPU.BX.High, this.oCPU.BX.High);
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x06d5); // stack management - push return offset
			// Instruction address 0x0000:0x06d0, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x40ba;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x06e5); // stack management - push return offset
			// Instruction address 0x0000:0x06e0, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L06e8:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc)), 0xf);
			if (this.oCPU.Flags.E) goto L075d;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd80a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x070c); // stack management - push return offset
			// Instruction address 0x0000:0x0707, size: 5
			this.oParent.MSCAPI.itoa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0719); // stack management - push return offset
			// Instruction address 0x0000:0x0714, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x40bc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0729); // stack management - push return offset
			// Instruction address 0x0000:0x0724, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.BX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0xf);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x074a); // stack management - push return offset
			// Instruction address 0x0000:0x0745, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x40be;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x075a); // stack management - push return offset
			// Instruction address 0x0000:0x0755, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L075d:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x4);
			if (this.oCPU.Flags.GE) goto L076c;
			goto L0671;

		L076c:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.E) goto L0776;
			goto L0826;

		L0776:
			goto L040d;

		L0779:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6424);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6810, this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x26fc));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x07ae); // stack management - push return offset
			// Instruction address 0x0000:0x07a9, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x40c0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x07be); // stack management - push return offset
			// Instruction address 0x0000:0x07b9, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x07d3); // stack management - push return offset
			// Instruction address 0x0000:0x07ce, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.NE) goto L07f3;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L07f3;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0f79();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L07f3:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x280c), this.oCPU.XORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x280c)), 0x8));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0d5d();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			goto L040d;

		L0826:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x2);
			if (this.oCPU.Flags.E) goto L0830;
			goto L0196;

		L0830:
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.getch();
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1b);
			if (this.oCPU.Flags.E) goto L083d;
			goto L0196;

		L083d:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);

		L0842:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x280c), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.L) goto L0842;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);

		L085c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L086e;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0d5d();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L086e:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x8);
			if (this.oCPU.Flags.L) goto L085c;
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x087c); // stack management - push return offset
			// Instruction address 0x0000:0x0877, size: 5
			this.oParent.Segment_1866.F0_1866_25d7();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0881); // stack management - push return offset
			// Instruction address 0x0000:0x087c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.NE) goto L0894;
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.close((short)this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680c));

		L0894:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.GE) goto L089e;
			goto L0007;

		L089e:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0000'");
		}

		public void F9_0000_08a3()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_08a3'(Cdecl) at 0x0000:0x08a3, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.NE) goto L08b3;
			goto L0978;

		L08b3:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6810), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L08c8;
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x08c5); // stack management - push return offset
			// Instruction address 0x0000:0x08c0, size: 5
			this.oParent.MSCAPI.strupr();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L08c8:
			this.oCPU.AX.Word = 0xf;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x08e1); // stack management - push return offset
			// Instruction address 0x0000:0x08dc, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x08f8); // stack management - push return offset
			// Instruction address 0x0000:0x08f3, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x3);
			if (this.oCPU.Flags.NE) goto L0935;
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x090b); // stack management - push return offset
			// Instruction address 0x0000:0x0906, size: 5
			this.oParent.MSCAPI.strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), 0xd);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f9), 0xa);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f8), 0x0);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.write((short)this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680c),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, 0xba06),
				this.oCPU.AX.Word);

		L0935:
			this.oCPU.AX.Word = 0x138;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0942); // stack management - push return offset
			// Instruction address 0x0000:0x093d, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0xf;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x095e); // stack management - push return offset
			// Instruction address 0x0000:0x0959, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0975); // stack management - push return offset
			// Instruction address 0x0000:0x0970, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

		L0978:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_08a3'");
		}

		public void F9_0000_097c()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_097c'(Cdecl) at 0x0000:0x097c, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0xfa);
			if (this.oCPU.Flags.G) goto L0991;
			this.oCPU.AX.Word = 0x14;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xfa0);
			goto L09da;

		L0991:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0xfa));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x32);
			if (this.oCPU.Flags.G) goto L09a7;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x3e8);
			goto L09da;

		L09a7:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x32));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x32);
			if (this.oCPU.Flags.G) goto L09bc;
			this.oCPU.AX.Word = 0x5;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5dc);
			goto L09da;

		L09bc:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x32));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x32);
			if (this.oCPU.Flags.G) goto L09d0;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6d6);
			goto L09da;

		L09d0:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x32));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x73a);

		L09da:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_097c'");
		}

		public void F9_0000_09dc()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_09dc'(Cdecl) at 0x0000:0x09dc, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L09ed;

		L09ea:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L09ed:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0a1d;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6422);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)), 0xffff);
			if (this.oCPU.Flags.NE) goto L09ea;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0), this.oCPU.AX.Word);

		L0a1d:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_09dc'");
		}

		public void F9_0000_0a22()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0a22'(Cdecl) at 0x0000:0x0a22, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0a33;

		L0a30:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0a33:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0a5f;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6422);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0a30;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0a30;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0), this.oCPU.AX.Word);

		L0a5f:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0a22'");
		}

		public void F9_0000_0a64()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0a64'(Cdecl) at 0x0000:0x0a64, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6812, 0x3e7);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L0a76:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6422);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)), 0xffff);
			if (this.oCPU.Flags.E) goto L0ab6;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0a9c); // stack management - push return offset
			// Instruction address 0x0000:0x0a97, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6812);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0ab6;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x6812, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L0ab6:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x80);
			if (this.oCPU.Flags.L) goto L0a76;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0a64'");
		}

		public void F9_0000_0ac8()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0ac8'(Cdecl) at 0x0000:0x0ac8, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680a), 0x4);
			if (this.oCPU.Flags.NE) goto L0ada;
			goto L0c2a;

		L0ada:
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0aed); // stack management - push return offset
			// Instruction address 0x0000:0x0ae8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0b06); // stack management - push return offset
			// Instruction address 0x0000:0x0b01, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x31;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0b20); // stack management - push return offset
			// Instruction address 0x0000:0x0b1b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x31;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0b3a); // stack management - push return offset
			// Instruction address 0x0000:0x0b35, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), this.oCPU.AX.Word);
			goto L0c19;

		L0b49:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6422);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0)), 0x1);
			if (this.oCPU.Flags.NE) goto L0b5f;
			this.oCPU.AX.Word = 0x7;
			goto L0b67;

		L0b5f:
			this.oCPU.AX.Word = 0xf;
			goto L0b67;

		L0b64:
			this.oCPU.AX.Word = 0x8;

		L0b67:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0b89); // stack management - push return offset
			// Instruction address 0x0000:0x0b84, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);

		L0b8c:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))));

		L0b8f:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0c16;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0ba2); // stack management - push return offset
			// Instruction address 0x0000:0x0b9d, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0b8c;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0a64();
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6812), 0x6);
			if (this.oCPU.Flags.GE) goto L0b64;
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6422);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x200)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x100)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0bdb); // stack management - push return offset
			// Instruction address 0x0000:0x0bd6, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0beb); // stack management - push return offset
			// Instruction address 0x0000:0x0be6, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L0bf5;
			goto L0b64;

		L0bf5:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6812), 0x0);
			if (this.oCPU.Flags.NE) goto L0bff;
			goto L0b49;

		L0bff:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6422);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946));
			goto L0b67;

		L0c16:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8))));

		L0c19:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0c2a;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.AX.Word);
			goto L0b8f;

		L0c2a:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0ac8'");
		}

		public void F9_0000_0c30()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0c30'(Cdecl) at 0x0000:0x0c30, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L0d3b;

		L0c3f:
			this.oCPU.AX.Low = 0x2e;

		L0c41:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0c4b:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.GE) goto L0c68;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0c5c); // stack management - push return offset
			// Instruction address 0x0000:0x0c57, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0c3f;
			this.oCPU.AX.Low = 0x20;
			goto L0c41;

		L0c68:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0); // Segment
			goto L0cbf;

		L0c6f:
			this.oCPU.AX.Low = 0x2b;

		L0c71:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0c7d:
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x642a);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x45f9), this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x50);
			if (this.oCPU.Flags.GE) goto L0cbc;
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0)), 0x0);
			if (this.oCPU.Flags.NE) goto L0c7d;

		L0cbc:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0cbf:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.GE) goto L0d24;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0cd0); // stack management - push return offset
			// Instruction address 0x0000:0x0ccb, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0cbc;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0ce2;

		L0cdf:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0ce2:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x100);
			if (this.oCPU.Flags.GE) goto L0cbc;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6426);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x540));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.NE) goto L0cdf;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6428);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x640));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.Flags.NE) goto L0cdf;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0d15); // stack management - push return offset
			// Instruction address 0x0000:0x0d10, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0d1f;
			goto L0c6f;

		L0d1f:
			this.oCPU.AX.Low = 0x2a;
			goto L0c71;

		L0d24:
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.write((short)this.oCPU.ReadWord(this.oCPU.DS.Word, 0x680c),
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, 0xba06),
				0x52);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0d3b:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x32);
			if (this.oCPU.Flags.GE) goto L0d58;
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba56, 0xd);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba57, 0xa);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba58, 0x0);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L0c4b;

		L0d58:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0c30'");
		}

		public void F9_0000_0d5d()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0d5d'(Cdecl) at 0x0000:0x0d5d, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x280c)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1502);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0d7d); // stack management - push return offset
			// Instruction address 0x0000:0x0d78, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x280c)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14f2);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0d94); // stack management - push return offset
			// Instruction address 0x0000:0x0d8f, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.NE) goto L0dc4;
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x280c)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1502);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0db1); // stack management - push return offset
			// Instruction address 0x0000:0x0dac, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x40de;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0dc1); // stack management - push return offset
			// Instruction address 0x0000:0x0dbc, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L0dc4:
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0dd6); // stack management - push return offset
			// Instruction address 0x0000:0x0dd1, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0d5d'");
		}

		public void F9_0000_0dde()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0dde'(Cdecl) at 0x0000:0x0dde, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x680e, 0x1);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0def); // stack management - push return offset
			// Instruction address 0x0000:0x0dea, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0df4); // stack management - push return offset
			// Instruction address 0x0000:0x0def, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xb1d4, 0x0);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0dfe:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x642c);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4), 0xff);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xe);
			if (this.oCPU.Flags.L) goto L0dfe;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0e2c); // stack management - push return offset
			// Instruction address 0x0000:0x0e27, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x6);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			// Call to overlay
			F9_0000_0000();
			this.oCPU.AX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x280c)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x151a)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0e58); // stack management - push return offset
			// Instruction address 0x0000:0x0e53, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0e67;
			this.oCPU.AX.Word = 0x22;
			goto L0e6a;

		L0e67:
			this.oCPU.AX.Word = 0x7;

		L0e6a:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x20;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x11c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x96;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x12;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0e84); // stack management - push return offset
			// Instruction address 0x0000:0x0e7f, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.AX.Word = 0x40e0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0e94); // stack management - push return offset
			// Instruction address 0x0000:0x0e8f, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x14;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x98;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0eac); // stack management - push return offset
			// Instruction address 0x0000:0x0ea7, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0ebb;
			this.oCPU.AX.Word = 0x17;
			goto L0ebe;

		L0ebb:
			this.oCPU.AX.Word = 0xf;

		L0ebe:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x97;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0ed0); // stack management - push return offset
			// Instruction address 0x0000:0x0ecb, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0ee6); // stack management - push return offset
			// Instruction address 0x0000:0x0ee1, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x40f7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0ef6); // stack management - push return offset
			// Instruction address 0x0000:0x0ef1, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x14;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f0e); // stack management - push return offset
			// Instruction address 0x0000:0x0f09, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0f1d;
			this.oCPU.AX.Word = 0x17;
			goto L0f20;

		L0f1d:
			this.oCPU.AX.Word = 0xf;

		L0f20:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f32); // stack management - push return offset
			// Instruction address 0x0000:0x0f2d, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f3a); // stack management - push return offset
			// Instruction address 0x0000:0x0f35, size: 5
			this.oParent.Segment_1403.F0_1403_4545();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f3f); // stack management - push return offset
			// Instruction address 0x0000:0x0f3a, size: 5
			this.oParent.Segment_2459.F0_2459_0918();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f48); // stack management - push return offset
			// Instruction address 0x0000:0x0f43, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f62); // stack management - push return offset
			// Instruction address 0x0000:0x0f5d, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f6a); // stack management - push return offset
			// Instruction address 0x0000:0x0f65, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f6f); // stack management - push return offset
			// Instruction address 0x0000:0x0f6a, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x680e, 0x0);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0dde'");
		}

		public void F9_0000_0f79()
		{
			this.oParent.LogWriteLine("Entering function 'F9_0000_0f79'(Cdecl) at 0x0000:0x0f79, stack: 0x0");
			this.oCPU.CS.Word = 0x0000; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x36);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0f85); // stack management - push return offset
			// Instruction address 0x0000:0x0f80, size: 5
			this.oParent.Segment_1000.F0_1000_07ed();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x280c));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3938));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4107;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0fa3); // stack management - push return offset
			// Instruction address 0x0000:0x0f9e, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), this.oCPU.ADDByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb)), this.oCPU.DX.Low));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Low));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L0fd2;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x0);
			if (this.oCPU.Flags.E) goto L0fce;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x3);
			if (this.oCPU.Flags.NE) goto L0fd2;

		L0fce:
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd), 0x6b);

		L0fd2:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0fea); // stack management - push return offset
			// Instruction address 0x0000:0x0fe5, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x0ffa); // stack management - push return offset
			// Instruction address 0x0000:0x0ff5, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_0254();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x85;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x8b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x43;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xb5;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1016); // stack management - push return offset
			// Instruction address 0x0000:0x1011, size: 5
			this.oParent.Segment_1000.F0_1000_077d();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x31;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3b; // Segment
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x33;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1032); // stack management - push return offset
			// Instruction address 0x0000:0x102d, size: 5
			this.oParent.Segment_1000.F0_1000_077d();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x31;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x97; // Segment
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x104e); // stack management - push return offset
			// Instruction address 0x0000:0x1049, size: 5
			this.oParent.Segment_1000.F0_1000_077d();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1059); // stack management - push return offset
			// Instruction address 0x0000:0x1054, size: 5
			this.oParent.Segment_1000.F0_1000_07a0();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.AX.Word = 0x4112;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1066); // stack management - push return offset
			// Instruction address 0x0000:0x1061, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_0254();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L1081;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x107e); // stack management - push return offset
			// Instruction address 0x0000:0x1079, size: 5
			this.oParent.Segment_1000.F0_1000_04d4();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

		L1081:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x109e); // stack management - push return offset
			// Instruction address 0x0000:0x1099, size: 5
			this.oParent.Segment_1000.F0_1000_07fb();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.AX.Word = 0x411c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x10ae); // stack management - push return offset
			// Instruction address 0x0000:0x10a9, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L10bc;
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x21), 0x67);

		L10bc:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.AX.Word = 0x85;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x10d3); // stack management - push return offset
			// Instruction address 0x0000:0x10ce, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_01a2();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L10db:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x642c);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4)), 0xff);
			if (this.oCPU.Flags.E) goto L1155;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x2a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x31);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.AX.Word = 0x21;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = 0x22; // Segment
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x85);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1152); // stack management - push return offset
			// Instruction address 0x0000:0x114d, size: 5
			this.oParent.Segment_1000.F0_1000_07fb();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x10);

		L1155:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0xe);
			if (this.oCPU.Flags.GE) goto L1161;
			goto L10db;

		L1161:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x5a);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0x0);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x2;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x642e);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x10));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xb4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x12));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), this.oCPU.AX.Word));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6430);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x48));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x40);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4a));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), this.oCPU.AX.Word));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x11b8); // stack management - push return offset
			// Instruction address 0x0000:0x11b3, size: 5
			this.oParent.Segment_1000.F0_1000_084d();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x11d0); // stack management - push return offset
			// Instruction address 0x0000:0x11cb, size: 5
			this.oParent.Segment_1000.F0_1000_084d();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x280c)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x151a)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x11ee); // stack management - push return offset
			// Instruction address 0x0000:0x11e9, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L1254;
			this.oCPU.AX.Word = 0x4126;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x9));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1205); // stack management - push return offset
			// Instruction address 0x0000:0x1200, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0xc1d6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1215); // stack management - push return offset
			// Instruction address 0x0000:0x1210, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_0288();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0xbdee;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x412a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1225); // stack management - push return offset
			// Instruction address 0x0000:0x1220, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_0288();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0xc0);

		L122d:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x3e24));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x420c), this.oCPU.AX.Low);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x1b0);
			if (this.oCPU.Flags.L) goto L122d;
			this.oCPU.AX.Word = 0xbdee;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1251); // stack management - push return offset
			// Instruction address 0x0000:0x124c, size: 5
			this.oParent.Segment_1000.F0_1000_04aa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L1254:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0xb1d4);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x7;
			this.oCPU.IDIVByte(this.oCPU.AX, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.AX.High;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0x1);
			if (this.oCPU.Flags.E) goto L1274;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			goto L127d;

		L1274:
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

		L127d:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, 0xb1d4);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xb1d4, this.oCPU.INCByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0xb1d4)));
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x7);
			if (this.oCPU.Flags.L) goto L128f;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0x7));

		L128f:
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x642c);
			this.oCPU.WriteByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4), this.oCPU.AX.Low);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x12a3); // stack management - push return offset
			// Instruction address 0x0000:0x129e, size: 5
			this.oParent.Segment_1000.F0_1000_033e();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.AX.Word = 0x4134;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x12b0); // stack management - push return offset
			// Instruction address 0x0000:0x12ab, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_0254();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.AX.Word = 0x85;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x12ca); // stack management - push return offset
			// Instruction address 0x0000:0x12c5, size: 5
			this.oParent.Segment_2fa1.F0_2fa1_01a2();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L12d2:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x642c);
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4)), 0xff);
			if (this.oCPU.Flags.E) goto L134c;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37c4));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x2a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x31);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4));
			this.oCPU.AX.Word = 0x21;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x85);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x7;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1349); // stack management - push return offset
			// Instruction address 0x0000:0x1344, size: 5
			this.oParent.Segment_1000.F0_1000_07fb();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x10);

		L134c:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0xe);
			if (this.oCPU.Flags.GE) goto L1358;
			goto L12d2;

		L1358:
			goto L135f;

		L135a:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba06, 0x0);

		L135f:
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1364); // stack management - push return offset
			// Instruction address 0x0000:0x135f, size: 5
			this.oParent.Segment_1000.F0_1000_033a();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xf0);
			if (this.oCPU.Flags.L) goto L135a;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd80a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.abs((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1382); // stack management - push return offset
			// Instruction address 0x0000:0x137d, size: 5
			this.oParent.MSCAPI.itoa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x138f); // stack management - push return offset
			// Instruction address 0x0000:0x138a, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.GE) goto L139d;
			this.oCPU.AX.Word = 0x413e;
			goto L13a0;

		L139d:
			this.oCPU.AX.Word = 0x4142;

		L13a0:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x13aa); // stack management - push return offset
			// Instruction address 0x0000:0x13a5, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x4146;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x13ba); // stack management - push return offset
			// Instruction address 0x0000:0x13b5, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x13d0); // stack management - push return offset
			// Instruction address 0x0000:0x13cb, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x4149;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x13e0); // stack management - push return offset
			// Instruction address 0x0000:0x13db, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x14;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x98;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x13f8); // stack management - push return offset
			// Instruction address 0x0000:0x13f3, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L1407;
			this.oCPU.AX.Word = 0x17;
			goto L140a;

		L1407:
			this.oCPU.AX.Word = 0xf;

		L140a:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x97;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x141c); // stack management - push return offset
			// Instruction address 0x0000:0x1417, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = 0x4152;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x142c); // stack management - push return offset
			// Instruction address 0x0000:0x1427, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1441); // stack management - push return offset
			// Instruction address 0x0000:0x143c, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x4157;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1451); // stack management - push return offset
			// Instruction address 0x0000:0x144c, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x14;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1469); // stack management - push return offset
			// Instruction address 0x0000:0x1464, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L1478;
			this.oCPU.AX.Word = 0x17;
			goto L147b;

		L1478:
			this.oCPU.AX.Word = 0xf;

		L147b:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x148d); // stack management - push return offset
			// Instruction address 0x0000:0x1488, size: 5
			this.oParent.Segment_1182.F0_1182_00b3();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = 0x85;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4));
			this.oCPU.AX.Word = 0x43;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x85;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x14b3); // stack management - push return offset
			// Instruction address 0x0000:0x14ae, size: 5
			this.oParent.Segment_1000.F0_1000_07fb();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x14cb); // stack management - push return offset
			// Instruction address 0x0000:0x14c6, size: 5
			this.oParent.Segment_1000.F0_1000_084d();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x14d6); // stack management - push return offset
			// Instruction address 0x0000:0x14d1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x14e2); // stack management - push return offset
			// Instruction address 0x0000:0x14dd, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x3c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x14ee); // stack management - push return offset
			// Instruction address 0x0000:0x14e9, size: 5
			this.oParent.Segment_1182.F0_1182_0134();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x280c)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x151a)));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x150d); // stack management - push return offset
			// Instruction address 0x0000:0x1508, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x151d); // stack management - push return offset
			// Instruction address 0x0000:0x1518, size: 5
			this.oParent.Segment_1000.F0_1000_07b5();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.AX.Word = 0xc8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x140;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4));
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x153d); // stack management - push return offset
			// Instruction address 0x0000:0x1538, size: 5
			this.oParent.Segment_1000.F0_1000_07fb();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1548); // stack management - push return offset
			// Instruction address 0x0000:0x1543, size: 5
			this.oParent.Segment_1000.F0_1000_0846();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x0000); // stack management - push return segment
			this.oCPU.PushWord(0x1554); // stack management - push return offset
			// Instruction address 0x0000:0x154f, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x0000; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F9_0000_0f79'");
		}
	}
}
