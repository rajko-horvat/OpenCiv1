using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_2c84
	{
		private CivGame oParent;
		private VCPU oCPU;

		// Local variables used exclusively inside this section
		private short Var_654a = 0;

		public Segment_2c84(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// Shows and handles one of the five top menus: Game, Orders, Advisors, World and Civilopedia.
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="menuIndex">Index of specific menu to show or -1 to select menu using current mouse X coordinate</param>
		public void F0_2c84_0000_ShowTopMenu(short playerID, short unitID, short menuIndex)
		{
			this.oCPU.Log.EnterBlock($"F0_2c84_0000_ShowTopMenu({playerID}, {unitID}, {menuIndex})");

			// function body
			this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xd4ca, -1);
			this.Var_654a = 0;

            if (menuIndex == -1)
			{
				// Instruction address 0x2c84:0x0026, size: 5
				menuIndex = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((short)this.oParent.Var_db3c_MouseXPos / 60, 0, 4);
			}
		
			// Instruction address 0x2c84:0x0031, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x2c84:0x003b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			switch (menuIndex)
			{
				case 0:
					// Instruction address 0x2c84:0x005e, size: 3
					F0_2c84_00ad_GameMenu();
					break;

				case 1:
					// Instruction address 0x2c84:0x006a, size: 3
					F0_2c84_01d8_OrdersMenu(playerID, unitID);
					break;

				case 2:
					// Instruction address 0x2c84:0x0073, size: 3
					F0_2c84_0615_AdvisorsMenu();
					break;

				case 3:
					// Instruction address 0x2c84:0x0079, size: 3
					F0_2c84_06e4_ShowWorldMenu();
					break;

				case 4:
					// Instruction address 0x2c84:0x007f, size: 3
					F0_2c84_07af_CivilopediaMenu();
					break;
			}

			// Instruction address 0x2c84:0x0082, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			if (this.Var_654a == 1)
			{
				// Instruction address 0x2c84:0x0094, size: 5
				this.oParent.Segment_1238.F0_1238_1b44();
			}
		
			if (this.Var_654a == 0)
			{
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);
			}
		
			// Instruction address 0x2c84:0x00a6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_0000_ShowTopMenu");
		}

		/// <summary>
		/// Shows game menu and handles its options submenu
		/// </summary>
		private void F0_2c84_00ad_GameMenu()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_00ad_GameMenu()");

			// function body
			if (oParent.CivState.TurnCount == 0)
			{
				// Disable 'Save Game' option
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x10);
			}

			// Instruction address 0x2c84:0x00c8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Tax Rate\n Luxuries Rate\n FindCity\n Options\n Save Game\n REVOLUTION!\n \n Retire\n QUIT to DOS\n");

			if (((ushort)this.oParent.CivState.SpaceshipFlags & 0x100) != 0)
			{
				// Instruction address 0x2c84:0x00e0, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " View Replay\n");
			}

			// Instruction address 0x2c84:0x00f4, size: 5
			var selectedOption = this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 16, 8, 0);

			// Instruction address 0x2c84:0x00ff, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			switch (selectedOption)
			{
				case 0: // Tax Rate
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x3d);
					break;

				case 1: // Luxuries
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x2d);
					break;

				case 2: // Find City
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x3f);
					break;

				case 3: // Options
					{
						// Instruction address 0x2c84:0x0143, size: 5
						this.oParent.MSCAPI.strcpy(0xba06, "Options:\n Instant Advice\n AutoSave\n End of Turn\n Animations\n Sound\n Enemy Moves\n Civilopedia Text\n Palace\n");

						short index;
						do
						{
							// Write current flags to show as checkmarks in options submenu
							this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd7f2, (ushort)this.oParent.CivState.GameSettingFlags.Value);
							// Process options submenu, return selected option index or -1 if selection was rejected
							index = (short)this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 24, 16, 0);
							if (index == -1)
							{
								continue;
							}

							if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c) == 0)
							{
								oParent.CivState.GameSettingFlags.Value ^= (short)(1 << index);
							}

							if (index != -1)
							{
								this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x2f9a, index);
							}
						}
						while (index != -1 || this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c) != 0);


					}
					break;

				case 4: // Save Game
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x53);
					break;

				case 5: // Revolution
					this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xd4ca, -2);
					break;

				case 6: // Empty option line
					break;

				case 7: // Retire
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x2);
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x1000);
					break;

				case 8: // Quit
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x1);
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x1000);
					break;

				case 9: // View replay
					this.oParent.GameReplay.F9_0000_0000();
					break;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_00ad_GameMenu");
		}

		/// <summary>
		/// Shows orders menu
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_2c84_01d8_OrdersMenu(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2c84_01d8_OrdersMenu({playerID}, {unitID})");

			// function body
			if (unitID < 0 || unitID >= 128)
			{
				// Far return
				this.oCPU.Log.ExitBlock("F0_2c84_01d8_OrdersMenu");
				return;
			}

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			Unit unit = this.oParent.CivState.Players[playerID].Units[unitID];
			ushort xPos = (ushort)unit.Position.X;
			ushort yPos = (ushort)unit.Position.Y;

			// Instruction address 0x2c84:0x0221, size: 5
			TerrainImprovementFlagsEnum improvements = this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(xPos, yPos);

			// Instruction address 0x2c84:0x0232, size: 5
			ushort terrainID = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(xPos, yPos);

			int orderCount = 0;
			char[] orders = new char[15];

			// Instruction address 0x2c84:0x0245, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " No Orders \x008fspace\n");
			orders[orderCount++] = ' ';

			// All orders are enabled by default
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x0);

			if (unit.TypeID == (short)UnitTypeEnum.Settlers)
			{
				if (improvements.HasFlag(TerrainImprovementFlagsEnum.City))
				{
					// Instruction address 0x2c84:0x027a, size: 5
					this.oParent.MSCAPI.strcat(0xba06, " Add to City \x008fb\n");
				}
				else
				{
					// Instruction address 0x2c84:0x027a, size: 5
					this.oParent.MSCAPI.strcat(0xba06, " Found New City \x008fb\n");
				}

				orders[orderCount++] = 'b';

				if (!improvements.HasFlag(TerrainImprovementFlagsEnum.Road))
				{
					// Instruction address 0x2c84:0x029a, size: 5
					this.oParent.MSCAPI.strcat(0xba06, " Build Road \x008fr\n");
					orders[orderCount++] = 'r';
				}
				else
				{
					// Instruction address 0x2c84:0x02bb, size: 5
					if (!improvements.HasFlag(TerrainImprovementFlagsEnum.RailRoad) && this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Railroad) != 0)
					{
						// Instruction address 0x2c84:0x02cf, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " Build RailRoad \x008fr\n");
						orders[orderCount++] = 'r';
					}
				}

				if (!improvements.HasFlag(TerrainImprovementFlagsEnum.Irrigation))
				{
					if (this.oParent.CivState.TerrainModifications[terrainID].IrrigationEffect == -2)
					{
						// Instruction address 0x2c84:0x0301, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " Build Irrigation");

						// Instruction address 0x2c84:0x030f, size: 5
						if (this.oParent.Segment_1403.F0_1403_3fd0(xPos, yPos) == 0)
						{
							// Disable 'Build Irrigation' option
							this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276), (ushort)(1 << orderCount)));
						}
					}
					else
					{
						if (this.oParent.CivState.TerrainModifications[terrainID].IrrigationEffect >= 0)
						{
							// Instruction address 0x2c84:0x0342, size: 5
							this.oParent.MSCAPI.strcat(0xba06, " Change to ");

							// Instruction address 0x2c84:0x035d, size: 5
							this.oParent.MSCAPI.strcat(0xba06,
								this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.DS.Word,
									(ushort)(0x2ba6 + this.oParent.CivState.TerrainModifications[terrainID].IrrigationEffect * 2))].Name);
						}
					}

					if (this.oParent.CivState.TerrainModifications[terrainID].IrrigationEffect != -1)
					{
						// Instruction address 0x2c84:0x0386, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " \x008fi\n");
						orders[orderCount++] = 'i';
					}
				}

				if (!improvements.HasFlag(TerrainImprovementFlagsEnum.Mines))
				{
					if (this.oParent.CivState.TerrainModifications[terrainID].MiningEffect <= -2)
					{
						// Instruction address 0x2c84:0x03dc, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " Build Mines");
					}
					else if (this.oParent.CivState.TerrainModifications[terrainID].MiningEffect >= 0)
					{
						// Instruction address 0x2c84:0x03c1, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " Change to ");

						// Instruction address 0x2c84:0x03dc, size: 5
						this.oParent.MSCAPI.strcat(0xba06,
							this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(0x2ba6 + this.oParent.CivState.TerrainModifications[terrainID].MiningEffect * 2))].Name);
					}

					if (this.oParent.CivState.TerrainModifications[terrainID].MiningEffect != -1)
					{
						// Instruction address 0x2c84:0x0405, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " \x008fm\n");
						orders[orderCount++] = 'm';
					}
				}

				if (improvements.HasFlag(TerrainImprovementFlagsEnum.Pollution))
				{
					// Instruction address 0x2c84:0x041b, size: 5
					this.oParent.MSCAPI.strcat(0xba06, " Clean up Pollution \x008fp\n");
					orders[orderCount++] = 'p';
				}
			}

			if (unit.TypeID == (short)UnitTypeEnum.Settlers)
			{
				// Instruction address 0x2c84:0x044c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Build Fortress \x008ff\n");

				// Instruction address 0x2c84:0x045b, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Construction) == 0)
				{
					// Disable 'Build Fortress' option
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276), (ushort)(1 << orderCount)));
				}
			}
			else if (this.oParent.CivState.UnitDefinitions[unit.TypeID].UnitCategory == UnitCategoryEnum.Land)
			{
				// Instruction address 0x2c84:0x049c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Fortify \x008ff\n");
			}

			if (this.oParent.CivState.UnitDefinitions[unit.TypeID].UnitCategory == UnitCategoryEnum.Land)
			{
				orders[orderCount++] = 'f';
			}

			// Instruction address 0x2c84:0x04d5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Wait \x008fw\n Sentry \x008fs\n GoTo\n");

			orders[orderCount++] = 'w';
			orders[orderCount++] = 's';
			orders[orderCount++] = 'g';

			if (((ushort)improvements & (ushort)TerrainImprovementFlagsEnum.PillageMask) != 0 && unit.TypeID < (short)UnitTypeEnum.Diplomat && unit.TypeID != (short)UnitTypeEnum.Fighter)
			{
				// Instruction address 0x2c84:0x0528, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Pillage \x008fP\n");
				orders[orderCount++] = 'P';
			}

			if (improvements.HasFlag(TerrainImprovementFlagsEnum.City))
			{
				// Instruction address 0x2c84:0x0548, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Home City \x008fh\n");
				orders[orderCount++] = 'h';
			}

			// Instruction address 0x2c84:0x05a4, size: 5
			if ((this.oParent.CivState.UnitDefinitions[unit.TypeID].AIRole == UnitAIRoleEnum.SeaTransport || unit.TypeID == (short)UnitTypeEnum.Carrier) && unit.NextUnitID != -1)
			{
				// Instruction address 0x2c84:0x05a4, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Unload \x008fu\n");
				orders[orderCount++] = 'u';
			}

			// Instruction address 0x2c84:0x05be, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " \n Disband Unit \x008fD\n");

			// Empty option line does not use hotkey
			orders[orderCount++] = '\0';
			orders[orderCount++] = 'D';

			// Instruction address 0x2c84:0x05e6, size: 5
			short selectedOrder = (short)this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 72, 8, 0);

			if (selectedOrder < 0 || selectedOrder >= orderCount)
			{
				this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xd4ca, -1);
			}
			else
			{
				this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xd4ca, (short)orders[selectedOrder]);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_01d8_OrdersMenu");
		}

		/// <summary>
		/// Shows advisors menu
		/// </summary>
		private void F0_2c84_0615_AdvisorsMenu()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_0615_AdvisorsMenu()");

			// function body
			// Instruction address 0x2c84:0x0623, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " City Status (F1)\n Military Advisor (F2)\n Intelligence Advisor (F3)\n Attitude Advisor (F4)\n");

			// Instruction address 0x2c84:0x0633, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Trade Advisor (F5)\n Science Advisor (F6)\n");

			// Instruction address 0x2c84:0x0647, size: 5
			ushort selectedOption = this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 112, 8, 0);

			// Instruction address 0x2c84:0x0652, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x2c84:0x065c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			Var_654a = -1;

			switch (selectedOption)
			{
				case 0: // City Status
					this.oParent.Overlay_14.F14_0000_186f_CityStatus(this.oParent.CivState.HumanPlayerID);
					break;

				case 1: // Military Advisor
					if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806) == 0)
					{
						this.oParent.Overlay_14.F14_0000_03ad_MilitaryStatus(this.oParent.CivState.HumanPlayerID);
					}
					else
					{
						this.oParent.Overlay_13.F13_0000_0554();
					}
					break;

				case 2: // Intelligence Advisor
					this.oParent.Overlay_14.F14_0000_0d43_IntelligenceReport();
					break;

				case 3: // Attitude Advisor
					this.oParent.Overlay_14.F14_0000_15f4_AttitudeSurvey(this.oParent.CivState.HumanPlayerID);
					break;

				case 4: // Trade Advisor
					this.oParent.Overlay_14.F14_0000_07f1_TradeReport(this.oParent.CivState.HumanPlayerID);
					break;

				case 5: // Science Advisor
					this.oParent.Overlay_14.F14_0000_014b_ScienceReport(this.oParent.CivState.HumanPlayerID);
					break;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_0615_AdvisorsMenu");
		}

		/// <summary>
		/// Shows world menu
		/// </summary>
		private void F0_2c84_06e4_ShowWorldMenu()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_06e4_ShowWorldMenu()");

			// function body
			if ((this.oParent.CivState.SpaceshipFlags & 0xfe00) == 0)
			{
				// Disable 'SpaceShips' option
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x20);
			}

			// Instruction address 0x2c84:0x0700, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Wonders of the World (F7)\n Top 5 Cities (F8)\n Civilization Score (F9)\n");

			// Instruction address 0x2c84:0x0710, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " World Map (F10)\n Demographics\n SpaceShips\n");

			// Instruction address 0x2c84:0x0724, size: 5
			ushort selectedOption = this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 144, 8, 0);

			// Instruction address 0x2c84:0x072f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x2c84:0x0739, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0xffff);

			switch (selectedOption)
			{
				case 0: // Wonders of the World
					this.oParent.WorldMap.F12_0000_080d_ShowWondersOfTheWorldPopup();
					break;

				case 1: // Top 5 Cities
					this.oParent.HallOfFame.F3_0000_09ac_ShowTopFiveCitiesPopup();
					break;

				case 2: // Civilization Score
					this.oParent.Overlay_20.F20_0000_0ca9_ShowCivilizationScorePopup(this.oParent.CivState.HumanPlayerID, true);
					break;

				case 3: // World Map
					this.oParent.WorldMap.F12_0000_0000_ShowWorldMapPopup(1);
					break;

				case 4: // Demographics
					this.oParent.WorldMap.F12_0000_0d6d_ShowsDemographicsPopup(this.oParent.CivState.HumanPlayerID);
					break;

				case 5: // SpaceShips
					this.oParent.Overlay_18.F18_0000_1527_ShowSpaceshipNationDialog();
					break;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_06e4_ShowWorldMenu");
		}

		/// <summary>
		/// Shows civilopedia menu
		/// </summary>
		private void F0_2c84_07af_CivilopediaMenu()
		{
			this.oCPU.Log.EnterBlock("F0_2c84_07af_CivilopediaMenu()");

			// function body
			// Instruction address 0x2c84:0x07bd, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Complete\n Civilization Advances\n City Improvements\n Military Units\n Terrain Types\n");

			// Instruction address 0x2c84:0x07cd, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Miscellaneous\n");

			// Instruction address 0x2c84:0x07e1, size: 5
			short selectedOption = (short)this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 182, 8, 0);
			if (selectedOption < 0)
			{
				this.Var_654a = 1;
			}
			else
			{
				this.oParent.Civilopedia.F8_0000_0000_ShowCivilopedia((short)(selectedOption - 1));
				this.Var_654a = -1;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2c84_07af_CivilopediaMenu");
		}
	}
}
