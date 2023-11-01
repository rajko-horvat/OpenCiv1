using System;
using System.IO;
using System.Windows.Forms;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class ApplicationExitException : Exception
	{
		public ApplicationExitException() : base() { }

		public ApplicationExitException(string message) : base(message) { }

		public ApplicationExitException(string message, Exception innerException) : base(message, innerException) { }
	}

	public partial class OpenCiv1
	{
		private CPU oCPU;

		#region Segment definitions
		private Segment_11a8 oSegment_11a8;
		private Segment_1000 oSegment_1000;
		private Segment_1199 oSegment_1199;
		private Segment_1238 oSegment_1238;
		private Segment_2d05 oSegment_2d05;
		private Segment_1403 oSegment_1403;
		private Segment_2dc4 oSegment_2dc4;
		private Segment_1182 oSegment_1182;
		private ImageLoading oSegment_2fa1;
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
		private Overlay_2 oOverlay_2;
		private Overlay_6 oOverlay_6;
		private Overlay_7 oOverlay_7;
		private Overlay_4 oOverlay_4;
		private Overlay_11 oOverlay_11;
		private Overlay_3 oOverlay_3;
		private Overlay_5 oOverlay_5;
		private Overlay_23 oOverlay_23;
		private Overlay_14 oOverlay_14;
		private Overlay_8 oOverlay_8;
		private Overlay_21 oOverlay_21;
		private Overlay_19 oOverlay_19;
		private Overlay_18 oOverlay_18;
		private Overlay_22 oOverlay_22;
		private Overlay_9 oOverlay_9;
		private Overlay_13 oOverlay_13;
		private Overlay_12 oOverlay_12;
		private Overlay_20 oOverlay_20;
		private Overlay_17 oOverlay_17;
		private Overlay_10 oOverlay_10;
		private Overlay_15 oOverlay_15;
		private CivQuiz oOverlay_16;
		private MSCAPI oMSCAPI;
		private VGADriver oVGADriver;
		private NSound oSoundDriver;
		#endregion

		private LogWrapper oLog;
		private LogWrapper oInterruptLog;
		private LogWrapper oVGALog;
		private LogWrapper oVGADriverLog;
		private LogWrapper oStringLog;
		private LogWrapper oIntroLog;

		private ushort OverlaySegment = 0;
		private ushort usStartSegment = 0x1000;
		//private MZExecutable oEXE;

		private GameState oGameState;

		public OpenCiv1(MainForm form)
		{
			this.oLog = new LogWrapper("Log.txt");
			this.oInterruptLog = new LogWrapper("InterruptLog.txt");
			this.oVGALog = new LogWrapper("VGALog.txt");
			this.oVGADriverLog = new LogWrapper("VGADriverLog.txt");
			this.oStringLog = new LogWrapper("StringLog.txt");
			this.oIntroLog = new LogWrapper("IntroLog.txt");

			this.oCPU = new CPU(this, this.oLog);

			this.oLog.CPU = this.oCPU;
			this.oInterruptLog.CPU = this.oCPU;
			this.oVGALog.CPU = this.oCPU;
			this.oVGADriverLog.CPU = this.oCPU;
			this.oStringLog.CPU = this.oCPU;
			this.oIntroLog.CPU = this.oCPU;

			this.oGameState = new GameState();

			#region Initialize Segments
			this.oMSCAPI = new MSCAPI(this);
			this.oVGADriver = new VGADriver(this, form);
			this.oSoundDriver = new NSound(this);

			this.oSegment_11a8 = new Segment_11a8(this);
			this.oSegment_1000 = new Segment_1000(this);
			this.oSegment_1199 = new Segment_1199(this);
			this.oSegment_1238 = new Segment_1238(this);
			this.oSegment_2d05 = new Segment_2d05(this);
			this.oSegment_1403 = new Segment_1403(this);
			this.oSegment_2dc4 = new Segment_2dc4(this);
			this.oSegment_1182 = new Segment_1182(this);
			this.oSegment_2fa1 = new ImageLoading(this);
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
			this.oOverlay_2 = new Overlay_2(this);
			this.oOverlay_6 = new Overlay_6(this);
			this.oOverlay_7 = new Overlay_7(this);
			this.oOverlay_4 = new Overlay_4(this);
			this.oOverlay_11 = new Overlay_11(this);
			this.oOverlay_3 = new Overlay_3(this);
			this.oOverlay_5 = new Overlay_5(this);
			this.oOverlay_23 = new Overlay_23(this);
			this.oOverlay_14 = new Overlay_14(this);
			this.oOverlay_8 = new Overlay_8(this);
			this.oOverlay_21 = new Overlay_21(this);
			this.oOverlay_19 = new Overlay_19(this);
			this.oOverlay_18 = new Overlay_18(this);
			this.oOverlay_22 = new Overlay_22(this);
			this.oOverlay_9 = new Overlay_9(this);
			this.oOverlay_13 = new Overlay_13(this);
			this.oOverlay_12 = new Overlay_12(this);
			this.oOverlay_20 = new Overlay_20(this);
			this.oOverlay_17 = new Overlay_17(this);
			this.oOverlay_10 = new Overlay_10(this);
			this.oOverlay_15 = new Overlay_15(this);
			this.oOverlay_16 = new CivQuiz(this);
			#endregion
		}

		public void Start()
		{
			ushort usInitialCS = 0x2045; // oEXE.InitialCS;
			ushort usInitialSS = 0x398d; // oEXE.InitialSS;
			ushort usInitialSP = 0x0800; // oEXE.InitialSP;

			this.oCPU.Memory.AllocateMemoryBlock(0xff00, 0x100, CPUMemoryFlagsEnum.ReadWrite);
			this.oCPU.Memory.WriteUInt16(0xff00, 0x20cd);
			this.oCPU.Memory.WriteUInt16(0xff02, (ushort)(this.oCPU.Memory.FreeMemory.End >> 4));
			this.oCPU.Memory.WriteUInt8(0xff81, (byte)'\r');
			this.oCPU.Memory.MemoryRegions[1].AccessFlags = CPUMemoryFlagsEnum.ReadWrite | CPUMemoryFlagsEnum.WriteWarning | CPUMemoryFlagsEnum.ReadWarning;

			uint uiEXEStart = CPU.ToLinearAddress(usStartSegment, 0);
			uint uiEXELength = 0x3a0e0;

			byte[] resources = (byte[])Properties.Resources.ResourceManager.GetObject("BinaryResources");

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
			this.oCPU.CS.Word = (ushort)(usInitialCS + usStartSegment);
			this.oCPU.SS.Word = (ushort)(usInitialSS + usStartSegment);
			this.oCPU.DS.Word = (ushort)(usStartSegment - 0x10);
			this.oCPU.ES.Word = (ushort)(usStartSegment - 0x10);
			this.oCPU.SP.Word = usInitialSP;

			// Overlay segment, set by F0_3045_2b44
			this.OverlaySegment = 0x3374;
			this.SetOverlayBase();

			this.oCPU.CS.Word = 0x3045; // set this function segment

			ushort usDataSegment = 0x3b01;

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);

			this.oCPU.DS.Word = 0x3b01;

			// Check for Default directory and individual Resource files
			if (!Directory.Exists(this.oCPU.DefaultDirectory))
			{
				MessageBox.Show($"OpenCiv1 resource files path not found at '{this.oCPU.DefaultDirectory}'.\n"+
					"The OpenCiv1 depends on Civilization resource files (*.pic, *.pal and *.txt).\nPlease adjust path to these resources.",
					"Resource path error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				this.oCPU.Exit(-1);
			}

			string[] aResourceFiles = new string[] {
				"adscreen.pic", "arch.pic", "back0a.pic", "back0m.pic", "back1a.pic", "back1m.pic", "back2a.pic", "back2m.pic", 
				"back3a.pic", "birth0.pic", "birth1.pic", "birth2.pic", "birth3.pic", "birth4.pic", "birth5.pic", "birth6.pic", 
				"birth7.pic", "birth8.pic", "castle0.pic", "castle1.pic", "castle2.pic", "castle3.pic", "castle4.pic", "cback.pic", 
				"cbacks1.pic", "cbacks2.pic", "cbacks3.pic", "cbrush0.pic", "cbrush1.pic", "cbrush2.pic", "cbrush3.pic", 
				"cbrush4.pic", "cbrush5.pic", "citypix1.pic", "citypix2.pic", "citypix3.pic", "custom.pic", "diffs.pic", 
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
				string sFilePath = Path.Combine(this.oCPU.DefaultDirectory, aResourceFiles[i]);

				while (!File.Exists(sFilePath))
				{
					DialogResult result = MessageBox.Show($"Missing resource file {sFilePath}. Plsease ensure that the file exists at specified path.\n" +
					   "Some Operating systems are case sensitive, ensure that the file name is in lowercase.",
					   "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

					if (result == DialogResult.Cancel)
					{
						this.oCPU.Exit(-1);
						break;
					}
				}
			}

			// Not important, but just for case it's still needed, to be removed later
			string sPath = Path.Combine(this.oCPU.DefaultDirectory, "CIV.EXE");

			this.oCPU.Memory.WriteUInt8(this.oCPU.DS.Word, 0x61ee, (byte)'C');
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
			this.oCPU.AX.High = 0x4a;
			this.oCPU.INT(0x21);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, 0x5901, this.oCPU.DS.Word);

			this.oCPU.ES.Word = this.oCPU.SS.Word;
			this.oCPU.DS.Word = this.oCPU.SS.Word;

			// Clear the rest of data and stack segment 0x652e - 0xe8c0
			for (int i = 0x652e; i < this.oCPU.SP.Word; i++)
			{
				if (i < 0x70ec && i > 0x70ec + 0xdff)
					this.oCPU.Memory.WriteUInt8(usDataSegment, (ushort)i, 0);
			}

			// protect already mapped data objects
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
			//this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x81d4, 0x3000, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb1d6, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xb1ea, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
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
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xd808, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdb36, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdcec, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xddfe, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xde10, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdeec, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdefc, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdf0e, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xdf1e, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe16a, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe3c4, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe698, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe898, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0xe8a8, 0x10, CPUMemoryFlagsEnum.AccessNotAllowed));

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

		private void SetOverlayBase()
		{
			this.oOverlay_2.Segment = this.OverlaySegment;
			this.oOverlay_6.Segment = this.OverlaySegment;
			this.oOverlay_7.Segment = this.OverlaySegment;
			this.oOverlay_4.Segment = this.OverlaySegment;
			this.oOverlay_11.Segment = this.OverlaySegment;
			this.oOverlay_3.Segment = this.OverlaySegment;
			this.oOverlay_5.Segment = this.OverlaySegment;
			this.oOverlay_23.Segment = this.OverlaySegment;
			this.oOverlay_14.Segment = this.OverlaySegment;
			this.oOverlay_8.Segment = this.OverlaySegment;
			this.oOverlay_21.Segment = this.OverlaySegment;
			this.oOverlay_19.Segment = this.OverlaySegment;
			this.oOverlay_18.Segment = this.OverlaySegment;
			this.oOverlay_22.Segment = this.OverlaySegment;
			this.oOverlay_9.Segment = this.OverlaySegment;
			this.oOverlay_13.Segment = this.OverlaySegment;
			this.oOverlay_12.Segment = this.OverlaySegment;
			this.oOverlay_20.Segment = this.OverlaySegment;
			this.oOverlay_17.Segment = this.OverlaySegment;
			this.oOverlay_10.Segment = this.OverlaySegment;
			this.oOverlay_15.Segment = this.OverlaySegment;
			this.oOverlay_16.Segment = this.OverlaySegment;
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

		public LogWrapper VGALog
		{
			get { return this.oVGALog; }
		}

		public LogWrapper VGADriverLog
		{
			get { return this.oVGADriverLog; }
		}

		public LogWrapper StringLog
		{
			get { return this.oStringLog; }
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

		public Segment_1199 Segment_1199
		{
			get { return this.oSegment_1199; }
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

		public ImageLoading Segment_2fa1
		{
			get { return this.oSegment_2fa1; }
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

		public Overlay_2 Overlay_2
		{
			get { return this.oOverlay_2; }
		}

		public Overlay_6 Overlay_6
		{
			get { return this.oOverlay_6; }
		}

		public Overlay_7 Overlay_7
		{
			get { return this.oOverlay_7; }
		}

		public Overlay_4 Overlay_4
		{
			get { return this.oOverlay_4; }
		}

		public Overlay_11 Overlay_11
		{
			get { return this.oOverlay_11; }
		}

		public Overlay_3 Overlay_3
		{
			get { return this.oOverlay_3; }
		}

		public Overlay_5 Overlay_5
		{
			get { return this.oOverlay_5; }
		}

		public Overlay_23 Overlay_23
		{
			get { return this.oOverlay_23; }
		}

		public Overlay_14 Overlay_14
		{
			get { return this.oOverlay_14; }
		}

		public Overlay_8 Overlay_8
		{
			get { return this.oOverlay_8; }
		}

		public Overlay_21 Overlay_21
		{
			get { return this.oOverlay_21; }
		}

		public Overlay_19 Overlay_19
		{
			get { return this.oOverlay_19; }
		}

		public Overlay_18 Overlay_18
		{
			get { return this.oOverlay_18; }
		}

		public Overlay_22 Overlay_22
		{
			get { return this.oOverlay_22; }
		}

		public Overlay_9 Overlay_9
		{
			get { return this.oOverlay_9; }
		}

		public Overlay_13 Overlay_13
		{
			get { return this.oOverlay_13; }
		}

		public Overlay_12 Overlay_12
		{
			get { return this.oOverlay_12; }
		}

		public Overlay_20 Overlay_20
		{
			get { return this.oOverlay_20; }
		}

		public Overlay_17 Overlay_17
		{
			get { return this.oOverlay_17; }
		}

		public Overlay_10 Overlay_10
		{
			get { return this.oOverlay_10; }
		}

		public Overlay_15 Overlay_15
		{
			get { return this.oOverlay_15; }
		}

		public CivQuiz Overlay_16
		{
			get { return this.oOverlay_16; }
		}

		public MSCAPI MSCAPI
		{
			get { return this.oMSCAPI; }
		}

		public VGADriver VGADriver
		{
			get { return this.oVGADriver; }
		}

		public NSound SoundDriver
		{
			get { return this.oSoundDriver; }
		}
		#endregion
	}
}
