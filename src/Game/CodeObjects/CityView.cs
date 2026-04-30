using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System;

namespace OpenCiv1
{
	public class CityView
	{
		private OpenCiv1Game parent;
		private VCPU CPU;

		private int[] Array_4f42_Offsets = { -96, -36, 0, -56};

		private int[] Array_6880_Roads = new int[16];
		private int[] Array_817a_Houses = new int[20];
		private int[] Array_81a2_Buildings = new int[23];
		private int[] Array_68a0_Wonders = new int[22];
		private GRectangle[] wonderRectangles = { 
			new(0, 0, 0, 0),
			new(131, 54, 318, 82),
			new(159, 149, 227, 198),
			new(88, 97, 211, 135),
			new(229, 116, 268, 198),
			new(61, 117, 101, 172),
			new(164, 97, 227, 147),
			new(1, 38, 66, 118),
			new(268, 53, 318, 114),
			new(9, 117, 59, 172),
			new(126, 1, 182, 53),
			new(276, 1, 318, 51),
			new(103, 139, 157, 198),
			new(184, 1, 224, 69),
			new(40, 69, 101, 115),
			new(1, 14, 147, 33),
			new(253, 1, 274, 47),
			new(226, 1, 251, 47),
			new(103, 79, 162, 137),
			new(270, 116, 318, 198),
			new(63, 1, 124, 54),
			new(240, 60, 266, 114)};

		public CityView(OpenCiv1Game parent)
		{
			this.parent = parent;
			this.CPU = parent.CPU;
		}
		
		/// <summary>
		/// Shows the city layout with buildings, streets, wonders, etc.
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="wonderID"></param>
		public void F19_0000_0000_ShowCityLayout(int cityID, int wonderID, string? message)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_0000({cityID}, {wonderID})");

			// function body
			City city = this.parent.GameData.Cities[cityID];

			int technologyCount = this.parent.GameData.Players[city.PlayerID].DiscoveredTechnologyCount >> 1;
			int[,] cityLayout = new int[19, 12];
			int x1, y1, x2, y2, y3;

			for (int i = 0; i < 19; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					cityLayout[i, j] = -1;
				}
			}

			// RNG based on city name
			RandomMT19937 oRNG = new RandomMT19937(this.parent.Segment_2459.F0_2459_08c6_GetCityName(cityID).GetHashCode());

			x1 = 9;
			y1 = 11;

			for (int i = 0, j = 0; (city.ActualSize << 3) > i; i++)
			{
				if (cityLayout[x1, y1] != -1)
				{
					j++;

					if (j < 999)
					{
						i--;
					}
				}
				else
				{
					// Instruction address 0x0000:0x0195, size: 5
					int combinedPosition = this.parent.Segment_2dc4.F0_2dc4_0208_GetShortestDistance(x1 - 9, y1 - 10);

					cityLayout[x1, y1] = Math.Min(Math.Max(((technologyCount - combinedPosition) / 3) - oRNG.Next(2), technologyCount / 6),
						Math.Min((city.ActualSize / 4) + 6, 9));

					if ((combinedPosition * combinedPosition) > ((int)city.ActualSize << 3))
					{
						x1 = 9;
						y1 = 11;
					}
				}

				GPoint direction = this.parent.MoveDirections[oRNG.Next(8) + 1];

				x1 = Math.Min(Math.Max(x1 + direction.X, 0), 18);
				y1 = Math.Min(Math.Max(y1 + direction.Y, 0), 11);
			}

			y2 = 4 + oRNG.Next(2);

			for (int i = 2; i < 17; i++)
			{
				cityLayout[i, y2] = -2;
			}

			cityLayout[18, y2] = -1;
			cityLayout[0, y2] = -1;

			y2 = 8 + oRNG.Next(2);
			y3 = y2;

			for (int i = 2; i < 17; i++)
			{
				cityLayout[i, y2] = -2;
			}

			cityLayout[18, y2] = -1;
			cityLayout[0, y2] = -1;

			x2 = 9 + oRNG.Next(4);

			for (int i = 1; i < 12; i++)
			{
				cityLayout[x2 - ((i + 1) >> 1), i] = -2;
			}

			x2 = 14 + oRNG.Next(4);

			for (int i = 1; i < 12; i++)
			{
				cityLayout[x2 - ((i + 1) >> 1), i] = -2;
			}

			if (cityID == this.parent.GameData.WonderCityID[7])
			{
				cityLayout[0, 0] = 15;
				cityLayout[0, 1] = 15;
				cityLayout[0, 2] = 15;
				cityLayout[1, 0] = 15;
				cityLayout[1, 1] = 15;
				cityLayout[2, 0] = 15;
			}

