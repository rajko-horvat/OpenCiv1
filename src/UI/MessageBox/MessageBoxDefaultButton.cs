using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.UI
{
	public enum MessageBoxDefaultButton
	{
		/// <summary>No default button, the User has to click on button instead of just pressing Enter key</summary>
		None,

		/// <summary>Specifies that the first button on the Message Box should be the default button</summary>
		Button1,

		/// <summary>Specifies that the second button on the Message Box should be the default button</summary>
		Button2,

		/// <summary>Specifies that the third button on the Message Box should be the default button</summary>
		Button3
	}
}
