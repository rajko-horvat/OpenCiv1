using OpenCiv1.Graphics;
using System;

namespace OpenCiv1
{
	partial class OpenCiv1Game
	{
		#region Global variables
		public GPoint[] CityOffsets = new GPoint[] { 
			new GPoint(0, -1), new GPoint(1, 0), new GPoint(0, 1), new GPoint(-1, 0), 
			new GPoint(1, -1), new GPoint(1, 1), new GPoint(-1, 1), new GPoint(-1, -1), 
			new GPoint(0, -2), new GPoint(2, 0), new GPoint(0, 2), new GPoint(-2, 0), 
			new GPoint(-1, -2), new GPoint(1, -2), new GPoint(2, -1), new GPoint(2, 1), new GPoint(1, 2), new GPoint(-1, 2), new GPoint(-2, 1), new GPoint(-2, -1), 
			new GPoint(0, 0) };

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

		public int Var_42 = 0; // ushort
		public int Var_44 = 0; // ushort
		public int Var_46 = 0; // ushort
		public int Var_48 = 0; // ushort
		public ushort Var_4a = 0; // ushort
		public int Var_4c = 0;  // ushort
		public int Var_4e = 0; // ushort
		public int Var_50 = 0; // ushort
		public int Var_52 = 0; // ushort
		public int Var_54 = 0; // ushort
		public ushort Var_56 = 0; // ushort
		public ushort Var_58 = 0; // byte
		public ushort Var_59 = 0; // byte
		public ushort Var_5a_TimerInitialized = 0; // byte
		public ushort Var_5c_TickCount = 0; // ushort
		public int Var_5e = 7; // byte

		public ushort Var_60 = 0; // ushort
		public ushort Var_62 = 0; // ushort
		public ushort Var_64 = 0; // ushort
		public ushort Var_66 = 0; // ushort
		public ushort Var_68 = 0; // ushort
		public ushort Var_6a = 0; // ushort
		public ushort Var_6c = 0; // ushort

		public CRectangle Var_aa_Rectangle = new CRectangle(0, 0, 0, 319, 199, 0x1, 15, 0, 4, 0, 0);
		public CRectangle Var_19d4_Rectangle = new CRectangle(1, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);
		public CRectangle Var_19e8_Rectangle = new CRectangle(2, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);

		// !!! This should not be used at all as screen 3 doesn't exist
		public CRectangle Var_19fc_Rectangle = new CRectangle(3, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);

		/// <summary>
		/// Allows to customize dialog shown by F0_1238_001e_ShowDialog().
		/// </summary>
		public ReportTypeEnum Var_2f9e_MessageBoxStyle = ReportTypeEnum.Default;

		// 0x652e - after this offset the default values are set to 0
		public int Var_6b64 = 0;
		public int Var_6b92 = 0;
		public int Var_6c98 = 0;
		public int Var_6c9a = 0;
		public int[] Var_70da_Arr = new int[4];
		public int Var_70e2 = 0;
		public int Var_70e4 = 0;
		public int Var_70e6 = 0;
		public int Var_8078 = 0;
		public int Var_b1e8 = 0;
		//public int Var_b278 = 0; This was some kind of experiment, Always 0, can be safely removed througout entire code
		public int Var_b882 = 0;
		public ushort Var_b2ba = 0;
		public int Var_d2de = 0;
		public int Var_d2e0 = 0;
		public int Var_d2f6 = 0;
		/// <summary>X coordinate of the top left cell in map view</summary>
		public int Var_d4cc_MapViewX = 0;
		/// <summary>Y coordinate of the top left cell in map view</summary>
		public int Var_d75e_MapViewY = 0;
		public ushort Var_d762 = 0;
		public ushort Var_d768 = 0;
		public bool Var_d806_DebugFlag = false;

		// Currently pressed mouse button: 0 - nothing, 1 - left button, 2 - right button
		public ushort Var_db3a_MouseButton = 0;
		// Current mouse position, in pixels. Position (0, 0) is the top-left corner
		public ushort Var_db3c_MouseXPos = 0;
		public ushort Var_db3e_MouseYPos = 0;

		public int Var_db42 = 0;
		public int Var_deb8 = 0;
		public int Var_e17a = 0;
		public int Var_e3c2 = 0;
		public int Var_e3c6 = 0;
		public int Var_e8b8 = 0;
		#endregion
	}
}
