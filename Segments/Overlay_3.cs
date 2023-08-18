using Disassembler;
using System;

namespace OpenCiv1
{
	public class Overlay_3
	{
		private OpenCiv1 oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

		public Overlay_3(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F3_0000_0000()
		{
			this.oCPU.Log.EnterBlock("'F3_0000_0000'(Cdecl, Far) at 0x0000:0x0000");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L000b:
			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37d2), 0xffff);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x6);
			if (this.oCPU.Flags.L) goto L000b;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F3_0000_0000'");
		}

		public void F3_0000_002b()
		{
			this.oCPU.Log.EnterBlock("'F3_0000_002b'(Cdecl, Far) at 0x0000:0x002b");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0035); // stack management - push return offset
			F3_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			// Instruction address 0x0000:0x0041, size: 5
			this.oParent.MSCAPI.open(0x33ac, 0x8102, 0x80);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0057, size: 5
			this.oParent.MSCAPI.read((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xba06, 0x114);

			this.oParent.MSCAPI.movedata(
				this.oCPU.DS.Word,
				0xba06,
				0x3772,
				0x37d2,
				0x114);

			// Instruction address 0x0000:0x007a, size: 5
			this.oParent.MSCAPI.close((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F3_0000_002b'");
		}

		public void F3_0000_0083()
		{
			this.oCPU.Log.EnterBlock("'F3_0000_0083'(Cdecl, Far) at 0x0000:0x0083");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x0095, size: 5
			this.oParent.MSCAPI.open(0x33b5, 0x8302, 0x80);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oParent.MSCAPI.movedata(
				0x3772,
				0x37d2,
				this.oCPU.DS.Word,
				0xba06,
				0x114);

			// Instruction address 0x0000:0x00c3, size: 5
			this.oParent.MSCAPI.write((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				0xba06, 0x114);
			
			// Instruction address 0x0000:0x00ce, size: 5
			this.oParent.MSCAPI.close((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F3_0000_0083'");
		}

		public void F3_0000_00d7()
		{
			this.oCPU.Log.EnterBlock("'F3_0000_00d7'(Cdecl, Far) at 0x0000:0x00d7");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1c);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x00f3, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 15);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x010f); // stack management - push return offset
			// Instruction address 0x0000:0x010a, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0x33be, 0xa0, 0x10, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0126); // stack management - push return offset
			// Instruction address 0x0000:0x0121, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0x33cb, 0xa0, 0x18, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			// Instruction address 0x0000:0x013d, size: 5
			this.oParent.VGADriver.F0_VGA_0599_DrawLine(
				new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa))),
				(short)0x50,
				(short)0x20,
				(short)0xf0,
				(short)0x20,
				0xe);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x28);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0160;

		L0151:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x5);
			if (this.oCPU.Flags.NE) goto L01d1;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x4);
			if (this.oCPU.Flags.NE) goto L01d1;

		L015d:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0160:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x6);
			if (this.oCPU.Flags.GE) goto L0174;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0151;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x5);
			if (this.oCPU.Flags.NE) goto L0151;

		L0174:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0xffff);
			if (this.oCPU.Flags.E) goto L01ad;
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xbd;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xfc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x346a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x018e); // stack management - push return offset
			// Instruction address 0x0000:0x0189, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3c;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xbb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xec;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01aa); // stack management - push return offset
			// Instruction address 0x0000:0x01a5, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);

		L01ad:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01b2); // stack management - push return offset
			// Instruction address 0x0000:0x01ad, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0xffff);
			if (this.oCPU.Flags.NE) goto L01be;
			goto L050b;

		L01be:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x63);
			if (this.oCPU.Flags.E) goto L01cb;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x43);
			if (this.oCPU.Flags.E) goto L01cb;
			goto L050b;

		L01cb:
			this.oCPU.AX.Word = 0x1;
			goto L050d;

		L01d1:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x8);
			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x37d2));
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x1c), this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.G) goto L0220;

			// Instruction address 0x0000:0x01fb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_33d8);

			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.AX.Word = 0x8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0216); // stack management - push return offset
			// Instruction address 0x0000:0x0211, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1a));
			goto L015d;

		L0220:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x023f, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) + 1), 10));

			// Instruction address 0x0000:0x024f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_33dd);

			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.MSCAPI.movedata(
				0x3772,
				(ushort)(this.oCPU.SI.Word + 0x37e0),
				this.oCPU.DS.Word,
				(ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06)),
				16);

			// Instruction address 0x0000:0x028c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_33e0);

			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x02a7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x33a2)));

			// Instruction address 0x0000:0x02b7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_33e3);

			this.oParent.MSCAPI.movedata(
				0x3772,
				(ushort)(this.oCPU.SI.Word + 0x37f0),
				this.oCPU.DS.Word,
				(ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06)),
				16);

			// Instruction address 0x0000:0x02e8, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x02fb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_33ec);

			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			// Instruction address 0x0000:0x032a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(Math.Abs((short)this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d8))), 10));

			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d8)), 0x0);
			if (this.oCPU.Flags.GE) goto L0343;
			this.oCPU.AX.Word = 0x33f1;
			goto L0346;

		L0343:
			this.oCPU.AX.Word = 0x33f6;

		L0346:
			// Instruction address 0x0000:0x034b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x035c); // stack management - push return offset
			// Instruction address 0x0000:0x0357, size: 5
			this.oParent.Segment_1182.F0_1182_00ef_GetStringWidth(0xba06);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x140);
			if (this.oCPU.Flags.L) goto L036f;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), 0x0);

		L036f:
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0381); // stack management - push return offset
			// Instruction address 0x0000:0x037c, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8));

			// Instruction address 0x0000:0x0390, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_33fb);

			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37de)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03ae); // stack management - push return offset
			// Instruction address 0x0000:0x03a9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0337();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x03b9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3408);

			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			// Instruction address 0x0000:0x03df, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d2)), 10));

			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d4));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0416;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L03fc;
			goto L04f3;

		L03fc:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L0404;
			goto L04f9;

		L0404:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L040c;
			goto L04ff;

		L040c:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.NE) goto L0414;
			goto L0505;

		L0414:
			goto L0426;

		L0416:
			this.oCPU.AX.Word = 0x3412;

		L0419:
			// Instruction address 0x0000:0x041e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

		L0426:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0xc);
			this.oCPU.AX.Word = 0x7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x043d); // stack management - push return offset
			// Instruction address 0x0000:0x0438, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8));

			// Instruction address 0x0000:0x044c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3446);

			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			
			// Instruction address 0x0000:0x0487, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((((short)this.oCPU.ReadWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc),
					(ushort)(this.oCPU.DI.Word + 0x37d4)) + 1) *
					(short)this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.DI.Word + 0x37d2))) / 0x32), 10));

			// Instruction address 0x0000:0x0497, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3464);

			this.oCPU.AX.Word = 0xc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04b0); // stack management - push return offset
			// Instruction address 0x0000:0x04ab, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04c6;
			goto L015d;

		L04c6:
			// Instruction address 0x0000:0x04e8, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 4),
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) - 28),
				296, 26, 15, 14);

			goto L015d;

		L04f3:
			this.oCPU.AX.Word = 0x341e;
			goto L0419;

		L04f9:
			this.oCPU.AX.Word = 0x3429;
			goto L0419;

		L04ff:
			this.oCPU.AX.Word = 0x3433;
			goto L0419;

		L0505:
			this.oCPU.AX.Word = 0x343b;
			goto L0419;

		L050b:
			this.oCPU.AX.Word = 0;

		L050d:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F3_0000_00d7'");
		}

		public void F3_0000_0513()
		{
			this.oCPU.Log.EnterBlock("'F3_0000_0513'(Cdecl, Far) at 0x0000:0x0513");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xe);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L051f:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L061a;

		L0527:
			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x37d2);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x3772);
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x37a4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x3772);

			// Instruction address 0x0000:0x0557, size: 5
			this.oParent.MSCAPI.movedata(
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				0x2e);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0562:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0527;
			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb77e);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d2), this.oCPU.AX.Word);
			
			this.oParent.MSCAPI.movedata(
				this.oCPU.DS.Word,
				this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee) << 1) + 0x19a2)),
				0x3772,
				(ushort)(this.oCPU.SI.Word + 0x37e0),
				0xe);

			this.oParent.MSCAPI.movedata(
				this.oCPU.DS.Word,
				this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee) << 1) + 0x1992)),
				0x3772,
				(ushort)(this.oCPU.SI.Word + 0x37f0),
				0x10);

			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b86);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xdc6a);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd764);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37da), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd766);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37dc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb220);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d8), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xd7ee));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05f1); // stack management - push return offset
			// Instruction address 0x0000:0x05ec, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_02cd();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.WriteWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37de), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0604); // stack management - push return offset
			F3_0000_00d7();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0612;

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x060f); // stack management - push return offset
			F3_0000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			goto L051f;

		L0612:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			goto L0658;

		L0617:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L061a:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x6);
			if (this.oCPU.Flags.GE) goto L0655;
			this.oCPU.AX.Word = 0x2e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.ES.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x63fc);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d4));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x37d2)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b86);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, 0xb77e));
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L064d;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x5);
			if (this.oCPU.Flags.NE) goto L0617;

		L064d:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x5);
			goto L0562;

		L0655:
			this.oCPU.AX.Word = 0xffff;

		L0658:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F3_0000_0513'");
		}

		public void F3_0000_065d()
		{
			this.oCPU.Log.EnterBlock("'F3_0000_065d'(Cdecl, Far) at 0x0000:0x065d");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L06a6;
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b86);
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x32;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), 0xffff);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L0686:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			if (this.oCPU.Flags.GE) goto L069d;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.AX.Word);

		L069d:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x14);
			if (this.oCPU.Flags.LE) goto L0686;

		L06a6:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x0);
			if (this.oCPU.Flags.GE) goto L06af;
			goto L09a8;

		L06af:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x13);
			if (this.oCPU.Flags.LE) goto L06ba;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), 0x13);

		L06ba:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06bf); // stack management - push return offset
			// Instruction address 0x0000:0x06ba, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			this.oCPU.AX.Word = 0x22;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06cd); // stack management - push return offset
			// Instruction address 0x0000:0x06c8, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x06e4, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 15);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06f1); // stack management - push return offset
			// Instruction address 0x0000:0x06ec, size: 5
			this.oParent.Segment_1866.F0_1866_260e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			// Instruction address 0x0000:0x070e, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19e8),
				0xc8, 0x8c, 0x28, 0x3c,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				10, 10);

			// Instruction address 0x0000:0x0736, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19e8),
				0xf0, 0x8c, 0x28, 0x3c,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0x10e, 10);

			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x7);
			this.oCPU.AX.Word = 0x1b;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x075c); // stack management - push return offset
			// Instruction address 0x0000:0x0757, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_03ce();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = 0x8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x9f;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x077c); // stack management - push return offset
			// Instruction address 0x0000:0x0777, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a66();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L0788;
			goto L0814;

		L0788:
			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x1f4,
				this.oCPU.DS.Word,
				0xba06,
				0x20);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07b5); // stack management - push return offset
			// Instruction address 0x0000:0x07b0, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 6, 0xf);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x20d,
				this.oCPU.DS.Word,
				0xba06,
				0x20);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07e5); // stack management - push return offset
			// Instruction address 0x0000:0x07e0, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xe, 0xf);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.MSCAPI.movedata(
				(ushort)((0x13 - this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))) * 0x19),
				0x36d4,
				this.oCPU.DS.Word,
				0xba06,
				0x20);

			this.oCPU.AX.Word = 0x3471;
			goto L08cd;

		L0814:
			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x226,
				this.oCPU.DS.Word,
				0xba06,
				0x20);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0841); // stack management - push return offset
			// Instruction address 0x0000:0x083c, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 6, 0xf);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.MSCAPI.movedata(
				0x36d4,
				0x23f,
				this.oCPU.DS.Word,
				0xba06,
				0x20);

			// Instruction address 0x0000:0x0874, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 10));

			// Instruction address 0x0000:0x0884, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3473);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08a1); // stack management - push return offset
			// Instruction address 0x0000:0x089c, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xe, 0xf);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.MSCAPI.movedata(
				0x36d4,
				(ushort)((0x13 - this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))) * 0x19),
				this.oCPU.DS.Word,
				0xba06,
				0x20);

			this.oCPU.AX.Word = 0x3482;

		L08cd:
			// Instruction address 0x0000:0x08d2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08ef); // stack management - push return offset
			// Instruction address 0x0000:0x08ea, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0x16, 0xf);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L091d;

		L08f9:
			this.oCPU.AX.Word = 0x7;

		L08fc:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0917); // stack management - push return offset
			// Instruction address 0x0000:0x0912, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0,
				(ushort)(-((this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 3) - 0xb8)),
				this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L091d:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0957;

			this.oParent.MSCAPI.movedata(
				0x36d4,
				(ushort)((0x13 - this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))) * 0x19),
				this.oCPU.DS.Word,
				0xba06,
				0x20);

			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L08f9;
			this.oCPU.AX.Word = 0;
			goto L08fc;

		L0957:
			// Instruction address 0x0000:0x097c, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa), 80,
				(ushort)(183 - (this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 6)) << 3)),
				160, 8, 15, 14);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0989); // stack management - push return offset
			// Instruction address 0x0000:0x0984, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0992); // stack management - push return offset
			// Instruction address 0x0000:0x098d, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x09a8); // stack management - push return offset
			// Instruction address 0x0000:0x09a3, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

		L09a8:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F3_0000_065d'");
		}

		public void F3_0000_09ac()
		{
			this.oCPU.Log.EnterBlock("'F3_0000_09ac'(Cdecl, Far) at 0x0000:0x09ac");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x20);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);

		L09b9:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x5);
			if (this.oCPU.Flags.L) goto L09b9;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			goto L0a0c;

		L09d9:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x20));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x10));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))));

		L09ef:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L09d9;
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x10), this.oCPU.AX.Word);

		L0a09:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

		L0a0c:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x80);
			if (this.oCPU.Flags.GE) goto L0a8e;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x70f2)), 0xff);
			if (this.oCPU.Flags.E) goto L0a09;
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a2e); // stack management - push return offset
			// Instruction address 0x0000:0x0a29, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x70f3));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x70e2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x70e4));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x1);

		L0a4e:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6ea8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0a60;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xa));

		L0a60:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x15);
			if (this.oCPU.Flags.LE) goto L0a4e;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0a73;

		L0a70:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0a73:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x5);
			if (this.oCPU.Flags.GE) goto L0a09;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0a70;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x3);
			goto L09ef;

		L0a8e:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0a93); // stack management - push return offset
			// Instruction address 0x0000:0x0a8e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x0aac, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 3);

			this.oCPU.AX.Word = 0xf;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3486;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0ac9); // stack management - push return offset
			// Instruction address 0x0000:0x0ac4, size: 5
			this.oParent.Segment_1182.F0_1182_0086();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x20);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);

		L0ad6:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0ae4;
			goto L0c57;

		L0ae4:
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x10));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0b0e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) + 1), 10));

			// Instruction address 0x0000:0x0b1e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_34a7);

			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0b2e); // stack management - push return offset
			// Instruction address 0x0000:0x0b29, size: 5
			this.oParent.Segment_2459.F0_2459_08c6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x0b39, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_34aa);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x70f7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0b5a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			// Instruction address 0x0000:0x0b6a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_34ad);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0b93); // stack management - push return offset
			// Instruction address 0x0000:0x0b8e, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0,
				(ushort)(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 3),
				this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)((ushort)((ushort)((short)((sbyte)this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x70f7)))) << 1) + 0x1946)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oCPU.AX.Word = 0xffff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0ba2); // stack management - push return offset
			// Instruction address 0x0000:0x0b9d, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x30);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xe8b8));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x30;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0bc5); // stack management - push return offset
			// Instruction address 0x0000:0x0bc0, size: 5
			this.oParent.Segment_1d12.F0_1d12_6ed4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);

			// Instruction address 0x0000:0x0bd9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(ushort)(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x70f3)) << 3), 0, 0xa0);

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x1);

		L0bec:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6ea8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0c1e;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x125);
			if (this.oCPU.Flags.GE) goto L0c1a;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x18);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0c17); // stack management - push return offset
			// Instruction address 0x0000:0x0c12, size: 5
			this.oParent.Segment_1d12.F0_1d12_7045();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L0c1a:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x13));

		L0c1e:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x15);
			if (this.oCPU.Flags.LE) goto L0bec;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x70f7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));
			this.oCPU.AX.Word = 0x19;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x12f;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = 0x8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0c50); // stack management - push return offset
			// Instruction address 0x0000:0x0c4b, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x20));

		L0c57:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x5);
			if (this.oCPU.Flags.GE) goto L0c63;
			goto L0ad6;

		L0c63:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0c68); // stack management - push return offset
			// Instruction address 0x0000:0x0c63, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0c72); // stack management - push return offset
			// Instruction address 0x0000:0x0c6d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F3_0000_09ac'");
		}
	}
}
