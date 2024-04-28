using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class BuildingDefinition
	{
		public int ID = -1;
		// Total size: 30 bytes
		public string Name = ""; // (24 bytes)
		public int Price = 0;
		public int Maintenance = 0;
		public TechnologyEnum RequiredTechnology = 0;

		public BuildingDefinition()
		{ }

		public BuildingDefinition(int id, string name, int price, int maintenance, TechnologyEnum requiredTechnology)
		{
			this.ID = id;

			this.Name = name;
			this.Price = price;
			this.Maintenance = maintenance;
			this.RequiredTechnology = requiredTechnology;
		}
	}
}
