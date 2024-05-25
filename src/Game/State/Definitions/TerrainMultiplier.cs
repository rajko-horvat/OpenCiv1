using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class TerrainMultiplier
	{
		int ID;

		// Total size: 12 bytes
		public short Multi1;
		public short Multi2;
		public short Multi3;
		public short Multi4;
		public short Multi5;
		public short Multi6;

		public TerrainMultiplier(int id, short multi1, short multi2, short multi3, short multi4, short multi5, short multi6)
		{
			this.ID = id;
			this.Multi1 = multi1;
			this.Multi2 = multi2;
			this.Multi3 = multi3;
			this.Multi4 = multi4;
			this.Multi5 = multi5;
			this.Multi6 = multi6;
		}
	}
}
