using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class TerrainDefinition
	{
		// General
		public string Name;
		public double MovementCost;
		public int DefenseBonus;

		// Resources
		public int Food;
		public int Production;
		public int Trade;

		// Multipliers
		// !!! ToDo: find out what are these exactly used for
		public int Multi1;
		public int Multi2;
		public int Multi3;
		public int Multi4;
		public int Multi5;
		public int Multi6;

		// Additional resources that can be available at this Terrain Type
		public TerrainResource[] Resources;

		// Not used at all?
		public int Unknown1;
		public int Unknown2;

		public TerrainDefinition(string name,
			double movementCost, int defenseBonus,
			int food, int production, int trade,
			int m1, int m2, int m3, int m4, int m5, int m6,
			TerrainResource[] resources, 
			int unknown1, int unknown2)
		{
			this.Name = name;

			this.MovementCost = movementCost;
			this.DefenseBonus = defenseBonus;

			this.Food = food;
			this.Production = production;
			this.Trade = trade;

			this.Multi1 = m1;
			this.Multi2 = m2;
			this.Multi3 = m3;
			this.Multi4 = m4;
			this.Multi5 = m5;
			this.Multi6 = m6;

			this.Resources = resources;

			this.Unknown1 = unknown1;
			this.Unknown2 = unknown2;
		}
	}
}
