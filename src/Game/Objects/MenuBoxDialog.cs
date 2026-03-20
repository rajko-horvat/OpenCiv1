using IRB.VirtualCPU;
using System.Diagnostics;

namespace OpenCiv1
{
	public class MenuBoxDialog
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		private string[] Array_2fa6 = { "Spies", "Diplomats", "Travelers", "Defense Minister:", "Domestic Advisor:", "Foreign Minister:", "Science Advisor:" };

		public MenuBoxDialog(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="emptyKeyboardAndMouse"></param>
		/// <returns></returns>
		public int F0_2d05_0031_ShowMenuBox(ushort stringPtr, int x, int y, bool emptyKeyboardAndMouse)
		{
			//this.oCPU.Log.EnterBlock($"F0_2d05_0031_ShowMenuBox(0x{stringPtr:x4}, {x}, {y}, {emptyKeyboardAndMouse})");

			// !!! To Do: Change stringPtr to string input

			//Debug.WriteLine($"\"{this.oCPU.ReadString(this.oCPU.DS.UInt16, stringPtr)}\"");

			// function body
			int lineHeight = 8;
			int textColor = 0;
			int optionCount = 0;
			int[] optionPositions = new int[32];
			int optionCountMax = 0;
			int firstOptionIndex = 0;
			int maxLineWidth = 0;
			char[] optionFirstChar = new char[32];
			int Var_de0e = 0;

			int local_2;
			int selectedOptionIndex;
			int local_8;
			int local_a;
			int backgroundColor;
			int local_e;
			int local_12;

			int windowHeight;
			int local_58;
			int local_5a;

			if (emptyKeyboardAndMouse)
			{
				// Instruction address 0x2d05:0x003e, size: 5
				this.oParent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();
			}

			local_2 = -1;
			this.oParent.Var_2fa2 = 0;
			this.oParent.Var_2f9c = 0;
			selectedOptionIndex = 0;

			if (this.oParent.Var_2f9a != -1)
			{
				selectedOptionIndex = this.oParent.Var_2f9a;
			}

			firstOptionIndex = -1;

			// Instruction address 0x2d05:0x0094, size: 5
			lineHeight = this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			if (lineHeight == 9)
			{
				lineHeight--;
			}

			if (this.oParent.Var_3936 != -1)
			{
				lineHeight = 8;
			}

			backgroundColor = 7;
			local_e = 22;

			if (y == 139)
			{
				local_e = 8;
			}

			if ((y & 1) != 0 && y != 139)
			{
				// Instruction address 0x2d05:0x00e1, size: 5
				backgroundColor = this.oParent.Graphics.F0_VGA_038c_GetPixel(0, x, y);
				local_e = -1;
			}

			textColor = (backgroundColor == 15) ? 3 : 15;

			if (this.oParent.Var_d762 == 0)
			{
				local_e = -1;
			}

			local_12 = 0;
			local_8 = 0;

			// Instruction address 0x2d05:0x011c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			optionPositions[0] = 0;

			for (int i = 0; i < 32; i++)
			{
				optionFirstChar[i] = '\x0';
			}

			local_5a = 0;
			int selectedLineWidth = 0;
			maxLineWidth = 0;
			int stringLength = this.oParent.CAPI.strlen(stringPtr);

			for (int i = 0; i < stringLength; i++)
			{
				char ch = (char)this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + i));

				if (ch != 0xa)
				{
					if (selectedLineWidth == 0)
					{
						if (ch == ' ' || ch == '_')
						{
							if (local_5a < 32)
							{
								optionFirstChar[local_5a] = (char)this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + i + 1));
							}

							if (firstOptionIndex == -1)
							{
								firstOptionIndex = optionCount;
							}

							local_5a++;
						}
					}

