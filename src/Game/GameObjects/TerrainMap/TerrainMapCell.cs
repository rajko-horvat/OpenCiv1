using IRB.Collections.Generic;
using OpenCiv1.Graphics;
using System.Text;
using System.Xml.Serialization;

namespace OpenCiv1
{
	[Serializable]
	public class TerrainMapCell : IEquatable<TerrainMapCell>
	{
		public static readonly TerrainMapCell Empty = new TerrainMapCell(-1, -1);

		private TerrainMap? oParent = null;

		private GPoint oPosition = new GPoint(-1);

		private TerrainTypeEnum eTerrainType = TerrainTypeEnum.Water;
		private TerrainDefinition? oTerrainDefinition = null;
		private int iTotalCellWorth = 0;

		public bool HasSpecialResources = false;
		public int Layer2_PlayerOwnership = 0;
		public int Layer3_GroupID = -1; // GroupID
		public int Layer4_BuildSites = 0;
		public int Layer5_TerrainImprovements1 = 0;
		public int Layer6_VisibleTerrainImprovements1 = 0; // 1 - City?, 2 - Irrigation, 4 - Mine, 8 - Roads
		public int Layer7_TerrainImprovements2 = 0;
		public int Layer8_VisibleTerrainImprovements2 = 0; // 1 - Railroads, 2 - City Walls, 4 - Pollution, 8 - ?
		public int Layer9_ActiveUnits = 0;
		public int Layer10_MiniMap = 0;

		public int Visibility = 0;
		public BHashSet<int> VisibilityList = new BHashSet<int>(); // List of the Player IDs that this cell is visible to

		#region AStar (A*) Algorithm data
		internal GPoint ParentPos = new GPoint(-1); // Position of our parent cell
		internal double GCost = double.MaxValue;
		internal double HCost = double.MaxValue;
		internal double FCost = double.MaxValue; // FCost = GCost + HCost
		internal bool IsCellClosed = false;
		#endregion

		public TerrainMapCell()
		{ }

		public TerrainMapCell(int x, int y) : this(new GPoint(x, y))
		{ }

		public TerrainMapCell(GPoint position)
		{
			this.oPosition = position;
		}

		[XmlIgnore]
		public TerrainMap? Parent
		{
			get => this.oParent;
		}

		[XmlIgnore]
		internal TerrainMap? ParentInternal
		{
			get => this.oParent;
			set
			{
				this.oParent = value;

			}
		}

		public GPoint Position
		{
			get => this.oPosition;
			set
			{
				if (this.oParent != null)
				{
					throw new InvalidOperationException("Cell position can't be changed once it's a part of the Map");
				}

				this.oPosition = value;
			}
		}

		[XmlIgnore]
		public int X
		{
			get => this.oPosition.X;
			set
			{
				if (this.oParent != null)
				{
					throw new InvalidOperationException("Cell position can't be changed once it's a part of the Map");
				}

				this.oPosition.X = value;
			}
		}

		[XmlIgnore]
		public int Y
		{
			get => this.oPosition.Y;
			set
			{
				if (this.oParent != null)
				{
					throw new InvalidOperationException("Cell position can't be changed once it's a part of the Map");
				}

				this.oPosition.Y = value;
			}
		}

		public TerrainTypeEnum TerrainType
		{
			get => this.eTerrainType;
			set
			{
				this.eTerrainType = value;
				this.oTerrainDefinition = null;
				this.iTotalCellWorth = 0;
			}
			/*{
				switch (this.Layer1_Terrain)
				{
					case 0:
					case 4:
					case 5:
					case 8:
						throw new Exception($"Undefined terrain type {this.Layer1_Terrain}");

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

					default:
						throw new Exception("Illegal Layer1 value");
				}
			}*/
		}

		[XmlIgnore]
		public TerrainMapGroupTypeEnum GroupType
		{
			get
			{
				switch (this.eTerrainType)
				{
					case TerrainTypeEnum.Water:
						return TerrainMapGroupTypeEnum.Water;

					default:
						return TerrainMapGroupTypeEnum.Land;
				}
			}
		}

		/// <summary>
		/// Makes this cell invisible to everyone
		/// </summary>
		public void ClearVisibility()
		{
			this.VisibilityList.Clear();
		}

