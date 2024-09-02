using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System.IO.Compression;
using System.Xml.Serialization;

namespace OpenCiv1
{
	[Serializable]
	public class Map
	{
		public static readonly GSize MinimumMapSize = new GSize(40, 25); // some sensible minimum values

		private OpenCiv1Game? oParent = null;
		private GameData? oGameData = null;

		private int iSeed;
		private GSize oSize;
		private int iAge = 1; // [0-2]
		private int iLandMass = 1; // [0-2]
		private int iTemperature = 1; // [0-2]
		private int iClimate = 1; // [0-2]
		private int iXMedian;
		private int iYMedian;
		private MapCellCollection oCells;
		private List<MapGroup> aGroups = new List<MapGroup>();

		/// <summary>
		/// Used exclusively for deserialization
		/// </summary>
		public Map()
		{
			this.iSeed = Environment.TickCount; // Used to generate special resource cells and polar caps
			this.oSize = new GSize(2, 2);
			this.iXMedian = this.oSize.Width / 2;
			this.iYMedian = this.oSize.Height / 2;
			this.oCells = new MapCellCollection(this);
		}

		public Map(OpenCiv1Game parent, int width, int height) : this(parent, new GSize(width, height))
		{ }

		public Map(OpenCiv1Game parent, int width, int height, int seed) : this(parent, new GSize(width, height), seed)
		{ }

		public Map(OpenCiv1Game parent, GSize size) : this(parent, size, Environment.TickCount)
		{ }

		public Map(OpenCiv1Game parent, GSize size, int seed)
		{
			// sanity check
			if (size.Width < 0 || size.Width < MinimumMapSize.Width)
			{
				throw new ArgumentOutOfRangeException("Width");
			}
			if (size.Height < 0 || size.Height < MinimumMapSize.Height)
			{
				throw new ArgumentOutOfRangeException("Height");
			}

			this.oParent = parent;
			this.oGameData = parent.GameData;

			this.iSeed = seed;
			this.oSize = size;
			this.iXMedian = this.oSize.Width / 2;
			this.iYMedian = this.oSize.Height / 2;
			this.oCells = new MapCellCollection(this);

			RandomMT19937 rng = new RandomMT19937(this.iSeed);
			GenerateNewMap(rng);
			GenerateCommonMapData(rng);

			// Debugging - Create Log file
			/*StreamWriter writer = new StreamWriter("Map1.log");
			// Output terrain
			for (int i = 0; i < this.oSize.Height; i++)
			{
				writer.Write("[");
				for (int j = 0; j < this.oSize.Width; j++)
				{
					if (j > 0)
						writer.Write(", ");

					writer.Write(this.Cells[j, i].Layer1_Terrain);
				}
				writer.WriteLine("]");
			}

			writer.WriteLine();
			writer.WriteLine("--- Groups ---");

			// Output Group IDs
			for (int i = 0; i < this.oSize.Height; i++)
			{
				writer.Write("[");
				for (int j = 0; j < this.oSize.Width; j++)
				{
					if (j > 0)
						writer.Write(", ");

					writer.Write(this.Cells[j, i].Layer3_GroupID);
				}
				writer.WriteLine("]");
			}

			// Output Groups
			writer.Write("[");
			for (int i = 0; i < this.aGroups.Count; i++)
			{
				if (i > 0)
					writer.Write(", ");

				MapGroup group = this.aGroups[i];

				writer.Write($"({group.ID}, {group.GroupType}, {group.Size}, {group.BuildSiteCount})");
			}
			writer.WriteLine("]");

			writer.WriteLine();
			writer.WriteLine("--- Build sites ---");

			// Output Group IDs
			for (int i = 0; i < this.oSize.Height; i++)
			{
				writer.Write("[");
				for (int j = 0; j < this.oSize.Width; j++)
				{
					if (j > 0)
						writer.Write(", ");

					writer.Write(this.Cells[j, i].Layer4_BuildSites);
				}
				writer.WriteLine("]");
			}

			writer.WriteLine();
			writer.WriteLine("--- Special resources ---");

			// Output Group IDs
			for (int i = 0; i < this.oSize.Height; i++)
			{
				writer.Write("[");
				for (int j = 0; j < this.oSize.Width; j++)
				{
					if (j > 0)
						writer.Write(", ");

					writer.Write(this.Cells[j, i].HasSpecialResource ? 1 : 0);
				}
				writer.WriteLine("]");
			}

			int iSpecialResourceCount = 0;

			for (int i = 2; i < this.oSize.Width - 2; i++)
			{
				for (int j = 2; j < this.oSize.Height - 2; j++)
				{
					if (this.Cells[i, j].HasSpecialResource)
						iSpecialResourceCount++;
				}
			}
			writer.WriteLine($"Special Resource count: {iSpecialResourceCount}");

			writer.Close();//*/
		}

		public Map(OpenCiv1Game parent, GBitmap bitmap) : this(parent, bitmap, Environment.TickCount)
		{ }

