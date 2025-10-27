using IRB.Collections.Generic;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace OpenCiv1
{
	public partial class OpenCiv1Game
	{
		public static readonly GPoint InvalidPosition = new GPoint(-1);

		private static bool enableLog = false;

		private VCPU oCPU;

		#region Segment definitions
		private Segment_11a8 oSegment_11a8;
		private CommonTools oCommonTools;
		private Segment_1238 oSegment_1238;
		private MenuBoxDialog oMenuBoxDialog;
		private Segment_1403 oSegment_1403;
		private Segment_2dc4 oSegment_2dc4;
		private DrawStringTools oDrawStringTools;
		private ImageTools oImageTools;
		private LanguageTools oLanguageTools;
		private MapManagement oMapManagement;
		private Segment_1866 oSegment_1866;
		private Segment_2459 oSegment_2459;
		private Segment_25fb oSegment_25fb;
		private Segment_1ade oSegment_1ade;
		private CityWorker oCityWorker;
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
		private Schizm oSchizm;
		private MSCAPI oMSCAPI;
		private GDriver oGraphics;
		private NSound oSound;
		#endregion

		private LogWrapper oLog;
		private LogWrapper oInterruptLog;
		private LogWrapper oGoToLog;

		private ushort usStartSegment = 0x1000;

		private GameData oGameData;

		public OpenCiv1Game()
		{
			this.oLog = new LogWrapper($"{VCPU.AssemblyPath}Log.txt", enableLog);
			this.oInterruptLog = new LogWrapper($"{VCPU.AssemblyPath}InterruptLog.txt", enableLog);
			this.oGoToLog = new LogWrapper($"{VCPU.AssemblyPath}GoToLog.txt", enableLog);

			this.oCPU = new VCPU(this, this.oLog);

			this.oLog.CPU = this.oCPU;
			this.oInterruptLog.CPU = this.oCPU;
			this.oGoToLog.CPU = this.oCPU;

			this.oGameData = new GameData(this);

			#region Initialize Segments
			this.oMSCAPI = new MSCAPI(this);
			this.oGraphics = new GDriver(this);
			this.oSound = new NSound(this);

			this.oSegment_11a8 = new Segment_11a8(this);
			this.oCommonTools = new CommonTools(this);
			this.oSegment_1238 = new Segment_1238(this);
			this.oMenuBoxDialog = new MenuBoxDialog(this);
			this.oSegment_1403 = new Segment_1403(this);
			this.oSegment_2dc4 = new Segment_2dc4(this);
			this.oDrawStringTools = new DrawStringTools(this);
			this.oImageTools = new ImageTools(this);
			this.oLanguageTools = new LanguageTools(this);
			this.oMapManagement = new MapManagement(this);
			this.oSegment_1866 = new Segment_1866(this);
			this.oSegment_2459 = new Segment_2459(this);
			this.oSegment_25fb = new Segment_25fb(this);
			this.oSegment_1ade = new Segment_1ade(this);
			this.oCityWorker = new CityWorker(this);
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
			this.oSchizm = new Schizm(this);
			#endregion

			/*string[] aFiles = Directory.GetFiles(this.oCPU.DefaultCIVPath, "*.pic");

			for (int i = 0; i < aFiles.Length; i++)
			{
				byte[] palette;
				VGABitmap bitmap = VGABitmap.FromPICFile(aFiles[i], out palette);

				bitmap.Bitmap.SaveToPIC(Path.GetFileNameWithoutExtension(aFiles[i]) + ".bmp", ImageFormat.Bmp);
			}//*/

			/*LanguagePack pack = new LanguagePack("en-en");

			// Parse Text resource files
			ParseSectionFile(pack, "BLURB0.TXT", "ENCYCLOPEDIA");
			ParseSectionFile(pack, "BLURB1.TXT", "ENCYCLOPEDIA");
			ParseSectionFile(pack, "BLURB2.TXT", "ENCYCLOPEDIA");
			ParseSectionFile(pack, "BLURB4.TXT", "ENCYCLOPEDIA");
			ParseSectionFile(pack, "ERROR.TXT", "ERROR");
			ParseSectionFile(pack, "HELP.TXT", "HELP");
			ParseSectionFile(pack, "KING.TXT", "KING");
			ParseSectionFile(pack, "PRODUCE.TXT", "PRODUCE");
			ParseTextFile(pack, "CREDITS.TXT", "GENERAL_CREDITS");
			ParseTextFile(pack, "STORY.TXT", "GENERAL_STORY");

			StreamWriter writer = new StreamWriter(new FileStream("en-en.xml", FileMode.Create, FileAccess.Write, FileShare.Read));

			XmlSerializer ser = new XmlSerializer(typeof(LanguagePack));
			ser.Serialize(writer, pack);

			writer.Flush();
			writer.Close();*/
		}

		public void ParseTextFile(LanguagePack pack, string filename, string section)
		{
			using (StreamReader textReader = new StreamReader(VCPU.DefaultCIVPath + filename, Encoding.ASCII))
			{
				List<string> contentItems = new List<string>();
				string? line;

				while (!textReader.EndOfStream)
				{
					line = textReader.ReadLine();

					if (!string.IsNullOrEmpty(line))
					{
						line = line.Trim().Replace("  ", " ");

						if (!string.IsNullOrEmpty(line) && !line.StartsWith('\x1a'))
						{
							contentItems.Add(line);
						}
					}
				}

				pack.Items.Add(section, contentItems);
			}
		}

		public void ParseSectionFile(LanguagePack pack, string filename, string section)
		{
			FileStream inputStream;
			StreamReader textReader;
			Regex rxKey = new Regex(@"^\s*\*([A-Z0-9' \.]+)\s*$");
			Match match;
			string? line;

			inputStream = new FileStream(VCPU.DefaultCIVPath + filename, FileMode.Open);
			inputStream.Seek(0x212, SeekOrigin.Begin);
			textReader = new StreamReader(inputStream, Encoding.ASCII);

			line = textReader.ReadLine();

			while (!textReader.EndOfStream)
			{
				List<string> contentItems = new List<string>();
				StringBuilder contentBuilder = new StringBuilder();
				List<string> keys = new List<string>();

				if (line != null && (match = rxKey.Match(line)).Success)
				{
					if (match.Groups[1].Value.Equals("END", StringComparison.CurrentCultureIgnoreCase))
						break;

					while (line != null && (match = rxKey.Match(line)).Success)
					{
						keys.Add(match.Groups[1].Value.Replace(' ', '_').Replace("'", "").Replace(".", "").ToUpper());

						line = textReader.ReadLine();
					}

					while (line != null && !(match = rxKey.Match(line)).Success)
					{
						line = line.Trim();

						if (line.Length > 0)
						{
							if (line.StartsWith('_') || line.StartsWith('-'))
							{
								contentItems.Add(contentBuilder.ToString().TrimEnd(' ', '^').Replace("  ", " "));
								contentBuilder.Clear();
							}

							if (line.EndsWith('^'))
							{
								contentBuilder.Append(line.TrimEnd(' ', '^'));
								contentBuilder.Append("^");
							}
							else
							{
								contentBuilder.Append(line);
								contentBuilder.Append(" ");
							}
						}

						line = textReader.ReadLine();
					}

					if (contentBuilder.Length > 0)
					{
						contentItems.Add(contentBuilder.ToString().TrimEnd(' ', '^').Replace("  ", " "));
					}

					for (int i = 0; i < keys.Count; i++)
					{
						pack.Items.Add($"{section}_{keys[i]}", contentItems);
					}
				}
				else
				{
					line = textReader.ReadLine();
				}
			}

			textReader.Close();
		}

		public void Start()
		{
			#region Check Resources
			// Check for Default directory and individual Resource files
			if (!string.IsNullOrEmpty(VCPU.DefaultCIVPath) && !Directory.Exists(VCPU.DefaultCIVPath))
			{
				throw new ResourceMissingException($"Resource path not found at '{VCPU.DefaultCIVPath}'.");
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
				string sFilePath = $"{VCPU.DefaultCIVPath}{aResourceFiles[i].ToUpper()}";

				if (!File.Exists(sFilePath))
				{
					throw new ResourceMissingException($"Missing resource file {sFilePath}. Please ensure that the file exists at specified path.");
				}
			}
			#endregion

			//ushort usInitialCS = 0x2045; // oEXE.InitialCS;
			ushort usInitialSS = 0x398d; // oEXE.InitialSS;
			ushort usInitialSP = 0x0800; // oEXE.InitialSP;

			this.oCPU.Memory.AllocateMemoryBlock(0xff00, 0x100, VCPUMemoryFlagsEnum.ReadWrite);
			this.oCPU.Memory.WriteUInt16(0xff00, 0x20cd);
			this.oCPU.Memory.WriteUInt16(0xff02, (ushort)(this.oCPU.Memory.FreeMemory.End >> 4));
			this.oCPU.Memory.WriteUInt8(0xff81, (byte)'\r');
			this.oCPU.Memory.MemoryRegions[1].AccessFlags = VCPUMemoryFlagsEnum.ReadWrite | VCPUMemoryFlagsEnum.WriteWarning | VCPUMemoryFlagsEnum.ReadWarning;

			uint uiEXEStart = VCPU.ToLinearAddress(usStartSegment, 0);
			uint uiEXELength = 0x3a0e0;

			byte[] resources = CommonResources.BinaryResources;

			this.oCPU.Memory.AllocateMemoryBlock(uiEXEStart, uiEXELength, VCPUMemoryFlagsEnum.ReadWrite);
			this.oCPU.Memory.WriteBlock(VCPU.ToLinearAddress(0x35cf, 0), resources, 0, resources.Length);
			this.oCPU.Memory.MemoryRegions[2].AccessFlags |= VCPUMemoryFlagsEnum.WriteWarning;

			// Define data and stack region
			uint uiDataStart = uiEXEStart + VCPU.ToLinearAddress(0x25cf, 0);
			uint uiDataEnd = uiEXEStart + VCPU.ToLinearAddress(0x2b01, 0xf0c0);

			this.oCPU.Memory.MemoryRegions[2].End = uiDataStart - 1;
			this.oCPU.Memory.MemoryRegions.Add(
				new VCPUMemoryRegion(uiDataStart, (uiDataEnd - uiDataStart) + 1, VCPUMemoryFlagsEnum.ReadWrite));

			// Initialize CPU
			//this.oCPU.CS.Word = (ushort)(usInitialCS + usStartSegment);
			this.oCPU.SS.UInt16 = (ushort)(usInitialSS + usStartSegment);
			this.oCPU.DS.UInt16 = (ushort)(usStartSegment - 0x10);
			this.oCPU.ES.UInt16 = (ushort)(usStartSegment - 0x10);
			this.oCPU.SP.UInt16 = usInitialSP;

			ushort usDataSegment = 0x3b01;

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.DS.UInt16);

			this.oCPU.DS.UInt16 = 0x3b01;

			// Not important, but just for case it's still needed, to be removed later
			string sPath = $"{VCPU.DefaultCIVPath}CIV.EXE";

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0x61ee, (byte)'C');
			this.oCPU.WriteString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0x6156), sPath);

			this.oCPU.DS.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.ES.UInt16 = this.oCPU.DS.UInt16;

			this.oCPU.SI.UInt16 = (ushort)(this.oCPU.Memory.FreeMemory.End >> 4); // top of memory
			this.oCPU.SI.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SI.UInt16, usDataSegment);

			// Init SS:SP
			this.oCPU.CLI();
			this.oCPU.SS.UInt16 = usDataSegment;
			this.oCPU.SP.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SP.UInt16, 0xe8c0);
			this.oCPU.STI();

			// Align SP
			this.oCPU.SP.UInt16 = this.oCPU.ANDUInt16(this.oCPU.SP.UInt16, 0xfffe);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, 0x5890, this.oCPU.SP.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, 0x588c, this.oCPU.SP.UInt16);

			this.oCPU.AX.UInt16 = this.oCPU.SI.UInt16;
			this.oCPU.AX.UInt16 = this.oCPU.SHLUInt16(this.oCPU.AX.UInt16, 4);
			this.oCPU.AX.UInt16 = this.oCPU.DECUInt16(this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, 0x588a, this.oCPU.AX.UInt16);

			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, usDataSegment);
			this.oCPU.BX.UInt16 = this.oCPU.ES.UInt16;
			this.oCPU.BX.UInt16 = this.oCPU.SUBUInt16(this.oCPU.BX.UInt16, this.oCPU.SI.UInt16);
			this.oCPU.BX.UInt16 = this.oCPU.NEGUInt16(this.oCPU.BX.UInt16);
			if (this.oCPU.Memory.ResizeMemoryBlock(this.oCPU.ES.UInt16, this.oCPU.BX.UInt16))
			{
				this.oCPU.Flags.C = false;
				this.oCPU.AX.UInt16 = 0;
			}
			else
			{
				this.oCPU.Flags.C = true;
				this.oCPU.AX.UInt16 = 8;
				this.oCPU.BX.UInt16 = 0;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, 0x5901, this.oCPU.DS.UInt16);

			this.oCPU.ES.UInt16 = this.oCPU.SS.UInt16;
			this.oCPU.DS.UInt16 = this.oCPU.SS.UInt16;

			// Clear the rest of data and stack segment 0x652e - 0xe8c0
			for (int i = 0x652e; i < this.oCPU.SP.UInt16; i++)
			{
				if (i < 0x70ec && i > 0x70ec + 0xdff)
					this.oCPU.WriteUInt8(usDataSegment, (ushort)i, 0);
			}

			#region Protect already mapped data objects

			#region Objects
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3604, 0, 0xd00, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x0, 0x4b0, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x4b0, 0x90, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x540, 0x100, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x640, 0x100, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x740, 0xfa0, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x16e0, 0x5a0, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x1f88, 0x4b0, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x253c, 0x1c0, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3772, 0x26fc, 0x1000, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x42, 0x1e, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x60, 0xc, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x98, 20, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x282, 456, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x44a, 144, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x4da, 1584, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb9a, 1380, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x10fe, 44, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x112a, 952, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x14e2, 928, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x1882, 96, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x18e4, 96, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x19be, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x19c0, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x19c2, 20, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x19d6, 20, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x19ea, 20, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x1c20, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x1c26, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x2494, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x2496, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x40dc, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x4cd4, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x4cd6, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x4cd8, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6b64, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6b92, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6b66, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6b76, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6b86, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6b8a, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6b96, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6c9c, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6cac, 0x100, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6dec, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6e80, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6e82, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6e94, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x6ea8, 0x2c, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x70ec, 0xe00, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x7f36, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x803c, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x804c, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x8068, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x8078, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x807a, 0x100, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x81d2, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0x81d4, 0x3000, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb1d6, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb1ea, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb1ee, 0x20, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb210, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb220, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb222, 0x18, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb23a, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb278, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb2ba, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xb3be, 0x1c0, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd2de, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd2e4, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd2f4, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd2f8, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd308, 0x1c0, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd4ce, 0x280, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd762, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd76e, 0x80, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd7ee, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd7f4, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd808, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xd91a, 0x1c, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdb36, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdb44, 0x104, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdc6c, 0x80, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdcec, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdcfe, 0x100, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xddfe, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xde10, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xde22, 0x80, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdeb6, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdeb8, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdeec, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdefc, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdf0e, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xdf1e, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe16a, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe3c2, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe3c4, 2, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe3c8, 0x50, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe418, 0x80, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe498, 0x80, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe698, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe898, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new VCPUMemoryRegion(0x3b01, 0xe8a8, 0x10, VCPUMemoryFlagsEnum.AccessNotAllowed));
			#endregion

			#endregion

			// DOS version
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x5903, 0x616);

			// Environment block is not used
			// Argument block is not used
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x5922, 0);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x5920, 0);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x591e, 0);

			// Get special devices information
			// Defaults are OK, no need to modify bytes at 0x590a - 0x590e

			this.oCPU.BP.UInt16 = 0x0;

			/*this.oCPU.ES.Word = 0x3b01; // segment
			StreamWriter writer = new StreamWriter("Data.cs");
			writer.Write("{");
			for (int i = 0; i < 12; i++)
			{
				if (i > 0)
					writer.WriteLine(", ");

				ushort dataPtr = (ushort)(0x44a + (i * 12));

				writer.Write($"new TerrainMulti(" +
					$"{i}, " +
					$"{this.oCPU.ReadInt8(this.oCPU.ES.Word, (ushort)(dataPtr + 0))}, " +
					$"{this.oCPU.ReadInt8(this.oCPU.ES.Word, (ushort)(dataPtr + 2))}, " +
					$"{this.oCPU.ReadInt8(this.oCPU.ES.Word, (ushort)(dataPtr + 4))}, " +
					$"{this.oCPU.ReadInt8(this.oCPU.ES.Word, (ushort)(dataPtr + 6))}, " +
					$"{this.oCPU.ReadInt8(this.oCPU.ES.Word, (ushort)(dataPtr + 8))}, " +
					$"{this.oCPU.ReadInt8(this.oCPU.ES.Word, (ushort)(dataPtr + 10))}" +
					$")");
			}
			writer.Write("}");
			writer.Close();
			this.oCPU.ES.Word = this.oCPU.SS.Word;//*/

			/*StreamWriter writer = new StreamWriter("Data.cs");
			writer.Write("{");
			for (int i = 0; i < 8; i++)
			{
				if (i > 0)
					writer.Write(", ");

				writer.Write(this.oCPU.ReadInt16(0x3b01, (ushort)(0x1946 + i * 2)));
			}
			writer.Write("}");
			writer.Close();
			this.oCPU.ES.Word = this.oCPU.SS.Word;//*/

			// Call our 'short Main()' function
			this.Segment_11a8.F0_11a8_0008_Main();

			this.MSCAPI.exit((short)this.oCPU.AX.UInt16);
		}

		public static void LogUnit(OpenCiv1Game game, LogWrapper log, int playerID, int unitID, int humanPlayerID)
		{
			if (playerID >= game.GameData.Players.Length || unitID >= game.GameData.Players[playerID].Units.Length)
			{
				log.WriteLine($"// Illegal indexes, PlayerID: {playerID}{((playerID == humanPlayerID) ? " (Human player)" : "")}, UnitID: {unitID}");
			}
			else
			{
				Unit unit = game.GameData.Players[playerID].Units[unitID];

				log.WriteLine($"// Player[{playerID}{((playerID == humanPlayerID) ? " (Human player)" : "")}].Unit[{unitID}] = {{TypeID: {unit.TypeID}, Status: {unit.Status}, Position: {unit.Position}, GoTo: {unit.GoToDestination}}}");
			}
		}

		public VCPU CPU
		{
			get { return this.oCPU; }
		}

		public GameData GameData
		{
			get { return this.oGameData; }
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

		public LogWrapper GoToLog
		{
			get { return this.oGoToLog; }
		}
		#endregion

		#region Public Segment getters
		public Segment_11a8 Segment_11a8
		{
			get { return this.oSegment_11a8; }
		}

		public CommonTools CommonTools
		{
			get { return this.oCommonTools; }
		}

		public Segment_1238 Segment_1238
		{
			get { return this.oSegment_1238; }
		}

		public MenuBoxDialog MenuBoxDialog
		{
			get { return this.oMenuBoxDialog; }
		}

		public Segment_1403 Segment_1403
		{
			get { return this.oSegment_1403; }
		}

		public Segment_2dc4 Segment_2dc4
		{
			get { return this.oSegment_2dc4; }
		}

		public DrawStringTools DrawStringTools
		{
			get { return this.oDrawStringTools; }
		}

		public ImageTools ImageTools
		{
			get { return this.oImageTools; }
		}

		public LanguageTools LanguageTools
		{
			get { return this.oLanguageTools; }
		}

		public MapManagement MapManagement
		{
			get { return this.oMapManagement; }
		}

		public Segment_1866 Segment_1866
		{
			get { return this.oSegment_1866; }
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

		public CityWorker CityWorker
		{
			get { return this.oCityWorker; }
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

		public Schizm Schizm
		{
			get { return this.oSchizm; }
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
