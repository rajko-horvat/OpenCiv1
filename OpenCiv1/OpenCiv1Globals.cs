using OpenCiv1.GPU;
using System;

namespace OpenCiv1
{
	partial class OpenCiv1
	{
		#region Global variables
		public GPoint[] aiCityOffsets = new GPoint[] { 
			new GPoint(0, -1), new GPoint(1, 0), new GPoint(0, 1), 
			new GPoint(-1, 0), new GPoint(1, -1), new GPoint(1, 1), new GPoint(-1, 1), new GPoint(-1, -1), 
			new GPoint(0, -2), new GPoint(2, 0), new GPoint(0, 2), new GPoint(-2, 0), new GPoint(-1, -2), 
			new GPoint(1, -2), new GPoint(2, -1), new GPoint(2, 1), new GPoint(1, 2), new GPoint(-1, 2), 
			new GPoint(-2, 1), new GPoint(-2, -1), new GPoint(0, 0) };

		public ushort Var_d768 = 0;
		public ushort Var_db3a = 0;
		public ushort Var_db3c = 0;
		public ushort Var_db3e = 0;
		#endregion
	}
}
