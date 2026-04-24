using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System;
using System.Numerics;

namespace OpenCiv1
{
	public class MapManagement
	{
		// The Map is currently kept as a bitmap, the layer number, description and position table following:
		// Layer 1: Terrain data (TerrainTypeEnum), 0:0
		// Layer 2: Player land ownership, 80:0
		//
		// Layer 3: Terrain groups, the land and water cells have separate group arrays, 0:50
		// Layer 4: Terrain-based land appeal for the computer to build cities, 80:50
		//
		// Layer 5: Same as layer 6, but only what's visible to the player, 0:100
		// Layer 6: Terrain improvements (irrigation, mining, roads), 80:100
		//
		// Layer 7: Same as layer 8, but only what's visible to the player, 0:150
		// Layer 8: Terrain improvements (railroads, roads, rivers, fortresses), 80:150
		//
		// Layer 9: Per-Civ land exploration and active units, 160:0
		// Layer 10: Mini-map render, 240:0

		private OpenCiv1Game parent;
		private GameData gameData;
		private VCPU CPU;

		// Local variables used exclusively inside this section
		public static GSize Size = new GSize(80, 50);
		public static int XMedian = 80 / 2;

		/// <summary>Number of cities currently visible on the screen</summary>
		private List<CityInfo> VisibleCities = new List<CityInfo>();

		public MapManagement(OpenCiv1Game parent)
		{
			this.parent = parent;
			this.gameData = parent.GameData;
			this.CPU = parent.CPU;
			this.gameData.Map.Visible = false;
		}

		#region Map management functions

		/// <summary>
		/// Creates a new map with preloaded Earth landscape
		/// </summary>
		public void LoadEarthMap()
		{
			GBitmap? earthMap = GBitmap.FromPICFile(this.parent.ResourcePath + "map.pic", true);

			if (earthMap == null)
			{
				throw new Exception("Can't find Earth map.pic image file");
			}
			else
			{
				bool visible = this.gameData.Map.Visible;

				this.gameData.Map = new GBitmap(320, 200);
				this.gameData.Map.Visible = visible;
				this.gameData.Map.DrawBitmap(0, 0, earthMap, false);

				// Add this Map to a screen collection so we can inspect it later
				//this.gameData.Map.Visible = true;
				if (this.parent.Graphics.Screens.ContainsKey(3))
				{
					this.parent.Graphics.Screens.RemoveByKey(3);
				}

				this.parent.Graphics.Screens.Add(3, this.gameData.Map);
			}
		}

		/// <summary>
		/// Creates a new empty map that needs to be populated
		/// </summary>
		public void CreateNewEmptyMap()
		{
			bool visible = this.gameData.Map.Visible;

			this.gameData.Map = new GBitmap(320, 200);
			this.gameData.Map.Visible = visible;
			this.gameData.Map.FillRectangle(new GRectangle(0, 0, 80, 50), 1, PixelWriteModeEnum.Normal);

			// Add this Map screen to a screen collection so we can inspect it later
			//this.gameData.Map.Visible = true;
			if (this.parent.Graphics.Screens.ContainsKey(3))
			{
				this.parent.Graphics.Screens.RemoveByKey(3);
			}

			this.parent.Graphics.Screens.Add(3, this.gameData.Map);
		}
		#endregion

		#region Screen drawing functions
		/// <summary>
		/// Draws visible Map to screen
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_2aea_0008_DrawVisibleMap(int playerID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_0008({playerID}, {x}, {y})");

			// function body
			// Instruction address 0x2aea:0x000f, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			this.parent.Var_1ae0 = 0;

			this.parent.Segment_1238.F0_1238_0fea();
			this.parent.Segment_1238.F0_1238_107e();

			int tempValue = this.parent.Var_d20a;

			this.parent.Var_d4cc_MapViewX = this.parent.MapManagement.AdjustXPosition(x);
			this.parent.Var_d75e_MapViewY = this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(y, 0, 38);

			// Another error, the code modified first parameter (playerID) to a
			// Visibility Mask and that conflicts with other code which expects playerID.
			int mapPlayerVisibilityMask = (0x1 << playerID);

			this.VisibleCities.Clear();

			// redraw Visible Map on screen
			int cellXPos;
			int cellYPos;
			int cellDrawOrder = this.parent.CAPI.RNG.Next(256);

			for (int i = 0; i < 256; i++)
			{
				cellXPos = (cellDrawOrder & 0xf);
				cellYPos = (cellDrawOrder & 0xf0) >> 4;

				if (cellYPos < 12 && cellXPos < 15)
				{
					if (this.parent.Var_d806_DebugFlag ||
						(this.parent.GameData.MapVisibility[this.parent.MapManagement.AdjustXPosition(cellXPos + this.parent.Var_d4cc_MapViewX),
							cellYPos + this.parent.Var_d75e_MapViewY] & mapPlayerVisibilityMask) != 0)
					{
						// Instruction address 0x2aea:0x0122, size: 3
						F0_2aea_11d4_DrawCellWithUnit(this.parent.MapManagement.AdjustXPosition(cellXPos + this.parent.Var_d4cc_MapViewX), cellYPos + this.parent.Var_d75e_MapViewY);
					}
					else
					{
						// Instruction address 0x2aea:0x0094, size: 5
						this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, (cellXPos * 16) + 80, (cellYPos * 16) + 8, 16, 16, 0);
					}
				}

				cellDrawOrder = (5 * cellDrawOrder) + 1;

				// A bit of delay should be introduced in the future so that appearing map cells effect can be seen
				//this.oParent.Segment_1000.F0_1182_0134_WaitTimer(1);
				//Thread.Sleep(2);
			}