		/// <summary>
		/// Generates a new Map from GBitmap pixel data.
		/// Pixel values are limited to the following: 
		/// (1 = TerrainTypeEnum.Water, 2 = TerrainTypeEnum.Forest, 3 = TerrainTypeEnum.Swamp, 6 = TerrainTypeEnum.Plains, 
		/// 7 = TerrainTypeEnum.Tundra, 9 = TerrainTypeEnum.River, 10 = TerrainTypeEnum.Grassland, 11 = TerrainTypeEnum.Jungle,
		/// 12 = TerrainTypeEnum.Hills, 13 = TerrainTypeEnum.Mountains, 14 = TerrainTypeEnum.Desert, 15 = TerrainTypeEnum.Arctic)
		/// </summary>
		/// <param name="bitmap"></param>
		/// <param name="seed"></param>
		public Map(OpenCiv1Game parent, GBitmap bitmap, int seed)
		{
			// sanity check
			if (bitmap.Size.Width < 0 || bitmap.Size.Width < MinimumMapSize.Width)
			{
				throw new ArgumentOutOfRangeException("Width");
			}
			if (bitmap.Size.Height < 0 || bitmap.Size.Height < MinimumMapSize.Height)
			{
				throw new ArgumentOutOfRangeException("Height");
			}

			this.oParent = parent;
			this.oGameData = parent.GameData;

			this.iSeed = seed;
			this.oSize = bitmap.Size;
			this.iXMedian = this.oSize.Width / 2;
			this.iYMedian = this.oSize.Height / 2;
			this.oCells = new MapCellCollection(this);

			RandomMT19937 rng = new RandomMT19937(this.iSeed);

			for (int i = 0; i < this.oSize.Height; i++)
			{
				for (int j = 0; j < this.oSize.Width; j++)
				{
					/*switch (bitmap.GetPixel(j, i))
					{
						case 0:
						case 4:
						case 5:
						case 8:
							return TerrainTypeEnum.Undefined;

						case 1:
							return TerrainTypeEnum.Water;

						case 2:
							return TerrainTypeEnum.Forest;

						case 3:
							return TerrainTypeEnum.Swamp;

						case 6:
							return TerrainTypeEnum.Plains;

						case 7:
							return TerrainTypeEnum.Tundra;

						case 9:
							return TerrainTypeEnum.River;

						case 10:
							return TerrainTypeEnum.Grassland;

						case 11:
							return TerrainTypeEnum.Jungle;

						case 12:
							return TerrainTypeEnum.Hills;

						case 13:
							return TerrainTypeEnum.Mountains;

						case 14:
							return TerrainTypeEnum.Desert;

						case 15:
							return TerrainTypeEnum.Arctic;
					}*/

					this[j, i].Layer1_Terrain = bitmap.GetPixel(j, i);
				}
			}

			GenerateCommonMapData(rng);
		}

