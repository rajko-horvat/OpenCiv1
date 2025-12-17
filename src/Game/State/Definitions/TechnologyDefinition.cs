using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class TechnologyDefinition
	{
		public TechnologyEnum Value;
		public string Name;
		public TechnologyEnum RequiresTechnology1;
		public TechnologyEnum RequiresTechnology2;

		public TechnologyDefinition(TechnologyEnum value, string name, TechnologyEnum requiresTechnology1, TechnologyEnum requiresTechnology2)
		{
			this.Value = value;
			this.Name = name;
			this.RequiresTechnology1 = requiresTechnology1;
			this.RequiresTechnology2 = requiresTechnology2;
		}
	}
}
