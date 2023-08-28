using IRB.Collections.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenCiv1.GPU
{
	[Serializable]
	public class CivFont
	{
		private BDictionary<char, CivFontCharacter> aCharacters = new BDictionary<char, CivFontCharacter>();
		private int iCharacterWidthSpacing = 1;
		private int iLineSpacing = 1;

		public CivFont()
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

		public BDictionary<char, CivFontCharacter> Characters
		{
			get { return this.aCharacters; }
		}
	}
}
