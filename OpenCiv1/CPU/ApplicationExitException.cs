using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class ApplicationExitException : Exception
	{
		public ApplicationExitException() : base() { }

		public ApplicationExitException(string message) : base(message) { }

		public ApplicationExitException(string message, Exception innerException) : base(message, innerException) { }
	}
}