		/// <summary>
		/// Generates entire new map based on given parameters
		/// This function blocks the current thread untill map generation is complete
		/// </summary>
		private void GenerateNewMap(RandomMT19937 rng)
		{
			if (this.oGameData != null)
			{
				int iTotalMapCellCount = this.oSize.Height * this.oSize.Width;

				// Points of improvement:
				// 1) Variable size (implemented)
				// 1) Randomize cells that have special resources (implemented)
				// 2) Continent land generation should continue around the map width (implemented)
				// 3) Improve and check map generation regarding it's mass, temperature, climate and age

				#region Initialize new map with empty cells
				this.Cells.Clear();

				for (int i = 0; i < this.oSize.Height; i++)
				{
					for (int j = 0; j < this.oSize.Width; j++)
					{
						this.Cells[j, i] = new MapCell(j, i);
					}
				}
				#endregion

				#region Stage 1 - Render Map by it's mass and create continents
				int iTotalContinentCellCount = 0;
				int iLandCellCount = (int)((iTotalMapCellCount / 6.25) + ((double)this.iLandMass * (iTotalMapCellCount / 12.5)));

				while (iTotalContinentCellCount < iLandCellCount)
				{
					int iContinentCellCount = 0;
					bool[,] aLand = new bool[this.oSize.Height, this.oSize.Width];
					int iLandXPos = rng.Next(this.oSize.Width);
					int iLandYPos = 8 + rng.Next(this.oSize.Height - 16);
					int iTergetCellCount = rng.Next(64) + 1;

					for (int i = 0; i < iTergetCellCount; i++)
					{
						// triangle shaped cloud (Default)
						aLand[iLandYPos, iLandXPos] = true;
						aLand[iLandYPos, WrapXPosition(iLandXPos + 1)] = true;
						aLand[iLandYPos + 1, iLandXPos] = true;

						switch (rng.Next(4))
						{
							case 1:
								iLandXPos++;
								break;

							case 3:
								iLandXPos--;
								break;

							case 2:
								iLandYPos++;
								break;

							case 0:
								iLandYPos--;
								break;
						}

						// wrap around the X position
						iLandXPos = WrapXPosition(iLandXPos);

						// iLandXPos <= 2 || iLandXPos >= (this.oSize.Width - 3)
						if (iLandYPos < 4 || iLandYPos > (this.oSize.Height - 6))
							break;
					}

					for (int i = 0; i < this.oSize.Height; i++)
					{
						for (int j = 0; j < this.oSize.Width; j++)
						{
							if (aLand[i, j])
							{
								MapCell cell = this.Cells[j, i];

								switch (cell.Layer1_Terrain)
								{
									// Convert Water to Plains
									case 1:
										cell.Layer1_Terrain = 6; // TerrainTypeEnum.Plains
										break;

									// Convert Plains to Hills
									case 6:
										cell.Layer1_Terrain = 12; // TerrainTypeEnum.Hills
										break;

									// Convert Hills to Mountains
									case 12:
										cell.Layer1_Terrain = 13; // TerrainTypeEnum.Mountains
										break;
								}

								iContinentCellCount++;
							}
						}
					}

					iTotalContinentCellCount += iContinentCellCount;
				}

				// Clear cells surrounding the map, and set them to TerrainTypeEnum.Ocean
				/*for (int i = 0; i < this.oSize.Height; i++)
				{
					this.Cells[0, i].Layer1_Terrain = 1;
					this.Cells[1, i].Layer1_Terrain = 1;
					this.Cells[this.oSize.Width - 1, i].Layer1_Terrain = 1;
					this.Cells[this.oSize.Width - 2, i].Layer1_Terrain = 1;
				}*/
				for (int i = 0; i < this.oSize.Width; i++)
				{
					this.Cells[i, 0].Layer1_Terrain = 1;
					this.Cells[i, 1].Layer1_Terrain = 1;
					this.Cells[i, this.oSize.Height - 1].Layer1_Terrain = 1;
					this.Cells[i, this.oSize.Height - 2].Layer1_Terrain = 1;
				}

				// Correct Land Plains, Hills and Mountains
				for (int i = 1; i < this.oSize.Height - 1; i++)
				{
					for (int j = 1; j < this.oSize.Width - 1; j++)
					{
						int edges = 0;

						if (this.Cells[j, i].Layer1_Terrain != 1)
						{
							edges |= 0x1;
						}
						if (this.Cells[j + 1, i].Layer1_Terrain != 1)
						{
							edges |= 0x2;
						}
						if (this.Cells[j, i + 1].Layer1_Terrain != 1)
						{
							edges |= 0x4;
						}
						if (this.Cells[j + 1, i + 1].Layer1_Terrain != 1)
						{
							edges |= 0x8;
						}

						if (edges == 6 || edges == 9)
						{
							this.Cells[j + 1, i].Layer1_Terrain = 6; // TerrainTypeEnum.Plains
							this.Cells[j, i + 1].Layer1_Terrain = 6; // TerrainTypeEnum.Plains
							this.Cells[j + 1, i + 1].Layer1_Terrain = 6; // TerrainTypeEnum.Plains

							if (i > 0)
							{
								i--;
							}

							if (j > 0)
							{
								j--;
							}
						}
					}
				}
				#endregion

				#region Stage 2 - Adjust Map by Temperature
				int yMedian = (this.oSize.Height + (iTotalMapCellCount / 500)) / 2;

				for (int i = 0; i < this.oSize.Width; i++)
				{
					for (int j = 0; j < this.oSize.Height; j++)
					{
						MapCell cell = this.Cells[i, j];

						if (cell.Layer1_Terrain == 6)
						{
							int local_4 = Math.Abs(rng.Next(8) + j - yMedian) + (1 - this.iTemperature);

							if (((local_4 / 6) + 1) < 8)
							{
								switch ((local_4 / 6) + 1)
								{
									case 2:
									case 3:
										cell.Layer1_Terrain = 6;
										break;

									case 4:
									case 5:
										cell.Layer1_Terrain = 7;
										break;

									case 0:
									case 1:
										cell.Layer1_Terrain = 14;
										break;

									case 6:
									case 7:
										cell.Layer1_Terrain = 15;
										break;
								}
							}
						}
					}
				}
				#endregion

				#region Stage 3 - Adjust Map by Climate
				for (int i = 0; i < this.oSize.Height; i++)
				{
					int threshold = Math.Abs(this.iYMedian - i);
					iTotalContinentCellCount = 0;

					for (int j = 0; j < this.oSize.Width; j++)
					{
						MapCell cell = this.Cells[j, i];

						if (cell.Layer1_Terrain != 1)
						{
							if (iTotalContinentCellCount > 0)
							{
								iTotalContinentCellCount -= rng.Next(7 - (this.iClimate * 2));

								switch (cell.Layer1_Terrain)
								{
									case 6:
										cell.Layer1_Terrain = 10;
										break;

									case 7:
										cell.Layer1_Terrain = 15;
										break;

									case 12:
										cell.Layer1_Terrain = 2;
										break;

									case 13:
										iTotalContinentCellCount -= 3;
										break;

									case 14:
										cell.Layer1_Terrain = 6;
										break;
								}
							}
						}
						else if (Math.Abs((this.iYMedian / 2) - threshold) + (this.iClimate * 4) > iTotalContinentCellCount)
						{
							iTotalContinentCellCount++;
						}
					}

					iTotalContinentCellCount = 0;

					for (int j = this.oSize.Width - 1; j >= 0; j--)
					{
						MapCell cell = this.Cells[j, i];

						if (cell.Layer1_Terrain == 1)
						{
							if (((threshold / 2) + this.iClimate) > iTotalContinentCellCount)
							{
								iTotalContinentCellCount++;
							}
						}
						else
						{
							if (iTotalContinentCellCount > 0)
							{
								iTotalContinentCellCount -= rng.Next(7 - (this.iClimate * 2));

								switch (cell.Layer1_Terrain)
								{
									case 3:
									case 12:
										cell.Layer1_Terrain = 2;
										break;

									case 6:
										cell.Layer1_Terrain = 10;
										break;

									case 10:
										if (threshold < 10)
										{
											cell.Layer1_Terrain = 11;
										}
										else
										{
											cell.Layer1_Terrain = 3;
										}

										iTotalContinentCellCount = -2;
										break;

									case 13:
										iTotalContinentCellCount -= 3;
										cell.Layer1_Terrain = 2;
										break;

									case 14:
										cell.Layer1_Terrain = 6;
										break;
								}
							}
						}
					}
				}
				#endregion

				#region Stage 4 - Adjust Map by Age
				int xPos = 0;
				int yPos = 0;
				iTotalContinentCellCount = (iTotalMapCellCount / 5) + ((iTotalMapCellCount / 5) * this.iAge);

				for (int i = 0; i < iTotalContinentCellCount; i++)
				{
					if ((i & 0x1) != 0)
					{
						GPoint direction = this.oGameData.Static.MoveOffsets[rng.Next(8) + 1];

						xPos += direction.X;
						yPos += direction.Y;
					}
					else
					{
						xPos = rng.Next(this.oSize.Width);
						yPos = rng.Next(this.oSize.Height);
					}

					if (xPos >= 0 && xPos < this.oSize.Width && yPos >= 0 && yPos < this.oSize.Height)
					{
						MapCell map = this.Cells[xPos, yPos];

						switch (map.Layer1_Terrain)
						{
							case 2:
								map.Layer1_Terrain = 11;
								break;

							case 3:
								map.Layer1_Terrain = 10;
								break;

							case 4:
							case 5:
							case 8:
							case 9:
								break;

							case 6:
							case 7:
								map.Layer1_Terrain = 12;
								break;

							case 10:
								map.Layer1_Terrain = 2;
								break;

							case 11:
								map.Layer1_Terrain = 3;
								break;

							case 12:
							case 15:
								map.Layer1_Terrain = 13;
								break;

							case 13:
								if (this.Cells[xPos - 1, yPos - 1].Layer1_Terrain != 1 && this.Cells[xPos - 1, yPos + 1].Layer1_Terrain != 1 &&
									this.Cells[xPos + 1, yPos - 1].Layer1_Terrain != 1 && this.Cells[xPos + 1, yPos + 1].Layer1_Terrain != 1)
								{
									map.Layer1_Terrain = 1;
								}
								break;

							case 14:
								map.Layer1_Terrain = 6;
								break;
						}
					}
				}
				#endregion

				#region Stage 5 - Render rivers
				int iMax = ((this.iLandMass + this.iClimate) * 2) + 6;
				int[,] aMapCopy = new int[this.oSize.Width, this.oSize.Height];

				for (int i = 0, j = 0; i < 256 && j < iMax; i++)
				{
					int local_16 = 0;

					// make a copy of the map
					for (int y = 0; y < this.oSize.Height; y++)
					{
						for (int x = 0; x < this.oSize.Width; x++)
						{
							aMapCopy[x, y] = this.Cells[x, y].Layer1_Terrain;
						}
					}

					do
					{
						xPos = rng.Next(80);
						yPos = rng.Next(50);
					}
					while (this.Cells[xPos, yPos].Layer1_Terrain != 12);

					int xPos1 = xPos;
					int yPos1 = yPos;
					int local_18 = rng.Next(4) * 2;
					int local_2;
					int local_4 = 0;

					do
					{
						this.Cells[xPos, yPos].Layer1_Terrain = 9;

						for (int k = 1; k < 9; k += 2)
						{
							GPoint direction1 = this.oGameData.Static.MoveOffsets[k];

							if (this.Cells[xPos + direction1.X, yPos + direction1.Y].Layer1_Terrain == 1)
							{
								local_4 = 1;
								break;
							}
						}

						int local_10 = local_18;
						local_18 = ((rng.Next(2) - (local_16 & 0x1)) * 2 + local_18) & 0x7;

						if ((local_10 ^ 0x4) > local_18)
						{
							// Instruction address 0x0000:0x077c, size: 5
							this.Cells[xPos, yPos].Layer7_TerrainImprovements2 = 8;
						}


						GPoint direction = this.oGameData.Static.MoveOffsets[local_18 + 1];

						xPos += direction.X;
						yPos += direction.Y;

						local_2 = this.Cells[xPos, yPos].Layer1_Terrain;
						local_16++;
					}
					while (local_4 == 0 && local_2 != 1 && local_2 != 9 && local_2 != 13);

					if ((local_4 == 0 && local_2 != 9) || local_16 < 5)
					{
						// restore map copy
						for (int y = 0; y < this.oSize.Height; y++)
						{
							for (int x = 0; x < this.oSize.Width; x++)
							{
								this.Cells[x, y].Layer1_Terrain = aMapCopy[x, y];
							}
						}
					}
					else
					{
						j++;

						for (int k = 1; k < 22; k++)
						{
							GPoint direction = this.oGameData.Static.MoveOffsets[k];

							xPos = xPos1 + direction.X;
							yPos = yPos1 + direction.Y;

							if (this.Cells[xPos, yPos].Layer1_Terrain == 2)
							{
								this.Cells[xPos, yPos].Layer1_Terrain = 11;
							}
						}
					}
				}
				#endregion
			}
		}

