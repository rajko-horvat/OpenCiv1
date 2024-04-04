using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class SpaceshipCell
	{
		public sbyte XPos;
		public sbyte YPos;
		public sbyte BitmapID;

		public SpaceshipCell(sbyte xPos, sbyte yPos, sbyte bitmapID)
		{
			this.XPos = xPos;
			this.YPos = yPos;
			this.BitmapID = bitmapID;
		}
	}
}
