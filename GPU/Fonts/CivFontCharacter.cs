using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace OpenCiv1.GPU
{
	[Serializable]
	public class CivFontCharacter
	{
		private int iWidth = 8;
		private int iHeight = 8;
		private int[][] aiBitmap;

		public CivFontCharacter()
		{
			this.aiBitmap = new int[this.iHeight][];

			for (int i = 0; i < iHeight; i++)
			{
				this.aiBitmap[i] = new int[this.iWidth];

				for (int j = 0; j < this.iWidth; j++)
				{
					this.aiBitmap[i][j] = 0;
				}
			}
		}

		public int Width
		{
			get { return this.iWidth; }
			set { this.iWidth = value; }
		}

		public int Height
		{
			get { return this.iHeight; }
			set { this.iHeight = value; }
		}

		public int[][] Bitmap
		{
			get { return this.aiBitmap; }
			set { this.aiBitmap = value; }
		}
	}
}