		// Generates Map common data
		private void GenerateCommonMapData(RandomMT19937 rng)
		{
			if (this.oGameData != null)
			{
				int iTotalMapCellCount = this.oSize.Height * this.oSize.Width;

				#region Stage 6 - Render polar caps
				for (int i = 0; i < this.oSize.Width; i++)
				{
					this.Cells[i, 0].Layer1_Terrain = 15;
					this.Cells[i, this.oSize.Height - 1].Layer1_Terrain = 15;
				}

				for (int i = 0; i < iTotalMapCellCount / 200; i++)
				{
					this.Cells[rng.Next(this.oSize.Width), 0].Layer1_Terrain = 7;
					this.Cells[rng.Next(this.oSize.Width), 1].Layer1_Terrain = 7;
					this.Cells[rng.Next(this.oSize.Width), this.oSize.Height - 2].Layer1_Terrain = 7;
					this.Cells[rng.Next(this.oSize.Width), this.oSize.Height - 1].Layer1_Terrain = 7;
				}
				#endregion

				#region Stage 6a - Render Special Resources
				for (int i = 0; i < iTotalMapCellCount / 18; i++)
				{
					int xPos = rng.Next(this.oSize.Width);
					int yPos = 4 + rng.Next(this.oSize.Height - 8);

					this.Cells[xPos, yPos].HasSpecialResource = true;
				}
				#endregion

				#region Stage 7 - Determine Map groups (Sea, Land and Polar caps)
				ReGenerateMapGroups();
				#endregion

				#region Stage 8 - Determine land cell worth for city build sites
				int[] terrainTypeCoefficient = new int[24];

				// Precalculate Terrain Type coefficients
				for (int i = 0; i < 24; i++)
				{
					int terrainIndex = i % 12;

					terrainTypeCoefficient[i] = (3 * this.oGameData.Static.Terrains[i].Food) + this.oGameData.Static.Terrains[i].Trade;

					if (terrainIndex != (int)TerrainTypeEnum.Grassland && terrainIndex != (int)TerrainTypeEnum.River)
					{
						terrainTypeCoefficient[i] += this.oGameData.Static.Terrains[i].Production * 2;
					}

					if (this.oGameData.Static.TerrainMultipliers[terrainIndex].Multi3 < 0)
					{
						terrainTypeCoefficient[i] += -1 - this.oGameData.Static.TerrainMultipliers[terrainIndex].Multi3;
					}
					else
					{
						if (this.oGameData.Static.TerrainMultipliers[terrainIndex].Multi1 < 0)
						{
							terrainTypeCoefficient[i] += (-1 - this.oGameData.Static.TerrainMultipliers[terrainIndex].Multi1) * 2;
						}
					}
				}

				// Calculate cell worth based on it's surrounding Terrain Types
				for (int i = 2; i < this.oSize.Height - 2; i++)
				{
					for (int j = 0; j < this.oSize.Width; j++)
					{
						TerrainTypeEnum terrainType = this.Cells[j, i].TerrainType;

						if (terrainType == TerrainTypeEnum.River || terrainType == TerrainTypeEnum.Grassland || terrainType == TerrainTypeEnum.Plains)
						{
							int totalCellWorth = 0;

							for (int k = 0; k < 21; k++)
							{
								int cellWorth = 0;
								int xPos = this.oGameData.Static.CityOffsets[k].X + j;
								int yPos = this.oGameData.Static.CityOffsets[k].Y + i;

								terrainType = this.Cells[xPos, yPos].TerrainType;

								if ((terrainType == TerrainTypeEnum.Grassland || terrainType == TerrainTypeEnum.River) && (((xPos * 7) + (yPos * 11)) & 0x2) == 0)
								{
									cellWorth += 2;
								}

								if (!this.Cells[xPos, yPos].HasSpecialResource)
								{
									cellWorth += terrainTypeCoefficient[(int)terrainType];
								}
								else
								{
									cellWorth += terrainTypeCoefficient[(int)terrainType + 12];
								}

								if (k < 9)
								{
									cellWorth += cellWorth;
								}

								if (k == 0)
								{
									cellWorth += cellWorth;
								}

								totalCellWorth += cellWorth;
							}

							terrainType = this.Cells[j, i].TerrainType;

							if (terrainType != TerrainTypeEnum.Plains && (((j * 7) + (i * 11)) & 0x2) != 0)
							{
								totalCellWorth -= 16;
							}

							totalCellWorth = (Math.Min(Math.Max((totalCellWorth - 120) / 8, 1), 15) / 2) + 8; // result is between [8 - 15]

							this.Cells[j, i].Layer2_PlayerOwnership = totalCellWorth; // do we care for layer2 (layer2 is used for player map cell ownership)?
							this.Cells[j, i].Layer4_BuildSites = totalCellWorth;

							this.aGroups[this.Cells[j, i].Layer3_GroupID].BuildSiteCount++;
						}
					}
				}
				#endregion
			}
		}

