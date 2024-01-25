using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_14
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Overlay_14(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="mode"></param>
		public void F14_0000_0000(ushort stringPtr, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_0000(0x{stringPtr:x4}, {mode})");

			// function body
			// Instruction address 0x0000:0x0003, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			F14_0000_001c(stringPtr, mode);

			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="mode"></param>
		public void F14_0000_001c(ushort stringPtr, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_001c(0x{stringPtr:x4}, {mode})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x0000:0x0032, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, mode);

			// Instruction address 0x0000:0x0049, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(stringPtr, 160, 2, 15);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0070;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0082;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L0087;
			goto L008c;

		L0070:
			this.oCPU.AX.Word = 0x473c;

		L0073:
			// Instruction address 0x0000:0x0078, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			goto L008c;

		L0082:
			this.oCPU.AX.Word = 0x4743;
			goto L0073;

		L0087:
			this.oCPU.AX.Word = 0x474b;
			goto L0073;

		L008c:
			// Instruction address 0x0000:0x0094, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4754);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x00aa, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x0000:0x00c2, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 10, 15);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x0000:0x00de, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x00ee, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_475d);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0104, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			// Instruction address 0x0000:0x0114, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_475f);

			// Instruction address 0x0000:0x011c, size: 5
			this.oParent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

			// Instruction address 0x0000:0x0131, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 18, 15);

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_001c");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F14_0000_013b()
		{
			this.oCPU.Log.EnterBlock("F14_0000_013b()");

			// function body
			// Instruction address 0x0000:0x013b, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x0145, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_013b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F14_0000_014b(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_014b({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			F14_0000_0000(0x4762, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.AX.Word = (ushort)oParent.GameState.DifficultyLevel;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd2de));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0xb;
			this.oCPU.AX.Word -= (ushort)this.oParent.GameState.Players[playerID].DiscoveredTechnologyCount;
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L018b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.SI.Word);

		L018b:
			if (this.oParent.GameState.Year >= 0) goto L0197;
			this.oCPU.CX.Word = 0x1;
			goto L019a;

		L0197:
			this.oCPU.CX.Word = 0x2;

		L019a:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].DiscoveredTechnologyCount;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x01be, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				2432 / (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) + 1),
				1, 64);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x01e9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))) / 8) + 8,
				8, 304);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xa0);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x28);
			if (this.oCPU.Flags.LE) goto L022e;
			
			// Instruction address 0x0000:0x0226, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0x118, 0x8c, 0x28, 0x3c,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x116, 0x2);

		L022e:
			// Instruction address 0x0000:0x0244, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 25,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 16, 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L0281;

		L0253:
			// Instruction address 0x0000:0x0270, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) >> 3) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				33,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xc << 1) + 0xd4ce)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0281:
			// Instruction address 0x0000:0x0290, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.GameState.Players[playerID].ResearchProgress,
				0, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.Flags.G) goto L0253;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1a);
			
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID == -1) goto L02ff;

			// Instruction address 0x0000:0x02b1, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4771);

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x02c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x02df, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 161, 26, 0);

			// Instruction address 0x0000:0x02f7, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 26, 15);

		L02ff:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x2a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L0355;

		L0310:
			this.oCPU.AX.Word = 0xb;

		L0313:
			// Instruction address 0x0000:0x032f, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) % 3) * 100) + 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L034b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x7));

		L034b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xc0);
			if (this.oCPU.Flags.G) goto L03a4;

		L0352:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0355:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x48);
			if (this.oCPU.Flags.GE) goto L03a4;

			// Instruction address 0x0000:0x0361, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L0352;

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x037b, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)this.oParent.GameState.TechnologyFirstDiscoveredBy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L039e;
			goto L0310;

		L039e:
			this.oCPU.AX.Word = 0xf;
			goto L0313;

		L03a4:
			F14_0000_013b();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_014b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F14_0000_03ad(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_03ad({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			F14_0000_0000(0x477e, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L03d3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] > 0)
				goto L03f1;

			if (this.oParent.GameState.Players[playerID].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] > 0)
				goto L03f1;

			goto L05d7;

		L03f1:
			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.VGADriver.F0_VGA_0599_DrawLine(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				36, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 2,
				319, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 2, 9);

			// Instruction address 0x0000:0x0432, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 0x1) << 4) + 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((((playerID << 5) +
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x40) << 1) + 0xd4ce)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0453, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				(ushort)(this.oCPU.SI.Word + 0x112a),
				36,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				15);

			// Instruction address 0x0000:0x0463, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_478e);

			// Instruction address 0x0000:0x0484, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x113e)), 10));

			// Instruction address 0x0000:0x0494, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4790);

			// Instruction address 0x0000:0x04b5, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1140)), 10));

			// Instruction address 0x0000:0x04c5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4792);

			// Instruction address 0x0000:0x04e6, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x113a)), 10));

			// Instruction address 0x0000:0x04f6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4794);

			// Instruction address 0x0000:0x050d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 112, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 11);

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[playerID].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.LE) goto L0574;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0545, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.SI.Word, 10));

			// Instruction address 0x0000:0x0555, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4796);

			// Instruction address 0x0000:0x056c, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 168, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 15);

		L0574:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[playerID].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))];

			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.LE) goto L05d3;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x05a4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.SI.Word, 10));

			// Instruction address 0x0000:0x05b4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_479e);

			// Instruction address 0x0000:0x05cb, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 232, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 11);

		L05d3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x9));

		L05d7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1c);
			if (this.oCPU.Flags.GE) goto L05e3;
			goto L03d3;

		L05e3:
			// Instruction address 0x0000:0x0603, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0xa0, 0x8c, 0x28, 0x3c,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x116, 0x2);

			F14_0000_013b();

			F14_0000_061f(playerID);

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_03ad");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F14_0000_061f(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_061f({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			F14_0000_0000(0x47ad, 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1c);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L0644:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L064e:
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].LostUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))], 0x0);
			if (this.oCPU.Flags.E) goto L066e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L066e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.L) goto L064e;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0680;
			goto L07b7;

		L0680:
			// Instruction address 0x0000:0x0692, size: 5
			this.oParent.VGADriver.F0_VGA_0599_DrawLine(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				36, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) - 1,
				319, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) - 1, 8);

			// Instruction address 0x0000:0x06bf, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) & 1) << 4) + 2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) - 4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((((playerID << 5) + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 0x40) << 1) + 0xd4ce)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

			// Instruction address 0x0000:0x06dc, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) * 0x22) + 0x112a),
				36,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x68);

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[playerID].LostUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L073f;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0720, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.SI.Word, 10));

			// Instruction address 0x0000:0x0737, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 104, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 12);

		L073f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);

		L0744:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L07aa;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x1c));

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].LostUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L07aa;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0787, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.SI.Word, 10));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x0000:0x07a2, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));

		L07aa:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.L) goto L0744;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x7));

		L07b7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1b);
			if (this.oCPU.Flags.GE) goto L07c3;
			goto L0644;

		L07c3:
			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x0000:0x07e0, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(100, 25,
				18, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) - 25,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));

			F14_0000_013b();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_061f");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F14_0000_07f1(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_07f1({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x40);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = (ushort)oParent.GameState.DifficultyLevel;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x080b, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x22);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))));
			}
		
			// Instruction address 0x0000:0x0821, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x25);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))));
			}
		
			F14_0000_0000(0x47bd, 2);

			// Instruction address 0x0000:0x085f, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0xc8, 0x8c, 0x28, 0x3c,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x116, 2);

			// Instruction address 0x0000:0x0877, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x47ca, 8, 32, 15);

			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.AX.Word);

		L088a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x34), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x18);
			if (this.oCPU.Flags.L) goto L088a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 0x28);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), 0x0);
			goto L09d3;

		L08aa:
			// Instruction address 0x0000:0x08b2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_47ef);

			// Instruction address 0x0000:0x08d3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e0), 10));

			// Instruction address 0x0000:0x08e3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_47f1);

			// Instruction address 0x0000:0x0904, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe17a), 10));

			// Instruction address 0x0000:0x0914, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_47f4);

			// Instruction address 0x0000:0x0935, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e6), 10));

			// Instruction address 0x0000:0x0945, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_47f7);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe17a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L0959:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0xb4);
			if (this.oCPU.Flags.GE) goto L097b;

			// Instruction address 0x0000:0x096f, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 80, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 10);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0x8));

		L097b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x1);

		L0980:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 28;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))].BuildingFlags0);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))].BuildingFlags1);
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.E) goto L09c7;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x34);
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xbd2));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), this.oCPU.AX.Word));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x1);
			if (this.oCPU.Flags.NE) goto L09c7;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), this.oCPU.AX.Word));

		L09c7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x18);
			if (this.oCPU.Flags.L) goto L0980;

		L09d0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))));

		L09d3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)), 0x80);
			if (this.oCPU.Flags.L) goto L09dd;
			goto L0a8d;

		L09dd:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L09d0;
			
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))].PlayerID != playerID)
				goto L09d0;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0xb4);
			if (this.oCPU.Flags.L) goto L0a16;

			// Instruction address 0x0000:0x09fd, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			F14_0000_001c(0x47d5, 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 0x28);

		L0a16:
			// Instruction address 0x0000:0x0a1d, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)), -1);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0a2d, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));

			// Instruction address 0x0000:0x0a3d, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 62);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0xb4);
			if (this.oCPU.Flags.GE) goto L0a63;

			// Instruction address 0x0000:0x0a5b, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(
				0xba06,
				16,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				15);

		L0a63:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))].StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L0a7a;
			goto L08aa;

		L0a7a:
			// Instruction address 0x0000:0x0a82, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_47e2);
			goto L0959;

		L0a8d:
			// Instruction address 0x0000:0x0a95, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_47f9);

			// Instruction address 0x0000:0x0ab5, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 10));

			// Instruction address 0x0000:0x0ac5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4808);

			// Instruction address 0x0000:0x0ae0, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 8, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) + 4, 10);

			// Instruction address 0x0000:0x0af0, size: 5
			this.oParent.Segment_1d12.F0_1d12_6c97(this.oParent.GameState.HumanPlayerID, 0x14);
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b07;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L0b07:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L0b10;
			goto L0baf;

		L0b10:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0xb4);
			if (this.oCPU.Flags.L) goto L0b1a;
			goto L0baf;

		L0b1a:
			if (this.oParent.GameState.Year >= 0) goto L0b26;
			this.oCPU.AX.Word = 0x1;
			goto L0b36;

		L0b26:
			if (this.oParent.GameState.Year>= 1750) goto L0b33;
			this.oCPU.AX.Word = 0x2;
			goto L0b36;

		L0b33:
			this.oCPU.AX.Word = 0x3;

		L0b36:
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].DiscoveredTechnologyCount);
			this.oCPU.CX.Word = (ushort)oParent.GameState.DifficultyLevel;
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x6);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0b5c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_480a);

			// Instruction address 0x0000:0x0b7c, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 10));

			// Instruction address 0x0000:0x0b8c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4818);

			// Instruction address 0x0000:0x0ba7, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 8, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) + 12, 10);

		L0baf:
			// Instruction address 0x0000:0x0bbf, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x481f, 160, 32, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 0x28);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x0);
			goto L0ca9;

		L0bd9:
			// Instruction address 0x0000:0x0c06, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, 
					(ushort)(this.oCPU.BP.Word + (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)) << 1) - 0x34)) /
					(short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 
					(ushort)((0x1e * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)) + 0xbd2) & 0xffff))), 10));

		L0bf6:
			// Instruction address 0x0000:0x0c16, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4831);

			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xbb8);
			// Instruction address 0x0000:0x0c2c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0c3c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4833);

			// Instruction address 0x0000:0x0c61, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(
					(short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word +
						(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)) << 1) - 0x34)), 10));

			// Instruction address 0x0000:0x0c71, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4836);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0xb4);
			if (this.oCPU.Flags.GE) goto L0c9b;

			// Instruction address 0x0000:0x0c8f, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 160, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 14);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0x8));

		L0c9b:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x34));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L0ca6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));

		L0ca9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x18);
			if (this.oCPU.Flags.GE) goto L0cda;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x34));
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L0ca6;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x1);
			if (this.oCPU.Flags.E) goto L0cc9;
			goto L0bd9;

		L0cc9:
			// Instruction address 0x0000:0x0c06, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)this.oCPU.SI.Word / 
					(short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))), 10));

			goto L0bf6;

		L0cda:
			// Instruction address 0x0000:0x0ce2, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4838);

			// Instruction address 0x0000:0x0d02, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 10));

			// Instruction address 0x0000:0x0d12, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4845);

			// Instruction address 0x0000:0x0d2d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 160, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) + 4, 14);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0xc));

			F14_0000_013b();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_07f1");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F14_0000_0d43()
		{
			this.oCPU.Log.EnterBlock("F14_0000_0d43()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x26);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			F14_0000_0000(0x4847, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x20);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			goto L0fee;

		L0d6f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x0);

		L0d79:
			this.oCPU.AX.Word = 28;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))].PlayerID,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.NE) goto L0d9f;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0d9f;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L0d9f;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L0d9f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x80);
			if (this.oCPU.Flags.L) goto L0d79;

			// Instruction address 0x0000:0x0db1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4873);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x0dc6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)));

			// Instruction address 0x0000:0x0ddd, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(
				0xba06,
				8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)),
				15);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0df3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1966)));

			// Instruction address 0x0000:0x0e03, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4876);

			// Instruction address 0x0000:0x0e24, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Coins, 10));

			// Instruction address 0x0000:0x0e34, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4879);

			if (this.oParent.GameState.DifficultyLevel > 1) goto L0e84;

			// Instruction address 0x0000:0x0e4b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_487b);

			// Instruction address 0x0000:0x0e6c, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].UnitCount, 10));

			// Instruction address 0x0000:0x0e7c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_487e);

		L0e84:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x0000:0x0e98, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 
				160,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x1);
			goto L0f1d;

		L0eb0:
			this.oCPU.AX.Word = 0x4890;

		L0eb3:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0ece, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)),
				7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0x60));

		L0eda:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			
			if ((this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))] & 3) != 1)
				goto L0f1a;

			// Instruction address 0x0000:0x0ef8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4899);

			// Instruction address 0x0000:0x0f0e, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)),
				7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0x60));

		L0f1a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));

		L0f1d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x8);
			if (this.oCPU.Flags.GE) goto L0f78;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0f35, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0xf0);
			if (this.oCPU.Flags.LE) goto L0f4d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x8));

		L0f4d:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			
			if ((this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))] & 2) == 0)
				goto L0eda;

			if ((this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))] & 4) == 0)
				goto L0eb0;

			this.oCPU.AX.Word = 0x4886;
			goto L0eb3;

		L0f78:
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0feb;

			// Instruction address 0x0000:0x0f96, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_48a0);

			// Instruction address 0x0000:0x0fb6, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 10));

			this.oCPU.AX.Word = 0x18;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			// Instruction address 0x0000:0x0fe3, size: 5
			this.oParent.Segment_1d12.F0_1d12_71bf(281, (short)this.oCPU.SI.Word + 20, 318, (short)this.oCPU.SI.Word + 29, 0xba06,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1946)));

		L0feb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0fee:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L0ff7;
			goto L1079;

		L0ff7:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.ActiveCivilizations);
			if (this.oCPU.Flags.E) goto L0feb;
			this.oCPU.AX.Word = 0x18;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x2);

			// Instruction address 0x0000:0x1024, size: 5
			this.oParent.VGADriver.F0_VGA_0599_DrawLine(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 
				4, (short)this.oCPU.SI.Word, 316, (short)this.oCPU.SI.Word, 9);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x1039, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L104c;
			goto L0d6f;

		L104c:
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 0x40) != 0)
				goto L0d6f;

			// Instruction address 0x0000:0x106b, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x485b, 
				96,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1946)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			goto L0feb;

		L1079:
			// Instruction address 0x0000:0x1079, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L107e:
			// Instruction address 0x0000:0x107e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L1093;

			// Instruction address 0x0000:0x108a, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L107e;

		L1093:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x1);

			// Instruction address 0x0000:0x1098, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L10b8;

			// Instruction address 0x0000:0x10a1, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x31);
			if (this.oCPU.Flags.L) goto L10b8;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x37);
			if (this.oCPU.Flags.G) goto L10b8;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x31);
			goto L10cc;

		L10b8:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x119);
			if (this.oCPU.Flags.LE) goto L1114;
			this.oCPU.AX.Word = this.oParent.Var_db3e;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x1c);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x18;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

		L10cc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1114;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1114;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1114;
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 0x40) == 0)
				goto L1114;

			F14_0000_1164(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);

		L1114:
			this.oCPU.AX.Word = this.oParent.Var_db3c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x111a, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x111f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x112c, size: 5
			this.oParent.Segment_1000.F0_1000_16ae(270, this.oParent.Var_db3e);
			
			// Instruction address 0x0000:0x1134, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x0);
			if (this.oCPU.Flags.NE) goto L1142;
			goto L107e;

		L1142:
			// Instruction address 0x0000:0x1142, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L1154;

			// Instruction address 0x0000:0x114d, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L1159;

		L1154:
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

		L1159:
			// Instruction address 0x0000:0x1159, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_0d43");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F14_0000_1164(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_1164({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			F14_0000_0000(0x48a5, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x20);

			// Instruction address 0x0000:0x1187, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_48b9);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x119c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			// Instruction address 0x0000:0x11b4, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06, 16, 32, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xc));

			// Instruction address 0x0000:0x11c8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_48c7);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x11de, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x11ee, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_48d1);

			// Instruction address 0x0000:0x11fe, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)));

			// Instruction address 0x0000:0x1215, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1512)), 0x1);
			if (this.oCPU.Flags.NE) goto L124c;

			// Instruction address 0x0000:0x1240, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x48d3, 24, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L124c:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1512)), 0xffff);
			if (this.oCPU.Flags.NE) goto L127c;

			// Instruction address 0x0000:0x1270, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x48de, 24, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L127c:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1514)), 0x1);
			if (this.oCPU.Flags.NE) goto L12ac;

			// Instruction address 0x0000:0x12a0, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x48e7, 24, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4),
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L12ac:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1514)), 0xffff);
			if (this.oCPU.Flags.NE) goto L12dc;

			// Instruction address 0x0000:0x12d0, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x48f6, 24, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L12dc:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1516)), 0x1);
			if (this.oCPU.Flags.NE) goto L130c;

			// Instruction address 0x0000:0x1300, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x4904, 24, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L130c:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1516)), 0xffff);
			if (this.oCPU.Flags.NE) goto L133c;

			// Instruction address 0x0000:0x1330, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x490e, 24, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L133c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L134a:
			this.oCPU.AX.Word = 28;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].PlayerID != playerID) goto L1370;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L1370;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L1370;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L1370:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x80);
			if (this.oCPU.Flags.L) goto L134a;

			// Instruction address 0x0000:0x1382, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_491b);

			// Instruction address 0x0000:0x138d, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			
			// Instruction address 0x0000:0x13a4, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

			// Instruction address 0x0000:0x13b8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4926);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x13d3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1966)));

			// Instruction address 0x0000:0x13ea, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

			// Instruction address 0x0000:0x13fe, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4934);

			// Instruction address 0x0000:0x141f, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].Coins, 10));

			// Instruction address 0x0000:0x142f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4940);

			// Instruction address 0x0000:0x1446, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));
			
			if (this.oParent.GameState.DifficultyLevel > 1) goto L14b5;

			// Instruction address 0x0000:0x1461, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4942);

			// Instruction address 0x0000:0x1482, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].UnitCount, 10));

			// Instruction address 0x0000:0x1492, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_494e);

			// Instruction address 0x0000:0x14a9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xc));

		L14b5:
			// Instruction address 0x0000:0x14c4, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x4956, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L14d5:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] & 2) != 0)
			{
				// Instruction address 0x0000:0x14f0, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4967);
			}
		
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] & 3) == 1)
			{
				// Instruction address 0x0000:0x1516, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4971);
			}
		
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] & 1) == 0)
				goto L157c;

			// Instruction address 0x0000:0x1539, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4979);

			// Instruction address 0x0000:0x1549, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			// Instruction address 0x0000:0x1559, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4985);

			// Instruction address 0x0000:0x1570, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 24, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L157c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.GE) goto L1588;
			goto L14d5;

		L1588:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4));

			// Instruction address 0x0000:0x159b, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x4987, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x47);

		L15ac:
			// Instruction address 0x0000:0x15b2, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L15e6;

			// Instruction address 0x0000:0x15d3, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) * 0x16) + 0x4da),
				24,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xc0);
			if (this.oCPU.Flags.GE) goto L15eb;

		L15e6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			if (this.oCPU.Flags.NS) goto L15ac;

		L15eb:
			F14_0000_013b();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_1164");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F14_0000_15f4(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_15f4({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x14);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			F14_0000_0000(0x4995, 9);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x20);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

		L1620:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L1632;
			goto L175a;

		L1632:
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].PlayerID != playerID)
				goto L175a;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xbe);
			if (this.oCPU.Flags.LE) goto L165f;

			// Instruction address 0x0000:0x1646, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			F14_0000_001c(0x49a5, 9);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x20);

		L165f:
			// Instruction address 0x0000:0x1666, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), -1);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x1676, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			// Instruction address 0x0000:0x1686, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_49b5);

			// Instruction address 0x0000:0x169d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 15);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x16c6, size: 5
			this.oParent.Segment_1d12.F0_1d12_6ed4(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) - 3),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe8b8), 124);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0xd4);

			// Instruction address 0x0000:0x16ec, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				212, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) - 1, 90, 10, 11);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L16f9:
			this.oCPU.AX.Word = 28;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].BuildingFlags0;
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.TESTWord(this.oCPU.AX.Word, 0x2618);
			if (this.oCPU.Flags.E) goto L172d;

			// Instruction address 0x0000:0x1721, size: 5
			this.oParent.Segment_1d12.F0_1d12_7045((short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) + 1),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) - 1));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x12));

		L172d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x18);
			if (this.oCPU.Flags.L) goto L16f9;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xa));

		L175a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x80);
			if (this.oCPU.Flags.GE) goto L1767;
			goto L1620;

		L1767:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L1770;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L1770:
			// Instruction address 0x0000:0x1778, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_49b7);

			// Instruction address 0x0000:0x1783, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_02cd(playerID);

			// Instruction address 0x0000:0x1793, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_49c4);

			F14_0000_181d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x0000:0x17b0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_49cc);

			F14_0000_181d(
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) -
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) -
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x0000:0x17d4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_49d7);

			F14_0000_181d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x0000:0x17f1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_49e2);

			// Instruction address 0x0000:0x180c, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 
				16,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) + 8,
				15);

			F14_0000_013b();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_15f4");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F14_0000_181d(short param1, short param2)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_181d({param1}, {param2})");

			// function body
			if (param1 < 300)
			{
				// Instruction address 0x0000:0x1865, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa((100 * param1) / param2, 10));
			}
			else
			{
				// Instruction address 0x0000:0x1865, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa((10 * param1) / (param2 / 10), 10));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_181d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F14_0000_186f(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F14_0000_186f({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			F14_0000_0000(0x49e4, 8);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1968;

		L1892:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xb9a);
			// Instruction address 0x0000:0x18ae, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x18be, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 96);

			// Instruction address 0x0000:0x18ce, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4a0e);

			// Instruction address 0x0000:0x18ef, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].ShieldsCount, 10));

			// Instruction address 0x0000:0x18ff, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4a12);

			// Instruction address 0x0000:0x1932, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((short)0xa * (short)this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((-((short)this.oParent.GameState.Cities[
						this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].CurrentProductionID * 
					0x1e)) + 0xbb2) & 0xffff))),
						10));

			this.oCPU.AX.Word = 0x4a14;

		L193d:
			// Instruction address 0x0000:0x1942, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

		L194a:
			// Instruction address 0x0000:0x1959, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 172, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8));

		L1965:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1968:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x80);
			if (this.oCPU.Flags.L) goto L1972;
			goto L1b69;

		L1972:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L1965;
			
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].PlayerID != playerID)
				goto L1965;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xc0);
			if (this.oCPU.Flags.L) goto L19ab;

			// Instruction address 0x0000:0x1992, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			F14_0000_001c(0x49f0, 8);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x20);

		L19ab:
			// Instruction address 0x0000:0x19b2, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), -1);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x19c2, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			
			// Instruction address 0x0000:0x19d9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 8, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 15);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x1a09, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].ActualSize, 10));

			// Instruction address 0x0000:0x1a19, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_49fc);

			// Instruction address 0x0000:0x1a3a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70da), 10));

			// Instruction address 0x0000:0x1a4a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_49fe);

			// Instruction address 0x0000:0x1a6b, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70dc), 10));

			// Instruction address 0x0000:0x1a7b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4a01);

			// Instruction address 0x0000:0x1a9c, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70de), 10));

			// Instruction address 0x0000:0x1aac, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4a04);

			// Instruction address 0x0000:0x1ac3, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 80, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 15);

			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].CurrentProductionID, 0x0);
			if (this.oCPU.Flags.GE) goto L1ad5;
			goto L1892;

		L1ad5:
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].CurrentProductionID, 0x40);
			if (this.oCPU.Flags.L) goto L1adf;
			goto L194a;

		L1adf:
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].CurrentProductionID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x112a);
			// Instruction address 0x0000:0x1aed, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1afd, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4a06);

			// Instruction address 0x0000:0x1b1e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].ShieldsCount, 10));

			// Instruction address 0x0000:0x1b2e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4a0a);

			// Instruction address 0x0000:0x1b5b, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(0xa * this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(0x22 * this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].CurrentProductionID + 0x1142))), 10));

			this.oCPU.AX.Word = 0x4a0c;
			goto L193d;

		L1b69:
			F14_0000_013b();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F14_0000_186f");
		}
	}
}
