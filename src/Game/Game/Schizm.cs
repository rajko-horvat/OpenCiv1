using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class Schizm
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Schizm(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F15_0000_0000(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F15_0000_0000({playerID})");

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8 = 0;
			int local_a;
			GPoint local_e = new GPoint(-1);
			int local_10 = 0;
			int newPlayerID = -1;
			int local_18;
			int local_1a;
			int local_1c;
			int local_1e;
			int local_20;
			int local_22;
			int local_24;
			int mapGroupCount = this.oGameData.Map.Groups.Count;
			int[] local_44 = new int[mapGroupCount];

			for (int i = 1; i < 8; i++)
			{
				if (this.oGameData.Players[i].UnitCount == 0 && this.oGameData.Players[i].CityCount == 0)
				{
					newPlayerID = i;
					break;
				}
			}

			// !!! This will have to be moved to GameData object as a part of new player method, the check if all nationalities are used is also needed
			int nationalityID = -1;

			while (nationalityID == -1)
			{
				// Instruction address 0x0000:0x09f9, size: 5
				nationalityID = this.oParent.MSCAPI.RNG.Next(14) + 1;
				if (nationalityID > 7) nationalityID++;

				for (int i = 0; i < 8; i++)
				{
					if (i != playerID && this.oGameData.Players[i].NationalityID == nationalityID)
					{
						nationalityID = -1;
						break;
					}
				}
			}

			if (newPlayerID != -1 && nationalityID!=-1)
			{
				Player oldPlayer = this.oGameData.Players[playerID];

				for (int i = 0; i < mapGroupCount; i++)
				{
					local_44[i] = 0;
				}

				local_24 = -1;

				for (int i = 0; i < 128; i++)
				{
					if (this.oGameData.Cities[i].StatusFlag != 0xff && this.oGameData.Cities[i].PlayerID == playerID)
					{
						int groupID = this.oGameData.Map[this.oGameData.Cities[i].Position].Layer3_GroupID;
						local_44[groupID] += this.oGameData.Cities[i].ActualSize;

						if ((this.oGameData.Cities[i].ImprovementFlags0 & 0x1) != 0)
						{
							if (local_24 == -1 || oldPlayer.XStart == this.oGameData.Cities[i].Position.X)
							{
								// Instruction address 0x0000:0x00cc, size: 5
								local_24 = groupID;
								local_e = this.oGameData.Cities[i].Position;
								local_8 = i;
							}
						}
					}
				}

				if (local_24 != -1)
				{
					this.oParent.GameData.ActivePlayers &= (short)(~(1 << newPlayerID));

					// !!! This will now do, the F5_0000_07c7_InitPlayerData seeks a new starting position, while we don't need a new one
					if (this.oParent.StartGameMenu.F5_0000_07c7_InitPlayerData((short)newPlayerID) != 0)
					{
						this.oParent.GameData.ActivePlayers |= (short)(1 << newPlayerID);

						Player newPlayer = this.oGameData.Players[newPlayerID];
						NationDefinition nation = this.oGameData.Static.Nations[nationalityID];

						newPlayer.NationalityID = (short)nationalityID;
						newPlayer.Name = nation.Leader;
						newPlayer.Nationality = nation.Nationality;

						if (!string.IsNullOrEmpty(nation.Nation))
						{
							newPlayer.Nation = nation.Nation;
						}
						else
						{
							newPlayer.Nation = newPlayer.Nationality + "s";
						}

						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

						// Instruction address 0x0000:0x0241, size: 5
						this.oParent.Array_30b8[0] = oldPlayer.Nationality;

						// Instruction address 0x0000:0x0251, size: 5
						this.oParent.Array_30b8[1] = newPlayer.Nationality;

						// Instruction address 0x0000:0x026a, size: 5
						this.oParent.Segment_2f4d.F0_2f4d_044f((ushort)((playerID == this.oGameData.HumanPlayerID) ? 0x4a18 : 0x4a20));

						this.oParent.Var_2f9e = 5;

						// Instruction address 0x0000:0x0281, size: 5
						this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

						newPlayer.Coins = (short)(oldPlayer.Coins / 2);
						oldPlayer.Coins /= 2;
						newPlayer.MilitaryPower = (short)(oldPlayer.MilitaryPower / 2);
						oldPlayer.MilitaryPower /= 2;
						newPlayer.ResearchProgress = oldPlayer.ResearchProgress;
						newPlayer.DiscoveredTechnologyCount = oldPlayer.DiscoveredTechnologyCount;
						newPlayer.GovernmentType = oldPlayer.GovernmentType;

						for (int i = 0; i < 5; i++)
						{
							newPlayer.DiscoveredTechnologyFlags[i] = oldPlayer.DiscoveredTechnologyFlags[i];
						}

						newPlayer.ContactPlayerCountdown = (short)(this.oParent.GameData.TurnCount - 8);
						oldPlayer.Diplomacy[newPlayerID] |= 1;
						oldPlayer.Diplomacy[newPlayerID] |= 9;

						local_1e = local_44[local_24];
						local_22 = 0;

						for (int i = 0; i < 16; i++)
						{
							if (local_44[i] != 0)
							{
								if (local_22 <= local_1e || i != local_24)
								{
									local_22 += local_44[i];
									local_44[i] = 2;
								}
								else
								{
									if (i != local_24)
									{
										local_1e += local_44[i];
									}

									local_44[i] = 1;
								}
							}
						}

						if (local_22 * 2 > local_1e && local_22 <= local_1e)
						{
							for (int i = 0; i < 128; i++)
							{
								if (this.oGameData.Cities[i].StatusFlag != 0xff && this.oGameData.Cities[i].PlayerID == playerID)
								{
									local_18 = this.oGameData.Map[this.oGameData.Cities[i].Position].Layer3_GroupID;

									if (local_44[local_18] == 2)
									{
										this.oGameData.Cities[i].SetCityOwner(this.oGameData, i, newPlayerID);
									}
								}
							}
						}
						else
						{
							local_22 = 0;

							while (((9 * local_22) / (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc6a) + 3)) < oldPlayer.TotalCitySize)
							{
								local_a = 1;

								for (int j = 0; j < 128; j++)
								{
									if (this.oGameData.Cities[j].StatusFlag != 0xff && this.oGameData.Cities[j].PlayerID == playerID)
									{
										// Instruction address 0x0000:0x0431, size: 5
										local_4 = this.oGameData.Map.GetDistance(this.oGameData.Cities[j].Position, local_e);

										if (local_4 > local_a)
										{
											local_a = local_4;
											local_10 = j;
										}
									}
								}

								local_22 += this.oGameData.Cities[local_10].ActualSize;

								this.oGameData.Cities[local_10].SetCityOwner(this.oGameData, local_10, newPlayerID);
							}
						}

						oldPlayer.TotalCitySize += newPlayer.TotalCitySize;

						for (int i = 0; i < 128; i++)
						{
							if (oldPlayer.Units[i].TypeID != -1)
							{
								local_2 = oldPlayer.Units[i].TypeID;

								// Instruction address 0x0000:0x0765, size: 5
								if ((this.oGameData.Map[oldPlayer.Units[i].Position].Layer5_TerrainImprovements1 & 0x1) != 0)
								{
									// Instruction address 0x0000:0x0780, size: 5
									this.oParent.Segment_2dc4.F0_2dc4_00ba(
										oldPlayer.Units[i].Position.X,
										oldPlayer.Units[i].Position.Y);

									local_10 = (short)this.oCPU.AX.Word;

									local_2 = oldPlayer.Units[i].TypeID;

									if (this.oGameData.Cities[oldPlayer.Units[i].HomeCityID].PlayerID ==
										this.oGameData.Cities[local_10].PlayerID)
									{
										if (this.oGameData.Cities[local_10].PlayerID == newPlayerID)
										{
											// Instruction address 0x0000:0x04cd, size: 5
											this.oParent.Segment_1866.F0_1866_0f10(playerID, (short)i);

											// Instruction address 0x0000:0x04f1, size: 5
											this.oParent.MapManagement.F0_2aea_1511_ActiveUnitsSetFlag8(
												oldPlayer.Units[i].Position.X,
												oldPlayer.Units[i].Position.Y);

											// Instruction address 0x0000:0x050b, size: 5
											local_6 = (short)this.oParent.Segment_1866.F0_1866_0cf5(
												(short)newPlayerID, (short)local_2,
												oldPlayer.Units[i].Position.X,
												oldPlayer.Units[i].Position.Y);

											newPlayer.Units[local_6].Status = (short)(oldPlayer.Units[i].Status & 0xfe);
										}
									}
									else
									{
										// Instruction address 0x0000:0x07b8, size: 5
										this.oParent.Segment_1866.F0_1866_0f10(playerID, (short)i);

										// Instruction address 0x0000:0x07cc, size: 5
										this.oParent.MapManagement.F0_2aea_1511_ActiveUnitsSetFlag8(
											oldPlayer.Units[i].Position.X,
											oldPlayer.Units[i].Position.Y);

										// Instruction address 0x0000:0x07e7, size: 5
										this.oParent.Segment_1866.F0_1866_0cf5(
											this.oGameData.Cities[local_10].PlayerID,
											oldPlayer.Units[i].TypeID,
											oldPlayer.Units[i].Position.X,
											oldPlayer.Units[i].Position.Y);

										local_6 = (short)this.oCPU.AX.Word;
									}
								}
								else
								{
									local_1c = this.oGameData.Cities[oldPlayer.Units[i].HomeCityID].PlayerID;
									local_1a = oldPlayer.Units[i].NextUnitID;

									if (local_1c == newPlayerID)
									{
										// Instruction address 0x0000:0x056c, size: 5
										this.oParent.Segment_1866.F0_1866_0f10(playerID, (short)i);

										// Instruction address 0x0000:0x0583, size: 5
										this.oParent.MapManagement.F0_2aea_138c_MapSetCityOwner(
											oldPlayer.Units[i].Position.X,
											oldPlayer.Units[i].Position.Y,
											(short)newPlayerID);

										// Instruction address 0x0000:0x0597, size: 5
										this.oParent.MapManagement.F0_2aea_1511_ActiveUnitsSetFlag8(
											oldPlayer.Units[i].Position.X,
											oldPlayer.Units[i].Position.Y);

										// Instruction address 0x0000:0x05b1, size: 5
										local_6 = (short)this.oParent.Segment_1866.F0_1866_0cf5(
											(short)newPlayerID, (short)local_2,
											oldPlayer.Units[i].Position.X,
											oldPlayer.Units[i].Position.Y);

										newPlayer.Units[local_6].Status = (short)(oldPlayer.Units[i].Status & 0xfe);
										newPlayer.Units[local_6].HomeCityID = oldPlayer.Units[i].HomeCityID;

										while (local_1a != -1 && local_1a != i)
										{
											local_20 = oldPlayer.Units[local_1a].NextUnitID;

											local_2 = oldPlayer.Units[local_1a].TypeID;

											// Instruction address 0x0000:0x061a, size: 5
											this.oParent.Segment_1866.F0_1866_0f10(playerID, (short)local_1a);

											// Instruction address 0x0000:0x063e, size: 5
											this.oParent.MapManagement.F0_2aea_138c_MapSetCityOwner(
												oldPlayer.Units[i].Position.X,
												oldPlayer.Units[i].Position.Y,
												(short)newPlayerID);

											if (local_2 != -1)
											{
												// Instruction address 0x0000:0x065b, size: 5
												this.oParent.MapManagement.F0_2aea_1511_ActiveUnitsSetFlag8(
													oldPlayer.Units[i].Position.X,
													oldPlayer.Units[i].Position.Y);

												// Instruction address 0x0000:0x0678, size: 5
												local_6 = (short)this.oParent.Segment_1866.F0_1866_0cf5(
													(short)newPlayerID, (short)local_2,
													oldPlayer.Units[i].Position.X,
													oldPlayer.Units[i].Position.Y);

												newPlayer.Units[local_6].Status = (short)(oldPlayer.Units[i].Status & 0xfe);

												if (this.oGameData.Cities[oldPlayer.Units[local_1a].HomeCityID].PlayerID != local_1c)
												{
													newPlayer.Units[local_6].HomeCityID = oldPlayer.Units[i].HomeCityID;
												}
											}

											local_1a = local_20;
										}
									}
									else
									{
										while (local_1a != -1 && local_1a != i)
										{
											local_20 = oldPlayer.Units[local_1a].NextUnitID;

											if (this.oGameData.Cities[oldPlayer.Units[local_1a].HomeCityID].PlayerID != local_1c)
											{
												oldPlayer.Units[local_1a].HomeCityID = oldPlayer.Units[i].HomeCityID;
											}

											local_1a = local_20;
										}
									}
								}
							}
						}

						local_10 = this.oGameData.FindNearestDomesticCity(newPlayerID);

						this.oGameData.Cities[local_10].ImprovementFlags0 |= 1;

						newPlayer.XStart = (short)this.oGameData.Cities[local_10].Position.X;

						if (playerID == this.oGameData.HumanPlayerID)
						{
							// Instruction address 0x0000:0x082f, size: 5
							this.oParent.MapManagement.F0_2aea_0008(this.oGameData.HumanPlayerID,
								this.oParent.Var_d4cc_XPos, this.oParent.Var_d75e_YPos);
						}
						else
						{
							this.oGameData.Cities[local_8].PlayerID = -1;

							local_10 = this.oGameData.FindNearestDomesticCity(playerID);

							this.oGameData.Cities[local_10].ImprovementFlags0 |= 1;
							oldPlayer.XStart = (short)this.oGameData.Cities[local_10].Position.X;
							this.oGameData.Cities[local_8].PlayerID = playerID;
						}
					
						this.oCPU.AX.Word = 0x1;
					}
					else
					{
						this.oCPU.AX.Word = 0;
					}
				}
				else
				{
					this.oCPU.AX.Word = 0;
				}
			}
			else
			{
				this.oCPU.AX.Word = 0;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F15_0000_0000");

			return this.oCPU.AX.Word;
		}
	}
}
