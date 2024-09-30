using Avalonia.Media;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class MainIntro
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public MainIntro(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F2_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F2_0000_0000()");

			// function body
			int local_44;
			int local_4e;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdeba, 0x1);

			for (int i = 1; i < 8; i++)
			{
				// Instruction address 0x0000:0x0019, size: 5
				if (this.oParent.Segment_11a8.F0_11a8_02a4(i, 0) == 0)
					break;

				this.oCPU.WriteInt16(this.oCPU.DS.Word, 0xdeba, (short)(i + 1));
			}
			
			this.oParent.Var_aa_Rectangle.FontID = 1;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6dfc, 0x0);

			for (int i = 0; i < 3; i++)
			{
				// Instruction address 0x0000:0x01a1, size: 5
				if (this.oParent.Graphics.F0_VGA_04ae_AllocateScreen(i) == 0)
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6dfc, 0x1);
				}
			}

			// Instruction address 0x0000:0x01be, size: 5
			this.oParent.Segment_1000.F0_1000_0a2b_InitSound();

			// Instruction address 0x0000:0x01c3, size: 5
			this.oParent.Segment_1000.F0_1000_0000_InitializeTimer();

			// Instruction address 0x0000:0x01c8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0042_Randomize();

			// Instruction address 0x0000:0x01e0, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);
		
			// Instruction address 0x0000:0x020e, size: 5
			this.oParent.Graphics.F0_VGA_010c_SetColorsByIndexArray(0x19fe);
			
			// Instruction address 0x0000:0x0223, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x328a, 1);

			// Instruction address 0x0000:0x023e, size: 5
			local_4e = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 0, 64, 320, 80);

			// Instruction address 0x0000:0x0256, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3293, 1);

			// Instruction address 0x0000:0x027c, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 76, 320, 24, this.oParent.Var_19d4_Rectangle, 0, 176);

			// Instruction address 0x0000:0x028c, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(2, 0, 0, 0x329e, 1);

			// Instruction address 0x0000:0x02b2, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 0, 76, 320, 24, this.oParent.Var_19e8_Rectangle, 0, 176);

			// Instruction address 0x0000:0x02be, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x32a9, 1);

			// Instruction address 0x0000:0x02dc, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 12, 320, 176, 0);

			// Instruction address 0x0000:0x02f4, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(1, 14, 146, 152);

			for (int i = 1; i <= 3; i++)
			{
				// Instruction address 0x0000:0x030b, size: 5
				this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(i);
			}

			this.oGameData.GameSettingFlags |= 0x10;

			// Instruction address 0x0000:0x0329, size: 5
			this.oParent.Var_d768 = (ushort)this.oParent.MSCAPI.fopen("credits.txt", "rt");

			// Instruction address 0x0000:0x0334, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();

			// Instruction address 0x0000:0x033d, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(3, 0);

			// First screen animation with credits
			this.oParent.Var_aa_Rectangle.FontID = 5;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			for (int i = 0; i < 320; i++)
			{
				// Instruction address 0x0000:0x04f7, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_19d4_Rectangle, 0, 176, 320 - i, 24, 0);

				// Instruction address 0x0000:0x051a, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					0, 64, i, 24, this.oParent.Var_19d4_Rectangle, 320 - i, 176);

				switch (i)
				{
					case 10:
					case 70:
					case 120:
					case 170:
					case 190:
					case 210:
					case 230:
					case 250:
					case 270:
					case 290:
					case 310:
						this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, "%[^\n]\n", 0xba06);
						break;

					case 50:
					case 160:
						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
						break;
				}

				// Instruction address 0x0000:0x0609, size: 5
				if (this.oParent.MSCAPI.strlen(0xba06) != 0)
				{
					local_44 = this.oParent.Var_aa_Rectangle.ScreenID;
					this.oParent.Var_aa_Rectangle.ScreenID = 1;

					// Instruction address 0x0000:0x0362, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 184, 0xfc);

					// Instruction address 0x0000:0x0386, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 182, 0xf8);

					// Instruction address 0x0000:0x03aa, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 183, 0xfa);

					this.oParent.Var_aa_Rectangle.ScreenID = local_44;
				}

				// Instruction address 0x0000:0x03f4, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					0, 0, i, 64, this.oParent.Var_aa_Rectangle, 320 - i, 12);

				// Instruction address 0x0000:0x041a, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					0, 176, 320, 24, this.oParent.Var_aa_Rectangle, 0, 76);

				// Instruction address 0x0000:0x043a, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					0, 88, i, 88, this.oParent.Var_aa_Rectangle, 320 - i, 100);

				// Instruction address 0x0000:0x0476, size: 5
				if ((i * 21) / 4 < (short)this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer() && (i & 0x1) == 0)
				{
					i++;
				}

				// Instruction address 0x0000:0x04a0, size: 5
				while ((i * 21) / 4 > (short)this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer() && this.oParent.MSCAPI.kbhit() == 0)
				{
					Thread.Sleep(0);
				}

				// Instruction address 0x0000:0x04c1, size: 5
				if (this.oParent.MSCAPI.kbhit() != 0)
				{
					break;
				}
			}

			// Second screen animation with credits
			for (int i = 0; i < 320; i++)
			{
				// Instruction address 0x0000:0x0868, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					i, 64, 320 - i, 24, this.oParent.Var_19d4_Rectangle, 0, 176);

				if (i > 0)
				{
					// Instruction address 0x0000:0x0897, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
						0, 64, i, 24, this.oParent.Var_19d4_Rectangle, 320 - i, 176);
				}

				switch (i)
				{
					case 10:
					case 30:
					case 64:
					case 84:
					case 130:
					case 150:
					case 170:
					case 190:
					case 210:
					case 230:
					case 250:
					case 270:
					case 290:
						this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, "%[^\n]\n", 0xba06);
						break;

					case 50:
					case 116:
					case 310:
						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
						break;
				}

				// Instruction address 0x0000:0x09ab, size: 5
				if (this.oParent.MSCAPI.strlen(0xba06) != 0)
				{
					local_44 = this.oParent.Var_aa_Rectangle.ScreenID;
					this.oParent.Var_aa_Rectangle.ScreenID = 1;

					// Instruction address 0x0000:0x064d, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 184, 0xfc);

					// Instruction address 0x0000:0x0671, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 182, 0xf8);

					// Instruction address 0x0000:0x0695, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 183, 0xfa);

					this.oParent.Var_aa_Rectangle.ScreenID = local_44;
				}

				// Instruction address 0x0000:0x06e6, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					i, 0, 320 - i, 64, this.oParent.Var_aa_Rectangle, 0, 12);

				if (i > 0)
				{
					// Instruction address 0x0000:0x0712, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
						0, 0, i, 64, this.oParent.Var_aa_Rectangle, 320 - i, 12);
				}

				// Instruction address 0x0000:0x0738, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					0, 176, 320, 24, this.oParent.Var_aa_Rectangle, 0, 76);

				// Instruction address 0x0000:0x0768, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
					i, 88, 320 - i, 88, this.oParent.Var_aa_Rectangle, 0, 100);

				if (i > 0)
				{
					// Instruction address 0x0000:0x0794, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
						0, 88, i, 88, this.oParent.Var_aa_Rectangle, 320 - i, 100);
				}

				// Instruction address 0x0000:0x07d0, size: 5
				if ((i * 21 + 6720) / 4 < this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer() && (i & 0x1) == 0)
				{
					i++;
				}

				// Instruction address 0x0000:0x07fd, size: 5
				// Instruction address 0x0000:0x0806, size: 5			
				while ((i * 21 + 6720) / 4 > this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer() && this.oParent.MSCAPI.kbhit() == 0)
				{
					Thread.Sleep(0);
				}

				// Instruction address 0x0000:0x082a, size: 5
				if (this.oParent.MSCAPI.kbhit() != 0)
				{
					break;
				}
			}

			this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x6b32, -2);

			// Instruction address 0x0000:0x09dd, size: 5
			if (this.oParent.MSCAPI.kbhit() != 0)
			{
				this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x6b32, -1);

				// Instruction address 0x0000:0x09ec, size: 5
				char navigationKey = char.ToUpper((char)this.oParent.MenuBoxDialog.F0_2d05_0ac9_GetNavigationKey());

				if (navigationKey == 'N')
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0);
				}
				else if (navigationKey == 'C')
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0x3);
				}
				else if (navigationKey == 'E')
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0x2);
				}
				else if (navigationKey == 'L')
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0x1);
				}
			}

			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6b32) == -2)
			{
				// Instruction address 0x0000:0x0a19, size: 5
				while (this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer() < 3463)
				{
					Thread.Sleep(0);
				}

				// Instruction address 0x0000:0x0a6b, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

				// Instruction address 0x0000:0x0a81, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, 0, 64, local_4e);

				// Instruction address 0x0000:0x0aa0, size: 5
				this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(4, 14, 224, 239);

				// Instruction address 0x0000:0x0aac, size: 5
				this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(4);

				for (int i = 0; i < 320; i += 4)
				{
					// Instruction address 0x0000:0x0ad7, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
						i, 64, 4, 80, this.oParent.Var_aa_Rectangle, i, 64);

					// Instruction address 0x0000:0x0ae3, size: 5
					this.oParent.Segment_1000.F0_1182_0134_WaitTimer(1);
				}

				// Instruction address 0x0000:0x0b12, size: 5
				for (int i = 0; i < 100 && this.oParent.MSCAPI.kbhit() == 0; i++)
				{
					// Instruction address 0x0000:0x0b01, size: 5
					this.oParent.Segment_1000.F0_1182_0134_WaitTimer(5);
				}

				// Instruction address 0x0000:0x0b1b, size: 5
				this.oParent.Segment_1403.F0_1403_4545();

				this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x6b32, -1);
			}

			for (int i = 1; i <= 4; i++)
			{
				// Instruction address 0x0000:0x0b40, size: 5
				this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(i);
			}

			// Instruction address 0x0000:0x0b65, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x0b7b, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, 0, 64, local_4e);

			// Instruction address 0x0000:0x0b8b, size: 5
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(1);

			// Instruction address 0x0000:0x0bab, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x0bb6, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);
			
			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x0bca, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(local_4e, 0);

			// Far return
			this.oCPU.Log.ExitBlock("F2_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F2_0000_0bd7(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F2_0000_0bd7({playerID})");

			// function body
			string local_200;
			int local_204;
			int local_208;
			int[] local_238 = new int[24];
			int local_23a;
			int local_23c;
			int local_240;
			int local_242;
			int local_244;

			// Instruction address 0x0000:0x0be9, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(6, 1);

			// Instruction address 0x0000:0x0bf9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "planet2.pic", 0);

			for (int i = 0; i < 24; i++)
			{
				// Instruction address 0x0000:0x0c39, size: 5
				local_238[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i % 6) * 50) + 1, ((i / 6) * 50) + 1, 49, 49);
			}			

			// Instruction address 0x0000:0x0c5b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x0c83, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 236);

			// Instruction address 0x0000:0x0c93, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "planet1.pic", 1);

			// Instruction address 0x0000:0x0cb6, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 24, 320, 176, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x0000:0x0cdc, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 32, 320, 24, this.oParent.Var_19d4_Rectangle, 0, 176);

			// Instruction address 0x0000:0x0ced, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x0000:0x0d2b, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0xec);

			// Instruction address 0x0000:0x0d4a, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 12, 320, 176, 0xec);

			this.oCPU.BX.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0d66, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x0d76, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			// Instruction address 0x0000:0x0d8c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Name);

			// Instruction address 0x0000:0x0d9c, size: 5
			this.oParent.Array_30b8[0] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			// Instruction address 0x0000:0x0db1, size: 5
			this.oParent.Array_30b8[1] = this.oGameData.Players[playerID].Nationality;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0dd7, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].SpaceshipPopulation, 10));

			// Instruction address 0x0000:0x0de7, size: 5
			this.oParent.Array_30b8[2] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0e0d, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[playerID].SpaceshipLaunchYear, 10));

			// Instruction address 0x0000:0x0e1d, size: 5
			this.oParent.Array_30b8[3] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0e43, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(this.oGameData.Year, 10));

			// Instruction address 0x0000:0x0e53, size: 5
			this.oParent.Array_30b8[4] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			// Instruction address 0x0000:0x0e70, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_01ad(0x3301, (ushort)((playerID != this.oGameData.HumanPlayerID) ? 0x32f9 : 0x32f2));

			// Instruction address 0x0000:0x0e78, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0471();

			// Instruction address 0x0000:0x0e86, size: 5
			local_200 = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			this.oParent.Var_aa_Rectangle.FontID = 6;

			local_242 = -10;
			local_244 = 92;

			local_204 = -1;
			local_23c = -1;

			// Instruction address 0x0000:0x0eb2, size: 5
			local_240 = this.oParent.MSCAPI.strlen(0xba06);

			// Instruction address 0x0000:0x0ec2, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(3, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			
			local_208 = 0;

			for (int i = 0; i < 320; i++)
			{
				// Instruction address 0x0000:0x10d7, size: 5
				this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();

				// Instruction address 0x0000:0x10ff, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_19d4_Rectangle, 0, 176, 320 - i, 24, 0xec);

				if (i > 0)
				{
					// Instruction address 0x0000:0x1131, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 20, i, 24,
						this.oParent.Var_19d4_Rectangle, 320 - i, 176);
				}

				if ((i % 22) == 0)
				{
					local_23c = local_204 + 1;

					do
					{
						local_204++;
					}
					while (this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(0xba06 + local_204)) != 0x5e && local_204 < local_240);

					if (local_204 < local_240)
					{
						this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(local_204 + 0xba06), 0x0);
					}
				}
			
				if (local_204 < local_240)
				{
					local_23a = this.oParent.Var_aa_Rectangle.ScreenID;
					this.oParent.Var_aa_Rectangle.ScreenID = 1;

					// Instruction address 0x0000:0x0eec, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA((ushort)(0xba06 + local_23c), 160, 184, 0x38);

					// Instruction address 0x0000:0x0f14, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA((ushort)(0xba06 + local_23c), 160, 183, 0x3c);

					this.oParent.Var_aa_Rectangle.ScreenID = local_23a;
				}

				local_208++;

				if (local_208 > 22)
				{
					local_208 = 0;
				}

				// Instruction address 0x0000:0x0f4d, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, 135, 51, local_238[local_208]);

				// Instruction address 0x0000:0x0f8d, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 12, 319, 20, 0xec);

				if (i > 0)
				{
					// Instruction address 0x0000:0x0fbc, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, i, 20,
						this.oParent.Var_aa_Rectangle, 320 - i, 12);
				}

				// Instruction address 0x0000:0x0fe2, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 176, 320, 24, this.oParent.Var_aa_Rectangle, 0, 32);

				// Instruction address 0x0000:0x100d, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 56, 320 - i, 132, 0xec);

				if (i > 0)
				{
					// Instruction address 0x0000:0x103f, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 44, i, 132,
						this.oParent.Var_aa_Rectangle, 320 - i, 56);
				}

				if ((i & 0x1) != 0)
				{
					local_242++;

					// Instruction address 0x0000:0x1067, size: 5
					this.oParent.Segment_1000.F0_1000_104f_SetPixel(local_242 - i, local_244, 15);
				}

				local_242++;

				this.oCPU.DoEvents();

				if (this.oParent.Var_5c_TickCount > 12 && (i & 0x1) == 0)
				{
					i++;
				}

				while (this.oParent.Var_5c_TickCount < 8)
				{
					this.oCPU.DoEvents();
				}
			}

			// Instruction address 0x0000:0x11a3, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(local_238[0], 0);

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x11b6, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);

			// Instruction address 0x0000:0x11cb, size: 5
			local_200 = this.oCPU.ReadString(this.oCPU.DS.Word, (ushort)(0xba07 + local_204));

			local_240 -= local_204 + 1;

			local_204 = -1;

			if (playerID == this.oGameData.HumanPlayerID)
			{
				// Instruction address 0x0000:0x11f7, size: 5
				this.oParent.Segment_11a8.F0_11a8_02a4(6, 1);

				// Instruction address 0x0000:0x1207, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x330a, 0);

				// Instruction address 0x0000:0x1213, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

				// Instruction address 0x0000:0x122b, size: 5
				this.oParent.Segment_1000.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

				// Instruction address 0x0000:0x1246, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

				// Instruction address 0x0000:0x1252, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x3316, 1);

				// Instruction address 0x0000:0x1263, size: 5
				this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

				// Instruction address 0x0000:0x126f, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x22, 0);

				// Instruction address 0x0000:0x128f, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

				// Instruction address 0x0000:0x12b1, size: 5
				this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(1, 15, 16, 31);

				// Instruction address 0x0000:0x12c9, size: 5
				this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(2, 100, 32, 34);

				// Instruction address 0x0000:0x12e1, size: 5
				this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(3, 42, 35, 40);

				// Instruction address 0x0000:0x12f9, size: 5
				this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(4, 300, 41, 47);

				// Instruction address 0x0000:0x1311, size: 5
				this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(5, 60, 48, 53);

				// Instruction address 0x0000:0x1329, size: 5
				this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(6, 37, 54, 63);

				for (int i = 1; i <= 6; i++)
				{
					// Instruction address 0x0000:0x133b, size: 5
					this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(i);
				}
			}
			else
			{
				this.oParent.Palace.F17_0000_07ec(1);

				// Instruction address 0x0000:0x1376, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);
			}

			do
			{
				local_23c = local_204 + 1;

				do
				{
					local_204++;
				}
				while (local_200[local_204] != '^' && local_204 < local_240);

				if (local_204 < local_240)
				{
					local_200 = local_200.Substring(0, local_204);
				}

				if (local_204 < local_240)
				{
					// Instruction address 0x0000:0x13d6, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 32, this.oParent.Var_aa_Rectangle, 0, 0);

					// Instruction address 0x0000:0x13f3, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(local_200.Substring(local_23c), 160, 5, 11);

					// Instruction address 0x0000:0x1410, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(local_200.Substring(local_23c), 160, 4, 15);

					// Instruction address 0x0000:0x1428, size: 5
					this.oParent.Segment_1000.F0_1000_104f_SetPixel(280, 32, 15);

					// Instruction address 0x0000:0x1434, size: 5
					this.oParent.Segment_1000.F0_1182_0134_WaitTimer(80);

					// Instruction address 0x0000:0x144b, size: 5
					this.oParent.Segment_1000.F0_1000_104f_SetPixel(280, 32, 0);

					// Instruction address 0x0000:0x1457, size: 5
					this.oParent.Segment_1000.F0_1182_0134_WaitTimer(80);
				}
			}
			while (local_204 < local_240);

			// Instruction address 0x0000:0x146c, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			if (playerID == this.oGameData.HumanPlayerID)
			{
				for (int i = 1; i < 7; i++)
				{
					// Instruction address 0x0000:0x148a, size: 5
					this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(i);
				}
			}
		
			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x14a9, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);
			
			// Instruction address 0x0000:0x14b5, size: 5
			this.oParent.MSCAPI.fclose((short)this.oParent.Var_d768);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x1513, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x151b, size: 5
			this.oParent.Segment_1238.F0_1238_1beb();

			// Instruction address 0x0000:0x1520, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_05dd();

			// Far return
			this.oCPU.Log.ExitBlock("F2_0000_0bd7");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F2_0000_152a()
		{
			this.oCPU.Log.EnterBlock("F2_0000_152a()");

			// function body
			int local_2;
			int local_4;
			int local_8;

			// Instruction address 0x0000:0x1530, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x153f, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(6, 1);

			// Instruction address 0x0000:0x155a, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x1566, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x23, 0);

			// Instruction address 0x0000:0x1576, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x332e, 1);

			// Instruction address 0x0000:0x1587, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x0000:0x15a7, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x15bd, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[this.oGameData.HumanPlayerID].Name);

			// Instruction address 0x0000:0x15c9, size: 5
			this.oParent.MSCAPI.strupr(0xba06);

			// Instruction address 0x0000:0x15d9, size: 5
			this.oParent.Array_30b8[0] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			// Instruction address 0x0000:0x15e9, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Irrigation");

			for (int i = 0; i < 72; i++)
			{
				// Instruction address 0x0000:0x15fd, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, i) != 0)
				{
					// Instruction address 0x0000:0x1617, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Static.Technologies[i].Name);
				}
			}

			// Instruction address 0x0000:0x1630, size: 5
			this.oParent.Array_30b8[3] = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x1645, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_01ad(0x3348, 0x3342);

			// Instruction address 0x0000:0x164d, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0471();

			this.oParent.Var_aa_Rectangle.FontID = 6;

			local_2 = -1;
			local_4 = -1;

			// Instruction address 0x0000:0x1668, size: 5
			local_8 = (short)this.oParent.MSCAPI.strlen(0xba06);

			do
			{
				local_4 = local_2 + 1;

				do
				{
					local_2++;
				}
				while (this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(local_2 + 0xba06)) != 0x5e && local_2 < local_8);

				if (local_2 < local_8)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(local_2 + 0xba06), 0x0);
				}

				if (local_2 < local_8)
				{
					// Instruction address 0x0000:0x16c3, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 6, 320, 20, this.oParent.Var_aa_Rectangle, 0, 6);

					// Instruction address 0x0000:0x16e5, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA((ushort)(0xba06 + local_4), 160, 7, 15);

					// Instruction address 0x0000:0x1700, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA((ushort)(0xba06 + local_4), 160, 9, 13);

					// Instruction address 0x0000:0x173b, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA((ushort)(0xba06 + local_4), 160, 8, 14);

					// Instruction address 0x0000:0x174d, size: 5
					if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(local_2 + 0xba05)) != 0x21 && this.oParent.MSCAPI.kbhit() == 0)
					{
						// Instruction address 0x0000:0x175a, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(200);
					}
				}
			}
			while (local_2 < local_8);

			// Instruction address 0x0000:0x1771, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			// Instruction address 0x0000:0x178c, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(
				this.oGameData.Static.Nations[this.oGameData.Players[this.oGameData.HumanPlayerID].NationalityID].ShortTune, 0);

			// Instruction address 0x0000:0x1798, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(300);

			// Instruction address 0x0000:0x17a4, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			// Instruction address 0x0000:0x17bf, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x17c7, size: 5
			this.oParent.Segment_1238.F0_1238_1beb();

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Far return
			this.oCPU.Log.ExitBlock("F2_0000_152a");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F2_0000_17d9()
		{
			this.oCPU.Log.EnterBlock("F2_0000_17d9()");

			// function body
			int local_a;
			int local_c;

			// Instruction address 0x0000:0x17e0, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			local_a = this.oParent.Var_d4cc_XPos + 7;
			local_c = this.oParent.Var_d75e_YPos + 6;

			for (int i = 1; i < 9; i++)
			{
				GPoint direction = TerrainMap.MoveOffsets[i];

				// Instruction address 0x0000:0x1809, size: 5
				int local_2 = this.oGameData.Map.WrapXPosition(local_a + direction.X);
				int local_4 = local_c + direction.Y;

				// Instruction address 0x0000:0x1822, size: 5
				TerrainTypeEnum local_8 = this.oGameData.Map[local_2, local_4].TerrainType;

				// Instruction address 0x0000:0x183d, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Map[local_2, local_4].TerrainName);

				// Instruction address 0x0000:0x1875, size: 5
				if (this.oParent.MapManagement.F0_2aea_1894(local_2, local_4, local_8) != 0)
				{
					// Instruction address 0x0000:0x1889, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, "Village");
				}

				direction = TerrainMap.MoveOffsets[i];

				F2_0000_195a(
					(direction.X * 16) + 200, (direction.Y * 16) + 112,
					(direction.X * 64) + 170, (direction.Y * 48) + 100);
			}

			// Instruction address 0x0000:0x18de, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Menu Bar");

			F2_0000_195a(160, 6, 200, 16);

			// Instruction address 0x0000:0x1905, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Map Window");

			F2_0000_195a(48, 32, 88, 24);

			// Instruction address 0x0000:0x192c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Active Unit");

			F2_0000_195a(40, 128, 88, 170);
			
			// Instruction address 0x0000:0x194b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x1950, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Far return
			this.oCPU.Log.ExitBlock("F2_0000_17d9");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <param name="xPos2"></param>
		/// <param name="yPos2"></param>
		public void F2_0000_195a(int xPos1, int yPos1, int xPos2, int yPos2)
		{
			this.oCPU.Log.EnterBlock($"F2_0000_195a({xPos1}, {yPos1}, {xPos2}, {yPos2})");

			// function body			
			// Instruction address 0x0000:0x1971, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos1, yPos1, xPos2, yPos2 + 6, 15);

			// Instruction address 0x0000:0x1981, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

			this.oParent.Var_db38 = 1;

			// Instruction address 0x0000:0x1999, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, xPos2, yPos2, 1);

			// Far return
			this.oCPU.Log.ExitBlock("F2_0000_195a");
		}
	}
}
