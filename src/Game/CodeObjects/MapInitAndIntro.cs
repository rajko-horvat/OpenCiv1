using Avalonia.Media;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class MapInitAndIntro
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		private MapManagement Map;
		private bool mapFinished = false;

		private int animationStage = 0;
		private int buildImageIndex = 1;
		private int paletteSlotCount = 0;

		private StreamReader? storyFile = null;
		private string storyText = "";

		private int storyTimeIndex = 0;
		private DateTime storyStartTime;
		private DateTime storyNextEvent;

		private PaletteCycleInfo[][] storyImagePaletteCycles = [
			[new(14, 146, 152), new(60, 183, 187), new(17, 188, 191)],
			[new(27, 48, 56), new(30, 32, 47), new(23, 141, 148), new(13, 176, 183), new(100, 211, 215), new(300, 152, 155), new(20, 57, 79)],
			[new(17, 80, 95), new(42, 96, 111), new(10, 112, 127), new(30, 136, 140), new(27, 184, 188)],
			[new(60, 134, 138), new(30, 139, 143), new(13, 240, 241), new(12, 96, 101), new(10, 242, 244), new(25, 245, 250), new(27, 251, 252), new(14, 102, 105)],
			[new(14, 184, 187), new(18, 180, 183), new(25, 135, 140), new(14, 214, 215), new(17, 96, 102)],
			[new(14, 136, 138), new(37, 129, 131), new(14, 246, 249), new(25, 250, 254)],
			[new(14, 246, 249), new(30, 250, 251), new(27, 208, 210), new(18, 135, 138)],
			[new(18, 208, 210), new(27, 216, 218), new(18, 131, 134), new(12, 48, 53), new(4, 246, 249)]];

		private TimeSpan[] storyEvents = [
			new(0, 0, 0), new(0, 0, 5), new(0, 0, 8), new(0, 0, 11),
			new(0, 0, 18), new(0, 0, 21), new(0, 0, 24),
			new(0, 0, 31), new(0, 0, 34), new(0, 0, 37), new(0, 0, 40), new(0, 0, 43), new(0, 0, 46), new(0, 0, 49), new(0, 0, 52),
			new(0, 0, 59), new(0, 1, 2), new(0, 1, 5), new(0, 1, 8), new(0, 1, 11),
			new(0, 1, 18), new(0, 1, 21), new(0, 1, 24), new(0, 1, 27), new(0, 1, 30), new(0, 1, 33),
			new(0, 1, 40), new(0, 1, 43), new(0, 1, 46), new(0, 1, 49), new(0, 1, 52), new(0, 1, 55), new(0, 1, 58), new(0, 2, 1),
			new(0, 2, 8), new(0, 2, 11), new(0, 2, 14), new(0, 2, 17), new(0, 2, 20), new(0, 2, 23), new(0, 2, 26), new(0, 2, 29), new(0, 2, 32), new(0, 2, 35),
			new(0, 2, 42), new(0, 2, 45)];

		public MapInitAndIntro(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.Map = this.oParent.MapManagement;
		}

		/// <summary>
		/// Generates a game map while showing the animation
		/// </summary>
		public void F7_0000_0012_GenerateMap()
		{
			//this.oCPU.Log.EnterBlock("F7_0000_0012_GameIntro()");

			// function body
			RandomMT19937 rng = new RandomMT19937(this.oParent.GameData.RandomSeed);

			this.mapFinished = false;

			if (this.oParent.Var_d76a_EarthMap)
			{
				this.Map.LoadEarthMap();
			}
			else
			{
				this.Map.CreateNewEmptyMap();

				#region Stage 1 - Generate continents
				F7_0000_17cf_AdvanceAnimation();

				int totalCellCount = this.oParent.Var_7ef6_PlanetLandMass * 320 + 640;

				for (int i = 0; i < totalCellCount;)
				{
					int cloudCellCount = 0;
					bool[,] cloud = new bool[80, 50];

					for (int j = 0; j < 80; j++)
					{
						for (int k = 0; k < 50; k++)
						{
							cloud[j, k] = false;
						}
					}

					int x = rng.Next(72) + 4;
					int y = rng.Next(34) + 8;
					int cloudSize = rng.Next(64) + 1;

					do
					{
						int x1 = this.Map.AdjustXPosition(x + 1);
						int xm1 = this.Map.AdjustXPosition(x - 1);

						cloud[x, y] = true;
						cloud[x, y - 1] = true;
						cloud[x1, y] = true;
						cloud[x, y + 1] = true;
						cloud[xm1, y] = true;

						switch (rng.Next(4))
						{
							case 0:
								x += 0;
								y -= 1;
								break;

							case 1:
								x += 1;
								y += 0;
								break;

							case 2:
								x += 0;
								y += 1;
								break;

							case 3:
								x -= 1;
								y += 0;
								break;
						}

						x = Map.AdjustXPosition(x);

						cloudSize--;

					} while (cloudSize > 0 && y > 4 && y < 45);

					// Copy the map cloud to actual map
					for (int j = 0; j < 80; j++)
					{
						for (int k = 0; k < 50; k++)
						{
							if (cloud[j, k])
							{
								// Are continents on map overlapping?
								switch (this.Map.GetTerrainType(j, k))
								{
									case TerrainTypeEnum.Water:
										this.Map.SetTerrainType(j, k, TerrainTypeEnum.Plains);
										break;

									case TerrainTypeEnum.Plains:
										this.Map.SetTerrainType(j, k, TerrainTypeEnum.Hills);
										break;

									case TerrainTypeEnum.Hills:
										this.Map.SetTerrainType(j, k, TerrainTypeEnum.Mountains);
										break;
								}

								cloudCellCount++;
							}
						}
					}

					i += cloudCellCount;

					F7_0000_17cf_AdvanceAnimation();
				}

				/*for (int i = 0; i < 80; i++)
				{
					for (int j = 1; j < 49; j++)
					{
						int edges = 0;

						edges |= (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j) != 0) ? 0x1 : 0;
						edges |= (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i + 1, j) != 0) ? 0x2 : 0;
						edges |= (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j + 1) != 0) ? 0x4 : 0;
						edges |= (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i + 1, j + 1) != 0) ? 0x8 : 0;

						if (edges == 0x6 || edges == 0x9)
						{
							// Instruction address 0x0000:0x0157, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 1, j, 1);

							// Instruction address 0x0000:0x016c, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j + 1, 1);

							// Instruction address 0x0000:0x017b, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 1, j + 1, 1);

							if (i != 0)
							{
								i--;
							}

							if (j != 0)
							{
								j--;
							}
						}
					}

					F7_0000_17cf_AdvanceAnimation();
				}*/
				#endregion

				#region Stage 2 - Add map details according to temperature
				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						// Instruction address 0x0000:0x01e2, size: 5
						if (this.Map.GetTerrainType(i, j) == TerrainTypeEnum.Plains)
						{
							switch ((Math.Abs(rng.Next(8) + j - 29) + (1 - this.oParent.Var_7ef8_PlanetTemperature)) / 6 + 1)
							{
								case 0:
								case 1:
									// Instruction address 0x0000:0x01c4, size: 5
									this.Map.SetTerrainType(i, j, TerrainTypeEnum.Desert);
									break;

								//case 2:
								//case 3:
									// Instruction address 0x0000:0x01c4, size: 5
									//this.Map.SetTerrainType(i, j, TerrainTypeEnum.Plains);
									//break;

								case 4:
								case 5:
									// Instruction address 0x0000:0x01c4, size: 5
									this.Map.SetTerrainType(i, j, TerrainTypeEnum.Tundra);
									break;

								case 6:
								case 7:
									// Instruction address 0x0000:0x01c4, size: 5
									this.Map.SetTerrainType(i, j, TerrainTypeEnum.Arctic);
									break;
							}
						}

						F7_0000_17cf_AdvanceAnimation();
					}
				}
				#endregion

				#region Stage 3 - Adjust climate regions
				for (int i = 0; i < 50; i++)
				{
					int medianY = Math.Abs(25 - i);
					int climateValue = 0;

					for (int j = 0; j < 80; j++)
					{
						// Instruction address 0x0000:0x030d, size: 5
						TerrainTypeEnum cellValue = this.Map.GetTerrainType(j, i);

						if (cellValue != TerrainTypeEnum.Water)
						{
							if (climateValue > 0)
							{
								// Instruction address 0x0000:0x02bd, size: 5
								climateValue -= rng.Next(-((this.oParent.Var_7efa_PlanetClimate * 2) - 7));

								switch (cellValue)
								{
									case TerrainTypeEnum.Plains:
										// Instruction address 0x0000:0x02f2, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Grassland);
										break;

									case TerrainTypeEnum.Tundra:
										// Instruction address 0x0000:0x02f2, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Arctic);
										break;

									case TerrainTypeEnum.Hills:
										// Instruction address 0x0000:0x02f2, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Forest);
										break;

									case TerrainTypeEnum.Mountains:
										climateValue -= 3;
										break;

									case TerrainTypeEnum.Desert:
										// Instruction address 0x0000:0x02f2, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Plains);
										break;
								}
							}
						}
						else
						{
							// Instruction address 0x0000:0x0324, size: 5				
							if (Math.Abs(12 - medianY) + this.oParent.Var_7efa_PlanetClimate * 4 > climateValue)
							{
								climateValue++;
							}
						}
					}

					climateValue = 0;

					for (int j = 79; j >= 0; j--)
					{
						// Instruction address 0x0000:0x03dc, size: 5
						TerrainTypeEnum cellValue = this.Map.GetTerrainType(j, i);

						if (cellValue != TerrainTypeEnum.Water)
						{
							if (climateValue > 0)
							{
								// Instruction address 0x0000:0x037e, size: 5
								climateValue -= rng.Next(-(this.oParent.Var_7efa_PlanetClimate * 2 - 7));

								switch (cellValue)
								{
									case TerrainTypeEnum.Swamp:
									case TerrainTypeEnum.Hills:
										// Instruction address 0x0000:0x03c1, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Forest);
										break;

									case TerrainTypeEnum.Plains:
										// Instruction address 0x0000:0x03c1, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Grassland);
										break;

									case TerrainTypeEnum.Grassland:
										if (medianY < 10)
										{
											// Instruction address 0x0000:0x0424, size: 5
											this.Map.SetTerrainType(j, i, TerrainTypeEnum.Jungle);
										}
										else
										{
											// Instruction address 0x0000:0x0424, size: 5
											this.Map.SetTerrainType(j, i, TerrainTypeEnum.Swamp);
										}

										climateValue = -2;
										break;

									case TerrainTypeEnum.Mountains:
										climateValue -= 3;

										// Instruction address 0x0000:0x03c1, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Forest);
										break;


									case TerrainTypeEnum.Desert:
										// Instruction address 0x0000:0x03c1, size: 5
										this.Map.SetTerrainType(j, i, TerrainTypeEnum.Plains);
										break;
								}
							}
						}
						else
						{
							if (medianY / 2 + this.oParent.Var_7efa_PlanetClimate > climateValue)
							{
								climateValue++;
							}
						}
					}

					F7_0000_17cf_AdvanceAnimation();
				}
				#endregion

				#region Stage 4 - Adjust planet age
				int cellX = 0;
				int cellY = 0;
				int ageValue = 800 + 800 * this.oParent.Var_7efc_PlanetAge;

				for (int i = 0; i < ageValue; i++)
				{
					if ((i & 0x1) != 0)
					{
						// Instruction address 0x0000:0x0553, size: 5
						GPoint direction = this.oParent.MoveDirections[rng.Next(8) + 1];

						cellX += direction.X;
						cellY += direction.Y;
					}
					else
					{
						cellX = rng.Next(80);
						cellY = rng.Next(50);
					}

					// Instruction address 0x0000:0x049d, size: 5				
					switch (this.Map.GetTerrainType(cellX, cellY))
					{
						case TerrainTypeEnum.Forest:
							// Instruction address 0x0000:0x050e, size: 5
							this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Jungle);
							break;

						case TerrainTypeEnum.Swamp:
							// Instruction address 0x0000:0x050e, size: 5
							this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Grassland);
							break;

						case TerrainTypeEnum.Plains:
						case TerrainTypeEnum.Tundra:
							// Instruction address 0x0000:0x050e, size: 5
							this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Hills);
							break;

						case TerrainTypeEnum.Grassland:
							// Instruction address 0x0000:0x050e, size: 5
							this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Forest);
							break;

						case TerrainTypeEnum.Jungle:
							// Instruction address 0x0000:0x050e, size: 5
							this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Swamp);
							break;

						case TerrainTypeEnum.Hills:
						case TerrainTypeEnum.Arctic:
							// Instruction address 0x0000:0x050e, size: 5
							this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Mountains);
							break;

						case TerrainTypeEnum.Mountains:
							if (this.Map.GetTerrainType(cellX - 1, cellY - 1) != TerrainTypeEnum.Water &&
								this.Map.GetTerrainType(cellX - 1, cellY + 1) != TerrainTypeEnum.Water &&
								this.Map.GetTerrainType(cellX + 1, cellY - 1) != TerrainTypeEnum.Water &&
								this.Map.GetTerrainType(cellX + 1, cellY + 1) != TerrainTypeEnum.Water)
							{
								this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Water);
							}
							break;

						case TerrainTypeEnum.Desert:
							// Instruction address 0x0000:0x050e, size: 5
							this.Map.SetTerrainType(cellX, cellY, TerrainTypeEnum.Plains);
							break;

						default:
							break;
					}
				}
				#endregion

				// !!! This needs to be reworked, not generating rivers properly (logically)
				#region Stage 5 - Generate rivers
				int riverValue = (this.oParent.Var_7ef6_PlanetLandMass + this.oParent.Var_7efa_PlanetClimate) * 2 + 6;
				int riverCellCount = 0;
				TerrainTypeEnum[,] mapCopy = new TerrainTypeEnum[80, 50];

				for (int i = 0; i < 256 && riverCellCount <= riverValue; i++)
				{
					int local_16 = 0;
					int riverX;
					int riverY;

					// make a copy of the map
					for (int j = 0; j < 80; j++)
					{
						for (int k = 0; k < 50; k++)
						{
							mapCopy[j, k] = this.Map.GetTerrainType(j, k);
						}
					}

					bool hasHills = false;

					for (int j = 0; j < 80 && !hasHills; j++)
					{
						for (int k = 0; k < 50; k++)
						{
							if (this.Map.GetTerrainType(j, k) == TerrainTypeEnum.Hills)
							{
								hasHills = true;
								break;
							}
						}
					}

					if (!hasHills)
						break;

					// Rivers start at hills
					do
					{
						riverX = rng.Next(80);
						riverY = rng.Next(50);
					}
					while (this.Map.GetTerrainType(riverX, riverY) != TerrainTypeEnum.Hills);

					int newRiverX = riverX;
					int newRiverY = riverY;
					bool riverEnds = false;
					TerrainTypeEnum cellValue;
					int newDirection = rng.Next(4) * 2;
					int oldDirection = newDirection;

					do
					{
						// Instruction address 0x0000:0x06f4, size: 5
						this.Map.SetTerrainType(newRiverX, newRiverY, TerrainTypeEnum.River);

						for (int j = 1; j < 9; j += 2)
						{
							GPoint direction = this.oParent.MoveDirections[j];

							if (this.Map.GetTerrainType(newRiverX + direction.X, newRiverY + direction.Y) == TerrainTypeEnum.Water)
							{
								riverEnds = true;
							}
						}

						oldDirection = newDirection;
						newDirection = ((rng.Next(2) - (local_16 & 1)) * 2 + newDirection) & 0x7;

						if ((oldDirection ^ 0x4) > newDirection)
						{
							// Instruction address 0x0000:0x077c, size: 5
							this.Map.F0_2aea_1653_SetTerrainImprovements(newRiverX, newRiverY, TerrainImprovementFlagsEnum.Flag80);
						}

						GPoint direction1 = this.oParent.MoveDirections[newDirection + 1];

						newRiverX += direction1.X;
						newRiverY += direction1.Y;

						// Instruction address 0x0000:0x07a1, size: 5
						cellValue = this.Map.GetTerrainType(newRiverX, newRiverY);

						local_16++;
					}
					while (!riverEnds && cellValue != TerrainTypeEnum.Water && cellValue != TerrainTypeEnum.River && cellValue != TerrainTypeEnum.Mountains);

					if ((!riverEnds && cellValue != TerrainTypeEnum.River) || local_16 < 5)
					{
						// restore map copy
						for (int j = 0; j < 80; j++)
						{
							for (int k = 0; k < 50; k++)
							{
								this.Map.SetTerrainType(j, k, mapCopy[j, k]);
							}
						}
					}
					else
					{
						riverCellCount++;

						for (int j = 1; j < 22; j++)
						{
							GPoint direction = this.oParent.MoveDirections[j];

							newRiverX = riverX + direction.X;
							newRiverY = riverY + direction.Y;

							// Instruction address 0x0000:0x0827, size: 5
							if (this.Map.GetTerrainType(newRiverX, newRiverY) == TerrainTypeEnum.Forest)
							{
								// Instruction address 0x0000:0x0842, size: 5
								this.Map.SetTerrainType(newRiverX, newRiverY, TerrainTypeEnum.Jungle);
							}
						}
					}

					F7_0000_17cf_AdvanceAnimation();
				}
				#endregion
			}

			// !!! This needs to be reworked, map could have more than 14 groups
			#region Stage 6 - Generage map groups
			int[,] groupIDs = new int[80, 50];

			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 80; j++)
				{
					for (int k = 0; k < 50; k++)
					{
						groupIDs[j, k] = 0;
					}
				}

				int newGroupID = 0;

				for (int j = 0; j < 50; j++)
				{
					int currentGroupID = -1;
					bool keepGroupID = false;

					for (int k = 0; k < 80; k++)
					{
						if (((this.Map.GetTerrainType(k, j) == TerrainTypeEnum.Water) ? 0 : 1) == ((i < 1) ? 1 : 0))
						{
							if (j > 0)
							{
								int xOffset = (k != 0) ? -1 : 0;

								if (((k >= 79) ? 0 : 1) >= xOffset)
								{
									int tempX = k + xOffset;
									int tempY = j;

									if (tempY > 0)
									{
										tempY--;
									}
									else
									{
										tempX--;
										tempY = 49;
									}

									int groupID = groupIDs[tempX, tempY];

									if (groupID != 0)
									{
										if (currentGroupID != -1 && currentGroupID != groupID)
										{
											for (int l = 0; l <= j; l++)
											{
												for (int m = 0; m < 80; m++)
												{
													if (groupIDs[m, l] == currentGroupID)
													{
														groupIDs[m, l] = (ushort)groupID;
													}

													switch (i)
													{
														case 0:
															this.oParent.GameData.Continents[groupID].Size += this.oParent.GameData.Continents[currentGroupID].Size;
															this.oParent.GameData.Continents[currentGroupID].Size = 0;
															break;

														case 1:
															this.oParent.GameData.Oceans[groupID].Size += this.oParent.GameData.Oceans[currentGroupID].Size;
															this.oParent.GameData.Oceans[currentGroupID].Size = 0;
															break;
													}
												}
											}
										}

										currentGroupID = groupID;

										F7_0000_17cf_AdvanceAnimation();
									}

								L0b87:
									xOffset++;

									if (((k >= 79) ? 0 : 1) >= xOffset)
									{
										tempX = k + xOffset;
										tempY = j;

										if (tempY > 0)
										{
											tempY--;
										}
										else
										{
											tempX--;
											tempY = 49;
										}

										groupID = groupIDs[tempX, tempY];

										if (groupID != 0)
										{
											if (currentGroupID != -1 && currentGroupID != groupID)
											{
												for (int l = 0; l <= j; l++)
												{
													for (int m = 0; m < 80; m++)
													{
														if (groupIDs[m, l] == currentGroupID)
														{
															groupIDs[m, l] = (ushort)groupID;
														}

														switch (i)
														{
															case 0:
																this.oParent.GameData.Continents[groupID].Size += this.oParent.GameData.Continents[currentGroupID].Size;
																this.oParent.GameData.Continents[currentGroupID].Size = 0;
																break;

															case 1:
																this.oParent.GameData.Oceans[groupID].Size += this.oParent.GameData.Oceans[currentGroupID].Size;
																this.oParent.GameData.Oceans[currentGroupID].Size = 0;
																break;
														}
													}
												}
											}
											currentGroupID = groupID;

											F7_0000_17cf_AdvanceAnimation();
										}
										goto L0b87;
									}
								}
							}

							if (currentGroupID == -1)
							{
								if (!keepGroupID)
								{
									newGroupID = 0;

								L0bac:
									newGroupID++;

									switch (i)
									{
										case 0:
											if (this.oParent.GameData.Continents[newGroupID].Size != 0)
												goto L0bac;

											break;

										case 1:
											if (this.oParent.GameData.Oceans[newGroupID].Size != 0)
												goto L0bac;

											break;
									}
								}

								currentGroupID = newGroupID;
							}

							groupIDs[k, j] = (ushort)currentGroupID;

							switch (i)
							{
								case 0:
									this.oParent.GameData.Continents[currentGroupID].Size++;
									break;

								case 1:
									this.oParent.GameData.Oceans[currentGroupID].Size++;
									break;
							}

							keepGroupID = true;
						}
						else
						{
							keepGroupID = false;
							currentGroupID = -1;
						}
					}

					F7_0000_17cf_AdvanceAnimation();
				}
				//

				int[] groupIndexes = new int[16];

				for (int j = 0; j < 16; j++)
				{
					groupIndexes[j] = 0;
				}

				int[] newGroupIDs = new int[64];

				newGroupIDs[0] = 0;

				for (int j = 1; j < 64; j++)
				{
					newGroupIDs[j] = 15;

					int groupIndex = 1;

				L0ce6:
					if (groupIndex < 15)
					{
						switch (i)
						{
							case 0:
								if (this.oParent.GameData.Continents[groupIndexes[groupIndex]].Size >= this.oParent.GameData.Continents[j].Size)
								{
									groupIndex++;
									goto L0ce6;
								}

								break;

							case 1:
								if (this.oParent.GameData.Oceans[groupIndexes[groupIndex]].Size >= this.oParent.GameData.Oceans[j].Size)
								{
									groupIndex++;
									goto L0ce6;
								}

								break;
						}

						for (int k = 15; k > groupIndex; k--)
						{
							newGroupIDs[groupIndexes[k - 1]] = k;

							groupIndexes[k] = groupIndexes[k - 1];
						}

						newGroupIDs[j] = groupIndex;
						groupIndexes[groupIndex] = j;
					}
				}

				newGroupIDs[0] = 0;

				for (int j = 0; j < 80; j++)
				{
					for (int k = 0; k < 50; k++)
					{
						int groupID = newGroupIDs[groupIDs[j, k]];

						if (groupID != 0)
						{
							// Instruction address 0x0000:0x0d67, size: 5
							this.Map.SetGroupID(j, k, groupID);
						}
					}
				}

				int[] groupSizes = new int[16];

				for (int j = 1; j < 15; j++)
				{
					switch (i)
					{
						case 0:
							groupSizes[j] = this.oParent.GameData.Continents[groupIndexes[j]].Size;
							break;

						case 1:
							groupSizes[j] = this.oParent.GameData.Oceans[groupIndexes[j]].Size;
							break;
					}
				}

				for (int j = 1; j < 15; j++)
				{
					switch (i)
					{
						case 0:
							this.oParent.GameData.Continents[j].Size = (short)groupSizes[j];
							break;

						case 1:
							this.oParent.GameData.Oceans[j].Size = (short)groupSizes[j];
							break;
					}
				}

				switch (i)
				{
					case 0:
						this.oParent.GameData.Continents[0].Size = 0;
						this.oParent.GameData.Continents[15].Size = 1;
						break;

					case 1:
						this.oParent.GameData.Oceans[0].Size = 0;
						this.oParent.GameData.Oceans[15].Size = 1;
						break;
				}

				F7_0000_17cf_AdvanceAnimation();
			}
			#endregion

			// For 'Save game' compatibility reasons
			F7_0000_1188_ConstructLandPath();
			//F7_0000_1440_ConstructWaterPath();

			F7_0000_17cf_AdvanceAnimation();

			#region Stage 7 - Look for suitable places to build cities
			int[] terrainCoefficients = new int[24];

			for (int i = 0; i < 16; i++)
			{
				this.oParent.GameData.Continents[i].BuildSiteCount = 0;
			}

			for (int i = 0; i < 24; i++)
			{
				terrainCoefficients[i] = this.oParent.GameData.Terrains[i].Trade + (3 * this.oParent.GameData.Terrains[i].Food);

				int local_2 = i % 12;

				if (local_2 != 2 && local_2 != 11)
				{
					terrainCoefficients[i] += this.oParent.GameData.Terrains[i].Production * 2;
				}

				if (this.oParent.GameData.TerrainModifications[local_2].MiningEffect >= 0)
				{
					if (this.oParent.GameData.TerrainModifications[local_2].IrrigationEffect < 0)
					{
						terrainCoefficients[i] += (-1 - this.oParent.GameData.TerrainModifications[local_2].IrrigationEffect) * 2;
					}
				}
				else
				{
					terrainCoefficients[i] += -1 - this.oParent.GameData.TerrainModifications[local_2].MiningEffect;
				}
			}

			for (int i = 2; i < 78; i++)
			{
				for (int j = 2; j < 48; j++)
				{
					TerrainTypeEnum terrainType = this.Map.GetTerrainType(i, j);

					if (terrainType == TerrainTypeEnum.River || terrainType == TerrainTypeEnum.Grassland || terrainType == TerrainTypeEnum.Plains)
					{
						int totalLocationScore = 0;

						for (int k = 0; k < 21; k++)
						{
							int locationScore = 0;
							int newX = this.oParent.CityOffsets[k].X + i;
							int newY = this.oParent.CityOffsets[k].Y + j;

							terrainType = this.Map.GetTerrainType(newX, newY);

							if (terrainType == TerrainTypeEnum.Grassland || terrainType == TerrainTypeEnum.River)
							{
								if ((((7 * newX) + (11 * newY)) & 0x2) == 0)
								{
									locationScore += 2;
								}
							}

							if (this.Map.F0_2aea_1836_CellHasSpecialResource(newX, newY))
							{
								terrainType += 12;
							}

							locationScore += terrainCoefficients[(int)terrainType];

							if (k < 9)
							{
								locationScore += locationScore;
							}

							if (k == 0)
							{
								locationScore += locationScore;
							}

							totalLocationScore += locationScore;
						}

						terrainType = this.Map.GetTerrainType(i, j);

						if (terrainType != TerrainTypeEnum.Plains)
						{
							if ((((7 * i) + (11 * j)) & 0x2) != 0)
							{
								totalLocationScore -= 16;
							}
						}

						// Instruction address 0x0000:0x1111, size: 5
						totalLocationScore = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((totalLocationScore - 120) / 8, 1, 15) / 2 + 8;

						// !!! Sets build score to both 80,0 & 80,50
						this.Map.SetBuildLocationScore(i, j, totalLocationScore);

						this.oParent.GameData.Continents[this.Map.F0_2aea_1942_GetGroupID(i, j)].BuildSiteCount++;
					}
					else
					{
						// !!! Sets build score to both 80,0 & 80,50
						this.Map.SetBuildLocationScore(i, j, 0);
					}
				}
			}
			#endregion

			#region Stage 8 - Generate polar caps
			for (int i = 0; i < 80; i++)
			{
				this.Map.SetTerrainType(i, 0, TerrainTypeEnum.Arctic);
				this.Map.SetTerrainType(i, 49, TerrainTypeEnum.Arctic);
			}

			for (int i = 0; i < 20; i++)
			{
				this.Map.SetTerrainType(rng.Next(80), 0, TerrainTypeEnum.Tundra);
				this.Map.SetTerrainType(rng.Next(80), 1, TerrainTypeEnum.Tundra);

				// We want to prevent polar caps to join with the continents (especially in earth map)
				int xTemp = rng.Next(80);
				if (this.Map.GetTerrainType(xTemp, 47) == TerrainTypeEnum.Water &&
					this.Map.GetTerrainType(xTemp - 1, 47) == TerrainTypeEnum.Water &&
					this.Map.GetTerrainType(xTemp + 1, 47) == TerrainTypeEnum.Water)
				{
					this.Map.SetTerrainType(xTemp, 48, TerrainTypeEnum.Tundra);
				}

				this.Map.SetTerrainType(rng.Next(80), 49, TerrainTypeEnum.Tundra);
			}
			#endregion

			this.mapFinished = true;

			while (F7_0000_17cf_AdvanceAnimation())
			{
				Thread.Sleep(1);
			}

			this.oParent.Graphics.F0_VGA_040a_FillRectangle(2, new GRectangle(0, 0, 320, 200), 0, 0);

			this.oParent.Var_aa_Screen0_Rectangle.FontID = 1;
		}

		/// <summary>
		/// Constructs the Land path array for old GoTo algorithm (needed for old save format)
		/// </summary>
		public void F7_0000_1188_ConstructLandPath()
		{
			//this.oCPU.Log.EnterBlock("F7_0000_1188()");

			// function body
			int[,] LandPath = this.oParent.UnitGoTo.Arr_db44_LandPath;

			for (int i = 0; i < LandPath.GetLength(0); i++)
			{
				for (int j = 0; j < LandPath.GetLength(1); j++)
				{
					LandPath[i, j] = 0;
				}
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					int x = (i * 4) + 1;
					int y = (j * 4) + 1;
					int groupID = -1;
					int fromX = 0;
					int fromY = 0;

					if (this.Map.GetTerrainType(x, y) != TerrainTypeEnum.Water)
					{
						// Instruction address 0x0000:0x1249, size: 5
						groupID = this.Map.F0_2aea_1942_GetGroupID(x, y);
						fromX = x;
						fromY = y;
					}
					else if (this.Map.GetTerrainType(x + 1, y) != TerrainTypeEnum.Water)
					{
						// Instruction address 0x0000:0x11c3, size: 5
						groupID = this.Map.F0_2aea_1942_GetGroupID(x + 1, y);
						fromX = x + 1;
						fromY = y;
					}
					else if (this.Map.GetTerrainType(x, y + 1) != TerrainTypeEnum.Water)
					{
						// Instruction address 0x0000:0x11ec, size: 5
						groupID = this.Map.F0_2aea_1942_GetGroupID(x, y + 1);
						fromX = x;
						fromY = y + 1;
					}
					else if (this.Map.GetTerrainType(x + 1, y + 1) != TerrainTypeEnum.Water)
					{
						groupID = this.Map.F0_2aea_1942_GetGroupID(x + 1, y + 1);
						fromX = x + 1;
						fromY = y + 1;
					}

					if (groupID != -1)
					{
						for (int k = 1; k < 5; k++)
						{
							GPoint direction = this.oParent.MoveDirections[k];

							int newX = (direction.X * 4) + x;
							int newY = (direction.Y * 4) + y;
							int newGroupID = -1;
							int toX = 0;
							int toY = 0;

							if (this.Map.GetTerrainType(newX, newY) != TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX, newY);
								toX = newX;
								toY = newY;
							}
							else if (this.Map.GetTerrainType(newX + 1, newY) != TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX + 1, newY);
								toX = newX + 1;
								toY = newY;
							}
							else if (this.Map.GetTerrainType(newX, newY + 1) != TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX, newY + 1);
								toX = newX;
								toY = newY + 1;
							}
							else if (this.Map.GetTerrainType(newX + 1, newY + 1) != TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX + 1, newY + 1);
								toX = newX + 1;
								toY = newY + 1;
							}

							if (groupID == newGroupID)
							{
								int distance = this.oParent.UnitGoTo.GetGoToDistance(fromX, fromY, toX, toY, UnitMovementTypeEnum.Land, 20);

								if (distance != -1 && distance < 20)
								{
									LandPath[i, j] |= (0x1 << (k - 1));

									direction = this.oParent.MoveDirections[k];

									newX = i + direction.X;
									newY = j + direction.Y;

									if (newX >= 0 && newX < 20 && newY >= 0 && newY < 13)
									{
										LandPath[newX, newY] |= 0x1 << ((k + 3) & 0x7);
									}
								}
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Constructs the Water path array for old GoTo algorithm
		/// </summary>
		public void F7_0000_1440_ConstructWaterPath()
		{
			//this.oCPU.Log.EnterBlock($"F7_0000_1440()");

			// function body
			int[,] waterPath = this.oParent.UnitGoTo.Arr_7f38_WaterPath;

			for (int i = 0; i < waterPath.GetLength(0); i++)
			{
				for (int j = 0; j < waterPath.GetLength(1); j++)
				{
					waterPath[i, j] = 0;
				}
			}

			for (int local_14 = 0; local_14 < 20; local_14++)
			{
				for (int local_18 = 0; local_18 < 12; local_18++)
				{
					int x = (local_14 * 4) + 1;
					int y = (local_18 * 4) + 1;
					int groupID = -1;

					if (this.Map.GetTerrainType(x, y) == TerrainTypeEnum.Water)
					{
						groupID = this.Map.F0_2aea_1942_GetGroupID(x, y);
					}
					else if (this.Map.GetTerrainType(x + 1, y) == TerrainTypeEnum.Water)
					{
						groupID = this.Map.F0_2aea_1942_GetGroupID(x + 1, y);
					}
					else if (this.Map.GetTerrainType(x, y + 1) == TerrainTypeEnum.Water)
					{
						groupID = this.Map.F0_2aea_1942_GetGroupID(x, y + 1);
					}
					else if (this.Map.GetTerrainType(x + 1, y + 1) == TerrainTypeEnum.Water)
					{
						groupID = this.Map.F0_2aea_1942_GetGroupID(x + 1, y + 1);
					}

					if (groupID != -1)
					{
						for (int local_a = 1; local_a < 9; local_a++)
						{
							GPoint direction = this.oParent.MoveDirections[local_a];
							int newX = x + (direction.X * 4);
							int newY = y + (direction.Y * 4);
							int newGroupID = -1;

							if (this.Map.GetTerrainType(newX, newY) == TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX, newY);
							}
							else if (this.Map.GetTerrainType(newX + 1, newY) == TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX + 1, newY);
							}
							else if (this.Map.GetTerrainType(newX, newY + 1) == TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX, newY + 1);
							}
							else if (this.Map.GetTerrainType(newX + 1, newY + 1) == TerrainTypeEnum.Water)
							{
								newGroupID = this.Map.F0_2aea_1942_GetGroupID(newX + 1, newY + 1);
							}

							if (groupID == newGroupID)
							{
								newX = x;
								newY = y;
								int local_6 = 0;

								for (int local_12 = 0; local_12 < 5; local_12++)
								{
									direction = this.oParent.MoveDirections[local_a];
									newX += direction.X;
									newY += direction.Y;

									local_6 = 4;

									if (!this.Map.F0_2aea_1326_ValidateMapCoordinates(newX, newY) ||
										this.Map.GetTerrainType(newX, newY) != TerrainTypeEnum.Water)
									{
										local_6--;
									}

									if (!this.Map.F0_2aea_1326_ValidateMapCoordinates(newX + 1, newY) ||
										this.Map.GetTerrainType(newX + 1, newY) != TerrainTypeEnum.Water)
									{
										local_6--;
									}

									if (!this.Map.F0_2aea_1326_ValidateMapCoordinates(newX, newY + 1) ||
										this.Map.GetTerrainType(newX, newY + 1) != TerrainTypeEnum.Water)
									{
										local_6--;
									}

									if (!this.Map.F0_2aea_1326_ValidateMapCoordinates(newX + 1, newY + 1) ||
										this.Map.GetTerrainType(newX + 1, newY + 1) != TerrainTypeEnum.Water)
									{
										local_6--;
									}

									if (local_6 < 2)
									{
										break;
									}
								}

								if (local_6 > 1 || (local_18 == 11 && local_a == 3))
								{
									direction = this.oParent.MoveDirections[local_a];

									int local_1a = local_18 + direction.Y;

									if (local_1a < 12)
									{
										waterPath[local_14, local_18] |= 0x1 << (local_a - 1);

										newX = local_14 + direction.X;
										newY = local_1a;

										if (newX >= 0 && newX < 20 && local_1a >= 0 && local_1a < 13)
										{
											waterPath[newX, local_1a] |= 0x1 << ((local_a + 3) & 0x7);
										}
									}
								}
							}
						}
					}
				}
			}

			for (int i = 0; i < 12; i++)
			{
				waterPath[0, i] |= 0xe0;
				waterPath[19, i] |= 0xe;
			}

			waterPath[0, 0] &= 0x7f;
			waterPath[0, 11] &= 0xdf;
			waterPath[19, 0] &= 0xfd;
			waterPath[19, 11] &= 0xf7;
		}

		/// <summary>
		/// Advances the story animation
		/// </summary>
		public bool F7_0000_17cf_AdvanceAnimation()
		{
			//this.oCPU.Log.EnterBlock("F7_0000_17cf()");

			// function body
			this.oCPU.DoEvents();

			// Instruction address 0x0000:0x17e4, size: 5
			if (this.animationStage >= 2 && this.oParent.CAPI.kbhit() == 0)
			{
				return false;
			}
			else
			{
				if (this.animationStage == 0)
				{
					// Instruction address 0x0000:0x1869, size: 5
					this.storyFile = new StreamReader($"{this.oParent.ResourcePath}story.txt");

					this.animationStage = 1;
					this.storyText = "";
					this.storyTimeIndex = 0;
					this.storyStartTime = DateTime.Now;
					this.storyNextEvent = this.storyStartTime + this.storyEvents[this.storyTimeIndex];

					this.oParent.Var_aa_Screen0_Rectangle.FontID = 7;
				}

				if (DateTime.Now < this.storyNextEvent)
				{
					return true;
				}
				else
				{
					if (this.animationStage != 2 && this.storyTimeIndex < 40)
					{
						// Instruction address 0x0000:0x18df, size: 5
						this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(this.storyText, 160, 160, 3);

						// Instruction address 0x0000:0x18eb, size: 5
						this.oParent.CommonTools.F0_1182_0134_WaitTimer(5);
					}

					if (this.storyFile != null)
					{
						string? temp = this.storyFile.ReadLine();

						if (temp != null)
						{
							this.storyText = temp;
						}
						else
						{
							this.storyText = "";
						}
					}

					if (this.storyFile != null && !this.storyFile.EndOfStream && this.oParent.CAPI.kbhit() == 0)
					{
						if (this.buildImageIndex > 1)
						{
							// Instruction address 0x0000:0x194a, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Screen2_Rectangle, 0, 160, 320, 8, this.oParent.Var_aa_Screen0_Rectangle, 0, 160);
						}

						// Instruction address 0x0000:0x1956, size: 5
						this.oParent.CommonTools.F0_1182_0134_WaitTimer(10);

						// Instruction address 0x0000:0x196b, size: 5
						this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(this.storyText, 160, 160, 3);

						// Instruction address 0x0000:0x1977, size: 5
						this.oParent.CommonTools.F0_1182_0134_WaitTimer(5);

						// Instruction address 0x0000:0x198c, size: 5
						this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(this.storyText, 160, 160, 11);

						// Instruction address 0x0000:0x199e, size: 5
						if (this.storyText.Length > 3)
						{
							if (this.storyTimeIndex == 0)
							{
								// Instruction address 0x0000:0x19b2, size: 5
								this.oParent.CommonTools.F0_1000_033e_ResetWaitTimer();

								// Instruction address 0x0000:0x19bb, size: 5
								this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

								// Instruction address 0x0000:0x19c7, size: 5
								this.oParent.CommonTools.F0_1000_0a32_PlayTune(4, 0);
							}

							this.storyTimeIndex++;
						}
						else
						{
							if (this.buildImageIndex < 9)
							{
								// Instruction address 0x0000:0x19e3, size: 5
								string imageFileName = $"birth{this.buildImageIndex}.pic";

								for (int i = 1; i <= this.paletteSlotCount; i++)
								{
									// Instruction address 0x0000:0x1a06, size: 5
									this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(i);
								}

								this.paletteSlotCount = 0;

								// Instruction address 0x0000:0x1a21, size: 5 
								this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(2, 0, 0, imageFileName, 0);

								// Instruction address 0x0000:0x1a39, size: 5
								this.oParent.CommonTools.F0_1000_04d4_TransformPaletteToColor(8, Color.FromRgb(0, 0, 0));

								// Instruction address 0x0000:0x1a59, size: 5
								this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Screen2_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Screen0_Rectangle, 0, 0);

								// Instruction address 0x0000:0x1a73, size: 5
								imageFileName = imageFileName.Replace(".pic", ".pal");

								byte[] palette;
								// Instruction address 0x0000:0x1a83, size: 5
								this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, imageFileName, out palette);

								// Instruction address 0x0000:0x1a93, size: 5
								this.oParent.CommonTools.F0_1000_04aa_TransformPalette(8, palette);

								PaletteCycleInfo[] paletteslots = this.storyImagePaletteCycles[this.buildImageIndex - 1];

								this.paletteSlotCount = paletteslots.Length;

								for (int i = 0; i < paletteslots.Length; i++)
								{
									PaletteCycleInfo paletteSlot = paletteslots[i];

									this.oParent.CommonTools.F0_1000_0382_AddPaletteCycleSlot(i + 1, paletteSlot.Speed, (byte)paletteSlot.FromIndex, (byte)paletteSlot.ToIndex);
								}

								for (int i = 1; i <= this.paletteSlotCount; i++)
								{
									// Instruction address 0x0000:0x1b16, size: 5
									this.oParent.CommonTools.F0_1000_03fa_StartPaletteCycleSlot(i);
								}

								this.buildImageIndex++;
							}
						}

						this.storyNextEvent = this.storyStartTime + this.storyEvents[this.storyTimeIndex];
					}
					else
					{
						if (this.storyFile != null)
						{
							if (this.storyFile.EndOfStream)
							{
								// Instruction address 0x0000:0x1b74, size: 5
								this.oParent.CommonTools.F0_1182_0134_WaitTimer(180);
							}

							this.storyFile.Close();
							this.storyFile = null;
						}

						// Instruction address 0x0000:0x1b8c, size: 5
						this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

						for (int i = 1; i <= this.paletteSlotCount; i++)
						{
							// Instruction address 0x0000:0x1ba5, size: 5
							this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(i);
						}
						this.paletteSlotCount = 0;

						this.animationStage = 2;
					}

					if (this.animationStage != 2)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
		}
	}
}
