using IRB.VirtualCPU;
using System.Text;

namespace OpenCiv1
{
	public class MenuBoxDialog
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public int Var_2fa0 = 0;
		private string[] Array_2fa6 = { "Spies", "Diplomats", "Travelers", "Defense Minister:", "Domestic Advisor:", "Foreign Minister:", "Science Advisor:" };
		public int Var_d7f2 = 0;

		public MenuBoxDialog(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// Shows a customizable Dialog Box with or without options
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F0_2d05_0031_ShowMenuBox(ushort stringPtr, int xPos, int yPos, int flag)
		{
			string text = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, stringPtr));

			return F0_2d05_0031_ShowMenuBox(text, xPos, yPos, flag);
		}

		/// <summary>
		/// Shows a customizable Dialog Box with or without options
		/// </summary>
		/// <param name="text"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F0_2d05_0031_ShowMenuBox(string text, int xPos, int yPos, int flag)
		{
			this.oCPU.Log.EnterBlock($"F0_2d05_0031_ShowDialogBox(\"{text}\", {xPos}, {yPos}, {flag})");

			// function body
			int Var_2fa4 = 8;
			int Var_654c = 0;
			int[] Array_654e = new int[32];
			int Var_658e = 0;
			int Var_b1ec = 0;
			int Var_d208 = 0;
			int Var_d4c8 = 0;
			char[] Array_dc4a = new char[32];
			int Var_de0e = 0;

			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_a;
			int local_c;
			int local_e;
			int local_10;
			int local_12;

			if (flag != 0)
			{
				// Instruction address 0x2d05:0x003e, size: 5
				this.oParent.Segment_1403.F0_1403_4545();
			}

			local_2 = -1;
			local_4 = 0;

			this.oParent.Var_2fa2 = 0;
			this.oParent.Var_2f9c = 0;

			if (this.oParent.Var_2f9a != -1)
			{
				local_4 = this.oParent.Var_2f9a;
			}

			Var_b1ec = -1;

			// Instruction address 0x2d05:0x0094, size: 5
			Var_2fa4 = this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			if (Var_2fa4 == 9)
			{
				Var_2fa4--;
			}

			if (this.oParent.Var_3936 != -1)
			{
				Var_2fa4 = 8;
			}

			local_c = 7;
			local_e = 22;

			if (yPos == 139)
			{
				local_e = 8;
			}

			if ((yPos & 1) != 0 && yPos != 139)
			{
				// Instruction address 0x2d05:0x00e1, size: 5
				local_c = this.oParent.Graphics.F0_VGA_038c_GetPixel(0, xPos, yPos);
				local_e = -1;
			}

			if (local_c == 15)
			{
				Var_654c = 3;
			}
			else
			{
				Var_654c = 15;
			}

			local_10 = Var_2fa4;
			local_12 = 0;
			local_8 = 0;

			// Instruction address 0x2d05:0x012f, size: 3
			Array_654e[0] = 0;

			// Instruction address 0x2d05:0x0494, size: 5
			Var_2fa4 = this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			if (Var_2fa4 == 9)
			{
				Var_2fa4--;
			}

			if (this.oParent.Var_3936 != -1)
			{
				Var_2fa4 = 8;
			}

			for (int i = 0; i < 32; i++)
			{
				Array_dc4a[i] = '\0';
			}

			int local_5a = 0;
			Var_658e = 0;
			int local_54 = 0;
			Var_d4c8 = 0;

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] != '\n')
				{
					if (local_54 == 0)
					{
						char local_5c = text[i];

						if (i + 1 < text.Length && (local_5c == ' ' || local_5c == '_'))
						{
							if (local_5a < 32)
							{
								Array_dc4a[local_5a] = text[i + 1];
							}

							if (Var_b1ec == -1)
							{
								Var_b1ec = Var_658e;
							}

							local_5a++;
						}
					}

					// Instruction address 0x2d05:0x052d, size: 5
					local_54 += this.oParent.Graphics.F0_VGA_115d_GetCharWidth(this.oParent.Var_aa_Rectangle.FontID, text[i]);
				}
				else
				{
					if (local_54 > Var_d4c8)
					{
						Var_d4c8 = local_54;
					}

					local_54 = 0;

					Var_658e++;

					Array_654e[Var_658e] = i + 1;
				}
			}

			// Instruction address 0x2d05:0x0592, size: 5
			Var_658e = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(Var_658e, 0, (192 - yPos) / Var_2fa4);

			Var_de0e = xPos + Var_d4c8 + 8;

			int local_52 = (Var_658e * Var_2fa4) + yPos + 6;

			if (this.Var_2fa0 != 0)
			{
				local_52 += 2;
			}

			// Instruction address 0x2d05:0x05c8, size: 5
			if (text[text.Length - 1] != '\n')
			{
				local_5a--;
			}

			Var_d208 = local_5a;

			if ((yPos & 1) == 0)
			{
				if (this.oParent.Var_2f9e == -1)
				{
					// Instruction address 0x2d05:0x060d, size: 3
					F0_2d05_096c_FillRectangleWithDoubleShadow(xPos, yPos, Var_de0e - xPos, local_52 - yPos, 7);
				}
				else
				{
					// Instruction address 0x2d05:0x0621, size: 5
					string local_50 = this.Array_2fa6[this.oParent.Var_2f9e];

					if (this.oParent.Var_2f9e <= 2)
					{
						// Instruction address 0x2d05:0x0638, size: 5
						local_50 += " report:";
					}

					// Instruction address 0x2d05:0x0644, size: 5
					int local_58 = this.oParent.DrawStringTools.F0_1182_00ef_GetStringWidth(local_50);

					if (Var_de0e < xPos + local_58 + 8)
					{
						Var_de0e = xPos + local_58 + 8;
					}

					// Instruction address 0x2d05:0x0677, size: 5
					// Instruction address 0x2d05:0x0699, size: 3
					F0_2d05_096c_FillRectangleWithDoubleShadow(xPos - 42, yPos - 8, (Var_de0e - xPos) + 42,
						this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(local_52 - yPos + 8, 61, 999), 7);

					local_58 = local_52 - yPos - 52;

					if (this.oParent.Var_2f9e > 2)
					{
						// ??? This is dialog image being drawn for future reference
						if (local_58 > 0)
						{
							// Instruction address 0x2d05:0x070d, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
								(40 * this.oParent.Var_2f9e) + 40, 140, 40, 60,
								this.oParent.Var_aa_Rectangle, xPos - 40, local_58 - 1 + yPos - 6);
						}
						else
						{
							// Instruction address 0x2d05:0x070d, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
								(40 * this.oParent.Var_2f9e) + 40, 140, 40, 60,
								this.oParent.Var_aa_Rectangle, xPos - 40, yPos - 6);
						}
					}
					else
					{
						// Instruction address 0x2d05:0x06c8, size: 5
						this.oParent.Graphics.F0_VGA_0d47_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, xPos - 40, yPos - 5, this.oParent.Array_df62[this.oParent.Var_2f9e]);
					}

					// Instruction address 0x2d05:0x072b, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(local_50, xPos + 5, yPos - 4, 15);

					// Instruction address 0x2d05:0x0742, size: 5
					// Instruction address 0x2d05:0x0753, size: 5
					this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle,
						xPos + 5 + this.oParent.DrawStringTools.F0_1182_00ef_GetStringWidth(local_50), yPos + 3, xPos + 5, yPos + 3, 11);
				}
			}

			if (this.Var_2fa0 != 0)
			{
				int local_56 = this.oParent.Var_aa_Rectangle.FontID;
				this.oParent.Var_aa_Rectangle.FontID = 2;

				// Instruction address 0x2d05:0x0787, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA("(HELP AVAILABLE)", Var_de0e - 74, local_52 - 4, 10);

				this.oParent.Var_aa_Rectangle.FontID = local_56;
			}

			int local_5a1 = -1;

			if (text[0] == ' ' || text[0] == '_')
			{
				local_5a1 = 0;
			}

			this.oParent.Var_aa_Rectangle.FrontColor = (byte)Var_654c;

			for (int i = 0; i < Var_658e; i++)
			{
				string item = text.Substring(Array_654e[i], Array_654e[i + 1] - Array_654e[i] - 1);

				//this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(text + Array_654e[i + 1] - 1), 0x0);

				if (local_5a1 < 0 || (this.Var_d7f2 & (1 << local_5a1)) == 0)
				{
					if (local_5a1 < 0 && Var_2fa4 > 9)
					{
						// Instruction address 0x2d05:0x087b, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(item, xPos + 5, (i * Var_2fa4) + yPos + 6, 0);
					}

					if (local_5a1 >= 0)
					{
						if ((this.oParent.Var_b276 & (1 << local_5a1)) != 0)
						{
							// Instruction address 0x2d05:0x08c6, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(item, xPos + 5, (i * Var_2fa4) + yPos + 5, 3);
						}
						else
						{
							// Instruction address 0x2d05:0x08c6, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(item, xPos + 5, (i * Var_2fa4) + yPos + 5, 0);
						}
					}
					else
					{
						// Instruction address 0x2d05:0x08c6, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(item, xPos + 5, (i * Var_2fa4) + yPos + 5, (byte)Var_654c);
					}
				}
				else
				{
					//this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(text + Array_654e[i]), '^');
					item = '^' + item.Substring(1);

					if (local_5a1 >= 0)
					{
						if ((this.oParent.Var_b276 & (1 << local_5a1)) != 0)
						{
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(item, xPos + 5, (i * Var_2fa4) + yPos + 5, 3);
						}
						else
						{
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(item, xPos + 5, (i * Var_2fa4) + yPos + 5, 0);
						}
					}
					else
					{
						// Instruction address 0x2d05:0x0834, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA(item, xPos + 5, (i * Var_2fa4) + yPos + 5, (byte)Var_654c);
					}

					//this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(text + Array_654e[i]), 0x20);
				}

				//this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(text + Array_654e[i + 1] - 1), 0xa);

				char local_5c = '\0';

				if (Array_654e[i + 1] < text.Length)
				{
					local_5c = text[Array_654e[i + 1]];
				}

				if (local_5c == ' ' || local_5c == '_')
				{
					local_5a1++;
				}
			}

			if (this.oParent.Var_db38 == 0)
			{
				do
				{
					if (this.oParent.Var_3936 != -1)
					{
						this.oParent.MeetWithKing.F6_0000_1b33();
					}

					this.oParent.Var_db3a = 0;

					// Instruction address 0x2d05:0x0165, size: 5
					this.oParent.Segment_11a8.F0_11a8_0223();

					if (this.oParent.Var_db3a != 0 || local_12 != 0)
					{
						this.oParent.Var_2fa2 = 1;
						local_12 = 1;

						if (this.oParent.Var_db3a == 2)
						{
							this.oParent.Var_2f9c = 1;
						}

						local_4 = ((this.oParent.Var_db3e - yPos - 4) / Var_2fa4) - Var_b1ec;

						if (xPos > this.oParent.Var_db3c)
						{
							local_4 = -1;
						}
						else if (this.oParent.Var_db3c > Var_de0e)
						{
							local_4 = -1;
						}

						if ((this.oParent.Var_b276 & (1 << local_4)) == 0)
						{
							if (this.oParent.Var_db3a == 0)
							{
								local_8 = 1;
							}
						}
						else
						{
							local_4 = local_2;
						}
					}
					else
					{
						// Instruction address 0x2d05:0x01db, size: 5
						if (this.oParent.MSCAPI.kbhit() != 0)
						{
							// Instruction address 0x2d05:0x01e5, size: 3
							local_6 = F0_2d05_0ac9_GetNavigationKey();

							switch (local_6)
							{
								case 0x20:
									if ((this.oParent.Var_b276 & (1 << local_4)) == 0)
									{
										local_8 = 1;
									}
									break;

								case 0xd:
									if ((this.oParent.Var_b276 & (1 << local_4)) == 0)
									{
										local_8 = 1;
									}
									break;

								case 0x1b:
									local_4 = -1;
									local_8 = 1;
									break;

								case 0x2300:
									this.oParent.Var_2f9c = 1;
									local_8 = 1;
									break;

								case 0x2f00:
									this.oGameData.GameSettingFlags ^= 0x10;

									if ((this.oGameData.GameSettingFlags & 0x10) == 0)
									{
										// Instruction address 0x2d05:0x03ad, size: 5
										this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);
									}
									break;

								case 0x4800:
									if (local_4 > 0)
									{
										local_4--;
									}
									break;

								case 0x5000:
									if (local_4 < Var_d208)
									{
										local_4++;
									}
									break;

								default:
									local_a = local_4 + 1;

									if (local_a < 32)
									{
										while (Array_dc4a[local_a] == '\0' || (Array_dc4a[local_a] & 0x1f) != (local_6 & 0x1f))
										{
											local_a++;
										}

										local_4 = local_a;
									}
									break;
							}
						}
					}

					if (local_4 < 0 || local_4 > Var_d208 || this.oParent.Var_d206 != 0)
					{
						local_4 = -1;
					}

					if (local_4 != local_2)
					{
						if (local_2 != -1)
						{
							// Instruction address 0x2d05:0x027c, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
								xPos + 3, ((local_2 + Var_b1ec) * Var_2fa4) + yPos + 4,
								Var_d4c8 + 5, local_10,
								11, (byte)local_c);

							if (local_e != -1)
							{
								// Instruction address 0x2d05:0x02b2, size: 5
								this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
									xPos + 3, ((local_2 + Var_b1ec) * Var_2fa4) + yPos + 4,
									Var_d4c8 + 5, local_10,
									3, (byte)local_e);
							}
						}

						if (local_4 != -1)
						{
							// Instruction address 0x2d05:0x02ee, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
								xPos + 3, ((local_4 + Var_b1ec) * Var_2fa4) + yPos + 4,
								Var_d4c8 + 5, local_10,
								(byte)local_c, 11);

							if (local_e != -1)
							{
								// Instruction address 0x2d05:0x0324, size: 5
								this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
									xPos + 3, ((local_4 + Var_b1ec) * Var_2fa4) + yPos + 4,
									Var_d4c8 + 5, local_10,
									(byte)local_e, 3);
							}
						}

						local_2 = local_4;
					}
				}
				while (local_8 == 0);

				if (local_4 != -1)
				{
					// Instruction address 0x2d05:0x0441, size: 5
					this.oParent.Segment_1000.F0_1182_0134_WaitTimer(20);
				}
				else
				{
					this.oParent.Var_2f9c = 0;
				}

				this.oParent.Var_2f9e = -1;
				this.oParent.Var_2f9a = -1;
				this.Var_2fa0 = 0;
				this.oParent.Var_d206 = 0;
				this.oParent.Var_b276 = 0;
				this.Var_d7f2 = 0;
				this.oCPU.AX.Word = (ushort)((short)local_4);
			}
			else
			{
				this.oParent.Var_db38 = 0;
				this.oCPU.AX.Word = 0xffff;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2d05_0031_ShowDialogBox");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_2d05_096c_FillRectangleWithDoubleShadow(int xPos, int yPos, int width, int height, ushort mode)
		{
			// function body
			if (mode == 7 && this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f98) != 0)
			{
				// Instruction address 0x2d05:0x098c, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_03ce_FillRectangleWithPattern(xPos + 1, yPos + 1, width, height);
			}
			else
			{
				// Instruction address 0x2d05:0x09b1, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos + 1, yPos + 1, width, height, mode);
			}
		
			this.oParent.Var_aa_Rectangle.BackColor = (byte)mode;

			// Instruction address 0x2d05:0x09e1, size: 3
			F0_2d05_0a66_DrawShadowRectangle(xPos + 1, yPos + 1, width, height, 15, 8);

			// Instruction address 0x2d05:0x09fd, size: 3
			F0_2d05_0a05_DrawRectangle(xPos, yPos, width + 2, height + 2, 0);
		}

		/// <summary>
		/// Draws a rectangle
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_2d05_0a05_DrawRectangle(int xPos, int yPos, int width, int height, ushort mode)
		{
			// function body
			// Instruction address 0x2d05:0x0a1d, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos, xPos + width, yPos, mode);

			// Instruction address 0x2d05:0x0a34, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos + height, xPos + width, yPos + height, mode);

			// Instruction address 0x2d05:0x0a45, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos + width, yPos, xPos + width, yPos + height, mode);

			// Instruction address 0x2d05:0x0a5a, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos, xPos, yPos + height, mode);
		}

		/// <summary>
		/// Draws a shaddow rectangle
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		/// <param name="mode1"></param>
		public void F0_2d05_0a66_DrawShadowRectangle(int xPos, int yPos, int width, int height, ushort mode, ushort mode1)
		{
			// function body
			// Instruction address 0x2d05:0x0a7e, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos, xPos + width, yPos, mode1);

			// Instruction address 0x2d05:0x0a95, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos + height, xPos + width, yPos + height, mode);

			// Instruction address 0x2d05:0x0aa6, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos + width, yPos, xPos + width, yPos + height, mode1);

			// Instruction address 0x2d05:0x0abd, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, xPos, yPos + 1, xPos, yPos + height, mode);
		}

		/// <summary>
		/// Get navigation key
		/// </summary>
		/// <returns></returns>
		public int F0_2d05_0ac9_GetNavigationKey()
		{
			this.oCPU.Log.EnterBlock("F0_2d05_0ac9_GetNavigationKey()");

			// function body

			// Instruction address 0x2d05:0x0acf, size: 5
			int iKey = this.oParent.MSCAPI.getch();

			switch (iKey)
			{
				case 0:
					break;

				case 0x4800: // Up
				case 0x487e: // Another code for Up
					iKey = 0x4800; // Up
					break;

				case 0x4d00: // Right
				case 0xf400: // Another code for Right
					iKey = 0x4d00; // Right
					break;

				case 0x5000: // Down
				case 0x5060: // Another code for Down
					iKey = 0x5000; // Down
					break;

				case 0x4b00: // Left
				case 0x4b7c: // Another code for Left
					iKey = 0x4b00; // Left
					break;

				case 0x4838: // Shift + Up
					iKey = 0x4838; // Shift + Up
					break;

				case 0x4d36: // Shift + Right
				case 0x4d46: // Another code for Shift + Right
					iKey = 0x4d36; // Shift + Right
					break;

				case 0x5032: // Shift + Down
					iKey = 0x5032; // Shift + Down
					break;

				case 0x4b34: // Shift + Left
				case 0x4b43: // Another code for Shift + Left
					iKey = 0x4b34; // Shift + Left
					break;

				case 0x4700: // Home
				case 0x475c: // Another code for Home
					iKey = 0x4700; // Home
					break;

				case 0x4f00: // End
					iKey = 0x4f00; // End
					break;

				case 0x4737: // shift + Home
					iKey = 0x4737; // Shift + Home
					break;

				case 0x4f31: // Shift + End
					iKey = 0x4f31; // Shift + End
					break;

				case 0x4900: // Page Up
					iKey = 0x4900; // Page Up
					break;

				case 0x5100: // Page Down
					iKey = 0x5100; // Page Down
					break;

				case 0x4939: // Shift + Page Up
					iKey = 0x4939; // Shift + Page Up
					break;

				case 0x5133: // Shift + Page Down
					iKey = 0x5133; // Shift + Page Down
					break;

				default:
					//iKey &= 0xff;
					break;
			}

			this.oCPU.AX.Word = (ushort)((short)iKey);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2d05_0ac9_GetNavigationKey");

			return iKey;
		}
	}
}
