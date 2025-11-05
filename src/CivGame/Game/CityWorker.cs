using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class CityWorker
	{
		private CivGame oParent;
		private VCPU oCPU;

		// Local variables used exclusively inside this section

		private int Var_2494 = 0;
		private int Var_2496 = 0;

		// 0x652e - after this offset the default values are set to 0

		public int Var_653e_CityID = 0;
		private int Var_6540_CityOffsetCount = 21;
		private int Var_6542 = 0;
		private int Var_6546 = 0;
		public short Var_6548_PlayerID = 0;
		private int Var_6b30 = 0;
		private int Var_70e8 = 0;
		//private ushort Var_deb6 = 0;

		public CityWorker(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="flag"></param>
		public ushort F0_1d12_0045_ProcessCityState(short cityID, short flag)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_0045({cityID}, {flag})");

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_a;
			int local_c;
			int[] Arr_3e = new int[21]; // 0x15 - 0x3e
			int local_40;
			int local_42 = 0;
			int local_44;
			int local_46;
			int local_48;
			int local_4a;
			int local_4c;
			int local_4e;
			int local_50;
			int[] Arr_74 = new int[18]; // 0x51 - 0x74
			int[,] Arr_a6 = new int[5, 5]; // 0x75 - 0xa6
			int local_a8;
			int local_ac;
			int local_ae;
			int local_b0 = 0;
			int local_b2;
			int local_b4;
			int local_b6 = 0;
			int local_b8 = 0;
			int local_ba;
			int local_bc;
			int local_be = 0;
			int local_c0;
			int local_c2;
			int local_c6;
			int local_c8;
			int local_ca = 0;
			int local_cc = 0;
			int local_ce;
			int local_d0;
			int local_d2;
			int local_d4;
			int local_d6;
			int local_d8;
			int local_da = 0;
			int local_de;
			int local_e0;
			int local_e2;
			int local_e4;
			int local_e6;
			int local_e8;
			int local_ea;
			uint local_ee_UInt;
			int local_f0;
			int local_f4;
			int local_f6;
			int local_f8;
			int local_fa;
			int local_fc;
			int local_fe = 0;
			int local_100;
			int local_102;
			int local_104;
			int local_106;
			int local_108 = 0;
			int local_10a = 0;

			this.oCPU.AX.Word = 0;
			City city = this.oParent.CivState.Cities[cityID];

			if (city.StatusFlag != 0xff)
			{
				this.Var_2496 = 0;

				// Instruction address 0x1d12:0x007e, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();

				for (int i = 0; i < 5; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						Arr_a6[i, j] = 0;
					}
				}

				local_d8 = city.Position.X;
				local_e4 = city.Position.Y;

				this.Var_653e_CityID = cityID;

				if (city.HasImprovement(ImprovementEnum.Palace))
				{
					this.Var_6b30 = 0;
				}
				else
				{
					this.Var_6b30 = 32;
				}

				if (city.ShieldsCount < 0 || city.ShieldsCount > 999)
				{
					city.ShieldsCount = 0;
				}

				for (int i = 0; i < 128; i++)
				{
					if (this.oParent.CivState.Cities[i].StatusFlag != 0xff && i != city.ID)
					{
						// Instruction address 0x1d12:0x01a2, size: 5
						local_b0 = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
							city.Position.X,
							city.Position.Y,
							this.oParent.CivState.Cities[i].Position.X,
							this.oParent.CivState.Cities[i].Position.Y);

						if (this.oParent.CivState.Cities[i].PlayerID == city.PlayerID &&
							this.oParent.CivState.Cities[i].HasImprovement(ImprovementEnum.Palace) && local_b0 < this.Var_6b30)
						{
							this.Var_6b30 = local_b0;
						}

						if (local_b0 <= 5)
						{
							for (int j = 0; j < 21; j++)
							{
								if ((this.oParent.CivState.Cities[i].WorkerFlags & (uint)(1 << j)) != 0 || j == 20)
								{
									int xPos = this.oParent.CivState.Cities[i].Position.X + this.oParent.CityOffsets[j].X;
									int yPos = this.oParent.CivState.Cities[i].Position.Y + this.oParent.CityOffsets[j].Y;

									if (Math.Abs(xPos - city.Position.X) <= 2 && Math.Abs(yPos - city.Position.Y) <= 2)
									{
										Arr_a6[xPos - city.Position.X + 2, yPos - city.Position.Y + 2] = 1;
									}
								}
							}
						}
					}
				}

				Arr_a6[2, 2] = 0;
				this.Var_6548_PlayerID = city.PlayerID;
				local_c2 = this.oParent.Var_d4cc_XPos;
				local_d0 = this.oParent.Var_d75e_YPos;

				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType <= 1)
				{
					local_48 = 1;
				}
				else
				{
					local_48 = 2;
				}

				this.oParent.Var_b882 = 0;

				if (!city.HasImprovement(ImprovementEnum.MassTransit))
				{
					// Instruction address 0x1d12:0x035e, size: 5
					if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Industrialization) != 0)
					{
						this.oParent.Var_b882++;
					}

					// Instruction address 0x1d12:0x037a, size: 5
					if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Automobile) != 0)
					{
						this.oParent.Var_b882++;
					}

					// Instruction address 0x1d12:0x0396, size: 5
					if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.MassProduction) != 0)
					{
						this.oParent.Var_b882++;
					}

					// Instruction address 0x1d12:0x03b2, size: 5
					if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Plastics) != 0)
					{
						this.oParent.Var_b882++;
					}
				}
			
				local_4a = 10;

				this.oParent.Var_e8b8 = (int)(city.WorkerFlags >>> 26);

				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
				{
					local_4a = -(this.oParent.CivState.DifficultyLevel * 2 - 16);

					if (this.oParent.CivState.Year >= 0 &&
						this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Ranking == 7 &&
						this.oParent.CivState.DifficultyLevel > 1)
					{
						local_4a -= 2;
					}

					if (flag == 0)
					{
						if ((city.StatusFlag & 0x1) == 0)
						{
							this.oParent.Var_e8b8 = 0;
						}
						else
						{
							city.WorkerFlags = 0;
						}
					}
				}

			L045f:
				local_d8 = city.Position.X;
				local_e4 = city.Position.Y;

				if (flag == 1)
				{
					// Instruction address 0x1d12:0x049a, size: 5
					this.oParent.Segment_1866.F0_1866_0006(cityID);

					// Instruction address 0x1d12:0x04ba, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

					// Instruction address 0x1d12:0x04d2, size: 5
					F0_1d12_70cb_FillRectangleWithPattern(2, 1, 208, 21);

					local_e8 = 0;

					for (int i = 1; i <= city.ActualSize; i++)
					{
						local_e8 += i;
					}

					this.oParent.Var_aa_Rectangle.FontID = 2;

					this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

					// Instruction address 0x1d12:0x051f, size: 5
					this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

					// Instruction address 0x1d12:0x052b, size: 5
					this.oParent.MSCAPI.strupr(0xba06);

					// Instruction address 0x1d12:0x053b, size: 5
					this.oParent.MSCAPI.strcat(0xba06, " (Pop:");

					// Instruction address 0x1d12:0x0547, size: 5
					this.oParent.Segment_2dc4.F0_2dc4_0337(local_e8);

					// Instruction address 0x1d12:0x0557, size: 5
					this.oParent.MSCAPI.strcat(0xba06, ")");

					// Instruction address 0x1d12:0x056f, size: 5
					this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 104, 2, 15);

					// Instruction address 0x1d12:0x0587, size: 5
					F0_1d12_70cb_FillRectangleWithPattern(127, 23, 208, 104);

					this.oParent.Var_d4cc_XPos = (short)(city.Position.X - 5);
					this.oParent.Var_d75e_YPos = (short)(city.Position.Y - 3);

					// Instruction address 0x1d12:0x05cd, size: 5
					this.oParent.MapManagement.F0_2aea_03ba(city.Position.X, city.Position.Y);

					for (int i = 0; i < this.Var_6540_CityOffsetCount; i++)
					{
						local_c6 = city.Position.X + this.oParent.CityOffsets[i].X;
						local_d2 = city.Position.Y + this.oParent.CityOffsets[i].Y;

						if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID ||
							(this.oParent.CivState.MapVisibility[local_c6, local_d2] & (1 << this.Var_6548_PlayerID)) != 0)
						{
							// Instruction address 0x1d12:0x0664, size: 5
							local_e8 = (short)this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_c6, local_d2);

							if (local_e8 != -1 && local_e8 != this.Var_6548_PlayerID)
							{
								// Instruction address 0x1d12:0x068e, size: 5
								this.oParent.MapManagement.F0_2aea_11d4(local_c6, local_d2);
							}
							else
							{
								// Instruction address 0x1d12:0x06a1, size: 5
								this.oParent.MapManagement.F0_2aea_03ba(local_c6, local_d2);

								if (Arr_a6[this.oParent.CityOffsets[i].X + 2, this.oParent.CityOffsets[i].Y + 2] != 0)
								{
									// Instruction address 0x1d12:0x06f6, size: 5
									this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
										(local_c6 - this.oParent.Var_d4cc_XPos) * 16 + 80, (local_d2 - this.oParent.Var_d75e_YPos) * 16 + 8, 15, 15, 12);
								}
							}
						}
					}
				}

				if (flag == 0)
				{
					city.StatusFlag &= 0x7f;

					if (city.FoodCount < 0)
					{
						local_e8 = -1;

						for (int i = 0; i < 128; i++)
						{
							if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID == 0 &&
								this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].HomeCityID == cityID)
							{
								local_e8 = i;
								break;
							}
						}

						if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
						{
							// Instruction address 0x1d12:0x07a6, size: 5
							this.oParent.MSCAPI.strcpy(0xba06, "Food storage exhausted\nin ");

							// Instruction address 0x1d12:0x07b1, size: 5
							this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

							if (local_e8 != -1)
							{
								// Instruction address 0x1d12:0x07d1, size: 5
								this.oParent.MSCAPI.strcat(0xba06, "!\nSettlers lost.\n");
							}
							else
							{
								// Instruction address 0x1d12:0x07d1, size: 5
								this.oParent.MSCAPI.strcat(0xba06, "!\nFamine feared.\n");
							}

							// Instruction address 0x1d12:0x07dd, size: 5
							this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

							this.oParent.Overlay_21.F21_0000_0000(cityID);

							// Instruction address 0x1d12:0x07f4, size: 5
							this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);
						}

						if (local_e8 != -1)
						{
							// Instruction address 0x1d12:0x080e, size: 5
							this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID, (short)local_e8);
						}
						else
						{
							city.ActualSize--;

							if (city.ActualSize <= 0)
							{
								// Instruction address 0x1d12:0x0843, size: 5
								this.oParent.Segment_1ade.F0_1ade_018e(cityID, city.Position.X, city.Position.Y);

								this.oParent.StartGameMenu.F5_0000_0e6c(this.Var_6548_PlayerID, 0);

								// Instruction address 0x1d12:0x085b, size: 5
								this.oParent.Segment_11a8.F0_11a8_0250();

								goto L6927;
							}
						}

						city.FoodCount = 0;

						// Instruction address 0x1d12:0x0879, size: 5
						this.oParent.Segment_1403.F0_1403_3ed7(local_d8, local_e4);
					}

					if ((city.ActualSize + 1) * local_4a <= city.FoodCount)
					{
						city.ActualSize++;

						if (city.HasImprovement(ImprovementEnum.Granary))
						{
							city.FoodCount = (short)((5 * city.ActualSize) + 5);
						}
						else
						{
							city.FoodCount = 0;
						}

						if (city.ActualSize > 10 && !city.HasImprovement(ImprovementEnum.Aqueduct) && (this.oParent.CivState.DebugFlags & 0x4) != 0)
						{
							city.ActualSize--;

							if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
							{
								this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DomesticAdvisor;

								this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

								// Instruction address 0x1d12:0x0929, size: 5
								this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

								// Instruction address 0x1d12:0x0939, size: 5
								this.oParent.MSCAPI.strcat(0xba06, " requires an AQUEDUCT\nfor further growth.\n");

								// Instruction address 0x1d12:0x094d, size: 5
								this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
							}
						}

						// Instruction address 0x1d12:0x095d, size: 5
						this.oParent.Segment_1403.F0_1403_3ed7(local_d8, local_e4);
					}
				}
			
				local_50 = city.ActualSize + 1;

				this.Var_6546 = 0;
				this.oParent.Var_deb8 = 0;
				this.oParent.Var_d2f6 = 0;
				this.oParent.Var_e3c6 = 0;

				for (int i = 0; i < 2; i++)
				{
					if (city.Unknown[i] != -1)
					{
						this.oParent.Var_deb8++;
					}
				}

				if (city.ActualSize < this.oParent.Var_deb8)
				{
					this.oParent.Var_d2f6 = this.oParent.Var_deb8 - city.ActualSize;
				}

				for (int i = 0; i < 128; i++)
				{
					if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID != -1 &&
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].HomeCityID == cityID)
					{
						if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID < 26)
						{
							this.oParent.Var_deb8++;

							if (city.ActualSize >= this.oParent.Var_deb8)
							{
								if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType > 1 && (this.oParent.CivState.DebugFlags & 2) != 0)
								{
									this.oParent.Var_d2f6++;
								}
							}
							else
							{
								this.oParent.Var_d2f6++;
							}

							if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID].AttackStrength != 0)
							{
								if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID].TerrainCategory == 1)
								{
									this.Var_6546++;
								}
								else
								{
									if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.X != city.Position.X ||
										this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.Y != city.Position.Y)
									{
										this.Var_6546++;
									}
								}
							}
						}

						if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID == 0)
						{
							this.oParent.Var_e3c6++;
						}
					}
				}

				this.Var_70e8 = 0;

				for (int i = 0; i < this.Var_6540_CityOffsetCount; i++)
				{
					Arr_3e[i] = 0;

					local_c6 = city.Position.X + this.oParent.CityOffsets[i].X;
					local_d2 = city.Position.Y + this.oParent.CityOffsets[i].Y;

					if (this.Var_6548_PlayerID != 0 && (this.oParent.CivState.MapVisibility[local_c6, local_d2] & (1 << this.Var_6548_PlayerID)) == 0)
					{
						Arr_3e[i] = 1;
					}

					// Instruction address 0x1d12:0x0bf4, size: 5
					local_e8 = (short)this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_c6, local_d2);

					if (local_e8 != -1 && local_e8 != this.Var_6548_PlayerID)
					{
						Arr_a6[this.oParent.CityOffsets[i].X + 2, this.oParent.CityOffsets[i].Y + 2] = 1;
						Arr_3e[i] = 1;

						if (local_e8 == this.oParent.CivState.HumanPlayerID)
						{
							this.Var_70e8 = 1;
						}
					}

					if (Arr_a6[this.oParent.CityOffsets[i].X + 2, this.oParent.CityOffsets[i].Y + 2] != 0)
					{
						Arr_3e[i] = 1;
					}

					if (Arr_3e[i] != 0)
					{
						city.WorkerFlags &= (uint)(~(1 << i));
					}
				}

				for (int i = 0; i < 4; i++)
				{
					this.oParent.Var_70da_Arr[i] = 0;
				}

				local_ee_UInt = 0;

				if (((ushort)this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) != 0 ||
					((cityID + this.oParent.CivState.TurnCount) & 0x3) != 0 ||
					(city.StatusFlag & 0x1) != 0 || this.Var_70e8 != 0)
				{
					for (int i = 0; i < this.Var_6540_CityOffsetCount; i++)
					{
						if ((city.WorkerFlags & (1 << i)) != 0)
						{
							local_50--;
						}
					}

					if (local_50 >= 0)
					{
						local_50 = city.ActualSize + 1;

						for (int i = 0; i < this.Var_6540_CityOffsetCount; i++)
						{
							if (local_50 != 0 && (city.WorkerFlags & (1 << i)) != 0)
							{
								Arr_3e[i] = 1;

								// Instruction address 0x1d12:0x0ddf, size: 5
								F0_1d12_692d_CityResources(cityID, i, flag);

								local_50--;

								local_ee_UInt |= (uint)(1 << i);
							}
						}
					}
					else
					{
						if (flag == 0 && this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
						{
							// Instruction address 0x1d12:0x0e26, size: 5
							this.oParent.MSCAPI.strcpy(0xba06, "Population decrease\nin ");

							// Instruction address 0x1d12:0x0e31, size: 5
							this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

							// Instruction address 0x1d12:0x0e41, size: 5
							this.oParent.MSCAPI.strcat(0xba06, ".\n");

							this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DomesticAdvisor;

							// Instruction address 0x1d12:0x0e5b, size: 5
							this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

							this.oParent.Var_b1e8 = 1;
						}

						local_50 = city.ActualSize + 1;
					}

					if (local_50 == this.oParent.Var_e8b8 || local_50 == 0)
						goto L1292;
				}

				if (local_50 > 0 && Arr_3e[20] == 0)
				{
					Arr_3e[20] = 1;

					// Instruction address 0x1d12:0x0eb2, size: 5
					F0_1d12_692d_CityResources(cityID, 20, flag);

					local_ee_UInt |= 0x100000;
					local_50--;
				}

				while ((((city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6)) > ((local_50 / 2) + this.oParent.Var_70da_Arr[0]) || city.ActualSize < 3) &&
					local_50 > this.oParent.Var_e8b8 && local_108 != -1)
				{
					local_108 = -1;
					local_d6 = 0;
					local_ce = 0;

					for (int i = 0; i < this.Var_6540_CityOffsetCount; i++)
					{
						if (Arr_3e[i] == 0)
						{
							local_c6 = city.Position.X + this.oParent.CityOffsets[i].X;
							local_d2 = city.Position.Y + this.oParent.CityOffsets[i].Y;

							// Instruction address 0x1d12:0x0f9e, size: 5
							local_cc = F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_c6, local_d2, CityResourceTypeEnum.Food);

							// Instruction address 0x1d12:0x0fb6, size: 5
							local_d4 = F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_c6, local_d2, CityResourceTypeEnum.Production) * 2;

							if (local_50 != 1 || this.oParent.Var_70da_Arr[1] != 0 || local_d4 != 0)
							{
								// Instruction address 0x1d12:0x0ff0, size: 5
								local_d4 += F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_c6, local_d2, CityResourceTypeEnum.Trade);

								if (local_cc > local_ce || (local_cc == local_ce && local_d4 > local_d6))
								{
									local_ce = local_cc;
									local_d6 = local_d4;
									local_108 = i;
								}
							}
						}
					}

					if (local_108 != -1)
						break;

					Arr_3e[local_108] = 1;

					// Instruction address 0x1d12:0x105d, size: 5
					F0_1d12_692d_CityResources(cityID, local_108, flag);

					local_ee_UInt |= (uint)(1 << local_108);
					local_50--;
				}

				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID && (city.StatusFlag & 0x1) != 0)
				{
					this.oParent.Var_e8b8++;
				}

				while (local_50 > this.oParent.Var_e8b8)
				{
					local_108 = -1;
					local_e2 = 0;
					local_d6 = 0;
					local_ce = 0;

					for (int i = 0; i < this.Var_6540_CityOffsetCount; i++)
					{
						if (Arr_3e[i] == 0)
						{
							local_c6 = city.Position.X + this.oParent.CityOffsets[i].X;
							local_d2 = city.Position.Y + this.oParent.CityOffsets[i].Y;

							// Instruction address 0x1d12:0x1173, size: 5
							local_4 = F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_c6, local_d2, CityResourceTypeEnum.Food);

							// Instruction address 0x1d12:0x1151, size: 5
							local_d4 = local_4 * (16 / this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
								this.oParent.Var_70da_Arr[0] - (city.ActualSize * 2) - (local_48 * this.oParent.Var_e3c6), 1, 99));

							// Instruction address 0x1d12:0x1190, size: 5
							local_c = F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_c6, local_d2, CityResourceTypeEnum.Production);

							// Instruction address 0x1d12:0x11af, size: 5
							local_d4 += ((city.ActualSize * 3) / this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
								this.oParent.Var_70da_Arr[1] - this.oParent.Var_d2f6, 1, 99)) * local_c;

							// Instruction address 0x1d12:0x11dc, size: 5
							local_46 = F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_c6, local_d2, CityResourceTypeEnum.Trade);

							// Instruction address 0x1d12:0x11f7, size: 5
							local_d4 += ((city.ActualSize * 2) / this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70da_Arr[2], 1, 99)) * local_46;

							if (local_d4 > local_d6)
							{
								local_d6 = local_d4;
								local_108 = i;
								local_e2 = ((local_4 + local_c) * 2) + local_46;
							}
						}
					}

					if (local_108 == -1)
						break;

					Arr_3e[local_108] = 1;

					// Instruction address 0x1d12:0x1267, size: 5
					F0_1d12_692d_CityResources(cityID, local_108, flag);

					local_ee_UInt |= (uint)(1 << local_108);
					local_50--;
				}

			L1292:
				city.WorkerFlags = (uint)((uint)local_50 << 26) | local_ee_UInt;

				local_ae = -local_50;

			L12c2:
				local_d8 = city.Position.X;
				local_e4 = city.Position.Y;
				local_8 = local_50;

				for (int i = 0; i < local_8; i++)
				{
					// Instruction address 0x1d12:0x1309, size: 5
					if (F0_1d12_6da1_GetSpecialWorkerFlags(i) == 0)
					{
						// Instruction address 0x1d12:0x1321, size: 5
						F0_1d12_6d6e_SetSpecialWorkerFlags(i, 3);
					}
				}

				for (int i = local_8; i < 8; i++)
				{
					// Instruction address 0x1d12:0x134c, size: 5
					F0_1d12_6d6e_SetSpecialWorkerFlags(i, 0);
				}

				local_ac = 0;
				local_f8 = 0;
				this.oParent.Var_6c98 = 1;

				if (city.HasImprovement(ImprovementEnum.Factory))
				{
					local_f8 = 2;
				}

				if (city.HasImprovement(ImprovementEnum.ManufacturingPlant))
				{
					local_f8 = 4;
				}

				if (city.HasImprovement(ImprovementEnum.PowerPlant))
				{
					local_ac = 2;
				}

				if (city.HasImprovement(ImprovementEnum.HydroPlant))
				{
					this.oParent.Var_6c98 = 2;
					local_ac = 2;
				}

				if (city.HasImprovement(ImprovementEnum.NuclearPlant))
				{
					this.oParent.Var_6c98 = 2;
					local_ac = 2;
				}

				// Instruction address 0x1d12:0x13f9, size: 5
				if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.HooverDam) != 0)
				{
					// Instruction address 0x1d12:0x1428, size: 5
					// Instruction address 0x1d12:0x1442, size: 5
					if (this.oParent.MapManagement.F0_2aea_1942(city.Position.X, city.Position.Y) ==
						this.oParent.MapManagement.F0_2aea_1942(
						this.oParent.CivState.Cities[this.oParent.CivState.WonderCityID[(int)WonderEnum.HooverDam]].Position.X,
						this.oParent.CivState.Cities[this.oParent.CivState.WonderCityID[(int)WonderEnum.HooverDam]].Position.Y))
					{
						this.oParent.Var_6c98 = 2;
						local_ac = 2;
					}
				}

				if (city.HasImprovement(ImprovementEnum.RecyclingCenter))
				{
					this.oParent.Var_6c98 = 3;
				}

				// Instruction address 0x1d12:0x1484, size: 5
				local_ac = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_ac, 0, local_f8);
				local_10a = this.oParent.Var_70da_Arr[1];
				local_a = this.oParent.Var_70da_Arr[2];

				this.oParent.Var_70da_Arr[1] += ((local_f8 * this.oParent.Var_70da_Arr[1]) / 4) + ((local_ac * this.oParent.Var_70da_Arr[1]) / 4);

				if (flag == 0)
				{
					city.FoodCount += (short)(this.oParent.Var_70da_Arr[0] - (local_48 * this.oParent.Var_e3c6) - (city.ActualSize * 2));

					local_e8 = this.oParent.Var_70da_Arr[1];
					local_e8 -= this.oParent.Var_d2f6;

					if ((city.StatusFlag & 0x1) != 0)
					{
						local_e8 = 0;
					}

					city.ShieldsCount += (short)local_e8;

					if (city.CurrentProductionID >= 0)
					{
						if ((this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) <= city.ShieldsCount)
						{
							if (city.CurrentProductionID == 0 && city.ActualSize == 1 && this.oParent.CivState.DifficultyLevel == 0)
							{
								goto L2307;
							}
							else
							{
								city.ShieldsCount -= (short)(this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a);

								local_ba = -1;

								if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID || city.CurrentProductionID != 0x1a)
								{
									// Instruction address 0x1d12:0x15fa, size: 5
									local_ba = (short)this.oParent.Segment_1866.F0_1866_0cf5(this.Var_6548_PlayerID, city.CurrentProductionID, city.Position.X, city.Position.Y);
								}

								if ((this.oParent.CivState.TechnologyFirstDiscoveredBy[city.CurrentProductionID] & 0x8) == 0)
								{
									// Instruction address 0x1d12:0x1640, size: 5
									this.oParent.Segment_1866.F0_1866_250e_AddReplayData(6, (byte)((sbyte)this.Var_6548_PlayerID), (byte)city.CurrentProductionID);

									this.oParent.CivState.TechnologyFirstDiscoveredBy[city.CurrentProductionID] |= 8;
								}

								if (city.HasImprovement(ImprovementEnum.Barracks) && local_ba != -1)
								{
									this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_ba].Status |= 0x20;
								}

								if (local_ba != -1 && city.CurrentProductionID == 0 && (city.ActualSize > 1 || this.oParent.CivState.Players[this.Var_6548_PlayerID].CityCount > 1))
								{
									city.ActualSize--;

									if (city.ActualSize == 0)
									{
										// Instruction address 0x1d12:0x16ff, size: 5
										this.oParent.Segment_1ade.F0_1ade_018e(cityID, city.Position.X, city.Position.Y);

										// Instruction address 0x1d12:0x1727, size: 5
										this.oParent.Segment_1866.F0_1866_0cf5(this.Var_6548_PlayerID, city.CurrentProductionID, city.Position.X, city.Position.Y);

										this.oParent.StartGameMenu.F5_0000_0e6c(this.Var_6548_PlayerID, 0);

										// Instruction address 0x1d12:0x1743, size: 5
										this.oParent.Segment_11a8.F0_11a8_0250();

										goto L6927;
									}
								}

								if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID && local_ba != -1)
								{
									if (city.CurrentProductionID == 27)
									{
										local_108 = -1;
										local_c8 = -1;

										for (int i = 0; i < 128; i++)
										{
											if (this.oParent.CivState.Cities[i].PlayerID != this.Var_6548_PlayerID && this.oParent.CivState.Cities[i].StatusFlag != 0xff &&
												this.oParent.CivState.Cities[i].PlayerID != this.oParent.CivState.HumanPlayerID && this.oParent.CivState.Cities[i].BaseTrade > local_c8)
											{
												local_c8 = this.oParent.CivState.Cities[i].BaseTrade;
												local_108 = i;
											}
										}

										// Instruction address 0x1d12:0x180e, size: 5
										this.oParent.Segment_2459.F0_2459_0948(this.Var_6548_PlayerID, (short)local_ba, (short)local_108);
									}

									if (city.CurrentProductionID == 26)
									{
										local_108 = -1;
										local_c8 = 32767;
										local_106 = 0;

										for (int i = 0; i < 128; i++)
										{
											if (this.oParent.CivState.Cities[i].PlayerID != this.oParent.CivState.HumanPlayerID || this.oParent.CivState.Cities[i].StatusFlag != 0xff)
											{
												// Instruction address 0x1d12:0x1898, size: 5
												local_e8 = (short)this.oParent.Segment_2dc4.F0_2dc4_0177(this.Var_6548_PlayerID, (short)local_ba,
													this.oParent.CivState.Cities[i].Position.X,
													this.oParent.CivState.Cities[i].Position.Y);

												this.oParent.Var_6c9a = Math.Abs(this.oParent.Var_6c9a - 3);

												if ((this.oParent.CivState.Cities[i].StatusFlag & 0x20) != 0)
												{
													this.oParent.Var_6c9a = 3;
												}

												if (local_c8 > this.oParent.Var_6c9a || (local_c8 == this.oParent.Var_6c9a && this.oParent.MSCAPI.RNG.Next(++local_106) == 0))
												{
													// Instruction address 0x1d12:0x191e, size: 5
													TerrainTypeEnum terrainType = (TerrainTypeEnum)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
														this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.X,
														this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.Y);

													// Instruction address 0x1d12:0x1956, size: 5
													// Instruction address 0x1d12:0x1970, size: 5
													if (terrainType != TerrainTypeEnum.Ocean && this.oParent.MapManagement.F0_2aea_1942(
														this.oParent.CivState.Cities[i].Position.X,	this.oParent.CivState.Cities[i].Position.Y) ==
														this.oParent.MapManagement.F0_2aea_1942(
														this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.X,
														this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.Y))
													{
														if (local_c8 != this.oParent.Var_6c9a)
														{
															local_c8 = this.oParent.Var_6c9a;
														}
														else
														{
															local_106 = 1;
														}

														local_108 = local_e8;
														local_b0 = i;
													}
												}
											}
										}

										if (local_c8 > 3 || (this.oParent.CivState.Players[this.Var_6548_PlayerID].Diplomacy[this.oParent.CivState.HumanPlayerID] & 2) != 0)
										{
											city.ShieldsCount += (short)(this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a);
										}
										else
										{
											// Instruction address 0x1d12:0x19f9, size: 5
											local_ba = (short)this.oParent.Segment_1866.F0_1866_0cf5(
												this.Var_6548_PlayerID,
												0x1a,
												this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_108].Position.X,
												this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_108].Position.Y);

											if (local_ba != -1)
											{
												this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_ba].GoToPosition.X = this.oParent.CivState.Cities[local_b0].Position.X;
												this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_ba].GoToPosition.Y = this.oParent.CivState.Cities[local_b0].Position.Y;
											}
										}
									}

									if (city.CurrentProductionID == 25 && this.oParent.CivState.Players[this.Var_6548_PlayerID].ActiveUnits[(int)UnitTypeEnum.Nuclear] == 1)
									{
										this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].ContactPlayerCountdown = -1;
									}

									// Instruction address 0x1d12:0x1aab, size: 5
									this.oParent.Segment_25fb.F0_25fb_34b6(cityID);
								}
								else
								{
									city.ShieldsCount = 0;

									if (local_ba != -1 && (city.CurrentProductionID == 0 || city.CurrentProductionID >= 26))
									{
										this.oParent.Var_b1e8 = 1;
										this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

										// Instruction address 0x1d12:0x1b00, size: 5
										this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

										// Instruction address 0x1d12:0x1b10, size: 5
										this.oParent.MSCAPI.strcat(0xba06, " builds ");

										// Instruction address 0x1d12:0x1b2e, size: 5
										this.oParent.MSCAPI.strcat(0xba06,
											this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Name);

										// Instruction address 0x1d12:0x1b3e, size: 5
										this.oParent.MSCAPI.strcat(0xba06, ".\n");

										this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DefenseMinister;

										// Instruction address 0x1d12:0x1b58, size: 5
										this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);
									}
								}
							}
						}
					}
					else
					{
						if ((this.oParent.CivState.ImprovementDefinitions(-city.CurrentProductionID).Price * local_4a) <= city.ShieldsCount)
						{
							local_e8 = -city.CurrentProductionID;

							if (local_e8 > 24)
							{
								if (this.oParent.CivState.WonderCityID[local_e8 - 24] == -1)
								{
									this.oParent.CivState.WonderCityID[local_e8 - 24] = cityID;

									// Instruction address 0x1d12:0x1bd7, size: 5
									this.oParent.Segment_1866.F0_1866_250e_AddReplayData(10, (byte)((sbyte)this.Var_6548_PlayerID), (byte)((sbyte)(local_e8 - 24)));
								}
								else
								{
									local_e8 = -1;
								}
							}
							else if (city.HasImprovement(City.BitToImprovementEnum(local_e8 - 1)))
							{
								local_e8 = -1;
							}

							if (local_e8 != -1)
							{
								if (local_e8 == 41)
								{
									// Instruction address 0x1d12:0x1c39, size: 5
									this.oParent.MSCAPI.strcpy(0xba06, "Sensors report a\nNUCLEAR WEAPONS test\nnear ");

									// Instruction address 0x1d12:0x1c44, size: 5
									this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

									// Instruction address 0x1d12:0x1c54, size: 5
									this.oParent.MSCAPI.strcat(0xba06, "!\n");

									// Instruction address 0x1d12:0x1c60, size: 5
									this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

									this.oParent.Overlay_21.F21_0000_0000(-1);

									// Instruction address 0x1d12:0x1c78, size: 5
									this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);
								}

								if (local_e8 < 22)
								{
									city.AddImprovement(City.BitToImprovementEnum(local_e8 - 1));
								}

								city.ShieldsCount -= (short)(this.oParent.CivState.ImprovementDefinitions(-city.CurrentProductionID).Price * local_4a);

								if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) != 0 || local_e8 > 24)
								{
									if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) == 0)
									{
										this.oParent.CivState.MapVisibility[city.Position.X, city.Position.Y] = 0xffff;
									}
									else
									{
										this.oParent.Var_b1e8 = 1;
									}

									this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

									// Instruction address 0x1d12:0x1d31, size: 5
									this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

									// Instruction address 0x1d12:0x1d41, size: 5
									this.oParent.MSCAPI.strcat(0xba06, " builds\n");

									// Instruction address 0x1d12:0x1d58, size: 5
									this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.ImprovementDefinitions(local_e8).Name);

									// Instruction address 0x1d12:0x1d68, size: 5
									this.oParent.MSCAPI.strcat(0xba06, ".\n");

									// Instruction address 0x1d12:0x1dbe, size: 5
									if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID && 
										this.oParent.CivState.GameSettingFlags.Animations && 
										(local_e8 <= 21 || local_e8 > 24) && (city.StatusFlag & 0x10) == 0 && 
										local_e8 != 1 && this.oParent.Segment_11a8.F0_11a8_02a4(1, 0) != 0)
									{
										this.oParent.CityView.F19_0000_0000(cityID, (short)local_e8);
									}
									else
									{
										this.oParent.Overlay_21.F21_0000_0000(cityID);
									}

									city.ShieldsCount = 0;
								}
								else
								{
									if (local_e8 == 1)
									{
										city.CurrentProductionID = -2;
									}

									// Instruction address 0x1d12:0x1e1a, size: 5
									city.CurrentProductionID = (sbyte)((short)this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID));

									if (city.CurrentProductionID >= 0)
									{
										this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;
									}
								}

								if (local_e8 >= 22 && local_e8 <= 24 && ((1 << this.Var_6548_PlayerID) & (ushort)this.oParent.CivState.SpaceshipFlags) == 0)
								{
									if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
									{
										this.oParent.Overlay_18.F18_0000_0f83(this.Var_6548_PlayerID, (ushort)((short)(local_e8 - 22)));
									}
									else
									{
										local_c8 = (short)this.oParent.Overlay_18.F18_0000_0d4f(this.Var_6548_PlayerID, (short)(local_e8 - 22));

										if (local_c8 != 0 && local_e8 < 24)
										{
											city.ShieldsCount += (short)(this.oParent.CivState.ImprovementDefinitions(local_e8).Price * local_4a);

											if (city.CurrentProductionID <= -22 && city.CurrentProductionID >= -24)
											{
												city.CurrentProductionID = (sbyte)((-local_e8) - 1);
											}

											local_c8--;
										}

										if ((this.oParent.CivState.SpaceshipFlags & (1 << this.Var_6548_PlayerID)) == 0 && this.oParent.CivState.AISpaceshipSuccessRate >= 40)
										{
											if (local_c8 == 0)
												goto L1feb;

											// Instruction address 0x1d12:0x1f5d, size: 5
											if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.CivState.HumanPlayerID, (int)TechnologyEnum.SpaceFlight) == 0)
												goto L2010;

											if (this.oParent.CivState.AISpaceshipSuccessRate > 75)
												goto L1feb;

											if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Ranking > this.oParent.CivState.Players[this.Var_6548_PlayerID].Ranking)
												goto L1feb;

											if ((this.oParent.CivState.SpaceshipFlags & (1 << this.oParent.CivState.HumanPlayerID)) == 0)
												goto L1fc5;

											if ((this.oParent.CivState.Players[this.Var_6548_PlayerID].SpaceshipETAYear - this.oParent.CivState.Year) <=
												(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].SpaceshipETAYear - this.oParent.CivState.Year))
												goto L1feb;

											L1fc5:
											if ((this.oParent.CivState.SpaceshipFlags & (1 << (this.oParent.CivState.HumanPlayerID + 8))) != 0 &&
												this.oParent.CivState.Players[this.oParent.CivState.ActiveCivilizations].Coins > 1000)
												goto L1feb;

											goto L2010;

										L1feb:
											this.oParent.Overlay_18.F18_0000_15c3(this.Var_6548_PlayerID);

											goto L2010;
										}
										else if (local_c8 != 0)
										{
											this.oParent.Overlay_18.F18_0000_15c3(this.Var_6548_PlayerID);
										}
									}
								}

							L2010:
								if (local_e8 == 1)
								{
									for (int i = 0; i < 128; i++)
									{
										if (this.oParent.CivState.Cities[i].PlayerID == this.Var_6548_PlayerID)
										{
											this.oParent.CivState.Cities[i].RemoveImprovement(ImprovementEnum.Palace);
										}
									}

									if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID ||
										(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Diplomacy[this.Var_6548_PlayerID] & 0x40) != 0)
									{
										this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

										if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
										{
											// Instruction address 0x1d12:0x2097, size: 5
											this.oParent.MSCAPI.strcpy(0xba06, "Diplomats report:\n");

											this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DiplomatsReport;
										}

										// Instruction address 0x1d12:0x20b3, size: 5
										this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.Players[this.Var_6548_PlayerID].Nationality);

										// Instruction address 0x1d12:0x20c3, size: 5
										this.oParent.MSCAPI.strcat(0xba06, " capital\nmoved to ");

										// Instruction address 0x1d12:0x20ce, size: 5
										this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

										// Instruction address 0x1d12:0x20de, size: 5
										this.oParent.MSCAPI.strcat(0xba06, ".\n");

										this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.ForeignMinister;

										// Instruction address 0x1d12:0x20f8, size: 5
										this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

										this.oParent.CivState.Players[this.Var_6548_PlayerID].XStart = (short)city.Position.X;

										city.AddImprovement(ImprovementEnum.Palace);
									}
								}

								if (local_e8 == 38)
								{
									// Instruction address 0x1d12:0x2136, size: 5
									this.oParent.Segment_11a8.F0_11a8_0280();

									// Instruction address 0x1d12:0x2143, size: 5
									this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

									// Instruction address 0x1d12:0x2153, size: 5
									this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

									// Instruction address 0x1d12:0x215b, size: 5
									this.oParent.Segment_11a8.F0_11a8_0294();
								}

								if (local_e8 == 43 && this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
								{
									for (int i = 0; i < 128; i++)
									{
										if (this.oParent.CivState.Cities[i].StatusFlag != 0xff && this.oParent.CivState.Cities[i].PlayerID != this.Var_6548_PlayerID)
										{
											this.oParent.CivState.Cities[i].VisibleSize = this.oParent.CivState.Cities[i].ActualSize;

											this.oParent.CivState.MapVisibility[this.oParent.CivState.Cities[i].Position.X,
												this.oParent.CivState.Cities[i].Position.Y] |= (ushort)(1 << this.Var_6548_PlayerID);

											// Instruction address 0x1d12:0x2204, size: 5
											this.oParent.MapManagement.F0_2aea_1601(
												this.oParent.CivState.Cities[i].Position.X, this.oParent.CivState.Cities[i].Position.Y);
										}
									}
								}
							}
						}
					}

					if ((this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID && (city.StatusFlag & 0x10) != 0) &&
						(city.ShieldsCount == 0 || (city.CurrentProductionID < 0 && local_e8 == -1)))
					{
						// Instruction address 0x1d12:0x2262, size: 5
						local_e8 = (short)this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

						this.oParent.Var_aa_Rectangle.FontID = 2;

						if (local_e8 == 99)
						{
							city.StatusFlag &= 0xef;
						}
						else
						{
							this.oParent.Var_b1e8 = 0;

							if (city.CurrentProductionID >= 0)
							{
								this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;
							}

							city.CurrentProductionID = (sbyte)local_e8;

							if (city.CurrentProductionID >= 0)
							{
								this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;
							}
						}
					}

				L2307:
					if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) == 0)
					{
						if ((city.StatusFlag & 0x10) != 0)
						{
							// Instruction address 0x1d12:0x232e, size: 5
							this.oParent.Segment_25fb.F0_25fb_34b6(cityID);
						}

						local_cc = 0;

						// Instruction address 0x1d12:0x2344, size: 5
						// !!! Added & 0x7 to prevent owerflow, need to investigate why this happens
						local_104 = this.oParent.CivState.Players[this.oParent.MapManagement.F0_2aea_1942(local_d8, local_e4) & 0x7].Continents[this.Var_6548_PlayerID].Strategy;

						if ((local_104 == 1 || local_104 == 2 || local_104 == 5) && local_e8 != 0 && city.CurrentProductionID >= 0 &&
							this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].UnitCategory == local_104)
						{
							local_cc = this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins / 64;
						}

						if ((this.oParent.CivState.SpaceshipFlags & (1 << (this.oParent.CivState.HumanPlayerID + 8))) != 0 &&
							(-city.CurrentProductionID) >= 0x16 && (-city.CurrentProductionID) <= 0x18)
						{
							local_cc = this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins / 128;
						}

						if ((city.StatusFlag & 0x1) != 0 && city.CurrentProductionID < 0 && city.ShieldsCount != 0)
						{
							// Instruction address 0x1d12:0x24a7, size: 5
							local_cc = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
								(this.oParent.CivState.ImprovementDefinitions(-city.CurrentProductionID).Price * local_4a) - city.ShieldsCount,
								0, this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins / 8);
						}

						// Instruction address 0x1d12:0x24bb, size: 5
						this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(local_d8, local_e4);
						if (((short)this.oCPU.AX.Word == -1 || (city.StatusFlag & 0x10) != 0) && city.CurrentProductionID >= 0 && city.ShieldsCount != 0)
						{
							// Instruction address 0x1d12:0x2530, size: 5
							local_cc = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
								(this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) - city.ShieldsCount,
								0, this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins / 3);
						}

						if (city.CurrentProductionID == -1 && city.ShieldsCount != 0)
						{
							// Instruction address 0x1d12:0x2591, size: 5
							local_cc = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
								(this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) - city.ShieldsCount,
								0, this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins / 3);
						}

						if (city.CurrentProductionID >= 0 && city.StatusFlag == 0x19 && this.oParent.CivState.Players[this.Var_6548_PlayerID].ActiveUnits[(int)UnitTypeEnum.Nuclear] == 0 && city.ShieldsCount != 0)
						{
							// Instruction address 0x1d12:0x260d, size: 5
							local_cc = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
								(this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) - city.ShieldsCount,
								0, this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins / 4);
						}

						if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins > 2000)
						{
							local_cc += this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins / 512;
						}

						city.ShieldsCount += (short)local_cc;
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins -= (short)(local_cc * 2);
						city.StatusFlag &= 0xef;
					}
				}

				if (flag == 1)
				{
					// Instruction address 0x1d12:0x2697, size: 5
					F0_1d12_70cb_FillRectangleWithPattern(2, 67, 124, 104);

					// Instruction address 0x1d12:0x26af, size: 5
					F0_1d12_70cb_FillRectangleWithPattern(95, 106, 227, 197);

					// Instruction address 0x1d12:0x26cf, size: 5
					F0_1d12_71bf_DrawFilledRectangleWithCenteredText(95, 106, 128, 114, 0x25ea, 9);

					// Instruction address 0x1d12:0x26ef, size: 5
					F0_1d12_71bf_DrawFilledRectangleWithCenteredText(129, 106, 160, 114, 0x25ef, 9);

					// Instruction address 0x1d12:0x270f, size: 5
					F0_1d12_71bf_DrawFilledRectangleWithCenteredText(161, 106, 193, 114, 0x25f5, 9);

					// Instruction address 0x1d12:0x272f, size: 5
					F0_1d12_71bf_DrawFilledRectangleWithCenteredText(194, 106, 226, 114, 0x25f9, 9);

					// Instruction address 0x1d12:0x275a, size: 5
					this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, (33 * this.Var_2496) + 96, 107, 32, 7, 9, 15);

					if (this.Var_2496 == 2)
					{
						// Instruction address 0x1d12:0x2768, size: 5
						F0_1d12_72b7_DrawCityWorldMap();
					}
				}
			
				local_d8 = city.Position.X;
				local_e4 = city.Position.Y;

				this.oParent.Var_d2e0 = 0;

				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType == 3)
				{
					this.Var_6b30 = 10;
				}

				this.oParent.Var_d2e0 = ((this.oParent.Var_70da_Arr[2] * this.Var_6b30) * 3) / ((this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType * 20) + 80);

				if (city.HasImprovement(ImprovementEnum.Courthouse) || city.HasImprovement(ImprovementEnum.Palace))
				{
					this.oParent.Var_d2e0 /= 2;
				}
			
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
				{
					this.oParent.Var_d2e0 = 0;
				}

				city.BaseTrade = (sbyte)(this.oParent.Var_70da_Arr[2] - this.oParent.Var_d2e0);

				for (int i = 0; i < 3; i++)
				{
					local_4c = city.TradeCityIDs[i];

					if (local_4c != -1)
					{
						if (this.oParent.CivState.Cities[local_4c].PlayerID == this.Var_6548_PlayerID)
						{
							this.oParent.Var_70da_Arr[2] += (this.oParent.CivState.Cities[local_4c].BaseTrade + this.oParent.Var_70da_Arr[2] + 4) / 16;
						}
						else
						{
							this.oParent.Var_70da_Arr[2] += (this.oParent.CivState.Cities[local_4c].BaseTrade + this.oParent.Var_70da_Arr[2] + 4) / 8;
						}
					}
				}

				this.oParent.Var_d2e0 = ((this.oParent.Var_70da_Arr[2] * this.Var_6b30) * 3) / ((this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType * 20) + 80);

				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
				{
					this.oParent.Var_d2e0 = 0;
				}

				if (city.HasImprovement(ImprovementEnum.Courthouse))
				{
					this.oParent.Var_d2e0 /= 2;
				}

				// Instruction address 0x1d12:0x2960, size: 5
				this.oParent.Var_70da_Arr[3] = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					((-(this.oParent.CivState.Players[this.Var_6548_PlayerID].ScienceTaxRate +
						this.oParent.CivState.Players[this.Var_6548_PlayerID].TaxRate - 10) *
						(this.oParent.Var_70da_Arr[2] - this.oParent.Var_d2e0)) + 5) / 10,
					0, this.oParent.Var_70da_Arr[2]);

				// !!! Minimum value is greater than maximum value, why?
				// Instruction address 0x1d12:0x2999, size: 5
				this.oParent.Var_e17a = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					((this.oParent.CivState.Players[this.Var_6548_PlayerID].TaxRate * (this.oParent.Var_70da_Arr[2] - this.oParent.Var_d2e0)) + 5) / 10,
					0, this.oParent.Var_70da_Arr[2] - this.oParent.Var_70da_Arr[3] - this.oParent.Var_d2e0);

				this.oParent.Var_70e6 = this.oParent.Var_70da_Arr[2] - this.oParent.Var_70da_Arr[3] - this.oParent.Var_e17a - this.oParent.Var_d2e0;

				// Instruction address 0x1d12:0x29ba, size: 5
				this.oParent.Var_e17a += F0_1d12_6dcc_GetWorkerCountByType(1) * 2;

				// Instruction address 0x1d12:0x29cc, size: 5
				this.oParent.Var_70e6 += F0_1d12_6dcc_GetWorkerCountByType(2) * 2;

				// Instruction address 0x1d12:0x29de, size: 5
				this.oParent.Var_70da_Arr[3] += F0_1d12_6dcc_GetWorkerCountByType(3) * 2;

				if (city.HasImprovement(ImprovementEnum.MarketPlace))
				{
					this.oParent.Var_70da_Arr[3] += this.oParent.Var_70da_Arr[3] / 2;
					this.oParent.Var_e17a += this.oParent.Var_e17a / 2;
				}

				if (city.HasImprovement(ImprovementEnum.Bank))
				{
					this.oParent.Var_70da_Arr[3] += this.oParent.Var_70da_Arr[3] / 2;
					this.oParent.Var_e17a += this.oParent.Var_e17a / 2;
				}
			
				local_e8 = this.oParent.Var_70e6;

				if (city.HasImprovement(ImprovementEnum.Library))
				{
					local_e8 += this.oParent.Var_70e6 / 2;

					// Instruction address 0x1d12:0x2a6e, size: 5
					if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.IsaacNewtonsCollege) != 0)
					{
						local_e8 += this.oParent.Var_70e6 / 3;
					}
				}

				if (city.HasImprovement(ImprovementEnum.University))
				{
					local_e8 += this.oParent.Var_70e6 / 2;

					// Instruction address 0x1d12:0x2ab2, size: 5
					if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.IsaacNewtonsCollege) != 0)
					{
						local_e8 += this.oParent.Var_70e6 / 3;
					}
				}

				// Instruction address 0x1d12:0x2ad3, size: 5
				if ((short)F0_1d12_6cf3_GetWonderCityID((int)WonderEnum.CopernicusObservatory) == cityID)
				{
					local_e8 += local_e8;
				}
			
				this.oParent.Var_70e6 = local_e8;
				this.oParent.Var_70e2 = 0;

				if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
				{
					local_e8 = 14 - (oParent.CivState.DifficultyLevel * 2);
					local_e8 = ((this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType / 2) + 2) * (local_e8 / 2);
					local_a8 = (((cityID % local_e8) + this.oParent.CivState.Players[this.Var_6548_PlayerID].CityCount - local_e8) / local_e8) +
						city.ActualSize + this.oParent.CivState.DifficultyLevel - 6;
					this.oParent.Var_70e4 = local_a8;
				}
				else
				{
					local_a8 = city.ActualSize - 3;
					this.oParent.Var_70e4 = local_a8;
				}

				this.Var_6542 = 0;

				if (city.ActualSize < this.oParent.Var_70e4)
				{
					this.Var_6542 = this.oParent.Var_70e4 - city.ActualSize;
					this.oParent.Var_70e4 = city.ActualSize;
				}
			
				// Instruction address 0x1d12:0x2bd9, size: 5
				F0_1d12_6dfe(cityID, local_8);

				if (flag == 1 && this.Var_2496 == 1)
				{
					local_42 = 116;

					// Instruction address 0x1d12:0x2c15, size: 5
					F0_1d12_6ed4_DrawResources(cityID, 100, local_42, local_8, 92);

					local_42 += 16;

					// Instruction address 0x1d12:0x2c35, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);
				}

				this.oParent.Var_70e2 = this.oParent.Var_70da_Arr[3] / 2;

				// Instruction address 0x1d12:0x2c4e, size: 5
				F0_1d12_6dfe(cityID, local_8);

				if (flag == 1 && this.Var_2496 == 1 && this.oParent.Var_70e2 != 0)
				{
					// Instruction address 0x1d12:0x2c8f, size: 5
					F0_1d12_6ed4_DrawResources(cityID, 100, local_42, local_8, 92);

					// Instruction address 0x1d12:0x2ca6, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
						208, local_42 + 4, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xe << 1) + 0xd4ce)));

					local_42 += 16;

					// Instruction address 0x1d12:0x2cc6, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);
				}

				local_6 = 208;

				if (city.HasImprovement(ImprovementEnum.Colosseum))
				{
					this.oParent.Var_70e4 -= 3;

					if (flag == 1 && this.Var_2496 == 1)
					{
						// Instruction address 0x1d12:0x2d13, size: 5
						F0_1d12_7045(14, (short)local_6, (short)local_42);

						local_6 -= 16;
					}
				}

				// Instruction address 0x1d12:0x2d27, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Religion) != 0)
				{
					if (city.HasImprovement(ImprovementEnum.Cathedral))
					{
						// Instruction address 0x1d12:0x2d52, size: 5
						if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.MichelangelosChapel) != 0)
						{
							this.oParent.Var_70e4 -= 6;
						}
						else
						{
							this.oParent.Var_70e4 -= 4;
						}
					}

					if (flag == 1 && this.Var_2496 == 1 && city.HasImprovement(ImprovementEnum.Cathedral))
					{
						// Instruction address 0x1d12:0x2db0, size: 5
						F0_1d12_7045(11, (short)local_6, (short)local_42);

						local_6 -= 16;
					}
				}

				if (city.HasImprovement(ImprovementEnum.Temple))
				{
					// Instruction address 0x1d12:0x2dd6, size: 5
					if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Mysticism) != 0)
					{
						this.oParent.Var_70e4 -= 2;
					}
					else
					{
						// Instruction address 0x1d12:0x2df6, size: 5
						if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.CeremonialBurial) != 0)
						{
							this.oParent.Var_70e4--;
						}
					}
				
					// Instruction address 0x1d12:0x2e12, size: 5
					if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.Oracle) != 0)
					{
						// Instruction address 0x1d12:0x2e2a, size: 5
						if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Mysticism) != 0)
						{
							this.oParent.Var_70e4 -= 2;
						}
						else
						{
							this.oParent.Var_70e4 -= 1;
						}
					}

					if (flag == 1 && this.Var_2496 == 1)
					{
						// Instruction address 0x1d12:0x2e6f, size: 5
						F0_1d12_7045(4, (short)local_6, (short)local_42);

						local_6 -= 16;
					}
				}

				// Instruction address 0x1d12:0x2e81, size: 5
				F0_1d12_6dfe(cityID, local_8);

				if (flag == 1 && this.Var_2496 == 1 && 
					(city.HasImprovement(ImprovementEnum.Colosseum) || city.HasImprovement(ImprovementEnum.Cathedral) || city.HasImprovement(ImprovementEnum.Temple)))
				{
					// Instruction address 0x1d12:0x2ecb, size: 5
					F0_1d12_6ed4_DrawResources(cityID, 100, local_42, local_8, 92);

					local_42 += 16;

					// Instruction address 0x1d12:0x2eeb, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);
				}

				local_6 = 208;

				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType < 4)
				{
					local_2 = 0;
					local_e6 = 0;

					// Instruction address 0x1d12:0x2f1a, size: 5
					local_e8 = (short)this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(local_d8, local_e4);
					local_ba = local_e8;

					while (local_ba != -1)
					{
						local_2++;

						if (local_2 >= 32)
							break;

						if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_ba].TypeID].AttackStrength != 0)
						{
							local_e6++;

							if (flag == 1 && this.Var_2496 == 1 && local_e6 <= 3)
							{
								// Instruction address 0x1d12:0x2fbd, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6, local_42 - 1,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word,
										(ushort)(((this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_ba].TypeID +
										(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));

								local_6 -= 2;
							}
						}

						local_ba = this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_ba].NextUnitID;

						if (local_ba == local_e8)
						{
							local_ba = -1;
						}
					}

					for (int i = 0; i < 2; i++)
					{
						if (this.oParent.Var_70e4 != 0 && city.Unknown[i] != -1 && this.oParent.CivState.UnitDefinitions[city.Unknown[i] & 0x3f].AttackStrength != 0)
						{
							local_e6++;
						}
					}

					if (local_e6 > 3)
					{
						local_e6 = 3;
					}

					// Instruction address 0x1d12:0x3079, size: 5
					this.oParent.Var_70e4 -= this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_e6, 0, this.oParent.Var_70e4);
				}
				else
				{
					// Instruction address 0x1d12:0x3090, size: 5
					local_e8 = ((short)F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.WomensSuffrage) < 1) ? 1 : 0;

					if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
					{
						local_e8++;
					}

					if (local_e8 != 0)
					{
						this.oParent.Var_70e4 += local_e8 * this.Var_6546;

						if (flag == 1 && this.Var_2496 == 1)
						{
							for (int i = 0; i < (local_e8 * this.Var_6546); i++)
							{
								// Instruction address 0x1d12:0x3117, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6, local_42 + 4,
									this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

								local_6 -= 2;
							}
						}
					}
				}

				// Instruction address 0x1d12:0x312c, size: 5
				F0_1d12_6dfe(cityID, local_8);

				if (flag == 1 && this.Var_2496 == 1)
				{
					// Instruction address 0x1d12:0x3163, size: 5
					F0_1d12_6ed4_DrawResources(cityID, 100, local_42, local_8, 92);

					local_42 += 16;

					// Instruction address 0x1d12:0x3183, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);
				}

				local_e8 = this.oParent.Var_70e2 - this.oParent.Var_70e4;

				// Instruction address 0x1d12:0x319e, size: 5
				if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.HangingGardens) != 0)
				{
					this.oParent.Var_70e2++;
				}
			
				// Instruction address 0x1d12:0x31ba, size: 5
				if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.CureForCancer) != 0)
				{
					this.oParent.Var_70e2++;
				}
			
				// Instruction address 0x1d12:0x31d2, size: 5
				if ((short)F0_1d12_6cf3_GetWonderCityID((int)WonderEnum.ShakespearesTheatre) == cityID)
				{
					this.oParent.Var_70e4 = 0;
				}
			
				// Instruction address 0x1d12:0x31f0, size: 5
				if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.JSBachsCathedral) != 0)
				{
					// Instruction address 0x1d12:0x3229, size: 5
					// Instruction address 0x1d12:0x3217, size: 5
					if (this.oParent.MapManagement.F0_2aea_1942(local_d8, local_e4) == 
						this.oParent.MapManagement.F0_2aea_1942(
							this.oParent.CivState.Cities[this.oParent.CivState.WonderCityID[(int)WonderEnum.JSBachsCathedral]].Position.X,
							this.oParent.CivState.Cities[this.oParent.CivState.WonderCityID[(int)WonderEnum.JSBachsCathedral]].Position.Y))
					{
						this.oParent.Var_70e4 -= 2;
					}
				}

				// Instruction address 0x1d12:0x3243, size: 5
				F0_1d12_6dfe(cityID, local_8);

				if (flag == 1 && this.Var_2496 == 1 && (this.oParent.Var_70e2 - this.oParent.Var_70e4) != local_e8)
				{
					// Instruction address 0x1d12:0x328a, size: 5
					F0_1d12_6ed4_DrawResources(cityID, 100, local_42, local_8, 92);

					// Instruction address 0x1d12:0x32a5, size: 5
					this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("WONDERS", 190, local_42 + 5, 15);

					local_42 += 16;

					// Instruction address 0x1d12:0x32c5, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);
				}

				if ((this.oParent.CivState.DebugFlags & 0x2) == 0)
				{
					this.oParent.Var_70e4 = 0;
					this.oParent.Var_70e2 = 0;
				}

			L32e0:
				local_4e = 0;
				this.oParent.Var_deb8 = 0;
				this.oParent.Var_d2f6 = 0;

				for (int i = 0; i < 2; i++)
				{
					if (city.Unknown[i] != -1)
					{
						this.oParent.Var_deb8++;
					}				
				}

				if (city.ActualSize < this.oParent.Var_deb8)
				{
					this.oParent.Var_d2f6 = this.oParent.Var_deb8 - city.ActualSize;
				}
			
				local_f6 = 8;
				local_fc = 69;
				local_fa = 100;
				local_100 = 116;

				for (int i = 0; i < 128; i++)
				{
					if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID != -1 &&
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].HomeCityID == cityID)
					{
						if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID < 26)
						{
							this.oParent.Var_deb8++;

							if (city.ActualSize >= this.oParent.Var_deb8)
							{
								if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType > 1 && (this.oParent.CivState.DebugFlags & 0x2) != 0)
								{
									this.oParent.Var_d2f6++;
								}
							}
							else
							{
								this.oParent.Var_d2f6++;
							}
						}

						if (flag == 0)
						{
							if (this.oParent.Var_70da_Arr[1] < this.oParent.Var_d2f6 ||
								((city.StatusFlag & 0x1) != 0 && ((i + this.oParent.CivState.TurnCount) & 0x7) == 0 &&
								this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID &&
								this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType >= 4))
							{
								local_108 = -1;
								local_c8 = -1;

								for (int j = 0; j < 128; j++)
								{
									if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[j].TypeID != -1 &&
										this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[j].HomeCityID == cityID &&
										this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[j].TypeID < 26)
									{
										// Instruction address 0x1d12:0x3513, size: 5
										local_b2 = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
											city.Position.X,
											city.Position.Y,
											this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[j].Position.X,
											this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[j].Position.Y);

										if (local_b2 > local_c8)
										{
											local_c8 = local_b2;
											local_108 = j;
										}
									}
								}

								if (this.oParent.Var_70da_Arr[1] >= this.oParent.Var_d2f6)
								{
									if (this.oParent.Var_8078 != 0 &&
										this.oParent.CivState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount <
										this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].DiscoveredTechnologyCount)
									{
										this.oParent.Var_db42 = -999; // 0xfc19
									}
									else if (local_c8 > 0 &&
										this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_108].TypeID].TerrainCategory == 0 &&
										this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_108].TypeID != 0)
									{
										// Instruction address 0x1d12:0x35c9, size: 5
										this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID, (short)local_108);

										city.StatusFlag &= 0xfe;
									}
								}
								else
								{
									if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
									{
										this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

										// Instruction address 0x1d12:0x35f5, size: 5
										this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

										// Instruction address 0x1d12:0x3605, size: 5
										this.oParent.MSCAPI.strcat(0xba06, " can't support\n");

										// Instruction address 0x1d12:0x362d, size: 5
										this.oParent.MSCAPI.strcat(0xba06,
											this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[local_108].TypeID].Name);

										// Instruction address 0x1d12:0x363d, size: 5
										this.oParent.MSCAPI.strcat(0xba06, ".\n Unit Disbanded.\n");

										this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DefenseMinister;

										// Instruction address 0x1d12:0x3657, size: 5
										this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
									}

									// Instruction address 0x1d12:0x3667, size: 5
									this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID, (short)local_108);

									goto L32e0;
								}
							}
						}

						if (flag == 1)
						{
							if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID < 26)
							{
								if (this.oParent.Var_d2f6 != 0)
								{
									// Instruction address 0x1d12:0x36c0, size: 5
									this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
										local_f6 + 8, local_fc + 12,
										this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));
								}
								if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID == 0)
								{
									// Instruction address 0x1d12:0x36f4, size: 5
									this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
										local_f6, local_fc + 12,
										this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));

									if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType >= 2)
									{
										// Instruction address 0x1d12:0x371f, size: 5
										this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
											local_f6 + 2, local_fc + 12,
											this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
									}
								}
								else
								{
									// Instruction address 0x1d12:0x3732, size: 5
									local_e8 = ((short)F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.WomensSuffrage) < 1) ? 1 : 0;

									if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
									{
										local_e8++;
									}

									if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType >= 4)
									{
										if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID].AttackStrength != 0 &&
											local_e8 != 0 &&
											(this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID].TerrainCategory == 1 ||
												this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.X != city.Position.X ||
												this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.Y != city.Position.Y))
										{
											// Instruction address 0x1d12:0x381d, size: 5
											this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
												local_f6, local_fc + 12,
												this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

											if (local_e8 > 1)
											{
												// Instruction address 0x1d12:0x3842, size: 5
												this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
													local_f6 + 2, local_fc + 12,
													this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));
											}
										}
									}
								}
							}

							// Instruction address 0x1d12:0x3877, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								local_f6, local_fc,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word,
									(ushort)(((this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID +
										(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));

							// Instruction address 0x1d12:0x38a3, size: 5
							F0_1d12_73ea_DrawCityRectangle(
								this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.X,
								this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.Y,
								7);

							local_f6 += 16;

							if (local_f6 >= 112)
							{
								local_f6 = 8;
								local_fc += 16;

								if (local_fc > 85)
								{
									local_fc -= 24;
								}
							}
						}
					}

					if (flag == 1 && local_4e < 18 && this.Var_2496 == 0 &&
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].TypeID != -1 &&
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.X == local_d8 &&
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].Position.Y == local_e4)
					{
						// Instruction address 0x1d12:0x3969, size: 5
						this.oParent.MapManagement.F0_2aea_0fb3(this.Var_6548_PlayerID, (short)i, local_fa, local_100);

						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

						// Instruction address 0x1d12:0x398e, size: 5
						this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[i].HomeCityID);

						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba09, 0x2e);
						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba0a, 0x0);

						// Instruction address 0x1d12:0x39b4, size: 5
						this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, local_fa, local_100 + 15, 0);

						Arr_74[local_4e] = i;

						local_4e++;

						local_fa += 18;
						
						if ((local_4e % 6) == 0)
						{
							local_fa = 100;
							local_100 += 16;
						}
					}
				}

				if (flag == 0)
				{
					if (this.oParent.Var_70da_Arr[1] < this.oParent.Var_deb8)
					{
						this.oParent.Var_e3c2 += (this.oParent.Var_deb8 - this.oParent.Var_70da_Arr[1]) * 5;
					}

					// Instruction address 0x1d12:0x3a2c, size: 5
					this.oParent.Var_e3c2 += this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_deb8, 0, city.ActualSize);

					if (city.HasImprovement(ImprovementEnum.MarketPlace))
					{
						this.oParent.Var_db42 -= (5 - this.oParent.CivState.Nations[this.oParent.CivState.Players[this.Var_6548_PlayerID].NationalityID].Ideology) * this.Var_6546;
					}
					else
					{
						this.oParent.Var_db42 -= (7 - this.oParent.CivState.Nations[this.oParent.CivState.Players[this.Var_6548_PlayerID].NationalityID].Ideology) * this.Var_6546;
					}
				}

				if (flag == 1)
				{
					this.oParent.Var_aa_Rectangle.FontID = 2;

					// Instruction address 0x1d12:0x3a9f, size: 5
					F0_1d12_70cb_FillRectangleWithPattern(211, 1, 317, 97);

					local_106 = 2;
					local_e4 = 2;
					local_40 = 0;
					local_b4 = 0;

					if (local_da == 0)
					{
						for (int i = 0; i < 21; i++)
						{
							if (this.oParent.CivState.WonderCityID[i + 1] == cityID)
							{
								local_e8 = i + 24;

								// Instruction address 0x1d12:0x3b09, size: 5
								this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.WonderDefinitions[i + 1].Name);

								// Instruction address 0x1d12:0x3b15, size: 5
								this.oParent.MSCAPI.strupr(0xba06);

								// Instruction address 0x1d12:0x3b25, size: 5
								this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 63);

								// Instruction address 0x1d12:0x3b40, size: 5
								this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 253, local_e4 + 2, 15);

								// Instruction address 0x1d12:0x3b69, size: 5
								F0_1d12_7045((short)(local_e8 + 1), (short)(((local_106 & 1) != 0) ? 213 : 233), (short)(local_e4 - 2));

								local_e4 += 6;
								local_106++;
								local_40++;
							}
						}
					}

					local_fe = 0;

					for (int i = local_da; i < 24; i++)
					{
						if (city.HasImprovement(City.BitToImprovementEnum(i)))
						{
							if (local_106 >= 16)
							{
								local_ca |= 0x2;
								local_ca &= 0x7ffffffe;
								local_fe = i;

								break;
							}
							else
							{
								local_b4++;

								// Instruction address 0x1d12:0x3bfb, size: 5
								this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									309, local_e4 + 1, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xb << 1) + 0xd4ce)));

								// Instruction address 0x1d12:0x3c12, size: 5
								this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.ImprovementDefinitions(i + 1).Name);

								// Instruction address 0x1d12:0x3c22, size: 5
								this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 56);

								// Instruction address 0x1d12:0x3c3d, size: 5
								this.oParent.MSCAPI.strupr(0xba06);

								// Instruction address 0x1d12:0x3c46, size: 5
								this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 253, local_e4 + 2, 15);

								// Instruction address 0x1d12:0x3c6f, size: 5
								F0_1d12_7045((short)(i + 1), (short)(((local_106 & 1) != 0) ? 213 : 233), (short)(local_e4 - 2));

								local_e4 += 6;
								local_106++;
							}
						}
					}

					// Instruction address 0x1d12:0x3c97, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 231, 0, 250, 0, 0);

					// Instruction address 0x1d12:0x3cb3, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 231, 1, 250, 1, 1);

					if ((local_ca & 2) != 0)
					{
						// Instruction address 0x1d12:0x3cdd, size: 5
						F0_1d12_71bf_DrawFilledRectangleWithCenteredText(287, 88, 315, 96, 0x262a, 9);
					}

					// Instruction address 0x1d12:0x3d01, size: 5
					this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 309, 2, 8, 96, 14, 12);

					if (city.CurrentProductionID >= 0)
					{
						local_de = this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost;
					}
					else
					{
						local_de = this.oParent.CivState.ImprovementDefinitions(-city.CurrentProductionID).Price;
					}

					// Instruction address 0x1d12:0x3d7a, size: 5
					local_44 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((local_de - 1) / 10) + 1, ((city.ShieldsCount - 1) / 100) + 1, 99);
					local_e8 = 80 / local_4a;
					local_f6 = (((local_44 * 8) - 8) / local_44) + (local_4a * local_e8);
					local_fc = (((local_de - 1) / local_44) * 8) + 8;

					// Instruction address 0x1d12:0x3ded, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 230, 99, local_f6 + 3, local_fc + 19, 1);

					if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
					{
						// Instruction address 0x1d12:0x3e31, size: 5
						F0_1d12_71bf_DrawFilledRectangleWithCenteredText(231, 106, 263, 114, (ushort)(((city.StatusFlag & 0x10) != 0) ? 0x262f : 0x2635), 9);

						// Instruction address 0x1d12:0x3e51, size: 5
						F0_1d12_71bf_DrawFilledRectangleWithCenteredText(294, 106, 311, 114, 0x263c, 9);
					}

					if (city.CurrentProductionID >= 0)
					{
						// Instruction address 0x1d12:0x3e8e, size: 5
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							264, 100,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((((byte)city.CurrentProductionID +
								(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));
					}
					else
					{
						// Instruction address 0x1d12:0x3eb5, size: 5
						this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.ImprovementDefinitions(-city.CurrentProductionID).Name);

						// Instruction address 0x1d12:0x3ec5, size: 5
						this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 0x56);

						// Instruction address 0x1d12:0x3edd, size: 5
						this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 274, 100, 15);
					}

					// Instruction address 0x1d12:0x3ef9, size: 5
					F0_1d12_710d_FillRectangleWithPattern(231, 116, local_f6 + 1, local_fc + 1);

					for (int i = 0; i < city.ShieldsCount; i++)
					{
						// Instruction address 0x1d12:0x3f55, size: 5
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
							this.oParent.Var_aa_Rectangle,
							(((i % (local_4a * local_44)) * local_e8) / local_44) + 232,
							((i / (local_4a * local_44)) * 8) + 117,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));
					}

					// Instruction address 0x1d12:0x3f7b, size: 5
					if (city.ActualSize != 0)
					{
						local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(80 / city.ActualSize, 1, 8);
					}
					else
					{
						local_e8 = 1;
					}

					local_fc = 80 / local_4a;

					// Instruction address 0x1d12:0x3fb5, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 2, 106, 91, (local_4a * local_fc) + 12, 1);

					// Instruction address 0x1d12:0x3fcd, size: 5
					this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Food Storage", 8, 108, 15);

					// Instruction address 0x1d12:0x3ffc, size: 5
					F0_1d12_710d_FillRectangleWithPattern(3, 115, (city.ActualSize * local_e8) + 9, (local_4a * local_fc) + 2);

					if (city.HasImprovement(ImprovementEnum.Granary))
					{
						// Instruction address 0x1d12:0x403b, size: 5
						this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 5, 155, (city.ActualSize * local_e8) + 9, 155, 1);
					}

					// Instruction address 0x1d12:0x406a, size: 5
					int iTemp = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(city.FoodCount, 0, (city.ActualSize + 1) * local_4a);

					for (int i = 0; i < iTemp; i++)
					{
						// Instruction address 0x1d12:0x40af, size: 5
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							((i % (city.ActualSize + 1)) * local_e8) + 4,
							((i / (city.ActualSize + 1)) * local_fc) + 116,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
					}

					// Instruction address 0x1d12:0x40ca, size: 5
					F0_1d12_70cb_FillRectangleWithPattern(2, 23, 124, 65);

					local_fc = 25;

					// Instruction address 0x1d12:0x40f0, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 2, 23, 122, 9, 1);

					// Instruction address 0x1d12:0x4108, size: 5
					this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("City Resources", 8, local_fc, 15);

					local_fc += 8;

					for (int i = 0; i < 3; i++)
					{
						local_d8 = 4;

						if (i == 0)
						{
							// Instruction address 0x1d12:0x416d, size: 5
							// Instruction address 0x1d12:0x4181, size: 5
							local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
								116 / (this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70da_Arr[i], 
									(city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6), 999) + 1),
								1, 8);
						}
						else
						{
							// Instruction address 0x1d12:0x41ac, size: 5
							local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / (this.oParent.Var_70da_Arr[i] + 1), 1, 8);
						}

						for (int j = 0; j < this.oParent.Var_70da_Arr[i]; j++)
						{
							switch (i)
							{
								case 0:
									if ((city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6) == j)
									{
										local_d8 += 4;
									}
									break;

								case 1:
									if (this.oParent.Var_d2f6 != 0 && j == this.oParent.Var_d2f6)
									{
										local_d8 += 4;
									}
									break;

								case 2:
									if ((this.oParent.Var_70da_Arr[2] - this.oParent.Var_d2e0) == j)
									{
										local_d8 += 2;
									}
									break;
							}

							// Instruction address 0x1d12:0x4267, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								local_d8, (i * 8) + local_fc,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(((i + 8) << 1) + 0xd4ce)));

							local_d8 += local_e8;
						}
					}

					local_d8 = 8;

					// Instruction address 0x1d12:0x42a6, size: 5
					local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
						224 / (this.oParent.Var_70da_Arr[3] + this.oParent.Var_70e6 + this.oParent.Var_e17a + this.oParent.Var_d2e0 + 2), 1, 16);

					for (int i = 0; i < this.oParent.Var_70da_Arr[3]; i++)
					{
						// Instruction address 0x1d12:0x42e1, size: 5
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_d8 / 2, local_fc + 24,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xe << 1) + 0xd4ce)));

						local_d8 += local_e8;
					}

					if (this.oParent.Var_70da_Arr[3] != 0)
					{
						local_d8 += 8;
					}

					local_f6 = local_d8;

					for (int i = 0; i < this.oParent.Var_e17a; i++)
					{
						// Instruction address 0x1d12:0x433a, size: 5
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_d8 / 2, local_fc + 24,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xb << 1) + 0xd4ce)));

						local_d8 += local_e8;
					}

					if (this.oParent.Var_e17a != 0)
					{
						local_d8 += 8;
					}

					for (int i = 0; i < this.oParent.Var_70e6; i++)
					{
						// Instruction address 0x1d12:0x438b, size: 5
						this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_d8 / 2, local_fc + 24,
							this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xc << 1) + 0xd4ce)));

						local_d8 += local_e8;
					}

					if ((city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6) > this.oParent.Var_70da_Arr[0])
					{
						// Instruction address 0x1d12:0x43ed, size: 5
						local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / ((city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6) + 1), 1, 8);

						for (int i = this.oParent.Var_70da_Arr[0]; i < (city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6); i++)
						{
							// Instruction address 0x1d12:0x443e, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								(i * local_e8) + 8, local_fc,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
						}

						// Instruction address 0x1d12:0x448f, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
							(local_e8 * this.oParent.Var_70da_Arr[0]) + 8, local_fc,
							(((city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6) - this.oParent.Var_70da_Arr[0]) * local_e8) + 4,
							8, 15, 0);
					}

					if (this.oParent.Var_70da_Arr[1] < this.oParent.Var_d2f6)
					{
						// Instruction address 0x1d12:0x44b9, size: 5
						local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / (this.oParent.Var_70da_Arr[1] + 1), 1, 8);

						for (int i = this.oParent.Var_70da_Arr[1]; i < this.oParent.Var_d2f6; i++)
						{
							// Instruction address 0x1d12:0x44f7, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								(i * local_e8) + 8, local_fc + 8,
								this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));
						}

						// Instruction address 0x1d12:0x4532, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
							(this.oParent.Var_70da_Arr[1] * local_e8) + 8, local_fc + 8,
							(this.oParent.Var_d2f6 - this.oParent.Var_70da_Arr[1]) * local_e8,
							8, 15, 0);
					}

					if (this.oParent.Var_d2e0 != 0)
					{
						// Instruction address 0x1d12:0x455a, size: 5
						local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / (this.oParent.Var_70da_Arr[2] + 1), 1, 8);

						// Instruction address 0x1d12:0x4598, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
							((this.oParent.Var_70da_Arr[2] - this.oParent.Var_d2e0) * local_e8) + 6,
							local_fc + 16, (local_e8 * this.oParent.Var_d2e0) + 2,
							8, 15, 0);
					}

					// Instruction address 0x1d12:0x45b0, size: 5
					F0_1d12_710d_FillRectangleWithPattern(8, 8, 200, 13);

					// Instruction address 0x1d12:0x45ca, size: 5
					local_f4 = F0_1d12_6ed4_DrawResources(cityID, 8, 8, local_8, 192);

					// Instruction address 0x1d12:0x45f3, size: 5
					local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((city.ActualSize * 8) + 24, 0, 128);

					for (int i = 0; i < 3; i++)
					{
						local_4c = city.TradeCityIDs[i];

						if (local_4c != -1)
						{
							this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

							// Instruction address 0x1d12:0x463d, size: 5
							this.oParent.Segment_2459.F0_2459_08c6_GetCityName((short)local_4c);

							// Instruction address 0x1d12:0x464d, size: 5
							this.oParent.MSCAPI.strcat(0xba06, ":+");

							if (this.oParent.CivState.Cities[local_4c].PlayerID != this.Var_6548_PlayerID)
							{
								// Instruction address 0x1d12:0x46b0, size: 5
								this.oParent.MSCAPI.strcat(0xba06,
									this.oParent.MSCAPI.itoa((city.BaseTrade + this.oParent.CivState.Cities[local_4c].BaseTrade + 4) / 8, 10));
							}
							else
							{
								// Instruction address 0x1d12:0x4700, size: 5
								this.oParent.MSCAPI.strcat(0xba06,
									this.oParent.MSCAPI.itoa((city.BaseTrade + this.oParent.CivState.Cities[local_4c].BaseTrade + 4) / 16, 10));
							}
						
							// Instruction address 0x1d12:0x4710, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "} ");

							if (this.Var_2496 == 2)
							{
								// Instruction address 0x1d12:0x473c, size: 5
								F0_1d12_73ea_DrawCityRectangle((ushort)((short)this.oParent.CivState.Cities[local_4c].Position.X),
									(ushort)((short)this.oParent.CivState.Cities[local_4c].Position.Y), 10);
							}

							if (this.Var_2496 == 0)
							{
								// Instruction address 0x1d12:0x4765, size: 5
								this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 98, (i * 6) + 179, 10);
							}
						}
					}

					if (this.Var_2496 == 2)
					{
						// Instruction address 0x1d12:0x4795, size: 5
						F0_1d12_73ea_DrawCityRectangle((ushort)((short)this.oParent.CivState.Cities[this.Var_653e_CityID].Position.X),
							(ushort)((short)this.oParent.CivState.Cities[this.Var_653e_CityID].Position.Y), 15);
					}

					if (this.Var_2496 == 0)
					{
						local_e0 = (this.oParent.Var_70da_Arr[1] / this.oParent.Var_6c98) - 20 + ((city.ActualSize * this.oParent.Var_b882) / 4);

						// Instruction address 0x1d12:0x47ef, size: 5
						// Instruction address 0x1d12:0x4802, size: 5
						local_fc = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
							100 / this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_e0, 1, 99), 1, 8);

						for (int i = 0; i < local_e0; i++)
						{
							// Instruction address 0x1d12:0x4847, size: 5
							this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								(i * local_fc) + 98, (i & 1) + 161, this.oParent.Var_b2ba);
						}
					}

					if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID)
					{
						local_ea = 0;

						// Instruction address 0x1d12:0x4876, size: 5
						F0_1d12_71bf_DrawFilledRectangleWithCenteredText(284, 190, 316, 198, 0x2662, 12);

						// Instruction address 0x1d12:0x4896, size: 5
						F0_1d12_71bf_DrawFilledRectangleWithCenteredText(231, 190, 272, 198, 0x2667, 9);

						local_c0 = 0;

						if (city.CurrentProductionID < 0 && city.CurrentProductionID >= -21 && city.HasImprovement(City.BitToImprovementEnum((-city.CurrentProductionID) - 1)))
						{
							local_c0 = 1;
						}

						if (city.CurrentProductionID < -21 && city.CurrentProductionID >= -24 && (this.oParent.CivState.SpaceshipFlags & (1 << this.Var_6548_PlayerID)) != 0)
						{
							local_c0 = 1;
						}

						if (city.CurrentProductionID < -24)
						{
							if (this.oParent.CivState.WonderCityID[Math.Abs(city.CurrentProductionID) - 24] != -1)
							{
								local_c0 = 1;
							}
						}

						if (city.CurrentProductionID >= 0 && this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitCount >= 127)
						{
							local_c0 = 1;
						}

						// Instruction address 0x1d12:0x4994, size: 5
						this.oParent.Segment_11a8.F0_11a8_0250();

						while (this.oParent.Var_db3a_MouseButton != 0)
						{
							// Instruction address 0x1d12:0x49a3, size: 5
							this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();
						}

						while (this.oParent.Var_db3a_MouseButton == 0)
						{
							// Instruction address 0x1d12:0x49b5, size: 5
							if (this.oParent.MSCAPI.kbhit() != 0 || local_b8 != 0)
								break;

							// Instruction address 0x1d12:0x49cc, size: 5
							this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

							if (local_c0 != 0)
							{
								// Instruction address 0x1d12:0x49db, size: 5
								this.oParent.Segment_11a8.F0_11a8_0268();

								local_c0++;

								if ((local_c0 & 1) != 0)
								{
									// Instruction address 0x1d12:0x4a0b, size: 5
									this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 231, 106, 32, 8, 14, 9);
								}
								else
								{
									// Instruction address 0x1d12:0x4a32, size: 5
									this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 231, 106, 32, 8, 9, 14);
								}

								// Instruction address 0x1d12:0x4a3a, size: 5
								this.oParent.Segment_11a8.F0_11a8_0250();

								// Instruction address 0x1d12:0x4a43, size: 5
								this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);
							}
						}

						local_f0 = -1;

						// Instruction address 0x1d12:0x4a54, size: 5
						if (this.oParent.MSCAPI.kbhit() == 0)
						{
							if (local_b8 != 0)
							{
								local_f0 = (int)'p';
							}
						}
						else
						{
							// Instruction address 0x1d12:0x4a61, size: 5
							local_f0 = this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

							this.oParent.Var_db3e_MouseYPos = 0;
							this.oParent.Var_db3c_MouseXPos = 0;
						}

						// Instruction address 0x1d12:0x4a86, size: 5
						this.oParent.Segment_11a8.F0_11a8_0268();

						if ((this.oParent.Var_db3a_MouseButton == 2 &&
							this.oParent.Var_db3c_MouseXPos >= 230 && this.oParent.Var_db3c_MouseXPos < 270 &&
							this.oParent.Var_db3e_MouseYPos >= 106 && this.oParent.Var_db3e_MouseYPos <= 116) ||
							local_f0 == 65)
						{
							city.StatusFlag ^= 0x10;

							if ((city.StatusFlag & 0x10) != 0)
							{
								// Instruction address 0x1d12:0x4aef, size: 5
								local_102 = (short)this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

								this.oParent.Var_aa_Rectangle.FontID = 2;

								if (local_102 != 99)
								{
									this.oParent.Var_b1e8 = 0;

									if (city.CurrentProductionID >= 0)
									{
										this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;
									}

									city.CurrentProductionID = (sbyte)local_102;

									if (city.CurrentProductionID >= 0)
									{
										this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;
									}

									// Instruction address 0x1d12:0x4b9c, size: 5
									this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 230, 99, 90, 100, 0);
								}
								else
								{
									goto L045f;
								}
							}

							this.oParent.Var_70da_Arr[1] = local_10a;
							this.oParent.Var_70da_Arr[2] = local_a;

							goto L12c2;
						}

						if (local_f0 != -1)
							goto L4be2;

						if (this.oParent.Var_db3a_MouseButton == 1) goto L4bce;
						goto L4ff5;

					L4bce:
						if (this.oParent.Var_db3e_MouseYPos >= 106) goto L4bd8;
						goto L4ff5;

					L4bd8:
						if (this.oParent.Var_db3e_MouseYPos <= 116) goto L4be2;
						goto L4ff5;

					L4be2:
						if (this.oParent.Var_db3c_MouseXPos < 296) goto L4bed;
						goto L4bf7;

					L4bed:
						if (local_f0 == (int)'b') goto L4bf7;
						goto L4e80;

					L4bf7:
						if (city.CurrentProductionID >= 0)
						{
							local_106 = this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Cost;

							// Instruction address 0x1d12:0x4c3d, size: 5
							local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((10 * local_106) - city.ShieldsCount, 0, 999);

							local_e8 = (local_e8 * local_e8) / 20 + local_e8 * 2;
						}
						else
						{
							local_106 = this.oParent.CivState.ImprovementDefinitions(-city.CurrentProductionID).Price;

							// Instruction address 0x1d12:0x4ca0, size: 5
							local_e8 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((10 * local_106) - city.ShieldsCount, 0, 999) * 2;

							if ((-city.CurrentProductionID) > 21)
							{
								local_e8 += local_e8;
							}
						}

						if (city.ShieldsCount == 0)
						{
							local_e8 += local_e8;
						}

						// Instruction address 0x1d12:0x4ce7, size: 5
						this.oParent.MSCAPI.strcpy(0xba06, "Cost to complete\n");

						if (city.CurrentProductionID >= 0)
						{
							// Instruction address 0x1d12:0x4d17, size: 5
							this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.UnitDefinitions[city.CurrentProductionID].Name);
						}
						else
						{
							// Instruction address 0x1d12:0x4d3e, size: 5
							this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.ImprovementDefinitions(-city.CurrentProductionID).Name);
						}

						// Instruction address 0x1d12:0x4d4e, size: 5
						this.oParent.MSCAPI.strcat(0xba06, ": $");

						// Instruction address 0x1d12:0x4d6f, size: 5
						this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(local_e8, 10));

						// Instruction address 0x1d12:0x4d7f, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "\nTreasury: $");

						// Instruction address 0x1d12:0x4da6, size: 5
						this.oParent.MSCAPI.strcat(0xba06,
							this.oParent.MSCAPI.itoa(this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins, 10));

						// Instruction address 0x1d12:0x4db6, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "\n");

						if (city.CurrentProductionID >= 0 && (city.StatusFlag & 0x1) != 0)
						{
							// Instruction address 0x1d12:0x4dea, size: 5
							this.oParent.MSCAPI.strcat(0xba06, "CIVIL DISORDER\n");
						}
						else if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins >= local_e8)
						{
							// Instruction address 0x1d12:0x4e10, size: 5
							this.oParent.MSCAPI.strcat(0xba06, " Yes\n No\n");
						}

						// Instruction address 0x1d12:0x4e18, size: 5
						this.oParent.Segment_11a8.F0_11a8_0250();

						this.oParent.Var_aa_Rectangle.FontID = 1;

						// Instruction address 0x1d12:0x4e32, size: 5
						if (this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 100, 80, 1) == 0 && this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins >= local_e8)
						{
							city.ShieldsCount = (short)(local_106 * 10);

							this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins -= (short)local_e8;
						}

						// Instruction address 0x1d12:0x4e78, size: 5
						this.oParent.Segment_11a8.F0_11a8_0268();

						goto L045f;

					L4e80:
						if ((this.oParent.Var_db3c_MouseXPos >= 230 && this.oParent.Var_db3c_MouseXPos < 270) || local_f0 == (int)'c')
						{
							city.StatusFlag &= 0xef;

							// Instruction address 0x1d12:0x4ead, size: 5
							this.oParent.Segment_11a8.F0_11a8_0250();

							if (city.CurrentProductionID >= 0)
							{
								this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;
							}

							// Instruction address 0x1d12:0x4ee9, size: 5
							city.CurrentProductionID = (sbyte)((short)this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID));

							if (city.CurrentProductionID >= 0)
							{
								this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;
							}

							// Instruction address 0x1d12:0x4f2f, size: 5
							this.oParent.Segment_11a8.F0_11a8_0268();

							goto L045f;
						}

						if (local_f0 == (int)'i') goto L4f41;
						goto L4f4a;

					L4f41:
						this.Var_2496 = 0;
						goto L4faf;

					L4f4a:
						if (local_f0 == (int)'h') goto L4f54;
						goto L4f5d;

					L4f54:
						this.Var_2496 = 1;
						goto L4faf;

					L4f5d:
						if (local_f0 == (int)'m') goto L4f67;
						goto L4f70;

					L4f67:
						this.Var_2496 = 2;
						goto L4faf;

					L4f70:
						if (local_f0 == (int)'v') goto L4f7a;
						goto L4f83;

					L4f7a:
						this.Var_2496 = 3;
						goto L4faf;

					L4f83:
						if (this.oParent.Var_db3c_MouseXPos >= 96 && this.oParent.Var_db3c_MouseXPos < 224) goto L4f98;
						goto L4ff5;

					L4f98:
						this.Var_2496 = (this.oParent.Var_db3c_MouseXPos - 96) / 32;

					L4faf:
						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						if (this.Var_2496 != 3)
							goto L12c2;

						this.oParent.Var_aa_Rectangle.FontID = 1;

						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

						this.oParent.CityView.F19_0000_0000(cityID, -1);

						this.oParent.Var_6b64 = 1;
						this.Var_2496 = 0;

						goto L045f;

					L4ff5:
						if (local_f0 == (int)'a') goto L4fff;
						goto L520e;

					L4fff:
						for (local_106 = 0; local_106 < local_4e && (this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status & 0xcf) == 0; local_106++)
						{
						}

						if (local_106 == local_4e)
						{
							local_106 = 0;
						}

					L504b:
						local_fa = ((local_106 % 6) * 18) + 100;
						local_100 = (local_106 / 6) * 16 + 116;

						do
						{
							// Instruction address 0x1d12:0x5088, size: 5
							F0_1d12_710d_FillRectangleWithPattern(local_fa, local_100, 16, 16);

							// Instruction address 0x1d12:0x5094, size: 5
							this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

							// Instruction address 0x1d12:0x50b1, size: 5
							this.oParent.MapManagement.F0_2aea_0fb3(this.Var_6548_PlayerID, (short)Arr_74[local_106], local_fa, local_100);

							// Instruction address 0x1d12:0x50bd, size: 5
							this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);
						}
						// Instruction address 0x1d12:0x50c5, size: 5
						while (this.oParent.MSCAPI.kbhit() == 0);

						// Instruction address 0x1d12:0x50d2, size: 5
						local_fc = this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey(); // this.oCPU.AX.Word has navigatio code also!

						switch (local_fc)
						{
							case 0x4800:
								local_ea = local_106 - 6;
								break;

							case 0x4b00:
								local_ea = local_106 - 1;
								break;

							case 0x4d00:
								local_ea = local_106 + 1;
								break;

							case 0x5000:
								local_ea = local_106 + 6;
								break;

							default:
								local_ea = local_106;
								break;
						}

						// Instruction address 0x1d12:0x5151, size: 5
						local_106 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_ea, 0, local_4e - 1);

						if (local_fc == '\n' || local_fc == ' ')
						{
							if ((this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status & 0x9) != 0)
							{
								this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].RemainingMoves =
									(short)(this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].TypeID].MoveCount * 3);
							}

							this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status &= 0x30;
							this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].GoToPosition.X = -1;
						}
					
						if (local_fc != 0x1b)
							goto L504b;

						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						goto L12c2;

					L520e:
						if (local_f0 == (int)'s') goto L5218;
						goto L532e;

					L5218:
						if ((city.StatusFlag & 0x80) == 0) goto L522a;
						goto L532e;

					L522a:
						local_106 = 0;

					L5230:
						// Instruction address 0x1d12:0x5258, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
							252, ((local_106 + local_40) * 6) + 3, 56, 7, 9, 1);

						// Instruction address 0x1d12:0x5264, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

						// Instruction address 0x1d12:0x5294, size: 5
						this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
							252, ((local_106 + local_40) * 6) + 3, 56, 7, 1, 9);

						// Instruction address 0x1d12:0x52a0, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

						// Instruction address 0x1d12:0x52a8, size: 5
						if (this.oParent.MSCAPI.kbhit() != 0) goto L52b5;
						goto L5230;

					L52b5:
						// Instruction address 0x1d12:0x52b5, size: 5
						local_fc = this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();
						goto L52e0;

					L52c5:
						local_ea = local_106 + 1;
						goto L52f3;

					L52d1:
						local_ea = local_106 - 1;
						goto L52f3;

					L52e0:
						if (local_fc != 0x4800) goto L52e8;
						goto L52d1;

					L52e8:
						if (local_fc != 0x5000) goto L52f3;
						goto L52c5;

					L52f3:
						// Instruction address 0x1d12:0x5301, size: 5
						local_106 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_ea, 0, local_b4 - 1);

						if (local_fc == '\n') goto L5740;

						if (local_fc == ' ') goto L5740;

						if (local_fc != 0x1b) goto L5230;

					L532e:
						if (local_f0 < '1' || local_f0 > '9')
							goto L53c8;

						local_ea = local_f0 - 49;

						if (local_ea >= local_8)
							goto L045f;

						if (city.ActualSize >= 5) goto L536b;
						goto L53ad;

					L536b:
						// Instruction address 0x1d12:0x536f, size: 5
						local_e8 = (short)F0_1d12_6da1_GetSpecialWorkerFlags(local_ea);

						if (local_e8 >= 3)
							goto L539a;

						// Instruction address 0x1d12:0x538f, size: 5
						F0_1d12_6d6e_SetSpecialWorkerFlags(local_ea, local_e8 + 1);

						goto L53aa;

					L539a:
						// Instruction address 0x1d12:0x53a2, size: 5
						F0_1d12_6d6e_SetSpecialWorkerFlags(local_ea, 1);

					L53aa:
						goto L53b5;

					L53ad:
						this.oParent.MSCAPI.strcpy(0xba06, "A City must have five\npopulation units to support\ntaxmen or scientists.\n");
						this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 32, 32, 1);

						goto L045f;

					L53b5:
						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						goto L12c2;

					L53c8:
						if (local_f0 == (int)'p') goto L53d2;
						goto L563f;

					L53d2:
						if (local_b8 != 0)
							goto L53ed;

						local_be = 0;
						local_b6 = 0;
						local_b8 = 1;

					L53ed:
						// Instruction address 0x1d12:0x541d, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle,
							(local_b6 * 16) + 160, (local_be * 16) + 56,
							16, 16, this.oParent.Var_19d4_Rectangle, 0, 0);

						// Instruction address 0x1d12:0x5449, size: 5
						this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
							(local_b6 * 16) + 160, (local_be * 16) + 56,
							15, 15, 15);

						// Instruction address 0x1d12:0x5455, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

						// Instruction address 0x1d12:0x548d, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 16, 16, this.oParent.Var_aa_Rectangle,
							(local_b6 * 16) + 160, (local_be * 16) + 56);

						// Instruction address 0x1d12:0x5499, size: 5
						this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

						this.oParent.Var_6b64 = 1;

						// Instruction address 0x1d12:0x54a7, size: 5
						if (this.oParent.MSCAPI.kbhit() != 0) goto L54b4;
						goto L53ed;

					L54b4:
						local_f6 = local_b6;
						local_fc = local_be;

						// Instruction address 0x1d12:0x54c4, size: 5
						local_e8 = this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

						goto L551f;

					L54d4:
						local_be--;

						goto L556a;

					L54db:
						local_be--;
						local_b6++;

						goto L556a;

					L54e6:
						local_b6++;

						goto L556a;

					L54ed:
						local_b6++;
						local_be++;

						goto L556a;

					L54f8:
						local_be++;

						goto L556a;

					L54ff:
						local_b6--;
						local_be++;

						goto L556a;

					L550a:
						local_b6--;

						goto L556a;

					L5511:
						local_b6--;
						local_be--;

						goto L556a;

					L551f:
						if (local_e8 != 0x4b00) goto L5527;
						goto L550a;

					L5527:
						if (local_e8 <= 0x4b00) goto L552c;
						goto L5547;

					L552c:
						if (local_e8 != 0x4700) goto L5534;
						goto L5511;

					L5534:
						if (local_e8 != 0x4800) goto L553c;
						goto L54d4;

					L553c:
						if (local_e8 != 0x4900) goto L556a;
						goto L54db;

					L5547:
						if (local_e8 != 0x4d00) goto L554f;
						goto L54e6;

					L554f:
						if (local_e8 != 0x4f00) goto L5557;
						goto L54ff;

					L5557:
						if (local_e8 != 0x5000) goto L555f;
						goto L54f8;

					L555f:
						if (local_e8 != 0x5100) goto L556a;
						goto L54ed;

					L556a:
						if (Math.Abs(local_b6) > 2 || Math.Abs(local_be) > 2)
							goto L55f5;

						if (Math.Abs(local_b6) + Math.Abs(local_be) < 4) goto L55b6;
						goto L55f5;

					L55b6:
						if ((this.oParent.CivState.MapVisibility[city.Position.X + local_b6, city.Position.Y + local_be] & (1 << this.oParent.CivState.HumanPlayerID)) == 0) goto L55f5;
						goto L5605;

					L55f5:
						local_b6 = local_f6;
						local_be = local_fc;

					L5605:
						if (local_e8 == 13)
							goto L5619;

						if (local_e8 != 32)
							goto L562c;

						L5619:
						local_f6 = local_b6;
						local_fc = local_be;

						goto L5aa6;

					L562c:
						if (local_e8 != 27)
							goto L53ed;

						local_b8 = 0;

						goto L045f;

					L563f:
						if (local_f0 == (int)'M') goto L5649;
						goto L5671;

					L5649:
						if ((local_ca & 2) == 0)
							goto L5671;

						local_ca ^= 1;
						local_da = local_fe;
						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						goto L12c2;

					L5671:
						if (local_f0 != (int)'r') goto L567b;
						goto L56a6;

					L567b:
						if (this.oParent.Var_db3a_MouseButton == 1) goto L5685;
						goto L56c8;

					L5685:
						if (this.oParent.Var_db3c_MouseXPos >= 231) goto L5690;
						goto L56c8;

					L5690:
						if (this.oParent.Var_db3e_MouseYPos > 190) goto L569b;
						goto L56c8;

					L569b:
						if (this.oParent.Var_db3c_MouseXPos < 270) goto L56a6;
						goto L56c8;

					L56a6:
						// Instruction address 0x1d12:0x56a6, size: 5
						this.oParent.Segment_1403.F0_1403_4545();

						this.oParent.Var_aa_Rectangle.FontID = 1;

						this.oParent.Overlay_23.F23_0000_0000_CityNameDialog(cityID);

						this.oParent.Var_6b64 = 1;

						goto L045f;

					L56c8:
						if (this.oParent.Var_db3a_MouseButton == 1) goto L56d2;
						goto L5cc2;

					L56d2:
						if (this.oParent.Var_db3c_MouseXPos >= 288) goto L56dd;
						goto L5719;

					L56dd:
						if (this.oParent.Var_db3e_MouseYPos < 96) goto L56e7;
						goto L5719;

					L56e7:
						if (this.oParent.Var_db3e_MouseYPos > 88) goto L56f1;
						goto L5719;

					L56f1:
						if ((local_ca & 2) == 0)
							goto L5719;

						local_ca ^= 1;
						local_da = local_fe;
						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						goto L12c2;

					L5719:
						if (this.oParent.Var_db3c_MouseXPos >= 300) goto L5724;
						goto L58ac;

					L5724:
						if (this.oParent.Var_db3e_MouseYPos < 94) goto L572e;
						goto L58ac;

					L572e:
						local_106 = ((this.oParent.Var_db3e_MouseYPos - 2) / 6) - local_40;

					L5740:
						local_bc = local_da;

						goto L574f;

					L574b:
						local_bc++;

					L574f:
						if (local_bc >= 24)
							goto L58ac;

						if (city.HasImprovement(City.BitToImprovementEnum(local_bc))) goto L5783;
						goto L574b;

					L5783:
						local_106--;

						if (local_106 != -1)
							goto L574b;

						if ((city.StatusFlag & 0x80) == 0) goto L57a5;
						goto L574b;

					L57a5:
						// Instruction address 0x1d12:0x57ad, size: 5
						this.oParent.MSCAPI.strcpy(0xba06, "Do you want to sell\nyour ");

						// Instruction address 0x1d12:0x57c4, size: 5
						this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.ImprovementDefinitions(local_bc + 1).Name);

						// Instruction address 0x1d12:0x57d4, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " for ");

						// Instruction address 0x1d12:0x5802, size: 5
						this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(10 * this.oParent.CivState.ImprovementDefinitions(local_bc + 1).Price, 10));

						// Instruction address 0x1d12:0x5812, size: 5
						this.oParent.MSCAPI.strcat(0xba06, "$?\n No.\n Yes.\n");

						this.oParent.Var_aa_Rectangle.FontID = 1;

						// Instruction address 0x1d12:0x5823, size: 5
						this.oParent.Segment_11a8.F0_11a8_0250();

						// Instruction address 0x1d12:0x5834, size: 5
						if (this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 128, 80, 1) == 1) goto L5844;
						goto L58a1;

					L5844:
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins += (short)(10 * this.oParent.CivState.ImprovementDefinitions(local_bc + 1).Price);
						city.RemoveImprovement(City.BitToImprovementEnum(local_bc));
						city.StatusFlag |= 0x80;

						if (local_bc + 1 != 8)
							goto L58a1;

						this.oParent.Var_6b64 = 1;

					L58a1:
						// Instruction address 0x1d12:0x58a1, size: 5
						this.oParent.Segment_11a8.F0_11a8_0268();

						goto L045f;

					L58ac:
						if (this.oParent.Var_db3c_MouseXPos < 200) goto L58b7;
						goto L596b;

					L58b7:
						if (this.oParent.Var_db3e_MouseYPos < 20) goto L58c1;
						goto L596b;

					L58c1:
						if (city.ActualSize >= 5) goto L58d3;
						goto L5953;

					L58d3:
						local_ea = (this.oParent.Var_db3c_MouseXPos - 16) / local_f4;
						local_ea -= city.ActualSize - local_50;

						if (local_ea < 0)
							goto L045f;


						if (local_ea >= local_8)
							goto L045f;

						// Instruction address 0x1d12:0x5915, size: 5
						local_e8 = (short)F0_1d12_6da1_GetSpecialWorkerFlags(local_ea);

						if (local_e8 >= 3)
							goto L5940;

						// Instruction address 0x1d12:0x5935, size: 5
						F0_1d12_6d6e_SetSpecialWorkerFlags(local_ea, local_e8 + 1);

						goto L5950;

					L5940:
						// Instruction address 0x1d12:0x5948, size: 5
						F0_1d12_6d6e_SetSpecialWorkerFlags(local_ea, 1);

					L5950:
						goto L595b;

					L5953:
						this.oParent.MSCAPI.strcpy(0xba06, "A City must have five\npopulation units to support\ntaxmen or scientists.\n");
						this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 32, 32, 1);

						goto L045f;

					L595b:
						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						goto L12c2;

					L596b:
						if (this.oParent.Var_db3c_MouseXPos >= 100) goto L5975;
						goto L5a60;

					L5975:
						if (this.oParent.Var_db3c_MouseXPos < 9600) goto L5980;
						goto L5a60;

					L5980:
						if (this.oParent.Var_db3e_MouseYPos >= 116) goto L598a;
						goto L5a60;

					L598a:
						local_106 = (((this.oParent.Var_db3e_MouseYPos - 116) / 16) * 6) + ((this.oParent.Var_db3c_MouseXPos - 100) / 16);

						if (local_106 >= local_4e)
							goto L5a60;

						if ((this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status & 0x9) == 0)
							goto L5a18;

						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].RemainingMoves =
							(short)(this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].TypeID].MoveCount * 3);

					L5a18:
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status &= 0x30;
						this.oParent.CivState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].GoToPosition.X = -1;

						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						goto L12c2;

					L5a60:
						if (this.oParent.Var_db3e_MouseYPos >= 24) goto L5a6a;
						goto L5cc2;

					L5a6a:
						if (this.oParent.Var_db3e_MouseYPos < 104) goto L5a74;
						goto L5cc2;

					L5a74:
						local_f6 = (this.oParent.Var_db3c_MouseXPos / 16) - 10;
						local_fc = ((this.oParent.Var_db3e_MouseYPos - 24) / 16) - 2;

					L5aa6:
						// Instruction address 0x1d12:0x5aae, size: 5
						local_ea = F0_1d12_000a_FindCityOffset(new GPoint(local_f6, local_fc));

						if (local_ea == -1)
							goto L045f;

						if (local_ea >= 20)
							goto L045f;

						if ((this.oParent.CivState.MapVisibility[city.Position.X + this.oParent.CityOffsets[local_ea].X, city.Position.Y + this.oParent.CityOffsets[local_ea].Y] &
							(1 << this.Var_6548_PlayerID)) != 0) goto L5b13;
						goto L045f;

					L5b13:
						this.oParent.Var_70da_Arr[1] = local_10a;
						this.oParent.Var_70da_Arr[2] = local_a;

						if ((city.WorkerFlags & (1 << local_ea)) != 0)
							goto L5b6e;

						if (Arr_a6[this.oParent.CityOffsets[local_ea].X + 2, this.oParent.CityOffsets[local_ea].Y + 2] != 0)
							goto L12c2;

					L5b6e:
						city.WorkerFlags ^= (uint)(1 << local_ea);

						if ((city.WorkerFlags & (1 << local_ea)) == 0)
							goto L5be5;

						local_ae++;

						// Instruction address 0x1d12:0x5bc9, size: 5
						F0_1d12_692d_CityResources(cityID, local_ea, flag);

						if (this.oParent.Var_e8b8 != 0)
						{
							this.oParent.Var_e8b8--;
							local_50--;
						}
						goto L5c78;

					L5be5:
						local_ae--;
						local_bc = 0;

						goto L5bf6;

					L5bf2:
						local_bc++;

					L5bf6:
						if (local_bc >= 3)
							goto L5c45;

						// Instruction address 0x1d12:0x5c28, size: 5
						local_cc = F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID,
							city.Position.X + this.oParent.CityOffsets[local_ea].X, city.Position.Y + this.oParent.CityOffsets[local_ea].Y, (CityResourceTypeEnum)local_bc);

						this.oParent.Var_70da_Arr[local_bc] -= local_cc;

						goto L5bf2;

					L5c45:
						// Instruction address 0x1d12:0x5c69, size: 5
						this.oParent.MapManagement.F0_2aea_03ba(
							city.Position.X + this.oParent.CityOffsets[local_ea].X,
							city.Position.Y + this.oParent.CityOffsets[local_ea].Y);

						this.oParent.Var_e8b8++;
						local_50++;

					L5c78:
						city.WorkerFlags &= 0x3ffffff;
						city.WorkerFlags |= (uint)((uint)local_50 << 26);

						if (local_ae > 0) goto L045f;
						goto L12c2;
					}

					// Instruction address 0x1d12:0x5cbd, size: 5
					this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

				L5cc2:
					this.oParent.Var_d4cc_XPos = (short)local_c2;
					this.oParent.Var_d75e_YPos = (short)local_d0;
				}

				if (flag != 0)
					goto L68cc;

				if (this.Var_6548_PlayerID == 0)
					goto L62d8;

				local_e8 = this.oParent.Var_70e2 - this.oParent.Var_70e4;

				if (local_e8 >= 0)
					goto L5f3f;

				if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) == 0)
					goto L5df3;

				// Instruction address 0x1d12:0x5d14, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Civil Disorder in\n");

				// Instruction address 0x1d12:0x5d1f, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x5d2f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "! Mayor\nflees in panic.\n");

				// Instruction address 0x1d12:0x5d3b, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

				if (this.oParent.CivState.GameSettingFlags.Animations) goto L5d4d;
				goto L5d9f;

			L5d4d:
				if ((city.StatusFlag & 0x1) == 0) goto L5d5f;
				goto L5d9f;

			L5d5f:
				if (this.oParent.Var_6b92 == 0) goto L5d69;
				goto L5d9f;

			L5d69:
				this.oParent.CityView.F19_0000_0000(cityID, -2);

				this.oParent.CityView.F19_0000_18c1_CivilDisorderAnimation();

				// Instruction address 0x1d12:0x5d89, size: 5
				this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

				// Instruction address 0x1d12:0x5d91, size: 5
				this.oParent.Segment_1238.F0_1238_1b44();

				this.oParent.Var_6b92 = 1;
				goto L5db9;

			L5d9f:
				this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DomesticAdvisor;

				// Instruction address 0x1d12:0x5db1, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			L5db9:
				// Instruction address 0x1d12:0x5dbd, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

				if ((city.StatusFlag & 0x1) == 0) goto L5dd7;
				goto L5df3;

			L5dd7:
				this.oParent.Var_b1e8 = 1;

				if (this.oParent.CivState.GameSettingFlags.InstantAdvice) goto L5de7;
				goto L5df3;

			L5de7:
				this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x2708);

			L5df3:
				if ((city.StatusFlag & 0x1) == 0) goto L5e05;
				goto L5eb4;

			L5e05:
				city.StatusFlag |= 1;

				if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) == 0) goto L5e24;
				goto L5ea1;

			L5e24:
				if (city.CurrentProductionID >= 0) goto L5e36;
				goto L5e54;

			L5e36:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

			L5e54:
				// Instruction address 0x1d12:0x5e5b, size: 5
				city.CurrentProductionID = (sbyte)((short)this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID));

				if (city.CurrentProductionID >= 0) goto L5e83;
				goto L5ea1;

			L5e83:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L5ea1:
				// Instruction address 0x1d12:0x5ea9, size: 5
				this.oParent.Segment_1403.F0_1403_3ed7(local_d8, local_e4);

				goto L606c;

			L5eb4:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType != 5)
					goto L606c;

				// Instruction address 0x1d12:0x5ec8, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

				// Instruction address 0x1d12:0x5ed8, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Discontented citizens of\n");

				// Instruction address 0x1d12:0x5ee3, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x5ef3, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " revolt:\nGovernment Collapses!\n");

				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
					goto L5f20;

				this.oParent.Overlay_21.F21_0000_0000(cityID);

				this.oParent.CivState.Players[this.Var_6548_PlayerID].Diplomacy[0] |= 4;

			L5f20:
				// Instruction address 0x1d12:0x5f28, size: 5
				this.oParent.Segment_2517.F0_2517_04a1(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x5f34, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

				goto L606c;

			L5f3f:
				if (local_e8 < 0)
					goto L604f;

				if ((city.StatusFlag & 0x1) != 0) goto L5f5b;
				goto L604f;

			L5f5b:
				city.StatusFlag &= 0xfe;

				if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) != 0) goto L5f7a;
				goto L5fc2;

			L5f7a:
				this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DomesticAdvisor;

				// Instruction address 0x1d12:0x5f88, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Order restored\nin ");

				// Instruction address 0x1d12:0x5f93, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x5fa3, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				// Instruction address 0x1d12:0x5fb7, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

				goto L603f;

			L5fc2:
				if (city.CurrentProductionID >= 0) goto L5fd4;
				goto L5ff2;

			L5fd4:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

			L5ff2:
				// Instruction address 0x1d12:0x5ff9, size: 5
				city.CurrentProductionID = (sbyte)((short)this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID));

				if (city.CurrentProductionID >= 0) goto L6021;
				goto L603f;

			L6021:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L603f:
				// Instruction address 0x1d12:0x6047, size: 5
				this.oParent.Segment_1403.F0_1403_3ed7(local_d8, local_e4);

			L604f:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L605f;
				goto L606c;

			L605f:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins += (short)this.oParent.Var_e17a;

			L606c:
				if (this.oParent.Var_70e4 != 0)
					goto L6213;

				if (city.ActualSize > 2) goto L6088;
				goto L6213;

			L6088:
				if (((city.ActualSize + 1) / 2) > this.oParent.Var_70e2)
					goto L6213;

				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L60b4;
				goto L6213;

			L60b4:
				if ((city.StatusFlag & 0x40) == 0) goto L60c6;
				goto L61ac;

			L60c6:
				if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) != 0) goto L60d8;
				goto L619c;

			L60d8:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L60e8;
				goto L619c;

			L60e8:
				// Instruction address 0x1d12:0x60f0, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "'We love the ");

				this.oCPU.BX.Word = (ushort)this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType;
				this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
				// Instruction address 0x1d12:0x610c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

				// Instruction address 0x1d12:0x611c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "'\nday celebrated in\n");

				// Instruction address 0x1d12:0x6127, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x6137, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "!\n");

				// Instruction address 0x1d12:0x6143, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x22, 0);

				if (this.oParent.CivState.GameSettingFlags.Animations)
				{
					this.oParent.CityView.F19_0000_0000(cityID, -2);

					this.oParent.CityView.F19_0000_1ae1();

					// Instruction address 0x1d12:0x6175, size: 5
					this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

					// Instruction address 0x1d12:0x617d, size: 5
					this.oParent.Segment_1238.F0_1238_1b44();
				}
				else
				{
					this.oParent.Overlay_21.F21_0000_0000(cityID);
				}

				// Instruction address 0x1d12:0x6194, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			L619c:
				city.StatusFlag |= 0x40;
				goto L6210;

			L61ac:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType >= 4) goto L61bc;
				goto L6210;

			L61bc:
				if (((city.ActualSize * 2) + (local_48 * this.oParent.Var_e3c6)) < this.oParent.Var_70da_Arr[0]) goto L61df;
				goto L6210;

			L61df:
				if (city.ActualSize >= 10) goto L61f1;
				goto L6204;

			L61f1:
				if (city.HasImprovement(ImprovementEnum.Aqueduct)) goto L6204;
				goto L6210;

			L6204:
				city.ActualSize++;

			L6210:
				goto L62d8;

			L6213:
				if (local_e8 < 0)
					goto L62d8;

				if ((city.StatusFlag & 0x40) != 0) goto L622f;
				goto L62d8;

			L622f:
				if ((this.oParent.CivState.PlayerFlags & (1 << this.Var_6548_PlayerID)) != 0) goto L6241;
				goto L62cb;

			L6241:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L6251;
				goto L62cb;

			L6251:
				// Instruction address 0x1d12:0x6255, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x23, 0);

				// Instruction address 0x1d12:0x6265, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "'We love the ");

				this.oCPU.BX.Word = (ushort)this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType;
				this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
				// Instruction address 0x1d12:0x6281, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

				// Instruction address 0x1d12:0x6291, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "'\ncelebration canceled\nin ");

				// Instruction address 0x1d12:0x629c, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x62ac, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				this.oParent.Overlay_21.F21_0000_0000(cityID);

				// Instruction address 0x1d12:0x62c3, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			L62cb:
				city.StatusFlag &= 0xbf;

			L62d8:
				local_e8 = (short)this.oParent.Var_70e6;

				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
					goto L635d;

				if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CurrentResearchID != -1) goto L62f5;
				goto L630d;

			L62f5:
				// Instruction address 0x1d12:0x62fd, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID,
					this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CurrentResearchID) == 0)
					goto L630d;

				goto L6327;

			L630d:
				if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CurrentResearchID == -1) goto L6317;
				goto L635d;

			L6317:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].ResearchProgress != 0) goto L6327;
				goto L635d;

			L6327:
				this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CurrentResearchID = -1;

				if ((this.oParent.CivState.DebugFlags & 0x8) != 0) goto L6337;
				goto L6351;

			L6337:
				// Instruction address 0x1d12:0x6337, size: 5
				this.oParent.Segment_11a8.F0_11a8_0280();

				// Instruction address 0x1d12:0x6344, size: 5
				this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x634c, size: 5
				this.oParent.Segment_11a8.F0_11a8_0294();

			L6351:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].ResearchProgress = 0;

			L635d:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType == 0)
				{
					local_e8 = 0;
				}

				this.oParent.CivState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)local_e8;

				if (this.Var_6548_PlayerID == this.oParent.CivState.HumanPlayerID && this.oParent.CivState.DifficultyLevel == 0)
				{
					if (this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CurrentResearchID >= 0 &&
						(this.oParent.CivState.TechnologyFirstDiscoveredBy[this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].CurrentResearchID] & 7) != 0)
					{
						this.oParent.CivState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)local_e8;
					}
				}

				// Instruction address 0x1d12:0x63c2, size: 5
				if (F0_1d12_6c97_PlayerHasWonder(this.Var_6548_PlayerID, (int)WonderEnum.SETIProgram) != 0) goto L63d2;
				goto L63e5;

			L63d2:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)(local_e8 / 2);

			L63e5:
				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
				{
					local_f4 = 14 - this.oParent.CivState.DifficultyLevel;
				}
				else
				{
					local_f4 = (this.oParent.CivState.DifficultyLevel * 2) + 6;
				}

				local_f4 += this.oParent.Var_d2de;

				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
					goto L6441;

				if ((11 - this.oParent.CivState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount) <= local_f4)
					goto L6441;

				local_f4 = 11 - this.oParent.CivState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;

			L6441:
				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
					goto L6457;

				if (this.oParent.Var_b1e8 == 0) goto L6457;
				goto L64b8;

			L6457:
				if ((this.oParent.CivState.Players[this.Var_6548_PlayerID].ResearchProgress / ((this.oParent.CivState.Year < 0) ? 1 : 2)) >
					(this.oParent.CivState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount * local_f4)) goto L6488;
				goto L64b8;

			L6488:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].ResearchProgress = 0;

				if ((this.oParent.CivState.DebugFlags & 0x8) != 0) goto L649e;
				goto L64b8;

			L649e:
				// Instruction address 0x1d12:0x649e, size: 5
				this.oParent.Segment_11a8.F0_11a8_0280();

				// Instruction address 0x1d12:0x64ab, size: 5
				this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x64b3, size: 5
				this.oParent.Segment_11a8.F0_11a8_0294();

			L64b8:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].Score +=
					(short)((city.ActualSize + this.oParent.Var_70e2) - this.oParent.Var_70e4);

				if (this.Var_6548_PlayerID != this.oParent.CivState.HumanPlayerID)
					goto L68cc;

				local_e0 = (this.oParent.Var_70da_Arr[1] / this.oParent.Var_6c98) - 20;
				local_e0 += (city.ActualSize * this.oParent.Var_b882) / 4;

				// Instruction address 0x1d12:0x6530, size: 5
				if ((local_e0 * 2) >
					this.oParent.MSCAPI.RNG.Next(-(((this.oParent.CivState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount * this.oParent.CivState.DifficultyLevel) / 2) - 256))) goto L6545;
				goto L6640;

			L6545:
				// Instruction address 0x1d12:0x6549, size: 5
				local_e8 = this.oParent.MSCAPI.RNG.Next(20);
				local_c6 = this.oParent.CityOffsets[local_e8].X + local_d8;
				local_d2 = this.oParent.CityOffsets[local_e8].Y + local_e4;

				// Instruction address 0x1d12:0x6581, size: 5
				if (!this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(local_c6, local_d2).HasFlag(TerrainImprovementFlagsEnum.Pollution)) goto L6590;
				goto L6640;

			L6590:
				// Instruction address 0x1d12:0x6598, size: 5
				if ((TerrainTypeEnum)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(local_c6, local_d2) != TerrainTypeEnum.Ocean) goto L65a8;
				goto L6640;

			L65a8:
				// Instruction address 0x1d12:0x65b0, size: 5
				if (!this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(local_c6, local_d2).HasFlag(TerrainImprovementFlagsEnum.City)) goto L65bf;
				goto L6640;

			L65bf:
				// Instruction address 0x1d12:0x65c7, size: 5
				F0_1d12_6d33(local_c6, local_d2);

				// Instruction address 0x1d12:0x65e3, size: 5
				this.oParent.MapManagement.F0_2aea_0008(this.oParent.CivState.HumanPlayerID, local_c6 - 8, local_d2 - 6);

				// Instruction address 0x1d12:0x65f3, size: 5
				this.oParent.MapManagement.F0_2aea_11d4(local_c6, local_d2);

				this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.ScienceAdvisor;

				// Instruction address 0x1d12:0x6609, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Pollution near ");

				// Instruction address 0x1d12:0x6614, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x6624, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				// Instruction address 0x1d12:0x6638, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 64);

			L6640:
				if ((city.StatusFlag & 0x1) != 0) goto L6652;
				goto L672d;

			L6652:
				if (city.HasImprovement(ImprovementEnum.NuclearPlant)) goto L6665;
				goto L672d;

			L6665:
				// Instruction address 0x1d12:0x6669, size: 5
				if (this.oParent.MSCAPI.RNG.Next(3) == 0) goto L6679;
				goto L672d;

			L6679:
				// Instruction address 0x1d12:0x6681, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.FusionPower) == 0)
					goto L6691;

				goto L672d;

			L6691:
				// Instruction address 0x1d12:0x66a5, size: 5
				this.oParent.MapManagement.F0_2aea_0008(this.oParent.CivState.HumanPlayerID, local_d8 - 8, local_e4 - 6);

				this.oParent.Overlay_22.F22_0000_0967(local_d8, local_e4);

				// Instruction address 0x1d12:0x66c5, size: 5
				this.oParent.Segment_29f3.F0_29f3_0ec3(local_d8, local_e4);

				city.RemoveImprovement(ImprovementEnum.NuclearPlant);

				// Instruction address 0x1d12:0x66e3, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

				// Instruction address 0x1d12:0x66f3, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Nuclear Catastrophe\nin ");

				// Instruction address 0x1d12:0x66fe, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x670e, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "!\nContamination feared!\n");

				this.oParent.Overlay_21.F21_0000_0000(cityID);

				// Instruction address 0x1d12:0x6725, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			L672d:
				local_bc = 1;
				goto L673a;

			L6736:
				local_bc++;

			L673a:
				if (local_bc >= 24)
					goto L68cc;

				if (city.HasImprovement(City.BitToImprovementEnum(local_bc))) goto L676e;
				goto L6736;

			L676e:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L677e;
				goto L6736;

			L677e:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins -= (short)this.oParent.CivState.ImprovementDefinitions(local_bc + 1).MaintenanceCost;

				if (local_bc != 1)
					goto L680b;

				if (this.oParent.CivState.DifficultyLevel < 2)
					goto L67b3;

				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins--;

			L67b3:
				if (this.oParent.CivState.DifficultyLevel < 4)
					goto L67c7;

				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins--;

			L67c7:
				// Instruction address 0x1d12:0x67cf, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Gunpowder) != 0)
					goto L67df;

				goto L67e9;

			L67df:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins--;

			L67e9:
				// Instruction address 0x1d12:0x67f1, size: 5
				if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Combustion) != 0)
					goto L6801;

				goto L680b;

			L6801:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins--;

			L680b:
				if (this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins < 0) goto L681b;
				goto L6736;

			L681b:
				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins = 0;
				
				city.RemoveImprovement(City.BitToImprovementEnum(local_bc));
				
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x1d12:0x6856, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x6866, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\ncan't maintain\n");

				// Instruction address 0x1d12:0x687d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.ImprovementDefinitions(local_bc + 1).Name);

				// Instruction address 0x1d12:0x688d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.DomesticAdvisor;

				// Instruction address 0x1d12:0x68a7, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

				this.oParent.CivState.Players[this.Var_6548_PlayerID].Coins += (short)(10 * this.oParent.CivState.ImprovementDefinitions(local_bc + 1).Price);

				goto L6736;

			L68cc:
				if ((city.StatusFlag & 0x4) != 0) goto L68de;
				goto L690f;

			L68de:
				// ??? this playerID reference needs to be checked!
				// Instruction address 0x1d12:0x68f4, size: 5
				if (this.oParent.Segment_1866.F0_1866_18d0(city.PlayerID, city.Position.X, city.Position.Y) == 0) goto L6904;
				goto L690f;

			L6904:
				// Instruction address 0x1d12:0x6907, size: 5
				this.oParent.Segment_1866.F0_1866_00c6(cityID);

			L690f:
				this.oParent.Var_aa_Rectangle.FontID = 1;

				// Instruction address 0x1d12:0x6918, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				// !!! Do we really need to return a value?
				this.oCPU.AX.Word = (ushort)((short)(this.oParent.Var_70e2 - this.oParent.Var_70e4));
			}

		L6927:
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_0045");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Finds Offset index for a give Point
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		private int F0_1d12_000a_FindCityOffset(GPoint point)
		{
			// function body
			for (int i = 0; i < 21; i++)
			{
				if (this.oParent.CityOffsets[i].Equals(point))
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Gets and draws (if flag=1) city resources
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="cityOffset"></param>
		/// <param name="flag"></param>
		private void F0_1d12_692d_CityResources(short cityID, int cityOffset, short flag)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_692d_CityResources({cityID}, {cityOffset}, {flag})");

			// function body
			int local_4;
			int local_6 = this.oParent.CivState.Cities[cityID].Position.X + this.oParent.CityOffsets[cityOffset].X;
			int local_8;
			int local_a = this.oParent.CivState.Cities[cityID].Position.Y + this.oParent.CityOffsets[cityOffset].Y;
			int local_c;
			int local_e = 0;
			int local_10 = 0;

			if (flag == 1)
			{
				// Instruction address 0x1d12:0x696f, size: 5
				this.oParent.MapManagement.F0_2aea_03ba(local_6, local_a);

				local_10 = 0;

				foreach (CityResourceTypeEnum cityResource in Enum.GetValues<CityResourceTypeEnum>())
				{
					// Instruction address 0x1d12:0x698b, size: 3
					local_10 += F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_6, local_a, cityResource);
				}

				if (local_10 <= 4)
				{
					local_e = 8;
				}
				else if (local_10 <= 6)
				{
					local_e = 5;
				}
				else
				{
					local_e = 3;
				}
			}
			else
			{
				this.Var_2494 = 1;

				// Instruction address 0x1d12:0x69dd, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, local_6 + 80, local_a, (ushort)this.oParent.CivState.Cities[cityID].PlayerID);
			}

			local_8 = 0;
			local_4 = 0;

			foreach (CityResourceTypeEnum cityResource in Enum.GetValues<CityResourceTypeEnum>())
			{
				// Instruction address 0x1d12:0x6a10, size: 3
				local_c = F0_1d12_6abc_GetCityResourceCount(this.Var_6548_PlayerID, this.Var_653e_CityID, local_6, local_a, cityResource);

				this.oParent.Var_70da_Arr[(int)cityResource] += local_c;

				while (flag == 1 && local_c > 0)
				{
					// Instruction address 0x1d12:0x6a5d, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
						161 + (this.oParent.CityOffsets[cityOffset].X * 16) + local_4,
						57 + (this.oParent.CityOffsets[cityOffset].Y * 16) + local_8,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(0xd4ce+ (((int)cityResource + 8) * 2))));

					if (local_4 < 8)
					{
						local_4 += local_e;
					}
					else
					{
						local_4 = 0;
						local_8 += 8;
					}

					local_c--;
				}
			}

			if (flag == 1 && local_10 == 0)
			{
				// Instruction address 0x1d12:0x6aa8, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					165 + (this.oParent.CityOffsets[cityOffset].X * 16),
					61 + (this.oParent.CityOffsets[cityOffset].Y * 16),
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));
			}

			this.Var_2494 = 0;

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_692d_CityResources");
		}

		/// <summary>
		/// Gets City resource count by resource type
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="resourceType"></param>
		/// <returns></returns>
		public int F0_1d12_6abc_GetCityResourceCount(int playerID, int cityID, int xPos, int yPos, CityResourceTypeEnum resourceType)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6abc_GetCityResourceCount({playerID}, {cityID}, {xPos}, {yPos}, {resourceType})");

			// function body
			// Instruction address 0x1d12:0x6ac9, size: 5
			if (this.oParent.MapManagement.F0_2aea_1326_CheckMapBounds(xPos, yPos) == 0)
			{
				this.oCPU.AX.Word = 0;

				// Far return
				this.oCPU.Log.ExitBlock("F0_1d12_6abc_GetCityResourceCount");

				return 0;
			}

			// Instruction address 0x1d12:0x6ade, size: 5
			int terrainType = (short)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(xPos, yPos);
			int index = terrainType;

			// Instruction address 0x1d12:0x6af0, size: 5
			if (this.oParent.MapManagement.F0_2aea_1836_CellHasSpecialResource(xPos, yPos) != 0)
			{
				// Access addon terrains
				index += 12;
			}

			int resourceCount = 0;

			switch (resourceType)
			{
				case CityResourceTypeEnum.Food:
					resourceCount = this.oParent.CivState.Terrains[index].Food;
					break;

				case CityResourceTypeEnum.Production:
					resourceCount = this.oParent.CivState.Terrains[index].Production;
					break;

				case CityResourceTypeEnum.Trade:
					resourceCount = this.oParent.CivState.Terrains[index].Trade;
					break;

				default:
					throw new Exception("Unknown terrain field");
			}

			// Instruction address 0x1d12:0x6b26, size: 5
			TerrainImprovementFlagsEnum improvements = this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(xPos, yPos);

			if ((this.oParent.CivState.DebugFlags & 0x2) == 0)
			{
				improvements = (terrainType == (int)TerrainTypeEnum.Desert
					|| terrainType == (int)TerrainTypeEnum.Plains
					|| terrainType == (int)TerrainTypeEnum.Grassland) ? TerrainImprovementFlagsEnum.Irrigation : TerrainImprovementFlagsEnum.Mines;

				improvements |= (terrainType != (int)TerrainTypeEnum.Plains) ? TerrainImprovementFlagsEnum.Road : TerrainImprovementFlagsEnum.None;
			}

			if (terrainType != (int)TerrainTypeEnum.Ocean)
			{
				if (resourceType == CityResourceTypeEnum.Food && improvements.HasFlag(TerrainImprovementFlagsEnum.Irrigation))
				{
					resourceCount += -1 - this.oParent.CivState.TerrainMultipliers[terrainType].Multi1;
				}

				if (resourceType == CityResourceTypeEnum.Production && improvements.HasFlag(TerrainImprovementFlagsEnum.Mines))
				{
					resourceCount += -1 - this.oParent.CivState.TerrainMultipliers[terrainType].Multi3;
				}

				if (resourceType == CityResourceTypeEnum.Trade
					&& improvements.HasFlag(TerrainImprovementFlagsEnum.Road)
					&& (terrainType == (int)TerrainTypeEnum.Desert
						|| terrainType == (int)TerrainTypeEnum.Plains
						|| terrainType == (int)TerrainTypeEnum.Grassland))
				{
					resourceCount++;
				}
			}

			if (resourceType == CityResourceTypeEnum.Production &&
				(terrainType == (int)TerrainTypeEnum.Grassland || terrainType == (int)TerrainTypeEnum.River) &&
				(((xPos * 7) + (yPos * 11)) & 0x2) != 0)
			{
				resourceCount = 0;
			}

			// Instruction address 0x1d12:0x6be7, size: 3
			if (resourceCount != 0 && resourceType == CityResourceTypeEnum.Trade && F0_1d12_6cf3_GetWonderCityID((int)WonderEnum.Colossus) == cityID)
			{
				resourceCount++;
			}

			if (improvements.HasFlag(TerrainImprovementFlagsEnum.RailRoad))
			{
				resourceCount += resourceCount / 2;
			}

			if (resourceCount > 2 && (this.oParent.CivState.Cities[cityID].StatusFlag & 0x40) == 0)
			{
				if (this.oParent.CivState.Players[playerID].GovernmentType <= 1)
				{
					resourceCount--;
				}

				if (this.Var_2494 != 0)
				{
					this.oParent.Var_e3c2 -= 2;
				}
			}

			if (resourceCount != 0 && resourceType == CityResourceTypeEnum.Trade)
			{
				if (this.Var_2494 != 0)
				{
					this.oParent.Var_db42++;
				}

				if ((this.oParent.CivState.Cities[cityID].StatusFlag & 0x40) != 0)
				{
					if (this.oParent.CivState.Players[playerID].GovernmentType >= 2)
					{
						resourceCount++;
					}
				}
				else
				{
					if (this.oParent.CivState.Players[playerID].GovernmentType >= 4)
					{
						resourceCount++;
					}
				}
			}

			if (improvements.HasFlag(TerrainImprovementFlagsEnum.Pollution))
			{
				resourceCount = (resourceCount + 1) / 2;
			}
				
			if (resourceCount < 0)
			{
				resourceCount = 0;
			}
			
			this.oCPU.AX.Word = (ushort)((short)resourceCount);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6abc_GetCityResourceCount");

			return resourceCount;
		}

		/// <summary>
		/// Tests if player has built a Wonder and if the Wonder is not obsolete
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="wonderID"></param>
		/// <returns></returns>
		public ushort F0_1d12_6c97_PlayerHasWonder(short playerID, short wonderID)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6c97_PlayerHasWonder({playerID}, {wonderID})");

			// function body
			int i;

			for (i = 1; i < 8; i++)
			{
				// Instruction address 0x1d12:0x6cb9, size: 5
				ImprovementDefinition wonder = this.oParent.CivState.WonderDefinitions[wonderID];

				if (wonder.ObsoletesAfterTechnology != TechnologyEnum.None &&
					this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology((short)i, (int)wonder.ObsoletesAfterTechnology) != 0)
				{
					break;
				}
			}

			if (i < 8 || this.oParent.CivState.WonderCityID[wonderID] == -1 ||
				this.oParent.CivState.Cities[this.oParent.CivState.WonderCityID[wonderID]].PlayerID != playerID)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 0x1;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6c97_PlayerHasWonder");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Returns a CityID that has a Wonder, and only if the Wonder is not obsolete
		/// </summary>
		/// <param name="wonderID"></param>
		/// <returns></returns>
		private short F0_1d12_6cf3_GetWonderCityID(short wonderID)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6cf3_GetWonderCityID({wonderID})");

			// function body
			int i;

			for (i = 1; i < 8; i++)
			{
				// Instruction address 0x1d12:0x6d15, size: 5
				if (this.oParent.CivState.WonderDefinitions[wonderID].ObsoletesAfterTechnology != TechnologyEnum.None &&
					this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology((short)i, (int)this.oParent.CivState.WonderDefinitions[wonderID].ObsoletesAfterTechnology) != 0)
				{
					break;
				}
			}

			if (i < 8)
			{
				this.oCPU.AX.Word = 0xffff;
			}
			else
			{
				this.oCPU.AX.Word = (ushort)this.oParent.CivState.WonderCityID[wonderID];
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6cf3_GetWonderCityID");

			return (short)this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_1d12_6d33(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6d33({xPos}, {yPos})");

			// function body
			// Instruction address 0x1d12:0x6d3c, size: 5
			if (!this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(xPos, yPos).HasFlag(TerrainImprovementFlagsEnum.Pollution))
			{
				// Instruction address 0x1d12:0x6d52, size: 5
				this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum.Pollution, xPos, yPos);

				// Instruction address 0x1d12:0x6d60, size: 5
				this.oParent.MapManagement.F0_2aea_1601(xPos, yPos);

				this.oParent.CivState.PollutedSquareCount++;
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6d33");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="position"></param>
		/// <param name="flag"></param>
		public void F0_1d12_6d6e_SetSpecialWorkerFlags(int position, int flag)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6d6e_SetSpecialWorkerFlags({position}, {flag})");

			// function body
			if (position < 8)
			{
				this.oParent.CivState.Cities[this.Var_653e_CityID].SpecialWorkerFlags &= (ushort)(~(0x3 << (position * 2)));

				this.oParent.CivState.Cities[this.Var_653e_CityID].SpecialWorkerFlags |= (ushort)((flag & 0x3) << (position * 2));
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6d6e_SetSpecialWorkerFlags");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="position"></param>
		/// <returns></returns>
		public ushort F0_1d12_6da1_GetSpecialWorkerFlags(int position)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6da1_GetSpecialWorkerFlags({position})");

			// function body
			if (position < 8)
			{
				this.oCPU.AX.Word = (ushort)((this.oParent.CivState.Cities[this.Var_653e_CityID].SpecialWorkerFlags >> (position * 2)) & 0x3);
			}
			else
			{
				this.oCPU.AX.Word = 0x1;
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6da1_GetSpecialWorkerFlags");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="workerType"></param>
		/// <returns></returns>
		private int F0_1d12_6dcc_GetWorkerCountByType(ushort workerType)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6dcc_GetWorkerCountByType({workerType})");

			// function body
			int workerCount = 0;

			for (int i = 0; i < 8; i++)
			{
				// Instruction address 0x1d12:0x6de0, size: 3
				if (F0_1d12_6da1_GetSpecialWorkerFlags(i) == workerType)
				{
					workerCount++;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6dcc_GetWorkerCountByType");

			return workerCount;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="param2"></param>
		private void F0_1d12_6dfe(short cityID, int size)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6dfe({cityID}, {size})");

			// function body
			while (this.Var_6542 >= 0 && this.oParent.Var_70e4 < this.Var_6542)
			{
				this.Var_6542--;
				this.oParent.Var_70e4++;
			}

			// Instruction address 0x1d12:0x6e16, size: 5
			this.oParent.Var_70e2 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e2, 0, this.oParent.CivState.Cities[cityID].ActualSize);
			// Instruction address 0x1d12:0x6e98, size: 5
			this.oParent.Var_70e4 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e4, 0, this.oParent.CivState.Cities[cityID].ActualSize);

			// Instruction address 0x1d12:0x6ebb, size: 5
			while ((this.oParent.Var_70e2 + this.oParent.Var_70e4) > this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.CivState.Cities[cityID].ActualSize - size, 0, 99))
			{
				if (this.Var_6542 > 0)
				{
					this.Var_6542--;
				}
				else
				{
					this.oParent.Var_70e2--;

					// Instruction address 0x1d12:0x6e74, size: 5
					this.oParent.Var_70e2 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e2, 0, this.oParent.CivState.Cities[cityID].ActualSize);
				}

				this.oParent.Var_70e4--;

				// Instruction address 0x1d12:0x6e98, size: 5
				this.oParent.Var_70e4 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e4, 0, this.oParent.CivState.Cities[cityID].ActualSize);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6dfe");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param4"></param>
		/// <param name="width"></param>
		/// <returns></returns>
		public int F0_1d12_6ed4_DrawResources(int cityID, int xPos, int yPos, int param4, int width)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6ed4_DrawResources({cityID}, {xPos}, {yPos}, {param4}, {width})");

			// function body
			int citySize = this.oParent.CivState.Cities[cityID].ActualSize;
			int i;
			int xSpacing;
			
			if (citySize * 7 > width)
			{
				xSpacing = width / citySize;
			}
			else
			{
				xSpacing = 7;
			}

			for (i = 0; i < this.oParent.Var_70e2; i++)
			{
				// Instruction address 0x1d12:0x6f26, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					xPos, yPos,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(((i & 1) << 1) + 0x6e96)));

				xPos += xSpacing;
			}

			for (i = 0; i < this.oParent.CivState.Cities[cityID].ActualSize - param4 - this.oParent.Var_70e2 - this.oParent.Var_70e4; i++)
			{
				// Instruction address 0x1d12:0x6f66, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					xPos, yPos,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(((i & 1) << 1) + 0x6e9a)));

				xPos += xSpacing;
			}

			if (i != 0)
			{
				xPos += 2;
			}

			for (i = 0; i < this.oParent.Var_70e4; i++)
			{
				// Instruction address 0x1d12:0x6fbb, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					xPos, yPos,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(((i & 1) << 1) + 0x6e9e)));

				if (i < this.Var_6542)
				{
					// Instruction address 0x1d12:0x6fe5, size: 5
					this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 12, 14, 5, 12);
				}

				xPos += xSpacing;
			}

			xPos += 4;

			for (i = 0; i < param4; i++)
			{
				// Instruction address 0x1d12:0x700d, size: 3
				F0_1d12_6da1_GetSpecialWorkerFlags(i);

				// Instruction address 0x1d12:0x7025, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					xPos, yPos,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.AX.Word << 1) + 0x6ea0)));

				xPos += xSpacing;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6ed4_DrawResources");

			return xSpacing;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPosSrc"></param>
		/// <param name="xPosDst"></param>
		/// <param name="yPosDst"></param>
		public void F0_1d12_7045(short xPosSrc, short xPosDst, short yPosDst)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_7045({xPosSrc}, {xPosDst}, {yPosDst})");

			// function body
			if (xPosSrc < 22 || xPosSrc > 24)
			{
				xPosSrc--;

				if (xPosSrc >= 24)
				{
					xPosSrc -= 3;
				}

				if (xPosSrc >= 40)
				{
					// Instruction address 0x1d12:0x70c1, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, ((xPosSrc & 1) * 19) + 161, 100, 18, 10,
						this.oParent.Var_aa_Rectangle, xPosDst, yPosDst);
				}
				else
				{
					// Instruction address 0x1d12:0x70c1, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, ((xPosSrc / 5) * 19) + 161, ((xPosSrc % 5) * 10) + 50, 18, 10,
						this.oParent.Var_aa_Rectangle, xPosDst, yPosDst);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_7045");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <param name="xPos2"></param>
		/// <param name="yPos2"></param>
		private void F0_1d12_70cb_FillRectangleWithPattern(int xPos1, int yPos1, int xPos2, int yPos2)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_70cb_FillRectangleWithPattern({xPos1}, {yPos1}, {xPos2}, {yPos2})");

			// function body			
			int iWidth = xPos2 - xPos1;
			int iHeight = yPos2 - yPos1;

			// Instruction address 0x1d12:0x70ee, size: 3
			F0_1d12_710d_FillRectangleWithPattern(xPos1, yPos1, iWidth, iHeight);

			// Instruction address 0x1d12:0x7104, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(xPos1, yPos1, iWidth, iHeight, 1);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_70cb_FillRectangleWithPattern");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		private void F0_1d12_710d_FillRectangleWithPattern(int xPos, int yPos, int width, int height)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_710d_FillRectangleWithPattern({xPos}, {yPos}, {width}, {height})");

			// function body
			if (this.oParent.Var_d762 == 0)
			{
				// Instruction address 0x1d12:0x712e, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos, yPos, width, height, 9);
			}
			else
			{
				int iRectYPos = yPos;
				int iRectHeight = height;

				while (iRectHeight > 0)
				{
					int iCellHeight = Math.Min(iRectHeight, 16);
					int iRectXPos = xPos;
					int iRectWidth = width;

					while (iRectWidth > 0)
					{
						int iCellWidth = Math.Min(iRectWidth, 16);

						// Instruction address 0x1d12:0x7195, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
							208, 100, iCellWidth, iCellHeight, this.oParent.Var_aa_Rectangle, iRectXPos, iRectYPos);

						iRectXPos += iCellWidth;
						iRectWidth -= iCellWidth;
					}

					iRectYPos += iCellHeight;
					iRectHeight -= iCellHeight;
				}
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_710d_FillRectangleWithPattern");
		}

		/// <summary>
		/// Draws rectangle filled with solid color and centered text message
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <param name="stringPtr"></param>
		/// <param name="mode"></param>
		public void F0_1d12_71bf_DrawFilledRectangleWithCenteredText(int xPos, int yPos, int xPos1, int yPos1, ushort stringPtr, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_71bf({xPos}, {yPos}, {xPos1}, {yPos1}, 0x{stringPtr:x4}, {mode})");

			// function body
			// Instruction address 0x1d12:0x71e8, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				xPos, yPos, xPos1 - xPos, yPos1 - yPos, mode);
		
			// Instruction address 0x1d12:0x720e, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos, yPos, xPos1, yPos, (ushort)((mode < 8) ? (mode + 8) : 7));
		
			// Instruction address 0x1d12:0x7234, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos, yPos, xPos, yPos1, (ushort)((mode < 8) ? (mode + 8) : 7));
		
			// Instruction address 0x1d12:0x725c, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos + 1, yPos1, xPos1, yPos1, (ushort)((mode < 8) ? 8 : (mode - 8)));

			// Instruction address 0x1d12:0x7282, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
				xPos1, yPos, xPos1, yPos1, (ushort)((mode < 0x8) ? 8 : (mode - 8)));

			// Instruction address 0x1d12:0x72ae, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(stringPtr,
				((xPos + xPos1) / 2) + 1, ((yPos + yPos1) / 2) - 2, (byte)(mode ^ 8));

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_71bf");
		}

		/// <summary>
		/// ?
		/// </summary>
		private void F0_1d12_72b7_DrawCityWorldMap()
		{
			this.oCPU.Log.EnterBlock("F0_1d12_72b7()");

			// function body
			// Instruction address 0x1d12:0x72d4, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 101, 117, 120, 75, 0);

			for (int yPos = 0; yPos < 50; yPos++)
			{
				for (int xPos = 0; xPos < 80; xPos++)
				{
					// Instruction address 0x1d12:0x731c, size: 5
					int mapXPos = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].XStart + xPos - 40);
					int mapYPos = yPos;

					if ((this.oParent.CivState.MapVisibility[mapXPos, mapYPos] & (1 << this.oParent.CivState.HumanPlayerID)) != 0)
					{
						int local_10 = ((yPos & 1) * 2) + (xPos & 1);

						int rectXPos = ((xPos / 2) * 3) + this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(local_10 + 0x280c)) + 101;
						int rectYPos = ((yPos / 2) * 3) + this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(local_10 + 0x2810)) + 118;

						// Instruction address 0x1d12:0x73a3, size: 5
						if ((TerrainTypeEnum)this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(mapXPos, mapYPos) != TerrainTypeEnum.Ocean)
						{
							// Instruction address 0x1d12:0x72f7, size: 5
							this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, rectXPos, rectYPos, 2, 2, 2);
						}
						else
						{
							// Instruction address 0x1d12:0x72f7, size: 5
							this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, rectXPos, rectYPos, 2, 2, 1);
						}
					}
				}
			}

			// Instruction address 0x1d12:0x73e1, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(100, 117, 121, 75, 9);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_72b7");
		}

		/// <summary>
		/// Draws a rectangle that represents a city (2x2 pixels)
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mode"></param>
		private void F0_1d12_73ea_DrawCityRectangle(int xPos, int yPos, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_73ea({xPos}, {yPos}, {mode})");

			// function body
			if (this.Var_2496 == 2)
			{
				// Instruction address 0x1d12:0x7405, size: 5
				xPos = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
					xPos - this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].XStart + 40);

				// Instruction address 0x1d12:0x7444, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
					((xPos * 3) / 2) + 101, ((yPos * 3) / 2) + 118, 2, 2, mode);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_73ea");
		}
	}
}
