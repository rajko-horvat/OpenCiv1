using OpenCiv1.Graphics;
using System;

namespace OpenCiv1
{
	partial class OpenCiv1Game
	{
		#region Global variables
		public GSize ScreenSize = new GSize(320, 200);

		public GPoint[] CityOffsets = new GPoint[] { 
			new GPoint(0, -1), new GPoint(1, 0), new GPoint(0, 1), new GPoint(-1, 0), 
			new GPoint(1, -1), new GPoint(1, 1), new GPoint(-1, 1), new GPoint(-1, -1), 
			new GPoint(0, -2), new GPoint(2, 0), new GPoint(0, 2), new GPoint(-2, 0), 
			new GPoint(-1, -2), new GPoint(1, -2), new GPoint(2, -1), new GPoint(2, 1), new GPoint(1, 2), new GPoint(-1, 2), new GPoint(-2, 1), new GPoint(-2, -1), 
			new GPoint(0, 0) };

		public GPoint[] MoveDirections = new GPoint[] {
			new GPoint(0, 0), new GPoint(0, -1), new GPoint(1, -1), // 1
			new GPoint(1, 0), new GPoint(1, 1), new GPoint(0, 1), 
			new GPoint(-1, 1), new GPoint(-1, 0), new GPoint(-1, -1), 
			new GPoint(0, -2), new GPoint(1, -2), new GPoint(2, -1), // 2, starts at index 9
			new GPoint(2, 0), new GPoint(2, 1), new GPoint(1, 2), 
			new GPoint(0, 2), new GPoint(-1, 2), new GPoint(-2, 1), 
			new GPoint(-2, 0), new GPoint(-2, -1), new GPoint(-1, -2), 
			new GPoint(2, 2), new GPoint(2, -2), new GPoint(-2, -2), 
			new GPoint(-2, 2),
			new GPoint(0, -3), new GPoint(1, -3), new GPoint(2, -3), // 3, starts at index 25
			new GPoint(3, -2), new GPoint(3, -1), new GPoint(3, 0), 
			new GPoint(3, 1), new GPoint(3, 2), new GPoint(2, 3), 
			new GPoint(1, 3), new GPoint(0, 3), new GPoint(-1, 3), 
			new GPoint(-2, 3), new GPoint(-3, 2), new GPoint(-3, 1), 
			new GPoint(-3, 0), new GPoint(-3, -1), new GPoint(-3, -2), 
			new GPoint(-2, -3), new GPoint(-1, -3), new GPoint(3, 3), 
			new GPoint(3, -3), new GPoint(-3, 3), new GPoint(-3, -3)}; // size is 49

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

		public CRectangle Var_aa_Screen0_Rectangle = new CRectangle(0, 0, 0, 319, 199, 0x1, 15, 0, 4, 0, 0);
		public CRectangle Var_19d4_Screen1_Rectangle = new CRectangle(1, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);
		public CRectangle Var_19e8_Screen2_Rectangle = new CRectangle(2, 0, 0, 319, 199, 0x0, 15, 0, 4, 0, 0);

		public byte[] Array_1946 = { 12, 15, 10, 9, 14, 11, 13, 7 };
		public byte[] Array_1956 = { 4, 7, 2, 1, 10, 3, 4, 8 };
		public string[] Array_1966 = { "Anarchy", "Despotism", "Monarchy", "Communist", "Republic", "Democratic" };

		public char Var_1a30_SoundDriverType = 'N';
		public bool Var_1a3c_MouseAvailable = true;
		public int Var_1a3e = 0;
		public int Var_1ae0 = 0;

		// Convert pixel value to actual TerrainTypeEnum value
		public TerrainTypeEnum[] PixelValuesToTerrainTypes = {
			TerrainTypeEnum.Invalid,	// Undefined0 = 0
			TerrainTypeEnum.Water,		// Water = 1
			TerrainTypeEnum.Forest,		// Forest = 2
			TerrainTypeEnum.Swamp,		// Swamp = 3
			TerrainTypeEnum.Invalid,	// Undefined4 = 4
			TerrainTypeEnum.Invalid,	// Undefined5 = 5
			TerrainTypeEnum.Plains,		// Plains = 6
			TerrainTypeEnum.Tundra,		// Tundra = 7
			TerrainTypeEnum.Invalid,	// Undefined8 = 8
			TerrainTypeEnum.River,		// River = 9
			TerrainTypeEnum.Grassland,	// Grassland = 10
			TerrainTypeEnum.Jungle,		// Jungle = 11
			TerrainTypeEnum.Hills,		// Hills = 12
			TerrainTypeEnum.Mountains,	// Mountains = 13
			TerrainTypeEnum.Desert,		// Desert = 14
			TerrainTypeEnum.Arctic		// Arctic = 15
		};

		public int[] TerrainTypeToPixelValues = {
			14, // Desert = 0
			6, // Plains = 1
			10, // Grassland = 2
			2, // Forest = 3
			12, // Hills = 4
			13, // Mountains = 5
			7, // Tundra = 6
			15, // Arctic = 7
			3, // Swamp = 8
			11, // Jungle = 9
			1, // Water = 10
			9 // River = 11
		};

