using Disassembler;
using Disassembler.MZ;
using OpenCiv1.Compression;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows;

namespace OpenCiv1
{
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

		public OpenCiv1()
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
			this.oMSCAPI = new MSCAPI(this);
			this.oVGADriver = new VGADriver(this);
			this.oSoundDriver = new NSound(this);
			#endregion

			// Export all bitmaps to file
			/*string[] aFiles = Directory.GetFiles(this.oCPU.DefaultDirectory, "*.pic");
			if (!Directory.Exists("Images"))
				Directory.CreateDirectory("Images");

			for (int i = 0; i < aFiles.Length; i++)
			{
				byte[] palette;
				VGABitmap bitmap1 = VGABitmap.FromFile(aFiles[i], out palette);

				if (bitmap1 != null)
				{
					bitmap1.Bitmap.Save(
						$"Images{Path.DirectorySeparatorChar}{Path.GetFileNameWithoutExtension(aFiles[i])}.png",
						ImageFormat.Png);
				}

				//break;
			}//*/

			// Test compressor and decompressor
			/*RandomMT19937 oRND = new RandomMT19937();
			for (int i = 0; i < 1000; i++)
			{
				byte[] buffer = new byte[0x10000];

				// fill buffer with random data
				for (int j = 0; j < buffer.Length; j++)
				{
					buffer[j] = (byte)(oRND.Next() & 0xff);
				}

				MemoryStream rleInput = new MemoryStream(buffer);
				MemoryStream rleOutput = new MemoryStream();

				LZW.Compress(rleOutput, rleInput, 9, 11);

				MemoryStream rleOutput1 = new MemoryStream();
				rleOutput.Position = 0;

				LZW.Decompress(rleOutput1, rleOutput, 9, rleOutput.ReadByte());

				// compare buffers
				byte[] buffer1 = rleOutput1.ToArray();

				if (buffer.Length != buffer1.Length)
					Console.WriteLine("Data not equal");

				for (int j = 0; j < buffer1.Length; j++)
				{
					if (buffer[j] != buffer1[j])
					{
						Console.WriteLine("Data not equal");
					}
				}
			}//*/
			
