using Avalonia.Media;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class Segment_11a8
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Segment_11a8(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// Main game entry
		/// </summary>
		public void F0_11a8_0008_Main()
		{
			this.oCPU.Log.EnterBlock("F0_11a8_0008_Main()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xa);

			// Main menu selection
			// '1' - No sound 0x4e ('N'), '4' - Sound blaster 0x41 ('A'), '5' - Roland MIDI board 0x52 ('R'); first letter of driver
			this.oParent.Var_1a30_SoundDriverType = 'N';
			// '1' - Mouse and Keyboard 0x1, '2' - Keyboard only 0x0
			this.oParent.Var_1a3c_MouseAvailable = true;

			this.oParent.MainIntro.F2_0000_0000();

			this.oCPU.PUSH_UInt16(0); // stack management - push return segment, ignored
			this.oCPU.PUSH_UInt16(0x0055); // stack management - push return offset
			// Instruction address 0x11a8:0x0050, size: 5
			this.oParent.Graphics.F0_VGA_0492_GetFreeMemory();
			this.oCPU.POP_UInt32(); // stack management - pop return offset and segment
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6dfc), 0x0);
			if (this.oCPU.Flags.E) goto L0064;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L0064:
			this.oCPU.AX.Word = 0x1f40;

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.LE) goto L00ee;

			// Instruction address 0x11a8:0x008c, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 12);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x11a8:0x00b1, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 10));

			// Instruction address 0x11a8:0x00c1, size: 5
			this.oParent.Array_30b8[3] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x11a8:0x00d2, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x270);

			// Instruction address 0x11a8:0x00e6, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 64, 49, 1);

		L00ee:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x23be);
			if (this.oCPU.Flags.GE) goto L0102;

			this.oParent.Var_1a3e = 1;

		L0102:
			// Instruction address 0x11a8:0x010b, size: 5
			this.oParent.Var_6e92 = this.oParent.ImageTools.F0_2fa1_044c_LoadIcon(0x277);

			if (!this.oParent.Var_1a3c_MouseAvailable) goto L012a;

			// Instruction address 0x11a8:0x0122, size: 5
			this.oParent.Var_1a3c_MouseAvailable = this.oParent.Segment_1000.F0_1000_163e_InitMouse() != 0;

		L012a:
			if (!this.oParent.Var_1a3c_MouseAvailable) goto L0145;

			// Instruction address 0x11a8:0x0139, size: 5
			this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oParent.Var_6e92);
			
		L0145:
			// Game type, load, etc. menu
			// And then after menu Intro
			// Instruction address 0x11a8:0x0146, size: 3
			F0_11a8_0486_LogoAndMainGameMenu();

			// Start Game menu, level, tribe, name
			// Instruction address 0x11a8:0x014a, size: 3
			F0_11a8_087c_NewGameMenu();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x1);
			if (this.oCPU.Flags.NE) goto L016f;

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].XStart;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x7);
			this.oParent.Var_d4cc_XPos = (short)this.oCPU.AX.Word;

			this.oParent.Var_d75e_YPos = 19;

			// Instruction address 0x11a8:0x016a, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

		L016f:
			this.oParent.Var_dc48 = 0;

		L0175:
			// Instruction address 0x11a8:0x0175, size: 5
			this.oParent.Segment_1238.F0_1238_0092();

			if (this.oParent.Var_dc48 == 0) goto L0175;

			if (!this.oParent.Var_1a3c_MouseAvailable) goto L018d;

			// Instruction address 0x11a8:0x0188, size: 5
			this.oParent.Segment_1000.F0_1000_1687();

		L018d:
			// Instruction address 0x11a8:0x0191, size: 3
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0, 0);

			// Instruction address 0x11a8:0x0197, size: 5
			this.oParent.Segment_1000.F0_1000_0a39_CloseSound();

			// Instruction address 0x11a8:0x019c, size: 5
			this.oParent.Segment_1000.F0_1000_0051_StopTimer();
			
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_11a8_0008");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0223()
		{
			// function body
			if (this.oParent.Var_1a3c_MouseAvailable)
			{
				// Instruction address 0x11a8:0x022a, size: 5
				this.oParent.Segment_1000.F0_1000_16d4();

				this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5872));
				this.oParent.Var_db3a = (short)this.oCPU.AX.Word;
				this.oParent.Var_db3c = this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x586e);
				this.oParent.Var_db3e = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870);
			}
			else
			{
				this.oParent.Var_db3e = 0;
				this.oParent.Var_db3c = 0;
				this.oParent.Var_db3a = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0486_LogoAndMainGameMenu()
		{
			this.oCPU.Log.EnterBlock("F0_11a8_0486_LogoAndMainGameMenu()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);

			this.oParent.Var_d76a_IsEarthMap = false;
			goto L04bb;

		L0494:
			// Instruction address 0x11a8:0x049c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, " Start a New Game\n Load a Saved Game\n EARTH\n Customize World\n View Hall of Fame\n");

			// Instruction address 0x11a8:0x04b0, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 100, 140, 1);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, this.oCPU.AX.Word);

		L04bb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0xffff);
			if (this.oCPU.Flags.E) goto L0494;

		L04c2:
			// Instruction address 0x11a8:0x04c2, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1495);
			if (this.oCPU.Flags.LE) goto L04dc;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x1495);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x120;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.OR_UInt16(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L04c2;

		L04dc:
			// Instruction address 0x11a8:0x04e1, size: 3
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0511;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L04f6;
			goto L07bd;

		L04f6:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L04fe;
			goto L0795;

		L04fe:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L0506;
			goto L0591;

		L0506:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.NE) goto L050e;
			goto L07ee;

		L050e:
			goto L0810;

		L0511:
			this.oParent.Var_7ef6_MapLandMass = 1;
			this.oParent.Var_7ef8_MapTemperature = 1;
			this.oParent.Var_7efa_MapClimate = 1;
			this.oParent.Var_7efc_MapAge = 1;

		L052e:
			// Intro...
			this.oCPU.Log.EnterBlock("// Intro start");

			this.oParent.GameInitAndIntro.Var_67fc = 0;
			this.oParent.GameInitAndIntro.F7_0000_17cf_AdvanceEvolutionAnimation();

			//this.oParent.GameInitAndIntro.F7_0000_0012_GenerateMap(false);
			this.oGameData.Map = new TerrainMap(this.oParent, 80, 50);

			this.oParent.GameInitAndIntro.Var_67fc = 1;
			while (this.oParent.GameInitAndIntro.F7_0000_17cf_AdvanceEvolutionAnimation() != 0) ;

			// intialize Player.Continents array
			int iGroupLength = this.oGameData.Map.Groups.Count;
			for (int i = 0; i < this.oGameData.Players.Length; i++)
			{
				Player player = this.oGameData.Players[i];
				player.Continents = new PlayerContinent[iGroupLength];

				for (int j = 0; j < iGroupLength; j++)
				{
					player.Continents[j] = new PlayerContinent();
				}
			}

			this.oCPU.Log.ExitBlock("// Intro end");

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x11a8:0x053e, size: 5
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(0);

			// Instruction address 0x11a8:0x054e, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1b33, 0);

		L0549:
			// Instruction address 0x11a8:0x0576, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 160, 50, 160, 150, this.oParent.Var_19e8_Rectangle, 160, 50);

			goto L0810;

		L0591:
			// Instruction address 0x11a8:0x05b6, size: 5
			this.oParent.Segment_1000.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

			// Instruction address 0x11a8:0x05d1, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x11a8:0x05e1, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1b3d, 1);

			// Instruction address 0x11a8:0x0611, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oParent.Var_2f9a = 1;

		L0623:
			// Instruction address 0x11a8:0x062b, size: 5
			this.oParent.Segment_1000.F0_1000_16ae(210, 11);

			// Instruction address 0x11a8:0x063b, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "LAND MASS:\n Small\n Normal\n Large\n");

			// Instruction address 0x11a8:0x064f, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 200, 1, 1);

			this.oParent.Var_7ef6_MapLandMass = (short)this.oCPU.AX.Word;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0623;
			
			if (this.oParent.Var_2f9c == 0) goto L067a;

			this.oParent.Help.F4_0000_0000(0x1b6a);

			this.oParent.Var_2f9a = this.oParent.Var_7ef6_MapLandMass;

			goto L0623;

		L067a:
			this.oParent.Var_2f9a = 1;

		L0680:
			// Instruction address 0x11a8:0x0688, size: 5
			this.oParent.Segment_1000.F0_1000_16ae(210, 61);

			// Instruction address 0x11a8:0x0698, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "TEMPERATURE:\n Cool\n Temperate\n Warm\n");

			// Instruction address 0x11a8:0x06ac, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 200, 51, 1);

			this.oParent.Var_7ef8_MapTemperature = (short)this.oCPU.AX.Word;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0680;

			if (this.oParent.Var_2f9c == 0) goto L06d7;

			this.oParent.Help.F4_0000_0000(0x1b94);

			this.oParent.Var_2f9a = this.oParent.Var_7ef8_MapTemperature;

			goto L0680;

		L06d7:
			this.oParent.Var_2f9a = 1;

		L06dd:
			// Instruction address 0x11a8:0x06e5, size: 5
			this.oParent.Segment_1000.F0_1000_16ae(210, 111);

			// Instruction address 0x11a8:0x06f5, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "CLIMATE:\n Arid\n Normal\n Wet\n");

			// Instruction address 0x11a8:0x0709, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 200, 101, 1);

			this.oParent.Var_7efa_MapClimate = (short)this.oCPU.AX.Word;

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L06dd;

			if (this.oParent.Var_2f9c == 0) goto L0734;

			this.oParent.Help.F4_0000_0000(0x1bbd);
			
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_7efa_MapClimate);

		L072f:
			this.oParent.Var_2f9a = (short)this.oCPU.AX.Word;
			goto L06dd;

		L0734:
			this.oParent.Var_2f9a = 1;

		L073a:
			// Instruction address 0x11a8:0x0742, size: 5
			this.oParent.Segment_1000.F0_1000_16ae(210, 161);

			// Instruction address 0x11a8:0x0752, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "AGE:\n 3 billion years\n 4 billion years\n 5 billion years\n");

			// Instruction address 0x11a8:0x0766, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 200, 151, 1);

			this.oParent.Var_7efc_MapAge = (short)this.oCPU.AX.Word;

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L073a;

			if (this.oParent.Var_2f9c == 0) goto L052e;

			this.oParent.Help.F4_0000_0000(0x1bfe);
			
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_7efc_MapAge);
			goto L072f;

		L0795:
			this.oParent.Var_d76a_IsEarthMap = true;

			this.oParent.GameInitAndIntro.Var_67fc = 0;
			this.oParent.GameInitAndIntro.F7_0000_17cf_AdvanceEvolutionAnimation();

			//this.oParent.GameInitAndIntro.F7_0000_0012_GenerateMap(true);
			byte[] palette;
			GBitmap? tempBitmap = GBitmap.FromPICFile($"{VCPU.DefaultCIVPath}map.pic", out palette);

			if (tempBitmap != null)
			{
				// Earth image is in 320x200 pixel image, crop to 80x50
				GBitmap earthBitmap = new GBitmap(80, 50);
				earthBitmap.DrawImage(0, 0, tempBitmap, new GRectangle(0, 0, 80, 50), false);

				this.oGameData.Map = new TerrainMap(this.oParent, earthBitmap);
			}
			else
			{
				throw new Exception("Can't load Earth map");
			}

			this.oParent.GameInitAndIntro.Var_67fc = 1;
			while (this.oParent.GameInitAndIntro.F7_0000_17cf_AdvanceEvolutionAnimation() != 0) ;

			// intialize Player.Continents array
			iGroupLength = this.oGameData.Map.Groups.Count;
			for (int i = 0; i < this.oGameData.Players.Length; i++)
			{
				Player player = this.oGameData.Players[i];
				player.Continents = new PlayerContinent[iGroupLength];

				for (int j = 0; j < iGroupLength; j++)
				{
					player.Continents[j] = new PlayerContinent();
				}
			}

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x11a8:0x07af, size: 5
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(0);

			// Instruction address 0x11a8:0x054e, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1c02, 0);

			goto L0549;

		L07bd:
			this.oParent.GameLoadAndSave.F11_0000_0000(0xffff);
			
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0807;

			// Instruction address 0x11a8:0x07e4, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 7);
			goto L0810;

		L07ee:
			this.oParent.HallOfFame.F3_0000_002b();

			this.oParent.HallOfFame.F3_0000_00d7(0xffff);

		L0807:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0xffff);
			goto L04bb;

		L0810:
			this.oParent.StartGameMenu.F5_0000_1455_LoadSprites();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f98, 0x1);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x0);
			if (this.oCPU.Flags.E) goto L0837;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x2);
			if (this.oCPU.Flags.E) goto L0837;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x3);
			if (this.oCPU.Flags.NE) goto L0848;

		L0837:
			// Instruction address 0x11a8:0x0840, size: 5
			this.oParent.Segment_1000.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

		L0848:
			// Instruction address 0x11a8:0x085b, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x11a8:0x0867, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x1c0c, 1);

			// Instruction address 0x11a8:0x086f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_05dd();

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_11a8_0486_LogoAndMainGameMenu");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_087c_NewGameMenu()
		{
			this.oCPU.Log.EnterBlock("F0_11a8_087c_NewGameMenu()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x6);

			if (!this.oParent.Var_1a3c_MouseAvailable) goto L0899;

			// Instruction address 0x11a8:0x0891, size: 5
			this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oParent.Array_d4ce[7]);

		L0899:
			if (this.oGameData.TurnCount != 0) goto L08c5;

			// Instruction address 0x11a8:0x08a8, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1c16, 1);

			this.oParent.StartGameMenu.F5_0000_0000_StartNewGame();

		L08c5:
			this.oParent.StartGameMenu.F5_0000_1af6_LoadGovernmentImage();

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_11a8_087c_NewGameMenu");
		}
	}
}
