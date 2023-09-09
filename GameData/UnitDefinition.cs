using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenCiv1.GameData
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
	}
}
