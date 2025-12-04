using OpenCiv1.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class AStar1
	{
		// A structure to hold the necessary parameters
		public class ACell
		{
			public GPoint Position;

			// Position of this cell parent cell
			public GPoint ParentPos = new GPoint(-1);

			// fCost = gCost + hCost
			public double fCost = double.MaxValue;
			public double gCost = double.MaxValue;
			public double hCost = double.MaxValue;

			public bool IsClosed = false;

			public ACell(GPoint position)
			{
				this.Position = position;
			}
		}

		// A Function to find the shortest path between
		// a given source to a destination cell according
		// to A* Search Algorithm
		public static void FindPath(int[,] map, GPoint src, GPoint dest)
		{
			GSize mapSize = new GSize(map.GetLength(1), map.GetLength(0));

			// If the source or destination is out of range
			if (!IsValidPos(src, mapSize) || !IsValidPos(dest, mapSize))
			{
				Debug.WriteLine("Source or destination is invalid");
				return;
			}

			// Either the source or the destination is blocked
			if (!IsUnBlocked(map, src) || !IsUnBlocked(map, dest))
			{
				Debug.WriteLine("Source or the destination is blocked");
				return;
			}

			// If the destination cell is the same as the source cell
			if (src == dest)
			{
				Debug.WriteLine("We are already at the destination");
				return;
			}

			// Declare a 2D cell array to hold the details
			ACell[,] cells = new ACell[mapSize.Height, mapSize.Width];

			for (int i = 0; i < mapSize.Height; i++)
			{
				for (int j = 0; j < mapSize.Width; j++)
				{
					cells[i, j] = new ACell(new GPoint(j, i));
				}
			}

			// Create a sorted open list in descending order (sorted from higher to lower value)
			// We compare this list by cell's f value
			List<ACell> openCells = new List<ACell>();

			// Initialize start cell
			ACell cell = cells[src.Y, src.X];
			cell.gCost = 0.0;
			cell.hCost = 0.0;
			cell.fCost = 0.0;
			cell.ParentPos = cell.Position;

			// Put the starting cell on the open list
			openCells.Add(cell);

			// We set this boolean value to false as, initially, 
			// the destination is not reached.
			bool foundDest = false;
			int iMaxDepth = 1;

			while (openCells.Count > 0)
			{
				// Our most favorable current cell is the cell with lowest fCost value
				cell = openCells[openCells.Count - 1];
				GPoint pos = cell.Position;

				openCells.RemoveAt(openCells.Count - 1);

				// Mark this cell as closed
				cell.IsClosed = true;

				// Generate all 8 successors of this cell
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if (i == 0 && j == 0)
							continue;

						GPoint newPos = pos.Offset(j, i);

						// If new cell successor position is a valid position
						if (IsValidPos(newPos, mapSize))
						{
							ACell newCell = cells[newPos.Y, newPos.X];

							// If the destination cell is the same as the current successor cell
							// we have reached our destination
							if (newPos == dest)
							{
								newCell.gCost = cell.gCost + MovementCost(map, newPos);
								newCell.hCost = 0.0;
								newCell.fCost = newCell.gCost + newCell.hCost;
								newCell.ParentPos = pos;

								Debug.WriteLine($"The maximum open list depth is {iMaxDepth}");
								Debug.WriteLine("The destination cell is found");
								TracePath(cells, dest);

								foundDest = true;
								return;
							}

							// Ignore the successor cell if it is closed or blocked
							if (!newCell.IsClosed && IsUnBlocked(map, newPos))
							{
								double newGCost = cell.gCost + MovementCost(map, newPos);
								double newHCost = CalculateHValue(newPos, dest);
								double newFCost = newGCost + newHCost;

								// Make current cell the parent of the new successor cell
								if (newCell.fCost == double.MaxValue)
								{
									// We have found a new path
									// Update the details of the new successor cell and add it to the open cell list in descending order
									newCell.gCost = newGCost;
									newCell.hCost = newHCost;
									newCell.fCost = newFCost;
									newCell.ParentPos = pos;

									bool bAdded = false;

									for (int k = 0; k < openCells.Count; k++)
									{
										if (openCells[k].fCost.CompareTo(newCell.fCost) <= 0)
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

									if (openCells.Count > iMaxDepth)
									{
										iMaxDepth = openCells.Count;
									}
								}
								else if (newCell.fCost > newFCost)
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
									newCell.gCost = newGCost;
									newCell.hCost = newHCost;
									newCell.fCost = newFCost;
									newCell.ParentPos = pos;

									bool bAdded = false;

									for (int k = 0; k < openCells.Count; k++)
									{
										if (openCells[k].fCost.CompareTo(newCell.fCost) <= 0)
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

									if (openCells.Count > iMaxDepth)
									{
										iMaxDepth = openCells.Count;
									}
								}
							}
						}
					}
				}
			}

			// For debugging purposes
			for (int i = 0; i < mapSize.Height; i++)
			{
				for (int j = 0; j < mapSize.Width; j++)
				{
					if (j > 0)
					{
						Debug.Write(", ");
					}

					Debug.Write($"[{cells[i, j].ParentPos.X}, {cells[i, j].ParentPos.Y}]");
				}

				Debug.WriteLine("");
			}

			// When the destination cell is not found and the open
			// list is empty, then we conclude that we failed to
			// reach the destination cell. This may happen when 
			// there is no way to destination cell (due to blockages)
			if (!foundDest)
				Debug.WriteLine("Failed to find the Destination Cell");
		}

		// A Utility Function to check whether given position is valid
		public static bool IsValidPos(GPoint pt, GSize sz)
		{
			// Returns true if pt is a valid position
			return (pt.X >= 0) && (pt.X < sz.Width) && (pt.Y >= 0) && (pt.Y < sz.Height);
		}

		// A Utility Function to check whether the given cell is blocked or not
		public static bool IsUnBlocked(int[,] map, GPoint pt)
		{
			// Returns true if the cell is not blocked else false
			return map[pt.Y, pt.X] != 0;
		}

		// A Utility Function to calculate the movement cost
		public static double MovementCost(int[,] map, GPoint pt)
		{
			switch (map[pt.Y, pt.X])
			{
				case 1:
					return 1.0;

				case 2:
					return 0.5;

				default:
					return 1.0;
			}
		}

		// A Utility Function to calculate the 'h' heuristics.
		public static double CalculateHValue(GPoint pt, GPoint dest)
		{
			// Return using the distance formula
			//return Math.Sqrt(Math.Pow(y - dest.Y, 2) + Math.Pow(x - dest.X, 2));

			// Chebyshev distance
			return Math.Max(Math.Abs(pt.X - dest.X), Math.Abs(pt.Y - dest.Y));
		}

		// A Utility Function to trace the path from the source to destination cell
		public static void TracePath(ACell[,] cells, GPoint dest)
		{
			Debug.WriteLine("");
			Debug.Write("The Path is ");

			GPoint pos = dest;
			Stack<GPoint> Path = new Stack<GPoint>();
			ACell cell;

			while ((cell = cells[pos.Y, pos.X]).ParentPos != pos)
			{
				Path.Push(pos);
				pos = cell.ParentPos;
			}

			Path.Push(pos);

			while (Path.Count > 0)
			{
				GPoint p = Path.Pop();
				Debug.Write($" -> ({p.X}, {p.Y}) ");
			}
		}

		public static void AMain()
		{
			/* Description of the Grid (Size: 9x8):
				1 - The cell is not blocked
				0 - The cell is blocked */
			int[,] grid = {
				{1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
				{1, 1, 1, 0, 2, 2, 2, 0, 1, 1},
				{1, 1, 1, 0, 1, 1, 0, 1, 0, 1},
				{0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
				{1, 1, 1, 0, 1, 1, 1, 0, 1, 0},
				{1, 0, 1, 1, 1, 1, 0, 1, 0, 0},
				{1, 0, 0, 0, 0, 1, 0, 0, 0, 1},
				{1, 0, 1, 1, 1, 1, 0, 1, 1, 1},
				{1, 1, 1, 0, 0, 0, 1, 0, 0, 1} };

			// Source is the right-most bottom-most corner
			GPoint src = new GPoint(9, 0);

			// Destination is the left-most top-most corner
			GPoint dest = new GPoint(0, 0);

			FindPath(grid, src, dest);
		}
	}
}