		public void ReGenerateMapGroups()
		{
			this.aGroups.Clear();

			for (int i = 0; i < this.oSize.Width; i++)
			{
				for (int j = 0; j < this.oSize.Height; j++)
				{
					FloodFillGroup(i, j);
				}
			}
		}

		/// <summary>
		/// We will use Flood Fill algorithm to determine Map Groups
		/// </summary>
		/// <param name="x">The starting X position of the new Group</param>
		/// <param name="y">The starting Y position of the new Group</param>
		/// <returns>The group ID of the specified cell</returns>
		private int FloodFillGroup(int x, int y)
		{
			int iGroupID = this.Cells[x, y].Layer3_GroupID;

			if (iGroupID == -1)
			{
				iGroupID = this.aGroups.Count; // this will be our new group ID
				int iCellCount = 0;
				Queue<GPoint> queue = new Queue<GPoint>();
				MapGroupTypeEnum groupType = this.Cells[x, y].GroupType; // Get the cell Group type

				// Detect polar caps. The polar caps start with one or two cells at the TopLeft and BottomLeft of the Map
				if (groupType == MapGroupTypeEnum.Land && x == 0 && (y == 0 || y == 1 || y == this.oSize.Height - 2 || y == this.oSize.Height - 1))
				{
					groupType = MapGroupTypeEnum.PolarCap;
				}

				MapGroup group = new MapGroup(iGroupID, groupType);

				this.Cells[x, y].Layer3_GroupID = iGroupID; // Set the starting cell to our GroupID
				iCellCount++; // Increment the group cell count
				queue.Enqueue(new GPoint(x, y)); // Append the starting position to the queue

				while (queue.Count > 0)
				{
					GPoint position = queue.Dequeue(); // remove the next position from the queue
					MapCell cell;

					// validate neighbouring positions
					if (position.Y - 1 >= 0)
					{
						// North
						if ((cell = this.Cells[position.X, position.Y - 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X, position.Y - 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X, position.Y - 1)); // Append the current position to the queue
						}

						// North - West
						if ((cell = this.Cells[position.X - 1, position.Y - 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X - 1, position.Y - 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X - 1, position.Y - 1)); // Append the current position to the queue
						}

						// North - East
						if ((cell = this.Cells[position.X + 1, position.Y - 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X + 1, position.Y - 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X + 1, position.Y - 1)); // Append the current position to the queue
						}
					}

					// West
					if ((cell = this.Cells[position.X - 1, position.Y]).Layer3_GroupID == -1 && cell.GroupType == groupType)
					{
						this.Cells[position.X - 1, position.Y].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
						iCellCount++; // Increment the group cell count
						queue.Enqueue(new GPoint(position.X - 1, position.Y)); // Append the current position to the queue
					}

					// East
					if ((cell = this.Cells[position.X + 1, position.Y]).Layer3_GroupID == -1 && cell.GroupType == groupType)
					{
						this.Cells[position.X + 1, position.Y].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
						iCellCount++; // Increment the group cell count
						queue.Enqueue(new GPoint(position.X + 1, position.Y)); // Append the current position to the queue
					}

					if (position.Y + 1 < this.oSize.Height)
					{
						// South
						if ((cell = this.Cells[position.X, position.Y + 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X, position.Y + 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X, position.Y + 1)); // Append the current position to the queue
						}

						// South - West
						if ((cell = this.Cells[position.X - 1, position.Y + 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X - 1, position.Y + 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X - 1, position.Y + 1)); // Append the current position to the queue
						}

						// South - East
						if ((cell = this.Cells[position.X + 1, position.Y + 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X + 1, position.Y + 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X + 1, position.Y + 1)); // Append the current position to the queue
						}
					}
				}

				group.Size = iCellCount; // update group cell count
				this.aGroups.Add(group); // add the group to our array
			}

			return iGroupID;
		}

