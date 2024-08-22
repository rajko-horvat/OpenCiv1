using Avalonia.Media;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System.Diagnostics;

namespace OpenCiv1
{
	public class GameInitAndIntro
	{
		private CivGame oParent;
		private VCPU oCPU;
		private CivStateData oGameData;
		private CivStaticData oStaticGameData;

		private int Var_3b62 = 0;
		private int Var_3b64 = 1;
		private int Var_3b66 = 0;
		private int Var_3b68 = 0;
		private int Var_67fc = 0;
		private int Var_6800 = 0;
		private int Var_6802 = 0;
		private int Var_6804_EvolutionStoryFileHandle = 0;
		private int Var_6806 = 0;

		public GameInitAndIntro(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
			this.oStaticGameData = parent.StaticGameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0012_GenerateMap()
		{
			this.oCPU.Log.EnterBlock("F7_0000_0012_GenerateMap()");

			// function body
			this.oGameData.Map.Parent = this.oParent; // ensure that our map has proper parents assigned
			this.oGameData.Map.Seed = 12345;
			this.oGameData.Map.GenerateNewMap();

			RandomMT19937 rng = new RandomMT19937(12345);

			// Instruction address 0x0000:0x0024, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(7, 1);

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			this.Var_67fc = 0;

			if (this.oParent.Var_d76a_IsEarthMap)
			{
				// Instruction address 0x0000:0x0049, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, $"{VCPU.DefaultCIVPath}map.pic", 1);
			}
			else
			{
				F7_0000_17cf_AdvanceEvolutionAnimation();

				#region Stage 1
				// Instruction address 0x0000:0x006b, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

				int iLandCellCount = (this.oParent.Var_7ef6_MapLandMass * 320) + 640;
				int iCount = 0;

				do
				{
					iCount += F7_0000_08be_TransferCloudToMap(rng);

					F7_0000_17cf_AdvanceEvolutionAnimation();
				}
				while (iCount < iLandCellCount);

				// Clear cells surrounding the map
				for (int i = 0; i < 50; i++)
				{
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, 0, i, 0);
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, 1, i, 0);
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, 79, i, 0);
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, 78, i, 0);
				}
				for (int i = 0; i < 80; i++)
				{
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, 0, 0);
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, 1, 0);
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, 79, 0);
					this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, 78, 0);
				}

				for (int i = 1; i < 79; i++)
				{
					for (int j = 1; j < 49; j++)
					{
						int local_2 = 0;

						// Instruction address 0x0000:0x00d8, size: 5
						if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j) != 0)
						{
							local_2 |= 0x1;
						}

						// Instruction address 0x0000:0x00f4, size: 5
						if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i + 1, j) != 0)
						{
							local_2 |= 0x2;
						}

						// Instruction address 0x0000:0x0110, size: 5
						if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j + 1) != 0)
						{
							local_2 |= 0x4;
						}

						// Instruction address 0x0000:0x012e, size: 5
						if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i + 1, j + 1) != 0)
						{
							local_2 |= 0x8;
						}

						if (local_2 == 6 || local_2 == 9)
						{
							// Instruction address 0x0000:0x0157, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 1, j, 1);

							// Instruction address 0x0000:0x016c, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j + 1, 1);

							// Instruction address 0x0000:0x017b, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 1, j + 1, 1);

							if (i > 0)
							{
								i--;
							}

							if (j > 0)
							{
								j--;
							}
						}
					}

					F7_0000_17cf_AdvanceEvolutionAnimation();
				}
				#endregion

				#region Stage 2
				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						// Instruction address 0x0000:0x01e2, size: 5
						switch (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j))
						{
							case 0:
								// Instruction address 0x0000:0x01c4, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, 1);
								break;

							case 1:
								// Instruction address 0x0000:0x020b, size: 5
								// Instruction address 0x0000:0x021c, size: 5
								int local_4 = Math.Abs(rng.Next(8) + j - 29) + (1 - this.oParent.Var_7ef8_MapTemperature);

								if (((local_4 / 6) + 1) < 8)
								{
									switch ((local_4 / 6) + 1)
									{
										case 0:
										case 1:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, 14);
											break;

										case 2:
										case 3:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, 6);
											break;

										case 4:
										case 5:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, 7);
											break;

										case 6:
										case 7:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, 15);
											break;
									}
								}
								break;

							case 2:
								// Instruction address 0x0000:0x01c4, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, 12);
								break;

							default:
								// Instruction address 0x0000:0x01c4, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, 13);
								break;
						}
					}

					F7_0000_17cf_AdvanceEvolutionAnimation();
				}
				#endregion

				#region Stage 3
				for (int i = 0; i < 50; i++)
				{
					// Instruction address 0x0000:0x0455, size: 5
					int local_4 = Math.Abs(25 - i);
					int local_8 = 0;

					for (int j = 0; j < 80; j++)
					{
						// Instruction address 0x0000:0x030d, size: 5
						int local_2 = this.oParent.Graphics.F0_VGA_038c_GetPixel(1, j, i);

						if (local_2 != 1)
						{
							if (local_8 > 0)
							{
								// Instruction address 0x0000:0x02bd, size: 5
								local_8 -= rng.Next(-((this.oParent.Var_7efa_MapClimate * 2) - 7));

								switch (local_2)
								{
									case 6:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 10);
										break;

									case 7:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 15);
										break;

									case 12:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 2);
										break;

									case 13:
										local_8 -= 3;
										break;

									case 14:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 6);
										break;
								}
							}
						}
						else if (Math.Abs(12 - local_4) + (this.oParent.Var_7efa_MapClimate * 4) > local_8)
						{
							local_8++;
						}
					}

					local_8 = 0;

					for (int j = 79; j >= 0; j--)
					{
						// Instruction address 0x0000:0x03dc, size: 5
						int local_2 = this.oParent.Graphics.F0_VGA_038c_GetPixel(1, j, i);

						if (local_2 == 1)
						{
							if (((local_4 / 2) + this.oParent.Var_7efa_MapClimate) > local_8)
							{
								local_8++;
							}
						}
						else
						{
							if (local_8 > 0)
							{
								// Instruction address 0x0000:0x037e, size: 5
								local_8 -= rng.Next(-((this.oParent.Var_7efa_MapClimate * 2) - 7));

								switch (local_2)
								{
									case 3:
									case 12:
										// Instruction address 0x0000:0x03c1, size: 5
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 2);
										break;

									case 6:
										// Instruction address 0x0000:0x03c1, size: 5
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 10);
										break;

									case 10:
										if (local_4 < 10)
										{
											// Instruction address 0x0000:0x0424, size: 5
											this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 11);
										}
										else
										{
											// Instruction address 0x0000:0x0424, size: 5
											this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 3);
										}

										local_8 = -2;
										break;

									case 13:
										local_8 -= 3;
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 2);
										break;

									case 14:
										// Instruction address 0x0000:0x03c1, size: 5
										this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, i, 6);
										break;
								}
							}
						}
					}

					F7_0000_17cf_AdvanceEvolutionAnimation();
				}
				#endregion

				#region Stage 4
				iCount = 800 + (800 * this.oParent.Var_7efc_MapAge);

				int xPos = 0;
				int yPos = 0;

				for (int i = 0; i < iCount; i++)
				{
					if ((i & 0x1) != 0)
					{
						// Instruction address 0x0000:0x0553, size: 5
						GPoint direction = this.oStaticGameData.MoveOffsets[rng.Next(8) + 1];

						xPos += direction.X;
						yPos += direction.Y;
					}
					else
					{
						// Instruction address 0x0000:0x0479, size: 5
						xPos = rng.Next(80);

						// Instruction address 0x0000:0x0488, size: 5
						yPos = rng.Next(50);
					}

					if (xPos >= 0 && xPos < 80 && yPos >= 0 && yPos < 50)
					{
						// Instruction address 0x0000:0x049d, size: 5
						int local_2 = this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos);

						switch (local_2)
						{
							case 2:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 11);
								break;

							case 3:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 10);
								break;

							case 4:
							case 5:
							case 8:
							case 9:
								break;

							case 6:
							case 7:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 12);
								break;

							case 10:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 2);
								break;

							case 11:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 3);
								break;

							case 12:
							case 15:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 13);
								break;

							case 13:
								if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos - 1, yPos - 1) != 1 &&
									this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos - 1, yPos + 1) != 1 &&
									this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + 1, yPos - 1) != 1 &&
									this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + 1, yPos + 1) != 1)
								{
									// Instruction address 0x0000:0x0652, size: 5
									this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 1);
								}
								break;

							case 14:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 6);
								break;
						}
					}
				}
				#endregion

				#region Stage 5
				int iMax = ((this.oParent.Var_7ef6_MapLandMass + this.oParent.Var_7efa_MapClimate) * 2) + 6;

				for (int i = 0, j = 0; i < 256 && j < iMax; i++)
				{
					int local_2;
					int local_4;
					int local_16 = 0;

					// Instruction address 0x0000:0x0686, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 160, 100, this.oParent.Var_aa_Rectangle, 160, 0);

					do
					{
						// Instruction address 0x0000:0x0697, size: 5
						xPos = rng.Next(80);
						// Instruction address 0x0000:0x06a6, size: 5
						yPos = rng.Next(50);
					}
					while (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos) != 12); // Instruction address 0x0000:0x06b9, size: 5

					int xPos1 = xPos;
					int yPos1 = yPos;

					// Instruction address 0x0000:0x06d6, size: 5
					int local_18 = rng.Next(4) * 2;

					do
					{
						// Instruction address 0x0000:0x06f4, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 9);

						local_4 = 0;

						for (int k = 1; k < 9; k += 2)
						{
							GPoint direction1 = this.oStaticGameData.MoveOffsets[k];

							// Instruction address 0x0000:0x071f, size: 5
							if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + direction1.X, yPos + direction1.Y) == 1)
							{
								local_4 = 1;
								break;
							}
						}

						int local_10 = local_18;

						// Instruction address 0x0000:0x0745, size: 5
						local_18 = ((rng.Next(2) - (local_16 & 0x1)) * 2 + local_18) & 0x7;

						if ((local_10 ^ 0x4) > local_18)
						{
							// Instruction address 0x0000:0x077c, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos + 50, 8);
						}

						GPoint direction = this.oStaticGameData.MoveOffsets[local_18 + 1];

						xPos += direction.X;
						yPos += direction.Y;

						// Instruction address 0x0000:0x07a1, size: 5
						local_2 = this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos);
						local_16++;
					}
					while (local_4 == 0 && local_2 != 1 && local_2 != 9 && local_2 != 13);

					if ((local_4 == 0 && local_2 != 9) || local_16 < 5)
					{
						// Instruction address 0x0000:0x07f4, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 160, 0, 160, 100, this.oParent.Var_aa_Rectangle, 0, 0);
					}
					else
					{
						j++;

						for (int k = 1; k < 22; k++)
						{
							GPoint direction = this.oStaticGameData.MoveOffsets[k];

							xPos = xPos1 + direction.X;
							yPos = yPos1 + direction.Y;

							// Instruction address 0x0000:0x0827, size: 5
							if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos) == 2)
							{
								// Instruction address 0x0000:0x0842, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos, yPos, 11);
							}
						}
					}

					F7_0000_17cf_AdvanceEvolutionAnimation();
				}

				// Instruction address 0x0000:0x0893, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 50, 80, 50, this.oParent.Var_aa_Rectangle, 0, 150);

				// Instruction address 0x0000:0x08b1, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 50, 80, 50, 0);
				#endregion
			}

			#region Stage 6
			// Instruction address 0x0000:0x058e, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 160, 0, 160, 200, 0);

			for (int i = 0; i < 2; i++)
			{
				int local_ac = 0;
				int[] local_a4 = new int[64];
				int[] local_d0 = new int[17];
				int[,] aPattern = new int[80, 50];

				for (int j = 0; j < 80; j++)
				{
					for (int k = 0; k < 50; k++)
					{
						aPattern[j, k] = 0;
					}
				}

				for (int j = 0; j < 50; j++)
				{
					int local_22 = -1;
					int local_6 = 0;
					int local_ae = 0;

					for (int k = 0; k < 80; k++)
					{
						int local_aa = F7_0000_176d_GetMapTerrainType_Screen1(k, j);

						if ((i == 0 && local_aa != 10) || (i == 1 && local_aa == 10))
						{
							if (j > 0)
							{
								if (k != 0)
								{
									local_ac = -1;
								}
								else
								{
									local_ac = 0;
								}

								while ((k < 79 && local_ac <= 1) || (k >= 79 && local_ac <= 0))
								{
									if (j > 0)
									{
										local_d0[0] = aPattern[k + local_ac, j - 1];
									}
									else
									{
										local_d0[0] = aPattern[k + local_ac - 1, 49];
									}

									if (local_d0[0] != 0)
									{
										if (local_22 != -1 && local_22 != local_d0[0])
										{
											for (int l = 0; l <= j; l++)
											{
												for (int m = 0; m < 80; m++)
												{
													if (aPattern[m, l] == local_22)
													{
														aPattern[m, l] = (ushort)((short)local_d0[0]);
													}

													switch (i)
													{
														case 0:
															this.oGameData.Continents[local_d0[0]].Size += this.oGameData.Continents[local_22].Size;
															this.oGameData.Continents[local_22].Size = 0;
															break;

														case 1:
															this.oGameData.Oceans[local_d0[0]].Size += this.oGameData.Oceans[local_22].Size;
															this.oGameData.Oceans[local_22].Size = 0;
															break;

														default:
															throw new IndexOutOfRangeException("Continent selector out of range");
													}
												}
											}
										}

										local_22 = local_d0[0];

										F7_0000_17cf_AdvanceEvolutionAnimation();
									}

									local_ac++;
								}
							}

							if (local_22 == -1)
							{
								if (local_6 == 0)
								{
									local_ae = 0;

								L0bac:
									local_ae++;

									switch (i)
									{
										case 0:
											if (this.oGameData.Continents[local_ae].Size != 0)
												goto L0bac;

											break;

										case 1:
											if (this.oGameData.Oceans[local_ae].Size != 0)
												goto L0bac;

											break;

										default:
											throw new IndexOutOfRangeException("Continent selector out of range");
									}
								}

								local_22 = local_ae;
							}

							aPattern[k, j] = (ushort)((short)local_22);

							switch (i)
							{
								case 0:
									this.oGameData.Continents[local_22].Size++;
									break;

								case 1:
									this.oGameData.Oceans[local_22].Size++;
									break;

								default:
									throw new IndexOutOfRangeException("Continent selector out of range");
							}

							local_6 = 1;
						}
						else
						{
							local_6 = 0;
							local_22 = -1;
						}
					}

					F7_0000_17cf_AdvanceEvolutionAnimation();
				}

				for (int j = 0; j < 16; j++)
				{
					local_d0[j + 1] = 0;
				}

				local_a4[0] = 0;

				for (int j = 1; j < 64; j++)
				{
					local_a4[j] = 15;

					for (int k = 1; k < 15; k++)
					{
						bool flag = false;

						switch (i)
						{
							case 0:
								if (this.oGameData.Continents[local_d0[k + 1]].Size >= this.oGameData.Continents[j].Size)
									flag = true;
								break;

							case 1:
								if (this.oGameData.Oceans[local_d0[k + 1]].Size >= this.oGameData.Oceans[j].Size)
									flag = true;
								break;

							default:
								throw new IndexOutOfRangeException("Continent selector out of range");
						}

						if (!flag)
						{
							for (int l = 15; l > k; l--)
							{
								local_a4[local_d0[l]] = l;
								local_d0[l + 1] = local_d0[l];
							}

							local_a4[j] = k;
							local_d0[k + 1] = j;

							break;
						}
					}
				}

				local_a4[0] = 0;

				for (int j = 0; j < 80; j++)
				{
					for (int k = 0; k < 50; k++)
					{
						if (local_a4[aPattern[j, k]] != 0)
						{
							// Instruction address 0x0000:0x0d67, size: 5
							this.oParent.Graphics.F0_VGA_0550_SetPixel(1, j, k + 50, (byte)((sbyte)local_a4[aPattern[j, k]]));
						}
					}
				}

				for (int j = 1; j < 15; j++)
				{
					switch (i)
					{
						case 0:
							local_d0[j + 1] = this.oGameData.Continents[local_d0[j + 1]].Size;
							break;

						case 1:
							local_d0[j + 1] = this.oGameData.Oceans[local_d0[j + 1]].Size;
							break;

						default:
							throw new IndexOutOfRangeException("Continent selector out of range");
					}
				}

				for (int j = 1; j < 15; j++)
				{
					switch (i)
					{
						case 0:
							this.oGameData.Continents[j].Size = (short)local_d0[j + 1];
							break;

						case 1:
							this.oGameData.Oceans[j].Size = (short)local_d0[j + 1];
							break;

						default:
							throw new IndexOutOfRangeException("Continent selector out of range");
					}
				}

				switch (i)
				{
					case 0:
						this.oGameData.Continents[0].Size = 0;
						this.oGameData.Continents[15].Size = 1;
						break;

					case 1:
						this.oGameData.Oceans[0].Size = 0;
						this.oGameData.Oceans[15].Size = 1;
						break;

					default:
						throw new IndexOutOfRangeException("Continent selector out of range");
				}
			}
			#endregion

			F7_0000_17cf_AdvanceEvolutionAnimation();

			// Instruction address 0x0000:0x0e0c, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19e8_Rectangle, 0, 0);

			F7_0000_1188_InitPathFind();

			F7_0000_1440_InitAuxPathFind(true);

			F7_0000_17cf_AdvanceEvolutionAnimation();

			F7_0000_0f0a_ProcessBuildSites();

			#region Render polar caps
			// Instruction address 0x0000:0x0e49, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 0, 79, 0, 15);

			// Instruction address 0x0000:0x0e68, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 49, 79, 49, 15);

			for (int i = 0; i < 20; i++)
			{
				// Instruction address 0x0000:0x0e8d, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(1, rng.Next(80), 0, 7);

				// Instruction address 0x0000:0x0eae, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(1, rng.Next(80), 1, 7);

				// Instruction address 0x0000:0x0ecf, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(1, rng.Next(80), 48, 7);

				// Instruction address 0x0000:0x0ef0, size: 5
				this.oParent.Graphics.F0_VGA_0550_SetPixel(1, rng.Next(80), 49, 7);
			}
			#endregion

			StreamWriter writer = new StreamWriter("Map.log");
			for (int i = 0; i < 50; i++)
			{
				writer.Write("[");
				for (int j = 0; j < 80; j++)
				{
					if (j > 0)
						writer.Write(", ");

					writer.Write(this.oParent.Graphics.F0_VGA_038c_GetPixel(1, j, i));
				}
				writer.WriteLine("]");
			}

			writer.WriteLine();
			writer.WriteLine("--- Groups ---");

			// Output Ocean Groups
			writer.Write("[");
			for (int i = 0; i < this.oGameData.Oceans.Length; i++)
			{
				if (i > 0)
					writer.Write(", ");

				Continent group = this.oGameData.Oceans[i];

				writer.Write($"({i}, {group.Size}, {group.BuildSiteCount})");
			}
			writer.WriteLine("]");

			// Output Continent Groups
			writer.Write("[");
			for (int i = 0; i < this.oGameData.Continents.Length; i++)
			{
				if (i > 0)
					writer.Write(", ");

				Continent group = this.oGameData.Continents[i];

				writer.Write($"({i}, {group.Size}, {group.BuildSiteCount})");
			}
			writer.WriteLine("]");

			writer.Close();

			Map map = new Map(80, 50, 12345);

			map.GenerateNewMap();

			this.Var_67fc = 1;

			while (F7_0000_17cf_AdvanceEvolutionAnimation() != 0) ;

			// check generated map
			for (int i = 0; i < 80; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					int local_2 = this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j);

					if (local_2 < 0 || local_2 > 15 || local_2 == 0 || local_2 == 4 || local_2 == 5 || local_2 == 8)
					{
						throw new Exception("Unknown terrain type generated");
					}
				}
			}

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x05c6, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19e8_Rectangle, 0, 0);

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0012_GenerateMap");
		}

		/// <summary>
		/// Transfers newly generated cloud to map
		/// </summary>
		private int F7_0000_08be_TransferCloudToMap(RandomMT19937 rng)
		{
			this.oCPU.Log.EnterBlock("F7_0000_08be_TransferCloudToMap()");

			// function body
			int iLandCellCount = 0;

			// Instruction address 0x0000:0x08da, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 160, 0, 80, 50, 0);

			// Instruction address 0x0000:0x08e6, size: 5
			// Instruction address 0x0000:0x08f8, size: 5
			F7_0000_0988_GenerateNewCloud(rng.Next(72) + 4, rng.Next(34) + 8, rng);

			for (int i = 0; i < 80; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					// Instruction address 0x0000:0x093f, size: 5
					if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i + 160, j) != 0)
					{
						// Instruction address 0x0000:0x0956, size: 5
						// Instruction address 0x0000:0x0966, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i, j, (byte)(this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j) + 1));

						iLandCellCount++;
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_08be_TransferCloudToMap");

			return iLandCellCount;
		}

		/// <summary>
		/// Generates new cloud
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		private void F7_0000_0988_GenerateNewCloud(int xPos, int yPos, RandomMT19937 rng)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_0988_GenerateNewCloud({xPos}, {yPos})");

			// function body
			int iCloudSize = rng.Next(64) + 1;

			do
			{
				// triangle shaped cloud (Default)
				this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos + 160, yPos, 15);
				this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos + 161, yPos, 15);
				this.oParent.Graphics.F0_VGA_0550_SetPixel(1, xPos + 160, yPos + 1, 15);

				switch (rng.Next(4))
				{
					case 0:
						xPos += 0;
						yPos += -1;
						break;

					case 1:
						xPos += 1;
						yPos += 0;
						break;

					case 2:
						xPos += 0;
						yPos += 1;
						break;

					case 3:
						xPos += -1;
						yPos += 0;
						break;
				}

				iCloudSize--;

			} while (iCloudSize > 0 && xPos > 2 && xPos < 77 && yPos > 2 && yPos < 47);

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0988_GenerateNewCloud");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0f0a_ProcessBuildSites()
		{
			this.oCPU.Log.EnterBlock("F7_0000_0f0a_ProcessBuildSites()");

			// function body
			int[] local_38 = new int[24];

			for (int i = 0; i < 16; i++)
			{
				this.oGameData.Continents[i].BuildSiteCount = 0;
			}

			for (int i = 0; i < 24; i++)
			{
				int local_2 = i % 12;

				local_38[i] = (3 * this.oStaticGameData.Terrains[i].Food) + this.oStaticGameData.Terrains[i].Trade;

				if (local_2 != 2 && local_2 != 11)
				{
					local_38[i] += this.oStaticGameData.Terrains[i].Production * 2;
				}

				if (this.oStaticGameData.TerrainMultipliers[local_2].Multi3 < 0)
				{
					local_38[i] += -1 - this.oStaticGameData.TerrainMultipliers[local_2].Multi3;
				}
				else
				{
					if (this.oStaticGameData.TerrainMultipliers[local_2].Multi1 < 0)
					{
						local_38[i] += (-1 - this.oStaticGameData.TerrainMultipliers[local_2].Multi1) * 2;
					}
				}
			}

			for (int i = 2; i < 78; i++)
			{
				for (int j = 2; j < 48; j++)
				{
					int terrainType = F7_0000_176d_GetMapTerrainType_Screen1(i, j);

					if (terrainType == 11 || terrainType == 2 || terrainType == 1)
					{
						int local_4;
						int local_6 = 0;

						for (int k = 0; k < 21; k++)
						{
							local_4 = 0;
							int xPos = this.oStaticGameData.CityOffsets[k].X + i;
							int yPos = this.oStaticGameData.CityOffsets[k].Y + j;

							terrainType = F7_0000_176d_GetMapTerrainType_Screen1(xPos, yPos);

							if ((terrainType == 2 || terrainType == 11) && (((xPos * 7) + (yPos * 11)) & 0x2) == 0)
							{
								local_4 += 2;
							}

							// Instruction address 0x0000:0x1081, size: 5
							if (this.oParent.Segment_2aea.F0_2aea_1836_HasSpecialResource(xPos, yPos))
							{
								terrainType += 12;
							}

							local_4 += local_38[terrainType];

							if (k < 9)
							{
								local_4 += local_4;
							}

							if (k == 0)
							{
								local_4 += local_4;
							}

							local_6 += local_4;
						}

						terrainType = F7_0000_176d_GetMapTerrainType_Screen1(i, j);

						if (terrainType != 1 && (((i * 7) + (j * 11)) & 0x2) != 0)
						{
							local_6 -= 16;
						}

						// Instruction address 0x0000:0x1111, size: 5
						local_4 = (this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((local_6 - 120) / 8, 1, 15) / 2) + 8;

						// Instruction address 0x0000:0x1138, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 80, j, (byte)local_4);

						// Instruction address 0x0000:0x1151, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 80, j + 50, (byte)local_4);

						this.oGameData.Continents[(short)F7_0000_178e_GetMapGroupID_Screen1(i, j)].BuildSiteCount++;
					}
					else
					{
						// Instruction address 0x0000:0x0fd3, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 80, j, 0);

						// Instruction address 0x0000:0x0fec, size: 5
						this.oParent.Graphics.F0_VGA_0550_SetPixel(1, i + 80, j + 50, 0);
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0f0a_ProcessBuildSites");
		}

		/// <summary>
		/// Initializes Path finding array (used exclusively withing GoTo function)
		/// </summary>
		public void F7_0000_1188_InitPathFind()
		{
			this.oCPU.Log.EnterBlock("F7_0000_1188_InitLandPathfinding()");

			// function body
			GPoint direction;

			// Instruction address 0x0000:0x119b, size: 5
			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					this.oGameData.PathFind[i, j] = 0;
				}
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					int xPos = 0;
					int yPos = 0;
					int xPos1 = (i * 4) + 1;
					int yPos1 = (j * 4) + 1;
					int local_18 = -1;

					if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1, yPos1) != 10)
					{
						// Instruction address 0x0000:0x1249, size: 5
						local_18 = GetContinentID_Screen1(xPos1, yPos1);
						xPos = xPos1;
						yPos = yPos1;
					}
					else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1 + 1, yPos1) != 10)
					{
						// Instruction address 0x0000:0x11c3, size: 5
						local_18 = GetContinentID_Screen1(xPos1 + 1, yPos1);
						xPos = xPos1 + 1;
						yPos = yPos1;
					}
					else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1, yPos1 + 1) != 10)
					{
						// Instruction address 0x0000:0x11ec, size: 5
						local_18 = GetContinentID_Screen1(xPos1, yPos1 + 1);
						xPos = xPos1;
						yPos = yPos1 + 1;
					}
					else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1 + 1, yPos1 + 1) != 10)
					{
						// Instruction address 0x0000:0x127a, size: 5
						local_18 = GetContinentID_Screen1(xPos1 + 1, yPos1 + 1);
						xPos = xPos1 + 1;
						yPos = yPos1 + 1;
					}

					if (local_18 != -1)
					{
						for (int k = 1; k < 5; k++)
						{
							direction = this.oStaticGameData.MoveOffsets[k];

							int xPos2 = xPos1 + direction.X * 4;
							int yPos2 = yPos1 + direction.Y * 4;
							int xPos3 = 0;
							int yPos3 = 0;
							int local_e = -1;

							if (F7_0000_176d_GetMapTerrainType_Screen1(xPos2, yPos2) != 10)
							{
								// Instruction address 0x0000:0x1343, size: 5
								local_e = GetContinentID_Screen1(xPos2, yPos2);
								xPos3 = xPos2;
								yPos3 = yPos2;
							}
							else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos2 + 1, yPos2) != 10)
							{
								// Instruction address 0x0000:0x12ad, size: 5
								local_e = GetContinentID_Screen1(xPos2 + 1, yPos2);
								xPos3 = xPos2 + 1;
								yPos3 = yPos2;
							}
							else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos2, yPos2 + 1) != 10)
							{
								// Instruction address 0x0000:0x12d9, size: 5
								local_e = GetContinentID_Screen1(xPos2, yPos2 + 1);
								xPos3 = xPos2;
								yPos3 = yPos2 + 1;
							}
							else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos2 + 1, yPos2 + 1) != 10)
							{
								// Instruction address 0x0000:0x1377, size: 5
								local_e = GetContinentID_Screen1(xPos2 + 1, yPos2 + 1);
								xPos3 = xPos2 + 1;
								yPos3 = yPos2 + 1;
							}

							if (local_18 == local_e)
							{
								// Test if the goto path is valid
								// Instruction address 0x0000:0x139e, size: 5
								int local_10 = this.oParent.UnitGoTo.F0_2e31_111c_CreateBarbarianUnit(xPos, yPos, xPos3, yPos3, 0, 20);

								if (local_10 != -1 && local_10 < 20)
								{
									this.oGameData.PathFind[i, j] |= (byte)(1 << (k - 1));

									direction = this.oStaticGameData.MoveOffsets[k];

									xPos2 = i + direction.X;
									yPos2 = j + direction.Y;

									if (xPos2 >= 0 && xPos2 < 20 && yPos2 >= 0 && yPos2 < 13)
									{
										this.oGameData.PathFind[xPos2, yPos2] |= (byte)(1 << ((k + 3) & 0x7));
									}
								}
							}
						}
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1188_InitLandPathfinding");
		}

		/// <summary>
		/// Initializes auxial Path finding array (used exclusively withing GoTo function)
		/// </summary>
		/// <param name="flag"></param>
		public void F7_0000_1440_InitAuxPathFind(bool flag)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_1440({flag})");

			// function body
			// Instruction address 0x0000:0x1453, size: 5
			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					this.oParent.UnitGoTo.Var_7f38_AuxPathFind[i, j] = 0;
				}
			}

			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 12; j++)
				{
					int xPos = (i * 4) + 1;
					int yPos = (j * 4) + 1;
					int local_16 = -1;

					if (F7_0000_176d_GetMapTerrainType_Screen1(xPos, yPos) == 10)
					{
						local_16 = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos, yPos);
					}
					else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos + 1, yPos) == 10)
					{
						local_16 = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos + 1, yPos);
					}
					else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos, yPos + 1) == 10)
					{
						local_16 = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos, yPos + 1);
					}
					else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos + 1, yPos + 1) == 10)
					{
						local_16 = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos + 1, yPos + 1);
					}

					if (local_16 != -1)
					{
						for (int k = 0; k < 9; k++)
						{
							GPoint direction = this.oStaticGameData.MoveOffsets[k];

							int xPos1 = xPos + (direction.X * 4);
							int yPos1 = yPos + (direction.Y * 4);
							int local_e = -1;

							if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1, yPos1) == 10)
							{
								local_e = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos1, yPos1);
							}
							else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1 + 1, yPos1) == 10)
							{
								local_e = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos1 + 1, yPos1);
							}
							else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1, yPos1 + 1) == 10)
							{
								local_e = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos1, yPos1 + 1);
							}
							else if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1 + 1, yPos1 + 1) != 10)
							{
								local_e = (short)F7_0000_178e_GetMapGroupID_Screen1(xPos1 + 1, yPos1 + 1);
							}

							if (local_16 == local_e)
							{
								xPos1 = xPos;
								yPos1 = yPos;
								int local_10 = 1;

								for (int l = 0; l < 5; l++)
								{
									direction = this.oStaticGameData.MoveOffsets[k];

									xPos1 += direction.X;
									yPos1 += direction.Y;
									int local_6 = 4;

									// Instruction address 0x0000:0x15fe, size: 5
									if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1, yPos1) != 10 || this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(xPos1, yPos1) == 0)
									{
										local_6--;
									}

									// Instruction address 0x0000:0x1625, size: 5
									if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1 + 1, yPos1) != 10 || this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(xPos1 + 1, yPos1) == 0)
									{
										local_6--;
									}

									// Instruction address 0x0000:0x164c, size: 5
									if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1, yPos1 + 1) != 10 || this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(xPos1, yPos1 + 1) == 0)
									{
										local_6--;
									}

									// Instruction address 0x0000:0x1673, size: 5
									if (F7_0000_176d_GetMapTerrainType_Screen1(xPos1 + 1, yPos1 + 1) != 10 || this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(xPos1 + 1, yPos1 + 1) == 0)
									{
										local_6--;
									}

									if (local_6 < 2)
									{
										local_10 = 0;
										break;
									}									
								}

								if (local_10 != 0 || (j == 11 && k == 3))
								{
									direction = this.oStaticGameData.MoveOffsets[k];

									if (j + direction.Y < 12)
									{
										this.oParent.UnitGoTo.Var_7f38_AuxPathFind[i, j] |= (byte)(1 << (k - 1));

										xPos1 = i + direction.X;
										yPos1 = j + direction.Y;

										if (xPos1 >= 0 && xPos1 < 20 && j + direction.Y >= 0 && j + direction.Y <= 12)
										{
											this.oParent.UnitGoTo.Var_7f38_AuxPathFind[xPos1, j + direction.Y] |= (byte)(1 << ((k + 3) & 0x7));
										}
									}
								}
							}
						}
					}
				}

				if (flag)
				{
					F7_0000_17cf_AdvanceEvolutionAnimation();
				}
			}

			for (int i = 0; i < 12; i++)
			{
				this.oParent.UnitGoTo.Var_7f38_AuxPathFind[0, i] |= 0xe0;
				this.oParent.UnitGoTo.Var_7f38_AuxPathFind[19, i] |= 0xe;
			}

			this.oParent.UnitGoTo.Var_7f38_AuxPathFind[0, 0] &= 0x7f;
			this.oParent.UnitGoTo.Var_7f38_AuxPathFind[0, 11] &= 0xdf;
			this.oParent.UnitGoTo.Var_7f38_AuxPathFind[19, 0] &= 0xfd;
			this.oParent.UnitGoTo.Var_7f38_AuxPathFind[19, 11] &= 0xf7;

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1440");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F7_0000_176d_GetMapTerrainType_Screen1(int xPos, int yPos)
		{
			// function body
			return this.oParent.Array_2ba6[this.oParent.Graphics.F0_VGA_038c_GetPixel(this.oParent.Var_aa_Rectangle.ScreenID, xPos, yPos)];
		}

		public byte GetContinentID_Screen1(int xPos, int yPos)
		{
			return this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos + 50);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public byte F7_0000_178e_GetMapGroupID_Screen1(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_178e({xPos}, {yPos})");

			// function body
			// Instruction address 0x0000:0x17a1, size: 5
			this.oCPU.AX.Word = this.oParent.Graphics.F0_VGA_038c_GetPixel(this.oParent.Var_aa_Rectangle.ScreenID, xPos, yPos + 50);

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_178e");

			return this.oCPU.AX.Low;
		}

		/// <summary>
		/// ?
		/// </summary>
		public ushort F7_0000_17cf_AdvanceEvolutionAnimation()
		{
			this.oCPU.Log.EnterBlock("F7_0000_17cf_AdvanceEvolutionAnimation()");

			// function body
			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x17e4, size: 5
			if (this.Var_3b62 >= 2 && this.oParent.MSCAPI.kbhit() == 0)
			{
				if (this.Var_3b62 < 5)
				{
					this.Var_3b62++;

					if (this.Var_3b62 == 5)
					{
						// Instruction address 0x0000:0x1816, size: 5
						this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 40, 160, 240, 8, 0);
					}
				}
				else
				{
					this.oCPU.DoEvents();
					this.Var_6800 = (int)this.oParent.Var_5c_TickCount / 60;

					// Instruction address 0x0000:0x1847, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0("BUILDING NEW WORLD...", 160, 160, (byte)(((this.Var_6800 & 0x1) != 0) ? 15 : 3));
				}

				this.oParent.Var_aa_Rectangle.ScreenID = 1;

				this.oCPU.AX.Word = 0;
			}
			else
			{
				if (this.Var_3b62 == 0)
				{
					// Instruction address 0x0000:0x1869, size: 5
					this.Var_6804_EvolutionStoryFileHandle = this.oParent.MSCAPI.fopen("story.txt", "rt");
					this.Var_3b62 = 1;
					this.Var_6806 = 0;
					this.Var_6800 = 0;

					// Instruction address 0x0000:0x188a, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, "");

					this.oParent.Var_aa_Rectangle.FontID = 7;
					this.Var_6802 = 0;
				}

				if (this.Var_6802 != 0)
				{
					// Instruction address 0x0000:0x18a8, size: 5
					this.Var_6800 = (short)this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer();
				}

				if (this.Var_6800 < this.Var_6806)
				{
					this.oParent.Var_aa_Rectangle.ScreenID = 1;
					this.oCPU.AX.Word = 1;
				}
				else
				{
					if (this.Var_3b62 != 2 && this.Var_6802 < 40)
					{
						// Instruction address 0x0000:0x18df, size: 5
						this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 3);

						// Instruction address 0x0000:0x18eb, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(5);
					}

					// Instruction address 0x0000:0x18ff, size: 5
					int charCount = this.oParent.MSCAPI.fscanf((short)this.Var_6804_EvolutionStoryFileHandle, "%[^\n]\n", 0xba06);

					if (charCount != -1 && (this.oParent.MSCAPI.kbhit() == 0 || this.Var_67fc == 0))
					{
						if (this.Var_3b64 > 1)
						{
							// Instruction address 0x0000:0x194a, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 0, 160, 320, 8, this.oParent.Var_aa_Rectangle, 0, 160);
						}

						// Instruction address 0x0000:0x1956, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

						// Instruction address 0x0000:0x196b, size: 5
						this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 3);

						// Instruction address 0x0000:0x1977, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(5);

						// Instruction address 0x0000:0x198c, size: 5
						this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 11);

						this.Var_6806 = 0;

						// Instruction address 0x0000:0x199e, size: 5
						if ((short)this.oParent.MSCAPI.strlen(0xba06) > 3)
						{
							if (this.Var_6802 == 0)
							{
								// Instruction address 0x0000:0x19b2, size: 5
								this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();

								// Instruction address 0x0000:0x19bb, size: 5
								this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

								// Instruction address 0x0000:0x19c7, size: 5
								this.oParent.Segment_1000.F0_1000_0a32_PlayTune(4, 0);
							}

							this.Var_6806 += 2;
							this.Var_6802++;
						}
						else
						{
							// Instruction address 0x0000:0x19e3, size: 5
							string sFileName = $"birth{this.Var_3b64}.pic";

							this.Var_3b64++;

							if (this.oParent.Var_d762 != 0)
							{
								for (int i = 1; i <= this.Var_3b68; i++)
								{
									// Instruction address 0x0000:0x1a06, size: 5
									this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(i);
								}
							}

							// Instruction address 0x0000:0x1a21, size: 5 
							this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(2, 0, 0, VCPU.DefaultCIVPath + sFileName, 0);

							if (this.oParent.Var_d762 != 0)
							{
								// Instruction address 0x0000:0x1a39, size: 5
								this.oParent.Segment_1000.F0_1000_04d4_TransformPaletteToColor(8, Color.FromRgb(0, 0, 0));
							}

							// Instruction address 0x0000:0x1a59, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

							if (this.oParent.Var_d762 != 0)
							{
								// Instruction address 0x0000:0x1a73, size: 5
								sFileName = sFileName.Replace(".pic", ".pal");

								// Instruction address 0x0000:0x1a83, size: 5
								this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, VCPU.DefaultCIVPath + sFileName, 0xc5be);

								// Instruction address 0x0000:0x1a93, size: 5
								this.oParent.Segment_1000.F0_1000_04aa_TransformPalette(8, 0xc5be);

								this.Var_3b68 = 0;

								goto L1af8;

							L1aa3:
								this.oCPU.ES.Word = 0x3710; // segment
								byte cycleFromIndex = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.Var_3b66));
								this.Var_3b66++;

								byte cycleToIndex = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.Var_3b66));
								this.Var_3b66++;

								int cycleSpeed = 300 / this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.Var_3b66));
								this.Var_3b66++;

								this.Var_3b68++;

								// Instruction address 0x0000:0x1af0, size: 5
								this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(this.Var_3b68, cycleSpeed, cycleFromIndex, cycleToIndex);

							L1af8:
								this.oCPU.ES.Word = 0x3710; // segment
								if (this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.Var_3b66)) != 0) goto L1aa3;

								this.Var_3b66++;

								for (int i = 1; i <= this.Var_3b68; i++)
								{
									// Instruction address 0x0000:0x1b16, size: 5
									this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(i);
								}
							}
						}

						// Instruction address 0x0000:0x1b2d, size: 5
						if ((short)this.oParent.MSCAPI.strlen(0xba06) > 19)
						{
							this.Var_6806++;
						}

						// Instruction address 0x0000:0x1b5d, size: 5
						this.Var_6806 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oCPU.ReadInt16(0x3710, (ushort)((this.Var_6802 * 2) + 131)),
							(45 * this.Var_6806) + this.Var_6800, 32767);
					}
					else
					{
						if (charCount == -1)
						{
							// Instruction address 0x0000:0x1b74, size: 5
							this.oParent.Segment_1000.F0_1182_0134_WaitTimer(180);
						}

						// Instruction address 0x0000:0x1b80, size: 5
						this.oParent.MSCAPI.fclose((short)this.Var_6804_EvolutionStoryFileHandle);

						// Instruction address 0x0000:0x1b8c, size: 5
						this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

						if (this.oParent.Var_d762 != 0)
						{
							for (int i = 1; i <= this.Var_3b68; i++)
							{
								// Instruction address 0x0000:0x1ba5, size: 5
								this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(i);
							}
						}

						this.Var_3b62 = 2;
					}

					// Instruction address 0x0000:0x1bc1, size: 5
					this.oParent.Segment_1000.F0_1000_0846(0);

					this.oParent.Var_aa_Rectangle.ScreenID = 1;

					if (this.Var_3b62 != 2)
					{
						this.oCPU.AX.Word = 1;
					}
					else
					{
						this.oCPU.AX.Word = 0;
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_17cf_AdvanceEvolutionAnimation");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Global warming causes Icecap melt event
		/// </summary>
		/// <param name="globalWarmingCount"></param>
		public void F7_0000_1be3_IcecapMeltEvent(short globalWarmingCount)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_1be3_IcecapMeltEvent({globalWarmingCount})");

			// function body
			// Instruction address 0x0000:0x1bf2, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Global temperature\nrises! Icecaps melt.\nSevere Drought.\n");
			this.oParent.Overlay_21.F21_0000_0000(-1);

			for (int i = 0; i < 80; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					// Instruction address 0x0000:0x1cbe, size: 5
					int local_8 = (short)this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(i, j);

					if (local_8 <= 3)
					{
						int local_a = 0;

						for (int k = 1; k < 9; k++)
						{
							GPoint direction = this.oStaticGameData.MoveOffsets[k];

							// Instruction address 0x0000:0x1ced, size: 5
							if (this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(i + direction.X, j + direction.Y) == TerrainTypeEnum.Water)
							{
								local_a++;
							}
						}

						if ((7 - globalWarmingCount) <= local_a)
						{
							this.oGameData.Map[i, j].Visibility |= 1;

							if (local_8 != 3)
							{
								// Instruction address 0x0000:0x1c18, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(2, i, j, 3);
							}
							else
							{
								// Instruction address 0x0000:0x1c18, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(2, i, j, 11);
							}

							// Instruction address 0x0000:0x1c2a, size: 5
							this.oParent.Segment_2aea.F0_2aea_16ee_RemoveImprovement(i, j, 6, 0);
						}
						else
						{
							if ((((i * 11) + (j * 13)) & 0x7) != globalWarmingCount)
								continue;

							this.oGameData.Map[i, j].Visibility |= 1;

							if (local_8 <= 1)
							{
								// Instruction address 0x0000:0x1c82, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(2, i, j, 14);
							}
							else
							{
								// Instruction address 0x0000:0x1c82, size: 5
								this.oParent.Graphics.F0_VGA_0550_SetPixel(2, i, j, 6);
							}
						}

						if ((this.oGameData.Map[i, j].Visibility & (1 << this.oGameData.HumanPlayerID)) != 0)
						{
							// Instruction address 0x0000:0x1ca4, size: 5
							this.oParent.Segment_2aea.F0_2aea_11d4(i, j);
						}
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1be3_IcecapMeltEvent");
		}
	}
}
