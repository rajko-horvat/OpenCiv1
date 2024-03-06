using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.UI
{
	public enum MessageBoxIcon
	{
		/// <summary>Specifies that the Message Box contains no icon</summary>
		None = 0,

		/// <summary>Specifies that the Message Box contains a hand symbol</summary>
		Stop,
		Hand = Stop,
		Error = Stop,

		/// <summary>Specifies that the Message Box contains a question mark symbol</summary>
		Question,

		/// <summary>Specifies that the Message Box contains an exclamation symbol</summary>
		Warning,
		Exclamation = Warning,

		/// <summary>Specifies that the Message Box contains an asterisk symbol</summary>
		Information,
		Asterisk = Information
	}
}