		/// <summary>
		/// This function Wraps the X position around
		/// </summary>
		/// <param name="x">The X coordinate to check</param>
		/// <returns>The corrected X coordinate</returns>
		public int WrapXPosition(int x)
		{
			if (x < 0)
			{
				x = Math.Abs(x) % this.oSize.Width;

				if (x > 0)
				{
					x = this.oSize.Width - x;
				}
			}

			if (x >= this.oSize.Width)
			{
				x %= this.oSize.Width;
			}

			return x;
		}

		/// <summary>
		/// Calculate the shortest map distance (number of moves) between two points in a two dimensional space (Chebyshev distance)
		/// </summary>
		/// <param name="xPos">The position of the start X coordinate</param>
		/// <param name="yPos">The position of the start Y coordinate</param>
		/// <param name="xPos1">The position of the destination X coordinate</param>
		/// <param name="yPos1">The position of the destination Y coordinate</param>
		/// <returns>The shortest distance (number of moves in a two dimensional space)</returns>
		public int GetDistance(int xPos, int yPos, int xPos1, int yPos1)
		{
			return GetDistance(new GPoint(xPos, yPos), new GPoint(xPos1, yPos1));
		}

		/// <summary>
		/// Calculate the shortest map distance (number of moves) between two points in a two dimensional space (Chebyshev distance)
		/// </summary>
		/// <param name="pt1">The position of the start point</param>
		/// <param name="pt2">The position of the destination point</param>
		/// <returns>The shortest distance (number of moves in a two dimensional space)</returns>
		public int GetDistance(GPoint pt1, GPoint pt2)
		{
			return GetDistance(new GSize(pt2 - pt1));
		}

