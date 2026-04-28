using IRB.VirtualCPU;
using OpenCiv1.UI;

namespace OpenCiv1
{
	public class TextBoxDialogs
	{
		private OpenCiv1Game parent;
		private VCPU CPU;

		public TextBoxDialogs(OpenCiv1Game parent)
		{
			this.parent = parent;
			this.CPU = parent.CPU;
		}

		/// <summary>
		/// Shows popup dialog allowing player to enter a custom name for a city.
		/// Updates name of a city with specified ID.
		/// </summary>
		/// <param name="cityID"></param>
		/// <returns>1 if player entered custom city name, 0 in case of rejected input</returns>
		public int F23_0000_0000_CityNameDialog(int cityID)
		{
			//this.oCPU.Log.EnterBlock($"F23_0000_0000_CityNameDialog({cityID})");

			// function body
			if (cityID >= 0 && cityID < 128)
			{
				string oldName = this.parent.GameData.CityNames[this.parent.GameData.Cities[cityID].NameID];
				string? cityName = EditBox.ShowEditBoxDialog(this.parent.MainWindow, "City name", "The name of your city",
					this.parent.GameData.CityNames[this.parent.GameData.Cities[cityID].NameID], 12, false);

				this.parent.GameData.CityNames[this.parent.GameData.Cities[cityID].NameID] =
					(string.IsNullOrEmpty(cityName) ? this.parent.GameData.CityNames[this.parent.GameData.Cities[cityID].NameID] : cityName);

				return (oldName.Equals(this.parent.GameData.CityNames[this.parent.GameData.Cities[cityID].NameID]) ? 0 : 1);
			}

			return 0;
			
			/*
			// Instruction address 0x0000:0x0006, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			// Save main screen graphics before showing popup dialog
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, this.parent.Var_19d4_Screen1_Rectangle, 0, 0);

			int editBoxResult = 0;
			int nameLength = 0;

			while (nameLength == 0)
			{
				// Dialog background
				// Instruction address 0x0000:0x0025, size: 5
				this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 80, 80, 160, 32, 15);

				// Borders
				// Instruction address 0x0000:0x003e, size: 5
				this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(80, 80, 160, 32, 11);

				// Title
				// Instruction address 0x0000:0x0055, size: 5
				this.parent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("City Name...", 88, 82, 0);

				this.CPU.WriteUInt8(this.CPU.DS.UInt16, 0xba06, 0x0);

				// Instruction address 0x0000:0x0065, size: 5
				this.parent.CAPI.strcat(0xba06, this.parent.Segment_2459.F0_2459_08c6_GetCityName(cityID));

				editBoxResult = F23_0000_0414_EditBoxDialog(88, 96, 12);

				// Instruction address 0x0000:0x0087, size: 5
				nameLength = this.parent.CAPI.strlen(0xba06);
			}

			if (editBoxResult != 0)
			{
				uint nameID = this.parent.GameData.Cities[cityID].NameID;
				char[] cityName = this.parent.GameData.CityNames[nameID].ToCharArray();

				for (int i = 0; i < 13; i++)
				{
					cityName[i] = (char)this.CPU.ReadUInt8(this.CPU.DS.UInt16, (ushort)(0xba06 + i));
				}

				this.parent.GameData.CityNames[nameID] = new string(cityName);
			}

			// Restore main screen graphics, 'hide' popup dialog
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 200, this.parent.Var_aa_Screen0_Rectangle, 0, 0);

			// Instruction address 0x0000:0x00ca, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();

			return editBoxResult;//*/
		}

