using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_23
	{
		private CivGame oParent;
		private VCPU oCPU;

		public Overlay_23(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// Shows popup dialog allowing player to enter a custom name for a city.
		/// Updates name of a city with specified ID.
		/// </summary>
		/// <param name="cityID"></param>
		/// <returns>1 if player entered custom city name, 0 in case of rejected input</returns>
		public ushort F23_0000_0000_CityNameDialog(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F23_0000_0000_CityNameDialog({cityID})");

			// function body
			// Instruction address 0x0000:0x0006, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Save main screen graphics before showing popup dialog
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			ushort editBoxResult;
			ushort nameLength = 0;

			do
			{
				// Dialog background
				// Instruction address 0x0000:0x0025, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 80, 80, 160, 32, 15);

				// Borders
				// Instruction address 0x0000:0x003e, size: 5
				this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(80, 80, 160, 32, 11);

				// Title
				// Instruction address 0x0000:0x0055, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("City Name...", 88, 82, 0);

				this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

				// Instruction address 0x0000:0x0065, size: 5
				this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

				editBoxResult = F23_0000_0414_EditBox(88, 96, 12);

				// Instruction address 0x0000:0x0087, size: 5
				nameLength = this.oParent.MSCAPI.strlen(0xba06);
			} while (nameLength == 0);

			if (editBoxResult != 0)
			{
				uint nameID = this.oParent.CivState.Cities[cityID].NameID;
				char[] cityName = this.oParent.CivState.CityNames[nameID].ToCharArray();
				
				for (int i = 0; i < 13; i++)
				{
					cityName[i] = (char)this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(0xba06 + i));
				}
				
				this.oParent.CivState.CityNames[nameID] = new string(cityName);
			}

			// Restore main screen graphics, 'hide' popup dialog
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x00ca, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Far return
			this.oCPU.Log.ExitBlock("F23_0000_0000_CityNameDialog");

			this.oCPU.AX.Word = editBoxResult;

			return editBoxResult;
		}

		/// <summary>
		/// Shows dialog allowing player to enter its name.
		/// Updates human player name.
		/// </summary>
		public void F23_0000_00d6_PlayerNameDialog()
		{
			this.oCPU.Log.EnterBlock("F23_0000_00d6_PlayerNameDialog()");

			// function body
			// Instruction address 0x0000:0x00d6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Dialog background
			// Instruction address 0x0000:0x00f3, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 158, 88, 160, 32, 15);

			// Borders
			// Instruction address 0x0000:0x010f, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(158, 88, 160, 32, 11);

			// Title
			// Instruction address 0x0000:0x0126, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Your Name...", 166, 90, 0);

			// Instruction address 0x0000:0x013c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Name);

			F23_0000_0414_EditBox(166, 104, 13);

			// Instruction address 0x0000:0x0165, size: 5
			this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Name = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			// Instruction address 0x0000:0x016d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Far return
			this.oCPU.Log.ExitBlock("F23_0000_00d6_PlayerNameDialog");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F23_0000_0173()
		{
			this.oCPU.Log.EnterBlock("F23_0000_0173()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x0179, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0196, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 158, 88, 160, 32, 15);

			// Instruction address 0x0000:0x01b2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(158, 88, 160, 32, 11);

			// Instruction address 0x0000:0x01c9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Name of your Tribe...", 166, 90, 0);

			// Instruction address 0x0000:0x01df, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Nation);

			F23_0000_0414_EditBox(0xa6, 0x68, 0xb);

			// Instruction address 0x0000:0x0208, size: 5
			this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Nation = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06);

			// Instruction address 0x0000:0x0214, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x73);
			if (this.oCPU.Flags.NE) goto L022e;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L022e:
			// Instruction address 0x0000:0x023c, size: 5
			this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Nationality = this.oCPU.ReadString(this.oCPU.DS.Word, 0xba06).Substring(0, 9);

			// Instruction address 0x0000:0x0252, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F23_0000_0173");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F23_0000_025b()
		{
			this.oCPU.Log.EnterBlock("F23_0000_025b()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0263, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			F23_0000_0319(0x53ce);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L02cd;

			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y];			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L02cd;

			// Instruction address 0x0000:0x02c3, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008(this.oParent.CivState.HumanPlayerID,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X - 7,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y - 6);

			goto L030e;

		L02cd:
			// Instruction address 0x0000:0x02e5, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 64, 78, 224, 10, 15);

			// Instruction address 0x0000:0x02fc, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Unknown city.", 82, 80, 0);

			// Instruction address 0x0000:0x0304, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L030e:
			// Instruction address 0x0000:0x030e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F23_0000_025b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <returns></returns>
		public ushort F23_0000_0319(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F23_0000_0319(0x{stringPtr:x4})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x14);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0338, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 64, 78, 224, 24, 15);

			// Instruction address 0x0000:0x0353, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(64, 78, 224, 24, 0);

			// Instruction address 0x0000:0x0369, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(stringPtr, 66, 80, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			F23_0000_0414_EditBox(66, 89, 16);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L03bc;

		L0390:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

		L0393:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x80);
			if (this.oCPU.Flags.GE) goto L03b9;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0390;
			this.oCPU.AX.Low = this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].NameID;
			this.oCPU.AX.High = 0;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			if (this.oCPU.Flags.NE) goto L0390;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			goto L040f;

		L03b9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L03bc:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x100);
			if (this.oCPU.Flags.GE) goto L040c;

			int uiCityNameID = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			ushort usStringOffset = (ushort)(this.oCPU.BP.Word - 0x10);

			for (int i = 0; i < 13; i++)
			{
				this.oCPU.Memory.WriteUInt8(this.oCPU.SS.Word, (ushort)(usStringOffset + i), this.oParent.CivState.CityNames[uiCityNameID][i]);
			}

			// Instruction address 0x0000:0x03e8, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			// Instruction address 0x0000:0x03f9, size: 5
			this.oParent.MSCAPI.strnicmp(0xba06, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L03b9;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			goto L0393;

		L040c:
			this.oCPU.AX.Word = 0xffff;

		L040f:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F23_0000_0319");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Draws and handles edit box logic which allows player to enter and edit a single line of text.
		/// Default text as well as a result are passed and retrieved using 0xba06 buffer.
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="lengthMax">Maximum permitted length of text, determines width of edit box on the screen</param>
		/// <returns>1 if player has finished editing by pressing enter, 0 in case of rejected input (player pressed escape).</returns>
		public ushort F23_0000_0414_EditBox(short xPos, short yPos, ushort lengthMax)
		{
			this.oCPU.Log.EnterBlock($"F23_0000_0414_EditBox({xPos}, {yPos}, {lengthMax})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x48);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0434, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos, yPos, (7 * lengthMax), 11, 15);

			// Instruction address 0x0000:0x0456, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(xPos, yPos - 1, lengthMax * 8 + 8, 13, 0);

			this.oParent.Var_aa_Rectangle.BackColor = 0xf;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x1);

			// Instruction address 0x0000:0x0476, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			goto L048e;

		L0483:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

		L048e:
			this.oCPU.AX.Word = lengthMax;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0483;
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

			F23_0000_06c1(xPos, yPos, this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x1);
			goto L0525;

		L04b2:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L052e;

			// Instruction address 0x0000:0x04d6, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68d0),	yPos + 1,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68ce), 10, 15, 11);

			// Text cursor blink time
			// Instruction address 0x0000:0x04e2, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

			// Instruction address 0x0000:0x0503, size: 5
			this.oParent.Graphics.F0_VGA_009a_ReplaceColor(this.oParent.Var_aa_Rectangle, 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68d0), yPos + 1,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68ce), 10, 11, 15);

			// Instruction address 0x0000:0x050b, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0520;

			// Instruction address 0x0000:0x0518, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

		L0520:
			// Instruction address 0x0000:0x0520, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

		L0525:
			// Instruction address 0x0000:0x0525, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04b2;

		L052e:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.E) goto L053c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0xd);
			goto L0544;

		L053c:
			// Instruction address 0x0000:0x053c, size: 5
			this.oParent.MSCAPI.getch();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

		L0544:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
			if (this.oCPU.Flags.NE) goto L0555;

			// Instruction address 0x0000:0x054a, size: 5
			this.oParent.MSCAPI.getch();

			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x80);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

		L0555:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd);
			if (this.oCPU.Flags.NE) goto L0565;

		L055b:
			this.oCPU.AX.Word = lengthMax;
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			goto L069d;

		L0565:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x1b);
			if (this.oCPU.Flags.NE) goto L0572;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x0);
			goto L055b;

		L0572:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xcb);
			if (this.oCPU.Flags.NE) goto L0584;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc), 0x0);
			if (this.oCPU.Flags.E) goto L0584;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L0584:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xcd);
			if (this.oCPU.Flags.NE) goto L0599;

			this.oCPU.AX.Word = lengthMax;
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc));
			if (this.oCPU.Flags.LE) goto L0599;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L0599:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd2);
			if (this.oCPU.Flags.NE) goto L05d7;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0xba06);
			// Instruction address 0x0000:0x05ab, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0xba07);
			// Instruction address 0x0000:0x05be, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.AX.Word, (ushort)(this.oCPU.BP.Word - 0x40));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.BX.Word = lengthMax;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L05d7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd3);
			if (this.oCPU.Flags.NE) goto L060a;

			// Instruction address 0x0000:0x05ec, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba06), (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba07));

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.BX.Word = lengthMax;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x20);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L060a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
			if (this.oCPU.Flags.NE) goto L063e;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc), 0x0);
			if (this.oCPU.Flags.E) goto L063e;

			// Instruction address 0x0000:0x0625, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba05), (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba06));

			this.oCPU.BX.Word = lengthMax;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x20);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L063e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x80);
			if (this.oCPU.Flags.GE) goto L0682;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x20);
			if (this.oCPU.Flags.L) goto L0682;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x0);
			if (this.oCPU.Flags.E) goto L066b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x0);
			goto L0663;

		L0658:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

		L0663:
			this.oCPU.AX.Word = lengthMax;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0658;

		L066b:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), this.oCPU.AX.Low);
			this.oCPU.AX.Word = lengthMax;
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.LE) goto L0682;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

		L0682:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x0);

			F23_0000_06c1(xPos, yPos, lengthMax);
			
			goto L0525;

		L069a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

		L069d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0x0);
			if (this.oCPU.Flags.LE) goto L06b4;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x20);
			if (this.oCPU.Flags.NE) goto L06b4;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
			goto L069a;

		L06b4:
			// Instruction address 0x0000:0x06b4, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F23_0000_0414_EditBox");

			return this.oCPU.AX.Word;
		}
		
		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="width"></param>
		public void F23_0000_06c1(short xPos, short yPos, ushort width)
		{
			this.oCPU.Log.EnterBlock($"F23_0000_06c1({xPos}, {yPos}, {width})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4);
			xPos += 2;
			yPos += 2;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0777;

		L06d7:
			// Instruction address 0x0000:0x06ea, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, xPos, yPos, 8, 8, 15);

			// Instruction address 0x0000:0x06f6, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			if (this.oCPU.Flags.LE) goto L0774;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07), 0x0);

			// Instruction address 0x0000:0x0722, size: 5
			this.oParent.Segment_1182.F0_1182_002a_DrawString((ushort)(0xba06 + this.oCPU.BX.Word), xPos, yPos, 0);
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07), this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
			this.oCPU.CMP_UInt16(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0759;
			this.oCPU.AX.Word = (ushort)xPos;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68d0, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06));

			// Instruction address 0x0000:0x074e, size: 5
			this.oParent.Graphics.F0_VGA_115d_GetCharWidth(this.oParent.Var_aa_Rectangle.FontID, this.oCPU.AX.Low);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68ce, this.oCPU.AX.Word);

		L0759:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06));
			
			// Instruction address 0x0000:0x0769, size: 5
			this.oParent.Graphics.F0_VGA_115d_GetCharWidth(this.oParent.Var_aa_Rectangle.FontID, this.oCPU.AX.Low);

			xPos += (short)this.oCPU.AX.Word;

		L0774:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0777:
			this.oCPU.AX.Word = width;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0782;
			goto L06d7;

		L0782:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F23_0000_06c1");
		}
	}
}
