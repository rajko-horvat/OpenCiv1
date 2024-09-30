using HarfBuzzSharp;
using IRB.Collections.Generic;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System.Diagnostics;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static OpenCiv1.AStar1;

namespace OpenCiv1
{
	[Serializable]
	public class TerrainMap
	{
		public static readonly GSize MinimumMapSize = new GSize(40, 25); // some sensible minimum values
		public static readonly GPoint[] MoveOffsets = new GPoint[] {
			new GPoint(0, 0), new GPoint(0, -1), new GPoint(1, -1),
			new GPoint(1, 0), new GPoint(1, 1), new GPoint(0, 1),
			new GPoint(-1, 1), new GPoint(-1, 0), new GPoint(-1, -1),
			new GPoint(0, -2), new GPoint(1, -2), new GPoint(2, -1),
			new GPoint(2, 0), new GPoint(2, 1), new GPoint(1, 2),
			new GPoint(0, 2), new GPoint(-1, 2), new GPoint(-2, 1),
			new GPoint(-2, 0), new GPoint(-2, -1), new GPoint(-1, -2),
			new GPoint(2, 2), new GPoint(2, -2), new GPoint(-2, -2),
			new GPoint(-2, 2), new GPoint(0, -3), new GPoint(1, -3),
			new GPoint(2, -3), new GPoint(3, -2), new GPoint(3, -1),
			new GPoint(3, 0), new GPoint(3, 1), new GPoint(3, 2),
			new GPoint(2, 3), new GPoint(1, 3), new GPoint(0, 3),
			new GPoint(-1, 3), new GPoint(-2, 3), new GPoint(-3, 2),
			new GPoint(-3, 1), new GPoint(-3, 0), new GPoint(-3, -1),
			new GPoint(-3, -2), new GPoint(-2, -3), new GPoint(-1, -3),
			new GPoint(3, 3), new GPoint(3, -3), new GPoint(-3, 3),
			new GPoint(-3, -3)};

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
		private TerrainMapCellCollection oCells;
		private List<TerrainMapGroup> aGroups = new List<TerrainMapGroup>();

		/// <summary>
		/// Used exclusively for deserialization
		/// </summary>
		public TerrainMap()
		{
			this.iSeed = Environment.TickCount; // Used to generate special resource cells and polar caps
			this.oSize = new GSize(2, 2);
			this.iXMedian = this.oSize.Width / 2;
			this.iYMedian = this.oSize.Height / 2;
			this.oCells = new TerrainMapCellCollection(this);
		}

		public TerrainMap(OpenCiv1Game parent, int width, int height) : this(parent, new GSize(width, height))
		{ }

		public TerrainMap(OpenCiv1Game parent, int width, int height, int seed) : this(parent, new GSize(width, height), seed)
		{ }

		public TerrainMap(OpenCiv1Game parent, GSize size) : this(parent, size, Environment.TickCount)
		{ }

		public TerrainMap(OpenCiv1Game parent, GSize size, int seed)
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
			this.oCells = new TerrainMapCellCollection(this);

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

					writer.Write(this.Cells[j, i].TerrainType);
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

		public TerrainMap(OpenCiv1Game parent, GBitmap bitmap) : this(parent, bitmap, Environment.TickCount)
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
		public TerrainMap(OpenCiv1Game parent, GBitmap bitmap, int seed)
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
			this.oCells = new TerrainMapCellCollection(this);

			RandomMT19937 rng = new RandomMT19937(this.iSeed);