		public bool Var_2f98_PatternAvailable = false;

		public int Var_d7f2_MenuBoxCheckedOptions = 0;
		public int Var_b276_MenuBoxDisabledOptions = 0;
		public int Var_2f9a_MenuBoxDefaultOptionIndex = -1;
		public bool Var_2f9c_MenuBoxHelpRequested = false;

		/// <summary>
		/// Allows to customize dialog shown by F0_1238_001e_ShowDialog().
		/// </summary>
		public MenuBoxReportTypeEnum Var_2f9e_MessageBoxStyle = MenuBoxReportTypeEnum.None;
		public bool Var_2fa2_DialogMousePressed = false;
		public string[] Array_2fac = { "Defense Minister:", "Domestic Advisor:", "Foreign Minister:", "Science Advisor:" };

		public string[] Array_33a2_GameDifficultyNames = { "Chief", "Lord", "Prince", "King", "Emperor" };

		public int Var_3484 = -1;
		public GPoint[] Array_35da = { new(0, 0), new(36, 19), new(45, 22), new(38, 15), new(41, 24), new(12, 18), new(39, 18), new(57, 24), 
			new(0, 0), new(44, 12), new(42, 42), new(33, 16), new(5, 23), new(66, 19), new(31, 14), new(49, 19) };
		public int Var_3936 = -1;
		public int Var_5402 = 0;
		public int Var_5403 = 0;
		public int Var_586e_MouseNewX = 0;
		public int Var_5870_MouseNewY = 0;
		public int Var_5872_MouseNewButtons = 0;
		public int Var_5874_MouseNewButtonsOr = 0;
		public int Var_5876_MouseIcon = 0;
		public int Var_5878_MouseIconXOffset = 0;
		public int Var_587a_MouseIconYOffset = 0;
		public int Var_587d = 0;

		// 0x652e - after this offset the default values are set to 0
		public int Var_6b32_SelectedGameType = 0;
		public byte[] Var_6b34 = new byte[48];
		public int Var_6b64 = 0;
		public int Var_6b90 = 0;
		public int Var_6b92 = 0;
		public int Var_6c98 = 0;
		public int Var_6c9a = 0;
		public int[] Array_6e00 = new int[32];
		public int Var_6e92_MouseIconHandle = 0;
		public int[] Array_6e96 = new int[9];
		public int Var_6ed6 = 0;
		public bool Var_70d8 = false;
		public int[] Var_70da_Arr = new int[4];
		public int Var_70e2 = 0;
		public int Var_70e4 = 0;
		public int Var_70e6 = 0;
		public int Var_70ea = 0;
		public int[] Array_7eec = new int[4];

		public int Var_7ef6_PlanetLandMass = 1;
		public int Var_7ef8_PlanetTemperature = 1;
		public int Var_7efa_PlanetClimate = 1;
		public int Var_7efc_PlanetAge = 1;

		public int Var_8078 = 0;
		public int Var_b1e8 = 0;
		
		public int[] Array_b27a = new int[8];
		public int[] Array_b29a = new int[8];
		public int Var_b880 = 0;
		public int Var_b882 = 0;
		public int Var_b884 = 0;
		public int[,] Array_b886 = new int[10, 16];
		public int Var_b2ba = 0;
		public int Var_d20a = 0;
		public int[,] Array_d21c = new int[3, 20];
		public int[,] Array_d294 = new int[8, 4];
		public int[] Array_d2d4 = new int[4];
		public int Var_d2de = 0;
		public int Var_d2e0 = 0;
		public int Var_d2f6 = 0;
		/// <summary>X coordinate of the top left cell in map view</summary>
		public int Var_d4cc_MapViewX = 0;
		/// <summary>Y coordinate of the top left cell in map view</summary>
		public int[] Array_d4ce = new int[320];
		public int Var_d75e_MapViewY = 0;
		public bool Var_d760_HumanPlayerMessageFlag = false;
		public ushort Var_d768 = 0;
		public bool Var_d76a_EarthMap = false;
		public int Var_d7f0 = 0;
		public bool Var_d806_DebugFlag = false;

		public int Var_db38 = 0;
		// Currently pressed mouse button: 0 - nothing, 1 - left button, 2 - right button
		public int Var_db3a_MouseButton = 0;
		// Current mouse position, in pixels. Position (0, 0) is the top-left corner
		public int Var_db3c_MouseXPos = 0;
		public int Var_db3e_MouseYPos = 0;

		public int Var_db42 = 0;
		public int Var_dc48_GameEndType = 0;
		public int Var_dcfc = 0;
		public int Var_deb8 = 0;
		public int Var_df0c = 0;
		public int Var_df60 = 0;
		public int[] Array_df62 = new int[3];
		public int Var_e17a = 0;
		public int Var_e3c2 = 0;
		public int Var_e3c6 = 0;
		public int Var_e8b8 = 0;
		#endregion
	}
}
