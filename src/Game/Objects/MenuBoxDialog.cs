using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System.Diagnostics;

namespace OpenCiv1
{
	public class MenuBoxDialog
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		private string[] Array_2fa6 = { "Spies report:", "Diplomats report:", "Travelers report:", "Defense Minister reports:", "Domestic Advisor reports:", "Foreign Minister reports:", "Science Advisor reports:" };

		public MenuBoxDialog(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public int F0_2d05_0031_ShowMenuBox(ushort stringPtr, int x, int y, bool windowFrame, bool helpOption, bool emptyKeyboardAndMouse)
		{
			return F0_2d05_0031_ShowMenuBox(this.oCPU.ReadString(this.oCPU.DS.UInt16, stringPtr), x, y, windowFrame, helpOption, emptyKeyboardAndMouse);
		}

		/// <summary>
		/// Shows customized MenuBox
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="windowFrame"></param>
		/// <param name="helpOption"></param>
		/// <param name="emptyKeyboardAndMouse"></param>
		/// <returns></returns>
		public int F0_2d05_0031_ShowMenuBox(string menuString, int x, int y, bool windowFrame, bool helpOption, bool emptyKeyboardAndMouse)
		{
			//this.oCPU.Log.EnterBlock($"F0_2d05_0031_ShowMenuBox(0x{stringPtr:x4}, {x}, {y}, {emptyKeyboardAndMouse})");

			if (windowFrame && this.oParent.Var_2f9e_MessageBoxStyle != MenuBoxReportTypeEnum.None)
			{
				// Instruction address 0x2d05:0x0621, size: 5
				menuString = $"{Array_2fa6[(int)this.oParent.Var_2f9e_MessageBoxStyle]}\n{menuString}";
			}

			// We want to remove empty entries, because they shouldn't be in the list
			string[] menuItems = menuString.TrimEnd().Split("\n" , StringSplitOptions.RemoveEmptyEntries);

			#region Print debug data
			/*Debug.WriteLine($"\"{menuString}\"");

			Debug.Write("{");
			for (int i = 0; i < menuItems.Length; i++)
			{
				if (i > 0)
					Debug.Write(", ");

				Debug.Write($"\"{menuItems[i]}\"");
			}
			Debug.WriteLine("}");//*/
			#endregion

			this.oParent.Var_2fa2_DialogMousePressed = false;
			this.oParent.Var_2f9c_MenuBoxHelpRequested = false;

			// Determine maximum line width and height
			int lineHeight = this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			if (lineHeight == 9)
			{
				lineHeight--;
			}

			if (this.oParent.Var_3936 != -1)
			{
				lineHeight = 8;
			}

			List<int> optionIndexes = new();
			List<char> optionChars = new();
			int selectedOptionIndex = 0;
			int maxContentWidth = this.oParent.ScreenSize.Width - (windowFrame ? 8 : 0) - x - ((windowFrame && this.oParent.Var_2f9e_MessageBoxStyle != MenuBoxReportTypeEnum.None) ? 44 : 0);
			int maxContentHeight = this.oParent.ScreenSize.Height - (windowFrame ? 8 : 0) - y;
			int maxLineWidth = 0;
			int maxLineCount = (maxContentHeight - (helpOption && windowFrame ? 8 : 0)) / lineHeight;

			// limit the number of available lines to window height
			if (menuItems.Length > maxLineCount)
			{
				Array.Resize(ref menuItems, maxLineCount);
			}

			// Detect default checked char, it can be a simple space or a bullet, but not checkmark '^'
			char defaultCheckedChar = '\x0';

			for (int i = 0; i < menuItems.Length; i++)
			{
				string menuItem = menuItems[i];

				if (defaultCheckedChar == '\x0' && (menuItem.StartsWith(' ') || menuItem.StartsWith('_')))
				{
					defaultCheckedChar = menuItem[0];
					break;
				}
			}

			for (int i = 0; i < menuItems.Length; i++)
			{
				string menuItem = menuItems[i];
				int itemWidth = this.oParent.Graphics.GetDrawStringSize(this.oParent.Var_aa_Rectangle.FontID, menuItem).Width;

				if (optionIndexes.Count > 0 && !menuItem.StartsWith(defaultCheckedChar) && menuItem.StartsWith(' '))
				{
					menuItem = defaultCheckedChar + menuItem;

					// treat this as exception for now
					throw new Exception($"The menu items are not properly formed, the offending menu text: '{menuString}'");
				}

				// Trim the item to the available content size
				while (itemWidth > maxContentWidth)
				{
					menuItem = menuItem.Substring(0, menuItem.Length - 1);
					itemWidth = this.oParent.Graphics.GetDrawStringSize(this.oParent.Var_aa_Rectangle.FontID, menuItem + "...").Width;

					if (itemWidth <= maxContentWidth)
					{
						menuItem += "...";
						menuItems[i] = menuItem;
					}
				}

				if (itemWidth > maxLineWidth)
				{
					maxLineWidth = itemWidth;
				}

				// detect options and select checkmarks if necessary
				if (menuItem.StartsWith(defaultCheckedChar))
				{
					optionIndexes.Add(i);

					// test if this option is checked
					if ((this.oParent.Var_d7f2_MenuBoxCheckedOptions & (0x1 << optionIndexes.Count)) != 0)
					{
						// Current default is to pass space as first character and then ammend it to a checkmark (if selected)
						menuItems[i] = '^' + menuItem.Substring(1);
					}

					// These are the shortcut characters which can be selected with the keyboard
					// !!! To do: What if the shourtcut characters have a duplicate?
					if (menuItem.Length > 1)
					{
						optionChars.Add(menuItem[1]);
					}
				}
			}

			int contentLeft = x + (windowFrame ? 4 : 0) + ((windowFrame && this.oParent.Var_2f9e_MessageBoxStyle != MenuBoxReportTypeEnum.None) ? 44 : 0);
			int contentTop = y + (windowFrame ? 4 : 0);
			int contentWidth = maxLineWidth;
			int contentHeight = Math.Max((menuItems.Length * lineHeight) + (helpOption && windowFrame ? 8 : 0), ((windowFrame && this.oParent.Var_2f9e_MessageBoxStyle != MenuBoxReportTypeEnum.None) ? 60 : 0));

			int windowWidth = contentWidth + (windowFrame ? 8 : 0) + ((windowFrame && this.oParent.Var_2f9e_MessageBoxStyle != MenuBoxReportTypeEnum.None) ? 44 : 0);
			int windowHeight = contentHeight + (windowFrame ? 8 : 0);

			// Adjust default selected option (if selected)
			if (this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex != -1)
			{
				selectedOptionIndex = Math.Min(optionIndexes.Count - 1, this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex);
			}

			// Determine colors
			int textColor;
			int backgroundColor = 7;
			int highlightColor = 22;

			if (y == 139)
			{
				highlightColor = 8;
			}

			if (!windowFrame && y != 139)
			{
				// in this case we want for a background color to be as color on the screen
				backgroundColor = this.oParent.Graphics.F0_VGA_038c_GetPixel(0, x, y);
				highlightColor = -1;
			}

			textColor = (backgroundColor == 15) ? 3 : 15;

			if (windowFrame)
			{
				FillRectangleWithDoubleShadow(x, y, windowWidth, windowHeight, 7);

				if (this.oParent.Var_2f9e_MessageBoxStyle != MenuBoxReportTypeEnum.None)
				{
					// This is dialog image being drawn

					if (this.oParent.Var_2f9e_MessageBoxStyle == MenuBoxReportTypeEnum.DefenseMinisterReport ||
						this.oParent.Var_2f9e_MessageBoxStyle == MenuBoxReportTypeEnum.DomesticAdvisorReport ||
						this.oParent.Var_2f9e_MessageBoxStyle == MenuBoxReportTypeEnum.ForeignMinisterReport ||
						this.oParent.Var_2f9e_MessageBoxStyle == MenuBoxReportTypeEnum.ScienceAdvisorReport)
					{
						this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19e8_Rectangle,
							40 + (40 * (int)this.oParent.Var_2f9e_MessageBoxStyle), 140, 40, 60,
							this.oParent.Var_aa_Rectangle, contentLeft - 44, contentTop);
					}
					else
					{
						// Instruction address 0x2d05:0x06c8, size: 5
						this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle, 
							contentLeft - 44, contentTop, this.oParent.Array_df62[(int)this.oParent.Var_2f9e_MessageBoxStyle]);
					}
				}
			}

