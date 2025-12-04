using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class MapManagement
	{
		// The Map is currently kept as a bitmap, the layer number, description and position table following:
		// Layer 1: Terrain data (TerrainTypeEnum), 0:0
		// Layer 2: Per-Civ land occupation, 80:0
		//
		// Layer 3: Terrain groups, the land and water cells have separate group arrays, 0:50
		// Layer 4: Terrain-based land appeal for the computer to build cities, 80:50
		//
		// Layer 5: Same as layer 6, but only what's visible to the player, 0:100
		// Layer 6: Terrain improvements(irrigation, mining, roads), 80:100
		//
		// Layer 7: Same as layer 8, but only what's visible to the player, 0:150
		// Layer 8: Railroads, roads, rivers, fortresses, 80:150
		//
		// Layer 9: Per-Civ land exploration and active units, 160:0
		// Layer 10: Mini-map render, 240:0

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

		private OpenCiv1Game oParent;
		private VCPU oCPU;

		// Local variables used exclusively inside this section

		/// <summary>Number of cities currently visible on the screen</summary>
		private List<CityInfo> VisibleCities = new List<CityInfo>();

		public MapManagement(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// Draws visible Map to screen
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_2aea_0008_DrawVisibleMap(int playerID, int x, int y)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0008({playerID}, {x}, {y})");

			// function body
			// Instruction address 0x2aea:0x000f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x1ae0, 0x0);

			this.oParent.Segment_1238.F0_1238_0fea();
			this.oParent.Segment_1238.F0_1238_107e();

			int tempValue = this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd20a);

			this.oParent.Var_d4cc_MapViewX = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x);
			this.oParent.Var_d75e_MapViewY = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(y, 0, 38);

			// Another error, the code modified first parameter (playerID) to a
			// Visibility Mask and that conflicts with other code which expects playerID.
			int mapPlayerVisibilityMask = (0x1 << playerID);

			this.VisibleCities.Clear();

			// redraw Visible Map on screen
			int cellXPos;
			int cellYPos;
			int cellDrawOrder = this.oParent.CAPI.RNG.Next(256);

			for (int i = 0; i < 256; i++)
			{
				cellXPos = (cellDrawOrder & 0xf);
				cellYPos = (cellDrawOrder & 0xf0) >> 4;

				if (cellYPos < 12 && cellXPos < 15)
				{
					if (this.oParent.Var_d806_DebugFlag ||
						(this.oParent.GameData.MapVisibility[this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(cellXPos + this.oParent.Var_d4cc_MapViewX),
							cellYPos + this.oParent.Var_d75e_MapViewY] & mapPlayerVisibilityMask) != 0)
					{
						// Instruction address 0x2aea:0x0122, size: 3
						F0_2aea_11d4_DrawCellWithUnit(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(cellXPos + this.oParent.Var_d4cc_MapViewX), cellYPos + this.oParent.Var_d75e_MapViewY);
					}
					else
					{
						// Instruction address 0x2aea:0x0094, size: 5
						this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, (cellXPos * 16) + 80, (cellYPos * 16) + 8, 16, 16, 0);
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

				this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

				// Instruction address 0x2aea:0x0148, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityInfo.CityID);

				// Instruction address 0x2aea:0x015c, size: 5
				this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, (ushort)(327 - cityInfo.ScreenPos.X));

				// Instruction address 0x2aea:0x018d, size: 5
				this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06,
					this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(cityInfo.ScreenPos.X - 8, 80, 999), cityInfo.ScreenPos.Y + 16, 11);
			}

			int xMap = x - 32;
			int yMap = y - 19;
			int mapXSrc;
			int mapYSrc;
			int mapXDst;
			int mapYDst;
			int mapYOffset;

			// Instruction address 0x2aea:0x01b9, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Navigation))
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

			this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x6ed6, (short)xMap);
			this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x70ea, (short)yMap);

			// Instruction address 0x2aea:0x0233, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 8, 80, 50, 0);

			if (this.oParent.Var_d806_DebugFlag)
			{
				// Instruction address 0x2aea:0x024c, size: 5
				xMap = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(xMap, 0, 16);
				this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x6ed6, (short)xMap);

				// Instruction address 0x2aea:0x0264, size: 5
				yMap = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(yMap, 0, 65530);
				this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0x70ea, (short)yMap);

				// Instruction address 0x2aea:0x02da, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, xMap, yMap, 80, 50, this.oParent.Var_aa_Rectangle, 0, 8);
			}
			else
			{
				// Instruction address 0x2aea:0x02af, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, mapXSrc + 240, mapYSrc, mapXDst, mapYDst,
					this.oParent.Var_aa_Rectangle, 0, mapYOffset + 8);

				if (mapXDst < 80)
				{
					// Instruction address 0x2aea:0x02da, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 240, mapYSrc, 80 - mapXDst, mapYDst,
						this.oParent.Var_aa_Rectangle, mapXDst, mapYOffset + 8);
				}
			}

			for (int i = 0; i < 128; i++)
			{
				City city = this.oParent.GameData.Cities[i];

				if (city.StatusFlag != 0xff && (city.VisibleSize != 0 || city.PlayerID == this.oParent.GameData.HumanPlayerID))
				{
					// Instruction address 0x2aea:0x031a, size: 5
					cellXPos = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(city.Position.X - mapXSrc);
					cellYPos = city.Position.Y - mapYSrc + mapYOffset;

					if (cellYPos >= 0 && cellYPos < 50)
					{
						// Instruction address 0x2aea:0x0355, size: 3
						this.oParent.CommonTools.F0_1000_104f_SetPixel(cellXPos, cellYPos + 8,
							this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0x1946 + (city.PlayerID * 2))));
					}
				}
			}

			// Instruction address 0x2aea:0x037c, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a66_DrawShadowRectangle(0, 8, 79, 49, 15, 8);

			// Instruction address 0x2aea:0x03a2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(x - xMap - 1, y - yMap + 7, 17, 10, 15);

			this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0xd20a, (short)tempValue);

			// Instruction address 0x2aea:0x03b0, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0008");
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
			int scrX = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x - this.oParent.Var_d4cc_MapViewX) * 16 + 80;
			int scrY = (y - this.oParent.Var_d75e_MapViewY) * 16 + 8;

			if (scrX < 80 || scrX >= 320 || scrY < 8 || scrY > 192)
			{
				// if cells screen coordinates are outside of actual screen

				return false;
			}
			else
			{
				TerrainTypeEnum terrainType = F0_2aea_134a_GetTerrainType(x, y);
				TerrainImprovementFlagsEnum terrainImprovements = F0_2aea_15c1_GetTerrainImprovements(x, y);

				if (this.oParent.Var_d806_DebugFlag)
				{
					// Instruction address 0x2aea:0x04a3, size: 3
					terrainImprovements = F0_2aea_1585_GetVisibleTerrainImprovements(x, y);
				}
			
				// Instruction address 0x2aea:0x04ac, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();

				if (terrainType == TerrainTypeEnum.Water)
				{
					// Draw ocean, coastal cells and river deltas
					int mask = 0;

					if (this.oParent.Var_d762 == 0)
					{
						for (int i = 1; i < 9; i += 2)
						{
							mask >>= 1;

							GPoint direction = this.oParent.MoveOffsets[i];

							// Instruction address 0x2aea:0x04f0, size: 3
							if (F0_2aea_134a_GetTerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), y + direction.Y) != TerrainTypeEnum.Water &&
								F0_2aea_1326_CheckMapCoordinates(0, y + direction.Y))
							{
								mask |= 0x8;
							}
						}

						// Instruction address 0x2aea:0x053e, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19fc_Rectangle, mask * 16, 64, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
					}
					else
					{
						for (int i = 1; i < 9; i++)
						{
							mask >>= 1;

							GPoint direction = this.oParent.MoveOffsets[i];

							// Instruction address 0x2aea:0x0570, size: 3
							if (F0_2aea_134a_GetTerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), y + direction.Y) != TerrainTypeEnum.Water &&
								F0_2aea_1326_CheckMapCoordinates(0, y + direction.Y))
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
								this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + ((i & 0x1) * 8), scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd294 + 0x8 * ((bitmapMask >> (i * 2)) & 0x7) + i * 2)));
							}
							else
							{
								// Instruction address 0x2aea:0x05f4, size: 5
								this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX - ((i & 0x1) * 8) + 8, scrY + 8,
									this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd294 + 0x8 * ((bitmapMask >> (i * 2)) & 0x7) + i * 2)));
							}
						}

						switch (mask)
						{
							case 0x1c:
								// Instruction address 0x2aea:0x0656, size: 5
								this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 224, 100, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
								break;

							case 0xc1:
								// Instruction address 0x2aea:0x0680, size: 5
								this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 240, 100, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
								break;

							case 0x7:
								// Instruction address 0x2aea:0x06a9, size: 5
								this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 256, 100, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
								break;

							case 0x70:
								// Instruction address 0x2aea:0x06d2, size: 5
								this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 272, 100, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
								break;

							case 0x8f:
								// Instruction address 0x2aea:0x06fc, size: 5
								this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 288, 100, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
								break;

							case 0xf8:
								// Instruction address 0x2aea:0x0726, size: 5
								this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 304, 100, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
								break;
						}

						// Draw river deltas on top of coastal cells
						for (int i = 1; i < 9; i += 2)
						{
							GPoint direction = this.oParent.MoveOffsets[i];

							// Instruction address 0x2aea:0x0752, size: 3
							if (F0_2aea_134a_GetTerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), y + direction.Y) == TerrainTypeEnum.River)
							{
								// Instruction address 0x2aea:0x0777, size: 5
								this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd2d4 + i - 1)));
							}
						}
					}
				}

				if (terrainType != TerrainTypeEnum.Water)
				{
					// Draw grassland background for land cells
					if (this.oParent.Var_d762 == 0)
					{
						// Instruction address 0x2aea:0x07cd, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19fc_Rectangle, 0, 80, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
					}
					else
					{
						// Instruction address 0x2aea:0x07cd, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 256, 120, 16, 16, this.oParent.Var_aa_Rectangle, scrX, scrY);
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Irrigation) &&
					terrainType != TerrainTypeEnum.Water && 
					this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xdcfc) == 0 &&
					!terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
				{
					// Draw irrigation
					// Instruction address 0x2aea:0x07f8, size: 5
					this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (4 << 1))));
				}

				if (terrainType == TerrainTypeEnum.River)
				{
					// Draw rivers
					int mask = 0;

					for (int i = 1; i < 9; i += 2)
					{
						mask >>= 1;

						GPoint direction = this.oParent.MoveOffsets[i];
						TerrainTypeEnum terrainType1 = F0_2aea_134a_GetTerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), y + direction.Y);

						if (terrainType1 == TerrainTypeEnum.Water || terrainType1 == TerrainTypeEnum.River)
						{
							mask |= 0x8;
						}
					}

					if (this.oParent.Var_d762 == 0 || (this.oParent.Graphics.F0_VGA_038c_GetPixel(2, x, y + 150) & 0x8) != 0)
					{
						mask += 0x10;
					}

					// Instruction address 0x2aea:0x0885, size: 5
					this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0x6dfe + (mask << 1))));
				}

				if (terrainType != TerrainTypeEnum.Water && terrainType != TerrainTypeEnum.River)
				{
					// Blend seams between cells with the same terrain types
					if (this.oParent.Var_d762 != 0)
					{
						int mask = 0;

						for (int i = 1; i < 9; i += 2)
						{
							mask >>= 1;

							GPoint direction = this.oParent.MoveOffsets[i];

							if (F0_2aea_134a_GetTerrainType(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), y + direction.Y) == terrainType &&
								F0_2aea_1326_CheckMapCoordinates(0, y + direction.Y))
							{
								mask |= 0x8;
							}
						}

						// Instruction address 0x2aea:0x091e, size: 5
						this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
							this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xb886 + ((int)terrainType * 32) + (mask * 2))));

						if (terrainType == TerrainTypeEnum.Grassland && (((7 * x) + (11 * y)) & 0x2) == 0)
						{
							// Draw grassland tiles with production bonus
							// Instruction address 0x2aea:0x0996, size: 5
							this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 4, scrY + 4, 
								this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xb880));
						}
					}
					else
					{
						if (terrainType == TerrainTypeEnum.Grassland)
						{
							// Instruction address 0x2aea:0x0996, size: 5
							this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
								this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xb886 + (int)terrainType * 32 + ((((7 * x) + (11 * y)) & 0x2) >> 1) * 2)));
						}
						else
						{
							// Instruction address 0x2aea:0x0996, size: 5
							this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
								this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xb886 + (int)terrainType * 32 + ((x + y) & 0x1) * 2)));
						}
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Pollution))
				{
					// Draw pollution

					if (this.oParent.Var_d762 == 0)
					{
						// Instruction address 0x2aea:0x09dc, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, scrX, scrY, 16, 16, 2, 0);

						// Instruction address 0x2aea:0x09fb, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, scrX, scrY, 16, 16, 10, 15);

						// Instruction address 0x2aea:0x0a1a, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, scrX, scrY, 16, 16, 9, 8);

						// Instruction address 0x2aea:0x0a38, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, scrX, scrY, 16, 16, 11, 0);
					}
					else
					{
						// Instruction address 0x2aea:0x09bc, size: 5
						this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
							this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xd4da));
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Road))
				{
					// Draw roads and railroads
					int roadIcon = (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.RailRoad)) ? 0 : 6;

					for (int i = 1; i < 9; i++)
					{
						GPoint direction = this.oParent.MoveOffsets[i];

						// Instruction address 0x2aea:0x0a9a, size: 3
						TerrainImprovementFlagsEnum terrainImprovements1 =
							F0_2aea_15c1_GetTerrainImprovements(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), y + direction.Y);

						if (terrainImprovements1.HasFlag(TerrainImprovementFlagsEnum.Road))
						{
							roadIcon = -1;

							TerrainImprovementFlagsEnum railRoadOrCity = TerrainImprovementFlagsEnum.RailRoad | TerrainImprovementFlagsEnum.City;

							if ((terrainImprovements & railRoadOrCity) == 0 || (terrainImprovements1 & railRoadOrCity) == 0)
							{
								// Instruction address 0x2aea:0x0a73, size: 5
								this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xb278 + i * 2)));
							}
							else
							{
								// Instruction address 0x2aea:0x0a73, size: 5
								this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xb298 + i * 2)));
							}
						}
					}

					if (roadIcon != -1)
					{
						// Draw single cell road or railroad

						// Instruction address 0x2aea:0x0ae0, size: 5
						this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, scrX + 7, scrY + 7, 2, 2, (ushort)roadIcon);
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Mines) &&
					this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xdcfc) == 0)
				{
					// Draw mines

					// Instruction address 0x2aea:0x0aff, size: 5
					this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (5 << 1))));
				}

				// Instruction address 0x2aea:0x0b11, size: 3
				if (F0_2aea_1836_CellHasSpecialResource(x, y))
				{
					// Draw special resources

					// Instruction address 0x2aea:0x0b28, size: 5
					this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.UInt16,	(ushort)(0xd4ce + (((int)terrainType + 16) << 1))));
				}

				// Instruction address 0x2aea:0x0b3a, size: 3
				if (F0_2aea_1894_CellHasMinorTribeHut(terrainType, x, y))
				{
					// Draw Minot tribe hut

					// Instruction address 0x2aea:0x0b4e, size: 5
					this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (0x1f << 1))));
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Fortress))
				{
					// Draw fortresses

					// Instruction address 0x2aea:0x0b66, size: 5
					this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (0x1e << 1))));
				}

				if (!this.oParent.Var_d806_DebugFlag)
				{
					// Draw fog of war borders

					for (int i = 1; i < 9; i += 2)
					{
						GPoint direction = this.oParent.MoveOffsets[i];

						// Instruction address 0x2aea:0x0b87, size: 5
						int yTemp = y + direction.Y;
						int visibilityMask = (yTemp >= 0 && yTemp < 50) ?
							this.oParent.GameData.MapVisibility[this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), yTemp] : 0;

						if ((visibilityMask & (0x1 << this.oParent.GameData.HumanPlayerID)) == 0)
						{
							// Instruction address 0x2aea:0x0bce, size: 5
							this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
								this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0x7eec + i - 1)));
						}
					}
				}

				// Instruction address 0x2aea:0x0be7, size: 3
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1e), F0_2aea_1369_GetCityOwner(x, y));

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City) && this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xdcfc) == 0)
				{
					// Draw city

					// Instruction address 0x2aea:0x0c09, size: 5
					int cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(x, y);

					if (cityID != -1)
					{
						// Draw city white borders at the left and bottom sides
						City city = this.oParent.GameData.Cities[cityID];

						if (city.PlayerID == this.oParent.GameData.HumanPlayerID || city.VisibleSize > 0 || this.oParent.Var_d806_DebugFlag)
						{
							// Instruction address 0x2aea:0x0c4b, size: 5
							this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(scrX + 1, scrY + 1, 13, 13, 15);

							// Draw city dark borders at the top and right sides

							// Instruction address 0x2aea:0x0c7d, size: 5
							this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(scrX + 2, scrY + 1, 12, 12,
								this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0x1956 + (city.PlayerID * 2))));

							// Draw city main color

							// Instruction address 0x2aea:0x0cac, size: 5
							this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, scrX + 2, scrY + 2, 12, 12,
								this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0x1946 + (city.PlayerID * 2))));

							// Draw city 'streets'

							// Instruction address 0x2aea:0x0cba, size: 5
							this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 1, scrY + 1,
								this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (0x1c << 1))));

							// Color city 'streets' according to player nation

							// Instruction address 0x2aea:0x0ce5, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, scrX + 2, scrY + 2, 12, 12, 5,
								(byte)this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0x1956 + (city.PlayerID * 2))));

							int citySize = (city.PlayerID == this.oParent.GameData.HumanPlayerID || this.oParent.Var_d806_DebugFlag) ?
									city.ActualSize : city.VisibleSize;

							this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

							// Instruction address 0x2aea:0x0d42, size: 5
							this.oParent.CAPI.strcat(0xba06, this.oParent.CAPI.itoa(citySize, 10));

							if ((city.StatusFlag & 0x1) != 0)
							{
								// Draw city disorder

								// Instruction address 0x2aea:0x0d66, size: 5
								this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 5, scrY + 2,
									this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6e9e));
							}
							else
							{
								// Draw city size

								// Instruction address 0x2aea:0x0d8d, size: 5
								this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, ((citySize < 10) ? 6 : 3) + scrX, scrY + 5, 0);
							}

							// Instruction address 0x2aea:0x0d9c, size: 3
							if (F0_2aea_1458_GetCellActiveUnitID(x, y) != -1 || city.Unknown[0] != -1)
							{
								// Draw city defenders

								// Instruction address 0x2aea:0x0dc2, size: 5
								this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(scrX, scrY, 15, 15, 0);
							}

							if ((city.ImprovementFlags0 & 0x80) != 0)
							{
								// Draw city walls

								// Instruction address 0x2aea:0x0de7, size: 5
								this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 1, scrY + 1,
									this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (0x1d << 1))));
							}

							this.VisibleCities.Add(new CityInfo(scrX, scrY, cityID));
						}
					}
				}

				// Instruction address 0x2aea:0x0e1b, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();
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
			Unit unit = this.oParent.GameData.Players[playerID].Units[unitID];
			int x = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(unit.Position.X - this.oParent.Var_d4cc_MapViewX) * 16 + 80;
			int y = (unit.Position.Y - this.oParent.Var_d75e_MapViewY) * 16 + 8;

			if (x >= 80 && x < 320 && y >= 8 && y < 193)
			{
				if ((unit.Status & 0x1) == 0 || F0_2aea_134a_GetTerrainType(unit.Position.X, unit.Position.Y) != TerrainTypeEnum.Water ||
					this.oParent.GameData.UnitTypes[unit.TypeID].MovementType == UnitMovementTypeEnum.Water)
				{
					// Instruction address 0x2aea:0x0f57, size: 5
					this.oParent.Segment_11a8.F0_11a8_0268();

					if (unit.NextUnitID != -1)
					{
						// There are multiple units stacked

						this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, x + 1, y + 1,
							this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (((playerID * 32) + unit.TypeID + 64) * 2))));
					}

					// Instruction address 0x2aea:0x0fa0, size: 3
					F0_2aea_0fb3_DrawUnitWithStatus(playerID, unitID, x, y);

					// Instruction address 0x2aea:0x0fa6, size: 5
					this.oParent.Segment_11a8.F0_11a8_0250();

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
			Unit unit = this.oParent.GameData.Players[playerID].Units[unitID];

			// Instruction address 0x2aea:0x0fe2, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, x, y,
				this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (((playerID * 32) + unit.TypeID + 64) * 2))));

			if ((unit.Status & 0x8) != 0)
			{

				// Instruction address 0x2aea:0x0ffb, size: 5
				this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, x, y,
					this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0xd4ce + (29 * 2))));
			}
			else
			{
				if ((unit.Status & 0x4) != 0)
				{
					// Instruction address 0x2aea:0x103d, size: 5
					this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow("F", x + 4, y + 7, (byte)((playerID == 1) ? 9 : 15));
				}
			}

			if (playerID == this.oParent.GameData.HumanPlayerID && unit.GoToDestination.X != -1)
			{
				// Instruction address 0x2aea:0x1085, size: 5
				this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow("G", x + 4, y + 7, (byte)((playerID == 1) ? 9 : 15));
			}

			if (((UnitStatusEnum)unit.Status & UnitStatusEnum.SettlerBuildMask) != 0 && this.oParent.GameData.UnitTypes[unit.TypeID].MovementType != UnitMovementTypeEnum.Air)
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
				this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(status, x + 4, y + 7, (byte)((playerID == 1) ? 9 : 15));

				// Instruction address 0x2aea:0x1172, size: 5
				this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(x - 1, y - 1, 15, 15, 7);
			}
		
			if ((unit.Status & 0x1) != 0)
			{
				// Instruction address 0x2aea:0x11a8, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, x, y, 16, 16, 5, 7);

				// Instruction address 0x2aea:0x11c7, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, x, y, 16, 16, 8, 7);
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

			if (this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xdcfc) == 0)
			{
				// Instruction address 0x2aea:0x11f6, size: 3
				int unitID = F0_2aea_1458_GetCellActiveUnitID(x, y);

				if (unitID != -1)
				{
					int playerID = this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xd20a);

					if (this.oParent.Var_d806_DebugFlag || playerID == this.oParent.GameData.HumanPlayerID ||
						(this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0)
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
		public void F0_2aea_125b_DrawWaterUnit(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_125b({playerID}, {unitID})");

			// function body
			// Instruction address 0x2aea:0x127f, size: 3
			Unit unit = this.oParent.GameData.Players[playerID].Units[unitID];

			if (unit.NextUnitID != -1 && F0_2aea_134a_GetTerrainType(unit.Position.X, unit.Position.Y) == TerrainTypeEnum.Water &&
				this.oParent.GameData.UnitTypes[unit.TypeID].MovementType != UnitMovementTypeEnum.Water)
			{
				int currentUnitID = unitID;

				do
				{
					currentUnitID = this.oParent.GameData.Players[playerID].Units[currentUnitID].NextUnitID;

					if (this.oParent.GameData.UnitTypes[this.oParent.GameData.Players[playerID].Units[currentUnitID].TypeID].MovementType == UnitMovementTypeEnum.Water)
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
				F0_2aea_0e29_DrawUnit(playerID, (short)this.oParent.Segment_1866.F0_1866_1122((short)playerID, (short)unitID));
			}
		}

		/// <summary>
		/// Check if the given coordinates are within map bounds
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_2aea_1326_CheckMapCoordinates(int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1326_CheckMapBounds({xPos}, {yPos})");

			// function body
			return x >= 0 && x < 80 && y >= 0 && y < 50;
		}

		/// <summary>
		/// Returns terrain type at specified map coordinates.
		/// Only basic terrain types are returned. Terrain addons presence should be checked separately using F0_2aea_1836().
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns>terrain ID</returns>
		public TerrainTypeEnum F0_2aea_134a_GetTerrainType(int xPos, int yPos)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_134a_GetTerrainID({xPos}, {yPos})");
			// function body
			// Instruction address 0x2aea:0x1357, size: 5
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(0x2ba6 + (this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos) * 2)));

			return (TerrainTypeEnum)this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// Gets the city owner
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns>ID of a player that owns the city</returns>
		public ushort F0_2aea_1369_GetCityOwner(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x137d, size: 5
			ushort value = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos);

			this.oCPU.AX.UInt16 = (ushort)(value & 0x7);

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// Sets the city owner
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_138c_SetCityOwner(short playerID, int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x13a2, size: 5
			ushort usOldValue = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos);

			// Instruction address 0x2aea:0x13c0, size: 3
			this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 160, yPos, (byte)((usOldValue & 8) + playerID), 0);
		}

		/// <summary>
		/// Adjusts currently active unit on map cell
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_2aea_13cb(int playerID, int unitID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_13cb({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x13d8, size: 3
			int activeUnitID = F0_2aea_1458_GetCellActiveUnitID(x, y);

			if (activeUnitID != -1)
			{
				// Instruction address 0x2aea:0x13ed, size: 5
				this.oParent.Segment_29f3.F0_29f3_0b66((short)playerID, (short)unitID, (short)activeUnitID);
			}
		
			// Instruction address 0x2aea:0x140b, size: 3
			this.oParent.CommonTools.F0_1000_104f_SetPixel(2, x + 160, y, (ushort)(playerID | 0x8));
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1412(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1412({playerID}, {unitID}, {xPos}, {yPos})");

			// function body			
			if (this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2aea:0x1433, size: 5
				this.oParent.Segment_29f3.F0_29f3_0bc9(playerID, unitID);
			}
			else
			{
				// Instruction address 0x2aea:0x144f, size: 3
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, xPos + 160, yPos, (byte)playerID);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1412");
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
					Unit unit = this.oParent.GameData.Players[playerID].Units[i];

					if (unit.TypeID != -1 && unit.Position.X == x && unit.Position.Y == y)
					{
						this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0xd7f0, (short)playerID);
						this.oCPU.WriteInt16(this.oCPU.DS.UInt16, 0xd20a, (short)playerID);

						return i;
					}
				}

				// Instruction address 0x2aea:0x14d3, size: 3
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, x + 160, y, 0);
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
			int value = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, x + 160, y);

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
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1511_ActiveUnitSetFlag8(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x1539, size: 3
			this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 160, yPos, (byte)((this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos) & 0x7) | 0x8), 0);
		}

		/// <summary>
		/// Checks if this map cell has road improvement built
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_2aea_1570_CheckCellHasRoadBuilt(int x, int y)
		{
			// function body
			// Instruction address 0x2aea:0x157a, size: 3
			return F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.Road);			
		}

		/// <summary>
		/// Returns terrain improvements at specified map coordinates.
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns>Terrain improvements flags</returns>
		public TerrainImprovementFlagsEnum F0_2aea_1585_GetVisibleTerrainImprovements(int xPos, int yPos)
		{
			// function body
			// Preserve compatibility
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100) | 
				(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150) << 4));

			return (TerrainImprovementFlagsEnum)this.oCPU.AX.UInt16;
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
			// Instruction address 0x2aea:0x15ef, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, x + 80, y + 100) | 
				(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, x + 80, y + 150) << 4));
			
			return (TerrainImprovementFlagsEnum)this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// Updates the map cell status for human player
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1601_UpdateVisbleCellStatus(int xPos, int yPos)
		{
			// function body			
			// Instruction address 0x2aea:0x1627, size: 3
			this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 100, (byte)this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100), 0);

			// Instruction address 0x2aea:0x1649, size: 3
			this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 150, (byte)this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150), 0);
		}

		/// <summary>
		/// Sets terrain improvements at specified map coordinates.
		/// </summary>
		/// <param name="improvements"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum improvements, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1653({improvements}, {xPos}, {yPos})");

			// function body
			if (improvements == TerrainImprovementFlagsEnum.None)
			{
				// Instruction address 0x2aea:0x16b7, size: 3
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, xPos, yPos + 100, 0);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, xPos, yPos + 150, 0);
			}
			else if (improvements >= TerrainImprovementFlagsEnum.RailRoad)
			{
				// Instruction address 0x2aea:0x1691, size: 5
				ushort current = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, xPos, yPos + 150, (ushort)(((ushort)improvements >> 4) | current));
			}
			else
			{
				// Instruction address 0x2aea:0x1672, size: 5
				ushort current = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.CommonTools.F0_1000_104f_SetPixel(2, xPos, yPos + 100, (ushort)(current | (ushort)improvements));
			}

			if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0x6b90) == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x2aea:0x16e5, size: 3
				F0_2aea_1601_UpdateVisbleCellStatus(xPos, yPos);
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1653");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_16ee(ushort param1, int xPos, int yPos)
		{
			// function body
			if ((param1 & 0xf) != 0)
			{
				// Instruction address 0x2aea:0x1707, size: 5
				this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100);

				// Instruction address 0x2aea:0x171c, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, (byte)(((~param1) & this.oCPU.AX.UInt16) & 0xff), 0);
			}

			if (((param1 & 0xf0) != 0))
			{
				// Instruction address 0x2aea:0x1738, size: 5
				this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150);

				// Instruction address 0x2aea:0x1751, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, (byte)(((~(param1 >> 4)) & this.oCPU.AX.UInt16) & 0xff), 0);
			}		
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_175a(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_175a({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x2aea:0x1768, size: 3
			F0_2aea_1369_GetCityOwner(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			goto L177b;

		L1778:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))));

		L177b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x80);
			if (this.oCPU.Flags.GE) goto L17b3;

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			if (this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))].StatusFlag == 0xff ||
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))].Position.X != xPos ||
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))].Position.Y != yPos)
				goto L1778;

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0xd7f0, this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0xd20a, this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			goto L17ca;

		L17b3:
			// Instruction address 0x2aea:0x17bf, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x2bc6, 100, 80);

			this.oCPU.AX.UInt16 = 0xffff;

		L17ca:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_175a");

			return this.oCPU.AX.UInt16;
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
				(((x & 0x3) * 4) + (y & 0x3)) == ((((x / 4) * 13) + ((y / 4) * 11) + this.oParent.GameData.RandomSeed) & 0xf))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Checks if this map cell has 'Minor Tribe Hut' available at specified coordinates
		/// </summary>
		/// <param name="terrainType"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public bool F0_2aea_1894_CellHasMinorTribeHut(TerrainTypeEnum terrainType, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_2aea_1894({terrainType}, {x}, {y})");
			// function body
			if (y > 1 && y < 48 && 
				terrainType != TerrainTypeEnum.Water && !F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.City) &&
				(this.oParent.GameData.MapVisibility[x, y] & 0x1) == 0 &&
				(((x & 0x3) * 4) + (y & 0x3)) == ((((x / 4) * 13) + ((y / 4) * 11) + this.oParent.GameData.RandomSeed + 8) & 0x1f))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Gets map cell group ID
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1942_GetCellGroupID(int xPos, int yPos)
		{
			// Instruction address 0x2aea:0x1953, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 50);

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// Gets the size of the Map group specified by coordinates
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public ushort F0_2aea_195d_GetMapGroupSize(int x, int y)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_195d({x}, {y})");

			// function body
			// Instruction address 0x2aea:0x1967, size: 3
			if (F0_2aea_134a_GetTerrainType(x, y) != TerrainTypeEnum.Water)
			{
				// Instruction address 0x2aea:0x1979, size: 3
				F0_2aea_1942_GetCellGroupID(x, y);

				// Land
				this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Continents[this.oCPU.AX.UInt16].Size;
			}
			else
			{
				// Instruction address 0x2aea:0x1990, size: 3
				F0_2aea_1942_GetCellGroupID(x, y);

				// Oceans
				this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Oceans[this.oCPU.AX.UInt16].Size;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_195d");

			return this.oCPU.AX.UInt16;
		}
	}
}
