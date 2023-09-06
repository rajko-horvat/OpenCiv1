using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.Data
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
