using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_21
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Overlay_21(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F21_0000_0000(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F21_0000_0000({cityID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x10);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L004d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0016:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0043;
			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID !=
				this.oGameData.HumanPlayerID) goto L0043;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ImprovementFlags0, 0x1);
			if (this.oCPU.Flags.NE) goto L003d;
			
			if (cityID != -1)
				goto L0043;

		L003d:
			cityID = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

		L0043:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.L) goto L0016;

		L004d:
			// Instruction address 0x0000:0x004d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xfffe);
			if (this.oCPU.Flags.E) goto L0078;

			// Instruction address 0x0000:0x0070, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

		L0078:
			// Instruction address 0x0000:0x008c, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 100, 15);

			this.oParent.Var_aa_Rectangle.FontID = 4;

			// Instruction address 0x0000:0x00ad, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 1, 1, 318, 1, 0);

			// Instruction address 0x0000:0x00cd, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 8, 3, 304, 20, 15);

			this.oParent.Var_aa_Rectangle.BackColor = 0xf;

			// Instruction address 0x0000:0x00f0, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 35, 319, 35, 0);

			// Instruction address 0x0000:0x0105, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 1, 1, 1, 35, 0);

			// Instruction address 0x0000:0x0120, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 318, 1, 318, 35, 0);

			// Instruction address 0x0000:0x013a, size: 5
			this.oParent.Graphics.F0_VGA_0599_DrawLine(this.oParent.Var_aa_Rectangle, 0, 97, 319, 97, 0);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xfffe);
			if (this.oCPU.Flags.E) goto L017f;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);

		L014d:
			// Instruction address 0x0000:0x016e, size: 5
			this.oParent.Segment_1000.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				20 * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				100 - this.oParent.MSCAPI.RNG.Next(2),
				this.oParent.Var_df0c);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x10);
			if (this.oCPU.Flags.L) goto L014d;

		L017f:
			// Instruction address 0x0000:0x018e, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(40, 16, 40, 0);

			this.oParent.Var_aa_Rectangle.FontID = 5;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x01a8, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(4));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L01ce;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L01bc;
			goto L028d;

		L01bc:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L01c4;
			goto L029e;

		L01c4:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L01cc;
			goto L02bf;

		L01cc:
			goto L01e9;

		L01ce:
			// Instruction address 0x0000:0x01d1, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x01e1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Weekly");

		L01e9:
			// Instruction address 0x0000:0x01ed, size: 5
			this.oParent.Segment_1182.F0_1182_00ef_GetStringWidth(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x12c);
			if (this.oCPU.Flags.LE) goto L022c;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0205, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0215, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " News");

			// Instruction address 0x0000:0x0221, size: 5
			this.oParent.Segment_1182.F0_1182_00ef_GetStringWidth(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

		L022c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xc8);
			if (this.oCPU.Flags.GE) goto L0261;

			// Instruction address 0x0000:0x0242, size: 5
			this.oParent.Segment_1182.F0_1182_002a_DrawStringToRectAA(",-.", 8, 11, 0);

			// Instruction address 0x0000:0x0259, size: 5
			this.oParent.Segment_1182.F0_1182_002a_DrawStringToRectAA(",-.", 268, 11, 0);

		L0261:
			// Instruction address 0x0000:0x0270, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 11, 0);

			// Instruction address 0x0000:0x027c, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L02e0;

			// Instruction address 0x0000:0x02e8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "EXTRA!");

			goto L02e3;

		L028d:
			// Instruction address 0x0000:0x0290, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);
			
			// Instruction address 0x0000:0x01e1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Today");

			goto L01e9;

		L029e:
			// Instruction address 0x0000:0x02a6, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "The ");

			// Instruction address 0x0000:0x02b1, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);
			
			// Instruction address 0x0000:0x01e1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Times");

			goto L01e9;

		L02bf:
			// Instruction address 0x0000:0x02c7, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "The ");

			// Instruction address 0x0000:0x02d2, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);
			
			// Instruction address 0x0000:0x01e1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Tribune");

			goto L01e9;

		L02e0:
			// Instruction address 0x0000:0x02e8, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "FLASH");

		L02e3:
			this.oParent.Var_aa_Rectangle.FontID = 3;

			// Instruction address 0x0000:0x0308, size: 5
			this.oParent.Segment_1182.F0_1182_002a_DrawStringToRectAA(0xba06, 6, 3, 0);

			// Instruction address 0x0000:0x031f, size: 5
			this.oParent.Segment_1182.F0_1182_002a_DrawStringToRectAA(0xba06, 272, 3, 0);
			
			this.oParent.Var_aa_Rectangle.FontID = 1;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x033d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "10 cents");

			// Instruction address 0x0000:0x0354, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 272, 28, 0);

			// Instruction address 0x0000:0x0364, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "January 1, ");

			// Instruction address 0x0000:0x036c, size: 5
			this.oParent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

			// Instruction address 0x0000:0x0380, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToRectAA(0xba06, 8, 28, 0);

			this.oParent.Var_aa_Rectangle.FontID = 2;

			// Instruction address 0x0000:0x0399, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0xc), "*NEWSA");

			// Instruction address 0x0000:0x03a5, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(14));

			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x7), this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x7)), this.oCPU.AX.Low));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x03bd, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_01ad(0x5178, (ushort)(this.oCPU.BP.Word - 0xc));

			// Instruction address 0x0000:0x03d4, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToRectAA(0xba06, 160, 3, 0);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xfffe);
			if (this.oCPU.Flags.E) goto L041f;

			// Instruction address 0x0000:0x03f7, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0x5181, 80, 128, 1);

			// Instruction address 0x0000:0x0417, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L041f:
			// Instruction address 0x0000:0x041f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F21_0000_0000");
		}
	}
}
