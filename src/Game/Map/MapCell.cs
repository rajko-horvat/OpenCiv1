using OpenCiv1.GPU;

namespace OpenCiv1.GameMap
{
	public class MapCell
	{
		private Map? oParent = null;

		private GPoint oPosition = new GPoint(-1);
		private TerrainTypeEnum eTerrainType = TerrainTypeEnum.Water;

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
			get => this.eTerrainType;
			set => this.eTerrainType = value;
		}

		public MapCell Clone()
		{
			MapCell cell = new MapCell();

			cell.oPosition = this.oPosition;
			cell.eTerrainType = this.eTerrainType;

			return cell;
		}
	}
}