			for (int i = 1; i <= 21; i++)
			{
				if (this.parent.GameData.WonderCityID[i] == cityID && ((1 << i) & 0x808a) == 0)
				{
					int j = 0;

					for (; j < 500; j++)
					{
						x1 = oRNG.Next(15) + 1;
						y1 = oRNG.Next(10) + 1;

						int iFlags = 0;

						if (cityLayout[x1 - 1, y1 + 1] >= 0 || cityLayout[x1, y1] >= 0 ||
							cityLayout[x1, y1 + 1] >= 0 || cityLayout[x1 + 1, y1] >= 0 ||
							cityLayout[x1 + 1, y1 + 1] >= 0 || cityLayout[x1 + 2, y1] >= 0 ||
							j > 400)
						{
							iFlags |= 1;
						}

						if (cityLayout[x1 - 1, y1 + 1] >= 15 || cityLayout[x1, y1] >= 15 ||
							cityLayout[x1, y1 + 1] >= 15 || cityLayout[x1 + 1, y1] >= 15 ||
							cityLayout[x1 + 1, y1 + 1] >= 15 || cityLayout[x1 + 2, y1] >= 15 ||
							cityLayout[x1 + 2, y1 + 1] >= 15 ||
							cityLayout[x1 - 1, y1 + 1] == -2 || cityLayout[x1, y1] == -2 ||
							cityLayout[x1, y1 + 1] == -2 || cityLayout[x1 + 1, y1] == -2 ||
							cityLayout[x1 + 1, y1 + 1] == -2)
						{
							iFlags |= 2;
						}

						if (iFlags == 1)
							break;
					}

					if (j < 500)
					{
						cityLayout[x1 - 1, y1 + 1] = 15;
						cityLayout[x1, y1] = i + 64;
						cityLayout[x1, y1 + 1] = 15;
						cityLayout[x1 + 1, y1] = 15;
						cityLayout[x1 + 1, y1 + 1] = 15;
						cityLayout[x1 + 1, y1 - 1] = 15;
						cityLayout[x1 + 2, y1] = 15;
						cityLayout[x1 + 2, y1 - 1] = 15;
						cityLayout[x1 + 2, y1 + 1] = 15;
						cityLayout[x1 + 3, y1 - 1] = 15;

						if (y1 < 7 && (cityLayout[x1 + 1, y1 + 2] & 7) == 0)
						{
							cityLayout[x1 + 1, y1 + 2] = -1;
						}
					}
				}
			}

			ImprovementEnum[] improvements = Enum.GetValues<ImprovementEnum>();

			for (int i = 0; i < improvements.Length; i++)
			{
				if (improvements[i] != ImprovementEnum.CityWalls && improvements[i] != ImprovementEnum.Aqueduct &&
					improvements[i] != ImprovementEnum.MassTransit && improvements[i] != ImprovementEnum.PowerPlant &&
					improvements[i] != ImprovementEnum.HydroPlant && city.HasImprovement(improvements[i]))
				{
					int j;

					for (j = 0; j < 500; j++)
					{
						x1 = oRNG.Next(16) + 1;
						y1 = oRNG.Next(10) + 1;

						int iFlags = 0;

						if (cityLayout[x1 - 1, y1 + 1] >= 0 || cityLayout[x1, y1] >= 0 ||
							cityLayout[x1, y1 + 1] >= 0 || cityLayout[x1 + 1, y1] >= 0 ||
							cityLayout[x1 + 1, y1 + 1] >= 0 ||
							j > 350)
						{
							iFlags |= 1;
						}

						if (cityLayout[x1 - 1, y1 + 1] >= 15 || cityLayout[x1, y1] >= 15 ||
							cityLayout[x1, y1 + 1] >= 15 || cityLayout[x1 + 1, y1] >= 15 ||
							cityLayout[x1 + 1, y1 + 1] >= 15 ||
							cityLayout[x1 - 1, y1 + 1] == -2 || cityLayout[x1, y1] == -2 ||
							cityLayout[x1, y1 + 1] == -2 || cityLayout[x1 + 1, y1] == -2 ||
							cityLayout[x1 + 1, y1 + 1] == -2)
						{
							iFlags |= 2;
						}

						if (iFlags == 1)
							break;
					}

					if (j < 500)
					{
						cityLayout[x1 - 1, y1 + 1] = 15;
						cityLayout[x1, y1] = 14 + (int)improvements[i];
						cityLayout[x1, y1 + 1] = 15;
						cityLayout[x1 + 1, y1] = 15;
						cityLayout[x1 + 1, y1 + 1] = 15;

						if (y1 < 7)
						{
							if ((cityLayout[x1 + 1, y1 + 2] & 7) == 0)
							{
								cityLayout[x1 + 1, y1 + 2] = -1;
							}
						}
					}
				}
			}

