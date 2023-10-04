using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenCiv1
{
	public class Unit
	{
		public byte StatusFlag = 0;
		public Point Position = new Point(0, 0);
		public byte Type = 0;
		public byte RemainingMoves = 0;
		public byte SpecialMoves = 0;
		public Point GotoPosition = new Point(0, 0);
		public byte GotoNextDirection = 0;
		public byte VisibleByFlag = 0;
		public byte NextUnitInStack = 0;
		public byte HomeCityID = 0;
	}
}
