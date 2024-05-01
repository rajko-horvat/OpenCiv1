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
		
		public CRectangle Var_aa_Rectangle = new CRectangle(0, 0, 0, 319, 199, 0x1, 15, 0, 4, 0, 0);
		public CRectangle Var_19d4_Rectangle = new CRectangle(1, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);
		public CRectangle Var_19e8_Rectangle = new CRectangle(2, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);

		// !!! This should not be used at all as screen 3 doesn't exist
		public CRectangle Var_19fc_Rectangle = new CRectangle(3, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);

		public ushort Var_2f9e_Unknown = 0xffff;

		// 0x652e - after this offset the default values are set to 0
		public ushort Var_6c98 = 0;
		public ushort Var_6c9a = 0;
		public ushort[] Var_70da_Arr = new ushort[4];
		public ushort Var_b1e8 = 0;
		public ushort Var_b882 = 0;
		public ushort Var_d2f6 = 0;
		public short Var_d4cc_XPos = 0;
		public short Var_d75e_YPos = 0;
		public ushort Var_d768 = 0;
		public ushort Var_db3a = 0;
		public ushort Var_db3c = 0;
		public ushort Var_db3e = 0;
		public ushort Var_deb8 = 0;
		public ushort Var_e3c6 = 0;
		public ushort Var_e8b8 = 0;
		#endregion
	}
}
