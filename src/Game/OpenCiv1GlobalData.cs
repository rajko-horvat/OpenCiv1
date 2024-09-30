using OpenCiv1.Graphics;
using System;

namespace OpenCiv1
{
	partial class OpenCiv1Game
	{
		#region Global variables
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
		public byte[] Array_1946 = new byte[] { 12, 15, 10, 9, 14, 11, 13, 7 };
		public byte[] Array_1956 = new byte[] { 4, 7, 2, 1, 10, 3, 4, 8 };
		public CRectangle Var_19d4_Rectangle = new CRectangle(1, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);
		public CRectangle Var_19e8_Rectangle = new CRectangle(2, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);

		// !!! This should not be used at all as screen 3 doesn't exist
		public CRectangle Var_19fc_Rectangle = new CRectangle(3, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);

		public int Var_1ae0 = 0;

		public int[] Array_2ba6 = new int[] {
			-1,	// Water = 0
			10,	// Coast = 1
			3,	// Forest = 2
			8,	// Swamp = 3
			-1,	// Undefined4 = 4
			-1,	// Undefined5 = 5
			1,	// Plains = 6
			6,	// Tundra = 7
			-1,	// Undefined8 = 8
			11,	// River = 9
			2,	// Grassland = 10
			9,	// Jungle = 11
			4,	// Hills = 12
			5,	// Mountains = 13
			0,	// Desert = 14
			7	// Arctic = 15
		};

		public int Var_2f9a = -1;
		public int Var_2f9c = 0;
		public int Var_2f9e = -1;
		public int Var_2fa2 = 0;

		public string[] Array_30ae = new string[] { "$US", "$THEM", "$BUCKS", "$RPLC1", "$RPLC2" };
		public string[] Array_30b8 = new string[] { "", "", "", "", "" };
		public int Var_3936 = -1;

		// 0x652e - after this offset the default values are set to 0
		public int Var_6b64 = 0;
		public int Var_6b90 = 0;
		public int Var_6b92 = 0;
		public int Var_6c98 = 0;
		public int Var_6c9a = 0;
		public int[] Array_6e00 = new int[15];
		public int[] Array_6e1e = new int[15];
		public ushort[] Array_6e96 = new ushort[9];
		public int Var_6ed6 = 0;
		public int[] Var_70da_Arr = new int[4];
		public int Var_70e2 = 0;
		public int Var_70e4 = 0;
		public int Var_70e6 = 0;
		public int Var_70ea = 0;
		public ushort[] Array_7eec = new ushort[4];
		public int Var_7ef6_MapLandMass = 0;
		public int Var_7ef8_MapTemperature = 0;
		public int Var_7efa_MapClimate = 0;
		public int Var_7efc_MapAge = 0;
		public int[] Array_804e = new int[13];
		public int Var_8078 = 0;
		public int Var_b1e8 = 0;
		public int Var_b276 = 0;
		public int Var_b278 = 0; // some kind of debugging flag
		public int[] Array_b27a = new int[8];
		public int[] Array_b29a = new int[8];
		public int Var_b880 = 0;
		public int Var_b882 = 0;
		public ushort[,] Array_b886 = new ushort[10, 16];
		public ushort Var_b2ba = 0;
		public int Var_d206 = 0;
		public int Var_d20a = 0;
		public ushort[,] Array_d294 = new ushort[8, 4];
		public int[] Array_d2d4 = new int[4];
		public int Var_d2de = 0;
		public int Var_d2e0 = 0;
		public int Var_d2f6 = 0;
		public short Var_d4cc_XPos = 0;
		public ushort[] Array_d4ce = new ushort[320];
		public short Var_d75e_YPos = 0;
		public ushort Var_d768 = 0;
		public bool Var_d76a_IsEarthMap = false;
		public short Var_d7f0 = 0;
		public int Var_d806 = 0;
		public int Var_db38 = 0;
		public int Var_db3a = 0;
		public int Var_db3c = 0;
		public ushort Var_db3e = 0;
		public int Var_db42 = 0;
		public int Var_dcfc = 0;
		public int Var_deb8 = 0;
		public int[] Array_df62 = new int[3];
		public int Var_e17a = 0;
		public int Var_e17c = 0;
		public int Var_e3c2 = 0;
		public int Var_e3c6 = 0;
		public int Var_e8b8 = 0;
		#endregion
	}
}
