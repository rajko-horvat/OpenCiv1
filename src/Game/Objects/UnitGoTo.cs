using System;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	/// <summary>
	/// This class encapsulates new GoTo algorithm.
	/// The old Goto Algorithm is included for archival purposes. It is unreliable and produces array index out of bounds often.
	/// </summary>
	public class UnitGoTo
	{
		private OpenCiv1Game parent;
		private GameData gameData;

		private int Var_6590_DestinationX = -1;
		private int Var_6592_DestinationY = -1;
		public int[] Arr_6594_PathX = new int[256];
		public int[] Arr_6694_PathY = new int[256];
		public int Var_6794 = 0;
		public int Var_6796_LastDestinationX = 0;
		public int Var_6798_LastDestinationY = 0;
		public int[,] Arr_b780 = new int[16, 16];
		public int[,] Arr_d816 = new int[20, 13]; // Divided by 4
		public int[,] Arr_db44_LandPath = new int[20, 13]; // Divided by 4
		public int[,] Arr_7f38_WaterPath = new int[20, 13]; // Divided by 4

		public UnitGoTo(OpenCiv1Game parent)
		{
			this.parent = parent;
			this.gameData = parent.GameData;

			// Ensure that all arrays contain zero value initially

			for (int i = 0; i < this.Arr_6594_PathX.Length; i++)
			{
				this.Arr_6594_PathX[i] = 0;
			}

			for (int i = 0; i < this.Arr_6694_PathY.Length; i++)
			{
				this.Arr_6694_PathY[i] = 0;
			}

			for (int i = 0; i < this.Arr_db44_LandPath.GetLength(0); i++)
			{
				for (int j = 0; j < this.Arr_db44_LandPath.GetLength(1); j++)
				{
					this.Arr_db44_LandPath[i, j] = 0;
				}
			}

			for (int i = 0; i < this.Arr_7f38_WaterPath.GetLength(0); i++)
			{
				for (int j = 0; j < this.Arr_7f38_WaterPath.GetLength(1); j++)
				{
					this.Arr_7f38_WaterPath[i, j] = 0;
				}
			}

			for (int i = 0; i < this.Arr_b780.GetLength(0); i++)
			{
				for (int j = 0; j < this.Arr_b780.GetLength(1); j++)
				{
					this.Arr_b780[i, j] = 0;
				}
			}

			for (int i = 0; i < this.Arr_d816.GetLength(0); i++)
			{
				for (int j = 0; j < this.Arr_d816.GetLength(1); j++)
				{
					this.Arr_d816[i, j] = 0;
				}
			}
		}

		/// <summary>
		/// Gets the next position that this unit should move to
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public int GetNextGoToMove(int playerID, int unitID)
		{
			Unit unit;

			if (playerID > 0 && (this.parent.GameData.ActiveCivilizations & (1 << playerID)) != 0 && unitID >= 0 && unitID < 128 &&
				(unit = this.parent.GameData.Players[playerID].Units[unitID]).TypeID != -1)
			{
				unit.PlayerID = (short)playerID;

				return GetNextGoToMove(unit, true);
			}

			return -1;
		}

		/// <summary>
		/// Gets the next position that this unit should move to
		/// </summary>
		public int GetNextGoToMove(Unit unit, bool testVisibility)
		{
			int direction = -1;

			unit.GoToNextDirection = -1;

			if (this.parent.MapManagement.F0_2aea_1326_ValidateMapCoordinates(unit.GoToDestination) && unit.Position != unit.GoToDestination)
			{
				if (unit.GoToPath.Count == 0)
				{
					this.FindGoToPath(unit, testVisibility);
				}

				if (unit.GoToPath.Count == 0)
				{
					// We couldn't find a path for a destination
					unit.GoToDestination = OpenCiv1Game.InvalidPosition;
					unit.GoToPath.Clear();
					unit.GoToNextDirection = -1;
				}
				else
				{
					GPoint newPos = unit.GoToPath.Pop();

					direction = this.parent.MapManagement.GetMoveOffset(newPos - unit.Position);
					unit.GoToNextDirection = (short)direction;
				}
			}

			return direction;
		}

		/// <summary>
		/// Validates if the given destination coordinates are reachable for a given unit movement type
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dest"></param>
		/// <param name="movementType"></param>
		/// <param name="maxMoves"></param>
		/// <returns></returns>
		public int GetGoToDistance(int srcX, int srcY, int dstX, int dstY, UnitMovementTypeEnum movementType, int maxMoves)
		{
			return GetGoToDistance(new GPoint(srcX, srcY), new GPoint(dstX, dstY), movementType, maxMoves);
		}

		/// <summary>
		/// Validates if the given destination coordinates are reachable for a given unit movement type
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dest"></param>
		/// <param name="movementType"></param>
		/// <param name="maxMoves"></param>
		/// <returns></returns>
		public int GetGoToDistance(GPoint src, GPoint dest, UnitMovementTypeEnum movementType, int maxMoves)
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
					return -1;
			}

			FindGoToPath(unit, false);

			int distance = -1;

			if (unit.GoToDestination != OpenCiv1Game.InvalidPosition && unit.GoToPath.Count > 0 && unit.GoToPath.Count < maxMoves)
			{
				distance = unit.GoToPath.Count;
			}

			return distance;
		}

		/// <summary>
		/// Validates if the given destination coordinates are reachable for a given unit movement type
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dest"></param>
		/// <param name="movementType"></param>
		/// <param name="maxMoves"></param>
		/// <returns></returns>
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

			FindGoToPath(unit, false);

			return unit.GoToDestination != OpenCiv1Game.InvalidPosition && unit.GoToPath.Count > 0 && unit.GoToPath.Count < maxMoves;
		}

		#region AStar (A*) Path finding algorithm
		/// <summary>
		/// A Function to find the shortest path between tho points according to AStar (A*) Algorithm
		/// </summary>
		/// <param name="unit"></param>
		/// <param name="testVisibility">ID of the unit</param>
		private void FindGoToPath(Unit unit, bool testVisibility)
		{
			if (unit.GoToDestination != OpenCiv1Game.InvalidPosition)
			{
				bool destinationReached = false; // remains false if we can't find a path to a destination
				TerrainMapGroupTypeEnum group1; // The unit can move on this terrain type
				TerrainMapGroupTypeEnum group2; // The unit can move on this terrain type
				UnitMovementTypeEnum movementType = this.gameData.Units[unit.TypeID].MovementType;
				MapManagement map = this.parent.MapManagement;
				
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

				// Rules to satisfy:
				// Source or destination cell position is out of range
				// Destination is the same as the source position
				// Destination has to be in the same movement group that the unit is
				// For the unit that is moving on Land or Water we have to be on the same group
				// Destination cell has to be visible to the Player
				if (!map.F0_2aea_1326_ValidateMapCoordinates(unit.Position) || !map.F0_2aea_1326_ValidateMapCoordinates(unit.GoToDestination) ||
					unit.Position == unit.GoToDestination ||
					(map.GetGroupType(unit.GoToDestination) != group1 && map.GetGroupType(unit.GoToDestination) != group2) ||
					(movementType != UnitMovementTypeEnum.Air && map.F0_2aea_1942_GetGroupID(unit.Position.X, unit.Position.Y) != map.F0_2aea_1942_GetGroupID(unit.GoToDestination.X, unit.GoToDestination.Y)) ||
					(testVisibility && (this.parent.GameData.MapVisibility[unit.GoToDestination.X, unit.GoToDestination.Y] & (1 << unit.PlayerID)) == 0))
				{
					return;
				}

				AStarCell[,] cells = new AStarCell[80, 50];

				for (int i = 0; i < cells.GetLength(0); i++)
				{
					for (int j = 0; j < cells.GetLength(1); j++)
					{
						cells[i, j] = new AStarCell(i, j);
					}
				}

				// Create a sorted open list in descending order (sorted from higher to lower value)
				// We compare this list by cell's f value
				List<AStarCell> openCells = new List<AStarCell>();

				// Initialize start cell
				AStarCell cell = cells[unit.Position.X, unit.Position.Y];
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
							if (map.F0_2aea_1326_ValidateMapCoordinates(newPos))
							{
								AStarCell newCell = cells[newPos.X, newPos.Y];

								if (map.GetGroupType(newPos.X, newPos.Y) == group1 || map.GetGroupType(newPos.X, newPos.Y) == group2)
								{
									// If the destination cell is the same as the current successor cell
									// we have reached our destination
									if (newPos == unit.GoToDestination)
									{
										newCell.GCost = cell.GCost + VisibleMovementCost(unit.PlayerID, newPos.X, newPos.Y);
										newCell.HCost = 0.0;
										newCell.FCost = newCell.GCost + newCell.HCost;
										newCell.ParentPos = pos;

										destinationReached = true;
										continue;
									}

									// Ignore the successor cell if it is closed or blocked
									if (!newCell.IsCellClosed &&
										(!testVisibility || (this.gameData.MapVisibility[newPos.X, newPos.Y] & (1 << unit.PlayerID)) != 0))
									{
										double newGCost = cell.GCost + VisibleMovementCost(unit.PlayerID, newPos.X, newPos.Y);
										double newHCost = map.GetDistance(newPos, unit.GoToDestination);
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
					while ((cell = cells[pos.X, pos.Y]).ParentPos != pos)
					{
						unit.GoToPath.Push(pos); // Store in reverse order
						pos = cell.ParentPos;
					}
				}
			}
		}

		/// <summary>
		/// Movement cost based on currently visible terrain and improvements
		/// </summary>
		private double VisibleMovementCost(int playerID, int x, int y)
		{
			MapManagement map = this.parent.MapManagement;
			TerrainDefinition terrain = this.gameData.Terrains[(int)map.F0_2aea_134a_GetTerrainType(x, y)];
			TerrainImprovementFlagsEnum improvements = map.F0_2aea_1585_GetVisibleTerrainImprovements(x, y);
			double dValue = terrain.MovementCost;

			if (improvements.HasFlag(TerrainImprovementFlagsEnum.Road)) // road
			{
				dValue = 1.0 / 3.0;
			}

			if (improvements.HasFlag(TerrainImprovementFlagsEnum.RailRoad)) // railroad
			{
				dValue = 0.0;
			}

			// Increase movement cost for nearby enemy units and cities

			if (this.parent.UnitManagement.IsEnemyCityNear(playerID, x, y, 1))
			{
				// this cell is blocked
				dValue = double.MaxValue;
			}
			else
			{
				if (this.parent.UnitManagement.IsEnemyCityNear(playerID, x, y, 2))
				{
					// this cell has enemy city near, increase cost to avoid it if possible
					dValue += 1.0;
				}

				if (this.parent.UnitManagement.IsEnemyUnitNear(playerID, x, y, 2))
				{
					// this cell has enemy unit near, increase cost to avoid it if possible
					dValue += 1.0;
				}
			}

			return dValue;
		}

		private class AStarCell
		{
			public GPoint Position = new GPoint(-1);
			public GPoint ParentPos = new GPoint(-1); // Position of our parent cell
			public double GCost = double.MaxValue;
			public double HCost = double.MaxValue;
			public double FCost = double.MaxValue; // FCost = GCost + HCost
			public bool IsCellClosed = false;

			public AStarCell(int x, int y)
			{
				this.Position = new GPoint(x, y);
			}
		}
		#endregion

		#region Old unfixable GoTo algorithm
		/// <summary>
		/// Checks if there is path from start to destination for a given unit
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="x1"></param>
		/// <param name="y1"></param>
		/// <param name="waterUnit"></param>
		/// <param name="param6"></param>
		/// <returns></returns>
		public int F0_2e31_111c_CheckUnitPath(int x, int y, int x1, int y1, bool waterUnit, short param6)
		{
			//this.oParent.GoToLog.EnterBlock($"F0_2e31_111c({xPos}, {yPos}, {xPos1}, {yPos1}, {flag}, {param6})");

			// function body
			int result = -1;

			if (Math.Abs(x - x1) <= 7 && Math.Abs(y - y1) <= 7)
			{
				// Temporary unit...
				Unit unit = this.parent.GameData.Players[0].Units[127];

				unit.TypeID = (short)(waterUnit ? UnitTypeEnum.Trireme : UnitTypeEnum.Militia);
				unit.Position.X = x;
				unit.Position.Y = y;
				unit.GoToDestination.X = x1;
				unit.GoToDestination.Y = y1;

				this.Var_6590_DestinationX = (short)x1;
				this.Var_6592_DestinationY = (short)y1;

				// Instruction address 0x2e31:0x117c, size: 3
				result = F0_2e31_0c1d_FindShortestPath(unit, param6);

				unit.TypeID = -1;
				unit.Position.X = -1;
				unit.Position.Y = -1;
				unit.GoToDestination.X = -1;
				unit.GoToDestination.Y = -1;

				if (result != -1)
				{
					result = this.Var_6794;
				}
			}

			return result;
		}

		/// <summary>
		/// Gets next move unit should take on it's path
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public int F0_2e31_000e_GetNextMove(int playerID, int unitID)
		{
			//this.oParent.GoToLog.EnterBlock($"F0_2e31_000e({playerID}, {unitID})");
			//OpenCiv1Game.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oParent.GameData.HumanPlayerID);

			// function body
			Unit unit;

			if (playerID < 0 || playerID > 7 || unitID < 0 || unitID > 127 ||
				(unit = this.parent.GameData.Players[playerID].Units[unitID]).TypeID == -1 || unit.GoToDestination.X == -1)
			{
				return -1;
			}

			GPoint move = unit.GoToDestination - unit.Position;
			GPoint absMove = GPoint.Abs(move);

			if (playerID == this.parent.GameData.HumanPlayerID && absMove.X < 2 && absMove.Y < 2)
			{
				move.X = (absMove.X >= 40) ? -Math.Sign(move.X) : Math.Sign(move.X);
				move.Y = Math.Sign(move.Y);

				unit.GoToDestination = new GPoint(-1);

				for (int i = 1; i < 9; i++)
				{
					if (this.parent.MoveDirections[i] == move)
					{
						return i;
					}
				}

				return -1;
			}

			if (this.parent.GameData.Units[unit.TypeID].MovementType == UnitMovementTypeEnum.Air)
			{
				this.Var_6590_DestinationX = unit.GoToDestination.X;
				this.Var_6592_DestinationY = unit.GoToDestination.Y;
			}
			else
			{
				bool local_e = false;

				if (absMove.Y > 6 || (absMove.X > 6 && absMove.X < 74))
				{
					this.Var_6590_DestinationX = unit.GoToDestination.X;
					this.Var_6592_DestinationY = unit.GoToDestination.Y;

					// Instruction address 0x2e31:0x01bf, size: 3
					int moveDirection = F0_2e31_0c1d_FindShortestPath(unit, 999);

					if (moveDirection != -1)
					{
						return moveDirection;
					}

					local_e = true;
				}

				// Instruction address 0x2e31:0x01df, size: 3
				if (F0_2e31_05e6(unit) || !local_e)
				{
					// Instruction address 0x2e31:0x01fa, size: 3
					int moveDirection = F0_2e31_0c1d_FindShortestPath(unit, 999);

					if (moveDirection != -1)
					{
						return moveDirection;
					}
				}
			}

			move.X = this.Var_6590_DestinationX - unit.Position.X;
			move.Y = this.Var_6592_DestinationY - unit.Position.Y;
			absMove = GPoint.Abs(move);
			int vector = (absMove.X > absMove.Y) ? Math.Abs(move.X) : Math.Abs(move.Y) + absMove.X + absMove.Y;

			if (move.X == 0 && move.Y == 0)
			{
				unit.GoToDestination.X = -1;
				unit.GoToNextDirection = -1;
				unit.RemainingMoves = 0;

				return -1;
			}
			else
			{
				// Instruction address 0x2e31:0x02c8, size: 5
				TerrainImprovementFlagsEnum terrainImprovements = this.parent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(unit.Position.X, unit.Position.Y);

				// Instruction address 0x2e31:0x02e5, size: 5
				bool unitIsNear = this.parent.UnitManagement.F0_1866_1725_IsUnitNear(playerID, unit.Position.X, unit.Position.Y);
				int newDistance = 9999;
				int newMoveDirection = 0;

				for (int i = 1; i < 9; i++)
				{
					GPoint direction = this.parent.MoveDirections[i];
					int unitNewX = unit.Position.X + direction.X;
					int unitNewY = unit.Position.Y + direction.Y;
					absMove.X = Math.Abs(move.X - direction.X);
					absMove.Y = Math.Abs(move.Y - direction.Y);
					int newVector = ((absMove.X <= absMove.Y) ? absMove.Y : absMove.X) + absMove.X + absMove.Y;

					if (playerID != this.parent.GameData.HumanPlayerID || newVector <= vector)
					{
						// Instruction address 0x2e31:0x03b7, size: 5
						TerrainTypeEnum newTerrainType = this.parent.MapManagement.F0_2aea_134a_GetTerrainType(unitNewX, unitNewY);

						// Instruction address 0x2e31:0x03c8, size: 5
						int cellOwner = this.parent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(unitNewX, unitNewY);

						if (((cellOwner == -1 || cellOwner == playerID) &&
							((((this.parent.GameData.Units[unit.TypeID].MovementType == UnitMovementTypeEnum.Water) ? 1 : 0) == (newTerrainType == TerrainTypeEnum.Water ? 1 : 0) &&
								(!unitIsNear || !this.parent.UnitManagement.F0_1866_1725_IsUnitNear(playerID, unitNewX, unitNewY))) ||
								this.parent.GameData.Units[unit.TypeID].MovementType == UnitMovementTypeEnum.Air)) ||
							(this.parent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(unitNewX, unitNewY).HasFlag(TerrainImprovementFlagsEnum.City) &&
								this.parent.MapManagement.F0_2aea_1369_GetCityOwner(unitNewX, unitNewY) == playerID))
						{
							if (newTerrainType != TerrainTypeEnum.Water || this.parent.MapManagement.F0_2aea_195d_GetMapGroupSize(unitNewX, unitNewY) >= 5)
							{
								int movementCost;

								if (terrainImprovements.HasFlag(TerrainImprovementFlagsEnum.Road) &&
									this.parent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(unitNewX, unitNewY).HasFlag(TerrainImprovementFlagsEnum.Road))
								{
									movementCost = 1;
								}
								else
								{
									movementCost = ((this.parent.GameData.Units[unit.TypeID].MoveCount > 1) ? (this.parent.GameData.Terrains[(int)newTerrainType].MovementCost * 3) : 3);
								}

								movementCost += (newVector * 4) + absMove.X + absMove.Y;

								if (unit.GoToNextDirection != -1)
								{
									int movement = Math.Abs(unit.GoToNextDirection - i);

									if (movement > 4)
									{
										movement = 8 - movement;
									}

									movementCost += movement * movement;
								}

								if (movementCost < newDistance)
								{
									newMoveDirection = i;
									newDistance = movementCost;
								}
							}
						}
					}
				}

				if (unit.GoToNextDirection != -1)
				{
					if ((unit.GoToNextDirection ^ 0x4) == newMoveDirection)
					{
						unit.RemainingMoves = 0;

						newMoveDirection = 0;
					}
				}

				if (newMoveDirection == 0)
				{
					unit.GoToDestination.X = -1;
					unit.GoToNextDirection = -1;

					return -1;
				}
				else
				{
					unit.GoToNextDirection = (short)newMoveDirection;

					return newMoveDirection;
				}
			}
		}

		/// <summary>
		/// Checks if there is a more favorable path available
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		private bool F0_2e31_05e6(Unit unit)
		{
			//this.oParent.GoToLog.EnterBlock($"F0_2e31_05e6({playerID}, {unitID})");
			//OpenCiv1Game.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oParent.GameData.HumanPlayerID);

			// function body
			bool waterUnit = this.parent.GameData.Units[unit.TypeID].MovementType == UnitMovementTypeEnum.Water;
			int local_a = 0;
			int unitX = unit.Position.X;
			int unitY = unit.Position.Y;
			this.Var_6590_DestinationX = unit.GoToDestination.X;
			this.Var_6592_DestinationY = unit.GoToDestination.Y;

			if (!F0_2e31_0a2c_CanUnitMove(unitX, unitY, waterUnit))
			{
				this.Var_6590_DestinationX = unit.GoToDestination.X;
				this.Var_6592_DestinationY = unit.GoToDestination.Y;

				return false;
			}

			unitX = this.Var_6590_DestinationX;
			unitY = this.Var_6592_DestinationY;

			// Instruction address 0x2e31:0x06a7, size: 3
			F0_2e31_0a2c_CanUnitMove(unit.GoToDestination.X, unit.GoToDestination.Y, waterUnit);

			// Instruction address 0x2e31:0x06b8, size: 5
			for (int i = 0; i < this.Arr_d816.GetLength(0); i++)
			{
				for (int j = 0; j < this.Arr_d816.GetLength(1); j++)
				{
					this.Arr_d816[i, j] = 0;
				}
			}

			int pathCount1 = 0;
			int pathCount2 = 0;

			this.Arr_6594_PathX[pathCount1] = this.Var_6590_DestinationX;
			this.Arr_6694_PathY[pathCount1] = this.Var_6592_DestinationY;

			pathCount1++;

			this.Arr_d816[this.Var_6590_DestinationX, this.Var_6592_DestinationY] = 1;

			bool oldPath = false;

			do
			{
				int prevPathX = this.Arr_6594_PathX[pathCount2];
				int prevPathY = this.Arr_6694_PathY[pathCount2];

				if (prevPathX != unitX || prevPathY != unitY)
				{
					int pathFlags;

					local_a = this.Arr_d816[prevPathX, prevPathY];

					pathCount2++;
					pathCount2 &= 0xff;

					if (waterUnit)
					{
						pathFlags = this.Arr_7f38_WaterPath[prevPathX, prevPathY];
					}
					else
					{
						pathFlags = this.Arr_db44_LandPath[prevPathX, prevPathY];
					}

					for (int i = 1; i < 9; i++)
					{
						if ((pathFlags & (0x1 << (i - 1))) != 0)
						{
							GPoint direction = this.parent.MoveDirections[i];

							int newX = prevPathX + direction.X;

							if (newX == 20)
							{
								newX = 0;
							}

							if (newX == -1)
							{
								newX = 19;
							}

							int newY = prevPathY + direction.Y;

							if (this.Arr_d816[newX, newY] == 0)
							{
								this.Arr_d816[newX, newY] = local_a + 1;
								this.Arr_6594_PathX[pathCount1] = newX;
								this.Arr_6694_PathY[pathCount1] = newY;

								pathCount1++;
								pathCount1 &= 0xff;
							}
						}
					}
				}
				else
				{
					oldPath = true;
				}
			}
			while (!oldPath && pathCount2 != pathCount1);

			this.Var_6590_DestinationX = -1;

			if (oldPath)
			{
				int local_6 = 0;
				int local_8 = 99;
				int newDirection = -1;
				int pathFlags;

				if (this.parent.GameData.Units[unit.TypeID].MovementType == UnitMovementTypeEnum.Water)
				{
					pathFlags = this.Arr_7f38_WaterPath[unitX, unitY];
				}
				else
				{
					pathFlags = this.Arr_db44_LandPath[unitX, unitY];
				}

				for (int i = 1; i < 9; i++)
				{
					if ((pathFlags & (0x1 << (i - 1))) != 0)
					{
						GPoint direction = this.parent.MoveDirections[i];
						int newX = unitX + direction.X;
						int newY = unitY + direction.Y;

						if (newX == 20)
						{
							newX = 0;
						}

						if (newX == -1)
						{
							newX = 19;
						}

						local_6 = this.Arr_d816[newX, newY];

						if (local_6 != 0)
						{
							if (local_6 < local_8)
							{
								local_8 = local_6;
								newDirection = i;

								// Instruction address 0x2e31:0x0976, size: 5
								local_a = this.parent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(unit.GoToDestination.X, unit.GoToDestination.Y,
									newX * 4 + 1, newY * 4 + 1);
							}
							else if (local_6 == local_8)
							{
								// Instruction address 0x2e31:0x08b0, size: 5
								int local_12 = this.parent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(unit.GoToDestination.X, unit.GoToDestination.Y,
									newX * 4 + 1, newY * 4 + 1);

								if (local_12 < local_a)
								{
									newDirection = i;
									local_a = local_12;
								}
							}
						}
					}
				}

				if (newDirection != -1)
				{
					GPoint direction = this.parent.MoveDirections[newDirection];

					// Instruction address 0x2e31:0x099d, size: 3
					this.Var_6590_DestinationX = this.parent.MapManagement.F0_2e31_119b_AdjustMapXPosition(((unitX + direction.X) * 4) + 1);
					this.Var_6592_DestinationY = ((unitY + direction.Y) * 4) + 1;

					if ((this.parent.MapManagement.F0_2aea_134a_GetTerrainType(this.Var_6590_DestinationX, this.Var_6592_DestinationY) == TerrainTypeEnum.Water) != waterUnit)
					{
						this.Var_6590_DestinationX++;

						if ((this.parent.MapManagement.F0_2aea_134a_GetTerrainType(this.Var_6590_DestinationX, this.Var_6592_DestinationY) == TerrainTypeEnum.Water) != waterUnit)
						{
							this.Var_6592_DestinationY++;
						}
					}
				}
			}

			if (this.Var_6590_DestinationX == -1)
			{
				this.Var_6590_DestinationX = unit.GoToDestination.X;
				this.Var_6592_DestinationY = unit.GoToDestination.Y;
			}

			return oldPath;
		}

		/// <summary>
		/// Tests if unit can move in any direction
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="waterUnit"></param>
		/// <returns>true if unit can move in any direction</returns>
		private bool F0_2e31_0a2c_CanUnitMove(int x, int y, bool waterUnit)
		{
			//this.oParent.GoToLog.EnterBlock($"F0_2e31_0a2c({x}, {y}, {waterFlag})");

			// function body
			int newMoveDirection = -1;
			int shortX = x / 4;
			int shortY = y / 4;

			if (waterUnit)
			{
				if (this.Arr_7f38_WaterPath[shortX, shortY] != 0)
				{
					newMoveDirection = 0;
				}
			}
			else if (this.Arr_db44_LandPath[shortX, shortY] != 0)
			{
				newMoveDirection = 0;
			}

			if (newMoveDirection == -1)
			{
				int minDistance = 99;

				for (int i = 1; i < 9; i++)
				{
					GPoint direction = this.parent.MoveDirections[i];

					int newShortX = shortX + direction.X;
					int newShortY = shortY + direction.Y;

					if ((waterUnit && this.Arr_7f38_WaterPath[newShortX, newShortY] != 0) ||
						(!waterUnit && this.Arr_db44_LandPath[newShortX, newShortY] != 0))
					{
						// Instruction address 0x2e31:0x0b43, size: 5
						int distance = this.parent.Segment_2dc4.F0_2dc4_0208_GetShortestDistance(x - (newShortX * 4) - 1, y - (newShortY * 4) - 1);

						if (distance < minDistance)
						{
							int testShortX = newShortX + 1;
							int testShortY = newShortY + 1;

							if ((this.parent.MapManagement.F0_2aea_134a_GetTerrainType(testShortX, testShortY) == TerrainTypeEnum.Water) == waterUnit)
							{
								if (F0_2e31_111c_CheckUnitPath(testShortX, testShortY, x, y, waterUnit, 18) != -1)
								{
									minDistance = distance;
									newMoveDirection = i;
								}
							}
							else
							{
								testShortX++;

								if ((this.parent.MapManagement.F0_2aea_134a_GetTerrainType(testShortX, testShortY) == TerrainTypeEnum.Water) == waterUnit)
								{
									if (F0_2e31_111c_CheckUnitPath(testShortX, testShortY, x, y, waterUnit, 18) != -1)
									{
										minDistance = distance;
										newMoveDirection = i;
									}
								}
								else
								{
									testShortY++;

									if ((this.parent.MapManagement.F0_2aea_134a_GetTerrainType(testShortX, testShortY) == TerrainTypeEnum.Water) == waterUnit)
									{
										if (F0_2e31_111c_CheckUnitPath(testShortX, testShortY, x, y, waterUnit, 18) != -1)
										{
											minDistance = distance;
											newMoveDirection = i;
										}
									}
									else
									{
										testShortX--;

										if ((this.parent.MapManagement.F0_2aea_134a_GetTerrainType(testShortX, testShortY) == TerrainTypeEnum.Water) == waterUnit)
										{
											if (F0_2e31_111c_CheckUnitPath(testShortX, testShortY, x, y, waterUnit, 18) != -1)
											{
												minDistance = distance;
												newMoveDirection = i;
											}
										}
									}
								}
							}
						}
					}
				}
			}

			if (newMoveDirection != -1)
			{
				GPoint direction = this.parent.MoveDirections[newMoveDirection];

				this.Var_6590_DestinationX = (shortX * 4) + direction.X;
				this.Var_6592_DestinationY = (shortY * 4) + direction.Y;

				return true;
			}

			return false;
		}

		/// <summary>
		/// Finds the shortest path from start to destination
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		private int F0_2e31_0c1d_FindShortestPath(Unit unit, short param3)
		{
			//this.oParent.GoToLog.EnterBlock($"F0_2e31_0c1d({playerID}, {unitID}, {param3})");
			//OpenCiv1Game.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oParent.GameData.HumanPlayerID);

			// function body
			bool waterUnit = this.parent.GameData.Units[unit.TypeID].MovementType == UnitMovementTypeEnum.Water;
			int local_20 = this.Var_6590_DestinationX - 8;
			int local_3a = this.Var_6592_DestinationY - 8;
			int unitX = unit.Position.X;
			int unitY = unit.Position.Y;
			GPoint direction;

			this.Var_6794 = 0;

			if (this.Var_6590_DestinationX != this.Var_6796_LastDestinationX || this.Var_6592_DestinationY != this.Var_6798_LastDestinationY ||
				this.Arr_b780[unitX - local_20, unitY - local_3a] == 0)
			{
				this.Var_6796_LastDestinationX = this.Var_6590_DestinationX;
				this.Var_6798_LastDestinationY = this.Var_6592_DestinationY;

				for (int i = 0; i < this.Arr_b780.GetLength(0); i++)
				{
					for (int j = 0; j < this.Arr_b780.GetLength(1); j++)
					{
						this.Arr_b780[i, j] = 0;
					}
				}

				int local_2 = 0;

				this.Arr_6594_PathX[local_2] = this.Var_6590_DestinationX;
				this.Arr_6694_PathY[local_2] = this.Var_6592_DestinationY;

				local_2++;

				this.Arr_b780[this.Var_6590_DestinationX - local_20, this.Var_6592_DestinationY - local_3a] = 1;
				this.Var_6794 = param3;
				int oneMove = (this.parent.GameData.Units[unit.TypeID].MoveCount == 1) ? 1 : 0;

				// local_2 will always be 1, so local_4 loop will also end at 1
				for (int local_4 = 0; local_4 != local_2 && local_4 < 225;)
				{
					int oldX = this.Arr_6594_PathX[local_4];
					int oldY = this.Arr_6694_PathY[local_4];

					local_4++;
					local_4 &= 0xff;

					int local_e = this.Arr_b780[oldX - local_20, oldY - local_3a];

					if (local_e <= this.Var_6794)
					{
						if (this.parent.MapManagement.F0_2e31_119b_AdjustMapXPosition(oldX) != unitX || oldY != unitY)
						{
							for (int i = 1; i < 9; i++)
							{
								direction = this.parent.MoveDirections[i];

								int newX = oldX + direction.X;

								if (Math.Abs(newX - this.Var_6590_DestinationX) < 8)
								{
									int newXAdjusted = this.parent.MapManagement.F0_2e31_119b_AdjustMapXPosition(newX);
									int newY = oldY + direction.Y;
									TerrainTypeEnum local_3e = this.parent.MapManagement.F0_2aea_134a_GetTerrainType(newXAdjusted, newY);

									if (Math.Abs(newY - this.Var_6592_DestinationY) < 8 &&
										this.parent.MapManagement.F0_2aea_1326_ValidateMapCoordinates(newXAdjusted, newY) &&
										((local_3e == TerrainTypeEnum.Water) == waterUnit ||
										this.parent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newXAdjusted, newY).HasFlag(TerrainImprovementFlagsEnum.City)))
									{
										int local_1a;

										if (this.parent.MapManagement.F0_2aea_1570_CheckIfCellHasRoad(this.parent.MapManagement.F0_2e31_119b_AdjustMapXPosition(oldX), oldY) &&
											this.parent.MapManagement.F0_2aea_1570_CheckIfCellHasRoad(newXAdjusted, newY))
										{
											local_1a = local_e + 1;
										}
										else if (oneMove != 0)
										{
											local_1a = local_e + 3;
										}
										else
										{
											local_1a = (3 * this.parent.GameData.Terrains[(int)local_3e].MovementCost) + local_e;
										}

										int local_38 = this.Arr_b780[newX - local_20, newY - local_3a];

										if (local_38 == 0 || local_38 > local_1a)
										{
											this.Arr_b780[newX - local_20, newY - local_3a] = local_1a;

											this.Arr_6594_PathX[local_2] = newX;
											this.Arr_6694_PathY[local_2] = newY;

											local_2++;
											local_2 &= 0xff;
										}
									}
								}
							}
						}
						else
						{
							this.Var_6794 = local_e;
						}
					}
				}
			}

			int nextMoveDirection = -1;

			if (param3 > this.Var_6794)
			{
				int local_a = 99;

				for (int i = 1; i < 9; i++)
				{
					direction = this.parent.MoveDirections[i];

					int newX = unitX + direction.X;

					if (Math.Abs(newX - this.Var_6590_DestinationX) >= 72)
					{
						if (newX <= this.Var_6590_DestinationX)
						{
							newX += 80;
						}
						else
						{
							newX -= 80;
						}
					}

					if (Math.Abs(newX - this.Var_6590_DestinationX) < 8)
					{
						int newXAdjusted = this.parent.MapManagement.F0_2e31_119b_AdjustMapXPosition(newX);
						int newY = unitY + direction.Y;

						if (Math.Abs(newY - this.Var_6592_DestinationY) < 8)
						{
							if ((this.parent.MapManagement.F0_2aea_134a_GetTerrainType(newXAdjusted, newY) == TerrainTypeEnum.Water) == waterUnit ||
								this.parent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(newXAdjusted, newY).HasFlag(TerrainImprovementFlagsEnum.City))
							{
								int local_6 = this.Arr_b780[newX - local_20, newY - local_3a];

								if (local_6 != 0)
								{
									int local_e = 0;

									if (local_6 < local_a)
									{
										local_a = local_6;
										nextMoveDirection = i;

										// Instruction address 0x2e31:0x1025, size: 5
										int activeUnitID = this.parent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(newXAdjusted, newY);

										if (activeUnitID != -1)
										{
											// Instruction address 0x2e31:0x103f, size: 5
											local_e = (short)this.parent.UnitManagement.F0_1866_1251(unit.PlayerID, activeUnitID, 2) * 4;
										}
										else
										{
											local_e = 0;
										}

										// Instruction address 0x2e31:0x1063, size: 5
										local_e += this.parent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(this.Var_6590_DestinationX, this.Var_6592_DestinationY, newXAdjusted, newY);
									}

									if (local_6 == local_a)
									{
										int local_1a;

										// Instruction address 0x2e31:0x107f, size: 5
										int activeUnitID = this.parent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(newXAdjusted, newY);

										if (activeUnitID != -1)
										{
											// Instruction address 0x2e31:0x1099, size: 5
											local_1a = (short)this.parent.UnitManagement.F0_1866_1251(unit.PlayerID, activeUnitID, 2) * 4;
										}
										else
										{
											local_1a = 0;
										}

										// Instruction address 0x2e31:0x10bd, size: 5
										local_1a += this.parent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(this.Var_6590_DestinationX, this.Var_6592_DestinationY, newXAdjusted, newY);

										if (local_1a < local_e)
										{
											nextMoveDirection = i;
											local_e = local_1a;
										}
									}
								}
							}
						}
					}
				}

				if (nextMoveDirection != -1)
				{
					return nextMoveDirection;
				}
			}

			if (nextMoveDirection == -1)
			{
				this.Var_6590_DestinationX = unit.GoToDestination.X;
				this.Var_6592_DestinationY = unit.GoToDestination.Y;
			}

			return -1;
		}
		#endregion
	}
}