			if (windowFrame && helpOption)
			{
				int fontID = this.oParent.Var_aa_Rectangle.FontID;
				this.oParent.Var_aa_Rectangle.FontID = 2;

				string helpText = "(HELP AVAILABLE)";
				GSize helpSize = this.oParent.Graphics.GetDrawStringSize(this.oParent.Var_aa_Rectangle.FontID, helpText);

				// Instruction address 0x2d05:0x0787, size: 5
				this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(helpText, contentLeft + contentWidth - helpSize.Width, contentTop + contentHeight - helpSize.Height, 10);

				this.oParent.Var_aa_Rectangle.FontID = fontID;
			}

			this.oParent.Var_aa_Rectangle.FrontColor = (byte)textColor;

			int optionIndex = -1;

			for (int i = 0; i < menuItems.Length; i++)
			{
				string menuItem = menuItems[i];

				if (optionIndexes.Count > 0)
				{
					if (optionIndex == -1 && i == optionIndexes[0])
					{
						optionIndex = 0;
					}
					else if (optionIndex != -1)
					{
						if (optionIndex < optionIndexes.Count)
						{
							optionIndex++;
						}
						else
						{
							throw new Exception("Run out of options. This should never happen.");
						}
					}
				}

				if (optionIndex == -1)
				{
					if (lineHeight > 9)
					{
						// Instruction address 0x2d05:0x08c6, size: 5
						this.oParent.DrawStringTools.F0_1182_0086_DrawStringWithShadowToScreen0(menuItem, contentLeft, contentTop + (i * lineHeight), (byte)textColor);
					}
					else
					{
						// Instruction address 0x2d05:0x08c6, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(menuItem, contentLeft, contentTop + (i * lineHeight), (byte)textColor);
					}
				}
				else
				{
					if ((this.oParent.Var_d7f2_MenuBoxCheckedOptions & (0x1 << optionIndex)) != 0 || (this.oParent.Var_b276_MenuBoxDisabledOptions & (0x1 << optionIndex)) != 0)
					{
						// Instruction address 0x2d05:0x0834, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(menuItem, contentLeft, contentTop + (i * lineHeight), 3);
					}
					else
					{
						// Instruction address 0x2d05:0x0834, size: 5
						this.oParent.DrawStringTools.F0_1182_005c_DrawStringToScreen0(menuItem, contentLeft, contentTop + (i * lineHeight), 0);
					}
				}
			}

