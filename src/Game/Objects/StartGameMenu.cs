using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class StartGameMenu
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public StartGameMenu(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_0000()
		{
			//this.oCPU.Log.EnterBlock("F5_0000_0000()");

			// function body
			// Instruction address 0x0000:0x0007, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			// Instruction address 0x0000:0x0024, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x002c, size: 5
			this.oParent.MainCode.F0_11a8_0250();

			this.oParent.Var_aa_Rectangle.FontID = 7;

			// Instruction address 0x0000:0x0042, size: 5
			this.oParent.CAPI.strcpy(0xba06, "Difficulty Level...\n Chieftain (easiest)\n Warlord\n Prince\n King\n Emperor (toughest)\n");

			// Instruction address 0x0000:0x0056, size: 5
			this.oParent.GameData.DifficultyLevel = (short)this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 160, 35, false, false, true);

			if (this.oParent.Var_1a3c_MouseAvailable && this.oParent.Var_2fa2_DialogMousePressed)
			{
				// Instruction address 0x0000:0x006f, size: 5
				this.oParent.MainCode.F0_11a8_0223_UpdateMouseState();

				if (this.oParent.Var_db3c_MouseXPos < 135)
				{
					// Instruction address 0x0000:0x0090, size: 5
					this.oParent.GameData.DifficultyLevel = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((this.oParent.Var_db3e_MouseYPos - 12) / 35, 0, 4);
				}
			}
		
			if (oParent.GameData.DifficultyLevel == -1)
			{
				this.oParent.GameData.DifficultyLevel = 0;
			}
		
			// Instruction address 0x0000:0x00a8, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			// Instruction address 0x0000:0x00c0, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 150, 200, 0);

			if ((this.oParent.GameData.DifficultyLevel & 0x1) != 0)
			{
				// Instruction address 0x0000:0x00fb, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					80, (35 * this.oParent.GameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 20, 100);
			}
			else
			{
				// Instruction address 0x0000:0x00fb, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					21, (35 * this.oParent.GameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 20, 100);
			}

			// Instruction address 0x0000:0x0121, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 150, 0, 160, 200, this.oParent.Var_aa_Rectangle, 150, 0);

			// Instruction address 0x0000:0x0129, size: 5
			this.oParent.MainCode.F0_11a8_0250();

			// Instruction address 0x0000:0x0136, size: 5
			this.oParent.CAPI.strcpy(0xba06, "Level of Competition...\n ");

			for (int i = 7; i > 2; i--)
			{
				// Instruction address 0x0000:0x016b, size: 5
				this.oParent.CAPI.strcat(0xba06, $"{i} Civilizations\n ");
			}

			do
			{
				// Instruction address 0x0000:0x0188, size: 5
				this.oParent.GameData.AIOpponentCount = (short)this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 160, 35, false, false, true);
			}
			while (this.oParent.GameData.AIOpponentCount == -1);

			// Instruction address 0x0000:0x01a8, size: 5
			this.oParent.GameData.AIOpponentCount = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(6 - this.oParent.GameData.AIOpponentCount, 2, 6);
			this.oParent.GameData.ActiveCivilizations = (short)(0xff >> (6 - this.oParent.GameData.AIOpponentCount));

			// Instruction address 0x0000:0x01c1, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			for (int i = this.oParent.GameData.AIOpponentCount; i >= 0; i--)
			{
				if ((this.oParent.GameData.DifficultyLevel & 0x1) != 0)
				{
					// Instruction address 0x0000:0x01d6, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
						80, (35 * this.oParent.GameData.DifficultyLevel) + 6, 53, 47,
						this.oParent.Var_aa_Rectangle, (i * 2) + 20, (i * 3) + 100);
				}
				else
				{
					// Instruction address 0x0000:0x01d6, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
						21, (35 * this.oParent.GameData.DifficultyLevel) + 6, 53, 47,
						this.oParent.Var_aa_Rectangle, (i * 2) + 20, (i * 3) + 100);
				}
			}

			this.oParent.GameData.Year = -4000;
			this.oParent.GameData.DebugFlags = 0xf;

			for (int i = 0; i < 128; i++)
			{
				this.oParent.GameData.Cities[i].NameID = 0xff;
				this.oParent.GameData.Cities[i].StatusFlag = 0xff;
			}

			for (int i = 0; i < 256; i++)
			{
				this.oParent.GameData.CityPositions[i].X = -1;
			}

			for (int i = 0; i < 72; i++)
			{
				this.oParent.GameData.TechnologyFirstDiscoveredBy[i] = 0;
			}

			for (int i = 0; i < 22; i++)
			{
				this.oParent.GameData.WonderCityID[i] = -1;
			}

			for (int i = 0; i < 8; i++)
			{
				this.oParent.GameData.Players[i].NationalityID = -1;

				F5_0000_1d1a_InitSpaceshipData(i);
			}

			for (int i = 0; i < 80; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					this.oParent.GameData.MapVisibility[i, j] = 0;
				}
			}

			//this.oParent.CivState.GameSettingFlags.Value = 0xfa;
			this.oParent.GameData.GameSettingFlags.InstantAdvice = false;
			this.oParent.GameData.GameSettingFlags.AutoSave = true;
			this.oParent.GameData.GameSettingFlags.EndOfTurn = false;
			this.oParent.GameData.GameSettingFlags.Animations = true;
			this.oParent.GameData.GameSettingFlags.Sound= true;
			this.oParent.GameData.GameSettingFlags.EnemyMoves= true;
			this.oParent.GameData.GameSettingFlags.CivilopediaText = true;
			this.oParent.GameData.GameSettingFlags.Palace = true;

			if (this.oParent.Var_1a30_SoundDriverType == 'N')
			{
				this.oParent.GameData.GameSettingFlags.Sound = false; // &= 0x7fef;
			}
		
			// Instruction address 0x0000:0x0311, size: 5
			this.oParent.CAPI.strcpy(0xba06, "Pick your tribe...\n ");

			for (int i = 1; i < this.oParent.GameData.AIOpponentCount + 2; i++)
			{
				// Instruction address 0x0000:0x033d, size: 5
				this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Nations[i].Nationality);

				// Instruction address 0x0000:0x034d, size: 5
				this.oParent.CAPI.strcat(0xba06, "\n ");
			}

			for (int i = 1; i < this.oParent.GameData.AIOpponentCount + 2; i++)
			{
				// Instruction address 0x0000:0x0377, size: 5
				this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Nations[8 + i].Nationality);

				// Instruction address 0x0000:0x0387, size: 5
				this.oParent.CAPI.strcat(0xba06, "\n ");
			}

			// Instruction address 0x0000:0x03ba, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 150, 0, 160, 200, this.oParent.Var_aa_Rectangle, 150, 0);

			// Instruction address 0x0000:0x03c2, size: 5
			this.oParent.MainCode.F0_11a8_0250();

			// Instruction address 0x0000:0x03d3, size: 5
			this.oParent.GameData.HumanPlayerID = (short)this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 160, 35, false, false, true);

			if (this.oParent.GameData.HumanPlayerID <= this.oParent.GameData.AIOpponentCount)
			{
				this.oParent.GameData.HumanPlayerID++;
			}
			else
			{
				this.oParent.GameData.HumanPlayerID = (short)((this.oParent.GameData.HumanPlayerID - this.oParent.GameData.AIOpponentCount) + 8);
			}

			if (this.oParent.GameData.DifficultyLevel == 0)
			{
				this.oParent.GameData.GameSettingFlags.InstantAdvice = true;
			}

			// Another indexing error. Value this.oParent.GameState.HumanPlayerID is equal
			// to nationality selected and not actual ID, but later in code it is forced to 0-7 by value & 7,
			// so we will use this value instead
			this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID & 7].ResearchTechnologyID = -1;

			// Instruction address 0x0000:0x0410, size: 5
			this.oParent.GameData.NextAnthologyTurn += (short)this.oParent.CAPI.RNG.Next(50);

			for (int i = 0; i < 12; i++)
			{
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID & 7].PalaceData1[i + 2] = -1;
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID & 7].PalaceData2[i] = 0;
			}

			for (int i = 3; i < 6; i++)
			{
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID & 7].PalaceData1[i + 2] = 0;
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID & 7].PalaceData1[i + 8] = 0;
			}

			this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Nationality = "";

			if (this.oParent.GameData.HumanPlayerID != 0)
			{
				int local_c = (this.oParent.GameData.HumanPlayerID > 7) ? 1 : 0;
				this.oParent.GameData.HumanPlayerID &= 7;

				if (local_c != 0)
				{
					this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID = (short)(this.oParent.GameData.HumanPlayerID + 8);
				}
				else
				{
					this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID = this.oParent.GameData.HumanPlayerID;
				}

				// Instruction address 0x0000:0x04ec, size: 5
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Name =
					this.oParent.GameData.Nations[this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID].Leader;

				// Instruction address 0x0000:0x0509, size: 5
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Nationality =
					this.oParent.GameData.Nations[this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID].Nationality;

				// Instruction address 0x0000:0x0526, size: 5
				this.oParent.CAPI.strcpy(0xba06,
					this.oParent.GameData.Nations[this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID].Nation);

				if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xba06) == 0)
				{
					// Instruction address 0x0000:0x0543, size: 5
					this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Nationality);

					// Instruction address 0x0000:0x0553, size: 5
					this.oParent.CAPI.strcat(0xba06, "s");
				}

				// Instruction address 0x0000:0x0569, size: 5
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Nation = this.oCPU.ReadString(this.oCPU.DS.UInt16, 0xba06);
			}
			else
			{
				// Instruction address 0x0000:0x047f, size: 5
				this.oParent.GameData.HumanPlayerID = (short)(this.oParent.CAPI.RNG.Next(this.oParent.GameData.AIOpponentCount) + 1);

				this.oParent.Overlay_23.F23_0000_0173();

				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID = this.oParent.GameData.HumanPlayerID;

				// Instruction address 0x0000:0x0569, size: 5
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Name = this.oParent.GameData.Nations[this.oParent.GameData.HumanPlayerID].Leader;
			}

			// Instruction address 0x0000:0x0587, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Nation, 46, 92, 15);

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 8; j++)
				{
					this.oParent.GameData.Players[i].UnitsDestroyed[j] = 0;
				}
				F5_0000_07c7(i);
			}

			F5_0000_0fe6();

			this.oParent.GameData.PlayerFlags = (short)(0x1 << this.oParent.GameData.HumanPlayerID);

			this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].TaxRate = 5;
			this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].ScienceTaxRate = 5;

			if (this.oParent.GameData.DifficultyLevel == 0)
			{
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Coins = 50;
			}
		
			this.oParent.GameData.PlayerIdentityFlags = 0;

			for (int i = 0; i < 8; i++)
			{
				if (this.oParent.GameData.Players[i].NationalityID >= 8)
				{
					this.oParent.GameData.PlayerIdentityFlags |= (short)(0x1 << i);
				}
			}

			// Instruction address 0x0000:0x062a, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			// Instruction address 0x0000:0x0645, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 150, 0, 170, 200, 0);

			this.oParent.Overlay_23.F23_0000_00d6_PlayerNameDialog();

			// Instruction address 0x0000:0x0652, size: 5
			this.oParent.MainCode.F0_11a8_0250();

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x066e, size: 5
			this.oParent.CAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x30be),
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Name);

			// Instruction address 0x0000:0x0684, size: 5
			this.oParent.CAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x30b8), 
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Nation);

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x0695, size: 5
			this.oParent.LanguageTools.F0_2f4d_044f(0x35c3);

			int local_2 = 0;

			for (int i = 0; i < 72; i++)
			{
				// Instruction address 0x0000:0x06bd, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameData.HumanPlayerID, (TechnologyEnum)i))
				{
					// Instruction address 0x0000:0x06d7, size: 5
					this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Technologies[i].Name);

					// Instruction address 0x0000:0x06e7, size: 5
					this.oParent.CAPI.strcat(0xba06, ", ");

					local_2++;

					if (local_2 == 2)
					{
						// Instruction address 0x0000:0x0700, size: 5
						this.oParent.CAPI.strcat(0xba06, "\n");
					}
				}
			}

			// Instruction address 0x0000:0x0719, size: 5
			this.oParent.CAPI.strcat(0xba06, "and Roads.\n");
			
			// Instruction address 0x0000:0x0738, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(
				this.oParent.GameData.Nations[this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID].LongTune, 3);

			// Instruction address 0x0000:0x0740, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			// Instruction address 0x0000:0x0759, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 15);

			// Instruction address 0x0000:0x0761, size: 5
			this.oParent.UnitManagement.F0_1866_260e();
			
			if ((this.oParent.GameData.DifficultyLevel & 0x1) != 0)
			{
				// Instruction address 0x0000:0x0799, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					80, (35 * this.oParent.GameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 134, 20);
			}
			else
			{
				// Instruction address 0x0000:0x0799, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					21, (35 * this.oParent.GameData.DifficultyLevel) + 6, 53, 47, this.oParent.Var_aa_Rectangle, 134, 20);
			}

			// Instruction address 0x0000:0x07b0, size: 5
			this.oParent.LanguageTools.F0_2f4d_0088_DrawTextBlock(99, 88, 81, 0);

			// Instruction address 0x0000:0x07b8, size: 5
			this.oParent.MainCode.F0_11a8_0250();

			// Instruction address 0x0000:0x07bd, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public int F5_0000_07c7(int playerID)
		{
			//this.oCPU.Log.EnterBlock($"F5_0000_07c7({playerID})");

			// function body
			int[] cityCount = new int[16];

			if (playerID != this.oParent.GameData.HumanPlayerID || this.oParent.GameData.TurnCount == 0)
			{
				this.oParent.GameData.Players[playerID].SpaceshipPopulation = 0;
				this.oParent.GameData.Players[playerID].CumulativeEpicRanking = 0;
				this.oParent.GameData.Players[playerID].DiscoveredTechnologyCount = 0;
				this.oParent.GameData.Players[playerID].ResearchProgress = 0;
				this.oParent.GameData.Players[playerID].Coins = 0;
				this.oParent.GameData.Players[playerID].GovernmentType = 1;
				this.oParent.GameData.Players[playerID].TaxRate = 4;
				this.oParent.GameData.Players[playerID].ScienceTaxRate = 4;

				for (int i = 0; i < 16; i++)
				{
					this.oParent.GameData.Players[playerID].Continents[i].Strategy = 0;
					cityCount[i] = 0;

					for (int j = 1; j < 8; j++)
					{
						cityCount[i] += this.oParent.GameData.Players[j].Continents[i].CityCount;
					}
				}

				this.oParent.GameData.Players[playerID].CityCount = 0;
				this.oParent.GameData.Players[playerID].UnitCount = 0;
				this.oParent.GameData.Players[playerID].LandCount = 1;
				this.oParent.GameData.Players[playerID].SettlerCount = 1;
				this.oParent.GameData.Players[playerID].ContactPlayerCountdown = -1;

				for (int i = 0; i < this.oParent.GameData.Players[playerID].TechnologyAcquiredFrom.Length; i++)
				{
					this.oParent.GameData.Players[playerID].TechnologyAcquiredFrom[i] = -1;
				}

				for (int i = 0; i < 128; i++)
				{
					this.oParent.GameData.Players[playerID].Units[i].TypeID = -1;
					this.oParent.GameData.Players[playerID].Units[i].Status = 0;
				}

				//this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(0xd20c + (playerID * 2)), 0);
				this.oParent.GameData.Players[playerID].Score = 0;

				if (playerID == this.oParent.GameData.HumanPlayerID)
				{
					// Instruction address 0x0000:0x08f4, size: 5
					this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_19e8_Rectangle, 240, 0, 80, 50, 0);
				}

				// Instruction address 0x0000:0x08ff, size: 5
				this.oParent.Segment_25fb.F0_25fb_3223_ClearStrategicLocations(playerID);

				for (int i = 0; i < 8; i++)
				{
					this.oParent.GameData.Players[playerID].Diplomacy[i] = 0;
					this.oParent.GameData.Players[i].Diplomacy[playerID] = 0;
				}

				for (int i = 0; i < 5; i++)
				{
					this.oParent.GameData.Players[playerID].DiscoveredTechnologyFlags[i] = 0;
				}

				if (this.oParent.GameData.TurnCount != 0)
				{
					for (int i = 0; i < 72; i++)
					{
						// Instruction address 0x0000:0x0967, size: 5
						if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameData.HumanPlayerID, (TechnologyEnum)i) &&
							(this.oParent.GameData.TechnologyFirstDiscoveredBy[i] & 0x7) != 0 &&
							(this.oParent.GameData.TechnologyFirstDiscoveredBy[i] & 0x7) != this.oParent.GameData.HumanPlayerID &&
							this.oParent.CAPI.RNG.Next(2) == 0)
						{
							// Instruction address 0x0000:0x09b2, size: 5
							this.oParent.Segment_1ade.F0_1ade_1d2e(playerID, (TechnologyEnum)i, playerID);
						}
					}
				}

				if (playerID != 0 && (this.oParent.GameData.ActiveCivilizations & (0x1 << playerID)) != 0)
				{
					if (playerID != this.oParent.GameData.HumanPlayerID)
					{
						if (this.oParent.GameData.TurnCount == 0)
						{
							bool flag;

							do
							{
								// Instruction address 0x0000:0x09f9, size: 5
								this.oParent.GameData.Players[playerID].NationalityID = (short)this.oParent.CAPI.RNG.Next(16);
								flag = true;

								if ((this.oParent.GameData.Players[playerID].NationalityID & 7) != playerID)
								{
									flag = false;
								}

								for (int i = 0; i < 8; i++)
								{
									if (i != playerID && this.oParent.GameData.Players[i].NationalityID == this.oParent.GameData.Players[playerID].NationalityID)
									{
										flag = false;
									}
								}
							}
							while (!flag);
						}
						else
						{
							this.oParent.GameData.Players[playerID].NationalityID ^= 8;
						}
					}

					int xStart;
					int yStart;
					int landOwnership;
					int tryCount = 0;

				L0a5e:
					// Instruction address 0x0000:0x0a62, size: 5
					xStart = this.oParent.CAPI.RNG.Next(64) + 8;
					yStart = this.oParent.CAPI.RNG.Next(34) + 8;

					int distance;
					int cityID = (short)this.oParent.Segment_2dc4.F0_2dc4_0102(xStart, yStart);

					if (cityID == -1)
					{
						distance = 30;
					}
					else
					{
						// Instruction address 0x0000:0x0abf, size: 5
						distance = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(xStart, yStart,
							this.oParent.GameData.Cities[cityID].Position.X, this.oParent.GameData.Cities[cityID].Position.Y);
					}

					if (oParent.GameData.TurnCount == 0)
					{
						for (int j = 1; j < playerID; j++)
						{
							// Instruction address 0x0000:0x0af2, size: 5
							int newDistance = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(xStart, yStart,
								this.oParent.GameData.Players[j].Units[0].Position.X, this.oParent.GameData.Players[j].Units[0].Position.Y);

							if (newDistance < distance)
							{
								distance = newDistance;
							}
						}
					}

					// Instruction address 0x0000:0x0b24, size: 5
					landOwnership = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xStart + 80, yStart);

					tryCount++;

					if (tryCount <= 2000 || playerID == this.oParent.GameData.HumanPlayerID && oParent.GameData.TurnCount == 0)
					{
						// Instruction address 0x0000:0x0b54, size: 5
						if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(xStart, yStart) == TerrainTypeEnum.Water ||
							-((tryCount / 32) - 12) > landOwnership || distance < 10 - (tryCount / 64) || 
							this.oParent.GameData.Continents[this.oParent.MapManagement.F0_2aea_1942_GetGroupID(xStart, yStart)].BuildSiteCount < -((this.oParent.GameData.TurnCount / 32) + (tryCount / 64) - 32) ||
							(this.oParent.GameData.Year > 0 && cityCount[this.oParent.MapManagement.F0_2aea_1942_GetGroupID(xStart, yStart)] != 0) ||
							this.oParent.MapManagement.F0_2aea_1894_CellHasMinorTribeHut(
								this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(xStart, yStart), xStart, yStart)) goto L0a5e;
					}

					if (this.oParent.GameData.TurnCount == 0 && this.oParent.Var_d76a != 0)
					{
						xStart = this.oParent.Array_35da[this.oParent.GameData.Players[playerID].NationalityID].X;
						yStart = this.oParent.Array_35da[this.oParent.GameData.Players[playerID].NationalityID].Y;
						tryCount = 0;
					}

					if (this.oParent.GameData.TurnCount != 0 &&
						((this.oParent.GameData.Players[playerID].NationalityID > 7 && (this.oParent.GameData.PlayerIdentityFlags & (0x1 << playerID)) != 0) ||
							(this.oParent.GameData.Players[playerID].NationalityID < 8 && (this.oParent.GameData.PlayerIdentityFlags & (0x1 << playerID)) == 0)))
					{
						tryCount = 2000;
					}

					if (playerID != this.oParent.GameData.HumanPlayerID)
					{
						this.oParent.GameData.Players[playerID].ScienceTaxRate = (short)(this.oParent.GameData.Nations[this.oParent.GameData.Players[playerID].NationalityID].Ideology + 3);
						this.oParent.GameData.Players[playerID].TaxRate = (short)(9 - this.oParent.GameData.Players[playerID].ScienceTaxRate);
					}

					if ((-((50 * this.oParent.GameData.DifficultyLevel) - 350) < this.oParent.GameData.TurnCount || tryCount >= 2000) &&
						playerID != this.oParent.GameData.HumanPlayerID)
					{
						this.oParent.GameData.Players[playerID].NationalityID ^= 8;
						this.oParent.GameData.ActiveCivilizations &= (short)(~(0x1 << playerID));

						if (((0x1 << this.oParent.GameData.HumanPlayerID) | 0x1) == this.oParent.GameData.ActiveCivilizations)
						{
							this.oParent.Var_dc48_GameEndType = 1;
							this.oParent.Var_b884 = 1;
						}

						return 0;
					}

					// Instruction address 0x0000:0x0d26, size: 5
					this.oParent.GameData.Players[playerID].Name = this.oParent.GameData.Nations[this.oParent.GameData.Players[playerID].NationalityID].Leader;

					if (playerID != this.oParent.GameData.HumanPlayerID || string.IsNullOrEmpty(this.oParent.GameData.Players[playerID].Nationality))
					{
						// Instruction address 0x0000:0x0d53, size: 5
						this.oParent.GameData.Players[playerID].Nationality = this.oParent.GameData.Nations[this.oParent.GameData.Players[playerID].NationalityID].Nationality;

						// Instruction address 0x0000:0x0d6a, size: 5
						this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Nations[this.oParent.GameData.Players[playerID].NationalityID].Nation);

						if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xba06) == 0)
						{
							// Instruction address 0x0000:0x0d81, size: 5
							this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[playerID].Nationality);

							// Instruction address 0x0000:0x0d91, size: 5
							this.oParent.CAPI.strcat(0xba06, "s");
						}

						// Instruction address 0x0000:0x0da6, size: 5
						this.oParent.GameData.Players[playerID].Nation = this.oCPU.ReadString(this.oCPU.DS.UInt16, 0xba06);
					}

					// Instruction address 0x0000:0x0db7, size: 5
					this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(playerID, xStart, yStart);

					// Instruction address 0x0000:0x0dcb, size: 5
					this.oParent.UnitManagement.F0_1866_0cf5_CreateUnit(playerID, 0, xStart, yStart);

					this.oParent.GameData.Players[playerID].XStart = (short)xStart;

					for (int i = 0; i < 128; i++)
					{
						if (this.oParent.GameData.Players[0].Units[i].TypeID != -1 &&
							this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(xStart, yStart,
								this.oParent.GameData.Players[0].Units[i].Position.X, this.oParent.GameData.Players[0].Units[i].Position.Y) < 9)
						{
							// Instruction address 0x0000:0x0e18, size: 5
							this.oParent.UnitManagement.F0_1866_0f10_DeleteUnit(0, i);
						}
					}

					this.oParent.GameData.Players[playerID].DiscoveredTechnologyCount = 1;
				}

				for (int i = 0; i < 28; i++)
				{
					this.oParent.GameData.Players[playerID].LostUnits[i] = 0;
					this.oParent.GameData.Players[playerID].ActiveUnits[i] = 0;
					this.oParent.GameData.Players[playerID].UnitsInProduction[i] = 0;
				}
				return 1;
			}

			return 0;
		}

		/// <summary>
		/// This function tests if a AI player has no more cities. 
		/// If the city count is zero the player is marked as destroyed and all units that belong to the AI player are deleted.
		/// The function doesn't take into account settlers which could respawn new cities.
		/// </summary>
		/// <param name="playerID">AI player to test</param>
		/// <param name="playerID1">The player that destroyed the last city</param>
		public void F5_0000_0e6c_TestIfAIPlayerDestroyed(int playerID, int playerID1)
		{
			//this.oCPU.Log.EnterBlock($"F5_0000_0e6c({playerID}, {playerID1})");

			// function body
			if (playerID != 0 && playerID != this.oParent.GameData.HumanPlayerID)
			{
				int cityCount = 0;

				for (int i = 0; i < 128; i++)
				{
					if (this.oParent.GameData.Cities[i].StatusFlag != 0xff && this.oParent.GameData.Cities[i].PlayerID == playerID)
					{
						cityCount++;
					}
				}

				if (cityCount == 0)
				{
					// Instruction address 0x0000:0x0ec1, size: 5
					this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[playerID].Nationality);

					// Instruction address 0x0000:0x0ed1, size: 5
					this.oParent.CAPI.strcat(0xba06, "\ncivilization\ndestroyed\nby ");

					// Instruction address 0x0000:0x0ee6, size: 5
					this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Players[playerID1].Nation);

					// Instruction address 0x0000:0x0ef6, size: 5
					this.oParent.CAPI.strcat(0xba06, "!\n");

					if ((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[playerID] & 0x40) != 0)
					{
						this.oParent.Var_2f9e_MessageBoxStyle = MenuBoxReportTypeEnum.ForeignMinisterReport;
					}
					else
					{
						this.oParent.Var_2f9e_MessageBoxStyle = MenuBoxReportTypeEnum.TravelersReport;
					}


					if (playerID1 == this.oParent.GameData.HumanPlayerID)
					{
						this.oParent.Var_2f9e_MessageBoxStyle = MenuBoxReportTypeEnum.DefenseMinisterReport;
					}

					// Instruction address 0x0000:0x0f32, size: 5
					this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

					// Instruction address 0x0000:0x0f3d, size: 5
					this.oParent.Segment_2459.F0_2459_05ee(playerID);

					// Instruction address 0x0000:0x0f53, size: 5
					this.oParent.UnitManagement.F0_1866_250e_AddReplayData(13, (byte)playerID, (byte)playerID1);

					for (int i = 0; i < 128; i++)
					{
						if (this.oParent.GameData.Players[playerID].Units[i].TypeID != -1)
						{
							// Instruction address 0x0000:0x0f7d, size: 5
							this.oParent.UnitManagement.F0_1866_0f10_DeleteUnit(playerID, i);
						}
					}

					ushort visibilityMask = (ushort)(~(0x1 << playerID));

					for (int j = 0; j < 80; j++)
					{
						for (int k = 0; k < 50; k++)
						{
							this.oParent.GameData.MapVisibility[j, k] &= visibilityMask;
						}
					}

					F5_0000_07c7(playerID);
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		private int F5_0000_0fe6()
		{
			//this.oCPU.Log.EnterBlock("F5_0000_0fe6()");

			// function body
			int[] local_1c = new int[8];
			int nearestPlayers = 0;
			int local_24 = 0;

			for (int i = 1; i < 8; i++)
			{
				if (this.oParent.GameData.Players[i].Units[0].TypeID == -1)
					break;

				int local_6 = 0;
				int shortestDistance = 999;

				for (int j = 1; j < 8; j++)
				{
					if (j != i && this.oParent.GameData.Players[j].Units[0].TypeID != -1 &&
						this.oParent.MapManagement.F0_2aea_1942_GetGroupID(this.oParent.GameData.Players[i].Units[0].Position.X,
						this.oParent.GameData.Players[i].Units[0].Position.Y) == this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
						this.oParent.GameData.Players[j].Units[0].Position.X,
						this.oParent.GameData.Players[j].Units[0].Position.Y))
					{
						// Instruction address 0x0000:0x12ae, size: 5
						int distance = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
							this.oParent.GameData.Players[i].Units[0].Position.X, this.oParent.GameData.Players[i].Units[0].Position.Y,
							this.oParent.GameData.Players[j].Units[0].Position.X, this.oParent.GameData.Players[j].Units[0].Position.Y);

						if (distance < shortestDistance)
						{
							shortestDistance = distance;
						}
					}
				}

				if (shortestDistance >= 10 && shortestDistance != 999)
				{
					nearestPlayers |= (0x1 << i);
				}

				// Instruction address 0x0000:0x12f3, size: 5
				this.oParent.CAPI.strcpy(0xba06, "Nearest civilization: ");

				if (shortestDistance < 10)
				{
					// Instruction address 0x0000:0x130c, size: 5
					this.oParent.CAPI.strcat(0xba06, "close");
				}
				else if (shortestDistance < 20)
				{
					// Instruction address 0x0000:0x1077, size: 5
					this.oParent.CAPI.strcat(0xba06, "moderate");

					local_6++;
				}
				else if (shortestDistance != 999)
				{
					// Instruction address 0x0000:0x1093, size: 5
					this.oParent.CAPI.strcat(0xba06, "far away");

					local_6 += 2;
				}
				else
				{
					// Instruction address 0x0000:0x10a9, size: 5
					this.oParent.CAPI.strcat(0xba06, "isolated");

					local_6 += 4;
				}
				int waterCellCount = 0;
				int grasslandCellCount = 0;
				int riverCellCount = 0;

				for (int k = 0; k < 9; k++)
				{
					GPoint direction = this.oParent.MoveDirections[k];

					int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(this.oParent.GameData.Players[i].Units[0].Position.X + direction.X);
					int newY = this.oParent.GameData.Players[i].Units[0].Position.Y + direction.Y;

					if (this.oParent.MapManagement.F0_2aea_1326_ValidateMapCoordinates(newX, newY))
					{
						// Instruction address 0x0000:0x10ee, size: 5
						switch (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY))
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
				}

				if (waterCellCount != 0)
				{
					// Instruction address 0x0000:0x112f, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Coastal ");
				}
				else
				{
					// Instruction address 0x0000:0x112f, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Inland ");
				}

				if (riverCellCount > 1)
				{
					// Instruction address 0x0000:0x1145, size: 5
					this.oParent.CAPI.strcat(0xba06, "river valley on a ");

					local_6 += 2;
				}
				else if (grasslandCellCount >= 3)
				{
					// Instruction address 0x0000:0x1161, size: 5
					this.oParent.CAPI.strcat(0xba06, "grasslands on a ");

					local_6++;
				}
				else
				{
					// Instruction address 0x0000:0x1176, size: 5
					this.oParent.CAPI.strcat(0xba06, "plains on a ");
				}

				// Instruction address 0x0000:0x119a, size: 5
				switch (this.oParent.MapManagement.F0_2aea_195d_GetMapGroupSize(
					this.oParent.GameData.Players[i].Units[0].Position.X,
					this.oParent.GameData.Players[i].Units[0].Position.Y) / 50)
				{
					case 0:
						// Instruction address 0x0000:0x11e2, size: 5
						this.oParent.CAPI.strcat(0xba06, "small island.");
						break;

					case 1:
						// Instruction address 0x0000:0x11e2, size: 5
						this.oParent.CAPI.strcat(0xba06, "large island.");
						break;

					case 2:
						// Instruction address 0x0000:0x1325, size: 5
						this.oParent.CAPI.strcat(0xba06, "small continent.");
						local_6++;
						break;

					case 3:
						// Instruction address 0x0000:0x1325, size: 5
						this.oParent.CAPI.strcat(0xba06, "medium continent.");
						local_6++;
						break;

					default:
						// Instruction address 0x0000:0x11cc, size: 5
						this.oParent.CAPI.strcat(0xba06, "large continent.");
						local_6 += 2;
						break;
				}

				if (local_6 > local_24)
				{
					local_24 = local_6;
				}

				local_1c[i] = local_6;
			}

			int local_5c = -1;

			for (int i = 1; i < 8; i++)
			{
				if (this.oParent.GameData.Players[i].Units[0].TypeID != -1)
				{
					// Instruction address 0x0000:0x13fb, size: 5
					this.oParent.CAPI.strcpy(0xba06, "Skills: ");

					if (local_24 - local_1c[i] > 3)
					{
						local_1c[i] += 3;

						// Instruction address 0x0000:0x142c, size: 5
						this.oParent.UnitManagement.F0_1866_0cf5_CreateUnit(i, 0,
							this.oParent.GameData.Players[i].Units[0].Position.X, this.oParent.GameData.Players[i].Units[0].Position.Y);

						// Instruction address 0x0000:0x143c, size: 5
						this.oParent.CAPI.strcat(0xba06, "Settlers+");
					}

					int local_48 = 0;

					while (local_24 - local_1c[i] > local_48)
					{
						if (local_48 != 0)
						{
							// Instruction address 0x0000:0x1353, size: 5
							this.oParent.CAPI.strcat(0xba06, "+");
						}

						// Instruction address 0x0000:0x1361, size: 5
						// Instruction address 0x0000:0x1376, size: 5
						this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Technologies[(short)this.oParent.Segment_1ade.F0_1ade_1584(i, 0)].Name);

						local_48++;
					}

					if (local_1c[i] == local_24)
					{
						// Instruction address 0x0000:0x13a6, size: 5
						this.oParent.CAPI.strcat(0xba06, "NONE");

						if (local_5c == -1 || (nearestPlayers & (0x1 << i)) != 0)
						{
							local_5c = i;
						}
					}
				}
			}

			return local_5c;
		}

		/// <summary>
		/// This function loads all game bitmaps
		/// </summary>
		public void F5_0000_1455_LoadBitmaps()
		{
			//this.oCPU.Log.EnterBlock("F5_0000_1455()");

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

			if (this.oParent.Var_d762_AlwaysOneForVGA != 0)
			{
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
						if (j < 2)
						{
							// Instruction address 0x0000:0x15a4, size: 5
							this.oParent.Array_d294[i, j] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) + ((j & 1) * 8), 176, 8, 8);
						}
						else
						{
							// Instruction address 0x0000:0x15a4, size: 5
							this.oParent.Array_d294[i, j] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) - ((j & 1) * 8) + 8, 184, 8, 8);
						}
					}
				}

				for (int i = 0; i < 4; i++)
				{
					// Instruction address 0x0000:0x1624, size: 5
					this.oParent.Array_d2d4[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i * 16) + 128, 176, 16, 16);
				}
			}
			else
			{
				// Instruction address 0x0000:0x163f, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(3, 0, 0, "sprites.pic", 1);

				// Instruction address 0x0000:0x165f, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19fc_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

				for (int i = 0; i < 12; i++)
				{
					// Instruction address 0x0000:0x1687, size: 5
					this.oParent.Array_b886[i, 0] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(3, i * 16, 0, 16, 16);

					// Instruction address 0x0000:0x169e, size: 5
					this.oParent.Array_b886[i, 0] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(3, i * 16, 16, 16, 16);
				}
			}

			if (this.oParent.Var_d762_AlwaysOneForVGA != 0)
			{
				// Instruction address 0x0000:0x16c2, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp257.pic", 0);

				byte[] palette;

				// Instruction address 0x0000:0x16d2, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "sp256.pal", out palette); // 0xbdee

				if (palette.Length > 53)
				{
					for (int i = 0; i < 48; i++)
					{
						this.oParent.Var_6b34[i] = palette[i + 6]; // 0xbdf4 (0xbdee + 6)
					}
				}
			}

			for (int i = 0; i < 8; i++)
			{
				// Instruction address 0x0000:0x1714, size: 5
				this.oParent.Array_b27a[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16, 48, 16, 16);

				// Instruction address 0x0000:0x1732, size: 5
				this.oParent.Array_b29a[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16 + 128, 96, 16, 16);
			}

			// Instruction address 0x0000:0x1758, size: 5
			this.oParent.Var_b2ba = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 48, 32, 16, 16);

			for (int i = 1; i < 16; i++)
			{
				// Instruction address 0x0000:0x1782, size: 5
				this.oParent.Array_6e00[i - 1] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16, 64, 16, 16);

				// Instruction address 0x0000:0x179c, size: 5
				this.oParent.Array_6e00[i + 15] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16, 80, 16, 16);
			}

			for (int i = 0; i < 20; i++)
			{
				// Instruction address 0x0000:0x17d7, size: 5
				this.oParent.Array_d21c[0, i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 7 * i + 160, 0, 7, 15); // 0xd21c

				// Instruction address 0x0000:0x17f4, size: 5
				this.oParent.Array_d21c[1, i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 7 * i + 160, 16, 7, 15); // 0xd244

				// Instruction address 0x0000:0x1811, size: 5
				this.oParent.Array_d21c[2,i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 7 * i + 160, 32, 7, 15); // 0xd26c
			}

			for (int i = 0; i < 4; i++)
			{
				// Instruction address 0x0000:0x1843, size: 5
				this.oParent.Array_7eec[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, i * 16 + 80, 128, 16, 16);
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
				this.oParent.Array_d4ce[8 + i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i & 3) * 8 + 129, (i & 4) * 2 + 33, 7, 7);
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
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 10, this.oParent.Array_1946[i]);

				// Instruction address 0x0000:0x1adb, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_19d4_Rectangle, 0, 128, 320, 32, 2, this.oParent.Array_1956[i]);

				for (int j = 0; j < 28; j++)
				{
					// Instruction address 0x0000:0x19ee, size: 5
					this.oParent.Array_d4ce[64 + (i * 32 + j)] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (j % 20) * 16 + 1, ((j / 20) * 16) + 129, 15, 15);
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1af6_LoadGovernmentImage()
		{
			//this.oCPU.Log.EnterBlock("F5_0000_1af6()");

			// function body
			// Instruction address 0x0000:0x1b17, size: 5
			int governmentTypeID = this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].GovernmentType / 2;
			bool ancientGovernment = true;

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].GovernmentType == 3)
			{
				governmentTypeID = 3;
			}
			else
			{
				// Instruction address 0x0000:0x1b48, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(oParent.GameData.HumanPlayerID, TechnologyEnum.Invention))
				{
					ancientGovernment = false;
				}
			}

			// Instruction address 0x0000:0x1b60, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, $"govt{governmentTypeID}{(ancientGovernment ? 'a' : 'm')}.pic", 0);

			// Instruction address 0x0000:0x1b84, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 160, 60, this.oParent.Var_19e8_Rectangle, 160, 140);
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F5_0000_1ba2_ChangeGovernment()
		{
			//this.oCPU.Log.EnterBlock("F5_0000_1ba2()");

			// function body
			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].GovernmentType != 0)
			{
				// Instruction address 0x0000:0x1bb9, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

				// Instruction address 0x0000:0x1bcc, size: 5
				this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Nationality);

				// Instruction address 0x0000:0x1bdc, size: 5
				this.oParent.CAPI.strcat(0xba06, " government\nchanged to ");

				// Instruction address 0x0000:0x1bf8, size: 5
				this.oParent.CAPI.strcat(0xba06, this.oParent.Array_1966[this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].GovernmentType]);

				// Instruction address 0x0000:0x1c08, size: 5
				this.oParent.CAPI.strcat(0xba06, "!\n");

				this.oParent.Overlay_21.F21_0000_0000(-2);

				// Instruction address 0x0000:0x1c38, size: 5
				this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, 15);

				this.oParent.Var_aa_Rectangle.FontID = 6;

				// Instruction address 0x0000:0x1c58, size: 5
				this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0("New Cabinet:", 160, 102, 0);

				this.oParent.Var_aa_Rectangle.FontID = 2;

				for (int i = 0; i < 4; i++)
				{
					// Instruction address 0x0000:0x1cbb, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, (40 * i) + 160, 140, 40, 60,
						this.oParent.Var_aa_Rectangle, (80 * i) + 20, 118);

					// Instruction address 0x0000:0x1cd0, size: 5
					this.oParent.CAPI.strcpy(0xba06, this.oParent.Array_2fac[i]);

					// Instruction address 0x0000:0x1cdc, size: 5
					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + this.oParent.CAPI.strlen(0xba06) - 1), 0x0);

					// Instruction address 0x0000:0x1c7c, size: 5
					this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, (80 * i) + 40, ((i & 1) != 0) ? 186 : 180, 0);
				}

				this.oParent.Var_aa_Rectangle.FontID = 1;

				// Instruction address 0x0000:0x1d06, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

				// Instruction address 0x0000:0x1d0b, size: 5
				this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F5_0000_1d1a_InitSpaceshipData(int playerID)
		{
			//this.oCPU.Log.EnterBlock($"F5_0000_1d1a_InitSpaceshipData({playerID})");

			// function body
			this.oParent.GameData.Players[playerID].SpaceshipETAYear = -1;

			for (int i = 0; i < 15; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					this.oParent.GameData.Players[playerID].SpaceshipData[(12 * i) + j] = -1;
				}
			}
		}
	}
}