		/// <summary>
		/// Tests if this cell is visible
		/// </summary>
		/// <param name="playerID">The Player ID to test visibility for</param>
		/// <returns></returns>
		public bool IsVisibleTo(int playerID)
		{
			return this.VisibilityList.Contains(playerID);
		}

		/// <summary>
		/// Sets visibility of this cell
		/// </summary>
		/// <param name="playerID">Player ID to set visibility for</param>
		/// <param name="visible">If the cell is visible to the provided Player</param>
		public void SetVisiblity(int playerID, bool visible)
		{
			if (visible)
			{
				if (!this.VisibilityList.Contains(playerID))
				{
					this.VisibilityList.Add(playerID);
				}
			}
			else
			{
				if (this.VisibilityList.Contains(playerID))
				{
					this.VisibilityList.Remove(playerID);
				}
			}
		}

		/// <summary>
		/// Appends another Visibility list to this cell
		/// </summary>
		/// <param name="visibilityList"></param>
		public void AppendVisibility(BHashSet<int> visibilityList)
		{
			for (int i = 0; i < visibilityList.Count; i++)
			{
				if (!this.VisibilityList.Contains(visibilityList[i]))
				{
					this.VisibilityList.Add(visibilityList[i]);
				}
			}
		}

		#region Map Cell Terrain type properties
		public string TerrainName
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return "";
					}
				}

				StringBuilder sName = new StringBuilder(this.oTerrainDefinition.Name);

				if (this.HasSpecialResources)
				{
					sName.Append("(");

					for (int i = 0; i < this.oTerrainDefinition.Resources.Length; i++)
					{
						if (i > 0)
							sName.Append(", ");

						sName.Append(this.oTerrainDefinition.Resources[i].Name);
					}

					sName.Append(")");
				}

				return sName.ToString();
			}
		}

		public double MovementCost
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 1.0;
					}
				}

				double dValue = this.oTerrainDefinition.MovementCost;

				if ((this.Layer5_TerrainImprovements1 & 0x8) != 0) // roads
				{
					dValue /= 3.0;
				}
				if ((this.Layer7_TerrainImprovements2 & 0x1) != 0) // railroads
				{
					dValue = 0.0;
				}

				return dValue;
			}
		}

		/// <summary>
		/// Movement cost based on currently visible improvements
		/// </summary>
		public double VisibleMovementCost
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 1;
					}
				}

				double dValue = this.oTerrainDefinition.MovementCost;

				if ((this.Layer6_VisibleTerrainImprovements1 & 0x8) != 0) // roads
				{
					dValue = 1.0 / 3.0;
				}
				if ((this.Layer8_VisibleTerrainImprovements2 & 0x1) != 0) // railroads
				{
					dValue = 0.0;
				}

				return dValue;
			}
		}

		public int DefenseBonus
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 1;
					}
				}

				return this.oTerrainDefinition.DefenseBonus;
			}
		}

		public int Food
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				int iValue = this.oTerrainDefinition.Food;

				if (this.HasSpecialResources)
				{
					foreach (TerrainResource resource in this.oTerrainDefinition.Resources)
					{
						iValue += resource.Food;
					}
				}

				return iValue;
			}
		}

		public int Production
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				int iValue = this.oTerrainDefinition.Production;

				if (this.HasSpecialResources)
				{
					foreach (TerrainResource resource in this.oTerrainDefinition.Resources)
					{
						iValue += resource.Production;
					}
				}

				return iValue;
			}
		}

		public int Trade
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				int iValue = this.oTerrainDefinition.Trade;

				if (this.HasSpecialResources)
				{
					foreach (TerrainResource resource in this.oTerrainDefinition.Resources)
					{
						iValue += resource.Trade;
					}
				}

				return iValue;
			}
		}

		public int Multi1
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				return this.oTerrainDefinition.Multi1;
			}
		}

		public int Multi2
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				return this.oTerrainDefinition.Multi2;
			}
		}

		public int Multi3
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				return this.oTerrainDefinition.Multi3;
			}
		}

		public int Multi4
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				return this.oTerrainDefinition.Multi4;
			}
		}

		public int Multi5
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				return this.oTerrainDefinition.Multi5;
			}
		}

		public int Multi6
		{
			get
			{
				if (this.oTerrainDefinition == null)
				{
					if (this.oParent != null && this.oParent.Parent != null)
					{
						this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
					}
					else
					{
						return 0;
					}
				}

				return this.oTerrainDefinition.Multi6;
			}
		}

		public int TotalCellWorth
		{
			get
			{
				if (this.oParent != null && this.oParent.Parent != null && this.eTerrainType != TerrainTypeEnum.Water && this.iTotalCellWorth <= 0)
				{
					if (this.oTerrainDefinition == null)
					{
						if (this.oParent != null && this.oParent.Parent != null)
						{
							this.oTerrainDefinition = this.oParent.Parent.GameData.Static.Terrains.GetValueByKey(this.eTerrainType);
						}
						else
						{
							return 0;
						}
					}

					this.iTotalCellWorth = 0;

					for (int k = 0; k < 21; k++)
					{
						int cellWorth = 0;
						GPoint newPos = this.oPosition.Offset(this.oParent.Parent.GameData.Static.CityOffsets[k]);

						if ((this.eTerrainType == TerrainTypeEnum.Grassland || this.eTerrainType == TerrainTypeEnum.River) && (((newPos.X * 7) + (newPos.Y * 11)) & 0x2) == 0)
						{
							cellWorth += 2;
						}

						int coefficient = (3 * this.Food) + this.Trade;

						if (this.eTerrainType != TerrainTypeEnum.Grassland && this.eTerrainType != TerrainTypeEnum.River)
						{
							coefficient += this.Production * 2;
						}

						if (this.oTerrainDefinition.Multi3 < 0)
						{
							coefficient += -1 - this.oTerrainDefinition.Multi3;
						}
						else
						{
							if (this.oTerrainDefinition.Multi1 < 0)
							{
								coefficient += (-1 - this.oTerrainDefinition.Multi1) * 2;
							}
						}

						cellWorth += coefficient;

						if (k < 9)
						{
							cellWorth += cellWorth;
						}

						if (k == 0)
						{
							cellWorth += cellWorth;
						}

						this.iTotalCellWorth += cellWorth;
					}

					if (this.eTerrainType != TerrainTypeEnum.Plains && (((this.oPosition.X * 7) + (this.oPosition.Y * 11)) & 0x2) != 0)
					{
						this.iTotalCellWorth -= 16;
					}

					this.iTotalCellWorth = (Math.Min(Math.Max((this.iTotalCellWorth - 120) / 8, 1), 15) / 2) + 8; // result is between [8 - 15]
				}

				return this.iTotalCellWorth;
			}
		}
		#endregion

		/*[XmlIgnore]
		public bool HasSpecialResources
		{
			get
			{
				GPoint pos = this.oPosition;

				if (this.oParent == null || pos.Y < 2 || pos.Y > this.oParent.Size.Height - 3 ||
					(((pos.X & 3) * 4) + (pos.Y & 3)) != ((((pos.X / 4) * 13) + ((pos.Y / 4) * 11) + this.oParent.Seed) & 0xf))
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}*/

		public bool Equals(TerrainMapCell? other)
		{
			if (other != null)
			{
				if (this.oParent == other.Parent && this.Position.Equals(other.Position) &&
					this.TerrainType.Equals(other.TerrainType) && this.Layer2_PlayerOwnership.Equals(other.Layer2_PlayerOwnership) &&
					this.Layer3_GroupID.Equals(other.Layer3_GroupID) && this.Layer4_BuildSites.Equals(other.Layer4_BuildSites) &&
					this.Layer5_TerrainImprovements1.Equals(other.Layer5_TerrainImprovements1) && this.Layer6_VisibleTerrainImprovements1.Equals(other.Layer6_VisibleTerrainImprovements1) &&
					this.Layer7_TerrainImprovements2.Equals(other.Layer7_TerrainImprovements2) && this.Layer8_VisibleTerrainImprovements2.Equals(other.Layer8_VisibleTerrainImprovements2) &&
					this.Layer9_ActiveUnits.Equals(other.Layer9_ActiveUnits) && this.Layer10_MiniMap.Equals(other.Layer10_MiniMap) &&
					this.Visibility.Equals(other.Visibility))
				{
					return true;
				}
			}

			return false;
		}
	}
}
