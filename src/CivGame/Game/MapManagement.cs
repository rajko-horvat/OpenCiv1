using IRB.VirtualCPU;
using OpenCiv1.GPU;
using System;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class MapManagement
	{
		// The Map is currently kept as a bitmap, the layer number, description and position table following:
		// Layer 1: Terrain data (TerrainTypeEnum), 0:0
		// Layer 2: Per-Civ land occupation, 80:0
		//
		// Layer 3: Area segmentation, with identifiers for separate land masses and inner seas, 0:50
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

		private CivGame oParent;
		private VCPU oCPU;

		public MapManagement(CivGame parent)
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

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1ae0, 0x0);

			this.oParent.Segment_1238.F0_1238_0fea();
			this.oParent.Segment_1238.F0_1238_107e();

			int tempValue = this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a);

			this.oParent.Var_d4cc_MapXCenter = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x);
			this.oParent.Var_d75e_MapYCenter = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(y, 0, 38);

			// Another error, the code modified first parameter (playerID) to a
			// Visibility Mask and that conflicts with other code which expects playerID.
			int mapPlayerVisibilityMask = (0x1 << playerID);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6c96, 0x0);

			// redraw Visible Map on screen
			int cellXPos;
			int cellYPos;
			int cellDrawOrder = this.oParent.MSCAPI.RNG.Next(256);

			for (int i = 0; i < 256; i++)
			{
				cellXPos = (cellDrawOrder & 0xf);
				cellYPos = (cellDrawOrder & 0xf0) >> 4;

				if (cellYPos < 12 && cellXPos < 15)
				{
					if (this.oParent.Var_d806_DebugFlag ||
						(this.oParent.CivState.MapVisibility[this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(cellXPos + this.oParent.Var_d4cc_MapXCenter),
							cellYPos + this.oParent.Var_d75e_MapYCenter] & mapPlayerVisibilityMask) != 0)
					{
						// Instruction address 0x2aea:0x0122, size: 3
						F0_2aea_11d4(this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(cellXPos + this.oParent.Var_d4cc_MapXCenter), cellYPos + this.oParent.Var_d75e_MapYCenter);
					}
					else
					{
						// Instruction address 0x2aea:0x0094, size: 5
						this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, (cellXPos * 16) + 80, (cellYPos * 16) + 8, 16, 16, 0);
					}
				}

				cellDrawOrder = (5 * cellDrawOrder) + 1;

				// A bit of delay should be introduced in the future so that appearing map cells effect can be seen
				//this.oParent.Segment_1000.F0_1182_0134_WaitTimer(1);
				//Thread.Sleep(2);
			}

			// Draw city names
			for (int i = 0; i < this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6c96); i++)
			{
				if (this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(0x6e3e + (i * 2))) < 184)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

					// Instruction address 0x2aea:0x0148, size: 5
					this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(0xdf20 + (i * 2))));

					// Instruction address 0x2aea:0x015c, size: 5
					this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, (ushort)(327 - this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x6dac + (i * 2)))));

					// Instruction address 0x2aea:0x018d, size: 5
					this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06,
						this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(0x6dac + (i * 2))) - 8, 80, 999),
						this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(0x6e3e + (i * 2))) + 16, 11);
				}
			}

			int xMap = x - 32;
			int yMap = y - 19;
			int mapXSrc;
			int mapYSrc;
			int mapXDst;
			int mapYDst;
			int mapYOffset;

			// Instruction address 0x2aea:0x01b9, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Navigation) != 0)
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

			this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x6ed6, (short)xMap);
			this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x70ea, (short)yMap);

			// Instruction address 0x2aea:0x0233, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 8, 80, 50, 0);

			if (this.oParent.Var_d806_DebugFlag)
			{
				// Instruction address 0x2aea:0x024c, size: 5
				xMap = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(xMap, 0, 16);
				this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x6ed6, (short)xMap);

				// Instruction address 0x2aea:0x0264, size: 5
				yMap = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(yMap, 0, 65530);
				this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x70ea, (short)yMap);

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
				City city = this.oParent.CivState.Cities[i];

				if (city.StatusFlag != 0xff && (city.VisibleSize != 0 || city.PlayerID == this.oParent.CivState.HumanPlayerID))
				{
					// Instruction address 0x2aea:0x031a, size: 5
					cellXPos = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(city.Position.X - mapXSrc);
					cellYPos = city.Position.Y - mapYSrc + mapYOffset;

					if (cellYPos >= 0 && cellYPos < 50)
					{
						// Instruction address 0x2aea:0x0355, size: 3
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(cellXPos, cellYPos + 8,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x1946 + (city.PlayerID * 2))));
					}
				}
			}

			// Instruction address 0x2aea:0x037c, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a66_DrawShadowRectangle(0, 8, 79, 49, 15, 8);

			// Instruction address 0x2aea:0x03a2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(x - xMap - 1, y - yMap + 7, 17, 10, 15);

			this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xd20a, (short)tempValue);

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
			int scrX = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x - this.oParent.Var_d4cc_MapXCenter) * 16 + 80;
			int scrY = (y - this.oParent.Var_d75e_MapYCenter) * 16 + 8;

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
								F0_2aea_1326_CheckMapBounds(0, y + direction.Y) != 0)
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
								F0_2aea_1326_CheckMapBounds(0, y + direction.Y) != 0)
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
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + ((i & 0x1) * 8), scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd294 + 0x8 * ((bitmapMask >> (i * 2)) & 0x7) + i * 2)));
							}
							else
							{
								// Instruction address 0x2aea:0x05f4, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX - ((i & 0x1) * 8) + 8, scrY + 8,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd294 + 0x8 * ((bitmapMask >> (i * 2)) & 0x7) + i * 2)));
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
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd2d4 + i - 1)));
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
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc) == 0 &&
					!terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
				{
					// Draw irrigation
					// Instruction address 0x2aea:0x07f8, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd4ce + (4 << 1))));
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
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x6dfe + (mask << 1))));
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
								F0_2aea_1326_CheckMapBounds(0, y + direction.Y) != 0)
							{
								mask |= 0x8;
							}
						}

						// Instruction address 0x2aea:0x091e, size: 5
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xb886 + ((int)terrainType * 32) + (mask * 2))));

						if (terrainType == TerrainTypeEnum.Grassland && (((7 * x) + (11 * y)) & 0x2) == 0)
						{
							// Draw grassland tiles with production bonus
							// Instruction address 0x2aea:0x0996, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 4, scrY + 4, 
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb880));
						}
					}
					else
					{
						if (terrainType == TerrainTypeEnum.Grassland)
						{
							// Instruction address 0x2aea:0x0996, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xb886 + (int)terrainType * 32 + ((((7 * x) + (11 * y)) & 0x2) >> 1) * 2)));
						}
						else
						{
							// Instruction address 0x2aea:0x0996, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xb886 + (int)terrainType * 32 + ((x + y) & 0x1) * 2)));
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
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4da));
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

							if ((!terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City) && !terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.RailRoad)) || 
								(!terrainImprovements1.HasFlag(TerrainImprovementFlagsEnum.City) && terrainImprovements1.HasFlag(TerrainImprovementFlagsEnum.RailRoad)))
							{
								// Instruction address 0x2aea:0x0a73, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xb278 + i * 2)));
							}
							else
							{
								// Instruction address 0x2aea:0x0a73, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xb298 + i * 2)));
							}
						}
					}

					if (roadIcon != -1)
					{
						// Draw single cell road or railroad

						// Instruction address 0x2aea:0x0ae0, size: 5
						this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, scrX + 7, scrY + 7, 2, 2, (ushort)roadIcon);
					}
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Mines) &&
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc) == 0)
				{
					// Draw mines

					// Instruction address 0x2aea:0x0aff, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd4ce + (5 << 1))));
				}

				// Instruction address 0x2aea:0x0b11, size: 3
				if (F0_2aea_1836_CellHasSpecialResource(x, y))
				{
					// Draw special resources

					// Instruction address 0x2aea:0x0b28, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word,	(ushort)(0xd4ce + (((int)terrainType + 16) << 1))));
				}

				// Instruction address 0x2aea:0x0b3a, size: 3
				if (F0_2aea_1894_CellHasMinorTribeHut(terrainType, x, y))
				{
					// Draw Minot tribe hut

					// Instruction address 0x2aea:0x0b4e, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd4ce + (0x1f << 1))));
				}

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Fortress))
				{
					// Draw fortresses

					// Instruction address 0x2aea:0x0b66, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd4ce + (0x1e << 1))));
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
							this.oParent.CivState.MapVisibility[this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(x + direction.X), yTemp] : 0;

						if ((visibilityMask & (0x1 << this.oParent.CivState.HumanPlayerID)) == 0)
						{
							// Instruction address 0x2aea:0x0bce, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX, scrY,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x7eec + i - 1)));
						}
					}
				}

				// Instruction address 0x2aea:0x0be7, size: 3
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), F0_2aea_1369_GetCityOwner(x, y));

				if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City) && this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc) == 0)
				{
					// Draw city

					// Instruction address 0x2aea:0x0c09, size: 5
					int cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(x, y);

					if (cityID != -1)
					{
						// Draw city white borders at the left and bottom sides
						City city = this.oParent.CivState.Cities[cityID];

						if (city.PlayerID == this.oParent.CivState.HumanPlayerID || city.VisibleSize > 0 || this.oParent.Var_d806_DebugFlag)
						{
							// Instruction address 0x2aea:0x0c4b, size: 5
							this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(scrX + 1, scrY + 1, 13, 13, 15);

							// Draw city dark borders at the top and right sides

							// Instruction address 0x2aea:0x0c7d, size: 5
							this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(scrX + 2, scrY + 1, 12, 12,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x1956 + (city.PlayerID * 2))));

							// Draw city main color

							// Instruction address 0x2aea:0x0cac, size: 5
							this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, scrX + 2, scrY + 2, 12, 12,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x1946 + (city.PlayerID * 2))));

							// Draw city 'streets'

							// Instruction address 0x2aea:0x0cba, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 1, scrY + 1,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd4ce + (0x1c << 1))));

							// Color city 'streets' according to player nation

							// Instruction address 0x2aea:0x0ce5, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, scrX + 2, scrY + 2, 12, 12, 5,
								(byte)this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x1956 + (city.PlayerID * 2))));

							int citySize = (city.PlayerID == this.oParent.CivState.HumanPlayerID || this.oParent.Var_d806_DebugFlag) ?
									city.ActualSize : city.VisibleSize;

							this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

							// Instruction address 0x2aea:0x0d42, size: 5
							this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(citySize, 10));

							if ((city.StatusFlag & 0x1) != 0)
							{
								// Draw city disorder

								// Instruction address 0x2aea:0x0d66, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 5, scrY + 2,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6e9e));
							}
							else
							{
								// Draw city size

								// Instruction address 0x2aea:0x0d8d, size: 5
								this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, ((citySize < 10) ? 6 : 3) + scrX, scrY + 5, 0);
							}

							// Instruction address 0x2aea:0x0d9c, size: 3
							if ((short)F0_2aea_1458_GetCellActiveUnitID(x, y) != -1 || city.Unknown[0] != -1)
							{
								// Draw city defenders

								// Instruction address 0x2aea:0x0dc2, size: 5
								this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(scrX, scrY, 15, 15, 0);
							}

							if ((city.ImprovementFlags0 & 0x80) != 0)
							{
								// Draw city walls

								// Instruction address 0x2aea:0x0de7, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, scrX + 1, scrY + 1,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd4ce + (0x1d << 1))));
							}

							if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6c96) < 32)
							{
								this.oCPU.WriteInt16(this.oCPU.DS.Word, (ushort)(0x6dac + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6c96) * 2), (short)scrX);
								this.oCPU.WriteInt16(this.oCPU.DS.Word, (ushort)(0x6e3e + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6c96) * 2), (short)scrY);
								this.oCPU.WriteInt16(this.oCPU.DS.Word, (ushort)(0xdf20 + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6c96) * 2), (short)cityID);

								this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6c96, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c96)));
							}
						}
					}
				}

				// Instruction address 0x2aea:0x0e1b, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();
			}

			return true;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_2aea_0e29(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0e29({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xe);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x0ecd, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oParent.CivState.Players[playerID].Units[unitID].Position.X - this.oParent.Var_d4cc_MapXCenter);

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_d75e_MapYCenter));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.L) goto L0f09;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x140);
			if (this.oCPU.Flags.GE) goto L0f09;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L0f09;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xc0);
			if (this.oCPU.Flags.LE) goto L0f0e;

		L0f09:
			this.oCPU.AX.Word = 0;
			goto L0fae;

		L0f0e:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				(short)this.oParent.CivState.Players[playerID].Units[unitID].TypeID);

			// Instruction address 0x2aea:0x0f33, size: 3
			F0_2aea_134a_GetTerrainType(this.oParent.CivState.Players[playerID].Units[unitID].Position.X, this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0f57;

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x1) == 0)
				goto L0f57;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].UnitCategory != UnitCategoryEnum.Ocean)
				goto L0f09;

		L0f57:
			// Instruction address 0x2aea:0x0f57, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			if (this.oParent.CivState.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2aea:0x0f8b, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 1,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 1,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((((playerID << 5) +
						this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x40) << 1) + 0xd4ce)));
			}

			// Instruction address 0x2aea:0x0fa0, size: 3
			F0_2aea_0fb3(playerID, unitID, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x2aea:0x0fa6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = 0x1;

		L0fae:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0e29");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_0fb3(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0fb3({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x0fe2, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oParent.CivState.Players[playerID].Units[unitID].TypeID + (playerID << 5) + 0x40) << 1) + 0xd4ce)));

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x8) == 0)
				goto L1005;

			// Instruction address 0x2aea:0x0ffb, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x1d << 1) + 0xd4ce)));
			goto L1045;

		L1005:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x4) == 0)
				goto L1045;

			if (playerID != 1)
				goto L1027;

			this.oCPU.AX.Word = 0x9;
			goto L102a;

		L1027:
			this.oCPU.AX.Word = 0xf;

		L102a:
			// Instruction address 0x2aea:0x103d, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow("F", xPos + 4, yPos + 7, this.oCPU.AX.Low);

		L1045:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L108d;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X != -1)
			{
				if (playerID == 1)
				{
					this.oCPU.AX.Word = 0x9;
				}
				else
				{
					this.oCPU.AX.Word = 0xf;
				}

				// Instruction address 0x2aea:0x1085, size: 5
				this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow("G", xPos + 4, yPos + 7, this.oCPU.AX.Low);
			}

		L108d:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0xc2) == 0)
				goto L117a;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].UnitCategory == UnitCategoryEnum.Air)
				goto L117a;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x52);

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x40) == 0)
				goto L10d7;

			if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID == 0)
				goto L10d1;

			this.oCPU.AX.Word = 0x3f;

			goto L10d4;

		L10d1:
			this.oCPU.AX.Word = 0x49;

		L10d4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L10d7:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x80) != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4d);

				if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x40) != 0)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x46);
				}

				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x2) != 0)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x50);
				}
			}

			// Instruction address 0x2aea:0x1128, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " ");

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, this.oCPU.AX.Low);
			this.oCPU.CMP_UInt16((ushort)playerID, 0x1);
			if (this.oCPU.Flags.NE) goto L1141;
			this.oCPU.AX.Word = 0x9;
			goto L1144;

		L1141:
			this.oCPU.AX.Word = 0xf;

		L1144:
			// Instruction address 0x2aea:0x1157, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06, xPos + 4, yPos + 7, this.oCPU.AX.Low);

			// Instruction address 0x2aea:0x1172, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(xPos - 1, yPos - 1, 15, 15, 7);

		L117a:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x1) != 0)
			{
				// Instruction address 0x2aea:0x11a8, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 16, 16, 5, 7);

				// Instruction address 0x2aea:0x11c7, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 16, 16, 8, 7);
			}

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0fb3");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_11d4(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_11d4({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x2aea:0x11e2, size: 3
			F0_2aea_03ba_DrawCell(xPos, yPos);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdcfc), 0x0);
			if (this.oCPU.Flags.NE) goto L1256;

			// Instruction address 0x2aea:0x11f6, size: 3
			F0_2aea_1458_GetCellActiveUnitID(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1256;
			
			if (this.oParent.Var_d806_DebugFlag) goto L1237;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1237;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].VisibleByPlayer;
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L1256;

		L1237:
			// Instruction address 0x2aea:0x123e, size: 3
			F0_2aea_1585_GetVisibleTerrainImprovements(xPos, yPos);

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L1256;

			// Instruction address 0x2aea:0x1250, size: 3
			F0_2aea_125b(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

		L1256:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_11d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_2aea_125b(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_125b({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x2aea:0x127f, size: 3
			F0_2aea_134a_GetTerrainType(this.oParent.CivState.Players[playerID].Units[unitID].Position.X, this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1308;

			if (this.oParent.CivState.Players[playerID].Units[unitID].NextUnitID == -1)
				goto L1308;
			
			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].UnitCategory == UnitCategoryEnum.Ocean)
				goto L1308;

			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L12ac:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				(short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].NextUnitID);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TypeID].UnitCategory != UnitCategoryEnum.Ocean)
				goto L12ed;

			// Instruction address 0x2aea:0x12e2, size: 3
			F0_2aea_0e29(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xffff);

		L12ed:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xffff);
			if (this.oCPU.Flags.E) goto L12fb;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L12ac;

		L12fb:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1321;

			// Instruction address 0x2aea:0x131b, size: 3
			F0_2aea_0e29(playerID, unitID);

			goto L1321;

		L1308:
			// Instruction address 0x2aea:0x131b, size: 3
			F0_2aea_0e29(playerID, (short)this.oParent.Segment_1866.F0_1866_1122(playerID, unitID));

		L1321:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_125b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1326_CheckMapBounds(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1326_CheckMapBounds({xPos}, {yPos})");

			// function body
			if (xPos < 0 || xPos >= 80 || yPos < 0 || yPos >= 50)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}

			this.oCPU.Log.ExitBlock("F0_2aea_1326_CheckMapBounds");

			return this.oCPU.AX.Word;
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
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0x2ba6 + (this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos) * 2)));

			return (TerrainTypeEnum)this.oCPU.AX.Word;
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

			this.oCPU.AX.Word = (ushort)(value & 0x7);

			return this.oCPU.AX.Word;
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
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_13cb(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_13cb({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x2aea:0x13d8, size: 3
			F0_2aea_1458_GetCellActiveUnitID(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L13f5;

			// Instruction address 0x2aea:0x13ed, size: 5
			this.oParent.Segment_29f3.F0_29f3_0b66(playerID, unitID, (short)this.oCPU.AX.Word);

		L13f5:
			// Instruction address 0x2aea:0x140b, size: 3
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, (ushort)(playerID + 8));

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_13cb");
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
			if (this.oParent.CivState.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2aea:0x1433, size: 5
				this.oParent.Segment_29f3.F0_29f3_0bc9(playerID, unitID);
			}
			else
			{
				// Instruction address 0x2aea:0x144f, size: 3
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, (byte)playerID);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1412");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1458_GetCellActiveUnitID(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1458_GetCellActiveUnitID({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x2aea:0x1466, size: 3
			F0_2aea_14e0_GetCellUnitPlayerID(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1477;

		L1472:
			this.oCPU.AX.Word = 0xffff;
			goto L14db;

		L1477:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1481;

		L147e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1481:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >= 128)
				goto L14c1;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) == -1 ||
				(this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].TypeID == -1) ||
				(this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X != xPos) ||
				(this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y != yPos))
				goto L147e;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd7f0, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd20a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			goto L14db;

		L14c1:
			// Instruction address 0x2aea:0x14d3, size: 3
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, 0);

			goto L1472;

		L14db:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1458_GetCellActiveUnitID");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_14e0_GetCellUnitPlayerID(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x14f4, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos);

			if ((this.oCPU.AX.Word & 8) != 0)
			{
				this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x7);
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1511_ActiveUnitSetFlag8(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x1525, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos);

			// Instruction address 0x2aea:0x1539, size: 3
			this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 160, yPos, (byte)((this.oCPU.AX.Word & 0x7) | 0x8), 0);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1570(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x157a, size: 3
			TerrainImprovementFlagsEnum improvements = F0_2aea_1585_GetVisibleTerrainImprovements(xPos, yPos);
			
			this.oCPU.AX.Word = (ushort)(improvements.HasFlag(TerrainImprovementFlagsEnum.Road) ? 1 : 0);

			return this.oCPU.AX.Word;
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
			this.oCPU.AX.Word = (ushort)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100) | 
				(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150) << 4));

			return (TerrainImprovementFlagsEnum)this.oCPU.AX.Word;
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
			this.oCPU.AX.Word = (ushort)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, x + 80, y + 100) | 
				(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, x + 80, y + 150) << 4));
			
			return (TerrainImprovementFlagsEnum)this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1601(int xPos, int yPos)
		{
			// function body			
			// Instruction address 0x2aea:0x161b, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100);

			// Instruction address 0x2aea:0x1627, size: 3
			this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 100, (byte)this.oCPU.AX.Word, 0);

			// Instruction address 0x2aea:0x163d, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150);

			// Instruction address 0x2aea:0x1649, size: 3
			this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 150, (byte)this.oCPU.AX.Word, 0);
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
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos, yPos + 100, 0);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos, yPos + 150, 0);
			}
			else if (improvements >= TerrainImprovementFlagsEnum.RailRoad)
			{
				// Instruction address 0x2aea:0x1691, size: 5
				ushort current = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos, yPos + 150, (ushort)(((ushort)improvements >> 4) | current));
			}
			else
			{
				// Instruction address 0x2aea:0x1672, size: 5
				ushort current = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos, yPos + 100, (ushort)(current | (ushort)improvements));
			}

			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6b90) == this.oParent.CivState.HumanPlayerID)
			{
				// Instruction address 0x2aea:0x16e5, size: 3
				F0_2aea_1601(xPos, yPos);
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
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, (byte)(((~param1) & this.oCPU.AX.Word) & 0xff), 0);
			}

			if (((param1 & 0xf0) != 0))
			{
				// Instruction address 0x2aea:0x1738, size: 5
				this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150);

				// Instruction address 0x2aea:0x1751, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, (byte)(((~(param1 >> 4)) & this.oCPU.AX.Word) & 0xff), 0);
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
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x2aea:0x1768, size: 3
			F0_2aea_1369_GetCityOwner(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L177b;

		L1778:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L177b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x80);
			if (this.oCPU.Flags.GE) goto L17b3;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].StatusFlag == 0xff ||
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X != xPos ||
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y != yPos)
				goto L1778;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd7f0, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd20a, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			goto L17ca;

		L17b3:
			// Instruction address 0x2aea:0x17bf, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x2bc6, 100, 80);

			this.oCPU.AX.Word = 0xffff;

		L17ca:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_175a");

			return this.oCPU.AX.Word;
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
				(((x & 0x3) * 4) + (y & 0x3)) == ((((x / 4) * 13) + ((y / 4) * 11) + this.oParent.CivState.RandomSeed) & 0xf))
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
				(this.oParent.CivState.MapVisibility[x, y] & 0x1) == 0 &&
				(((x & 0x3) * 4) + (y & 0x3)) == ((((x / 4) * 13) + ((y / 4) * 11) + this.oParent.CivState.RandomSeed + 8) & 0x1f))
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1942(int xPos, int yPos)
		{
			// Instruction address 0x2aea:0x1953, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 50);

			return this.oCPU.AX.Word;
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
				F0_2aea_1942(x, y);

				// Land
				this.oCPU.AX.Word = (ushort)this.oParent.CivState.Continents[this.oCPU.AX.Word].Size;
			}
			else
			{
				// Instruction address 0x2aea:0x1990, size: 3
				F0_2aea_1942(x, y);

				// Oceans
				this.oCPU.AX.Word = (ushort)this.oParent.CivState.Oceans[this.oCPU.AX.Word].Size;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_195d");

			return this.oCPU.AX.Word;
		}
	}
}
