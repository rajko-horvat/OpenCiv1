using HarfBuzzSharp;
using IRB.Collections.Generic;
using System.Globalization;

namespace OpenCiv1
{
	/// <summary>
	/// The class that encapsulates Language Pack including Interface text and other text elements
	/// The Language name should conform to an official IETF language tag specification: https://en.wikipedia.org/wiki/IETF_language_tag
	/// </summary>
	public class LanguagePack
	{
		private string sName = "";
		private string sDisplayName = "";
		private BDictionary<string, List<string>> oItems = new BDictionary<string, List<string>>();

		public LanguagePack()
		{ }

		public LanguagePack(string name)
		{
			CultureInfo info = CultureInfo.GetCultureInfo(name);

			this.sName = info.Name;
			this.sDisplayName = info.DisplayName;
		}

		/// <summary>
		/// The name of the Language pack in official IETF language tag specification
		/// </summary>
		public string Name
		{
			get => this.sName;
			set
			{
				CultureInfo info = CultureInfo.GetCultureInfo(value);

				this.sName = info.Name;
				this.sDisplayName = info.DisplayName;
			}
		}

		/// <summary>
		/// The Language Pack display name
		/// </summary>
		public string DisplayName
		{
			get => this.sDisplayName;
			set { this.sDisplayName = value; }
		}

		/// <summary>
		/// Language Pack key, value items
		/// The value can contain more than one string, if that is what's required
		/// </summary>
		public BDictionary<string, List<string>> Items
		{
			get => this.oItems;
		}
	}
}