			if (city.HasImprovement(ImprovementEnum.HydroPlant))
			{
				cityLayout[17, 7] = 34;
				cityLayout[17, 8] = 15;
				cityLayout[18, 7] = 15;
				cityLayout[18, 8] = 15;
			}

			if (city.HasImprovement(ImprovementEnum.Aqueduct))
			{
				cityLayout[0, y3 - 1] = 23;
				cityLayout[0, y3] = 15;
				cityLayout[1, y3] = 15;
				cityLayout[1, y3 + 1] = 15;
				cityLayout[2, y3] = 15;
				cityLayout[2, y3 + 1] = 15;
			}

			// Instruction address 0x0000:0x08e4, size: 5
			this.parent.Segment_2dc4.F0_2dc4_065f_StopPaletteCycleSlots();

			F19_0000_137f_LoadCityViewBitmaps(wonderID, city.PlayerID, cityID);

			bool initFlag = false;

			do
			{
				// Instruction address 0x0000:0x091b, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "HILL.PIC", 0);

				for (int i = 1; i < 8; i++)
				{
					int wonderID1 = i;

					if (i == 2)
					{
						wonderID1 = 15;
					}

					if (this.parent.GameData.WonderCityID[wonderID1] == cityID)
					{
						if ((wonderID1 + 24) != wonderID)
						{
							if (((1 << wonderID1) & 0x808a) != 0)
							{
								// Instruction address 0x0000:0x09d4, size: 5
								this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
									((wonderID1 == 3) ? 80 : 0) + ((this.wonderRectangles[wonderID1].X < 10) ? -1 : 2) + this.wonderRectangles[wonderID1].X,
									((wonderID1 <= 7) ? 0 : (this.wonderRectangles[wonderID1].Y - 6)),
									this.Array_68a0_Wonders[wonderID1]);
							}
						}
					}
				}