		/// <summary>
		/// Calculate the shortest map distance (number of moves) between two points in a two dimensional space (Chebyshev distance)
		/// </summary>
		/// <param name="width">The width (number of cells between two points in X coordinate)</param>
		/// <param name="height">The width (number of cells between two points in Y coordinate)</param>
		/// <returns>The shortest distance (number of moves in a two dimensional space)</returns>
		public int GetDistance(int width, int height)
		{
			return GetDistance(new GSize(width, height));
		}

		/// <summary>
		/// Calculate the shortest map distance (number of moves) between two points in a two dimensional space (Chebyshev distance)
		/// </summary>
		/// <param name="size">The size (number of cells between two points 2d space)</param>
		/// <returns>The shortest distance (number of moves in a two dimensional space)</returns>
		public int GetDistance(GSize size)
		{
			size = GSize.Abs(size);

			if (size.Width >= this.iXMedian)
			{
				size.Width = this.oSize.Width - size.Width;
			}

			return Math.Max(size.Width, size.Height);
		}

		public static Map FromPIC(OpenCiv1Game parent, string path)
		{
			byte[] palette;
			GBitmap? bitmap = GBitmap.FromPICFile(path, out palette);
			Map map = new Map(parent, 80, 50);

			if (bitmap == null)
			{
				throw new Exception("Can't load bitmap from file");
			}

			for (int j = 0; j < 50; j++)
			{
				for (int i = 0; i < 80; i++)
				{
					MapCell cell = map[i, j];

					cell.Layer1_Terrain = bitmap.GetPixel(i, j);
					cell.Layer2_PlayerOwnership = bitmap.GetPixel(i + 80, j);

					cell.Layer3_GroupID = bitmap.GetPixel(i, j + 50);
					cell.Layer4_BuildSites = bitmap.GetPixel(i + 80, j + 50);

					cell.Layer5_TerrainImprovements1 = bitmap.GetPixel(i, j + 100);
					cell.Layer6_VisibleTerrainImprovements1 = bitmap.GetPixel(i + 80, j + 100);

					cell.Layer7_TerrainImprovements2 = bitmap.GetPixel(i, j + 150);
					cell.Layer8_VisibleTerrainImprovements2 = bitmap.GetPixel(i + 80, j + 150);

					cell.Layer9_ActiveUnits = bitmap.GetPixel(i + 160, j);
					cell.Layer10_MiniMap = bitmap.GetPixel(i + 240, j);
				}
			}

			return map;
		}

		public GBitmap ToBitmap()
		{
			int width = this.oSize.Width;
			int height = this.oSize.Height;
			GBitmap bitmap = new GBitmap(width * 4, height * 4);

			for (int j = 0; j < height; j++)
			{
				for (int i = 0; i < width; i++)
				{
					MapCell cell = this.Cells[i, j];

					bitmap.SetPixel(i, j, (byte)(cell.Layer1_Terrain & 0xff));
					bitmap.SetPixel(i + width, j, (byte)(cell.Layer2_PlayerOwnership & 0xff));

					bitmap.SetPixel(i, j + height, (byte)(cell.Layer3_GroupID & 0xff));
					bitmap.SetPixel(i + width, j + height, (byte)(cell.Layer4_BuildSites & 0xff));

					bitmap.SetPixel(i, j + height * 2, (byte)(cell.Layer5_TerrainImprovements1 & 0xff));
					bitmap.SetPixel(i + width, j + height * 2, (byte)(cell.Layer6_VisibleTerrainImprovements1 & 0xff));

					bitmap.SetPixel(i, j + height * 3, (byte)(cell.Layer7_TerrainImprovements2 & 0xff));
					bitmap.SetPixel(i + width, j + height * 3, (byte)(cell.Layer8_VisibleTerrainImprovements2 & 0xff));

					bitmap.SetPixel(i + width * 2, j, (byte)(cell.Layer9_ActiveUnits & 0xff));
					bitmap.SetPixel(i + width * 3, j, (byte)(cell.Layer10_MiniMap & 0xff));
				}
			}

			return bitmap;
		}

