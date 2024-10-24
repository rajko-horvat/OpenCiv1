using System;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class MapManagement
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		private int Var_6c96 = 0;
		private int[] Array_6dac = new int[33];
		private int[] Array_6e3e = new int[33];
		private int[] Array_df20 = new int[33];

		public MapManagement(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;

			for (int i = 0; i < this.Array_6dac.Length; i++)
			{
				Array_6dac[i] = 0;
			}

			for (int i = 0; i < this.Array_6e3e.Length; i++)
			{
				Array_6e3e[i] = 0;
			}

			for (int i = 0; i < this.Array_df20.Length; i++)
			{
				Array_df20[i] = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_0008(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0008({playerID}, {xPos}, {yPos})");

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_c;
			int local_12;
			int local_14;
			int local_16;
			int local_18;
			int local_1a;
			int local_1c;

			this.oParent.Var_1ae0 = 0;

			// Instruction address 0x2aea:0x001a, size: 5
			this.oParent.Segment_1238.F0_1238_0fea();

			// Instruction address 0x2aea:0x001f, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

			local_2 = this.oParent.Var_d20a;

			// Instruction address 0x2aea:0x002d, size: 5
			this.oParent.Var_d4cc_XPos = (short)this.oGameData.Map.WrapXPosition(xPos);

			// Instruction address 0x2aea:0x0042, size: 5
			this.oParent.Var_d75e_YPos = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(yPos, 0, 38);

			this.Var_6c96 = 0;

			// Instruction address 0x2aea:0x0062, size: 5
			local_4 = this.oParent.MSCAPI.RNG.Next(256);

			for (int i = 0; i < 256; i++)
			{
				local_18 = local_4 & 0xf;
				local_1c = local_4 / 16;

				if (local_1c < 12 && local_18 < 15)
				{
					if (this.oParent.Var_d806 != 0 ||
						this.oGameData.Map[local_18 + this.oParent.Var_d4cc_XPos, local_1c + this.oParent.Var_d75e_YPos].IsVisibleTo(playerID))
					{
						// Instruction address 0x2aea:0x0118, size: 5
						// Instruction address 0x2aea:0x0122, size: 3
						F0_2aea_11d4(this.oGameData.Map.WrapXPosition(local_18 + this.oParent.Var_d4cc_XPos), local_1c + this.oParent.Var_d75e_YPos);
					}
					else
					{
						// Instruction address 0x2aea:0x0094, size: 5
						this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 80 + (local_18 * 16), 8 + (local_1c * 16), 16, 16, 0);
					}
				}

				local_4 = ((local_4 * 5) + 1) & 0xff;
			}

			for (int i = 0; i < this.Var_6c96; i++)
			{
				if (this.Array_6e3e[i] < 184)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

					// Instruction address 0x2aea:0x0148, size: 5
					this.oParent.Segment_2459.F0_2459_08c6_GetCityName((short)this.Array_df20[i]);

					// Instruction address 0x2aea:0x015c, size: 5
					this.oParent.Segment_2f4d.F0_2f4d_04f7(0xba06, (ushort)(327 - this.Array_6dac[i]));

					// Instruction address 0x2aea:0x018d, size: 5
					this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06,
						this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.Array_6dac[i] - 8, 80, 999),
						this.Array_6e3e[i] + 16, 11);
				}
			}

			local_c = xPos - 32;
			local_12 = yPos - 19;

			// Instruction address 0x2aea:0x01b9, size: 5
			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Navigation) != 0)
			{
				local_12 = 0;
			}

			if (local_c >= 0)
			{
				local_16 = local_c;
			}
			else
			{
				local_16 = local_c + 80;
			}

			local_6 = 80;

			if (local_16 > 0)
			{
				local_6 -= local_16;
			}

			local_1a = (local_12 < 0) ? 0 : local_12;
			local_14 = local_1a - local_12;
			local_8 = 50 - local_14;

			if (local_12 > 0)
			{
				local_8 -= local_12;
			}

			this.oParent.Var_6ed6 = local_c;
			this.oParent.Var_70ea = local_12;

			// Instruction address 0x2aea:0x0233, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 8, 80, 50, 0);

			if (this.oParent.Var_d806 != 0)
			{
				// Instruction address 0x2aea:0x024c, size: 5
				local_c = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_c, 0, 16);
				this.oParent.Var_6ed6 = local_c;

				// Instruction address 0x2aea:0x0264, size: 5
				local_12 = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_12, 0, 65530);
				this.oParent.Var_70ea = local_12;

				// Instruction address 0x2aea:0x02da, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
					local_c, local_12, 80, 50, this.oParent.Var_aa_Rectangle, 0, 8);
			}
			else
			{
				// Instruction address 0x2aea:0x02af, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
					local_16 + 240, local_1a, local_6, local_8, this.oParent.Var_aa_Rectangle, 0, local_14 + 8);

				if (local_6 < 80)
				{
					// Instruction address 0x2aea:0x02da, size: 5
					this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
						240, local_1a, 80 - local_6, local_8, this.oParent.Var_aa_Rectangle, local_6, local_14 + 8);
				}
			}

			for (int i = 0; i < 128; i++)
			{
				if (this.oGameData.Cities[i].StatusFlag != 0xff &&
					(this.oGameData.Cities[i].VisibleSize != 0 || this.oGameData.Cities[i].PlayerID == this.oGameData.HumanPlayerID))
				{
					// Instruction address 0x2aea:0x031a, size: 5
					local_18 = this.oGameData.Map.WrapXPosition(this.oGameData.Cities[i].Position.X - local_16);
					local_1c = this.oGameData.Cities[i].Position.Y - local_1a + local_14;

					if (local_1c >= 0 && local_1c < 50)
					{
						// Instruction address 0x2aea:0x0355, size: 3
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(
							local_18, local_1c + 8, this.oParent.Array_1946[this.oGameData.Cities[i].PlayerID]);
					}
				}
			}

			// Instruction address 0x2aea:0x037c, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a66_DrawShadowRectangle(0, 8, 79, 49, 15, 8);

			// Instruction address 0x2aea:0x03a2, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(xPos - local_c - 1, yPos - local_12 + 7, 17, 10, 15);

			this.oParent.Var_d20a = local_2;

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0008");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_03ba(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_03ba({xPos}, {yPos})");

			// function body
			TerrainTypeEnum local_4;
			int local_6;
			int local_a;
			int local_c;
			int local_e;
			int local_12;
			int local_14;
			TerrainTypeEnum local_18;
			int local_1c;
			int local_1e;
			int local_20;
			GPoint direction;

			if (this.oParent.Var_b278 == 1)
			{
				// Instruction address 0x2aea:0x03d0, size: 3
				if ((F0_2aea_1585_GetImprovements(xPos, yPos) & 0x1) != 0)
				{
					// Instruction address 0x2aea:0x03e1, size: 3
					// Instruction address 0x2aea:0x0408, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, yPos * 4, 4, 4,
						this.oParent.Array_1946[F0_2aea_1369_GetCellUnitPlayerID(xPos, yPos)]);

				}
				else if (this.oGameData.Map[xPos, yPos].TerrainType == TerrainTypeEnum.Water) // Instruction address 0x2aea:0x041a, size: 3
				{
					// Instruction address 0x2aea:0x0408, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, yPos * 4, 4, 4, 1);
				}
				else
				{
					// Instruction address 0x2aea:0x0408, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos * 4, yPos * 4, 4, 4, 2);
				}
			}
			else
			{
				// Instruction address 0x2aea:0x0438, size: 5
				local_6 = (this.oGameData.Map.WrapXPosition(xPos - this.oParent.Var_d4cc_XPos) * 16) + 80;
				local_a = ((yPos - this.oParent.Var_d75e_YPos) * 16) + 8;

				if (local_6 > 79 && local_6 < 320 && local_a > 7 && local_a < 193)
				{
					// Instruction address 0x2aea:0x047c, size: 3
					local_18 = this.oGameData.Map[xPos, yPos].TerrainType;

					// Instruction address 0x2aea:0x048c, size: 3
					local_14 = F0_2aea_15c1_GetVisibleImprovements(xPos, yPos);

					if (this.oParent.Var_d806 != 0)
					{
						// Instruction address 0x2aea:0x04a3, size: 3
						local_14 = F0_2aea_1585_GetImprovements(xPos, yPos);
					}
				
					if (local_18 == TerrainTypeEnum.Water)
					{
						local_12 = 0;

						for (int i = 1; i < 9; i++)
						{
							local_12 /= 2;

							direction = TerrainMap.MoveOffsets[i];

							// Instruction address 0x2aea:0x0566, size: 5
							// Instruction address 0x2aea:0x0570, size: 3
							// Instruction address 0x2aea:0x0587, size: 3
							if (this.oGameData.Map.IsValidPosition(0, yPos + direction.Y) &&
								this.oGameData.Map[xPos + direction.X, yPos + direction.Y].TerrainType != TerrainTypeEnum.Water)
							{
								local_12 |= 0x80;
							}
						}

						local_e = local_12;
						local_12 = ((local_12 / 64) & 0x3) + (local_12 * 4);

						for (int i = 0; i < 4; i++)
						{
							if (i >= 2)
							{
								// Instruction address 0x2aea:0x05f4, size: 5
								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6 - ((i & 0x1) * 8) + 8, local_a + 8,
									this.oParent.Array_d294[(local_12 >> (i * 2)) & 0x7, i]);
							}
							else
							{
								// Instruction address 0x2aea:0x05f4, size: 5
								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6 + ((i & 0x1) * 8), local_a,
									this.oParent.Array_d294[(local_12 >> (i * 2)) & 0x7, i]);
							}
						}

						if (local_e == 28)
						{
							// Instruction address 0x2aea:0x0656, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 224, 100, 16, 16,
								this.oParent.Var_aa_Rectangle, local_6, local_a);
						}

						if (local_e == 193)
						{
							// Instruction address 0x2aea:0x0680, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 240, 100, 16, 16,
								this.oParent.Var_aa_Rectangle, local_6, local_a);
						}

						if (local_e == 7)
						{
							// Instruction address 0x2aea:0x06a9, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 256, 100, 16, 16,
								this.oParent.Var_aa_Rectangle, local_6, local_a);
						}

						if (local_e == 112)
						{
							// Instruction address 0x2aea:0x06d2, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 272, 100, 16, 16,
								this.oParent.Var_aa_Rectangle, local_6, local_a);
						}

						if (local_e == 143)
						{
							// Instruction address 0x2aea:0x06fc, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 288, 100, 16, 16,
								this.oParent.Var_aa_Rectangle, local_6, local_a);
						}

						if (local_e == 248)
						{
							// Instruction address 0x2aea:0x0726, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 304, 100, 16, 16,
								this.oParent.Var_aa_Rectangle, local_6, local_a);
						}

						for (int i = 1; i < 9; i += 2)
						{
							direction = TerrainMap.MoveOffsets[i];

							// Instruction address 0x2aea:0x0748, size: 5
							// Instruction address 0x2aea:0x0752, size: 3
							if (this.oGameData.Map[xPos + direction.X, yPos + direction.Y].TerrainType == TerrainTypeEnum.River)
							{
								// Instruction address 0x2aea:0x0777, size: 5
								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6, local_a, this.oParent.Array_d2d4[i / 2]);
							}
						}
					}
				
					if (local_18 != TerrainTypeEnum.Water)
					{
						// Instruction address 0x2aea:0x07cd, size: 5
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 256, 120, 16, 16,
							this.oParent.Var_aa_Rectangle, local_6, local_a);
					}

					if ((local_14 & 0x2) != 0 && local_18 != TerrainTypeEnum.Water && this.oParent.Var_dcfc == 0 && (local_14 & 0x1) == 0)
					{
						// Instruction address 0x2aea:0x07f8, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_6, local_a, this.oParent.Array_d4ce[4]);
					}

					if (local_18 == TerrainTypeEnum.River)
					{
						local_12 = 0;

						for (int i = 1; i < 9; i += 2)
						{
							local_12 /= 2;

							direction = TerrainMap.MoveOffsets[i];

							// Instruction address 0x2aea:0x082c, size: 3
							local_4 = this.oGameData.Map[xPos + direction.X, yPos + direction.Y].TerrainType;

							if (local_4 == TerrainTypeEnum.River || local_4 == TerrainTypeEnum.Water)
							{
								local_12 |= 0x8;
							}
						}

						// Instruction address 0x2aea:0x0862, size: 5
						//if ((this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150) & 0x8) == 0) goto L0872;

						if ((this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 & 0x8) != 0)
						{
							// Instruction address 0x2aea:0x0885, size: 5
							this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								local_6, local_a, this.oParent.Array_6e1e[local_12 - 1]);
						}
						else
						{
							// Instruction address 0x2aea:0x0885, size: 5
							this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								local_6, local_a, this.oParent.Array_6e00[local_12 - 1]);
						}
					}

					if (local_18 != TerrainTypeEnum.Water && local_18 != TerrainTypeEnum.River)
					{
						local_12 = 0;

						for (int i = 1; i < 9; i += 2)
						{
							local_12 /= 2;

							direction = TerrainMap.MoveOffsets[i];

							// Instruction address 0x2aea:0x08ec, size: 3
							// Instruction address 0x2aea:0x08cb, size: 5
							// Instruction address 0x2aea:0x08d5, size: 3
							if (this.oGameData.Map.IsValidPosition(0, yPos + direction.Y) &&
								this.oGameData.Map[xPos + direction.X, yPos + direction.Y].TerrainType == local_18)
							{
								local_12 |= 0x8;
							}
						}

						// Instruction address 0x2aea:0x091e, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_6, local_a,
							this.oParent.Array_b886[TerrainMap.TerrainTypeEnumToValue(local_18), local_12]);

						if (local_18 == TerrainTypeEnum.Grassland && (((xPos * 7) + (yPos * 11)) & 0x2) == 0)
						{
							// Instruction address 0x2aea:0x0996, size: 5
							this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								local_6 + 4, local_a + 4, this.oParent.Var_b880);
						}
					}

					if ((local_14 & 0x40) != 0)
					{
						// Instruction address 0x2aea:0x09bc, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_6, local_a, this.oParent.Array_d4ce[6]);
					}

					if ((local_14 & 0x8) != 0)
					{
						if ((local_14 & 0x10) != 0)
						{
							local_20 = 0;
						}
						else
						{
							local_20 = 6;
						}

						for (int i = 1; i < 9; i++)
						{
							direction = TerrainMap.MoveOffsets[i];

							// Instruction address 0x2aea:0x0a9a, size: 3
							local_1c = F0_2aea_15c1_GetVisibleImprovements(this.oGameData.Map.WrapXPosition(xPos + direction.X), yPos + direction.Y);

							if ((local_1c & 0x8) != 0)
							{
								local_20 = -1;

								if ((local_14 & 0x11) == 0 || (local_1c & 0x11) == 0)
								{
									// Instruction address 0x2aea:0x0a73, size: 5
									this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
										local_6, local_a, this.oParent.Array_b27a[i - 1]);
								}
								else
								{
									// Instruction address 0x2aea:0x0a73, size: 5
									this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
										local_6, local_a, this.oParent.Array_b29a[i - 1]);
								}
							}
						}

						if (local_20 != -1)
						{
							// Instruction address 0x2aea:0x0ae0, size: 5
							this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
								local_6 + 7, local_a + 7, 2, 2, (ushort)local_20);
						}
					}
				
					if ((local_14 & 0x4) != 0 && this.oParent.Var_dcfc == 0)
					{
						// Instruction address 0x2aea:0x0aff, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_6, local_a, this.oParent.Array_d4ce[5]);
					}
				
					// Instruction address 0x2aea:0x0b11, size: 3
					if (this.oGameData.Map[xPos, yPos].HasSpecialResources)
					{
						// Instruction address 0x2aea:0x0b28, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_6, local_a, this.oParent.Array_d4ce[TerrainMap.TerrainTypeEnumToValue(local_18) + 16]);
					}

					// Instruction address 0x2aea:0x0b3a, size: 3
					if (F0_2aea_1894(xPos, yPos, local_18) != 0)
					{
						// Instruction address 0x2aea:0x0b4e, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_6, local_a, this.oParent.Array_d4ce[31]);
					}

					if ((local_14 & 0x20) != 0)
					{
						// Instruction address 0x2aea:0x0b66, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
							local_6, local_a, this.oParent.Array_d4ce[30]);
					}

					if (this.oParent.Var_d806 == 0)
					{
						for (int i = 1; i < 9; i += 2)
						{
							direction = TerrainMap.MoveOffsets[i];

							int yTemp = yPos + direction.Y;

							if (yTemp >= 0 && yTemp < 50 && !this.oGameData.Map[xPos + direction.X, yTemp].IsVisibleTo(this.oGameData.HumanPlayerID))
							{
								// Instruction address 0x2aea:0x0bce, size: 5
								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6, local_a, this.oParent.Array_7eec[i / 2]);
							}
						}
					}
				
					// Instruction address 0x2aea:0x0be7, size: 3
					local_1e = F0_2aea_1369_GetCellUnitPlayerID(xPos, yPos);

					if ((local_14 & 0x1) != 0 && this.oParent.Var_dcfc == 0)
					{
						// Instruction address 0x2aea:0x0c09, size: 5
						local_c = (short)this.oParent.Segment_2dc4.F0_2dc4_00ba(xPos, yPos);

						if (this.oGameData.Cities[local_c].PlayerID == this.oGameData.HumanPlayerID ||
							this.oGameData.Cities[local_c].VisibleSize != 0 || this.oParent.Var_d806 != 0)
						{
							// Instruction address 0x2aea:0x0c4b, size: 5
							this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(local_6 + 1, local_a + 1, 13, 13, 15);

							// Instruction address 0x2aea:0x0c7d, size: 5
							this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(local_6 + 2, local_a + 1, 12, 12,
								this.oParent.Array_1956[this.oGameData.Cities[local_c].PlayerID]);

							// Instruction address 0x2aea:0x0cac, size: 5
							this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
								local_6 + 2, local_a + 2, 12, 12,
								this.oParent.Array_1946[this.oGameData.Cities[local_c].PlayerID]);

							// Instruction address 0x2aea:0x0cba, size: 5
							this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								local_6 + 1, local_a + 1, this.oParent.Array_d4ce[28]);

							// Instruction address 0x2aea:0x0ce5, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
								local_6 + 2, local_a + 2, 12, 12, 5,
								this.oParent.Array_1956[this.oGameData.Cities[local_c].PlayerID]);

							if (this.oGameData.Cities[local_c].PlayerID == this.oGameData.HumanPlayerID || this.oParent.Var_d806 != 0)
							{
								local_e = this.oGameData.Cities[local_c].ActualSize;
							}
							else
							{
								local_e = this.oGameData.Cities[local_c].VisibleSize;
							}

							this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

							// Instruction address 0x2aea:0x0d42, size: 5
							this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(local_e, 10));

							if ((this.oGameData.Cities[local_c].StatusFlag & 0x1) != 0)
							{
								// Instruction address 0x2aea:0x0d66, size: 5
								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6 + 5, local_a + 2, this.oParent.Array_6e96[4]);
							}
							else
							{
								// Instruction address 0x2aea:0x0d8d, size: 5
								this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, ((local_e < 10) ? 6 : 3) + local_6, local_a + 5, 0);
							}

							// Instruction address 0x2aea:0x0d9c, size: 3
							if ((short)F0_2aea_1458_GetCellActiveUnitID(xPos, yPos) != -1 || this.oGameData.Cities[local_c].Unknown[0] != -1)
							{
								// Instruction address 0x2aea:0x0dc2, size: 5
								this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(local_6, local_a, 15, 15, 0);
							}
						
							if ((this.oGameData.Cities[local_c].ImprovementFlags0 & 0x80) != 0)
							{
								// Instruction address 0x2aea:0x0de7, size: 5
								this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
									local_6 + 1, local_a + 1, this.oParent.Array_d4ce[29]);
							}

							if (this.Var_6c96 < 32)
							{
								this.Array_6dac[this.Var_6c96] = local_6;
								this.Array_6e3e[this.Var_6c96] = local_a;
								this.Array_df20[this.Var_6c96] = local_c;

								this.Var_6c96++;
							}
						}
					}

					this.oCPU.AX.Word = 1;
				}
				else
				{
					this.oCPU.AX.Word = 0;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_03ba");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_2aea_0e29(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0e29({playerID}, {unitID})");

			// function body
			int local_2;
			int local_4;
			int local_6;
			TerrainTypeEnum local_c;

			if (this.oParent.Var_b278 == 1)
			{
				if (this.oGameData.Players[playerID].Units[unitID].TypeID == 0)
				{
					// Instruction address 0x2aea:0x0e77, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
						(this.oGameData.Players[playerID].Units[unitID].Position.X * 4) + 1,
						(this.oGameData.Players[playerID].Units[unitID].Position.Y * 4) + 1,
						3, 3, 6);
				}
				else
				{
					// Instruction address 0x2aea:0x0e77, size: 5
					this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
						(this.oGameData.Players[playerID].Units[unitID].Position.X * 4) + 1,
						(this.oGameData.Players[playerID].Units[unitID].Position.Y * 4) + 1,
						3, 3, 0);
				}

				// Instruction address 0x2aea:0x0ea7, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
					this.oGameData.Players[playerID].Units[unitID].Position.X * 4,
					this.oGameData.Players[playerID].Units[unitID].Position.Y * 4,
					3, 3,
					this.oParent.Array_1946[playerID]);
			}
			else
			{
				// Instruction address 0x2aea:0x0ecd, size: 5
				local_4 = (this.oGameData.Map.WrapXPosition(this.oGameData.Players[playerID].Units[unitID].Position.X - this.oParent.Var_d4cc_XPos) * 16) + 80;
				local_6 = ((this.oGameData.Players[playerID].Units[unitID].Position.Y - this.oParent.Var_d75e_YPos) * 16) + 8;

				if (local_4 > 79 && local_4 < 320 && local_6 > 7 && local_6 < 193)
				{
					local_2 = this.oGameData.Players[playerID].Units[unitID].TypeID;

					// Instruction address 0x2aea:0x0f33, size: 3
					local_c = this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].Position].TerrainType;

					if (local_c != TerrainTypeEnum.Water ||
						(this.oGameData.Players[playerID].Units[unitID].Status & 0x1) == 0 ||
						this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air)
					{
						if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1)
						{
							// Instruction address 0x2aea:0x0f8b, size: 5
							this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
								local_4 + 1, local_6 + 1, this.oParent.Array_d4ce[(playerID << 5) + local_2 + 64]);
						}

						// Instruction address 0x2aea:0x0fa0, size: 3
						F0_2aea_0fb3(playerID, unitID, local_4, local_6);

						this.oCPU.AX.Word = 1;
					}
					else
					{
						this.oCPU.AX.Word = 0;
					}
				}
				else
				{
					this.oCPU.AX.Word = 0;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0e29");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_0fb3(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_0fb3({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x0fe2, size: 5
			this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos,
				this.oParent.Array_d4ce[this.oGameData.Players[playerID].Units[unitID].TypeID + (playerID << 5) + 64]);

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x8) != 0)
			{
				// Instruction address 0x2aea:0x0ffb, size: 5
				this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					xPos, yPos, this.oParent.Array_d4ce[29]);
			}
			else
			{
				if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x4) != 0)
				{
					if (playerID == 1)
					{
						// Instruction address 0x2aea:0x103d, size: 5
						this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA("F", xPos + 4, yPos + 7, 9);
					}
					else
					{
						// Instruction address 0x2aea:0x103d, size: 5
						this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA("F", xPos + 4, yPos + 7, 15);
					}
				}
			}

			if (playerID == this.oGameData.HumanPlayerID)
			{
				if (this.oGameData.Players[playerID].Units[unitID].GoToDestination.X != -1)
				{
					if (playerID == 1)
					{
						// Instruction address 0x2aea:0x1085, size: 5
						this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA("G", xPos + 4, yPos + 7, 9);
					}
					else
					{
						// Instruction address 0x2aea:0x1085, size: 5
						this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA("G", xPos + 4, yPos + 7, 15);
					}
				}
			}

			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0xc2) != 0 &&
				this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Water)
			{
				char local_2 = 'R';

				if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x40) != 0)
				{
					if (this.oGameData.Players[playerID].Units[unitID].TypeID != 0)
					{
						local_2 = '?';
					}
					else
					{
						local_2 = 'I';
					}
				}

				if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x80) != 0)
				{
					local_2 = 'M';

					if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x40) != 0)
					{
						local_2 = 'F';
					}

					if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x2) != 0)
					{
						local_2 = 'P';
					}
				}

				// Instruction address 0x2aea:0x1128, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "" + local_2);

				//this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, (byte)local_2);

				if (playerID == 1)
				{
					// Instruction address 0x2aea:0x1157, size: 5
					this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06, xPos + 4, yPos + 7, 9);
				}
				else
				{
					// Instruction address 0x2aea:0x1157, size: 5
					this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadowToRectAA(0xba06, xPos + 4, yPos + 7, 15);
				}

				// Instruction address 0x2aea:0x1172, size: 5
				this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(xPos - 1, yPos - 1, 15, 15, 7);
			}
		
			if ((this.oGameData.Players[playerID].Units[unitID].Status & 0x1) != 0)
			{
				// Instruction address 0x2aea:0x11a8, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 16, 16, 5, 7);

				// Instruction address 0x2aea:0x11c7, size: 5
				this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, xPos, yPos, 16, 16, 8, 7);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_0fb3");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_11d4(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_11d4({xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x11e2, size: 3
			F0_2aea_03ba(xPos, yPos);

			if (this.oParent.Var_dcfc == 0)
			{
				// Instruction address 0x2aea:0x11f6, size: 3
				int unitID = (short)F0_2aea_1458_GetCellActiveUnitID(xPos, yPos);

				if (unitID != -1)
				{
					if (this.oParent.Var_d806 != 0 || this.oParent.Var_d20a == this.oGameData.HumanPlayerID ||
						this.oGameData.Players[this.oParent.Var_d20a].Units[unitID].IsVisibleTo(this.oGameData.HumanPlayerID))
					{
						// Instruction address 0x2aea:0x123e, size: 3
						if ((F0_2aea_1585_GetImprovements(xPos, yPos) & 0x1) == 0)
						{
							// Instruction address 0x2aea:0x1250, size: 3
							F0_2aea_125b((short)this.oParent.Var_d20a, (short)unitID);
						}
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_11d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_2aea_125b(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_125b({playerID}, {unitID})");

			// function body
			int local_2;
			int local_4;

			// Instruction address 0x2aea:0x127f, size: 3
			TerrainTypeEnum local_6 = this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].Position].TerrainType;

			if (local_6 == TerrainTypeEnum.Water && this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1 &&
				this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
			{
				local_2 = unitID;
				local_4 = unitID;

				do
				{
					local_2 = this.oGameData.Players[playerID].Units[local_2].NextUnitID;

					if (this.oGameData.Static.Units[this.oGameData.Players[playerID].Units[local_2].TypeID].MovementType == UnitMovementTypeEnum.Air)
					{
						// Instruction address 0x2aea:0x12e2, size: 3
						F0_2aea_0e29(playerID, (short)local_2);

						local_2 = -1;
					}
				}
				while (local_2 != -1 && local_2 != local_4);

				if (local_2 == local_4)
				{
					// Instruction address 0x2aea:0x131b, size: 3
					F0_2aea_0e29(playerID, unitID);
				}
			}
			else
			{
				// Instruction address 0x2aea:0x131b, size: 3
				F0_2aea_0e29(playerID, (short)this.oParent.Segment_1866.F0_1866_1122(playerID, unitID));
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_125b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1369_GetCellUnitPlayerID(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x137d, size: 5
			//this.oCPU.AX.Word = (ushort)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos) & 0x7);

			int iValue = this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits & 0x7;
			this.oCPU.AX.Word = (ushort)((short)iValue);

			return iValue;
		}

		/// <summary>
		/// Sets the city owner on map
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="playerID"></param>
		public void F0_2aea_138c_MapSetCityOwner(int xPos, int yPos, short playerID)
		{
			// function body
			// Instruction address 0x2aea:0x13a2, size: 5
			// Instruction address 0x2aea:0x13c0, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 160, yPos, (byte)((this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos) & 0x8) + playerID), 0);

			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits &= 0x8;
			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits += playerID;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_13cb(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_13cb({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x13d8, size: 3
			int local_2 = (short)F0_2aea_1458_GetCellActiveUnitID(xPos, yPos);

			if (local_2 != -1)
			{
				// Instruction address 0x2aea:0x13ed, size: 5
				this.oParent.Segment_29f3.F0_29f3_0b66(playerID, unitID, (short)local_2);
			}
		
			// Instruction address 0x2aea:0x140b, size: 3
			//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, (ushort)(playerID + 8));
			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits = playerID + 0x8;

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_13cb");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1412(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1412({playerID}, {unitID}, {xPos}, {yPos})");

			// function body			
			if (this.oGameData.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				// Instruction address 0x2aea:0x1433, size: 5
				this.oParent.Segment_29f3.F0_29f3_0bc9(playerID, unitID);
			}
			else
			{
				// Instruction address 0x2aea:0x144f, size: 3
				//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, (byte)playerID);
				this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits = playerID;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1412");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_2aea_1458_GetCellActiveUnitID(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1458({xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x1466, size: 3
			int local_2 = F0_2aea_14e0_GetCellUnitPlayerID(xPos, yPos);

			if (local_2 != -1)
			{
				bool bFlag = false;

				for (int i = 0; i < 128; i++)
				{
					if (local_2 != -1 && this.oGameData.Players[local_2].Units[i].TypeID != -1 &&
						this.oGameData.Players[local_2].Units[i].Position.X == xPos && this.oGameData.Players[local_2].Units[i].Position.Y == yPos)
					{

						this.oParent.Var_d7f0 = (short)local_2;
						this.oParent.Var_d20a = local_2;
						this.oCPU.AX.Word = (ushort)((short)i);
						bFlag = true;

						break;
					}
				}

				if (!bFlag)
				{
					// Instruction address 0x2aea:0x14d3, size: 3
					//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, xPos + 160, yPos, 0);
					this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits = 0;

					this.oCPU.AX.Word = 0xffff;
				}
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1458");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_14e0_GetCellUnitPlayerID(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x14f4, size: 5
			/*this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos);

			if ((this.oCPU.AX.Word & 0x8) != 0)
			{
				this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x7);
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}*/

			int iRetVal = (this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits & 0x8) != 0 ? (this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits & 0x7) : -1;
			this.oCPU.AX.Word = (ushort)((short)iRetVal);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1511_ActiveUnitsSetFlag8(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x1525, size: 5
			// Instruction address 0x2aea:0x1539, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 160, yPos, (byte)((this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 160, yPos) & 7) + 0x8));

			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits &= 0x7;
			this.oGameData.Map[xPos, yPos].Layer9_ActiveUnits |= 0x8;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1570_CellHasRoads(int xPos, int yPos)
		{
			// function body
			// Instruction address 0x2aea:0x157a, size: 3
			int iRetVal = F0_2aea_1585_GetImprovements(xPos, yPos);
			iRetVal &= 0x8;

			this.oCPU.AX.Word = (ushort)((short)iRetVal);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1585_GetImprovements(int xPos, int yPos)
		{
			// function body
			/*// Instruction address 0x2aea:0x1597, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100);

			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x2aea:0x15b0, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150);

			this.oCPU.AX.Word <<= 4;
			this.oCPU.AX.Word |= this.oCPU.BX.Word;*/

			int iRetVal = this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 | (this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 << 4);
			this.oCPU.AX.Word = (ushort)(iRetVal & 0xff);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_15c1_GetVisibleImprovements(int xPos, int yPos)
		{
			// function body
			/*// Instruction address 0x2aea:0x15d8, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 80, yPos + 100);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x2aea:0x15ef, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos + 80, yPos + 150);

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);*/

			int iRetVal = this.oGameData.Map[xPos, yPos].Layer6_VisibleTerrainImprovements1 | (this.oGameData.Map[xPos, yPos].Layer8_VisibleTerrainImprovements2 << 4);
			this.oCPU.AX.Word = (ushort)(iRetVal & 0xff);

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_2aea_1601_UpdateVisiblemprovements(int xPos, int yPos)
		{
			// function body			
			// Instruction address 0x2aea:0x161b, size: 5
			// Instruction address 0x2aea:0x1627, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 100, (byte)this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100));

			// Instruction address 0x2aea:0x163d, size: 5
			// Instruction address 0x2aea:0x1649, size: 3
			//this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos + 80, yPos + 150, (byte)this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150));

			this.oGameData.Map[xPos, yPos].Layer6_VisibleTerrainImprovements1 = this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1;
			this.oGameData.Map[xPos, yPos].Layer8_VisibleTerrainImprovements2 = this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mask1"></param>
		public void F0_2aea_1653_ClearOrSetImprovements(int xPos, int yPos, int mask1, int mask2)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1653({xPos}, {yPos}, {mask1}, {mask2})");

			// function body
			/*if (mask1 == 0)
			{
				// Instruction address 0x2aea:0x16b7, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, 0);

				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, 0);
			}
			else if (mask1 >= 0x10)
			{
				// Instruction address 0x2aea:0x1691, size: 5
				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, (byte)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150) | (mask1 >> 4)));
			}
			else
			{
				// Instruction address 0x2aea:0x1672, size: 5
				// Instruction address 0x2aea:0x16cf, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, (byte)(this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100) | mask1));
			}*/

			if (mask1 == 0 && mask2 == 0)
			{
				this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 = 0;
				this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 = 0;
			}
			else
			{
				this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 |= mask1;
				this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 |= mask2;
			}

			if (this.oParent.Var_6b90 == this.oGameData.HumanPlayerID)
			{
				// Instruction address 0x2aea:0x16e5, size: 3
				F0_2aea_1601_UpdateVisiblemprovements(xPos, yPos);
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1653");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="mask1"></param>
		public void F0_2aea_16ee_RemoveImprovement(int xPos, int yPos, int mask1, int mask2)
		{
			// function body
			/*if ((mask & 0xf) != 0)
			{
				// Instruction address 0x2aea:0x1707, size: 5
				// Instruction address 0x2aea:0x171c, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 100, (byte)(((~mask) & this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 100)) & 0xff));
			}

			if (((mask & 0xf0) != 0))
			{
				// Instruction address 0x2aea:0x1738, size: 5
				// Instruction address 0x2aea:0x1751, size: 3
				this.oParent.Graphics.F0_VGA_0550_SetPixel(2, xPos, yPos + 150, (byte)(((~(mask >> 4)) & this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 150)) & 0xff));
			}*/

			this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 |= mask1;
			this.oGameData.Map[xPos, yPos].Layer5_TerrainImprovements1 ^= mask1;

			this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 |= mask2;
			this.oGameData.Map[xPos, yPos].Layer7_TerrainImprovements2 ^= mask2;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_175a(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_175a({xPos}, {yPos})");

			// function body
			// Instruction address 0x2aea:0x1768, size: 3
			int iRetVal = -1;

			for (int i = 0; i < 128; i++)
			{
				if (this.oGameData.Cities[i].StatusFlag != 0xff &&
					this.oGameData.Cities[i].Position.X == xPos && this.oGameData.Cities[i].Position.Y == yPos)
				{
					iRetVal = F0_2aea_1369_GetCellUnitPlayerID(xPos, yPos);

					this.oParent.Var_d7f0 = (short)iRetVal;
					this.oParent.Var_d20a = iRetVal;
					break;
				}
			}

			if (iRetVal == -1)
			{
				// Instruction address 0x2aea:0x17bf, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x2bc6, 100, 80);
			}

			this.oCPU.AX.Word = (ushort)((short)iRetVal);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_175a");

			return iRetVal;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public bool F0_2aea_1836_HasSpecialResource(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1836_HasSpecialResource({xPos}, {yPos})");

			// function body
			/*if (yPos <= 1 || yPos >= 48 || (((xPos & 3) * 4) + (yPos & 3)) != ((((xPos / 4) * 13) + ((yPos / 4) * 11) + this.oGameData.RandomSeed) & 0xf))
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}*/
			bool bTemp = this.oGameData.Map[xPos, yPos].HasSpecialResources;

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1836_HasSpecialResource");

			return bTemp;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="terrain"></param>
		public ushort F0_2aea_1894(int xPos, int yPos, TerrainTypeEnum terrain)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_1894({terrain}, {xPos}, {yPos})");

			// function body
			if (terrain == TerrainTypeEnum.Water || this.oGameData.Map[xPos, yPos].IsVisibleTo(this.oGameData.BarbarianPlayerID) ||
				yPos <= 1 || yPos >= 48)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				if (((xPos & 3) * 4 + (yPos & 3)) == ((((xPos / 4) * 13) + ((yPos / 4) * 11) + this.oGameData.RandomSeed + 8) & 0x1f) &&
					(F0_2aea_1585_GetImprovements(xPos, yPos) & 0x1) == 0)
				{
					this.oCPU.AX.Word = 1;
				}
				else
				{
					this.oCPU.AX.Word = 0;
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_1894");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_1942_GetGroupID(int xPos, int yPos)
		{
			// Instruction address 0x2aea:0x1953, size: 5
			//this.oCPU.AX.Word = this.oParent.Graphics.F0_VGA_038c_GetPixel(2, xPos, yPos + 50);

			int iTemp = this.oGameData.Map[xPos, yPos].Layer3_GroupID;
			this.oCPU.AX.Word = (ushort)((short)iTemp);

			return iTemp;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public int F0_2aea_195d_GetGroupSize(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_2aea_195d_GetGroupSize({xPos}, {yPos})");

			// function body
			/*// Instruction address 0x2aea:0x1967, size: 3
			if (F0_2aea_134a_GetMapLayer1_TerrainType(xPos, yPos) != 10)
			{
				// Instruction address 0x2aea:0x1979, size: 3
				// Land
				this.oCPU.AX.Word = (ushort)this.oGameData.Continents[F0_2aea_1942_GetContinentID(xPos, yPos)].Size;
			}
			else
			{
				// Instruction address 0x2aea:0x1990, size: 3
				// Oceans
				this.oCPU.AX.Word = (ushort)this.oGameData.Oceans[F0_2aea_1942_GetContinentID(xPos, yPos)].Size;
			}*/

			int iTemp = this.oGameData.Map.Groups[this.oGameData.Map[xPos, yPos].Layer3_GroupID].Size;
			this.oCPU.AX.Word = (ushort)((short)iTemp);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2aea_195d_GetGroupSize");

			return iTemp;
		}
	}
}
