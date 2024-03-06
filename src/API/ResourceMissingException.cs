using System;

namespace OpenCiv1
{
	public class ResourceMissingException : Exception
	{
		public ResourceMissingException() : base() { }

		public ResourceMissingException(string message) : base(message) { }

		public ResourceMissingException(string message, Exception innerException) : base(message, innerException) { }
	}
}
