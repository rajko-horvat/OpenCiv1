using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class ResourceMissingException : Exception
	{
		public ResourceMissingException() : base() { }

		public ResourceMissingException(string message) : base(message) { }

		public ResourceMissingException(string message, Exception innerException) : base(message, innerException) { }
	}
}
