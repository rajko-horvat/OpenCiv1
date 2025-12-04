namespace OpenCiv1
{
	public class TerrainResource
	{
		public string Name;

		// Resources
		public int Food;
		public int Production;
		public int Trade;

		public TerrainResource(string name, int food, int production, int trade)
		{
			this.Name = name;
			this.Food = food;
			this.Production = production;
			this.Trade = trade;
		}
	}
}
