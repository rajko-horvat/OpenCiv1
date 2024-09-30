using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System.Diagnostics;

namespace OpenCiv1
{
	public class StartGameMenu
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public StartGameMenu(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F5_0000_0000()");

			// function body
			int local_c;

			// Instruction address 0x0000:0x0007, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0024, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x002c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oParent.Var_aa_Rectangle.FontID = 7;

			// Instruction address 0x0000:0x0042, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Difficulty Level...\n Chieftain (easiest)\n Warlord\n Prince\n King\n Emperor (toughest)\n");

			// Instruction address 0x0000:0x0056, size: 5
			this.oGameData.DifficultyLevel = (short)this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 160, 35, 1);

			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x1a3c) != 0 && this.oParent.Var_2fa2 != 0)
			{
				// Instruction address 0x0000:0x006f, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223();

				if (this.oParent.Var_db3c < 135)
				{
					// Instruction address 0x0000:0x0090, size: 5
					this.oGameData.DifficultyLevel = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((short)this.oParent.Var_db3e - 12) / 35, 0, 4);
				}
			}

			if (this.oGameData.DifficultyLevel == -1)
			{
				this.oGameData.DifficultyLevel = 0;
			}

			// Instruction address 0x0000:0x00a8, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x00c0, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 150, 200, 0);

			if ((this.oGameData.DifficultyLevel & 0x1) != 0)
			{
				// Instruction address 0x0000:0x00fb, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					80, (35 * this.oGameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 20, 100);
			}
			else
			{
				// Instruction address 0x0000:0x00fb, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					21, (35 * this.oGameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 20, 100);
			}

			// Instruction address 0x0000:0x0121, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
				150, 0, 160, 200, this.oParent.Var_aa_Rectangle, 150, 0);

			// Instruction address 0x0000:0x0129, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x0136, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Level of Competition...\n ");

			for (int i = 7; i > 2; i--)
			{
				// Instruction address 0x0000:0x015b, size: 5
				// Instruction address 0x0000:0x016b, size: 5
				this.oParent.MSCAPI.strcat(0xba06, $"{i} Civilizations\n ");
			}

			do
			{
				// Instruction address 0x0000:0x0188, size: 5
				this.oGameData.AIOpponentCount = (short)this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 160, 35, 1);
			}
			while (this.oGameData.AIOpponentCount == -1);

			// Instruction address 0x0000:0x01a8, size: 5
			this.oGameData.AIOpponentCount = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(6 - this.oGameData.AIOpponentCount, 2, 6);
			this.oGameData.ActiveCivilizations = (short)(255 >> (6 - this.oGameData.AIOpponentCount));

			// Instruction address 0x0000:0x01c1, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			for (int i = this.oGameData.AIOpponentCount; i >= 0; i--)
			{
				if ((this.oGameData.DifficultyLevel & 0x1) != 0)
				{
					// Instruction address 0x0000:0x01d6, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
						80, (35 * this.oGameData.DifficultyLevel) + 6, 53, 47,
						this.oParent.Var_aa_Rectangle, (i * 2) + 20, (3 * i) + 100);
				}
				else
				{
					// Instruction address 0x0000:0x01d6, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
						21, (35 * this.oGameData.DifficultyLevel) + 6, 53, 47,
						this.oParent.Var_aa_Rectangle, (i * 2) + 20, (3 * i) + 100);
				}
			}

			this.oGameData.Year = -4000;
			this.oGameData.DebugFlags = 0xf;

			this.oGameData.GameSettingFlags = 0xfa;

			if (this.oCPU.ReadInt8(this.oCPU.DS.Word, 0x1a30) == 78)
			{
				this.oGameData.GameSettingFlags &= 0x7fef;
			}

			// Instruction address 0x0000:0x0311, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Pick your tribe...\n ");

			for (int i = 1; i < this.oGameData.AIOpponentCount + 2; i++)
			{
				// Instruction address 0x0000:0x033d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Nations[i].Nationality);

				// Instruction address 0x0000:0x034d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\n ");
			}

			for (int i = 1; i < this.oGameData.AIOpponentCount + 2; i++)
			{
				// Instruction address 0x0000:0x0377, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Nations[i + 8].Nationality);

				// Instruction address 0x0000:0x0387, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\n ");
			}

			// Instruction address 0x0000:0x03ba, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 150, 0, 160, 200, this.oParent.Var_aa_Rectangle, 150, 0);

			// Instruction address 0x0000:0x03c2, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x03d3, size: 5
			this.oGameData.HumanPlayerID = (short)this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 160, 35, 1);

			if (this.oGameData.HumanPlayerID <= this.oGameData.AIOpponentCount)
			{
				this.oGameData.HumanPlayerID++;
			}
			else
			{
				this.oGameData.HumanPlayerID = (short)((this.oGameData.HumanPlayerID - this.oGameData.AIOpponentCount) + 8);
			}

			if (this.oGameData.DifficultyLevel == 0)
			{
				this.oGameData.GameSettingFlags |= 1;
			}

			// Another indexing error. Value this.oParent.GameState.HumanPlayerID is equal
			// to nationality selected and not actual ID, but later in code it is forced to 0-7 by value & 7,
			// so we will use this value instead
			this.oGameData.Players[this.oGameData.HumanPlayerID & 7].CurrentResearchID = -1;

			// Instruction address 0x0000:0x0410, size: 5
			this.oGameData.NextAnthologyTurn += (short)this.oParent.MSCAPI.RNG.Next(50);

			for (int i = 0; i < 12; i++)
			{
				this.oGameData.Players[this.oGameData.HumanPlayerID & 7].PalaceData1[i + 2] = -1;
				this.oGameData.Players[this.oGameData.HumanPlayerID & 7].PalaceData2[i] = 0;
			}

			for (int i = 3; i < 6; i++)
			{
				this.oGameData.Players[this.oGameData.HumanPlayerID & 7].PalaceData1[i + 2] = 0;
				this.oGameData.Players[this.oGameData.HumanPlayerID & 7].PalaceData1[i + 8] = 0;
			}

			if (this.oGameData.HumanPlayerID != 0)
			{
				if (this.oGameData.HumanPlayerID > 7)
				{
					local_c = 1;
				}
				else
				{
					local_c = 0;
				}

				this.oGameData.HumanPlayerID &= 7;
			}
			else
			{
				local_c = -1;

				// Instruction address 0x0000:0x047f, size: 5
				this.oGameData.HumanPlayerID = (short)(this.oParent.MSCAPI.RNG.Next(this.oGameData.AIOpponentCount) + 1);
			}

			this.oGameData.Players[this.oGameData.HumanPlayerID].Nationality = "";

			if (local_c == -1)
			{
				this.oParent.Overlay_23.F23_0000_0173();

				this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID = this.oGameData.HumanPlayerID;

				// Instruction address 0x0000:0x0569, size: 5
				this.oGameData.Players[this.oGameData.HumanPlayerID].Name =
					this.oGameData.Static.Nations[this.oGameData.HumanPlayerID].Leader;
			}
			else
			{
				if (local_c != 0)
				{
					this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID = (short)(this.oGameData.HumanPlayerID + 8);
				}
				else
				{
					this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID = this.oGameData.HumanPlayerID;
				}

				// Instruction address 0x0000:0x04ec, size: 5
				this.oGameData.Players[this.oGameData.HumanPlayerID].Name =
					this.oGameData.Static.Nations[this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID].Leader;

				// Instruction address 0x0000:0x0509, size: 5
				this.oGameData.Players[this.oGameData.HumanPlayerID].Nationality =
					this.oGameData.Static.Nations[this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID].Nationality;

				// Instruction address 0x0000:0x0526, size: 5
				this.oParent.MSCAPI.strcpy(0xba06,
					this.oGameData.Static.Nations[this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID].Nation);

				if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06) == 0)
				{
					// Instruction address 0x0000:0x0543, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Nationality);

					// Instruction address 0x0000:0x0553, size: 5
					this.oParent.MSCAPI.strcat(0xba06, "s");
				}

				// Instruction address 0x0000:0x0569, size: 5
				this.oGameData.Players[this.oGameData.HumanPlayerID].Nation = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);
			}

			// Instruction address 0x0000:0x0587, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(
				this.oGameData.Players[this.oGameData.HumanPlayerID].Nation,
				46, 92, 15);

			for (int i = 0; i < 8; i++)
			{
				F5_0000_07c7((short)i);

				for (int j = 0; j < 8; j++)
				{
					this.oGameData.Players[i].UnitsDestroyed[j] = 0;
				}
			}

			F5_0000_0fe6();

			this.oGameData.PlayerFlags = (short)(1 << this.oGameData.HumanPlayerID);
			this.oGameData.Players[this.oGameData.HumanPlayerID].TaxRate = 5;
			this.oGameData.Players[this.oGameData.HumanPlayerID].ScienceTaxRate = 5;

			if (this.oGameData.DifficultyLevel == 0)
			{
				this.oGameData.Players[this.oGameData.HumanPlayerID].Coins = 50;
			}

			oParent.GameData.PlayerIdentityFlags = 0;

			for (int i = 0; i < 8; i++)
			{
				if (this.oGameData.Players[i].NationalityID >= 8)
				{
					oParent.GameData.PlayerIdentityFlags |= (short)(1 << i);
				}
			}

			// Instruction address 0x0000:0x062a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0645, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 150, 0, 170, 200, 0);

			this.oParent.Overlay_23.F23_0000_00d6();

			// Instruction address 0x0000:0x0652, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x066e, size: 5
			this.oParent.Array_30b8[3] = this.oGameData.Players[this.oGameData.HumanPlayerID].Name;

			// Instruction address 0x0000:0x0684, size: 5
			this.oParent.Array_30b8[0] = this.oGameData.Players[this.oGameData.HumanPlayerID].Nation;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0695, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x35c3);

			for (int i = 0, j = 0; i < 72; i++)
			{
				// Instruction address 0x0000:0x06bd, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, i) != 0)
				{
					// Instruction address 0x0000:0x06d7, size: 5
					this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Technologies[i].Name);

					// Instruction address 0x0000:0x06e7, size: 5
					this.oParent.MSCAPI.strcat(0xba06, ", ");

					j++;

					if (j == 2)
					{
						// Instruction address 0x0000:0x0700, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "\n");
					}
				}
			}

			// Instruction address 0x0000:0x0719, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "and Roads.\n");

			// Instruction address 0x0000:0x0738, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(
				this.oGameData.Static.Nations[this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID].LongTune, 3);

			// Instruction address 0x0000:0x0740, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0759, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 15);

			// Instruction address 0x0000:0x0761, size: 5
			this.oParent.Segment_1866.F0_1866_260e();

			if ((this.oGameData.DifficultyLevel & 0x1) != 0)
			{
				// Instruction address 0x0000:0x0799, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					80, (35 * this.oGameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 134, 20);
			}
			else
			{
				// Instruction address 0x0000:0x0799, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					21, (35 * this.oGameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 134, 20);
			}

			// Instruction address 0x0000:0x07b0, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(99, 88, 81, 0);

			// Instruction address 0x0000:0x07b8, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x07bd, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F5_0000_07c7(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F5_0000_07c7({playerID})");

			// function body
			int iMapGroupLength = this.oGameData.Map.Groups.Count;
			int local_4;
			int local_6;
			int local_8;
			int local_a;
			int local_e;
			int local_10;
			int local_12;
			int[] local_32 = new int[iMapGroupLength];
			int local_34;

			if (playerID != this.oGameData.HumanPlayerID || this.oGameData.TurnCount == 0)
			{
				this.oGameData.Players[playerID].SpaceshipPopulation = 0;
				this.oGameData.Players[playerID].CumulativeEpicRanking = 0;
				this.oGameData.Players[playerID].DiscoveredTechnologyCount = 0;
				this.oGameData.Players[playerID].ResearchProgress = 0;
				this.oGameData.Players[playerID].Coins = 0;
				this.oGameData.Players[playerID].GovernmentType = 1;
				this.oGameData.Players[playerID].TaxRate = 4;
				this.oGameData.Players[playerID].ScienceTaxRate = 4;

				for (int i = 0; i < iMapGroupLength; i++)
				{
					this.oGameData.Players[playerID].Continents[i].Strategy = 0;
					local_32[i] = 0;

					for (int j = 1; j < this.oGameData.Players.Length; j++)
					{
						local_32[i] += this.oGameData.Players[j].Continents[i].CityCount;
					}
				}

				this.oGameData.Players[playerID].CityCount = 0;
				this.oGameData.Players[playerID].UnitCount = 0;
				this.oGameData.Players[playerID].LandCount = 1;
				this.oGameData.Players[playerID].SettlerCount = 1;
				this.oGameData.Players[playerID].ContactPlayerCountdown = -1;

				for (int i = 0; i < this.oGameData.Players[playerID].TechnologyAcquiredFrom.Length; i++)
				{
					this.oGameData.Players[playerID].TechnologyAcquiredFrom[i] = -1;
				}

				for (int i = 0; i < 128; i++)
				{
					this.oGameData.Players[playerID].Units[i].TypeID = -1;
					this.oGameData.Players[playerID].Units[i].Status = 0;
				}

				this.oCPU.SI.Word = (ushort)playerID;
				this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd20c), 0);
				this.oGameData.Players[playerID].Score = 0;

				if (playerID == this.oGameData.HumanPlayerID)
				{
					// Instruction address 0x0000:0x08f4, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_19e8_Rectangle, 240, 0, 80, 50, 0);
				}

				// Instruction address 0x0000:0x08ff, size: 5
				this.oParent.Segment_25fb.F0_25fb_3223_ClearStrategicLocations(playerID);

				for (int i = 0; i < 8; i++)
				{
					this.oGameData.Players[playerID].Diplomacy[i] = 0;
					this.oGameData.Players[i].Diplomacy[playerID] = 0;
				}

				for (int i = 0; i < 5; i++)
				{
					this.oGameData.Players[playerID].DiscoveredTechnologyFlags[i] = 0;
				}

				if (this.oGameData.TurnCount != 0)
				{
					for (int i = 0; i < 72; i++)
					{
						// Instruction address 0x0000:0x0967, size: 5
						if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, i) != 0 &&
							(this.oGameData.TechnologyFirstDiscoveredBy[i] & 0x7) != 0 &&
							(this.oGameData.TechnologyFirstDiscoveredBy[i] & 0x7) != this.oGameData.HumanPlayerID &&
							this.oParent.MSCAPI.RNG.Next(2) == 0)
						{
							// Instruction address 0x0000:0x09b2, size: 5
							this.oParent.Segment_1ade.F0_1ade_1d2e(playerID, (short)i, playerID);
						}
					}
				}

				if (playerID != 0 && (this.oGameData.ActiveCivilizations & (1 << playerID)) != 0) goto L09dd;
				goto L0e35;

			L09dd:
				if (playerID != this.oGameData.HumanPlayerID)
				{
					if (this.oGameData.TurnCount == 0)
					{
						do
						{
							// Instruction address 0x0000:0x09f9, size: 5
							this.oGameData.Players[playerID].NationalityID = (short)this.oParent.MSCAPI.RNG.Next(16);
							local_e = 1;

							if ((this.oGameData.Players[playerID].NationalityID & 7) != playerID)
							{
								local_e = 0;
							}

							for (int i = 0; i < 8; i++)
							{
								if (i != playerID && this.oGameData.Players[i].NationalityID == this.oGameData.Players[playerID].NationalityID)
								{
									local_e = 0;
								}
							}
						}
						while (local_e == 0);
					}
					else
					{
						this.oGameData.Players[playerID].NationalityID ^= 8;
					}
				}

				bool bFlag = false;

				for (int i = 0; i < this.oGameData.Map.Size.Height && !bFlag; i++)
				{
					for (int j = 0; j < this.oGameData.Map.Size.Width; j++)
					{
						if (this.oGameData.Map[j, i].TerrainType != TerrainTypeEnum.Water)
						{
							bFlag = true;
							break;
						}
					}
				}

				if (!bFlag)
				{
					throw new Exception("Uninitialized map");
				}

				local_34 = 0;

			L0a5e:
				// Instruction address 0x0000:0x0a62, size: 5
				local_8 = this.oParent.MSCAPI.RNG.Next(64) + 8;

				// Instruction address 0x0000:0x0a74, size: 5
				local_a = this.oParent.MSCAPI.RNG.Next(34) + 8;

				// Instruction address 0x0000:0x0a86, size: 5
				local_6 = (short)this.oParent.Segment_2dc4.F0_2dc4_0102(local_8, local_a);

				if (local_6 == -1)
				{
					local_4 = 30;
				}
				else
				{
					// Instruction address 0x0000:0x0abf, size: 5
					local_4 = this.oGameData.Map.GetDistance(local_8, local_a,
						this.oGameData.Cities[local_6].Position.X,
						this.oGameData.Cities[local_6].Position.Y);
				}

				if (oParent.GameData.TurnCount == 0)
				{
					for (int i = 1; i < playerID; i++)
					{
						// Instruction address 0x0000:0x0af2, size: 5
						local_12 = this.oGameData.Map.GetDistance(local_8, local_a,
							this.oGameData.Players[i].Units[0].Position.X,
							this.oGameData.Players[i].Units[0].Position.Y);

						if (local_12 < local_4)
						{
							local_4 = local_12;
						}
					}
				}

				// Instruction address 0x0000:0x0b24, size: 5
				//local_10 = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, local_8 + 80, local_a);
				local_10 = this.oGameData.Map[local_8, local_a].Layer2_PlayerOwnership;

				local_34++;

				if (local_34 <= 2000 || (playerID == this.oGameData.HumanPlayerID && oParent.GameData.TurnCount == 0)) goto L0b4e;
				goto L0c1b;

			L0b4e:
				// Instruction address 0x0000:0x0b54, size: 5
				if (this.oGameData.Map[local_8, local_a].TerrainType != TerrainTypeEnum.Water) goto L0b64;

				goto L0a5e;

			L0b64:
				if (-((local_34 / 32) - 12) <= local_10) goto L0b82;
				goto L0a5e;

			L0b82:
				if (local_4 >= (10 - (local_34 / 64))) goto L0ba2;
				goto L0a5e;

			L0ba2:
				if (this.oGameData.Map.Groups[this.oGameData.Map[local_8, local_a].Layer3_GroupID].BuildSiteCount < 
					-(((this.oGameData.TurnCount / 16) + (local_34 / 64)) - 32))
					goto L0a5e;

				if (this.oGameData.Year <= 0)
					goto L0bf7;

				// Instruction address 0x0000:0x0be2, size: 5
				if (local_32[(short)this.oParent.MapManagement.F0_2aea_1942_GetGroupID(local_8, local_a)] == 0) goto L0bf7;
				goto L0a5e;

			L0bf7:
				// Instruction address 0x0000:0x0c03, size: 5
				// Instruction address 0x0000:0x0c0c, size: 5
				if (this.oParent.MapManagement.F0_2aea_1894(local_8, local_a, this.oGameData.Map[local_8, local_a].TerrainType) == 0) goto L0c1b;

				goto L0a5e;

			L0c1b:
				if (this.oGameData.TurnCount != 0) goto L0c49;
				
				if (!this.oParent.Var_d76a_IsEarthMap) goto L0c49;

				local_8 = this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oGameData.Players[playerID].NationalityID * 2 + 0x35da));
				local_a = this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oGameData.Players[playerID].NationalityID * 2 + 0x35db));

				local_34 = 0;

			L0c49:
				if (this.oGameData.TurnCount == 0) goto L0c8e;
				
				if (this.oGameData.Players[playerID].NationalityID < 8) goto L0c6f;
				if ((this.oGameData.PlayerIdentityFlags & (1 << playerID)) == 0) goto L0c6f;

				local_34 = 2000;

			L0c6f:
				if (this.oGameData.Players[playerID].NationalityID >= 8) goto L0c8e;
				if ((this.oGameData.PlayerIdentityFlags & (1 << playerID)) != 0) goto L0c8e;

				local_34 = 2000;

			L0c8e:
				if (playerID == this.oGameData.HumanPlayerID) goto L0cba;

				this.oGameData.Players[playerID].ScienceTaxRate = 
					(short)(this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Ideology + 3);
				this.oGameData.Players[playerID].TaxRate = (short)(9 - this.oGameData.Players[playerID].ScienceTaxRate);

			L0cba:
				if (-((this.oGameData.DifficultyLevel * 50) - 350) < this.oGameData.TurnCount) goto L0cd3;
				if (local_34 < 2000) goto L0d12;

			L0cd3:
				if (playerID == this.oGameData.HumanPlayerID) goto L0d12;

				this.oGameData.Players[playerID].NationalityID ^= 8;
				this.oGameData.ActiveCivilizations &= (short)(~(1 << playerID));

				if (((1 << this.oGameData.HumanPlayerID) | 0x1) == this.oGameData.ActiveCivilizations)
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 1);
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb884, 1);
				}

				this.oCPU.AX.Word = 0;
				goto L0e66;

			L0d12:
				// Instruction address 0x0000:0x0d26, size: 5
				this.oGameData.Players[playerID].Name =
					this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Leader;

				if (playerID != this.oGameData.HumanPlayerID) goto L0d3f;

				if (!string.IsNullOrEmpty(this.oGameData.Players[playerID].Nationality))
					goto L0dae;

			L0d3f:
				// Instruction address 0x0000:0x0d53, size: 5
				this.oGameData.Players[playerID].Nationality = 
					this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Nationality;

				// Instruction address 0x0000:0x0d6a, size: 5
				this.oParent.MSCAPI.strcpy(0xba06,
					this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Nation);

				if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06) == 0)
				{
					// Instruction address 0x0000:0x0d81, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

					// Instruction address 0x0000:0x0d91, size: 5
					this.oParent.MSCAPI.strcat(0xba06, "s");
				}

				// Instruction address 0x0000:0x0da6, size: 5
				this.oGameData.Players[playerID].Nation = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			L0dae:
				// Instruction address 0x0000:0x0db7, size: 5
				this.oParent.MapManagement.F0_2aea_138c_MapSetCityOwner(local_8, local_a, playerID);

				// Instruction address 0x0000:0x0dcb, size: 5
				this.oParent.Segment_1866.F0_1866_0cf5(playerID, 0, local_8, local_a);
				
				this.oGameData.Players[playerID].XStart = (short)local_8;

				for (int i = 0; i < 128; i++)
				{
					if (this.oGameData.Players[0].Units[i].TypeID != -1)
					{
						// Instruction address 0x0000:0x0e05, size: 5
						if (this.oGameData.Map.GetDistance(local_8, local_a, 
							this.oGameData.Players[0].Units[i].Position.X, this.oGameData.Players[0].Units[i].Position.Y) < 9)
						{
							// Instruction address 0x0000:0x0e18, size: 5
							this.oParent.Segment_1866.F0_1866_0f10(0, (short)i);
						}
					}
				}

				this.oGameData.Players[playerID].DiscoveredTechnologyCount = 1;

			L0e35:
				for (int i = 0; i < 28; i++)
				{
					this.oGameData.Players[playerID].LostUnits[i] = 0;
					this.oGameData.Players[playerID].ActiveUnits[i] = 0;
					this.oGameData.Players[playerID].UnitsInProduction[i] = 0;
				}
				this.oCPU.AX.Word = 0x1;
			}

		L0e66:
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_07c7");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="playerID1"></param>
		public void F5_0000_0e6c_CheckPlayerEndGame(short playerID, short playerID1)
		{
			this.oCPU.Log.EnterBlock($"F5_0000_0e6c_CheckPlayerDestroyed({playerID}, {playerID1})");

			// function body
			if (playerID != 0 && playerID != this.oGameData.HumanPlayerID)
			{
				bool bFlag = true;

				for (int i = 0; i < 128; i++)
				{
					if (this.oGameData.Cities[i].StatusFlag != 0xff && this.oGameData.Cities[i].PlayerID == playerID)
					{
						bFlag = false;
					}
				}

				if (bFlag)
				{
					// Instruction address 0x0000:0x0ec1, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

					// Instruction address 0x0000:0x0ed1, size: 5
					this.oParent.MSCAPI.strcat(0xba06, "\ncivilization\ndestroyed\nby ");

					// Instruction address 0x0000:0x0ee6, size: 5
					this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID1].Nation);

					// Instruction address 0x0000:0x0ef6, size: 5
					this.oParent.MSCAPI.strcat(0xba06, "!\n");

					if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID] & 0x40) != 0)
					{
						this.oParent.Var_2f9e = 5;
					}
					else
					{
						this.oParent.Var_2f9e = 2;
					}

					if (playerID1 == this.oGameData.HumanPlayerID)
					{
						this.oParent.Var_2f9e = 3;
					}

					// Instruction address 0x0000:0x0f32, size: 5
					this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

					// Instruction address 0x0000:0x0f3d, size: 5
					this.oParent.Segment_2459.F0_2459_05ee(playerID);

					// Instruction address 0x0000:0x0f53, size: 5
					this.oParent.Segment_1866.F0_1866_250e_AddReplayData(13, (byte)((sbyte)playerID), (byte)((sbyte)playerID1));

					for (int i = 0; i < 128; i++)
					{
						if (this.oGameData.Players[playerID].Units[i].TypeID != -1)
						{
							// Instruction address 0x0000:0x0f7d, size: 5
							this.oParent.Segment_1866.F0_1866_0f10(playerID, (short)i);
						}
					}

					for (int i = 0; i < 80; i++)
					{
						for (int j = 0; j < 50; j++)
						{
							this.oGameData.Map[i, j].SetVisiblity(playerID, false);
						}
					}

					F5_0000_07c7(playerID);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_0e6c_CheckPlayerDestroyed");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F5_0000_0fe6()
		{
			this.oCPU.Log.EnterBlock("F5_0000_0fe6()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x5e);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			TerrainTypeEnum local_4a;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x0);

		L0ff3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x46), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0x10);
			if (this.oCPU.Flags.L) goto L0ff3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L1010:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].TypeID != -1)
			{
				this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
				this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
				this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.BP.Word);
				this.oCPU.DI.Word = this.oCPU.SUB_UInt16(this.oCPU.DI.Word, 0x5a);

				// Instruction address 0x0000:0x103d, size: 5
				this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
					this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.X,
					this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.Y);

				this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Word);
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
				this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.BP.Word);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x46), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x46))));
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L1010;
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			goto L1206;

		L1069:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x14);
			if (this.oCPU.Flags.GE) goto L1084;

			// Instruction address 0x0000:0x1077, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "moderate");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			goto L10b5;

		L1084:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3e7);
			if (this.oCPU.Flags.E) goto L10a1;

			// Instruction address 0x0000:0x1093, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "far away");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			goto L10b5;

		L10a1:
			// Instruction address 0x0000:0x10a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "isolated");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x4));

		L10b5:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

		L10c3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = TerrainMap.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))];

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x10ee, size: 5
			local_4a = this.oGameData.Map[
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.X + 
					direction.X,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.Y + 
					direction.Y].TerrainType;

			if (local_4a != TerrainTypeEnum.Water) goto L1101;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))));

		L1101:
			if (local_4a != TerrainTypeEnum.Grassland) goto L110a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L110a:
			if (local_4a != TerrainTypeEnum.River) goto L1113;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e))));

		L1113:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
			if (this.oCPU.Flags.LE) goto L10c3;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0x0);
			if (this.oCPU.Flags.E) goto L1127;
			
			// Instruction address 0x0000:0x112f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Coastal ");
			
			goto L112a;

		L1127:
			// Instruction address 0x0000:0x112f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Inland ");

		L112a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x1);
			if (this.oCPU.Flags.LE) goto L1153;

			// Instruction address 0x0000:0x1145, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "river valley on a ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			goto L117e;

		L1153:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.L) goto L116e;

			// Instruction address 0x0000:0x1161, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "grasslands on a ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			goto L117e;

		L116e:
			// Instruction address 0x0000:0x1176, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "plains on a ");

		L117e:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x119a, size: 5
			this.oParent.MapManagement.F0_2aea_195d_GetGroupSize(
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.X,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.Y);

			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x32;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L11da;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L11b4;
			goto L1317;

		L11b4:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L11bc;
			goto L131d;

		L11bc:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L11c4;
			goto L1333;

		L11c4:
			// Instruction address 0x0000:0x11cc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "large continent.");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2));
			goto L11ea;

		L11da:
			// Instruction address 0x0000:0x11e2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "small island.");

		L11ea:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L11f8;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);

		L11f8:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1c), this.oCPU.AX.Word);

		L1203:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1206:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L120f;
			goto L1338;

		L120f:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].TypeID == -1)
				goto L1203;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x18);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x1);

		L1241:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L12c7;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))].Units[0].TypeID == -1)
				goto L12c7;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1274, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))].Units[0].Position.X,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))].Units[0].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x128b, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.X,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e)));
			if (this.oCPU.Flags.NE) goto L12c7;

			// Instruction address 0x0000:0x12ae, size: 5
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Map.GetDistance(
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.X,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Position.Y,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))].Units[0].Position.X,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))].Units[0].Position.Y));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L12c7;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

		L12c7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
			if (this.oCPU.Flags.GE) goto L12d3;
			goto L1241;

		L12d3:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xa);
			if (this.oCPU.Flags.L) goto L12eb;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3e7);
			if (this.oCPU.Flags.E) goto L12eb;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word));

		L12eb:
			// Instruction address 0x0000:0x12f3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Nearest civilization: ");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xa);
			if (this.oCPU.Flags.L) goto L1304;
			goto L1069;

		L1304:
			// Instruction address 0x0000:0x130c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "close");
			goto L10b5;

		L1317:
			// Instruction address 0x0000:0x11e2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "large island.");

			goto L11ea;

		L131d:
			// Instruction address 0x0000:0x1325, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "small continent.");

		L1320:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			goto L11ea;

		L1333:
			// Instruction address 0x0000:0x1325, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "medium continent.");

			goto L1320;

		L1338:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			goto L13ca;

		L1345:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
			if (this.oCPU.Flags.E) goto L135b;

			// Instruction address 0x0000:0x1353, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "+");

		L135b:
			// Instruction address 0x0000:0x1361, size: 5
			this.oParent.Segment_1ade.F0_1ade_1584(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0);

			// Instruction address 0x0000:0x1376, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Static.Technologies[(short)this.oCPU.AX.Word].Name);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L1381:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1c)));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			if (this.oCPU.Flags.G) goto L1345;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1c)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L13c7;

			// Instruction address 0x0000:0x13a6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "NONE");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c)), 0xffff);
			if (this.oCPU.Flags.E) goto L13c1;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			if (this.oCPU.Flags.E) goto L13c7;

		L13c1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Word);

		L13c7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L13ca:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.GE) goto L144c;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].TypeID == -1)
				goto L13c7;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x13fb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Skills: ");

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.BP.Word);
			this.oCPU.DI.Word = this.oCPU.SUB_UInt16(this.oCPU.DI.Word, 0x1c);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.LE) goto L1444;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word), 0x3));
			
			// Instruction address 0x0000:0x142c, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				0,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[0].Position.X,
				this.oGameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Units[0].Position.Y);

			// Instruction address 0x0000:0x143c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Settlers+");

		L1444:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x0);
			goto L1381;

		L144c:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c));
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_0fe6");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1455()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1455()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1467, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(7, 1);

			// Instruction address 0x0000:0x147c, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x36ff, 0);

			// Instruction address 0x0000:0x14a4, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 160, 50, 160, 150, this.oParent.Var_19e8_Rectangle, 160, 50);

			for (int i = 0; i < 3; i++)
			{
				// Instruction address 0x0000:0x14cb, size: 5
				this.oParent.Array_df62[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (42 * i) + 160, 142, 41, 58);
			}

			// Instruction address 0x0000:0x14f7, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3709, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L156c;

		L1506:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oParent.Array_b886[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] =
					this.oParent.Array_b886[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
						this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) - 1];

		L151c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L151f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x10);
			if (this.oCPU.Flags.GE) goto L1569;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x6);
			if (this.oCPU.Flags.GE) goto L1532;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3e), 0x0);
			if (this.oCPU.Flags.E) goto L1538;

		L1532:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L1506;

		L1538:
			// Instruction address 0x0000:0x154f, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) << 4),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4),
				0x10, 0x10);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oParent.Array_b886[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] = this.oCPU.AX.Word;

			goto L151c;

		L1569:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L156c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xa);
			if (this.oCPU.Flags.GE) goto L1579;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L151f;

		L1579:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L15ec;

		L1580:
			// Instruction address 0x0000:0x15a4, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) - ((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 3)) + 8),
				0xb8, 8, 8);

		L159f:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oParent.Array_d294[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L15bf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x4);
			if (this.oCPU.Flags.GE) goto L15e9;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.GE) goto L1580;

			// Instruction address 0x0000:0x15a4, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 3) + (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4)),
				0xb0, 8, 8);
			goto L159f;

		L15e9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L15ec:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.GE) goto L15f9;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L15bf;

		L15f9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1603;

		L1600:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1603:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.L) goto L160c;
			goto L16b3;

		L160c:
			// Instruction address 0x0000:0x1624, size: 5
			this.oParent.Array_d2d4[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) * 16) + 128,
				176, 16, 16);

			goto L1600;

		L16b3:
			// Instruction address 0x0000:0x16c2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3720, 0);

			// Instruction address 0x0000:0x16d2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x372a, 0xbdee);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L16df:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xbdf4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6b34), this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x30);
			if (this.oCPU.Flags.L) goto L16df;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L16fa:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);

			// Instruction address 0x0000:0x1714, size: 5
			this.oParent.Array_b27a[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] = 
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (short)this.oCPU.SI.Word, 48, 16, 16);

			// Instruction address 0x0000:0x1732, size: 5
			this.oParent.Array_b29a[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] = 
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (short)this.oCPU.SI.Word + 128, 96, 16, 16);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L16fa;
			
			// Instruction address 0x0000:0x1758, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 0x30, 0x20, 0x10, 0x10);

			this.oParent.Var_b2ba = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L1768:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			
			// Instruction address 0x0000:0x1782, size: 5
			this.oParent.Array_6e00[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 1] = 
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (short)this.oCPU.SI.Word, 64, 16, 16);

			// Instruction address 0x0000:0x179c, size: 5
			this.oParent.Array_6e1e[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 1] = 
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (short)this.oCPU.SI.Word, 80, 16, 16);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.L) goto L1768;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L17b6:
			this.oCPU.AX.Word = 0x7;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, 0xa0);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);

			// Instruction address 0x0000:0x17d7, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 0, 7, 15);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xd21c), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x17f4, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 16, 7, 15);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xd244), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x1811, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, 0x20, 7, 15);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xd26c), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x14);
			if (this.oCPU.Flags.L) goto L17b6;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L182b:
			// Instruction address 0x0000:0x1843, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) + 0x50),
				0x80, 0x10, 0x10);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.Array_7eec[this.oCPU.BX.Word/2] = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.L) goto L182b;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L1862:
			// Instruction address 0x0000:0x1877, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4),
				0x20, 16, 16);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.Array_d4ce[this.oCPU.BX.Word / 2] = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x7);
			if (this.oCPU.Flags.L) goto L1862;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6e92);
			this.oParent.Array_d4ce[7] = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L189c:
			// Instruction address 0x0000:0x18bf, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 3) << 3) + 0x81),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 4) << 1) + 0x21),
				7, 7);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.Array_d4ce[8 + this.oCPU.BX.Word / 2] = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L189c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L18de:
			// Instruction address 0x0000:0x18f6, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 3),
				0x80, 8, 16);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.Array_6e96[this.oCPU.BX.Word / 2] = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x9);
			if (this.oCPU.Flags.L) goto L18de;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L1915:
			// Instruction address 0x0000:0x192b, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) + 1),
				0x71, 15, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.Array_d4ce[16 + this.oCPU.BX.Word / 2] = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.L) goto L1915;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L194a:
			// Instruction address 0x0000:0x1960, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 4) + 1),
				0x61, 15, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.Array_d4ce[32 + this.oCPU.BX.Word / 2] = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L194a;
			
			// Instruction address 0x0000:0x198b, size: 5
			this.oParent.Var_b880 = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 153, 41, 7, 7);
			
			// Instruction address 0x0000:0x19aa, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 0xb0, 0x80, 0x14, 9);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdf0c, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L1a0b;

		L19bc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L19bf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1c);
			if (this.oCPU.Flags.GE) goto L1a08;
			
			// Instruction address 0x0000:0x19ee, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) % 0x14) << 4) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) / 0x14) << 4) + 0x81),
				15, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oParent.Array_d4ce[64 + this.oCPU.BX.Word / 2] = this.oCPU.AX.Word;

			goto L19bc;

		L1a08:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L1a0b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.L) goto L1a14;
			goto L1aeb;

		L1a14:
			// Instruction address 0x0000:0x1a32, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 160, 320, 32, this.oParent.Var_19d4_Rectangle, 0, 128);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oCPU.CMP_UInt16(this.oParent.Array_1946[this.oCPU.BX.Word/2], 0xf);
			if (this.oCPU.Flags.NE) goto L1a69;
			// Instruction address 0x0000:0x1a61, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 15, 11);

		L1a69:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oCPU.CMP_UInt16(this.oParent.Array_1946[this.oCPU.BX.Word / 2], 0x7);
			if (this.oCPU.Flags.NE) goto L1a98;
			// Instruction address 0x0000:0x1a90, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 7, 3);

		L1a98:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word <<= 1;

			// Instruction address 0x0000:0x1ab8, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 10,
				(byte)this.oParent.Array_1946[this.oCPU.SI.Word / 2]);

			// Instruction address 0x0000:0x1adb, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 2,
				this.oParent.Array_1956[this.oCPU.SI.Word / 2]);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L19bf;

		L1aeb:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1455");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1af6()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1af6()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x12);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1b07, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(2, 1);

			// Instruction address 0x0000:0x1b17, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "govt0a.pic");

			this.oCPU.SI.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADD_UInt8(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Low);
			this.oCPU.CMP_UInt16(this.oCPU.SI.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L1b40;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x33);
			goto L1b58;

		L1b40:
			// Instruction address 0x0000:0x1b48, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(oParent.GameData.HumanPlayerID, (int)TechnologyEnum.Invention);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), 0x6d);
			}

		L1b58:
			// Instruction address 0x0000:0x1b60, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			// Instruction address 0x0000:0x1b84, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 160, 60, this.oParent.Var_19e8_Rectangle, 160, 140);

			// Instruction address 0x0000:0x1b95, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1af6");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1ba2()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1ba2()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.CMP_UInt16((ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType, 0x0);
			if (this.oCPU.Flags.NE) goto L1bb9;
			goto L1d15;

		L1bb9:
			// Instruction address 0x0000:0x1bb9, size: 5
			this.oParent.Segment_1ade.F0_1ade_0394();

			// Instruction address 0x0000:0x1bcc, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Nationality);

			// Instruction address 0x0000:0x1bdc, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " government\nchanged to ");

			this.oCPU.BX.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1bf8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1966)));

			// Instruction address 0x0000:0x1c08, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			this.oParent.Overlay_21.F21_0000_0000(-2);
			
			// Instruction address 0x0000:0x1c1c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x1c38, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, 15);

			this.oParent.Var_aa_Rectangle.FontID = 6;

			// Instruction address 0x0000:0x1c58, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA("New Cabinet:", 160, 102, 0);

			this.oParent.Var_aa_Rectangle.FontID = 2;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L1c87:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x4);
			if (this.oCPU.Flags.GE) goto L1cfd;

			// Instruction address 0x0000:0x1cbb, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
				(40 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))) + 160, 140, 40, 60, 
				this.oParent.Var_aa_Rectangle, (80 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))) + 20, 118);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1cd0, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2fac)));

			// Instruction address 0x0000:0x1cdc, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x0);

			// Instruction address 0x0000:0x1c7c, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06,
				(80 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))) + 40,
				((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) & 1) != 0) ? 186 : 180, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			goto L1c87;

		L1cfd:
			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x1d06, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x1d0b, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x1d10, size: 5
			this.oParent.Segment_1ade.F0_1ade_03bf();

		L1d15:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1ba2");
		}
	}
}
