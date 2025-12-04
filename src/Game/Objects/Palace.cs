using Avalonia.Media;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Palace
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public Palace(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F17_0000_0000()
		{
			this.oCPU.Log.EnterBlock("F17_0000_0000()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x110);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x0009, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x0017, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4ade);

			// Instruction address 0x0000:0x0028, size: 5
			this.oParent.CAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x100), 0xba06);

			// Instruction address 0x0000:0x003a, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(2, 1);

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			F17_0000_07ec(0);

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x006d, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x0075, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x0091, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(
				this.oParent.GameData.NationTypes[this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].NationalityID].LongTune, 3);

			// Instruction address 0x0000:0x009d, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4ae6, 1);

			// Instruction address 0x0000:0x00bd, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x00d2, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031((ushort)(this.oCPU.BP.UInt16 - 0x100), 20, 16, 1);

			// Instruction address 0x0000:0x00fa, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 20, 16, 280, 44, this.oParent.Var_aa_Rectangle, 20, 16);

			// Instruction address 0x0000:0x011a, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0xdb38, 0x1);

			// Instruction address 0x0000:0x0134, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(0x4af0, 40, 16, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 0x1);

		L0148:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)) + 2] >= 4)
				goto L01bc;

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)) + 1] > 0 ||
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)) + 3] > 0)
				goto L016a;

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)) + 2] < 0)
				goto L01bc;

		L016a:
			this.oCPU.AX.UInt16 = 0x30;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)));
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x24);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x0196, size: 5
			this.oParent.CAPI.strcat(0xba06,
				this.oParent.CAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 10));

			// Instruction address 0x0000:0x01ae, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)),
				144,
				14);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102), 0x1);

		L01bc:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x8);
			if (this.oCPU.Flags.L) goto L0148;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 0x0);

		L01cd:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[10 + this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)) + 1] >= 3)
				goto L0217;

			// Instruction address 0x0000:0x01e2, size: 5
			this.oParent.CAPI.strcpy(0xba06, "A");

			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 
				this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xba06), this.oCPU.AX.LowUInt8));

			// Instruction address 0x0000:0x0209, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)) * 120 + 40,
				160,
				14);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102), 0x1);

		L0217:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x3);
			if (this.oCPU.Flags.L) goto L01cd;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x102)), 0x0);
			if (this.oCPU.Flags.NE) goto L022c;
			goto L0792;

		L022c:
			// Instruction address 0x0000:0x022c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L0231:
			// Instruction address 0x0000:0x0231, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.NE) goto L0246;

			// Instruction address 0x0000:0x023d, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0231;

		L0246:
			// Instruction address 0x0000:0x0246, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L02a0;
			this.oCPU.CMP_UInt16(this.oParent.Var_db3e_MouseYPos, 0x9a);
			if (this.oCPU.Flags.GE) goto L0292;
			this.oCPU.AX.UInt16 = this.oParent.Var_db3c_MouseXPos;
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0xc);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x30;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);

		L0264:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), this.oCPU.AX.UInt16);

		L0268:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 2] >= 4)
				goto L0231;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x9);
			if (this.oCPU.Flags.L) goto L0289;

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 2] >= 3)
				goto L0231;

		L0289:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x9);
			if (this.oCPU.Flags.GE) goto L030e;
			goto L02e6;

		L0292:
			this.oCPU.AX.UInt16 = this.oParent.Var_db3c_MouseXPos;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x6b;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x9);
			goto L0264;

		L02a0:
			// Instruction address 0x0000:0x02a0, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x38);
			if (this.oCPU.Flags.GE) goto L02b5;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x30));
			goto L02ba;

		L02b5:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x58));

		L02ba:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x1);
			if (this.oCPU.Flags.GE) goto L02c4;
			goto L0231;

		L02c4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0xb);
			if (this.oCPU.Flags.LE) goto L0268;
			goto L0231;

		L02ce:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 3] > 0)
				goto L0307;

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 2] != -1)
				goto L0307;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e))));

		L02e6:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x4);
			if (this.oCPU.Flags.L) goto L02ce;
			goto L0307;

		L02ef:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 1] > 0 ||
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 2] != -1)
				goto L030e;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e), this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e))));

		L0307:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x4);
			if (this.oCPU.Flags.G) goto L02ef;

		L030e:
			// Instruction address 0x0000:0x030e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x032b, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x0000:0x0347, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 2] + 1,
				1, 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x9);
			if (this.oCPU.Flags.L) goto L035d;
			goto L0747;

		L035d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 0x1);

		L0363:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.AX.LowUInt8 = 0xff;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0xb25f), this.oCPU.AX.LowUInt8);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0xb25e), this.oCPU.AX.LowUInt8);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x8);
			if (this.oCPU.Flags.L) goto L0363;

			F17_0000_0cfe(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 0x1);

		L0393:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0xb25e));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.DI.UInt16 + 0xb25e), this.oCPU.AX.LowUInt8);
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0xb25f));
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.DI.UInt16 + 0xb25f), this.oCPU.AX.LowUInt8);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x3);
			if (this.oCPU.Flags.LE) goto L0393;
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6828, 0xffff);

			F17_0000_0e95(
				(ushort)(1 << this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110))),
				0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106), 0x5c);

			// Instruction address 0x0000:0x03fd, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 16, 2, 288, 102, 9);

			// Instruction address 0x0000:0x0415, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0("Select new section.", 160, 3, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 0x1);
			goto L0587;

		L0426:
			// Instruction address 0x0000:0x043e, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), 10,
				80, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106)), 1);

		L0429:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), 0x2);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x4);
			if (this.oCPU.Flags.GE) goto L0478;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), 0x1);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 1] == -1)
				goto L0472;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x1);
			if (this.oCPU.Flags.NE) goto L0478;

		L0472:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), 0x0);

		L0478:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x4);
			if (this.oCPU.Flags.LE) goto L049f;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), 0x1);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 3] == -1)
				goto L0499;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x7);
			if (this.oCPU.Flags.NE) goto L049f;

		L0499:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), 0x3);

		L049f:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a));
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L04c1;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L04af;
			goto L05af;

		L04af:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.NE) goto L04b7;
			goto L0609;

		L04b7:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.NE) goto L04bf;
			goto L062d;

		L04bf:
			goto L053e;

		L04c1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x1);
			if (this.oCPU.Flags.E) goto L0502;

			// Instruction address 0x0000:0x04fa, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)) + this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0x4b32),
				this.oCPU.ReadInt8(this.oCPU.DS.UInt16,
					(ushort)((0xf * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110))) +
					(5 * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))) + 0x4b32)) + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, 
					(ushort)(this.oCPU.BP.UInt16 - 0x108)) << 2) + 0xb23e)));

		L0502:
			// Instruction address 0x0000:0x052f, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)),
				this.oCPU.ReadInt8(this.oCPU.DS.UInt16,
				(ushort)((0xf * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110))) +
					(0x5 * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))) + 0x4b34)) + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, 
					(ushort)(this.oCPU.BP.UInt16 - 0x108)) << 2) + 0xb23c)));

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b32);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), this.oCPU.AX.UInt16));

		L053e:
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x055c, size: 5
			this.oParent.CAPI.strcat(0xba06,
				this.oParent.CAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 10));

			// Instruction address 0x0000:0x057b, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)) * 100 - 44,
				12,
				15);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))));

		L0587:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x3);
			if (this.oCPU.Flags.LE) goto L0591;
			goto L06ae;

		L0591:
			this.oCPU.AX.UInt16 = 0x64;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)));
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L05a9;
			goto L0426;

		L05a9:
			// Instruction address 0x0000:0x043e, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), 10,
				80, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x106)), 3);

			goto L0429;

		L05af:
			// Instruction address 0x0000:0x05dc, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)),
				this.oCPU.ReadInt8(this.oCPU.DS.UInt16,
					(ushort)(((0x5 * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))) +
					(0xf * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)))) + 0x4b32)) + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.UInt16,
					(ushort)(this.oCPU.BP.UInt16 - 0x108)) << 2) + 0xb23c)));

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b2e);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), this.oCPU.AX.UInt16));
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.DI.UInt16 + 0xb23e)));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0x4b33));

		L05f3:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)));

		L05fa:
			// Instruction address 0x0000:0x05fe, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(short)this.oCPU.POP_UInt16(), (short)this.oCPU.POP_UInt16(), this.oCPU.POP_UInt16());
			goto L053e;

		L0609:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb23c)));
			this.oCPU.AX.UInt16 = 0xf;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x5;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 + 0x4b31));
			goto L05f3;

		L062d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)), 0x7);
			if (this.oCPU.Flags.E) goto L0670;

			// Instruction address 0x0000:0x0661, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)),
				this.oCPU.ReadInt8(this.oCPU.DS.UInt16,
					(ushort)((0xf * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110))) +
					(0x5 * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108))) + 0x4b32)) + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, 
					(ushort)(this.oCPU.BP.UInt16 - 0x108)) << 2) + 0xb23c)));

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b2e);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104)), this.oCPU.AX.UInt16));

		L0670:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.PUSH_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb23e)));
			this.oCPU.AX.UInt16 = 0xf;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x5;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 + 0x4b35));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x108)), 0x2);
			if (this.oCPU.Flags.NE) goto L06a1;
			this.oCPU.AX.UInt16 = 0x3;
			goto L06a4;

		L06a1:
			this.oCPU.AX.UInt16 = 0x2;

		L06a4:
			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x104));
			this.oCPU.CX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.CX.UInt16, this.oCPU.AX.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.CX.UInt16);
			goto L05fa;

		L06ae:
			// Instruction address 0x0000:0x06b6, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6828), 0x4b27);

			// Instruction address 0x0000:0x06be, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x06c3, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L06c8:
			// Instruction address 0x0000:0x06c8, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.NE) goto L06dd;

			// Instruction address 0x0000:0x06d4, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L06c8;

		L06dd:
			// Instruction address 0x0000:0x06dd, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L06f5;
			this.oCPU.AX.UInt16 = this.oParent.Var_db3c_MouseXPos;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x6b;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), this.oCPU.AX.UInt16);
			goto L070a;

		L06f5:
			// Instruction address 0x0000:0x06f5, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x31);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.L) goto L06c8;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.G) goto L06c8;

		L070a:
			// Instruction address 0x0000:0x070a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			F17_0000_07ec(0);
			
			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x073f, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L0747:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e)) + 2] =
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x110));

			this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10e))] =
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10a));

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			F17_0000_07ec(0);

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x0000:0x0780, size: 5
			this.oParent.Graphics.F0_VGA_06b7_DrawScreenToMainScreen(1);

			// Instruction address 0x0000:0x0788, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			// Instruction address 0x0000:0x078d, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

		L0792:
			// Instruction address 0x0000:0x0795, size: 5
			this.oParent.CommonTools.F0_1000_0846(0);
			
			// Instruction address 0x0000:0x07a1, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(1, 0);

			// Instruction address 0x0000:0x07b2, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.NE) goto L07dc;

			// Instruction address 0x0000:0x07d4, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

		L07dc:
			// Instruction address 0x0000:0x07dc, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			// Instruction address 0x0000:0x07e1, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F17_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="flag"></param>
		public void F17_0000_07ec(ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F17_0000_07ec({flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x2e);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x07fd, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(2, 1);

			this.oParent.Var_aa_Rectangle.ScreenID = 1;

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6828, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0x0);

		L081d:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			this.oCPU.SI.UInt16 = (ushort)((short)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 2]);
			this.oCPU.CMP_UInt16(this.oCPU.SI.UInt16, 0xffff);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.AX.UInt16 = 0x1;
				this.oCPU.CX.UInt16 = this.oCPU.SI.UInt16;
				this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14),
					this.oCPU.OR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), this.oCPU.AX.UInt16));
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x9);
			if (this.oCPU.Flags.L) goto L081d;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0x1);

		L0843:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0xb25f), 0xff);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.SI.UInt16 + 0xb25e), 0xff);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 2] != -1)
			{
				F17_0000_0cfe(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 1);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x8);
			if (this.oCPU.Flags.L) goto L0843;

			F17_0000_0e95(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)),
				1);

			this.oCPU.CMP_UInt16(flag, 0x0);
			if (this.oCPU.Flags.E) goto L0897;
			
			// Instruction address 0x0000:0x089f, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4b81, 0);

			goto L089a;

		L0897:
			// Instruction address 0x0000:0x089f, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4b89, 0);

		L089a:
			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[12] > 0)
			{
				// Instruction address 0x0000:0x08b6, size: 5
				this.oParent.CAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x10), "cbacks0.pic");

				this.oCPU.AX.LowUInt8 = (byte)((sbyte)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[12]);
				this.oCPU.AX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.AX.LowUInt8, 0x30);
				this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.LowUInt8);

				// Instruction address 0x0000:0x08d8, size: 5
				this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0x87, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), 0x10);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[4] == -1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c),
					this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), 0x18));
			}
		
			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[4] == 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), 
					this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c))));
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20), 0x24);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0x8);
			goto L090c;

		L0906:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22),
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)));

		L090c:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 2] == -1)
				goto L0906;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0x1);

			goto L0b05;

		L0923:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x3);
			if (this.oCPU.Flags.NE) goto L0945;

			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)) + this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0x4b32)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				1);

		L0945:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))] != 1)
				goto L0957;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x3);
			if (this.oCPU.Flags.NE) goto L096d;

		L0957:
			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				0);

		L096d:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b32);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), this.oCPU.AX.UInt16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x3);
			if (this.oCPU.Flags.NE) goto L097f;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b2e);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), this.oCPU.AX.UInt16));

		L097f:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.AX.UInt16);
			goto L0b02;

		L0988:
			if (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)) + 1 == this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)))
			{
				this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
				this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

				this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
				this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

				if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))] ==
					this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))])
				{
					F17_0000_0e2f(
						this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
						this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)),
						(short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)) +
							this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0x4b2e) - 17),
						(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)) - 2),
						0);
				}
			}

			if (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)) - 1 == this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)))
			{
				this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
				this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

				this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18));
				this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

				if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))] ==
					this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18))])
				{
					F17_0000_0e2f(
						this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
						this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)),
						(short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)) +
							this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0x4b2e) - 17),
						(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)) - 2),
						1);
				}
			}
		
			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				0);
			
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b2e);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), this.oCPU.AX.UInt16));

			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				1);
			
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b2e);
			goto L0af9;

		L0a3e:
			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[4] == 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c),
					this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c))));
			}
		
			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)) - 2),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				0);
			
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b2c);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), this.oCPU.AX.UInt16));

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[4] == 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), 
					this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c))));
			}

			goto L0b02;

		L0a77:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x5);
			if (this.oCPU.Flags.NE) goto L0a99;

			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				0);
			
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b2e);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), this.oCPU.AX.UInt16));

		L0a99:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))] != 1)
				goto L0ac9;

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 1] <=
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 2])
				goto L0ac9;

			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)) - 3),
				(ushort)((short)(this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 1] -
					this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 2] +
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)) + 1)),
				1);

			goto L0ae9;

		L0ac9:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);			

			F17_0000_0e2f(
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)) -
					((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))] == 1) ? 3 : 2)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)),
				1);

		L0ae9:			
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x4b34);

		L0af9:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), this.oCPU.AX.UInt16));
			goto L0b02;

		L0afe:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), 0x30));

		L0b02:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))));

		L0b05:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x8);
			if (this.oCPU.Flags.GE) goto L0b87;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 2] == -1)
				goto L0afe;

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2e),
				(short)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 2]);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26), 0x2);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x4);
			if (this.oCPU.Flags.GE) goto L0b40;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26), 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 1] == -1)
				goto L0b3b;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x1);
			if (this.oCPU.Flags.NE) goto L0b40;

		L0b3b:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26), 0x0);

		L0b40:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x4);
			if (this.oCPU.Flags.LE) goto L0b62;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26), 0x1);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 3] == -1)
				goto L0b5d;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x7);
			if (this.oCPU.Flags.NE) goto L0b62;

		L0b5d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26), 0x3);

		L0b62:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26));
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L0b6c;
			goto L0923;

		L0b6c:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.NE) goto L0b74;
			goto L0988;

		L0b74:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.NE) goto L0b7c;
			goto L0a3e;

		L0b7c:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.NE) goto L0b84;
			goto L0a77;

		L0b84:
			goto L0b02;

		L0b87:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))] == 1)
			{
				if (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)) != 3)
				{
					F17_0000_0e2f(
						(ushort)((short)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)) + 2]),
						this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)),
						(short)((this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)) * 48) - 36),
						(ushort)((short)(this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)) + 3] -
							this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)) + 2] +
							this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20)))),
						0);
				}
			}

			// Instruction address 0x0000:0x0bc8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6828), 0x4b9f);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[11] == 0  &&
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[13] == 0)
				goto L0c94;

			// Instruction address 0x0000:0x0bee, size: 5
			this.oParent.CAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x10), "cbrush0.pic");

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[11] != 0)
			{
				this.oCPU.AX.LowUInt8 = (byte)((sbyte)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[11]);
				this.oCPU.AX.LowUInt8 = this.oCPU.SHL_UInt8(this.oCPU.AX.LowUInt8, 0x1);
				this.oCPU.AX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.AX.LowUInt8, 0x2e);
				this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.LowUInt8);

				// Instruction address 0x0000:0x0c0b, size: 5
				this.oCPU.AX.Int16 = (short)this.oParent.ImageTools.F0_2fa1_044c_LoadIcon((ushort)(this.oCPU.BP.UInt16 - 0x10));

				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2a), this.oCPU.AX.UInt16);

				// Instruction address 0x0000:0x0c2e, size: 5
				this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					0,
					((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[11] <= 1) ? 105 : 94),
					this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2a)));
			}

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[13] != 0)
			{
				this.oCPU.AX.LowUInt8 = (byte)((sbyte)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[13]);
				this.oCPU.AX.LowUInt8 = this.oCPU.SHL_UInt8(this.oCPU.AX.LowUInt8, 0x1);
				this.oCPU.AX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.AX.LowUInt8, 0x2f);
				this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.LowUInt8);

				// Instruction address 0x0000:0x0c4b, size: 5
				this.oCPU.AX.Int16 = (short)this.oParent.ImageTools.F0_2fa1_044c_LoadIcon((ushort)(this.oCPU.BP.UInt16 - 0x10));

				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2c), this.oCPU.AX.UInt16);

				// Instruction address 0x0000:0x0c6f, size: 5
				this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
					184, ((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[13] <= 1) ? 105 : 94),
					this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2c)));
			}
		
			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[11] != 0)
			{
				this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2a));
			}
			else
			{
				this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2c));
			}

			// Instruction address 0x0000:0x0c8c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.AX.UInt16, 0);

		L0c94:
			this.oCPU.CMP_UInt16(flag, 0x0);
			if (this.oCPU.Flags.E) goto L0cf9;

			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L0cc1;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xdeba), 0x7);
			if (this.oCPU.Flags.LE) goto L0cc1;

			// Instruction address 0x0000:0x0cb9, size: 5
			this.oParent.CommonTools.F0_1000_04d4_TransformPaletteToColor(5, Color.FromRgb(0, 0, 0));

		L0cc1:
			// Instruction address 0x0000:0x0cd4, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x0ce0, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4bb0, 1);

			// Instruction address 0x0000:0x0cf1, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

		L0cf9:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F17_0000_07ec");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="flag"></param>
		public void F17_0000_0cfe(ushort param1, ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F17_0000_0cfe({param1}, {flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			this.oCPU.SI.UInt16 = param1;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4),
				(short)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1 + 2]);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x2);

			this.oCPU.CMP_UInt16(param1, 0x4);
			if (this.oCPU.Flags.GE) goto L0d33;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1 + 1] == -1)
				goto L0d2e;

			if (param1 != 1)
				goto L0d33;

		L0d2e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

		L0d33:
			this.oCPU.CMP_UInt16(param1, 0x4);
			if (this.oCPU.Flags.LE) goto L0d55;
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x1);
			
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1 + 3] == -1)
				goto L0d50;

			this.oCPU.CMP_UInt16(param1, 0x7);
			if (this.oCPU.Flags.NE) goto L0d55;

		L0d50:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x3);

		L0d55:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0d6e;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L0d9f;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.E) goto L0ddd;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.E) goto L0de9;
			goto L0e2a;

		L0d6e:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25e), 0x3);
			this.oCPU.CMP_UInt16(param1, 0x3);
			if (this.oCPU.Flags.E) goto L0d87;
			this.oCPU.CMP_UInt16(flag, 0x0);
			if (this.oCPU.Flags.E) goto L0d87;
			goto L0e2a;

		L0d87:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L0d91;
			this.oCPU.AX.LowUInt8 = 0x1;
			goto L0d93;

		L0d91:
			this.oCPU.AX.LowUInt8 = 0x2;

		L0d93:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25f), this.oCPU.AX.LowUInt8);
			goto L0e2a;

		L0d9f:
			this.oCPU.SI.UInt16 = param1;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1 + 1] >
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1 + 2] ||
				param1 == 5)
				goto L0dbb;

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1] != -1)
				goto L0dc7;

		L0dbb:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25e), 0x1);
			goto L0dd1;

		L0dc7:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25e), 0x2);

		L0dd1:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25f), 0x2);
			goto L0e2a;

		L0ddd:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25e), 0x0);
			goto L0e2a;

		L0de9:
			this.oCPU.CMP_UInt16(param1, 0x5);
			if (this.oCPU.Flags.E) goto L0df5;
			this.oCPU.CMP_UInt16(flag, 0x0);
			if (this.oCPU.Flags.NE) goto L0e20;

		L0df5:
			this.oCPU.SI.UInt16 = param1;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1 + 1] >
				this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param1 + 2])
				goto L0e0a;

			this.oCPU.CMP_UInt16(param1, 0x5);
			if (this.oCPU.Flags.NE) goto L0e16;

		L0e0a:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25e), 0x1);
			goto L0e20;

		L0e16:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25e), 0x2);

		L0e20:
			this.oCPU.BX.UInt16 = param1;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + 0xb25f), 0x4);

		L0e2a:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F17_0000_0cfe");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="xPos"></param>
		/// <param name="param4"></param>
		/// <param name="flag"></param>
		public void F17_0000_0e2f(ushort param1, ushort param2, short xPos, ushort param4, ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F17_0000_0e2f({param1}, {param2}, {xPos}, {param4}, {flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x4);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			
			this.oCPU.SI.UInt16 = param2;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2),
				(short)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[param2 + 2]);

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4),
				(short)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[param2]);

			this.oCPU.BX.UInt16 = flag;
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 + 0xb25e));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x5;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			this.oCPU.DI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.DI.UInt16, this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = 0xf;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.DI.UInt16 + 0x4b36));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, param4);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, param1);
			// Instruction address 0x0000:0x0e87, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, (short)this.oCPU.AX.UInt16,
				this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)((flag << 1) + (param2 << 2) + 0xb23c)));

			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F17_0000_0e2f");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F17_0000_0e95(ushort param1, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F17_0000_0e95({param1}, {param2})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x1a);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), 0x0);
			goto L104e;

		L0ea4:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)) + 1),
				0x34, 0x63);

		L0eb4:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 + 0xb23c), this.oCPU.AX.UInt16);

		L0ed0:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 + 0xb25e)), 0xff);
			if (this.oCPU.Flags.E) goto L0ef6;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x6828), 0xffff);
			if (this.oCPU.Flags.NE) goto L0ef6;
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 + 0xb23c));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x6828, this.oCPU.AX.UInt16);

		L0ef6:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L0ef9:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x2);
			if (this.oCPU.Flags.L) goto L0f02;
			goto L0fdf;

		L0f02:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, (ushort)(this.oCPU.BX.UInt16 + this.oCPU.SI.UInt16 + 0xb25e));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0ea4;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L0f29;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.E) goto L0f40;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.E) goto L0f55;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x4);
			if (this.oCPU.Flags.E) goto L0f99;
			goto L0ed0;

		L0f29:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)) + 0x35),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)) + 1),
				0x18, 0x63);

		L0f3c:
			goto L0eb4;

		L0f40:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)) + 0x4e),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)) + 1),
				0x18, 0x63);
			goto L0f3c;

		L0f55:
			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.E) goto L0f67;
			
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))] != 1)
				goto L0f73;

		L0f67:
			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.NE) goto L0f88;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), 0x2);
			if (this.oCPU.Flags.E) goto L0f88;

		L0f73:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)) + 0x67),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)) + 1),
				0x1c, 0x63);
			goto L0f3c;

		L0f88:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 0xa0, 0x65, 0x23, 0x63);
			goto L0f3c;

		L0f99:
			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.E) goto L0fab;
			
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))] != 1)
				goto L0fb7;

		L0fab:
			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.NE) goto L0fcd;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), 0x2);
			if (this.oCPU.Flags.E) goto L0fcd;

		L0fb7:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)) + 0x84),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18)) + 1),
				0x1b, 0x63);
			goto L0f3c;

		L0fcd:
			// Instruction address 0x0000:0x0eb8, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 0xc4, 0x65, 0x23, 0x63);
			goto L0f3c;

		L0fdf:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))));

		L0fe2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)), 0x8);
			if (this.oCPU.Flags.GE) goto L104b;
			
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if (this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData1[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)) + 2] ==
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)))
				goto L0ffc;

			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.NE) goto L0fdf;

		L0ffc:
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			this.oCPU.SI.UInt16 = 
				(ushort)((short)this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].PalaceData2[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))]);
			this.oCPU.AX.UInt16 = this.oCPU.SI.UInt16;

			this.oCPU.AX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CX.UInt16 = 0xa0;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = this.oCPU.SI.UInt16;
			this.oCPU.AX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.AX.UInt16, 0x2);
			this.oCPU.CX.UInt16 = 0x32;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);

			this.oCPU.CMP_UInt16(param2, 0x0);
			if (this.oCPU.Flags.NE) goto L1043;
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12));
			this.oCPU.SI.UInt16 = this.oCPU.DEC_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SI.UInt16;
			this.oCPU.AX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CX.UInt16 = 0xa0;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SI.UInt16;
			this.oCPU.AX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.AX.UInt16, 0x2);
			this.oCPU.CX.UInt16 = 0x32;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);

		L1043:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			goto L0ef9;

		L104b:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))));

		L104e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)), 0x5);
			if (this.oCPU.Flags.GE) goto L1091;
			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.TEST_UInt16(this.oCPU.AX.UInt16, param1);
			if (this.oCPU.Flags.E) goto L104b;

			// Instruction address 0x0000:0x1069, size: 5
			this.oParent.CAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x10), "castle0.pic");

			this.oCPU.AX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a));
			this.oCPU.AX.LowUInt8 = this.oCPU.ADD_UInt8(this.oCPU.AX.LowUInt8, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.LowUInt8);

			// Instruction address 0x0000:0x1081, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), 0x1);
			goto L0fe2;

		L1091:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F17_0000_0e95");
		}
	}
}
