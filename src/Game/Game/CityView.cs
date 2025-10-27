using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class CityView
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		GPoint[] Array_4f42 = new GPoint[] { new GPoint(-96, -6), new GPoint(-36, -4), new GPoint(0, -2), new GPoint(-56, 0) };
		int[] Array_6880 = new int[16];
		int[] Array_68a0 = new int[22];
		int[] Array_817a = new int[20];
		int[] Array_81a2 = new int[23];

		GRectangle[] Array_0_3767 = new GRectangle[] {
			new GRectangle(0, 0, 0, 0),
			new GRectangle(131, 54, 318, 82),
			new GRectangle(159, 149, 227, 198),
			new GRectangle(88, 97, 211, 135),
			new GRectangle(229, 116, 268, 198),
			new GRectangle(61, 117, 101, 172),
			new GRectangle(164, 97, 227, 147),
			new GRectangle(1, 38, 66, 118),
			new GRectangle(268, 53, 318, 114),
			new GRectangle(9, 117, 59, 172),
			new GRectangle(126, 1, 182, 53),
			new GRectangle(276, 1, 318, 51),
			new GRectangle(103, 139, 157, 198),
			new GRectangle(184, 1, 224, 69),
			new GRectangle(40, 69, 101, 115),
			new GRectangle(1, 14, 147, 33),
			new GRectangle(253, 1, 274, 47),
			new GRectangle(226, 1, 251, 47),
			new GRectangle(103, 79, 162, 137),
			new GRectangle(270, 116, 318, 198),
			new GRectangle(63, 1, 124, 54),
			new GRectangle(240, 60, 266, 114) };

		public CityView(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// Draws the layout of the city
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="improvementID"></param>
		public void F19_0000_0000_DrawCityLayout(int cityID, short improvementID)
		{
			// function body
			this.oCPU.Log.EnterBlock($"F19_0000_0000_DrawCityLayout({cityID}, {improvementID})");

			string local_80;

			City city = this.oGameData.Cities[cityID];

			int technologyCount = this.oGameData.Players[city.PlayerID].DiscoveredTechnologyCount / 2;
			int[,] cityLayout = new int[19, 12];
			int xPos1, yPos1, xPos2, yPos2, i8;
			int iValue;

			// Bitmaps are initially unallocated
			for (int i = 0; i < 16; i++)
			{
				this.Array_6880[i] = 0;
			}

			for (int i = 0; i < 22; i++)
			{
				this.Array_68a0[i] = 0;
			}

			for (int i = 0; i < 20; i++)
			{
				this.Array_817a[i] = 0;
			}

			for (int i = 0; i < 23; i++)
			{
				this.Array_81a2[i] = 0;
			}

			// Initialize layout
			for (int i = 0; i < 19; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					cityLayout[i, j] = -1;
				}
			}

			local_80 = "";

			if (this.oParent.MSCAPI.strlen(0xba06) < 120)
			{
				// Instruction address 0x0000:0x004d, size: 5
				local_80 = this.oCPU.ReadString(this.oCPU.DS.UInt16, 0xba06);
			}

			// RNG based on city name
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);
			string sCityName = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0xba06));

			// We need predictable RNG for city layout (based on city name)
			RandomMT19937 oRNG = new RandomMT19937(sCityName.GetHashCode());

			xPos1 = 9;
			yPos1 = 11;

			for (int i = 0, j = 0; (city.ActualSize << 3) > i; i++)
			{
				if (cityLayout[xPos1, yPos1] != -1)
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
					int iCombinedPosition = this.oGameData.Map.GetDistance(xPos1 - 9, yPos1 - 10);

					cityLayout[xPos1, yPos1] = Math.Min(Math.Max(((technologyCount - iCombinedPosition) / 3) - oRNG.Next(2), technologyCount / 6),
						Math.Min((city.ActualSize / 4) + 6, 9));

					if ((iCombinedPosition * iCombinedPosition) > ((int)city.ActualSize << 3))
					{
						xPos1 = 9;
						yPos1 = 11;
					}
				}

				GPoint direction = TerrainMap.MoveOffsets[oRNG.Next(8) + 1];

				xPos1 = Math.Min(Math.Max(xPos1 + direction.X, 0), 18);
				yPos1 = Math.Min(Math.Max(yPos1 + direction.Y, 0), 11);
			}

			yPos2 = 4 + oRNG.Next(2);

			for (int i = 2; i < 17; i++)
			{
				cityLayout[i, yPos2] = -2;
			}

			cityLayout[18, yPos2] = -1;
			cityLayout[0, yPos2] = -1;

			yPos2 = 8 + oRNG.Next(2);
			i8 = yPos2;

			for (int i = 2; i < 17; i++)
			{
				cityLayout[i, yPos2] = -2;
			}

			cityLayout[18, yPos2] = -1;
			cityLayout[0, yPos2] = -1;

			xPos2 = 9 + oRNG.Next(4);

			for (int i = 1; i < 12; i++)
			{
				cityLayout[xPos2 - ((i + 1) >> 1), i] = -2;
			}

			xPos2 = 14 + oRNG.Next(4);

			for (int i = 1; i < 12; i++)
			{
				cityLayout[xPos2 - ((i + 1) >> 1), i] = -2;
			}

			if (cityID == this.oGameData.WonderCityID[7])
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
				if (this.oGameData.WonderCityID[i] == cityID && ((1 << i) & 0x808a) == 0)
				{
					int j = 0;

					for (; j < 500; j++)
					{
						xPos1 = oRNG.Next(15) + 1;
						yPos1 = oRNG.Next(10) + 1;

						int iFlags = 0;

						if (cityLayout[xPos1 - 1, yPos1 + 1] >= 0 || cityLayout[xPos1, yPos1] >= 0 ||
							cityLayout[xPos1, yPos1 + 1] >= 0 || cityLayout[xPos1 + 1, yPos1] >= 0 ||
							cityLayout[xPos1 + 1, yPos1 + 1] >= 0 || cityLayout[xPos1 + 2, yPos1] >= 0 ||
							j > 400)
						{
							iFlags |= 1;
						}

						if (cityLayout[xPos1 - 1, yPos1 + 1] >= 15 || cityLayout[xPos1, yPos1] >= 15 ||
							cityLayout[xPos1, yPos1 + 1] >= 15 || cityLayout[xPos1 + 1, yPos1] >= 15 ||
							cityLayout[xPos1 + 1, yPos1 + 1] >= 15 || cityLayout[xPos1 + 2, yPos1] >= 15 ||
							cityLayout[xPos1 + 2, yPos1 + 1] >= 15 ||
							cityLayout[xPos1 - 1, yPos1 + 1] == -2 || cityLayout[xPos1, yPos1] == -2 ||
							cityLayout[xPos1, yPos1 + 1] == -2 || cityLayout[xPos1 + 1, yPos1] == -2 ||
							cityLayout[xPos1 + 1, yPos1 + 1] == -2)
						{
							iFlags |= 2;
						}

						if (iFlags == 1)
							break;
					}

					if (j < 500)
					{
						cityLayout[xPos1 - 1, yPos1 + 1] = 15;
						cityLayout[xPos1, yPos1] = i + 64;
						cityLayout[xPos1, yPos1 + 1] = 15;
						cityLayout[xPos1 + 1, yPos1] = 15;
						cityLayout[xPos1 + 1, yPos1 + 1] = 15;
						cityLayout[xPos1 + 1, yPos1 - 1] = 15;
						cityLayout[xPos1 + 2, yPos1] = 15;
						cityLayout[xPos1 + 2, yPos1 - 1] = 15;
						cityLayout[xPos1 + 2, yPos1 + 1] = 15;
						cityLayout[xPos1 + 3, yPos1 - 1] = 15;

						if (yPos1 < 7 && (cityLayout[xPos1 + 1, yPos1 + 2] & 7) == 0)
						{
							cityLayout[xPos1 + 1, yPos1 + 2] = -1;
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
						xPos1 = oRNG.Next(16) + 1;
						yPos1 = oRNG.Next(10) + 1;

						int iFlags = 0;

						if (cityLayout[xPos1 - 1, yPos1 + 1] >= 0 || cityLayout[xPos1, yPos1] >= 0 ||
							cityLayout[xPos1, yPos1 + 1] >= 0 || cityLayout[xPos1 + 1, yPos1] >= 0 ||
							cityLayout[xPos1 + 1, yPos1 + 1] >= 0 ||
							j > 350)
						{
							iFlags |= 1;
						}

						if (cityLayout[xPos1 - 1, yPos1 + 1] >= 15 || cityLayout[xPos1, yPos1] >= 15 ||
							cityLayout[xPos1, yPos1 + 1] >= 15 || cityLayout[xPos1 + 1, yPos1] >= 15 ||
							cityLayout[xPos1 + 1, yPos1 + 1] >= 15 ||
							cityLayout[xPos1 - 1, yPos1 + 1] == -2 || cityLayout[xPos1, yPos1] == -2 ||
							cityLayout[xPos1, yPos1 + 1] == -2 || cityLayout[xPos1 + 1, yPos1] == -2 ||
							cityLayout[xPos1 + 1, yPos1 + 1] == -2)
						{
							iFlags |= 2;
						}

						if (iFlags == 1)
							break;
					}

					if (j < 500)
					{
						cityLayout[xPos1 - 1, yPos1 + 1] = 15;
						cityLayout[xPos1, yPos1] = 14 + (int)improvements[i];
						cityLayout[xPos1, yPos1 + 1] = 15;
						cityLayout[xPos1 + 1, yPos1] = 15;
						cityLayout[xPos1 + 1, yPos1 + 1] = 15;

						if (yPos1 < 7)
						{
							if ((cityLayout[xPos1 + 1, yPos1 + 2] & 7) == 0)
							{
								cityLayout[xPos1 + 1, yPos1 + 2] = -1;
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
				cityLayout[0, i8 - 1] = 23;
				cityLayout[0, i8] = 15;
				cityLayout[1, i8] = 15;
				cityLayout[1, i8 + 1] = 15;
				cityLayout[2, i8] = 15;
				cityLayout[2, i8 + 1] = 15;
			}

			// Instruction address 0x0000:0x08e4, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			F19_0000_137f_LoadCityBitmaps(improvementID, city.PlayerID, cityID);

			int i3 = 0;

			do
			{
				// Instruction address 0x0000:0x091b, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "hill.pic", 0);

				for (int i = 1; i < 8; i++)
				{
					int iWonderID = i;

					if (i == 2)
					{
						iWonderID = 15;
					}

					if (this.oGameData.WonderCityID[iWonderID] == cityID)
					{
						if ((iWonderID + 24) != improvementID)
						{
							if (((1 << iWonderID) & 0x808a) != 0)
							{
								// Instruction address 0x0000:0x09d4, size: 5
								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
									((iWonderID == 3) ? 80 : 0) + ((this.Array_0_3767[iWonderID].X < 10) ? -1 : 2) + this.Array_0_3767[iWonderID].X,
									(iWonderID <= 7) ? 0 : (this.Array_0_3767[iWonderID].Y - 6),
									this.Array_68a0[iWonderID]);
							}
						}
					}
				}

				if (city.HasImprovement(ImprovementEnum.PowerPlant) && improvementID != 19)
				{
					for (int i = (cityID == this.oGameData.WonderCityID[7]) ? 69 : 0; i < 310; i += 45)
					{
						// Instruction address 0x0000:0x0a1a, size: 5
						this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, i, 2, this.Array_81a2[17]);
					}
				}

				for (yPos1 = 0; yPos1 < 12; yPos1++)
				{
					for (xPos1 = 0; xPos1 < 19; xPos1++)
					{
						iValue = cityLayout[xPos1, yPos1];

						if (iValue == -2)
						{
							int iDirection = 0;

							for (int i = 1; i < 9; i++)
							{
								int iPrefixTemp;
								GPoint direction = TerrainMap.MoveOffsets[i];

								if ((yPos1 & 0x1) == 0)
								{
									iPrefixTemp = ((direction.Y <= 0) ? 0 : -1);
								}
								else
								{
									iPrefixTemp = (direction.Y >= 0) ? 0 : 1;
								}

								int iXTemp = xPos1 + iPrefixTemp + direction.X;
								int iYTemp = yPos1 + direction.Y;

								if (iYTemp < 12 && cityLayout[iXTemp, iYTemp] >= 0)
								{
									iDirection = 1;
								}
							}

							if (iDirection == 0)
							{
								cityLayout[xPos1, yPos1] = -1;
							}
						}
					}
				}

				for (yPos1 = 0; yPos1 < 12; yPos1++)
				{
					for (xPos1 = 0; xPos1 < 19; xPos1++)
					{
						iValue = cityLayout[xPos1, yPos1];

						if (iValue == -1 && xPos1 > 2 && cityLayout[xPos1 - 1, yPos1] != -1 && ((xPos1 + yPos1) & 1) != 0)
						{
							this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
								((yPos1 & 1) * 8) + (xPos1 * 16) - 5, (yPos1 * 8) + 50, this.Array_6880[0]);
						}

						if (iValue != -1 && iValue != 15)
						{
							if (iValue != -2)
							{
								if (iValue >= 16)
								{
									if (improvementID + 14 != iValue && improvementID + 40 != iValue)
									{
										iValue -= 16;
										if (iValue < 48)
										{
											// Instruction address 0x0000:0x10a5, size: 5
											// Instruction address 0x0000:0x10b2, size: 5
											this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
												this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((yPos1 & 1) * 8) + (xPos1 * 16) - 9, 0, 999), (yPos1 * 8) + 16,
												this.Array_81a2[iValue]);
										}
										else
										{
											iValue -= 48;
											int yPos = (yPos1 * 8) - this.Array_0_3767[iValue].Height + 76;

											// Instruction address 0x0000:0x1108, size: 5
											// Instruction address 0x0000:0x1115, size: 5
											this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
												this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((yPos & 1) * 8) + (xPos1 * 16) - 9, 0, 999), yPos - 10,
												this.Array_68a0[iValue]);
										}
									}
								}
								else if (iValue >= 2)
								{
									this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
										((yPos1 & 1) * 8) + (xPos1 * 16), (yPos1 * 8) + 26,
										this.Array_817a[(((iValue & 1) * 2) + ((xPos1 + yPos1) & 1)) + ((iValue / 2) * 4)]);

								}
								else
								{
									this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
										((yPos1 & 1) * 8) + (xPos1 * 16), (yPos1 * 8) + 26,
										this.Array_817a[(((iValue & 1) * 2) + (cityID & 1)) + ((iValue / 2) * 4)]);

								}
							}
							else
							{
								int bitmapID = 0;

								for (int i = 1; i < 9; i++)
								{
									int iPrefixTemp;
									GPoint direction = TerrainMap.MoveOffsets[i];

									if ((yPos1 & 1) == 0)
									{
										iPrefixTemp = (direction.Y <= 0) ? 0 : -1;
									}
									else
									{
										iPrefixTemp = (direction.Y >= 0) ? 0 : 1;
									}

									int iXTemp = xPos1 + iPrefixTemp + direction.X;
									int iYTemp = yPos1 + direction.Y;

									if ((i & 1) != 0)
									{
										bitmapID >>= 1;

										if (iYTemp < 12 && cityLayout[iXTemp, iYTemp] == -2)
										{
											bitmapID |= 8;
										}
									}
								}

								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
									((yPos1 & 1) * 8) + (xPos1 * 16) - 5, (yPos1 * 8) + 50, this.Array_6880[bitmapID]);
							}
						}
					}
				}
				
				if (city.HasImprovement(ImprovementEnum.CityWalls) && improvementID != 8)
				{
					for (int i = 0; i < 320; i += 43)
					{
						if (i == 172)
						{
							i += 19;
						}

						// Instruction address 0x0000:0x0ce2, size: 5
						this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, i, 108, this.Array_81a2[22]);
					}

					// Instruction address 0x0000:0x0d07, size: 5
					this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, 142, 108, this.Array_81a2[6]);
				}

				if (city.HasImprovement(ImprovementEnum.MassTransit) && improvementID != 13)
				{
					for (int i = 0; i < 310; i += 46)
					{
						// Instruction address 0x0000:0x0d3b, size: 5
						this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, i, 115, this.Array_81a2[21]);
					}

					// Instruction address 0x0000:0x0d5f, size: 5
					this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, 0, 115, this.Array_81a2[11]);
				}

				this.oParent.Var_aa_Rectangle.ScreenID = 1;
				this.oParent.Var_aa_Rectangle.FontID = 6;

				if (string.IsNullOrEmpty(local_80))
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

					// Instruction address 0x0000:0x0d82, size: 5
					this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

					// Instruction address 0x0000:0x0db1, size: 5
					this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringWithShadowToRectAA(0xba06, 160, 2, 15);

					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

					// Instruction address 0x0000:0x0dbe, size: 5
					this.oParent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

					// Instruction address 0x0000:0x0de7, size: 5
					this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringWithShadowToRectAA(0xba06, 160, 15, 15);
				}
				else
				{
					this.oParent.Var_db38 = 1;

					// Instruction address 0x0000:0x0e03, size: 5
					this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(local_80, 80, 8, 1);
				}

				this.oParent.Var_aa_Rectangle.ScreenID = 0;
				this.oParent.Var_aa_Rectangle.FontID = 1;

				if (i3 != 0)
				{
					// Instruction address 0x0000:0x0e2c, size: 5
					this.oParent.CommonTools.F0_1000_0a32_PlayTune(0x2c, 0);

					// Instruction address 0x0000:0x0e3c, size: 5
					this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreenWithEffect(1);
				}
				else
				{
					// Instruction address 0x0000:0x0e5a, size: 5
					this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

					if (improvementID != -3)
					{
						// Instruction address 0x0000:0x0e6c, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "hill.pic", 1);
					}

					// Instruction address 0x0000:0x0e8c, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

					if (improvementID == -3)
					{
						// Instruction address 0x0000:0x0ea9, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "hill.pal", out this.oParent.Var_bdee);

						// Instruction address 0x0000:0x0eb9, size: 5
						this.oParent.CommonTools.F0_1000_04aa_TransformPalette(15, this.oParent.Var_bdee);
					}

					// Instruction address 0x0000:0x0ed8, size: 5
					this.oParent.CommonTools.F0_1000_0382_AddPaletteCycleSlot(4, 15, 64, 79);

					// Instruction address 0x0000:0x0ee4, size: 5
					this.oParent.CommonTools.F0_1000_03fa_StartPaletteCycleSlot(4);
				}

				if (improvementID == -1 && i3 == 0)
				{
					F19_0000_111f_DrawCityPopulation(cityID, 24, 140, 256);
				}

				if (improvementID <= -1 || this.oParent.MSCAPI.kbhit() != 0)
					break;

				improvementID = -1;
				i3 = 1;

				// Instruction address 0x0000:0x0f3d, size: 5
				this.oParent.CommonTools.F0_1182_0134_WaitTimer(60);
			}
			while (this.oParent.MSCAPI.kbhit() == 0);

			// release all bitmap resources
			for (int i = 0; i < 16; i++)
			{
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.Array_6880[i], "City view");
			}

			for (int i = 0; i < 22; i++)
			{
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.Array_68a0[i], "City view");
			}

			for (int i = 0; i < 20; i++)
			{
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.Array_817a[i], "City view");
			}

			for (int i = 0; i < 23; i++)
			{
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.Array_81a2[i], "City view");
			}

			if (improvementID == -2)
			{
				// Instruction address 0x0000:0x0fe6, size: 5
				this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(4);
			}
			else
			{
				if (this.oParent.MSCAPI.kbhit() != 0)
				{
					// Instruction address 0x0000:0x0f84, size: 5
					this.oParent.Segment_1403.F0_1403_4545();
				}
				else
				{
					// Instruction address 0x0000:0x0f7d, size: 5
					this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
				}

				// Instruction address 0x0000:0x0f94, size: 5
				this.oParent.CommonTools.F0_1000_042b_StopPaletteCycleSlot(4);

				// Instruction address 0x0000:0x0fc7, size: 5
				this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

				// Instruction address 0x0000:0x0fcf, size: 5
				this.oParent.Segment_1238.F0_1238_1beb();

				// Instruction address 0x0000:0x0fd4, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0626();
			}

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_0000_DrawCityLayout");
		}
		
		/// <summary>
		/// Draw the population of the city
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="maxSize"></param>
		public void F19_0000_111f_DrawCityPopulation(int cityID, int xPos, int yPos, int maxSize)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_111f_DrawCityPopulation({cityID}, {xPos}, {yPos}, {maxSize})");

			// function body
			int local_2;
			int local_4;
			int[] array_16 = new int[9];
			int local_18;
			int local_1a;

			// Instruction address 0x0000:0x1133, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "pop.pic", 0);

			for (int i = 0; i < 9; i++)
			{
				// Instruction address 0x0000:0x117b, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, (int)TechnologyEnum.Industrialization) == 0)
				{
					// Instruction address 0x0000:0x1152, size: 5
					array_16[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (35 * i) + 1, 52, 34, 50);
				}
				else
				{
					// Instruction address 0x0000:0x1152, size: 5
					array_16[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (35 * i) + 1, 1, 34, 50);
				}
			}

			int local_1c = this.oGameData.Cities[cityID].ActualSize;

			if (local_1c * 12 > maxSize)
			{
				local_1a = maxSize / local_1c;
			}
			else
			{
				local_1a = 12;
			}

			// Instruction address 0x0000:0x11d7, size: 5
			local_2 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e2, 0, this.oGameData.Cities[cityID].ActualSize);

			// Instruction address 0x0000:0x1214, size: 5
			local_4 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e4, 0, this.oGameData.Cities[cityID].ActualSize);

			while (local_2 + local_4 > this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oGameData.Cities[cityID].ActualSize - this.oParent.Var_e8b8, 0, 99))
			{
				local_2--;

				// Instruction address 0x0000:0x11fc, size: 5
				local_2 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_2, 0, this.oGameData.Cities[cityID].ActualSize);

				local_4--;

				// Instruction address 0x0000:0x1214, size: 5
				local_4 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_4, 0, this.oGameData.Cities[cityID].ActualSize);
			}

			for (int i = 0; i < local_2; i++)
			{
				// Instruction address 0x0000:0x1270, size: 5
				this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, xPos, yPos, array_16[i & 1]);

				xPos += local_1a;
			}

			if (local_2 != 0)
			{
				xPos += 8;
			}

			for (local_18 = 0; local_18 < (this.oGameData.Cities[cityID].ActualSize - local_2 - local_4 - this.oParent.Var_e8b8); local_18++)
			{
				// Instruction address 0x0000:0x12b6, size: 5
				this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, xPos, yPos, array_16[(local_18 & 1) + 2]);

				xPos += local_1a;
			}

			if (local_18 != 0)
			{
				xPos += 8;
			}

			for (int i = 0; i < local_4; i++)
			{
				// Instruction address 0x0000:0x1312, size: 5
				this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					xPos, yPos, array_16[(i & 1) + 4]);

				xPos += local_1a;
			}

			xPos += 12;

			for (int i = 0; i < this.oParent.Var_e8b8; i++)
			{
				// Instruction address 0x0000:0x1339, size: 5
				// Instruction address 0x0000:0x1352, size: 5
				this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					xPos, yPos, array_16[this.oParent.CityWorker.F0_1d12_6da1_GetSpecialWorkerFlags(i)]);

				xPos += local_1a;
			}

			// Instruction address 0x0000:0x1372, size: 5
			for (int i = 0; i < 9; i++)
			{
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(array_16[i], "City view population");
			}

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_111f_DrawCityPopulation");
		}

		/// <summary>
		/// Load city bitmaps
		/// </summary>
		/// <param name="improvementID"></param>
		/// <param name="playerID"></param>
		/// <param name="cityID"></param>
		public void F19_0000_137f_LoadCityBitmaps(short improvementID, short playerID, int cityID)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_137f_LoadCityBitmaps({improvementID}, {playerID}, {cityID})");

			// function body
			// Instruction address 0x0000:0x1394, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "citypix1.pic", 0);

			for (int i = 0; i < 5; i++)
			{
				int local_6 = i * 64;

				// Instruction address 0x0000:0x13c0, size: 5
				this.Array_817a[i * 4] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, local_6 + 1, 1, 31, 31);

				// Instruction address 0x0000:0x13f7, size: 5
				this.Array_817a[i * 4 + 1] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, local_6 + 33, 1, 31, 31);

				// Instruction address 0x0000:0x13da, size: 5
				this.Array_817a[i * 4 + 2] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, local_6 + 1, 33, 31, 31);

				// Instruction address 0x0000:0x1411, size: 5
				this.Array_817a[i * 4 + 3] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, local_6 + 33, 33, 31, 31);
			}

			for (int i = 0; i < 16; i++)
			{
				// Instruction address 0x0000:0x1488, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Automobile) == 0)
				{
					// Instruction address 0x0000:0x145f, size: 5
					this.Array_6880[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i & 0x7) * 24, ((i / 8) * 8) + 65, 24, 8);
				}
				else
				{
					// Instruction address 0x0000:0x145f, size: 5
					this.Array_6880[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i & 0x7) * 24, ((i / 8) * 8) + 81, 24, 8);
				}
			}

			// Instruction address 0x0000:0x14a0, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Combustion) == 0)
			{

				// Instruction address 0x0000:0x14b9, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "citypix2.pic", 0);
			}
			else
			{
				// Instruction address 0x0000:0x14b9, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "citypix3.pic", 0);
			}

			for (int i = 0; i < 23; i++)
			{
				if ((this.oGameData.Cities[cityID].ImprovementFlags & (1 << (i + 1))) != 0 || improvementID - 1 == i || i > 20)
				{
					// Instruction address 0x0000:0x1529, size: 5
					this.Array_81a2[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i / 2) * 50) + 1, ((i & 0x3) * 50) + 1, 49, 49);
				}
			}

			this.Array_68a0[0] = 0;

			// Instruction address 0x0000:0x1576, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "wonders.pic", 0);

			for (int i = 1; i < 22; i++)
			{
				if (this.oGameData.WonderCityID[i] == cityID && (0x808a & (1 << i)) == 0)
				{
					this.Array_68a0[i] = F19_0000_1606_GetWonderBitmap(i);
				}
			}

			// Instruction address 0x0000:0x15d2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "wonders2.pic", 0);

			for (int i = 1; i < 22; i++)
			{
				if (this.oGameData.WonderCityID[i] == cityID && (0x808a & (1 << i)) != 0)
				{
					this.Array_68a0[i] = F19_0000_1606_GetWonderBitmap(i);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_137f_LoadCityBitmaps");
		}

		/// <summary>
		/// Get the Wonder bitmap
		/// </summary>
		/// <param name="rectIndex"></param>
		private int F19_0000_1606_GetWonderBitmap(int rectIndex)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_1606_GetWonderBitmap({rectIndex})");

			// function body
			if (this.Array_0_3767[1].Width > 300)
			{
				for (int i = 1; i < 22; i++)
				{
					this.Array_0_3767[i].Width = (this.Array_0_3767[i].Width - this.Array_0_3767[i].X) + 1;
					this.Array_0_3767[i].Height = (this.Array_0_3767[i].Height - this.Array_0_3767[i].Y) + 1;
				}
			}
		
			// Instruction address 0x0000:0x166e, size: 5
			int retValue = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				this.Array_0_3767[rectIndex].X, this.Array_0_3767[rectIndex].Y, this.Array_0_3767[rectIndex].Width, this.Array_0_3767[rectIndex].Height);

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_1606_GetWonderBitmap");

			return retValue;
		}

		/// <summary>
		/// Animate the conquering of the city
		/// </summary>
		/// <param name="playerID"></param>
		public void F19_0000_167b_ConqueredCityAnimation(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_167b_ConqueredCityAnimation({playerID})");

			// function body
			int[] array_20 = new int[10];

			// Instruction address 0x0000:0x1682, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x1698, size: 5
			this.oParent.Graphics.SetPaletteColor(253, GBitmap.Color18ToColor(3, 3, 3));

			// Instruction address 0x0000:0x16b1, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Gunpowder) != 0)
			{
				// Instruction address 0x0000:0x16c7, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Automobile) != 0)
				{
					// Instruction address 0x0000:0x16e0, size: 5
					this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "invaders.pic", 0);
				}
				else
				{
					// Instruction address 0x0000:0x16e0, size: 5
					this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "invader2.pic", 0);
				}

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x1731, size: 5
					array_20[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (i % 4) * 79, ((i / 4) * 61) + 2, 78, 60);
				}
			}
			else
			{
				// Instruction address 0x0000:0x174b, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "invader3.pic", 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x178e, size: 5
					array_20[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i % 4) * 79) + 1, ((i / 4) * 66) + 1, 78, 65);
				}
			}

			// Instruction address 0x0000:0x17c7, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 0);

			int local_28 = 0;

			for (int xOffset = 0; xOffset < 660; xOffset += 3)
			{
				// Instruction address 0x0000:0x17e9, size: 5
				this.oParent.CommonTools.F0_1000_033e_ResetWaitTimer();

				// Instruction address 0x0000:0x1809, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 100);

				for (int j = 7; j >= 0; j--)
				{
					int xPos = xOffset - (j * 48);

					if (xPos < 320 || xPos > -48)
					{
						// Instruction address 0x0000:0x184a, size: 5
						this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle, xPos, 132, array_20[local_28 % 10]);
					}
				}

				// Instruction address 0x0000:0x1875, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 100, 320, 100, this.oParent.Var_aa_Rectangle, 0, 100);

				local_28++;

				while (this.oParent.Var_5c_TickCount < 10)
				{
					this.oCPU.DoEvents();
					Thread.Sleep(1);
				}

				// Instruction address 0x0000:0x188a, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223();

				// Instruction address 0x0000:0x188f, size: 5
				if (this.oParent.MSCAPI.kbhit() != 0 || this.oParent.Var_db3a == 0) break;
			}

			// Instruction address 0x0000:0x18a7, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x18af, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(array_20[i], "Conquered city animation");
			}

			// Instruction address 0x0000:0x18b7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_167b_ConqueredCityAnimation");
		}
		
		/// <summary>
		/// Animate City civil disorder
		/// </summary>
		public void F19_0000_18c1_CivilDisorderAnimation()
		{
			this.oCPU.Log.EnterBlock("F19_0000_18c1_CivilDisorderAnimation()");

			// function body
			int[] bitmaps = new int[10];

			// Instruction address 0x0000:0x18c8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x18df, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, (int)TechnologyEnum.University) != 0)
			{
				// Instruction address 0x0000:0x18f3, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "riot.pic", 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x1943, size: 5
					bitmaps[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i % 4) * 79) + 1, ((i >> 2) * 64) + 1, 78, 63);
				}
			}
			else
			{
				// Instruction address 0x0000:0x195d, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "riot2.pic", 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x19a0, size: 5
					bitmaps[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i % 4) * 75) + 1, ((i >> 2) * 66) + 1, 74, 65);
				}
			}

			// Draw City View to screen 0
			// Instruction address 0x0000:0x19d9, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 0);

			for (int i = -48, j = 0; i < 420; i += 3, j++)
			{
				// Instruction address 0x0000:0x19fb, size: 5
				this.oParent.CommonTools.F0_1000_033e_ResetWaitTimer();

				// Draw a lower portion of City View to screen 0
				// Instruction address 0x0000:0x1a1b, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 100);

				for (int k = 0; k < 4; k++)
				{
					int iXPos = this.Array_4f42[k].X + i;

					if (iXPos > -48 && iXPos < 320)
					{
						// Instruction address 0x0000:0x1a6b, size: 5
						this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
							iXPos, this.Array_4f42[k].Y + 132, bitmaps[(k * 3 + j) % 10]);
					}				
				}

				// Draw a lower portion of City View to screen 0
				// Instruction address 0x0000:0x1a9a, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 100, 320, 100, this.oParent.Var_aa_Rectangle, 0, 100);

				while (this.oParent.Var_5c_TickCount < 10)
				{
					this.oCPU.DoEvents();
					Thread.Sleep(1);
				}

				// Instruction address 0x0000:0x1aaf, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223();

				// Instruction address 0x0000:0x1ab4, size: 5
				if (this.oParent.MSCAPI.kbhit() != 0 || this.oParent.Var_db3a != 0)
					break;
			}

			// Instruction address 0x0000:0x1acc, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x1ad4, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(bitmaps[i], "Civil disorder animation");
			}

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_18c1_CivilDisorderAnimation");
		}

		/// <summary>
		/// Animate Love day celebration
		/// </summary>
		public void F19_0000_1ae1_LoveDayAnimation()
		{
			this.oCPU.Log.EnterBlock("F19_0000_1ae1_LoveDayAnimation()");

			// function body
			int[] bitmaps = new int[10];
			int local_28;

			// Instruction address 0x0000:0x1ae8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x1afa, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, (int)TechnologyEnum.Industrialization) == 0)
			{
				// Instruction address 0x0000:0x1b13, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "love1.pic", 0);
			}
			else
			{
				// Instruction address 0x0000:0x1b13, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, "love2.pic", 0);
			}

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x1b56, size: 5
				bitmaps[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, ((i % 4) * 79) + 1, ((i / 4) * 66) + 1, 78, 65);
			}

			// Instruction address 0x0000:0x1b94, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 0);

			local_28 = 0;

			for (int xOffset = 420; xOffset > -48; xOffset -= 3)
			{
				// Instruction address 0x0000:0x1bb5, size: 5
				this.oParent.CommonTools.F0_1000_033e_ResetWaitTimer();

				// Instruction address 0x0000:0x1bd5, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 100);

				for (int i = 0; i < 4; i++)
				{
					int xPos = ((this.Array_4f42[i].X * 3) / 2) + xOffset;

					if (xPos > -48 && xPos < 320)
					{
						// Instruction address 0x0000:0x1c2d, size: 5
						this.oParent.Graphics.F0_VGA_0c3e_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
							xPos, this.Array_4f42[i].Y + 132, bitmaps[((i * 3) + local_28) % 10]);
					}
				}

				// Instruction address 0x0000:0x1c5c, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 100, 320, 100, this.oParent.Var_aa_Rectangle, 0, 100);

				local_28++;

				while (this.oParent.Var_5c_TickCount < 10)
				{
					this.oCPU.DoEvents();
					Thread.Sleep(1);
				}

				// Instruction address 0x0000:0x1c71, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223();

				// Instruction address 0x0000:0x1c76, size: 5
				if (this.oParent.MSCAPI.kbhit() != 0 || this.oParent.Var_db3a != 0)
					break;
			}

			// Instruction address 0x0000:0x1c8e, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x1c96, size: 5
			for (int i = 0; i < 10; i++)
			{
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(bitmaps[i], "Love day animation");
			}

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_1ae1_LoveDayAnimation");
		}
	}
}
