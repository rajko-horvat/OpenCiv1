using Avalonia.Media;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class MainCode
	{
		private OpenCiv1Game parent;
		private VCPU CPU;

		private int Var_652e_MouseHideCountTemp = 0;
		private int Var_deea_MouseHideCount = 0;

		public MainCode(OpenCiv1Game parent)
		{
			this.parent = parent;
			this.CPU = parent.CPU;
		}

		/// <summary>
		/// Main game entry
		/// </summary>
		public void F0_11a8_0008_Main()
		{
			// this.oCPU.Log.EnterBlock("F0_11a8_0008_Main()");

			// function body

			// Main menu selection
			// 'N' - No sound, 'A' - Sound blaster, 'R' - Roland MIDI board
			this.parent.Var_1a30_SoundDriverType = 'N';
			this.parent.Var_1a3c_MouseAvailable = true;

			this.parent.MainIntro.F2_0000_0000();

			// Instruction address 0x11a8:0x010b, size: 5
			this.parent.Var_6e92_MouseIconHandle = this.parent.Graphics.LoadIcon("torch.pic");

			// Instruction address 0x11a8:0x0122, size: 5
			this.parent.CommonTools.F0_1000_163e_InitMouse();

			// Instruction address 0x11a8:0x0139, size: 5
			this.parent.CommonTools.F0_1000_1697(0, 0, this.parent.Var_6e92_MouseIconHandle);
			
			// Instruction address 0x11a8:0x0142, size: 3
			F0_11a8_0250_ShowMouse();

			// Game type, load, etc. menu
			// And then after menu Intro
			// Instruction address 0x11a8:0x0146, size: 3
			F0_11a8_0486_LogoAndMainGameMenu();

			// Start Game menu, level, tribe, name
			// Instruction address 0x11a8:0x014a, size: 3
			F0_11a8_087c_NewGameMenu();

			if (this.parent.Var_6b32_SelectedGameType == 1)
			{
				this.parent.Var_d4cc_MapViewX = this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].XStart - 7;
				this.parent.Var_d75e_MapViewY = 19;

				// Instruction address 0x11a8:0x016a, size: 5
				this.parent.Segment_1238.F0_1238_1b44();
			}

			this.parent.Var_dc48_GameEndType = 0;

			while (this.parent.Var_dc48_GameEndType == 0)
			{
				// Instruction address 0x11a8:0x0175, size: 5
				this.parent.Segment_1238.F0_1238_0092_GameTurn();
			}

			// Instruction address 0x11a8:0x0188, size: 5
			this.parent.Var_587d = 0;
		
			// Instruction address 0x11a8:0x0191, size: 3
			this.parent.CommonTools.F0_1000_0a32_PlayTune(0, 0);

			// Instruction address 0x11a8:0x0197, size: 5
			this.parent.CommonTools.F0_1000_0a39_CloseSound();

			// Instruction address 0x11a8:0x019c, size: 5
			this.parent.CommonTools.F0_1000_0051_StopTimer();			
		}

		/// <summary>
		/// Updates current mouse position and pressed button state.
		/// </summary>
		public void F0_11a8_0223_UpdateMouseState()
		{
			// function body
			this.CPU.DoEvents();

			if (this.parent.Var_1a3c_MouseAvailable)
			{
				// Instruction address 0x11a8:0x022a, size: 5
				this.parent.Var_db3a_MouseButton = this.parent.Var_5874_MouseNewButtonsOr | this.parent.Var_5872_MouseNewButtons;
				this.parent.Var_5874_MouseNewButtonsOr = 0;

				this.parent.Var_db3c_MouseXPos = this.parent.Var_586e_MouseNewX;
				this.parent.Var_db3e_MouseYPos = this.parent.Var_5870_MouseNewY;
			}
			else
			{
				this.parent.Var_db3e_MouseYPos = 0;
				this.parent.Var_db3c_MouseXPos = 0;
				this.parent.Var_db3a_MouseButton = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0250_ShowMouse()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0250()");

			// function body
			this.Var_deea_MouseHideCount++;

			if (this.parent.Var_1a3c_MouseAvailable && this.Var_deea_MouseHideCount == 1)
			{
				// Instruction address 0x11a8:0x0262, size: 5
				this.parent.CommonTools.F0_1000_16db();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0268_HideMouse()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0268()");

			// function body
			if (this.parent.Var_1a3c_MouseAvailable && this.Var_deea_MouseHideCount == 1)
			{
				// Instruction address 0x11a8:0x0276, size: 5
				this.parent.CommonTools.F0_1000_170b();
			}

			this.Var_deea_MouseHideCount--;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0280_ShowMouseAndSaveState()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0280()");

			// function body
			this.Var_652e_MouseHideCountTemp = this.Var_deea_MouseHideCount;

			while (this.Var_deea_MouseHideCount < 1)
			{
				// Instruction address 0x11a8:0x0289, size: 3
				F0_11a8_0250_ShowMouse();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0294_HideMouseAndSaveState()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0294()");

			// function body
			while (this.Var_deea_MouseHideCount > this.Var_652e_MouseHideCountTemp)
			{
				// Instruction address 0x11a8:0x0297, size: 3
				F0_11a8_0268_HideMouse();
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_0486_LogoAndMainGameMenu()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_0486_LogoAndMainGameMenu()");

			// function body
			this.parent.Var_d76a_EarthMap = false;

			while (this.parent.Var_6b32_SelectedGameType == -1)
			{
				// Instruction address 0x11a8:0x04b0, size: 5
				this.parent.Var_6b32_SelectedGameType = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(" Start a New Game\n Load a Saved Game\n EARTH\n Customize World\n View Hall of Fame\n", 100, 140, true, false, true);

				int timerValue = 0;
				do
				{
					// Instruction address 0x11a8:0x04c2, size: 5
					timerValue = this.parent.CommonTools.F0_1000_0a4e_Soundtimer();

					if (timerValue <= 5269) break;

					timerValue -= 5269;
					timerValue %= 288;
				}
				while (timerValue != 0);

				// Instruction address 0x11a8:0x04e1, size: 3
				this.parent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

				switch (this.parent.Var_6b32_SelectedGameType)
				{
					case 0:
						// Instruction address 0x11a8:0x0512, size: 3
						F0_11a8_0268_HideMouse();

						this.parent.Var_7ef6_PlanetLandMass = 1;
						this.parent.Var_7ef8_PlanetTemperature = 1;
						this.parent.Var_7efa_PlanetClimate = 1;
						this.parent.Var_7efc_PlanetAge = 1;

						// Intro...
						this.parent.MapInitAndIntro.F7_0000_0012_GenerateMap();

						this.parent.Var_aa_Screen0_Rectangle.ScreenID = 0;

						// Instruction address 0x11a8:0x053e, size: 5
						this.parent.CommonTools.F0_1000_0846(0);

						// Instruction address 0x11a8:0x054e, size: 5
						this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp299.pic", 0);

						// Instruction address 0x11a8:0x0576, size: 5
						this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 160, 50, 160, 150, this.parent.Var_19e8_Screen2_Rectangle, 160, 50);
						break;

					case 1:
						if (this.parent.GameLoadAndSave.F11_0000_0000_LoadGameDialog() == -1)
						{
							this.parent.Var_6b32_SelectedGameType = -1;
						}
						else
						{
							// Instruction address 0x11a8:0x07cd, size: 3
							F0_11a8_0268_HideMouse();

							// Instruction address 0x11a8:0x07e4, size: 5
							this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 7);
						}
						break;

					case 2:
						// Instruction address 0x11a8:0x0796, size: 3
						F0_11a8_0268_HideMouse();

						this.parent.Var_d76a_EarthMap = true;

						this.parent.MapInitAndIntro.F7_0000_0012_GenerateMap();

						this.parent.Var_aa_Screen0_Rectangle.ScreenID = 0;

						// Instruction address 0x11a8:0x07af, size: 5
						this.parent.CommonTools.F0_1000_0846(0);

						// Instruction address 0x11a8:0x054e, size: 5
						this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp299.pic", 0);

						// Instruction address 0x11a8:0x0576, size: 5
						this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 160, 50, 160, 150, this.parent.Var_19e8_Screen2_Rectangle, 160, 50);

						break;

					case 3:
						// Instruction address 0x11a8:0x0592, size: 3
						F0_11a8_0268_HideMouse();

						// Instruction address 0x11a8:0x05b6, size: 5
						this.parent.CommonTools.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

						// Instruction address 0x11a8:0x05d1, size: 5
						this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 0);

						// Instruction address 0x11a8:0x05e1, size: 5
						this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "custom.pic", 1);

						// Instruction address 0x11a8:0x0611, size: 5
						this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 200, this.parent.Var_aa_Screen0_Rectangle, 0, 0);

						// Instruction address 0x11a8:0x061a, size: 3
						F0_11a8_0250_ShowMouse();

						this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.parent.Var_7ef6_PlanetLandMass = -1;

						while (this.parent.Var_7ef6_PlanetLandMass == -1)
						{
							// Instruction address 0x11a8:0x062b, size: 5
							this.parent.CommonTools.F0_1000_16ae(210, 11);

							// Instruction address 0x11a8:0x064f, size: 5
							this.parent.Var_7ef6_PlanetLandMass = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("LAND MASS:\n Small\n Normal\n Large\n", 200, 1, false, true, true);

							if (this.parent.Var_7ef6_PlanetLandMass != -1 && this.parent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.parent.Help.F4_0000_0000(0x1b6a);

								this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = this.parent.Var_7ef6_PlanetLandMass;
								this.parent.Var_7ef6_PlanetLandMass = -1;
							}
						}

						this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.parent.Var_7ef8_PlanetTemperature = -1;

						while (this.parent.Var_7ef8_PlanetTemperature == -1)
						{
							// Instruction address 0x11a8:0x0688, size: 5
							this.parent.CommonTools.F0_1000_16ae(210, 61);

							// Instruction address 0x11a8:0x06ac, size: 5
							this.parent.Var_7ef8_PlanetTemperature = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("TEMPERATURE:\n Cool\n Temperate\n Warm\n", 200, 51, false, true, true);

							if (this.parent.Var_7ef8_PlanetTemperature != -1 && this.parent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.parent.Help.F4_0000_0000(0x1b94);

								this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = this.parent.Var_7ef8_PlanetTemperature;
								this.parent.Var_7ef8_PlanetTemperature = -1;
							}
						}

						this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.parent.Var_7efa_PlanetClimate = -1;

						while (this.parent.Var_7efa_PlanetClimate == -1)
						{
							// Instruction address 0x11a8:0x06e5, size: 5
							this.parent.CommonTools.F0_1000_16ae(210, 111);

							// Instruction address 0x11a8:0x0709, size: 5
							this.parent.Var_7efa_PlanetClimate = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("CLIMATE:\n Arid\n Normal\n Wet\n", 200, 101, false, true, true);

							if (this.parent.Var_7efa_PlanetClimate != -1 && this.parent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.parent.Help.F4_0000_0000(0x1bbd);

								this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = this.parent.Var_7efa_PlanetClimate;
								this.parent.Var_7efa_PlanetClimate = -1;
							}
						}

						this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = 1;
						this.parent.Var_7efc_PlanetAge = -1;

						while (this.parent.Var_7efc_PlanetAge == -1)
						{
							// Instruction address 0x11a8:0x0742, size: 5
							this.parent.CommonTools.F0_1000_16ae(210, 161);

							// Instruction address 0x11a8:0x0766, size: 5
							this.parent.Var_7efc_PlanetAge = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox("AGE:\n 3 billion years\n 4 billion years\n 5 billion years\n", 200, 151, false, true, true);

							if (this.parent.Var_7efc_PlanetAge != -1 && this.parent.Var_2f9c_MenuBoxHelpRequested)
							{
								this.parent.Help.F4_0000_0000(0x1bfe);

								this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = this.parent.Var_7efc_PlanetAge;
								this.parent.Var_7efc_PlanetAge = -1;
							}
						}

						// Instruction address 0x11a8:0x078f, size: 3
						F0_11a8_0268_HideMouse();

						// Intro...
						this.parent.MapInitAndIntro.F7_0000_0012_GenerateMap();

						this.parent.Var_aa_Screen0_Rectangle.ScreenID = 0;

						// Instruction address 0x11a8:0x053e, size: 5
						this.parent.CommonTools.F0_1000_0846(0);

						// Instruction address 0x11a8:0x054e, size: 5
						this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "sp299.pic", 0);

						// Instruction address 0x11a8:0x0576, size: 5
						this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 160, 50, 160, 150, this.parent.Var_19e8_Screen2_Rectangle, 160, 50);

						break;

					case 4:
						// Instruction address 0x11a8:0x07ef, size: 3
						F0_11a8_0268_HideMouse();

						this.parent.HallOfFame.F3_0000_002b();

						this.parent.HallOfFame.F3_0000_00d7(-1);

						// Instruction address 0x11a8:0x0804, size: 3
						F0_11a8_0250_ShowMouse();

						this.parent.Var_6b32_SelectedGameType = -1;
						break;

					default:
						this.parent.Var_6b32_SelectedGameType = -1;
						break;
				}
			}

			this.parent.StartGameMenu.F5_0000_1455_LoadBitmaps();

			this.parent.Var_2f98_PatternAvailable = true;

			if (this.parent.Var_6b32_SelectedGameType == 0 || this.parent.Var_6b32_SelectedGameType == 2 || this.parent.Var_6b32_SelectedGameType == 3)
			{
				// Instruction address 0x11a8:0x0840, size: 5
				this.parent.CommonTools.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));
			}

			// Instruction address 0x11a8:0x085b, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x11a8:0x0867, size: 5
			this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "sp257.pic", 1);

			// Instruction address 0x11a8:0x086f, size: 5
			this.parent.Segment_2dc4.F0_2dc4_05dd_AddPaletteCycleSlots();

			// Instruction address 0x11a8:0x0875, size: 3
			F0_11a8_0250_ShowMouse();
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_11a8_087c_NewGameMenu()
		{
			//this.oCPU.Log.EnterBlock("F0_11a8_087c_NewGameMenu()");

			// function body
			// Instruction address 0x11a8:0x0891, size: 5
			this.parent.CommonTools.F0_1000_1697(0, 0, this.parent.Array_d4ce[7]);

			if (this.parent.GameData.TurnCount == 0)
			{
				// Instruction address 0x11a8:0x08a8, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "diffs.pic", 1);

				this.parent.StartGameMenu.F5_0000_0000_InitNewGameData();
			}
		
			this.parent.StartGameMenu.F5_0000_1af6_LoadGovernmentImage();
		}
	}
}