		[XmlIgnore]
		public OpenCiv1Game? Parent
		{
			get => this.oParent;
			set
			{
				if (value != null)
				{
					this.oParent = value;
					this.oGameData = value.GameData;
				}
			}
		}

		public GSize Size
		{
			get => this.oSize;
			set
			{
				if (this.oSize != value)
				{
					// sanity check
					if (value.Width < 0 || value.Width < MinimumMapSize.Width)
					{
						throw new ArgumentOutOfRangeException("Size.Width");
					}
					if (value.Height < 0 || value.Height < MinimumMapSize.Height)
					{
						throw new ArgumentOutOfRangeException("Size.Height");
					}

					this.oSize = value;
					this.iXMedian = this.oSize.Width / 2;
					this.iYMedian = this.oSize.Height / 2;
					this.oCells = new MapCellCollection(this);
				}
			}
		}

		public int Seed
		{
			get => this.iSeed;
			set => this.iSeed = value;
		}

		public int Age
		{
			get => this.iAge;
			set => this.iAge = Math.Max(0, Math.Min(2, value));
		}

		public int LandMass
		{
			get => this.iLandMass;
			set => this.iLandMass = Math.Max(0, Math.Min(2, value));
		}

		public int Temperature
		{
			get => this.iTemperature;
			set => this.iTemperature = Math.Max(0, Math.Min(2, value));
		}

		public int Climate
		{
			get => this.iClimate;
			set => this.iClimate = Math.Max(0, Math.Min(2, value));
		}

		public MapCellCollection Cells
		{
			get => this.oCells;
		}

		public List<MapGroup> Groups
		{
			get => this.aGroups;
		}

		[XmlIgnore]
		public MapCell this[int x, int y]
		{
			get => this.oCells[x, y];
			set => this.oCells[x, y] = value;
		}

		/// <summary>
		/// Deserializes a Map object.
		/// </summary>
		/// <param name="path">A full path to the Map object xml file</param>
		/// <param name="gzipped">If true appends an ".gz" extension to the file path.</param>
		/// <returns>A deserialized Map object.</returns>
		public static Map Deserialize(string path, bool gzipped)
		{
			return Deserialize(path + (gzipped ? ".gz" : ""));
		}

		/// <summary>
		/// Deserializes a Map object.
		/// Assumes file iz gzipped, if the filename ends with .gz
		/// </summary>
		/// <param name="path">A full path to a Map object xml file.</param>
		/// <returns>A deserialized Map object.</returns>
		public static Map Deserialize(string path)
		{
			StreamReader reader;

			if (path.EndsWith(".gz"))
			{
				reader = new StreamReader(new GZipStream(new BufferedStream(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read), 65536), CompressionMode.Decompress));
			}
			else
			{
				reader = new StreamReader(new BufferedStream(new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read), 65536));
			}

			Map newMap = Deserialize(reader);

			reader.Close();

			return newMap;
		}

		/// <summary>
		/// Deserializes a Map object.
		/// </summary>
		/// <param name="reader">A stream to read the Map object from.</param>
		/// <returns>A deserialized Map object.</returns>
		public static Map Deserialize(StreamReader reader)
		{
			XmlSerializer ser = new XmlSerializer(typeof(Map));
			object? obj = ser.Deserialize(reader);

			if (obj == null)
				throw new Exception("Can't deserialize Map object");

			Map newMap = (Map)obj;

			return newMap;
		}

		/// <summary>
		/// Serializes a Map object.
		/// </summary>
		/// <param name="path">A full path to a Map object xml file.</param>
		/// <param name="gzipped">If true appends an ".gz" extension to the file path.</param>
		public void Serialize(string path, bool gzipped)
		{
			Serialize(path + (gzipped ? ".gz" : ""));
		}

		/// <summary>
		/// Serializes a Map object.
		/// Assumes file iz gzipped, if the filename ends with .gz
		/// </summary>
		/// <param name="filePath">A full path to an Map object xml file (can end with .gz).</param>
		public void Serialize(string filePath)
		{
			StreamWriter writer;

			if (filePath.EndsWith(".gz"))
			{
				writer = new StreamWriter(new GZipStream(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read), CompressionMode.Compress));
			}
			else
			{
				writer = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read));
			}

			Serialize(writer);

			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// Serializes a Map object.
		/// </summary>
		/// <param name="writer">A stream to serialize the object to.</param>
		public void Serialize(StreamWriter writer)
		{
			XmlSerializer ser = new XmlSerializer(typeof(Map));
			ser.Serialize(writer, this);
		}
	}
}
