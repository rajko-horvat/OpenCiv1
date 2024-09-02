using OpenCiv1.Graphics;
using System.Xml.Serialization;

namespace OpenCiv1
{
	[Serializable]
	public class MapCell : IEquatable<MapCell>
	{
		public static readonly MapCell Empty = new MapCell(-1, -1);

		private Map? oParent = null;

		private GPoint oPosition = new GPoint(-1);

		public int Layer1_Terrain = 1; // TerrainType
		public bool HasSpecialResource = false;
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

		public MapCell()
		{ }

		public MapCell(int x, int y) : this(new GPoint(x, y))
		{ }

		public MapCell(GPoint position)
		{
			this.oPosition = position;
		}

		[XmlIgnore]
		public Map? Parent
		{
			get => this.oParent;
		}

		[XmlIgnore]
		internal Map? ParentInternal
		{
			get => this.oParent;
			set => this.oParent = value;
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

		[XmlIgnore]
		public TerrainTypeEnum TerrainType
		{
			get
			{
				switch (this.Layer1_Terrain)
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

					default:
						throw new Exception("Illegal Layer1 value");
				}
			}
		}

		[XmlIgnore]
		public MapGroupTypeEnum GroupType
		{
			get
			{
				switch (this.Layer1_Terrain)
				{
					case 1:
						return MapGroupTypeEnum.Water;

					default:
						return MapGroupTypeEnum.Land;
				}
			}
		}

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

		public bool Equals(MapCell? other)
		{
			if (other != null)
			{
				if (this.oParent == other.Parent && this.Position.Equals(other.Position) &&
					this.Layer1_Terrain.Equals(other.Layer1_Terrain) && this.Layer2_PlayerOwnership.Equals(other.Layer2_PlayerOwnership) &&
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