				if (city.HasImprovement(ImprovementEnum.PowerPlant) && wonderID != 19)
				{
					for (int i = (cityID == this.parent.GameData.WonderCityID[7]) ? 69 : 0; i < 310; i += 45)
					{
						// Instruction address 0x0000:0x0a1a, size: 5
						this.parent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
							i, 2, this.Array_81a2_Buildings[17]);
					}
				}

				for (y1 = 0; y1 < 12; y1++)
				{
					for (x1 = 0; x1 < 19; x1++)
					{
						int layoutElement = cityLayout[x1, y1];

						if (layoutElement == -2)
						{
							int iDirection = 0;

							for (int i = 1; i < 9; i++)
							{
								int iPrefixTemp;
								GPoint direction = this.parent.MoveDirections[i];

								if ((y1 & 0x1) == 0)
								{
									iPrefixTemp = ((direction.Y <= 0) ? 0 : -1);
								}
								else
								{
									iPrefixTemp = (direction.Y >= 0) ? 0 : 1;
								}

								int iXTemp = x1 + iPrefixTemp + direction.X;
								int iYTemp = y1 + direction.Y;

								if (iYTemp < 12 && cityLayout[iXTemp, iYTemp] >= 0)
								{
									iDirection = 1;
								}
							}

							if (iDirection == 0)
							{
								cityLayout[x1, y1] = -1;
							}
						}
					}
				}

				for (y1 = 0; y1 < 12; y1++)
				{
					for (x1 = 0; x1 < 19; x1++)
					{
						int layoutElement = cityLayout[x1, y1];

						if (layoutElement == -1 && x1 > 2 && cityLayout[x1 - 1, y1] != -1 && ((x1 + y1) & 1) != 0)
						{
							F19_0000_0ff4_DrawRoad(x1, y1, 0);
						}

						if (layoutElement != -1 && layoutElement != 15)
						{
							if (layoutElement != -2)
							{
								if (layoutElement >= 16)
								{
									if (wonderID + 14 != layoutElement && wonderID + 40 != layoutElement)
									{
										F19_0000_106c_DrawWonder(x1, y1, (ushort)(layoutElement - 16));
									}
								}
								else if (layoutElement >= 2)
								{
									F19_0000_102e_DrawBuilding(x1, y1, (((x1 + y1) & 1) + ((layoutElement & 1) << 1)), (layoutElement >> 1));
								}
								else
								{
									F19_0000_102e_DrawBuilding(x1, y1, (((layoutElement & 1) << 1) + (cityID & 1)), (layoutElement >> 1));
								}
							}
							else
							{
								int iFlag = 0;

								for (int i = 1; i < 9; i++)
								{
									int iPrefixTemp;
									GPoint direction = this.parent.MoveDirections[i];

									if ((y1 & 1) == 0)
									{
										iPrefixTemp = (direction.Y <= 0) ? 0 : -1;
									}
									else
									{
										iPrefixTemp = (direction.Y >= 0) ? 0 : 1;
									}

									int iXTemp = x1 + iPrefixTemp + direction.X;
									int iYTemp = y1 + direction.Y;

									if ((i & 1) != 0)
									{
										iFlag >>= 1;

										if (iYTemp < 12 && cityLayout[iXTemp, iYTemp] == -2)
										{
											iFlag |= 8;
										}
									}
								}

								F19_0000_0ff4_DrawRoad(x1, y1, (ushort)iFlag);
							}
						}
					}
				}
				
				if (city.HasImprovement(ImprovementEnum.CityWalls) && wonderID != 8)
				{
					for (int i = 0; i < 320; i += 43)
					{
						if (i == 172)
						{
							i += 19;
						}

						// Instruction address 0x0000:0x0ce2, size: 5
						this.parent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
							i, 108, this.Array_81a2_Buildings[22]);
					}

					// Instruction address 0x0000:0x0d07, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
						142, 108, this.Array_81a2_Buildings[6]);
				}

				if (city.HasImprovement(ImprovementEnum.MassTransit) && wonderID != 13)
				{
					for (int i = 0; i < 310; i += 46)
					{
						// Instruction address 0x0000:0x0d3b, size: 5
						this.parent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
							i, 115, this.Array_81a2_Buildings[15]);
					}

					// Instruction address 0x0000:0x0d5f, size: 5
					this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
						0, 115, this.Array_81a2_Buildings[11]);
				}

				this.parent.Var_aa_Screen0_Rectangle.ScreenID = 1;
				this.parent.Var_aa_Screen0_Rectangle.FontID = 6;

				if (string.IsNullOrEmpty(message))
				{
					// Instruction address 0x0000:0x0db1, size: 5
					this.parent.DrawStringTools.F0_1182_00b3_DrawCenteredStringWithShadowToScreen0(
						$"{this.parent.Segment_2459.F0_2459_08c6_GetCityName(cityID)} ({this.parent.Segment_1238.F0_1238_1720_GetCurrentYearAsString()})", 160, 2, 15);
				}
				else
				{
					this.parent.Var_db38 = 1;

					// Instruction address 0x0000:0x0e03, size: 5
					this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(message, 80, 8, true, false, true);
				}

				this.parent.Var_aa_Screen0_Rectangle.ScreenID = 0;
				this.parent.Var_aa_Screen0_Rectangle.FontID = 1;

				if (initFlag)
				{
					// Instruction address 0x0000:0x0e2c, size: 5
					this.parent.CommonTools.F0_1000_0a32_PlayTune(44, 0);

					// Instruction address 0x0000:0x0e3c, size: 5
					this.parent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(1);
				}
				else
				{
					// Instruction address 0x0000:0x0e5a, size: 5
					this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 0);

					if (wonderID != -3)
					{
						// Instruction address 0x0000:0x0e6c, size: 5
						this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "hill.pic", 1);
					}

					// Instruction address 0x0000:0x0e8c, size: 5
					this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 200, this.parent.Var_aa_Screen0_Rectangle, 0, 0);

					if (wonderID == -3)
					{
						byte[] palette;

						// Instruction address 0x0000:0x0ea9, size: 5
						this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "hill.pal", out palette);

						// Instruction address 0x0000:0x0eb9, size: 5
						this.parent.CommonTools.F0_1000_04aa_TransformPalette(15, palette);
					}

					// Instruction address 0x0000:0x0ed8, size: 5
					this.parent.CommonTools.F0_1000_0382_AddPaletteCycleSlot(4, 15, 64, 79);

					// Instruction address 0x0000:0x0ee4, size: 5
					this.parent.CommonTools.F0_1000_03fa_StartPaletteCycleSlot(4);
				}

				if (wonderID == -1 && !initFlag)
				{
					F19_0000_111f_DrawCityPopulation(cityID, 24, 140, 256);
				}

				if (wonderID <= -1 || this.parent.CAPI.kbhit() != 0)
					break;

				wonderID = -1;
				initFlag = true;

				// Instruction address 0x0000:0x0f3d, size: 5
				this.parent.CommonTools.F0_1182_0134_WaitTimer(60);
			}
			while (this.parent.CAPI.kbhit() == 0);

			if (wonderID == -2)
			{
				// Instruction address 0x0000:0x0fe6, size: 5
				this.parent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(4);
			}
			else
			{
				if (this.parent.CAPI.kbhit() != 0)
				{
					// Instruction address 0x0000:0x0f84, size: 5
					this.parent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();
				}
				else
				{
					// Instruction address 0x0000:0x0f7d, size: 5
					this.parent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
				}

				// Instruction address 0x0000:0x0f94, size: 5
				this.parent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(4);

				// Instruction address 0x0000:0x0fc7, size: 5
				this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 0);

				// Instruction address 0x0000:0x0fcf, size: 5
				this.parent.Segment_1238.F0_1238_1beb();

				// Instruction address 0x0000:0x0fd4, size: 5
				this.parent.Segment_2dc4.F0_2dc4_0626_StartPaletteCycleSlots();
			}

			for (int i = 0; i < 20; i++)
			{
				this.parent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.Array_817a_Houses[i], "City layout");
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="bitmapID"></param>
		public void F19_0000_0ff4_DrawRoad(int x, int y, ushort bitmapID)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_0ff4({xPos}, {yPos}, {bitmapID})");

			// function body
			// Instruction address 0x0000:0x1024, size: 5
			this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
				((y & 1) * 8) + (x * 16) - 5, (y * 8) + 50, this.Array_6880_Roads[bitmapID]);
		}
		
		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="bitmapID1"></param>
		/// <param name="bitmapID2"></param>
		public void F19_0000_102e_DrawBuilding(int x, int y, int bitmapID1, int bitmapID2)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_102e({xPos}, {yPos}, {bitmapID1}, {bitmapID2})");

			// function body
			// Instruction address 0x0000:0x1061, size: 5
			this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
				((y & 1) << 3) + (x << 4), (y << 3) + 26, this.Array_817a_Houses[bitmapID1 + (bitmapID2 * 4)]);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="bitmapID"></param>
		public void F19_0000_106c_DrawWonder(int x, int y, ushort bitmapID)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_106c({xPos}, {yPos}, {bitmapID})");

			// function body
			if (bitmapID < 48)
			{
				// Instruction address 0x0000:0x10b2, size: 5
				this.parent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
					this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((y & 1) * 8) + (x * 16) - 9, 0, 999), 16 + (y << 3),
					this.Array_81a2_Buildings[bitmapID]);

			}
			else
			{
				bitmapID -= 48;
				y = 76 + (y * 8) - this.wonderRectangles[bitmapID].Height;

				// Instruction address 0x0000:0x1115, size: 5
				this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
					this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((y & 1) * 8) + (x * 16) - 9, 0, 999), y - 10,
					this.Array_68a0_Wonders[bitmapID]);
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="param4"></param>
		public void F19_0000_111f_DrawCityPopulation(int cityID, int x, int y, int param4)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_111f({cityID}, {x}, {y}, {param4})");

			// function body
			// Instruction address 0x0000:0x1133, size: 5
			this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "POP.PIC", 0);

			int[] bitmaps = new int[9];

			for (int i = 0; i < 9; i++)
			{
				// Instruction address 0x0000:0x117b, size: 5
				if (!this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.parent.GameData.HumanPlayerID, TechnologyEnum.Industrialization))
				{
					// Instruction address 0x0000:0x1152, size: 5
					bitmaps[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (35 * i) + 1, 52, 34, 50);
				}
				else
				{
					// Instruction address 0x0000:0x1152, size: 5
					bitmaps[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (35 * i) + 1, 1, 34, 50);
				}
			}

			int xStep;
			int cityActualSize = this.parent.GameData.Cities[cityID].ActualSize;
			
			if (cityActualSize * 12 > param4)
			{
				xStep = param4 / cityActualSize;
			}
			else
			{
				xStep = 12;
			}

			int local_2 = this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.parent.Var_70e2, 0, this.parent.GameData.Cities[cityID].ActualSize);
			int local_4 = this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.parent.Var_70e4, 0, this.parent.GameData.Cities[cityID].ActualSize);

			while (local_2 + local_4 > this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.parent.GameData.Cities[cityID].ActualSize - this.parent.Var_e8b8, 0, 99))
			{
				local_2--;

				// Instruction address 0x0000:0x11fc, size: 5
				local_2 = this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_2, 0, this.parent.GameData.Cities[cityID].ActualSize);

				local_4--;

				// Instruction address 0x0000:0x1214, size: 5
				local_4 = this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_4, 0, this.parent.GameData.Cities[cityID].ActualSize);
			}

			for (int i = 0; i < local_2; i++)
			{
				// Instruction address 0x0000:0x1270, size: 5
				this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, x, y, bitmaps[i & 0x1]);

				x += xStep;
			}

			if (local_2 != 0)
			{
				x += 8;
			}
		
			int j;

			for (j = 0; (this.parent.GameData.Cities[cityID].ActualSize - local_2 - local_4 - this.parent.Var_e8b8) > j; j++)
			{
				// Instruction address 0x0000:0x12b6, size: 5
				this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, x, y, bitmaps[2 + (j & 0x1)]);

				x += xStep;
			}

			if (j != 0)
			{
				x += 8;
			}

			for (int i = 0; i < local_4; i++)
			{
				// Instruction address 0x0000:0x1312, size: 5
				this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle, x, y, bitmaps[4 + (i & 0x1)]);

				x += xStep;
			}

			x += 12;

			for (int i = 0; i < this.parent.Var_e8b8; i++)
			{
				// Instruction address 0x0000:0x1352, size: 5
				this.parent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.parent.Var_aa_Screen0_Rectangle,
					x, y, bitmaps[5 + this.parent.CityWorker.F0_1d12_6da1_GetSpecialWorkerFlags(i)]);

				x += xStep;
			}

			for (int i = 0; i < 9; i++)
			{
				// Instruction address 0x0000:0x1372, size: 5
				this.parent.Segment_2dc4.F0_2dc4_0523_FreeResource(bitmaps[i], "Draw city population");
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="wonderID"></param>
		/// <param name="playerID"></param>
		/// <param name="cityID"></param>
		public void F19_0000_137f_LoadCityViewBitmaps(int wonderID, int playerID, int cityID)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_137f({wonderID}, {playerID}, {cityID})");

			// function body
			// Instruction address 0x0000:0x1394, size: 5
			this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "CITYPIX1.PIC", 0);

			for (int i = 0; i < 5; i++)
			{
				int x = i * 64;

				this.Array_817a_Houses[i * 4] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 1 + x, 1, 31, 31);
				this.Array_817a_Houses[1 + i * 4] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 33 + x, 1, 31, 31);
				this.Array_817a_Houses[2 + i * 4] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 1 + x, 33, 31, 31);
				this.Array_817a_Houses[3 + i * 4] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 33 + x, 33, 31, 31);
			}

			for (int i = 0; i < 16; i++)
			{
				int x = i % 8;
				int y = i - x;

				// Instruction address 0x0000:0x1488, size: 5
				if (!this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Automobile))
				{
					// Instruction address 0x0000:0x145f, size: 5
					this.Array_6880_Roads[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, x * 24, 65 + y, 24, 8);
				}
				else
				{
					// Instruction address 0x0000:0x145f, size: 5
					this.Array_6880_Roads[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, x * 24, 81 + y, 24, 8);
				}
			}

			// Instruction address 0x0000:0x14a0, size: 5
			if (this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Combustion))
			{
				// Instruction address 0x0000:0x14b9, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "CITYPIX3.PIC", 0);
			}
			else
			{
				// Instruction address 0x0000:0x14b9, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "CITYPIX2.PIC", 0);
			}

			for (int i = 0; i < 23; i++)
			{
				if (this.parent.GameData.Cities[cityID].HasImprovement(City.BitToImprovementEnum((i + 1))) || wonderID - 1 == i || i > 20)
				{
					// Instruction address 0x0000:0x1529, size: 5
					this.Array_81a2_Buildings [i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i >> 2) * 50) + 1, ((i & 0x3) * 50) + 1, 49, 49);
				}
			}

			// Instruction address 0x0000:0x1576, size: 5
			this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "WONDERS.PIC", 0);

			for (int i = 1; i < 22; i++)
			{
				if (this.parent.GameData.WonderCityID[i] == cityID)
				{
					if (((0x1 << i) & 0x808a) == 0)
					{
						this.Array_68a0_Wonders[i] = F19_0000_1606_GetWonderBitmap(i);
					}
				}
			}

			// Instruction address 0x0000:0x15d2, size: 5
			this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "WONDERS2.PIC", 0);

			for (int i = 1; i < 22; i++)
			{
				if (this.parent.GameData.WonderCityID[i] == cityID)
				{
					if (((0x1 << i) & 0x808a) != 0)
					{
						this.Array_68a0_Wonders[i] = F19_0000_1606_GetWonderBitmap(i);
					}
				}
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="wonderID"></param>
		public int F19_0000_1606_GetWonderBitmap(int wonderID)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_1606({WonderID})");

			// function body
			if (this.wonderRectangles[1].Width > 300)
			{
				for (int i = 1; i < 22; i++)
				{
					this.wonderRectangles[i].Width -= this.wonderRectangles[i].X + 1;

					this.wonderRectangles[i].Height -= this.wonderRectangles[i].Y + 1;
				}
			}

			// Instruction address 0x0000:0x166e, size: 5
			return this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.wonderRectangles[wonderID].X, this.wonderRectangles[wonderID].Y,
				this.wonderRectangles[wonderID].Width, this.wonderRectangles[wonderID].Height);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F19_0000_167b_InvadersAnimation(int playerID)
		{
			//this.oCPU.Log.EnterBlock($"F19_0000_167b({playerID})");

			// function body
			// Instruction address 0x0000:0x1682, size: 5
			this.parent.Segment_2dc4.F0_2dc4_065f_StopPaletteCycleSlots();

			// Instruction address 0x0000:0x1698, size: 5
			this.parent.Graphics.SetPaletteColor(0xfd, GBitmap.Color18ToColor(3, 3, 3));

			// Instruction address 0x0000:0x16a5, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			int[] bitmaps = new int[10];

			// Instruction address 0x0000:0x16b1, size: 5
			if (this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Gunpowder))
			{
				if (this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Automobile))
				{
					// Instruction address 0x0000:0x16e0, size: 5
					this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "INVADERS.PIC", 0);
				}
				else
				{
					// Instruction address 0x0000:0x16e0, size: 5
					this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "INVADER2.PIC", 0);
				}

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x1731, size: 5
					bitmaps[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i % 4) * 79, 2 + ((i >> 2) * 61), 78, 60);
				}
			}
			else
			{
				// Instruction address 0x0000:0x174b, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "INVADER3.PIC", 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x178e, size: 5
					bitmaps[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 1 + ((i % 4) * 79), 1 + ((i >> 2) * 66), 78, 65);
				}
			}

			// Instruction address 0x0000:0x17c7, size: 5
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_aa_Screen0_Rectangle, 0, 100, 320, 100, this.parent.Var_19d4_Screen1_Rectangle, 0, 0);

			for (int i = 0, j = 0; i < 660; i += 3, j++)
			{
				// Instruction address 0x0000:0x17e9, size: 5
				this.parent.CommonTools.F0_1000_033e_ResetWaitTimer();

				// Instruction address 0x0000:0x1809, size: 5
				this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 100, this.parent.Var_19d4_Screen1_Rectangle, 0, 100);

				for (int k = 7; k >= 0; k--)
				{
					int x = i - (48 * k);

					if (x > -48 && x < 320)
					{
						// Instruction address 0x0000:0x184a, size: 5
						this.parent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle, x, 132, bitmaps[j % 10]);
					}
				}

				// Instruction address 0x0000:0x1875, size: 5
				this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 100, 320, 100, this.parent.Var_aa_Screen0_Rectangle, 0, 100);

				while (this.parent.Var_5c_TickCount < 10)
				{
					this.CPU.DoEvents();
					Thread.Sleep(1);
				}

				// Instruction address 0x0000:0x188a, size: 5
				this.parent.MainCode.F0_11a8_0223_UpdateMouseState();

				// Instruction address 0x0000:0x188f, size: 5
				if (this.parent.CAPI.kbhit() != 0 || this.parent.Var_db3a_MouseButton != 0)
					break;
			}

			// Instruction address 0x0000:0x18a2, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();

			// Instruction address 0x0000:0x18a7, size: 5
			this.parent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();

			// Instruction address 0x0000:0x18b7, size: 5
			this.parent.Segment_2dc4.F0_2dc4_0626_StartPaletteCycleSlots();

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x1ad4, size: 5
				this.parent.Segment_2dc4.F0_2dc4_0523_FreeResource(bitmaps[i], "Invaders");
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F19_0000_18c1_CivilDisorderAnimation()
		{
			//this.oCPU.Log.EnterBlock("F19_0000_18c1_CivilDisorderAnimation()");

			// function body
			int[] bitmaps = new int[10];

			// Instruction address 0x0000:0x18c8, size: 5
			this.parent.Segment_2dc4.F0_2dc4_065f_StopPaletteCycleSlots();

			// Instruction address 0x0000:0x18cd, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			// Instruction address 0x0000:0x18df, size: 5
			if (this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.parent.GameData.HumanPlayerID, TechnologyEnum.University))
			{
				// Instruction address 0x0000:0x18f3, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "RIOT.PIC", 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x1943, size: 5
					bitmaps[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i % 4) * 79) + 1, ((i >> 2) * 64) + 1, 78, 63);
				}
			}
			else
			{
				// Instruction address 0x0000:0x195d, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "RIOT2.PIC", 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x19a0, size: 5
					bitmaps[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i % 4) * 75) + 1, ((i >> 2) * 66) + 1, 74, 65);
				}
			}

			// Draw City View to screen 0
			// Instruction address 0x0000:0x19d9, size: 5
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_aa_Screen0_Rectangle, 0, 100, 320, 100, this.parent.Var_19d4_Screen1_Rectangle, 0, 0);

			for (int i = -48, j = 0; i < 420; i += 3, j++)
			{
				// Instruction address 0x0000:0x19fb, size: 5
				this.parent.CommonTools.F0_1000_033e_ResetWaitTimer();

				// Draw a lower portion of City View to screen 0
				// Instruction address 0x0000:0x1a1b, size: 5
				this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 100, this.parent.Var_19d4_Screen1_Rectangle, 0, 100);

				for (int k = 0; k < 4; k++)
				{
					int x = this.Array_4f42_Offsets[k] + i;

					if (x > -48 && x < 320)
					{
						// Instruction address 0x0000:0x1a6b, size: 5
						this.parent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
							x, 132 + -6 + (k * 2), bitmaps[(k * 3 + j) % 10]);
					}				
				}

				// Draw a lower portion of City View to screen 0
				// Instruction address 0x0000:0x1a9a, size: 5
				this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 100, 320, 100, this.parent.Var_aa_Screen0_Rectangle, 0, 100);

				while (this.parent.Var_5c_TickCount < 10)
				{
					this.CPU.DoEvents();
					Thread.Sleep(1);
				}

				// Instruction address 0x0000:0x1aaf, size: 5
				this.parent.MainCode.F0_11a8_0223_UpdateMouseState();

				// Instruction address 0x0000:0x1ab4, size: 5
				if (this.parent.CAPI.kbhit() != 0 || this.parent.Var_db3a_MouseButton != 0)
					break;
			}

			// Instruction address 0x0000:0x1ac7, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();

			// Instruction address 0x0000:0x1acc, size: 5
			this.parent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x1ad4, size: 5
				this.parent.Segment_2dc4.F0_2dc4_0523_FreeResource(bitmaps[i], "Civil disorder");
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F19_0000_1ae1_LoveOurLeaderAnimation()
		{
			//this.oCPU.Log.EnterBlock("F19_0000_1ae1()");

			// function body
			// Instruction address 0x0000:0x1ae8, size: 5
			this.parent.Segment_2dc4.F0_2dc4_065f_StopPaletteCycleSlots();

			// Instruction address 0x0000:0x1afa, size: 5
			if (!this.parent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.parent.GameData.HumanPlayerID, TechnologyEnum.Industrialization))
			{
				// Instruction address 0x0000:0x1b13, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "LOVE1.PIC", 0);
			}
			else
			{
				// Instruction address 0x0000:0x1b13, size: 5
				this.parent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "LOVE2.PIC", 0);
			}

			int[] bitmaps = new int[10];

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x1b56, size: 5
				bitmaps[i] = this.parent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 1 + ((i % 4) * 79), 1 + ((i >> 2) * 66), 78, 65);
			}

			// Instruction address 0x0000:0x1b74, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			// Instruction address 0x0000:0x1b94, size: 5
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_aa_Screen0_Rectangle, 0, 100, 320, 100, this.parent.Var_19d4_Screen1_Rectangle, 0, 0);

			for (int i = 420, j = 0; i > -48; i -= 3, j++)
			{
				// Instruction address 0x0000:0x1bb5, size: 5
				this.parent.CommonTools.F0_1000_033e_ResetWaitTimer();

				// Instruction address 0x0000:0x1bd5, size: 5
				this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 100, this.parent.Var_19d4_Screen1_Rectangle, 0, 100);

				for (int k = 0; k < 4; k++)
				{
					int x = (this.Array_4f42_Offsets[k] * 3) / 2 + i;

					if (x > -48 && x < 320)
					{
						// Instruction address 0x0000:0x1c2d, size: 5
						this.parent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.parent.Var_19d4_Screen1_Rectangle,
							x, 132 + -6 + (k * 2), bitmaps[(k * 3 + j) % 10]);
					}
				}

				// Instruction address 0x0000:0x1c5c, size: 5
				this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 100, 320, 100, this.parent.Var_aa_Screen0_Rectangle, 0, 100);

				while (this.parent.Var_5c_TickCount < 10)
				{
					this.CPU.DoEvents();
					Thread.Sleep(1);
				}

				// Instruction address 0x0000:0x1c71, size: 5
				this.parent.MainCode.F0_11a8_0223_UpdateMouseState();

				if (this.parent.CAPI.kbhit() != 0 || this.parent.Var_db3a_MouseButton != 0)
					break;
			}

			// Instruction address 0x0000:0x1c89, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();

			// Instruction address 0x0000:0x1c8e, size: 5
			this.parent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x1ad4, size: 5
				this.parent.Segment_2dc4.F0_2dc4_0523_FreeResource(bitmaps[i], "Love leader");
			}
		}
	}
}
