using Disassembler;

namespace OpenCiv1
{
	public class Overlay_23
	{
		private OpenCiv1 oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

		public Overlay_23(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F23_0000_0000()
		{
			this.oCPU.Log.EnterBlock("'F23_0000_0000'(Cdecl, Far) at 0x0000:0x0000");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x000b); // stack management - push return offset
			// Instruction address 0x0000:0x0006, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

		L0010:
			// Instruction address 0x0000:0x0025, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x50, 0x50, 0xa0, 0x20, 0xf);

			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x20;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0043); // stack management - push return offset
			// Instruction address 0x0000:0x003e, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x52;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x58;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x539e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x005a); // stack management - push return offset
			// Instruction address 0x0000:0x0055, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x006a); // stack management - push return offset
			// Instruction address 0x0000:0x0065, size: 5
			this.oParent.Segment_2459.F0_2459_08c6();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x60;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x58;
			this.oCPU.PushWord(this.oCPU.AX.Word);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x007d); // stack management - push return offset
			F23_0000_0414();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0087, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0096;
			goto L0010;

		L0096:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L00c5;

			this.oParent.MSCAPI.movedata(
				this.oCPU.DS.Word,
				0xba06,
				0x3604,
				(ushort)(0xd * (ushort)this.oCPU.ReadUInt8(this.oCPU.DS.Word,
					(ushort)(0x1c * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)) + 0x7102))),
				0xd);

		L00c5:
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00cf); // stack management - push return offset
			// Instruction address 0x0000:0x00ca, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F23_0000_0000'");
		}

		public void F23_0000_00d6()
		{
			this.oCPU.Log.EnterBlock("'F23_0000_00d6'(Cdecl, Far) at 0x0000:0x00d6");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00db); // stack management - push return offset
			// Instruction address 0x0000:0x00d6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			// Instruction address 0x0000:0x00f3, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x9e, 0x58, 0xa0, 0x20, 0xf);

			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x20;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x58;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x9e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0114); // stack management - push return offset
			// Instruction address 0x0000:0x010f, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x53ab;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x012b); // stack management - push return offset
			// Instruction address 0x0000:0x0126, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

			this.oCPU.BX.Word = this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x013c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			this.oCPU.AX.Word = 0xd;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x68;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa6;
			this.oCPU.PushWord(this.oCPU.AX.Word);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0154); // stack management - push return offset
			F23_0000_0414();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			this.oCPU.BX.Word = this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0165, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)), 0xba06);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0172); // stack management - push return offset
			// Instruction address 0x0000:0x016d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			// Far return
			this.oCPU.Log.ExitBlock("'F23_0000_00d6'");
		}

		public void F23_0000_0173()
		{
			this.oCPU.Log.EnterBlock("'F23_0000_0173'(Cdecl, Far) at 0x0000:0x0173");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x017e); // stack management - push return offset
			// Instruction address 0x0000:0x0179, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			// Instruction address 0x0000:0x0196, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x9e, 0x58, 0xa0, 0x20, 0xf);

			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x20;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x58;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x9e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01b7); // stack management - push return offset
			// Instruction address 0x0000:0x01b2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x5a;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x53b8;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01ce); // stack management - push return offset
			// Instruction address 0x0000:0x01c9, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

			this.oCPU.BX.Word = this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x01df, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			this.oCPU.AX.Word = 0xb;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x68;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xa6;
			this.oCPU.PushWord(this.oCPU.AX.Word);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x01f7); // stack management - push return offset
			F23_0000_0414();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			this.oCPU.BX.Word = this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0208, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)), 0xba06);

			// Instruction address 0x0000:0x0214, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x73);
			if (this.oCPU.Flags.NE) goto L022e;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L022e:
			this.oCPU.BX.Word = this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x023c, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)), 0xba06);

			this.oCPU.BX.Word = this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xa), 0x0);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0257); // stack management - push return offset
			// Instruction address 0x0000:0x0252, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F23_0000_0173'");
		}

		public void F23_0000_025b()
		{
			this.oCPU.Log.EnterBlock("'F23_0000_025b'(Cdecl, Far) at 0x0000:0x025b");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0268); // stack management - push return offset
			// Instruction address 0x0000:0x0263, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			this.oCPU.AX.Word = 0x53ce;
			this.oCPU.PushWord(this.oCPU.AX.Word);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0275); // stack management - push return offset
			F23_0000_0319();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L02cd;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x70f1));
			this.oCPU.AX.High = 0;
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x32;
			this.oCPU.MULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x70f0)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.DI.Word);
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x740));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L02cd;
			this.oCPU.PushWord((ushort)(this.oCPU.DI.Word - 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x70f0));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oParent.GameState.HumanPlayerID);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x02c8); // stack management - push return offset
			// Instruction address 0x0000:0x02c3, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			goto L030e;

		L02cd:
			// Instruction address 0x0000:0x02e5, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x40, 0x4e, 0xe0, 0xa, 0xf);

			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x52;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x53f3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0301); // stack management - push return offset
			// Instruction address 0x0000:0x02fc, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0309); // stack management - push return offset
			// Instruction address 0x0000:0x0304, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

		L030e:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0313); // stack management - push return offset
			// Instruction address 0x0000:0x030e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F23_0000_025b'");
		}

		public void F23_0000_0319()
		{
			this.oCPU.Log.EnterBlock("'F23_0000_0319'(Cdecl, Far) at 0x0000:0x0319");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x14);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0338, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x40, 0x4e, 0xe0, 0x18, 0xf);

			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x18;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xe0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x4e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x40;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0358); // stack management - push return offset
			// Instruction address 0x0000:0x0353, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x42;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x036e); // stack management - push return offset
			// Instruction address 0x0000:0x0369, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x10;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x59;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x42;
			this.oCPU.PushWord(this.oCPU.AX.Word);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0386); // stack management - push return offset
			F23_0000_0414();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L03bc;

		L0390:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

		L0393:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x80);
			if (this.oCPU.Flags.GE) goto L03b9;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x70f2)), 0xff);
			if (this.oCPU.Flags.E) goto L0390;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x7102));
			this.oCPU.AX.High = 0;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			if (this.oCPU.Flags.NE) goto L0390;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			goto L040f;

		L03b9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L03bc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x100);
			if (this.oCPU.Flags.GE) goto L040c;

			this.oParent.MSCAPI.movedata(
				0x3604,
				(ushort)(0xd * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))),
				this.oCPU.DS.Word,
				(ushort)(this.oCPU.BP.Word - 0x10),
				0xd);

			// Instruction address 0x0000:0x03e8, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			// Instruction address 0x0000:0x03f9, size: 5
			this.oParent.MSCAPI.strnicmp(0xba06, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L03b9;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			goto L0393;

		L040c:
			this.oCPU.AX.Word = 0xffff;

		L040f:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F23_0000_0319'");
		}

		public void F23_0000_0414()
		{
			this.oCPU.Log.EnterBlock("'F23_0000_0414'(Cdecl, Far) at 0x0000:0x0414");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x48);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0434, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)),
				(ushort)(7 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa))),
				0xb, 0xf);

			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x045b); // stack management - push return offset
			// Instruction address 0x0000:0x0456, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xe), 0xf);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x1);

			// Instruction address 0x0000:0x0476, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			goto L048e;

		L0483:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

		L048e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0483;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04a8); // stack management - push return offset
			F23_0000_06c1();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x1);
			goto L0525;

		L04b2:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L052e;

			// Instruction address 0x0000:0x04d6, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68d0),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)) + 1),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68ce), 10, 15, 11);

			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04e7); // stack management - push return offset
			// Instruction address 0x0000:0x04e2, size: 5
			this.oParent.Segment_1182.F0_1182_0134();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x0503, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68d0),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 8)) + 1),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68ce), 10, 11, 15);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0510); // stack management - push return offset
			// Instruction address 0x0000:0x050b, size: 5
			this.oParent.MSCAPI.kbhit();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0520;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x051d); // stack management - push return offset
			// Instruction address 0x0000:0x0518, size: 5
			this.oParent.Segment_1182.F0_1182_0134();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L0520:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0525); // stack management - push return offset
			// Instruction address 0x0000:0x0520, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

		L0525:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x052a); // stack management - push return offset
			// Instruction address 0x0000:0x0525, size: 5
			this.oParent.MSCAPI.kbhit();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04b2;

		L052e:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.E) goto L053c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0xd);
			goto L0544;

		L053c:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0541); // stack management - push return offset
			// Instruction address 0x0000:0x053c, size: 5
			this.oParent.MSCAPI.getch();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

		L0544:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
			if (this.oCPU.Flags.NE) goto L0555;
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x054f); // stack management - push return offset
			// Instruction address 0x0000:0x054a, size: 5
			this.oParent.MSCAPI.getch();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x80);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

		L0555:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd);
			if (this.oCPU.Flags.NE) goto L0565;

		L055b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			goto L069d;

		L0565:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x1b);
			if (this.oCPU.Flags.NE) goto L0572;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x0);
			goto L055b;

		L0572:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xcb);
			if (this.oCPU.Flags.NE) goto L0584;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc), 0x0);
			if (this.oCPU.Flags.E) goto L0584;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L0584:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xcd);
			if (this.oCPU.Flags.NE) goto L0599;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc));
			if (this.oCPU.Flags.LE) goto L0599;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L0599:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd2);
			if (this.oCPU.Flags.NE) goto L05d7;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba06);
			// Instruction address 0x0000:0x05ab, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba07);
			// Instruction address 0x0000:0x05be, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.AX.Word, (ushort)(this.oCPU.BP.Word - 0x40));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L05d7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd3);
			if (this.oCPU.Flags.NE) goto L060a;

			// Instruction address 0x0000:0x05ec, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba06),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba07));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x20);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L060a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
			if (this.oCPU.Flags.NE) goto L063e;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc), 0x0);
			if (this.oCPU.Flags.E) goto L063e;

			// Instruction address 0x0000:0x0625, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba05),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba06));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x20);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L063e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x80);
			if (this.oCPU.Flags.GE) goto L0682;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x20);
			if (this.oCPU.Flags.L) goto L0682;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x0);
			if (this.oCPU.Flags.E) goto L066b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x0);
			goto L0663;

		L0658:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

		L0663:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0658;

		L066b:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.LE) goto L0682;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L0682:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x0);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0694); // stack management - push return offset
			F23_0000_06c1();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			goto L0525;

		L069a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

		L069d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0x0);
			if (this.oCPU.Flags.LE) goto L06b4;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x20);
			if (this.oCPU.Flags.NE) goto L06b4;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
			goto L069a;

		L06b4:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x06b9); // stack management - push return offset
			// Instruction address 0x0000:0x06b4, size: 5
			this.oParent.Segment_1403.F0_1403_4545();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F23_0000_0414'");
		}

		public void F23_0000_06c1()
		{
			this.oCPU.Log.EnterBlock("'F23_0000_06c1'(Cdecl, Far) at 0x0000:0x06c1");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0777;

		L06d7:
			// Instruction address 0x0000:0x06ea, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)),
				8, 8, 0xf);

			// Instruction address 0x0000:0x06f6, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			if (this.oCPU.Flags.LE) goto L0774;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07), 0x0);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0727); // stack management - push return offset
			// Instruction address 0x0000:0x0722, size: 5
			this.oParent.Segment_1182.F0_1182_002a_DrawString((ushort)(0xba06 + this.oCPU.BX.Word),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)),
				0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07), this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0759;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68d0, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06));

			// Instruction address 0x0000:0x074e, size: 5
			this.oParent.VGADriver.F0_VGA_115d_GetCharWidth(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0x10)), this.oCPU.AX.Low);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68ce, this.oCPU.AX.Word);

		L0759:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06));
			
			// Instruction address 0x0000:0x0769, size: 5
			this.oParent.VGADriver.F0_VGA_115d_GetCharWidth(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0x10)), this.oCPU.AX.Low);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.AX.Word));

		L0774:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0777:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0782;
			goto L06d7;

		L0782:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F23_0000_06c1'");
		}
	}
}