			// Draw city names
			for (int i = 0; i < this.VisibleCities.Count; i++)
			{
				CityInfo cityInfo = this.VisibleCities[i];

				if (cityInfo.ScreenPos.Y >= 184)
				{
					continue;
				}

				this.CPU.WriteUInt8(this.CPU.DS.UInt16, 0xba06, 0x0);

				// Instruction address 0x2aea:0x0148, size: 5
				this.parent.CAPI.strcat(0xba06, this.parent.Segment_2459.F0_2459_08c6_GetCityName(cityInfo.CityID));

				// Instruction address 0x2aea:0x015c, size: 5
				this.parent.LanguageTools.F0_2f4d_04f7(0xba06, (ushort)(327 - cityInfo.ScreenPos.X));

				// Instruction address 0x2aea:0x018d, size: 5
				this.parent.DrawStringTools.F0_1182_0086_DrawStringWithShadow(0xba06,
					this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(cityInfo.ScreenPos.X - 8, 80, 999), cityInfo.ScreenPos.Y + 16, 11);
			}

			int xMap = x - 32;
			int yMap = y - 19;
			int mapXSrc;
			int mapYSrc;
			int mapXDst;
			int mapYDst;
			int mapYOffset;

			// Instruction address 0x2aea:0x01b9, size: 5
			if (this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Navigation))
			{
				yMap = 0;
			}

			if (xMap >= 0)
			{
				mapXSrc = xMap;
			}
			else
			{
				mapXSrc = xMap + 80;
			}

			mapXDst = 80;

			if (mapXSrc > 0)
			{
				mapXDst -= mapXSrc;
			}

			mapYSrc = (yMap >= 0) ? yMap : 0;
			mapYOffset = mapYSrc - yMap;
			mapYDst = 50 - mapYOffset;

			if (yMap > 0)
			{
				mapYDst -= yMap;
			}

			this.parent.Var_6ed6 = xMap;
			this.parent.Var_70ea = yMap;

			// Instruction address 0x2aea:0x0233, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 8, 80, 50, 0);

			if (this.parent.Var_d806_DebugFlag)
			{
				this.parent.Graphics.DrawBitmapToScreen(this.gameData.Map, mapXSrc, mapYSrc, mapXDst, mapYDst,
					this.parent.Var_aa_Screen0_Rectangle, 0, mapYOffset + 8);

				if (mapXDst < 80)
				{
					this.parent.Graphics.DrawBitmapToScreen(this.gameData.Map, 0, mapYSrc, 80 - mapXDst, mapYDst,
						this.parent.Var_aa_Screen0_Rectangle, mapXDst, mapYOffset + 8);
				}
			}
			else
			{
				// Instruction address 0x2aea:0x02af, size: 5
				this.parent.Graphics.DrawBitmapToScreen(this.gameData.Map, mapXSrc + 240, mapYSrc, mapXDst, mapYDst,
					this.parent.Var_aa_Screen0_Rectangle, 0, mapYOffset + 8);

				if (mapXDst < 80)
				{
					// Instruction address 0x2aea:0x02da, size: 5
					this.parent.Graphics.DrawBitmapToScreen(this.gameData.Map, 240, mapYSrc, 80 - mapXDst, mapYDst,
						this.parent.Var_aa_Screen0_Rectangle, mapXDst, mapYOffset + 8);
				}
			}

			for (int i = 0; i < 128; i++)
			{
				City city = this.parent.GameData.Cities[i];

				if (city.StatusFlag != 0xff && (city.VisibleSize != 0 || city.PlayerID == this.parent.GameData.HumanPlayerID))
				{
					// Instruction address 0x2aea:0x031a, size: 5
					cellXPos = this.parent.MapManagement.AdjustXPosition(city.Position.X - mapXSrc);
					cellYPos = city.Position.Y - mapYSrc + mapYOffset;

					if (cellYPos >= 0 && cellYPos < 50)
					{
						// Instruction address 0x2aea:0x0355, size: 3
						this.parent.Graphics.F0_VGA_0550_SetPixel(this.parent.Var_aa_Screen0_Rectangle.ScreenID, cellXPos, cellYPos + 8,
							this.parent.Array_1946[city.PlayerID]);
					}
				}
			}

			// Instruction address 0x2aea:0x037c, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0a66_DrawShadowRectangle(0, 8, 79, 49, 15, 8);

			// Instruction address 0x2aea:0x03a2, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(x - xMap - 1, y - yMap + 7, 17, 10, 15);

			this.parent.Var_d20a = tempValue;

