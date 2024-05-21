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
		public short Mood;
		public short Policy;
		public short Ideology;
		public short ShortTune;
		public short LongTune;

		public NationDefinition(string leader, string nation, string nationality, short mood, short policy, short ideology, short shortTune, short longTune)
		{
			this.Leader = leader;
			this.Nation = nation;
			this.Nationality = nationality;
			this.Mood = mood; // -1 = Friendly, 0 = Neutral, 1 = Aggressive
			this.Policy = policy; // -1 = Perfectionist, 0 = Neutral, 1 = Expansionistic
			this.Ideology = ideology; // -1 = Militaristic, 0 = Neutral, 1 = Civilized
			this.ShortTune = shortTune;
			this.LongTune = longTune;
		}
	}
}
