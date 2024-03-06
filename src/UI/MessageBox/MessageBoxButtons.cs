using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.UI
{
	public enum MessageBoxButtons
	{
		/// <summary>Specifies that the Message Box contains an OK button</summary>
		OK,

		/// <summary>Specifies that the Message Box contains OK and Cancel buttons</summary>
		OKCancel,

		/// <summary>Specifies that the Message Box contains Abort, Retry, and Ignore buttons</summary>
		AbortRetryIgnore,

		/// <summary>Specifies that the Message Box contains Yes, No, and Cancel buttons</summary>
		YesNoCancel,

		/// <summary>Specifies that the Message Box contains Yes and No buttons</summary>
		YesNo,

		/// <summary>Specifies that the Message Box contains Retry and Cancel buttons</summary>
		RetryCancel,

		/// <summary>Specifies that the Message Box contains Cancel, Try Again, and Continue buttons</summary>
		CancelTryContinue
	}
}
