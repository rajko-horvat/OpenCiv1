using Avalonia.Media;
using IRB.VirtualCPU;
using OpenCiv1.GPU;
using System.Diagnostics;
using System.Runtime;

namespace OpenCiv1
{
	public class GameInitAndIntro
	{
		private CivGame oParent;
		private VCPU oCPU;

		public GameInitAndIntro(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0012_GenerateMap()
		{
			this.oCPU.Log.EnterBlock("F7_0000_0012_GenerateMap()");

			// function body
			RandomMT19937 rng = new RandomMT19937(12345);

			// Instruction address 0x0000:0x0024, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(7, 1);

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67fc, 0x0);

			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd76a) != 0)
			{
				// Instruction address 0x0000:0x0049, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3b20, 1);
			}
			else
			{
				F7_0000_17cf();

				// Stage 1

				// Instruction address 0x0000:0x006b, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

				do
				{
					F7_0000_08be_TransferCloudToMap(rng);

					F7_0000_17cf();
				}
				while (((this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7ef6) * 8) * 40) + 640 > this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x67fe));

				// Instruction address 0x0000:0x009f, size: 5
				this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(0, 0, 79, 49, 0);

				// Instruction address 0x0000:0x00b7, size: 5
				this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(1, 1, 77, 47, 0);

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
							this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i + 1, j, 1);

							// Instruction address 0x0000:0x016c, size: 5
							this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j + 1, 1);

							// Instruction address 0x0000:0x017b, size: 5
							this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i + 1, j + 1, 1);

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

					F7_0000_17cf();
				}

				// Stage 2
				//this.oParent.CPU.PauseCPU();
				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						// Instruction address 0x0000:0x01e2, size: 5
						switch ((short)this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j))
						{
							case 0:
								// Instruction address 0x0000:0x01c4, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, 1);
								break;

							case 1:
								// Instruction address 0x0000:0x020b, size: 5
								// Instruction address 0x0000:0x021c, size: 5
								int local_4 = Math.Abs(rng.Next(8) + j - 29) + (1 - this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7ef8));

								if (((local_4 / 6) + 1) < 8)
								{
									switch ((local_4 / 6) + 1)
									{
										case 0:
										case 1:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, 14);
											break;

										case 2:
										case 3:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, 6);
											break;

										case 4:
										case 5:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, 7);
											break;

										case 6:
										case 7:
											// Instruction address 0x0000:0x01c4, size: 5
											this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, 15);
											break;
									}
								}
								break;

							case 2:
								// Instruction address 0x0000:0x01c4, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, 12);
								break;

							default:
								// Instruction address 0x0000:0x01c4, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, 13);
								break;
						}
					}

					F7_0000_17cf();
				}

				// Stage 3
				//this.oParent.CPU.PauseCPU();
				for (int i = 0; i < 50; i++)
				{
					// Instruction address 0x0000:0x0455, size: 5
					int local_4 = Math.Abs(25 - i);
					int local_8 = 0;

					for (int j = 0; j < 80; j++)
					{
						// Instruction address 0x0000:0x030d, size: 5
						int local_2 = (short)this.oParent.Graphics.F0_VGA_038c_GetPixel(1, j, i);

						if (local_2 != 1)
						{
							if (local_8 > 0)
							{
								// Instruction address 0x0000:0x02bd, size: 5
								local_8 -= rng.Next(-((this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7efa) * 2) - 7));

								switch (local_2)
								{
									case 6:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 10);
										break;

									case 7:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 15);
										break;

									case 12:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 2);
										break;

									case 13:
										local_8 -= 3;
										break;

									case 14:
										// Instruction address 0x0000:0x02f2, size: 5
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 6);
										break;
								}
							}
						}
						else if (Math.Abs(12 - local_4) + (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7efa) * 4) > local_8)
						{
							local_8++;
						}
					}

					local_8 = 0;

					for (int j = 79; j >= 0; j--)
					{
						// Instruction address 0x0000:0x03dc, size: 5
						int local_2 = (short)this.oParent.Graphics.F0_VGA_038c_GetPixel(1, j, i);

						if (local_2 == 1)
						{
							if (((local_4 / 2) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7efa)) > local_8)
							{
								local_8++;
							}
						}
						else
						{
							if (local_8 > 0)
							{
								// Instruction address 0x0000:0x037e, size: 5
								local_8 -= rng.Next(-((this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7efa) * 2) - 7));

								switch (local_2)
								{
									case 3:
									case 12:
										// Instruction address 0x0000:0x03c1, size: 5
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 2);
										break;

									case 6:
										// Instruction address 0x0000:0x03c1, size: 5
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 10);
										break;

									case 10:
										if (local_4 < 10)
										{
											// Instruction address 0x0000:0x0424, size: 5
											this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 11);
										}
										else
										{
											// Instruction address 0x0000:0x0424, size: 5
											this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 3);
										}

										local_8 = -2;
										break;

									case 13:
										local_8 -= 3;
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 2);
										break;

									case 14:
										// Instruction address 0x0000:0x03c1, size: 5
										this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, j, i, 6);
										break;
								}
							}
						}
					}

					F7_0000_17cf();
				}

				// Stage 4
				//this.oParent.CPU.PauseCPU();
				int iCount = 800 + (800 * this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7efc));

				int local_a = 0;
				int local_c = 0;

				for (int i = 0; i < iCount; i++)
				{
					int local_2;

					if ((i & 0x1) != 0)
					{
						// Instruction address 0x0000:0x0553, size: 5
						GPoint direction = this.oParent.MoveOffsets[rng.Next(8) + 1];

						local_a += direction.X;
						local_c += direction.Y;
					}
					else
					{
						// Instruction address 0x0000:0x0479, size: 5
						local_a = rng.Next(80);

						// Instruction address 0x0000:0x0488, size: 5
						local_c = rng.Next(50);
					}

					if (local_a >= 0 && local_a < 80 && local_c >= 0 && local_c < 50)
					{
						// Instruction address 0x0000:0x049d, size: 5
						local_2 = (short)this.oParent.Graphics.F0_VGA_038c_GetPixel(1, local_a, local_c);

						switch (local_2 - 2)
						{
							case 0:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, local_a, local_c, 11);
								break;

							case 1:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, local_a, local_c, 10);
								break;

							case 2:
							case 3:
							case 6:
							case 7:
								break;

							case 4:
							case 5:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, local_a, local_c, 12);
								break;

							case 8:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, local_a, local_c, 2);
								break;

							case 9:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, local_a, local_c, 3);
								break;

							case 10:
							case 13:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, local_a, local_c, 13);
								break;

							case 11:
								F7_0000_05d4((short)local_a, (short)local_c);
								break;

							case 12:
								// Instruction address 0x0000:0x050e, size: 5
								this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, local_a, local_c, 6);
								break;
						}
					}
				}

				/*StreamWriter writer = new StreamWriter("Map.log");
				for (int i = 0; i < 80; i++)
				{
					writer.Write("[");
					for (int j = 0; j < 50; j++)
					{
						if (j > 0)
							writer.Write(", ");

						writer.Write(this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j));
					}
					writer.WriteLine("]");
				}
				writer.WriteLine(rng.Next());
				writer.Close();*/

				// Stage 5
				//this.oParent.CPU.PauseCPU();

				F7_0000_065c(rng);

				/*Debug.WriteLine(rng.Next());
				this.oParent.CPU.PauseCPU();*/
			}

			// Instruction address 0x0000:0x058e, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 160, 0, 160, 200, 0);

			F7_0000_0a33_FinishMapConstruction(rng);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67fc, 0x1);

			while (F7_0000_17cf() != 0);

			// check generated map
			for (int i = 0; i < 80; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					int local_2 = (short)this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j);

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
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F7_0000_05d4(short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_05d4({xPos}, {yPos})");

			// function body
			if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos - 1, yPos - 1) != 1 &&
				this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos - 1, yPos + 1) != 1 &&
				this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + 1, yPos - 1) != 1 &&
				this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + 1, yPos + 1) != 1)
			{
				// Instruction address 0x0000:0x0652, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos, yPos, 1);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_05d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_065c(RandomMT19937 rng)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_065c()");

			// function body
			int local_2;
			int local_4;
			int local_10;
			int local_16;
			int local_18;
			int iMax = ((this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7ef6) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x7efa)) * 2) + 6;
			GPoint direction;
			//StreamWriter writer = new StreamWriter("Map1.log");

			for (int i = 0, j = 0; i < 256 && j < iMax; i++)
			{
				//writer.WriteLine($"{i}, {j}");

				// Instruction address 0x0000:0x0686, size: 5
				this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 160, 100, this.oParent.Var_aa_Rectangle, 160, 0);

				local_16 = 0;
				// Instruction address 0x0000:0x0697, size: 5
				int xPos = rng.Next(80);
				// Instruction address 0x0000:0x06a6, size: 5
				int yPos = rng.Next(50);

				while (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos) != 12) // Instruction address 0x0000:0x06b9, size: 5
				{
					// Instruction address 0x0000:0x0697, size: 5
					xPos = rng.Next(80);
					// Instruction address 0x0000:0x06a6, size: 5
					yPos = rng.Next(50);
				}

				int xPos1 = xPos;
				int yPos1 = yPos;

				// Instruction address 0x0000:0x06d6, size: 5
				local_18 = rng.Next(4) * 2;
				local_10 = local_18;

				do
				{
					// Instruction address 0x0000:0x06f4, size: 5
					this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos, yPos, 9);

					local_4 = 0;

					for (int k = 1; k < 9; k += 2)
					{
						direction = this.oParent.MoveOffsets[k];

						// Instruction address 0x0000:0x071f, size: 5
						if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos + direction.X, yPos + direction.Y) == 1)
						{
							local_4 = 1;
							break;
						}
					}

					local_10 = local_18;

					// Instruction address 0x0000:0x0745, size: 5
					local_18 = ((rng.Next(2) - (local_16 & 0x1)) * 2 + local_18) & 0x7;

					if ((local_10 ^ 0x4) > local_18)
					{
						// Instruction address 0x0000:0x077c, size: 5
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos, yPos + 50, 8);
					}

					direction = this.oParent.MoveOffsets[local_18 + 1];

					xPos += direction.X;
					yPos += direction.Y;

					// Instruction address 0x0000:0x07a1, size: 5
					local_2 = (short)this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos);
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
						direction = this.oParent.MoveOffsets[k];

						xPos = xPos1 + direction.X;
						yPos = yPos1 + direction.Y;

						// Instruction address 0x0000:0x0827, size: 5
						if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, xPos, yPos) == 2)
						{
							// Instruction address 0x0000:0x0842, size: 5
							this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos, yPos, 11);
						}
					}
				}

				F7_0000_17cf();
			}

			// Instruction address 0x0000:0x0893, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 50, 80, 50, this.oParent.Var_aa_Rectangle, 0, 150);

			// Instruction address 0x0000:0x08b1, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 50, 80, 50, 0);
			
			//writer.Close();

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_065c");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_08be_TransferCloudToMap(RandomMT19937 rng)
		{
			this.oCPU.Log.EnterBlock("F7_0000_08be_TransferCloudToMap()");

			// function body
			// Instruction address 0x0000:0x08da, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 160, 0, 80, 50, 0);

			// Instruction address 0x0000:0x08e6, size: 5
			// Instruction address 0x0000:0x08f8, size: 5
			F7_0000_0988_GenerateMapCloud(rng.Next(72) + 4, rng.Next(34) + 8, rng);

			for (int i = 0; i < 80; i++)
			{
				for (int j = 0; j < 50; j++)
				{
					// Instruction address 0x0000:0x093f, size: 5
					if (this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i + 160, j) != 0)
					{
						// Instruction address 0x0000:0x0956, size: 5
						// Instruction address 0x0000:0x0966, size: 5
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, i, j, (ushort)(this.oParent.Graphics.F0_VGA_038c_GetPixel(1, i, j) + 1));

						this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67fe, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67fe)));
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_08be_TransferCloudToMap");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F7_0000_0988_GenerateMapCloud(int xPos, int yPos, RandomMT19937 rng)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_0988_GenerateCloud({xPos}, {yPos})");

			// function body
			int iCloudSize = rng.Next(64) + 1;

			do
			{
				// triangle shaped cloud (Default)
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 160, yPos, 15);
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 161, yPos, 15);
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(1, xPos + 160, yPos + 1, 15);

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
			this.oCPU.Log.ExitBlock("F7_0000_0988_GenerateCloud");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0a33_FinishMapConstruction(RandomMT19937 rng)
		{
			this.oCPU.Log.EnterBlock("F7_0000_0a33_FinishMapConstruction()");

			// function body
			int[] local_a4 = new int[64];
			int local_ac;
			int local_ae = 0;
			int[] local_d0 = new int[17];

			for (int i = 0; i < 2; i++)
			{
				for (int j = 0; j < 80; j++)
				{
					for (int k = 0; k < 50; k++)
					{
						this.oParent.CivState.MapVisibility[j, k] = 0;
					}
				}

				for (int j = 0; j < 50; j++)
				{
					int local_22 = -1;
					int local_6 = 0;

					for (int k = 0; k < 80; k++)
					{
						int local_aa = (short)F7_0000_176d(k, j);

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
										local_d0[0] = this.oParent.CivState.MapVisibility[k + local_ac, j - 1];
									}
									else
									{
										local_d0[0] = this.oParent.CivState.MapVisibility[k + local_ac - 1, 49];
									}

									if (local_d0[0] != 0)
									{
										if (local_22 != -1 && local_22 != local_d0[0])
										{
											for (int l = 0; l <= j; l++)
											{
												for (int m = 0; m < 80; m++)
												{
													if (this.oParent.CivState.MapVisibility[m, l] == local_22)
													{
														this.oParent.CivState.MapVisibility[m, l] = (ushort)((short)local_d0[0]);
													}

													switch (i)
													{
														case 0:
															this.oParent.CivState.Continents[local_d0[0]].Size += this.oParent.CivState.Continents[local_22].Size;
															this.oParent.CivState.Continents[local_22].Size = 0;
															break;

														case 1:
															this.oParent.CivState.Oceans[local_d0[0]].Size += this.oParent.CivState.Oceans[local_22].Size;
															this.oParent.CivState.Oceans[local_22].Size = 0;
															break;

														default:
															throw new IndexOutOfRangeException("Continent selector out of range");
													}
												}
											}
										}

										local_22 = local_d0[0];

										F7_0000_17cf();
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
											if (this.oParent.CivState.Continents[local_ae].Size != 0)
												goto L0bac;

											break;

										case 1:
											if (this.oParent.CivState.Oceans[local_ae].Size != 0)
												goto L0bac;

											break;

										default:
											throw new IndexOutOfRangeException("Continent selector out of range");
									}
								}

								local_22 = local_ae;
							}

							this.oParent.CivState.MapVisibility[k, j] = (ushort)((short)local_22);

							switch (i)
							{
								case 0:
									this.oParent.CivState.Continents[local_22].Size++;
									break;

								case 1:
									this.oParent.CivState.Oceans[local_22].Size++;
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

					F7_0000_17cf();
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
								if (this.oParent.CivState.Continents[local_d0[k + 1]].Size >= this.oParent.CivState.Continents[j].Size)
									flag = true;
								break;

							case 1:
								if (this.oParent.CivState.Oceans[local_d0[k + 1]].Size >= this.oParent.CivState.Oceans[j].Size)
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
						if (local_a4[this.oParent.CivState.MapVisibility[j, k]] != 0)
						{
							// Instruction address 0x0000:0x0d67, size: 5
							this.oParent.Segment_1000.F0_1000_104f_SetPixel(j, k + 50, (ushort)((short)local_a4[this.oParent.CivState.MapVisibility[j, k]]));
						}
					}
				}

				for (int j = 1; j < 15; j++)
				{
					switch (i)
					{
						case 0:
							local_d0[j + 1] = this.oParent.CivState.Continents[local_d0[j + 1]].Size;
							break;

						case 1:
							local_d0[j + 1] = this.oParent.CivState.Oceans[local_d0[j + 1]].Size;
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
							this.oParent.CivState.Continents[j].Size = (short)local_d0[j + 1];
							break;

						case 1:
							this.oParent.CivState.Oceans[j].Size = (short)local_d0[j + 1];
							break;

						default:
							throw new IndexOutOfRangeException("Continent selector out of range");
					}
				}

				switch (i)
				{
					case 0:
						this.oParent.CivState.Continents[0].Size = 0;
						this.oParent.CivState.Continents[15].Size = 1;
						break;

					case 1:
						this.oParent.CivState.Oceans[0].Size = 0;
						this.oParent.CivState.Oceans[15].Size = 1;
						break;

					default:
						throw new IndexOutOfRangeException("Continent selector out of range");
				}
			}

			F7_0000_17cf();

			// Instruction address 0x0000:0x0e0c, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19e8_Rectangle, 0, 0);

			F7_0000_1188();

			F7_0000_1440(1);

			F7_0000_17cf();

			F7_0000_0f0a_ProcessBuildSites();

			#region Render polar caps
			// Instruction address 0x0000:0x0e49, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 0, 79, 0, 15);

			// Instruction address 0x0000:0x0e68, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 49, 79, 49, 15);

			for (int i = 0; i < 20; i++)
			{
				// Instruction address 0x0000:0x0e8d, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(rng.Next(80), 0, 7);

				// Instruction address 0x0000:0x0eae, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(rng.Next(80), 1, 7);

				// Instruction address 0x0000:0x0ecf, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(rng.Next(80), 48, 7);

				// Instruction address 0x0000:0x0ef0, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(rng.Next(80), 49, 7);
			}
			#endregion

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0a33_FinishMapConstruction");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_0f0a_ProcessBuildSites()
		{
			this.oCPU.Log.EnterBlock("F7_0000_0f0a_ProcessBuildSites()");

			// function body
			int local_4;
			int[] local_38 = new int[24];

			for (int i = 0; i < 16; i++)
			{
				this.oParent.CivState.Continents[i].BuildSiteCount = 0;
			}

			for (int i = 0; i < 24; i++)
			{
				int local_2 = i % 12;

				local_38[i] = (3 * this.oParent.CivState.Terrains[i].Food) + this.oParent.CivState.Terrains[i].Trade;

				if (local_2 != 2 && local_2 != 11)
				{
					local_38[i] += this.oParent.CivState.Terrains[i].Production * 2;
				}

				if (this.oParent.CivState.TerrainMultipliers[local_2].Multi3 < 0)
				{
					local_38[i] += -1 - this.oParent.CivState.TerrainMultipliers[local_2].Multi3;
				}
				else
				{
					if (this.oParent.CivState.TerrainMultipliers[local_2].Multi1 < 0)
					{
						local_38[i] += (-1 - this.oParent.CivState.TerrainMultipliers[local_2].Multi1) * 2;
					}
				}
			}

			for (int i = 2; i < 78; i++)
			{
				for (int j = 2; j < 48; j++)
				{
					int local_42 = (short)F7_0000_176d(i, j);

					if (local_42 == 11 || local_42 == 2 || local_42 == 1)
					{
						int local_6 = 0;

						for (int k = 0; k < 21; k++)
						{
							local_4 = 0;
							int local_8 = this.oParent.CityOffsets[k].X + i;
							int local_3a = this.oParent.CityOffsets[k].Y + j;

							local_42 = (short)F7_0000_176d(local_8, local_3a);

							if ((local_42 == 2 || local_42 == 11) && (((local_8 * 7) + (local_3a * 11)) & 0x2) == 0)
							{
								local_4 += 2;
							}

							// Instruction address 0x0000:0x1081, size: 5
							if (this.oParent.Segment_2aea.F0_2aea_1836(local_8, local_3a) != 0)
							{
								local_42 += 12;
							}

							local_4 += local_38[local_42];

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

						local_42 = (short)F7_0000_176d(i, j);

						if (local_42 != 1 && (((i * 7) + (j * 11)) & 0x2) != 0)
						{
							local_6 -= 16;
						}

						// Instruction address 0x0000:0x1111, size: 5
						local_4 = (this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((local_6 - 120) / 8, 1, 15) / 2) + 8;

						// Instruction address 0x0000:0x1138, size: 5
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(i + 80, j, (ushort)local_4);

						// Instruction address 0x0000:0x1151, size: 5
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(i + 80, j + 50, (ushort)local_4);

						this.oParent.CivState.Continents[(short)F7_0000_178e(i, j)].BuildSiteCount++;
					}
					else
					{
						// Instruction address 0x0000:0x0fd3, size: 5
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(i + 80, j, 0);

						// Instruction address 0x0000:0x0fec, size: 5
						this.oParent.Segment_1000.F0_1000_104f_SetPixel(i + 80, j + 50, 0);
					}
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_0f0a_ProcessBuildSites");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F7_0000_1188()
		{
			this.oCPU.Log.EnterBlock("F7_0000_1188()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x26);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x119b, size: 5
			for (int i = 0; i < 20; i++)
			{
				for (int j = 0; j < 13; j++)
				{
					this.oParent.CivState.LandPathfinding[i, j] = 0;
				}
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L142c;

		L11ab:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L11d4;

			// Instruction address 0x0000:0x11c3, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.SI.Word);
			goto L125a;

		L11d4:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)this.oCPU.SI.Word);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L1262;

			// Instruction address 0x0000:0x11ec, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)this.oCPU.SI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.SI.Word);

		L1200:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.E) goto L1209;
			goto L128e;

		L1209:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))));

		L120c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0xd);
			if (this.oCPU.Flags.L) goto L1215;
			goto L1429;

		L1215:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0xffff);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)this.oCPU.AX.Word);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1243;
			goto L11ab;

		L1243:
			// Instruction address 0x0000:0x1249, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);

		L125a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			goto L1200;

		L1262:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.DI.Word = this.oCPU.INC_UInt16(this.oCPU.DI.Word);

			F7_0000_176d((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L1200;

			// Instruction address 0x0000:0x127a, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				(short)this.oCPU.SI.Word,
				(short)this.oCPU.DI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.DI.Word);
			goto L1200;

		L128e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			goto L12fb;

		L1295:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L12be;

			// Instruction address 0x0000:0x12ad, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.SI.Word);
			goto L1354;

		L12be:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.SI.Word);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L12d5;
			goto L135c;

		L12d5:
			// Instruction address 0x0000:0x12d9, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.SI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.SI.Word);

		L12ed:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L12f8;
			goto L138b;

		L12f8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L12fb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x4);
			if (this.oCPU.Flags.LE) goto L1304;
			goto L1209;

		L1304:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];

			this.oCPU.AX.Word = (ushort)((short)direction.X * 4);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)direction.Y * 4);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.AX.Word);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L133d;
			goto L1295;

		L133d:
			// Instruction address 0x0000:0x1343, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

		L1354:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			goto L12ed;

		L135c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.INC_UInt16(this.oCPU.DI.Word);

			F7_0000_176d((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1375;
			goto L12ed;

		L1375:
			// Instruction address 0x0000:0x1377, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				(short)this.oCPU.SI.Word,
				(short)this.oCPU.DI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.DI.Word);
			goto L12ed;

		L138b:
			// Instruction address 0x0000:0x139e, size: 5
			this.oCPU.AX.Word = (ushort)((short)this.oParent.UnitGoTo.F0_2e31_111c_CreateBarbarianUnit(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				0, 20));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L13b1;
			goto L12f8;

		L13b1:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 20);
			if (this.oCPU.Flags.L) goto L13b9;
			goto L12f8;

		L13b9:
			this.oCPU.AX.Word = 13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));

			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CX.Low = this.oCPU.DEC_UInt8(this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.SHL_UInt8(this.oCPU.AX.Low, this.oCPU.CX.Low);

			this.oParent.CivState.LandPathfinding[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))] |= 
				this.oCPU.AX.Low;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];

			this.oCPU.AX.Word = (ushort)((short)direction.X);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)direction.Y);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.GE) goto L13f2;
			goto L12f8;

		L13f2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x14);
			if (this.oCPU.Flags.L) goto L13fb;
			goto L12f8;

		L13fb:
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1402;
			goto L12f8;

		L1402:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xd);
			if (this.oCPU.Flags.L) goto L140a;
			goto L12f8;

		L140a:
			this.oCPU.AX.Word = 13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, 0x3);
			this.oCPU.CX.Low = this.oCPU.AND_UInt8(this.oCPU.CX.Low, 0x7);
			this.oCPU.AX.Low = this.oCPU.SHL_UInt8(this.oCPU.AX.Low, this.oCPU.CX.Low);

			this.oParent.CivState.LandPathfinding[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] |=
				this.oCPU.AX.Low;

			goto L12f8;

		L1429:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L142c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x14);
			if (this.oCPU.Flags.GE) goto L143a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 0x0);
			goto L120c;

		L143a:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1188");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="flag"></param>
		public void F7_0000_1440(ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_1440({flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x18);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1453, size: 5
			for (int i = 0; i < this.oParent.UnitGoTo.Var_7f38.GetLength(0); i++)
			{
				for (int j = 0; j < this.oParent.UnitGoTo.Var_7f38.GetLength(1); j++)
				{
					this.oParent.UnitGoTo.Var_7f38[i, j] = 0;
				}
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L172a;

		L1463:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L147d;

			F7_0000_178e(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			goto L14f3;

		L147d:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)this.oCPU.SI.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1494;

			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)this.oCPU.SI.Word);

			goto L14f3;

		L1494:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.DI.Word = this.oCPU.INC_UInt16(this.oCPU.DI.Word);

			F7_0000_176d((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L14ad;

			F7_0000_178e((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			goto L14f3;

		L14ad:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0xffff);
			if (this.oCPU.Flags.NE) goto L14ff;

			L14b3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

		L14b6:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xc);
			if (this.oCPU.Flags.L) goto L14bf;
			goto L171d;

		L14bf:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0xffff);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				(short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L14ed;
			goto L1463;

		L14ed:
			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

		L14f3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			goto L14ad;

		L14ff:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			goto L155b;

		L1506:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1520;

			F7_0000_178e(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			goto L159e;

		L1520:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.SI.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1537;

			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.SI.Word);

			goto L159e;

		L1537:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.INC_UInt16(this.oCPU.DI.Word);

			F7_0000_176d((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1550;

			F7_0000_178e((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			goto L159e;

		L1550:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L15aa;

			L1558:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L155b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.LE) goto L1564;
			goto L14b3;

		L1564:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];

			this.oCPU.AX.Word = (ushort)((short)direction.X * 4);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)direction.Y * 4);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L1598;
			goto L1506;

		L1598:
			F7_0000_178e(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

		L159e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			goto L1550;

		L15aa:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			goto L15c5;

		L15c2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

		L15c5:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x4);
			if (this.oCPU.Flags.LE) goto L15ce;
			goto L1690;

		L15ce:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), (ushort)((short)direction.X)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4),
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), (ushort)((short)direction.Y)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x4);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L160a;

			// Instruction address 0x0000:0x15fe, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L160d;

			L160a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L160d:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1631;

			// Instruction address 0x0000:0x1625, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				(short)this.oCPU.SI.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1634;

			L1631:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L1634:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);

			F7_0000_176d(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.SI.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1658;

			// Instruction address 0x0000:0x164c, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				(short)this.oCPU.SI.Word);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L165b;

			L1658:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L165b:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.INC_UInt16(this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.DI.Word = this.oCPU.INC_UInt16(this.oCPU.DI.Word);

			F7_0000_176d((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L167f;

			// Instruction address 0x0000:0x1673, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds((short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1682;

			L167f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L1682:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.L) goto L168b;
			goto L15c2;

		L168b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);

		L1690:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.NE) goto L16a8;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xb);
			if (this.oCPU.Flags.E) goto L169f;
			goto L1558;

		L169f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3);
			if (this.oCPU.Flags.E) goto L16a8;
			goto L1558;

		L16a8:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];

			this.oCPU.DI.Word = (ushort)((short)direction.Y);
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));

			if ((short)this.oCPU.DI.Word >= 12)
				goto L1558;

			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));

			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CX.Low = this.oCPU.DEC_UInt8(this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.SHL_UInt8(this.oCPU.AX.Low, this.oCPU.CX.Low);

			this.oParent.UnitGoTo.Var_7f38[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))] |= this.oCPU.AX.Low;

			this.oCPU.AX.Word = (ushort)((short)direction.X);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L16e8;
			goto L1558;

		L16e8:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x14);
			if (this.oCPU.Flags.L) goto L16f0;
			goto L1558;

		L16f0:
			this.oCPU.DI.Word = this.oCPU.OR_UInt16(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.GE) goto L16f7;
			goto L1558;

		L16f7:
			this.oCPU.CMP_UInt16(this.oCPU.DI.Word, 0xc);
			if (this.oCPU.Flags.LE) goto L16ff;
			goto L1558;

		L16ff:
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.DI.Word);

			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, 0x3);
			this.oCPU.CX.Low = this.oCPU.AND_UInt8(this.oCPU.CX.Low, 0x7);
			this.oCPU.AX.Low = this.oCPU.SHL_UInt8(this.oCPU.AX.Low, this.oCPU.CX.Low);

			this.oParent.UnitGoTo.Var_7f38[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.DI.Word] |= this.oCPU.AX.Low;

			goto L1558;

		L171d:
			if (flag != 0)
			{
				F7_0000_17cf();
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L172a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x14);
			if (this.oCPU.Flags.GE) goto L1738;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);
			goto L14b6;

		L1738:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);

		L173d:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));

			this.oParent.UnitGoTo.Var_7f38[0, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))] |= 0xe0;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x802f),
				this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x802f)), 0xe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xc);
			if (this.oCPU.Flags.L) goto L173d;

			this.oParent.UnitGoTo.Var_7f38[0, 0] &= 0x7f;
			this.oParent.UnitGoTo.Var_7f38[0, 11] &= 0xdf;
			this.oParent.UnitGoTo.Var_7f38[19, 0] &= 0xfd;
			this.oParent.UnitGoTo.Var_7f38[19, 11] &= 0xf7;

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1440");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F7_0000_176d(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_176d({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x0000:0x177c, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(this.oParent.Var_aa_Rectangle.ScreenID, xPos, yPos);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2ba6));
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_176d");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F7_0000_178e(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_178e({xPos}, {yPos})");

			// function body
			// Instruction address 0x0000:0x17a1, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(this.oParent.Var_aa_Rectangle.ScreenID, xPos, yPos + 50);

			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_178e");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public ushort F7_0000_17cf()
		{
			this.oCPU.Log.EnterBlock("F7_0000_17cf()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x1a);

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b62), 0x2);
			if (this.oCPU.Flags.L) goto L185a;

			// Instruction address 0x0000:0x17e4, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L185a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b62), 0x5);
			if (this.oCPU.Flags.GE) goto L1820;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b62, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b62)));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b62), 0x5);
			if (this.oCPU.Flags.NE) goto L184f;

			// Instruction address 0x0000:0x1816, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 40, 160, 240, 8, 0);

			goto L184f;

		L1820:
			this.oCPU.AX.Word = this.oParent.Var_5c_TickCount;
			this.oCPU.DoEvents();
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3c;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6800, this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x6800), 0x1);
			if (this.oCPU.Flags.E) goto L183a;
			this.oCPU.AX.Word = 0xf;
			goto L183d;

		L183a:
			this.oCPU.AX.Word = 0x3;

		L183d:
			// Instruction address 0x0000:0x1847, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0("BUILDING NEW WORLD...", 160, 160, this.oCPU.AX.Low);

		L184f:
			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			goto L1bdd;

		L185a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b62), 0x0);
			if (this.oCPU.Flags.NE) goto L18a1;

			// Instruction address 0x0000:0x1869, size: 5
			this.oParent.MSCAPI.fopen("story.txt", "rt");

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6804, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b62, 0x1);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6806, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6800, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x188a, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "");

			this.oParent.Var_aa_Rectangle.FontID = 7;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6802, 0x0);

		L18a1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6802), 0x0);
			if (this.oCPU.Flags.E) goto L18b0;

			// Instruction address 0x0000:0x18a8, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e_Soundtimer();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6800, this.oCPU.AX.Word);

		L18b0:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6806);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6800), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L18c4;

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			goto L1bd8;

		L18c4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b62), 0x2);
			if (this.oCPU.Flags.E) goto L18f3;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6802), 0x28);
			if (this.oCPU.Flags.GE) goto L18f3;

			// Instruction address 0x0000:0x18df, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 3);

			// Instruction address 0x0000:0x18eb, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(5);

		L18f3:
			// Instruction address 0x0000:0x18ff, size: 5
			this.oParent.MSCAPI.fscanf((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6804), "%[^\n]\n", 0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L1912;
			goto L1b6a;

		L1912:
			// Instruction address 0x0000:0x1912, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1925;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67fc), 0x0);
			if (this.oCPU.Flags.E) goto L1925;
			goto L1b6a;

		L1925:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b64), 0x1);
			if (this.oCPU.Flags.LE) goto L1952;

			// Instruction address 0x0000:0x194a, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 0, 160, 320, 8, this.oParent.Var_aa_Rectangle, 0, 160);

		L1952:
			// Instruction address 0x0000:0x1956, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x0000:0x196b, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 3);

			// Instruction address 0x0000:0x1977, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(5);

			// Instruction address 0x0000:0x198c, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 160, 11);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6806, 0x0);

			// Instruction address 0x0000:0x199e, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.LE) goto L19db;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6802), 0x0);
			if (this.oCPU.Flags.NE) goto L19cf;

			// Instruction address 0x0000:0x19b2, size: 5
			this.oParent.Segment_1000.F0_1000_033e_ResetWaitTimer();

			// Instruction address 0x0000:0x19bb, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			// Instruction address 0x0000:0x19c7, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(4, 0);

		L19cf:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6806, this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6806), 0x2));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6802, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6802)));
			goto L1b29;

		L19db:
			// Instruction address 0x0000:0x19e3, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "birth0.pic");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b64);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b64, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b64)));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb)), this.oCPU.AX.Low));
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1a19;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x1);
			goto L1a11;

		L1a03:
			// Instruction address 0x0000:0x1a06, size: 5
			this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))));

		L1a11:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b68);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L1a03;

		L1a19:
			// Instruction address 0x0000:0x1a21, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(2, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1a41;

			// Instruction address 0x0000:0x1a39, size: 5
			this.oParent.Segment_1000.F0_1000_04d4_TransformPaletteToColor(8, Color.FromRgb(0, 0, 0));

		L1a41:
			// Instruction address 0x0000:0x1a59, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.NE) goto L1a6b;
			goto L1b29;

		L1a6b:
			// Instruction address 0x0000:0x1a73, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x9), "pal");

			// Instruction address 0x0000:0x1a83, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0xc5be);

			// Instruction address 0x0000:0x1a93, size: 5
			this.oParent.Segment_1000.F0_1000_04aa_TransformPalette(8, 0xc5be);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b68, 0x0);
			goto L1af8;

		L1aa3:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66)));
			this.oCPU.ES.Word = 0x3710; // segment
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66)));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66)));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x12c;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.DIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b68, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b68)));

			// Instruction address 0x0000:0x1af0, size: 5
			this.oParent.Segment_1000.F0_1000_0382_AddPaletteCycleSlot(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b68),
				this.oCPU.AX.Word,
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));

		L1af8:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66);
			this.oCPU.ES.Word = 0x3710; // segment
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0)), 0x0);
			if (this.oCPU.Flags.NE) goto L1aa3;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b66, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b66)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x1);
			goto L1b21;

		L1b13:
			// Instruction address 0x0000:0x1b16, size: 5
			this.oParent.Segment_1000.F0_1000_03fa_StartPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))));

		L1b21:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b68);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L1b13;

		L1b29:
			// Instruction address 0x0000:0x1b2d, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x13);
			if (this.oCPU.Flags.LE) goto L1b3e;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6806, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6806)));

		L1b3e:
			// Instruction address 0x0000:0x1b5d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(0x3710, (ushort)((this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6802) << 1) + 0x83)),
				(45 * this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6806)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6800),
				32767);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6806, this.oCPU.AX.Word);
			goto L1bbe;

		L1b6a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1b7c;

			// Instruction address 0x0000:0x1b74, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(180);

		L1b7c:
			// Instruction address 0x0000:0x1b80, size: 5
			this.oParent.MSCAPI.fclose((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6804));

			// Instruction address 0x0000:0x1b8c, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1bb8;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x1);
			goto L1bb0;

		L1ba2:
			// Instruction address 0x0000:0x1ba5, size: 5
			this.oParent.Segment_1000.F0_1000_042b_StopPaletteCycleSlot(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))));

		L1bb0:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b68);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L1ba2;

		L1bb8:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3b62, 0x2);

		L1bbe:
			// Instruction address 0x0000:0x1bc1, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3b62), 0x2);
			if (this.oCPU.Flags.E) goto L1bdd;

		L1bd8:
			this.oCPU.AX.Word = 0x1;
			goto L1bdf;

		L1bdd:
			this.oCPU.AX.Word = 0;

		L1bdf:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_17cf");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="globalWarmingCount"></param>
		public void F7_0000_1be3(short globalWarmingCount)
		{
			this.oCPU.Log.EnterBlock($"F7_0000_1be3({globalWarmingCount})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xe);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1bf2, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Global temperature\nrises! Icecaps melt.\nSevere Drought.\n");

			this.oParent.Overlay_21.F21_0000_0000(-1);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L1d45;

		L1c11:
			// Instruction address 0x0000:0x1c2a, size: 5
			this.oParent.Segment_2aea.F0_2aea_16ee(6,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			goto L1c8a;

		L1c34:
			this.oCPU.AX.Word = 0xb;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, this.oCPU.AX.Low);
			this.oCPU.CX.High = 0;
			this.oCPU.CX.Word = this.oCPU.AND_UInt16(this.oCPU.CX.Word, 0x7);
			this.oCPU.CMP_UInt16(this.oCPU.CX.Word, (ushort)globalWarmingCount);
			if (this.oCPU.Flags.NE) goto L1cac;

			this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] |= 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x1);
			if (this.oCPU.Flags.LE)
			{
				// Instruction address 0x0000:0x1c82, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					14);
			}
			else
			{
				// Instruction address 0x0000:0x1c82, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					6);
			}

		L1c8a:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L1cac;

			// Instruction address 0x0000:0x1ca4, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

		L1cac:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L1caf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x32);
			if (this.oCPU.Flags.L) goto L1cb8;
			goto L1d42;

		L1cb8:
			// Instruction address 0x0000:0x1cbe, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.G) goto L1cac;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L1cd8:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))];

			// Instruction address 0x0000:0x1ced, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + direction.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + direction.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1cfd;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L1cfd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.LE) goto L1cd8;
			this.oCPU.AX.Word = 0x7;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)globalWarmingCount);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			if (this.oCPU.Flags.LE) goto L1d14;
			goto L1c34;

		L1d14:
			this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))] |= 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x3);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x0000:0x1c18, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					3);
			}
			else
			{
				// Instruction address 0x0000:0x1c18, size: 5
				this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					11);
			}
			goto L1c11;

		L1d42:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L1d45:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x50);
			if (this.oCPU.Flags.GE) goto L1d53;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L1caf;

		L1d53:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F7_0000_1be3");
		}
	}
}
