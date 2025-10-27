using System;
using System.Xml.Linq;
using IRB.Collections.Generic;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class Segment_25fb
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		byte[,] Array_2438 = new byte[20, 13];
		int[,] Array_b2be = new int[8, 32];
		public int[,] Array_e2c2 = new int[8, 32];
		public int[,] Array_e598 = new int[8, 32];
		public int[,] Array_e798 = new int[8, 32];

		public Segment_25fb(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;

			for (int i = 0; i < 8; i++)
			{
				for (int j = 0; j < 32; j++)
				{
					Array_b2be[i, j] = 0;
					Array_e2c2[i, j] = 0;
					Array_e598[i, j] = 0;
					Array_e798[i, j] = 0;
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_25fb_0004(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_0004({playerID})");

			// function body
			int local_2;
			int local_4;
			int[] local_44 = new int[32];
			int local_46;
			int local_48;
			int local_4a;
			int local_4e;
			int local_50;
			int local_52;
			int local_54;
			int local_58;
			int local_5c;
			int local_5e;
			int local_60;
			int local_62;
			int local_66;

			for (int i = 0; i < 16; i++)
			{
				this.oGameData.Players[playerID].Continents[i].CityCount = 0;
				this.oGameData.Players[playerID].Continents[i].Defense = 0;
				this.oGameData.Players[playerID].Continents[i].Attack = 0;
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					Array_2438[i, j] = 0;
				}
			}

			this.oGameData.Players[playerID].MilitaryPower = 0;
			this.oGameData.Players[playerID].SettlerCount = 0;
			this.oGameData.Players[playerID].UnitCount = 0;

			for (int i = 0; i < 128; i++)
			{
				if (this.oGameData.Players[playerID].Units[i].TypeID != -1 &&
					this.oGameData.Players[playerID].Units[i].TypeID != 25)
				{
					if (this.oGameData.Players[playerID].Units[i].TypeID != 0)
					{
						this.oGameData.Players[playerID].UnitCount++;
					}
					else
					{
						this.oGameData.Players[playerID].SettlerCount++;
					}

					this.oGameData.Players[playerID].MilitaryPower +=
						this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[i].TypeID].AttackStrength;
					this.oGameData.Players[playerID].MilitaryPower +=
						this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[i].TypeID].DefenseStrength;

					this.oGameData.Players[playerID].Units[i].Status &= 0xef;

					// Instruction address 0x25fb:0x00ca, size: 5
					if (this.oParent.Segment_1866.F0_1866_1750_UpdateVisibility(playerID, this.oGameData.Players[playerID].Units[i].Position.X, this.oGameData.Players[playerID].Units[i].Position.Y) != 0)
					{
						this.oGameData.Players[playerID].Units[i].Status |= 0x10;
					}

					// Instruction address 0x25fb:0x00f7, size: 5
					if (this.oGameData.Map[this.oGameData.Players[playerID].Units[i].Position].TerrainType != TerrainTypeEnum.Water)
					{
						// Instruction address 0x25fb:0x0110, size: 5
						int groupID = this.oGameData.Map[this.oGameData.Players[playerID].Units[i].Position].Layer3_GroupID;

						this.oGameData.Players[playerID].Continents[groupID].Attack +=
							this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[i].TypeID].DefenseStrength;
						this.oGameData.Players[playerID].Continents[groupID].Defense +=
							this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[i].TypeID].AttackStrength;
					}
					else
					{
						if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[i].TypeID].MovementType == UnitMovementTypeEnum.Land)
						{
							this.oGameData.Players[playerID].Units[i].Status |= 0x10;
						}
					}

					Array_2438[this.oGameData.Players[playerID].Units[i].Position.X / 4,
						this.oGameData.Players[playerID].Units[i].Position.Y / 4] |= (byte)(2 << this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[i].TypeID].UnitCategory);
				}
			}

			// Instruction address 0x25fb:0x0210, size: 5
			local_4 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oGameData.Players[playerID].UnitCount / 8, 3, 99);
			this.oGameData.Players[playerID].TotalCitySize = 0;
			this.oGameData.Players[playerID].CityCount = 0;

			for (int i = 0; i < 28; i++)
			{
				this.oGameData.Players[playerID].UnitsInProduction[i] = 0;
			}

			for (int i = 0; i < 128; i++)
			{
				if (this.oGameData.Cities[i].StatusFlag != 0xff)
				{
					if (this.oGameData.Cities[i].PlayerID == playerID)
					{
						this.oGameData.Players[playerID].CityCount++;
						this.oGameData.Players[playerID].Continents[this.oGameData.Map[this.oGameData.Cities[i].Position].Layer3_GroupID].CityCount++;
						this.oGameData.Players[playerID].TotalCitySize += this.oGameData.Cities[i].ActualSize;

						if (this.oGameData.Cities[i].CurrentProductionID >= 0)
						{
							this.oGameData.Players[playerID].UnitsInProduction[this.oGameData.Cities[i].CurrentProductionID]++;
						}

						Array_2438[this.oGameData.Cities[i].Position.X / 4, this.oGameData.Cities[i].Position.Y / 4] |= 1;

						for (int j = 0; j < 2; j++)
						{
							if (this.oGameData.Cities[i].Unknown[j] != -1)
							{
								this.oGameData.Players[playerID].MilitaryPower +=
									this.oGameData.Static.Units[this.oGameData.Cities[i].Unknown[j] & 0x3f].AttackStrength;
								this.oGameData.Players[playerID].MilitaryPower +=
									this.oGameData.Static.Units[this.oGameData.Cities[i].Unknown[j] & 0x3f].DefenseStrength;

								int groupID = this.oGameData.Map[this.oGameData.Cities[i].Position].Layer3_GroupID;

								this.oGameData.Players[playerID].Continents[groupID].Attack =
									this.oGameData.Static.Units[this.oGameData.Cities[i].Unknown[j] & 0x3f].DefenseStrength;

								this.oGameData.Players[playerID].Continents[groupID].Defense +=
									this.oGameData.Static.Units[this.oGameData.Cities[i].Unknown[j] & 0x3f].AttackStrength;
							}
						}
					}
					else
					{
						if (this.oGameData.TurnCount * this.oGameData.DifficultyLevel > 200 ||
							this.oGameData.Map[this.oGameData.Cities[i].Position].IsVisibleTo(playerID) ||
							this.oGameData.Cities[i].PlayerID != this.oGameData.HumanPlayerID)
						{
							if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.Cities[i].PlayerID] & 0x102) != 2 &&
								((i + this.oGameData.TurnCount) & 0x3) != 0)
							{
								if ((this.oGameData.Cities[i].ImprovementFlags0 & 0x80) == 0)
								{
									// Instruction address 0x25fb:0x0264, size: 3
									F0_25fb_304d(playerID, this.oGameData.Cities[i].Position.X, this.oGameData.Cities[i].Position.Y, 1, 5);
								}
								else
								{
									// Instruction address 0x25fb:0x0264, size: 3
									F0_25fb_304d(playerID, this.oGameData.Cities[i].Position.X, this.oGameData.Cities[i].Position.Y, 1, 3);
								}
							}
						}
					}

					// Instruction address 0x25fb:0x03ab, size: 5
					if ((short)this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(this.oGameData.Cities[i].Position.X,
						this.oGameData.Cities[i].Position.Y) == -1)
					{
						if (this.oGameData.Cities[i].Unknown[0] == -1)
						{
							if (this.oGameData.Cities[i].PlayerID == playerID)
							{
								// Instruction address 0x25fb:0x03e4, size: 3
								F0_25fb_304d(playerID, this.oGameData.Cities[i].Position.X, this.oGameData.Cities[i].Position.Y, 2, 4);
							}
							else
							{
								// Instruction address 0x25fb:0x03e4, size: 3
								F0_25fb_304d(playerID, this.oGameData.Cities[i].Position.X, this.oGameData.Cities[i].Position.Y, 2, 2);
							}
						}
					}
				}
			}

			this.oGameData.Players[playerID].LandCount = 0;

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					if (Array_2438[i, j] != 0)
					{
						this.oGameData.Players[playerID].LandCount++;
					}
				}
			}

			this.oGameData.Players[playerID].Continents[0].Strategy = 0;
			this.oGameData.Players[playerID].Continents[15].Strategy = 0;

			this.oParent.Var_2a6e |= (1 << playerID);
			this.oParent.Var_2a6e ^= (1 << playerID);
			this.oParent.Var_6ed4 = 0;

			for (int i = 1; i < 8; i++)
			{
				if ((this.oGameData.Players[playerID].Diplomacy[i] & 3) == 1)
				{
					this.oParent.Var_6ed4 = 1;
				}
			}

			local_48 = -1;

			for (int i = 1; i < 15; i++)
			{
				local_5e = 0;
				local_2 = 0;
				local_62 = 0;
				local_5c = 0;
				local_4e = 0;
				local_60 = this.oGameData.Players[playerID].Continents[i].Strategy;

				for (int j = 1; j < 8; j++)
				{
					if (this.oGameData.Players[j].Continents[i].Attack != 0)
					{
						if (this.oGameData.Players[playerID].Continents[i].Defense / 4 < this.oGameData.Players[j].Continents[i].Defense ||
							this.oGameData.Players[j].Continents[i].CityCount != 0)
						{
							if ((this.oGameData.Players[playerID].Diplomacy[j] & 3) == 1 ||
								(this.oGameData.Players[playerID].Diplomacy[j] & 0x100) != 0)
							{
								if (this.oGameData.Players[j].Continents[i].Attack < this.oGameData.Players[playerID].Continents[i].Defense ||
									this.oGameData.Players[j].Continents[i].Defense < this.oGameData.Players[playerID].Continents[i].Attack)
								{
									local_5e++;
								}
								else if (this.oGameData.Players[playerID].Continents[i].CityCount != 0)
								{
									local_2++;
								}
								else
								{
									break;
								}
							}
						}
					}

					if (this.oGameData.Players[j].Continents[i].Attack != 0)
					{
						if (j == this.oGameData.HumanPlayerID)
						{
							if ((this.oGameData.Players[playerID].Diplomacy[j] & 2) != 0)
							{
								if ((this.oGameData.Players[playerID].Continents[i].Defense / 2) + this.oGameData.Players[playerID].Continents[i].Attack <
									this.oGameData.Players[j].Continents[i].Defense)
								{
									local_2++;
								}
							}
						}
					}

					local_4e += this.oGameData.Players[j].Continents[i].Attack;
					local_5c += this.oGameData.Players[j].Continents[i].CityCount;

					if (this.oGameData.Players[j].Continents[i].Attack != 0)
					{
						if ((this.oGameData.Players[playerID].Diplomacy[j] & 2) != 0)
						{
							local_62 |= 0x1;
						}
						else
						{
							local_62 |= 0x2;
						}
					}
				}

				if (this.oGameData.Players[0].Continents[i].CityCount != 0)
				{
					local_5e++;
				}

				if (((this.oGameData.Players[playerID].Continents[i].Attack + local_4e) * 2 > this.oGameData.Map.Groups[i].Size ||
					((this.oGameData.Players[playerID].Continents[i].CityCount + local_5c) * 6) + 2 > this.oGameData.Map.Groups[i].BuildSiteCount) &&
					this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Mapmaking) != 0)
				{
					this.oGameData.Players[playerID].Continents[i].Strategy = 5;
				}
				else
				{
					this.oGameData.Players[playerID].Continents[i].Strategy = 0;
				}

				if (local_5e != 0)
				{
					this.oGameData.Players[playerID].Continents[i].Strategy = 1;
				}

				if (local_2 != 0)
				{
					this.oGameData.Players[playerID].Continents[i].Strategy = 2;
				}

				if (this.oGameData.Players[playerID].Continents[i].Attack == 0 &&
					this.oGameData.Players[playerID].Continents[i].CityCount == 0 &&
					local_62 != 1)
				{
					this.oGameData.Players[playerID].Continents[i].Strategy = 1;
				}

				if (local_48 < this.oGameData.Players[playerID].Continents[i].CityCount)
				{
					local_48 = this.oGameData.Players[playerID].Continents[i].CityCount;
				}

				if (this.oGameData.Players[playerID].Continents[i].Strategy != local_60)
				{
					if (playerID != this.oGameData.HumanPlayerID)
					{
						// Instruction address 0x25fb:0x0797, size: 3
						F0_25fb_3459(playerID, i);
					}
				}

				if (this.oGameData.Players[playerID].Continents[i].Attack != 0 &&
					this.oGameData.Players[this.oGameData.HumanPlayerID].Continents[i].CityCount > 1)
				{
					this.oParent.Var_2a6e |= (1 << playerID);
				}
			}

			if (playerID != 0 && playerID != this.oGameData.HumanPlayerID)
			{
				if (playerID != this.oGameData.HumanPlayerID &&
					this.oGameData.Players[playerID].SettlerCount == 0 && this.oGameData.Players[playerID].CityCount == 0)
				{
					this.oParent.StartGameMenu.F5_0000_0e6c_PlayerCheckEndGame(playerID, 0);
				}

				if (((playerID + this.oGameData.TurnCount) & 0x7) == 0)
				{
					if (this.oParent.Var_e3c2 <= 0)
					{
						// Instruction address 0x25fb:0x085e, size: 5
						if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.TheRepublic) != 0 && this.oParent.Var_db42 >= 0)
						{
							// Instruction address 0x25fb:0x08b9, size: 5
							this.oParent.Segment_2517.F0_2517_04a1(playerID, 4);
						}
						else
						{
							// Instruction address 0x25fb:0x087d, size: 5
							if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Communism) != 0 &&
								this.oGameData.Players[playerID].CityCount > 10)
							{
								// Instruction address 0x25fb:0x08b9, size: 5
								this.oParent.Segment_2517.F0_2517_04a1(playerID, 3);
							}
							else
							{
								// Instruction address 0x25fb:0x08a1, size: 5
								if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Monarchy) != 0)
								{
									// Instruction address 0x25fb:0x08b9, size: 5
									this.oParent.Segment_2517.F0_2517_04a1(playerID, 2);
								}
							}
						}
					}
					else
					{
						// Instruction address 0x25fb:0x08b9, size: 5
						this.oParent.Segment_2517.F0_2517_04a1(playerID, 1);
					}
				}

				for (int i = 0; i < 32; i++)
				{
					local_44[i] = local_4;
				}

				local_54 = 0;
				goto L09f8;

			L09f5:
				local_54++;

			L09f8:
				int groupID;

				if (local_54 < 128)
				{
					if (this.oGameData.Players[playerID].Units[local_54].TypeID == -1 ||
						(this.oGameData.Players[playerID].Units[local_54].Status & 0x10) != 0 ||
						this.oGameData.Players[playerID].Units[local_54].TypeID == 25)
						goto L09f5;

					local_4a = 0x270f;
					local_62 = -1;
					local_50 = this.oGameData.Players[playerID].Units[local_54].Position.X;
					local_52 = this.oGameData.Players[playerID].Units[local_54].Position.Y;

					// Instruction address 0x25fb:0x0910, size: 5
					groupID = this.oGameData.Map[local_50, local_52].Layer3_GroupID;

					// Instruction address 0x25fb:0x0938, size: 5
					// Instruction address 0x25fb:0x0989, size: 5
					// Instruction address 0x25fb:0x09c7, size: 5
					// Instruction address 0x25fb:0x099e, size: 5
					if (((local_54 + this.oGameData.TurnCount) & 0xf) == 0 &&

						(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
						(int)this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_54].TypeID].ObsoletesAfterTechnology) != 0 ||
						((this.oGameData.Players[playerID].GovernmentType > 1 || this.oGameData.Players[playerID].Continents[groupID].Strategy == 5) &&
							this.oGameData.Players[playerID].Units[local_54].TypeID != 1)) &&

						(this.oParent.Segment_1866.F0_1866_1750_UpdateVisibility(playerID, local_50, local_52) == 0 &&
						(!this.oGameData.Map[local_50, local_52].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City) ||
							this.oGameData.Players[playerID].Units[local_54].NextUnitID != -1) &&
						this.oGameData.Map[local_50, local_52].TerrainType != TerrainTypeEnum.Water &&
						this.oGameData.Players[playerID].Continents[groupID].Strategy != 2))
					{
						// Instruction address 0x25fb:0x09ed, size: 5
						this.oParent.Segment_1866.F0_1866_0f10(playerID, (short)local_54);

						goto L09f5;
					}

					local_58 = 0;

					goto L0ad2;
				}

				goto L0c97;

			L0acf:
				local_58++;

			L0ad2:
				if (local_58 < 32) goto L0adb;

				if (local_62 != -1)
				{
					this.oGameData.Players[playerID].Units[local_54].GoToDestination.X = Array_e598[playerID, local_62];
					this.oGameData.Players[playerID].Units[local_54].GoToDestination.Y = Array_e798[playerID, local_62];
					this.oGameData.Players[playerID].Units[local_54].Status |= 0x10;
					this.oGameData.Players[playerID].Units[local_54].Status &= 0xf0;

					local_44[local_62]++;
				}

				goto L09f5;

			L0adb:
				if (Array_e2c2[playerID, local_58] != 0xff)
				{
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_54].TypeID].UnitCategory != Array_e2c2[playerID, local_58])
						goto L0b28;

					if (this.oGameData.Map[Array_e598[playerID, local_58], Array_e798[playerID, local_58]].Layer3_GroupID == groupID) goto L0b6c;

				L0b28:
					if (this.oGameData.Players[playerID].Units[local_54].TypeID == 15)
					{
						local_66 = Array_e2c2[playerID, local_58];

						if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_54].TypeID].UnitCategory == local_66 || local_66 == 3) goto L0b6c;
					}
				}

				goto L0acf;

			L0b6c:
				if (this.oGameData.Players[playerID].Units[local_54].TypeID != 15)
				{
					// Instruction address 0x25fb:0x0a5f, size: 5				
					local_46 = (local_44[local_58] * this.oGameData.Map.GetDistance(local_50, local_52,
						Array_e598[playerID, local_58], Array_e798[playerID, local_58])) / (Array_b2be[playerID, local_58] + 1);
				}
				else
				{
					if ((Array_b2be[playerID, local_58] & 0x1) == 0 || ((local_58 + (this.oGameData.TurnCount / 2)) & 0x1) == 0)
						goto L0acf;

					// Instruction address 0x25fb:0x0bc0, size: 5
					local_46 = this.oGameData.Map.GetDistance(local_50, local_52, Array_e598[playerID, local_58], Array_e798[playerID, local_58]);

					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_54].TypeID].MoveCount < local_46)
					{
						local_46 = (local_46 * 4) / (Array_b2be[playerID, local_58] + 1);
					}
					else
					{
						local_46 = (local_46 * 2) / (Array_b2be[playerID, local_58] + 1);
					}
				}

				if ((this.oGameData.Players[playerID].Units[local_54].Status & 0xc) == 0 ||
					(Array_b2be[playerID, local_58] >= 2 && (Array_b2be[playerID, local_58] * local_4 >= local_46 || local_44[local_58] == local_4) &&
					!this.oGameData.Map[this.oGameData.Players[playerID].Units[local_54].Position].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City)))
				{
					if (local_46 < local_4a)
					{
						if (Array_b2be[playerID, local_58] * 4 >= local_46 / local_4)
						{
							local_4a = local_46;
							local_62 = local_58;
						}
					}
				}

				goto L0acf;
			}

		L0c97:
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_0004");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_25fb_0c9d(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_0c9d({playerID}, {unitID})");

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_a;
			int local_c = 0;
			int local_e;
			int local_10;
			int local_12 = 0;
			int local_14;
			int local_16;
			int groupID;
			int local_1c;
			int local_1e;
			int local_20;
			int local_22;
			int local_24;
			int local_26;
			int local_28;
			int local_2a;
			int local_2c;
			int local_2e;
			int local_30;
			int local_32;
			int local_34;
			int local_36;
			TerrainTypeEnum local_38;
			int local_3a = 0;
			int local_3c;
			int local_3e;
			int local_40;
			TerrainTypeEnum local_42;
			int local_44;
			int local_4a;
			int local_4c;
			int local_52 = 0;
			int local_54;
			int local_56;
			int local_58;
			int local_5a;
			int local_5c;

			if (playerID == 0)
			{
				// Instruction address 0x25fb:0x0cc6, size: 3
				F0_25fb_362d(playerID, unitID);
			}
			else
			{
				if (this.oGameData.Players[playerID].Units[unitID].TypeID == 15 &&
					this.oGameData.Players[playerID].Units[unitID].SpecialMoves <= 0)
				{
					this.oCPU.AX.UInt16 = 0x68;
				}
				else
				{
					if (this.oGameData.Players[playerID].Units[unitID].TypeID != 14 ||
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
						goto L0f13;

					if ((this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MoveCount / 2) * 3 >= 
						this.oGameData.Players[playerID].Units[unitID].RemainingMoves)
					{
						this.oCPU.AX.UInt16 = 0x68;
						goto L2fd0;
					}

					local_14 = 999;
					local_4 = -1;
					local_40 = 0;

				L0d47:
					if (this.oGameData.Players[this.oGameData.HumanPlayerID].Units[local_40].TypeID == 15 &&
						this.oGameData.Players[this.oGameData.HumanPlayerID].Units[local_40].IsVisibleTo(playerID))
					{
						// Instruction address 0x25fb:0x0d96, size: 5
						local_12 = this.oGameData.Map.GetDistance(this.oGameData.Players[playerID].Units[unitID].Position,
							this.oGameData.Players[this.oGameData.HumanPlayerID].Units[local_40].Position);

						if (local_12 < local_14)
						{
							local_14 = local_12;
							local_4 = local_40;
						}
					}

					local_40++;

					if (local_40 < 128) goto L0d47;

					if (local_4 != -1 && local_12 > 1) goto L0dd1;
					goto L0f13;

				L0dd1:
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MoveCount <= local_14)
						goto L0e16;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Players[this.oGameData.HumanPlayerID].Units[local_4].Position.X;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Players[this.oGameData.HumanPlayerID].Units[local_4].Position.Y;

					goto L0f13;

				L0e16:
					local_14 = 999;
					local_34 = -1;
					local_40 = 0;

					goto L0e70;

				L0e27:
					// Instruction address 0x25fb:0x0e55, size: 5
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MoveCount >=
						this.oGameData.Map.GetDistance(this.oGameData.Players[playerID].Units[unitID].Position, this.oGameData.Cities[local_40].Position))
						goto L0e92;

				L0e6d:
					local_40++;

				L0e70:
					if (local_40 >= 128) goto L0ee2;

					if (this.oGameData.Cities[local_40].StatusFlag == 0xff) goto L0e6d;

					if (this.oGameData.Cities[local_40].PlayerID == playerID) goto L0e27;

					goto L0e6d;

				L0e92:
					// Instruction address 0x25fb:0x0ec1, size: 5
					local_12 = this.oGameData.Map.GetDistance(this.oGameData.Players[this.oGameData.HumanPlayerID].Units[local_4].Position, 
						this.oGameData.Cities[local_40].Position);

					if (local_12 >= local_14) goto L0e6d;

					local_14 = local_12;
					local_34 = local_40;
					goto L0e6d;

				L0ee2:
					if (local_34 != -1) goto L0eeb;

					goto L16b3;

				L0eeb:
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[local_34].Position.X;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[local_34].Position.Y;

				L0f13:
					// Instruction address 0x25fb:0x0f32, size: 5
					local_4c = (short)this.oParent.Segment_1866.F0_1866_1725_UpdateCityVisibility(playerID,
						this.oGameData.Players[playerID].Units[unitID].Position.X,
						this.oGameData.Players[playerID].Units[unitID].Position.Y);
					local_2c = 0;
					local_30 = this.oGameData.Players[playerID].Units[unitID].Position.X;
					local_36 = this.oGameData.Players[playerID].Units[unitID].Position.Y;
					local_8 = this.oGameData.Players[playerID].Units[unitID].TypeID;
					// Instruction address 0x25fb:0x0f60, size: 5
					local_34 = this.oParent.Segment_2dc4.F0_2dc4_0102_FindNearestCity(local_30, local_36);
					local_2a = this.oParent.Var_6c9a;
					this.oGameData.Players[playerID].Units[unitID].TypeID = -1;
					// Instruction address 0x25fb:0x0f82, size: 5
					local_4 = this.oParent.Segment_2dc4.F0_2dc4_0177(playerID, unitID, local_30, local_36);
					local_32 = this.oParent.Var_6c9a;
					this.oGameData.Players[playerID].Units[unitID].TypeID = (short)local_8;
					// Instruction address 0x25fb:0x0fa0, size: 5
					local_42 = this.oGameData.Map[local_30, local_36].TerrainType;
					local_56 = this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].UnitCategory;
					// Instruction address 0x25fb:0x0fc0, size: 5
					groupID = this.oGameData.Map[local_30, local_36].Layer3_GroupID;
					local_2 = this.oGameData.Players[playerID].Continents[groupID].Strategy;

					if (local_8 == 25) goto L0ff1;

					goto L12a3;

				L0ff1:
					local_28 = -1;
					local_c = 0;
					goto L10ff;

				L0ffe:
					if (local_20 != playerID) goto L100c;

					local_3a -= 2;

					goto L1010;

				L100c:
					local_3a -= 0x63;

				L1010:
					local_40++;

				L1013:
					if (local_40 > 8) goto L106e;

					GPoint direction = TerrainMap.MoveOffsets[local_40];
					local_26 = this.oGameData.Cities[local_c].Position.X + direction.X;
					local_2e = this.oGameData.Cities[local_c].Position.Y + direction.Y;

					// Instruction address 0x25fb:0x1044, size: 5
					local_20 = this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_26, local_2e);

					if (local_20 == -1) goto L1010;

					if ((this.oGameData.Players[playerID].Diplomacy[local_20] & 0x82) != 0x80)
						goto L0ffe;

					local_3a++;

					goto L1010;

				L106e:
					local_3a += this.oGameData.Cities[local_c].ActualSize / 2;

				L1083:
					if (local_3a <= local_28) goto L10fc;

					local_3e = 0;
					local_22 = 0;
					goto L109a;

				L1097:
					local_22++;

				L109a:
					if (local_22 >= 128) goto L10ea;

					if (this.oGameData.Cities[local_22].StatusFlag == 0xff) goto L1097;

					if (this.oGameData.Cities[local_22].PlayerID != playerID) goto L1097;

					// Instruction address 0x25fb:0x10d8, size: 5
					if (this.oGameData.Map.GetDistance(this.oGameData.Cities[local_c].Position, this.oGameData.Cities[local_22].Position) > 16) goto L1097;

					local_3e = 1;

				L10ea:
					if (local_3e == 0) goto L10fc;

					local_28 = local_3a;
					local_34 = local_c;

				L10fc:
					local_c++;

				L10ff:
					if (local_c < 128) goto L1109;
					goto L11ad;

				L1109:
					local_3a = this.oGameData.Cities[local_c].PlayerID;

					if (this.oGameData.Cities[local_c].StatusFlag != 0xff) 
						goto L1123;
					goto L1083;

				L1123:
					if ((this.oGameData.Cities[local_c].ImprovementFlags1 & 0x1) == 0) 
						goto L112e;
					goto L1083;

				L112e:					
					if (this.oGameData.Players[playerID].MilitaryPower * 3 < this.oGameData.Players[local_3a].MilitaryPower * 2) 
						goto L1176;

					if ((this.oGameData.Players[playerID].Diplomacy[local_3a] & 8) != 0)
						goto L1176;

					if (this.oGameData.Players[local_3a].ActiveUnits[25] != 0)
						goto L1083;

					if (this.oGameData.Players[playerID].MilitaryPower < this.oGameData.Players[local_3a].MilitaryPower * 2) 
						goto L1176;
					goto L1083;

				L1176:
					if ((this.oGameData.Players[playerID].Diplomacy[local_3a] & 0x82) != 0x80)
						goto L1083;

					if (this.oGameData.Cities[local_c].ActualSize > 4)
						goto L11a0;
					goto L1083;

				L11a0:
					local_3a = 0;
					local_40 = 0;
					goto L1013;

				L11ad:
					if (local_28 >= 10)
						goto L11b6;
					goto L16b3;

				L11b6:
					if (this.oGameData.Players[playerID].ActiveUnits[25] <= 1)
						goto L16b3;

					local_c = local_34;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[local_c].Position.X;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[local_c].Position.Y;

					local_40 = 1;

					goto L1200;

				L11fd:
					local_40++;

				L1200:
					if (local_40 <= 8) goto L1209;
					goto L16b3;

				L1209:
					direction = TerrainMap.MoveOffsets[local_40];

					local_26 = this.oGameData.Players[playerID].Units[unitID].GoToDestination.X + direction.X;
					local_2e = this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y + direction.Y;

					// Instruction address 0x25fb:0x123c, size: 5
					if (this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_26, local_2e) != -1) goto L11fd;

					// Instruction address 0x25fb:0x1253, size: 5
					this.oParent.MapManagement.F0_2aea_1412(playerID, unitID, local_30, local_36);

					this.oGameData.Players[playerID].Units[unitID].Position.X = local_26;
					this.oGameData.Players[playerID].Units[unitID].Position.Y = local_2e;

					// Instruction address 0x25fb:0x1275, size: 5
					this.oParent.MapManagement.F0_2aea_13cb(playerID, unitID, local_26, local_2e);

					if (this.oGameData.Cities[local_34].PlayerID == this.oGameData.HumanPlayerID)
					{
						this.oGameData.Players[playerID].ContactPlayerCountdown = -2;
					}

					this.oCPU.AX.UInt16 = (ushort)((short)(local_40 ^ 0x4));
					goto L2fd0;

				L12a3:
					if (local_8 != 26) goto L1307;

					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X == -1)
						goto L12c5;

					this.oCPU.AX.UInt16 = 0;
					goto L2fd0;

				L12c5:
					if (this.oGameData.Cities[local_34].PlayerID == playerID) goto L12f9;

				L12d7:
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[local_34].Position.X;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[local_34].Position.Y;

					this.oCPU.AX.UInt16 = 0;
					goto L2fd0;

				L12f9:
					// Instruction address 0x25fb:0x12ff, size: 5
					this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

				L1307:
					if (local_56 == 0)
					{
						// Instruction address 0x25fb:0x131b, size: 3
						F0_25fb_3401(playerID, 0, local_30, local_36, 0);
					}
				
					// Instruction address 0x25fb:0x132f, size: 5
					//this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
					//	local_30 + 80,
					//	local_36);
					local_28 = this.oGameData.Map[local_30, local_36].Layer2_PlayerOwnership;

					if (local_28 != 0 && local_56 < 3) goto L134a;
					goto L1434;

				L134a:
					local_2c = 0;
					local_40 = 1;

					goto L1359;

				L1356:
					local_40++;

				L1359:
					if (local_40 > 8) goto L13d9;

					direction = TerrainMap.MoveOffsets[local_40];
					// Instruction address 0x25fb:0x136c, size: 5
					local_26 = this.oGameData.Map.WrapXPosition(local_30 + direction.X);
					local_2e = direction.Y + local_36;

					// Instruction address 0x25fb:0x138d, size: 5
					//this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
					//	local_26 + 80,
					//	local_2e);

					local_10 = this.oGameData.Map[local_26, local_2e].Layer2_PlayerOwnership;

					if (local_10 <= local_28) goto L13ac;

					local_28 = local_10;
					local_2c = local_40;

				L13ac:
					// Instruction address 0x25fb:0x13b8, size: 5
					// Instruction address 0x25fb:0x13c1, size: 5
					if (this.oParent.MapManagement.F0_2aea_1894(local_26, local_2e, this.oGameData.Map[local_26, local_2e].TerrainType) == 0) goto L1356;

					if (local_56 == 0) goto L1356;

					this.oCPU.AX.UInt16 = (ushort)((short)local_40);
					goto L2fd0;

				L13d9:
					if (this.oGameData.TurnCount != 0 || !this.oParent.Var_d76a_IsEarthMap) goto L13f1;

					local_28 = 15;
					local_2c = 0;

				L13f1:
					if (local_28 < 8) goto L1434;

					if (15 - local_2a > local_28) goto L1434;

					if (local_4c != 0) goto L1434;

					if (local_56 != 0) goto L141d;

					if (local_2c == 0) goto L1417;

					goto L2fcd;

				L1417:
					this.oCPU.AX.UInt16 = 0x62;
					goto L2fd0;

				L141d:
					// Instruction address 0x25fb:0x142e, size: 3
					F0_25fb_3251_AddStrategicLocation(playerID, local_30, local_36, 0, 2);

				L1434:
					if (local_56 != 0) goto L14ac;

					if (this.oGameData.DifficultyLevel == 0) goto L14ac;

					if (this.oGameData.HumanPlayerID != ((local_34 < 128) ? this.oGameData.Cities[local_34].PlayerID : -1)) goto L14ac;

					if (local_4c != 0) goto L14ac;

					if (local_2a <= 1) goto L14ac;

					if (playerID == ((local_34 < 128) ? this.oGameData.Cities[local_34].PlayerID : -1)) goto L14ac;

					if (this.oGameData.Players[playerID].DiscoveredTechnologyCount >= this.oGameData.Players[this.oGameData.HumanPlayerID].DiscoveredTechnologyCount)
						goto L14ac;

					// Instruction address 0x25fb:0x148e, size: 5
					//this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
					//	local_30 + 80,
					//	local_36 + 50);

					local_3a = this.oGameData.Map[local_30, local_36].Layer4_BuildSites;

					if (local_3a < 9) goto L14ac;

					if (14 - local_2a > local_3a) goto L14ac;
					goto L1417;

				L14ac:
					// Instruction address 0x25fb:0x14b2, size: 5
					if (this.oGameData.Map[local_30, local_36].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City)) goto L14c1;
					goto L166c;

				L14c1:
					if (local_56 == 2) goto L14ca;
					goto L168f;

				L14ca:
					if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1)
						goto L14e7;

					this.oCPU.AX.UInt16 = 0x66;
					goto L2fd0;

				L14e7:
					local_3a = this.oGameData.Players[playerID].Units[unitID].TypeID;

					this.oGameData.Players[playerID].Units[unitID].TypeID = 26;

					// Instruction address 0x25fb:0x150c, size: 5
					local_20 = (short)this.oParent.Segment_1866.F0_1866_1089(playerID, unitID);

					this.oGameData.Players[playerID].Units[unitID].TypeID = (short)local_3a;

					if (local_20 != -1)
					{
						if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_20].TypeID].DefenseStrength <
							this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].DefenseStrength)
						{
							this.oCPU.AX.UInt16 = 0x66;
							goto L2fd0;
						}
					}

					// Instruction address 0x25fb:0x154e, size: 5
					if (this.oParent.Segment_1866.F0_1866_1750_UpdateVisibility(playerID, local_30, local_36) != 0)
					{
						local_6 = 3;
					}
					else
					{
						local_6 = 4;
					}

					if ((this.oGameData.Cities[local_34].ImprovementFlags0 & 0x1) == 0) goto L1579;

					local_6--;

					goto L1582;

				L1579:
					if (local_2 != 0) goto L1582;

					local_6++;

				L1582:
					// Instruction address 0x25fb:0x158c, size: 5
					local_3a = (short)this.oParent.Segment_1866.F0_1866_1380(playerID, unitID, 2);

					if ((this.oGameData.Cities[local_34].ActualSize / local_6) + 1 <= local_3a) goto L15c5;

					// Instruction address 0x25fb:0x15bf, size: 3
					F0_25fb_304d(playerID, local_30, local_36, 2, 2);

				L15c5:
					if ((this.oGameData.Cities[local_34].ActualSize / local_6) + 1 < local_3a) goto L15e1;

					this.oCPU.AX.UInt16 = 0x66;
					goto L2fd0;

				L15e1:
					local_3a = this.oGameData.Players[playerID].Units[unitID].Status;

					this.oGameData.Players[playerID].Units[unitID].Status |= 8;

					// Instruction address 0x25fb:0x1604, size: 5
					if ((short)this.oParent.Segment_1866.F0_1866_1089(playerID, unitID) != unitID) goto L1645;

					// Instruction address 0x25fb:0x161b, size: 5
					if ((this.oGameData.Cities[local_34].ActualSize / local_6) + 1 <= (short)this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 4)) goto L1645;

					this.oGameData.Players[playerID].Units[unitID].Status = (short)local_3a;

					this.oCPU.AX.UInt16 = 0x66;
					goto L2fd0;

				L1645:
					this.oGameData.Players[playerID].Units[unitID].Status = (short)local_3a;

					if (((unitID + this.oGameData.TurnCount) & 0x7) == 0)
					{
						this.oGameData.Players[playerID].Units[unitID].Status &= 0xf2;
					}

				L166c:
					if (local_56 == 5) goto L167b;

					if (local_56 == 3) goto L167b;

					goto L1f44;

				L167b:
					local_2c = 0;
					local_1e = 0;
					local_54 = 0;

					local_20 = this.oGameData.Players[playerID].Units[unitID].NextUnitID;

					if (this.oGameData.Players[playerID].Units[unitID].NextUnitID == -1)
						goto L1752;

					goto L16b9;

				L168f:
					if (local_32 <= 0) goto L166c;

					if (local_56 == 0) goto L166c;

					// Instruction address 0x25fb:0x16ad, size: 3
					F0_25fb_304d(playerID, local_30, local_36, 2, 4);

				L16b3:
					this.oCPU.AX.UInt16 = 0x20;
					goto L2fd0;

				L16b9:
					if (local_20 != unitID) goto L16c4;

					goto L1752;

				L16c4:
					if ((this.oGameData.Players[playerID].Units[local_20].Status & 0x8) != 0)
						goto L16f8;

					local_1e |= 1 << this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_20].TypeID].UnitCategory;

					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_20].TypeID].MovementType != UnitMovementTypeEnum.Land)
						goto L1732;

					goto L172f;

				L16f8:
					// !!! Illegal memory access, local_c > 127
					if (local_c >= 128 || local_2 != 5)
						goto L1732;

					if (this.oGameData.Cities[local_c].ActualSize / 5 >= local_2c++) goto L1732;

					this.oGameData.Players[playerID].Units[local_20].Status &= 0xf7;

				L172f:
					local_54++;

				L1732:
					local_20 = this.oGameData.Players[playerID].Units[local_20].NextUnitID;

					if (local_20 == -1)
						goto L1752;

					goto L16b9;

				L1752:
					if (((local_2a != 0) ? 1 : 3) > local_54) goto L176e;

					if (local_1e == 1) goto L176e;

					goto L198e;

				L176e:
					if (local_56 == 5) goto L1777;

					goto L198e;

				L1777:
					local_14 = 999;
					local_c = 0;
					goto L17d4;

				L1783:
					// Instruction address 0x25fb:0x179d, size: 5
					local_12 = this.oGameData.Map.GetDistance(local_30, local_36, this.oGameData.Cities[local_c].Position.X, this.oGameData.Cities[local_c].Position.Y);

					// Instruction address 0x25fb:0x17b4, size: 5
					local_4a = this.oGameData.Map[this.oGameData.Cities[local_c].Position].Layer3_GroupID;

					if (this.oGameData.Players[playerID].Continents[local_4a].Attack >= 16)
						goto L1800;

				L17d1:
					local_c++;

				L17d4:
					if (local_c < 128) goto L17de;
					goto L18d1;

				L17de:
					if (this.oGameData.Cities[local_c].StatusFlag == 0xff) goto L17d1;

					if (this.oGameData.Cities[local_c].PlayerID != playerID) goto L17d1;

					if ((this.oGameData.Cities[local_c].StatusFlag & 0x2) != 0) goto L1783;

					goto L17d1;

				L1800:
					// Instruction address 0x25fb:0x1814, size: 5
					local_24 = this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(
						this.oGameData.Cities[local_c].Position.X, this.oGameData.Cities[local_c].Position.Y);

					if (local_24 == -1) goto L1846;

					// Instruction address 0x25fb:0x182e, size: 5
					if (((local_12 == 0) ? 1 : 0) >= (short)this.oParent.Segment_1866.F0_1866_1380(playerID, (short)local_24, 5)) goto L1846;

					local_12 += 16;

				L1846:
					if (this.oGameData.Players[playerID].Continents[local_4a].Strategy == 5)
						goto L185f;

					local_12 += 16;

					goto L1880;

				L185f:
					local_12 -= this.oGameData.Players[playerID].Continents[local_4a].Defense / 4;

				L1880:
					if (local_12 < local_14) goto L188b;

					goto L17d1;

				L188b:
					local_14 = local_12;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[local_c].Position.X;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[local_c].Position.Y;
					local_3a = this.oGameData.Players[playerID].Continents[local_4a].Strategy;

					goto L17d1;

				L18d1:
					if (local_3a == 5)
					{
						local_12 = 4;
					}
					else
					{
						local_12 = 2;
					}

					if (local_12 * 3 >= local_14) goto L18f0;
					goto L1f44;

				L18f0:
					if (local_3a == 0) goto L1922;

					// Instruction address 0x25fb:0x191c, size: 3
					F0_25fb_304d(playerID,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.X,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y,
						0, (short)local_12);

				L1922:
					if (local_3a == 2) goto L1955;

					// Instruction address 0x25fb:0x194f, size: 3
					F0_25fb_304d(playerID,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.X,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y,
						2, (short)local_12);

				L1955:
					if (local_3a != 1) goto L195e;
					goto L1f44;

				L195e:
					// Instruction address 0x25fb:0x1985, size: 3
					F0_25fb_304d(playerID,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.X,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y,
						1, (short)local_12);

					goto L1f44;

				L198e:
					if (local_56 == 5) goto L1997;
					goto L1c37;

				L1997:
					local_40 = 1;

					goto L1a68;

				L199f:
					if (this.oGameData.Players[playerID].Continents[local_4a].Strategy != 1)
						goto L19ca;

					// Instruction address 0x25fb:0x19c4, size: 3
					F0_25fb_304d(playerID, local_30, local_36, 3, 5);

				L19ca:
					this.oGameData.Players[playerID].Units[unitID].RemainingMoves = 0;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

					this.oCPU.AX.UInt16 = 0x75;

					goto L2fd0;

				L19ea:
					if ((this.oGameData.TurnCount & 0x3) != 0) goto L1a06;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

				L1a06:
					if (this.oGameData.Players[playerID].Units[unitID].RemainingMoves > 3)
						goto L1c37;

					local_26 = (this.oGameData.Players[playerID].Units[unitID].Position.X + this.oGameData.Players[playerID].Units[unitID].GoToDestination.X) / 2;
					local_2e = (this.oGameData.Players[playerID].Units[unitID].Position.Y + this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y) / 2;

					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X == -1)
						goto L1c37;

					// Instruction address 0x25fb:0x1a52, size: 5
					if (this.oGameData.Map[local_26, local_2e].TerrainType != TerrainTypeEnum.Water) goto L1c37;

					goto L1c22;

				L1a65:
					local_40++;

				L1a68:
					if (local_40 > 8) goto L1a06;

					direction = TerrainMap.MoveOffsets[local_40];

					// Instruction address 0x25fb:0x1a7b, size: 5
					local_26 = this.oGameData.Map.WrapXPosition(local_30 + direction.X);
					local_2e = direction.Y + local_36;

					// Instruction address 0x25fb:0x1a94, size: 5
					local_20 = this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_26, local_2e);

					// Instruction address 0x25fb:0x1aa5, size: 5
					if (this.oGameData.Map[local_26, local_2e].TerrainType == TerrainTypeEnum.Water) goto L1a65;

					// Instruction address 0x25fb:0x1ab8, size: 5
					if (!this.oGameData.Map.IsValidPosition(local_26, local_2e)) goto L1a65;

					if (local_20 == -1) goto L1ad2;

					if (local_20 != playerID) goto L1a65;

				L1ad2:
					if (local_20 != playerID) goto L1b00;

					// Instruction address 0x25fb:0x1ae4, size: 5
					// Instruction address 0x25fb:0x1af0, size: 5
					if (this.oParent.Segment_1866.F0_1866_1251(playerID, (short)this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_26, local_2e), 2) < 2)
						goto L1b00;

					goto L1a65;

				L1b00:
					if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.HumanPlayerID] & 2) == 0)
						goto L1b3d;

					// Instruction address 0x25fb:0x1b1a, size: 5
					if (this.oParent.MapManagement.F0_2aea_1369_MapGetPlayerID(local_26, local_2e) != this.oGameData.HumanPlayerID) goto L1b3d;

					// Instruction address 0x25fb:0x1b2e, size: 5
					if (!this.oGameData.Map[local_26, local_2e].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City, 
						TerrainImprovementEnum.Irrigation, TerrainImprovementEnum.Mine, TerrainImprovementEnum.Roads)) goto L1b3d;

					goto L1a65;

				L1b3d:
					// Instruction address 0x25fb:0x1b43, size: 5
					local_4a = this.oGameData.Map[local_26, local_2e].Layer3_GroupID;
					local_3c = 0;

					if (this.oGameData.Players[playerID].Continents[local_4a].Attack >= 16)
						goto L1b6c;

					if (this.oGameData.Players[playerID].Continents[local_4a].Strategy != 5)
						goto L1b87;

				L1b6c:
					if ((((1 << this.oGameData.Players[playerID].Continents[local_4a].Strategy) & local_1e) & 0x6) == 0) goto L1b8c;

				L1b87:
					local_3c = 1;

				L1b8c:
					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X == -1)
						goto L1bc1;

					// Instruction address 0x25fb:0x1baf, size: 5
					if (this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].GoToDestination].Layer3_GroupID != local_4a) goto L1bc1;

					local_3c = 1;

				L1bc1:
					if (local_3c != 0) goto L1bca;

					goto L19ea;

				L1bca:
					if (this.oGameData.Map.Groups[local_4a].BuildSiteCount < 5)
						goto L19ea;

					if (local_2e > 1) goto L1be2;

					goto L19ea;

				L1be2:
					if (local_2e < 48) goto L1beb;

					goto L19ea;

				L1beb:
					if (this.oGameData.Players[playerID].Units[unitID].RemainingMoves <= 3)
						goto L199f;

					// Instruction address 0x25fb:0x1c0f, size: 3
					local_3a = F0_25fb_3521(playerID, local_30, local_36);

					if (local_3a > 0) goto L1c1f;
					goto L199f;

				L1c1f:
					goto L2fd0;

				L1c22:
					// Instruction address 0x25fb:0x1c31, size: 3
					F0_25fb_304d(playerID, local_26, local_2e, 3, 3);

				L1c37:
					if (local_4c == 0) goto L1c46;

					if (local_56 == 5) goto L1c46;

					goto L1f44;

				L1c46:
					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
						goto L1d49;

					if ((local_1e & 0x2) != 0) goto L1c6f;

					if ((local_1e & 0x1) == 0) goto L1c6f;

					goto L1d49;

				L1c6f:
					if (this.oGameData.Players[playerID].Units[unitID].TypeID == 16)
						goto L1d49;

					local_14 = 999;
					local_40 = this.oGameData.TurnCount & 0x7;

					goto L1d3f;

				L1c9a:
					local_3a = this.oGameData.Cities[local_40].PlayerID;

					if (this.oGameData.Cities[local_40].StatusFlag == 0xff)
						goto L1d3b;

					if (local_3a == playerID) goto L1d3b;

					if ((this.oGameData.Players[playerID].Diplomacy[local_3a] & 0x102) == 2)
						goto L1d3b;

					if (this.oGameData.Players[this.oGameData.HumanPlayerID].Ranking < 7)
						goto L1ce8;

					if (local_3a != this.oGameData.HumanPlayerID) goto L1d3b;

				L1ce8:
					// Instruction address 0x25fb:0x1d02, size: 5
					local_12 = this.oGameData.Map.GetDistance(local_30, local_36,
						this.oGameData.Cities[local_40].Position.X, this.oGameData.Cities[local_40].Position.Y);

					if (local_12 >= local_14) goto L1d3b;

					local_14 = local_12;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[local_40].Position.X;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[local_40].Position.Y;

				L1d3b:
					local_40 += 8;

				L1d3f:
					if (local_40 >= 128) goto L1d49;

					goto L1c9a;

				L1d49:
					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X != -1 || this.oGameData.Players[playerID].Units[unitID].TypeID == 16)
						goto L1e78;

					local_14 = 999;
					local_10 = -1;

					// Instruction address 0x25fb:0x1d7d, size: 5
					if (this.oGameData.Map[local_30, local_36].TerrainType == TerrainTypeEnum.Water) goto L1d90;

					local_10 = groupID;

				L1d90:
					local_40 = 0;

				L1d95:
					local_3a = this.oGameData.Cities[local_40].PlayerID;

					if (this.oGameData.Cities[local_40].StatusFlag == 0xff)
						goto L1e6b;

					if (local_3a == playerID) goto L1dba;

					goto L1e6b;

				L1dba:
					// Instruction address 0x25fb:0x1dcc, size: 5
					local_12 = this.oGameData.Map.GetDistance(local_30, local_36,
						this.oGameData.Cities[local_40].Position.X, this.oGameData.Cities[local_40].Position.Y);

					if (local_12 >= 8) goto L1ddf;

					goto L1e6b;

				L1ddf:
					// Instruction address 0x25fb:0x1df3, size: 5
					local_4a = this.oGameData.Map[this.oGameData.Cities[local_40].Position].Layer3_GroupID;

					if (local_4a == local_10) goto L1e6b;

					if (this.oGameData.Players[playerID].Continents[local_4a].Strategy == 5)
						goto L1e6b;

					if ((((1 << this.oGameData.Players[playerID].Continents[local_4a].Strategy) & local_1e) & 0x7) != 0) goto L1e35;

					local_12 *= 2;

				L1e35:
					if (local_12 >= local_14) goto L1e6b;

					local_14 = local_12;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[local_40].Position.X;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[local_40].Position.Y;

				L1e6b:
					local_40++;

					if (local_40 >= 128) goto L1e78;
					goto L1d95;

				L1e78:
					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
						goto L1f44;

					local_40 = 2;

					goto L1e9c;

				L1e99:
					local_40++;

				L1e9c:
					if (local_40 < 24) goto L1ea5;

					goto L1f44;

				L1ea5:
					// Instruction address 0x25fb:0x1ea9, size: 5
					local_3a = this.oParent.MSCAPI.RNG.Next(9);
					direction = TerrainMap.MoveOffsets[local_3a];
					// Instruction address 0x25fb:0x1ed9, size: 5
					local_26 = this.oGameData.Map.WrapXPosition((direction.X * local_40) + this.oGameData.Players[playerID].Units[unitID].Position.X);
					local_2e = (direction.Y * local_40) + this.oGameData.Players[playerID].Units[unitID].Position.Y;

					if (local_2e <= 2) goto L1e99;

					if (local_2e >= 47) goto L1e99;

					// Instruction address 0x25fb:0x1f04, size: 5
					if (this.oGameData.Map[local_26, local_2e].TerrainType == TerrainTypeEnum.Water) goto L1e99;

					// Instruction address 0x25fb:0x1f17, size: 5
					if (this.oGameData.Players[playerID].Continents[this.oGameData.Map[local_26, local_2e].Layer3_GroupID].CityCount != 0)
						goto L1e99;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = local_26;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = local_2e;

				L1f44:
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MoveCount >= 2)
						goto L1fb2;

					if (local_2a >= 4) goto L1fb2;

					if (this.oGameData.Cities[local_34].PlayerID != this.oGameData.HumanPlayerID)
						goto L1fb2;

					if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID] & 2) != 0)
						goto L1fb2;

					// Instruction address 0x25fb:0x1f98, size: 5
					if (!this.oGameData.Map[local_30, local_36].Improvements.ContainsAnyFlag(TerrainImprovementEnum.Irrigation, TerrainImprovementEnum.Mine)) goto L1fb2;

					if (this.oGameData.Cities[local_34].PlayerID == playerID) goto L1fb2;

					this.oCPU.AX.UInt16 = 0x50;
					goto L2fd0;

				L1fb2:
					if (local_56 == 0) goto L1fbb;
					goto L2520;

				L1fbb:
					if (local_42 != TerrainTypeEnum.Water) goto L1fc4;
					goto L241e;

				L1fc4:
					if (local_32 < 2) goto L1fdf;

					// Instruction address 0x25fb:0x1fd9, size: 3
					F0_25fb_304d(playerID, local_30, local_36, 2, 2);

				L1fdf:
					// Instruction address 0x25fb:0x1fe6, size: 5
					if (((this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Monarchy) == 0) ?
							this.oGameData.Static.Terrains.GetValueByKey(local_42).Multi5 : this.oGameData.Static.Terrains.GetValueByKey(local_42).Multi6) != 0)
						goto L2014;

					if (local_2 == 5) goto L2014;
					goto L213b;

				L2014:
					if (local_2a > 0) goto L201d;
					goto L213b;

				L201d:
					if (local_2a <= 2) goto L2026;
					goto L213b;

				L2026:
					if (this.oGameData.Cities[local_34].PlayerID == playerID) goto L203b;
					goto L213b;

				L203b:
					if (this.oGameData.Cities[local_34].ActualSize >= 3) goto L2060;

					if (local_42 != TerrainTypeEnum.Hills) goto L2060;

					// Instruction address 0x25fb:0x2051, size: 5
					if (this.oGameData.Map[local_30, local_36].HasSpecialResources) goto L2060;
					goto L213b;

				L2060:
					if ((this.oGameData.DebugFlags & 0x2) != 0) goto L206a;
					goto L213b;

				L206a:
					// Instruction address 0x25fb:0x2070, size: 5
					if (this.oParent.Segment_1403.F0_1403_3f68(local_30, local_36) == 1) goto L20c0;

					if (this.oParent.Segment_1403.F0_1403_3f68(local_30, local_36) == 2) goto L20db;

					// Instruction address 0x25fb:0x2088, size: 5
					EnumFlagCollection<TerrainImprovementEnum> local_3a_1 = this.oGameData.Map[local_30, local_36].Improvements;

					if (!local_3a_1.ContainsAnyFlag(TerrainImprovementEnum.Irrigation, TerrainImprovementEnum.Mine)) goto L20f6;

					if (local_3a_1.ContainsAnyFlag(TerrainImprovementEnum.Roads)) goto L20f6;

					if (local_42 != TerrainTypeEnum.Desert && local_42 != TerrainTypeEnum.Plains && local_42 != TerrainTypeEnum.Grassland) goto L20f6;

				L20a5:
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

				L20ba:
					this.oCPU.AX.UInt16 = 0x72;
					goto L2fd0;

				L20c0:
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

					this.oCPU.AX.UInt16 = 0x69;
					goto L2fd0;

				L20db:
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

					this.oCPU.AX.UInt16 = 0x6d;
					goto L2fd0;

				L20f6:
					if (local_3a_1.ContainAllFlags(TerrainImprovementEnum.Roads, TerrainImprovementEnum.Railroads)) goto L213b;

					// Instruction address 0x25fb:0x2106, size: 5
					if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Railroad) == 0)
						goto L213b;

					// Instruction address 0x25fb:0x211c, size: 5
					// !!! this call was using uninitialized playerID and cityID from CityWorker class, it now makes sense to use referenced player and unit ID
					if ((local_3a_1.ContainsAnyFlag(TerrainImprovementEnum.Roads) ? 1 : 2) > 
						this.oParent.CityWorker.F0_1d12_6abc_GetCityResourceCount(playerID, this.oGameData.Players[playerID].Units[unitID].HomeCityID, local_30, local_36, 1))
						goto L213b;

					goto L20a5;

				L213b:
					// Instruction address 0x25fb:0x2141, size: 5
					if (!this.oGameData.Map[local_30, local_36].Improvements.ContainsAnyFlag(TerrainImprovementEnum.Pollution)) goto L2153;

					this.oCPU.AX.UInt16 = 0x70;
					goto L2fd0;

				L2153:
					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X == -1)
						goto L219c;

					if ((this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Policy + 1) * this.oGameData.Map.Groups[groupID].BuildSiteCount <=
						this.oGameData.Players[playerID].Continents[groupID].CityCount * 16) goto L219c;

					this.oCPU.AX.UInt16 = 0;
					goto L2fd0;

				L219c:
					if (local_2a <= 1) goto L21a5;
					goto L230b;

				L21a5:
					if (this.oGameData.Cities[local_34].PlayerID == playerID) goto L21ba;
					goto L230b;

				L21ba:
					if ((this.oGameData.DebugFlags & 0x2) != 0) goto L21c4;
					goto L230b;

				L21c4:
					local_40 = 1;

					goto L22a6;

				L21cc:
					// Instruction address 0x25fb:0x21d2, size: 5
					// Instruction address 0x25fb:0x21ea, size: 5
					if (((this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Monarchy) == 0) ? 
						this.oGameData.Static.Terrains.GetValueByKey(this.oGameData.Map[local_26, local_2e].TerrainType).Multi5 : 
						this.oGameData.Static.Terrains.GetValueByKey(this.oGameData.Map[local_26, local_2e].TerrainType).Multi6) == 0)
						goto L22a3;

					// Instruction address 0x25fb:0x2210, size: 5
					if (this.oParent.Segment_1403.F0_1403_3f68(local_26, local_2e) != 0) goto L221f;
					goto L22a3;

				L221f:
					if (this.oGameData.Cities[local_34].ActualSize >= 3) goto L2257;

					// Instruction address 0x25fb:0x2234, size: 5
					if (this.oGameData.Map[local_26, local_2e].TerrainType != TerrainTypeEnum.Hills) goto L2257;

					// Instruction address 0x25fb:0x224b, size: 5
					if (!this.oGameData.Map[local_26, local_2e].HasSpecialResources) goto L22a3;

				L2257:
					// Instruction address 0x25fb:0x2275, size: 5
					if (this.oGameData.Map.GetDistance(local_26 - this.oGameData.Cities[local_34].Position.X,
						local_2e - this.oGameData.Cities[local_34].Position.Y) > 2) goto L22a3;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = local_26;
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = local_2e;

					this.oCPU.AX.UInt16 = 0;
					goto L2fd0;

				L22a3:
					local_40++;

				L22a6:
					if (local_40 > 8) goto L230b;

					local_3a = ((local_40 + this.oGameData.TurnCount) & 0x7) + 1;
					direction = TerrainMap.MoveOffsets[local_3a];
					local_26 = direction.X + local_30;
					local_2e = direction.Y + local_36;

					// Instruction address 0x25fb:0x22d6, size: 5
					local_20 = (short)this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_26, local_2e);

					if (local_20 != -1) goto L22e9;
					goto L21cc;

				L22e9:
					if (playerID != this.oParent.Var_d7f0) goto L22a3;

					// Instruction address 0x25fb:0x22fa, size: 5
					if (this.oParent.Segment_1866.F0_1866_1331(playerID, (short)local_20, 0)!=0) goto L22a3;

					goto L21cc;

				L230b:
					// Instruction address 0x25fb:0x2311, size: 5
					if (!this.oGameData.Map[local_30, local_36].Improvements.ContainsAnyFlag(TerrainImprovementEnum.Roads)) goto L2320;

					goto L241e;

				L2320:
					if (local_42 != TerrainTypeEnum.River) goto L233c;

					// Instruction address 0x25fb:0x232d, size: 5
					if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.BridgeBuilding) != 0)
						goto L233c;

					goto L241e;

				L233c:
					if (((local_34 < 128) ? this.oGameData.Cities[local_34].PlayerID : -1) == playerID) goto L2351;

					goto L241e;

				L2351:
					if (local_2a > 2) goto L2369;

					if (local_42 != TerrainTypeEnum.Plains) goto L2360;

					goto L20ba;

				L2360:
					if (local_42 != TerrainTypeEnum.Grassland) goto L2369;

					goto L20ba;

				L2369:
					local_3a = 0;
					local_54 = 0;
					local_10 = 0;
					local_40 = 1;

				L2379:
					direction = TerrainMap.MoveOffsets[local_40];

					// Instruction address 0x25fb:0x238e, size: 5
					if (this.oGameData.Map[local_30 + direction.X, local_36 + direction.Y].Improvements.ContainsAnyFlag(TerrainImprovementEnum.Roads))
					{
						local_10 |= 1 << (local_40 - 1);

						local_54++;

						// Instruction address 0x25fb:0x23be, size: 5
						if (this.oGameData.Map[local_30 + (direction.X * 2), local_36 + (direction.Y * 2)].Improvements.ContainsAnyFlag(TerrainImprovementEnum.Roads))
						{
							local_3a = 1;
						}
					}

					local_40++;

					if (local_40 <= 8)
						goto L2379;

					local_10 &= local_10 / 16;

					if (local_54 >= 4) goto L2400;

					if (local_10 == 0) goto L23f1;

					goto L20ba;

				L23f1:
					if (local_2a != 1) goto L2400;

					if (local_42 != TerrainTypeEnum.Desert && local_42 != TerrainTypeEnum.Plains && local_42 != TerrainTypeEnum.Grassland) goto L2400;

					goto L20ba;

				L2400:
					if (local_54 != 1) goto L241e;

					if (local_3a == 0) goto L241e;

					if (this.oGameData.Static.Terrains.GetValueByKey(local_42).MovementCost == 1)
						goto L20ba;

				L241e:
					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
					{
						this.oCPU.AX.UInt16 = 0;
						goto L2fd0;
					}

					// Instruction address 0x25fb:0x243c, size: 5
					local_3a = this.oParent.MSCAPI.RNG.Next(20) + 1;
					direction = TerrainMap.MoveOffsets[local_3a];
					local_26 = (this.oGameData.Players[playerID].Units[unitID].Position.X / 4) + direction.X;
					local_2e = (this.oGameData.Players[playerID].Units[unitID].Position.Y / 4) + direction.Y;

					if ((Array_2438[local_26, local_2e] & 0x3) != 0)
						goto L2520;

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X =
						this.oGameData.Players[playerID].Units[unitID].Position.X + (direction.X * 4);

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y =
						this.oGameData.Players[playerID].Units[unitID].Position.Y + (direction.Y * 4);

					// Instruction address 0x25fb:0x24c1, size: 5
					if (!this.oGameData.Map.IsValidPosition(
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.X,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y)) goto L250b;

					// Instruction address 0x25fb:0x24d9, size: 5
					if (this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].GoToDestination.X,
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y].Production == 0)
						goto L250b;

					// Instruction address 0x25fb:0x24fb, size: 5
					if (this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].GoToDestination].Layer3_GroupID != groupID) goto L250b;

					this.oCPU.AX.UInt16 = 0;
					goto L2fd0;

				L250b:
					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

				L2520:
					if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X == -1)
						goto L2558;

					if (local_56 == 3) goto L2540;
					
					this.oCPU.AX.UInt16 = 0;
					goto L2fd0;

				L2540:
					// Instruction address 0x25fb:0x2549, size: 5
					if (this.oParent.Segment_1866.F0_1866_18d0(playerID, local_30, local_36) != 0) goto L2558;

					this.oCPU.AX.UInt16 = 0;
					goto L2fd0;

				L2558:
					if (local_56 != 2) goto L2594;

					if (local_42 == TerrainTypeEnum.Water) goto L2594;

					if (local_32 <= 1) goto L2585;

					if (local_2a > 3) goto L2585;

					if (this.oGameData.Cities[local_34].PlayerID != playerID) goto L2585;

					this.oCPU.AX.UInt16 = 0x66;
					goto L2fd0;

				L2585:
					if (local_4c == 0) goto L2594;

					if (local_32 == 0) goto L2594;

					this.oCPU.AX.UInt16 = 0x66;
					goto L2fd0;

				L2594:
					if (local_56 != 0) goto L25f2;

					if (this.oGameData.Players[playerID].Continents[groupID].CityCount <= this.oGameData.Map.Groups[groupID].BuildSiteCount / 8) goto L25f2;

					if (local_2a != 0) goto L25d6;

					if (this.oGameData.Cities[local_34].ActualSize >= 10) goto L25d6;

					goto L1417;

				L25d6:
					if (this.oGameData.Cities[local_34].PlayerID != playerID) goto L25f2;

					if (this.oGameData.Cities[local_34].ActualSize >= 10) goto L25f2;

					goto L12d7;

				L25f2:
					local_28 = -999;
					local_2c = 0;
					local_5c = 0;

					// Instruction address 0x25fb:0x260a, size: 5
					if (this.oParent.Segment_1866.F0_1866_1750_UpdateVisibility(playerID, local_30, local_36) == 0) goto L262d;

					this.oGameData.Players[playerID].Units[unitID].GoToNextDirection = -1;

					goto L2632;

				L262d:
					local_5c = 1;

				L2632:
					if (local_8 != 1) goto L2643;

					if (local_2 != 1) goto L2643;

					local_56 = 1;

				L2643:
					local_40 = 1;

					goto L267b;

				L264a:
					if (local_24 != -1) goto L2653;
					goto L2857;

				L2653:
					if (local_58 == playerID) goto L265e;
					goto L2857;

				L265e:
					// Instruction address 0x25fb:0x2668, size: 5
					if ((short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_24, 2) >= 2) goto L2678;
					goto L2857;

				L2678:
					local_40++;

				L267b:
					if (local_40 <= 8) goto L2684;
					goto L2f94;

				L2684:
					direction = TerrainMap.MoveOffsets[local_40];
					// Instruction address 0x25fb:0x2691, size: 5
					local_26 = this.oGameData.Map.WrapXPosition(local_30 + direction.X);
					local_2e = direction.Y + local_36;

					// Instruction address 0x25fb:0x26aa, size: 5
					if (!this.oGameData.Map.IsValidPosition(local_26, local_2e)) goto L2678;

					// Instruction address 0x25fb:0x26bc, size: 5
					local_58 = this.oParent.MapManagement.F0_2aea_1369_MapGetPlayerID(local_26, local_2e);

					// Instruction address 0x25fb:0x26cd, size: 5
					local_38 = this.oGameData.Map[local_26, local_2e].TerrainType;

					if (local_38 != TerrainTypeEnum.Water) goto L26ff;

					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
						goto L2678;

				L26ff:
					// Instruction address 0x25fb:0x2705, size: 5
					local_24 = (short)this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_26, local_2e);

					if (local_24 == -1) goto L277d;

					if (this.oGameData.Players[this.oParent.Var_d7f0].Units[local_24].TypeID != 26)
						goto L277d;

					local_20 = local_24;

				L2733:
					local_20 = this.oGameData.Players[this.oParent.Var_d7f0].Units[local_20].NextUnitID;

					if (local_20 == -1)
						goto L2771;

					if (local_20 == local_24) goto L2771;

					if (this.oGameData.Players[this.oParent.Var_d7f0].Units[local_20].TypeID == 26)
						goto L2733;

				L2771:
					if (local_20 == -1) goto L277d;

					local_24 = local_20;

				L277d:
					if (local_4c == 0) goto L27cd;

					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land)
						goto L27cd;

					if (local_24 != -1)
						goto L27cd;

					// Instruction address 0x25fb:0x27b3, size: 5
					if (this.oParent.Segment_1866.F0_1866_1725_UpdateCityVisibility(playerID, local_26, local_2e) == 0)
						goto L27cd;

					if (this.oGameData.Players[playerID].Units[unitID].TypeID >= 26)
						goto L27cd;

					if (local_42 == TerrainTypeEnum.Water) goto L27cd;

					goto L2678;

				L27cd:
					if (local_42 != TerrainTypeEnum.Water) goto L2803;

					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land)
						goto L2803;

					if (local_24 == -1) goto L2803;

					if (local_58 == playerID) goto L2803;
					goto L2678;

				L2803:
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
						goto L264a;

					if (local_38 != TerrainTypeEnum.Water) goto L282e;

					goto L264a;

				L282e:
					if (local_24 != -1) goto L2837;
					goto L2678;

				L2837:
					if (local_58 != playerID) goto L2842;
					goto L2678;

				L2842:
					if (local_8 != 22) goto L284b;
					goto L2678;

				L284b:
					if (local_42 != TerrainTypeEnum.Water) goto L2678;

					goto L264a;

				L2857:
					if (local_56 != 0) goto L2886;

					local_10 = 0;

					if (local_42 == TerrainTypeEnum.Water) goto L286b;

					goto L29ed;

				L286b:
					// Instruction address 0x25fb:0x2874, size: 5
					if (this.oParent.Segment_1866.F0_1866_1750_UpdateVisibility(playerID, local_26, local_2e) != 0) goto L2883;
					goto L29ed;

				L2883:
					goto L2678;

				L2886:
					if (this.oGameData.Players[playerID].Units[unitID].VisibilityList.Count > 0)
						goto L28eb;

					if (local_42 == TerrainTypeEnum.Water) goto L28eb;

					if (local_56 != 1) goto L28ce;

					// Instruction address 0x25fb:0x28ad, size: 5
					local_10 = this.oParent.MSCAPI.RNG.Next(3) - (int)(this.oGameData.Static.Terrains.GetValueByKey(local_38).MovementCost * 2);
					goto L29bf;

				L28ce:
					// Instruction address 0x25fb:0x28d2, size: 5
					local_10 = this.oParent.MSCAPI.RNG.Next(3) - this.oGameData.Static.Terrains.GetValueByKey(local_38).DefenseBonus;
					goto L29bf;

				L28eb:
					// Instruction address 0x25fb:0x28ef, size: 5
					local_10 = this.oParent.MSCAPI.RNG.Next(5);

					if (local_24 != -1) goto L2903;
					goto L29ab;

				L2903:
					if (local_58 == playerID) goto L290e;
					goto L29ab;

				L290e:
					if (local_56 != 1) goto L2947;

					// Instruction address 0x25fb:0x291e, size: 5
					// Instruction address 0x25fb:0x2935, size: 5
					local_10 += ((short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_24, 1) * 4) / ((short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_24, 2) + 1);

				L2947:
					if (local_56 != 0) goto L2975;

					// Instruction address 0x25fb:0x2957, size: 5
					local_10 += (this.oGameData.Static.Terrains.GetValueByKey(local_38).DefenseBonus + (short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_24, 1)) * 2;

				L2975:
					if (local_56 != 2) goto L29bf;

					// Instruction address 0x25fb:0x2985, size: 5
					// Instruction address 0x25fb:0x299c, size: 5
					local_10 += ((short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_24, 3) * 2) / ((short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_24, 1) + 1);
					goto L29bf;

				L29ab:
					local_10 += this.oGameData.Static.Terrains.GetValueByKey(local_38).DefenseBonus * 4;

				L29bf:
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Water)
						goto L29ed;

					// Instruction address 0x25fb:0x29e2, size: 5
					local_10 = this.oParent.MSCAPI.RNG.Next(3);

				L29ed:
					if (this.oGameData.Players[playerID].Units[unitID].GoToNextDirection != -1)
					{
						local_a = Math.Abs(this.oGameData.Players[playerID].Units[unitID].GoToNextDirection - local_40);

						if (local_a > 4)
						{
							local_a = 8 - local_a;
						}

						local_10 -= (local_a * local_a) * 2;
					}

					local_1c = 0;

					if (local_24 == -1) goto L2d85;

					if (local_58 != playerID) goto L2a49;
					goto L2d64;

				L2a49:
					local_1c = 1;

					if (local_56 != 0) goto L2a57;
					goto L2678;

				L2a57:
					if ((this.oGameData.Players[playerID].Diplomacy[local_58] & 2) != 0)
						goto L2c6a;

					// Instruction address 0x25fb:0x2a72, size: 5
					local_24 = (short)this.oParent.Segment_1866.F0_1866_1122((short)local_58, (short)local_24);

					if (this.oGameData.Static.Units[this.oGameData.Players[local_58].Units[local_24].TypeID].MovementType != UnitMovementTypeEnum.Water)
						goto L2ac8;

					if (this.oGameData.Players[playerID].Units[unitID].TypeID == 14)
						goto L2ac8;

					// Instruction address 0x25fb:0x2ab9, size: 5
					if (this.oGameData.Map[local_26, local_2e].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City)) goto L2ac8;
					goto L2678;

				L2ac8:
					// Instruction address 0x25fb:0x2ad8, size: 5
					local_5a = (short)this.oParent.Segment_29f3.F0_29f3_000e(playerID, unitID, (short)local_58, (short)local_24, 0);

					// Instruction address 0x25fb:0x2aec, size: 5
					local_5a = ((short)this.oParent.Segment_1866.F0_1866_1251((short)local_58, (short)local_24, 0) + 1) * local_5a;
					local_5a = local_5a / this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].Price;

					// Instruction address 0x25fb:0x2b26, size: 5
					if (!this.oGameData.Map[local_26, local_2e].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City)) goto L2b3b;

					local_5a = local_5a * 3;

				L2b3b:
					if (local_56 != 1) goto L2b50;

					if (local_2 != 1) goto L2b50;

					local_5a = local_5a * 3;

				L2b50:
					if (local_56 != 1) goto L2b8f;

					// Instruction address 0x25fb:0x2b60, size: 5
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].AttackStrength * 2 >= (short)this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 3)) goto L2b8f;

					local_5a *= 2;

				L2b8f:				
					if (((playerID != 0) ? 6 : 12) > local_5a) goto L2baf;

					local_10 += local_5a * 4;

					goto L2dbd;

				L2baf:
					local_10 -= 999;

					if (local_56 == 1) goto L2bbd;
					goto L2dbd;

				L2bbd:
					if (local_2 == 1) goto L2bc6;
					goto L2dbd;

				L2bc6:
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land)
						goto L2dbd;

					if ((this.oGameData.Players[local_58].Units[local_24].Status & 0x28) == 0)
						goto L2dbd;

					if (this.oGameData.Static.Terrains.GetValueByKey(local_38).DefenseBonus < 4)
						goto L2dbd;

					// Instruction address 0x25fb:0x2c1e, size: 5
					if ((short)this.oParent.Segment_1866.F0_1866_1251((short)local_58, (short)local_24, 2) < 2) goto L2c2e;
					goto L2dbd;

				L2c2e:
					// Instruction address 0x25fb:0x2c32, size: 5
					if (this.oParent.MSCAPI.RNG.Next(4) == 0) goto L2c41;
					goto L2dbd;

				L2c41:
					// Instruction address 0x25fb:0x2c47, size: 5
					if (!this.oGameData.Map[local_26, local_2e].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City)) goto L2c56;
					goto L2dbd;

				L2c56:
					this.oParent.Overlay_22.F22_0000_0639((short)local_58, (short)local_24, playerID);

					goto L2dbd;

				L2c6a:
					if (local_56 == 1) goto L2c73;
					goto L2678;

				L2c73:
					if (local_2 == 1) goto L2c7c;
					goto L2678;

				L2c7c:
					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land)
						goto L2678;

					if ((this.oGameData.Players[local_58].Units[local_24].Status & 0x8) == 0)
						goto L2678;

					if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.HumanPlayerID] & 3) != 1)
						goto L2678;

					if ((this.oGameData.Players[local_58].Diplomacy[this.oGameData.HumanPlayerID] & 3) == 1)
						goto L2678;

					if (this.oGameData.Players[this.oGameData.HumanPlayerID].Continents[groupID].CityCount == 0)
						goto L2678;

					// Instruction address 0x25fb:0x2d05, size: 5
					if ((short)this.oParent.Segment_1866.F0_1866_1251((short)local_58, (short)local_24, 2) < 2) goto L2d15;
					goto L2678;

				L2d15:
					// Instruction address 0x25fb:0x2d19, size: 5
					if (this.oParent.MSCAPI.RNG.Next(8) == 0) goto L2d3b;

					if (this.oGameData.Cities[local_34].PlayerID != this.oGameData.HumanPlayerID)
						goto L2678;

				L2d3b:
					// Instruction address 0x25fb:0x2d41, size: 5
					if (!this.oGameData.Map[local_26, local_2e].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City)) goto L2d50;
					goto L2678;

				L2d50:
					this.oParent.Overlay_22.F22_0000_0639((short)local_58, (short)local_24, playerID);

					goto L2678;

				L2d64:
					local_10 -= this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].DefenseStrength;
					goto L2dbd;

				L2d85:
					// Instruction address 0x25fb:0x2d8b, size: 5
					if (!this.oGameData.Map[local_26, local_2e].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City)) goto L2da4;

					if (local_58 == playerID) goto L2da4;

					local_10 = 999;

				L2da4:
					// Instruction address 0x25fb:0x2dad, size: 5
					if (this.oParent.MapManagement.F0_2aea_1894(local_26, local_2e, local_38) == 0) goto L2dbd;

					local_10 += 20;

				L2dbd:
					if (local_5c == 0)
						goto L2f15;

					direction = TerrainMap.MoveOffsets[local_40];
					local_26 = local_30 + (direction.X * 4);
					local_2e = local_36 + (direction.Y * 4);

					if (Array_2438[local_26 / 4, local_2e / 4] != 0) goto L2e47;

					// Instruction address 0x25fb:0x2e24, size: 5
					if (this.oGameData.Map[local_26, local_2e].TerrainType == TerrainTypeEnum.Water) goto L2e47;

					// Instruction address 0x25fb:0x2e37, size: 5
					if (!this.oGameData.Map.IsValidPosition(local_26, local_2e)) goto L2e47;

					local_10 += 8;

				L2e47:
					local_44 = 1;

				L2e4c:
					direction = TerrainMap.MoveOffsets[local_44];
					// Instruction address 0x25fb:0x2e59, size: 5
					local_e = this.oGameData.Map.WrapXPosition(local_26 + direction.X);
					local_16 = direction.Y + local_2e;

					// Instruction address 0x25fb:0x2e72, size: 5
					if (this.oGameData.Map.IsValidPosition(local_e, local_16)) goto L2e81;

					goto L2f09;

				L2e81:
					if (this.oGameData.Map[local_e, local_16].IsVisibleTo(playerID)) goto L2ed1;

					// Instruction address 0x25fb:0x2ea1, size: 5
					if (this.oGameData.Map[local_e, local_16].TerrainType != TerrainTypeEnum.Water) goto L2ecd;

					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
						goto L2ed1;

				L2ecd:
					local_10 += 2;

				L2ed1:
					// Instruction address 0x25fb:0x2ed7, size: 5
					if ((short)this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_e, local_16) == -1) goto L2ee6;

					local_10 -= 2;

				L2ee6:
					if (local_56 != 0x0) goto L2f09;

					// Instruction address 0x25fb:0x2ef2, size: 5
					local_10 += this.oGameData.Map[local_e, local_16].Food;

				L2f09:
					local_44++;

					if (local_44 > 8) goto L2f15;
					goto L2e4c;

				L2f15:
					if (local_1c != 0)
					{
						if (this.oGameData.Players[playerID].Units[unitID].RemainingMoves < 3)
						{
							// Instruction address 0x25fb:0x2f44, size: 5
							// Instruction address 0x25fb:0x2f4d, size: 5
							// Instruction address 0x25fb:0x2f63, size: 5
							local_10 = ((short)this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 1) * local_10) / 
								this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((short)this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 3), 1, 99);
						}
					}

					if (local_10 > local_28) goto L2f7f;
					goto L2678;

				L2f7f:
					local_28 = local_10;
					local_2c = local_40;
					local_52 = local_1c;

					goto L2678;

				L2f94:
					if (local_52 != 0)
					{
						if (this.oGameData.Players[playerID].Units[unitID].RemainingMoves < 3)
						{
							local_2c = 0;
						}
					}

					this.oGameData.Players[playerID].Units[unitID].GoToNextDirection = local_2c;

				L2fcd:
					this.oCPU.AX.UInt16 = (ushort)((short)local_2c);
				}
			}

		L2fd0:
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_0c9d");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_25fb_2fd7(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_2fd7({playerID})");

			// function body
			for (int i = 0; i < 32; i++)
			{
				Array_e2c2[playerID, i] = 0xff;
				Array_b2be[playerID, i] = 0;
			}

			for (int i = 0; i < 16; i++)
			{
				if (this.oGameData.Players[playerID].StrategicLocations[i].Active != -1 &&
					this.oGameData.Players[playerID].StrategicLocations[i].Active <= 2)
				{

					// Instruction address 0x25fb:0x3039, size: 3
					F0_25fb_304d(playerID,
						this.oGameData.Players[playerID].StrategicLocations[i].Position.X,
						this.oGameData.Players[playerID].StrategicLocations[i].Position.Y,
						this.oGameData.Players[playerID].StrategicLocations[i].Active,
						this.oGameData.Players[playerID].StrategicLocations[i].Policy);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_2fd7");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="active"></param>
		/// <param name="policy"></param>
		public void F0_25fb_304d(short playerID, int xPos, int yPos, short active, short policy)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_304d({playerID}, {xPos}, {yPos}, {active}, {policy})");
			
			// function body			
			for (int i = 0; i < 32; i++)
			{
				if (Array_e598[playerID, i] == xPos && Array_e798[playerID, i] == yPos &&
					Array_e2c2[playerID, i] == active && Array_b2be[playerID, i] <= policy)
				{
					goto L31ce;
				}
			}

			if (playerID == this.oParent.Var_6b90 && playerID != this.oGameData.HumanPlayerID && (active == 3 || active == 4))
			{
				for (int i = 0; i < 128; i++)
				{
					if (this.oGameData.Players[playerID].Units[i].TypeID != -1 &&
						this.oGameData.Players[playerID].Units[i].RemainingMoves != 0 &&
						this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[i].TypeID].UnitCategory == active &&
						this.oGameData.Map[this.oGameData.Players[playerID].Units[i].Position].Layer3_GroupID ==
						this.oGameData.Map[xPos, yPos].Layer3_GroupID &&
						this.oGameData.Players[playerID].Units[i].RemainingMoves >=
							this.oGameData.Map.GetDistance(this.oGameData.Players[playerID].Units[i].Position.X,
							this.oGameData.Players[playerID].Units[i].Position.Y, xPos, yPos) * 2)
					{
						this.oGameData.Players[playerID].Units[i].GoToDestination.X = xPos;
						this.oGameData.Players[playerID].Units[i].GoToDestination.Y = yPos;
						this.oGameData.Players[playerID].Units[i].Status |= 0x10;
						this.oGameData.Players[playerID].Units[i].Status &= 0xf0;
						break;
					}
				}
			}

			for (int i = 0; i < 32; i++)
			{
				if (Array_e2c2[playerID, i] == 0xff || Array_b2be[playerID, i] < policy)
				{
					// Instruction address 0x25fb:0x31a2, size: 3
					F0_25fb_31d4(playerID, i);

					Array_e598[playerID, i] = xPos;
					Array_e798[playerID, i] = yPos;
					Array_e2c2[playerID, i] = active;
					Array_b2be[playerID, i] = policy;

					break;
				}
			}

		L31ce:
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_304d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="position"></param>
		public void F0_25fb_31d4(int playerID, int position)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_31d4({playerID}, {position})");

			// function body
			for (int i = 30; i >= position; i--)
			{
				if (Array_b2be[playerID, i] != 0)
				{
					Array_e598[playerID, i + 1] = Array_e598[playerID, i];
					Array_e798[playerID, i + 1] = Array_e798[playerID, i];
					Array_e2c2[playerID, i + 1] = Array_e2c2[playerID, i];
					Array_b2be[playerID, i + 1] = Array_b2be[playerID, i];
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_31d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_25fb_3223_ClearStrategicLocations(short playerID)
		{
			for (int i = 0; i < 16; i++)
			{
				this.oGameData.Players[playerID].StrategicLocations[i].Active = -1;
				this.oGameData.Players[playerID].StrategicLocations[i].Policy = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="active"></param>
		/// <param name="policy"></param>
		public void F0_25fb_3251_AddStrategicLocation(int playerID, int xPos, int yPos, ushort active, ushort policy)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3251_AddStrategicLocation({playerID}, {xPos}, {yPos}, {active}, {policy})");

			// function body
			bool bFound = false;

			for (int i = 0; i < 16; i++)
			{
				if (this.oGameData.Players[playerID].StrategicLocations[i].Position.X == xPos &&
					this.oGameData.Players[playerID].StrategicLocations[i].Position.Y == yPos &&
					this.oGameData.Players[playerID].StrategicLocations[i].Active == active &&
					this.oGameData.Players[playerID].StrategicLocations[i].Policy <= policy)
				{
					bFound = true;
					break;
				}
			}

			if (!bFound)
			{
				for (int i = 0; i < 16; i++)
				{
					if (this.oGameData.Players[playerID].StrategicLocations[i].Active == -1 ||
						this.oGameData.Players[playerID].StrategicLocations[i].Policy < policy)
					{
						// Instruction address 0x25fb:0x32ce, size: 3
						F0_25fb_32ff_AppendStrategicLocation(playerID, i);

						this.oGameData.Players[playerID].StrategicLocations[i].Position.X = xPos;
						this.oGameData.Players[playerID].StrategicLocations[i].Position.Y = yPos;
						this.oGameData.Players[playerID].StrategicLocations[i].Active = (sbyte)active;
						this.oGameData.Players[playerID].StrategicLocations[i].Policy = (byte)policy;
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3251_AddStrategicLocation");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="position"></param>
		public void F0_25fb_32ff_AppendStrategicLocation(int playerID, int position)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_32ff_AppendStrategicLocation({playerID}, {position})");

			// function body
			for (int i = 14; i >= position; i--)
			{
				if (this.oGameData.Players[playerID].StrategicLocations[i].Policy != 0)
				{
					this.oGameData.Players[playerID].StrategicLocations[i + 1].Position.X = this.oGameData.Players[playerID].StrategicLocations[i].Position.X;
					this.oGameData.Players[playerID].StrategicLocations[i + 1].Position.Y = this.oGameData.Players[playerID].StrategicLocations[i].Position.Y;
					this.oGameData.Players[playerID].StrategicLocations[i + 1].Active = this.oGameData.Players[playerID].StrategicLocations[i].Active;
					this.oGameData.Players[playerID].StrategicLocations[i + 1].Policy = this.oGameData.Players[playerID].StrategicLocations[i].Policy;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_32ff_AppendStrategicLocation");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="active"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="distance"></param>
		public void F0_25fb_3401(int playerID, int active, int xPos, int yPos, int distance)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3401({playerID}, {active}, {xPos}, {yPos}, {distance})");

			// function body
			for (int i = 0; i < 16; i++)
			{
				// Instruction address 0x25fb:0x3433, size: 5
				if (this.oGameData.Players[playerID].StrategicLocations[i].Active == active &&
					this.oGameData.Map.GetDistance(xPos, yPos,
						this.oGameData.Players[playerID].StrategicLocations[i].Position.X,
						this.oGameData.Players[playerID].StrategicLocations[i].Position.Y) <= distance)
				{
					this.oGameData.Players[playerID].StrategicLocations[i].Active = -1;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3401");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="groupID"></param>
		public void F0_25fb_3459(int playerID, int groupID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3459({playerID}, {groupID})");

			// function body
			for (int i = 0; i < 128; i++)
			{
				if (this.oGameData.Cities[i].PlayerID == playerID && this.oGameData.Cities[i].StatusFlag != 0xff &&
					(groupID == -1 || this.oGameData.Map[this.oGameData.Cities[i].Position].Layer3_GroupID == groupID))
				{
					// Instruction address 0x25fb:0x34a1, size: 3
					F0_25fb_34b6(i);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3459");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_25fb_34b6(int cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_34b6({cityID})");

			// function body
			int playerID = this.oGameData.Cities[cityID].PlayerID;

			if (this.oGameData.Cities[cityID].CurrentProductionID >= 0)
			{
				this.oGameData.Players[playerID].UnitsInProduction[this.oGameData.Cities[cityID].CurrentProductionID]--;
			}

			// Instruction address 0x25fb:0x34fc, size: 5
			this.oGameData.Cities[cityID].CurrentProductionID = (sbyte)((short)this.oParent.Segment_1ade.F0_1ade_0421(playerID, cityID));

			if (this.oGameData.Cities[cityID].CurrentProductionID >= 0)
			{
				this.oGameData.Players[playerID].UnitsInProduction[this.oGameData.Cities[cityID].CurrentProductionID]++;
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_34b6");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_25fb_3521(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3521({playerID}, {xPos}, {yPos})");

			// function body
			int local_6;
			int local_12;

			local_6 = -1;
			local_12 = -1;

			for (int i = 0; i < 9; i++)
			{
				int local_2 = 0;

				GPoint direction = TerrainMap.MoveOffsets[i];

				int xPos1 = xPos + direction.X;
				int yPos1 = yPos + direction.Y;

				// Instruction address 0x25fb:0x35f8, size: 5
				// Instruction address 0x25fb:0x3614, size: 5
				if (this.oGameData.Map[xPos1, yPos1].TerrainType == TerrainTypeEnum.Water &&
					(i == 0 || this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(xPos1, yPos1) == -1))
				{
					for (int j = 1; j < 9; j++)
					{
						direction = TerrainMap.MoveOffsets[j];

						int xPos2 = xPos1 + direction.X;
						int yPos2 = yPos1 + direction.Y;

						// Instruction address 0x25fb:0x355c, size: 5
						// Instruction address 0x25fb:0x356f, size: 5
						if (this.oGameData.Map[xPos2, yPos2].TerrainType != TerrainTypeEnum.Water &&
							this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(xPos2, yPos2) == -1)
						{
							local_2++;

							// Instruction address 0x25fb:0x359f, size: 5
							//this.oParent.Graphics.F0_VGA_038c_GetPixel(2, local_4 + 80, local_8);
							if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.HumanPlayerID] & 2) != 0 &&
								this.oGameData.Map[xPos2, yPos2].Layer2_PlayerOwnership == this.oGameData.HumanPlayerID)
							{
								local_2--;
							}
						}
					}

					if (local_2 > local_6)
					{
						local_6 = local_2;
						local_12 = i;
					}
				}
			}

			this.oCPU.AX.UInt16 = (ushort)((short)local_12);

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3521");

			return local_12;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_25fb_362d(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_362d({playerID}, {unitID})");

			// function body
			if (this.oGameData.Players[playerID].Units[unitID].Position.Y > 1 && this.oGameData.Players[playerID].Units[unitID].Position.Y < 48)
			{
				// Instruction address 0x25fb:0x3684, size: 5
				int local_44 = (short)this.oParent.Segment_1866.F0_1866_1725_UpdateCityVisibility(playerID, this.oGameData.Players[playerID].Units[unitID].Position.X,
					this.oGameData.Players[playerID].Units[unitID].Position.Y);
				int nextDirection = 0;

				int unitXPos = this.oGameData.Players[playerID].Units[unitID].Position.X;
				int unitYPos = this.oGameData.Players[playerID].Units[unitID].Position.Y;

				if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].UnitCategory == 5)
				{
					if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1)
					{
						// Instruction address 0x25fb:0x36df, size: 5
						int nearestCityID = this.oParent.Segment_2dc4.F0_2dc4_0102_FindNearestCity(unitXPos, unitYPos);

						for (int i = 1; i < 9; i++)
						{
							GPoint direction = TerrainMap.MoveOffsets[i];

							// Instruction address 0x25fb:0x3722, size: 5
							int newUnitXPos = this.oGameData.Map.WrapXPosition(unitXPos + direction.X);
							int newUnitYPos = unitYPos + direction.Y;

							// Instruction address 0x25fb:0x3742, size: 5
							// Instruction address 0x25fb:0x3755, size: 5
							// Instruction address 0x25fb:0x3767, size: 5
							if (this.oParent.Var_6c9a > 8 ||
								this.oGameData.Map[newUnitXPos, newUnitYPos].TerrainType == TerrainTypeEnum.Water ||
								this.oGameData.Map[newUnitXPos, newUnitYPos].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City) ||
								this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(newUnitXPos, newUnitYPos) != -1 || newUnitYPos <= 1 || newUnitYPos >= 48)
							{
								// Instruction address 0x25fb:0x36f7, size: 5
								if (this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(newUnitXPos, newUnitYPos) > 0)
								{
									this.oCPU.AX.UInt16 = (ushort)((short)i);
									goto L3e96;
								}
							}
							else
							{
								// Instruction address 0x25fb:0x37ce, size: 5
								// Instruction address 0x25fb:0x37de, size: 5
								if (this.oGameData.Map[newUnitXPos, newUnitYPos].IsVisibleTo(this.oGameData.HumanPlayerID) &&
									this.oGameData.Cities[nearestCityID].PlayerID == this.oGameData.HumanPlayerID &&
									this.oGameData.Map[newUnitXPos, newUnitYPos].Layer3_GroupID ==
										this.oGameData.Map[this.oGameData.Cities[nearestCityID].Position].Layer3_GroupID)
								{
									this.oGameData.Players[playerID].Units[unitID].SetVisiblity(this.oGameData.HumanPlayerID, true);

									// Instruction address 0x25fb:0x3813, size: 5
									this.oParent.Segment_1866.F0_1866_16a9(this.oGameData.HumanPlayerID, newUnitXPos, newUnitYPos);

									this.oParent.Var_2f9e = 3;

									// Instruction address 0x25fb:0x3829, size: 5
									this.oParent.MSCAPI.strcpy(0xba06, "Barbarian raiding party\nlands near ");

									// Instruction address 0x25fb:0x3837, size: 5
									// Instruction address 0x25fb:0x3843, size: 5
									this.oParent.Segment_2459.F0_2459_08c6_GetCityName((short)this.oParent.Segment_2dc4.F0_2dc4_0102_FindNearestCity(newUnitXPos, newUnitYPos));

									// Instruction address 0x25fb:0x3853, size: 5
									this.oParent.MSCAPI.strcat(0xba06, "!\nCitizens are alarmed.\n");


									// Instruction address 0x25fb:0x3867, size: 5
									this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 32);
								}

								this.oGameData.Players[playerID].Units[unitID].AppendVisibility(this.oGameData.Map[newUnitXPos, newUnitYPos].VisibilityList);
								this.oGameData.Players[playerID].Units[unitID].RemainingMoves = 0;

								this.oCPU.AX.UInt16 = 0x75;
								goto L3e96;
							}
						}

						if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
						{
							this.oCPU.AX.UInt16 = 0;
						}
						else
						{
							int local_22 = 0;
							int local_2e = 0;

							for (int i = 0; i < 128; i++)
							{
								if (this.oGameData.Cities[i].StatusFlag != 0xff)
								{
									// Instruction address 0x25fb:0x38e7, size: 5
									// Instruction address 0x25fb:0x38f7, size: 5
									int local_34 = ((short)this.oParent.Segment_2459.F0_2459_0687((short)i) + 50) / (this.oGameData.Map.GetDistance(unitXPos, unitYPos,
										this.oGameData.Cities[i].Position.X, this.oGameData.Cities[i].Position.Y) + 1);

									if (local_34 > local_22)
									{
										local_22 = local_34;
										local_2e = i;
									}
								}
							}

							if (local_22 == 0)
							{
								// Instruction address 0x25fb:0x36cb, size: 5
								this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

								this.oCPU.AX.UInt16 = 0x20;
							}
							else
							{
								this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[local_2e].Position.X;
								this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[local_2e].Position.Y;

								this.oCPU.AX.UInt16 = 0;
							}
						}
					}
					else
					{
						// Instruction address 0x25fb:0x36cb, size: 5
						this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

						this.oCPU.AX.UInt16 = 0x20;
					}
				}
				else
				{
					// Instruction address 0x25fb:0x3962, size: 5
					int nearestCityID = this.oParent.Segment_2dc4.F0_2dc4_0102_FindNearestCity(unitXPos, unitYPos);

					if (this.oParent.Var_6c9a == 0 &&
						(this.oGameData.Players[playerID].Units[unitID].NextUnitID == -1 ||
						this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].UnitCategory == 2))
					{
						this.oCPU.AX.UInt16 = 0x66;
						goto L3e96;
					}

					int local_46 = -2;
					int local_40 = -2;

					if (((unitID + this.oGameData.TurnCount) & 0x3) == 0)
					{
						// Instruction address 0x25fb:0x39c8, size: 5
						// Instruction address 0x25fb:0x39d8, size: 5
						if (this.oGameData.Map[unitXPos, unitYPos].Layer3_GroupID !=
							this.oGameData.Map[this.oGameData.Cities[nearestCityID].Position].Layer3_GroupID)
						{
							// Instruction address 0x25fb:0x36cb, size: 5
							this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

							this.oCPU.AX.UInt16 = 0x20;
							goto L3e96;
						}
						else if (this.oParent.Var_6c9a > 8)
						{
							// Instruction address 0x25fb:0x36cb, size: 5
							this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

							this.oCPU.AX.UInt16 = 0x20;
							goto L3e96;
						}
					}

					// Instruction address 0x25fb:0x3a0b, size: 5
					// Instruction address 0x25fb:0x3a1b, size: 5
					if (nearestCityID != -1 &&
						this.oGameData.Map[unitXPos, unitYPos].Layer3_GroupID ==
							this.oGameData.Map[this.oGameData.Cities[nearestCityID].Position].Layer3_GroupID &&
						this.oGameData.Cities[nearestCityID].PlayerID == this.oGameData.HumanPlayerID)
					{
						local_40 = Math.Sign(this.oGameData.Cities[nearestCityID].Position.X - unitXPos);
						local_46 = Math.Sign(this.oGameData.Cities[nearestCityID].Position.Y - unitYPos);
					}

					if (playerID != this.oGameData.Cities[nearestCityID].PlayerID &&
						(this.oGameData.Players[this.oGameData.Cities[nearestCityID].PlayerID].CityCount >= 2 ||
						this.oGameData.Players[this.oGameData.Cities[nearestCityID].PlayerID].Coins >= 100))
					{
						local_46 = -2;
						local_40 = -2;
					}

					if (local_40 != -2)
					{
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Cities[nearestCityID].Position.X;
						this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Cities[nearestCityID].Position.Y;

						// Instruction address 0x25fb:0x3ac3, size: 5
						//this.oParent.UnitGoTo.F0_2e31_000e_GetNextGoToMove(playerID, unitID);
						this.oGameData.Players[playerID].Units[unitID].GetNextGoToMove();

						//this.oGameData.Players[playerID].Units[unitID].GoToNextDirection = (sbyte)this.oCPU.AX.Low;
					}

					this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

					if (this.oGameData.Players[playerID].Units[unitID].TypeID == 26)
					{
						// Instruction address 0x25fb:0x3afc, size: 5
						TerrainTypeEnum local_32 = this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].Position.X,
							this.oGameData.Players[playerID].Units[unitID].Position.Y].TerrainType;

						if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1 &&
							local_32 != TerrainTypeEnum.Water &&
							this.oGameData.Players[playerID].Units[this.oGameData.Players[playerID].Units[unitID].NextUnitID].TypeID != 26)
						{
							this.oCPU.AX.UInt16 = 0x20;
							goto L3e96;
						}

						int local_34 = this.oParent.Var_6c9a;

						if (local_32 == TerrainTypeEnum.Water)
						{
							if (local_34 < 3)
							{
								// Instruction address 0x25fb:0x36cb, size: 5
								this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

								this.oCPU.AX.UInt16 = 0x20;
								goto L3e96;
							}
						}
						else
						{
							// Instruction address 0x25fb:0x3b55, size: 5
							int local_1c = (short)this.oParent.Segment_2dc4.F0_2dc4_0177(playerID, unitID,
								this.oGameData.Players[playerID].Units[unitID].Position.X,
								this.oGameData.Players[playerID].Units[unitID].Position.Y);

							if (this.oParent.Var_6c9a <= 3 && this.oGameData.Players[playerID].Units[local_1c].TypeID != 26)
							{
								this.oGameData.Players[playerID].Units[unitID].GoToDestination.X = this.oGameData.Players[playerID].Units[local_1c].Position.X;
								this.oGameData.Players[playerID].Units[unitID].GoToDestination.Y = this.oGameData.Players[playerID].Units[local_1c].Position.Y;

								this.oCPU.AX.UInt16 = 0;
								goto L3e96;
							}
							else if ((oParent.GameData.TurnCount & 0x7) + 4 <= local_34)
							{
								// Instruction address 0x25fb:0x36cb, size: 5
								this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

								this.oCPU.AX.UInt16 = 0x20;
								goto L3e96;
							}
						}
					}

					nextDirection = 0;
					int local_22 = -999;

					for (int i = 1; i < 9; i++)
					{
						GPoint direction = TerrainMap.MoveOffsets[i];

						// Instruction address 0x25fb:0x3c03, size: 5
						int newUnitXPos = this.oGameData.Map.WrapXPosition(this.oGameData.Players[playerID].Units[unitID].Position.X + direction.X);
						int newUnitYPos = this.oGameData.Players[playerID].Units[unitID].Position.Y + direction.Y;

						// Instruction address 0x25fb:0x3c1f, size: 5
						TerrainTypeEnum local_32 = this.oGameData.Map[newUnitXPos, newUnitYPos].TerrainType;

						if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air &&
							local_32 == TerrainTypeEnum.Water)
						{
							// Instruction address 0x25fb:0x3c3a, size: 5
							if (this.oGameData.Map.IsValidPosition(newUnitXPos, newUnitYPos))
							{
								// Instruction address 0x25fb:0x3c4c, size: 5
								int local_1e = (short)this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(newUnitXPos, newUnitYPos);

								if (this.oGameData.Players[playerID].Units[unitID].TypeID == 26)
								{
									int local_10 = 0;

									if (local_1e != -1)
									{
										if (playerID == this.oParent.Var_d7f0)
										{
											local_10 += 99;
										}
										else
										{
											local_10 -= 99;
										}
									}

									// Instruction address 0x25fb:0x3c92, size: 5
									this.oParent.Segment_2dc4.F0_2dc4_0102_FindNearestCity(newUnitXPos, newUnitYPos);

									// Instruction address 0x25fb:0x3c9e, size: 5			
									local_10 += (int)this.oGameData.Static.Terrains.GetValueByKey(local_32).MovementCost + this.oParent.MSCAPI.RNG.Next(4) + (this.oParent.Var_6c9a * 4);

									if (local_10 > local_22)
									{
										local_22 = local_10;
										nextDirection = i;
									}
								}
								else if (!this.oGameData.Map[newUnitXPos, newUnitYPos].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City) ||
									this.oParent.MapManagement.F0_2aea_1369_MapGetPlayerID(newUnitXPos, newUnitYPos) == playerID)
								{
									// Instruction address 0x25fb:0x3d09, size: 5
									// Instruction address 0x25fb:0x3d19, size: 5
									// Instruction address 0x25fb:0x3d34, size: 5
									int local_10 = ((this.oParent.MapManagement.F0_2aea_1369_MapGetPlayerID(newUnitXPos, newUnitYPos) == playerID) ? 0 : 4) +
										(this.oGameData.Map[newUnitXPos, newUnitYPos].Improvements.ContainsAnyFlag(TerrainImprovementEnum.Irrigation, TerrainImprovementEnum.Mine) ? 6 : 0) +
										this.oParent.MSCAPI.RNG.Next(6);

									if (local_1e == -1)
									{
										// Instruction address 0x25fb:0x3ddf, size: 5
										if (local_44 == 0 || this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land ||
											local_1e != -1 || this.oParent.Segment_1866.F0_1866_1725_UpdateCityVisibility(playerID, newUnitXPos, newUnitYPos) == 0)
										{
											if (this.oGameData.Players[playerID].Units[unitID].GoToNextDirection == i)
											{
												local_10 += 6;
											}

											direction = TerrainMap.MoveOffsets[i];

											if (direction.X == local_40)
											{
												local_10 += 2;
											}

											if (direction.Y == local_46)
											{
												local_10 += 2;
											}

											if (local_10 > local_22)
											{
												local_22 = local_10;
												nextDirection = i;
											}
										}
									}
									else if (playerID == this.oParent.Var_d7f0)
									{
										// Instruction address 0x25fb:0x3d63, size: 5
										if (this.oGameData.Map[unitXPos, unitYPos].TerrainType == TerrainTypeEnum.Water)
										{
											local_10 -= 20;

											// Instruction address 0x25fb:0x3ddf, size: 5
											if (local_44 == 0 || this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land ||
												local_1e != -1 || this.oParent.Segment_1866.F0_1866_1725_UpdateCityVisibility(playerID, newUnitXPos, newUnitYPos) == 0)
											{
												if (this.oGameData.Players[playerID].Units[unitID].GoToNextDirection == i)
												{
													local_10 += 6;
												}

												direction = TerrainMap.MoveOffsets[i];

												if (direction.X == local_40)
												{
													local_10 += 2;
												}

												if (direction.Y == local_46)
												{
													local_10 += 2;
												}

												if (local_10 > local_22)
												{
													local_22 = local_10;
													nextDirection = i;
												}
											}
										}
									}
									else
									{
										// Instruction address 0x25fb:0x3d7f, size: 5
										if (this.oGameData.Map[unitXPos, unitYPos].TerrainType != TerrainTypeEnum.Water)
										{
											if (this.oGameData.Players[this.oParent.Var_d7f0].Units[local_1e].TypeID != 26)
											{
												local_10 += 99;
											}

											// Instruction address 0x25fb:0x3ddf, size: 5
											if (local_44 == 0 || this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land ||
												local_1e != -1 || this.oParent.Segment_1866.F0_1866_1725_UpdateCityVisibility(playerID, newUnitXPos, newUnitYPos) == 0)
											{
												if (this.oGameData.Players[playerID].Units[unitID].GoToNextDirection == i)
												{
													local_10 += 6;
												}

												direction = TerrainMap.MoveOffsets[i];

												if (direction.X == local_40)
												{
													local_10 += 2;
												}

												if (direction.Y == local_46)
												{
													local_10 += 2;
												}

												if (local_10 > local_22)
												{
													local_22 = local_10;
													nextDirection = i;
												}
											}
										}
									}
								}
								else if (this.oGameData.Map[unitXPos, unitYPos].TerrainType != TerrainTypeEnum.Water)
								{
									this.oCPU.AX.UInt16 = (ushort)((short)i);
									goto L3e96;
								}
							}
						}
					}

					// Instruction address 0x25fb:0x3e50, size: 5
					if (!this.oGameData.Map[unitXPos, unitYPos].Improvements.ContainsAnyFlag(TerrainImprovementEnum.City) ||
						this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1 || local_22 >= 99)
					{
						this.oGameData.Players[playerID].Units[unitID].GoToNextDirection = nextDirection;

						this.oCPU.AX.UInt16 = (ushort)((short)nextDirection);
					}
					else
					{
						this.oCPU.AX.UInt16 = 0x20;
					}
				}
			}
			else
			{
				// Instruction address 0x25fb:0x365a, size: 5
				this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

				this.oCPU.AX.UInt16 = 0x20;
			}

		L3e96:
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_362d");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_25fb_3e9c(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3e9c({cityID})");

			// function body
			int xPos = this.oGameData.Cities[cityID].Position.X;
			int yPos = this.oGameData.Cities[cityID].Position.Y;

			for (int i = 1; i < 8; i++)
			{
				if (i != this.oGameData.HumanPlayerID)
				{
					if ((this.oGameData.Players[i].Diplomacy[this.oGameData.HumanPlayerID] & 2) == 0)
					{
						for (int j = 0; j < 128; j++)
						{
							// Instruction address 0x25fb:0x3f10, size: 5
							// Instruction address 0x25fb:0x3f2f, size: 5
							if (this.oGameData.Players[i].Units[j].TypeID != -1 &&
								this.oGameData.Static.Units[this.oGameData.Players[i].Units[j].TypeID].TransportCapacity != 0 &&
								this.oGameData.Players[i].Units[j].NextUnitID != -1 &&
								this.oGameData.Map[this.oGameData.Players[i].Units[j].Position.X,
									this.oGameData.Players[i].Units[j].Position.Y].TerrainType == TerrainTypeEnum.Water &&
								this.oGameData.Static.Units[this.oGameData.Players[i].Units[j].TypeID].MoveCount * 3 >
									this.oGameData.Map.GetDistance(this.oGameData.Players[i].Units[j].Position.X,
										this.oGameData.Players[i].Units[j].Position.Y, xPos, yPos))
							{
								this.oGameData.Players[i].Units[j].GoToDestination.X = xPos;
								this.oGameData.Players[i].Units[j].GoToDestination.Y = yPos;
							}
						}
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3e9c");
		}
	}
}
