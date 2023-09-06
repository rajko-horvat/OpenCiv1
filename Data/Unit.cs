using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.Data
{
	public class Unit
	{
		public byte StatusFlag;
		public byte XPosition;
		public byte YPosition;
		public byte Type;
		public byte RemainingMoves;
		public byte SpecialMoves;
		public byte GotoX;
		public byte GotoY;
		public byte GotoNextDirection;
		public byte VisibleByFlag;
		public byte NextUnitInStack;
		public byte HomeCityID;
	}
}
