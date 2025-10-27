using IRB.Collections.Generic;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class Help
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Help(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		public void F4_0000_0000(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F4_0000_0000(0x{stringPtr:x4})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x18);

			// Instruction address 0x0000:0x000e, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.UInt16 - 0x18), "*");

			// Instruction address 0x0000:0x0019, size: 5
			this.oParent.MSCAPI.strupr(stringPtr);

			// Instruction address 0x0000:0x0026, size: 5
			this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x003b, size: 5
			this.oParent.LanguageTools.F0_2f4d_01ad_GetTextBySectionAndKey("HELP", (ushort)(this.oCPU.BP.UInt16 - 0x18));

			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L00a5;

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			// Instruction address 0x0000:0x0065, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 2);

			// Instruction address 0x0000:0x007c, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA((ushort)(this.oCPU.BP.UInt16 - 0x18), 160, 192, 0);

			// Instruction address 0x0000:0x008e, size: 5
			this.oParent.LanguageTools.F0_2f4d_0088_DrawTextBlock(32, 32, 32, 15);

			// Instruction address 0x0000:0x0096, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L00a5:
			this.oParent.Var_2f9c = 0;

			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F4_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F4_0000_00af(short playerID, ushort unitID)
		{
			this.oCPU.Log.EnterBlock($"F4_0000_00af({playerID}, {unitID})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0xc);
			this.oCPU.PUSHUInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);

			TerrainTypeEnum local_c;
			EnumFlagCollection<TerrainImprovementEnum> local_a;

			this.oCPU.CMPUInt16(unitID, 0x80);
			if (this.oCPU.Flags.L) goto L00c1;
			goto L02cd;

		L00c1:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x00dd, size: 5
			local_c = this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].Position.X, this.oGameData.Players[playerID].Units[unitID].Position.Y].TerrainType;

			this.oCPU.AX.UInt16 = (ushort)((short)this.oGameData.Static.Terrains.GetValueByKey(local_c).Production);
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = (ushort)((short)this.oGameData.Static.Terrains.GetValueByKey(local_c).Food);
			this.oCPU.AX.UInt16 = this.oCPU.ADDUInt16(this.oCPU.AX.UInt16, this.oCPU.CX.UInt16);

			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.L) goto L0108;
			this.oCPU.AX.UInt16 = 0x1;
			goto L010a;

		L0108:
			this.oCPU.AX.UInt16 = 0;

		L010a:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0120, size: 5
			//this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
			//	this.oGameData.Players[playerID].Units[unitID].Position.X + 80,
			//	this.oGameData.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				(short)this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].Position.X,
					this.oGameData.Players[playerID].Units[unitID].Position.Y].Layer2_PlayerOwnership);

			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0xa);
			if (this.oCPU.Flags.GE) goto L0135;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

		L0135:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x1);

		L013a:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.SI.UInt16 = this.oCPU.SHLUInt16(this.oCPU.SI.UInt16, 0x1);

			GPoint direction = TerrainMap.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))];

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, unitID);
			this.oCPU.DI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.DI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x016c, size: 5
			//this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
			//	this.oGameData.Players[playerID].Units[unitID].Position.X + direction.X + 80,
			//	this.oGameData.Players[playerID].Units[unitID].Position.Y + direction.Y);

			this.oCPU.AX.UInt16 = (ushort)((short)this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].Position.X + direction.X,
				this.oGameData.Players[playerID].Units[unitID].Position.Y + direction.Y].Layer2_PlayerOwnership);

			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			if (this.oCPU.Flags.LE) goto L017e;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x0);

		L017e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.INCUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x8);
			if (this.oCPU.Flags.LE) goto L013a;
			this.oCPU.CMPUInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L01c3;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x01b5, size: 5
			this.oParent.MapManagement.F0_2aea_0008(this.oGameData.HumanPlayerID,
				this.oGameData.Players[playerID].Units[unitID].Position.X - 7, this.oGameData.Players[playerID].Units[unitID].Position.Y - 6);

			F4_0000_02d3(0x34bb);

			goto L02cd;

		L01c3:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x01df, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102_FindNearestCity(this.oGameData.Players[playerID].Units[unitID].Position.X, this.oGameData.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, 0xffff);
			if (this.oCPU.Flags.NE) goto L01f2;
			goto L02cd;

		L01f2:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = (ushort)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))].PlayerID;
			this.oCPU.CMPUInt16(this.oCPU.AX.UInt16, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L0207;
			goto L02cd;

		L0207:
			if (this.oParent.Var_6c9a == 1) goto L0211;
			goto L02cd;

		L0211:
			// Instruction address 0x0000:0x021d, size: 5
			local_a = this.oGameData.Map[this.oGameData.Players[playerID].Units[unitID].Position].Improvements;

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x0230, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));

			// Instruction address 0x0000:0x0240, size: 5
			this.oParent.Array_30b8[0] = this.oCPU.ReadString(this.oCPU.DS.UInt16, 0xba06);

			if (local_c != TerrainTypeEnum.Hills) goto L025f;

			if (local_a.ContainsAnyFlag(TerrainImprovementEnum.Irrigation, TerrainImprovementEnum.Mine)) goto L025f;

			F4_0000_02d3(0x34c6);

		L025f:
			if (local_c != TerrainTypeEnum.Plains) goto L0298;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0281, size: 5
			this.oParent.Segment_1403.F0_1403_3fd0(this.oGameData.Players[playerID].Units[unitID].Position.X, this.oGameData.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.AX.UInt16 = this.oCPU.ORUInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0298;

			if (local_a.ContainsAnyFlag(TerrainImprovementEnum.Irrigation, TerrainImprovementEnum.Mine)) goto L0298;

			F4_0000_02d3(0x34ce);

			goto L02cd;

		L0298:
			if (this.oGameData.Static.Terrains.GetValueByKey(local_c).MovementCost != 1)
				goto L02cd;

			if (local_a.ContainsAnyFlag(TerrainImprovementEnum.Roads)) goto L02cd;

			if (local_c == TerrainTypeEnum.River) goto L02cd;

			this.oCPU.AX.UInt16 = 0x38;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			
			if (this.oGameData.Players[playerID].ActiveUnits[0] >= 2)
				goto L02cd;

			F4_0000_02d3(0x34d8);

		L02cd:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F4_0000_00af");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		public void F4_0000_02d3(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F4_0000_02d3(0x{stringPtr:x4})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x2);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);

			this.oCPU.TESTUInt8((byte)(this.oGameData.GameSettingFlags & 0xff), 0x1);
			if (this.oCPU.Flags.NE) goto L02e4;
			goto L03a5;

		L02e4:
			if (this.oGameData.Year < 0) goto L02ee;
			goto L03a5;

		L02ee:
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x02fa, size: 5
			this.oParent.LanguageTools.F0_2f4d_01ad_GetTextBySectionAndKey("HELP", stringPtr);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0305, size: 5
			this.oCPU.WriteString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0xba06), 
				this.oParent.LanguageTools.F0_2f4d_0471_ReplaceKeywords(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0xba06))));

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.AX.UInt16 = 0x6;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, 0xa);

			// Instruction address 0x0000:0x0334, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 56, 16, 208, (short)this.oCPU.SI.UInt16, 2);

			// Instruction address 0x0000:0x034d, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(56, 16, 208, (short)this.oCPU.SI.UInt16, 10);

			this.oParent.Var_aa_Rectangle.FontID = 2;

			// Instruction address 0x0000:0x036d, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA("--- Civilization Note ---", 160, 19, 0);

			// Instruction address 0x0000:0x0385, size: 5
			this.oParent.LanguageTools.F0_2f4d_0088_DrawTextBlock(32, 64, 25, 15);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x0396, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L03a5:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F4_0000_02d3");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		public void F4_0000_03aa(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F4_0000_03aa(0x{stringPtr:x4})");

			// function body
			this.oCPU.PUSHUInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUBUInt16(this.oCPU.SP.UInt16, 0x2);
			this.oCPU.PUSHUInt16(this.oCPU.SI.UInt16);

			if (this.oParent.Var_6b90 == this.oGameData.HumanPlayerID) goto L03bd;
			goto L0474;

		L03bd:
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x03c9, size: 5
			this.oParent.LanguageTools.F0_2f4d_01ad_GetTextBySectionAndKey("ERROR", stringPtr);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x03d4, size: 5
			this.oCPU.WriteString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0xba06),
				this.oParent.LanguageTools.F0_2f4d_0471_ReplaceKeywords(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.UInt16, 0xba06))));

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.AX.UInt16 = 0x6;
			this.oCPU.IMULUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.SI.UInt16 = this.oCPU.ADDUInt16(this.oCPU.SI.UInt16, 0xa);

			// Instruction address 0x0000:0x0403, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 56, 16, 208, (short)this.oCPU.SI.UInt16, 4);

			// Instruction address 0x0000:0x041c, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0a05_DrawRectangle(56, 16, 208, (short)this.oCPU.SI.UInt16, 12);

			this.oParent.Var_aa_Rectangle.FontID = 2;

			// Instruction address 0x0000:0x043c, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToRectAA("--- Civilization Note ---", 160, 19, 0);

			// Instruction address 0x0000:0x0454, size: 5
			this.oParent.LanguageTools.F0_2f4d_0088_DrawTextBlock(32, 64, 25, 15);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x0465, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L0474:
			this.oCPU.SI.UInt16 = this.oCPU.POPUInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POPUInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F4_0000_03aa");
		}
	}
}