			// Instruction address 0x2aea:0x03b0, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();
		}

		/// <summary>
		/// Draws map cell with its terrain features, improvements, fog of war, Minor tribe hut and city if present
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_2aea_03ba_DrawCell(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_03ba({x}, {y})");

			// function body
			// Tile position in screen coordinates
			int scrX = this.parent.MapManagement.AdjustXPosition(x - this.parent.Var_d4cc_MapViewX) * 16 + 80;
			int scrY = (y - this.parent.Var_d75e_MapViewY) * 16 + 8;

			if (scrX < 80 || scrX >= 320 || scrY < 8 || scrY > 192)
			{
				// if cells screen coordinates are outside of actual screen

				return false;
			}
			else
			{
				TerrainTypeEnum terrainType = GetTerrainType(x, y);
				TerrainImprovementFlagsEnum terrainImprovements = F0_2aea_15c1_GetTerrainImprovements(x, y);

				if (this.parent.Var_d806_DebugFlag)
				{
					// Instruction address 0x2aea:0x04a3, size: 3
					terrainImprovements = F0_2aea_1585_GetVisibleTerrainImprovements(x, y);
				}
			
				// Instruction address 0x2aea:0x04ac, size: 5
				this.parent.MainCode.F0_11a8_0268_HideMouse();

				if (terrainType == TerrainTypeEnum.Water)
				{
					// Draw ocean, coastal cells and river deltas
					int mask = 0;

					for (int i = 1; i < 9; i++)
					{
						mask >>= 1;

						GPoint direction = this.parent.MoveDirections[i];

						// Instruction address 0x2aea:0x0570, size: 3
						if (GetTerrainType(this.parent.MapManagement.AdjustXPosition(x + direction.X), y + direction.Y) != TerrainTypeEnum.Water &&
							F0_2aea_1326_ValidateMapCoordinates(0, y + direction.Y))
						{
							mask |= 0x80;
						}
					}

					int bitmapMask = (mask >> 6) & 0x3;
					bitmapMask += (mask << 2);

					for (int i = 0; i < 4; i++)
					{
						if (i < 2)
						{
							// Instruction address 0x2aea:0x05f4, size: 5
							this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX + ((i & 0x1) * 8), scrY,
								this.parent.Array_d294[(bitmapMask >> (i * 2)) & 0x7, i]);
						}
						else
						{
							// Instruction address 0x2aea:0x05f4, size: 5
							this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX - ((i & 0x1) * 8) + 8, scrY + 8,
								this.parent.Array_d294[(bitmapMask >> (i * 2)) & 0x7, i]);
						}
					}

					switch (mask)
					{
						case 0x1c:
							// Instruction address 0x2aea:0x0656, size: 5
							this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19e8_Screen2_Rectangle, 224, 100, 16, 16, this.parent.Var_aa_Screen0_Rectangle, scrX, scrY);
							break;

						case 0xc1:
							// Instruction address 0x2aea:0x0680, size: 5
							this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19e8_Screen2_Rectangle, 240, 100, 16, 16, this.parent.Var_aa_Screen0_Rectangle, scrX, scrY);
							break;

						case 0x7:
							// Instruction address 0x2aea:0x06a9, size: 5
							this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19e8_Screen2_Rectangle, 256, 100, 16, 16, this.parent.Var_aa_Screen0_Rectangle, scrX, scrY);
							break;

						case 0x70:
							// Instruction address 0x2aea:0x06d2, size: 5
							this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19e8_Screen2_Rectangle, 272, 100, 16, 16, this.parent.Var_aa_Screen0_Rectangle, scrX, scrY);
							break;

						case 0x8f:
							// Instruction address 0x2aea:0x06fc, size: 5
							this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19e8_Screen2_Rectangle, 288, 100, 16, 16, this.parent.Var_aa_Screen0_Rectangle, scrX, scrY);
							break;

						case 0xf8:
							// Instruction address 0x2aea:0x0726, size: 5
							this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19e8_Screen2_Rectangle, 304, 100, 16, 16, this.parent.Var_aa_Screen0_Rectangle, scrX, scrY);
							break;
					}

					// Draw river deltas on top of coastal cells
					for (int i = 1; i < 9; i += 2)
					{
						GPoint direction = this.parent.MoveDirections[i];

						// Instruction address 0x2aea:0x0752, size: 3
						if (GetTerrainType(this.parent.MapManagement.AdjustXPosition(x + direction.X), y + direction.Y) == TerrainTypeEnum.River)
						{
							// Instruction address 0x2aea:0x0777, size: 5
							this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_d2d4[(i - 1) / 2]);
						}
					}
				}

				if (terrainType != TerrainTypeEnum.Water)
				{
					// Draw grassland background for land cells
					// Instruction address 0x2aea:0x07cd, size: 5
					this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19e8_Screen2_Rectangle, 256, 120, 16, 16, this.parent.Var_aa_Screen0_Rectangle, scrX, scrY);
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Irrigation) && terrainType != TerrainTypeEnum.Water &&
					this.parent.Var_dcfc == 0 && !terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
				{
					// Draw irrigation
					// Instruction address 0x2aea:0x07f8, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_d4ce[4]);
				}

				if (terrainType == TerrainTypeEnum.River)
				{
					// Draw rivers
					int mask = 0;

					for (int i = 1; i < 9; i += 2)
					{
						mask >>= 1;

						GPoint direction = this.parent.MoveDirections[i];
						TerrainTypeEnum terrainType1 = GetTerrainType(this.parent.MapManagement.AdjustXPosition(x + direction.X), y + direction.Y);

						if (terrainType1 == TerrainTypeEnum.Water || terrainType1 == TerrainTypeEnum.River)
						{
							mask |= 0x8;
						}
					}

					if (this.F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.Flag80))
					{
						mask += 0x10;
					}

					if (mask > 0)
					{
						// Instruction address 0x2aea:0x0885, size: 5
						this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_6e00[mask - 1]);
					}
				}

				if (terrainType != TerrainTypeEnum.Water && terrainType != TerrainTypeEnum.River)
				{
					// Blend seas between cells with the same terrain types
					int mask = 0;

					for (int i = 1; i < 9; i += 2)
					{
						mask >>= 1;

						GPoint direction = this.parent.MoveDirections[i];

						if (GetTerrainType(this.parent.MapManagement.AdjustXPosition(x + direction.X), y + direction.Y) == terrainType &&
							F0_2aea_1326_ValidateMapCoordinates(0, y + direction.Y))
						{
							mask |= 0x8;
						}
					}

					// Instruction address 0x2aea:0x091e, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_b886[(int)terrainType, mask]);

					if (terrainType == TerrainTypeEnum.Grassland && (((7 * x) + (11 * y)) & 0x2) == 0)
					{
						// Draw grassland tiles with production bonus
						// Instruction address 0x2aea:0x0996, size: 5
						this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX + 4, scrY + 4, this.parent.Var_b880);
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Pollution))
				{
					// Draw pollution

					// Instruction address 0x2aea:0x09bc, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_d4ce[6]);
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Road))
				{
					// Draw roads and railroads
					int roadIcon = (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.RailRoad)) ? 0 : 6;

					for (int i = 1; i < 9; i++)
					{
						GPoint direction = this.parent.MoveDirections[i];

						// Instruction address 0x2aea:0x0a9a, size: 3
						TerrainImprovementFlagsEnum terrainImprovements1 =
							F0_2aea_15c1_GetTerrainImprovements(this.parent.MapManagement.AdjustXPosition(x + direction.X), y + direction.Y);

						if (terrainImprovements1.HasFlag(TerrainImprovementFlagsEnum.Road))
						{
							roadIcon = -1;

							TerrainImprovementFlagsEnum railRoadOrCity = TerrainImprovementFlagsEnum.RailRoad | TerrainImprovementFlagsEnum.City;

							if ((terrainImprovements & railRoadOrCity) == 0 || (terrainImprovements1 & railRoadOrCity) == 0)
							{
								// Instruction address 0x2aea:0x0a73, size: 5
								this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_b27a[i - 1]);
							}
							else
							{
								// Instruction address 0x2aea:0x0a73, size: 5
								this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_b29a[i - 1]);
							}
						}
					}

					if (roadIcon != -1)
					{
						// Draw single cell road or railroad

						// Instruction address 0x2aea:0x0ae0, size: 5
						this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, scrX + 7, scrY + 7, 2, 2, (ushort)roadIcon);
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Mines) && this.parent.Var_dcfc == 0)
				{
					// Draw mines

					// Instruction address 0x2aea:0x0aff, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_d4ce[5]);
				}

				// Instruction address 0x2aea:0x0b11, size: 3
				if (F0_2aea_1836_CellHasSpecialResource(x, y))
				{
					// Draw special resources

					// Instruction address 0x2aea:0x0b28, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_d4ce[(int)terrainType + 16]);
				}

				// Instruction address 0x2aea:0x0b3a, size: 3
				if (F0_2aea_1894_CellHasMinorTribeHut(x, y, terrainType))
				{
					// Draw Minot tribe hut

					// Instruction address 0x2aea:0x0b4e, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_d4ce[31]);
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Fortress))
				{
					// Draw fortresses

					// Instruction address 0x2aea:0x0b66, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_d4ce[30]);
				}

				if (!this.parent.Var_d806_DebugFlag)
				{
					// Draw fog of war borders

					for (int i = 1; i < 9; i += 2)
					{
						GPoint direction = this.parent.MoveDirections[i];

						// Instruction address 0x2aea:0x0b87, size: 5
						int yTemp = y + direction.Y;
						int visibilityMask = (yTemp >= 0 && yTemp < 50) ?
							this.parent.GameData.MapVisibility[this.parent.MapManagement.AdjustXPosition(x + direction.X), yTemp] : 0;

						if ((visibilityMask & (0x1 << this.parent.GameData.HumanPlayerID)) == 0)
						{
							// Instruction address 0x2aea:0x0bce, size: 5
							this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX, scrY, this.parent.Array_7eec[(i - 1) / 2]);
						}
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City) && this.parent.Var_dcfc == 0)
				{
					// Draw city

					// Instruction address 0x2aea:0x0c09, size: 5
					int cityID = this.parent.Segment_2dc4.F0_2dc4_00ba_GetCityID(x, y);

					if (cityID != -1)
					{
						// Draw city white borders at the left and bottom sides
						City city = this.parent.GameData.Cities[cityID];

						if (city.PlayerID == this.parent.GameData.HumanPlayerID || city.VisibleSize > 0 || this.parent.Var_d806_DebugFlag)
						{
							// Instruction address 0x2aea:0x0c4b, size: 5
							this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(scrX + 1, scrY + 1, 13, 13, 15);

							// Draw city dark borders at the top and right sides

							// Instruction address 0x2aea:0x0c7d, size: 5
							this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(scrX + 2, scrY + 1, 12, 12, this.parent.Array_1956[city.PlayerID]);

							// Draw city main color

							// Instruction address 0x2aea:0x0cac, size: 5
							this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, scrX + 2, scrY + 2, 12, 12,
								this.parent.Array_1946[city.PlayerID]);

							// Draw city 'streets'

							// Instruction address 0x2aea:0x0cba, size: 5
							this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX + 1, scrY + 1, this.parent.Array_d4ce[28]);

							// Color city 'streets' according to player nation

							// Instruction address 0x2aea:0x0ce5, size: 5
							this.parent.Graphics.F0_VGA_009a_ReplaceColor(this.parent.Var_aa_Screen0_Rectangle, scrX + 2, scrY + 2, 12, 12, 5,
								this.parent.Array_1956[city.PlayerID]);

							int citySize = (city.PlayerID == this.parent.GameData.HumanPlayerID || this.parent.Var_d806_DebugFlag) ?
									city.ActualSize : city.VisibleSize;

							this.CPU.WriteUInt8(this.CPU.DS.UInt16, 0xba06, 0x0);

							// Instruction address 0x2aea:0x0d42, size: 5
							this.parent.CAPI.strcat(0xba06, this.parent.CAPI.itoa(citySize, 10));

							if ((city.StatusFlag & 0x1) != 0)
							{
								// Draw city disorder

								// Instruction address 0x2aea:0x0d66, size: 5
								this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX + 5, scrY + 2, this.parent.Array_6e96[4]);
							}
							else
							{
								// Draw city size

								// Instruction address 0x2aea:0x0d8d, size: 5
								this.parent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, ((citySize < 10) ? 6 : 3) + scrX, scrY + 5, 0);
							}

							// Instruction address 0x2aea:0x0d9c, size: 3
							if (F0_2aea_1458_GetCellActiveUnitID(x, y) != -1 || city.Unknown[0] != -1)
							{
								// Draw city defenders

								// Instruction address 0x2aea:0x0dc2, size: 5
								this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(scrX, scrY, 15, 15, 0);
							}

							if ((city.ImprovementFlags0 & 0x80) != 0)
							{
								// Draw city walls

								// Instruction address 0x2aea:0x0de7, size: 5
								this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, scrX + 1, scrY + 1, this.parent.Array_d4ce[29]);
							}

							this.VisibleCities.Add(new CityInfo(scrX, scrY, cityID));
						}
					}
				}

				// Instruction address 0x2aea:0x0e1b, size: 5
				this.parent.MainCode.F0_11a8_0250_ShowMouse();
			}

			return true;
		}

		/// <summary>
		/// Draws unit(s) located on the currently visible map
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns>true if unit is drawn, otherwise false</returns>
		public bool F0_2aea_0e29_DrawUnit(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_0e29({playerID}, {unitID})");

			// function body
			// Instruction address 0x2aea:0x0ecd, size: 5
			Unit unit = this.parent.GameData.Players[playerID].Units[unitID];
			int x = this.parent.MapManagement.AdjustXPosition(unit.Position.X - this.parent.Var_d4cc_MapViewX) * 16 + 80;
			int y = (unit.Position.Y - this.parent.Var_d75e_MapViewY) * 16 + 8;

			if (x >= 80 && x < 320 && y >= 8 && y < 193)
			{
				if ((unit.Status & 0x1) == 0 || GetTerrainType(unit.Position.X, unit.Position.Y) != TerrainTypeEnum.Water ||
					this.parent.GameData.Units[unit.TypeID].MovementType == UnitMovementTypeEnum.Water)
				{
					// Instruction address 0x2aea:0x0f57, size: 5
					this.parent.MainCode.F0_11a8_0268_HideMouse();

					if (unit.NextUnitID != -1)
					{
						// There are multiple units stacked

						this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, x + 1, y + 1,
							this.parent.Array_d4ce[64 + (playerID * 32) + unit.TypeID]);
					}

					// Instruction address 0x2aea:0x0fa0, size: 3
					F0_2aea_0fb3_DrawUnitWithStatus(playerID, unitID, x, y);

					// Instruction address 0x2aea:0x0fa6, size: 5
					this.parent.MainCode.F0_11a8_0250_ShowMouse();

					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Draws unit and its statuses (Unit(s) in city production screen are drawn by other function)
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_2aea_0fb3_DrawUnitWithStatus(int playerID, int unitID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_0fb3({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			Unit unit = this.parent.GameData.Players[playerID].Units[unitID];

			// Instruction address 0x2aea:0x0fe2, size: 5
			this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, x, y,
				this.parent.Array_d4ce[64 + (playerID * 32) + unit.TypeID]);

			if ((unit.Status & 0x8) != 0)
			{

				// Instruction address 0x2aea:0x0ffb, size: 5
				this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, x, y, this.parent.Array_d4ce[29]);
			}
			else
			{
				if ((unit.Status & 0x4) != 0)
				{
					// Instruction address 0x2aea:0x103d, size: 5
					this.parent.DrawStringTools.F0_1182_0086_DrawStringWithShadowToScreen0("F", x + 4, y + 7, (byte)((playerID == 1) ? 9 : 15));
				}
			}

			if (playerID == this.parent.GameData.HumanPlayerID && unit.GoToDestination.X != -1)
			{
				// Instruction address 0x2aea:0x1085, size: 5
				this.parent.DrawStringTools.F0_1182_0086_DrawStringWithShadowToScreen0("G", x + 4, y + 7, (byte)((playerID == 1) ? 9 : 15));
			}

			if (((UnitStatusEnum)unit.Status & UnitStatusEnum.SettlerBuildMask) != 0 && this.parent.GameData.Units[unit.TypeID].MovementType != UnitMovementTypeEnum.Air)
			{
				string status = "R";

				if ((unit.Status & 0x40) != 0)
				{
					status = (unit.TypeID != (int)UnitTypeEnum.Settlers) ? "?" : "I";
				}

				if ((unit.Status & 0x80) != 0)
				{
					status = "M";

					if ((unit.Status & 0x40) != 0)
					{
						status = "F";
					}

					if ((unit.Status & 0x2) != 0)
					{
						status = "P";
					}
				}

				// Instruction address 0x2aea:0x1157, size: 5
				this.parent.DrawStringTools.F0_1182_0086_DrawStringWithShadowToScreen0(status, x + 4, y + 7, (byte)((playerID == 1) ? 9 : 15));

				// Instruction address 0x2aea:0x1172, size: 5
				this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(x - 1, y - 1, 15, 15, 7);
			}
		
			if ((unit.Status & 0x1) != 0)
			{
				// Instruction address 0x2aea:0x11a8, size: 5
				this.parent.Graphics.F0_VGA_009a_ReplaceColor(this.parent.Var_aa_Screen0_Rectangle, x, y, 16, 16, 5, 7);

				// Instruction address 0x2aea:0x11c7, size: 5
				this.parent.Graphics.F0_VGA_009a_ReplaceColor(this.parent.Var_aa_Screen0_Rectangle, x, y, 16, 16, 8, 7);
			}
		}

		/// <summary>
		/// Draws map cell with a unit on it if it exists and is visible to the human player
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_2aea_11d4_DrawCellWithUnit(int x, int y)
		{
			// this.oCPU.Log.EnterBlock($"F0_2aea_11d4({x}, {y})");

			// function body
			// Instruction address 0x2aea:0x11e2, size: 3
			F0_2aea_03ba_DrawCell(x, y);

			if (this.parent.Var_dcfc == 0)
			{
				// Instruction address 0x2aea:0x11f6, size: 3
				int unitID = F0_2aea_1458_GetCellActiveUnitID(x, y);

				if (unitID != -1)
				{
					int playerID = this.parent.Var_d20a;

					if (this.parent.Var_d806_DebugFlag || playerID == this.parent.GameData.HumanPlayerID ||
						(this.parent.GameData.Players[playerID].Units[unitID].VisibleByPlayer & (0x1 << this.parent.GameData.HumanPlayerID)) != 0)
					{
						// Instruction address 0x2aea:0x123e, size: 3
						if (!F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.City))
						{
							// Instruction address 0x2aea:0x1250, size: 3
							F0_2aea_125b_DrawWaterUnit((short)playerID, (short)unitID);
						}
					}
				}
			}
		}

		/// <summary>
		/// Draws stack of units or first found water carrier in unit stack on water terrain
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_2aea_125b_DrawWaterUnit(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_125b({playerID}, {unitID})");

			// function body
			// Instruction address 0x2aea:0x127f, size: 3
			Unit unit = this.parent.GameData.Players[playerID].Units[unitID];

			if (unit.NextUnitID != -1 && GetTerrainType(unit.Position.X, unit.Position.Y) == TerrainTypeEnum.Water &&
				this.parent.GameData.Units[unit.TypeID].MovementType != UnitMovementTypeEnum.Water)
			{
				int currentUnitID = unitID;

				do
				{
					currentUnitID = this.parent.GameData.Players[playerID].Units[currentUnitID].NextUnitID;

					if (this.parent.GameData.Units[this.parent.GameData.Players[playerID].Units[currentUnitID].TypeID].MovementType == UnitMovementTypeEnum.Water)
					{
						// Instruction address 0x2aea:0x12e2, size: 3
						F0_2aea_0e29_DrawUnit(playerID, currentUnitID);

						currentUnitID = -1;
					}
				}
				while (currentUnitID != -1 && currentUnitID != unitID);

				if (currentUnitID == unitID)
				{
					// Instruction address 0x2aea:0x131b, size: 3
					F0_2aea_0e29_DrawUnit(playerID, unitID);
				}
			}
			else
			{
				// Instruction address 0x2aea:0x131b, size: 3
				F0_2aea_0e29_DrawUnit(playerID, (short)this.parent.UnitManagement.F0_1866_1122(playerID, unitID));
			}
		}
		#endregion

		#region Map functions
		/// <summary>
		/// Adjusts Map X position
		/// </summary>
		/// <param name="xPos">Map X position to adjust</param>
		/// <returns>Adjusted map X position</returns>
		public int AdjustXPosition(int xPos)
		{
			// function body
			while (xPos < 0)
			{
				xPos += 80;
			}

			while (xPos >= 80)
			{
				xPos -= 80;
			}

			return xPos;
		}

		/// <summary>
		/// Check if the given coordinates are within map bounds
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>True if given coordinates are within map bounds</returns>
		public bool F0_2aea_1326_ValidateMapCoordinates(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1326_CheckMapBounds({xPos}, {yPos})");

			// function body
			x = AdjustXPosition(x);
			return x >= 0 && x < 80 && y >= 0 && y < 50;
		}

		/// <summary>
		/// Check if the given coordinates are within map bounds
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_2aea_1326_ValidateMapCoordinates(GPoint pt)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1326_CheckMapBounds({xPos}, {yPos})");

			// function body
			return F0_2aea_1326_ValidateMapCoordinates(pt.X, pt.Y);
		}

		/// <summary>
		/// Returns terrain type at specified map coordinates.
		/// Only basic terrain types are returned. Terrain addons presence should be checked separately using F0_2aea_1836().
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>terrain ID</returns>
		public TerrainTypeEnum GetTerrainType(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_134a_GetTerrainID({xPos}, {yPos})");
			// function body
			return this.parent.PixelValuesToTerrainTypes[this.gameData.Map.GetPixel(this.AdjustXPosition(x), y)];
		}

		/// <summary>
		/// Returns terrain type at specified map coordinates.
		/// Only basic terrain types are returned. Terrain addons presence should be checked separately using F0_2aea_1836().
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>terrain ID</returns>
		public void SetTerrainType(int x, int y, TerrainTypeEnum terrainType)
		{
			if (terrainType == TerrainTypeEnum.Invalid)
			{
				throw new Exception($"Trying to set invalid TerrainTypeEnum value at position {x}, {y}");
			}

			this.gameData.Map.SetPixel(this.AdjustXPosition(x), y, (byte)this.parent.TerrainTypeToPixelValues[(int)terrainType]);
		}

		public int GetPlayerLandOwnership(int x, int y)
		{
			return this.gameData.Map.GetPixel(80 + this.AdjustXPosition(x), y);
		}

		public void SetPlayerLandOwnership(int x, int y, int playerID)
		{
			this.gameData.Map.SetPixel(80 + this.AdjustXPosition(x), y, (byte)playerID);
		}

		/// <summary>
		/// Gets the city owner
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>ID of a player that owns the city</returns>
		public int F0_2aea_1369_GetCityOwner(int x, int y)
		{
			// function body
			return (this.gameData.Map.GetPixel(x + 160, y) & 0x7);
		}

		/// <summary>
		/// Sets the city owner
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="playerID"></param>
		public void F0_2aea_138c_SetCityOwner(int x, int y, int playerID)
		{
			// function body
			// Instruction address 0x2aea:0x13a2, size: 5
			ushort usOldValue = this.gameData.Map.GetPixel(x + 160, y);

			// Instruction address 0x2aea:0x13c0, size: 3
			this.gameData.Map.SetPixel(x + 160, y, (byte)((usOldValue & 0x8) | playerID), 0);
		}

		/// <summary>
		/// Sets map cell owner player
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_2aea_13cb_SetCellPlayerID(int x, int y, int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_13cb({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x13d8, size: 3
			int activeUnitID = F0_2aea_1458_GetCellActiveUnitID(x, y);

			if (activeUnitID != -1)
			{
				// Instruction address 0x2aea:0x13ed, size: 5
				this.parent.Segment_29f3.F0_29f3_0b66((short)playerID, (short)unitID, (short)activeUnitID);
			}
		
			// Instruction address 0x2aea:0x140b, size: 3
			this.gameData.Map.SetPixel(x + 160, y, (byte)(playerID | 0x8));
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_2aea_1412_SetCellActivePlayerID(int x, int y, int playerID, int unitID)
		{
			this.CPU.Log.EnterBlock($"F0_2aea_1412({playerID}, {unitID}, {x}, {y})");

			// function body			
			if (this.parent.GameData.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2aea:0x1433, size: 5
				this.parent.Segment_29f3.F0_29f3_0bc9(playerID, unitID);
			}
			else
			{
				// Instruction address 0x2aea:0x144f, size: 3
				this.gameData.Map.SetPixel(x + 160, y, (byte)playerID);
			}

			// Far return
			this.CPU.Log.ExitBlock("F0_2aea_1412");
		}

		/// <summary>
		/// Gets the active unit on this map cell
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Unit ID if the unit is present, otherwise -1</returns>
		public int F0_2aea_1458_GetCellActiveUnitID(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1458_GetCellActiveUnitID({x}, {y})");

			// function body
			// Instruction address 0x2aea:0x1466, size: 3
			int playerID = F0_2aea_14e0_GetCellUnitPlayerID(x, y);

			if (playerID != -1)
			{
				for (int i = 0; i < 128; i++)
				{
					Unit unit = this.parent.GameData.Players[playerID].Units[i];

					if (unit.TypeID != -1 && unit.Position.X == x && unit.Position.Y == y)
					{
						this.parent.Var_d7f0 = playerID;
						this.parent.Var_d20a = playerID;

						return i;
					}
				}

				// Instruction address 0x2aea:0x14d3, size: 3
				this.gameData.Map.SetPixel(x + 160, y, 0);
			}

			return -1;
		}

		/// <summary>
		/// Gets the PlayerID of the active unit on this map cell
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Player ID of the active unit present, otherwise -1</returns>
		public int F0_2aea_14e0_GetCellUnitPlayerID(int x, int y)
		{
			// function body
			// Instruction address 0x2aea:0x14f4, size: 5
			int value = this.gameData.Map.GetPixel(x + 160, y);

			if ((value & 8) != 0)
			{
				value &= 0x7;
			}
			else
			{
				value = -1;
			}

			return value;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_2aea_1511_ActiveUnitSetFlag8(int x, int y)
		{
			// function body
			// Instruction address 0x2aea:0x1539, size: 3
			this.gameData.Map.SetPixel(x + 160, y, (byte)((this.gameData.Map.GetPixel(x + 160, y) & 0x7) | 0x8), 0);
		}

		/// <summary>
		/// Checks if this map cell has road improvement built
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_2aea_1570_CheckIfCellHasRoad(int x, int y)
		{
			// function body
			// Instruction address 0x2aea:0x157a, size: 3
			return F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.Road);			
		}

		/// <summary>
		/// Returns terrain improvements at specified map coordinates.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Terrain improvements flags</returns>
		public TerrainImprovementFlagsEnum F0_2aea_1585_GetVisibleTerrainImprovements(int x, int y)
		{
			// function body
			return (TerrainImprovementFlagsEnum)(this.gameData.Map.GetPixel(x, y + 100) |
				(this.gameData.Map.GetPixel(x, y + 150) << 4));
		}

		/// <summary>
		/// Gets visible (to the player) terrain improvements at specified map coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public TerrainImprovementFlagsEnum F0_2aea_15c1_GetTerrainImprovements(int x, int y)
		{
			// function body			
			return (TerrainImprovementFlagsEnum)(this.gameData.Map.GetPixel(x + 80, y + 100) |
				(this.gameData.Map.GetPixel(x + 80, y + 150) << 4));
		}

		/// <summary>
		/// Updates the map cell status for human player
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_2aea_1601_UpdateVisibleCellStatus(int x, int y)
		{
			// function body			
			// Instruction address 0x2aea:0x1627, size: 3
			this.gameData.Map.SetPixel(x + 80, y + 100, (byte)this.gameData.Map.GetPixel(x, y + 100), 0);

			// Instruction address 0x2aea:0x1649, size: 3
			this.gameData.Map.SetPixel(x + 80, y + 150, (byte)this.gameData.Map.GetPixel(x, y + 150), 0);
		}

		/// <summary>
		/// Sets terrain improvements at specified map coordinates.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="improvements"></param>
		public void F0_2aea_1653_SetTerrainImprovements(int x, int y, TerrainImprovementFlagsEnum improvements)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1653({improvements}, {xPos}, {yPos})");

			// function body
			if (improvements == TerrainImprovementFlagsEnum.None)
			{
				// Instruction address 0x2aea:0x16b7, size: 3
				this.gameData.Map.SetPixel(x, y + 100, 0);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.gameData.Map.SetPixel(x, y + 150, 0);
			}
			else if (improvements >= TerrainImprovementFlagsEnum.RailRoad)
			{
				// Instruction address 0x2aea:0x1691, size: 5
				ushort current = this.gameData.Map.GetPixel(x, y + 150);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.gameData.Map.SetPixel(x, y + 150, (byte)(((ushort)improvements >> 4) | current));
			}
			else
			{
				// Instruction address 0x2aea:0x1672, size: 5
				ushort current = this.gameData.Map.GetPixel(x, y + 100);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.gameData.Map.SetPixel(x, y + 100, (byte)(current | (ushort)improvements));
			}

			if (this.parent.Var_6b90 == this.parent.GameData.HumanPlayerID)
			{
				// Instruction address 0x2aea:0x16e5, size: 3
				F0_2aea_1601_UpdateVisibleCellStatus(x, y);
			}		
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="improvements"></param>
		public void F0_2aea_16ee_ClearTerrainImprovements(int x, int y, TerrainImprovementFlagsEnum improvements)
		{
			// function body
			if (((int)improvements & 0xf) != 0)
			{
				// Instruction address 0x2aea:0x171c, size: 3
				this.gameData.Map.SetPixel(x, y + 100, 
					(byte)(((~(int)improvements) & this.gameData.Map.GetPixel(x, y + 100)) & 0xff), 0);
			}

			if ((((int)improvements & 0xf0) != 0))
			{
				// Instruction address 0x2aea:0x1751, size: 3
				this.gameData.Map.SetPixel(x, y + 150, 
					(byte)(((~((int)improvements >> 4)) & this.gameData.Map.GetPixel(x, y + 150)) & 0xff), 0);
			}		
		}

		public void SetMiniMapCell(int x, int y, int value)
		{
			x = AdjustXPosition(x);

			this.gameData.Map.SetPixel(240 + x, y, (byte)value);
		}

		public int GetMiniMapCell(int x, int y)
		{
			x = AdjustXPosition(x);

			return this.gameData.Map.GetPixel(240 + x, y);
		}

		/// <summary>
		/// Finds the city at given coordinates. If the city doesn't exist print error
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int F0_2aea_175a_FindCityHumanPlayer(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_175a({x}, {y})");

			// function body
			// Instruction address 0x2aea:0x1768, size: 3
			for (int i = 0; i < 128; i++)
			{
				City city = this.parent.GameData.Cities[i];

				if (city.StatusFlag != 0xff && city.Position.X == x && city.Position.Y == y)
				{
					int playerID = F0_2aea_1369_GetCityOwner(x, y);

					this.parent.Var_d7f0 = playerID;
					this.parent.Var_d20a = playerID;

					return i;
				}
			}

			// Instruction address 0x2aea:0x17bf, size: 5
			this.parent.Segment_1238.F0_1238_001e_ShowDialog(0x2bc6, 100, 80);

			return -1;
		}

		/// <summary>
		/// Checks if this map cell has special resource available at specified coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>true if this cell has special resource</returns>
		public bool F0_2aea_1836_CellHasSpecialResource(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1836_CellHasSpecialResource({xPos}, {yPos})");
			// function body
			if (y > 1 && y < 48 && 
				(((x & 0x3) * 4) + (y & 0x3)) == ((((x / 4) * 13) + ((y / 4) * 11) + this.parent.GameData.RandomSeed) & 0xf))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Checks if this map cell has 'Minor Tribe Hut' available at specified coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="terrainType"></param>
		public bool F0_2aea_1894_CellHasMinorTribeHut(int x, int y, TerrainTypeEnum terrainType)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1894({terrainType}, {x}, {y})");
			// function body
			// When 'Minor Tribe Hut' is explored the (this.oParent.GameData.MapVisibility[x, y] & 0x1) != 0
			if (y > 1 && y < 48 && terrainType != TerrainTypeEnum.Water && 
				!F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.City) &&
				(this.parent.GameData.MapVisibility[x, y] & 0x1) == 0 &&
				(((x & 0x3) * 4) + (y & 0x3)) == ((((x / 4) * 13) + ((y / 4) * 11) + this.parent.GameData.RandomSeed + 8) & 0x1f))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets map cell group ID at selected coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int F0_2aea_1942_GetGroupID(int x, int y)
		{
			// Instruction address 0x2aea:0x1953, size: 5
			return this.gameData.Map.GetPixel(x, y + 50);
		}

		/// <summary>
		/// Sets map cell group ID at selected coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public void SetGroupID(int x, int y, int groupID)
		{
			this.gameData.Map.SetPixel(x, y + 50, (byte)groupID);
		}

		/// <summary>
		/// Gets the size of the Map group specified by coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public int F0_2aea_195d_GetMapGroupSize(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_195d({x}, {y})");

			// function body
			// Instruction address 0x2aea:0x1967, size: 3
			if (GetTerrainType(x, y) != TerrainTypeEnum.Water)
			{
				// Land
				return this.parent.GameData.Continents[F0_2aea_1942_GetGroupID(x, y)].Size;
			}
			else
			{
				// Oceans
				return this.parent.GameData.Oceans[F0_2aea_1942_GetGroupID(x, y)].Size;
			}
		}

		public int GetBuildLocationScore(int x, int y)
		{
			return this.gameData.Map.GetPixel(x + 80, y + 50);
		}

		public void SetBuildLocationScore(int x, int y, int score)
		{
			this.gameData.Map.SetPixel(x + 80, y + 50, (byte)score);
		}

		public TerrainMapGroupTypeEnum GetGroupType(int x, int y)
		{
			switch (GetTerrainType(x, y))
			{
				case TerrainTypeEnum.Desert:
				case TerrainTypeEnum.Plains:
				case TerrainTypeEnum.Grassland:
				case TerrainTypeEnum.Forest:
				case TerrainTypeEnum.Hills:
				case TerrainTypeEnum.Mountains:
				case TerrainTypeEnum.Tundra:
				case TerrainTypeEnum.Arctic:
				case TerrainTypeEnum.Swamp:
				case TerrainTypeEnum.Jungle:
				case TerrainTypeEnum.River:
					return TerrainMapGroupTypeEnum.Land;

				case TerrainTypeEnum.Water:
					return TerrainMapGroupTypeEnum.Water;

				default:
					return TerrainMapGroupTypeEnum.Land;
			}
		}

		public TerrainMapGroupTypeEnum GetGroupType(GPoint pt)
		{
			switch (GetTerrainType(pt.X, pt.Y))
			{
				case TerrainTypeEnum.Desert:
				case TerrainTypeEnum.Plains:
				case TerrainTypeEnum.Grassland:
				case TerrainTypeEnum.Forest:
				case TerrainTypeEnum.Hills:
				case TerrainTypeEnum.Mountains:
				case TerrainTypeEnum.Tundra:
				case TerrainTypeEnum.Arctic:
				case TerrainTypeEnum.Swamp:
				case TerrainTypeEnum.Jungle:
				case TerrainTypeEnum.River:
					return TerrainMapGroupTypeEnum.Land;

				case TerrainTypeEnum.Water:
					return TerrainMapGroupTypeEnum.Water;

				default:
					return TerrainMapGroupTypeEnum.Land;
			}
		}

		/// <summary>
		/// Calculate the shortest map distance (number of moves) between two points in a two dimensional space (Chebyshev distance)
		/// </summary>
		/// <param name="x">The position of the start X coordinate</param>
		/// <param name="y">The position of the start Y coordinate</param>
		/// <param name="x1">The position of the destination X coordinate</param>
		/// <param name="y1">The position of the destination Y coordinate</param>
		/// <returns>The shortest distance (number of moves in a two dimensional space)</returns>
		public int GetDistance(int x, int y, int x1, int y1)
		{
			return GetDistance(new GPoint(x, y), new GPoint(x1, y1));
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

			if (size.Width >= MapManagement.XMedian)
			{
				size.Width = MapManagement.Size.Width - size.Width;
			}

			return Math.Max(size.Width, size.Height);
		}

		public int GetMoveOffset(GPoint offset)
		{
			int offsetIndex = -1;

			GPoint[] moveDirections = this.parent.MoveDirections;

			for (int i = 0; i < moveDirections.Length; i++)
			{
				if (moveDirections[i] == offset)
				{
					offsetIndex = i;
					break;
				}
			}

			return offsetIndex;
		}
		#endregion

		private struct CityInfo
		{
			public readonly GPoint ScreenPos;
			public readonly int CityID;

			public CityInfo(int x, int y, int cityID)
			{
				this.ScreenPos = new GPoint(x, y);
				this.CityID = cityID;
			}
		}
	}
}