			if (emptyKeyboardAndMouse)
			{
				// Instruction address 0x2d05:0x003e, size: 5
				this.oParent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();
			}

			if (this.oParent.Var_db38 == 0)
			{
				int oldMouseX = -1;
				int oldMouseY = -1;
				int oldSelectedOptionIndex = -1;
				bool mouseActive = false;
				bool exitLoop = false;

				while (true)
				{
					if (this.oParent.Var_3936 != -1)
					{
						this.oParent.MeetWithKing.F6_0000_1b33();
					}

					this.oParent.Var_db3a_MouseButton = 0;

					// Instruction address 0x2d05:0x0165, size: 5
					this.oParent.MainCode.F0_11a8_0223_UpdateMouseState();

					if (this.oParent.Var_db3c_MouseXPos >= contentLeft && this.oParent.Var_db3c_MouseXPos <= contentLeft + contentWidth &&
						this.oParent.Var_db3e_MouseYPos >= contentTop && this.oParent.Var_db3e_MouseYPos <= contentTop + contentHeight)
					{
						if (this.oParent.Var_db3c_MouseXPos != oldMouseX && this.oParent.Var_db3e_MouseYPos != oldMouseY)
						{
							int selectedLine = ((this.oParent.Var_db3e_MouseYPos - contentTop) / lineHeight);

							for (int i = 0; i < optionIndexes.Count; i++)
							{
								if (selectedLine == optionIndexes[i])
								{
									selectedOptionIndex = i;
									mouseActive = true;
									break;
								}
							}

							oldMouseX = this.oParent.Var_db3c_MouseXPos;
							oldMouseY = this.oParent.Var_db3e_MouseYPos;
						}
					}
					else if (mouseActive && this.oParent.Var_db3a_MouseButton != 0)
					{
						selectedOptionIndex = -1;
						exitLoop = true;
					}

					if (!mouseActive && this.oParent.Var_db3a_MouseButton == 0)
					{
						mouseActive = true;
					}
					else if (mouseActive)
					{
						if (this.oParent.Var_db3a_MouseButton == 1)
						{
							this.oParent.Var_2fa2_DialogMousePressed = true;

							if (selectedOptionIndex == oldSelectedOptionIndex)
							{
								exitLoop = true;
							}
						}
						else if (this.oParent.Var_db3a_MouseButton == 2)
						{
							if (helpOption && selectedOptionIndex == oldSelectedOptionIndex)
							{
								this.oParent.Var_2f9c_MenuBoxHelpRequested = true;
								exitLoop = true;
							}
						}
					}

					// Instruction address 0x2d05:0x01db, size: 5
					if (this.oParent.CAPI.kbhit() != 0)
					{
						// Instruction address 0x2d05:0x01e5, size: 3
						int pressedKey = F0_2d05_0ac9_GetNavigationKey();

						switch (pressedKey)
						{
							case 0xd:
							case 0x20:
								if ((this.oParent.Var_b276_MenuBoxDisabledOptions & (0x1 << selectedOptionIndex)) == 0)
								{
									exitLoop = true;
								}
								break;

							case 0x1b:
								selectedOptionIndex = -1;
								exitLoop = true;
								break;

							case 0x2300:
								this.oParent.Var_2f9c_MenuBoxHelpRequested = true;
								exitLoop = true;
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
								if (selectedOptionIndex == -1 && optionIndexes.Count > 0)
								{
									selectedOptionIndex = 0;
								}
								else if (selectedOptionIndex > 0)
								{
									selectedOptionIndex--;
								}
								break;

							case 0x5000:
								if (selectedOptionIndex == -1 && optionIndexes.Count > 0)
								{
									selectedOptionIndex = 0;
								}
								else if (selectedOptionIndex < optionIndexes.Count - 1)
								{
									selectedOptionIndex++;
								}
								break;

							default:
								for (int i = 0; i < optionChars.Count; i++)
								{
									if (optionChars[i] != '\0' && optionChars[i] == pressedKey)
									{
										selectedOptionIndex = i;
										break;
									}
								}
								break;
						}
					}

					if (selectedOptionIndex < 0 || selectedOptionIndex >= optionIndexes.Count)
					{
						selectedOptionIndex = -1;
					}

					if (selectedOptionIndex != oldSelectedOptionIndex)
					{
						if (oldSelectedOptionIndex != -1)
						{
							int oldLineIndex = optionIndexes[oldSelectedOptionIndex];

							// Instruction address 0x2d05:0x027c, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
								contentLeft, contentTop + (oldLineIndex * lineHeight) - 1, maxLineWidth, lineHeight, 11, (byte)backgroundColor);

							if (highlightColor != -1)
							{
								// Instruction address 0x2d05:0x02b2, size: 5
								this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
									contentLeft, contentTop + (oldLineIndex * lineHeight) - 1, maxLineWidth, lineHeight, 3, (byte)highlightColor);
							}
						}

						if (selectedOptionIndex != -1)
						{
							int lineIndex = optionIndexes[selectedOptionIndex];

							// Instruction address 0x2d05:0x02ee, size: 5
							this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
								contentLeft, contentTop + (lineIndex * lineHeight) - 1, maxLineWidth, lineHeight, (byte)backgroundColor, 11);

							if (highlightColor != -1)
							{
								// Instruction address 0x2d05:0x0324, size: 5
								this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle,
									contentLeft, contentTop + (lineIndex * lineHeight) - 1, maxLineWidth, lineHeight, (byte)highlightColor, 3);
							}
						}

						oldSelectedOptionIndex = selectedOptionIndex;
					}

					if (exitLoop)
					{
						if (selectedOptionIndex != -1)
						{
							// Instruction address 0x2d05:0x0441, size: 5
							this.oParent.CommonTools.F0_1182_0134_WaitTimer(20);
						}
						else
						{
							this.oParent.Var_2f9c_MenuBoxHelpRequested = false;
						}

						break;
					}
				}

				this.oParent.Var_2f9e_MessageBoxStyle = MenuBoxReportTypeEnum.None;
				this.oParent.Var_2f9a_MenuBoxDefaultOptionIndex = -1;
				this.oParent.Var_b276_MenuBoxDisabledOptions = 0;
				this.oParent.Var_d7f2_MenuBoxCheckedOptions = 0;

				return selectedOptionIndex;
			}

			this.oParent.Var_db38 = 0;

			return -1;
		}

		/// <summary>
		/// Fills the rectangle and draws a double shadow around the rectangle
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <param name="width"></param>
		/// <param name="height"></param>
		/// <param name="mode"></param>
		public void FillRectangleWithDoubleShadow(int x, int y, int width, int height, ushort mode)
		{
			// function body
			if (mode == 7 && this.oParent.Var_2f98_PatternAvailable)
			{
				// Instruction address 0x2d05:0x098c, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_03ce_FillRectangleWithPattern(x, y, width, height);
			}
			else
			{
				// Instruction address 0x2d05:0x09b1, size: 5
				this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, x, y, width, height, mode);
			}

			this.oParent.Var_aa_Rectangle.BackColor = (byte)mode;

			// Instruction address 0x2d05:0x09e1, size: 3
			F0_2d05_0a66_DrawShadowRectangle(x - 1, y - 1, width + 1, height + 1, 15, 8);

			// Instruction address 0x2d05:0x09fd, size: 3
			F0_2d05_0a05_DrawRectangle(x - 2, y - 2, width + 3, height + 3, 0);
		}

		/// <summary>
		/// Fills the rectangle and draws a double shadow around the rectangle
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
