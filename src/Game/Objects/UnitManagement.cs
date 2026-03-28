using System;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class UnitManagement
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		private bool Var_20f4 = false;
		private int Var_6530 = 0;
		private int Var_6534 = 0;

		public UnitManagement(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_1866_0006(int cityID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_0006({cityID})");

			// function body
			if (this.oParent.GameData.Cities[cityID].PlayerID == this.oParent.GameData.HumanPlayerID)
			{
				this.Var_20f4 = true;

				for (int i = 0; i < 2; i++)
				{
					if (this.oParent.GameData.Cities[cityID].Unknown[i] != -1)
					{
						// Instruction address 0x1866:0x005e, size: 3
						int unitID = F0_1866_0cf5_CreateUnit(this.oParent.GameData.Cities[cityID].PlayerID,
							(this.oParent.GameData.Cities[cityID].Unknown[i] & 0x3f),
							this.oParent.GameData.Cities[cityID].Position.X, this.oParent.GameData.Cities[cityID].Position.Y);

						if (unitID != -1)
						{
							this.oParent.GameData.Players[this.oParent.GameData.Cities[cityID].PlayerID].Units[unitID].Status |= 8;

							if ((this.oParent.GameData.Cities[cityID].Unknown[i] & 0x40) != 0)
							{
								this.oParent.GameData.Players[this.oParent.GameData.Cities[cityID].PlayerID].Units[unitID].Status |= 0x20;
							}

							this.oParent.GameData.Cities[cityID].Unknown[i] = -1;
						}
					}
				}

				this.Var_20f4 = false;

				this.oParent.GameData.Cities[cityID].StatusFlag |= 4;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_1866_00c6(int cityID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_00c6({cityID})");

			// function body
			int local_2 = this.oParent.GameData.Cities[cityID].PlayerID;
			
			if (local_2 == this.oParent.GameData.HumanPlayerID)
			{
				bool oldValue = this.oParent.Var_70d8;
				bool skipFirstUnit = true;
				this.oParent.Var_70d8 = false;
				this.Var_20f4 = true;

				for (int i = 0; i < 128; i++)
				{
					if (this.oParent.GameData.Players[local_2].Units[i].TypeID != -1 &&
						(this.oParent.GameData.Players[local_2].Units[i].Position.X == this.oParent.GameData.Cities[cityID].Position.X) &&
						(this.oParent.GameData.Players[local_2].Units[i].Position.Y == this.oParent.GameData.Cities[cityID].Position.Y) &&
						this.oParent.GameData.Players[local_2].Units[i].HomeCityID == cityID &&
						(this.oParent.GameData.Players[local_2].Units[i].Status & 0x8) != 0)
					{
						if (!skipFirstUnit)
						{
							if (this.oParent.GameData.Cities[cityID].Unknown[0] == -1)
							{
								this.oParent.GameData.Cities[cityID].Unknown[0] = (sbyte)this.oParent.GameData.Players[local_2].Units[i].TypeID;

								if ((this.oParent.GameData.Players[local_2].Units[i].Status & 0x20) != 0)
								{
									this.oParent.GameData.Cities[cityID].Unknown[0] |= 0x40;
								}

							}
							else
							{
								if (this.oParent.GameData.Cities[cityID].Unknown[1] != -1)
									break;

								this.oParent.GameData.Cities[cityID].Unknown[1] = (sbyte)this.oParent.GameData.Players[local_2].Units[i].TypeID;

								if ((this.oParent.GameData.Players[local_2].Units[i].Status & 0x20) != 0)
								{
									this.oParent.GameData.Cities[cityID].Unknown[1] |= 0x40;
								}
							}

							// Instruction address 0x1866:0x013d, size: 3
							F0_1866_0f10_DeleteUnit(local_2, i);
						}
						skipFirstUnit = false;
					}
				}

				this.Var_20f4 = false;
				this.oParent.Var_70d8 = oldValue;
				this.oParent.GameData.Cities[cityID].StatusFlag &= 0xfb;
			}		
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="flag"></param>
		public void F0_1866_01dc(int x, int y, int playerID, int unitID, bool flag)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_01dc({x}, {y}, {playerID}, {unitID}, {flag})");

			// function body
			TerrainTypeEnum terrainType = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(x, y);
			// Instruction address 0x1866:0x02b5, size: 5
			TerrainImprovementFlagsEnum visibleTerrainImprovements = this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(x, y);

			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				for (int i = 0; i < 25; i++)
				{
					GPoint direction = this.oParent.MoveDirections[i];

					// Instruction address 0x1866:0x0212, size: 5
					int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(x + direction.X);
					int newY = y + direction.Y;

					if (!this.oParent.MapManagement.F0_2aea_1326_ValidateMapCoordinates(newX, newY))
						continue;

					if(i < 9 || (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].SightRange & 0x2) != 0 ||
						(this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(x, y) != TerrainTypeEnum.Water &&
						this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) != TerrainTypeEnum.Water))
					{
						// Instruction address 0x1866:0x026c, size: 5
						this.oParent.GameData.MapVisibility[newX, newY] |= (ushort)(1 << playerID);

						// Instruction address 0x1866:0x029b, size: 5
						this.oParent.MapManagement.F0_2aea_1601_UpdateVisibleCellStatus(newX, newY);
					}
				}
			}

			for (int i = 1; i < 9; i++)
			{
				GPoint direction = this.oParent.MoveDirections[i];

				// Instruction address 0x1866:0x0397, size: 5
				int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(x + direction.X);
				int newY = y + direction.Y;

				// Instruction address 0x1866:0x03b0, size: 5
				if (!this.oParent.MapManagement.F0_2aea_1326_ValidateMapCoordinates(newX, newY))
					continue;

				if (playerID != 0)
				{
					this.oParent.GameData.MapVisibility[newX, newY] |= (ushort)(1 << playerID);
				}

				// Instruction address 0x1866:0x03e5, size: 5
				TerrainImprovementFlagsEnum newVisibleTerrainImprovements = this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newX, newY);

				if (newVisibleTerrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
				{
					// Instruction address 0x1866:0x03ff, size: 5
					if (this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(newX, newY) != playerID)
					{
						// Instruction address 0x1866:0x0415, size: 5
						int cityOwnerPlayerID = this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(newX, newY);

						// Instruction address 0x1866:0x0426, size: 5
						int cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(newX, newY);

						// Instruction address 0x1866:0x0433, size: 3
						F0_1866_0006(cityID);

						if (playerID == this.oParent.GameData.HumanPlayerID)
						{
							this.oParent.GameData.Cities[cityID].VisibleSize = this.oParent.GameData.Cities[cityID].ActualSize;
						}

						if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
						{
							this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << cityOwnerPlayerID);

							if ((this.oParent.GameData.Players[playerID].Diplomacy[cityOwnerPlayerID] & 2) == 0)
							{
								// Instruction address 0x1866:0x049f, size: 5
								this.oParent.Segment_25fb.F0_25fb_304d(cityOwnerPlayerID, newX, newY, 1, 4);

								// Instruction address 0x1866:0x04b5, size: 5
								this.oParent.Segment_25fb.F0_25fb_304d(cityOwnerPlayerID, newX, newY, 2, 2);
							}
						}
					}
				}

				// Instruction address 0x1866:0x04c3, size: 5
				int activeUnitID = this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(newX, newY);

				if (activeUnitID != -1 && playerID != this.oParent.Var_d7f0)
				{
					if (!visibleTerrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
					{
						this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << this.oParent.Var_d7f0);
					}

					// Instruction address 0x1866:0x0513, size: 3
					F0_1866_14a2_UnitStack(this.oParent.Var_d7f0, activeUnitID);

					// Instruction address 0x1866:0x051f, size: 5
					if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) == TerrainTypeEnum.Water ||
						terrainType != TerrainTypeEnum.Water)
					{
						this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].GoToDestination.X = -1;
					}

					// Instruction address 0x1866:0x054e, size: 5
					if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) != TerrainTypeEnum.Water ||
						terrainType == TerrainTypeEnum.Water ||
						this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air)
					{
						this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
					}

					if (!newVisibleTerrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
					{
						this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].VisibleByPlayer |= (ushort)(1 << playerID);
					}

					if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land &&
						this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(x, y) != TerrainTypeEnum.Water &&
						this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) != TerrainTypeEnum.Water &&
						this.oParent.GameData.Units[this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
					{
						// Instruction address 0x1866:0x0635, size: 5
						this.oParent.Segment_2517.F0_2517_0737(playerID, this.oParent.Var_d7f0, x, y);

						if ((this.oParent.GameData.Players[playerID].Diplomacy[this.oParent.Var_d7f0] & 2) == 0)
						{
							int local_6 = 1;

							if (this.oParent.Var_d7f0 != 0 &&
								this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].TypeID != 26 &&
								((this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].Status & 0x8) == 0 ||
									this.oParent.GameData.Units[this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].TypeID].AIRole != UnitAIRoleEnum.Defense))
							{
								local_6 = 3;
							}

							// Instruction address 0x1866:0x069b, size: 5
							this.oParent.Segment_25fb.F0_25fb_304d(playerID, newX, newY, 1, (short)local_6);
						}

						if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 26)
						{
							if (playerID == 0)
							{
								// Instruction address 0x1866:0x02da, size: 5
								this.oParent.Segment_25fb.F0_25fb_304d(this.oParent.Var_d7f0, x, y, 2, 1);
							}
							else
							{
								// Instruction address 0x1866:0x02da, size: 5
								this.oParent.Segment_25fb.F0_25fb_304d(this.oParent.Var_d7f0, x, y, 2, 2);
							}
						}
					}

					// Instruction address 0x1866:0x02e8, size: 5
					if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) == TerrainTypeEnum.Water &&
						this.oParent.Var_d7f0 != 0 &&
						(this.oParent.GameData.Players[playerID].Diplomacy[this.oParent.Var_d7f0] & 0x2) == 0)
					{
						// Instruction address 0x1866:0x0321, size: 5
						this.oParent.Segment_25fb.F0_25fb_304d(playerID, newX, newY, 3, 2);
					}
				}

				if (flag && (playerID == this.oParent.GameData.HumanPlayerID || this.oParent.Var_d806_DebugFlag))
				{
					// Instruction address 0x1866:0x0344, size: 5
					this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(newX, newY);

					// Instruction address 0x1866:0x0358, size: 3
					if (this.oParent.Graphics.F0_VGA_038c_GetPixel(2, newX, newY) == 1)
					{
						// Instruction address 0x1866:0x0376, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(2, newX + 240, newY, 1);
					}
					else
					{
						// Instruction address 0x1866:0x0376, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(2, newX + 240, newY, 2);
					}
				}
			}

			for (int i = 9; i < 25; i++)
			{
				GPoint direction = this.oParent.MoveDirections[i];

				// Instruction address 0x1866:0x08d2, size: 5
				int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(x + direction.X);
				int newY = y + direction.Y;

				// Instruction address 0x1866:0x08eb, size: 5
				if (this.oParent.MapManagement.F0_2aea_1326_ValidateMapCoordinates(newX, newY))
				{
					// Instruction address 0x1866:0x08fd, size: 5
					int activeUnitID = this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(newX, newY);

					// Instruction address 0x1866:0x090e, size: 5
					TerrainImprovementFlagsEnum newVisibleTerrainImprovements = this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newX, newY);

					if ((this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].SightRange & 0x2) != 0 &&
						(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Water ||
						this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) == TerrainTypeEnum.Water))
					{
						if (playerID != 0)
						{
							this.oParent.GameData.MapVisibility[newX, newY] |= (ushort)(1 << playerID);
						}

						if (activeUnitID != -1 && playerID != this.oParent.Var_d7f0 &&
							this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].TypeID != 22)
						{
							if (!newVisibleTerrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
							{
								this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].VisibleByPlayer |= (ushort)(1 << playerID);
							}

							// Instruction address 0x1866:0x09b8, size: 5
							if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) == TerrainTypeEnum.Water &&
								this.oParent.Var_d7f0 != 0 &&
								(this.oParent.GameData.Players[playerID].Diplomacy[this.oParent.Var_d7f0] & 2) == 0)
							{
								// Instruction address 0x1866:0x09f1, size: 5
								this.oParent.Segment_25fb.F0_25fb_304d(playerID, newX, newY, 3, 2);
							}
						}

						if (flag && (playerID == this.oParent.GameData.HumanPlayerID || this.oParent.Var_d806_DebugFlag))
						{
							// Instruction address 0x1866:0x0a1a, size: 5
							this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(newX, newY);

							// Instruction address 0x1866:0x0a2e, size: 3
							if (this.oParent.Graphics.F0_VGA_038c_GetPixel(2, newX, newY) == 1)
							{
								// Instruction address 0x1866:0x06e2, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(2, newX + 240, newY, 1);
							}
							else
							{
								// Instruction address 0x1866:0x06e2, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(2, newX + 240, newY, 2);
							}
						}
					}

					if (activeUnitID != -1)
					{
						if (playerID != this.oParent.Var_d7f0 &&
							this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 22)
						{
							if ((this.oParent.GameData.Units[this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].TypeID].SightRange & 0x2) != 0 &&
								(this.oParent.GameData.Units[this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].TypeID].MovementType != UnitMovementTypeEnum.Water ||
									this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(x, y) == TerrainTypeEnum.Water))
							{
								this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].Status &= 0xfe;
								this.oParent.GameData.Players[this.oParent.Var_d7f0].Units[activeUnitID].GoToDestination.X = -1;

								if (!visibleTerrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City))
								{
									this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << this.oParent.Var_d7f0);
								}

								// Instruction address 0x1866:0x07a3, size: 5
								if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) == TerrainTypeEnum.Water &&
									this.oParent.Var_d7f0 != 0 &&
									(this.oParent.GameData.Players[playerID].Diplomacy[this.oParent.Var_d7f0] & 0x2) == 0)
								{
									// Instruction address 0x1866:0x07e6, size: 5
									this.oParent.Segment_25fb.F0_25fb_304d(this.oParent.Var_d7f0, x, y, 3, 2);
								}
							}
							else if (this.oParent.Var_d7f0 == this.oParent.GameData.HumanPlayerID &&
								this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newX, newY).HasFlag(TerrainImprovementFlagsEnum.City) &&
								(this.oParent.GameData.MapVisibility[x, y] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0)
							{
								this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << this.oParent.Var_d7f0);

								// Instruction address 0x1866:0x084f, size: 5
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(x, y);
							}
						}
					}

					if (newVisibleTerrainImprovements.HasFlag(TerrainImprovementFlagsEnum.City) &&
						this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(newX, newY) == this.oParent.GameData.HumanPlayerID &&
						(this.oParent.GameData.MapVisibility[x, y] & (0x1 << this.oParent.GameData.HumanPlayerID)) != 0)
					{
						this.oParent.GameData.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << this.oParent.GameData.HumanPlayerID);

						// Instruction address 0x1866:0x08b1, size: 5
						this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(x, y);
					}
				}
			}

			if (flag && playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x0a59, size: 5
				this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(x, y);

				for (int i = 9; i < 49; i++)
				{
					GPoint direction = this.oParent.MoveDirections[i];

					// Instruction address 0x1866:0x0a73, size: 5
					int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(x + direction.X);
					int newY = y + direction.Y;

					// Instruction address 0x1866:0x0a8c, size: 5
					if (this.oParent.MapManagement.F0_2aea_1326_ValidateMapCoordinates(newX, newY) &&
						(this.oParent.GameData.MapVisibility[newX, newY] & (0x1 << playerID)) != 0)
					{
						// Instruction address 0x1866:0x0abf, size: 5
						this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(newX, newY);
					}
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xOffset"></param>
		/// <param name="yOffset"></param>
		public void F0_1866_0ad6(int playerID, int unitID, int xOffset, int yOffset)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_0ad6({playerID}, {unitID}, {xOffset}, {yOffset})");

			// function body
			int xScreen = -1;
			int yScreen = 0;

			if (xOffset != -1)
			{
				// Instruction address 0x1866:0x0af0, size: 5
				xScreen = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(xOffset - this.oParent.Var_d4cc_MapViewX) * 16 + 80;
				yScreen = (yOffset - this.oParent.Var_d75e_MapViewY) * 16 + 8;

				if (xScreen < 80 || xScreen >= 320 || yScreen < 8 || yScreen > 192)
				{
					xScreen = -1;
				}				
			}

			int local_e = (this.oParent.Var_70ea < 0) ? 0 : this.oParent.Var_70ea;
			int local_a = local_e - this.oParent.Var_70ea;
			
			// Instruction address 0x1866:0x0b5b, size: 5
			int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(this.oParent.GameData.Players[playerID].Units[unitID].Position.X - this.oParent.Var_6ed6);
			int newY = (unitID < 127) ? (this.oParent.GameData.Players[playerID].Units[unitID].Position.Y - local_e + local_a) : (-1 - local_e + local_a);

			do
			{
				// Instruction address 0x1866:0x0b75, size: 5
				this.oParent.MainCode.F0_11a8_0268();

				if (unitID >= 128)
				{
					// Instruction address 0x1866:0x0bd9, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("End of Turn", 4, 124, 7);
				}
				else
				{
					// Instruction address 0x1866:0x0b9d, size: 5
					this.oParent.MapManagement.F0_2aea_03ba_DrawCell(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

					if (newY >= 0 && newY < 50)
					{
						// Instruction address 0x1866:0x0bbf, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel((ushort)this.oParent.Var_aa_Rectangle.ScreenID, newX, newY + 8, 15);
					}
				}

				if (xScreen != -1)
				{
					// Instruction address 0x1866:0x0bf3, size: 5
					this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(xScreen, yScreen, 15, 15, 15);
				}

				// Instruction address 0x1866:0x0bfb, size: 5
				this.oParent.MainCode.F0_11a8_0250();

				// Instruction address 0x1866:0x0c00, size: 5
				if (this.oParent.CAPI.kbhit() != 0)
				{
					// Instruction address 0x1866:0x0c12, size: 5
					this.oParent.CommonTools.F0_1182_0134_WaitTimer(1);
				}
				else
				{
					// Instruction address 0x1866:0x0c12, size: 5
					this.oParent.CommonTools.F0_1182_0134_WaitTimer(10);
				}

				// Instruction address 0x1866:0x0c1a, size: 5
				this.oParent.MainCode.F0_11a8_0268();

				if (unitID >= 128)
				{
					// Instruction address 0x1866:0x0c95, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("End of Turn", 4, 124, 0);
				}
				else
				{
					// Instruction address 0x1866:0x0c2c, size: 5
					this.oParent.MapManagement.F0_2aea_0e29_DrawUnit(playerID, unitID);

					if (newY >= 0 && newY < 50)
					{
						// Instruction address 0x1866:0x0c5c, size: 5
						if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
							this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) == TerrainTypeEnum.Water)
						{
							// Instruction address 0x1866:0x0c7c, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(this.oParent.Var_aa_Rectangle.ScreenID, newX, newY + 8, 1);
						}
						else
						{
							// Instruction address 0x1866:0x0c7c, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(this.oParent.Var_aa_Rectangle.ScreenID, newX, newY + 8, 2);
						}
					}
				}

				if (xScreen != -1)
				{
					// Instruction address 0x1866:0x0cb1, size: 5
					this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(xScreen, yScreen, 15, 15, 0);
				}

				// Instruction address 0x1866:0x0cb9, size: 5
				this.oParent.MainCode.F0_11a8_0250();

				// Instruction address 0x1866:0x0cbe, size: 5
				if (this.oParent.CAPI.kbhit() != 0)
				{
					// Instruction address 0x1866:0x0cd0, size: 5
					this.oParent.CommonTools.F0_1182_0134_WaitTimer(1);
				}
				else
				{
					// Instruction address 0x1866:0x0cd0, size: 5
					this.oParent.CommonTools.F0_1182_0134_WaitTimer(10);
				}

				// Instruction address 0x1866:0x0cd8, size: 5
				this.oParent.MainCode.F0_11a8_0223_UpdateMouseState();
			}
			while (this.oParent.CAPI.kbhit() == 0 && this.oParent.Var_db3a_MouseButton == 0);
		}

		/// <summary>
		/// Creates unit of specified type.
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitTypeID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>ID of newly created unit or -1 if unit can not be created</returns>
		public int F0_1866_0cf5_CreateUnit(int playerID, int unitTypeID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_0cf5_CreateUnit({playerID}, {unitTypeID}, {xPos}, {yPos})");

			// function body
			Player player = this.oParent.GameData.Players[playerID];
			int unitID;

			// Find free unit ID
			for (unitID = 0; unitID < 127 && player.Units[unitID].TypeID != -1; unitID++)
			{ }

			if (unitID >= 127)
			{
				if (playerID == this.oParent.GameData.HumanPlayerID && !this.oParent.Var_d760_HumanPlayerMessageFlag)
				{
					this.oParent.Var_2f9e_MessageBoxStyle = MenuBoxReportTypeEnum.DefenseMinisterReport;

					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

					// Instruction address 0x1866:0x0ee6, size: 5
					this.oParent.LanguageTools.F0_2f4d_044f(0x2126);

					// Instruction address 0x1866:0x0efa, size: 5
					this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 64);

					// Show message to the human player only once per turn
					this.oParent.Var_d760_HumanPlayerMessageFlag = true;
				}
			}
			else
			{
				Unit unit = player.Units[unitID];
				unit.Position.X = -1;
				unit.NextUnitID = -1;

				// Instruction address 0x1866:0x0d39, size: 5
				this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(playerID, x, y);

				// Instruction address 0x1866:0x0d4d, size: 5
				this.oParent.MapManagement.F0_2aea_13cb_SetCellPlayerID(playerID, unitID, x, y);

				this.oParent.GameData.MapVisibility[x, y] |= (ushort)(1 << playerID);

				unit.Status = 0;
				unit.Position = new GPoint(x, y);
				unit.TypeID = (short)unitTypeID;
				unit.VisibleByPlayer = (ushort)(1 << playerID);
				unit.GoToDestination.X = -1;
				unit.GoToNextDirection = -1;
				unit.SpecialMoves = this.oParent.GameData.Units[unit.TypeID].TurnsOutside;

				// Instruction address 0x1866:0x0db6, size: 5
				unit.HomeCityID = (short)this.oParent.Segment_2dc4.F0_2dc4_0102(x, y);

				short cityOwnerID = (short)((unit.HomeCityID < 128 && unit.HomeCityID != -1) ? this.oParent.GameData.Cities[unit.HomeCityID].PlayerID : -1);

				if (cityOwnerID != playerID)
				{
					unit.HomeCityID = -1;
				}

				if (unit.SpecialMoves != 0)
				{
					unit.SpecialMoves--;
				}

				player.ActiveUnits[unitTypeID]++;

				if (!this.Var_20f4)
				{
					if (!this.oParent.Var_d806_DebugFlag || playerID == this.oParent.GameData.HumanPlayerID ||
						(unit.VisibleByPlayer & (1 << this.oParent.GameData.HumanPlayerID)) != 0)
					{
						// Instruction address 0x1866:0x0e5c, size: 5
						this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(unit.Position.X, unit.Position.Y);
					}

					// Instruction address 0x1866:0x0e77, size: 3
					F0_1866_01dc(x, y, playerID, unitID, true);
				}

				if (playerID == this.oParent.GameData.HumanPlayerID && 
					this.oParent.GameData.TurnCount != 0 && !this.Var_20f4)
				{
					if (player.UnitCount == 0)
					{
						this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x210e);
					}

					if (player.UnitCount == 1)
					{
						this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x211a);
					}
				}

				return unitID;
			}

			return -1;
		}

		/// <summary>
		/// Deletes stack of units counting it as lost.
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_0f10_DeleteUnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_0f10_DeleteUnit(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// Deletes unit counting it as lost.
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_0f10_DeleteUnit(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_0f10_DeleteUnit({playerID}, {unitID})");

			// function body
			Player player = this.oParent.GameData.Players[playerID];
			Unit unit = player.Units[unitID];

			if (unit.TypeID != -1)
			{
				if (this.oParent.Var_70d8)
				{
					player.LostUnits[unit.TypeID]++;
				}
	
				if (this.oParent.GameData.Units[unit.TypeID].TransportCapacity != 0 && unit.NextUnitID != -1 && 
					this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(unit.Position.X, unit.Position.Y) == TerrainTypeEnum.Water)
				{
					// Delete land units aboard the ship

					// Instruction address 0x1866:0x0f94, size: 3
					F0_1866_1610_UnitStack(playerID, unitID);
				}
	
				if (unit.TypeID == (short)UnitTypeEnum.Carrier && unit.NextUnitID != -1 && 
					this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(unit.Position.X, unit.Position.Y) == TerrainTypeEnum.Water)
				{
					// Delete air unit(s) along with aircraft carrier

					// Instruction address 0x1866:0x0fe0, size: 3
					F0_1866_1676_UnitStack(playerID, unitID);
				}
	
				if (unit.TypeID != -1)
				{
					player.ActiveUnits[unit.TypeID]--;
				}
	
				unit.TypeID = -1;
				unit.RemainingMoves = 0;
	
				// Instruction address 0x1866:0x1027, size: 5
				this.oParent.MapManagement.F0_2aea_1412_SetCellActivePlayerID(playerID, unitID, unit.Position.X, unit.Position.Y);
	
				if (!this.Var_20f4 && this.oParent.Var_3936 == -1)
				{
					if (this.oParent.Var_d806_DebugFlag || playerID == this.oParent.GameData.HumanPlayerID ||
						(unit.VisibleByPlayer & (1 << this.oParent.GameData.HumanPlayerID)) != 0)
					{	
						// Instruction address 0x1866:0x107d, size: 5
						this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(unit.Position.X, unit.Position.Y);
					}
				}
			}			
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public int F0_1866_1089(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1089({playerID}, {unitID})");

			// function body
			if (this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID == -1)
			{
				return unitID;
			}

			this.Var_6530 = unitID;
			this.Var_6534 = 0;

			for (int local_2 = 0; local_2 < 128; local_2++)
			{
				if (this.oParent.GameData.Players[playerID].Units[local_2].TypeID != -1 &&
					(this.oParent.GameData.Players[playerID].Units[unitID].Position.X == this.oParent.GameData.Players[playerID].Units[local_2].Position.X) &&
					(this.oParent.GameData.Players[playerID].Units[unitID].Position.Y == this.oParent.GameData.Players[playerID].Units[local_2].Position.Y))
				{
					// Instruction address 0x1866:0x1113, size: 3
					F0_1866_1169_UnitStack(playerID, local_2);
					break;
				}
			}

			return this.Var_6530;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public int F0_1866_1122(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1122({playerID}, {unitID})");

			// function body			
			if (this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID == -1)
			{
				return unitID;
			}

			this.Var_6530 = unitID;
			this.Var_6534 = -1;

			// Instruction address 0x1866:0x115d, size: 3
			F0_1866_1169_UnitStack(playerID, unitID);

			return this.Var_6530;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1169_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_1169(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1169(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1169({playerID}, {unitID})");

			// function body
			int unitTypeID = this.oParent.GameData.Players[playerID].Units[unitID].TypeID;

			// Instruction address 0x1866:0x1195, size: 5
			TerrainTypeEnum terrainType = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

			if (terrainType != TerrainTypeEnum.Water || this.oParent.GameData.Units[unitTypeID].MovementType == UnitMovementTypeEnum.Water)
			{
				int defenseStrength;

				if (this.oParent.GameData.Units[unitTypeID].MovementType == UnitMovementTypeEnum.Land)
				{

					if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x8) != 0)
					{
						defenseStrength = 3 * this.oParent.GameData.Units[unitTypeID].DefenseStrength * this.oParent.GameData.Terrains[(int)terrainType].DefenseBonus * 8;
					}
					else
					{
						defenseStrength = 2 * this.oParent.GameData.Units[unitTypeID].DefenseStrength * this.oParent.GameData.Terrains[(int)terrainType].DefenseBonus * 8;
					}
				}
				else
				{
					defenseStrength = this.oParent.GameData.Units[unitTypeID].DefenseStrength * 16;
				}

				if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x20) != 0)
				{
					defenseStrength += defenseStrength / 2;
				}

				if (defenseStrength > this.Var_6534)
				{
					this.Var_6534 = defenseStrength;
					this.Var_6530 = unitID;
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="valueType"></param>
		/// <returns></returns>
		public int F0_1866_1251(int playerID, int unitID, int valueType)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1251({playerID}, {unitID}, {param3})");

			// function body
			// Instruction address 0x1866:0x1275, size: 3
			return F0_1866_1280_UnitStack(playerID, unitID, valueType);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private int F0_1866_1280_UnitStack(int playerID, int unitID, int valueType)
		{
			int oldUnitID = unitID;
			int value = 0;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				value += F0_1866_1280(playerID, oldUnitID, unitID, valueType);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}

			return value;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private int F0_1866_1280(int playerID, int unitID, int mainUnitID, int valueType)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1280({playerID}, {unitID})");

			// function body
			int value = 0;

			switch (valueType)
			{
				case 0:
					value += this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].Cost;
					break;

				case 1:
					value += this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].DefenseStrength;
					break;

				case 2:
					value++;
					break;

				case 3:
					value += this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].AttackStrength;
					break;

				case 4:
					if (unitID < mainUnitID && 
						this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].AIRole == UnitAIRoleEnum.Defense)
					{
						value++;
					}
					break;
			}

			return value;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="unitTypeID"></param>
		/// <returns></returns>
		public int F0_1866_1331(int playerID, int unitID, int unitTypeID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1331({playerID}, {unitID}, {param3})");

			// function body			
			// Instruction address 0x1866:0x134f, size: 3
			return F0_1866_135a_UnitStack(playerID, unitID, unitTypeID);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private int F0_1866_135a_UnitStack(int playerID, int unitID, int unitTypeID)
		{
			int oldUnitID = unitID;
			int count = 0;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				if (this.oParent.GameData.Players[playerID].Units[oldUnitID].TypeID == unitTypeID)
				{
					count++;
				}

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}

			return count;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="aiRole"></param>
		/// <returns></returns>
		public int F0_1866_1380(int playerID, int unitID, UnitAIRoleEnum aiRole)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1380({playerID}, {unitID}, {aiRole})");

			// function body
			// Instruction address 0x1866:0x139e, size: 3
			return F0_1866_13a9_UnitStack(playerID, unitID, aiRole);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private int F0_1866_13a9_UnitStack(int playerID, int unitID, UnitAIRoleEnum aiRole)
		{
			int oldUnitID = unitID;
			int count = 0;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[oldUnitID].TypeID].AIRole == aiRole)
				{
					count++;
				}

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}

			return count;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public int F0_1866_13d5(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_13d5({playerID}, {unitID})");

			// function body
			// Instruction address 0x1866:0x13ed, size: 3
			return F0_1866_13f8_UnitStack(playerID, unitID);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private int F0_1866_13f8_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;
			int count = 0;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[oldUnitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
				{
					count--;
				}

				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[oldUnitID].TypeID].AIRole == UnitAIRoleEnum.SeaTransport)
				{
					count += this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[oldUnitID].TypeID].TransportCapacity;
				}

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}

			return count;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_14a2_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_14a2(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_14a2(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_14a2({playerID}, {unitID})");

			// function body
			// Instruction address 0x1866:0x14c2, size: 5
			if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(this.oParent.GameData.Players[playerID].Units[unitID].Position.X, 
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) != TerrainTypeEnum.Water)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfe;
			}
			else
			{
				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfe;
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_14f6_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_14f6(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_14f6(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_14f6({playerID}, {unitID})");

			// function body
			if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0x1) != 0)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0xfe;

				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves =
					(short)(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MoveCount * 3);

				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside != 0)
				{
					this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves =
						(short)(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].TurnsOutside - 1);
				}
			}

			this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;
			this.oParent.GameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1560_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_1560(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1560(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1560({playerID}, {unitID})");

			// function body
			if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Water)
			{
				// Instruction address 0x1866:0x158a, size: 3
				F0_1866_1593(playerID, unitID);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1593_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_1593(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1593(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1593({playerID}, {unitID})");

			// function body
			if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0xc2) != 0)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].SpecialMoves = 0;
			}

			if ((this.oParent.GameData.Players[playerID].Units[unitID].Status & 0xcb) != 0)
			{
				this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 
					(short)(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MoveCount * 3);
			}

			this.oParent.GameData.Players[playerID].Units[unitID].Status &= 0x30;
			this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1605, size: 5
				this.oParent.MapManagement.F0_2aea_0e29_DrawUnit(playerID, unitID);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1610_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_1610(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1610(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1610({playerID}, {unitID})");

			// function body			
			if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Land)
			{
				// Instruction address 0x1866:0x163a, size: 3
				F0_1866_0f10_DeleteUnit(playerID, unitID);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1643_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_1643(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1643(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1643({playerID}, {unitID})");

			// function body
			if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != -1)
			{
				if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Land)
				{
					// Instruction address 0x1866:0x166d, size: 3
					F0_1866_0f10_DeleteUnit(playerID, unitID);
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1676_UnitStack(int playerID, int unitID)
		{
			int oldUnitID = unitID;

			for (int i = 0; i < 10 && oldUnitID != -1; i++)
			{
				int newUnitID = this.oParent.GameData.Players[playerID].Units[oldUnitID].NextUnitID;

				F0_1866_1676(playerID, oldUnitID);

				oldUnitID = newUnitID;

				if (oldUnitID == unitID)
					break;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		private void F0_1866_1676(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1676({playerID}, {unitID})");

			// function body
			if (this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air)
			{
				// Instruction address 0x1866:0x16a0, size: 3
				F0_1866_0f10_DeleteUnit(playerID, unitID);
			}
		}

		/// <summary>
		/// ??? To be checked - Too many parameters calling F0_2aea_0008
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public void F0_1866_16a9(int playerID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_16a9({playerID}, {x}, {y})");

			// function body
			bool flag = false;

			if (x < 16 && this.oParent.Var_d4cc_MapViewX > 64)
			{
				x += 80;
			}

			if (x < this.oParent.Var_d4cc_MapViewX + 2 || x > this.oParent.Var_d4cc_MapViewX + 13 ||
				y < this.oParent.Var_d75e_MapViewY + 2 || y > this.oParent.Var_d75e_MapViewY + 9)
			{
				flag = true;
			}

			if (flag)
			{
				// Instruction address 0x1866:0x1719, size: 5
				this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID, this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(x - 8), y - 6);
			}
		}

		/// <summary>
		/// This function tests if unit is near and updates visibility if player is human player
		/// This should be reworked as the function should update visibility for any player taking into account the visibility range
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public bool F0_1866_1725_IsUnitNear(int playerID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1725({playerID}, {x}, {y})");

			// function body
			if (!this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.City))
			{
				// Instruction address 0x1866:0x1748, size: 3
				return F0_1866_1750_IsUnitOrCityNear(playerID, x, y);
			}

			return false;
		}

		/// <summary>
		/// This function tests if unit or city is near and updates visibility if player is human player
		/// This should be reworked as the function should update visibility for any player taking into account the visibility range
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public bool F0_1866_1750_IsUnitOrCityNear(int playerID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1750({playerID}, {x}, {y})");

			// function body
			TerrainTypeEnum terrainType = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(x, y);

			for(int i = 1; i < 9; i++)
			{
				GPoint direction = this.oParent.MoveDirections[i];

				int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(x + direction.X);
				int newY = y + direction.Y;

				if (((this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) == TerrainTypeEnum.Water) ? 1 : 0) == ((terrainType == TerrainTypeEnum.Water) ? 1 : 0))
				{
					// Instruction address 0x1866:0x17d1, size: 5
					int unitPlayerID = this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(newX, newY);

					if (unitPlayerID != -1 && unitPlayerID != playerID)
					{
						if (playerID == this.oParent.GameData.HumanPlayerID)
						{
							ushort humanPlayerBitmask = (ushort)(0x1 << this.oParent.GameData.HumanPlayerID);
							int unitID = this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(newX, newY);

							if ((this.oParent.GameData.Players[unitPlayerID].Units[unitID].VisibleByPlayer & humanPlayerBitmask) == 0)
							{
								this.oParent.GameData.Players[unitPlayerID].Units[unitID].VisibleByPlayer |= humanPlayerBitmask;

								this.oParent.GameData.MapVisibility[newX, newY] |= humanPlayerBitmask;

								// Instruction address 0x1866:0x184e, size: 5
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(newX, newY);
							}

							// Instruction address 0x1866:0x185c, size: 5
							if (this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newX, newY).HasFlag(TerrainImprovementFlagsEnum.City))
							{
								// Instruction address 0x1866:0x186e, size: 5
								int cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(newX, newY);

								this.oParent.GameData.Cities[cityID].VisibleSize = this.oParent.GameData.Cities[cityID].ActualSize;

								// Instruction address 0x1866:0x188f, size: 5
								this.oParent.MapManagement.F0_2aea_1601_UpdateVisibleCellStatus(newX, newY);

								this.oParent.GameData.MapVisibility[newX, newY] |= humanPlayerBitmask;

								// Instruction address 0x1866:0x18bb, size: 5
								this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(newX, newY);
							}
						}

						return true;
					}
				}
			}

			return false;
		}

		public bool IsEnemyUnitNear(int playerID, int x, int y, int distance)
		{
			ushort playerBitmask = (ushort)(0x1 << playerID);
			GPoint[] moveDirections = this.oParent.MoveDirections;
			MapManagement mapManagement = this.oParent.MapManagement;

			if (distance != 0)
			{
				for (int i = -distance; i < distance; i++)
				{
					for (int j = -distance; j < distance; j++)
					{
						if (i == 0 && j == 0)
							continue;

						int newX = x + i;
						int newY = y + j;
						int unitPlayerID = mapManagement.F0_2aea_14e0_GetCellUnitPlayerID(newX, newY);
						int unitID = mapManagement.F0_2aea_1458_GetCellActiveUnitID(newX, newY);

						if (unitPlayerID != -1 && unitID != -1 && unitPlayerID != playerID &&
							(this.oParent.GameData.Players[unitPlayerID].Units[unitID].VisibleByPlayer & playerBitmask) != 0)
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		public bool IsEnemyCityNear(int playerID, int x, int y, int distance)
		{
			ushort playerBitmask = (ushort)(0x1 << playerID);
			GPoint[] moveDirections = this.oParent.MoveDirections;
			MapManagement mapManagement = this.oParent.MapManagement;

			if (distance != 0)
			{
				for (int i = -distance; i < distance; i++)
				{
					for (int j = -distance; j < distance; j++)
					{
						if (i == 0 && j == 0)
							continue;

						int newX = x + i;
						int newY = y + j;
						int cityID;

						if ((this.oParent.GameData.MapVisibility[newX, newY] & playerBitmask) != 0 &&
							mapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newX, newY).HasFlag(TerrainImprovementFlagsEnum.City) &&
							(cityID = this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(newX, newY)) != -1 &&
							this.oParent.GameData.Cities[cityID].PlayerID != playerID)
						{
							return true;
						}
					}
				}
			}

			return false;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public bool F0_1866_18d0(int playerID, int x, int y)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_18d0({playerID}, {x}, {y})");

			// function body
			for (int i = 1; i < 9; i++)
			{
				GPoint direction = this.oParent.MoveDirections[i];

				// Instruction address 0x1866:0x18f4, size: 5
				int newX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(x + direction.X);
				int newY = y + direction.Y;

				// Instruction address 0x1866:0x190d, size: 5
				int unitPlayerID = this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(newX, newY);

				if (unitPlayerID != -1 && unitPlayerID != playerID)
				{
					return true;
				}
			}
		
			return false;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1931_FoundMinorTribeHut(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1931({playerID}, {unitID})");

			// function body
			if (playerID != 0 &&
				this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
			{
				// Instruction address 0x1866:0x1980, size: 5
				int nearestCityID = (short)this.oParent.Segment_2dc4.F0_2dc4_0102(
					this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

				// Instruction address 0x1866:0x19a9, size: 5
				int nearestCityDistance = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
					this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y,
					// !!! Added if city doesn't exist at that location
					(nearestCityID >= 0 && nearestCityID < 128) ? this.oParent.GameData.Cities[nearestCityID].Position.X : -1,
					// !!! Added if city doesn't exist at that location
					(nearestCityID >= 0 && nearestCityID < 128) ? this.oParent.GameData.Cities[nearestCityID].Position.Y : -1);

				// Instruction address 0x1866:0x19b8, size: 5
				switch (this.oParent.CAPI.RNG.Next(4))
				{
					case 0:
						if (nearestCityDistance > 3)
						{
							// !!!! Presumably here local_e gets the current UnitID

							// Instruction address 0x1866:0x1a0b, size: 3
							int local_e = this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
								this.oParent.GameData.Players[playerID].Units[unitID].Position.X + 80,
								this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) & 0x7;

							if (local_e > 6)
							{
								F0_1866_1931_FoundAdvancedTribe(playerID, unitID);
							}
							else
							{
								F0_1866_1931_FoundMetalDeposits(playerID, unitID);
							}
						}
						else
						{
							F0_1866_1931_FoundSkilledMercenaries(playerID, unitID);
						}
						break;

					case 1:
						if (this.oParent.GameData.TurnCount == 0 || this.oParent.GameData.Year > 1000)
						{
							F0_1866_1931_FoundMetalDeposits(playerID, unitID);
						}
						else
						{
							F0_1866_1931_FoundAncientWisdom(playerID, unitID);
						}
						break;

					case 2:
						F0_1866_1931_FoundMetalDeposits(playerID, unitID);
						break;

					case 3:
						if (nearestCityDistance < 4 || this.oParent.GameData.Players[playerID].CityCount == 0)
						{
							F0_1866_1931_FoundSkilledMercenaries(playerID, unitID);
						}
						else
						{
							F0_1866_1931_FoundBarbarians(playerID, unitID);
						}
						break;

					case 4:
						F0_1866_1931_FoundSkilledMercenaries(playerID, unitID);
						break;

					default:
						break;
				}
			}
		}

		private void F0_1866_1931_FoundMetalDeposits(int playerID, int unitID)
		{
			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1a96, size: 5
				this.oParent.CAPI.strcpy(0xba06, "You have discovered\nvaluable metal deposits\nworth 50$\n");

				// Instruction address 0x1866:0x1ab2, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}

			this.oParent.GameData.Players[playerID].Coins += 50;
		}

		private void F0_1866_1931_FoundAdvancedTribe(int playerID, int unitID)
		{
			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1a2d, size: 5
				this.oParent.CAPI.strcpy(0xba06, "You have discovered\nan advanced tribe.\n");

				// Instruction address 0x1866:0x1a49, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}

			this.oParent.Overlay_20.F20_0000_0000(playerID,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.X, this.oParent.GameData.Players[playerID].Units[unitID].Position.Y, 1);

			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1d47, size: 5
				this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);
			}
		}

		private void F0_1866_1931_FoundSkilledMercenaries(int playerID, int unitID)
		{
			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1ba2, size: 5
				this.oParent.CAPI.strcpy(0xba06, "You have discovered\na friendly tribe of\nskilled mercenaries.\n");

				// Instruction address 0x1866:0x1bbe, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}

			// Instruction address 0x1866:0x1d2d, size: 3
			F0_1866_0cf5_CreateUnit(playerID, (this.oParent.CAPI.RNG.Next(2) != 0) ? 3 : 6,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1d47, size: 5
				this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);
			}
		}

		private void F0_1866_1931_FoundAncientWisdom(int playerID, int unitID)
		{
			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1acf, size: 5
				this.oParent.CAPI.strcpy(0xba06, "You have discovered\nscrolls of ancient wisdom.\n");

				// Instruction address 0x1866:0x1aeb, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}

			// Compile a list of yet undiscovered technologies that have all of the prerequisites
			List<TechnologyEnum> undiscoveredTech = new();

			foreach (TechnologyEnum technology in Enum.GetValues(typeof(TechnologyEnum)))
			{
				if (technology != TechnologyEnum.None && technology != TechnologyEnum.NewFutureTechnology &&
					!this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, technology) &&
					this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, this.oParent.GameData.Technologies[(int)technology].RequiresTechnology1) &&
					this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, this.oParent.GameData.Technologies[(int)technology].RequiresTechnology2))
				{
					undiscoveredTech.Add(technology);
				}
			}

			if (undiscoveredTech.Count > 0)
			{
				int index = this.oParent.CAPI.RNG.Next(undiscoveredTech.Count);

				this.oParent.Segment_1ade.F0_1ade_1d2e(playerID, undiscoveredTech[index], 0);
			}
			else
			{
				F0_1866_1931_FoundMetalDeposits(playerID, unitID);
			}
		}

		private void F0_1866_1931_FoundBarbarians(int playerID, int unitID)
		{
			if (playerID == this.oParent.GameData.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1c07, size: 5
				this.oParent.CAPI.strcpy(0xba06, "You have unleashed\na horde of barbarians!\n");

				// Instruction address 0x1866:0x1c23, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}

			for (int i = 1; i < 9;)
			{
				GPoint direction = this.oParent.MoveDirections[i];

				int newX = this.oParent.GameData.Players[playerID].Units[unitID].Position.X + direction.X;
				int newY = this.oParent.GameData.Players[playerID].Units[unitID].Position.Y + direction.Y;

				// Instruction address 0x1866:0x1ccd, size: 5
				if (this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(newX, newY) == -1 &&
					!this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newX, newY).HasFlag(TerrainImprovementFlagsEnum.City))
				{
					// Instruction address 0x1866:0x1cf0, size: 5
					if (this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY) != TerrainTypeEnum.Water)
					{
						// Instruction address 0x1866:0x1c43, size: 3
						int newUnitID = F0_1866_0cf5_CreateUnit(0, 
							(this.oParent.GameData.Terrains[(int)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(newX, newY)].MovementCost < 3) ? 6 : 3, newX, newY);

						// In case our unit count has reached capacity
						if (newUnitID != -1)
						{
							this.oParent.GameData.Players[0].Units[newUnitID].VisibleByPlayer |= (ushort)(1 << playerID);
						}

						if (playerID == this.oParent.GameData.HumanPlayerID)
						{
							// Instruction address 0x1866:0x1c69, size: 5
							this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(newX, newY);
						}
					}
				}
				// Instruction address 0x1866:0x1c86, size: 5
				i += this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(4 - this.oParent.GameData.Players[playerID].CityCount, 1, 4);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="moveDirection"></param>
		public void F0_1866_1d55(int playerID, int unitID, int moveDirection)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1d55({playerID}, {unitID}, {moveDirection})");

			// function body
			// Instruction address 0x1866:0x1d8b, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			GPoint direction = this.oParent.MoveDirections[moveDirection];

			// Instruction address 0x1866:0x1dae, size: 5
			if (this.oParent.MapManagement.F0_2aea_03ba_DrawCell(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) &&
				this.oParent.CheckPlayerTurn.F0_1403_4508(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) &&
				this.oParent.CheckPlayerTurn.F0_1403_4508(this.oParent.GameData.Players[playerID].Units[unitID].Position.X + direction.X,
					this.oParent.GameData.Players[playerID].Units[unitID].Position.Y + direction.Y))
			{
				if (this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID != -1 &&
					(this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
						this.oParent.GameData.Players[playerID].Units[unitID].Position.Y) != TerrainTypeEnum.Water ||
					this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID].TypeID].MovementType == UnitMovementTypeEnum.Water))
				{
					// Instruction address 0x1866:0x1e59, size: 5
					this.oParent.MapManagement.F0_2aea_0e29_DrawUnit(playerID, this.oParent.GameData.Players[playerID].Units[unitID].NextUnitID);
				}

				// Instruction address 0x1866:0x1e7f, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 80, 0, 240, 200, this.oParent.Var_19d4_Rectangle, 80, 0);

				// Instruction address 0x1866:0x1ea2, size: 5
				int mapX = this.oParent.MapManagement.F0_2e31_119b_AdjustMapXPosition(this.oParent.GameData.Players[playerID].Units[unitID].Position.X - this.oParent.Var_d4cc_MapViewX) * 16 + 80;
				int mapY = (this.oParent.GameData.Players[playerID].Units[unitID].Position.Y - this.oParent.Var_d75e_MapViewY) * 16 + 8;

				for (int i = 0; i < 17; i++)
				{
					direction = this.oParent.MoveDirections[moveDirection];

					// Instruction address 0x1866:0x1f0a, size: 5
					this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
						(direction.X * i) + mapX + 1, (direction.Y * i) + mapY + 1,
						this.oParent.Array_d4ce[64 + this.oParent.GameData.Players[playerID].Units[unitID].TypeID + (playerID * 32)]);

					// Instruction address 0x1866:0x1f16, size: 5
					this.oParent.CommonTools.F0_1182_0134_WaitTimer(1);

					int newX = direction.X * i + mapX;
					int newY = direction.Y * i + mapY;

					// Instruction address 0x1866:0x1f4a, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
						newX, newY, 16, 16, this.oParent.Var_aa_Rectangle, newX, newY);
				}
			}

			// Instruction address 0x1866:0x1f5e, size: 5
			this.oParent.MainCode.F0_11a8_0250();
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public int F0_1866_1f69(int playerID, int unitID)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_1f69({playerID}, {unitID})");

			// function body
			// Instruction address 0x1866:0x1f71, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x1866:0x1f81, size: 3
			int selectedUnitID = F0_1866_1089(playerID, unitID);
			int[] unitIDs = new int[12];
			int nextUnitID = unitID;
			int unitCount = 0;

			do
			{
				unitIDs[unitCount] = nextUnitID;
				nextUnitID = this.oParent.GameData.Players[playerID].Units[nextUnitID].NextUnitID;

				unitCount++;
			}
			while (unitCount < 12 && nextUnitID != -1 && nextUnitID != unitID);

			int yTop = 96 - unitCount * 8;

		L1fe2:
			// Instruction address 0x1866:0x1ffc, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_096c_FillRectangleWithDoubleShadow(100, yTop, 120, (unitCount * 16) + 5, 3);

			unitCount = 0;
			nextUnitID = unitID;
			int unitYPos = yTop + 5;

			do
			{
				// Instruction address 0x1866:0x2025, size: 5
				this.oParent.MapManagement.F0_2aea_0fb3_DrawUnitWithStatus(playerID, nextUnitID, 106, unitYPos);

				// Instruction address 0x1866:0x204b, size: 5
				this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[nextUnitID].TypeID].Name);

				if ((this.oParent.GameData.Players[playerID].Units[nextUnitID].Status & 0x20) != 0)
				{
					// Instruction address 0x1866:0x2062, size: 5
					this.oParent.CAPI.strcat(0xba06, " (V)");
				}

				// Instruction address 0x1866:0x2079, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, 128, unitYPos, 15);

				// Instruction address 0x1866:0x209c, size: 5
				this.oParent.CAPI.strcat(0xba06, this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oParent.GameData.Players[playerID].Units[nextUnitID].HomeCityID));

				// Instruction address 0x1866:0x20b7, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(0xba06, 128, unitYPos + 8, 14);

				nextUnitID = this.oParent.GameData.Players[playerID].Units[nextUnitID].NextUnitID;

				unitYPos += 16;
				unitCount++;
			}
			while (unitCount < 12 && nextUnitID != -1 && nextUnitID != unitID);

			// Instruction address 0x1866:0x20e4, size: 5
			this.oParent.MainCode.F0_11a8_0250();

			// Instruction address 0x1866:0x20e9, size: 5
			this.oParent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();

			do
			{
				// Instruction address 0x1866:0x20f5, size: 5
				this.oParent.MainCode.F0_11a8_0223_UpdateMouseState();
			}
			while (this.oParent.Var_db3a_MouseButton == 0 && this.oParent.CAPI.kbhit() == 0);

			// Instruction address 0x1866:0x21b7, size: 5
			this.oParent.MainCode.F0_11a8_0268();

			if (this.oParent.Var_db3a_MouseButton == 1 && this.oParent.Var_db3c_MouseXPos > 100 && this.oParent.Var_db3c_MouseXPos < 220)
			{
				nextUnitID = (this.oParent.Var_db3e_MouseYPos - yTop - 5) / 16;

				if (nextUnitID >= 0 && nextUnitID < unitCount)
				{
					selectedUnitID = unitIDs[nextUnitID];

					if ((this.oParent.GameData.Players[playerID].Units[selectedUnitID].Status & 0xc2) != 0)
					{
						this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves =
							(short)(this.oParent.GameData.Units[this.oParent.GameData.Players[playerID].Units[selectedUnitID].TypeID].MoveCount * 3);
					}

					this.oParent.GameData.Players[playerID].Units[selectedUnitID].Status &= 0x30;
					this.oParent.GameData.Players[playerID].Units[selectedUnitID].GoToDestination.X = -1;

					// !!!!! This looks like a closed loop
					if (unitCount > 1) goto L1fe2;
				}
			}

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x1866:0x225a, size: 5
			this.oParent.MainCode.F0_11a8_0250();

			// Instruction address 0x1866:0x225f, size: 5
			this.oParent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();

			return selectedUnitID;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public int F0_1866_226d(int playerID, int unitID)
		{
			// this.oCPU.Log.EnterBlock($"F0_1866_226d({playerID}, {unitID})");

			// function body
			int distance;
			int minDistance = 999;
			int selectedDirection;
			int xPos = 0;
			int yPos = 0;

			for (int i = 0; i < 128; i++)
			{
				if (this.oParent.GameData.Cities[i].StatusFlag != 0xff && this.oParent.GameData.Cities[i].PlayerID == playerID)
				{
					int x = Math.Abs(this.oParent.GameData.Players[playerID].Units[unitID].Position.X - this.oParent.GameData.Cities[i].Position.X);

					if (x > 40)
					{
						x = 80 - x;
					}
				
					int y = Math.Abs(this.oParent.GameData.Players[playerID].Units[unitID].Position.Y - this.oParent.GameData.Cities[i].Position.Y);

					if (x < y)
					{
						distance = y;
					}
					else
					{
						distance = x;
					}

					if (distance < minDistance)
					{
						minDistance = distance;
						xPos = this.oParent.GameData.Cities[i].Position.X;
						yPos = this.oParent.GameData.Cities[i].Position.Y;
					}
				}
			}

			for (int i = 0; i < 128; i++)
			{
				if (this.oParent.GameData.Players[playerID].Units[i].TypeID == 23)
				{
					// Instruction address 0x1866:0x239d, size: 5
					int x = Math.Abs(this.oParent.GameData.Players[playerID].Units[unitID].Position.X - this.oParent.GameData.Players[playerID].Units[i].Position.X);

					if (x > 40)
					{
						x = 80 - x;
					}

					int y = Math.Abs(this.oParent.GameData.Players[playerID].Units[unitID].Position.Y - this.oParent.GameData.Players[playerID].Units[i].Position.Y);

					if (x < y)
					{
						distance = y;
					}
					else
					{
						distance = x;
					}

					if (distance < minDistance)
					{
						minDistance = distance;
						xPos = this.oParent.GameData.Players[playerID].Units[i].Position.X;
						yPos = this.oParent.GameData.Players[playerID].Units[i].Position.Y;
					}
				}
			}

			selectedDirection = 0;

			// Instruction address 0x1866:0x244c, size: 5
			minDistance = (short)this.oParent.Segment_2dc4.F0_2dc4_0243(
				this.oParent.GameData.Players[playerID].Units[unitID].Position.X - xPos,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.Y - yPos);

			for (int i = 1; i < 9; i++)
			{
				GPoint direction = this.oParent.MoveDirections[i];

				int x = this.oParent.GameData.Players[playerID].Units[unitID].Position.X + direction.X;
				int y = this.oParent.GameData.Players[playerID].Units[unitID].Position.Y + direction.Y;

				// Instruction address 0x1866:0x248f, size: 5
				int local_2 = this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(x, y);

				if (local_2 != -1 && local_2 != playerID)
				{
					// Instruction address 0x1866:0x24ad, size: 5
					if (!this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(x, y).HasFlag(TerrainImprovementFlagsEnum.City) ||
						this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(x, y) == playerID)
					{
						// Instruction address 0x1866:0x24da, size: 5
						distance = this.oParent.Segment_2dc4.F0_2dc4_0243(x - xPos, y - yPos);

						if (distance < minDistance)
						{
							minDistance = distance;
							selectedDirection = i;
						}
					}
				}
			}

			return selectedDirection;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1866_260e()
		{
			//this.oCPU.Log.EnterBlock("F0_1866_260e()");

			// function body
			// Instruction address 0x1866:0x261a, size: 5
			int x = this.oParent.CAPI.RNG.Next(2) * 32 + 192;
			int y = 120;

			// Instruction address 0x1866:0x2649, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x, 120, 8, 8, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x1866:0x2670, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x + 8, 120, 8, 8, this.oParent.Var_aa_Rectangle, 312, 0);

			// Instruction address 0x1866:0x2698, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x + 24, 120, 8, 8, this.oParent.Var_aa_Rectangle, 312, 192);

			// Instruction address 0x1866:0x26bf, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x + 16, 120, 8, 8, this.oParent.Var_aa_Rectangle, 0, 192);

			for (int i = 1; i < 24; i++)
			{
				// Instruction address 0x1866:0x26f2, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x + 24, y + 8, 8, 8, this.oParent.Var_aa_Rectangle, 0, i * 8);

				// Instruction address 0x1866:0x2714, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x + 8, y + 8, 8, 8, this.oParent.Var_aa_Rectangle, 312, i * 8);
			}

			for (int i = 1; i < 39; i++)
			{
				// Instruction address 0x1866:0x274c, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x, y + 8, 8, 8, this.oParent.Var_aa_Rectangle, i * 8, 0);

				// Instruction address 0x1866:0x276e, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, x + 16, y + 8, 8, 8, this.oParent.Var_aa_Rectangle, i * 8, 192);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1})");

			// function body
			if (this.oParent.GameData.ReplayDataLength + 3 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameData.TurnCount & 0xfff));

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data1;
				this.oParent.GameData.ReplayDataLength++;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1, byte data2)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1}, {data2})");

			// function body
			if (this.oParent.GameData.ReplayDataLength + 4 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameData.TurnCount & 0xfff));

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data1;
				this.oParent.GameData.ReplayDataLength++;
				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data2;
				this.oParent.GameData.ReplayDataLength++;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		/// <param name="data3"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1, byte data2, byte data3)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1}, {data2}, {data3})");

			// function body
			if (this.oParent.GameData.ReplayDataLength + 5 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameData.TurnCount & 0xfff));

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data1;
				this.oParent.GameData.ReplayDataLength++;
				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data2;
				this.oParent.GameData.ReplayDataLength++;
				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data3;
				this.oParent.GameData.ReplayDataLength++;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		/// <param name="data3"></param>
		/// <param name="data4"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1, byte data2, byte data3, byte data4)
		{
			//this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1}, {data2}, {data3}, {data4})");

			// function body
			if (this.oParent.GameData.ReplayDataLength + 6 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameData.TurnCount & 0xfff));

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameData.ReplayDataLength++;

				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data1;
				this.oParent.GameData.ReplayDataLength++;
				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data2;
				this.oParent.GameData.ReplayDataLength++;
				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data3;
				this.oParent.GameData.ReplayDataLength++;
				this.oParent.GameData.ReplayData[this.oParent.GameData.ReplayDataLength] = data4;
				this.oParent.GameData.ReplayDataLength++;
			}
		}
	}
}