		/// <summary>
		/// Shows dialog allowing player to enter its name.
		/// Updates human player name.
		/// </summary>
		public void F23_0000_00d6_PlayerNameDialog()
		{
			//this.CPU.Log.EnterBlock("F23_0000_00d6_PlayerNameDialog()");

			// function body
			string? playerName = EditBox.ShowEditBoxDialog(this.parent.MainWindow, "Your name", "Please enter your name", 
				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Name, 13, false);

			this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Name = 
				(string.IsNullOrEmpty(playerName) ? this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Name : playerName);

			/*
			// Instruction address 0x0000:0x00d6, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			// Dialog background
			// Instruction address 0x0000:0x00f3, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 158, 88, 160, 32, 15);

			// Borders
			// Instruction address 0x0000:0x010f, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(158, 88, 160, 32, 11);

			// Title
			// Instruction address 0x0000:0x0126, size: 5
			this.parent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("Your Name...", 166, 90, 0);

			// Instruction address 0x0000:0x013c, size: 5
			this.parent.CAPI.strcpy(0xba06, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Name);

			F23_0000_0414_EditBoxDialog(166, 104, 13);

			// Instruction address 0x0000:0x0165, size: 5
			this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Name = this.CPU.ReadString(this.CPU.DS.UInt16, 0xba06);

			// Instruction address 0x0000:0x016d, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();*/
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F23_0000_0173_TribeNameDialog()
		{
			//this.CPU.Log.EnterBlock("F23_0000_0173()");

			// function body

			string? nationality = EditBox.ShowEditBoxDialog(this.parent.MainWindow, "Nation name", "For example 'Zulu' (not 'Zulus')",
				 this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nationality, 10, false);

			this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nationality =
				(string.IsNullOrEmpty(nationality) ? this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nationality : nationality);

			// !!! To Do: Would need to change this, as different languages have different declinations rules, for now we will not add "s" to the end
			this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nation = this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nationality;

			/*
			// Instruction address 0x0000:0x0179, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			// Instruction address 0x0000:0x0196, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 158, 88, 160, 32, 15);

			// Instruction address 0x0000:0x01b2, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(158, 88, 160, 32, 11);

			// Instruction address 0x0000:0x01c9, size: 5
			this.parent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("Name of your Tribe...", 166, 90, 0);

			// Instruction address 0x0000:0x01df, size: 5
			this.parent.CAPI.strcpy(0xba06, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nation);

			F23_0000_0414_EditBoxDialog(166, 104, 11);

			string nationName = this.CPU.ReadString(this.CPU.DS.UInt16, 0xba06);

			// Instruction address 0x0000:0x0208, size: 5
			this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nation = nationName;

			if (nationName.EndsWith('s'))
			{
				nationName = nationName.Substring(0, nationName.Length - 1);
			}

			// Instruction address 0x0000:0x023c, size: 5
			this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nationality = (nationName.Length > 9) ? nationName.Substring(0, 9) : nationName;

			// Instruction address 0x0000:0x0252, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();*/
		}

		/// <summary>
		/// Shows find city dialog. Handles city name input and search.
		/// Centers map on a city if found.
		/// !!! To Do: Replace this TextBox dialog with a list of known cities.
		/// </summary>
		public void F23_0000_025b_FindCityDialog()
		{
			//this.oCPU.Log.EnterBlock("F23_0000_025b_FindCityDialog()");

			// function body

			string? cityName = EditBox.ShowEditBoxDialog(this.parent.MainWindow, "City name", "City name to search for", null, 12, true);

			/*
			// Instruction address 0x0000:0x0263, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			// Save main screen graphics before showing popup dialog
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, this.parent.Var_19d4_Screen1_Rectangle, 0, 0);

			// Dialog background
			// Instruction address 0x0000:0x0338, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 64, 78, 224, 24, 15);

			// Borders
			// Instruction address 0x0000:0x0353, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(64, 78, 224, 24, 0);

			// Title
			// Instruction address 0x0000:0x0369, size: 5
			this.parent.DrawStringTools.F0_1182_005c_DrawStringToScreen0("Where in the heck is ... (city name)", 66, 80, 0);

			this.CPU.WriteUInt8(this.CPU.DS.UInt16, 0xba06, 0x0);

			F23_0000_0414_EditBoxDialog(66, 89, 16);*/

			if (!string.IsNullOrEmpty(cityName))
			{
				int cityID = -1;
				//string cityName = this.CPU.ReadString(this.CPU.DS.UInt16, 0xba06);

				// Search all city names
				for (int j = 0; j < 128; j++)
				{
					int cityNameID = this.parent.GameData.Cities[j].NameID;

					if (this.parent.GameData.Cities[j].StatusFlag != 0xff && cityNameID >= 0 && cityNameID < 256 &&
						cityName.StartsWith(this.parent.GameData.CityNames[cityNameID], StringComparison.CurrentCultureIgnoreCase))
					{
						cityID = j;
						break;
					}
				}

				if (cityID != -1)
				{
					City city = this.parent.GameData.Cities[cityID];

					if ((this.parent.GameData.MapVisibility[city.Position.X, city.Position.Y] & (1 << this.parent.GameData.HumanPlayerID)) != 0)
					{
						// Center map at the found city
						this.parent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.parent.GameData.HumanPlayerID, city.Position.X - 7, city.Position.Y - 6);
						//this.parent.MainCode.F0_11a8_0250_ShowMouse();

						return;
					}
				}

				// Could not find the city by name, or the city is not visible
				MessageBox.Show(this.parent.MainWindow, $"Can not find the city named '{cityName}'.", "Unknown city", MessageBoxIcon.Information);
			}

			/*
			// Restore main screen graphics, 'hide' dialog
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 200, this.parent.Var_aa_Screen0_Rectangle, 0, 0);

			// Instruction address 0x0000:0x030e, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();*/
		}