					// Instruction address 0x2d05:0x052d, size: 5
					selectedLineWidth += this.oParent.Graphics.F0_VGA_115d_GetCharWidth(this.oParent.Var_aa_Rectangle.FontID, ch);
				}
				else
				{
					if (selectedLineWidth > maxLineWidth)
					{
						maxLineWidth = selectedLineWidth;
					}

					selectedLineWidth = 0;
					optionCount++;

					optionPositions[optionCount] = i + 1;
				}
			}

			// Instruction address 0x2d05:0x0592, size: 5
			optionCount = this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(optionCount, 0, (192 - y) / lineHeight);

			Var_de0e = x + maxLineWidth + 8;

			windowHeight = y + (optionCount * lineHeight) + 6;

			if (this.oParent.Var_2fa0 != 0)
			{
				windowHeight += 2;
			}

			// Instruction address 0x2d05:0x05c8, size: 5
			if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + this.oParent.CAPI.strlen(stringPtr) - 1)) != 0xa)
			{
				local_5a--;
			}

			optionCountMax = local_5a;

			if ((y & 1) == 0)
			{
				if (this.oParent.Var_2f9e_MessageBoxStyle != ReportTypeEnum.Default)
				{
					// Instruction address 0x2d05:0x0621, size: 5
					string messageText = Array_2fa6[(int)this.oParent.Var_2f9e_MessageBoxStyle];

					if (this.oParent.Var_2f9e_MessageBoxStyle != ReportTypeEnum.DefenseMinister && this.oParent.Var_2f9e_MessageBoxStyle != ReportTypeEnum.DomesticAdvisor &&
						this.oParent.Var_2f9e_MessageBoxStyle != ReportTypeEnum.ForeignMinister && this.oParent.Var_2f9e_MessageBoxStyle != ReportTypeEnum.ScienceAdvisor)
					{
						// Instruction address 0x2d05:0x0638, size: 5
						messageText += " report:";
					}

					// Instruction address 0x2d05:0x0644, size: 5
					local_58 = this.oParent.DrawStringTools.F0_1182_00ef_GetStringWidth(messageText);

					if (Var_de0e < x + local_58 + 8)
					{
						Var_de0e = x + local_58 + 8;
					}

					// Instruction address 0x2d05:0x0677, size: 5
					// Instruction address 0x2d05:0x0699, size: 3
					F0_2d05_096c_FillRectangleWithDoubleShadow(x - 42, y - 8,
						(Var_de0e - x) + 42, this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(windowHeight - y + 8, 61, 999), 7);

					local_58 = windowHeight - y - 52;

					if (this.oParent.Var_2f9e_MessageBoxStyle == ReportTypeEnum.DefenseMinister || this.oParent.Var_2f9e_MessageBoxStyle == ReportTypeEnum.DomesticAdvisor ||
						this.oParent.Var_2f9e_MessageBoxStyle == ReportTypeEnum.ForeignMinister || this.oParent.Var_2f9e_MessageBoxStyle == ReportTypeEnum.ScienceAdvisor)
					{
						// ??? This is dialog image being drawn for future reference
						if (local_58 > 0)
						{
							// Instruction address 0x2d05:0x070d, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
								40 + (40 * (int)this.oParent.Var_2f9e_MessageBoxStyle), 140, 40, 60,
								this.oParent.Var_aa_Rectangle, x - 40, ((local_58 - 1) + y) - 6);
						}
						else
						{
							// Instruction address 0x2d05:0x070d, size: 5
							this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
								40 + (40 * (int)this.oParent.Var_2f9e_MessageBoxStyle), 140, 40, 60,
								this.oParent.Var_aa_Rectangle, x - 40, y - 6);
						}
					}
					else
					{
						// Instruction address 0x2d05:0x06c8, size: 5
						this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, x - 40, y - 5,
							this.oParent.Array_df62[(int)this.oParent.Var_2f9e_MessageBoxStyle]);

						// Instruction address 0x2d05:0x072b, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(messageText, x + 5, y - 4, 15);

						// Instruction address 0x2d05:0x0753, size: 5
						this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x + 5, y + 3, x + 5, y + 3, 11);
					}
				}
				else
				{
					// Instruction address 0x2d05:0x060d, size: 3
					F0_2d05_096c_FillRectangleWithDoubleShadow(x, y, Var_de0e - x, windowHeight - y, 7);
				}
			}

			if (this.oParent.Var_2fa0 != 0)
			{
				int fontID = this.oParent.Var_aa_Rectangle.FontID;
				this.oParent.Var_aa_Rectangle.FontID = 2;

				// Instruction address 0x2d05:0x0787, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("(HELP AVAILABLE)", Var_de0e - 74, windowHeight - 4, 10);

				this.oParent.Var_aa_Rectangle.FontID = fontID;
			}

			if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, stringPtr) == 0x20 || this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, stringPtr) == 0x5f)
			{
				local_5a = 0;
			}
			else
			{
				local_5a = -1;
			}

			this.oParent.Var_aa_Rectangle.FrontColor = (byte)textColor;

			for (int i = 0; i < optionCount; i++)
			{
				// ??? Why is this here at all? if (Math.Abs(this.oParent.Var_2f9a - local_5a) < 2)
				//{
				this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + optionPositions[i + 1] - 1), 0x0);

				if (local_5a >= 0 && (this.oParent.Var_d7f2 & (0x1 << local_5a)) != 0)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + optionPositions[i]), 0x5e);

					if (local_5a < 0)
					{
						// Instruction address 0x2d05:0x0834, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0((ushort)(stringPtr + optionPositions[i]),
							x + 5, y + 5 + (i * lineHeight), (byte)textColor);

						this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + optionPositions[i]), 0x20);
					}
					else
					{
						if ((this.oParent.Var_b276 & (0x1 << local_5a)) != 0)
						{
							// Instruction address 0x2d05:0x0834, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0((ushort)(stringPtr + optionPositions[i]),
								x + 5, y + 5 + (i * lineHeight), 3);

							this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + optionPositions[i]), 0x20);
						}
						else
						{
							// Instruction address 0x2d05:0x0834, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0((ushort)(stringPtr + optionPositions[i]),
								x + 5, y + 5 + (i * lineHeight), 0);

							this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + optionPositions[i]), 0x20);
						}
					}
				}
				else
				{
					if (local_5a < 0 && lineHeight > 9)
					{
						// Instruction address 0x2d05:0x087b, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0((ushort)(optionPositions[i] + stringPtr),
							x + 5, y + 6 + (i * lineHeight), 0);
					}

					if (local_5a < 0)
					{
						// Instruction address 0x2d05:0x08c6, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0((ushort)(optionPositions[i] + stringPtr),
							x + 5, y + (i * lineHeight) + 5, (byte)textColor);
					}
					else
					{
						if ((this.oParent.Var_b276 & (0x1 << local_5a)) != 0)
						{
							// Instruction address 0x2d05:0x08c6, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0((ushort)(optionPositions[i] + stringPtr),
								x + 5, y + (i * lineHeight) + 5, 3);
						}
						else
						{
							// Instruction address 0x2d05:0x08c6, size: 5
							this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0((ushort)(optionPositions[i] + stringPtr),
								x + 5, y + (i * lineHeight) + 5, 0);
						}
					}
				}

				this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + optionPositions[i + 1] - 1), 0xa);
				//}

				char ch = (char)this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(stringPtr + optionPositions[i + 1]));

				if (ch == ' ' || ch == '_')
				{
					local_5a++;
				}
			}

			// Instruction address 0x2d05:0x0135, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			if (this.oParent.Var_db38 == 0)
			{
				while (true)
				{
					if (this.oParent.Var_3936 != -1)
					{
						this.oParent.MeetWithKing.F6_0000_1b33();
					}

					this.oParent.Var_db3a_MouseButton = 0;

					// Instruction address 0x2d05:0x0165, size: 5
					this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

					if (this.oParent.Var_db3a_MouseButton != 0 || local_12 != 0)
					{
						this.oParent.Var_2fa2 = 1;
						local_12 = 1;

						if (this.oParent.Var_db3a_MouseButton == 2)
						{
							this.oParent.Var_2f9c = 1;
						}

						selectedOptionIndex = ((this.oParent.Var_db3e_MouseYPos - y - 4) / lineHeight) - firstOptionIndex;

						if (x > this.oParent.Var_db3c_MouseXPos || this.oParent.Var_db3c_MouseXPos > Var_de0e)
						{
							selectedOptionIndex = -1;
						}

						if ((this.oParent.Var_b276 & (0x1 << selectedOptionIndex)) == 0)
						{
							if (this.oParent.Var_db3a_MouseButton == 0)
							{
								local_8 = 1;
							}
						}
						else
						{
							selectedOptionIndex = local_2;
						}
					}
					else
					{
						// Instruction address 0x2d05:0x01db, size: 5
						if (this.oParent.CAPI.kbhit() != 0)
						{
							// Instruction address 0x2d05:0x01e5, size: 3
							int pressedKey = F0_2d05_0ac9_GetNavigationKey();

							switch (pressedKey)
							{
								case 0xd:
								case 0x20:
									if ((this.oParent.Var_b276 & (0x1 << selectedOptionIndex)) == 0)
									{
										local_8 = 1;
									}
									break;

								case 0x1b:
									selectedOptionIndex = -1;
									local_8 = 1;
									break;

								case 0x2300:
									this.oParent.Var_2f9c = 1;
									local_8 = 1;
									break;

								case 0x2f00:
									this.oParent.GameData.GameSettingFlags.Sound ^= true;

									if (!this.oParent.GameData.GameSettingFlags.Sound)
									{
										// Instruction address 0x2d05:0x03ad, size: 5
										this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);
									}
									break;

								case 0x4800:
									if (selectedOptionIndex > 0)
									{
										selectedOptionIndex--;
									}
									break;

								case 0x5000:
									if (selectedOptionIndex < optionCountMax - 1)
									{
										selectedOptionIndex++;
									}
									break;

								default:
									local_a = selectedOptionIndex + 1;

									while (local_a < 0x20)
									{
										if (optionFirstChar[local_a] == '\0' || (optionFirstChar[local_a] & 0x1f) != (pressedKey & 0x1f))
										{
											local_a++;
										}
										else
										{
											selectedOptionIndex = local_a;
											break;
										}
									}
									break;
							}
						}
					}

					if (selectedOptionIndex < 0 || selectedOptionIndex >= optionCountMax || this.oParent.Var_d206 != 0)
					{
						selectedOptionIndex = -1;
					}

					if (selectedOptionIndex != local_2)
					{
						// Instruction address 0x2d05:0x0243, size: 5
						this.oParent.Segment_11a8.F0_11a8_0268();

						if (local_2 != -1)
						{
							// Instruction address 0x2d05:0x027c, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
								x + 3, y + ((local_2 + firstOptionIndex) * lineHeight) + 4,
								maxLineWidth + 5, lineHeight, 11, (byte)backgroundColor);

							if (local_e != -1)
							{
								// Instruction address 0x2d05:0x02b2, size: 5
								this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
									x + 3, y + ((local_2 + firstOptionIndex) * lineHeight) + 4,
									maxLineWidth + 5, lineHeight, 3, (byte)local_e);
							}
						}

						if (selectedOptionIndex != -1)
						{
							// Instruction address 0x2d05:0x02ee, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
								x + 3, y + ((selectedOptionIndex + firstOptionIndex) * lineHeight) + 4,
								maxLineWidth + 5, lineHeight, (byte)backgroundColor, 11);

							if (local_e != -1)
							{
								// Instruction address 0x2d05:0x0324, size: 5
								this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
									x + 3, y + ((selectedOptionIndex + firstOptionIndex) * lineHeight) + 4,
									maxLineWidth + 5, lineHeight, (byte)local_e, 3);
							}
						}

						local_2 = selectedOptionIndex;

						// Instruction address 0x2d05:0x0332, size: 5
						this.oParent.Segment_11a8.F0_11a8_0250();
					}

					if (local_8 != 0)
					{
						if (selectedOptionIndex != -1)
						{
							// Instruction address 0x2d05:0x0349, size: 5
							this.oParent.Segment_11a8.F0_11a8_0268();

							if (this.oParent.Var_d762 == 0)
							{
								if (this.oParent.Var_2f9c != 0)
								{
									// Instruction address 0x2d05:0x0435, size: 5
									this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
										x + 3, y + ((selectedOptionIndex + firstOptionIndex) * lineHeight) + 4,
										maxLineWidth + 5, lineHeight, 11, 11);
								}
								else
								{
									// Instruction address 0x2d05:0x0435, size: 5
									this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
										x + 3, y + ((selectedOptionIndex + firstOptionIndex) * lineHeight) + 4,
										maxLineWidth + 5, lineHeight, 11, (byte)textColor);
								}
							}

							// Instruction address 0x2d05:0x0441, size: 5
							this.oParent.CommonTools.F0_1182_0134_WaitTimer(20);

							// Instruction address 0x2d05:0x0449, size: 5
							this.oParent.Segment_11a8.F0_11a8_0250();
						}
						else
						{
							this.oParent.Var_2f9c = 0;
						}

						break;
					}
				}

				this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.Default;
				this.oParent.Var_2f9a = -1;
				this.oParent.Var_2fa0 = 0;
				this.oParent.Var_d206 = 0;
				this.oParent.Var_b276 = 0;
				this.oParent.Var_d7f2 = 0;

				return selectedOptionIndex;
			}

			this.oParent.Var_db38 = 0;

			return -1;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_2d05_096c_FillRectangleWithDoubleShadow(int x, int y, int width, int height, ushort mode)
		{
			// function body
			if (mode == 7 && this.oParent.Var_2f98_PatternAvailable)
			{
				// Instruction address 0x2d05:0x098c, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_03ce_FillRectangleWithPattern(x + 1, y + 1, width, height);
			}
			else
			{
				// Instruction address 0x2d05:0x09b1, size: 5
				this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, x + 1, y + 1, width, height, mode);
			}
		
			this.oParent.Var_aa_Rectangle.BackColor = (byte)mode;

			// Instruction address 0x2d05:0x09e1, size: 3
			F0_2d05_0a66_DrawShadowRectangle(x + 1, y + 1, width, height, 15, 8);

			// Instruction address 0x2d05:0x09fd, size: 3
			F0_2d05_0a05_DrawRectangle(x, y, width + 2, height + 2, 0);
		}

		/// <summary>
		/// Draws a rectangle
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void F0_2d05_0a05_DrawRectangle(int x, int y, int width, int height, ushort mode)
		{
			// function body
			// Instruction address 0x2d05:0x0a1d, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x, y, x + width, y, mode);

			// Instruction address 0x2d05:0x0a34, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x, y + height, x + width, y + height, mode);

			// Instruction address 0x2d05:0x0a45, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x + width, y, x + width, y + height, mode);

			// Instruction address 0x2d05:0x0a5a, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x, y, x, y + height, mode);
		}

		/// <summary>
		/// Draws a shaddow rectangle
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		/// <param name="mode1"></param>
		public void F0_2d05_0a66_DrawShadowRectangle(int x, int y, int width, int height, ushort mode, ushort mode1)
		{
			// function body
			// Instruction address 0x2d05:0x0a7e, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x, y, x + width, y, mode1);

			// Instruction address 0x2d05:0x0a95, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x, y + height, x + width, y + height, mode);

			// Instruction address 0x2d05:0x0aa6, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x + width, y, x + width, y + height, mode1);

			// Instruction address 0x2d05:0x0abd, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, x, y + 1, x, y + height, mode);
		}

		/// <summary>
		/// Get navigation key
		/// </summary>
		/// <returns></returns>
		public int F0_2d05_0ac9_GetNavigationKey()
		{
			//this.oCPU.Log.EnterBlock("F0_2d05_0ac9_GetNavigationKey()");

			// function body
			// Instruction address 0x2d05:0x0acf, size: 5
			return this.oParent.CAPI.getch();
		}
	}
}
