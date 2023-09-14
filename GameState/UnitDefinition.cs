using System;
using System.Collections.Generic;
using System.Text;

namespace OpenCiv1
{
	public class UnitDefinition
	{
		// Total size: 34 bytes
		public string Name; // (12 bytes)
		public short CancelTechnology;
		public short TerrainCategory;
		public short MoveCount;
		public short TurnsOutside;
		public short AttackStrength;
		public short DefenceStrength;
		public short Cost;
		public short SightRange;
		public short TransportCapacity;
		public short UnitCategory;
		public short TechnologyRequired;

		public UnitDefinition(string name, short cancelTechnology, short terrainCategory,
			short moveCount, short turnsOutside, short attackStrength, short defenceStrength,
			short cost, short sightRange, short transportCapacity, short unitCategory,
			short technologyRequired)
		{
			this.Name = name;
			this.CancelTechnology = cancelTechnology;
			this.TerrainCategory = terrainCategory;
			this.MoveCount = moveCount;
			this.TurnsOutside = turnsOutside;
			this.AttackStrength = attackStrength;
			this.DefenceStrength = defenceStrength;
			this.Cost = cost;
			this.SightRange = sightRange;
			this.TransportCapacity = transportCapacity;
			this.UnitCategory = unitCategory;
			this.TechnologyRequired = technologyRequired;
		}
	}
}
