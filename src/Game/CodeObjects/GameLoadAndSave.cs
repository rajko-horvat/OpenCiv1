using Avalonia.Threading;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;
using System.Text;

namespace OpenCiv1
{
	public class GameLoadAndSave
	{
		private OpenCiv1Game parent;
		private VCPU CPU;

		private int Var_681a = 0;
		private int Var_e168 = 0;

		public GameLoadAndSave(OpenCiv1Game parent)
		{
			this.parent = parent;
			this.CPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="saveIndex"></param>
		/// <returns></returns>
		public int F11_0000_0000_LoadGameDialog(int saveIndex)
		{
			//this.oCPU.Log.EnterBlock($"F11_0000_0000({flag})");

			// function body
			/*LoadGameDialog? dialog = null;
			bool creatingWindow = true;

			Dispatcher.UIThread.Invoke(() => { try { dialog = new LoadGameDialog(this.parent); dialog.ShowDialog(this.parent.MainWindow); } finally { creatingWindow = false; } });

			while (creatingWindow) { Thread.Sleep(1); }

			while (dialog != null && !dialog.IsClosed) { Thread.Sleep(1); }//*/

			int local_d74e = 0;

			this.Var_681a = 1;

			if ((short)F11_0000_05f8() != -1)
			{
				if (saveIndex == -1)
				{
					local_d74e = 0;

					StringBuilder loadGameList = new();

					loadGameList.Append("\x008cSelect Load File...\n");

					for (int i = 0; i < 10; i++)
					{
						bool success;

						loadGameList.Append(F11_0000_0103_ReadGameData($"CIVIL{i}.SVE", out success));

						if (success)
						{
							local_d74e |= (0x1 << i);
						}
					}

					// Instruction address 0x0000:0x0087, size: 5
					this.Var_e168 = this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(loadGameList.ToString(), 48, 65, false, false, true);

					if (((0x1 << this.Var_e168) & local_d74e) == 0)
					{
						this.Var_e168 = -1;
					}
				}
				else
				{
					this.Var_e168 = saveIndex;
				}

				if (this.Var_e168 != -1 && !F11_0000_0103_LoadGame($"CIVIL{this.Var_e168}.SVE"))
				{
					this.Var_e168 = -1;
				}
			
				return this.Var_e168;
			}

			return -1;
		}

		/// <summary>
		/// Reads a data from a saved game
		/// </summary>
		/// <param name="filename"></param>
		/// <param name="success"></param>
		/// <returns>True if command succeeded</returns>
		public string F11_0000_0103_ReadGameData(string filename, out bool success)
		{
			//this.oCPU.Log.EnterBlock($"F11_0000_0103_LoadGame(0x{filename:x4}, {flag})");

			// function body
			try
			{
				FileStream reader = new FileStream($"{this.parent.ResourcePath}{filename}", FileMode.Open, FileAccess.Read);

				reader.Seek(2, SeekOrigin.Begin);
				int humanPlayerID = ReadInt16(reader);

				reader.Seek(8, SeekOrigin.Begin);
				int currentYear = ReadInt16(reader);

				reader.Seek(10, SeekOrigin.Begin);
				int gameDifficulty = ReadInt16(reader);

				reader.Seek(16 + (humanPlayerID * 14), SeekOrigin.Begin);
				string humanPlayerName = ReadString(reader, 14);

				reader.Seek(128 + (humanPlayerID * 12), SeekOrigin.Begin);
				string humanNationName = ReadString(reader, 12);

				reader.Close();

				success = true;

				return $" {this.parent.Array_33a2_GameDifficultyNames[gameDifficulty]} {humanPlayerName}, {humanNationName}/{this.parent.CAPI.itoa(Math.Abs(currentYear), 10)}" + 
					((currentYear < 0) ? " BC\n" : " AD\n");
			}
			catch
			{
				success = false;

				return " (Empty)\n";
			}
		}

		/// <summary>
		/// Loads a data from a save game
		/// </summary>
		/// <param name="filename"></param>
		/// <returns>True if command succeeded</returns>
		public bool F11_0000_0103_LoadGame(string filename)
		{
			//this.oCPU.Log.EnterBlock($"F11_0000_0103_LoadGame(0x{filename:x4}, {flag})");

			// function body
			bool result = F11_0000_083b_LoadGameData(filename);

			//this.oParent.GameInitAndIntro.F7_0000_1440_ConstructWaterPath();

			if (this.Var_e168 < 4)
			{
				this.parent.Var_df60 = 1;
			}
			else
			{
				this.parent.Var_df60 = 2;
			}

			this.parent.Var_3484 = -3;
			this.parent.GameData.SpaceshipFlags &= 0x7ffe;

			return result;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F11_0000_036a_SaveGameDialog(ushort param1)
		{
			this.CPU.Log.EnterBlock($"F11_0000_036a({param1})");

			// function body
			this.CPU.PUSH_UInt16(this.CPU.BP.UInt16);
			this.CPU.BP.UInt16 = this.CPU.SP.UInt16;
			this.CPU.SP.UInt16 = this.CPU.SUB_UInt16(this.CPU.SP.UInt16, 0x4);

			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x681c, 0);
			this.Var_681a = 0;

			// Instruction address 0x0000:0x0378, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, this.parent.Var_19d4_Screen1_Rectangle, 0, 0);

			F11_0000_05f8();

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x4), this.CPU.AX.UInt16);
			this.CPU.CMP_UInt16(this.CPU.AX.UInt16, 0xffff);
			if (this.CPU.Flags.NE) goto L0391;
			goto L04d0;