			//ExtractStrings();
		}

		public void Start()
		{
			// Load old exe image to memory, not needed anymore
			//oEXE = new MZExecutable($"{this.oCPU.DefaultDirectory}CIV.EXE");
			//oEXE.ApplyRelocations(usStartSegment);

			ushort usInitialCS = 0x2045; // oEXE.InitialCS;
			ushort usInitialSS = 0x398d; // oEXE.InitialSS;
			ushort usInitialSP = 0x0800; // oEXE.InitialSP;

			// We don't need environment variables as they are not used
			// Copy EXE to memory and allocate resources
			/*string sEnvironment = "COMSPEC =C:\\WINDOWS\\SYSTEM32\\COMMAND.COM\0FP_NO_HOST_CHECK=NO\0HOMEDRIVE=C:\0" +
				"NUMBER_OF_PROCESSORS=1\0OS=Windows_NT\0PATH=C:\\DOS\0"+
				"PATHEXT=.COM;.EXE;.BAT;.CMD\0PROCESSOR_ARCHITECTURE=x86\0"+
				"PROCESSOR_IDENTIFIER=x86\0PROCESSOR_LEVEL=6\0PROMPT=$P$G\0"+
				"SYSTEMDRIVE=C:\0SYSTEMROOT=C:\0TEMP=C:\\TEMP\0TMP=C:\\TEMP\0BLASTER=A220 I5 D1 P330 T3\0";
			uint uiEnvirenmentLength = (uint)(((sEnvironment.Length + 2) + 0xf) & 0xfff0);
			uint uiEnvironment = (uint)(0xff00 - uiEnvirenmentLength);

			this.oCPU.Memory.AllocateMemoryBlock(uiEnvironment, uiEnvirenmentLength, CPUMemoryFlagsEnum.ReadWrite);
			this.oCPU.Memory.WriteUInt8(uiEnvironment, (byte)sEnvironment.Length);
			this.oCPU.WriteString(uiEnvironment + 1, sEnvironment, sEnvironment.Length);
			this.oCPU.Memory.MemoryRegions[1].AccessFlags = CPUMemoryFlagsEnum.Read;*/

			this.oCPU.Memory.AllocateMemoryBlock(0xff00, 0x100, CPUMemoryFlagsEnum.ReadWrite);
			this.oCPU.Memory.WriteUInt16(0xff00, 0x20cd);
			this.oCPU.Memory.WriteUInt16(0xff02, (ushort)(this.oCPU.Memory.FreeMemory.End >> 4));
			//this.oCPU.Memory.WriteUInt16(0xff2c, (ushort)(uiEnvironment >> 4));
			this.oCPU.Memory.WriteUInt8(0xff81, (byte)'\r');
			this.oCPU.Memory.MemoryRegions[1].AccessFlags = CPUMemoryFlagsEnum.ReadWrite | CPUMemoryFlagsEnum.WriteWarning | CPUMemoryFlagsEnum.ReadWarning;

			uint uiEXEStart = CPU.ToLinearAddress(usStartSegment, 0);
			uint uiEXELength = 0x3a0e0;
			//this.oCPU.Memory.AllocateMemoryBlock(0x10000,
			//	(uint)((uint)oEXE.Data.Length + ((uint)oEXE.MinimumAllocation << 4)), CPUMemoryFlagsEnum.ReadWrite);
			//this.oCPU.Memory.WriteBlock(0x10000, oEXE.Data, 0, oEXE.Data.Length);

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

			// protect already mapped data
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3604, 0, 0xd00, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x4b0, 0x90, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x540, 0x100, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x640, 0x100, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x740, 0xfa0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x1f88, 0x4b0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x253c, 0x1c0, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3772, 0x26fc, 0x1000, CPUMemoryFlagsEnum.AccessNotAllowed));

			// Create BinaryResources.bin file for code that is not yet translated and needs this data in memory
			/*FileStream writer = new FileStream("BinaryResources.bin", FileMode.Create);
			uint uiStart = CPU.ToLinearAddress(0x35cf, 0);
			uint uiEnd = CPU.ToLinearAddress(0x3b01, 0x652d);
			writer.Write(this.oCPU.Memory.MemoryContent, (int)uiStart, (int)((uiEnd - uiStart) + 1));
			writer.Close();//*/

			// Create UnitDefinition array
			/*StreamWriter writer = new StreamWriter("UnitDefinitions.cs");
			uint uiArrayAddress = CPU.ToLinearAddress(0x3b01, 0x112a);
			writer.WriteLine("{");
			for (int i = 0; i < 28; i++)
			{
				writer.WriteLine($"new UnitDefinition(\"{this.oCPU.ReadString(uiArrayAddress)}\", " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 12)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 14)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 16)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 18)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 20)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 22)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 24)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 26)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 28)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 30)}, " +
					$"{this.oCPU.Memory.ReadInt16(uiArrayAddress + 32)}), ");

				uiArrayAddress += 34;
			}
			writer.WriteLine("};");
			writer.Close();//*/

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

			string sPath = $"{this.oCPU.DefaultDirectory}CIV.EXE";
			this.oCPU.Memory.WriteUInt8(this.oCPU.DS.Word, 0x61ee, (byte)Path.GetPathRoot(this.oCPU.DefaultDirectory)[0]);
			this.oCPU.WriteString(CPU.ToLinearAddress(this.oCPU.DS.Word, 0x6156), sPath, sPath.Length);

			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.ES.Word = this.oCPU.DS.Word;

			// PSP segment, not needed anymore
			//this.oCPU.Memory.WriteUInt16(this.oCPU.DS.Word, 0x5901, this.oCPU.ES.Word); // PSP segment
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
			// PSP segment, not needed anymore
			//this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2, this.oCPU.SI.Word);
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

			// protect already mapped data
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
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x81d2, 2, CPUMemoryFlagsEnum.AccessNotAllowed));
			this.oCPU.Memory.MemoryRegions.Add(new CPUMemoryRegion(0x3b01, 0x81d4, 0x3000, CPUMemoryFlagsEnum.AccessNotAllowed));
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

		private void ExtractStrings()
		{
			// change strcat, strcpy direct address references
			Regex rxStrCat = new Regex(@"^(\s*this\.oParent\.MSCAPI\.strcat)\(0x([0-9a-f]+), 0x([0-9a-f]+)\);\s*$");
			Regex rxStrCpy = new Regex(@"^(\s*this\.oParent\.MSCAPI\.strcpy)\(0x([0-9a-f]+), 0x([0-9a-f]+)\);\s*$");
			string[] files = Directory.GetFiles(@"..\..\..\OpenCiv1-master\Segments", "*.cs");
			List<CivStringMatch> aStrings = new List<CivStringMatch>();

			for (int i = 0; i < files.Length; i++)
			{
				StreamReader reader = new StreamReader(files[i]);
				StreamWriter writer = new StreamWriter(@".\Code\" +
					Path.GetFileName(files[i]));

				while (!reader.EndOfStream)
				{
					string sLine = reader.ReadLine();
					Match match = rxStrCat.Match(sLine);

					if (match.Success)
					{
						ushort usString1Ptr = Convert.ToUInt16(match.Groups[2].Value, 16);
						ushort usString2Ptr = Convert.ToUInt16(match.Groups[3].Value, 16);
						if (usString1Ptr != 0xba06)
						{
							Console.WriteLine($"First strcat parameter 0x{usString1Ptr:x4} is not buffer pointer");
							writer.WriteLine($"{match.Groups[1].Value}(0x{usString1Ptr:x4}, 0x{usString2Ptr:x4});");
						}
						else
						{
							int iPos = -1;

							for (int j = 0; j < aStrings.Count; j++)
							{
								CivStringMatch strMatch = aStrings[j];
								if (strMatch.Start == usString2Ptr)
								{
									iPos = j;
									break;
								}
								if (strMatch.Start > usString2Ptr && strMatch.End <= usString2Ptr)
								{
									throw new Exception("String is a part of another string");
								}
							}
							if (iPos >= 0)
							{
								writer.WriteLine($"{match.Groups[1].Value}(0x{usString1Ptr:x4}, OpenCiv1.String_{aStrings[iPos].Start:x4});");
							}
							else
							{
								CivStringMatch strMatch = new CivStringMatch(this.oCPU, usString2Ptr);
								aStrings.Add(strMatch);
								writer.WriteLine($"{match.Groups[1].Value}(0x{usString1Ptr:x4}, OpenCiv1.String_{strMatch.Start:x4});");
							}
						}
					}
					else
					{
						match = rxStrCpy.Match(sLine);
						if (match.Success)
						{
							ushort usString1Ptr = Convert.ToUInt16(match.Groups[2].Value, 16);
							ushort usString2Ptr = Convert.ToUInt16(match.Groups[3].Value, 16);
							if (usString1Ptr != 0xba06)
							{
								Console.WriteLine($"First strcpy parameter 0x{usString1Ptr:x4} is not buffer pointer");
								writer.WriteLine($"{match.Groups[1].Value}(0x{usString1Ptr:x4}, 0x{usString2Ptr:x4});");
							}
							else
							{
								int iPos = -1;

								for (int j = 0; j < aStrings.Count; j++)
								{
									CivStringMatch strMatch = aStrings[j];
									if (strMatch.Start == usString2Ptr)
									{
										iPos = j;
										break;
									}
									if (strMatch.Start > usString2Ptr && strMatch.End <= usString2Ptr)
									{
										throw new Exception("String is a part of another string");
									}
								}
								if (iPos >= 0)
								{
									writer.WriteLine($"{match.Groups[1].Value}(0x{usString1Ptr:x4}, OpenCiv1.String_{aStrings[iPos].Start:x4});");
								}
								else
								{
									CivStringMatch strMatch = new CivStringMatch(this.oCPU, usString2Ptr);
									aStrings.Add(strMatch);
									writer.WriteLine($"{match.Groups[1].Value}(0x{usString1Ptr:x4}, OpenCiv1.String_{strMatch.Start:x4});");
								}
							}
						}
						else
						{
							writer.WriteLine(sLine);
						}
					}
				}

				writer.Close();
				reader.Close();
			}

			aStrings.Sort();

			StreamWriter stringWriter = new StreamWriter(@".\Code\Strings.cs");
			StreamWriter tableWriter = new StreamWriter(@".\Code\Table.txt");

			for (int i = 0; i < aStrings.Count; i++)
			{
				CivStringMatch strMatch = aStrings[i];

				stringWriter.WriteLine("/// <summary>");
				stringWriter.WriteLine($"/// \"{strMatch.FormatttedString}\"");
				stringWriter.WriteLine("/// </summary>");
				stringWriter.WriteLine($"public static string String_{strMatch.Start:x4} = \"{strMatch.FormatttedString}\";");

				tableWriter.WriteLine($"0x3b01\t0x{strMatch.Start:x4}\t0x{strMatch.End:x4}\t\"{strMatch.FormatttedString}\"");
			}
			tableWriter.Close();
			stringWriter.Close();
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
