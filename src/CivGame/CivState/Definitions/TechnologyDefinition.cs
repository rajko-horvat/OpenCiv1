using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class TechnologyDefinition
	{
		public TechnologyEnum ID;
		public string Name;
		public TechnologyEnum RequiresTechnology1;
		public TechnologyEnum RequiresTechnology2;

		public TechnologyDefinition(TechnologyEnum id, string name, TechnologyEnum requiresTechnology1, TechnologyEnum requiresTechnology2)
		{
			this.ID = id;
			this.Name = name;
			this.RequiresTechnology1 = requiresTechnology1;
			this.RequiresTechnology2 = requiresTechnology2;
		}
	}
}
