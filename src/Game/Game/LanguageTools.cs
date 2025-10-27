using IRB.VirtualCPU;
using System.Text;

namespace OpenCiv1
{
	public class LanguageTools
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public LanguageTools(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// Adjusts the width of a string by adding a new line where necessary
		/// </summary>
		/// <param name="maxLineWidth"></param>
		public void F0_2f4d_0000_AdjustLineWidth(int maxLineWidth)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_0000_AdjustLineWidth({maxLineWidth})");

			// function body
			int lineWidth = 0;

			for (int i = 0; i < this.oParent.MSCAPI.strlen(0xba06); i++)
			{
				if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0x5e)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i), 0x20);
					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i + 1), 0xa);

					lineWidth = -1;
				}

				if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0xa)
				{
					lineWidth = -1;
				}
			
				lineWidth++;

				if (lineWidth > maxLineWidth && this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0x20 &&
					this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i + 1)) != 0x20)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i), 0xa);
					lineWidth = 0;
				}
			}

			if (lineWidth > 0)
			{
				// Instruction address 0x2f4d:0x007c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\n");
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_0000_AdjustLineWidth");
		}

		/// <summary>
		/// Draws a text in a block of maximum width
		/// </summary>
		/// <param name="maxWidth"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="frontColor"></param>
		/// <returns></returns>
		public int F0_2f4d_0088_DrawTextBlock(int maxWidth, int xPos, int yPos, byte frontColor)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_0088_DrawTextBlock({maxWidth}, {xPos}, {yPos}, {frontColor})");

			// function body
			int charHeight;

			int lineWidth = 0;
			int linePos = 0;
			int lineStart = 0;

			// Instruction address 0x2f4d:0x00a0, size: 5
			charHeight = this.oParent.Graphics.F0_VGA_11ae_GetTextHeight(this.oParent.Var_aa_Rectangle.FontID);

			for (int i = 0; yPos <= 192 && i < this.oParent.MSCAPI.strlen(0xba06); i++)
			{
				this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i));

				// Instruction address 0x2f4d:0x00d9, size: 5
				lineWidth += this.oParent.Graphics.F0_VGA_115d_GetCharWidth(this.oParent.Var_aa_Rectangle.FontID, this.oCPU.AX.LowUInt8);

				if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0x20 ||
					this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0xa ||
					this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0x5e)
				{
					linePos = i;
				}

				if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0xa ||
					this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0x5e ||
					maxWidth * 8 < lineWidth)
				{
					byte local_2 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + linePos));

					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + linePos), 0x0);

					// Instruction address 0x2f4d:0x013b, size: 5
					this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA((ushort)(0xba06 + lineStart), xPos, yPos, frontColor);

					this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + linePos), local_2);

					yPos += charHeight;

					lineWidth = 0;
					lineStart = linePos + 1;

					if (this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(0xba06 + i)) == 0x5e)
					{
						lineStart++;
					}

					i = linePos;
				}
			}
		
			if (lineWidth <= 0)
				goto L01a6;
			
			if (yPos > 192)
				goto L01a6;

			// Instruction address 0x2f4d:0x0198, size: 5
			this.oParent.DrawStringTools.F0_1182_005c_DrawStringToRectAA((ushort)(0xba06 + lineStart), xPos, yPos, frontColor);

			yPos += charHeight;

		L01a6:
			this.oCPU.AX.UInt16 = (ushort)((short)yPos);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_0088_DrawTextBlock");

			return yPos;
		}

		public string F0_2f4d_01ad_GetTextBySectionAndKey(string filename, ushort keyPtr)
		{
			string key = this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, keyPtr));

			return F0_2f4d_01ad_GetLanguageItemBySectionAndKey(filename, key);
		}

		/// <summary>
		/// Gets the Language item from Language pack
		/// </summary>
		/// <param name="section"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public string F0_2f4d_01ad_GetLanguageItemBySectionAndKey(string section, string key)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_01ad_GetTextBySectionAndKey(\"{section}\", \"{key}\")");

			// function body
			string fullKey = section + "_" + key.Substring(1).Replace(' ', '_').Replace("'", "").Replace(".", "").ToUpper();
			StringBuilder languageItem = new StringBuilder();

			if (this.oGameData.Language.Items.ContainsKey(fullKey))
			{
				List<string> items = this.oGameData.Language.Items.GetValueByKey(fullKey);
				int lineCount = 0;

				for (int i = 0; i < items.Count; i++)
				{
					if (i > 0)
					{
						languageItem.Append('^');
					}

					languageItem.Append(items[i]);
					lineCount++;
				}

				this.oParent.MSCAPI.strcat(0xba06, languageItem.ToString().Replace("^", "^ "));

				this.oCPU.AX.UInt16 = (ushort)((short)lineCount);
			}
			else
			{
				throw new Exception($"Can't find a language item {fullKey}");
			}

			// We have introduced the Language packs, so we no longer need the old .TXT files
			// Leave this old part of a code just in case...
			/*StringBuilder itemText = new StringBuilder();
			int local_10c;
			FileStream inputStream;
			StreamReader textReader;
			string? line;

			inputStream = new FileStream(VCPU.DefaultCIVPath + section, FileMode.Open);
			inputStream.Seek(0x212, SeekOrigin.Begin);
			textReader = new StreamReader(inputStream, Encoding.ASCII);

			local_10c = 0;

			do
			{
				line = textReader.ReadLine();

				// Instruction address 0x2f4d:0x0310, size: 5
				if (line != null && line.Equals(key, StringComparison.CurrentCultureIgnoreCase))
				{
					line = textReader.ReadLine();

					while (line != null && line.StartsWith('*'))
					{
						line = textReader.ReadLine();
					}
					bool bAddSpace = false;

					while (line != null && !line.StartsWith('*'))
					{
						line = line.Trim();

						if (line.Length > 0)
						{
							if (bAddSpace)
							{
								itemText.Append(' ');
								bAddSpace = false;
							}

							if (line.EndsWith('^'))
							{
								itemText.Append(line.TrimEnd(' ', '^', '\n'));
								itemText.Append("^");
								bAddSpace = false;
							}
							else
							{
								itemText.Append(line);
								itemText.Append(" ");
								bAddSpace = false;
							}
						}

						line = textReader.ReadLine();

						local_10c++;
					}

					string temp = itemText.ToString().TrimEnd(' ', '^', '\n');

					this.oParent.MSCAPI.strcat(0xba06, temp);

					itemText.Clear();
					itemText.Append(temp);

					this.oCPU.AX.Word = (ushort)((short)local_10c);

					break;
				}
				else if (line == null)
				{
					this.oCPU.AX.Word = 0xffff;

					break;
				}
			}
			while (true);

			textReader.Close();*/

			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_01ad_GetTextBySectionAndKey");

			return languageItem.ToString();
		}

		/// <summary>
		/// Gets the Language item in king section from Language pack, replaces keywords, and adjusts the the width of the text
		/// </summary>
		/// <param name="stringPtr"></param>
		public void F0_2f4d_044f_GetAndAdjustLanguageItemFromKingSection(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_044f(0x{stringPtr:x4})");

			// function body
			// Instruction address 0x2f4d:0x045a, size: 3
			F0_2f4d_01ad_GetTextBySectionAndKey("KING", stringPtr);

			// Instruction address 0x2f4d:0x0461, size: 3
			this.oCPU.WriteString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0xba06),
				F0_2f4d_0471_ReplaceKeywords(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0xba06))));

			// Instruction address 0x2f4d:0x0469, size: 3
			F0_2f4d_0000_AdjustLineWidth(80);

			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_044f");
		}

		string[] Array_30ae = new string[] { "$US", "$THEM", "$BUCKS", "$RPLC1", "$RPLC2" };

		/// <summary>
		/// Replaces keywords in a string with their value
		/// </summary>
		public string F0_2f4d_0471_ReplaceKeywords(string text)
		{
			this.oCPU.Log.EnterBlock("F0_2f4d_0471_ReplaceKeywords()");

			// function body
			for (int i = 0; i < Array_30ae.Length; i++)
			{
				text = text.Replace(Array_30ae[i], this.oParent.Array_30b8[i]);
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_0471_ReplaceKeywords");

			return text;
		}

		/// <summary>
		/// Trims (deletes) the characters from the end of a string to a specified pixel width
		/// </summary>
		/// <param name="text">The text to trim</param>
		/// <param name="maxWidth">Maximum width in pixels</param>
		public string F0_2f4d_04f7_TrimStringToWidth(string text, int maxWidth)
		{
			this.oCPU.Log.EnterBlock($"F0_2f4d_04f7_TrimStringToWidth(0x{text:x4}, {maxWidth})");

			// function body
			// Instruction address 0x2f4d:0x053a, size: 5
			while (text.Length > 0 && this.oParent.DrawStringTools.F0_1182_00ef_GetStringWidth(text) > maxWidth)
			{
				if (text[text.Length - 2] != ' ')
				{
					text = text.Substring(0, text.Length - 2) + '.';
				}
				else
				{
					text = text.Substring(0, text.Length - 1);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_2f4d_04f7_TrimStringToWidth");

			return text;
		}
	}
}