		/// <summary>
		/// Draws and handles edit box logic which allows player to enter and edit a single line of text.
		/// Default text as well as a result are passed and retrieved using 0xba06 buffer.
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="maxTextLength">Maximum permitted length of text, determines width of edit box on the screen</param>
		/// <returns>1 if player has finished editing by pressing enter, 0 in case of rejected input (player pressed escape).</returns>
		/*public int F23_0000_0414_EditBoxDialog(int xPos, int yPos, int maxTextLength)
		{
			this.CPU.Log.EnterBlock($"F23_0000_0414_EditBox({xPos}, {yPos}, {maxTextLength})");

			// function body
			this.CPU.PUSH_UInt16(this.CPU.BP.UInt16);
			this.CPU.BP.UInt16 = this.CPU.SP.UInt16;
			this.CPU.SP.UInt16 = this.CPU.SUB_UInt16(this.CPU.SP.UInt16, 0x48);
			this.CPU.PUSH_UInt16(this.CPU.SI.UInt16);

			// Instruction address 0x0000:0x0434, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, xPos, yPos, (7 * maxTextLength), 11, 15);

			// Instruction address 0x0000:0x0456, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(xPos, yPos - 1, maxTextLength * 8 + 8, 13, 0);

			this.parent.Var_aa_Screen0_Rectangle.BackColor = 0xf;

			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x68cc, 0x0);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x42), 0x1);

			// Instruction address 0x0000:0x0476, size: 5
			this.parent.CAPI.strlen(0xba06);

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44), this.CPU.AX.UInt16);
			goto L048e;

		L0483:
			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44));
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x20);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44), this.CPU.INC_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44))));

		L048e:
			this.CPU.AX.Int16 = (short)maxTextLength;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44)), this.CPU.AX.UInt16);
			if (this.CPU.Flags.L) goto L0483;

			this.CPU.BX.UInt16 = this.CPU.AX.UInt16;
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x0);

			F23_0000_06c1(xPos, yPos, this.CPU.AX.Int16);

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x46), 0x1);
			goto L0525;

		L04b2:
			if (this.parent.Var_db3a_MouseButton != 0) goto L052e;

			// Instruction address 0x0000:0x04d6, size: 5
			this.parent.Graphics.F0_VGA_009a_ReplaceColor(this.parent.Var_aa_Screen0_Rectangle,
				this.CPU.ReadInt16(this.CPU.DS.UInt16, 0x68d0), yPos + 1,
				this.CPU.ReadInt16(this.CPU.DS.UInt16, 0x68ce), 10, 15, 11);

			// Text cursor blink time
			// Instruction address 0x0000:0x04e2, size: 5
			this.parent.CommonTools.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x0000:0x0503, size: 5
			this.parent.Graphics.F0_VGA_009a_ReplaceColor(this.parent.Var_aa_Screen0_Rectangle,
				this.CPU.ReadInt16(this.CPU.DS.UInt16, 0x68d0), yPos + 1,
				this.CPU.ReadInt16(this.CPU.DS.UInt16, 0x68ce), 10, 11, 15);

			// Instruction address 0x0000:0x050b, size: 5
			this.parent.CAPI.kbhit();

			this.CPU.AX.UInt16 = this.CPU.OR_UInt16(this.CPU.AX.UInt16, this.CPU.AX.UInt16);
			if (this.CPU.Flags.NE) goto L0520;

			// Instruction address 0x0000:0x0518, size: 5
			this.parent.CommonTools.F0_1182_0134_WaitTimer(10);

		L0520:
			// Instruction address 0x0000:0x0520, size: 5
			this.parent.MainCode.F0_11a8_0223_UpdateMouseState();

		L0525:
			// Instruction address 0x0000:0x0525, size: 5
			this.parent.CAPI.kbhit();

			this.CPU.AX.UInt16 = this.CPU.OR_UInt16(this.CPU.AX.UInt16, this.CPU.AX.UInt16);
			if (this.CPU.Flags.E) goto L04b2;

			L052e:
			if (this.parent.Var_db3a_MouseButton == 0) goto L053c;

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48), 0xd);
			goto L0544;

		L053c:
			// Instruction address 0x0000:0x053c, size: 5
			this.parent.CAPI.getch();

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48), this.CPU.AX.UInt16);

		L0544:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0x0);
			if (this.CPU.Flags.NE) goto L0555;

			// Instruction address 0x0000:0x054a, size: 5
			this.parent.CAPI.getch();

			this.CPU.AX.UInt16 = this.CPU.ADD_UInt16(this.CPU.AX.UInt16, 0x80);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48), this.CPU.AX.UInt16);

		L0555:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0xd);
			if (this.CPU.Flags.NE) goto L0565;

			L055b:
			this.CPU.AX.Int16 = (short)maxTextLength;
			this.CPU.AX.UInt16 = this.CPU.DEC_UInt16(this.CPU.AX.UInt16);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44), this.CPU.AX.UInt16);
			goto L069d;

		L0565:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0x1b);
			if (this.CPU.Flags.NE) goto L0572;
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x46), 0x0);
			goto L055b;

		L0572:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0xcb);
			if (this.CPU.Flags.NE) goto L0584;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc), 0x0);
			if (this.CPU.Flags.E) goto L0584;
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x68cc, this.CPU.DEC_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc)));

		L0584:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0xcd);
			if (this.CPU.Flags.NE) goto L0599;

			this.CPU.AX.Int16 = (short)maxTextLength;
			this.CPU.AX.UInt16 = this.CPU.DEC_UInt16(this.CPU.AX.UInt16);
			this.CPU.CMP_UInt16(this.CPU.AX.UInt16, this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc));
			if (this.CPU.Flags.LE) goto L0599;
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x68cc, this.CPU.INC_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc)));

		L0599:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0xd2);
			if (this.CPU.Flags.NE) goto L05d7;

			this.CPU.AX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc);
			this.CPU.AX.UInt16 = this.CPU.ADD_UInt16(this.CPU.AX.UInt16, 0xba06);
			// Instruction address 0x0000:0x05ab, size: 5
			this.parent.CAPI.strcpy((ushort)(this.CPU.BP.UInt16 - 0x40), this.CPU.AX.UInt16);

			this.CPU.AX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc);
			this.CPU.AX.UInt16 = this.CPU.ADD_UInt16(this.CPU.AX.UInt16, 0xba07);
			// Instruction address 0x0000:0x05be, size: 5
			this.parent.CAPI.strcpy(this.CPU.AX.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x40));

			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x20);
			this.CPU.BX.Int16 = (short)maxTextLength;
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x0);

		L05d7:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0xd3);
			if (this.CPU.Flags.NE) goto L060a;

			// Instruction address 0x0000:0x05ec, size: 5
			this.parent.CAPI.strcpy((ushort)(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc) + 0xba06), (ushort)(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc) + 0xba07));

			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x20);
			this.CPU.BX.Int16 = (short)maxTextLength;
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba05), 0x20);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x0);

		L060a:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0x8);
			if (this.CPU.Flags.NE) goto L063e;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc), 0x0);
			if (this.CPU.Flags.E) goto L063e;

			// Instruction address 0x0000:0x0625, size: 5
			this.parent.CAPI.strcpy((ushort)(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc) + 0xba05), (ushort)(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc) + 0xba06));

			this.CPU.BX.Int16 = (short)maxTextLength;
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba05), 0x20);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x0);
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x68cc, this.CPU.DEC_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc)));

		L063e:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0x80);
			if (this.CPU.Flags.GE) goto L0682;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48)), 0x20);
			if (this.CPU.Flags.L) goto L0682;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x42)), 0x0);
			if (this.CPU.Flags.E) goto L066b;
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44), 0x0);
			goto L0663;

		L0658:
			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44));
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x20);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44), this.CPU.INC_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44))));

		L0663:
			this.CPU.AX.Int16 = (short)maxTextLength;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44)), this.CPU.AX.UInt16);
			if (this.CPU.Flags.L) goto L0658;

			L066b:
			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc);
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x48));
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), this.CPU.AX.LowUInt8);
			this.CPU.AX.Int16 = (short)maxTextLength;
			this.CPU.AX.UInt16 = this.CPU.DEC_UInt16(this.CPU.AX.UInt16);
			this.CPU.CMP_UInt16(this.CPU.AX.UInt16, this.CPU.BX.UInt16);
			if (this.CPU.Flags.LE) goto L0682;
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x68cc, this.CPU.INC_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc)));

		L0682:
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x42), 0x0);

			F23_0000_06c1(xPos, yPos, maxTextLength);

			goto L0525;

		L069a:
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44), this.CPU.DEC_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44))));

		L069d:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44)), 0x0);
			if (this.CPU.Flags.LE) goto L06b4;
			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x44));
			this.CPU.CMP_UInt8(this.CPU.ReadUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06)), 0x20);
			if (this.CPU.Flags.NE) goto L06b4;
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06), 0x0);
			goto L069a;

		L06b4:
			// Instruction address 0x0000:0x06b4, size: 5
			this.parent.CheckPlayerTurn.F0_1403_4545_EmptyKeyboardAndMouse();

			this.CPU.AX.UInt16 = this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x46));
			this.CPU.SI.UInt16 = this.CPU.POP_UInt16();
			this.CPU.SP.UInt16 = this.CPU.BP.UInt16;
			this.CPU.BP.UInt16 = this.CPU.POP_UInt16();

			// Far return
			this.CPU.Log.ExitBlock("F23_0000_0414_EditBox");

			return this.CPU.AX.Int16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		public void F23_0000_06c1(int xPos, int yPos, int width)
		{
			this.CPU.Log.EnterBlock($"F23_0000_06c1({xPos}, {yPos}, {width})");

			// function body
			this.CPU.PUSH_UInt16(this.CPU.BP.UInt16);
			this.CPU.BP.UInt16 = this.CPU.SP.UInt16;
			this.CPU.SP.UInt16 = this.CPU.SUB_UInt16(this.CPU.SP.UInt16, 0x4);
			xPos += 2;
			yPos += 2;
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2), 0x0);
			goto L0777;

		L06d7:
			// Instruction address 0x0000:0x06ea, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, xPos, yPos, 8, 8, 15);

			// Instruction address 0x0000:0x06f6, size: 5
			this.parent.CAPI.strlen(0xba06);

			this.CPU.CMP_UInt16(this.CPU.AX.UInt16, this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)));
			if (this.CPU.Flags.LE) goto L0774;
			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2));
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba07));
			this.CPU.CBW(this.CPU.AX);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x4), this.CPU.AX.UInt16);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba07), 0x0);

			// Instruction address 0x0000:0x0722, size: 5
			this.parent.DrawStringTools.F0_1182_002a_DrawString((ushort)(0xba06 + this.CPU.BX.UInt16), xPos, yPos, 0);

			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2));
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x4));
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba07), this.CPU.AX.LowUInt8);
			this.CPU.AX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x68cc);
			this.CPU.CMP_UInt16(this.CPU.BX.UInt16, this.CPU.AX.UInt16);
			if (this.CPU.Flags.NE) goto L0759;
			this.CPU.AX.UInt16 = (ushort)xPos;
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x68d0, this.CPU.AX.UInt16);
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06));

			// Instruction address 0x0000:0x074e, size: 5
			this.parent.Graphics.F0_VGA_115d_GetCharWidth(this.parent.Var_aa_Screen0_Rectangle.FontID, this.CPU.AX.LowUInt8);

			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x68ce, this.CPU.AX.UInt16);

		L0759:
			this.CPU.BX.UInt16 = this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2));
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba06));

			// Instruction address 0x0000:0x0769, size: 5
			this.parent.Graphics.F0_VGA_115d_GetCharWidth(this.parent.Var_aa_Screen0_Rectangle.FontID, this.CPU.AX.LowUInt8);

			xPos += (short)this.CPU.AX.UInt16;

		L0774:
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2), this.CPU.INC_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2))));

		L0777:
			if (this.CPU.ReadInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)) >= width) goto L0782;
			goto L06d7;

		L0782:
			this.CPU.SP.UInt16 = this.CPU.BP.UInt16;
			this.CPU.BP.UInt16 = this.CPU.POP_UInt16();
			// Far return
			this.CPU.Log.ExitBlock("F23_0000_06c1");
		}*/
	}
}
