using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class NationDefinition
	{
		public string Leader;
		public string Nation;
		public string Nationality;
		public short Behavior1;
		public short Behavior2;
		public short Behavior3;
		public short ShortTune;
		public short LongTune;

		public NationDefinition(string leader, string nation, string nationality, short behavior1, short behavior2, short behavior3, short shortTune, short longTune)
		{
			this.Leader = leader;
			this.Nation = nation;
			this.Nationality = nationality;
			this.Behavior1 = behavior1;
			this.Behavior2 = behavior2;
			this.Behavior3 = behavior3;
			this.ShortTune = shortTune;
			this.LongTune = longTune;
		}
	}
}
