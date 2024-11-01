using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_10
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Overlay_10(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F10_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F10_0000_0000()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x0000:0x000e, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Which army?\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L001b:
			// Instruction address 0x0000:0x0028, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Nationality);

			// Instruction address 0x0000:0x0038, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L001b;

			// Instruction address 0x0000:0x0055, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			F10_0000_0079((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F10_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F10_0000_0079(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F10_0000_0079({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x14);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			TerrainTypeEnum local_c;

			// Instruction address 0x0000:0x0098, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L01c1;

		L00b3:
			// Instruction address 0x0000:0x00c6, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				4, 4, 2);

		L00b6:
			// Instruction address 0x0000:0x00d4, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L00ff;

			// Instruction address 0x0000:0x00e6, size: 5
			this.oParent.MapManagement.F0_2aea_1369_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = this.oParent.Array_1946[this.oCPU.BX.Word / 2];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0159, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				4, 4,
				this.oParent.Array_1946[this.oCPU.BX.Word / 2]);

			goto L0161;

		L00ff:
			// Instruction address 0x0000:0x0105, size: 5
			this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0161;

			// Instruction address 0x0000:0x0116, size: 5
			this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = this.oParent.Array_1946[this.oCPU.BX.Word/2];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x013f, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) + 1,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) + 1,
				3, 3, 0);

			// Instruction address 0x0000:0x0159, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				3, 3,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L0161:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L0164:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.GE) goto L01be;

			if (this.oGameData.Map[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].IsVisibleTo(playerID)) goto L018b;
			
			if (this.oParent.Var_d806 == 0) goto L0161;

		L018b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x01a5, size: 5
			local_c = this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TerrainType;

			if (local_c == TerrainTypeEnum.Water) goto L01b8;
			goto L00b3;

		L01b8:
			// Instruction address 0x0000:0x00c6, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				4, 4, 1);

			goto L00b6;

		L01be:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L01c1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x32);
			if (this.oCPU.Flags.GE) goto L01ce;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L0164;

		L01ce:
			// Instruction address 0x0000:0x01ce, size: 5
			this.oParent.MSCAPI.getch();

			this.oParent.Var_aa_Rectangle.FontID = 2;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L0224;

		L01e3:
			// Instruction address 0x0000:0x01eb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "S");

		L01f3:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x0000:0x0219, size: 5
			this.oParent.DrawStringTools.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe598)) << 2,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe798)) << 2,
				13);

		L0221:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L0224:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x20);
			if (this.oCPU.Flags.GE) goto L0264;
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xe2c2));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Low);
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0xff);
			if (this.oCPU.Flags.E) goto L0221;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L01e3;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0255;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L025a;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.E) goto L025f;
			goto L01f3;

		L0255:
			// Instruction address 0x0000:0x01eb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "A");
			goto L01f3;

		L025a:
			// Instruction address 0x0000:0x01eb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "D");
			goto L01f3;

		L025f:
			// Instruction address 0x0000:0x01eb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "N");
			goto L01f3;

		L0264:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L02ac;

		L026b:
			// Instruction address 0x0000:0x0273, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "S");

		L027b:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x0000:0x02a1, size: 5
			this.oParent.DrawStringTools.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06,
				this.oGameData.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.X << 2,
				this.oGameData.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.Y << 2,
				14);

		L02a9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L02ac:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x10);
			if (this.oCPU.Flags.GE) goto L02e2;
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));

			this.oCPU.AX.Low = (byte)this.oGameData.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Active;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Low);

			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0xff);
			if (this.oCPU.Flags.E) goto L02a9;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L026b;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L02d8;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L02dd;
			goto L027b;

		L02d8:
			// Instruction address 0x0000:0x0273, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "A");

			goto L027b;

		L02dd:
			// Instruction address 0x0000:0x0273, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "D");

			goto L027b;

		L02e2:
			// Instruction address 0x0000:0x02e2, size: 5
			this.oParent.MSCAPI.getch();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L02f1:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			if (this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Attack == 0)
				goto L0453;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0324, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 10));

			// Instruction address 0x0000:0x0334, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "/");

			if (this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Strategy == 0)
			{
				// Instruction address 0x0000:0x0357, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "S");
			}
		
			if (this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Strategy == 2)
			{
				// Instruction address 0x0000:0x037a, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "D");
			}
		
			if (this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Strategy == 1)
			{
				// Instruction address 0x0000:0x039d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "A");
			}
		
			if (this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Strategy == 5)
			{
				// Instruction address 0x0000:0x03c0, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "T");
			}

			// Instruction address 0x0000:0x03d0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x03ff, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Defense, 10));

			// Instruction address 0x0000:0x040f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "/");

			// Instruction address 0x0000:0x0430, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Attack, 10));

			// Instruction address 0x0000:0x0447, size: 5
			this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(0xba06, 2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x6));

		L0453:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xf);
			if (this.oCPU.Flags.GE) goto L045f;
			goto L02f1;

		L045f:
			// Instruction address 0x0000:0x045f, size: 5
			this.oParent.MSCAPI.getch();

			this.oParent.Var_aa_Rectangle.FontID = 1;

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F10_0000_0079");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F10_0000_0477(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F10_0000_0477({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x048b, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x049b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

			// Instruction address 0x0000:0x04bb, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)unitID, 10));

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x04e1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].Name);

			// Instruction address 0x0000:0x04f1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

			// Instruction address 0x0000:0x04ff, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oGameData.Players[playerID].Units[unitID].HomeCityID);

			// Instruction address 0x0000:0x050f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

			// Instruction address 0x0000:0x051f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Loc:");

			// Instruction address 0x0000:0x0543, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].Units[unitID].Position.X, 10));

			// Instruction address 0x0000:0x0553, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ",");

			// Instruction address 0x0000:0x0577, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].Units[unitID].Position.Y, 10));

			// Instruction address 0x0000:0x0587, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

			if(this.oGameData.Players[playerID].Units[unitID].GoToDestination.X == -1)
				goto L060e;

			// Instruction address 0x0000:0x059e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "To:");

			// Instruction address 0x0000:0x05c2, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].Units[unitID].GoToDestination.X, 10));

			// Instruction address 0x0000:0x05d2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ",");

			// Instruction address 0x0000:0x05f6, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y, 10));

			// Instruction address 0x0000:0x0606, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

		L060e:
			// Instruction address 0x0000:0x0616, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "*");

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Players[playerID].Units[unitID].NextUnitID);
			goto L0687;

		L0634:
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0690;

			// Instruction address 0x0000:0x0640, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x200);
			if (this.oCPU.Flags.GE) goto L0690;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x066b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TypeID].Name);

			// Instruction address 0x0000:0x067b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n*");

			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].NextUnitID);

		L0687:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0634;

		L0690:
			// Instruction address 0x0000:0x0699, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 10, 10);

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F10_0000_0477");
		}
	}
}
