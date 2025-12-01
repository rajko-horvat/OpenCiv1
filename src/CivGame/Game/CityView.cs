using IRB.VirtualCPU;
using OpenCiv1.GPU;
using System;

namespace OpenCiv1
{
	public class CityView
	{
		private CivGame oParent;
		private VCPU oCPU;

		public CityView(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}
		
		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="param2"></param>
		public void F19_0000_0000(short cityID, short param2)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_0000({cityID}, {param2})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x186);

			City city = this.oParent.CivState.Cities[cityID];

			int iTechnologyCount = this.oParent.CivState.Players[city.PlayerID].DiscoveredTechnologyCount >> 1;
			int[,] aCityLayout = new int[19, 12];
			int iXPos1, iYPos1, iXPos2, iYPos2, i8;
			int iValue;

			for (int i = 0; i < 19; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					aCityLayout[i, j] = -1;
				}
			}

			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x80), 0x0);

			if (this.oParent.MSCAPI.strlen(0xba06) < 120)
			{
				// Instruction address 0x0000:0x004d, size: 5
				this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x80), 0xba06);
			}

			// RNG based on city name
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);
			string sCityName = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, 0xba06));
			RandomMT19937 oRNG = new RandomMT19937((uint)sCityName.GetHashCode());

			iXPos1 = 9;
			iYPos1 = 11;

			for (int i = 0, j = 0; (city.ActualSize << 3) > i; i++)
			{
				if (aCityLayout[iXPos1, iYPos1] != -1)
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
					int iCombinedPosition = this.oParent.Segment_2dc4.F0_2dc4_0208_GetShortestDistance((short)(iXPos1 - 9), (short)(iYPos1 - 10));

					aCityLayout[iXPos1, iYPos1] = Math.Min(Math.Max(((iTechnologyCount - iCombinedPosition) / 3) - oRNG.Next(2), iTechnologyCount / 6),
						Math.Min((city.ActualSize / 4) + 6, 9));

					if ((iCombinedPosition * iCombinedPosition) > ((int)city.ActualSize << 3))
					{
						iXPos1 = 9;
						iYPos1 = 11;
					}
				}

				GPoint direction = this.oParent.MoveOffsets[oRNG.Next(8) + 1];

				iXPos1 = Math.Min(Math.Max(iXPos1 + direction.X, 0), 18);
				iYPos1 = Math.Min(Math.Max(iYPos1 + direction.Y, 0), 11);
			}

			iYPos2 = 4 + oRNG.Next(2);

			for (int i = 2; i < 17; i++)
			{
				aCityLayout[i, iYPos2] = -2;
			}

			aCityLayout[18, iYPos2] = -1;
			aCityLayout[0, iYPos2] = -1;

			iYPos2 = 8 + oRNG.Next(2);
			i8 = iYPos2;

			for (int i = 2; i < 17; i++)
			{
				aCityLayout[i, iYPos2] = -2;
			}

			aCityLayout[18, iYPos2] = -1;
			aCityLayout[0, iYPos2] = -1;

			iXPos2 = 9 + oRNG.Next(4);

			for (int i = 1; i < 12; i++)
			{
				aCityLayout[iXPos2 - ((i + 1) >> 1), i] = -2;
			}

			iXPos2 = 14 + oRNG.Next(4);

			for (int i = 1; i < 12; i++)
			{
				aCityLayout[iXPos2 - ((i + 1) >> 1), i] = -2;
			}

			if (cityID == this.oParent.CivState.WonderCityID[7])
			{
				aCityLayout[0, 0] = 15;
				aCityLayout[0, 1] = 15;
				aCityLayout[0, 2] = 15;
				aCityLayout[1, 0] = 15;
				aCityLayout[1, 1] = 15;
				aCityLayout[2, 0] = 15;
			}

			for (int i = 1; i <= 21; i++)
			{
				if (this.oParent.CivState.WonderCityID[i] == cityID && ((1 << i) & 0x808a) == 0)
				{
					int j = 0;

					for (; j < 500; j++)
					{
						iXPos1 = oRNG.Next(15) + 1;
						iYPos1 = oRNG.Next(10) + 1;

						int iFlags = 0;

						if (aCityLayout[iXPos1 - 1, iYPos1 + 1] >= 0 || aCityLayout[iXPos1, iYPos1] >= 0 ||
							aCityLayout[iXPos1, iYPos1 + 1] >= 0 || aCityLayout[iXPos1 + 1, iYPos1] >= 0 ||
							aCityLayout[iXPos1 + 1, iYPos1 + 1] >= 0 || aCityLayout[iXPos1 + 2, iYPos1] >= 0 ||
							j > 400)
						{
							iFlags |= 1;
						}

						if (aCityLayout[iXPos1 - 1, iYPos1 + 1] >= 15 || aCityLayout[iXPos1, iYPos1] >= 15 ||
							aCityLayout[iXPos1, iYPos1 + 1] >= 15 || aCityLayout[iXPos1 + 1, iYPos1] >= 15 ||
							aCityLayout[iXPos1 + 1, iYPos1 + 1] >= 15 || aCityLayout[iXPos1 + 2, iYPos1] >= 15 ||
							aCityLayout[iXPos1 + 2, iYPos1 + 1] >= 15 ||
							aCityLayout[iXPos1 - 1, iYPos1 + 1] == -2 || aCityLayout[iXPos1, iYPos1] == -2 ||
							aCityLayout[iXPos1, iYPos1 + 1] == -2 || aCityLayout[iXPos1 + 1, iYPos1] == -2 ||
							aCityLayout[iXPos1 + 1, iYPos1 + 1] == -2)
						{
							iFlags |= 2;
						}

						if (iFlags == 1)
							break;
					}

					if (j < 500)
					{
						aCityLayout[iXPos1 - 1, iYPos1 + 1] = 15;
						aCityLayout[iXPos1, iYPos1] = i + 64;
						aCityLayout[iXPos1, iYPos1 + 1] = 15;
						aCityLayout[iXPos1 + 1, iYPos1] = 15;
						aCityLayout[iXPos1 + 1, iYPos1 + 1] = 15;
						aCityLayout[iXPos1 + 1, iYPos1 - 1] = 15;
						aCityLayout[iXPos1 + 2, iYPos1] = 15;
						aCityLayout[iXPos1 + 2, iYPos1 - 1] = 15;
						aCityLayout[iXPos1 + 2, iYPos1 + 1] = 15;
						aCityLayout[iXPos1 + 3, iYPos1 - 1] = 15;

						if (iYPos1 < 7 && (aCityLayout[iXPos1 + 1, iYPos1 + 2] & 7) == 0)
						{
							aCityLayout[iXPos1 + 1, iYPos1 + 2] = -1;
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
						iXPos1 = oRNG.Next(16) + 1;
						iYPos1 = oRNG.Next(10) + 1;

						int iFlags = 0;

						if (aCityLayout[iXPos1 - 1, iYPos1 + 1] >= 0 || aCityLayout[iXPos1, iYPos1] >= 0 ||
							aCityLayout[iXPos1, iYPos1 + 1] >= 0 || aCityLayout[iXPos1 + 1, iYPos1] >= 0 ||
							aCityLayout[iXPos1 + 1, iYPos1 + 1] >= 0 ||
							j > 350)
						{
							iFlags |= 1;
						}

						if (aCityLayout[iXPos1 - 1, iYPos1 + 1] >= 15 || aCityLayout[iXPos1, iYPos1] >= 15 ||
							aCityLayout[iXPos1, iYPos1 + 1] >= 15 || aCityLayout[iXPos1 + 1, iYPos1] >= 15 ||
							aCityLayout[iXPos1 + 1, iYPos1 + 1] >= 15 ||
							aCityLayout[iXPos1 - 1, iYPos1 + 1] == -2 || aCityLayout[iXPos1, iYPos1] == -2 ||
							aCityLayout[iXPos1, iYPos1 + 1] == -2 || aCityLayout[iXPos1 + 1, iYPos1] == -2 ||
							aCityLayout[iXPos1 + 1, iYPos1 + 1] == -2)
						{
							iFlags |= 2;
						}

						if (iFlags == 1)
							break;
					}

					if (j < 500)
					{
						aCityLayout[iXPos1 - 1, iYPos1 + 1] = 15;
						aCityLayout[iXPos1, iYPos1] = 14 + (int)improvements[i];
						aCityLayout[iXPos1, iYPos1 + 1] = 15;
						aCityLayout[iXPos1 + 1, iYPos1] = 15;
						aCityLayout[iXPos1 + 1, iYPos1 + 1] = 15;

						if (iYPos1 < 7)
						{
							if ((aCityLayout[iXPos1 + 1, iYPos1 + 2] & 7) == 0)
							{
								aCityLayout[iXPos1 + 1, iYPos1 + 2] = -1;
							}
						}
					}
				}
			}

			if (city.HasImprovement(ImprovementEnum.HydroPlant))
			{
				aCityLayout[17, 7] = 34;
				aCityLayout[17, 8] = 15;
				aCityLayout[18, 7] = 15;
				aCityLayout[18, 8] = 15;
			}

			if (city.HasImprovement(ImprovementEnum.Aqueduct))
			{
				aCityLayout[0, i8 - 1] = 23;
				aCityLayout[0, i8] = 15;
				aCityLayout[1, i8] = 15;
				aCityLayout[1, i8 + 1] = 15;
				aCityLayout[2, i8] = 15;
				aCityLayout[2, i8 + 1] = 15;
			}

			// Instruction address 0x0000:0x08e4, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x08f0, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(1, 1);

			F19_0000_137f((ushort)param2, city.PlayerID, cityID);

			int i3 = 0;

			do
			{
				// Instruction address 0x0000:0x091b, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4e98, 0);

				for (int i = 1; i < 8; i++)
				{
					int iWonderID = i;

					if (i == 2)
					{
						iWonderID = 15;
					}

					if (this.oParent.CivState.WonderCityID[iWonderID] == cityID)
					{
						if ((iWonderID + 24) != param2)
						{
							if (((1 << iWonderID) & 0x808a) != 0)
							{
								// Instruction address 0x0000:0x09d4, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
									(((iWonderID == 3) ? 80 : 0) +
										((this.oCPU.ReadInt16(0x3767, (ushort)((iWonderID << 3) + 0x0)) < 10) ? -1 : 2) +
										this.oCPU.ReadInt16(0x3767, (ushort)((iWonderID << 3) + 0x0))),
									((iWonderID <= 7) ? 0 : (this.oCPU.ReadInt16(0x3767, (ushort)((iWonderID << 3) + 0x2)) - 6)),
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((iWonderID << 1) + 0x68a0)));
							}
						}
					}
				}

				if (city.HasImprovement(ImprovementEnum.PowerPlant) && param2 != 19)
				{
					for (int i = (cityID == this.oParent.CivState.WonderCityID[7]) ? 69 : 0; i < 310; i += 45)
					{
						// Instruction address 0x0000:0x0a1a, size: 5
						this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
							i, 2, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81c4));
					}
				}

				for (iYPos1 = 0; iYPos1 < 12; iYPos1++)
				{
					for (iXPos1 = 0; iXPos1 < 19; iXPos1++)
					{
						iValue = aCityLayout[iXPos1, iYPos1];

						if (iValue == -2)
						{
							int iDirection = 0;

							for (int i = 1; i < 9; i++)
							{
								int iPrefixTemp;
								GPoint direction = this.oParent.MoveOffsets[i];

								if ((iYPos1 & 0x1) == 0)
								{
									iPrefixTemp = ((direction.Y <= 0) ? 0 : -1);
								}
								else
								{
									iPrefixTemp = (direction.Y >= 0) ? 0 : 1;
								}

								int iXTemp = iXPos1 + iPrefixTemp + direction.X;
								int iYTemp = iYPos1 + direction.Y;

								if (iYTemp < 12 && aCityLayout[iXTemp, iYTemp] >= 0)
								{
									iDirection = 1;
								}
							}

							if (iDirection == 0)
							{
								aCityLayout[iXPos1, iYPos1] = -1;
							}
						}
					}
				}

				for (iYPos1 = 0; iYPos1 < 12; iYPos1++)
				{
					for (iXPos1 = 0; iXPos1 < 19; iXPos1++)
					{
						iValue = aCityLayout[iXPos1, iYPos1];

						if (iValue == -1 && iXPos1 > 2 && aCityLayout[iXPos1 - 1, iYPos1] != -1 && ((iXPos1 + iYPos1) & 1) != 0)
						{
							F19_0000_0ff4(iXPos1, iYPos1, 0);
						}

						if (iValue != -1 && iValue != 15)
						{
							if (iValue != -2)
							{
								if (iValue >= 16)
								{
									if (param2 + 14 != iValue && param2 + 40 != iValue)
									{
										F19_0000_106c(iXPos1, iYPos1, (ushort)(iValue - 16));
									}
								}
								else if (iValue >= 2)
								{
									F19_0000_102e(iXPos1, iYPos1, (ushort)(((iXPos1 + iYPos1) & 1) + ((iValue & 1) << 1)), (ushort)(iValue >> 1));
								}
								else
								{
									F19_0000_102e(iXPos1, iYPos1, (ushort)(((iValue & 1) << 1) + (cityID & 1)), (ushort)(iValue >> 1));
								}
							}
							else
							{
								int iFlag = 0;

								for (int i = 1; i < 9; i++)
								{
									int iPrefixTemp;
									GPoint direction = this.oParent.MoveOffsets[i];

									if ((iYPos1 & 1) == 0)
									{
										iPrefixTemp = (direction.Y <= 0) ? 0 : -1;
									}
									else
									{
										iPrefixTemp = (direction.Y >= 0) ? 0 : 1;
									}

									int iXTemp = iXPos1 + iPrefixTemp + direction.X;
									int iYTemp = iYPos1 + direction.Y;

									if ((i & 1) != 0)
									{
										iFlag >>= 1;

										if (iYTemp < 12 && aCityLayout[iXTemp, iYTemp] == -2)
										{
											iFlag |= 8;
										}
									}
								}

								F19_0000_0ff4(iXPos1, iYPos1, (ushort)iFlag);
							}
						}
					}
				}
				
				if (city.HasImprovement(ImprovementEnum.CityWalls) && param2 != 8)
				{
					for (int i = 0; i < 320; i += 43)
					{
						if (i == 172)
						{
							i += 19;
						}

						// Instruction address 0x0000:0x0ce2, size: 5
						this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
							i, 108, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81ce));
					}

					// Instruction address 0x0000:0x0d07, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
						142, 108, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81ae));
				}

				if (city.HasImprovement(ImprovementEnum.MassTransit) && param2 != 13)
				{
					for (int i = 0; i < 310; i += 46)
					{
						// Instruction address 0x0000:0x0d3b, size: 5
						this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
							i, 115, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81cc));
					}

					// Instruction address 0x0000:0x0d5f, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
						0, 115, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x81b8));
				}

				this.oParent.Var_aa_Rectangle.ScreenID = 1;
				this.oParent.Var_aa_Rectangle.FontID = 6;

				if (this.oParent.MSCAPI.strlen((ushort)(this.oCPU.BP.Word - 0x80)) == 0)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

					// Instruction address 0x0000:0x0d82, size: 5
					this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

					// Instruction address 0x0000:0x0db1, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringWithShadowToScreen0(0xba06, 160, 2, 15);

					this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

					// Instruction address 0x0000:0x0dbe, size: 5
					this.oParent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

					// Instruction address 0x0000:0x0de7, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringWithShadowToScreen0(0xba06, 160, 15, 15);
				}
				else
				{
					this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdb38, 0x1);

					// Instruction address 0x0000:0x0e03, size: 5
					this.oParent.Segment_2d05.F0_2d05_0031((ushort)(this.oCPU.BP.Word - 0x80), 80, 8, 1);
				}

				this.oParent.Var_aa_Rectangle.ScreenID = 0;
				this.oParent.Var_aa_Rectangle.FontID = 1;

				if (i3 != 0)
				{
					// Instruction address 0x0000:0x0e2c, size: 5
					this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x2c, 0);

					// Instruction address 0x0000:0x0e3c, size: 5
					this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreen(1);
				}
				else
				{
					// Instruction address 0x0000:0x0e5a, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

					if (param2 != -3)
					{
						// Instruction address 0x0000:0x0e6c, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4ea1, 1);
					}

					// Instruction address 0x0000:0x0e8c, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

					if (param2 == -3 && this.oParent.Var_d762 != 0)
					{
						// Instruction address 0x0000:0x0ea9, size: 5
						this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4eaa, 0xbdee);

						// Instruction address 0x0000:0x0eb9, size: 5
						this.oParent.Segment_1000.F0_1000_04aa_TransformPalette(15, 0xbdee);
					}

					if (this.oParent.Var_d762 != 0)
					{
						// Instruction address 0x0000:0x0ed8, size: 5
						this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(4, 15, 64, 79);

						// Instruction address 0x0000:0x0ee4, size: 5
						this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(4);
					}
				}

				if (param2 == -1 && i3 == 0)
				{
					// Instruction address 0x0000:0x0f01, size: 5
					this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x817a), 0x4eb3);

					F19_0000_111f(cityID, 24, 140, 0x100);
				}

				if (param2 <= -1 || this.oParent.MSCAPI.kbhit() != 0)
					break;

				param2 = -1;
				i3 = 1;

				// Instruction address 0x0000:0x0f3d, size: 5
				this.oParent.Segment_1000.F0_1182_0134_WaitTimer(60);
			}
			while (this.oParent.MSCAPI.kbhit() == 0);

			if (param2 != -1 || i3 != 0)
			{
				// Instruction address 0x0000:0x0f66, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x817a), 0x4eb8);
			}

			if (param2 == -2)
			{
				if (this.oParent.Var_d762 != 0)
				{
					// Instruction address 0x0000:0x0fe6, size: 5
					this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(4);
				}
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

				if (this.oParent.Var_d762 != 0)
				{
					// Instruction address 0x0000:0x0f94, size: 5
					this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(4);
				}

				// Instruction address 0x0000:0x0fa5, size: 5
				this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

				if (this.oParent.Var_d762 != 0)
				{
					// Instruction address 0x0000:0x0fc7, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

					// Instruction address 0x0000:0x0fcf, size: 5
					this.oParent.Segment_1238.F0_1238_1beb();
				}

				// Instruction address 0x0000:0x0fd4, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0626();
			}

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapID"></param>
		public void F19_0000_0ff4(int xPos, int yPos, ushort bitmapID)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_0ff4({xPos}, {yPos}, {bitmapID})");

			// function body
			// Instruction address 0x0000:0x1024, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
				((yPos & 1) * 8) + (xPos * 16) - 5, (yPos * 8) + 50,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((bitmapID << 1) + 0x6880)));

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_0ff4");
		}
		
		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param3"></param>
		/// <param name="param4"></param>
		public void F19_0000_102e(int xPos, int yPos, ushort param3, ushort param4)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_102e({xPos}, {yPos}, {param3}, {param4})");

			// function body
			// Instruction address 0x0000:0x1061, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
				((yPos & 1) << 3) + (xPos << 4), (yPos << 3) + 26,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((param3 << 1) + (param4 << 3) + 0x817a)));

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_102e");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="bitmapID"></param>
		public void F19_0000_106c(int xPos, int yPos, ushort bitmapID)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_106c({xPos}, {yPos}, {bitmapID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.CMP_UInt16(bitmapID, 0x30);
			if (this.oCPU.Flags.GE) goto L10b9;

			// Instruction address 0x0000:0x10a5, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((yPos & 1) * 8) + (xPos * 16) - 9, 0, 999);

			// Instruction address 0x0000:0x10b2, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
				(short)this.oCPU.AX.Word, (yPos << 3) + 16,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((bitmapID << 1) + 0x81a2)));

			goto L111a;

		L10b9:
			this.oCPU.ES.Word = 0x3767; // segment
			bitmapID -= 0x30;
			yPos = (short)((yPos << 3) - this.oCPU.ReadInt16(this.oCPU.ES.Word, (ushort)((bitmapID << 3) + 6)) + 76);

			// Instruction address 0x0000:0x1108, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((yPos & 1) * 8) + (xPos * 16) - 9, 0, 999);

			// Instruction address 0x0000:0x1115, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
				(short)this.oCPU.AX.Word, yPos - 10,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((bitmapID << 1) + 0x68a0)));

		L111a:
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_106c");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param4"></param>
		public void F19_0000_111f(short cityID, int xPos, int yPos, ushort param4)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_111f({cityID}, {xPos}, {yPos}, {param4})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x1c);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1133, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ebc, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L1165;

		L1145:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1165:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x9);
			if (this.oCPU.Flags.GE) goto L118c;

			// Instruction address 0x0000:0x117b, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID, TechnologyEnum.Industrialization) ? 1 : 0);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
			{
				// Instruction address 0x0000:0x1152, size: 5
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)(((0x23 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)))) + 1),
					0x34, 0x22, 0x32);
			}
			else
			{
				// Instruction address 0x0000:0x1152, size: 5
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)(((0x23 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)))) + 1),
					1, 0x22, 0x32);
			}
			goto L1145;

		L118c:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)this.oParent.CivState.Cities[cityID].ActualSize;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0xc;
			this.oCPU.IMUL_UInt8(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, param4);
			if (this.oCPU.Flags.LE) goto L11bb;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = param4;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

			goto L11c0;

		L11bb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 0xc);

		L11c0:
			// Instruction address 0x0000:0x11d7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e2, 0, this.oParent.CivState.Cities[cityID].ActualSize);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1214, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e4, 0, this.oParent.CivState.Cities[cityID].ActualSize);

			goto L1214;

		L11ef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x0000:0x11fc, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				0, this.oParent.CivState.Cities[cityID].ActualSize);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			
			// Instruction address 0x0000:0x1214, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				0, this.oParent.CivState.Cities[cityID].ActualSize);

		L1214:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x123a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.CivState.Cities[cityID].ActualSize - this.oParent.Var_e8b8, 0, 99);

			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CMP_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L11ef;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L1281;

		L1253:
			this.oCPU.SI.Word = 0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1270, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16)));

			xPos += this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1281:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1253;
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1291;

			xPos += 8;

		L1291:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L12c7;

		L1298:
			this.oCPU.SI.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x12b6, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16)));

			xPos += this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L12c7:
			this.oCPU.AX.Low = (byte)this.oParent.CivState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_e8b8));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			if (this.oCPU.Flags.G) goto L1298;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x0);
			if (this.oCPU.Flags.E) goto L12ed;

			xPos += 8;

		L12ed:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L1323;

		L12f4:
			this.oCPU.SI.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1312, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x16)));

			xPos += this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1323:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L12f4;

			xPos += 12;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);

			goto L1363;

		L1336:
			// Instruction address 0x0000:0x1339, size: 5
			this.oParent.CityWorker.F0_1d12_6da1_GetSpecialWorkerFlags(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1352, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xc)));

			xPos += this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L1363:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_e8b8);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1336;

			// Instruction address 0x0000:0x1372, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x4ec4);

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_111f");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="playerID"></param>
		/// <param name="cityID"></param>
		public void F19_0000_137f(ushort param1, short playerID, short cityID)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_137f({param1}, {playerID}, {cityID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1394, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ec8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L13a1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x6;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.INC_UInt16(this.oCPU.DI.Word);

			// Instruction address 0x0000:0x13c0, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 1, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x817a), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x13da, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 0x21, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x817e), this.oCPU.AX.Word);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, 0x21);

			// Instruction address 0x0000:0x13f7, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 1, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x817c), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1411, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.DI.Word, 0x21, 0x1f, 0x1f);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x8180), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.G) goto L1429;
			goto L13a1;

		L1429:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L1473;

		L1433:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6880), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L1473:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.GE) goto L1499;

			// Instruction address 0x0000:0x1488, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Automobile) ? 1 : 0);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
			{
				// Instruction address 0x0000:0x145f, size: 5
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 0x7) * 0x18),
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >> 3) << 3) + 0x41),
					0x18, 0x8);
			}
			else
			{
				// Instruction address 0x0000:0x145f, size: 5
				this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 0x7) * 0x18),
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >> 3) << 3) + 0x51),
					0x18, 0x8);
			}
			goto L1433;

		L1499:
			// Instruction address 0x0000:0x14a0, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Combustion) ? 1 : 0);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L14b1;

			// Instruction address 0x0000:0x14b9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ed5, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L14c6;

		L14b1:
			// Instruction address 0x0000:0x14b9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4ee2, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L14c6:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Low = this.oCPU.INC_UInt8(this.oCPU.CX.Low);
			this.oCPU.UInt32ToTwoUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.TwoUInt16ToUInt32(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.BX.Word = this.oCPU.DX.Word;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.AND_UInt16(this.oCPU.CX.Word, this.oParent.CivState.Cities[cityID].ImprovementFlags0);
			this.oCPU.BX.Word = this.oCPU.AND_UInt16(this.oCPU.BX.Word, this.oParent.CivState.Cities[cityID].ImprovementFlags1);
			this.oCPU.BX.Word = this.oCPU.OR_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L14fb;

			this.oCPU.AX.Word = param1;
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.E) goto L14fb;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x14);
			if (this.oCPU.Flags.LE) goto L153a;

		L14fb:
			// Instruction address 0x0000:0x1529, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) >> 2) * 0x32) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) & 0x3) * 0x32) + 1),
				0x31, 0x31);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81a2), this.oCPU.AX.Word);

		L153a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x17);
			if (this.oCPU.Flags.L) goto L14c6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L154d:
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMP_UInt16((ushort)this.oParent.CivState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))], this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1596;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, 0x808a);
			if (this.oCPU.Flags.NE) goto L1596;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L157e;

			// Instruction address 0x0000:0x1576, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4eef, 0);

		L157e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

			F19_0000_1606(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x68a0), this.oCPU.AX.Word);

		L1596:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x15);
			if (this.oCPU.Flags.LE) goto L154d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L15a9:
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMP_UInt16((ushort)this.oParent.CivState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))], this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L15f2;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, 0x808a);
			if (this.oCPU.Flags.E) goto L15f2;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L15da;

			// Instruction address 0x0000:0x15d2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4efb, 0);

		L15da:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

			F19_0000_1606(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x68a0), this.oCPU.AX.Word);

		L15f2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x15);
			if (this.oCPU.Flags.LE) goto L15a9;

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_137f");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F19_0000_1606(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_1606({param1})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.ES.Word = 0x3767; // segment
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.ES.Word, 0xc), 0x12c);
			if (this.oCPU.Flags.LE) goto L164f;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L161f:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word <<= 3;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x6));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x2)));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x6), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x15);
			if (this.oCPU.Flags.LE) goto L161f;

		L164f:
			this.oCPU.SI.Word = param1;
			this.oCPU.SI.Word <<= 3;
			// Instruction address 0x0000:0x166e, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x0)),
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x6)));

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_1606");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F19_0000_167b(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F19_0000_167b({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x28);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1682, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L16a0;

			// Instruction address 0x0000:0x1698, size: 5
			this.oParent.Graphics.SetPaletteColor(0xfd, GBitmap.Color18ToColor(3, 3, 3));

		L16a0:
			// Instruction address 0x0000:0x16a5, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x16b1, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Gunpowder) ? 1 : 0);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L16c0;

			goto L1743;

		L16c0:
			// Instruction address 0x0000:0x16c7, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, TechnologyEnum.Automobile) ? 1 : 0);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L16d8;

			// Instruction address 0x0000:0x16e0, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f08, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L16f2;

		L16d8:
			// Instruction address 0x0000:0x16e0, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f15, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L16f2;

		L16ef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));

		L16f2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L16fb;
			goto L17a7;

		L16fb:
			// Instruction address 0x0000:0x1731, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4f),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) * 0x3d) + 2),
				0x4e, 0x3c);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			goto L16ef;

		L1743:
			// Instruction address 0x0000:0x174b, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f22, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L1758:
			// Instruction address 0x0000:0x178e, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4f) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) * 0x42) + 1),
				0x4e, 0x41);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L1758;

		L17a7:
			// Instruction address 0x0000:0x17c7, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x0);
			goto L17df;

		L17db:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3));

		L17df:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x294);
			if (this.oCPU.Flags.L) goto L17e9;
			goto L18a2;

		L17e9:
			// Instruction address 0x0000:0x17e9, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();
			
			// Instruction address 0x0000:0x1809, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x7);

		L1816:
			this.oCPU.AX.Word = 0x30;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.CX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.CX.Word, 0x140);
			if (this.oCPU.Flags.GE) goto L1852;
			this.oCPU.CMP_UInt16(this.oCPU.CX.Word, 0xffd0);
			if (this.oCPU.Flags.LE) goto L1852;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x184a, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 132,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20)));

		L1852:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			if (this.oCPU.Flags.NS) goto L1816;
			
			// Instruction address 0x0000:0x1875, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 100, 320, 100, this.oParent.Var_aa_Rectangle, 0, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))));

		L1880:
			this.oCPU.AX.Word = this.oParent.Var_5c_TickCount;
			this.oCPU.DoEvents();
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.L) goto L1880;

			// Instruction address 0x0000:0x188a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			// Instruction address 0x0000:0x188f, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L18a2;
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.NE) goto L18a2;
			goto L17db;

		L18a2:
			// Instruction address 0x0000:0x18a2, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x18a7, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x18af, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0);

			// Instruction address 0x0000:0x18b7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_167b");
		}
		
		/// <summary>
		/// ?
		/// </summary>
		public void F19_0000_18c1_CivilDisorderAnimation()
		{
			this.oCPU.Log.EnterBlock("F19_0000_18c1_CivilDisorderAnimation()");

			// function body
			ushort[] aBitmaps = new ushort[10];

			// Instruction address 0x0000:0x18c8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x18cd, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x18df, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID, TechnologyEnum.University))
			{
				// Instruction address 0x0000:0x18f3, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f2f, 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x1943, size: 5
					aBitmaps[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (ushort)(((i % 4) * 79) + 1), (ushort)(((i >> 2) * 64) + 1), 78, 63);
				}
			}
			else
			{
				// Instruction address 0x0000:0x195d, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f38, 0);

				for (int i = 0; i < 10; i++)
				{
					// Instruction address 0x0000:0x19a0, size: 5
					aBitmaps[i] = this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, (ushort)(((i % 4) * 75) + 1), (ushort)(((i >> 2) * 66) + 1), 74, 65);
				}
			}

			// Draw City View to screen 0
			// Instruction address 0x0000:0x19d9, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 0);

			for (int i = -48, j = 0; i < 420; i += 3, j++)
			{
				// Instruction address 0x0000:0x19fb, size: 5
				this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();

				// Draw a lower portion of City View to screen 0
				// Instruction address 0x0000:0x1a1b, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 100);

				for (int k = 0; k < 4; k++)
				{
					int iXPos = this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(0x4f42 + (k << 1))) + i;

					if (iXPos > -48 && iXPos < 320)
					{
						// Instruction address 0x0000:0x1a6b, size: 5
						this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
							iXPos, this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((k << 1) + 0x4f4a)) + 132,
							aBitmaps[(k * 3 + j) % 10]);
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
				this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

				// Instruction address 0x0000:0x1ab4, size: 5
				if (this.oParent.MSCAPI.kbhit() != 0 || this.oParent.Var_db3a_MouseButton != 0)
					break;
			}

			// Instruction address 0x0000:0x1ac7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x1acc, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			for (int i = 0; i < 10; i++)
			{
				// Instruction address 0x0000:0x1ad4, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(aBitmaps[i], 0);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_18c1_CivilDisorderAnimation");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F19_0000_1ae1()
		{
			this.oCPU.Log.EnterBlock("F19_0000_1ae1()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x28);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1ae8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x1afa, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID, TechnologyEnum.Industrialization) ? 1 : 0);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L1b0b;

			// Instruction address 0x0000:0x1b13, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f52, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L1b20;

		L1b0b:
			// Instruction address 0x0000:0x1b13, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4f5c, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L1b20:
			// Instruction address 0x0000:0x1b56, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) % 4) * 0x4f) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) >> 2) * 0x42) + 1),
				0x4e, 0x41);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xa);
			if (this.oCPU.Flags.L) goto L1b20;

			// Instruction address 0x0000:0x1b74, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x1b94, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 100, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x1a4);
			goto L1bac;

		L1ba8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 
				this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3));

		L1bac:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0xffd0);
			if (this.oCPU.Flags.G) goto L1bb5;
			goto L1c89;

		L1bb5:
			// Instruction address 0x0000:0x1bb5, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();

			// Instruction address 0x0000:0x1bd5, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 100, this.oParent.Var_19d4_Rectangle, 0, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L1be2:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4f42)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x140);
			if (this.oCPU.Flags.GE) goto L1c35;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffd0);
			if (this.oCPU.Flags.LE) goto L1c35;

			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.DX.Word;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1c2d, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, 
					(ushort)(this.oCPU.BP.Word - 0x24)) << 1) + 0x4f4a)) + 132,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x20)));

		L1c35:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x4);
			if (this.oCPU.Flags.L) goto L1be2;

			// Instruction address 0x0000:0x1c5c, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 100, 320, 100, this.oParent.Var_aa_Rectangle, 0, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))));

		L1c67:
			this.oCPU.AX.Word = this.oParent.Var_5c_TickCount;
			this.oCPU.DoEvents();
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.L) goto L1c67;

			// Instruction address 0x0000:0x1c71, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			// Instruction address 0x0000:0x1c76, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1c89;
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.NE) goto L1c89;
			goto L1ba8;

		L1c89:
			// Instruction address 0x0000:0x1c89, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x1c8e, size: 5
			this.oParent.Segment_1403.F0_1403_4545();
			
			// Instruction address 0x0000:0x1c96, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0);

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F19_0000_1ae1");
		}
	}
}
