using System;
using System.IO;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_11
	{
		private OpenCiv1 oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

		public Overlay_11(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F11_0000_0000()
		{
			this.oCPU.Log.EnterBlock("'F11_0000_0000'(Cdecl, Far) at 0x0000:0x0000");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681a, 0x1);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0011); // stack management - push return offset
										// Instruction address 0x0000:0x000c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0015); // stack management - push return offset
			F11_0000_05f8();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0020;
			goto L00f7;

		L0020:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0xffff);
			if (this.oCPU.Flags.E) goto L0029;
			goto L00ae;

		L0029:
			// Instruction address 0x0000:0x0031, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_41b0);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd74e, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0044:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x41c6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x005a); // stack management - push return offset
			F11_0000_0103_LoadGame();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L006d;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd74e, this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd74e), this.oCPU.AX.Word));

		L006d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xa);
			if (this.oCPU.Flags.B) goto L0044;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x007b); // stack management - push return offset
										// Instruction address 0x0000:0x0076, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = 0x41;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x30;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x008c); // stack management - push return offset
										// Instruction address 0x0000:0x0087, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0097); // stack management - push return offset
										// Instruction address 0x0000:0x0092, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xe168);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd74e));
			if (this.oCPU.Flags.NE) goto L00b4;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, 0xffff);
			goto L00b4;

		L00ae:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, this.oCPU.AX.Word);

		L00b4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe168), 0xffff);
			if (this.oCPU.Flags.E) goto L00dc;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xe168);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x41c6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00cf); // stack management - push return offset
			F11_0000_0103_LoadGame();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L00dc;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, 0xffff);

		L00dc:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00ea); // stack management - push return offset
										// Instruction address 0x0000:0x00e5, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00f2); // stack management - push return offset
										// Instruction address 0x0000:0x00ed, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe168);
			goto L00ff;

		L00f7:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00fc); // stack management - push return offset
										// Instruction address 0x0000:0x00f7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = 0xffff;

		L00ff:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F11_0000_0000'");
		}

		public void F11_0000_0103_LoadGame()
		{
			this.oCPU.Log.EnterBlock("'F11_0000_0103'(Cdecl, Far) at 0x0000:0x0103");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);

			// Instruction address 0x0000:0x0114, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)) + 9),
				OpenCiv1.String_41d3);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L0125;
			goto L02fd;

		L0125:
			// Instruction address 0x0000:0x012c, size: 5
			this.oParent.MSCAPI.open(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x8000);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681e, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L013f;
			goto L02d1;

		L013f:
			// Instruction address 0x0000:0x014c, size: 5
			this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 2, 0);

			// Instruction address 0x0000:0x0160, size: 5
			this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0x6822, 2);

			// Instruction address 0x0000:0x0175, size: 5
			this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 8, 0);

			// Instruction address 0x0000:0x0189, size: 5
			this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0x6826, 2);

			// Instruction address 0x0000:0x0199, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_41d7);

			// Instruction address 0x0000:0x01ae, size: 5
			this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 10, 0);

			// Instruction address 0x0000:0x01c2, size: 5
			this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0x6824, 2);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6824);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x01d8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x33a2)));

			// Instruction address 0x0000:0x01e8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_41d9);

			// Instruction address 0x0000:0x0207, size: 5
			this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e),
				((14 * (int)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6822))) + 16), 0);

			// Instruction address 0x0000:0x021b, size: 5
			this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), (ushort)(this.oCPU.BP.Word - 0x10), 14);

			// Instruction address 0x0000:0x022b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, (ushort)(this.oCPU.BP.Word - 0x10));

			// Instruction address 0x0000:0x024a, size: 5
			this.oParent.MSCAPI.lseek((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e),
				((12 * (int)((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6822))) + 0x80), 0);

			// Instruction address 0x0000:0x025e, size: 5
			this.oParent.MSCAPI.read((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), (ushort)(this.oCPU.BP.Word - 0x10), 0xc);

			// Instruction address 0x0000:0x026e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_41db);

			// Instruction address 0x0000:0x027e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, (ushort)(this.oCPU.BP.Word - 0x10));

			// Instruction address 0x0000:0x028e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_41de);

			// Instruction address 0x0000:0x02b8, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(Math.Abs((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6826)), 10));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6826), 0x0);
			if (this.oCPU.Flags.GE) goto L02cc;
			this.oCPU.AX.Word = 0x41e0;
			goto L02d4;

		L02cc:
			this.oCPU.AX.Word = 0x41e5;
			goto L02d4;

		L02d1:
			this.oCPU.AX.Word = 0x41ea;

		L02d4:
			// Instruction address 0x0000:0x02d9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x02e5, size: 5
			this.oParent.MSCAPI.close((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681e), 0xffff);
			if (this.oCPU.Flags.E) goto L02f9;

			L02f4:
			this.oCPU.AX.Word = 0x1;
			goto L0366;

		L02f9:
			this.oCPU.AX.Word = 0;
			goto L0366;

		L02fd:
			string path = this.oCPU.ReadString(
				CPU.ToLinearAddress(this.oCPU.DS.Word,
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))));

			F11_0000_083b_LoadGameData(path);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0315); // stack management - push return offset
										// Instruction address 0x0000:0x0310, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x2);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0329); // stack management - push return offset
			this.oParent.Overlay_7.F7_0000_1440();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6820, 0x1);
			goto L0340;

		L033c:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6820, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6820)));

		L0340:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6820), 0x8);
			if (this.oCPU.Flags.L) goto L033c;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe168), 0x4);
			if (this.oCPU.Flags.GE) goto L0353;
			this.oCPU.AX.Word = 0x1;
			goto L0356;

		L0353:
			this.oCPU.AX.Word = 0x2;

		L0356:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdf60, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3484, 0xfffd);
			this.oParent.GameState.SpaceshipFlags &= 0x7ffe;
			goto L02f4;

		L0366:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F11_0000_0103'");
		}

		public void F11_0000_036a()
		{
			this.oCPU.Log.EnterBlock("'F11_0000_036a'(Cdecl, Far) at 0x0000:0x036a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681c, 0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x681a, 0);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x037d); // stack management - push return offset
										// Instruction address 0x0000:0x0378, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0386); // stack management - push return offset
			F11_0000_05f8();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0391;
			goto L04d0;

		L0391:
			// Instruction address 0x0000:0x0399, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_41f4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L03a6:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x41c6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03bc); // stack management - push return offset
			F11_0000_0103_LoadGame();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x4);
			if (this.oCPU.Flags.L) goto L03a6;

			// Instruction address 0x0000:0x03d3, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xe168), 0, 3);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0405;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03e9); // stack management - push return offset
										// Instruction address 0x0000:0x03e4, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = 0x21;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x30;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03fa); // stack management - push return offset
										// Instruction address 0x0000:0x03f5, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0405); // stack management - push return offset
										// Instruction address 0x0000:0x0400, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

		L0405:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0xffff);
			if (this.oCPU.Flags.NE) goto L040e;
			goto L04d0;

		L040e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe168, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41cd, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0x41c6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0424); // stack management - push return offset
			F11_0000_04ef_SaveGame();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L042e;
			goto L04d0;

		L042e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681c);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0448;

			// Instruction address 0x0000:0x043e, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_420a);

			goto L0478;

		L0448:
			// Instruction address 0x0000:0x0450, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4221);

			// Instruction address 0x0000:0x0470, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x40, 0x7f, 0xc0, 0x22, 0xc);

		L0478:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681c), 0xd);
			if (this.oCPU.Flags.NE) goto L048f;

			// Instruction address 0x0000:0x0487, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4233);

		L048f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681c), 0x1c);
			if (this.oCPU.Flags.NE) goto L04a6;

			// Instruction address 0x0000:0x049e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_424a);

		L04a6:
			// Instruction address 0x0000:0x04ae, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4257);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd206, 0x1);
			this.oCPU.AX.Word = 0x7f;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x40;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04cd); // stack management - push return offset
										// Instruction address 0x0000:0x04c8, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L04d0:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04de); // stack management - push return offset
										// Instruction address 0x0000:0x04d9, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04eb); // stack management - push return offset
										// Instruction address 0x0000:0x04e6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F11_0000_036a'");
		}

		public void F11_0000_04ef_SaveGame()
		{
			this.oCPU.Log.EnterBlock("'F11_0000_04ef'(Cdecl, Far) at 0x0000:0x04ef");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdb38, 0x1);

			// Instruction address 0x0000:0x0503, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4270);

			// Instruction address 0x0000:0x0512, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));

			// Instruction address 0x0000:0x0522, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4272);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.DifficultyLevel;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0538, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x33a2)));

			// Instruction address 0x0000:0x0548, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4275);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x055e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			// Instruction address 0x0000:0x056e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4277);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0584, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x0000:0x0594, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_427a);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05a1); // stack management - push return offset
										// Instruction address 0x0000:0x059c, size: 5
			this.oParent.Segment_1238.F0_1238_1720();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			// Instruction address 0x0000:0x05a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_427c);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd206, 0x1);
			this.oCPU.AX.Word = 0x56;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x40;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05c8); // stack management - push return offset
										// Instruction address 0x0000:0x05c3, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			string path = this.oCPU.ReadString(
				CPU.ToLinearAddress(this.oCPU.DS.Word,
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))));

			F11_0000_08f6_SaveGameData(path);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F11_0000_04ef'");
		}

		public void F11_0000_05f8()
		{
			this.oCPU.Log.EnterBlock("'F11_0000_05f8'(Cdecl, Far) at 0x0000:0x05f8");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384), 0xffff);
			if (this.oCPU.Flags.NE) goto L0615;

			// Instruction address 0x0000:0x0609, size: 5
			this.oParent.MSCAPI._dos_getdrive(0x4384);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384,
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384)));

		L0615:
			// Instruction address 0x0000:0x0629, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 15);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681a), 0x0);
			if (this.oCPU.Flags.NE) goto L063d;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x063d); // stack management - push return offset
										// Instruction address 0x0000:0x0638, size: 5
			this.oParent.Segment_1866.F0_1866_260e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

		L063d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x681a), 0x0);
			if (this.oCPU.Flags.E) goto L0649;
			// Instruction address 0x0000:0x0651, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4295);
			goto L064c;

		L0649:
			// Instruction address 0x0000:0x0651, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_42d5);

		L064c:
			// Instruction address 0x0000:0x065d, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x4384);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), this.oCPU.AX.Low);

			// Instruction address 0x0000:0x0678, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4314);

			// Instruction address 0x0000:0x0688, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4351);

			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x48;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x63;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06a4); // stack management - push return offset
										// Instruction address 0x0000:0x069f, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0088();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06ac); // stack management - push return offset
										// Instruction address 0x0000:0x06a7, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x41);
			if (this.oCPU.Flags.E) goto L06b9;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x61);
			if (this.oCPU.Flags.NE) goto L06bf;

		L06b9:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x0);

		L06bf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x42);
			if (this.oCPU.Flags.E) goto L06cb;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x62);
			if (this.oCPU.Flags.NE) goto L06d1;

			L06cb:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x1);

		L06d1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x43);
			if (this.oCPU.Flags.E) goto L06dd;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x63);
			if (this.oCPU.Flags.NE) goto L06e3;

		L06dd:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x2);

		L06e3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x44);
			if (this.oCPU.Flags.E) goto L06ef;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x64);
			if (this.oCPU.Flags.NE) goto L06f5;

		L06ef:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x3);

		L06f5:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x45);
			if (this.oCPU.Flags.E) goto L0701;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x65);
			if (this.oCPU.Flags.NE) goto L0707;

		L0701:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x4);

		L0707:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x46);
			if (this.oCPU.Flags.E) goto L0713;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x66);
			if (this.oCPU.Flags.NE) goto L0719;

		L0713:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0x5);

		L0719:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1b);
			if (this.oCPU.Flags.NE) goto L0725;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x4384, 0xffff);

		L0725:
			// Instruction address 0x0000:0x073d, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x50, 0x58, 0xa0, 0x18, 15);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xd);
			if (this.oCPU.Flags.E) goto L0754;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1b);
			if (this.oCPU.Flags.E) goto L0754;
			goto L063d;

		L0754:
			// Instruction address 0x0000:0x0769, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				8, 8, 0x130, 0xb8, 15);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384), 0xffff);
			if (this.oCPU.Flags.E) goto L07c7;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384));
			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0780); // stack management - push return offset
			F11_0000_07d6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L07c7;

			// Instruction address 0x0000:0x078f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_436e);

			// Instruction address 0x0000:0x079b, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x4384);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x41);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba03), this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07bf); // stack management - push return offset
										// Instruction address 0x0000:0x07ba, size: 5
			this.oParent.Segment_1238.F0_1238_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = 0xffff;
			goto L07d2;

		L07c7:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x4384);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x61);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x41c6, this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4384);

		L07d2:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F11_0000_05f8'");
		}

		public void F11_0000_07d6()
		{
			this.oCPU.Log.EnterBlock("'F11_0000_07d6'(Cdecl, Far) at 0x0000:0x07d6");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x1);
			if (this.oCPU.Flags.LE) goto L07e7;

		L07e2:
			this.oCPU.AX.Word = 0x1;
			goto L0837;

		L07e7:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0806:
			// Instruction address 0x0000:0x080e, size: 5
			this.oParent.MSCAPI._bios_disk(4, (ushort)(this.oCPU.BP.Word - 0x12));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.TESTWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xff00);
			if (this.oCPU.Flags.E) goto L07e2;

			// Instruction address 0x0000:0x0824, size: 5
			this.oParent.MSCAPI._bios_disk(0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.L) goto L0806;
			this.oCPU.AX.Word = 0;

		L0837:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F11_0000_07d6'");
		}

		public bool F11_0000_083b_LoadGameData(string path)
		{
			this.oCPU.Log.EnterBlock($"F11_0000_083b_LoadGame({path})");

			// function body
			bool bSuccess = false;
			string filename = Path.GetFileNameWithoutExtension(path).ToLower();

			try
			{
				// read map file
				byte[] temp;
				VGABitmap map = VGABitmap.FromFile(Path.Combine(this.oCPU.DefaultDirectory, $"{filename}.map"), out temp);
				this.oParent.VGADriver.Screens.SetValueByKey(2, map);

				// read sve file
				FileStream reader = new FileStream(Path.Combine(this.oCPU.DefaultDirectory, $"{filename}.sve"), FileMode.Open);
				this.oParent.GameState.TurnCount = ReadInt16(reader);
				this.oParent.GameState.HumanPlayerID = ReadInt16(reader);
				this.oParent.GameState.PlayerFlags = ReadInt16(reader);
				this.oParent.GameState.RandomSeed = ReadUInt16(reader);
				this.oParent.GameState.Year = ReadInt16(reader);
				this.oParent.GameState.DifficultyLevel = ReadInt16(reader);
				this.oParent.GameState.ActiveCivilizations = ReadInt16(reader);
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID = ReadInt16(reader);
				ReadData(reader, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19a2), 0x70);
				ReadData(reader, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1992), 0x60);
				ReadData(reader, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1982), 0x58);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].Coins = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].ResearchProgress = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].ActiveUnits.Length; j++)
					{
						this.oParent.GameState.Players[i].ActiveUnits[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].UnitsInProduction.Length; j++)
					{
						this.oParent.GameState.Players[i].UnitsInProduction[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].DiscoveredTechnologyCount = ReadInt16(reader);
				}

				ReadData(reader, 0xe3c8, 0x50);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].GovernmentType = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].Continents.Length; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].Strategy = ReadInt16(reader);
					}
				}

				ReadData(reader, 0xe498, 0x80);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].CityCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].UnitCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].LandCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SettlerCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].TotalCitySize = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].MilitaryPower = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].Ranking = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].TaxRate = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].Score = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].ContactPlayerCountdown = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].XStart = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].LeaderGraphics = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].Attack = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].Defense = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].Continents.Length; j++)
					{
						this.oParent.GameState.Players[i].Continents[j].CityCount = ReadInt16(reader);
					}
				}

				ReadData(reader, 0xdcfe, 0x100);
				ReadData(reader, 0xb1ee, 0x20);
				ReadData(reader, 0x3772, 0, 0x4b0);

				for (int i = 0; i < this.oParent.GameState.PeaceGraphData.Length; i++)
				{
					this.oParent.GameState.PeaceGraphData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Cities.Length; i++)
				{
					this.oParent.GameState.Cities[i] = City.FromStream(reader);
				}

				ReadData(reader, 0x112a, 0x3b8);

				byte[] aUnits = new byte[0x3000];
				reader.Read(aUnits, 0, 0x3000);
				MemoryStream unitReader = new MemoryStream(aUnits);

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.oParent.GameState.Players[i].Units[j] = Unit.FromStream(unitReader);
					}
				}

				unitReader.Position = 0;
				ReadData(unitReader, 0x81d4, 0x3000);

				unitReader.Close();
				aUnits = null;

				for (int i = 0; i < this.oParent.GameState.MapVisibility.GetLength(0); i++)
				{
					for (int j = 0; j < this.oParent.GameState.MapVisibility.GetLength(1); j++)
					{
						this.oParent.GameState.MapVisibility[i, j] = (sbyte)ReadUInt8(reader);
					}
				}

				ReadData(reader, 0xd76e, 0x80);
				ReadData(reader, 0xe518, 0x80);
				ReadData(reader, 0xdc6c, 0x80);
				ReadData(reader, 0xde22, 0x80);

				for (int i = 0; i < this.oParent.GameState.TechnologyFirstDiscoveredBy.Length; i++)
				{
					this.oParent.GameState.TechnologyFirstDiscoveredBy[i] = ReadInt16(reader);
				}

				ReadData(reader, 0xe418, 0x80);

				for (int i = 0; i < this.oParent.GameState.CityNames.Length; i++)
				{
					char[] acCityName = new char[13];

					for (int j = 0; j < 13; j++)
					{
						acCityName[j] = (char)Overlay_11.ReadUInt8(reader);
					}
					this.oParent.GameState.CityNames[i] = new string(acCityName);
				}

				this.oParent.GameState.ReplayDataLength = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.ReplayData.Length; i++)
				{
					this.oParent.GameState.ReplayData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.oParent.GameState.WonderCityID.Length; i++)
				{
					this.oParent.GameState.WonderCityID[i] = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].LostUnits.Length; j++)
					{
						this.oParent.GameState.Players[i].LostUnits[j] = ReadInt16(reader);

					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						this.oParent.GameState.Players[i].TechnologyAcquiredFrom[j] = (sbyte)ReadUInt8(reader);
					}
				}

				this.oParent.GameState.PollutedSquareCount = ReadInt16(reader);
				this.oParent.GameState.PollutionEffectLevel = ReadInt16(reader);
				this.oParent.GameState.GlobalWarmingCount = ReadInt16(reader);
				this.oParent.GameState.GameSettingFlags = ReadInt16(reader);
				ReadData(reader, 0xdb44, 0x104);
				this.oParent.GameState.MaximumTechnologyCount = ReadInt16(reader);
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].FutureTechnologyCount = ReadInt16(reader);
				this.oParent.GameState.DebugFlags = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].ScienceTaxRate = ReadInt16(reader);
				}
				
				this.oParent.GameState.NextAnthologyTurn = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].CumulativeEpicRanking = ReadInt16(reader);
				}

				ReadData(reader, 0x3772, 0x16e0, 0x5a0);
				this.oParent.GameState.SpaceshipFlags = ReadInt16(reader);
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipSuccessRate = ReadInt16(reader);
				this.oParent.GameState.AISpaceshipSuccessRate = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SpaceshipETAYear = ReadInt16(reader);
				}

				ReadData(reader, 0xd91e, 0x18);
				ReadData(reader, 0xb222, 0x18);

				for (int i = 0; i < this.oParent.GameState.CityPositions.Length; i++)
				{
					this.oParent.GameState.CityPositions[i].X = ReadUInt8(reader);
				}

				for (int i = 0; i < this.oParent.GameState.CityPositions.Length; i++)
				{
					this.oParent.GameState.CityPositions[i].Y = ReadUInt8(reader);
				}

				this.oParent.GameState.PalaceLevel = ReadInt16(reader);
				this.oParent.GameState.PeaceTurnCount = ReadInt16(reader);
				this.oParent.GameState.AIOpponentCount = ReadInt16(reader);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SpaceshipPopulation = ReadInt16(reader);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					this.oParent.GameState.Players[i].SpaceshipLaunchYear = ReadInt16(reader);
				}

				this.oParent.GameState.PlayerIdentityFlags = ReadInt16(reader);

				reader.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.oParent.MSCAPI.strcpy(0xba06, ex.Message);

				this.oCPU.AX.Word = 0x50;
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = 0x64;
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = 0xba06;
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				this.oCPU.PushWord(0x08a8); // stack management - push return offset
											// Instruction address 0x0000:0x08a3, size: 5
				this.oParent.Segment_1238.F0_1238_001e();
				this.oCPU.PopDWord(); // stack management - pop return offset and segment
				this.oCPU.CS.Word = this.usSegment; // restore this function segment
				this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

				bSuccess = false;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_083b_LoadGame");

			return bSuccess;
		}

		private void ReadData(Stream reader, ushort bufferPtr, ushort length)
		{
			reader.Read(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(this.oCPU.DS.Word, bufferPtr), length);
		}

		private void ReadData(Stream reader, ushort bufferSeg, ushort bufferPtr, ushort length)
		{
			reader.Read(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(bufferSeg, bufferPtr), length);
		}

		public static byte ReadUInt8(Stream reader)
		{
			int byte0 = reader.ReadByte();

			if (byte0 >= 0)
			{
				return (byte)byte0;
			}

			return 0;
		}

		public static ushort ReadUInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (ushort)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		public static short ReadInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (short)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		public bool F11_0000_08f6_SaveGameData(string path)
		{
			this.oCPU.Log.EnterBlock($"F11_0000_08f6_SaveGame({path})");

			// function body
			bool bSuccess = false;
			string filename = Path.GetFileNameWithoutExtension(path);

			try
			{
				// write map file
				this.oParent.VGADriver.Screens.GetValueByKey(2).Save(Path.Combine(this.oCPU.DefaultDirectory, $"{filename}.map"), false);

				// write sve file
				FileStream writer = new FileStream(Path.Combine(this.oCPU.DefaultDirectory, $"{filename}.sve"), FileMode.Create);
				WriteInt16(writer, this.oParent.GameState.TurnCount);
				WriteInt16(writer, this.oParent.GameState.HumanPlayerID);
				WriteInt16(writer, this.oParent.GameState.PlayerFlags);
				WriteUInt16(writer, this.oParent.GameState.RandomSeed);
				WriteInt16(writer, this.oParent.GameState.Year);
				WriteInt16(writer, this.oParent.GameState.DifficultyLevel);
				WriteInt16(writer, this.oParent.GameState.ActiveCivilizations);
				WriteInt16(writer, this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID);
				WriteData(writer, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19a2), 0x70);
				WriteData(writer, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1992), 0x60);
				WriteData(writer, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1982), 0x58);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].Coins);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].ResearchProgress);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].ActiveUnits.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].ActiveUnits[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].UnitsInProduction.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].UnitsInProduction[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].DiscoveredTechnologyCount);
				}

				WriteData(writer, 0xe3c8, 0x50);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].GovernmentType);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].Continents.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].Strategy);
					}
				}

				WriteData(writer, 0xe498, 0x80);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].CityCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].UnitCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].LandCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SettlerCount);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].TotalCitySize);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].MilitaryPower);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].Ranking);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].TaxRate);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].Score);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].ContactPlayerCountdown);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].XStart);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].LeaderGraphics);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].Attack);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].Defense);
					}
				}
				
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].Continents[j].CityCount);
					}
				}

				WriteData(writer, 0xdcfe, 0x100);
				WriteData(writer, 0xb1ee, 0x20);
				WriteData(writer, 0x3772, 0, 0x4b0);

				for (int i = 0; i < this.oParent.GameState.PeaceGraphData.Length; i++)
				{
					writer.WriteByte(this.oParent.GameState.PeaceGraphData[i]);
				}

				for (int i = 0; i < this.oParent.GameState.Cities.Length; i++)
				{
					this.oParent.GameState.Cities[i].ToStream(writer);
				}

				WriteData(writer, 0x112a, 0x3b8);

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.oParent.GameState.Players[i].Units[j].ToStream(writer);
					}
				}

				for (int i = 0; i < this.oParent.GameState.MapVisibility.GetLength(0); i++)
				{
					for (int j = 0; j < this.oParent.GameState.MapVisibility.GetLength(1); j++)
					{
						writer.WriteByte((byte)this.oParent.GameState.MapVisibility[i, j]);
					}
				}

				WriteData(writer, 0xd76e, 0x80);
				WriteData(writer, 0xe518, 0x80);
				WriteData(writer, 0xdc6c, 0x80);
				WriteData(writer, 0xde22, 0x80);

				for (int i = 0; i < this.oParent.GameState.TechnologyFirstDiscoveredBy.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.TechnologyFirstDiscoveredBy[i]);
				}

				WriteData(writer, 0xe418, 0x80);

				for (int i = 0; i < this.oParent.GameState.CityNames.Length; i++)
				{
					for (int j = 0; j < 13; j++)
					{
						writer.WriteByte((byte)this.oParent.GameState.CityNames[i][j]);
					}
				}

				WriteInt16(writer, this.oParent.GameState.ReplayDataLength);
				for (int i = 0; i < this.oParent.GameState.ReplayData.Length; i++)
				{
					writer.WriteByte(this.oParent.GameState.ReplayData[i]);
				}

				for (int i = 0; i < this.oParent.GameState.WonderCityID.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.WonderCityID[i]);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[j].LostUnits.Length; j++)
					{
						WriteInt16(writer, this.oParent.GameState.Players[i].LostUnits[j]);
					}
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					for (int j = 0; j < this.oParent.GameState.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						writer.WriteByte((byte)((sbyte)this.oParent.GameState.Players[i].TechnologyAcquiredFrom[j]));
					}
				}

				WriteInt16(writer, this.oParent.GameState.PollutedSquareCount);
				WriteInt16(writer, this.oParent.GameState.PollutionEffectLevel);
				WriteInt16(writer, this.oParent.GameState.GlobalWarmingCount);
				WriteInt16(writer, this.oParent.GameState.GameSettingFlags);
				WriteData(writer, 0xdb44, 0x104);
				WriteInt16(writer, this.oParent.GameState.MaximumTechnologyCount);
				WriteInt16(writer, this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].FutureTechnologyCount);
				WriteInt16(writer, this.oParent.GameState.DebugFlags);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].ScienceTaxRate);
				}
				
				WriteInt16(writer, this.oParent.GameState.NextAnthologyTurn);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].CumulativeEpicRanking);
				}

				WriteData(writer, 0x3772, 0x16e0, 0x5a0);
				WriteInt16(writer, this.oParent.GameState.SpaceshipFlags);
				WriteInt16(writer, this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipSuccessRate);
				WriteInt16(writer, this.oParent.GameState.AISpaceshipSuccessRate);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SpaceshipETAYear);
				}

				WriteData(writer, 0xd91e, 0x18);
				WriteData(writer, 0xb222, 0x18);

				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)this.oParent.GameState.CityPositions[i].X);
				}
				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)this.oParent.GameState.CityPositions[i].Y);
				}

				WriteInt16(writer, this.oParent.GameState.PalaceLevel);
				WriteInt16(writer, this.oParent.GameState.PeaceTurnCount);
				WriteInt16(writer, this.oParent.GameState.AIOpponentCount);

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SpaceshipPopulation);
				}

				for (int i = 0; i < this.oParent.GameState.Players.Length; i++)
				{
					WriteInt16(writer, this.oParent.GameState.Players[i].SpaceshipLaunchYear);
				}

				WriteInt16(writer, this.oParent.GameState.PlayerIdentityFlags);

				writer.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.oParent.MSCAPI.strcpy(0xba06, ex.Message);

				this.oCPU.AX.Word = 0x40;
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = 0x4;
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = 0xba06;
				this.oCPU.PushWord(this.oCPU.AX.Word);
				this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
				this.oCPU.PushWord(0x0940); // stack management - push return offset
				this.oParent.Segment_1238.F0_1238_0008();
				this.oCPU.PopDWord(); // stack management - pop return offset and segment
				this.oCPU.CS.Word = this.usSegment; // restore this function segment
				this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

				bSuccess = false;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F11_0000_08f6_SaveGame");

			return bSuccess;
		}

		private void WriteData(Stream writer, ushort bufferPtr, ushort length)
		{
			writer.Write(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(this.oCPU.DS.Word, bufferPtr), length);
		}

		private void WriteData(Stream writer, ushort bufferSeg, ushort bufferPtr, ushort length)
		{
			writer.Write(this.oCPU.Memory.MemoryContent,
				(int)CPU.ToLinearAddress(bufferSeg, bufferPtr), length);
		}

		public static void WriteUInt16(Stream writer, ushort value)
		{
			writer.WriteByte((byte)(value & 0xff));
			writer.WriteByte((byte)((value & 0xff00) >> 8));
		}

		public static void WriteInt16(Stream writer, short value)
		{
			writer.WriteByte((byte)((ushort)value & 0xff));
			writer.WriteByte((byte)(((ushort)value & 0xff00) >> 8));
		}
	}
}
