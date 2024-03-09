using System;
using System.IO;
using System.Reflection;
using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public partial class Game
	{
		private CPU oCPU;

		#region Segment definitions
		private Segment_11a8 oSegment_11a8;
		private Segment_1000 oSegment_1000;
		private Segment_1238 oSegment_1238;
		private Segment_2d05 oSegment_2d05;
		private Segment_1403 oSegment_1403;
		private Segment_2dc4 oSegment_2dc4;
		private Segment_1182 oSegment_1182;
		private ImageTools oImageTools;
		private Segment_2f4d oSegment_2f4d;
		private Segment_2aea oSegment_2aea;
		private Segment_1866 oSegment_1866;
		private Segment_2e31 oSegment_2e31;
		private Segment_2459 oSegment_2459;
		private Segment_25fb oSegment_25fb;
		private Segment_1ade oSegment_1ade;
		private Segment_1d12 oSegment_1d12;
		private Segment_29f3 oSegment_29f3;
		private Segment_2517 oSegment_2517;
		private Segment_2c84 oSegment_2c84;
		private MainIntro oMainIntro;
		private MeetWithKing oMeetWithKing;
		private GameInitAndIntro oGameInitAndIntro;
		private Help oHelp;
		private GameLoadAndSave oGameLoadAndSave;
		private HallOfFame oHallOfFame;
		private StartGameMenu oStartGameMenu;
		private Overlay_23 oOverlay_23;
		private Overlay_14 oOverlay_14;
		private Civilopedia oCivilopedia;
		private Overlay_21 oOverlay_21;
		private CityView oCityView;
		private Overlay_18 oOverlay_18;
		private Overlay_22 oOverlay_22;
		private GameReplay oGameReplay;
		private Overlay_13 oOverlay_13;
		private WorldMap oWorldMap;
		private Overlay_20 oOverlay_20;
		private Palace oPalace;
		private Overlay_10 oOverlay_10;
		private Overlay_15 oOverlay_15;
		private MSCAPI oMSCAPI;
		private GDriver oGraphics;
		private NSound oSound;
		#endregion

		private LogWrapper oLog;
		private LogWrapper oInterruptLog;
		private LogWrapper oVGADriverLog;
		private LogWrapper oIntroLog;

		private ushort usStartSegment = 0x1000;

		private GameState oGameState;

		public Game()
		{
			this.oLog = new LogWrapper($"{CPU.AssemblyPath}Log.txt");
			this.oInterruptLog = new LogWrapper($"{CPU.AssemblyPath}InterruptLog.txt");
			this.oVGADriverLog = new LogWrapper($"{CPU.AssemblyPath}VGADriverLog.txt");
			this.oIntroLog = new LogWrapper($"{CPU.AssemblyPath}IntroLog.txt");

			this.oCPU = new CPU(this, this.oLog);

			this.oLog.CPU = this.oCPU;
			this.oInterruptLog.CPU = this.oCPU;
			this.oVGADriverLog.CPU = this.oCPU;
			this.oIntroLog.CPU = this.oCPU;

			this.oGameState = new GameState();

			#region Initialize Segments
			this.oMSCAPI = new MSCAPI(this);
			this.oGraphics = new GDriver(this);
			this.oSound = new NSound(this);

			this.oSegment_11a8 = new Segment_11a8(this);
			this.oSegment_1000 = new Segment_1000(this);
			this.oSegment_1238 = new Segment_1238(this);
			this.oSegment_2d05 = new Segment_2d05(this);
			this.oSegment_1403 = new Segment_1403(this);
			this.oSegment_2dc4 = new Segment_2dc4(this);
			this.oSegment_1182 = new Segment_1182(this);
			this.oImageTools = new ImageTools(this);
			this.oSegment_2f4d = new Segment_2f4d(this);
			this.oSegment_2aea = new Segment_2aea(this);
			this.oSegment_1866 = new Segment_1866(this);
			this.oSegment_2e31 = new Segment_2e31(this);
			this.oSegment_2459 = new Segment_2459(this);
			this.oSegment_25fb = new Segment_25fb(this);
			this.oSegment_1ade = new Segment_1ade(this);
			this.oSegment_1d12 = new Segment_1d12(this);
			this.oSegment_29f3 = new Segment_29f3(this);
			this.oSegment_2517 = new Segment_2517(this);
			this.oSegment_2c84 = new Segment_2c84(this);
			this.oMainIntro = new MainIntro(this);
			this.oMeetWithKing = new MeetWithKing(this);
			this.oGameInitAndIntro = new GameInitAndIntro(this);
			this.oHelp = new Help(this);
			this.oGameLoadAndSave = new GameLoadAndSave(this);
			this.oHallOfFame = new HallOfFame(this);
			this.oStartGameMenu = new StartGameMenu(this);
			this.oOverlay_23 = new Overlay_23(this);
			this.oOverlay_14 = new Overlay_14(this);
			this.oCivilopedia = new Civilopedia(this);
			this.oOverlay_21 = new Overlay_21(this);
			this.oCityView = new CityView(this);
			this.oOverlay_18 = new Overlay_18(this);
			this.oOverlay_22 = new Overlay_22(this);
			this.oGameReplay = new GameReplay(this);
			this.oOverlay_13 = new Overlay_13(this);
			this.oWorldMap = new WorldMap(this);
			this.oOverlay_20 = new Overlay_20(this);
			this.oPalace = new Palace(this);
			this.oOverlay_10 = new Overlay_10(this);
			this.oOverlay_15 = new Overlay_15(this);
			#endregion

			/*string[] aFiles = Directory.GetFiles(this.oCPU.DefaultCIVPath, "*.pic");

			for (int i = 0; i < aFiles.Length; i++)
			{
				byte[] palette;
				VGABitmap bitmap = VGABitmap.FromPICFile(aFiles[i], out palette);

				bitmap.Bitmap.SaveToPIC(Path.GetFileNameWithoutExtension(aFiles[i]) + ".bmp", ImageFormat.Bmp);
			}//*/
		}

		public void Start()
		{
			#region Check Resources
			// Check for Default directory and individual Resource files
			if (!string.IsNullOrEmpty(CPU.DefaultCIVPath) && !Directory.Exists(CPU.DefaultCIVPath))
			{
				throw new ResourceMissingException($"Resource path not found at '{CPU.DefaultCIVPath}'.");
			}

			string[] aResourceFiles = new string[] {
				"adscreen.pic", "arch.pic", "back0a.pic", "back0m.pic", "back1a.pic", "back1m.pic", "back2a.pic", "back2m.pic",
				"back3a.pic", "birth0.pic", "birth1.pic", "birth2.pic", "birth3.pic", "birth4.pic", "birth5.pic", "birth6.pic",
				"birth7.pic", "birth8.pic", "castle0.pic", "castle1.pic", "castle2.pic", "castle3.pic", "castle4.pic", "cback.pic",
				"cbacks1.pic", "cbacks2.pic", "cbacks3.pic", "cbrush0.pic", "cbrush1.pic", "cbrush2.pic", "cbrush3.pic",
				"cbrush4.pic", "cbrush5.pic", "civ.exe", "citypix1.pic", "citypix2.pic", "citypix3.pic", "custom.pic", "diffs.pic",
				"discovr1.pic", "discovr2.pic", "docker.pic", "govt0a.pic", "govt0m.pic", "govt1a.pic", "govt1m.pic", "govt2a.pic",
				"govt2m.pic", "govt3a.pic", "hill.pic", "iconpg1.pic", "iconpg2.pic", "iconpg3.pic", "iconpg4.pic", "iconpg5.pic",
				"iconpg6.pic", "iconpg7.pic", "iconpg8.pic", "iconpga.pic", "iconpgb.pic", "iconpgc.pic", "iconpgd.pic",
				"iconpge.pic", "iconpgt1.pic", "iconpgt2.pic", "invader2.pic", "invader3.pic", "invaders.pic", "king00.pic",
				"king01.pic", "king02.pic", "king03.pic", "king04.pic", "king05.pic", "king06.pic", "king07.pic", "king08.pic",
				"king09.pic", "king10.pic", "king11.pic", "king12.pic", "king13.pic", "kink00.pic", "kink03.pic", "logo.pic",
				"love1.pic", "love2.pic", "map.pic", "nuke1.pic", "planet1.pic", "planet2.pic", "pop.pic", "riot.pic", "riot2.pic",
				"sad.pic", "settlers.pic", "slag2.pic", "slam1.pic", "slam2.pic", "sp257.pic", "sp299.pic", "spacest.pic",
				"sprites.pic", "ter257.pic", "torch.pic", "wonders.pic", "wonders2.pic", "back0a.pal", "back0m.pal", "back1a.pal",
				"back1m.pal", "back2a.pal", "back2m.pal", "back3a.pal", "birth0.pal", "birth1.pal", "birth2.pal", "birth3.pal",
				"birth4.pal", "birth5.pal", "birth6.pal", "birth7.pal", "birth8.pal", "discovr1.pal", "discovr2.pal", "hill.pal",
				"iconpg1.pal", "iconpga.pal", "king00.pal", "king01.pal", "king02.pal", "king03.pal", "king04.pal", "king05.pal",
				"king06.pal", "king07.pal", "king08.pal", "king09.pal", "king10.pal", "king11.pal", "king12.pal", "king13.pal",
				"slam1.pal", "sp256.pal", "sp257.pal", "blurb0.txt", "blurb1.txt", "blurb2.txt", "blurb3.txt", "blurb4.txt",
				"credits.txt", "error.txt", "help.txt", "intro.txt", "intro3.txt", "king.txt", "produce.txt", "story.txt"
			};

			for (int i = 0; i < aResourceFiles.Length; i++)
			{
				string sFilePath = $"{CPU.DefaultCIVPath}{aResourceFiles[i].ToUpper()}";

				if (!File.Exists(sFilePath))
				{
					throw new ResourceMissingException($"Missing resource file {sFilePath}. Plsease ensure that the file exists at specified path.");
				}
			}
			#endregion

			//ushort usInitialCS = 0x2045; // oEXE.InitialCS;
			ushort usInitialSS = 0x398d; // oEXE.InitialSS;
			ushort usInitialSP = 0x0800; // oEXE.InitialSP;

			this.oCPU.Memory.AllocateMemoryBlock(0xff00, 0x100, CPUMemoryFlagsEnum.ReadWrite);
			this.oCPU.Memory.WriteUInt16(0xff00, 0x20cd);
			this.oCPU.Memory.WriteUInt16(0xff02, (ushort)(this.oCPU.Memory.FreeMemory.End >> 4));
			this.oCPU.Memory.WriteUInt8(0xff81, (byte)'\r');
			this.oCPU.Memory.MemoryRegions[1].AccessFlags = CPUMemoryFlagsEnum.ReadWrite | CPUMemoryFlagsEnum.WriteWarning | CPUMemoryFlagsEnum.ReadWarning;

			uint uiEXEStart = CPU.ToLinearAddress(usStartSegment, 0);
			uint uiEXELength = 0x3a0e0;

			byte[] resources = Resources.BinaryResources;

			this.oCPU.Memory.AllocateMemoryBlock(uiEXEStart, uiEXELength, CPUMemoryFlagsEnum.ReadWrite);
			this.oCPU.Memory.WriteBlock(CPU.ToLinearAddress(0x35cf, 0), resources, 0, resources.Length);
			this.oCPU.Memory.MemoryRegions[2].AccessFlags |= CPUMemoryFlagsEnum.WriteWarning;

			// Define data and stack region
			uint uiDataStart = uiEXEStart + CPU.ToLinearAddress(0x25cf, 0);
			uint uiDataEnd = uiEXEStart + CPU.ToLinearAddress(0x2b01, 0xf0c0);

			this.oCPU.Memory.MemoryRegions[2].End = uiDataStart - 1;
			this.oCPU.Memory.MemoryRegions.Add(
				new CPUMemoryRegion(uiDataStart, (uiDataEnd - uiDataStart) + 1, CPUMemoryFlagsEnum.ReadWrite));

			// Initialize CPU
			//this.oCPU.CS.Word = (ushort)(usInitialCS + usStartSegment);
			this.oCPU.SS.Word = (ushort)(usInitialSS + usStartSegment);
			this.oCPU.DS.Word = (ushort)(usStartSegment - 0x10);
			this.oCPU.ES.Word = (ushort)(usStartSegment - 0x10);
			this.oCPU.SP.Word = usInitialSP;

			ushort usDataSegment = 0x3b01;

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);

			this.oCPU.DS.Word = 0x3b01;

			// Not important, but just for case it's still needed, to be removed later
			string sPath = $"{CPU.DefaultCIVPath}CIV.EXE";

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x61ee, (byte)'C');
			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, 0x6156), sPath, sPath.Length);

			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.DS.Word;

			this.oCPU.SI.Word = (ushort)(this.oCPU.Memory.FreeMemory.End >> 4); // top of memory
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, usDataSegment);

			// Init SS:SP
			this.oCPU.CLI();
			this.oCPU.SS.Word = usDataSegment;
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xe8c0);
			this.oCPU.STI();

			// Align SP
			this.oCPU.SP.Word = this.oCPU.ANDWord(this.oCPU.SP.Word, 0xfffe);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, 0x5890, this.oCPU.SP.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, 0x588c, this.oCPU.SP.Word);

			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 4);
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, 0x588a, this.oCPU.AX.Word);

			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, usDataSegment);
			this.oCPU.BX.Word = this.oCPU.ES.Word;
			this.oCPU.BX.Word = this.oCPU.SUBWord(this.oCPU.BX.Word, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
			if (this.oCPU.Memory.ResizeMemoryBlock(this.oCPU.ES.Word, this.oCPU.BX.Word))
			{
				this.oCPU.Flags.C = false;
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.Flags.C = true;
				this.oCPU.AX.Word = 8;
				this.oCPU.BX.Word = 0;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, 0x5901, this.oCPU.DS.Word);

			this.oCPU.ES.Word = this.oCPU.SS.Word;
			this.oCPU.DS.Word = this.oCPU.SS.Word;

			// Clear the rest of data and stack segment 0x652e - 0xe8c0
			for (int i = 0x652e; i < this.oCPU.SP.Word; i++)
			{
				if (i < 0x70ec && i > 0x70ec + 0xdff)
					this.oCPU.WriteUInt8(usDataSegment, (ushort)i, 0);
			}

			#region Protect already mapped data objects

			#region Strings
			// Skip checking of strings as it slows down VCPU too much

			/*this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x0267, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			//this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1a22, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			//this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1a30, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1a93, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1aa7, 39, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1ade, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1ae2, 81, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1b48, 34, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1b6f, 37, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1ba0, 29, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1bc5, 57, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1c31, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1c33, 32, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1c53, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1c66, 52, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1c9a, 39, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1cc1, 47, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1d12, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1d6c, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1d9b, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1d9d, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1d9f, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1da1, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1da3, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1da5, 31, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1dc4, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1dd9, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1ddc, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1df8, 67, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1e3b, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1e3e, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1e48, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1e4b, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1ee4, 47, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1f13, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1f39, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1f44, 30, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1f6f, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1f74, 43, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1f9f, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1fb6, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1fbf, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1fcc, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1fe8, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1ff6, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2018, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2037, 57, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x20ab, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x20b3, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x20b5, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x20b7, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x20b9, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x20bb, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x212c, 40, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2154, 48, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2184, 55, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x21bb, 43, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x21e6, 62, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2224, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x222a, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2242, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2246, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x224d, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x224f, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2251, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2255, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2259, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x225b, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x225f, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2268, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2271, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2290, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x22af, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x22bf, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x22e2, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x22fb, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x22fd, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2300, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x230c, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2327, 41, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2350, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2353, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2366, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2369, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x236c, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x239c, 34, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x23be, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x23c1, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x23d5, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x23eb, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x23f6, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2404, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2408, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x240b, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x241e, 39, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2445, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2455, 36, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2479, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2491, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x24ec, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x24f3, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x24f5, 27, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2534, 43, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x255f, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2577, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x257a, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2583, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2586, 44, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x25b2, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x25b5, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x25be, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x25c1, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x25d4, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x25e7, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2606, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2616, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x265c, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x265f, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x266e, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2680, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2684, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2691, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2693, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x26a3, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x26ad, 26, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x26c7, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x26cd, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x26dc, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x26ef, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2712, 26, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x272c, 32, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x274c, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x275f, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2762, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2770, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2785, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2788, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2796, 27, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x27b1, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x27b4, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x27c4, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x27c7, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x27df, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x27f8, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2809, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2814, 73, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x285e, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2868, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x286b, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2884, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x28af, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x28b9, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x28be, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x28f6, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2906, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2909, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2910, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2913, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2918, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2927, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2934, 36, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2958, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x295c, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2971, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x297b, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x29af, 31, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x29ce, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x29d1, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x29e9, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x29ec, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x29f1, 34, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2a13, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2a19, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2a30, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2a70, 36, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2a94, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2aae, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2abf, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ac9, 27, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ae4, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2aef, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2b02, 40, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2b2a, 34, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2b4c, 43, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2b77, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2b8e, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2b9c, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ba4, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2bd4, 92, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2c30, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2c3e, 107, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ca9, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ce1, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2cf1, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d05, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d17, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d23, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d35, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d41, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d46, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d5e, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d72, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d7f, 27, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2d9a, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2da7, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2db6, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2dc2, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2dd6, 92, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2e32, 43, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2e5d, 72, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ea5, 44, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ed1, 84, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2f25, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2fb4, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2fd2, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2fd4, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2fd6, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2fdc, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2fe5, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2fee, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ff0, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ff3, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ff6, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x2ffd, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x300b, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x300d, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x30c2, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x30d4, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x30e7, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x30f8, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3110, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3123, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3130, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x313f, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3155, 26, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x316f, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3185, 83, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x31d8, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x31ef, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x31f9, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3203, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3219, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3253, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3256, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x326b, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3281, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x32b2, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x32b5, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x32f0, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3337, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3351, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3359, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3362, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x336d, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3379, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x337b, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33ac, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33b5, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33d8, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33dd, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33e0, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33e3, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33ec, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x33fb, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3408, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3446, 30, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3464, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3473, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x34a7, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x34aa, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x34ad, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x34b0, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3526, 85, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x357b, 26, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3595, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35a6, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35bb, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35be, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35c1, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35c9, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35cc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35ce, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35fa, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x35fc, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3618, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x361b, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3632, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3638, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3641, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x364a, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3664, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3677, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3688, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x36d4, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x36e5, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x36ee, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x36f8, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x36fa, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3734, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x373f, 24, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3757, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3768, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3770, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x37d4, 49, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3834, 34, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3856, 52, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x388a, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x388c, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x38aa, 32, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x38ca, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x38e6, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3906, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x391b, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3948, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x395e, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x397a, 34, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x399c, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x39f8, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a0a, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a0f, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a1e, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a2d, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a32, 31, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a53, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a5b, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3a60, 44, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3aca, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3acd, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ad6, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ad8, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ae3, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3af3, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b06, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b11, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b15, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b3e, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b41, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b4b, 1, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b4c, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b53, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b5e, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3b6a, 57, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3c8e, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3cd6, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3cda, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3d42, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3d68, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3d99, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3d9b, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3d9d, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3da7, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3db6, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3dbe, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3dc0, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3dc8, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3dca, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e10, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e1d, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e1f, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e29, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e30, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e3a, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e49, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e53, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e68, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e6f, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e7b, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3e8d, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ea0, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3eb0, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3eb7, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3eb9, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ebc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ebe, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ed0, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ed8, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ee5, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ee8, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3eeb, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3eed, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3efb, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f03, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f0b, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f0d, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f0f, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f12, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f7d, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f8d, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3f91, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3fa2, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x3ffd, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4008, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x401c, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x401f, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4033, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x403d, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x406b, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4076, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4086, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x408d, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4095, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x409a, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x409d, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40b3, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40b8, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40ba, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40bc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40be, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40c0, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40de, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40e0, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40f7, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4107, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x411c, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4126, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4146, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4149, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4152, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4157, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4166, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4174, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4177, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4179, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x417b, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x417d, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4185, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4187, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4189, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x418b, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x418d, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x418f, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4191, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4193, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4195, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4197, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4199, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x419e, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41a0, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41a2, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41a6, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41a8, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41aa, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41ac, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41b0, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41b0, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41d3, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41d7, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41d7, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41d9, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41d9, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41db, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41db, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41de, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41de, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x41f4, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x420a, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4221, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4233, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4233, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x424a, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x424a, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4257, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4257, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4270, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4272, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4272, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4275, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4275, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4277, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x427a, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x427c, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4295, 64, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x42d5, 63, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4314, 61, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4351, 29, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x436e, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4386, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x438a, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4397, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4399, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x439d, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x43a1, 25, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x43ba, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x43be, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x43cb, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x43ce, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x43d0, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4409, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4418, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x441c, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x441e, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x44b6, 29, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x44d3, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x44d9, 29, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x44f6, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x44fd, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4513, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4536, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4555, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x456f, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4589, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x45a2, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x45bf, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x45cc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x45db, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x45ff, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4618, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x461a, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4637, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4652, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x467c, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x467e, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4681, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4684, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4691, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x469e, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46aa, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46bc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46da, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46dc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46de, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46e0, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46e2, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46e9, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46f0, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x46f7, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4701, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4703, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x471e, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4737, 1, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4738, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x473a, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4754, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x475d, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x475f, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4771, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x478e, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4790, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4792, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4794, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4796, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x479e, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x47e2, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x47ef, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x47f1, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x47f4, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x47f7, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x47f9, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4808, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x480a, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4818, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4831, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4833, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4836, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4838, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4845, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4873, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4876, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4879, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x487b, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x487e, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4899, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x48a0, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x48b9, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x48c7, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x48d1, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x491b, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4926, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4934, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4940, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4942, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x494e, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4967, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4971, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4979, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4985, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49b5, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49b7, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49c4, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49cc, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49d7, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49e2, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49fc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x49fe, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a01, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a04, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a06, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a0a, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a0e, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a12, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a16, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4a2a, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4aaf, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4ab6, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4ab8, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4aba, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4abc, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4ac0, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4ac6, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4b11, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4b93, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4ba4, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4bb8, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4cdf, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4cf4, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d14, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d1a, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d24, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d26, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d2f, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d37, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d39, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d41, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d48, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d57, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d59, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d71, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d76, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4d95, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4db1, 52, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4de5, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4e40, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4e4c, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4e58, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4e68, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4e6b, 20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4e7f, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4e94, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4f7a, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4f89, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4ff2, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x503f, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x504d, 27, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5068, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5090, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x509c, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x509e, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50ae, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50b0, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50bd, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50c7, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50c9, 13, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50d6, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50db, 10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50e5, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50e8, 16, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50f8, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x50fa, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5108, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5127, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5133, 5, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5141, 6, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x515c, 9, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5165, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5171, 7, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x519e, 22, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x51b4, 114, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5226, 8, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x522e, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x524b, 12, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5257, 23, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x526e, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5272, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5275, 15, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5284, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5297, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x529a, 28, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x52b6, 21, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x52cb, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x52cd, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x52df, 14, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x52ed, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x52f0, 18, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5302, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5304, 17, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5315, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5352, 3, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x538d, 11, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5398, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x540e, 4, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5412, 27, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x542d, 54, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x5463, 19, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x54b9, 37, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x54de, 43, CPUMemoryFlagsEnum.AccessNotAllowed));*/
			#endregion

			#region Objects
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3604, 0, 0xd00, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x4b0, 0x90, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x540, 0x100, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x640, 0x100, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x740, 0xfa0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x1f88, 0x4b0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x253c, 0x1c0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x26fc, 0x1000, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x19be, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x19c0, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1c20, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x1c26, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x40dc, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4cd4, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4cd6, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x4cd8, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6b66, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6b76, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6b86, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6b8a, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6b96, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6c9c, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6cac, 0x100, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6dec, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6e80, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6e82, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6e94, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x6ea8, 0x2c, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x70ec, 0xe00, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x7f36, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x803c, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x804c, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x8068, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x807a, 0x100, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x81d2, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			//this.oCPU.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x81d4, 0x3000, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb1d6, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb1ea, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb1ee, 0x20, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb210, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb220, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb23a, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb3be, 0x1c0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd2e4, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd2f4, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd2f8, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd308, 0x1c0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd7ee, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd7f4, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd76e, 0x80, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd808, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdb36, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdc6c, 0x80, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdcec, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xddfe, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xde10, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xde22, 0x80, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdeec, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdefc, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdf0e, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdf1e, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe16a, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe3c4, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe3c8, 0x50, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe418, 0x80, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe498, 0x80, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe698, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe898, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe8a8, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			#endregion

			#endregion

			// DOS version
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5903, 0x616);

			// Environment block is not used
			// Argument block in not used
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5922, 0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5920, 0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x591e, 0);

			// Get special devices information
			// Defaults are OK, no need to modify bytes at 0x590a - 0x590e

			this.oCPU.BP.Word = 0x0;

			// Call our 'short Main()' function
			this.Segment_11a8.F0_11a8_0008_Main();

			this.MSCAPI.exit((short)this.oCPU.AX.Word);
		}

		public CPU CPU
		{
			get { return this.oCPU; }
		}

		public GameState GameState
		{
			get { return this.oGameState; }
		}

		#region Logs
		public LogWrapper Log
		{
			get { return this.oLog; }
		}

		public LogWrapper InterruptLog
		{
			get { return this.oInterruptLog; }
		}

		public LogWrapper VGADriverLog
		{
			get { return this.oVGADriverLog; }
		}

		public LogWrapper IntroLog
		{
			get { return this.oIntroLog; }
		}
		#endregion

		#region Public Segment getters
		public Segment_11a8 Segment_11a8
		{
			get { return this.oSegment_11a8; }
		}

		public Segment_1000 Segment_1000
		{
			get { return this.oSegment_1000; }
		}

		public Segment_1238 Segment_1238
		{
			get { return this.oSegment_1238; }
		}

		public Segment_2d05 Segment_2d05
		{
			get { return this.oSegment_2d05; }
		}

		public Segment_1403 Segment_1403
		{
			get { return this.oSegment_1403; }
		}

		public Segment_2dc4 Segment_2dc4
		{
			get { return this.oSegment_2dc4; }
		}

		public Segment_1182 Segment_1182
		{
			get { return this.oSegment_1182; }
		}

		public ImageTools ImageTools
		{
			get { return this.oImageTools; }
		}

		public Segment_2f4d Segment_2f4d
		{
			get { return this.oSegment_2f4d; }
		}

		public Segment_2aea Segment_2aea
		{
			get { return this.oSegment_2aea; }
		}

		public Segment_1866 Segment_1866
		{
			get { return this.oSegment_1866; }
		}

		public Segment_2e31 Segment_2e31
		{
			get { return this.oSegment_2e31; }
		}

		public Segment_2459 Segment_2459
		{
			get { return this.oSegment_2459; }
		}

		public Segment_25fb Segment_25fb
		{
			get { return this.oSegment_25fb; }
		}

		public Segment_1ade Segment_1ade
		{
			get { return this.oSegment_1ade; }
		}

		public Segment_1d12 Segment_1d12
		{
			get { return this.oSegment_1d12; }
		}

		public Segment_29f3 Segment_29f3
		{
			get { return this.oSegment_29f3; }
		}

		public Segment_2517 Segment_2517
		{
			get { return this.oSegment_2517; }
		}

		public Segment_2c84 Segment_2c84
		{
			get { return this.oSegment_2c84; }
		}

		public MainIntro MainIntro
		{
			get { return this.oMainIntro; }
		}

		public MeetWithKing MeetWithKing
		{
			get { return this.oMeetWithKing; }
		}

		public GameInitAndIntro GameInitAndIntro
		{
			get { return this.oGameInitAndIntro; }
		}

		public Help Help
		{
			get { return this.oHelp; }
		}

		public GameLoadAndSave GameLoadAndSave
		{
			get { return this.oGameLoadAndSave; }
		}

		public HallOfFame HallOfFame
		{
			get { return this.oHallOfFame; }
		}

		public StartGameMenu StartGameMenu
		{
			get { return this.oStartGameMenu; }
		}

		public Overlay_23 Overlay_23
		{
			get { return this.oOverlay_23; }
		}

		public Overlay_14 Overlay_14
		{
			get { return this.oOverlay_14; }
		}

		public Civilopedia Civilopedia
		{
			get { return this.oCivilopedia; }
		}

		public Overlay_21 Overlay_21
		{
			get { return this.oOverlay_21; }
		}

		public CityView CityView
		{
			get { return this.oCityView; }
		}

		public Overlay_18 Overlay_18
		{
			get { return this.oOverlay_18; }
		}

		public Overlay_22 Overlay_22
		{
			get { return this.oOverlay_22; }
		}

		public GameReplay GameReplay
		{
			get { return this.oGameReplay; }
		}

		public Overlay_13 Overlay_13
		{
			get { return this.oOverlay_13; }
		}

		public WorldMap WorldMap
		{
			get { return this.oWorldMap; }
		}

		public Overlay_20 Overlay_20
		{
			get { return this.oOverlay_20; }
		}

		public Palace Palace
		{
			get { return this.oPalace; }
		}

		public Overlay_10 Overlay_10
		{
			get { return this.oOverlay_10; }
		}

		public Overlay_15 Overlay_15
		{
			get { return this.oOverlay_15; }
		}

		public MSCAPI MSCAPI
		{
			get { return this.oMSCAPI; }
		}

		public GDriver Graphics
		{
			get { return this.oGraphics; }
		}

		public NSound Sound
		{
			get { return this.oSound; }
		}
		#endregion
	}
}