		L0391:
			// Instruction address 0x0000:0x0399, size: 5
			this.parent.CAPI.strcpy(0xba06, "\x008cSelect Save File...\n");

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2), 0x0);

		L03a6:
			bool temp;
			this.parent.CAPI.strcat(0xba06, F11_0000_0103_ReadGameData($"CIVIL{this.CPU.ReadUInt8(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2))}.SVE", out temp));
			
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2), 
				this.CPU.INC_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2))));
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x4);
			if (this.CPU.Flags.L) goto L03a6;

			// Instruction address 0x0000:0x03d3, size: 5
			this.parent.Var_2f9a_MenuBoxDefaultOptionIndex = this.parent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.Var_e168, 0, 3);

			this.CPU.CMP_UInt16(param1, 0xffff);
			if (this.CPU.Flags.NE) goto L0405;

			// Instruction address 0x0000:0x03e4, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();

			// Instruction address 0x0000:0x03f5, size: 5
			this.CPU.AX.Int16 = (short)this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 48, 33, false, false, true);

			param1 = this.CPU.AX.UInt16;

			// Instruction address 0x0000:0x0400, size: 5
			this.parent.MainCode.F0_11a8_0268_HideMouse();

		L0405:
			this.CPU.CMP_UInt16(param1, 0xffff);
			if (this.CPU.Flags.NE) goto L040e;
			goto L04d0;

		L040e:
			this.Var_e168 = (short)param1;
			this.CPU.AX.LowUInt8 = (byte)param1;
			this.CPU.AX.LowUInt8 = this.CPU.ADD_UInt8(this.CPU.AX.LowUInt8, 0x30);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, 0x41cd, this.CPU.AX.LowUInt8);

			F11_0000_04ef_SaveGame(0x41c6);
			
			this.CPU.AX.UInt16 = this.CPU.OR_UInt16(this.CPU.AX.UInt16, this.CPU.AX.UInt16);
			if (this.CPU.Flags.NE) goto L042e;
			goto L04d0;

		L042e:
			this.CPU.AX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x681c);
			this.CPU.CWD(this.CPU.AX, this.CPU.DX);
			this.CPU.DX.UInt16 = this.CPU.OR_UInt16(this.CPU.DX.UInt16, this.CPU.AX.UInt16);
			if (this.CPU.Flags.NE) goto L0448;

			// Instruction address 0x0000:0x043e, size: 5
			this.parent.CAPI.strcpy(0xba06, " Game has been saved.\n");

			goto L0478;

		L0448:
			// Instruction address 0x0000:0x0450, size: 5
			this.parent.CAPI.strcpy(0xba06, " Game NOT saved.\n");

			// Instruction address 0x0000:0x0470, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 64, 127, 192, 34, 12);

		L0478:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x681c), 0xd);
			if (this.CPU.Flags.NE) goto L048f;

			// Instruction address 0x0000:0x0487, size: 5
			this.parent.CAPI.strcat(0xba06, " Write access denied.\n");

		L048f:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x681c), 0x1c);
			if (this.CPU.Flags.NE) goto L04a6;

			// Instruction address 0x0000:0x049e, size: 5
			this.parent.CAPI.strcat(0xba06, " Disk Full.\n");

		L04a6:
			// Instruction address 0x0000:0x04ae, size: 5
			this.parent.CAPI.strcat(0xba06, " Press key to continue.\n");

			// Instruction address 0x0000:0x04c8, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 64, 127, false, false, true);

		L04d0:
			this.parent.Graphics.F0_VGA_07d8_DrawImage(this.parent.Var_19d4_Screen1_Rectangle, 0, 0, 320, 200, this.parent.Var_aa_Screen0_Rectangle, 0, 0);

			// Instruction address 0x0000:0x04e6, size: 5
			this.parent.MainCode.F0_11a8_0250_ShowMouse();

			this.CPU.SP.UInt16 = this.CPU.BP.UInt16;
			this.CPU.BP.UInt16 = this.CPU.POP_UInt16();
			// Far return
			this.CPU.Log.ExitBlock("F11_0000_036a");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="filenamePtr"></param>
		/// <returns></returns>
		public ushort F11_0000_04ef_SaveGame(ushort filenamePtr)
		{
			this.CPU.Log.EnterBlock($"F11_0000_04ef_SaveGame(0x{filenamePtr:x4})");

			// function body
			this.CPU.PUSH_UInt16(this.CPU.BP.UInt16);
			this.CPU.BP.UInt16 = this.CPU.SP.UInt16;
			this.CPU.SP.UInt16 = this.CPU.SUB_UInt16(this.CPU.SP.UInt16, 0x8);

			this.parent.Var_db38 = 1;

			// Instruction address 0x0000:0x0503, size: 5
			this.parent.CAPI.strcpy(0xba06, " ");

			// Instruction address 0x0000:0x0512, size: 5
			this.parent.CAPI.strcat(0xba06, filenamePtr);

			// Instruction address 0x0000:0x0522, size: 5
			this.parent.CAPI.strcat(0xba06, "\n ");

			// Instruction address 0x0000:0x0538, size: 5
			this.parent.CAPI.strcat(0xba06, this.parent.Array_33a2_GameDifficultyNames[this.parent.GameData.DifficultyLevel]);

			// Instruction address 0x0000:0x0548, size: 5
			this.parent.CAPI.strcat(0xba06, " ");

			// Instruction address 0x0000:0x055e, size: 5
			this.parent.CAPI.strcat(0xba06, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Name);

			// Instruction address 0x0000:0x056e, size: 5
			this.parent.CAPI.strcat(0xba06, "\n ");

			// Instruction address 0x0000:0x0584, size: 5
			this.parent.CAPI.strcat(0xba06, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].Nation);

			// Instruction address 0x0000:0x0594, size: 5
			this.parent.CAPI.strcat(0xba06, "/");

			// Instruction address 0x0000:0x059c, size: 5
			this.parent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

			// Instruction address 0x0000:0x05a9, size: 5
			this.parent.CAPI.strcat(0xba06, "\n ... save in progress.\n");

			// Instruction address 0x0000:0x05c3, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 64, 86, true, false, true);

			string path = this.CPU.ReadString(VCPU.ToLinearAddress(this.CPU.DS.UInt16, filenamePtr));
			F11_0000_08f6_SaveGameData(path);

			this.CPU.AX.UInt16 = 0x1;
			this.CPU.SP.UInt16 = this.CPU.BP.UInt16;
			this.CPU.BP.UInt16 = this.CPU.POP_UInt16();

			// Far return
			this.CPU.Log.ExitBlock("F11_0000_04ef_SaveGame");

			return this.CPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F11_0000_05f8()
		{
			this.CPU.Log.EnterBlock("F11_0000_05f8()");

			// function body
			this.CPU.PUSH_UInt16(this.CPU.BP.UInt16);
			this.CPU.BP.UInt16 = this.CPU.SP.UInt16;
			this.CPU.SP.UInt16 = this.CPU.SUB_UInt16(this.CPU.SP.UInt16, 0x6);
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x4384), 0xffff);
			if (this.CPU.Flags.NE) goto L0615;

			// Instruction address 0x0000:0x0609, size: 5
			this.parent.CAPI._dos_getdrive(0x4384);

			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384,
				this.CPU.DEC_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x4384)));

		L0615:
			// Instruction address 0x0000:0x0629, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 0, 0, 320, 200, 15);

			if (this.Var_681a != 0) goto L063d;

			// Instruction address 0x0000:0x0638, size: 5
			this.parent.UnitManagement.F0_1866_260e();

		L063d:
			if (this.Var_681a == 0) goto L0649;

			// Instruction address 0x0000:0x0651, size: 5
			this.parent.CAPI.strcpy(0xba06, "  Which drive contains your\n    saved game files?\n\n            ");
			goto L064c;

		L0649:
			// Instruction address 0x0000:0x0651, size: 5
			this.parent.CAPI.strcpy(0xba06, "  Which drive contains your\n     Save Game disk?\n\n            ");

		L064c:
			// Instruction address 0x0000:0x065d, size: 5
			this.parent.CAPI.strlen(0xba06);

			this.CPU.BX.UInt16 = this.CPU.AX.UInt16;
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.DS.UInt16, 0x4384);
			this.CPU.AX.LowUInt8 = this.CPU.ADD_UInt8(this.CPU.AX.LowUInt8, 0x41);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba05), this.CPU.AX.LowUInt8);

			// Instruction address 0x0000:0x0678, size: 5
			this.parent.CAPI.strcat(0xba06, ":\n\n    Press drive letter and\nReturn when disk is inserted.\n");

			// Instruction address 0x0000:0x0688, size: 5
			this.parent.CAPI.strcat(0xba06, "    Press Escape to cancel.\n");

			// Instruction address 0x0000:0x069f, size: 5
			this.parent.LanguageTools.F0_2f4d_0088_DrawTextBlock(99, 80, 72, 0);

			// Instruction address 0x0000:0x06a7, size: 5
			this.CPU.AX.Int16 = (short)this.parent.MenuBoxDialog.F0_2d05_0ac9_GetNavigationKey();

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2), this.CPU.AX.UInt16);
			this.CPU.CMP_UInt16(this.CPU.AX.UInt16, 0x41);
			if (this.CPU.Flags.E) goto L06b9;
			this.CPU.CMP_UInt16(this.CPU.AX.UInt16, 0x61);
			if (this.CPU.Flags.NE) goto L06bf;

		L06b9:
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384, 0x0);

		L06bf:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x42);
			if (this.CPU.Flags.E) goto L06cb;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x62);
			if (this.CPU.Flags.NE) goto L06d1;

			L06cb:
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384, 0x1);

		L06d1:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x43);
			if (this.CPU.Flags.E) goto L06dd;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x63);
			if (this.CPU.Flags.NE) goto L06e3;

		L06dd:
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384, 0x2);

		L06e3:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x44);
			if (this.CPU.Flags.E) goto L06ef;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x64);
			if (this.CPU.Flags.NE) goto L06f5;

		L06ef:
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384, 0x3);

		L06f5:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x45);
			if (this.CPU.Flags.E) goto L0701;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x65);
			if (this.CPU.Flags.NE) goto L0707;

		L0701:
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384, 0x4);

		L0707:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x46);
			if (this.CPU.Flags.E) goto L0713;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x66);
			if (this.CPU.Flags.NE) goto L0719;

		L0713:
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384, 0x5);

		L0719:
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x1b);
			if (this.CPU.Flags.NE) goto L0725;
			this.CPU.WriteUInt16(this.CPU.DS.UInt16, 0x4384, 0xffff);

		L0725:
			// Instruction address 0x0000:0x073d, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 80, 88, 160, 24, 15);

			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0xd);
			if (this.CPU.Flags.E) goto L0754;
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x1b);
			if (this.CPU.Flags.E) goto L0754;
			goto L063d;

		L0754:
			// Instruction address 0x0000:0x0769, size: 5
			this.parent.CommonTools.F0_1000_0bfa_FillRectangle(this.parent.Var_aa_Screen0_Rectangle, 8, 8, 304, 184, 15);

			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x4384), 0xffff);
			if (this.CPU.Flags.E) goto L07c7;

			F11_0000_07d6(this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x4384));

			this.CPU.AX.UInt16 = this.CPU.OR_UInt16(this.CPU.AX.UInt16, this.CPU.AX.UInt16);
			if (this.CPU.Flags.NE) goto L07c7;

			// Instruction address 0x0000:0x078f, size: 5
			this.parent.CAPI.strcpy(0xba06, "No Disk in Drive A.\n");

			// Instruction address 0x0000:0x079b, size: 5
			this.parent.CAPI.strlen(0xba06);

			this.CPU.BX.UInt16 = this.CPU.AX.UInt16;
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.DS.UInt16, 0x4384);
			this.CPU.AX.LowUInt8 = this.CPU.ADD_UInt8(this.CPU.AX.LowUInt8, 0x41);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, (ushort)(this.CPU.BX.UInt16 + 0xba03), this.CPU.AX.LowUInt8);

			// Instruction address 0x0000:0x07ba, size: 5
			this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 100, 80, true, false, true);

			this.CPU.AX.UInt16 = 0xffff;
			goto L07d2;

		L07c7:
			this.CPU.AX.LowUInt8 = this.CPU.ReadUInt8(this.CPU.DS.UInt16, 0x4384);
			this.CPU.AX.LowUInt8 = this.CPU.ADD_UInt8(this.CPU.AX.LowUInt8, 0x61);
			this.CPU.WriteUInt8(this.CPU.DS.UInt16, 0x41c6, this.CPU.AX.LowUInt8);
			this.CPU.AX.UInt16 = this.CPU.ReadUInt16(this.CPU.DS.UInt16, 0x4384);

		L07d2:
			this.CPU.SP.UInt16 = this.CPU.BP.UInt16;
			this.CPU.BP.UInt16 = this.CPU.POP_UInt16();

			// Far return
			this.CPU.Log.ExitBlock("F11_0000_05f8");

			return this.CPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <returns></returns>
		public ushort F11_0000_07d6(ushort param1)
		{
			this.CPU.Log.EnterBlock($"F11_0000_07d6({param1})");

			// function body
			this.CPU.PUSH_UInt16(this.CPU.BP.UInt16);
			this.CPU.BP.UInt16 = this.CPU.SP.UInt16;
			this.CPU.SP.UInt16 = this.CPU.SUB_UInt16(this.CPU.SP.UInt16, 0x12);
			this.CPU.CMP_UInt16(param1, 0x1);
			if (this.CPU.Flags.LE) goto L07e7;

		L07e2:
			this.CPU.AX.UInt16 = 0x1;
			goto L0837;

		L07e7:
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x12), param1);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x10), 0x0);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0xe), 0x0);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0xc), 0x2);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0xa), 0x1);
			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2), 0x0);

		L0806:
			// Instruction address 0x0000:0x080e, size: 5
			this.parent.CAPI._bios_disk(4, (ushort)(this.CPU.BP.UInt16 - 0x12));

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x4), this.CPU.AX.UInt16);
			this.CPU.TEST_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x4)), 0xff00);
			if (this.CPU.Flags.E) goto L07e2;

			// Instruction address 0x0000:0x0824, size: 5
			this.parent.CAPI._bios_disk(0, 0);

			this.CPU.WriteUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2),
				this.CPU.INC_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2))));
			this.CPU.CMP_UInt16(this.CPU.ReadUInt16(this.CPU.SS.UInt16, (ushort)(this.CPU.BP.UInt16 - 0x2)), 0x3);
			if (this.CPU.Flags.L) goto L0806;
			this.CPU.AX.UInt16 = 0;

		L0837:
			this.CPU.SP.UInt16 = this.CPU.BP.UInt16;
			this.CPU.BP.UInt16 = this.CPU.POP_UInt16();

			// Far return
			this.CPU.Log.ExitBlock("F11_0000_07d6");

			return this.CPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool F11_0000_083b_LoadGameData(string path)
		{
			path = path.ToUpper();

			this.CPU.Log.EnterBlock($"F11_0000_083b_LoadGameData('{path}')");

			// function body
			bool bSuccess = false;
			string filename = Path.GetFileNameWithoutExtension(CAPI.GetDOSFileName(path));

			try
			{
				// read map file
				GBitmap? map;

				if ((map = GBitmap.FromPICFile($"{this.parent.ResourcePath}{filename}.MAP", true)) == null)
					throw new Exception($"Can't read Map file '{filename}.MAP'");

				this.parent.GameData.Map = map;

				if (this.parent.Graphics.Screens.ContainsKey(3))
				{
					this.parent.Graphics.Screens.RemoveByKey(3);
				}

				this.parent.Graphics.Screens.Add(3, this.parent.GameData.Map);

				// read sve file
				FileStream reader = new FileStream($"{this.parent.ResourcePath}{filename}.SVE", FileMode.Open);
				this.parent.GameData.TurnCount = ReadInt16(reader);
				this.parent.GameData.HumanPlayerID = ReadInt16(reader);
				this.parent.GameData.PlayerFlags = ReadInt16(reader);
				this.parent.GameData.RandomSeed = ReadUInt16(reader);
				this.parent.GameData.Year = ReadInt16(reader);
				this.parent.GameData.DifficultyLevel = ReadInt16(reader);
				this.parent.GameData.ActiveCivilizations = ReadInt16(reader);
				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].ResearchTechnologyID = ReadInt16(reader);

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[13];
					reader.Read(buffer, 0, 13);
					reader.ReadByte();

					string sTemp = ASCIIEncoding.ASCII.GetString(buffer);
					int iPosition = sTemp.IndexOf('\0');

					if (iPosition >= 0)
					{
						sTemp = sTemp.Substring(0, iPosition);
					}

					this.parent.GameData.Players[i].Name = sTemp;
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[11];
					reader.Read(buffer, 0, 11);
					reader.ReadByte();

					string sTemp = ASCIIEncoding.ASCII.GetString(buffer);
					int iPosition = sTemp.IndexOf('\0');

					if (iPosition >= 0)
					{
						sTemp = sTemp.Substring(0, iPosition);
					}

					this.parent.GameData.Players[i].Nation = sTemp;
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[10];
					reader.Read(buffer, 0, 10);
					reader.ReadByte();

					string sTemp = ASCIIEncoding.ASCII.GetString(buffer);
					int iPosition = sTemp.IndexOf('\0');

					if (iPosition >= 0)
					{
						sTemp = sTemp.Substring(0, iPosition);
					}

					this.parent.GameData.Players[i].Nationality = sTemp;
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].Coins = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].ResearchProgress = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].ActiveUnits.Length; j++)
					{
						this.parent.GameData.Players[i].ActiveUnits[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].UnitsInProduction.Length; j++)
					{
						this.parent.GameData.Players[i].UnitsInProduction[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].DiscoveredTechnologyCount = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						this.parent.GameData.Players[i].DiscoveredTechnologyFlags[j] = ReadUInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].GovernmentType = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].Continents.Length; j++)
					{
						this.parent.GameData.Players[i].Continents[j].Strategy = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						this.parent.GameData.Players[i].Diplomacy[j] = ReadUInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].CityCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].UnitCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].LandCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SettlerCount = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].TotalCitySize = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].MilitaryPower = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].Ranking = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].TaxRate = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].Score = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].ContactPlayerCountdown = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].XStart = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].NationalityID = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].Continents[j].Attack = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].Continents[j].Defense = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].Continents.Length; j++)
					{
						this.parent.GameData.Players[i].Continents[j].CityCount = ReadInt16(reader);
					}
				}

				for (int i = 0; i < 16; i++)
				{
					this.parent.GameData.Continents[i].Size = ReadInt16(reader);
				}
				reader.Seek(48 * 2, SeekOrigin.Current);

				for (int i = 0; i < 16; i++)
				{
					this.parent.GameData.Oceans[i].Size = ReadInt16(reader);
				}
				reader.Seek(48 * 2, SeekOrigin.Current);

				for (int i = 0; i < 16; i++)
				{
					this.parent.GameData.Continents[i].BuildSiteCount = ReadInt16(reader);
				}

				for (int i = 0; i < 1200; i++)
				{
					this.parent.GameData.ScoreGraphData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.PeaceGraphData.Length; i++)
				{
					this.parent.GameData.PeaceGraphData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.Cities.Length; i++)
				{
					this.parent.GameData.Cities[i] = City.FromStream(i, reader);
				}

				for (int i = 0; i < 28; i++)
				{
					this.parent.GameData.Units[i] = UnitDefinition.FromStream(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.parent.GameData.Players[i].Units[j] = Unit.FromStream(reader);
					}
				}

				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						this.parent.GameData.MapVisibility[i, j] = (ushort)((short)((sbyte)ReadUInt8(reader)));
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Active = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Policy = ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Position.X = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						this.parent.GameData.Players[i].StrategicLocations[j].Position.Y = (sbyte)ReadUInt8(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.TechnologyFirstDiscoveredBy.Length; i++)
				{
					this.parent.GameData.TechnologyFirstDiscoveredBy[i] = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						this.parent.GameData.Players[i].UnitsDestroyed[j] = ReadInt16(reader);
					}
				}

				for (int i = 0; i < this.parent.GameData.CityNames.Length; i++)
				{
					char[] acCityName = new char[13];

					for (int j = 0; j < 13; j++)
					{
						acCityName[j] = (char)GameLoadAndSave.ReadUInt8(reader);
					}
					this.parent.GameData.CityNames[i] = new string(acCityName);
				}

				this.parent.GameData.ReplayDataLength = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.ReplayData.Length; i++)
				{
					this.parent.GameData.ReplayData[i] = ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.WonderCityID.Length; i++)
				{
					this.parent.GameData.WonderCityID[i] = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].LostUnits.Length; j++)
					{
						this.parent.GameData.Players[i].LostUnits[j] = ReadInt16(reader);

					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						this.parent.GameData.Players[i].TechnologyAcquiredFrom[j] = (sbyte)ReadUInt8(reader);
					}
				}

				this.parent.GameData.PollutedSquareCount = ReadInt16(reader);
				this.parent.GameData.PollutionEffectLevel = ReadInt16(reader);
				this.parent.GameData.GlobalWarmingCount = ReadInt16(reader);
				this.parent.GameData.GameSettingFlags.Value = ReadInt16(reader);

				//reader.Seek(260, SeekOrigin.Current); // Skip corrupted Land path data
				int[,] landPath = this.parent.UnitGoTo.Arr_db44_LandPath;

				for (int i = 0; i < 20; i++)
				{
					for (int j = 0; j < 13; j++)
					{
						landPath[i, j] = ReadUInt8(reader);
					}
				}

				this.parent.GameData.MaximumTechnologyCount = ReadInt16(reader);
				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].FutureTechnologyCount = ReadInt16(reader);
				this.parent.GameData.DebugFlags = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].ScienceTaxRate = ReadInt16(reader);
				}
				
				this.parent.GameData.NextAnthologyTurn = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].CumulativeEpicRanking = ReadInt16(reader);
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[180];
					reader.Read(buffer, 0, 180);

					for (int j = 0; j < 180; j++)
					{
						this.parent.GameData.Players[i].SpaceshipData[j] = (sbyte)buffer[j];
					}
				}

				this.parent.GameData.SpaceshipFlags = ReadInt16(reader);
				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].SpaceshipSuccessRate = ReadInt16(reader);
				this.parent.GameData.AISpaceshipSuccessRate = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SpaceshipETAYear = ReadInt16(reader);
				}

				for (int i = 0; i < 12; i++)
				{
					this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData1[i + 2] = ReadInt16(reader);
				}

				for (int i = 0; i < 12; i++)
				{
					this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData2[i] = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.CityPositions.Length; i++)
				{
					this.parent.GameData.CityPositions[i].X = (sbyte)ReadUInt8(reader);
				}

				for (int i = 0; i < this.parent.GameData.CityPositions.Length; i++)
				{
					this.parent.GameData.CityPositions[i].Y = (sbyte)ReadUInt8(reader);
				}

				this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceLevel = ReadInt16(reader);
				this.parent.GameData.PeaceTurnCount = ReadInt16(reader);
				this.parent.GameData.AIOpponentCount = ReadInt16(reader);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SpaceshipPopulation = ReadInt16(reader);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					this.parent.GameData.Players[i].SpaceshipLaunchYear = ReadInt16(reader);
				}

				this.parent.GameData.PlayerIdentityFlags = ReadInt16(reader);

				reader.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.parent.CAPI.strcpy(0xba06, ex.Message);

				// Instruction address 0x0000:0x08a3, size: 5
				this.parent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

				bSuccess = false;
			}

			// Far return
			this.CPU.Log.ExitBlock("F11_0000_083b_LoadGameData");

			return bSuccess;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void ReadData(Stream reader, ushort bufferPtr, ushort length)
		{
			reader.Read(this.CPU.Memory.MemoryContent,
				(int)VCPU.ToLinearAddress(this.CPU.DS.UInt16, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <param name="bufferSeg"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void ReadData(Stream reader, ushort bufferSeg, ushort bufferPtr, ushort length)
		{
			reader.Read(this.CPU.Memory.MemoryContent,
				(int)VCPU.ToLinearAddress(bufferSeg, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static byte ReadUInt8(Stream reader)
		{
			int byte0 = reader.ReadByte();

			if (byte0 >= 0)
			{
				return (byte)byte0;
			}

			return 0;
		}

		/// <summary>
		/// Reads a UInt16 from a Stream
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static ushort ReadUInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (ushort)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		/// <summary>
		/// Reads a UInt32 from a Stream
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static uint ReadUInt32(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();
			int byte2 = reader.ReadByte();
			int byte3 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0 && byte2 >= 0 && byte3 >= 0)
			{
				return (uint)(byte0 | (byte1 << 8) | (byte2 << 16) | (byte3 << 24));
			}

			return 0;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="reader"></param>
		/// <returns></returns>
		public static short ReadInt16(Stream reader)
		{
			int byte0 = reader.ReadByte();
			int byte1 = reader.ReadByte();

			if (byte0 >= 0 && byte1 >= 0)
			{
				return (short)(byte0 | (byte1 << 8));
			}

			return 0;
		}

		/// <summary>
		/// Reads a null terminated string from the stream (null character included)
		/// </summary>
		/// <param name="reader">Reading stream</param>
		/// <param name="length">Full string length, including null character</param>
		/// <returns></returns>
		public static string ReadString(Stream reader, int length)
		{
			int len = 0;
			char[] str = new char[length];
			bool end = false;

			for (int i = 0; i < length - 1; i++)
			{
				int ch = reader.ReadByte();

				if (!end && ch >= 0)
				{
					if (ch == 0)
					{
						end = true;
					}
					else
					{
						str[len] = (char)ch;
						len++;
					}
				}
			}

			reader.ReadByte();

			return new string(str, 0, len);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public bool F11_0000_08f6_SaveGameData(string path)
		{
			path = path.ToUpper();

			this.CPU.Log.EnterBlock($"F11_0000_08f6_SaveGameData('{path}')");

			// function body
			bool bSuccess = false;
			string filename = Path.GetFileNameWithoutExtension(CAPI.GetDOSFileName(path));

			try
			{
				// write map file
				this.parent.GameData.Map.SaveToPIC($"{this.parent.ResourcePath}{filename}.MAP", false);

				// write sve file
				FileStream writer = new FileStream($"{this.parent.ResourcePath}{filename}.SVE", FileMode.Create);
				WriteInt16(writer, this.parent.GameData.TurnCount);
				WriteInt16(writer, this.parent.GameData.HumanPlayerID);
				WriteInt16(writer, this.parent.GameData.PlayerFlags);
				WriteUInt16(writer, this.parent.GameData.RandomSeed);
				WriteInt16(writer, this.parent.GameData.Year);
				WriteInt16(writer, this.parent.GameData.DifficultyLevel);
				WriteInt16(writer, this.parent.GameData.ActiveCivilizations);
				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].ResearchTechnologyID);

				for (int i = 0; i < 8; i++)
				{
					string sTemp = this.parent.GameData.Players[i].Name;

					for (int j = 0; j < 13; j++)
					{
						if (j >= sTemp.Length)
						{
							writer.WriteByte(0);
						}
						else
						{
							writer.WriteByte((byte)sTemp[j]);
						}
					}
					writer.WriteByte(0);
				}

				for (int i = 0; i < 8; i++)
				{
					string sTemp = this.parent.GameData.Players[i].Nation;

					for (int j = 0; j < 11; j++)
					{
						if (j >= sTemp.Length)
						{
							writer.WriteByte(0);
						}
						else
						{
							writer.WriteByte((byte)sTemp[j]);
						}
					}
					writer.WriteByte(0);
				}

				for (int i = 0; i < 8; i++)
				{
					string sTemp = this.parent.GameData.Players[i].Nationality;

					for (int j = 0; j < 10; j++)
					{
						if (j >= sTemp.Length)
						{
							writer.WriteByte(0);
						}
						else
						{
							writer.WriteByte((byte)sTemp[j]);
						}
					}
					writer.WriteByte(0);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].Coins);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].ResearchProgress);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].ActiveUnits.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].ActiveUnits[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].UnitsInProduction.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].UnitsInProduction[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].DiscoveredTechnologyCount);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 5; j++)
					{
						WriteUInt16(writer, this.parent.GameData.Players[i].DiscoveredTechnologyFlags[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].GovernmentType);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].Continents.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].Strategy);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						WriteUInt16(writer, this.parent.GameData.Players[i].Diplomacy[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].CityCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].UnitCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].LandCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SettlerCount);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].TotalCitySize);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].MilitaryPower);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].Ranking);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].TaxRate);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].Score);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].ContactPlayerCountdown);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].XStart);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].NationalityID);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].Attack);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].Defense);
					}
				}
				
				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].Continents[j].CityCount);
					}
				}

				for (int i = 0; i < 16; i++)
				{
					WriteInt16(writer, this.parent.GameData.Continents[i].Size);
				}

				for (int i = 0; i < 48; i++)
				{
					WriteInt16(writer, 0);
				}

				for (int i = 0; i < 16; i++)
				{
					WriteInt16(writer, this.parent.GameData.Oceans[i].Size);
				}

				for (int i = 0; i < 48; i++)
				{
					WriteInt16(writer, 0);
				}

				for (int i = 0; i < 16; i++)
				{
					WriteInt16(writer, this.parent.GameData.Continents[i].BuildSiteCount);
				}

				for (int i = 0; i < 1200; i++)
				{
					writer.WriteByte(this.parent.GameData.ScoreGraphData[i]);
				}

				for (int i = 0; i < this.parent.GameData.PeaceGraphData.Length; i++)
				{
					writer.WriteByte(this.parent.GameData.PeaceGraphData[i]);
				}

				for (int i = 0; i < this.parent.GameData.Cities.Length; i++)
				{
					this.parent.GameData.Cities[i].ToStream(writer);
				}

				for (int i = 0; i < 28; i++)
				{
					this.parent.GameData.Units[i].ToStream(writer);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 128; j++)
					{
						this.parent.GameData.Players[i].Units[j].ToStream(writer);
					}
				}

				for (int i = 0; i < 80; i++)
				{
					for (int j = 0; j < 50; j++)
					{
						writer.WriteByte((byte)((sbyte)((short)this.parent.GameData.MapVisibility[i, j])));
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.parent.GameData.Players[i].StrategicLocations[j].Active);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte(this.parent.GameData.Players[i].StrategicLocations[j].Policy);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.parent.GameData.Players[i].StrategicLocations[j].Position.X);
					}
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 16; j++)
					{
						writer.WriteByte((byte)this.parent.GameData.Players[i].StrategicLocations[j].Position.Y);
					}
				}

				for (int i = 0; i < this.parent.GameData.TechnologyFirstDiscoveredBy.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.TechnologyFirstDiscoveredBy[i]);
				}

				for (int i = 0; i < 8; i++)
				{
					for (int j = 0; j < 8; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].UnitsDestroyed[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.CityNames.Length; i++)
				{
					for (int j = 0; j < 13; j++)
					{
						writer.WriteByte((byte)this.parent.GameData.CityNames[i][j]);
					}
				}

				WriteInt16(writer, this.parent.GameData.ReplayDataLength);
				for (int i = 0; i < this.parent.GameData.ReplayData.Length; i++)
				{
					writer.WriteByte(this.parent.GameData.ReplayData[i]);
				}

				for (int i = 0; i < this.parent.GameData.WonderCityID.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.WonderCityID[i]);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].LostUnits.Length; j++)
					{
						WriteInt16(writer, this.parent.GameData.Players[i].LostUnits[j]);
					}
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					for (int j = 0; j < this.parent.GameData.Players[i].TechnologyAcquiredFrom.Length; j++)
					{
						writer.WriteByte((byte)((sbyte)this.parent.GameData.Players[i].TechnologyAcquiredFrom[j]));
					}
				}

				WriteInt16(writer, this.parent.GameData.PollutedSquareCount);
				WriteInt16(writer, this.parent.GameData.PollutionEffectLevel);
				WriteInt16(writer, this.parent.GameData.GlobalWarmingCount);
				WriteInt16(writer, (short)this.parent.GameData.GameSettingFlags.Value);

				int[,] landPath = this.parent.UnitGoTo.Arr_db44_LandPath;

				for (int i = 0; i < 20; i++)
				{
					for (int j = 0; j < 13; j++)
					{
						writer.WriteByte((byte)landPath[i, j]);
					}
				}

				WriteInt16(writer, this.parent.GameData.MaximumTechnologyCount);
				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].FutureTechnologyCount);
				WriteInt16(writer, this.parent.GameData.DebugFlags);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].ScienceTaxRate);
				}
				
				WriteInt16(writer, this.parent.GameData.NextAnthologyTurn);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].CumulativeEpicRanking);
				}

				for (int i = 0; i < 8; i++)
				{
					byte[] buffer = new byte[180];

					for (int j = 0; j < 180; j++)
					{
						buffer[j] = (byte)this.parent.GameData.Players[i].SpaceshipData[j];
					}

					writer.Write(buffer, 0, 180);
				}

				WriteInt16(writer, this.parent.GameData.SpaceshipFlags);
				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].SpaceshipSuccessRate);
				WriteInt16(writer, this.parent.GameData.AISpaceshipSuccessRate);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SpaceshipETAYear);
				}

				for (int i = 0; i < 12; i++)
				{
					WriteInt16(writer, (short)this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData1[i + 2]);
				}

				for (int i = 0; i < 12; i++)
				{
					WriteInt16(writer, (short)this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceData2[i]);
				}

				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)((sbyte)this.parent.GameData.CityPositions[i].X));
				}
				for (int i = 0; i < 256; i++)
				{
					writer.WriteByte((byte)((sbyte)this.parent.GameData.CityPositions[i].Y));
				}

				WriteInt16(writer, this.parent.GameData.Players[this.parent.GameData.HumanPlayerID].PalaceLevel);
				WriteInt16(writer, this.parent.GameData.PeaceTurnCount);
				WriteInt16(writer, this.parent.GameData.AIOpponentCount);

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SpaceshipPopulation);
				}

				for (int i = 0; i < this.parent.GameData.Players.Length; i++)
				{
					WriteInt16(writer, this.parent.GameData.Players[i].SpaceshipLaunchYear);
				}

				WriteInt16(writer, this.parent.GameData.PlayerIdentityFlags);

				writer.Close();

				bSuccess = true;
			}
			catch (Exception ex)
			{
				this.parent.CAPI.strcpy(0xba06, ex.Message);
				this.parent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 4, 64, true, false, true);

				bSuccess = false;
			}

			// Far return
			this.CPU.Log.ExitBlock("F11_0000_08f6_SaveGameData");

			return bSuccess;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void WriteData(Stream writer, ushort bufferPtr, ushort length)
		{
			writer.Write(this.CPU.Memory.MemoryContent,
				(int)VCPU.ToLinearAddress(this.CPU.DS.UInt16, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="bufferSeg"></param>
		/// <param name="bufferPtr"></param>
		/// <param name="length"></param>
		private void WriteData(Stream writer, ushort bufferSeg, ushort bufferPtr, ushort length)
		{
			writer.Write(this.CPU.Memory.MemoryContent,
				(int)VCPU.ToLinearAddress(bufferSeg, bufferPtr), length);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteUInt16(Stream writer, ushort value)
		{
			writer.WriteByte((byte)(value & 0xff));
			writer.WriteByte((byte)((value & 0xff00) >> 8));
		}

		/// <summary>
		/// Writes an UInt32 to a Stream
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteUInt32(Stream writer, uint value)
		{
			writer.WriteByte((byte)(value & 0xff));
			writer.WriteByte((byte)((value & 0xff00) >> 8));
			writer.WriteByte((byte)((value & 0xff0000) >> 16));
			writer.WriteByte((byte)((value & 0xff000000) >> 24));
		}

		/// <summary>
		/// Writes an Int16 to a Stream
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="value"></param>
		public static void WriteInt16(Stream writer, short value)
		{
			writer.WriteByte((byte)((ushort)value & 0xff));
			writer.WriteByte((byte)(((ushort)value & 0xff00) >> 8));
		}

		/// <summary>
		/// Writes a null terminated string to a stream. Null character is included in the string length
		/// </summary>
		/// <param name="writer">Writer</param>
		/// <param name="text">String to write</param>
		/// <param name="length">maximum string length including the null character</param>
		public static void WriteString(Stream writer, string text, int length)
		{
			bool end = false;

			for (int i = 0; i < length - 1; i++)
			{
				if (!end && i < text.Length)
				{
					if (text[i] == 0)
					{
						end = true;
						writer.WriteByte(0);
					}
					else
					{
						writer.WriteByte((byte)text[i]);
					}
				}
				else
				{
					writer.WriteByte(0);
				}
			}

			writer.WriteByte(0);
		}
	}
}
