using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class ImprovementDefinition
	{
		public int ID = -1;

		// Total size: 30 bytes
		public string Name = ""; // (24 bytes)
		public int Price = 0;
		public int MaintenanceCost = 0;
		public TechnologyEnum RequiresTechnology = TechnologyEnum.None;
		public TechnologyEnum ObsoletesAfterTechnology = TechnologyEnum.None;

		public ImprovementDefinition()
		{ }

		public ImprovementDefinition(int id, string name, int price, int maintenanceCost, TechnologyEnum requiresTechnology, TechnologyEnum obsoletesAfterTechnology)
		{
			this.ID = id;
			this.Name = name;
			this.Price = price;
			this.MaintenanceCost = maintenanceCost;
			this.RequiresTechnology = requiresTechnology;
			this.ObsoletesAfterTechnology = obsoletesAfterTechnology;
		}
	}
}
