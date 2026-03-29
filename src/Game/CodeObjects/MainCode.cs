using Avalonia.Media;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class MainCode
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		private int Var_652e = 0;
		private int Var_deea = 0;

		public MainCode(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// Main game entry
		/// </summary>
		public void F0_11a8_0008_Main()
		{
			// this.oCPU.Log.EnterBlock("F0_11a8_0008_Main()");

			// function body
			// Main menu selection
			// 'M' - VGA
			this.oParent.Var_1a22_VGAType = 'M';
			// 'N' - No sound, 'A' - Sound blaster, 'R' - Roland MIDI board
			this.oParent.Var_1a30_SoundDriverType = 'N';
			// '1' - Mouse and Keyboard 0x1, '2' - Keyboard only 0x0
			this.oParent.Var_1a3c_MouseAvailable = true;

			this.oParent.MainIntro.F2_0000_0000();

			// Instruction address 0x11a8:0x010b, size: 5
			this.oParent.Var_6e92_MouseIconHandle = this.oParent.Graphics.LoadIcon("torch.pic");

			// Instruction address 0x11a8:0x0122, size: 5
			this.oParent.CommonTools.F0_1000_163e_InitMouse();

			// Instruction address 0x11a8:0x0139, size: 5
			this.oParent.CommonTools.F0_1000_1697(0, 0, this.oParent.Var_6e92_MouseIconHandle);
			
			// Instruction address 0x11a8:0x0142, size: 3
			F0_11a8_0250();

			// Game type, load, etc. menu
			// And then after menu Intro
			// Instruction address 0x11a8:0x0146, size: 3
			F0_11a8_0486_LogoAndMainGameMenu();

			// Start Game menu, level, tribe, name
			// Instruction address 0x11a8:0x014a, size: 3
			F0_11a8_087c_NewGameMenu();

			if (this.oParent.Var_6b32_SelectedGameType == 1)
			{
				this.oParent.Var_d4cc_MapViewX = this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].XStart - 7;
				this.oParent.Var_d75e_MapViewY = 19;

				// Instruction address 0x11a8:0x016a, size: 5
				this.oParent.Segment_1238.F0_1238_1b44();
			}

			this.oParent.Var_dc48_GameEndType = 0;

			while (this.oParent.Var_dc48_GameEndType == 0)
			{
				// Instruction address 0x11a8:0x0175, size: 5
				this.oParent.Segment_1238.F0_1238_0092_GameTurn();
			}

			// Instruction address 0x11a8:0x0188, size: 5
			this.oParent.Var_587d = 0;
		
			// Instruction address 0x11a8:0x0191, size: 3
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(0, 0);

			// Instruction address 0x11a8:0x0197, size: 5
			this.oParent.CommonTools.F0_1000_0a39_CloseSound();

			// Instruction address 0x11a8:0x019c, size: 5
			this.oParent.CommonTools.F0_1000_0051_StopTimer();			
		}

		/// <summary>
		/// Updates current mouse position and pressed button state.
		/// </summary>
		public void F0_11a8_0223_UpdateMouseState()
		{
			// function body
			this.oCPU.DoEvents();

			if (this.oParent.Var_1a3c_MouseAvailable)
			{
				// Instruction address 0x11a8:0x022a, size: 5
				this.oParent.Var_db3a_MouseButton = this.oParent.Var_5874_MouseNewButtonsOr | this.oParent.Var_5872_MouseNewButtons;
				this.oParent.Var_5874_MouseNewButtonsOr = 0;

				this.oParent.Var_db3c_MouseXPos = this.oParent.Var_586e_MouseNewX;
				this.oParent.Var_db3e_MouseYPos = this.oParent.Var_5870_MouseNewY;
			}
			else
			{
				this.oParent.Var_db3e_MouseYPos = 0;
				this.oParent.Var_db3c_MouseXPos = 0;
				this.oParent.Var_db3a_MouseButton = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0250()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0250()");

			// function body
			this.Var_deea++;

			if (this.oParent.Var_1a3c_MouseAvailable && this.Var_deea == 1)
			{
				// Instruction address 0x11a8:0x0262, size: 5
				this.oParent.CommonTools.F0_1000_16db();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0268()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0268()");

			// function body
			if (this.oParent.Var_1a3c_MouseAvailable && this.Var_deea == 1)
			{
				// Instruction address 0x11a8:0x0276, size: 5
				this.oParent.CommonTools.F0_1000_170b();
			}

			this.Var_deea--;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0280()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0280()");

			// function body
			this.Var_652e = this.Var_deea;

			while (this.Var_deea < 1)
			{
				// Instruction address 0x11a8:0x0289, size: 3
				F0_11a8_0250();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0294()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0294()");

			// function body
			while (this.Var_deea > this.Var_652e)
			{
				// Instruction address 0x11a8:0x0297, size: 3
				F0_11a8_0268();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0486_LogoAndMainGameMenu()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0486_LogoAndMainGameMenu()");

			// function body
		#region Testing region
			/*this.oParent.Var_d762 = 1;
			this.oParent.StartGameMenu.F5_0000_1455_LoadBitmaps();

			this.oParent.Var_2f9e_MessageBoxStyle = MenuBoxReportTypeEnum.None;
			this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = -1;
			this.oParent.Var_b276_MenuBoxDisabledOptions = 0;
			this.oParent.Var_d7f2_MenuBoxCheckedOptions = 0;

			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("This is the test with options:\n Option A\n Option B", 100, 100, true, true, true);
			//*/
		#endregion

			this.oParent.Var_d76a = 0;

			while (this.oParent.Var_6b32_SelectedGameType == -1)
			{
				// Instruction address 0x11a8:0x04b0, size: 5
				this.oParent.Var_6b32_SelectedGameType = this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(" Start a New Game\n Load a Saved Game\n EARTH\n Customize World\n View Hall of Fame\n", 100, 140, true, false, true);

				int timerValue = 0;
				do
				{
					// Instruction address 0x11a8:0x04c2, size: 5
					timerValue = this.oParent.CommonTools.F0_1000_0a4e_Soundtimer();

					if (timerValue <= 5269) break;

					timerValue -= 5269;
					timerValue %= 288;
				}
				while (timerValue != 0);

				// Instruction address 0x11a8:0x04e1, size: 3
				this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

				switch (this.oParent.Var_6b32_SelectedGameType)
				{
					case 0:
						// Instruction address 0x11a8:0x0512, size: 3
						F0_11a8_0268();

						this.oParent.Var_7ef6_PlanetLandMass = 1;
						this.oParent.Var_7ef8_PlanetTemperature = 1;
						this.oParent.Var_7efa_PlanetClimate = 1;
						this.oParent.Var_7efc_PlanetAge = 1;

						// Intro...
						this.oParent.GameInitAndIntro.F7_0000_0012_GameIntro();

						this.oParent.Var_aa_Rectangle.ScreenID = 0;

						// Instruction address 0x11a8:0x053e, size: 5
						this.oParent.CommonTools.F0_1000_0846(0);

						// Instruction address 0x11a8:0x054e, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp299.pic", 0);

						// Instruction address 0x11a8:0x0576, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 160, 50, 160, 150, this.oParent.Var_19e8_Rectangle, 160, 50);
						break;

					case 1:
						if ((short)this.oParent.GameLoadAndSave.F11_0000_0000(0xffff) == -1)
						{
							this.oParent.Var_6b32_SelectedGameType = -1;
						}
						else
						{
							// Instruction address 0x11a8:0x07cd, size: 3
							F0_11a8_0268();

							// Instruction address 0x11a8:0x07e4, size: 5
							this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 7);
						}
						break;

					case 2:
						// Instruction address 0x11a8:0x0796, size: 3
						F0_11a8_0268();

						this.oParent.Var_d76a = 1;

						this.oParent.GameInitAndIntro.F7_0000_0012_GameIntro();

						this.oParent.Var_aa_Rectangle.ScreenID = 0;

						// Instruction address 0x11a8:0x07af, size: 5
						this.oParent.CommonTools.F0_1000_0846(0);

						// Instruction address 0x11a8:0x054e, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp299.pic", 0);

						// Instruction address 0x11a8:0x0576, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 160, 50, 160, 150, this.oParent.Var_19e8_Rectangle, 160, 50);

						break;

					case 3:
						// Instruction address 0x11a8:0x0592, size: 3
						F0_11a8_0268();

						// Instruction address 0x11a8:0x05b6, size: 5
						this.oParent.CommonTools.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

						// Instruction address 0x11a8:0x05d1, size: 5
						this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

						// Instruction address 0x11a8:0x05e1, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "custom.pic", 1);

						// Instruction address 0x11a8:0x0611, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

						// Instruction address 0x11a8:0x061a, size: 3
						F0_11a8_0250();

						this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.oParent.Var_7ef6_PlanetLandMass = -1;

						while (this.oParent.Var_7ef6_PlanetLandMass == -1)
						{
							// Instruction address 0x11a8:0x062b, size: 5
							this.oParent.CommonTools.F0_1000_16ae(210, 11);

							// Instruction address 0x11a8:0x064f, size: 5
							this.oParent.Var_7ef6_PlanetLandMass = this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("LAND MASS:\n Small\n Normal\n Large\n", 200, 1, false, true, true);

							if (this.oParent.Var_7ef6_PlanetLandMass != -1 && this.oParent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.oParent.Help.F4_0000_0000(0x1b6a);

								this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = this.oParent.Var_7ef6_PlanetLandMass;
								this.oParent.Var_7ef6_PlanetLandMass = -1;
							}
						}

						this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.oParent.Var_7ef8_PlanetTemperature = -1;

						while (this.oParent.Var_7ef8_PlanetTemperature == -1)
						{
							// Instruction address 0x11a8:0x0688, size: 5
							this.oParent.CommonTools.F0_1000_16ae(210, 61);

							// Instruction address 0x11a8:0x06ac, size: 5
							this.oParent.Var_7ef8_PlanetTemperature = this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("TEMPERATURE:\n Cool\n Temperate\n Warm\n", 200, 51, false, true, true);

							if (this.oParent.Var_7ef8_PlanetTemperature != -1 && this.oParent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.oParent.Help.F4_0000_0000(0x1b94);

								this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = this.oParent.Var_7ef8_PlanetTemperature;
								this.oParent.Var_7ef8_PlanetTemperature = -1;
							}
						}

						this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.oParent.Var_7efa_PlanetClimate = -1;

						while (this.oParent.Var_7efa_PlanetClimate == -1)
						{
							// Instruction address 0x11a8:0x06e5, size: 5
							this.oParent.CommonTools.F0_1000_16ae(210, 111);

							// Instruction address 0x11a8:0x0709, size: 5
							this.oParent.Var_7efa_PlanetClimate = this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("CLIMATE:\n Arid\n Normal\n Wet\n", 200, 101, false, true, true);

							if (this.oParent.Var_7efa_PlanetClimate != -1 && this.oParent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.oParent.Help.F4_0000_0000(0x1bbd);

								this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = this.oParent.Var_7efa_PlanetClimate;
								this.oParent.Var_7efa_PlanetClimate = -1;
							}
						}

						this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.oParent.Var_7efc_PlanetAge = -1;

						while (this.oParent.Var_7efc_PlanetAge == -1)
						{
							// Instruction address 0x11a8:0x0742, size: 5
							this.oParent.CommonTools.F0_1000_16ae(210, 161);

							// Instruction address 0x11a8:0x0766, size: 5
							this.oParent.Var_7efc_PlanetAge = this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("AGE:\n 3 billion years\n 4 billion years\n 5 billion years\n", 200, 151, false, true, true);

							if (this.oParent.Var_7efc_PlanetAge != -1 && this.oParent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.oParent.Help.F4_0000_0000(0x1bfe);

								this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = this.oParent.Var_7efc_PlanetAge;
								this.oParent.Var_7efc_PlanetAge = -1;
							}
						}

						// Instruction address 0x11a8:0x078f, size: 3
						F0_11a8_0268();

						// Intro...
						this.oParent.GameInitAndIntro.F7_0000_0012_GameIntro();

						this.oParent.Var_aa_Rectangle.ScreenID = 0;

						// Instruction address 0x11a8:0x053e, size: 5
						this.oParent.CommonTools.F0_1000_0846(0);

						// Instruction address 0x11a8:0x054e, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp299.pic", 0);

						// Instruction address 0x11a8:0x0576, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 160, 50, 160, 150, this.oParent.Var_19e8_Rectangle, 160, 50);

						break;

					case 4:
						// Instruction address 0x11a8:0x07ef, size: 3
						F0_11a8_0268();

						this.oParent.HallOfFame.F3_0000_002b();

						this.oParent.HallOfFame.F3_0000_00d7(-1);

						// Instruction address 0x11a8:0x0804, size: 3
						F0_11a8_0250();

						this.oParent.Var_6b32_SelectedGameType = -1;
						break;

					default:
						this.oParent.Var_6b32_SelectedGameType = -1;
						break;
				}
			}

			this.oParent.StartGameMenu.F5_0000_1455_LoadBitmaps();

			this.oParent.Var_2f98_PatternAvailable = true;

			if (this.oParent.Var_6b32_SelectedGameType == 0 || this.oParent.Var_6b32_SelectedGameType == 2 || this.oParent.Var_6b32_SelectedGameType == 3)
			{
				// Instruction address 0x11a8:0x0840, size: 5
				this.oParent.CommonTools.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));
			}

			// Instruction address 0x11a8:0x085b, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x11a8:0x0867, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "sp257.pic", 1);

			// Instruction address 0x11a8:0x086f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_05dd();

			// Instruction address 0x11a8:0x0875, size: 3
			F0_11a8_0250();
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_087c_NewGameMenu()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_087c_NewGameMenu()");

			// function body
			// Instruction address 0x11a8:0x0891, size: 5
			this.oParent.CommonTools.F0_1000_1697(0, 0, this.oParent.Array_d4ce[7]);

			if (this.oParent.GameData.TurnCount == 0)
			{
				// Instruction address 0x11a8:0x08a8, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "diffs.pic", 1);

				this.oParent.StartGameMenu.F5_0000_0000();
			}
		
			this.oParent.StartGameMenu.F5_0000_1af6_LoadGovernmentImage();
		}
	}
}