			for (int i = 0; i < this.oSize.Height; i++)
			{
				for (int j = 0; j < this.oSize.Width; j++)
				{
					switch (bitmap.GetPixel(j, i))
					{
						case 1:
							this[j, i].TerrainType = TerrainTypeEnum.Water;
							break;

						case 2:
							this[j, i].TerrainType = TerrainTypeEnum.Forest;
							break;

						case 3:
							this[j, i].TerrainType = TerrainTypeEnum.Swamp;
							break;

						case 6:
							this[j, i].TerrainType = TerrainTypeEnum.Plains;
							break;

						case 7:
							this[j, i].TerrainType = TerrainTypeEnum.Tundra;
							break;

						case 9:
							this[j, i].TerrainType = TerrainTypeEnum.River;
							break;

						case 10:
							this[j, i].TerrainType = TerrainTypeEnum.Grassland;
							break;

						case 11:
							this[j, i].TerrainType = TerrainTypeEnum.Jungle;
							break;

						case 12:
							this[j, i].TerrainType = TerrainTypeEnum.Hills;
							break;

						case 13:
							this[j, i].TerrainType = TerrainTypeEnum.Mountains;
							break;

						case 14:
							this[j, i].TerrainType = TerrainTypeEnum.Desert;
							break;

						case 15:
							this[j, i].TerrainType = TerrainTypeEnum.Arctic;
							break;

						default:
							throw new Exception($"Undefined terrain type {bitmap.GetPixel(j, i)}");
					}
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
						this.Cells[j, i] = new TerrainMapCell(j, i);
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
								TerrainMapCell cell = this.Cells[j, i];

								switch (cell.TerrainType)
								{
									// Convert Water to Plains
									case TerrainTypeEnum.Water:
										cell.TerrainType = TerrainTypeEnum.Plains;
										break;

									// Convert Plains to Hills
									case TerrainTypeEnum.Plains:
										cell.TerrainType = TerrainTypeEnum.Hills;
										break;

									// Convert Hills to Mountains
									case TerrainTypeEnum.Hills:
										cell.TerrainType = TerrainTypeEnum.Mountains;
										break;
								}

								iContinentCellCount++;
							}
						}
					}

