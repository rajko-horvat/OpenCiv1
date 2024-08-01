using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class MapCell
	{
		private Map? oParent = null;

		private GPoint oPosition = new GPoint(-1);

		public int Visibility = 0;

		public int Layer1 = 0;
		public int Layer2 = 0;
		public int Layer3 = 0;
		public int Layer4 = 0;
		public int Layer5 = 0;
		public int Layer6 = 0;
		public int Layer7 = 0;
		public int Layer8 = 0;
		public int Layer9 = 0;
		public int Layer10 = 0;

		public MapCell()
		{ }

		public MapCell(int x, int y) : this(new GPoint(x, y))
		{ }

		public MapCell(GPoint position)
		{
			this.oPosition = position;
		}

		public Map? Parent
		{
			get => this.oParent;
		}

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

		public TerrainTypeEnum TerrainType
		{
			get
			{
				switch (this.Layer1)
				{
					case 0:
					case 4:
					case 5:
					case 8:
						return TerrainTypeEnum.Undefined;

					case 1:
						return TerrainTypeEnum.Ocean;

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

		public MapCell Clone()
		{
			MapCell cell = new MapCell();

			cell.oPosition = this.oPosition;
			cell.Visibility = this.Visibility;
			cell.Layer1 = this.Layer1;
			cell.Layer2 = this.Layer2;
			cell.Layer3 = this.Layer3;
			cell.Layer4 = this.Layer4;
			cell.Layer5 = this.Layer5;
			cell.Layer6 = this.Layer6;
			cell.Layer7 = this.Layer7;
			cell.Layer8 = this.Layer8;
			cell.Layer9 = this.Layer9;
			cell.Layer10 = this.Layer10;

			return cell;
		}
	}
}
