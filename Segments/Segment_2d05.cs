using Disassembler;

namespace Civilization1
{
	public class Segment_2d05
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_2d05(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_2d05_0000()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_0000'(Cdecl, Far) at 0x2d05:0x0000");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0013); // stack management - push return offset
			// Instruction address 0x2d05:0x0010, size: 3
			F0_2d05_0031();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_0000'");
		}

		public void F0_2d05_0018()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_0018'(Cdecl, Far) at 0x2d05:0x0018");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x002c); // stack management - push return offset
			// Instruction address 0x2d05:0x0029, size: 3
			F0_2d05_0031();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_0018'");
		}

		public void F0_2d05_0031()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_0031'(Cdecl, Far) at 0x2d05:0x0031");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)), 0x0);
			if (this.oCPU.Flags.E) goto L0043;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0043); // stack management - push return offset
			// Instruction address 0x2d05:0x003e, size: 5
			this.oParent.Segment_1403.F0_1403_4545();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

		L0043:
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa2, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9c, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x1a3c), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x8066), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd206), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L006f;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L006f:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9a), 0xffff);
			if (this.oCPU.Flags.E) goto L0081;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9a);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L0081:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xb1ec, 0xffff);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd2e2, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0099); // stack management - push return offset
			// Instruction address 0x2d05:0x0094, size: 5
			this.oParent.Segment_1000.F0_1000_07c3();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa4, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.NE) goto L00a8;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa4, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4)));

		L00a8:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x3936), 0xffff);
			if (this.oCPU.Flags.E) goto L00b5;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa4, 0x8);

		L00b5:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x7);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x16);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x8b);
			if (this.oCPU.Flags.NE) goto L00cb;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x8);

		L00cb:
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x1);
			if (this.oCPU.Flags.E) goto L00f1;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x8b);
			if (this.oCPU.Flags.E) goto L00f1;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00e6); // stack management - push return offset
			// Instruction address 0x2d05:0x00e1, size: 5
			this.oParent.Segment_1000.F0_1000_07d1();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L00f1:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xf);
			if (this.oCPU.Flags.NE) goto L00fc;
			this.oCPU.AX.Word = 0x3;
			goto L00ff;

		L00fc:
			this.oCPU.AX.Word = 0xf;

		L00ff:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x654c, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L010e;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L010e:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0121); // stack management - push return offset
			// Instruction address 0x2d05:0x011c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9a));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0132); // stack management - push return offset
			// Instruction address 0x2d05:0x012f, size: 3
			F0_2d05_0475();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x013a); // stack management - push return offset
			// Instruction address 0x2d05:0x0135, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdb38), 0x0);
			if (this.oCPU.Flags.E) goto L014d;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xdb38, 0x0);
			this.oCPU.AX.Word = 0xffff;
			goto L0470;

		L014d:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x3936), 0xffff);
			if (this.oCPU.Flags.E) goto L0159;
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0159); // stack management - push return offset
			this.oParent.Overlay_6.F6_0000_1b33();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

		L0159:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd2e2, 0x0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xdb3a, 0x0);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x016a); // stack management - push return offset
			// Instruction address 0x2d05:0x0165, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdb3a), 0x0);
			if (this.oCPU.Flags.NE) goto L0177;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.E) goto L01db;

		L0177:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa2, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdb3a), 0x2);
			if (this.oCPU.Flags.NE) goto L018a;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9c, this.oCPU.AX.Word);

		L018a:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdb3e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb1ec));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdb3c);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L01b2;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xde0e);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdb3c), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L01b7;

		L01b2:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);

		L01b7:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb276));
			if (this.oCPU.Flags.E) goto L01cd;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

		L01c8:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			goto L0217;

		L01cd:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdb3a), 0x0);

		L01d2:
			if (this.oCPU.Flags.NE) goto L0217;

		L01d4:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			goto L0217;

		L01db:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01e0); // stack management - push return offset
			// Instruction address 0x2d05:0x01db, size: 5
			this.oParent.MSCAPI.kbhit();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0217;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01e8); // stack management - push return offset
			// Instruction address 0x2d05:0x01e5, size: 3
			F0_2d05_0ac9();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x20);
			if (this.oCPU.Flags.NE) goto L01f3;
			goto L0377;

		L01f3:
			if (this.oCPU.Flags.LE) goto L01f8;
			goto L03e3;

		L01f8:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xd);
			if (this.oCPU.Flags.NE) goto L0200;
			goto L0377;

		L0200:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1b);
			if (this.oCPU.Flags.NE) goto L0208;
			goto L0392;

		L0208:
			goto L03fd;

		L020b:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd208);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0217;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0217:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.L) goto L0233;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd208);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0233;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x8066), 0x0);
			if (this.oCPU.Flags.NE) goto L0233;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd206), 0x0);
			if (this.oCPU.Flags.E) goto L0238;

		L0233:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);

		L0238:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0243;
			goto L0337;

		L0243:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0248); // stack management - push return offset
			// Instruction address 0x2d05:0x0243, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xffff);
			if (this.oCPU.Flags.E) goto L02ba;

			// Instruction address 0x2d05:0x027c, size: 5
			this.oParent.VGA.F0_VGA_009a_ReplaceColor(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)) + 3),
				(ushort)((((this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4)) + this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa))) + 4),
				(ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4c8) + 5),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				11, (byte)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.E) goto L02ba;

			// Instruction address 0x2d05:0x02b2, size: 5
			this.oParent.VGA.F0_VGA_009a_ReplaceColor(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)) + 3),
				(ushort)((((this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4)) + this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa))) + 4),
				(ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4c8) + 5),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				3, (byte)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

		L02ba:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.E) goto L032c;

			// Instruction address 0x2d05:0x02ee, size: 5
			this.oParent.VGA.F0_VGA_009a_ReplaceColor(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)) + 3),
				(ushort)((((this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4)) + this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa))) + 4),
				(ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4c8) + 5),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				(byte)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				11);
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.E) goto L032c;

			// Instruction address 0x2d05:0x0324, size: 5
			this.oParent.VGA.F0_VGA_009a_ReplaceColor(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)) + 3),
				(ushort)((((this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4)) + this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa))) + 4),
				(ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4c8) + 5),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				(byte)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				3);
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

		L032c:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0337); // stack management - push return offset
			// Instruction address 0x2d05:0x0332, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

		L0337:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L0340;
			goto L014d;

		L0340:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0349;
			goto L0450;

		L0349:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x034e); // stack management - push return offset
			// Instruction address 0x2d05:0x0349, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0358;
			goto L043d;

		L0358:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9c), 0x0);
			if (this.oCPU.Flags.NE) goto L0362;
			goto L0406;

		L0362:
			this.oCPU.AX.Word = 0xb;
			goto L0409;

		L0368:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.G) goto L0371;
			goto L0217;

		L0371:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			goto L0217;

		L0377:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb276));
			goto L01d2;

		L0386:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9c, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			goto L0217;

		L0392:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);
			goto L01d4;

		L039a:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x19c0, this.oCPU.XORByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x19c0), 0x10));
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.DS.Word, 0x19c0), 0x10);
			if (this.oCPU.Flags.E) goto L03a9;
			goto L0217;

		L03a9:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03b2); // stack management - push return offset
			// Instruction address 0x2d05:0x03ad, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			goto L0217;

		L03b8:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L03bb:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x20);
			if (this.oCPU.Flags.L) goto L03c4;
			goto L0217;

		L03c4:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x23b6)), 0xff);
			if (this.oCPU.Flags.E) goto L03b8;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x23b6));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x1f);
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CX.Low = this.oCPU.ANDByte(this.oCPU.CX.Low, 0x1f);
			this.oCPU.CMPByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			if (this.oCPU.Flags.NE) goto L03b8;
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			goto L01c8;

		L03e3:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2300);
			if (this.oCPU.Flags.E) goto L0386;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2f00);
			if (this.oCPU.Flags.E) goto L039a;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.NE) goto L03f5;
			goto L0368;

		L03f5:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.NE) goto L03fd;
			goto L020b;

		L03fd:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			goto L03bb;

		L0406:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x654c);

		L0409:
			// Instruction address 0x2d05:0x0435, size: 5
			this.oParent.VGA.F0_VGA_009a_ReplaceColor(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)) + 3),
				(ushort)((((this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb1ec)) *
					this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4)) + this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa))) + 4),
				(ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4c8) + 5),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				11,
				this.oCPU.AX.Low);
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

		L043d:
			this.oCPU.AX.Word = 0x14;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0446); // stack management - push return offset
			// Instruction address 0x2d05:0x0441, size: 5
			this.oParent.Segment_1182.F0_1182_0134();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x044e); // stack management - push return offset
			// Instruction address 0x2d05:0x0449, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			goto L0456;

		L0450:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9c, 0x0);

		L0456:
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa0, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd206, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xb276, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd7f2, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

		L0470:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_0031'");
		}

		public void F0_2d05_0475()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_0475'(Cdecl, Far) at 0x2d05:0x0475");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x5c);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x654e, 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd2e2), 0x1);
			if (this.oCPU.Flags.E) goto L048d;
			goto L07df;

		L048d:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0499); // stack management - push return offset
			// Instruction address 0x2d05:0x0494, size: 5
			this.oParent.Segment_1000.F0_1000_07c3();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa4, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.NE) goto L04a8;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa4, this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4)));

		L04a8:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x3936), 0xffff);
			if (this.oCPU.Flags.E) goto L04b5;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x2fa4, 0x8);

		L04b5:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), 0x0);

		L04ba:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x23b6), 0xff);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x20);
			if (this.oCPU.Flags.L) goto L04ba;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x658e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd4c8, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.AX.Word);
			goto L053b;

		L04de:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x0);
			if (this.oCPU.Flags.NE) goto L051c;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L04f7;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5f);
			if (this.oCPU.Flags.NE) goto L051c;

		L04f7:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x20);
			if (this.oCPU.Flags.GE) goto L050c;
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x1));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x23b6), this.oCPU.AX.Low);

		L050c:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb1ec), 0xffff);
			if (this.oCPU.Flags.NE) goto L0519;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x658e);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xb1ec, this.oCPU.AX.Word);

		L0519:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))));

		L051c:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0532); // stack management - push return offset
			// Instruction address 0x2d05:0x052d, size: 5
			this.oParent.Segment_1000.F0_1000_078b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), this.oCPU.AX.Word));

		L0538:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56))));

		L053b:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0543); // stack management - push return offset
			// Instruction address 0x2d05:0x053e, size: 5
			this.oParent.MSCAPI.strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)));
			if (this.oCPU.Flags.LE) goto L057d;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word)), 0xa);
			if (this.oCPU.Flags.NE) goto L04de;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4c8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0564;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd4c8, this.oCPU.AX.Word);

		L0564:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0x0);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x658e, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x658e)));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x658e);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x654e), this.oCPU.AX.Word);
			goto L0538;

		L057d:
			this.oCPU.AX.Word = 0xc0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x658e));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0597); // stack management - push return offset
			// Instruction address 0x2d05:0x0592, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x658e, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd4c8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xde0e, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x658e);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa0), 0x0);
			if (this.oCPU.Flags.E) goto L05c5;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x2));

		L05c5:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05cd); // stack management - push return offset
			// Instruction address 0x2d05:0x05c8, size: 5
			this.oParent.MSCAPI.strlen();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x1)), 0xa);
			if (this.oCPU.Flags.E) goto L05de;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))));

		L05de:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd208, this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0x1);
			if (this.oCPU.Flags.E) goto L05ed;
			goto L075b;

		L05ed:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9e), 0xffff);
			if (this.oCPU.Flags.NE) goto L0613;
			this.oCPU.AX.Word = 0x7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xde0e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0610); // stack management - push return offset
			// Instruction address 0x2d05:0x060d, size: 3
			F0_2d05_096c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			goto L0758;

		L0613:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9e);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2fa6)));
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0626); // stack management - push return offset
			// Instruction address 0x2d05:0x0621, size: 5
			this.oParent.MSCAPI.strcpy();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9e), 0x2);
			if (this.oCPU.Flags.G) goto L0640;
			this.oCPU.AX.Word = 0x2fb4;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x063d); // stack management - push return offset
			// Instruction address 0x2d05:0x0638, size: 5
			this.oParent.MSCAPI.strcat();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L0640:
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0649); // stack management - push return offset
			// Instruction address 0x2d05:0x0644, size: 5
			this.oParent.Segment_1182.F0_1182_00ef();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x8);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xde0e), this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L0661;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xde0e, this.oCPU.SI.Word);

		L0661:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = 0x7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3e7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3d;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.SI.Word + 0x8));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x067c); // stack management - push return offset
			// Instruction address 0x2d05:0x0677, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xde0e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x2a);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x2a);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x069c); // stack management - push return offset
			// Instruction address 0x2d05:0x0699, size: 3
			F0_2d05_096c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.SI.Word - 0x34);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9e), 0x2);
			if (this.oCPU.Flags.G) goto L06d2;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9e);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x209e)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x28);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06cd); // stack management - push return offset
			// Instruction address 0x2d05:0x06c8, size: 5
			this.oParent.Segment_1000.F0_1000_084d();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			goto L0715;

		L06d2:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), 0x0);
			if (this.oCPU.Flags.LE) goto L06de;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			goto L06e0;

		L06de:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

		L06e0:
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x28);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.AX.Word = 0x3c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x28;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x8c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x28;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f9e));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x28);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19e8));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0712); // stack management - push return offset
			// Instruction address 0x2d05:0x070d, size: 5
			this.oParent.Segment_1000.F0_1000_07fb();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x10);

		L0715:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x5);
			this.oCPU.AX.Word = 0xf;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0730); // stack management - push return offset
			// Instruction address 0x2d05:0x072b, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x3);
			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x50));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0747); // stack management - push return offset
			// Instruction address 0x2d05:0x0742, size: 5
			this.oParent.Segment_1182.F0_1182_00ef();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0758); // stack management - push return offset
			// Instruction address 0x2d05:0x0753, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment

		L0758:
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);

		L075b:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa0), 0x0);
			if (this.oCPU.Flags.E) goto L0799;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x2);
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xde0e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x4a);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x2fbd;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x078c); // stack management - push return offset
			// Instruction address 0x2d05:0x0787, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), this.oCPU.AX.Word);

		L0799:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x8066), 0x0);
			if (this.oCPU.Flags.E) goto L07df;
			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xde0e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x11);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x2fce;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07bb); // stack management - push return offset
			// Instruction address 0x2d05:0x07b6, size: 5
			this.oParent.Segment_1182.F0_1182_002a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x14;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xde0e);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x14);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07dc); // stack management - push return offset
			// Instruction address 0x2d05:0x07d9, size: 3
			F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);

		L07df:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x20);
			if (this.oCPU.Flags.E) goto L07ec;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x5f);
			if (this.oCPU.Flags.NE) goto L07f0;

		L07ec:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			goto L07f3;

		L07f0:
			this.oCPU.AX.Word = 0xffff;

		L07f3:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x654c);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), 0x0);
			goto L08fd;

		L0808:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb276));
			if (this.oCPU.Flags.E) goto L081b;
			this.oCPU.AX.Word = 0x3;
			goto L081d;

		L081b:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

		L081d:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0839); // stack management - push return offset
			// Instruction address 0x2d05:0x0834, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x654e));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x20);
			goto L08ce;

		L0849:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.GE) goto L0883;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4), 0x9);
			if (this.oCPU.Flags.LE) goto L0883;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x654e));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0880); // stack management - push return offset
			// Instruction address 0x2d05:0x087b, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

		L0883:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.GE) goto L088e;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x654c);
			goto L08a3;

		L088e:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb276));
			if (this.oCPU.Flags.E) goto L08a1;
			this.oCPU.AX.Word = 0x3;
			goto L08a3;

		L08a1:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);

		L08a3:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2fa4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x654e));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08cb); // stack management - push return offset
			// Instruction address 0x2d05:0x08c6, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

		L08ce:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6550));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x1), 0xa);

		L08de:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6550));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L08f7;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x5f);
			if (this.oCPU.Flags.NE) goto L08fa;

		L08f7:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))));

		L08fa:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56))));

		L08fd:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x658e);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0963;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd2e2), 0x0);
			if (this.oCPU.Flags.NE) goto L0920;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0918); // stack management - push return offset
			// Instruction address 0x2d05:0x0913, size: 5
			this.oParent.MSCAPI.abs();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.GE) goto L08de;

		L0920:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x6550));
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x1), 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.GE) goto L0939;
			goto L0849;

		L0939:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7f2));
			if (this.oCPU.Flags.NE) goto L094a;
			goto L0849;

		L094a:
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x654e));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.DI.Word, 0x5e);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x0);
			if (this.oCPU.Flags.L) goto L095d;
			goto L0808;

		L095d:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x654c);
			goto L081d;

		L0963:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_0475'");
		}

		public void F0_2d05_096c()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_096c'(Cdecl, Far) at 0x2d05:0x096c");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)), 0x7);
			if (this.oCPU.Flags.NE) goto L0996;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x2f98), 0x0);
			if (this.oCPU.Flags.E) goto L0996;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0991); // stack management - push return offset
			// Instruction address 0x2d05:0x098c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_03ce();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			goto L09b9;

		L0996:
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x09b6); // stack management - push return offset
			// Instruction address 0x2d05:0x09b1, size: 5
			this.oParent.Segment_1182.F0_1182_0148();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);

		L09b9:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe), 0xf);
			this.oCPU.AX.Word = 0x8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xf;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x09e4); // stack management - push return offset
			// Instruction address 0x2d05:0x09e1, size: 3
			F0_2d05_0a66();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a00); // stack management - push return offset
			// Instruction address 0x2d05:0x09fd, size: 3
			F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_096c'");
		}

		public void F0_2d05_0a05()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_0a05'(Cdecl, Far) at 0x2d05:0x0a05");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a22); // stack management - push return offset
			// Instruction address 0x2d05:0x0a1d, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a39); // stack management - push return offset
			// Instruction address 0x2d05:0x0a34, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a4a); // stack management - push return offset
			// Instruction address 0x2d05:0x0a45, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a5f); // stack management - push return offset
			// Instruction address 0x2d05:0x0a5a, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_0a05'");
		}

		public void F0_2d05_0a66()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_0a66'(Cdecl, Far) at 0x2d05:0x0a66");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a83); // stack management - push return offset
			// Instruction address 0x2d05:0x0a7e, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a9a); // stack management - push return offset
			// Instruction address 0x2d05:0x0a95, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x10)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0aab); // stack management - push return offset
			// Instruction address 0x2d05:0x0aa6, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0ac2); // stack management - push return offset
			// Instruction address 0x2d05:0x0abd, size: 5
			this.oParent.Segment_1182.F0_1182_000a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_0a66'");
		}

		public void F0_2d05_0ac9()
		{
			this.oCPU.Log.EnterBlock("'F0_2d05_0ac9'(Cdecl, Far) at 0x2d05:0x0ac9");
			this.oCPU.CS.Word = 0x2d05; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0ad4); // stack management - push return offset
			// Instruction address 0x2d05:0x0acf, size: 5
			this.oParent.Segment_1000.F0_1000_09ec();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2d05; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b34);
			if (this.oCPU.Flags.NE) goto L0adf;
			goto L0b6b;

		L0adf:
			if (this.oCPU.Flags.LE) goto L0ae4;
			goto L0ba2;

		L0ae4:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800); // Up
			if (this.oCPU.Flags.E) goto L0b05;
			if (this.oCPU.Flags.LE) goto L0aee;
			goto L0b79;

		L0aee:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xf400);
			if (this.oCPU.Flags.E) goto L0b17;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4700); // Home
			if (this.oCPU.Flags.E) goto L0b3a;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4737); // shift + Home
			if (this.oCPU.Flags.E) goto L0b72;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x475c);
			if (this.oCPU.Flags.E) goto L0b3a;
			goto L0b92;

		L0b05:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4800); // Up

		L0b0a:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			goto L0bf6;

		L0b10:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4900); // Page Up
			goto L0b0a;

		L0b17:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4d00); // Right
			goto L0b0a;

		L0b1e:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x5100); // Page Down
			goto L0b0a;

		L0b25:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x5000); // Down
			goto L0b0a;

		L0b2c:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4f00); // End
			goto L0b0a;

		L0b33:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4b00); // Left
			goto L0b0a;

		L0b3a:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4700); // Home
			goto L0b0a;

		L0b41:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4838); // Shift + Up
			goto L0b0a;

		L0b48:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4939); // Shift + Page Up
			goto L0b0a;

		L0b4f:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4d36); // Shift + Right
			goto L0b0a;

		L0b56:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x5133); // Shift + Page Down
			goto L0b0a;

		L0b5d:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x5032); // Shift + Down
			goto L0b0a;

		L0b64:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4f31); // Shift + End
			goto L0b0a;

		L0b6b:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4b34); // Shift + Left
			goto L0b0a;

		L0b72:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4737); // Shift + Home
			goto L0b0a;

		L0b79:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4838); // Shift + Up
			if (this.oCPU.Flags.E) goto L0b41;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x487e);
			if (this.oCPU.Flags.E) goto L0b05;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4900); // Page Up
			if (this.oCPU.Flags.E) goto L0b10;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4939); // Shift + Page Up
			if (this.oCPU.Flags.E) goto L0b48;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b00); // Left
			if (this.oCPU.Flags.E) goto L0b33;

		L0b92:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0b9b;
			goto L0b0a;

		L0b9b:
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1), 0x0);
			goto L0b0a;

		L0ba2:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4f00); // End
			if (this.oCPU.Flags.E) goto L0b2c;
			if (this.oCPU.Flags.G) goto L0bca;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b43);
			if (this.oCPU.Flags.E) goto L0b6b;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b7c);
			if (this.oCPU.Flags.NE) goto L0bb6;
			goto L0b33;

		L0bb6:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d00); // Right
			if (this.oCPU.Flags.NE) goto L0bbe;
			goto L0b17;

		L0bbe:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d36); // Shift + Right
			if (this.oCPU.Flags.E) goto L0b4f;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d46);
			if (this.oCPU.Flags.E) goto L0b4f;
			goto L0b92;

		L0bca:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4f31); // Shift + End
			if (this.oCPU.Flags.E) goto L0b64;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000); // Down
			if (this.oCPU.Flags.NE) goto L0bd7;
			goto L0b25;

		L0bd7:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5032); // Shift + Down
			if (this.oCPU.Flags.E) goto L0b5d;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5060);
			if (this.oCPU.Flags.NE) goto L0be4;
			goto L0b25;

		L0be4:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5100); // Page Down
			if (this.oCPU.Flags.NE) goto L0bec;
			goto L0b1e;

		L0bec:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5133); // Shift + Page Down
			if (this.oCPU.Flags.NE) goto L0bf4;
			goto L0b56;

		L0bf4:
			goto L0b92;

		L0bf6:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2d05_0ac9'");
		}
	}
}
