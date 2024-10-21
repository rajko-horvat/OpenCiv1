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
		public void F5_0000_0000_StartNewGame()
		{
			this.oCPU.Log.EnterBlock("F5_0000_0000_StartNewGame()");

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

			if (this.oParent.Var_1a3c_MouseAvailable && this.oParent.Var_2fa2 != 0)
			{
				// Instruction address 0x0000:0x006f, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223();

				if (this.oParent.Var_db3c < 135)
				{
					// Instruction address 0x0000:0x0090, size: 5
					this.oGameData.DifficultyLevel = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((short)this.oParent.Var_db3e - 12) / 35, 0, 4);
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

			if (this.oParent.Var_1a30_SoundDriverType == 'N')
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
				this.oGameData.Players[this.oGameData.HumanPlayerID].Nation, 46, 92, 15);

			for (int i = 0; i < 8; i++)
			{
				F5_0000_07c7((short)i);

				for (int j = 0; j < 8; j++)
				{
					this.oGameData.Players[i].UnitsDestroyed[j] = 0;
				}
			}

			// !!! Seems like a leftover code which has no real use
			//F5_0000_0fe6();

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
			this.oCPU.Log.ExitBlock("F5_0000_0000_StartNewGame");
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
			int xPos;
			int yPos;
			int[] local_32 = new int[iMapGroupLength];

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

				// !!! Can't find any reference to this array
				//this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(0xd20c + playerID * 2), 0);

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

				if (playerID != 0 && (this.oGameData.ActiveCivilizations & (1 << playerID)) != 0)
				{
					if (playerID != this.oGameData.HumanPlayerID)
					{
						if (this.oGameData.TurnCount == 0)
						{
							int local_e;

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

					int retryCount = 0;

					if (this.oGameData.TurnCount == 0 && this.oParent.Var_d76a_IsEarthMap)
					{
						xPos = this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].EarthStartPosition.X;
						yPos = this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].EarthStartPosition.Y;
					}
					else
					{
						int distance;

					L0a5e:
						// Instruction address 0x0000:0x0a62, size: 5
						xPos = this.oParent.MSCAPI.RNG.Next(64) + 8;

						// Instruction address 0x0000:0x0a74, size: 5
						yPos = this.oParent.MSCAPI.RNG.Next(50);

						// Instruction address 0x0000:0x0a86, size: 5
						int local_6 = (short)this.oParent.Segment_2dc4.F0_2dc4_0102(xPos, yPos);

						if (local_6 == -1)
						{
							distance = 30;
						}
						else
						{
							// Instruction address 0x0000:0x0abf, size: 5
							distance = this.oGameData.Map.GetDistance(xPos, yPos,
								this.oGameData.Cities[local_6].Position.X,
								this.oGameData.Cities[local_6].Position.Y);
						}

						if (oParent.GameData.TurnCount == 0)
						{
							for (int i = 1; i < playerID; i++)
							{
								// Instruction address 0x0000:0x0af2, size: 5
								int local_12 = this.oGameData.Map.GetDistance(xPos, yPos,
									this.oGameData.Players[i].Units[0].Position.X,
									this.oGameData.Players[i].Units[0].Position.Y);

								if (local_12 < distance)
								{
									distance = local_12;
								}
							}
						}

						// Instruction address 0x0000:0x0b24, size: 5

						retryCount++;

						// Instruction address 0x0000:0x0b54, size: 5
						// Instruction address 0x0000:0x0be2, size: 5
						// Instruction address 0x0000:0x0c03, size: 5
						// Instruction address 0x0000:0x0c0c, size: 5
						if ((retryCount <= 2000 || (playerID == this.oGameData.HumanPlayerID && oParent.GameData.TurnCount == 0)) &&
							(this.oGameData.Map[xPos, yPos].TerrainType == TerrainTypeEnum.Water ||
								(12 - (retryCount / 32)) > this.oGameData.Map[xPos, yPos].Layer2_PlayerOwnership || distance < (10 - (retryCount / 64)) ||
								this.oGameData.Map.Groups[this.oGameData.Map[xPos, yPos].Layer3_GroupID].BuildSiteCount <
								(32 - ((this.oGameData.TurnCount / 16) + (retryCount / 64))) ||
								(this.oGameData.Year > 0 && local_32[this.oParent.MapManagement.F0_2aea_1942_GetGroupID(xPos, yPos)] != 0) ||
								this.oParent.MapManagement.F0_2aea_1894(xPos, yPos, this.oGameData.Map[xPos, yPos].TerrainType) != 0)) goto L0a5e;
					}

					if (this.oGameData.TurnCount != 0)
					{
						if (this.oGameData.Players[playerID].NationalityID >= 8 && (this.oGameData.PlayerIdentityFlags & (1 << playerID)) != 0)
						{
							retryCount = 2000;
						}

						if (this.oGameData.Players[playerID].NationalityID < 8 && (this.oGameData.PlayerIdentityFlags & (1 << playerID)) == 0)
						{
							retryCount = 2000;
						}
					}

					if (playerID != this.oGameData.HumanPlayerID)
					{
						this.oGameData.Players[playerID].ScienceTaxRate =
							(short)(this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Ideology + 3);
						this.oGameData.Players[playerID].TaxRate = (short)(9 - this.oGameData.Players[playerID].ScienceTaxRate);
					}

					if (((350 - (this.oGameData.DifficultyLevel * 50)) < this.oGameData.TurnCount || retryCount >= 2000) &&
						playerID != this.oGameData.HumanPlayerID)
					{
						this.oGameData.Players[playerID].NationalityID ^= 8;
						this.oGameData.ActiveCivilizations &= (short)(~(1 << playerID));

						if (((1 << this.oGameData.HumanPlayerID) | 0x1) == this.oGameData.ActiveCivilizations)
						{
							this.oParent.Var_dc48 = 1;
							this.oParent.Var_b884 = 1;
						}

						this.oCPU.AX.Word = 0;
					}
					else
					{
						// Instruction address 0x0000:0x0d26, size: 5
						this.oGameData.Players[playerID].Name =
							this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Leader;

						if (playerID != this.oGameData.HumanPlayerID || string.IsNullOrEmpty(this.oGameData.Players[playerID].Nationality))
						{
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
						}

						// Instruction address 0x0000:0x0db7, size: 5
						this.oParent.MapManagement.F0_2aea_138c_MapSetCityOwner(xPos, yPos, playerID);

						// Instruction address 0x0000:0x0dcb, size: 5
						this.oParent.Segment_1866.F0_1866_0cf5(playerID, 0, xPos, yPos);

						this.oGameData.Players[playerID].XStart = (short)xPos;

						for (int i = 0; i < 128; i++)
						{
							if (this.oGameData.Players[0].Units[i].TypeID != -1)
							{
								// Instruction address 0x0000:0x0e05, size: 5
								if (this.oGameData.Map.GetDistance(xPos, yPos,
									this.oGameData.Players[0].Units[i].Position.X, this.oGameData.Players[0].Units[i].Position.Y) < 9)
								{
									// Instruction address 0x0000:0x0e18, size: 5
									this.oParent.Segment_1866.F0_1866_0f10(0, (short)i);
								}
							}
						}

						this.oGameData.Players[playerID].DiscoveredTechnologyCount = 1;

						for (int i = 0; i < 28; i++)
						{
							this.oGameData.Players[playerID].LostUnits[i] = 0;
							this.oGameData.Players[playerID].ActiveUnits[i] = 0;
							this.oGameData.Players[playerID].UnitsInProduction[i] = 0;
						}
						this.oCPU.AX.Word = 0x1;
					}
				}
				else
				{
					for (int i = 0; i < 28; i++)
					{
						this.oGameData.Players[playerID].LostUnits[i] = 0;
						this.oGameData.Players[playerID].ActiveUnits[i] = 0;
						this.oGameData.Players[playerID].UnitsInProduction[i] = 0;
					}
					this.oCPU.AX.Word = 0x1;
				}
			}

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
		public void F5_0000_0fe6()
		{
			this.oCPU.Log.EnterBlock("F5_0000_0fe6()");

			// function body
			int[] local_1c = new int[8];
			int[] local_5a = new int[8];
			int groupCount = this.oGameData.Map.Groups.Count;
			int[] local_46 = new int[groupCount];

			for (int i = 0; i < groupCount; i++)
			{
				local_46[i] = 0;
			}

			for (int i = 1; i < 8; i++)
			{
				if (this.oGameData.Players[i].Units[0].TypeID != -1)
				{
					// Instruction address 0x0000:0x103d, size: 5
					int groupID = this.oGameData.Map[this.oGameData.Players[i].Units[0].Position].Layer3_GroupID;

					local_5a[i] = groupID;
					local_46[groupID]++;
				}
			}

			int local_c = 0;
			int local_24 = 0;

			for (int i = 1; i < 8; i++)
			{
				if (this.oGameData.Players[i].Units[0].TypeID != -1)
				{
					int local_6 = 0;
					int distanceToAnotherPlayer = 999;

					for (int j = 1; j < 8; j++)
					{
						// Instruction address 0x0000:0x1274, size: 5
						// Instruction address 0x0000:0x128b, size: 5
						if (j != i && this.oGameData.Players[j].Units[0].TypeID != -1 &&
							this.oGameData.Map[this.oGameData.Players[i].Units[0].Position].Layer3_GroupID ==
							this.oGameData.Map[this.oGameData.Players[j].Units[0].Position].Layer3_GroupID)
						{
							// Instruction address 0x0000:0x12ae, size: 5
							int distanceToUnit = this.oGameData.Map.GetDistance(this.oGameData.Players[i].Units[0].Position,
								this.oGameData.Players[j].Units[0].Position);

							if (distanceToUnit < distanceToAnotherPlayer)
							{
								distanceToAnotherPlayer = distanceToUnit;
							}
						}
					}

					if (distanceToAnotherPlayer >= 10 && distanceToAnotherPlayer != 999)
					{
						local_c |= 1 << i;
					}

					// Instruction address 0x0000:0x12f3, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, "Nearest civilization: ");

					if (distanceToAnotherPlayer < 10)
					{
						// Instruction address 0x0000:0x130c, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "close");
					}
					else if (distanceToAnotherPlayer < 20)
					{
						// Instruction address 0x0000:0x1077, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "moderate");

						local_6++;
					}
					else if (distanceToAnotherPlayer != 999)
					{
						// Instruction address 0x0000:0x1093, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "far away");

						local_6 += 2;
					}
					else
					{
						// Instruction address 0x0000:0x10a9, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "isolated");

						local_6 += 4;
					}

					int waterCellCount = 0;
					int grasslandCellCount = 0;
					int riverCellCount = 0;

					for (int j = 0; j < 9; j++)
					{
						GPoint direction = TerrainMap.MoveOffsets[j];

						// Instruction address 0x0000:0x10ee, size: 5
						switch (this.oGameData.Map[this.oGameData.Players[i].Units[0].Position.X + direction.X,
							this.oGameData.Players[i].Units[0].Position.Y + direction.Y].TerrainType)
						{
							case TerrainTypeEnum.Water:
								waterCellCount++;
								break;

							case TerrainTypeEnum.Grassland:
								grasslandCellCount++;
								break;

							case TerrainTypeEnum.River:
								riverCellCount++;
								break;
						}
					}

					if (waterCellCount != 0)
					{
						// Instruction address 0x0000:0x112f, size: 5
						this.oParent.MSCAPI.strcpy(0xba06, "Coastal ");
					}
					else
					{
						// Instruction address 0x0000:0x112f, size: 5
						this.oParent.MSCAPI.strcpy(0xba06, "Inland ");
					}

					if (riverCellCount > 1)
					{
						// Instruction address 0x0000:0x1145, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "river valley on a ");
						local_6 += 2;

					}
					else if (grasslandCellCount < 3)
					{
						// Instruction address 0x0000:0x1176, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "plains on a ");
					}
					else
					{
						// Instruction address 0x0000:0x1161, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "grasslands on a ");

						local_6++;
					}

					// Instruction address 0x0000:0x119a, size: 5
					switch (this.oGameData.Map.Groups[this.oGameData.Map[this.oGameData.Players[i].Units[0].Position].Layer3_GroupID].Size / 50)
					{
						case 0:
							// Instruction address 0x0000:0x11e2, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "small island.");
							break;

						case 1:
							// Instruction address 0x0000:0x11e2, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "large island.");

							break;

						case 2:
							// Instruction address 0x0000:0x1325, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "small continent.");
							local_6++;

							break;

						case 3:
							// Instruction address 0x0000:0x1325, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "medium continent.");
							local_6++;

							break;

						default:
							// Instruction address 0x0000:0x11cc, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "large continent.");
							local_6 += 2;

							break;
					}

					if (local_6 > local_24)
					{
						local_24 = local_6;
					}

					local_1c[i] = local_6;
				}
			}

			int local_5c = -1;

			for (int i = 1; i < 8; i++)
			{
				if (this.oGameData.Players[i].Units[0].TypeID != -1)
				{
					// Instruction address 0x0000:0x13fb, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, "Skills: ");

					if (local_24 - local_1c[i] > 3)
					{
						local_1c[i] += 3;

						// Instruction address 0x0000:0x142c, size: 5
						this.oParent.Segment_1866.F0_1866_0cf5((short)i, 0,
							this.oGameData.Players[i].Units[0].Position.X,
							this.oGameData.Players[i].Units[0].Position.Y);

						// Instruction address 0x0000:0x143c, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "Settlers+");
					}

					for (int j = 0; j < local_24 - local_1c[i]; j++)
					{
						if (j != 0)
						{
							// Instruction address 0x0000:0x1353, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "+");
						}

						// Instruction address 0x0000:0x1361, size: 5
						// Instruction address 0x0000:0x1376, size: 5
						this.oParent.MSCAPI.strcat(0xba06,
							this.oGameData.Static.Technologies[(short)this.oParent.Segment_1ade.F0_1ade_1584((short)i, 0)].Name);
					}

					if (local_1c[i] == local_24)
					{
						// Instruction address 0x0000:0x13a6, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "NONE");

						if (local_5c == -1 || ((1 << i) & local_c) != 0)
						{
							local_5c = i;
						}
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_0fe6");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1455_LoadSprites()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1455_LoadSprites()");

			// function body
			// Instruction address 0x0000:0x147c, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp299.pic", 0);

			// Instruction address 0x0000:0x14a4, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 160, 50, 160, 150, this.oParent.Var_19e8_Rectangle, 160, 50);

			for (int i = 0; i < 3; i++)
			{
				// Instruction address 0x0000:0x14cb, size: 5
				this.oParent.Array_df62[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (42 * i) + 160, 142, 41, 58);
			}

			// Instruction address 0x0000:0x14f7, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "ter257.pic", 0);

			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 16; j++)
				{
					if ((i >= 6 || this.oParent.Var_1a3e != 0) && j != 0)
					{
						this.oParent.Array_b886[i, j] = this.oParent.Array_b886[i, j - 1];
					}
					else
					{
						// Instruction address 0x0000:0x154f, size: 5
						this.oParent.Array_b886[i, j] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, j * 16, i * 16, 16, 16);
					}
				}
			}

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (j >= 2)
					{
						// Instruction address 0x0000:0x15a4, size: 5
						this.oParent.Array_d294[i, j] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i * 16) - ((j & 1) * 8)) + 8, 184, 8, 8);
					}
					else
					{
						// Instruction address 0x0000:0x15a4, size: 5
						this.oParent.Array_d294[i, j] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) + ((j & 1) * 8), 176, 8, 8);
					}
				}
			}

			for (int i = 0; i < 4; i++)
			{
				// Instruction address 0x0000:0x1624, size: 5
				this.oParent.Array_d2d4[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) + 128, 176, 16, 16);
			}

			// Instruction address 0x0000:0x16c2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp257.pic", 0);

			// Instruction address 0x0000:0x16d2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "sp256.pal", out this.oParent.Var_bdee);

			for (int i = 0; i < 48; i++)
			{
				this.oParent.Var_6b34[i] = this.oParent.Var_bdee[i + 6];
			}

			for (int i = 0; i < 8; i++)
			{
				// Instruction address 0x0000:0x1714, size: 5
				this.oParent.Array_b27a[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16, 48, 16, 16);

				// Instruction address 0x0000:0x1732, size: 5
				this.oParent.Array_b29a[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16 + 128, 96, 16, 16);
			}

			// Instruction address 0x0000:0x1758, size: 5
			this.oParent.Var_b2ba = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 0x30, 0x20, 0x10, 0x10);

			for (int i = 1; i < 16; i++)
			{
				// Instruction address 0x0000:0x1782, size: 5
				this.oParent.Array_6e00[i - 1] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16, 64, 16, 16);

				// Instruction address 0x0000:0x179c, size: 5
				this.oParent.Array_6e1e[i - 1] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16, 80, 16, 16);
			}

			for (int i = 0; i < 20; i++)
			{
				// Instruction address 0x0000:0x17d7, size: 5
				this.oParent.Array_d21c[0, i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 7) + 160, 0, 7, 15);

				// Instruction address 0x0000:0x17f4, size: 5
				this.oParent.Array_d21c[1, i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 7) + 160, 16, 7, 15);

				// Instruction address 0x0000:0x1811, size: 5
				this.oParent.Array_d21c[2, i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 7) + 160, 32, 7, 15);
			}

			for (int i = 0; i < 4; i++)
			{
				// Instruction address 0x0000:0x1843, size: 5
				this.oParent.Array_7eec[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) + 80, 128, 16, 16);
			}

			for (int i = 0; i < 7; i++)
			{
				// Instruction address 0x0000:0x1877, size: 5
				this.oParent.Array_d4ce[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16, 32, 16, 16);
			}

			this.oParent.Array_d4ce[7] = this.oParent.Var_6e92;

			for (int i = 0; i < 8; i++)
			{
				// Instruction address 0x0000:0x18bf, size: 5
				this.oParent.Array_d4ce[8 + i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i & 3) * 8) + 129, ((i & 4) * 2) + 33, 7, 7);
			}

			for (int i = 0; i < 9; i++)
			{
				// Instruction address 0x0000:0x18f6, size: 5
				this.oParent.Array_6e96[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 8, 128, 8, 16);
			}

			for (int i = 0; i < 16; i++)
			{
				// Instruction address 0x0000:0x192b, size: 5
				this.oParent.Array_d4ce[16 + i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) + 1, 113, 15, 15);
			}

			for (int i = 0; i < 8; i++)
			{
				// Instruction address 0x0000:0x1960, size: 5
				this.oParent.Array_d4ce[32 + i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) + 1, 97, 15, 15);
			}

			// Instruction address 0x0000:0x198b, size: 5
			this.oParent.Var_b880 = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 153, 41, 7, 7);

			// Instruction address 0x0000:0x19aa, size: 5
			this.oParent.Var_df0c = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 176, 128, 20, 9);

			for (int i = 0; i < 8; i++)
			{
				// Instruction address 0x0000:0x1a32, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 160, 320, 32, this.oParent.Var_19d4_Rectangle, 0, 128);

				if (this.oParent.Array_1946[i] == 15)
				{
					// Instruction address 0x0000:0x1a61, size: 5
					this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 15, 11);
				}

				if (this.oParent.Array_1946[i] == 7)
				{
					// Instruction address 0x0000:0x1a90, size: 5
					this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 7, 3);
				}

				// Instruction address 0x0000:0x1ab8, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 10,
					this.oParent.Array_1946[i]);

				// Instruction address 0x0000:0x1adb, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 2,
					this.oParent.Array_1956[i]);

				for (int j = 0; j < 28; j++)
				{
					// Instruction address 0x0000:0x19ee, size: 5
					this.oParent.Array_d4ce[64 + ((i * 32) + j)] =
						this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((j % 20) * 16) + 1, ((j / 20) * 16) + 129, 15, 15);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1455_LoadSprites");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1af6_LoadGovernmentImage()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1af6_LoadGovernmentImage()");

			// function body
			int govType = this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType / 2;
			bool ancient = true;

			if (this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType == 3)
			{
				govType = 3;
			}
			else
			{
				// Instruction address 0x0000:0x1b48, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(oParent.GameData.HumanPlayerID, (int)TechnologyEnum.Invention) != 0)
				{
					ancient = false;
				}
			}

			// Instruction address 0x0000:0x1b60, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, $"govt{govType}{(ancient ? 'a' : 'm')}.pic", 0);

			// Instruction address 0x0000:0x1b84, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 160, 60, this.oParent.Var_19e8_Rectangle, 160, 140);

			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1af6_LoadGovernmentImage");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1ba2_ChangeGovernment()
		{
			this.oCPU.Log.EnterBlock("F5_0000_1ba2_ChangeGovernment()");

			// function body
			if (this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType != 0)
			{
				// Instruction address 0x0000:0x1bb9, size: 5
				this.oParent.Segment_1ade.F0_1ade_0394();

				// Instruction address 0x0000:0x1bcc, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Nationality);

				// Instruction address 0x0000:0x1bdc, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " government\nchanged to ");

				// Instruction address 0x0000:0x1bf8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.Array_1966[this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType]);

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

				for (int i = 0; i < 4; i++)
				{
					// Instruction address 0x0000:0x1cbb, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, (40 * i) + 160, 140, 40, 60,
						this.oParent.Var_aa_Rectangle, (80 * i) + 20, 118);

					// Instruction address 0x0000:0x1cd0, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, this.oParent.Var_2fac[i]);

					// Instruction address 0x0000:0x1cdc, size: 5
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06) - 1), 0x0);

					// Instruction address 0x0000:0x1c7c, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, (80 * i) + 40, ((i & 1) != 0) ? 186 : 180, 0);
				}

				this.oParent.Var_aa_Rectangle.FontID = 1;

				// Instruction address 0x0000:0x1d06, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				// Instruction address 0x0000:0x1d0b, size: 5
				this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

				// Instruction address 0x0000:0x1d10, size: 5
				this.oParent.Segment_1ade.F0_1ade_03bf();
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F5_0000_1ba2_ChangeGovernment");
		}
	}
}
