using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_2c84
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Segment_2c84(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="flag"></param>
		public void F0_2c84_0000(short playerID, short unitID, short flag)
		{
			this.oCPU.Log.EnterBlock($"F0_2c84_0000({playerID}, {unitID}, {flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0x0);

			if (flag == -1)
			{
				// Instruction address 0x2c84:0x0026, size: 5
				flag = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_db3c / 60, 0, 4);
			}
		
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			switch (flag)
			{
				case 0:
					// Instruction address 0x2c84:0x005e, size: 3
					F0_2c84_00ad();
					break;

				case 1:
					// Instruction address 0x2c84:0x006a, size: 3
					F0_2c84_01d8(playerID, unitID);
					break;

				case 2:
					// Instruction address 0x2c84:0x0073, size: 3
					F0_2c84_0615();
					break;

				case 3:
					// Instruction address 0x2c84:0x0079, size: 3
					F0_2c84_06e4();
					break;

				case 4:
					// Instruction address 0x2c84:0x007f, size: 3
					F0_2c84_07af();
					break;
			}

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x654a);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0099;
			this.oCPU.DX.Word = this.oCPU.OR_UInt16(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0099;

			// Instruction address 0x2c84:0x0094, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

		L0099:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x654a);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DX.Word = this.oCPU.OR_UInt16(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L00a6;

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L00a6:
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2c84_00ad()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_00ad()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);

			if (oParent.GameData.TurnCount != 0) goto L00c0;
			this.oParent.Var_b276 = 0x10;

		L00c0:
			// Instruction address 0x2c84:0x00c8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Tax Rate\n Luxuries Rate\n FindCity\n Options\n Save Game\n REVOLUTION!\n \n Retire\n QUIT to DOS\n");

			this.oCPU.TEST_UInt16((ushort)this.oGameData.SpaceshipFlags, 0x100);
			if (this.oCPU.Flags.E) goto L00e8;

			// Instruction address 0x2c84:0x00e0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " View Replay\n");

		L00e8:
			// Instruction address 0x2c84:0x00f4, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 16, 8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			// Instruction address 0x2c84:0x00ff, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.BE) goto L010f;
			goto L01d4;

		L010f:
			switch(this.oCPU.AX.Word)
			{
				case 0:
					goto L0120;
				case 1:
					goto L0129;
				case 2:
					goto L0132;
				case 3:
					goto L013b;
				case 4:
					goto L019b;
				case 5:
					goto L0117;
				case 6:
					goto L01d4;
				case 7:
					goto L01a3;
				case 8:
					goto L01b1;
				case 9:
					goto L01b9;
			}

		L0117:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0xfffe);
			goto L01d4;

		L0120:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x3d);
			goto L01d4;

		L0129:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x2d);
			goto L01d4;

		L0132:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x3f);
			goto L01d4;

		L013b:
			// Instruction address 0x2c84:0x0143, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Options:\n Instant Advice\n AutoSave\n End of Turn\n Animations\n Sound\n Enemy Moves\n Civilopedia Text\n Palace\n");

		L014b:
			this.oParent.MenuBoxDialog.Var_d7f2 = this.oGameData.GameSettingFlags;

			// Instruction address 0x2c84:0x015d, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 24, 16, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0180;

			if (this.oParent.Var_2f9c != 0) goto L0180;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			oParent.GameData.GameSettingFlags ^= (short)this.oCPU.AX.Word;

		L0180:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
			if (this.oCPU.Flags.E) goto L018c;

			this.oParent.Var_2f9a = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));

		L018c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
			if (this.oCPU.Flags.NE) goto L014b;

			if (this.oParent.Var_2f9c != 0) goto L014b;
			goto L01d4;

		L019b:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x53);
			goto L01d4;

		L01a3:
			this.oParent.Var_dc48 = 2;

		L01a9:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x1000);
			goto L01d4;

		L01b1:
			this.oParent.Var_dc48 = 1;
			goto L01a9;

		L01b9:
			this.oParent.GameReplay.F9_0000_0000();

		L01d4:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_00ad");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_2c84_01d8(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2c84_01d8({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x30);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			TerrainTypeEnum local_2a;

			if (unitID != -1) goto L01e9;
			goto L060f;

		L01e9:
			if (unitID != 128) goto L01f3;
			goto L060f;

		L01f3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Players[playerID].Units[unitID].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			// Instruction address 0x2c84:0x0221, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);

			// Instruction address 0x2c84:0x0232, size: 5
			local_2a = this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].TerrainType;

			// Instruction address 0x2c84:0x0245, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " No Orders \x008fspace\n");

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x22), 0x20);
			this.oParent.Var_b276 = 0;

			if (this.oGameData.Players[playerID].Units[unitID].TypeID != 0)
				goto L042d;

			if ((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)) & 1) != 0)
			{
				// Instruction address 0x2c84:0x027a, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Add to City \x008fb\n");
			}
			else
			{
				// Instruction address 0x2c84:0x027a, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Found New City \x008fb\n");
			}

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x22), 0x62);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x8);
			if (this.oCPU.Flags.NE) goto L02ae;

			// Instruction address 0x2c84:0x029a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Build Road \x008fr\n");

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x22), 0x72);
			goto L02e1;

		L02ae:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x10);
			if (this.oCPU.Flags.NE) goto L02e1;

			// Instruction address 0x2c84:0x02bb, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Railroad);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L02e1;

			// Instruction address 0x2c84:0x02cf, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Build RailRoad \x008fr\n");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x72);

		L02e1:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x2);
			if (this.oCPU.Flags.E) goto L02ea;
			goto L038e;

		L02ea:
			if (this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi1 != -2)
				goto L0329;

			// Instruction address 0x2c84:0x0301, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Build Irrigation");

			// Instruction address 0x2c84:0x030f, size: 5
			this.oParent.Segment_1403.F0_1403_3fd0(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0365;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);

			this.oParent.Var_b276 |= this.oCPU.AX.Word;
			goto L0365;

		L0329:
			if (this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi1 >= 0)
			{
				// Instruction address 0x2c84:0x0342, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Change to ");

				// Instruction address 0x2c84:0x035d, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oGameData.Static.Terrains.GetValueByKey(TerrainMap.ValueToTerrainTypeEnum(this.oParent.Array_2ba6[this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi1])).Name);
			}

		L0365:
			if (this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi1 == -1)
				goto L038e;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x69);

			// Instruction address 0x2c84:0x0386, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " \x008fi\n");

		L038e:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x4);
			if (this.oCPU.Flags.NE) goto L040d;

			if (this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi3 > -2)
				goto L03a8;
			
			// Instruction address 0x2c84:0x03dc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Build Mines");

			goto L03e4;

		L03a8:
			if (this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi3 >= 0)
			{
				// Instruction address 0x2c84:0x03c1, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Change to ");

				// Instruction address 0x2c84:0x03dc, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oGameData.Static.Terrains.GetValueByKey(TerrainMap.ValueToTerrainTypeEnum(this.oParent.Array_2ba6[this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi3])).Name);
			}

		L03e4:
			if (this.oGameData.Static.Terrains.GetValueByKey(local_2a).Multi3 != -1)
			{
				this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x6d);

				// Instruction address 0x2c84:0x0405, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " \x008fm\n");
			}

		L040d:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x40);
			if (this.oCPU.Flags.E) goto L042d;

			// Instruction address 0x2c84:0x041b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Clean up Pollution \x008fp\n");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x70);

		L042d:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Players[playerID].Units[unitID].TypeID != 0)
				goto L0475;

			// Instruction address 0x2c84:0x044c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Build Fortress \x008ff\n");

			// Instruction address 0x2c84:0x045b, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Construction);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L04a4;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);

			this.oParent.Var_b276 |= this.oCPU.AX.Word;

			goto L04a4;

		L0475:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oGameData.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
			{
				// Instruction address 0x2c84:0x049c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Fortify \x008ff\n");
			}

		L04a4:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oGameData.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
			{
				this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x66);
			}

			// Instruction address 0x2c84:0x04d5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Wait \x008fw\n Sentry \x008fs\n GoTo\n");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x77);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x73);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x67);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x1e);
			if (this.oCPU.Flags.E) goto L053a;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30),
				(short)this.oGameData.Players[playerID].Units[unitID].TypeID);

			if (this.oGameData.Players[playerID].Units[unitID].TypeID < 26 &&
				this.oGameData.Players[playerID].Units[unitID].TypeID != 14)
			{
				// Instruction address 0x2c84:0x0528, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Pillage \x008fP\n");

				this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
					this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x50);
			}

		L053a:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x1);
			if (this.oCPU.Flags.E) goto L055a;

			// Instruction address 0x2c84:0x0548, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Home City \x008fh\n");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x68);

		L055a:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30),
				(short)this.oGameData.Players[playerID].Units[unitID].TypeID);

			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMUL_UInt8(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oCPU.ReadInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30))].UnitCategory == 5)
				goto L0585;

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)), 0x17);
			if (this.oCPU.Flags.NE) goto L05b6;

		L0585:
			if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2c84:0x05a4, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Unload \x008fu\n");

				this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
					this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x75);
			}

		L05b6:
			// Instruction address 0x2c84:0x05be, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " \n Disband Unit \x008fD\n");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x0);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x44);

			// Instruction address 0x2c84:0x05e6, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 72, 8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0609;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0609;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, this.oCPU.AX.Word);
			goto L060f;

		L0609:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0xffff);

		L060f:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_01d8");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2c84_0615()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_0615()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x2c84:0x0623, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " City Status (F1)\n Military Advisor (F2)\n Intelligence Advisor (F3)\n Attitude Advisor (F4)\n");

			// Instruction address 0x2c84:0x0633, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Trade Advisor (F5)\n Science Advisor (F6)\n");

			// Instruction address 0x2c84:0x0647, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 112, 8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0xffff);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L06ca;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0694;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L06b4;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.E) goto L06bf;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.E) goto L0689;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5);
			if (this.oCPU.Flags.E) goto L06d5;

			goto L06e0;

		L0689:
			this.oParent.Overlay_14.F14_0000_07f1(this.oGameData.HumanPlayerID);

			goto L06e0;


		L0694:
			if (this.oParent.Var_d806 == 0) goto L06a9;

			this.oParent.Overlay_13.F13_0000_0554();

			goto L06e0;

		L06a9:
			this.oParent.Overlay_14.F14_0000_03ad(this.oGameData.HumanPlayerID);

			goto L06e0;

		L06b4:
			this.oParent.Overlay_14.F14_0000_0d43();

			goto L06e0;

		L06bf:
			this.oParent.Overlay_14.F14_0000_15f4(this.oGameData.HumanPlayerID);

			goto L06e0;

		L06ca:
			this.oParent.Overlay_14.F14_0000_186f(this.oGameData.HumanPlayerID);

			goto L06e0;

		L06d5:
			this.oParent.Overlay_14.F14_0000_014b(this.oGameData.HumanPlayerID);

		L06e0:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_0615");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2c84_06e4()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_06e4()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.TEST_UInt16((ushort)this.oGameData.SpaceshipFlags, 0xfe00);
			if (this.oCPU.Flags.NE) goto L06f8;

			this.oParent.Var_b276 = 0x20;

		L06f8:
			// Instruction address 0x2c84:0x0700, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Wonders of the World (F7)\n Top 5 Cities (F8)\n Civilization Score (F9)\n");

			// Instruction address 0x2c84:0x0710, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " World Map (F10)\n Demographics\n SpaceShips\n");

			// Instruction address 0x2c84:0x0724, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 144, 8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0xffff);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0766;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L078f;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L077b;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.E) goto L0796;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.E) goto L076d;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5);
			if (this.oCPU.Flags.E) goto L07a6;
			goto L07ab;

		L0766:
			this.oParent.WorldMap.F12_0000_080d();

			goto L07ab;

		L076d:
			this.oParent.WorldMap.F12_0000_0d6d(this.oGameData.HumanPlayerID);

			goto L07ab;

		L077b:
			this.oParent.Overlay_20.F20_0000_0ca9(this.oGameData.HumanPlayerID, true);

			goto L07ab;

		L078f:
			this.oParent.HallOfFame.F3_0000_09ac();

			goto L07ab;

		L0796:
			this.oParent.WorldMap.F12_0000_0000(1);
			
			goto L07ab;

		L07a6:
			this.oParent.Overlay_18.F18_0000_1527();

		L07ab:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_06e4");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_2c84_07af()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_07af()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x2c84:0x07bd, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Complete\n Civilization Advances\n City Improvements\n Military Units\n Terrain Types\n");

			// Instruction address 0x2c84:0x07cd, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Miscellaneous\n");

			// Instruction address 0x2c84:0x07e1, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 182, 8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0806;

			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oParent.Civilopedia.F8_0000_0000(this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0xffff);
			goto L080c;

		L0806:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0x1);

		L080c:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_07af");
		}
	}
}