					iTotalContinentCellCount += iContinentCellCount;
				}

				// Clear cells surrounding the map, and set them to TerrainTypeEnum.Water
				/*for (int i = 0; i < this.oSize.Height; i++)
				{
					this.Cells[0, i].TerrainType = 1;
					this.Cells[1, i].TerrainType = 1;
					this.Cells[this.oSize.Width - 1, i].TerrainType = 1;
					this.Cells[this.oSize.Width - 2, i].TerrainType = 1;
				}*/
				for (int i = 0; i < this.oSize.Width; i++)
				{
					this.Cells[i, 0].TerrainType = TerrainTypeEnum.Water;
					this.Cells[i, 1].TerrainType = TerrainTypeEnum.Water;
					this.Cells[i, this.oSize.Height - 1].TerrainType = TerrainTypeEnum.Water;
					this.Cells[i, this.oSize.Height - 2].TerrainType = TerrainTypeEnum.Water;
				}

				// Correct Land Plains, Hills and Mountains
				for (int i = 1; i < this.oSize.Height - 1; i++)
				{
					for (int j = 1; j < this.oSize.Width - 1; j++)
					{
						int edges = 0;

						if (this.Cells[j, i].TerrainType != TerrainTypeEnum.Water)
						{
							edges |= 0x1;
						}
						if (this.Cells[j + 1, i].TerrainType != TerrainTypeEnum.Water)
						{
							edges |= 0x2;
						}
						if (this.Cells[j, i + 1].TerrainType != TerrainTypeEnum.Water)
						{
							edges |= 0x4;
						}
						if (this.Cells[j + 1, i + 1].TerrainType != TerrainTypeEnum.Water)
						{
							edges |= 0x8;
						}

						if (edges == 6 || edges == 9)
						{
							this.Cells[j + 1, i].TerrainType = TerrainTypeEnum.Plains;
							this.Cells[j, i + 1].TerrainType = TerrainTypeEnum.Plains;
							this.Cells[j + 1, i + 1].TerrainType = TerrainTypeEnum.Plains;

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
						TerrainMapCell cell = this.Cells[i, j];

						if (cell.TerrainType == TerrainTypeEnum.Plains)
						{
							int local_4 = Math.Abs(rng.Next(8) + j - yMedian) + (1 - this.iTemperature);

							if (((local_4 / 6) + 1) < 8)
							{
								switch ((local_4 / 6) + 1)
								{
									case 2:
									case 3:
										cell.TerrainType = TerrainTypeEnum.Plains;
										break;

									case 4:
									case 5:
										cell.TerrainType = TerrainTypeEnum.Tundra;
										break;

									case 0:
									case 1:
										cell.TerrainType = TerrainTypeEnum.Desert;
										break;

									case 6:
									case 7:
										cell.TerrainType = TerrainTypeEnum.Arctic;
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
						TerrainMapCell cell = this.Cells[j, i];

						if (cell.TerrainType != TerrainTypeEnum.Water)
						{
							if (iTotalContinentCellCount > 0)
							{
								iTotalContinentCellCount -= rng.Next(7 - (this.iClimate * 2));

								switch (cell.TerrainType)
								{
									case TerrainTypeEnum.Plains:
										cell.TerrainType = TerrainTypeEnum.Grassland;
										break;

									case TerrainTypeEnum.Tundra:
										cell.TerrainType = TerrainTypeEnum.Arctic;
										break;

									case TerrainTypeEnum.Hills:
										cell.TerrainType = TerrainTypeEnum.Forest;
										break;

									case TerrainTypeEnum.Mountains:
										iTotalContinentCellCount -= 3;
										break;

									case TerrainTypeEnum.Desert:
										cell.TerrainType = TerrainTypeEnum.Plains;
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
						TerrainMapCell cell = this.Cells[j, i];

						if (cell.TerrainType == TerrainTypeEnum.Water)
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

								switch (cell.TerrainType)
								{
									case TerrainTypeEnum.Swamp:
									case TerrainTypeEnum.Hills:
										cell.TerrainType = TerrainTypeEnum.Forest;
										break;

									case TerrainTypeEnum.Plains:
										cell.TerrainType = TerrainTypeEnum.Grassland;
										break;

									case TerrainTypeEnum.Grassland:
										if (threshold < 10)
										{
											cell.TerrainType = TerrainTypeEnum.Jungle;
										}
										else
										{
											cell.TerrainType = TerrainTypeEnum.Swamp;
										}

										iTotalContinentCellCount = -2;
										break;

									case TerrainTypeEnum.Mountains:
										iTotalContinentCellCount -= 3;
										cell.TerrainType = TerrainTypeEnum.Forest;
										break;

									case TerrainTypeEnum.Desert:
										cell.TerrainType = TerrainTypeEnum.Plains;
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
						GPoint direction = TerrainMap.MoveOffsets[rng.Next(8) + 1];

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
						TerrainMapCell cell = this.Cells[xPos, yPos];

						switch (cell.TerrainType)
						{
							case TerrainTypeEnum.Forest:
								cell.TerrainType = TerrainTypeEnum.Jungle;
								break;

							case TerrainTypeEnum.Swamp:
								cell.TerrainType = TerrainTypeEnum.Grassland;
								break;

							case TerrainTypeEnum.River:
								break;

							case TerrainTypeEnum.Plains:
							case TerrainTypeEnum.Tundra:
								cell.TerrainType = TerrainTypeEnum.Hills;
								break;

							case TerrainTypeEnum.Grassland:
								cell.TerrainType = TerrainTypeEnum.Forest;
								break;

							case TerrainTypeEnum.Jungle:
								cell.TerrainType = TerrainTypeEnum.Swamp;
								break;

							case TerrainTypeEnum.Hills:
							case TerrainTypeEnum.Arctic:
								cell.TerrainType = TerrainTypeEnum.Mountains;
								break;

							case TerrainTypeEnum.Mountains:
								if (this.Cells[xPos - 1, yPos - 1].TerrainType != TerrainTypeEnum.Water && 
									this.Cells[xPos - 1, yPos + 1].TerrainType != TerrainTypeEnum.Water &&
									this.Cells[xPos + 1, yPos - 1].TerrainType != TerrainTypeEnum.Water && 
									this.Cells[xPos + 1, yPos + 1].TerrainType != TerrainTypeEnum.Water)
								{
									cell.TerrainType = TerrainTypeEnum.Water;
								}
								break;

							case TerrainTypeEnum.Desert:
								cell.TerrainType = TerrainTypeEnum.Plains;
								break;
						}
					}
				}
				#endregion

				#region Stage 5 - Render rivers
				int iMax = ((this.iLandMass + this.iClimate) * 2) + 6;
				TerrainTypeEnum[,] aMapCopy = new TerrainTypeEnum[this.oSize.Width, this.oSize.Height];

				for (int i = 0, j = 0; i < 256 && j < iMax; i++)
				{
					int local_16 = 0;

					// make a copy of the map
					for (int y = 0; y < this.oSize.Height; y++)
					{
						for (int x = 0; x < this.oSize.Width; x++)
						{
							aMapCopy[x, y] = this.Cells[x, y].TerrainType;
						}
					}

					do
					{
						xPos = rng.Next(80);
						yPos = rng.Next(50);
					}
					while (this.Cells[xPos, yPos].TerrainType != TerrainTypeEnum.Hills);

					int xPos1 = xPos;
					int yPos1 = yPos;
					int local_18 = rng.Next(4) * 2;
					TerrainTypeEnum local_2;
					int local_4 = 0;

					do
					{
						this.Cells[xPos, yPos].TerrainType = TerrainTypeEnum.River;

						for (int k = 1; k < 9; k += 2)
						{
							GPoint direction1 = TerrainMap.MoveOffsets[k];

							if (this.Cells[xPos + direction1.X, yPos + direction1.Y].TerrainType == TerrainTypeEnum.Water)
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


						GPoint direction = TerrainMap.MoveOffsets[local_18 + 1];

						xPos += direction.X;
						yPos += direction.Y;

						local_2 = this.Cells[xPos, yPos].TerrainType;
						local_16++;
					}
					while (local_4 == 0 && local_2 != TerrainTypeEnum.Water && local_2 != TerrainTypeEnum.River && local_2 != TerrainTypeEnum.Mountains);

					if ((local_4 == 0 && local_2 != TerrainTypeEnum.River) || local_16 < 5)
					{
						// restore map copy
						for (int y = 0; y < this.oSize.Height; y++)
						{
							for (int x = 0; x < this.oSize.Width; x++)
							{
								this.Cells[x, y].TerrainType = aMapCopy[x, y];
							}
						}
					}
					else
					{
						j++;

						for (int k = 1; k < 22; k++)
						{
							GPoint direction = TerrainMap.MoveOffsets[k];

							xPos = xPos1 + direction.X;
							yPos = yPos1 + direction.Y;

							if (this.Cells[xPos, yPos].TerrainType == TerrainTypeEnum.Forest)
							{
								this.Cells[xPos, yPos].TerrainType = TerrainTypeEnum.Jungle;
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
			if (this.oParent!=null && this.oGameData != null)
			{
				int iTotalMapCellCount = this.oSize.Height * this.oSize.Width;

				#region Stage 6 - Render polar caps
				for (int i = 0; i < this.oSize.Width; i++)
				{
					this.Cells[i, 0].TerrainType = TerrainTypeEnum.Arctic;
					this.Cells[i, this.oSize.Height - 1].TerrainType = TerrainTypeEnum.Arctic;
				}

				for (int i = 0; i < iTotalMapCellCount / 200; i++)
				{
					this.Cells[rng.Next(this.oSize.Width), 0].TerrainType = TerrainTypeEnum.Tundra;
					this.Cells[rng.Next(this.oSize.Width), 1].TerrainType = TerrainTypeEnum.Tundra;
					this.Cells[rng.Next(this.oSize.Width), this.oSize.Height - 2].TerrainType = TerrainTypeEnum.Tundra;
					this.Cells[rng.Next(this.oSize.Width), this.oSize.Height - 1].TerrainType = TerrainTypeEnum.Tundra;
				}
				#endregion

				#region Stage 6a - Render Special Resources
				for (int i = 0; i < iTotalMapCellCount / 18; i++)
				{
					int xPos = rng.Next(this.oSize.Width);
					int yPos = 4 + rng.Next(this.oSize.Height - 8);

					this.Cells[xPos, yPos].HasSpecialResources = true;
				}
				#endregion

				#region Stage 7 - Determine Map groups (Sea, Land and Polar caps)
				ReGenerateMapGroups();
				#endregion

				#region Stage 8 - Determine land cell worth for city build sites
				BDictionary<TerrainTypeEnum, int> terrainCoefficients = new BDictionary<TerrainTypeEnum, int>();
				BDictionary<TerrainTypeEnum, int> terrainCoefficients1 = new BDictionary<TerrainTypeEnum, int>();

				foreach (TerrainTypeEnum terrainType in Enum.GetValues<TerrainTypeEnum>())
				{
					TerrainDefinition terrain = this.oGameData.Static.Terrains.GetValueByKey(terrainType);
					int iFood1 = terrain.Food;
					int iTrade1 = terrain.Trade;
					int iProduction1 = terrain.Production;

					foreach (TerrainResource resource in terrain.Resources)
					{
						iFood1 += resource.Food;
						iTrade1 += resource.Trade;
						iProduction1 += resource.Production;
					}

					int coefficient = (3 * terrain.Food) + terrain.Trade;
					int coefficient1 = (3 * iFood1) + iTrade1;

					if (terrainType != TerrainTypeEnum.Grassland && terrainType != TerrainTypeEnum.River)
					{
						coefficient += terrain.Production * 2;
						coefficient1 += iProduction1 * 2;
					}

					if (terrain.Multi3 < 0)
					{
						coefficient += -1 - terrain.Multi3;
						coefficient1 += -1 - terrain.Multi3;
					}
					else
					{
						if (terrain.Multi1 < 0)
						{
							coefficient += (-1 - terrain.Multi1) * 2;
							coefficient1 += (-1 - terrain.Multi1) * 2;
						}
					}

					terrainCoefficients.Add(terrainType, coefficient);
					terrainCoefficients1.Add(terrainType, coefficient1);
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

								if (!this.Cells[xPos, yPos].HasSpecialResources)
								{
									cellWorth += terrainCoefficients.GetValueByKey(terrainType);
								}
								else
								{
									cellWorth += terrainCoefficients1.GetValueByKey(terrainType);
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
				TerrainMapGroupTypeEnum groupType = this.Cells[x, y].GroupType; // Get the cell Group type

				// Detect polar caps. The polar caps start with one or two cells at the TopLeft and BottomLeft of the Map
				if (groupType == TerrainMapGroupTypeEnum.Land && x == 0 && (y == 0 || y == 1 || y == this.oSize.Height - 2 || y == this.oSize.Height - 1))
				{
					groupType = TerrainMapGroupTypeEnum.PolarCap;
				}

				TerrainMapGroup group = new TerrainMapGroup(iGroupID, groupType);

				this.Cells[x, y].Layer3_GroupID = iGroupID; // Set the starting cell to our GroupID
				iCellCount++; // Increment the group cell count
				queue.Enqueue(new GPoint(x, y)); // Append the starting position to the queue

				while (queue.Count > 0)
				{
					GPoint position = queue.Dequeue(); // remove the next position from the queue
					TerrainMapCell cell;

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
						if (groupType != TerrainMapGroupTypeEnum.Water && (cell = this.Cells[position.X - 1, position.Y - 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X - 1, position.Y - 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X - 1, position.Y - 1)); // Append the current position to the queue
						}

						// North - East
						if (groupType != TerrainMapGroupTypeEnum.Water && (cell = this.Cells[position.X + 1, position.Y - 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
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
						if (groupType != TerrainMapGroupTypeEnum.Water && (cell = this.Cells[position.X - 1, position.Y + 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
						{
							this.Cells[position.X - 1, position.Y + 1].Layer3_GroupID = iGroupID; // Set the neighbour cell to our GroupID
							iCellCount++; // Increment the group cell count
							queue.Enqueue(new GPoint(position.X - 1, position.Y + 1)); // Append the current position to the queue
						}

						// South - East
						if (groupType != TerrainMapGroupTypeEnum.Water && (cell = this.Cells[position.X + 1, position.Y + 1]).Layer3_GroupID == -1 && cell.GroupType == groupType)
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
		/// Returns true if the given position is valid for this map
		/// </summary>
		/// <param name="x">X position to test</param>
		/// <param name="y">Y position to test</param>
		/// <returns></returns>
		public bool IsValidPosition(int x, int y)
		{
			// X position is wrapped so we don't need to test it
			return y >= 0 && y < this.oSize.Height;
		}

		/// <summary>
		/// Returns true if the given position is valid for this map
		/// </summary>
		/// <param name="pt">Point to test</param>
		/// <returns></returns>
		public bool IsValidPosition(GPoint pt)
		{
			// X position is wrapped so we don't need to test it
			return pt.Y >= 0 && pt.Y < this.oSize.Height;
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

		public int GetMoveOffset(GPoint offset)
		{
			int offsetIndex = -1;

			if (this.oGameData != null)
			{
				GPoint[] moveOffsets = TerrainMap.MoveOffsets;

				for (int i = 0; i < moveOffsets.Length; i++)
				{
					if (moveOffsets[i] == offset)
					{
						offsetIndex = i;
						break;
					}
				}
			}

			return offsetIndex;
		}

		public GPoint GetMoveOffset(int offsetIndex)
		{
			GPoint offset = OpenCiv1Game.InvalidPosition;

			if (this.oGameData != null)
			{
				GPoint[] moveOffsets = TerrainMap.MoveOffsets;

				if (offsetIndex >= 0 && offsetIndex < moveOffsets.Length)
				{
					offset = moveOffsets[offsetIndex];
				}
			}

			return offset;
		}

		public bool IsValidGoToPath(GPoint src, GPoint dest, UnitMovementTypeEnum movementType, int maxMoves)
		{
			Unit unit;

			switch (movementType)
			{
				case UnitMovementTypeEnum.Land:
					unit = new Unit();
					unit.TypeID = (int)UnitTypeEnum.Militia;
					unit.Position = src;
					unit.GoToDestination = dest;
					break;

				case UnitMovementTypeEnum.Water:
					unit = new Unit();
					unit.TypeID = (int)UnitTypeEnum.Trireme;
					unit.Position = src;
					unit.GoToDestination = dest;
					break;

				case UnitMovementTypeEnum.Air:
					unit = new Unit();
					unit.TypeID = (int)UnitTypeEnum.Fighter;
					unit.Position = src;
					unit.GoToDestination = dest;
					break;

				default:
					return false;
			}

			FindUnitPath(unit, false);

			return unit.GoToDestination != OpenCiv1Game.InvalidPosition && unit.GoToPath.Count > 0 && unit.GoToPath.Count < maxMoves;
		}

		#region AStar (A*) Path finding algorithm
		/// <summary>
		/// A Function to find the shortest path between tho points according to AStar (A*) Algorithm
		/// </summary>
		/// <param name="src">Source position</param>
		/// <param name="dest">Destination position</param>
		/// <param name="playerID">ID of the player</param>
		/// <param name="unitType">ID of the unit</param>
		public void FindUnitPath(Unit unit, bool testVisibility)
		{
			if (this.oGameData != null && unit.GoToDestination != OpenCiv1Game.InvalidPosition)
			{
				bool destinationReached = false; // remains false if we can't find a path to a destination
				TerrainMapGroupTypeEnum group1; // The unit can move on this terrain type
				TerrainMapGroupTypeEnum group2; // The unit can move on this terrain type
				UnitMovementTypeEnum movementType = this.oGameData.Static.Units[unit.TypeID].MovementType;

				unit.GoToPath.Clear();

				switch (movementType)
				{
					case UnitMovementTypeEnum.Land:
						group1 = TerrainMapGroupTypeEnum.Land;
						group2 = TerrainMapGroupTypeEnum.Land;
						break;

					case UnitMovementTypeEnum.Water:
						group1 = TerrainMapGroupTypeEnum.Water;
						group2 = TerrainMapGroupTypeEnum.Water;
						break;

					case UnitMovementTypeEnum.Air:
						group1 = TerrainMapGroupTypeEnum.Water;
						group2 = TerrainMapGroupTypeEnum.Land;
						break;

					default:
						throw new Exception("Unknown Unit Movement Type"); // should never happen, but we want to make compiler happy
				}

				if (!IsValidPosition(unit.Position) || !IsValidPosition(unit.GoToDestination) || // Source or destination cell position is out of range
					unit.Position == unit.GoToDestination || // Destination is the same as the source position
					this[unit.GoToDestination].GroupType != TerrainMapGroupTypeEnum.Land || // Destination has to be on the land also
					((movementType == UnitMovementTypeEnum.Land || movementType == UnitMovementTypeEnum.Water) &&
						this[unit.Position].Layer3_GroupID != this[unit.GoToDestination].Layer3_GroupID) || // For the unit that is moving on Land or Water we have to be on the same continent
					(testVisibility && !this[unit.Position].IsVisibleTo(unit.PlayerID)) ||
					(testVisibility && !this[unit.GoToDestination].IsVisibleTo(unit.PlayerID))) // Either the source or the destination cell is invisible to the Player
				{
					return;
				}

				// Clean AStar cell details
				this.oCells.ClearAStarData();

				// Create a sorted open list in descending order (sorted from higher to lower value)
				// We compare this list by cell's f value
				List<TerrainMapCell> openCells = new List<TerrainMapCell>();

				// Initialize start cell
				TerrainMapCell cell = this[unit.Position];
				cell.GCost = 0.0;
				cell.HCost = 0.0;
				cell.FCost = 0.0;
				cell.ParentPos = cell.Position;

				// Put the starting cell on the open list
				openCells.Add(cell);

				while (openCells.Count > 0)
				{
					// Our most favorable current cell is the cell with lowest FCost value
					cell = openCells[openCells.Count - 1];
					GPoint pos = cell.Position;

					openCells.RemoveAt(openCells.Count - 1);

					// Mark this cell as closed
					cell.IsCellClosed = true;

					// Generate all 8 successors of this cell
					for (int i = -1; i <= 1 && !destinationReached; i++)
					{
						for (int j = -1; j <= 1 && !destinationReached; j++)
						{
							if (i == 0 && j == 0)
								continue;

							GPoint newPos = pos.Offset(j, i);

							// If new cell successor position is a valid position
							if (IsValidPosition(newPos))
							{
								TerrainMapCell newCell = this[newPos];

								if (newCell.GroupType == group1 || newCell.GroupType == group2)
								{
									// If the destination cell is the same as the current successor cell
									// we have reached our destination
									if (newPos == unit.GoToDestination)
									{
										newCell.GCost = cell.GCost + newCell.VisibleMovementCost;
										newCell.HCost = 0.0;
										newCell.FCost = newCell.GCost + newCell.HCost;
										newCell.ParentPos = pos;

										destinationReached = true;
										continue;
									}

									// Ignore the successor cell if it is closed or blocked
									if (!newCell.IsCellClosed && (!testVisibility || this[newPos].IsVisibleTo(unit.PlayerID)))
									{
										double newGCost = cell.GCost + newCell.VisibleMovementCost;
										double newHCost = GetDistance(newPos, unit.GoToDestination);
										double newFCost = newGCost + newHCost;

										// Make current cell the parent of the new successor cell
										if (newCell.FCost == double.MaxValue)
										{
											// We have found a new path
											// Update the details of the new successor cell and add it to the open cell list in descending order
											newCell.GCost = newGCost;
											newCell.HCost = newHCost;
											newCell.FCost = newFCost;
											newCell.ParentPos = pos;

											bool bAdded = false;

											for (int k = 0; k < openCells.Count; k++)
											{
												if (openCells[k].FCost.CompareTo(newCell.FCost) <= 0)
												{
													openCells.Insert(k, newCell);
													bAdded = true;
													break;
												}
											}

											if (!bAdded)
											{
												openCells.Add(newCell);
											}
										}
										else if (newCell.FCost > newFCost)
										{
											// We have found a more favorable path
											// First, remove existing cell from open cell list to avoid duplicates
											for (int k = 0; k < openCells.Count; k++)
											{
												if (openCells[k].Position == newPos)
												{
													openCells.RemoveAt(k);
													break;
												}
											}

											// Update the details of the new successor cell and add it to the open cell list in descending order
											newCell.GCost = newGCost;
											newCell.HCost = newHCost;
											newCell.FCost = newFCost;
											newCell.ParentPos = pos;

											bool bAdded = false;

											for (int k = 0; k < openCells.Count; k++)
											{
												if (openCells[k].FCost.CompareTo(newCell.FCost) <= 0)
												{
													openCells.Insert(k, newCell);
													bAdded = true;
													break;
												}
											}

											if (!bAdded)
											{
												openCells.Add(newCell);
											}
										}
									}
								}
							}
						}
					}
				}

				// When the destination cell is not found and the open list is empty
				// We can safely conclude that we failed to reach the destination cell.
				// This may happen when there is no way to destination cell
				if (!destinationReached)
				{
					unit.GoToDestination = OpenCiv1Game.InvalidPosition;
				}
				else
				{
					// We have sucessfuly found a path from Source to Destination position
					GPoint pos = unit.GoToDestination;

					// Exclude out source position
					while ((cell = this[pos]).ParentPos != pos)
					{
						unit.GoToPath.Push(pos); // Store in reverse order
						pos = cell.ParentPos;
					}
				}
			}
		}
		#endregion

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
					this.oCells = new TerrainMapCellCollection(this);
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

		public TerrainMapCellCollection Cells
		{
			get => this.oCells;
		}

		public List<TerrainMapGroup> Groups
		{
			get => this.aGroups;
		}

		[XmlIgnore]
		public TerrainMapCell this[int x, int y]
		{
			get => this.oCells[x, y];
			set => this.oCells[x, y] = value;
		}

		[XmlIgnore]
		public TerrainMapCell this[GPoint pt]
		{
			get => this.oCells[pt.X, pt.Y];
			set => this.oCells[pt.X, pt.Y] = value;
		}


		public static int TerrainTypeEnumToValue(TerrainTypeEnum terrainType)
		{
			switch (terrainType)
			{
				case TerrainTypeEnum.Desert:
					return 0;

				case TerrainTypeEnum.Plains:
					return 1;

				case TerrainTypeEnum.Grassland:
					return 2;

				case TerrainTypeEnum.Forest:
					return 3;

				case TerrainTypeEnum.Hills:
					return 4;

				case TerrainTypeEnum.Mountains:
					return 5;

				case TerrainTypeEnum.Tundra:
					return 6;

				case TerrainTypeEnum.Arctic:
					return 7;

				case TerrainTypeEnum.Swamp:
					return 8;

				case TerrainTypeEnum.Jungle:
					return 9;

				case TerrainTypeEnum.River:
					return 11;

				default:
					return 10;
			}
		}

		public static TerrainTypeEnum ValueToTerrainTypeEnum(int terrainValue)
		{
			switch (terrainValue)
			{
				case 0:
					return TerrainTypeEnum.Desert;

				case 1:
					return TerrainTypeEnum.Plains;

				case 2:
					return TerrainTypeEnum.Grassland;

				case 3:
					return TerrainTypeEnum.Forest;

				case 4:
					return TerrainTypeEnum.Hills;

				case 5:
					return TerrainTypeEnum.Mountains;

				case 6:
					return TerrainTypeEnum.Tundra;

				case 7:
					return TerrainTypeEnum.Arctic;

				case 8:
					return TerrainTypeEnum.Swamp;

				case 9:
					return TerrainTypeEnum.Jungle;

				case 11:
					return TerrainTypeEnum.River;

				default:
					return TerrainTypeEnum.Water;
			}
		}

		/// <summary>
		/// Deserializes a Map object.
		/// </summary>
		/// <param name="path">A full path to the Map object xml file</param>
		/// <param name="gzipped">If true appends an ".gz" extension to the file path.</param>
		/// <returns>A deserialized Map object.</returns>
		public static TerrainMap Deserialize(string path, bool gzipped)
		{
			return Deserialize(path + (gzipped ? ".gz" : ""));
		}

		/// <summary>
		/// Deserializes a Map object.
		/// Assumes file iz gzipped, if the filename ends with .gz
		/// </summary>
		/// <param name="path">A full path to a Map object xml file.</param>
		/// <returns>A deserialized Map object.</returns>
		public static TerrainMap Deserialize(string path)
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

			TerrainMap newMap = Deserialize(reader);

			reader.Close();

			return newMap;
		}

		/// <summary>
		/// Deserializes a Map object.
		/// </summary>
		/// <param name="reader">A stream to read the Map object from.</param>
		/// <returns>A deserialized Map object.</returns>
		public static TerrainMap Deserialize(StreamReader reader)
		{
			XmlSerializer ser = new XmlSerializer(typeof(TerrainMap));
			object? obj = ser.Deserialize(reader);

			if (obj == null)
				throw new Exception("Can't deserialize Map object");

			TerrainMap newMap = (TerrainMap)obj;

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
			XmlSerializer ser = new XmlSerializer(typeof(TerrainMap));
			ser.Serialize(writer, this);
		}
	}
}
