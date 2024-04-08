using OpenCiv1.GPU;
using System;

namespace OpenCiv1
{
	partial class Game
	{
		#region Global variables
		public GPoint[] aiCityOffsets = new GPoint[] { 
			new GPoint(0, -1), new GPoint(1, 0), new GPoint(0, 1), 
			new GPoint(-1, 0), new GPoint(1, -1), new GPoint(1, 1), new GPoint(-1, 1), new GPoint(-1, -1), 
			new GPoint(0, -2), new GPoint(2, 0), new GPoint(0, 2), new GPoint(-2, 0), new GPoint(-1, -2), 
			new GPoint(1, -2), new GPoint(2, -1), new GPoint(2, 1), new GPoint(1, 2), new GPoint(-1, 2), 
			new GPoint(-2, 1), new GPoint(-2, -1), new GPoint(0, 0) };

		public GPoint[] MoveOffsets = new GPoint[] {
			new GPoint(0, 0), new GPoint(0, -1), new GPoint(1, -1),
			new GPoint(1, 0), new GPoint(1, 1), new GPoint(0, 1), 
			new GPoint(-1, 1), new GPoint(-1, 0), new GPoint(-1, -1), 
			new GPoint(0, -2), new GPoint(1, -2), new GPoint(2, -1), 
			new GPoint(2, 0), new GPoint(2, 1), new GPoint(1, 2), 
			new GPoint(0, 2), new GPoint(-1, 2), new GPoint(-2, 1), 
			new GPoint(-2, 0), new GPoint(-2, -1), new GPoint(-1, -2), 
			new GPoint(2, 2), new GPoint(2, -2), new GPoint(-2, -2), 
			new GPoint(-2, 2), new GPoint(0, -3), new GPoint(1, -3), 
			new GPoint(2, -3), new GPoint(3, -2), new GPoint(3, -1), 
			new GPoint(3, 0), new GPoint(3, 1), new GPoint(3, 2), 
			new GPoint(2, 3), new GPoint(1, 3), new GPoint(0, 3), 
			new GPoint(-1, 3), new GPoint(-2, 3), new GPoint(-3, 2), 
			new GPoint(-3, 1), new GPoint(-3, 0), new GPoint(-3, -1), 
			new GPoint(-3, -2), new GPoint(-2, -3), new GPoint(-1, -3),
			new GPoint(3, 3), new GPoint(3, -3), new GPoint(-3, 3), 
			new GPoint(-3, -3)};

		public ushort Var_d768 = 0;
		public ushort Var_db3a = 0;
		public ushort Var_db3c = 0;
		public ushort Var_db3e = 0;
		#endregion
	}
}
