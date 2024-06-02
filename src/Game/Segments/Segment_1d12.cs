using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class Segment_1d12
	{
		private Game oParent;
		private CPU oCPU;

		// Local variables used exclusively inside this section

		private ushort Var_2494 = 0;
		private ushort Var_2496 = 0;

		// 0x652e - after this offset the default values are set to 0

		private short Var_653e_CityID = 0;
		private int Var_6540_CityOffsetCount = 21;
		private ushort Var_6542 = 0;
		private ushort Var_6546 = 0;
		private short Var_6548_PlayerID = 0;
		private ushort Var_6b30 = 0;
		private ushort Var_70e8 = 0;
		//private ushort Var_deb6 = 0;

		public Segment_1d12(Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_1d12_000a_FindCityOffset(GPoint point)
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
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="flag"></param>
		public void F0_1d12_0045(short cityID, short flag)
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
			int local_10c;

			City city = this.oParent.GameState.Cities[cityID];

			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

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

				if ((city.BuildingFlags0 & 0x1) != 0)
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
					if (this.oParent.GameState.Cities[i].StatusFlag != 0xff && i != city.ID)
					{
						// Instruction address 0x1d12:0x01a2, size: 5
						this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
							city.Position.X,
							city.Position.Y,
							this.oParent.GameState.Cities[i].Position.X,
							this.oParent.GameState.Cities[i].Position.Y);

						local_b0 = (short)this.oCPU.AX.Word;

						if (this.oParent.GameState.Cities[i].PlayerID == city.PlayerID &&
							(this.oParent.GameState.Cities[i].BuildingFlags0 & 0x1) != 0 && local_b0 < (short)this.Var_6b30)
						{
							this.Var_6b30 = (ushort)((short)local_b0);
						}

						if (local_b0 <= 5)
						{
							for (int j = 0; j < 21; j++)
							{
								if ((this.oParent.GameState.Cities[i].WorkerFlags & (uint)(1 << j)) != 0 || j == 20)
								{
									int xPos = this.oParent.GameState.Cities[i].Position.X + this.oParent.CityOffsets[j].X;
									int yPos = this.oParent.GameState.Cities[i].Position.Y + this.oParent.CityOffsets[j].Y;

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

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType <= 1)
				{
					local_48 = 1;
				}
				else
				{
					local_48 = 2;
				}

				this.oParent.Var_b882 = 0;

				if ((city.BuildingFlags0 & 0x1000) == 0)
				{
					// Instruction address 0x1d12:0x035e, size: 5
					this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Industrialization);
					this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
					if (this.oCPU.Flags.NE)
					{
						this.oParent.Var_b882++;
					}

					// Instruction address 0x1d12:0x037a, size: 5
					this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Automobile);
					this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
					if (this.oCPU.Flags.NE)
					{
						this.oParent.Var_b882++;
					}

					// Instruction address 0x1d12:0x0396, size: 5
					this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.MassProduction);
					this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
					if (this.oCPU.Flags.NE)
					{
						this.oParent.Var_b882++;
					}

					// Instruction address 0x1d12:0x03b2, size: 5
					this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Plastics);
					this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
					if (this.oCPU.Flags.NE)
					{
						this.oParent.Var_b882++;
					}
				}
			
				local_4a = 10;

				this.oParent.Var_e8b8 = (ushort)(city.WorkerFlags >>> 26);

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
				{
					local_4a = -(this.oParent.GameState.DifficultyLevel * 2 - 16);

					if (this.oParent.GameState.Year >= 0 &&
						this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Ranking == 7 &&
						this.oParent.GameState.DifficultyLevel > 1)
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

				if (flag != 1)
					goto L0701;

				// Instruction address 0x1d12:0x049a, size: 5
				this.oParent.Segment_1866.F0_1866_0006(cityID);

				// Instruction address 0x1d12:0x04ba, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

				// Instruction address 0x1d12:0x04d2, size: 5
				F0_1d12_70cb_FillRectangleWithPattern(2, 1, 208, 21);

				local_e8 = 0;
				local_ea = 1;

				goto L04ed;

			L04e9:
				local_ea++;

			L04ed:
				if (city.ActualSize < local_ea)
					goto L050e;

				local_e8 += local_ea;

				goto L04e9;

			L050e:
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
				this.oParent.Segment_2aea.F0_2aea_03ba(city.Position.X, city.Position.Y);

				for (int i = 0; i < this.Var_6540_CityOffsetCount; i++)
				{
					local_c6 = city.Position.X + this.oParent.CityOffsets[i].X;
					local_d2 = city.Position.Y + this.oParent.CityOffsets[i].Y;

					if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID ||
						(this.oParent.GameState.MapVisibility[local_c6, local_d2] & (1 << this.Var_6548_PlayerID)) != 0)
					{
						// Instruction address 0x1d12:0x0664, size: 5
						this.oParent.Segment_2aea.F0_2aea_14e0(local_c6, local_d2);
						local_e8 = (short)this.oCPU.AX.Word;

						if (local_e8 != -1 && local_e8 != this.Var_6548_PlayerID)
						{
							// Instruction address 0x1d12:0x068e, size: 5
							this.oParent.Segment_2aea.F0_2aea_11d4(local_c6, local_d2);
						}
						else
						{
							// Instruction address 0x1d12:0x06a1, size: 5
							this.oParent.Segment_2aea.F0_2aea_03ba(local_c6, local_d2);

							if (Arr_a6[this.oParent.CityOffsets[i].X + 2, this.oParent.CityOffsets[i].Y + 2] != 0)
							{
								// Instruction address 0x1d12:0x06f6, size: 5
								this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
									(local_c6 - this.oParent.Var_d4cc_XPos) * 16 + 80, (local_d2 - this.oParent.Var_d75e_YPos) * 16 + 8, 15, 15, 12);
							}
						}
					}
				}

			L0701:
				if (flag != 0)
					goto L0965;

				city.StatusFlag &= 0x7f;

				if (city.FoodCount >= 0)
					goto L0881;

				local_e8 = -1;
				local_ea = 0;

				goto L073e;

			L073a:
				local_ea++;

			L073e:
				if (local_ea >= 128)
					goto L0792;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID != 0 ||
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].HomeCityID != cityID)
					goto L073a;

				local_e8 = local_ea;

			L0792:
				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
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

				if (local_e8 == -1)
					goto L0819;

				// Instruction address 0x1d12:0x080e, size: 5
				this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID, (short)local_e8);

				goto L0863;

			L0819:
				city.ActualSize--;
				if (city.ActualSize > 0)
					goto L0863;

				// Instruction address 0x1d12:0x0843, size: 5
				this.oParent.Segment_1ade.F0_1ade_018e(cityID, city.Position.X, city.Position.Y);

				this.oParent.StartGameMenu.F5_0000_0e6c(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x085b, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				goto L6927;

			L0863:
				city.FoodCount = 0;

				// Instruction address 0x1d12:0x0879, size: 5
				this.oParent.Segment_1403.F0_1403_3ed7(local_d8, local_e4);

			L0881:				
				if ((city.ActualSize + 1) * local_4a > city.FoodCount)
					goto L0965;

				city.ActualSize++;

				if ((city.BuildingFlags0 & 0x4) != 0)
				{
					city.FoodCount = (short)((5 * city.ActualSize) + 5);
				}
				else
				{
					city.FoodCount = 0;
				}

				if (city.ActualSize > 10 && (city.BuildingFlags0 & 0x100) == 0 && (this.oParent.GameState.DebugFlags & 0x4) != 0)
				{
					city.ActualSize--;

					if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
					{
						this.oParent.Var_2f9e_Unknown = 0x4;

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

			L0965:
				local_50 = city.ActualSize + 1;

				this.Var_6546 = 0;
				this.oParent.Var_deb8 = 0;
				this.oParent.Var_d2f6 = 0;
				this.oParent.Var_e3c6 = 0;
				local_ea = 0;

				goto L0992;

			L098e:
				local_ea++;

			L0992:
				if (local_ea >= 2)
					goto L09b9;

				if (city.Unknown[local_ea] == -1)
					goto L098e;

				this.oParent.Var_deb8++;

				goto L098e;

			L09b9:
				if (city.ActualSize < (short)this.oParent.Var_deb8)
				{
					this.oParent.Var_d2f6 = (ushort)((short)((short)this.oParent.Var_deb8 - city.ActualSize));
				}
			
				local_ea = 0;

				goto L09f3;

			L09ef:
				local_ea++;

			L09f3:
				if (local_ea >= 128)
					goto L0b4e;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID == -1)
					goto L09ef;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].HomeCityID != cityID)
					goto L09ef;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID >= 26)
					goto L0b2b;

				this.oParent.Var_deb8++;

				if (city.ActualSize >= (short)this.oParent.Var_deb8)
					goto L0a6f;

				this.oParent.Var_d2f6++;

				goto L0a8d;

			L0a6f:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType > 1 && (this.oParent.GameState.DebugFlags & 2) != 0)
				{
					this.oParent.Var_d2f6++;
				}

			L0a8d:
				if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID].AttackStrength == 0)
					goto L0b2b;

				if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID].TerrainCategory == 1)
					goto L0b27;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.X == city.Position.X)
					goto L0afe;

				goto L0b27;

			L0afe:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.Y == city.Position.Y)
					goto L0b2b;

			L0b27:
				this.Var_6546++;

			L0b2b:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID == 0)
				{
					this.oParent.Var_e3c6++;
				}

				goto L09ef;

			L0b4e:
				this.Var_70e8 = 0x0;
				local_ea = 0;

				goto L0b61;

			L0b5d:
				local_ea++;

			L0b61:
				if (local_ea >= this.Var_6540_CityOffsetCount)
					goto L0cae;

				Arr_3e[local_ea] = 0;

				local_c6 = city.Position.X + this.oParent.CityOffsets[local_ea].X;
				local_d2 = city.Position.Y + this.oParent.CityOffsets[local_ea].Y;

				if (this.Var_6548_PlayerID != 0 && (this.oParent.GameState.MapVisibility[local_c6, local_d2] & (1 << this.Var_6548_PlayerID)) == 0)
				{
					Arr_3e[local_ea] = 1;
				}
			
				// Instruction address 0x1d12:0x0bf4, size: 5
				this.oParent.Segment_2aea.F0_2aea_14e0(local_c6, local_d2);
				local_e8 = (short)this.oCPU.AX.Word;

				if (local_e8 != -1 && local_e8 != this.Var_6548_PlayerID)
				{
					Arr_a6[this.oParent.CityOffsets[local_ea].X + 2, this.oParent.CityOffsets[local_ea].Y + 2] = 1;

					Arr_3e[local_ea] = 1;

					if (local_e8 == this.oParent.GameState.HumanPlayerID)
					{
						this.Var_70e8 = 0x1;
					}
				}

				if (Arr_a6[this.oParent.CityOffsets[local_ea].X + 2, this.oParent.CityOffsets[local_ea].Y + 2] != 0)
				{
					Arr_3e[local_ea] = 1;
				}

				if (Arr_3e[local_ea] == 0)
					goto L0cab;

				city.WorkerFlags &= (uint)(~(1 << local_ea));

			L0cab:
				goto L0b5d;

			L0cae:
				local_ea = 0;

				goto L0cbb;

			L0cb7:
				local_ea++;

			L0cbb:
				if (local_ea >= 4)
					goto L0cd4;

				this.oParent.Var_70da_Arr[local_ea] = 0;

				goto L0cb7;

			L0cd4:
				local_ee_UInt = 0;

				if (((ushort)this.oParent.GameState.PlayerFlags & (1 << this.Var_6548_PlayerID)) != 0)
					goto L0d1b;

				if (((cityID + this.oParent.GameState.TurnCount) & 0x3) != 0)
					goto L0d1b;

				if ((city.StatusFlag & 0x1) != 0)
					goto L0d1b;

				if (this.Var_70e8 == 0)
					goto L0e91;

			L0d1b:
				local_ea = 0;

				goto L0d28;

			L0d24:
				local_ea++;

			L0d28:
				if (local_ea >= this.Var_6540_CityOffsetCount)
					goto L0d64;

				if ((city.WorkerFlags & (1 << local_ea)) == 0)
					goto L0d61;

				local_50--;

			L0d61:
				goto L0d24;

			L0d64:
				if (local_50 < 0)
					goto L0e07;

				local_50 = city.ActualSize + 1;
				local_ea = 0;

				goto L0d8b;

			L0d87:
				local_ea++;

			L0d8b:
				if (local_ea >= this.Var_6540_CityOffsetCount)
					goto L0e7a;

				if (local_50 == 0)
					goto L0d87;

				if ((city.WorkerFlags & (1 << local_ea)) == 0)
					goto L0d87;

				Arr_3e[local_ea] = 1;

				// Instruction address 0x1d12:0x0ddf, size: 5
				F0_1d12_692d(cityID, local_ea, flag);

				local_50--;

				local_ee_UInt |= (uint)(1 << local_ea);

				goto L0d87;

			L0e07:
				if (flag == 0 && this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
				{
					// Instruction address 0x1d12:0x0e26, size: 5
					this.oParent.MSCAPI.strcpy(0xba06, "Population decrease\nin ");

					// Instruction address 0x1d12:0x0e31, size: 5
					this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

					// Instruction address 0x1d12:0x0e41, size: 5
					this.oParent.MSCAPI.strcat(0xba06, ".\n");

					this.oParent.Var_2f9e_Unknown = 0x4;

					// Instruction address 0x1d12:0x0e5b, size: 5
					this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

					this.oParent.Var_b1e8 = 0x1;
				}
			
				local_50 = city.ActualSize + 1;

			L0e7a:
				if (local_50 == (short)this.oParent.Var_e8b8)
					goto L1292;

				if (local_50 == 0)
					goto L1292;

			L0e91:
				if (local_50 > 0 && Arr_3e[20] == 0)
				{
					Arr_3e[20] = 1;

					// Instruction address 0x1d12:0x0eb2, size: 5
					F0_1d12_692d(cityID, 20, flag);

					local_ee_UInt |= 0x100000;
					local_50--;
				}

			L0ec9:
				if (((city.ActualSize * 2) + (local_48 * (short)this.oParent.Var_e3c6)) > ((local_50 / 2) + this.oParent.Var_70da_Arr[0]))
					goto L0f0c;

				if (city.ActualSize >= 3)
					goto L1088;

			L0f0c:
				if (local_50 <= (short)this.oParent.Var_e8b8 || local_108 == -1)
					goto L1088;

				local_108 = -1;
				local_d6 = 0;
				local_ce = 0;
				local_ea = 0;

				goto L0f3f;

			L0f3b:
				local_ea++;

			L0f3f:
				if (local_ea >= this.Var_6540_CityOffsetCount)
					goto L103e;

				if (Arr_3e[local_ea] != 0)
					goto L0f3b;

				local_c6 = city.Position.X + this.oParent.CityOffsets[local_ea].X;
				local_d2 = city.Position.Y + this.oParent.CityOffsets[local_ea].Y;

				// Instruction address 0x1d12:0x0f9e, size: 5
				F0_1d12_6abc(local_c6, local_d2, 0);
				local_cc = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x0fb6, size: 5
				F0_1d12_6abc(local_c6, local_d2, 1);
				local_d4 = (short)this.oCPU.AX.Word * 2;

				if (local_50 != 1)
					goto L0fe4;

				if (this.oParent.Var_70da_Arr[1] != 0)
					goto L0fe4;

				if (local_d4 == 0)
					goto L0f3b;

			L0fe4:
				// Instruction address 0x1d12:0x0ff0, size: 5
				F0_1d12_6abc(local_c6, local_d2, 2);
				local_d4 += (short)this.oCPU.AX.Word;

				if (local_cc > local_ce)
					goto L1023;

				if (local_cc != local_ce)
					goto L0f3b;

				if (local_d4 <= local_d6)
					goto L0f3b;

			L1023:
				local_ce = local_cc;
				local_d6 = local_d4;
				local_108 = local_ea;

				goto L0f3b;

			L103e:
				if (local_108 == -1)
					goto L1088;

				Arr_3e[local_108] = 1;

				// Instruction address 0x1d12:0x105d, size: 5
				F0_1d12_692d(cityID, local_108, flag);

				local_ee_UInt |= (uint)(1 << local_108);

				local_50--;

				goto L0ec9;

			L1088:
				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID && (city.StatusFlag & 0x1) != 0)
				{
					this.oParent.Var_e8b8++;
				}

			L10aa:
				if (local_50 <= (short)this.oParent.Var_e8b8)
					goto L1292;

				local_108 = -1;
				local_e2 = 0;
				local_d6 = 0;
				local_ce = 0;
				local_ea = 0;

				goto L10d7;

			L10d3:
				local_ea++;

			L10d7:
				if (local_ea >= this.Var_6540_CityOffsetCount)
					goto L1248;

				if (Arr_3e[local_ea] != 0)
					goto L10d3;

				local_c6 = city.Position.X + this.oParent.CityOffsets[local_ea].X;
				local_d2 = city.Position.Y + this.oParent.CityOffsets[local_ea].Y;

				// Instruction address 0x1d12:0x1173, size: 5
				F0_1d12_6abc(local_c6, local_d2, 0);
				local_4 = (short)this.oCPU.AX.Word;
				
				// Instruction address 0x1d12:0x1151, size: 5
				local_d4 = local_4 * (16 / this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					this.oParent.Var_70da_Arr[0] - (city.ActualSize * 2) - (local_48 * (short)this.oParent.Var_e3c6), 1, 99));

				// Instruction address 0x1d12:0x1190, size: 5
				F0_1d12_6abc(local_c6, local_d2, 1);
				local_c = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x11af, size: 5
				local_d4 += ((city.ActualSize * 3) / this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					this.oParent.Var_70da_Arr[1] - (short)this.oParent.Var_d2f6, 1, 99)) * local_c;

				// Instruction address 0x1d12:0x11dc, size: 5
				F0_1d12_6abc(local_c6, local_d2, 2);
				local_46 = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x11f7, size: 5
				local_d4 += ((city.ActualSize * 2) / this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70da_Arr[2], 1, 99)) * local_46;
				
				if (local_d4 <= local_d6)
					goto L10d3;

				local_d6 = local_d4;
				local_108 = local_ea;

				local_e2 = ((local_4 + local_c) * 2) + local_46;

				goto L10d3;

			L1248:
				if (local_108 == -1)
					goto L1292;

				Arr_3e[local_108] = 1;

				// Instruction address 0x1d12:0x1267, size: 5
				F0_1d12_692d(cityID, local_108, flag);

				local_ee_UInt |= (uint)(1 << local_108);

				local_50--;

				goto L10aa;

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

				this.oCPU.TESTWord(city.BuildingFlags0, 0x4000);
				if (this.oCPU.Flags.NE) goto L137b;
				goto L1381;

			L137b:
				local_f8 = 2;

			L1381:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x8000);
				if (this.oCPU.Flags.NE) goto L1394;
				goto L139a;

			L1394:
				local_f8 = 4;

			L139a:
				this.oCPU.TESTWord(city.BuildingFlags1, 0x4);
				if (this.oCPU.Flags.NE) goto L13ad;
				goto L13b3;

			L13ad:
				local_ac = 2;

			L13b3:
				this.oCPU.TESTWord(city.BuildingFlags1, 0x8);
				if (this.oCPU.Flags.NE) goto L13c6;
				goto L13d2;

			L13c6:
				this.oParent.Var_6c98 = 2;
				local_ac = 2;

			L13d2:
				this.oCPU.TESTWord(city.BuildingFlags1, 0x10);
				if (this.oCPU.Flags.NE) goto L13e5;
				goto L13f1;

			L13e5:
				this.oParent.Var_6c98 = 2;
				local_ac = 2;

			L13f1:
				// Instruction address 0x1d12:0x13f9, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 15);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L1409;
				goto L145f;

			L1409:
				// Instruction address 0x1d12:0x1428, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(
					this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[15]].Position.X,
					this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[15]].Position.Y);

				local_10c = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x1442, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(city.Position.X, city.Position.Y);

				if ((short)this.oCPU.AX.Word != local_10c)
					goto L145f;

				this.oParent.Var_6c98 = 2;
				local_ac = 2;

			L145f:
				this.oCPU.TESTWord(city.BuildingFlags1, 0x2);
				if (this.oCPU.Flags.NE) goto L1472;
				goto L1478;

			L1472:
				this.oParent.Var_6c98 = 3;

			L1478:
				// Instruction address 0x1d12:0x1484, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_ac, 0, local_f8);

				local_ac = (short)this.oCPU.AX.Word;

				local_10a = this.oParent.Var_70da_Arr[1];

				local_a = this.oParent.Var_70da_Arr[2];

				this.oCPU.AX.Word = (ushort)((short)local_ac);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)((short)this.oParent.Var_70da_Arr[1]));
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x2;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_f8);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)((short)this.oParent.Var_70da_Arr[1]));
				this.oCPU.BX.Word = this.oCPU.CX.Word;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x2;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.BX.Word);

				this.oParent.Var_70da_Arr[1] += (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L14de;
				goto L2673;

			L14de:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)local_48);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
				this.oCPU.DX.Word = (ushort)((short)this.oParent.Var_70da_Arr[0]);
				this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
				this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.CX.Word);
				city.FoodCount += (short)this.oCPU.DX.Word;

				local_e8 = this.oParent.Var_70da_Arr[1];
				local_e8 -= (short)this.oParent.Var_d2f6;

				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.NE) goto L1522;
				goto L1528;

			L1522:
				local_e8 = 0;

			L1528:
				city.ShieldsCount += (short)local_e8;

				if (city.CurrentProductionID < 0)
					goto L1b63;

				if ((this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) > city.ShieldsCount)
					goto L220f;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.E) goto L157c;
				goto L159b;

			L157c:
				this.oCPU.CMPByte((byte)city.ActualSize, 0x1);
				if (this.oCPU.Flags.E) goto L158e;
				goto L159b;

			L158e:
				if (this.oParent.GameState.DifficultyLevel == 0)
					goto L2307;

			L159b:
				city.ShieldsCount -= (short)(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a);

				local_ba = -1;

				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
					goto L15da;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1a);
				if (this.oCPU.Flags.NE) goto L15da;
				goto L1606;

			L15da:
				// Instruction address 0x1d12:0x15fa, size: 5
				this.oParent.Segment_1866.F0_1866_0cf5(this.Var_6548_PlayerID, city.CurrentProductionID, city.Position.X, city.Position.Y);
				local_ba = (short)this.oCPU.AX.Word;

			L1606:
				this.oCPU.TESTByte((byte)this.oParent.GameState.TechnologyFirstDiscoveredBy[city.CurrentProductionID], 0x8);
				if (this.oCPU.Flags.E) goto L1626;
				goto L1664;

			L1626:
				// Instruction address 0x1d12:0x1640, size: 5
				this.oParent.Segment_1866.F0_1866_250e_AddReplayData(6, (byte)((sbyte)this.Var_6548_PlayerID), (byte)city.CurrentProductionID);

				this.oParent.GameState.TechnologyFirstDiscoveredBy[city.CurrentProductionID] |= 8;

			L1664:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x2);
				if (this.oCPU.Flags.NE) goto L1676;
				goto L1697;

			L1676:
				if (local_ba == -1)
					goto L1697;

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ba].Status |= 0x20;

			L1697:
				if (local_ba == -1)
					goto L174b;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.E) goto L16b3;
				goto L174b;

			L16b3:
				this.oCPU.CMPByte((byte)city.ActualSize, 0x1);
				if (this.oCPU.Flags.LE) goto L16c5;
				goto L16d5;

			L16c5:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].CityCount > 1) goto L16d5;

				goto L174b;

			L16d5:
				city.ActualSize--;
				if (city.ActualSize == 0) goto L16e6;
				goto L174b;

			L16e6:
				// Instruction address 0x1d12:0x16ff, size: 5
				this.oParent.Segment_1ade.F0_1ade_018e(cityID, city.Position.X, city.Position.Y);

				// Instruction address 0x1d12:0x1727, size: 5
				this.oParent.Segment_1866.F0_1866_0cf5(this.Var_6548_PlayerID, city.CurrentProductionID, city.Position.X, city.Position.Y);
				local_ba = (short)this.oCPU.AX.Word;

				this.oParent.StartGameMenu.F5_0000_0e6c(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x1743, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				goto L6927;

			L174b:
				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
					goto L1ab6;

				if (local_ba == -1)
					goto L1ab6;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1b);
				if (this.oCPU.Flags.E) goto L1773;
				goto L1816;

			L1773:
				local_108 = -1;
				local_c8 = -1;
				local_4c = 0;

				goto L1789;

			L1786:
				local_4c++;

			L1789:
				if (local_4c >= 128)
					goto L1802;

				if (this.oParent.GameState.Cities[local_4c].PlayerID == this.Var_6548_PlayerID)
					goto L17ff;

				this.oCPU.CMPByte(this.oParent.GameState.Cities[local_4c].StatusFlag, 0xff);
				if (this.oCPU.Flags.NE) goto L17bb;
				goto L17ff;

			L17bb:
				if (this.oParent.GameState.Cities[local_4c].PlayerID == this.oParent.GameState.HumanPlayerID)
					goto L17ff;

				this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[local_4c].BaseTrade;
				this.oCPU.CBW(this.oCPU.AX);
				
				if (this.oParent.GameState.Cities[local_4c].BaseTrade <= local_c8)
					goto L17ff;

				this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[local_4c].BaseTrade;
				this.oCPU.CBW(this.oCPU.AX);

				local_c8 = this.oParent.GameState.Cities[local_4c].BaseTrade;

				local_108 = local_4c;

			L17ff:
				goto L1786;

			L1802:
				// Instruction address 0x1d12:0x180e, size: 5
				this.oParent.Segment_2459.F0_2459_0948(this.Var_6548_PlayerID, (short)local_ba, (short)local_108);

			L1816:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1a);
				if (this.oCPU.Flags.E) goto L1828;
				goto L1a77;

			L1828:
				local_108 = -1;
				local_c8 = 32767;
				local_106 = 0;
				local_4c = 0;

				goto L1845;

			L1842:
				local_4c++;

			L1845:
				if (local_4c >= 128)
					goto L19af;

				if (this.oParent.GameState.Cities[local_4c].PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L1842;

				this.oCPU.CMPByte(this.oParent.GameState.Cities[local_4c].StatusFlag, 0xff);
				if (this.oCPU.Flags.E) goto L1842;

				// Instruction address 0x1d12:0x1898, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0177(this.Var_6548_PlayerID, (short)local_ba,
					this.oParent.GameState.Cities[local_4c].Position.X,
					this.oParent.GameState.Cities[local_4c].Position.Y);

				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = this.oParent.Var_6c9a;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x3);
				// Instruction address 0x1d12:0x18ab, size: 5
				this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);
				this.oParent.Var_6c9a = this.oCPU.AX.Word;

				this.oCPU.TESTByte(this.oParent.GameState.Cities[local_4c].StatusFlag, 0x20);
				if (this.oCPU.Flags.NE) goto L18c8;
				goto L18ce;

			L18c8:
				this.oParent.Var_6c9a = 3;

			L18ce:
				this.oCPU.AX.Word = this.oParent.Var_6c9a;

				if (local_c8 > (short)this.oParent.Var_6c9a)
					goto L18fe;

				this.oCPU.AX.Word = this.oParent.Var_6c9a;

				if (local_c8 != (short)this.oParent.Var_6c9a)
					goto L19ac;

				local_106++;

				// Instruction address 0x1d12:0x18ee, size: 5
				this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(local_106));

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L18fe;
				goto L19ac;

			L18fe:
				// Instruction address 0x1d12:0x191e, size: 5
				this.oParent.Segment_2aea.F0_2aea_134a(
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.X,
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.Y);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
				if (this.oCPU.Flags.NE) goto L192e;
				goto L19ac;

			L192e:
				// Instruction address 0x1d12:0x1956, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.X,
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_e8].Position.Y);

				local_10c = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x1970, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(
					this.oParent.GameState.Cities[local_4c].Position.X,
					this.oParent.GameState.Cities[local_4c].Position.Y);

				if ((short)this.oCPU.AX.Word != local_10c)
					goto L19ac;

				this.oCPU.AX.Word = this.oParent.Var_6c9a;

				if (local_c8 != (short)this.oParent.Var_6c9a)
					goto L1996;

				local_106 = 1;

				goto L199d;

			L1996:
				this.oCPU.AX.Word = this.oParent.Var_6c9a;

				local_c8 = (short)this.oParent.Var_6c9a;

			L199d:
				local_108 = local_e8;

				this.oCPU.AX.Word = (ushort)((short)local_4c);

				local_b0 = local_4c;

			L19ac:
				goto L1842;

			L19af:
				if (local_c8 > 3)
					goto L1a5c;

				if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) != 0)
					goto L1a5c;

				// Instruction address 0x1d12:0x19f9, size: 5
				this.oParent.Segment_1866.F0_1866_0cf5(
					this.Var_6548_PlayerID,
					0x1a,
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_108].Position.X,
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_108].Position.Y);

				local_ba = (short)this.oCPU.AX.Word;

				if (local_ba == -1)
					goto L1a77;

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ba].GoToPosition.X =
					this.oParent.GameState.Cities[local_b0].Position.X;

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ba].GoToPosition.Y =
					this.oParent.GameState.Cities[local_b0].Position.Y;

				goto L1a77;

			L1a5c:
				city.ShieldsCount += (short)(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a);

			L1a77:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x19);
				if (this.oCPU.Flags.E) goto L1a89;
				goto L1aa8;

			L1a89:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].ActiveUnits[25] == 1)
				{
					this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ContactPlayerCountdown = -1;
				}

			L1aa8:
				// Instruction address 0x1d12:0x1aab, size: 5
				this.oParent.Segment_25fb.F0_25fb_34b6(cityID);

				goto L220f;

			L1ab6:
				city.ShieldsCount = 0;

				if (local_ba == -1)
					goto L220f;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.NE) goto L1ae0;
				goto L1af2;

			L1ae0:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x1a);
				if (this.oCPU.Flags.GE) goto L1af2;
				goto L220f;

			L1af2:
				this.oParent.Var_b1e8 = 1;
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x1d12:0x1b00, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x1b10, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " builds ");

				// Instruction address 0x1d12:0x1b2e, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Name);

				// Instruction address 0x1d12:0x1b3e, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				this.oParent.Var_2f9e_Unknown = 0x3;

				// Instruction address 0x1d12:0x1b58, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

				goto L220f;

			L1b63:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CX.Word = 0x1e;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				if ((this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price * local_4a) > city.ShieldsCount)
					goto L220f;

				local_e8 = -city.CurrentProductionID;

				if (local_e8 <= 24)
					goto L1beb;

				if (this.oParent.GameState.WonderCityID[local_e8 - 24] != -1)
					goto L1be2;

				this.oParent.GameState.WonderCityID[local_e8 - 24] = cityID;

				// Instruction address 0x1d12:0x1bd7, size: 5
				this.oParent.Segment_1866.F0_1866_250e_AddReplayData(10, (byte)((sbyte)this.Var_6548_PlayerID), (byte)((sbyte)(local_e8 - 24)));

				goto L1be8;

			L1be2:
				local_e8 = -1;

			L1be8:
				goto L1c1d;

			L1beb:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Low = (byte)((sbyte)local_e8);
				this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.DX.Word;

				this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
				this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

				this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
				if (this.oCPU.Flags.E)
					goto L1c1d;

				local_e8 = -1;

			L1c1d:
				if (local_e8 == -1)
					goto L220f;

				if (local_e8 != 41)
					goto L1c80;

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

			L1c80:
				if (local_e8 >= 22)
					goto L1caf;

				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Low = (byte)((sbyte)local_e8);
				this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.DX.Word;

				city.BuildingFlags0 |= this.oCPU.CX.Word;
				city.BuildingFlags1 |= this.oCPU.BX.Word;

			L1caf:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CX.Word = 0x1e;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				city.ShieldsCount -= (short)(this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price * local_4a);

				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.E) goto L1ce2;
				goto L1cec;

			L1ce2:
				if (local_e8 <= 24)
					goto L1dfc;

			L1cec:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.NE) goto L1cfe;
				goto L1d07;

			L1cfe:
				this.oParent.Var_b1e8 = 1;
				goto L1d29;

			L1d07:
				short tempVal = -1;
				this.oParent.GameState.MapVisibility[city.Position.X, city.Position.Y] = (ushort)tempVal;

			L1d29:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x1d12:0x1d31, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x1d41, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " builds\n");

				// Instruction address 0x1d12:0x1d58, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.BuildingDefinitions[local_e8].Name);

				// Instruction address 0x1d12:0x1d68, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L1de0;

				this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
				if (this.oCPU.Flags.NE) goto L1d86;
				goto L1de0;

			L1d86:
				if (local_e8 <= 21)
					goto L1d9a;

				if (local_e8 <= 24)
					goto L1de0;

			L1d9a:
				this.oCPU.TESTByte(city.StatusFlag, 0x10);
				if (this.oCPU.Flags.E) goto L1dac;
				goto L1de0;

			L1dac:
				if (local_e8 == 1)
					goto L1de0;

				// Instruction address 0x1d12:0x1dbe, size: 5
				this.oParent.Segment_11a8.F0_11a8_02a4(1, 0);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L1dce;
				goto L1de0;

			L1dce:
				this.oParent.CityView.F19_0000_0000(cityID, (short)local_e8);

				goto L1deb;

			L1de0:
				this.oParent.Overlay_21.F21_0000_0000(cityID);

			L1deb:
				city.ShieldsCount = 0;
				goto L1e60;

			L1dfc:
				if (local_e8 != 1)
					goto L1e13;

				city.CurrentProductionID = -2;

			L1e13:
				// Instruction address 0x1d12:0x1e1a, size: 5
				this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

				this.oCPU.CX.Word = this.oCPU.AX.Word;

				city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L1e42;
				goto L1e60;

			L1e42:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L1e60:
				if (local_e8 < 22)
					goto L2010;

				if (local_e8 > 24)
					goto L2010;

				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
				if (this.oCPU.Flags.E) goto L1e86;
				goto L2010;

			L1e86:
				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L1ea9;

				this.oParent.Overlay_18.F18_0000_0f83(this.Var_6548_PlayerID, (ushort)((short)(local_e8 - 22)));

				goto L2010;

			L1ea9:
				this.oParent.Overlay_18.F18_0000_0d4f(this.Var_6548_PlayerID, (short)(local_e8 - 22));

				local_c8 = (short)this.oCPU.AX.Word;

				if (local_c8 == 0 || local_e8 >= 24)
					goto L1f2f;

				city.ShieldsCount += (short)(this.oParent.GameState.BuildingDefinitions[local_e8].Price * local_4a);

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xea);
				if (this.oCPU.Flags.LE) goto L1f05;
				goto L1f2b;

			L1f05:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xe8);
				if (this.oCPU.Flags.GE) goto L1f17;
				goto L1f2b;

			L1f17:
				city.CurrentProductionID = (sbyte)((-local_e8) - 1);

			L1f2b:
				local_c8--;

			L1f2f:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
				if (this.oCPU.Flags.E) goto L1f41;
				goto L1ffa;

			L1f41:
				if (this.oParent.GameState.AISpaceshipSuccessRate >= 40) goto L1f4b;
				goto L1ffa;

			L1f4b:
				if (local_c8 != 0)
					goto L1feb;

				// Instruction address 0x1d12:0x1f5d, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID, (int)TechnologyEnum.SpaceFlight);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L1f6d;

				goto L1ff7;

			L1f6d:
				if (this.oParent.GameState.AISpaceshipSuccessRate <= 75) goto L1f77;
				goto L1feb;

			L1f77:
				if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Ranking >
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Ranking) goto L1feb;

				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
				if (this.oCPU.Flags.E) goto L1fc5;

				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].SpaceshipETAYear;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Year);
				this.oCPU.CX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipETAYear;
				this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, (ushort)this.oParent.GameState.Year);
				this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
				if (this.oCPU.Flags.LE) goto L1feb;

			L1fc5:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
				this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, 0x8);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
				if (this.oCPU.Flags.E) goto L1ff7;
				if (this.oParent.GameState.Players[this.oParent.GameState.ActiveCivilizations].Coins <= 1000) goto L1ff7;

				L1feb:
				this.oParent.Overlay_18.F18_0000_15c3(this.Var_6548_PlayerID);

			L1ff7:
				goto L2010;

			L1ffa:
				if (local_c8 == 0)
					goto L2010;

				this.oParent.Overlay_18.F18_0000_15c3(this.Var_6548_PlayerID);

			L2010:
				if (local_e8 != 1)
					goto L212c;

				local_4c = 0;

				goto L2025;

			L2022:
				local_4c++;

			L2025:
				if (local_4c >= 128)
					goto L205a;

				if (this.oParent.GameState.Cities[local_4c].PlayerID != this.Var_6548_PlayerID)
					goto L2057;

				this.oParent.GameState.Cities[local_4c].BuildingFlags0 &= 0xfffe;
				this.oParent.GameState.Cities[local_4c].BuildingFlags1 &= 0xffff;

			L2057:
				goto L2022;

			L205a:
				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
					goto L207e;

				if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[this.Var_6548_PlayerID] & 0x40) == 0)
					goto L212c;

				L207e:
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
					goto L20a5;

				// Instruction address 0x1d12:0x2097, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Diplomats report:\n");

				this.oParent.Var_2f9e_Unknown = 0x1;

			L20a5:
				// Instruction address 0x1d12:0x20b3, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.Players[this.Var_6548_PlayerID].Nationality);

				// Instruction address 0x1d12:0x20c3, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " capital\nmoved to ");

				// Instruction address 0x1d12:0x20ce, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x20de, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				this.oParent.Var_2f9e_Unknown = 0x5;

				// Instruction address 0x1d12:0x20f8, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

				this.oParent.GameState.Players[this.Var_6548_PlayerID].XStart = (short)city.Position.X;

				city.BuildingFlags0 |= 1;
				city.BuildingFlags1 |= 0;

			L212c:
				if (local_e8 != 38)
					goto L2160;

				// Instruction address 0x1d12:0x2136, size: 5
				this.oParent.Segment_11a8.F0_11a8_0280();

				// Instruction address 0x1d12:0x2143, size: 5
				this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x2153, size: 5
				this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x215b, size: 5
				this.oParent.Segment_11a8.F0_11a8_0294();

			L2160:
				if (local_e8 != 43)
					goto L220f;

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L220f;

				local_4c = 0;

				goto L2181;

			L217e:
				local_4c++;

			L2181:
				if (local_4c >= 128)
					goto L220f;

				this.oCPU.CMPByte(this.oParent.GameState.Cities[local_4c].StatusFlag, 0xff);
				if (this.oCPU.Flags.NE) goto L219d;
				goto L220c;

			L219d:
				if (this.oParent.GameState.Cities[local_4c].PlayerID == this.Var_6548_PlayerID)
					goto L220c;

				this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[local_4c].ActualSize;
				this.oParent.GameState.Cities[local_4c].VisibleSize = (sbyte)this.oCPU.AX.Low;

				this.oParent.GameState.MapVisibility[this.oParent.GameState.Cities[local_4c].Position.X,
					this.oParent.GameState.Cities[local_4c].Position.Y] |= (ushort)(1 << this.Var_6548_PlayerID);

				// Instruction address 0x1d12:0x2204, size: 5
				this.oParent.Segment_2aea.F0_2aea_1601(
					this.oParent.GameState.Cities[local_4c].Position.X,
					this.oParent.GameState.Cities[local_4c].Position.Y);

			L220c:
				goto L217e;

			L220f:
				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L2307;

				this.oCPU.TESTByte(city.StatusFlag, 0x10);
				if (this.oCPU.Flags.NE) goto L222d;
				goto L2307;

			L222d:
				this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
				if (this.oCPU.Flags.NE) goto L223f;
				goto L225b;

			L223f:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.L) goto L2251;
				goto L2307;

			L2251:
				if (local_e8 != -1)
					goto L2307;

			L225b:
				// Instruction address 0x1d12:0x2262, size: 5
				this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

				local_e8 = (short)this.oCPU.AX.Word;

				this.oParent.Var_aa_Rectangle.FontID = 2;

				if (local_e8 == 99)
					goto L22fa;

				this.oParent.Var_b1e8 = 0;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L2299;
				goto L22b7;

			L2299:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

			L22b7:
				city.CurrentProductionID = (sbyte)local_e8;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L22d9;
				goto L22f7;

			L22d9:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L22f7:
				goto L2307;

			L22fa:
				city.StatusFlag &= 0xef;

			L2307:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.E) goto L2319;
				goto L2673;

			L2319:
				this.oCPU.TESTByte(city.StatusFlag, 0x10);
				if (this.oCPU.Flags.NE) goto L232b;
				goto L2336;

			L232b:
				// Instruction address 0x1d12:0x232e, size: 5
				this.oParent.Segment_25fb.F0_25fb_34b6(cityID);

			L2336:
				local_cc = 0;

				// Instruction address 0x1d12:0x2344, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(local_d8, local_e4);

				// ??? Needs further investigation why this happens
				if (this.oCPU.AX.Word >= this.oParent.GameState.Players.Length)
				{
					this.oCPU.AX.Word = 0;
				}
				else
				{
					this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.AX.Word].Continents[this.Var_6548_PlayerID].Strategy;
				}

				local_104 = (short)this.oCPU.AX.Word;

				if (local_104 == 1)
					goto L237e;

				if (local_104 == 2)
					goto L237e;

				if (local_104 != 5)
					goto L23d3;

			L237e:
				if (local_e8 != 0 && city.CurrentProductionID >= 0)
				{
					if (this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].UnitCategory == local_104)
					{
						local_cc = this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 64;
					}
				}

			L23d3:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
				this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, 0x8);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
				if (this.oCPU.Flags.NE) goto L23e8;
				goto L2432;

			L23e8:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x16);
				if (this.oCPU.Flags.GE) goto L23ff;
				goto L2432;

			L23ff:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x18);
				if (this.oCPU.Flags.LE) goto L2416;
				goto L2432;

			L2416:
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x7;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				local_cc = (short)this.oCPU.AX.Word;

			L2432:
				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.NE) goto L2444;
				goto L24b3;

			L2444:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.L) goto L2456;
				goto L24b3;

			L2456:
				this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
				if (this.oCPU.Flags.NE) goto L2468;
				goto L24b3;

			L2468:
				// Instruction address 0x1d12:0x24a7, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					(this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price * local_4a) - city.ShieldsCount,
					0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 8);

				local_cc = (short)this.oCPU.AX.Word;

			L24b3:
				// Instruction address 0x1d12:0x24bb, size: 5
				this.oParent.Segment_2aea.F0_2aea_14e0(local_d8, local_e4);

				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE) goto L24c9;
				goto L24db;

			L24c9:
				this.oCPU.TESTByte(city.StatusFlag, 0x10);
				if (this.oCPU.Flags.NE) goto L24db;
				goto L253c;

			L24db:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L24ed;
				goto L253c;

			L24ed:
				this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
				if (this.oCPU.Flags.NE) goto L24ff;
				goto L253c;

			L24ff:
				// Instruction address 0x1d12:0x2530, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) - city.ShieldsCount,
					0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 3);

				local_cc = (short)this.oCPU.AX.Word;

			L253c:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xff);
				if (this.oCPU.Flags.E) goto L254e;
				goto L259d;

			L254e:
				this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
				if (this.oCPU.Flags.NE) goto L2560;
				goto L259d;

			L2560:
				// Instruction address 0x1d12:0x2591, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) - city.ShieldsCount,
					0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 3);

				local_cc = (short)this.oCPU.AX.Word;

			L259d:
				this.oCPU.CMPByte(city.StatusFlag, 0x19);
				if (this.oCPU.Flags.E) goto L25af;
				goto L2619;

			L25af:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].ActiveUnits[25] != 0)
					goto L2619;

				this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
				if (this.oCPU.Flags.NE) goto L25d4;
				goto L2619;

			L25d4:
				// Instruction address 0x1d12:0x260d, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					(this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost * local_4a) - city.ShieldsCount,
					0, this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins / 4);

				local_cc = (short)this.oCPU.AX.Word;

			L2619:
				this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins, 0x7d0);
				if (this.oCPU.Flags.G) goto L262a;
				goto L2646;

			L262a:
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x9;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				local_cc += (short)this.oCPU.AX.Word;

			L2646:
				city.ShieldsCount += (short)local_cc;
				
				this.oCPU.AX.Word = (ushort)((short)local_cc);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins -= (short)(local_cc * 2);
				city.StatusFlag &= 0xef;

			L2673:
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L267f;
				goto L277e;

			L267f:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2687;
				goto L277e;

			L2687:
				// Instruction address 0x1d12:0x2697, size: 5
				F0_1d12_70cb_FillRectangleWithPattern(2, 67, 124, 104);

				// Instruction address 0x1d12:0x26af, size: 5
				F0_1d12_70cb_FillRectangleWithPattern(95, 106, 227, 197);

				// Instruction address 0x1d12:0x26cf, size: 5
				F0_1d12_71bf(95, 106, 128, 114, 0x25ea, 9);

				// Instruction address 0x1d12:0x26ef, size: 5
				F0_1d12_71bf(129, 106, 160, 114, 0x25ef, 9);

				// Instruction address 0x1d12:0x270f, size: 5
				F0_1d12_71bf(161, 106, 193, 114, 0x25f5, 9);

				// Instruction address 0x1d12:0x272f, size: 5
				F0_1d12_71bf(194, 106, 226, 114, 0x25f9, 9);

				// Instruction address 0x1d12:0x275a, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
					(33 * this.Var_2496) + 96, 107, 32, 7, 9, 15);

				this.oCPU.AX.Word = Var_2496;
				goto L2773;

			L2768:
				// Instruction address 0x1d12:0x2768, size: 5
				F0_1d12_72b7();
				goto L277e;

			L2773:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
				if (this.oCPU.Flags.NE) goto L277e;
				goto L2768;

			L277e:
				local_d8 = city.Position.X;
				local_e4 = city.Position.Y;

				this.oParent.Var_d2e0 = 0;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 3)
				{
					this.Var_6b30 = 10;
				}

				this.oCPU.AX.Word = 0x14;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
					(ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x50);
				this.oCPU.BX.Word = 0x3;
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[2]);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6b30);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oParent.Var_d2e0 = this.oCPU.AX.Word;

				this.oCPU.TESTWord(city.BuildingFlags0, 0x40);
				if (this.oCPU.Flags.E) goto L27f4;
				goto L2806;

			L27f4:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x1);
				if (this.oCPU.Flags.NE) goto L2806;
				goto L2812;

			L2806:
				this.oCPU.CX.Word = 0x2;
				this.oCPU.AX.Word = this.oParent.Var_d2e0;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oParent.Var_d2e0 = this.oCPU.AX.Word;

			L2812:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
				{
					this.oParent.Var_d2e0 = 0x0;
				}

				city.BaseTrade = (sbyte)(this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0);
				local_bc = 0;

				goto L2848;

			L2844:
				local_bc++;

			L2848:
				if (local_bc >= 3)
					goto L28d9;

				this.oCPU.AX.Low = (byte)city.TradeCityIDs[local_bc];
				this.oCPU.AX.High = 0;
				local_4c = city.TradeCityIDs[local_bc];

				if (local_4c == -1)
					goto L28d6;

				if (this.oParent.GameState.Cities[local_4c].PlayerID == this.Var_6548_PlayerID)
					goto L28b0;

				this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[local_4c].BaseTrade;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70da_Arr[2]));
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x3;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);

				this.oParent.Var_70da_Arr[2] += (short)this.oCPU.AX.Word;

				goto L28d6;

			L28b0:
				this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[local_4c].BaseTrade;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70da_Arr[2]));
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x4;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);

				this.oParent.Var_70da_Arr[2] += (short)this.oCPU.AX.Word;

			L28d6:
				goto L2844;

			L28d9:
				this.oCPU.AX.Word = 0x14;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
					(ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x50);
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[2]);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6b30);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, 3);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oParent.Var_d2e0 = this.oCPU.AX.Word;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
				{
					this.oParent.Var_d2e0 = 0;
				}

				if ((city.BuildingFlags0 & 0x40) != 0)
				{
					this.oCPU.CX.Word = 0x2;
					this.oCPU.AX.Word = this.oParent.Var_d2e0;
					this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
					this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
					this.oParent.Var_d2e0 = this.oCPU.AX.Word;
				}

				// Instruction address 0x1d12:0x2960, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					((-(this.oParent.GameState.Players[this.Var_6548_PlayerID].ScienceTaxRate +
						this.oParent.GameState.Players[this.Var_6548_PlayerID].TaxRate - 10) *
						(this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0)) + 5) / 10,
					0, this.oParent.Var_70da_Arr[2]);

				this.oParent.Var_70da_Arr[3] = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x2999, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					((this.oParent.GameState.Players[this.Var_6548_PlayerID].TaxRate * (this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0)) + 5) / 10,
					0, this.oParent.Var_70da_Arr[2] - this.oParent.Var_70da_Arr[3] - (short)this.oParent.Var_d2e0);

				this.oParent.Var_e17a = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[2]);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, ((ushort)(short)this.oParent.Var_70da_Arr[3]));
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_e17a);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oParent.Var_d2e0);
				this.oParent.Var_70e6 = this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x29ba, size: 5
				F0_1d12_6dcc(1);

				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_e17a += this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x29cc, size: 5
				F0_1d12_6dcc(2);

				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_70e6 += this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x29de, size: 5
				F0_1d12_6dcc(3);

				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_70da_Arr[3] += (short)this.oCPU.AX.Word;

				this.oCPU.TESTWord(city.BuildingFlags0, 0x10);
				if (this.oCPU.Flags.NE) goto L29fe;
				goto L2a16;

			L29fe:
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[3]);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_70da_Arr[3] += (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = this.oParent.Var_e17a;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_e17a += this.oCPU.AX.Word;

			L2a16:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x200);
				if (this.oCPU.Flags.NE) goto L2a29;
				goto L2a41;

			L2a29:
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[3]);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_70da_Arr[3] += (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = this.oParent.Var_e17a;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_e17a += this.oCPU.AX.Word;

			L2a41:
				local_e8 = (short)this.oParent.Var_70e6;

				this.oCPU.TESTWord(city.BuildingFlags0, 0x20);
				if (this.oCPU.Flags.NE) goto L2a5a;
				goto L2a8b;

			L2a5a:
				this.oCPU.AX.Word = this.oParent.Var_70e6;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				local_e8 += (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x2a6e, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 0xc);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L2a7e;
				goto L2a8b;

			L2a7e:
				this.oCPU.AX.Word = this.oParent.Var_70e6;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = 0x3;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				local_e8 += (short)this.oCPU.AX.Word;

			L2a8b:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x800);
				if (this.oCPU.Flags.NE) goto L2a9e;
				goto L2acf;

			L2a9e:
				this.oCPU.AX.Word = this.oParent.Var_70e6;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				local_e8 += (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x2ab2, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 0xc);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L2ac2;
				goto L2acf;

			L2ac2:
				this.oCPU.AX.Word = this.oParent.Var_70e6;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = 0x3;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				local_e8+= (short)this.oCPU.AX.Word;

			L2acf:
				// Instruction address 0x1d12:0x2ad3, size: 5
				F0_1d12_6cf3(10);

				this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)cityID);
				if (this.oCPU.Flags.E) goto L2ae3;
				goto L2aeb;

			L2ae3:
				local_e8 += local_e8;

			L2aeb:
				this.oParent.Var_70e6 = (ushort)((short)local_e8);
				this.oParent.Var_70e2 = 0;

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L2b79;

				this.oCPU.AX.Word = (ushort)oParent.GameState.DifficultyLevel;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xe);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_e8);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.CX.Word = (ushort)((short)local_e8);
				this.oCPU.DX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)cityID;
				this.oCPU.BX.Word = this.oCPU.DX.Word;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.AX.Word = this.oCPU.DX.Word;
				this.oCPU.AX.Word += (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].CityCount;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)local_e8));
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = (ushort)((short)local_e8);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.DifficultyLevel);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x6);
				this.oParent.Var_70e4 = (short)this.oCPU.AX.Word;
				local_a8 = (short)this.oCPU.AX.Word;

				goto L2b90;

			L2b79:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x3);
				this.oParent.Var_70e4 = (short)this.oCPU.AX.Word;
				local_a8 = (short)this.oCPU.AX.Word;

			L2b90:
				this.Var_6542 = 0;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);

				if (city.ActualSize >= this.oParent.Var_70e4)
					goto L2bd3;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.CX.Word = (ushort)((short)this.oParent.Var_70e4);
				this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
				this.Var_6542 = this.oCPU.CX.Word;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);

				this.oParent.Var_70e4 = city.ActualSize;

			L2bd3:
				// Instruction address 0x1d12:0x2bd9, size: 5
				F0_1d12_6dfe(cityID, (ushort)((short)local_8));

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L2bed;
				goto L2c3d;

			L2bed:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2bf5;
				goto L2c3d;

			L2bf5:
				if (this.Var_2496 != 1)
					goto L2c3d;

				local_42 = 116;

				// Instruction address 0x1d12:0x2c15, size: 5
				F0_1d12_6ed4(cityID, 100, (short)local_42, (ushort)((short)local_8), 92);

				local_42 += 16;

				// Instruction address 0x1d12:0x2c35, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);

			L2c3d:
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[3]);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oParent.Var_70e2 = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x2c4e, size: 5
				F0_1d12_6dfe(cityID, (ushort)((short)local_8));

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L2c62;
				goto L2cce;

			L2c62:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2c6a;
				goto L2cce;

			L2c6a:
				if (this.Var_2496 != 1)
					goto L2cce;

				if (this.oParent.Var_70e2 == 0)
					goto L2cce;

				// Instruction address 0x1d12:0x2c8f, size: 5
				F0_1d12_6ed4(cityID, 100, (short)local_42, (ushort)((short)local_8), 92);

				// Instruction address 0x1d12:0x2ca6, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					208, local_42 + 4,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xe << 1) + 0xd4ce)));

				local_42 += 16;

				// Instruction address 0x1d12:0x2cc6, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);

			L2cce:
				local_6 = 208;

				this.oCPU.TESTWord(city.BuildingFlags0, 0x2000);
				if (this.oCPU.Flags.NE) goto L2ce6;
				goto L2d1f;

			L2ce6:
				this.oParent.Var_70e4 -= 3;
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L2cf7;
				goto L2d1f;

			L2cf7:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2cff;
				goto L2d1f;

			L2cff:
				if (this.Var_2496 != 1)
					goto L2d1f;

				// Instruction address 0x1d12:0x2d13, size: 5
				F0_1d12_7045(14, (short)local_6, (short)local_42);

				local_6 -= 16;

			L2d1f:
				// Instruction address 0x1d12:0x2d27, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Religion);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L2d37;

				goto L2dbc;

			L2d37:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x400);
				if (this.oCPU.Flags.NE) goto L2d4a;
				goto L2d6e;

			L2d4a:
				// Instruction address 0x1d12:0x2d52, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 9);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L2d62;
				goto L2d68;

			L2d62:
				this.oCPU.AX.Word = 0x6;
				goto L2d6b;

			L2d68:
				this.oCPU.AX.Word = 0x4;

			L2d6b:
				goto L2d71;

			L2d6e:
				this.oCPU.AX.Word = 0x0;

			L2d71:
				this.oParent.Var_70e4 -= (short)this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L2d81;
				goto L2dbc;

			L2d81:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2d89;
				goto L2dbc;

			L2d89:
				if (this.Var_2496 != 1)
					goto L2dbc;

				this.oCPU.TESTWord(city.BuildingFlags0, 0x400);
				if (this.oCPU.Flags.NE) goto L2da6;
				goto L2dbc;

			L2da6:
				// Instruction address 0x1d12:0x2db0, size: 5
				F0_1d12_7045(11, (short)local_6, (short)local_42);

				local_6 -= 16;

			L2dbc:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x8);
				if (this.oCPU.Flags.NE) goto L2dce;
				goto L2e7b;

			L2dce:
				// Instruction address 0x1d12:0x2dd6, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Mysticism);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L2de6;

				goto L2dee;

			L2de6:
				this.oParent.Var_70e4 -= 2;
				goto L2e0a;

			L2dee:
				// Instruction address 0x1d12:0x2df6, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.CeremonialBurial);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L2e06;

				goto L2e0a;

			L2e06:
				this.oParent.Var_70e4--;

			L2e0a:
				// Instruction address 0x1d12:0x2e12, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 6);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L2e22;
				goto L2e47;

			L2e22:
				// Instruction address 0x1d12:0x2e2a, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Mysticism);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L2e3a;

				goto L2e40;

			L2e3a:
				this.oCPU.AX.Word = 0x2;
				goto L2e43;

			L2e40:
				this.oCPU.AX.Word = 0x1;

			L2e43:
				this.oParent.Var_70e4 -= (short)this.oCPU.AX.Word;

			L2e47:
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L2e53;
				goto L2e7b;

			L2e53:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2e5b;
				goto L2e7b;

			L2e5b:
				if (this.Var_2496 != 1)
					goto L2e7b;

				// Instruction address 0x1d12:0x2e6f, size: 5
				F0_1d12_7045(4, (short)local_6, (short)local_42);

				local_6 -= 16;

			L2e7b:
				// Instruction address 0x1d12:0x2e81, size: 5
				F0_1d12_6dfe(cityID, (ushort)((short)local_8));

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L2e95;
				goto L2ef3;

			L2e95:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2e9d;
				goto L2ef3;

			L2e9d:
				if (this.Var_2496 != 1)
					goto L2ef3;

				this.oCPU.TESTWord(city.BuildingFlags0, 0x2408);
				if (this.oCPU.Flags.NE) goto L2eba;
				goto L2ef3;

			L2eba:
				// Instruction address 0x1d12:0x2ecb, size: 5
				F0_1d12_6ed4(cityID, 100, (short)local_42, (ushort)((short)local_8), 92);

				local_42 += 16;

				// Instruction address 0x1d12:0x2eeb, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);

			L2ef3:
				local_6 = 208;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType < 4) goto L2f08;
				goto L3088;

			L2f08:
				local_2 = 0;
				local_e6 = 0;

				// Instruction address 0x1d12:0x2f1a, size: 5
				this.oParent.Segment_2aea.F0_2aea_1458(local_d8, local_e4);

				local_e8 = (short)this.oCPU.AX.Word;
				local_ba = (short)this.oCPU.AX.Word;

			L2f2a:
				if (local_ba == -1)
					goto L2ffa;

				local_2++;

				if (local_2 >= 32)
					goto L2ffa;

				if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ba].TypeID].AttackStrength == 0)
					goto L2fc9;

				local_e6++;

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L2f74;
				goto L2fc9;

			L2f74:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L2f7c;
				goto L2fc9;

			L2f7c:
				if (this.Var_2496 != 1)
					goto L2fc9;

				if (local_e6 > 3)
					goto L2fc9;

				// Instruction address 0x1d12:0x2fbd, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_6, local_42 - 1,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word,
						(ushort)(((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ba].TypeID +
						(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));

				local_6 -= 2;

			L2fc9:
				local_ba = this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ba].NextUnitID;

				if (local_ba != local_e8)
					goto L2ff7;

				local_ba = -1;

			L2ff7:
				goto L2f2a;

			L2ffa:
				local_ba = 0;

				goto L3007;

			L3003:
				local_ba++;

			L3007:
				if (local_ba >= 2)
					goto L305d;

				if (this.oParent.Var_70e4 == 0)
					goto L305a;

				this.oCPU.CMPByte((byte)city.Unknown[local_ba], 0xff);
				if (this.oCPU.Flags.NE) goto L3031;
				goto L305a;

			L3031:
				if (this.oParent.GameState.UnitDefinitions[city.Unknown[local_ba] & 0x3f].AttackStrength != 0)
				{
					local_e6++;
				}

			L305a:
				goto L3003;

			L305d:
				if (local_e6 <= 3)
					goto L306d;

				local_e6 = 3;

			L306d:
				// Instruction address 0x1d12:0x3079, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_e6, 0, this.oParent.Var_70e4);

				this.oParent.Var_70e4 -= (short)this.oCPU.AX.Word;

				goto L3126;

			L3088:
				// Instruction address 0x1d12:0x3090, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 16);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.SBBWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
				this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
				local_e8 = (short)this.oCPU.CX.Word;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
				{
					local_e8++;
				}

				if (local_e8 == 0)
					goto L3126;

				this.oCPU.AX.Word = (ushort)((short)local_e8);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6546);
				this.oParent.Var_70e4 += (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L30d9;
				goto L3126;

			L30d9:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L30e1;
				goto L3126;

			L30e1:
				if (this.Var_2496 != 1)
					goto L3126;

				local_ba = 0;

				goto L30f8;

			L30f4:
				local_ba++;

			L30f8:
				this.oCPU.AX.Word = (ushort)((short)local_e8);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6546);
				
				if ((short)this.oCPU.AX.Word <= local_ba)
					goto L3126;

				// Instruction address 0x1d12:0x3117, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_6, local_42 + 4,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

				local_6 -= 2;

				goto L30f4;

			L3126:
				// Instruction address 0x1d12:0x312c, size: 5
				F0_1d12_6dfe(cityID, (ushort)((short)local_8));

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L3140;
				goto L318b;

			L3140:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L3148;
				goto L318b;

			L3148:
				if (this.Var_2496 != 1)
					goto L318b;

				// Instruction address 0x1d12:0x3163, size: 5
				F0_1d12_6ed4(cityID, 100, (short)local_42, (ushort)((short)local_8), 92);

				local_42 += 16;

				// Instruction address 0x1d12:0x3183, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);

			L318b:
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e2);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
				local_e8 = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x319e, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 2);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L31ae;
				goto L31b2;

			L31ae:
				this.oParent.Var_70e2++;

			L31b2:
				// Instruction address 0x1d12:0x31ba, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 0x15);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L31ca;
				goto L31ce;

			L31ca:
				this.oParent.Var_70e2++;

			L31ce:
				// Instruction address 0x1d12:0x31d2, size: 5
				F0_1d12_6cf3(11);

				this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)cityID);
				if (this.oCPU.Flags.E) goto L31e2;
				goto L31e8;

			L31e2:
				this.oParent.Var_70e4 = 0;

			L31e8:
				// Instruction address 0x1d12:0x31f0, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 0xd);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L3200;
				goto L323d;

			L3200:
				// Instruction address 0x1d12:0x3217, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(
					this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[13]].Position.X,
					this.oParent.GameState.Cities[this.oParent.GameState.WonderCityID[13]].Position.Y);

				this.oCPU.DI.Word = this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x3229, size: 5
				this.oParent.Segment_2aea.F0_2aea_1942(local_d8, local_e4);

				this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
				if (this.oCPU.Flags.E) goto L3238;
				goto L323d;

			L3238:
				this.oParent.Var_70e4 -= 2;

			L323d:
				// Instruction address 0x1d12:0x3243, size: 5
				F0_1d12_6dfe(cityID, (ushort)((short)local_8));

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L3257;
				goto L32cd;

			L3257:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L325f;
				goto L32cd;

			L325f:
				if (this.Var_2496 != 1)
					goto L32cd;

				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e2);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
				if ((short)this.oCPU.AX.Word == local_e8)
					goto L32cd;

				// Instruction address 0x1d12:0x328a, size: 5
				F0_1d12_6ed4(cityID, 100, (short)local_42, (ushort)((short)local_8), 92);

				// Instruction address 0x1d12:0x32a5, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("WONDERS", 190, local_42 + 5, 15);

				local_42 += 16;

				// Instruction address 0x1d12:0x32c5, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 100, local_42 - 2, 222, local_42 - 2, 1);

			L32cd:
				this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
				if (this.oCPU.Flags.E) goto L32d7;
				goto L32e0;

			L32d7:
				this.oParent.Var_70e4 = 0;
				this.oParent.Var_70e2 = 0;

			L32e0:
				local_4e = 0;
				this.oParent.Var_deb8 = 0;
				this.oParent.Var_d2f6 = 0;
				local_ea = 0;

				goto L32fc;

			L32f8:
				local_ea++;

			L32fc:
				if (local_ea >= 2)
					goto L3323;

				if (city.Unknown[local_ea] == -1)
					goto L3320;

				this.oParent.Var_deb8++;

			L3320:
				goto L32f8;

			L3323:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_deb8);
				if (this.oCPU.Flags.L) goto L3339;
				goto L3350;

			L3339:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.CX.Word = this.oParent.Var_deb8;
				this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
				this.oParent.Var_d2f6 = this.oCPU.CX.Word;

			L3350:
				local_f6 = 8;
				local_fc = 69;
				local_fa = 100;
				local_100 = 116;
				local_ea = 0;

				goto L3375;

			L3371:
				local_ea++;

			L3375:
				if (local_ea >= 128)
					goto L39ef;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID == -1)
					goto L38d4;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].HomeCityID != cityID)
					goto L38d4;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID >= 26)
					goto L340f;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);

				this.oParent.Var_deb8++;

				this.oCPU.CMPWord(this.oCPU.AX.Word, this.oParent.Var_deb8);
				if (this.oCPU.Flags.GE) goto L33f1;
				goto L340b;

			L33f1:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType > 1) goto L3401;
				goto L340f;

			L3401:
				this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
				if (this.oCPU.Flags.NE) goto L340b;
				goto L340f;

			L340b:
				this.oParent.Var_d2f6++;

			L340f:
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L341a;
				goto L3672;

			L341a:
				this.oCPU.AX.Word = this.oParent.Var_d2f6;

				if (this.oParent.Var_70da_Arr[1] < (short)this.oParent.Var_d2f6)
					goto L3463;

				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.NE) goto L3438;
				goto L3672;

			L3438:
				this.oCPU.AX.Low = (byte)local_ea;
				this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, (byte)(this.oParent.GameState.TurnCount & 0xff));
				this.oCPU.TESTByte(this.oCPU.AX.Low, 0x7);
				if (this.oCPU.Flags.E) goto L3447;
				goto L3672;

			L3447:
				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
					goto L3672;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 4) goto L3463;
				goto L3672;

			L3463:
				local_108 = -1;
				local_c8 = -1;
				local_106 = 0;

				goto L347b;

			L3477:
				local_106++;

			L347b:
				if (local_106 >= 0x80)
					goto L353f;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_106].TypeID == -1)
					goto L3477;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_106].HomeCityID != cityID)
					goto L3477;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_106].TypeID >= 26)
					goto L3477;

				// Instruction address 0x1d12:0x3513, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
					city.Position.X,
					city.Position.Y,
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_106].Position.X,
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_106].Position.Y);

				local_b2 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_c8);

				if (local_b2 <= local_c8)
					goto L3477;

				this.oCPU.AX.Word = (ushort)((short)local_b2);
				local_c8 = local_b2;

				local_108 = local_106;

				goto L3477;

			L353f:
				this.oCPU.AX.Word = this.oParent.Var_d2f6;

				if (this.oParent.Var_70da_Arr[1] < (short)this.oParent.Var_d2f6)
					goto L35e1;

				this.oCPU.CMPWord(this.oParent.Var_8078, 0x0);
				if (this.oCPU.Flags.NE) goto L3555;
				goto L3577;

			L3555:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount <
					this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].DiscoveredTechnologyCount)
					goto L356e;

				goto L3577;

			L356e:
				this.oParent.Var_db42 = 0xfc19;
				goto L35de;

			L3577:
				if (local_c8 <= 0 ||
					this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_108].TypeID].TerrainCategory != 0 ||
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_108].TypeID == 0)
					goto L35de;

				// Instruction address 0x1d12:0x35c9, size: 5
				this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID, (short)local_108);

				city.StatusFlag &= 0xfe;

			L35de:
				goto L3672;

			L35e1:
				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L365f;

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x1d12:0x35f5, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x3605, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " can't support\n");

				// Instruction address 0x1d12:0x362d, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_108].TypeID].Name);

				// Instruction address 0x1d12:0x363d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n Unit Disbanded.\n");

				this.oParent.Var_2f9e_Unknown = 0x3;

				// Instruction address 0x1d12:0x3657, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			L365f:
				// Instruction address 0x1d12:0x3667, size: 5
				this.oParent.Segment_1866.F0_1866_0f10(this.Var_6548_PlayerID, (short)local_108);

				goto L32e0;

			L3672:
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L367e;
				goto L38d4;

			L367e:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L3686;
				goto L38d4;

			L3686:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID >= 26)
					goto L384a;

				this.oCPU.CMPWord(this.oParent.Var_d2f6, 0x0);
				if (this.oCPU.Flags.NE) goto L36ac;
				goto L36c8;

			L36ac:
				// Instruction address 0x1d12:0x36c0, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_f6 + 8, local_fc + 12,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));

			L36c8:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID != 0)
					goto L372a;

				// Instruction address 0x1d12:0x36f4, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_f6, local_fc + 12,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 2)
				{
					// Instruction address 0x1d12:0x371f, size: 5
					this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
						local_f6 + 2, local_fc + 12,
						this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
				}
				goto L384a;

			L372a:
				// Instruction address 0x1d12:0x3732, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 16);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.SBBWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
				this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
				local_e8 = (short)this.oCPU.CX.Word;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 5)
				{
					local_e8++;
				}

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 4) goto L3769;
				goto L384a;

			L3769:
				if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID].AttackStrength == 0)
					goto L384a;

				if (local_e8 == 0)
					goto L384a;

				if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID].TerrainCategory == 1)
					goto L380d;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.X !=
					city.Position.X)
					goto L380d;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.Y ==
					city.Position.Y)
					goto L384a;

				L380d:
				// Instruction address 0x1d12:0x381d, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_f6, local_fc + 12,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

				if (local_e8 <= 1)
					goto L384a;

				// Instruction address 0x1d12:0x3842, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_f6 + 2, local_fc + 12,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

			L384a:
				// Instruction address 0x1d12:0x3877, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_f6, local_fc,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word,
						(ushort)(((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID +
							(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));

				// Instruction address 0x1d12:0x38a3, size: 5
				F0_1d12_73ea(
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.X,
					this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.Y,
					7);

				local_f6 += 16;

				if (local_f6 < 0x70)
					goto L38d4;

				local_f6 = 8;
				local_fc += 16;

				if (local_fc <= 0x55)
					goto L38d4;

				local_fc -= 24;

			L38d4:
				if (local_4e >= 18)
					goto L3371;

				if (this.Var_2496 != 0)
					goto L3371;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].TypeID == -1)
					goto L3371;

				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.NE)
					goto L3371;

				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L3371;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.X != local_d8)
					goto L3371;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].Position.Y != local_e4)
					goto L3371;

				// Instruction address 0x1d12:0x3969, size: 5
				this.oParent.Segment_2aea.F0_2aea_0fb3(this.Var_6548_PlayerID, (short)local_ea, local_fa, local_100);

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x1d12:0x398e, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[local_ea].HomeCityID);

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba09, 0x2e);
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba0a, 0x0);

				// Instruction address 0x1d12:0x39b4, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, local_fa, local_100 + 15, 0);

				Arr_74[local_4e] = local_ea;

				local_4e++;

				local_fa += 18;

				this.oCPU.AX.Word = (ushort)((short)local_4e);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = 0x6;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E)
				{
					local_fa = 100;
					local_100 += 16;
				}

				goto L3371;

			L39ef:
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.E) goto L39fa;
				goto L3a72;

			L39fa:
				this.oCPU.AX.Word = this.oParent.Var_deb8;

				if (this.oParent.Var_70da_Arr[1] >= (short)this.oParent.Var_deb8)
					goto L3a16;

				this.oCPU.AX.Word = this.oParent.Var_deb8;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70da_Arr[1]));
				this.oCPU.CX.Word = 0x5;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oParent.Var_e3c2 += this.oCPU.AX.Word;

			L3a16:
				// Instruction address 0x1d12:0x3a2c, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					(short)this.oParent.Var_deb8,
					0, city.ActualSize);

				this.oParent.Var_e3c2 += this.oCPU.AX.Word;

				this.oCPU.TESTWord(city.BuildingFlags0, 0x10);
				if (this.oCPU.Flags.NE) goto L3a4a;
				goto L3a50;

			L3a4a:
				this.oCPU.AX.Word = 0x5;
				goto L3a53;

			L3a50:
				this.oCPU.AX.Word = 0x7;

			L3a53:
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word,
					(ushort)this.oParent.GameState.Nations[this.oParent.GameState.Players[this.Var_6548_PlayerID].NationalityID].Ideology);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.Var_6546);
				this.oParent.Var_db42 -= this.oCPU.AX.Word;

			L3a72:
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L3a7e;
				goto L5cd0;

			L3a7e:
				this.oCPU.CMPWord(this.oCPU.DX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L3a86;
				goto L5cd0;

			L3a86:
				this.oParent.Var_aa_Rectangle.FontID = 2;

				// Instruction address 0x1d12:0x3a9f, size: 5
				F0_1d12_70cb_FillRectangleWithPattern(211, 1, 317, 97);

				local_106 = 2;
				local_e4 = 2;
				local_40 = 0;
				local_b4 = 0;

				if (local_da != 0)
					goto L3b80;

				local_bc = 0;

				goto L3ad3;

			L3acf:
				local_bc++;

			L3ad3:
				if (local_bc >= 21)
					goto L3b80;

				if (this.oParent.GameState.WonderCityID[local_bc + 1] != cityID)
					goto L3b7d;

				local_e8 = local_bc + 24;

				// Instruction address 0x1d12:0x3b09, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.BuildingDefinitions[local_e8 + 1].Name);

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

			L3b7d:
				goto L3acf;

			L3b80:
				local_fe = 0;

				this.oCPU.AX.Word = (ushort)((short)local_da);

				local_bc = local_da;

				goto L3b95;

			L3b91:
				local_bc++;

			L3b95:
				if (local_bc >= 24)
					goto L3c83;

				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Word = (ushort)((short)local_bc);
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.DX.Word;

				this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
				this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

				this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
				if (this.oCPU.Flags.NE) goto L3bc9;
				goto L3c80;

			L3bc9:
				if (local_106 < 0x10)
					goto L3be9;

				local_ca |= 2;
				local_ca &= 0x7ffffffe;

				this.oCPU.AX.Word = (ushort)((short)local_bc);

				local_fe = local_bc;
				goto L3c83;

			L3be9:
				local_b4++;

				// Instruction address 0x1d12:0x3bfb, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					309, local_e4 + 1,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xb << 1) + 0xd4ce)));

				// Instruction address 0x1d12:0x3c12, size: 5
				this.oParent.MSCAPI.strcpy(0xba06,
					this.oParent.GameState.BuildingDefinitions[local_bc + 1].Name);

				// Instruction address 0x1d12:0x3c22, size: 5
				this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 56);

				// Instruction address 0x1d12:0x3c3d, size: 5
				this.oParent.MSCAPI.strupr(0xba06);

				// Instruction address 0x1d12:0x3c46, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 253, local_e4 + 2, 15);

				// Instruction address 0x1d12:0x3c6f, size: 5
				F0_1d12_7045((short)(local_bc + 1), (short)(((local_106 & 1) != 0) ? 213 : 233), (short)(local_e4 - 2));

				local_e4 += 6;
				local_106++;

			L3c80:
				goto L3b91;

			L3c83:
				// Instruction address 0x1d12:0x3c97, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
					231, 0, 250, 0, 0);

				// Instruction address 0x1d12:0x3cb3, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
					231, 1, 250, 1, 1);

				if ((local_ca & 2) != 0)
				{
					// Instruction address 0x1d12:0x3cdd, size: 5
					F0_1d12_71bf(287, 88, 315, 96, 0x262a, 9);
				}

				// Instruction address 0x1d12:0x3d01, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 309, 2, 8, 96, 14, 12);

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L3d1b;
				goto L3d36;

			L3d1b:
				this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost);

				local_de = this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost;

				goto L3d54;

			L3d36:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CX.Word = 0x1e;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price);
				local_de = this.oCPU.AX.Word;

			L3d54:
				// Instruction address 0x1d12:0x3d7a, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(((local_de - 1) / 10) + 1, ((city.ShieldsCount - 1) / 100) + 1, 99);

				local_44 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x50;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Word = (ushort)((short)local_4a);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_4a);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)((short)local_e8));
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)local_44);
				this.oCPU.DX.Word = this.oCPU.CX.Word;
				this.oCPU.CX.Low = 0x3;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x8);
				this.oCPU.CX.Word = this.oCPU.DX.Word;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.BX.Word = (ushort)((short)local_44);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
				local_f6 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_de);
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = (ushort)((short)local_44);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.CX.Low = 0x3;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
				local_fc = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x3ded, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
					230, 99, local_f6 + 3, local_fc + 19, 1);

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L3e59;

				// Instruction address 0x1d12:0x3e31, size: 5
				F0_1d12_71bf(231, 106, 263, 114, (ushort)(((city.StatusFlag & 0x10) != 0) ? 0x262f : 0x2635), 9);

				// Instruction address 0x1d12:0x3e51, size: 5
				F0_1d12_71bf(294, 106, 311, 114, 0x263c, 9);

			L3e59:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L3e6b;
				goto L3e99;

			L3e6b:
				// Instruction address 0x1d12:0x3e8e, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					264, 100,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((((byte)city.CurrentProductionID +
						(this.Var_6548_PlayerID << 5) + 0x40) << 1) + 0xd4ce)));
				goto L3ee5;

			L3e99:
				// Instruction address 0x1d12:0x3eb5, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Name);

				// Instruction address 0x1d12:0x3ec5, size: 5
				this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, 0x56);

				// Instruction address 0x1d12:0x3edd, size: 5
				this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 274, 100, 15);

			L3ee5:
				// Instruction address 0x1d12:0x3ef9, size: 5
				F0_1d12_710d_FillRectangleWithPattern(231, 116, local_f6 + 1, local_fc + 1);

				local_ea = 0;

				goto L3f0e;

			L3f0a:
				local_ea++;

			L3f0e:
				this.oCPU.AX.Word = (ushort)((short)local_ea);
				
				if (city.ShieldsCount <= local_ea)
					goto L3f60;

				// Instruction address 0x1d12:0x3f55, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
					this.oParent.Var_aa_Rectangle,
					(((local_ea % (local_4a * local_44)) * local_e8) / local_44) + 232,
					((local_ea / (local_4a * local_44)) * 8) + 117,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));
				goto L3f0a;

			L3f60:
				// Instruction address 0x1d12:0x3f7b, size: 5
				if (city.ActualSize != 0)
				{
					this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(80 / city.ActualSize, 1, 8);
				}
				else
				{
					this.oCPU.AX.Word = 1;
				}

				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x50;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Word = (ushort)((short)local_4a);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				local_fc = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x3fb5, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
					2, 106, 91, (local_4a * local_fc) + 12, 1);

				// Instruction address 0x1d12:0x3fcd, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Food Storage", 8, 108, 15);

				// Instruction address 0x1d12:0x3ffc, size: 5
				F0_1d12_710d_FillRectangleWithPattern(3, 115, (city.ActualSize * local_e8) + 9, (local_4a * local_fc) + 2);

				this.oCPU.TESTWord(city.BuildingFlags0, 0x4);
				if (this.oCPU.Flags.NE) goto L4016;
				goto L4043;

			L4016:
				// Instruction address 0x1d12:0x403b, size: 5
				this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 5, 155, (city.ActualSize * local_e8) + 9, 155, 1);

			L4043:
				local_ea = 0;

				goto L4050;

			L404c:
				local_ea++;

			L4050:
				// Instruction address 0x1d12:0x406a, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(city.FoodCount, 0, (city.ActualSize + 1) * local_4a);

				if ((short)this.oCPU.AX.Word <= local_ea)
					goto L40ba;

				// Instruction address 0x1d12:0x40af, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					((local_ea % (city.ActualSize + 1)) * local_e8) + 4,
					((local_ea / (city.ActualSize + 1)) * local_fc) + 116,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
				goto L404c;

			L40ba:
				// Instruction address 0x1d12:0x40ca, size: 5
				F0_1d12_70cb_FillRectangleWithPattern(2, 23, 124, 65);

				local_fc = 25;

				// Instruction address 0x1d12:0x40f0, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 2, 23, 122, 9, 1);

				// Instruction address 0x1d12:0x4108, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("City Resources", 8, local_fc, 15);

				local_fc += 8;
				local_bc = 0;

				goto L4122;

			L411e:
				local_bc++;

			L4122:
				if (local_bc >= 3)
					goto L427d;

				local_d8 = 4;

				if (local_bc != 0)
					goto L4190;

				// Instruction address 0x1d12:0x416d, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70da_Arr[local_bc],
					(city.ActualSize * 2) + (local_48 * (short)this.oParent.Var_e3c6), 999);

				// Instruction address 0x1d12:0x4181, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / ((short)this.oCPU.AX.Word + 1), 1, 8);

				local_e8 = (short)this.oCPU.AX.Word;

				goto L41b8;

			L4190:
				// Instruction address 0x1d12:0x41ac, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / (this.oParent.Var_70da_Arr[local_bc] + 1),
					1, 8);

				local_e8 = (short)this.oCPU.AX.Word;

			L41b8:
				local_ea = 0;

				goto L41c5;

			L41c1:
				local_ea++;

			L41c5:
				this.oCPU.BX.Word = (ushort)((short)local_bc);
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
				this.oCPU.AX.Word = (ushort)((short)local_ea);

				if (this.oParent.Var_70da_Arr[local_bc] <= local_ea)
					goto L411e;

				if (local_bc != 0)
					goto L420a;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)local_48);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);

				if ((city.ActualSize * 2) + (local_48 * (short)this.oParent.Var_e3c6) == local_ea)
				{
					local_d8 += 4;
				}

			L420a:
				if (local_bc != 1)
					goto L422f;

				this.oCPU.CMPWord(this.oParent.Var_d2f6, 0x0);
				if (this.oCPU.Flags.NE) goto L421e;
				goto L422f;

			L421e:
				if (local_ea == (short)this.oParent.Var_d2f6)
				{
					local_d8 += 4;
				}

			L422f:
				if (local_bc != 2)
					goto L424e;

				if ((this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0) == local_ea)
				{
					local_d8 += 2;
				}

			L424e:
				// Instruction address 0x1d12:0x4267, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
					this.oParent.Var_aa_Rectangle,
					local_d8, (local_bc * 8) + local_fc,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(((local_bc + 8) << 1) + 0xd4ce)));

				local_d8 += local_e8;

				goto L41c1;

			L427d:
				local_d8 = 8;

				// Instruction address 0x1d12:0x42a6, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					224 / (this.oParent.Var_70da_Arr[3] + (short)this.oParent.Var_70e6 + (short)this.oParent.Var_e17a + (short)this.oParent.Var_d2e0 + 2),
					1, 16);

				local_e8 = (short)this.oCPU.AX.Word;
				local_ea = 0;

				goto L42bf;

			L42bb:
				local_ea++;

			L42bf:
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[3]);
				
				if (local_ea >= this.oParent.Var_70da_Arr[3])
					goto L42f4;

				// Instruction address 0x1d12:0x42e1, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					local_d8 / 2, local_fc + 24,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xe << 1) + 0xd4ce)));

				local_d8 += local_e8;

				goto L42bb;

			L42f4:
				if (this.oParent.Var_70da_Arr[3] != 0)
				{
					local_d8 += 8;
				}
			
				this.oCPU.AX.Word = (ushort)((short)local_d8);

				local_f6 = local_d8;
				local_ea = 0;
				goto L4318;

			L4314:
				local_ea++;

			L4318:
				this.oCPU.AX.Word = this.oParent.Var_e17a;
				
				if (local_ea >= (short)this.oParent.Var_e17a)
					goto L434d;

				// Instruction address 0x1d12:0x433a, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
					this.oParent.Var_aa_Rectangle,
					local_d8 / 2, local_fc + 24,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xb << 1) + 0xd4ce)));

				local_d8 += local_e8;

				goto L4314;

			L434d:
				this.oCPU.CMPWord(this.oParent.Var_e17a, 0x0);
				if (this.oCPU.Flags.NE) goto L4357;
				goto L435c;

			L4357:
				local_d8 += 8;

			L435c:
				local_ea = 0;

				goto L4369;

			L4365:
				local_ea++;

			L4369:				
				if (local_ea >= (short)this.oParent.Var_70e6)
					goto L439e;

				// Instruction address 0x1d12:0x438b, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
					this.oParent.Var_aa_Rectangle,
					local_d8 / 2, local_fc + 24,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xc << 1) + 0xd4ce)));

				local_d8 += local_e8;

				goto L4365;

			L439e:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)local_48);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.CX.Word, (ushort)((short)this.oParent.Var_70da_Arr[0]));
				if (this.oCPU.Flags.G) goto L43c1;
				goto L4497;

			L43c1:
				// Instruction address 0x1d12:0x43ed, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
					116 / ((city.ActualSize * 2) + (local_48 * (short)this.oParent.Var_e3c6) + 1), 1, 8);

				local_e8 = (short)this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[0]);
				local_ea = this.oParent.Var_70da_Arr[0];

				goto L4407;

			L4403:
				local_ea++;

			L4407:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)local_48);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);

				if ((city.ActualSize * 2) + (local_48 * (short)this.oParent.Var_e3c6) <= local_ea)
					goto L4449;

				// Instruction address 0x1d12:0x443e, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					(local_ea * local_e8) + 8, local_fc,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x8 << 1) + 0xd4ce)));
				goto L4403;

			L4449:
				// Instruction address 0x1d12:0x448f, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
					(local_e8 * this.oParent.Var_70da_Arr[0]) + 8, local_fc,
					(((city.ActualSize * 2) + (local_48 * (short)this.oParent.Var_e3c6) - this.oParent.Var_70da_Arr[0]) * local_e8) + 4,
					8, 15, 0);

			L4497:
				this.oCPU.AX.Word = this.oParent.Var_d2f6;

				if (this.oParent.Var_70da_Arr[1] >= (short)this.oParent.Var_d2f6)
					goto L453a;

				// Instruction address 0x1d12:0x44b9, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / (this.oParent.Var_70da_Arr[1] + 1), 1, 8);

				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[1]);

				local_ea = this.oParent.Var_70da_Arr[1];

				goto L44d3;

			L44cf:
				local_ea++;

			L44d3:
				this.oCPU.AX.Word = this.oParent.Var_d2f6;
				
				if (local_ea >= (short)this.oParent.Var_d2f6)
					goto L4502;

				// Instruction address 0x1d12:0x44f7, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					(local_ea * local_e8) + 8, local_fc + 8,
					this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0x9 << 1) + 0xd4ce)));
				goto L44cf;

			L4502:
				// Instruction address 0x1d12:0x4532, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
					(this.oParent.Var_70da_Arr[1] * local_e8) + 8, local_fc + 8,
					((short)this.oParent.Var_d2f6 - this.oParent.Var_70da_Arr[1]) * local_e8,
					8, 15, 0);

			L453a:
				if (this.oParent.Var_d2e0 == 0)
					goto L45a0;

				// Instruction address 0x1d12:0x455a, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(116 / (this.oParent.Var_70da_Arr[2] + 1), 1, 8);

				local_e8 = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x4598, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
					((this.oParent.Var_70da_Arr[2] - (short)this.oParent.Var_d2e0) * local_e8) + 6,
					local_fc + 16, (local_e8 * (short)this.oParent.Var_d2e0) + 2,
					8, 15, 0);

			L45a0:
				// Instruction address 0x1d12:0x45b0, size: 5
				F0_1d12_710d_FillRectangleWithPattern(8, 8, 200, 13);

				// Instruction address 0x1d12:0x45ca, size: 5
				F0_1d12_6ed4(cityID, 8, 8, (ushort)((short)local_8), 192);

				local_f4 = (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x45f3, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((city.ActualSize * 8) + 24, 0, 128);

				local_e8 = (short)this.oCPU.AX.Word;
				local_bc = 0;

				goto L460c;

			L4608:
				local_bc++;

			L460c:
				if (local_bc >= 3)
					goto L4770;

				this.oCPU.AX.Low = (byte)city.TradeCityIDs[local_bc];
				this.oCPU.AX.High = 0;
				local_4c = city.TradeCityIDs[local_bc];

				if (local_4c == -1)
					goto L476d;

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x1d12:0x463d, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName((short)local_4c);

				// Instruction address 0x1d12:0x464d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ":+");

				if (this.oParent.GameState.Cities[local_4c].PlayerID == this.Var_6548_PlayerID)
					goto L46bb;

				// Instruction address 0x1d12:0x46b0, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.MSCAPI.itoa((short)((city.BaseTrade + this.oParent.GameState.Cities[local_4c].BaseTrade + 4) / 8), 10));

				goto L4708;

			L46bb:
				// Instruction address 0x1d12:0x4700, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.MSCAPI.itoa((short)(((short)city.BaseTrade +
						(short)this.oParent.GameState.Cities[local_4c].BaseTrade + 4) >> 4),
						10));

			L4708:
				// Instruction address 0x1d12:0x4710, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "} ");

				if (this.Var_2496 != 2)
					goto L4744;

				// Instruction address 0x1d12:0x473c, size: 5
				F0_1d12_73ea((ushort)((short)this.oParent.GameState.Cities[local_4c].Position.X),
					(ushort)((short)this.oParent.GameState.Cities[local_4c].Position.Y), 10);

			L4744:
				if (this.Var_2496 != 0)
					goto L476d;

				// Instruction address 0x1d12:0x4765, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 98, (local_bc * 6) + 179, 10);

			L476d:
				goto L4608;

			L4770:
				if (this.Var_2496 != 2)
					goto L479d;

				// Instruction address 0x1d12:0x4795, size: 5
				F0_1d12_73ea((ushort)((short)this.oParent.GameState.Cities[this.Var_653e_CityID].Position.X),
					(ushort)((short)this.oParent.GameState.Cities[this.Var_653e_CityID].Position.Y), 15);

			L479d:
				if (this.Var_2496 != 0)
					goto L4852;

				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[1]);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = this.oParent.Var_6c98;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x14);
				local_e0 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.Var_b882);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x2;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				local_e0 += (short)this.oCPU.AX.Word;

				// Instruction address 0x1d12:0x47ef, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_e0, 1, 99);

				// Instruction address 0x1d12:0x4802, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(100 / (short)this.oCPU.AX.Word, 1, 8);

				local_fc = (short)this.oCPU.AX.Word;
				local_ea = 0;

				goto L481b;

			L4817:
				local_ea++;

			L481b:
				if (local_ea >= local_e0)
					goto L4852;

				// Instruction address 0x1d12:0x4847, size: 5
				this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					(local_ea * local_fc) + 98, (local_ea & 1) + 161,
					this.oParent.Var_b2ba);
				goto L4817;

			L4852:
				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L5cbd;

				// Instruction address 0x1d12:0x4876, size: 5
				F0_1d12_71bf(284, 190, 316, 198, 0x2662, 12);

				// Instruction address 0x1d12:0x4896, size: 5
				F0_1d12_71bf(231, 190, 272, 198, 0x2667, 9);

				local_c0 = 0;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.L) goto L48b6;
				goto L48fb;

			L48b6:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xeb);
				if (this.oCPU.Flags.GE) goto L48c8;
				goto L48fb;

			L48c8:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
				this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, city.BuildingFlags0);
				this.oCPU.DX.Word = this.oCPU.ANDWord(this.oCPU.DX.Word, city.BuildingFlags1);

				this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE) goto L48f5;
				goto L48fb;

			L48f5:
				local_c0 = 1;

			L48fb:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xeb);
				if (this.oCPU.Flags.L) goto L490d;
				goto L4937;

			L490d:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xe8);
				if (this.oCPU.Flags.GE) goto L491f;
				goto L4937;

			L491f:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
				if (this.oCPU.Flags.NE) goto L4931;
				goto L4937;

			L4931:
				local_c0 = 1;

			L4937:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0xe8);
				if (this.oCPU.Flags.L) goto L4949;
				goto L496c;

			L4949:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.NEGWord(this.oCPU.BX.Word);
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

				if (this.oParent.GameState.WonderCityID[Math.Abs(city.CurrentProductionID) - 24] == -1)
					goto L496c;

				local_c0 = 1;

			L496c:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L497e;
				goto L4994;

			L497e:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitCount >= 127)
				{
					local_c0 = 1;
				}

			L4994:
				// Instruction address 0x1d12:0x4994, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

			L4999:
				this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
				if (this.oCPU.Flags.NE) goto L49a3;
				goto L49ab;

			L49a3:
				// Instruction address 0x1d12:0x49a3, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223();

				goto L4999;

			L49ab:
				this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
				if (this.oCPU.Flags.E) goto L49b5;
				goto L4a4e;

			L49b5:
				// Instruction address 0x1d12:0x49b5, size: 5
				this.oParent.MSCAPI.kbhit();

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L49c2;
				goto L4a4e;

			L49c2:
				if (local_b8 != 0)
					goto L4a4e;

				// Instruction address 0x1d12:0x49cc, size: 5
				this.oParent.Segment_11a8.F0_11a8_0223();

				if (local_c0 == 0)
					goto L4a4b;

				// Instruction address 0x1d12:0x49db, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();

				local_c0++;

				if ((local_c0 & 1) == 0)
					goto L4a16;

				// Instruction address 0x1d12:0x4a0b, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 231, 106, 32, 8, 14, 9);

				goto L4a3a;

			L4a16:
				// Instruction address 0x1d12:0x4a32, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 231, 106, 32, 8, 9, 14);

			L4a3a:
				// Instruction address 0x1d12:0x4a3a, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				// Instruction address 0x1d12:0x4a43, size: 5
				this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			L4a4b:
				goto L49ab;

			L4a4e:
				local_f0 = -1;

				// Instruction address 0x1d12:0x4a54, size: 5
				this.oParent.MSCAPI.kbhit();

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L4a61;
				goto L4a76;

			L4a61:
				// Instruction address 0x1d12:0x4a61, size: 5
				this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

				local_f0 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x0;
				this.oParent.Var_db3e = 0;
				this.oParent.Var_db3c = 0;
				goto L4a86;

			L4a76:
				if (local_b8 == 0)
					goto L4a86;

				local_f0 = 0x70;

			L4a86:
				// Instruction address 0x1d12:0x4a86, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();

				this.oCPU.CMPWord(this.oParent.Var_db3a, 0x2);
				if (this.oCPU.Flags.E) goto L4a95;
				goto L4abf;

			L4a95:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe6);
				if (this.oCPU.Flags.GE) goto L4aa0;
				goto L4abf;

			L4aa0:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x10e);
				if (this.oCPU.Flags.L) goto L4aab;
				goto L4abf;

			L4aab:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x6a);
				if (this.oCPU.Flags.GE) goto L4ab5;
				goto L4abf;

			L4ab5:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x74);
				if (this.oCPU.Flags.G) goto L4abf;
				goto L4ac9;

			L4abf:
				if (local_f0 != 0x41)
					goto L4bba;

			L4ac9:
				city.StatusFlag ^= 0x10;

				this.oCPU.TESTByte(city.StatusFlag, 0x10);
				if (this.oCPU.Flags.NE) goto L4ae8;
				goto L4baa;

			L4ae8:
				// Instruction address 0x1d12:0x4aef, size: 5
				this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

				local_102 = (short)this.oCPU.AX.Word;

				this.oParent.Var_aa_Rectangle.FontID = 2;

				if (local_102 == 0x63)
					goto L4ba7;

				this.oParent.Var_b1e8 = 0;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L4b26;
				goto L4b44;

			L4b26:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

			L4b44:
				city.CurrentProductionID = (sbyte)local_102;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L4b66;
				goto L4b84;

			L4b66:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L4b84:
				// Instruction address 0x1d12:0x4b9c, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 230, 99, 90, 100, 0);

				goto L4baa;

			L4ba7:
				goto L045f;

			L4baa:
				this.oParent.Var_70da_Arr[1] = local_10a;
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				goto L12c2;

			L4bba:
				if (local_f0 != -1)
					goto L4be2;

				this.oCPU.CMPWord(this.oParent.Var_db3a, 0x1);
				if (this.oCPU.Flags.E) goto L4bce;
				goto L4ff5;

			L4bce:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x6a);
				if (this.oCPU.Flags.GE) goto L4bd8;
				goto L4ff5;

			L4bd8:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x74);
				if (this.oCPU.Flags.LE) goto L4be2;
				goto L4ff5;

			L4be2:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x128);
				if (this.oCPU.Flags.L) goto L4bed;
				goto L4bf7;

			L4bed:
				if (local_f0 == 0x62) goto L4bf7;
				goto L4e80;

			L4bf7:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L4c09;
				goto L4c66;

			L4c09:
				local_106 = this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Cost;

				// Instruction address 0x1d12:0x4c3d, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((10 * local_106) - city.ShieldsCount, 0, 999);

				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_e8);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)((short)local_e8));
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = 0x14;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.CX.Word = (ushort)((short)local_e8);
				this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
				local_e8 = (short)this.oCPU.AX.Word;

				goto L4cc9;

			L4c66:
				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CX.Word = 0x1e;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				local_106 = this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Price;

				// Instruction address 0x1d12:0x4ca0, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((10 * local_106) - city.ShieldsCount, 0, 999);

				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				local_e8 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Low = (byte)city.CurrentProductionID;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x15);
				if (this.oCPU.Flags.G) goto L4cc5;
				goto L4cc9;

			L4cc5:
				local_e8 += local_e8;

			L4cc9:
				this.oCPU.CMPWord((ushort)city.ShieldsCount, 0x0);
				if (this.oCPU.Flags.E) goto L4cdb;
				goto L4cdf;

			L4cdb:
				local_e8 += local_e8;

			L4cdf:
				// Instruction address 0x1d12:0x4ce7, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Cost to complete\n");

				if (city.CurrentProductionID >= 0)
				{
					// Instruction address 0x1d12:0x4d17, size: 5
					this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.UnitDefinitions[city.CurrentProductionID].Name);
				}
				else
				{
					// Instruction address 0x1d12:0x4d3e, size: 5
					this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.BuildingDefinitions[-city.CurrentProductionID].Name);
				}

				// Instruction address 0x1d12:0x4d4e, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ": $");

				// Instruction address 0x1d12:0x4d6f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(local_e8, 10));

				// Instruction address 0x1d12:0x4d7f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\nTreasury: $");

				// Instruction address 0x1d12:0x4da6, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins, 10));

				// Instruction address 0x1d12:0x4db6, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\n");

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L4dd0;
				goto L4df5;

			L4dd0:
				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.NE) goto L4de2;
				goto L4df5;

			L4de2:
				// Instruction address 0x1d12:0x4dea, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "CIVIL DISORDER\n");
				goto L4e18;

			L4df5:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins < local_e8)
					goto L4e18;

				// Instruction address 0x1d12:0x4e10, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " Yes\n No\n");

			L4e18:
				// Instruction address 0x1d12:0x4e18, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				this.oParent.Var_aa_Rectangle.FontID = 1;

				// Instruction address 0x1d12:0x4e32, size: 5
				this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 100, 80, 1);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L4e42;
				goto L4e78;

			L4e42:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins < local_e8)
					goto L4e78;

				this.oCPU.AX.Word = 0xa;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)((short)local_106));
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				city.ShieldsCount = (short)this.oCPU.CX.Word;
				
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins -= (short)local_e8;

			L4e78:
				// Instruction address 0x1d12:0x4e78, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();

				goto L045f;

			L4e80:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe6);
				if (this.oCPU.Flags.GE) goto L4e8b;
				goto L4e96;

			L4e8b:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x10e);
				if (this.oCPU.Flags.GE) goto L4e96;
				goto L4ea0;

			L4e96:
				if (local_f0 == 0x63) goto L4ea0;
				goto L4f37;

			L4ea0:
				city.StatusFlag &= 0xef;

				// Instruction address 0x1d12:0x4ead, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L4ec4;
				goto L4ee2;

			L4ec4:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

			L4ee2:
				// Instruction address 0x1d12:0x4ee9, size: 5
				this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

				this.oCPU.CX.Word = this.oCPU.AX.Word;
				city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L4f11;
				goto L4f2f;

			L4f11:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L4f2f:
				// Instruction address 0x1d12:0x4f2f, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();

				goto L045f;

			L4f37:
				if (local_f0 == 0x69) goto L4f41;
				goto L4f4a;

			L4f41:
				this.Var_2496 = 0;
				goto L4faf;

			L4f4a:
				if (local_f0 == 0x68) goto L4f54;
				goto L4f5d;

			L4f54:
				this.Var_2496 = 1;
				goto L4faf;

			L4f5d:
				if (local_f0 == 0x6d) goto L4f67;
				goto L4f70;

			L4f67:
				this.Var_2496 = 2;
				goto L4faf;

			L4f70:
				if (local_f0 == 0x76) goto L4f7a;
				goto L4f83;

			L4f7a:
				this.Var_2496 = 3;
				goto L4faf;

			L4f83:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x60);
				if (this.oCPU.Flags.GE) goto L4f8d;
				goto L4ff5;

			L4f8d:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe0);
				if (this.oCPU.Flags.L) goto L4f98;
				goto L4ff5;

			L4f98:
				this.oCPU.AX.Word = this.oParent.Var_db3c;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x60);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x5;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);

				this.Var_2496 = this.oCPU.AX.Word;

			L4faf:
				this.oParent.Var_70da_Arr[1] = local_10a;
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				if (this.Var_2496 != 3)
					goto L4ff2;

				this.oParent.Var_aa_Rectangle.FontID = 1;

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				this.oParent.CityView.F19_0000_0000(cityID, -1);

				this.oParent.Var_6b64 = 1;
				this.Var_2496 = 0;

				goto L045f;

			L4ff2:
				goto L12c2;

			L4ff5:
				if (local_f0 == 0x61) goto L4fff;
				goto L520e;

			L4fff:
				local_106 = 0;

			L5005:
				if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status & 0xcf) != 0)
					goto L5039;

				this.oCPU.AX.Word = (ushort)((short)local_4e);

				if (local_106 >= local_4e)
					goto L5039;

				local_106++;

				goto L5005;

			L5039:
				this.oCPU.AX.Word = (ushort)((short)local_4e);
				
				if (local_106 != local_4e)
					goto L504b;

				local_106 = 0;

			L504b:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = 0x6;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.AX.Word = this.oCPU.DX.Word;
				this.oCPU.CX.Word = 0x12;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x64);
				local_fa = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = 0x6;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.CX.Low = 0x4;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x74);
				local_100 = (short)this.oCPU.AX.Word;

			L5078:
				// Instruction address 0x1d12:0x5088, size: 5
				F0_1d12_710d_FillRectangleWithPattern(local_fa, local_100, 16, 16);

				// Instruction address 0x1d12:0x5094, size: 5
				this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

				// Instruction address 0x1d12:0x50b1, size: 5
				this.oParent.Segment_2aea.F0_2aea_0fb3(this.Var_6548_PlayerID, (short)Arr_74[local_106], local_fa, local_100);

				// Instruction address 0x1d12:0x50bd, size: 5
				this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

				// Instruction address 0x1d12:0x50c5, size: 5
				this.oParent.MSCAPI.kbhit();

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L50d2;
				goto L5078;

			L50d2:
				// Instruction address 0x1d12:0x50d2, size: 5
				this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

				local_fc = (short)this.oCPU.AX.Word;
				
				goto L5121;

			L50e2:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);

				local_ea = local_106 + 1;

				goto L5144;

			L50ee:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);

				local_ea = local_106 - 1;

				goto L5144;

			L50fa:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);

				local_ea = local_106 + 6;

				goto L5144;

			L5108:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x6);

				local_ea = local_106 - 6;

				goto L5144;

			L5116:
				this.oCPU.AX.Word = (ushort)((short)local_106);

				local_ea = local_106;

				goto L5144;

			L5121:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
				if (this.oCPU.Flags.NE) goto L5129;
				goto L5108;

			L5129:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b00);
				if (this.oCPU.Flags.NE) goto L5131;
				goto L50ee;

			L5131:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d00);
				if (this.oCPU.Flags.NE) goto L5139;
				goto L50e2;

			L5139:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
				if (this.oCPU.Flags.NE) goto L5141;
				goto L50fa;

			L5141:
				goto L5116;

			L5144:
				// Instruction address 0x1d12:0x5151, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_ea, 0, local_4e - 1);

				local_106 = (short)this.oCPU.AX.Word;

				if (local_fc == 0xd)
					goto L5171;

				if (local_fc != 0x20)
					goto L51f4;

			L5171:
				if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status & 0x9) == 0)
					goto L51bc;

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].RemainingMoves =
					(short)(this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].TypeID].MoveCount * 3);

			L51bc:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status &= 0x30;
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].GoToPosition.X = -1;

			L51f4:
				if (local_fc != 0x1b)
					goto L504b;

				this.oParent.Var_70da_Arr[1] = local_10a;
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				goto L12c2;

			L520e:
				if (local_f0 == 0x73) goto L5218;
				goto L532e;

			L5218:
				this.oCPU.TESTByte(city.StatusFlag, 0x80);
				if (this.oCPU.Flags.E) goto L522a;
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
				this.oParent.MSCAPI.kbhit();

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L52b5;
				goto L5230;

			L52b5:
				// Instruction address 0x1d12:0x52b5, size: 5
				this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

				local_fc = (short)this.oCPU.AX.Word;

				goto L52e0;

			L52c5:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);

				local_ea = local_106 + 1;

				goto L52f3;

			L52d1:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);

				local_ea = local_106 - 1;

				goto L52f3;

			L52e0:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
				if (this.oCPU.Flags.NE) goto L52e8;
				goto L52d1;

			L52e8:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
				if (this.oCPU.Flags.NE) goto L52f3;
				goto L52c5;

			L52f3:
				// Instruction address 0x1d12:0x5301, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_ea, 0, local_b4 - 1);

				local_106 = (short)this.oCPU.AX.Word;

				if (local_fc == 0xd)
					goto L5740;

				if (local_fc == 0x20)
					goto L5740;

				if (local_fc != 0x1b)
					goto L5230;

			L532e:
				if (local_f0 < 0x31)
					goto L53c8;

				if (local_f0 > 0x39)
					goto L53c8;

				this.oCPU.AX.Word = (ushort)((short)local_f0);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x31);
				local_ea = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_8);
				
				if (local_ea >= local_8)
					goto L045f;

				this.oCPU.CMPByte((byte)city.ActualSize, 0x5);
				if (this.oCPU.Flags.GE) goto L536b;
				goto L53ad;

			L536b:
				// Instruction address 0x1d12:0x536f, size: 5
				F0_1d12_6da1_GetSpecialWorkerFlags(local_ea);

				local_e8 = (short)this.oCPU.AX.Word;

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
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				goto L12c2;

			L53c8:
				if (local_f0 == 0x70) goto L53d2;
				goto L563f;

			L53d2:
				if (local_b8 != 0)
					goto L53ed;

				this.oCPU.AX.Word = 0x0;

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
				this.oParent.MSCAPI.kbhit();

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L54b4;
				goto L53ed;

			L54b4:
				local_f6 = local_b6;
				local_fc = local_be;

				// Instruction address 0x1d12:0x54c4, size: 5
				this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

				local_e8 = (short)this.oCPU.AX.Word;
				
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
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4b00);
				if (this.oCPU.Flags.NE) goto L5527;
				goto L550a;

			L5527:
				if (this.oCPU.Flags.LE) goto L552c;
				goto L5547;

			L552c:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4700);
				if (this.oCPU.Flags.NE) goto L5534;
				goto L5511;

			L5534:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
				if (this.oCPU.Flags.NE) goto L553c;
				goto L54d4;

			L553c:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4900);
				if (this.oCPU.Flags.NE) goto L556a;
				goto L54db;

			L5547:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4d00);
				if (this.oCPU.Flags.NE) goto L554f;
				goto L54e6;

			L554f:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4f00);
				if (this.oCPU.Flags.NE) goto L5557;
				goto L54ff;

			L5557:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
				if (this.oCPU.Flags.NE) goto L555f;
				goto L54f8;

			L555f:
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5100);
				if (this.oCPU.Flags.NE) goto L556a;
				goto L54ed;

			L556a:
				// Instruction address 0x1d12:0x556e, size: 5
				this.oParent.MSCAPI.abs((short)local_b6);

				if (Math.Abs(local_b6) > 2)
					goto L55f5;

				// Instruction address 0x1d12:0x5582, size: 5
				this.oParent.MSCAPI.abs((short)local_be);

				if (Math.Abs(local_be) > 2)
					goto L55f5;

				// Instruction address 0x1d12:0x5596, size: 5
				this.oParent.MSCAPI.abs((short)local_be);

				this.oCPU.SI.Word = this.oCPU.AX.Word;
				// Instruction address 0x1d12:0x55a4, size: 5
				this.oParent.MSCAPI.abs((short)local_b6);

				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
				if (this.oCPU.Flags.L) goto L55b6;
				goto L55f5;

			L55b6:
				this.oCPU.AX.Word = (ushort)((short)city.Position.X);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)((short)local_b6));

				this.oCPU.BX.Word = (ushort)((short)city.Position.Y);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, (ushort)((short)local_be));

				this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.AX.Word, this.oCPU.BX.Word];

				this.oCPU.DX.Word = 0x1;
				this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
				this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				if (this.oCPU.Flags.E) goto L55f5;
				goto L5605;

			L55f5:
				local_b6 = local_f6;

				this.oCPU.AX.Word = (ushort)((short)local_fc);

				local_be = local_fc;

			L5605:
				if (local_e8 == 13)
					goto L5619;

				if (local_e8 != 32)
					goto L562c;

			L5619:
				local_f6 = local_b6;

				this.oCPU.AX.Word = (ushort)((short)local_be);

				local_fc = local_be;

				goto L5aa6;

			L562c:
				if (local_e8 != 27)
					goto L53ed;

				local_b8 = 0;

				goto L045f;

			L563f:
				if (local_f0 == 0x4d) goto L5649;
				goto L5671;

			L5649:
				if ((local_ca & 2) == 0)
					goto L5671;

				local_ca ^= 1;
				local_da = local_fe;
				this.oParent.Var_70da_Arr[1] = local_10a;
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				goto L12c2;

			L5671:
				if (local_f0 != 0x72) goto L567b;
				goto L56a6;

			L567b:
				this.oCPU.CMPWord(this.oParent.Var_db3a, 0x1);
				if (this.oCPU.Flags.E) goto L5685;
				goto L56c8;

			L5685:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0xe7);
				if (this.oCPU.Flags.GE) goto L5690;
				goto L56c8;

			L5690:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0xbe);
				if (this.oCPU.Flags.G) goto L569b;
				goto L56c8;

			L569b:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x10e);
				if (this.oCPU.Flags.L) goto L56a6;
				goto L56c8;

			L56a6:
				// Instruction address 0x1d12:0x56a6, size: 5
				this.oParent.Segment_1403.F0_1403_4545();

				this.oParent.Var_aa_Rectangle.FontID = 1;

				this.oParent.Overlay_23.F23_0000_0000(cityID);

				this.oParent.Var_6b64 = 1;

				goto L045f;

			L56c8:
				this.oCPU.CMPWord(this.oParent.Var_db3a, 0x1);
				if (this.oCPU.Flags.E) goto L56d2;
				goto L5cc2;

			L56d2:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x120);
				if (this.oCPU.Flags.GE) goto L56dd;
				goto L5719;

			L56dd:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x60);
				if (this.oCPU.Flags.L) goto L56e7;
				goto L5719;

			L56e7:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x58);
				if (this.oCPU.Flags.G) goto L56f1;
				goto L5719;

			L56f1:
				if ((local_ca & 2) == 0)
					goto L5719;

				local_ca ^= 1;
				local_da = local_fe;
				this.oParent.Var_70da_Arr[1] = local_10a;
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				goto L12c2;

			L5719:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x12c);
				if (this.oCPU.Flags.GE) goto L5724;
				goto L58ac;

			L5724:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x5e);
				if (this.oCPU.Flags.L) goto L572e;
				goto L58ac;

			L572e:
				this.oCPU.AX.Word = this.oParent.Var_db3e;
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = 0x6;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)local_40));
				local_106 = (short)this.oCPU.AX.Word;

			L5740:
				this.oCPU.AX.Word = (ushort)((short)local_da);

				local_bc = local_da;

				goto L574f;

			L574b:
				local_bc++;

			L574f:
				if (local_bc >= 24)
					goto L58ac;

				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Word = (ushort)((short)local_bc);
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.DX.Word;

				this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
				this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

				this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
				if (this.oCPU.Flags.NE) goto L5783;
				goto L574b;

			L5783:
				this.oCPU.AX.Word = (ushort)((short)local_106);
				local_106--;

				if (this.oCPU.AX.Word != 0)
					goto L574b;

				this.oCPU.TESTByte(city.StatusFlag, 0x80);
				if (this.oCPU.Flags.E) goto L57a5;
				goto L574b;

			L57a5:
				// Instruction address 0x1d12:0x57ad, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Do you want to sell\nyour ");

				// Instruction address 0x1d12:0x57c4, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.GameState.BuildingDefinitions[local_bc + 1].Name);

				// Instruction address 0x1d12:0x57d4, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " for ");

				// Instruction address 0x1d12:0x5802, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.MSCAPI.itoa(10 *
						this.oParent.GameState.BuildingDefinitions[local_bc + 1].Price, 10));

				// Instruction address 0x1d12:0x5812, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "$?\n No.\n Yes.\n");

				this.oParent.Var_aa_Rectangle.FontID = 1;

				// Instruction address 0x1d12:0x5823, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				// Instruction address 0x1d12:0x5834, size: 5
				this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 128, 80, 1);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
				if (this.oCPU.Flags.E) goto L5844;
				goto L58a1;

			L5844:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins +=
					(short)(10 * this.oParent.GameState.BuildingDefinitions[local_bc + 1].Price);

				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Word = (ushort)((short)local_bc);
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.DX.Word;

				uint uiTemp = (uint)((long)city.BuildingFlags0 | ((long)city.BuildingFlags1 << 16));
				uint uiTemp1 = (uint)((long)this.oCPU.CX.Word | ((long)this.oCPU.BX.Word << 16));
				uiTemp -= uiTemp1;
				city.BuildingFlags0 = (ushort)(uiTemp & 0xffff);
				city.BuildingFlags1 = (ushort)((uiTemp & 0xffff0000) >> 16);

				city.StatusFlag |= 0x80;

				this.oCPU.AX.Word = (ushort)((short)local_bc);
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);

				if (local_bc + 1 != 8)
					goto L58a1;

				this.oParent.Var_6b64 = 1;

			L58a1:
				// Instruction address 0x1d12:0x58a1, size: 5
				this.oParent.Segment_11a8.F0_11a8_0268();

				goto L045f;

			L58ac:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0xc8);
				if (this.oCPU.Flags.L) goto L58b7;
				goto L596b;

			L58b7:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x14);
				if (this.oCPU.Flags.L) goto L58c1;
				goto L596b;

			L58c1:
				this.oCPU.CMPByte((byte)city.ActualSize, 0x5);
				if (this.oCPU.Flags.GE) goto L58d3;
				goto L5953;

			L58d3:
				this.oCPU.AX.Word = this.oParent.Var_db3c;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x10);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = (ushort)((short)local_f4);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				local_ea = (short)this.oCPU.AX.Word;

				local_ea -= city.ActualSize - local_50;

				if (local_ea < 0)
					goto L045f;

				this.oCPU.AX.Word = (ushort)((short)local_8);
				
				if (local_ea >= local_8)
					goto L045f;

				// Instruction address 0x1d12:0x5915, size: 5
				F0_1d12_6da1_GetSpecialWorkerFlags(local_ea);

				local_e8 = (short)this.oCPU.AX.Word;

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
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				goto L12c2;

			L596b:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x64);
				if (this.oCPU.Flags.GE) goto L5975;
				goto L5a60;

			L5975:
				this.oCPU.CMPWord(this.oParent.Var_db3c, 0x2580);
				if (this.oCPU.Flags.L) goto L5980;
				goto L5a60;

			L5980:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x74);
				if (this.oCPU.Flags.GE) goto L598a;
				goto L5a60;

			L598a:
				this.oCPU.AX.Word = this.oParent.Var_db3e;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x74);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x4;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x6;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = this.oParent.Var_db3c;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x64);
				this.oCPU.BX.Word = this.oCPU.CX.Word;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x4;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
				local_106 = (short)this.oCPU.BX.Word;

				this.oCPU.AX.Word = (ushort)((short)local_4e);

				if (local_106 >= local_4e)
					goto L5a60;

				if ((this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status & 0x9) == 0)
					goto L5a18;

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].RemainingMoves =
					(short)(this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].TypeID].MoveCount * 3);

			L5a18:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].Status &= 0x30;
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Units[Arr_74[local_106]].GoToPosition.X = -1;

				this.oParent.Var_70da_Arr[1] = local_10a;
				this.oCPU.AX.Word = (ushort)((short)local_a);
				this.oParent.Var_70da_Arr[2] = local_a;

				goto L12c2;

			L5a60:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x18);
				if (this.oCPU.Flags.GE) goto L5a6a;
				goto L5cc2;

			L5a6a:
				this.oCPU.CMPWord(this.oParent.Var_db3e, 0x68);
				if (this.oCPU.Flags.L) goto L5a74;
				goto L5cc2;

			L5a74:
				this.oCPU.AX.Word = this.oParent.Var_db3c;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x4;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xa);
				local_f6 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = this.oParent.Var_db3e;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x18);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x4;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
				local_fc = (short)this.oCPU.AX.Word;

			L5aa6:
				// Instruction address 0x1d12:0x5aae, size: 5
				local_ea = F0_1d12_000a_FindCityOffset(new GPoint(local_f6, local_fc));

				if (local_ea == -1)
					goto L045f;

				if (local_ea >= 20)
					goto L045f;

				this.oCPU.AX.Word = (ushort)((short)(city.Position.X + this.oParent.CityOffsets[local_ea].X));

				this.oCPU.BX.Word = (ushort)((short)(city.Position.Y + this.oParent.CityOffsets[local_ea].Y));

				this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.AX.Word, this.oCPU.BX.Word];

				this.oCPU.DX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				if (this.oCPU.Flags.NE) goto L5b13;
				goto L045f;

			L5b13:
				this.oParent.Var_70da_Arr[1] = local_10a;
				this.oCPU.AX.Word = (ushort)((short)local_a);
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
				F0_1d12_692d(cityID, local_ea, flag);

				this.oCPU.CMPWord(this.oParent.Var_e8b8, 0x0);
				if (this.oCPU.Flags.NE)
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
				F0_1d12_6abc(
					city.Position.X + this.oParent.CityOffsets[local_ea].X,
					city.Position.Y + this.oParent.CityOffsets[local_ea].Y,
					(ushort)((short)local_bc));

				local_cc = (short)this.oCPU.AX.Word;

				this.oParent.Var_70da_Arr[local_bc] -= local_cc;

				goto L5bf2;

			L5c45:
				// Instruction address 0x1d12:0x5c69, size: 5
				this.oParent.Segment_2aea.F0_2aea_03ba(
					city.Position.X + this.oParent.CityOffsets[local_ea].X,
					city.Position.Y + this.oParent.CityOffsets[local_ea].Y);

				this.oParent.Var_e8b8++;
				local_50++;

			L5c78:
				city.WorkerFlags &= 0x3ffffff;
				city.WorkerFlags |= (uint)((uint)local_50 << 26);

				if (local_ae > 0) goto L045f;
				goto L12c2;

			L5cbd:
				// Instruction address 0x1d12:0x5cbd, size: 5
				this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			L5cc2:
				this.oParent.Var_d4cc_XPos = (short)local_c2;
				this.oParent.Var_d75e_YPos = (short)local_d0;

			L5cd0:
				this.oCPU.AX.Word = (ushort)flag;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE)
					goto L68cc;

				if (this.Var_6548_PlayerID == 0)
					goto L62d8;

				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e2);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
				local_e8 = (short)this.oCPU.AX.Word;

				if (local_e8 >= 0)
					goto L5f3f;

				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.E)
					goto L5df3;

				// Instruction address 0x1d12:0x5d14, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Civil Disorder in\n");

				// Instruction address 0x1d12:0x5d1f, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x5d2f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "! Mayor\nflees in panic.\n");

				// Instruction address 0x1d12:0x5d3b, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

				this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
				if (this.oCPU.Flags.NE) goto L5d4d;
				goto L5d9f;

			L5d4d:
				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.E) goto L5d5f;
				goto L5d9f;

			L5d5f:
				this.oCPU.CMPWord(this.oParent.Var_6b92, 0x0);
				if (this.oCPU.Flags.E) goto L5d69;
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
				this.oParent.Var_2f9e_Unknown = 0x4;

				// Instruction address 0x1d12:0x5db1, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			L5db9:
				// Instruction address 0x1d12:0x5dbd, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.E) goto L5dd7;
				goto L5df3;

			L5dd7:
				this.oParent.Var_b1e8 = 1;

				this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x1);
				if (this.oCPU.Flags.NE) goto L5de7;
				goto L5df3;

			L5de7:
				this.oParent.Help.F4_0000_02d3(0x2708);

			L5df3:
				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.E) goto L5e05;
				goto L5eb4;

			L5e05:
				city.StatusFlag |= 1;
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.E) goto L5e24;
				goto L5ea1;

			L5e24:
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L5e36;
				goto L5e54;

			L5e36:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

			L5e54:
				// Instruction address 0x1d12:0x5e5b, size: 5
				this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

				this.oCPU.CX.Word = this.oCPU.AX.Word;

				city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L5e83;
				goto L5ea1;

			L5e83:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L5ea1:
				// Instruction address 0x1d12:0x5ea9, size: 5
				this.oParent.Segment_1403.F0_1403_3ed7(local_d8, local_e4);

				goto L606c;

			L5eb4:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 5)
					goto L606c;

				// Instruction address 0x1d12:0x5ec8, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x24, 0);

				// Instruction address 0x1d12:0x5ed8, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Discontented citizens of\n");

				// Instruction address 0x1d12:0x5ee3, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x5ef3, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " revolt:\nGovernment Collapses!\n");

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L5f20;

				this.oParent.Overlay_21.F21_0000_0000(cityID);

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Diplomacy[0] |= 4;

			L5f20:
				// Instruction address 0x1d12:0x5f28, size: 5
				this.oParent.Segment_2517.F0_2517_04a1(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x5f34, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

				goto L606c;

			L5f3f:
				if (local_e8 < 0)
					goto L604f;

				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.NE) goto L5f5b;
				goto L604f;

			L5f5b:
				city.StatusFlag &= 0xfe;
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.NE) goto L5f7a;
				goto L5fc2;

			L5f7a:
				this.oParent.Var_2f9e_Unknown = 0x4;

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
				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L5fd4;
				goto L5ff2;

			L5fd4:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]--;

			L5ff2:
				// Instruction address 0x1d12:0x5ff9, size: 5
				this.oParent.Segment_1ade.F0_1ade_0421(this.Var_6548_PlayerID, cityID);

				this.oCPU.CX.Word = this.oCPU.AX.Word;

				city.CurrentProductionID = (sbyte)this.oCPU.CX.Low;

				this.oCPU.CMPByte((byte)city.CurrentProductionID, 0x0);
				if (this.oCPU.Flags.GE) goto L6021;
				goto L603f;

			L6021:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].UnitsInProduction[city.CurrentProductionID]++;

			L603f:
				// Instruction address 0x1d12:0x6047, size: 5
				this.oParent.Segment_1403.F0_1403_3ed7(local_d8, local_e4);

			L604f:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L605f;
				goto L606c;

			L605f:
				this.oCPU.AX.Word = this.oParent.Var_e17a;
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins += (short)this.oCPU.AX.Word;

			L606c:
				if (this.oParent.Var_70e4 != 0)
					goto L6213;

				this.oCPU.CMPByte((byte)city.ActualSize, 0x2);
				if (this.oCPU.Flags.G) goto L6088;
				goto L6213;

			L6088:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				
				if ((short)this.oCPU.AX.Word > this.oParent.Var_70e2)
					goto L6213;

				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L60b4;
				goto L6213;

			L60b4:
				this.oCPU.TESTByte(city.StatusFlag, 0x40);
				if (this.oCPU.Flags.E) goto L60c6;
				goto L61ac;

			L60c6:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.NE) goto L60d8;
				goto L619c;

			L60d8:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L60e8;
				goto L619c;

			L60e8:
				// Instruction address 0x1d12:0x60f0, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "'We love the ");

				this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType;
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
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

				if ((this.oParent.GameState.GameSettingFlags & 0x8) != 0)
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
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType >= 4) goto L61bc;
				goto L6210;

			L61bc:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)((short)local_48);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oParent.Var_e3c6);
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.CX.Word, (ushort)((short)this.oParent.Var_70da_Arr[0]));
				if (this.oCPU.Flags.L) goto L61df;
				goto L6210;

			L61df:
				this.oCPU.CMPByte((byte)city.ActualSize, 0xa);
				if (this.oCPU.Flags.GE) goto L61f1;
				goto L6204;

			L61f1:
				this.oCPU.TESTWord(city.BuildingFlags0, 0x100);
				if (this.oCPU.Flags.NE) goto L6204;
				goto L6210;

			L6204:
				city.ActualSize++;

			L6210:
				goto L62d8;

			L6213:
				if (local_e8 < 0)
					goto L62d8;

				this.oCPU.TESTByte(city.StatusFlag, 0x40);
				if (this.oCPU.Flags.NE) goto L622f;
				goto L62d8;

			L622f:
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)this.Var_6548_PlayerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.NE) goto L6241;
				goto L62cb;

			L6241:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L6251;
				goto L62cb;

			L6251:
				// Instruction address 0x1d12:0x6255, size: 5
				this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x23, 0);

				// Instruction address 0x1d12:0x6265, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "'We love the ");

				this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType;
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
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
				this.oCPU.AX.Word = this.oParent.Var_70e6;
				local_e8 = (short)this.oParent.Var_70e6;

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L635d;

				if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID != -1) goto L62f5;
				goto L630d;

			L62f5:
				// Instruction address 0x1d12:0x62fd, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID,
					this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.E)
					goto L630d;

				goto L6327;

			L630d:
				if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID == -1) goto L6317;
				goto L635d;

			L6317:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress != 0) goto L6327;
				goto L635d;

			L6327:
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID = -1;
				this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x8);
				if (this.oCPU.Flags.NE) goto L6337;
				goto L6351;

			L6337:
				// Instruction address 0x1d12:0x6337, size: 5
				this.oParent.Segment_11a8.F0_11a8_0280();

				// Instruction address 0x1d12:0x6344, size: 5
				this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x634c, size: 5
				this.oParent.Segment_11a8.F0_11a8_0294();

			L6351:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress = 0;

			L635d:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType == 0)
				{
					local_e8 = 0;
				}

				this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)local_e8;

				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID && this.oParent.GameState.DifficultyLevel == 0)
				{
					if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID >= 0 &&
						(this.oParent.GameState.TechnologyFirstDiscoveredBy[this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CurrentResearchID] & 7) != 0)
					{
						this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)local_e8;
					}
				}

				// Instruction address 0x1d12:0x63c2, size: 5
				F0_1d12_6c97(this.Var_6548_PlayerID, 0x14);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE) goto L63d2;
				goto L63e5;

			L63d2:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress += (short)(local_e8 / 2);

			L63e5:
				if (this.Var_6548_PlayerID == this.oParent.GameState.HumanPlayerID)
					goto L63fb;

				this.oCPU.AX.Word = 0xe;
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.DifficultyLevel);
				goto L6403;

			L63fb:
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.DifficultyLevel;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);

			L6403:
				local_f4 = (short)this.oCPU.AX.Word;
				local_f4 += (short)this.oParent.Var_d2de;

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L6441;

				this.oCPU.AX.Word = 0xb;
				this.oCPU.AX.Word -= (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;

				if ((11 - this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount) <= local_f4)
					goto L6441;

				this.oCPU.AX.Word = 0xb;
				this.oCPU.AX.Word -= (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;

				local_f4 = 11 - this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;

			L6441:
				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L6457;

				this.oCPU.CMPWord(this.oParent.Var_b1e8, 0x0);
				if (this.oCPU.Flags.E) goto L6457;
				goto L64b8;

			L6457:
				if (this.oParent.GameState.Year < 0)
				{
					this.oCPU.CX.Word = 0x1;
				}
				else
				{
					this.oCPU.CX.Word = 0x2;
				}

				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)((short)local_f4));
				this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.G) goto L6488;
				goto L64b8;

			L6488:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].ResearchProgress = 0;
				this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x8);
				if (this.oCPU.Flags.NE) goto L649e;
				goto L64b8;

			L649e:
				// Instruction address 0x1d12:0x649e, size: 5
				this.oParent.Segment_11a8.F0_11a8_0280();

				// Instruction address 0x1d12:0x64ab, size: 5
				this.oParent.Segment_1ade.F0_1ade_1584(this.Var_6548_PlayerID, 0);

				// Instruction address 0x1d12:0x64b3, size: 5
				this.oParent.Segment_11a8.F0_11a8_0294();

			L64b8:
				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e2));
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Score += (short)this.oCPU.AX.Word;

				if (this.Var_6548_PlayerID != this.oParent.GameState.HumanPlayerID)
					goto L68cc;

				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70da_Arr[1]);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.CX.Word = this.oParent.Var_6c98;
				this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x14);
				local_e0 = (short)this.oCPU.AX.Word;

				this.oCPU.AX.Low = (byte)city.ActualSize;
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.Var_b882);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.CX.Word = 0x2;
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				local_e0 += (short)this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].DiscoveredTechnologyCount;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.DifficultyLevel);
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x100);
				this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);

				// Instruction address 0x1d12:0x6530, size: 5
				this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.RNG.Next(this.oCPU.AX.Word);

				this.oCPU.CX.Word = (ushort)((short)local_e0);
				this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
				this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.G) goto L6545;
				goto L6640;

			L6545:
				// Instruction address 0x1d12:0x6549, size: 5
				this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.RNG.Next(20);

				local_e8 = (short)this.oCPU.AX.Word;

				local_c6 = this.oParent.CityOffsets[local_e8].X + local_d8;
				local_d2 = this.oParent.CityOffsets[local_e8].Y + local_e4;

				// Instruction address 0x1d12:0x6581, size: 5
				this.oParent.Segment_2aea.F0_2aea_1585(local_c6, local_d2);

				this.oCPU.TESTByte(this.oCPU.AX.Low, 0x40);
				if (this.oCPU.Flags.E) goto L6590;
				goto L6640;

			L6590:
				// Instruction address 0x1d12:0x6598, size: 5
				this.oParent.Segment_2aea.F0_2aea_134a(local_c6, local_d2);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
				if (this.oCPU.Flags.NE) goto L65a8;
				goto L6640;

			L65a8:
				// Instruction address 0x1d12:0x65b0, size: 5
				this.oParent.Segment_2aea.F0_2aea_1585(local_c6, local_d2);

				this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
				if (this.oCPU.Flags.E) goto L65bf;
				goto L6640;

			L65bf:
				// Instruction address 0x1d12:0x65c7, size: 5
				F0_1d12_6d33(local_c6, local_d2);

				// Instruction address 0x1d12:0x65e3, size: 5
				this.oParent.Segment_2aea.F0_2aea_0008(this.oParent.GameState.HumanPlayerID, local_c6 - 8, local_d2 - 6);

				// Instruction address 0x1d12:0x65f3, size: 5
				this.oParent.Segment_2aea.F0_2aea_11d4(local_c6, local_d2);

				this.oParent.Var_2f9e_Unknown = 0x6;

				// Instruction address 0x1d12:0x6609, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Pollution near ");

				// Instruction address 0x1d12:0x6614, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x6624, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				// Instruction address 0x1d12:0x6638, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 64);

			L6640:
				this.oCPU.TESTByte(city.StatusFlag, 0x1);
				if (this.oCPU.Flags.NE) goto L6652;
				goto L672d;

			L6652:
				this.oCPU.TESTWord(city.BuildingFlags1, 0x10);
				if (this.oCPU.Flags.NE) goto L6665;
				goto L672d;

			L6665:
				// Instruction address 0x1d12:0x6669, size: 5
				this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI.RNG.Next(3);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L6679;
				goto L672d;

			L6679:
				// Instruction address 0x1d12:0x6681, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.FusionPower);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.E)
					goto L6691;

				goto L672d;

			L6691:
				// Instruction address 0x1d12:0x66a5, size: 5
				this.oParent.Segment_2aea.F0_2aea_0008(this.oParent.GameState.HumanPlayerID, local_d8 - 8, local_e4 - 6);

				this.oParent.Overlay_22.F22_0000_0967(local_d8, local_e4);

				// Instruction address 0x1d12:0x66c5, size: 5
				this.oParent.Segment_29f3.F0_29f3_0ec3(local_d8, local_e4);

				city.BuildingFlags0 &= 0xffff;
				city.BuildingFlags1 &= 0xffef;

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

				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Word = (ushort)((short)local_bc);
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.DX.Word;

				this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, city.BuildingFlags0);
				this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, city.BuildingFlags1);

				this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.CX.Word);
				if (this.oCPU.Flags.NE) goto L676e;
				goto L6736;

			L676e:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType != 0) goto L677e;
				goto L6736;

			L677e:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins -=
					(short)this.oParent.GameState.BuildingDefinitions[local_bc + 1].Maintenance;

				if (local_bc != 1)
					goto L680b;

				if (this.oParent.GameState.DifficultyLevel < 2)
					goto L67b3;

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

			L67b3:
				if (this.oParent.GameState.DifficultyLevel < 4)
					goto L67c7;

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

			L67c7:
				// Instruction address 0x1d12:0x67cf, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Gunpowder);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L67df;

				goto L67e9;

			L67df:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

			L67e9:
				// Instruction address 0x1d12:0x67f1, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.Var_6548_PlayerID, (int)TechnologyEnum.Combustion);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.NE)
					goto L6801;

				goto L680b;

			L6801:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins--;

			L680b:
				if (this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins < 0) goto L681b;
				goto L6736;

			L681b:
				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins = 0;
				this.oCPU.AX.Word = 0x1;
				this.oCPU.DX.Word = 0x0;
				this.oCPU.CX.Word = (ushort)((short)local_bc);
				this.oCPU.DWordToWords(this.oCPU.AX, this.oCPU.DX, this.oCPU.WordsToDWord(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

				this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
				this.oCPU.DX.Word = this.oCPU.NOTWord(this.oCPU.DX.Word);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.BX.Word = this.oCPU.DX.Word;

				city.BuildingFlags0 &= this.oCPU.CX.Word;
				city.BuildingFlags1 &= this.oCPU.BX.Word;
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x1d12:0x6856, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				// Instruction address 0x1d12:0x6866, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\ncan't maintain\n");

				// Instruction address 0x1d12:0x687d, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.GameState.BuildingDefinitions[local_bc + 1].Name);

				// Instruction address 0x1d12:0x688d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".\n");

				this.oParent.Var_2f9e_Unknown = 0x4;

				// Instruction address 0x1d12:0x68a7, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

				this.oParent.GameState.Players[this.Var_6548_PlayerID].Coins +=
					(short)(10 * this.oParent.GameState.BuildingDefinitions[local_bc + 1].Price);

				goto L6736;

			L68cc:
				this.oCPU.TESTByte(city.StatusFlag, 0x4);
				if (this.oCPU.Flags.NE) goto L68de;
				goto L690f;

			L68de:
				// ??? this playerID reference needs to be checked!
				// Instruction address 0x1d12:0x68f4, size: 5
				this.oParent.Segment_1866.F0_1866_18d0(city.PlayerID,
					city.Position.X,
					city.Position.Y);

				this.oCPU.CMPWord(this.oCPU.AX.Word, 0x0);
				if (this.oCPU.Flags.E) goto L6904;
				goto L690f;

			L6904:
				// Instruction address 0x1d12:0x6907, size: 5
				this.oParent.Segment_1866.F0_1866_00c6(cityID);

			L690f:
				this.oParent.Var_aa_Rectangle.FontID = 1;

				// Instruction address 0x1d12:0x6918, size: 5
				this.oParent.Segment_11a8.F0_11a8_0250();

				this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e2);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
			}

		L6927:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_0045");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="cityOffset"></param>
		/// <param name="flag"></param>
		public void F0_1d12_692d(short cityID, int cityOffset, short flag)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_692d({cityID}, {cityOffset}, {flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);

			this.oCPU.AX.Word = (ushort)((short)(this.oParent.GameState.Cities[cityID].Position.X + this.oParent.CityOffsets[cityOffset].X));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(this.oParent.GameState.Cities[cityID].Position.Y + this.oParent.CityOffsets[cityOffset].Y));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			if (flag != 1 || flag < 0)
				goto L69bb;

			// Instruction address 0x1d12:0x696f, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L6981:
			// Instruction address 0x1d12:0x698b, size: 3
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.L) goto L6981;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x4);
			if (this.oCPU.Flags.G) goto L69a8;
			this.oCPU.AX.Word = 0x8;
			goto L69b6;

		L69a8:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x6);
			if (this.oCPU.Flags.G) goto L69b3;
			this.oCPU.AX.Word = 0x5;
			goto L69b6;

		L69b3:
			this.oCPU.AX.Word = 0x3;

		L69b6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			goto L69e5;

		L69bb:
			this.Var_2494 = 1;

			// Instruction address 0x1d12:0x69dd, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				(ushort)this.oParent.GameState.Cities[cityID].PlayerID);

		L69e5:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			goto L6a00;

		L69f2:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L69f8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			goto L6a22;

		L69fd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6a00:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3);
			if (this.oCPU.Flags.GE) goto L6a76;

			// Instruction address 0x1d12:0x6a10, size: 3
			F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oParent.Var_70da_Arr[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))] += (short)this.oCPU.AX.Word;

		L6a22:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
			if (this.oCPU.Flags.LE) goto L69fd;

			if (flag != 1 || flag < 0)
				goto L69fd;

			// Instruction address 0x1d12:0x6a5d, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				161 + (this.oParent.CityOffsets[cityOffset].X * 16) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				57 + (this.oParent.CityOffsets[cityOffset].Y * 16) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x8) << 1) + 0xd4ce)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L69f2;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x8));
			goto L69f8;

		L6a76:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.NE) goto L6ab0;

			if (flag != 1 || flag < 0)
				goto L6ab0;

			// Instruction address 0x1d12:0x6aa8, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				165 + (this.oParent.CityOffsets[cityOffset].X * 16),
				61 + (this.oParent.CityOffsets[cityOffset].Y * 16),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((0xd << 1) + 0xd4ce)));

		L6ab0:
			this.Var_2494 = 0;
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_692d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F0_1d12_6abc(int xPos, int yPos, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6abc({xPos}, {yPos}, {param3})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x1d12:0x6ac9, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(xPos, yPos);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L6ad8;
			goto L6c90;

		L6ad8:
			// Instruction address 0x1d12:0x6ade, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x6af0, size: 5
			this.oParent.Segment_2aea.F0_2aea_1836(xPos, yPos);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L6b0d;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = param3;

			switch (param3)
			{
				case 0:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[12 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Food;
					break;

				case 1:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[12 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Production;
					break;

				case 2:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[12 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Trade;
					break;

				default:
					throw new Exception("Unknown terrain field");
			}

			goto L6b1c;

		L6b0d:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = param3;

			switch (param3)
			{
				case 0:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Food;
					break;

				case 1:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Production;
					break;

				case 2:
					this.oCPU.AX.Low = (byte)this.oParent.GameState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Trade;
					break;

				default:
					throw new Exception("Unknown terrain field");
			}

		L6b1c:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x1d12:0x6b26, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
			if (this.oCPU.Flags.NE) goto L6b53;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.G) goto L6b43;
			this.oCPU.AX.Word = 0x2;
			goto L6b46;

		L6b43:
			this.oCPU.AX.Word = 0x4;

		L6b46:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1);
			if (this.oCPU.Flags.E) goto L6b53;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8));

		L6b53:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xa);
			if (this.oCPU.Flags.E) goto L6baa;
			this.oCPU.CMPWord(param3, 0x0);
			if (this.oCPU.Flags.NE) goto L6b77;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x2);
			if (this.oCPU.Flags.E) goto L6b77;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xffff;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.TerrainMultipliers[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Multi1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L6b77:
			this.oCPU.CMPWord(param3, 0x1);
			if (this.oCPU.Flags.NE) goto L6b95;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
			if (this.oCPU.Flags.E) goto L6b95;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xffff;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 
				(ushort)this.oParent.GameState.TerrainMultipliers[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Multi3);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L6b95:
			this.oCPU.CMPWord(param3, 0x2);
			if (this.oCPU.Flags.NE) goto L6baa;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.E) goto L6baa;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.G) goto L6baa;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6baa:
			this.oCPU.CMPWord(param3, 0x1);
			if (this.oCPU.Flags.NE) goto L6bd6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.E) goto L6bbc;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xb);
			if (this.oCPU.Flags.NE) goto L6bd6;

		L6bbc:
			this.oCPU.AX.Word = 0x7;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)xPos);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xb;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)yPos);
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, this.oCPU.AX.Low);
			this.oCPU.TESTByte(this.oCPU.CX.Low, 0x2);
			if (this.oCPU.Flags.E) goto L6bd6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L6bd6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L6bf6;
			this.oCPU.CMPWord(param3, 0x2);
			if (this.oCPU.Flags.NE) goto L6bf6;

			// Instruction address 0x1d12:0x6be7, size: 3
			F0_1d12_6cf3(3);

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.Var_653e_CityID);
			if (this.oCPU.Flags.NE) goto L6bf6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6bf6:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.E) goto L6c07;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L6c07:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x2);
			if (this.oCPU.Flags.LE) goto L6c39;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.Var_653e_CityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oParent.GameState.Cities[this.Var_653e_CityID].StatusFlag, 0x40);
			if (this.oCPU.Flags.NE) goto L6c39;

			if (this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType <= 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			}

			this.oCPU.CMPWord(this.Var_2494, 0x0);
			if (this.oCPU.Flags.E) goto L6c39;

			this.oParent.Var_e3c2 -= 2;

		L6c39:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L6c77;
			this.oCPU.CMPWord(param3, 0x2);
			if (this.oCPU.Flags.NE) goto L6c77;
			this.oCPU.CMPWord(this.Var_2494, 0x0);
			if (this.oCPU.Flags.E) goto L6c50;
			
			this.oParent.Var_db42++;

		L6c50:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.Var_653e_CityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oParent.GameState.Cities[this.Var_653e_CityID].StatusFlag, 0x40);
			if (this.oCPU.Flags.E) goto L6c65;
			this.oCPU.AX.Word = 0x2;
			goto L6c68;

		L6c65:
			this.oCPU.AX.Word = 0x4;

		L6c68:
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Players[this.Var_6548_PlayerID].GovernmentType);
			if (this.oCPU.Flags.G) goto L6c77;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6c77:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x40);
			if (this.oCPU.Flags.E) goto L6c89;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L6c89:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L6c92;

		L6c90:
			this.oCPU.AX.Word = 0;

		L6c92:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6abc");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="wonderID"></param>
		/// <returns></returns>
		public ushort F0_1d12_6c97(short playerID, short wonderID)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6c97({playerID}, {wonderID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			goto L6ca7;

		L6ca4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6ca7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L6cc9;

			// Instruction address 0x1d12:0x6cb9, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(int)this.oParent.GameState.BuildingDefinitions[24 + wonderID].ObsoletesAfterTechnology);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L6ca4;

		L6cc5:
			this.oCPU.AX.Word = 0;
			goto L6cef;

		L6cc9:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.WonderCityID[wonderID];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L6cc5;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].PlayerID != playerID) goto L6cc5;

			this.oCPU.AX.Word = 0x1;

		L6cef:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6c97");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Returns a CityID that has a Wonder
		/// </summary>
		/// <param name="wonderID"></param>
		/// <returns></returns>
		public ushort F0_1d12_6cf3(short wonderID)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6cf3({wonderID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			goto L6d03;

		L6d00:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6d03:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L6d26;

			// Instruction address 0x1d12:0x6d15, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(int)this.oParent.GameState.BuildingDefinitions[24 + wonderID].ObsoletesAfterTechnology);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L6d00;

			this.oCPU.AX.Word = 0xffff;
			goto L6d2f;

		L6d26:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.WonderCityID[wonderID];

		L6d2f:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6cf3");

			return this.oCPU.AX.Word;
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
			this.oParent.Segment_2aea.F0_2aea_1585(xPos, yPos);

			if ((this.oCPU.AX.Word & 0x40) == 0)
			{
				// Instruction address 0x1d12:0x6d52, size: 5
				this.oParent.Segment_2aea.F0_2aea_1653(0x40, xPos, yPos);

				// Instruction address 0x1d12:0x6d60, size: 5
				this.oParent.Segment_2aea.F0_2aea_1601(xPos, yPos);

				this.oParent.GameState.PollutedSquareCount++;
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
				this.oParent.GameState.Cities[this.Var_653e_CityID].SpecialWorkerFlags &= (ushort)(~(0x3 << (position * 2)));

				this.oParent.GameState.Cities[this.Var_653e_CityID].SpecialWorkerFlags |= (ushort)((flag & 0x3) << (position * 2));
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
				this.oCPU.AX.Word = (ushort)((this.oParent.GameState.Cities[this.Var_653e_CityID].SpecialWorkerFlags >> (position * 2)) & 0x3);
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
		/// <param name="param1"></param>
		/// <returns></returns>
		public ushort F0_1d12_6dcc(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6dcc({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L6ddc:
			// Instruction address 0x1d12:0x6de0, size: 3
			F0_1d12_6da1_GetSpecialWorkerFlags(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, param1);
			if (this.oCPU.Flags.NE) goto L6dee;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L6dee:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L6ddc;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6dcc");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="param2"></param>
		public void F0_1d12_6dfe(short cityID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6dfe({cityID}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x1d12:0x6e16, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e2, 0, this.oParent.GameState.Cities[cityID].ActualSize);

			this.oParent.Var_70e2 = (short)this.oCPU.AX.Word;
			goto L6e34;

		L6e23:
			this.oCPU.AX.Word = this.Var_6542;

			if (this.oParent.Var_70e4 >= (short)this.Var_6542)
				goto L6e3b;

			this.Var_6542--;
			this.oParent.Var_70e4++;

		L6e34:
			this.oCPU.CMPWord(this.Var_6542, 0x0);
			if (this.oCPU.Flags.NE) goto L6e23;

		L6e3b:
			// Instruction address 0x1d12:0x6e98, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e4, 0, this.oParent.GameState.Cities[cityID].ActualSize);

			goto L6e94;

		L6e4e:
			this.oCPU.CMPWord(this.Var_6542, 0x0);
			if (this.oCPU.Flags.E) goto L6e5b;
			this.Var_6542--;
			goto L6e7f;

		L6e5b:
			this.oParent.Var_70e2--;
			
			// Instruction address 0x1d12:0x6e74, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e2, 0, this.oParent.GameState.Cities[cityID].ActualSize);

			this.oParent.Var_70e2 = (short)this.oCPU.AX.Word;

		L6e7f:
			this.oParent.Var_70e4--;

			// Instruction address 0x1d12:0x6e98, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Var_70e4, 0, this.oParent.GameState.Cities[cityID].ActualSize);

		L6e94:
			this.oParent.Var_70e4 = (short)this.oCPU.AX.Word;

			// Instruction address 0x1d12:0x6ebb, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.GameState.Cities[cityID].ActualSize - (short)param2, 0, 99);

			this.oCPU.CX.Word = (ushort)((short)this.oParent.Var_70e2);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, (ushort)((short)this.oParent.Var_70e4));
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L6ed2;
			goto L6e4e;

		L6ed2:
			this.oCPU.BP.Word = this.oCPU.PopWord();
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
		/// <param name="param5"></param>
		/// <returns></returns>
		public ushort F0_1d12_6ed4(short cityID, short xPos, short yPos, ushort param4, ushort param5)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_6ed4({cityID}, {xPos}, {yPos}, {param4}, {param5})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x7;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, param5);
			if (this.oCPU.Flags.LE) goto L6f04;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = param5;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			goto L6f09;

		L6f04:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x7);

		L6f09:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L6f37;

		L6f10:
			// Instruction address 0x1d12:0x6f26, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 1) + 0x6e96)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L6f37:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e2);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L6f10;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L6f49;
			xPos += 2;

		L6f49:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L6f77;

		L6f50:
			// Instruction address 0x1d12:0x6f66, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 1) + 0x6e9a)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L6f77:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, param4);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)((short)this.oParent.Var_70e4));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			if (this.oCPU.Flags.G) goto L6f50;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L6f9e;
			xPos += 2;

		L6f9e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L6ff6;

		L6fa5:
			// Instruction address 0x1d12:0x6fbb, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) & 1) << 1) + 0x6e9e)));

			this.oCPU.AX.Word = this.Var_6542;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L6fed;

			// Instruction address 0x1d12:0x6fe5, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 12, 14, 5, 12);

		L6fed:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L6ff6:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_70e4);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L6fa5;
			xPos += 4;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L7036;

		L7009:
			// Instruction address 0x1d12:0x700d, size: 3
			F0_1d12_6da1_GetSpecialWorkerFlags(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x1d12:0x7025, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.AX.Word << 1) + 0x6ea0)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			xPos += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L7036:
			this.oCPU.AX.Word = param4;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L7009;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_6ed4");

			return this.oCPU.AX.Word;
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
		public void F0_1d12_70cb_FillRectangleWithPattern(int xPos1, int yPos1, int xPos2, int yPos2)
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
		public void F0_1d12_710d_FillRectangleWithPattern(int xPos, int yPos, int width, int height)
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
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <param name="stringPtr"></param>
		/// <param name="mode"></param>
		public void F0_1d12_71bf(int xPos, int yPos, int xPos1, int yPos1, ushort stringPtr, ushort mode)
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
		public void F0_1d12_72b7()
		{
			this.oCPU.Log.EnterBlock("F0_1d12_72b7()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);

			// Instruction address 0x1d12:0x72d4, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 101, 117, 120, 75, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L73bf;

		L72e4:
			// Instruction address 0x1d12:0x72f7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				2, 2, 2);

		L72ff:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L7302:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x50);
			if (this.oCPU.Flags.L) goto L730b;
			goto L73bc;

		L730b:
			// Instruction address 0x1d12:0x731c, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].XStart +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) - 40);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L72ff;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x280c));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x65);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2810));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x76);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.CX.Word);

			// Instruction address 0x1d12:0x73a3, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L73b6;
			goto L72e4;

		L73b6:
			// Instruction address 0x1d12:0x72f7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				2, 2, 1);

			goto L72ff;

		L73bc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L73bf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x32);
			if (this.oCPU.Flags.GE) goto L73cd;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L7302;

		L73cd:
			// Instruction address 0x1d12:0x73e1, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(100, 117, 121, 75, 9);

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_72b7");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mode"></param>
		public void F0_1d12_73ea(int xPos, int yPos, ushort mode)
		{
			this.oCPU.Log.EnterBlock($"F0_1d12_73ea({xPos}, {yPos}, {mode})");

			// function body
			if (this.Var_2496 == 2)
			{
				// Instruction address 0x1d12:0x7405, size: 5
				xPos = this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
					xPos - this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].XStart + 40);

				// Instruction address 0x1d12:0x7444, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
					((xPos * 3) / 2) + 101, ((yPos * 3) / 2) + 118, 2, 2, mode);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1d12_73ea");
		}
	}
}
