using System;
using IRB.Collections.Generic;

namespace OpenCiv1.Graphics
{
	[Serializable]
	public class GFont
	{
		private BDictionary<char, GFontChar> aCharacters = new BDictionary<char, GFontChar>();
		private int iCharacterWidthSpacing = 1;
		private int iLineSpacing = 1;

		public GFont()
		{ }

		public int LineSpacing
		{
			get { return this.iLineSpacing; }
			set { this.iLineSpacing = value; }
		}

		public int CharacterWidthSpacing
		{
			get { return this.iCharacterWidthSpacing; }
			set { this.iCharacterWidthSpacing = value; }
		}

		public BDictionary<char, GFontChar> Characters
		{
			get { return this.aCharacters; }
		}
	}
}
