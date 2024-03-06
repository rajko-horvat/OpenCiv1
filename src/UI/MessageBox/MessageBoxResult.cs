using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.UI
{
	/// <summary>Possible return values from the Message Box.</summary>
	public enum MessageBoxResult
	{
		/// <summary>Nothing is returned from the Message Box. This means that the modal dialog continues running.</summary>
		None = 0,

		/// <summary>The Message Box return value is OK</summary>
		OK,

		/// <summary>The Message Box return value is Cancel</summary>
		Cancel,

		/// <summary>The Message Box return value is Abort</summary>
		Abort,

		/// <summary>The Message Box return value is Retry</summary>
		Retry,

		/// <summary>The Message Box return value is Ignore</summary>
		Ignore,

		/// <summary>The Message Box return value is Yes</summary>
		Yes,

		/// <summary>The Message Box return value is No</summary>
		No,

		/// <summary>The Message Box return value is Try Again</summary>
		TryAgain,

		/// <summary>The Message Box return value is Continue</summary>
		Continue
	}
}
