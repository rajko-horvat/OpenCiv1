using Avalonia.Media;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_22
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public Overlay_22(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F22_0000_0000(short cityID, short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F22_0000_0000({cityID}, {playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x28);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26),
				(short)this.oParent.GameData.Cities[cityID].PlayerID);

			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			this.oParent.GameData.Players[playerID].Units[unitID].GoToDestination.X = -1;

			// Instruction address 0x0000:0x003a, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x004a, size: 5
			this.oParent.CAPI.strcat(0xba06, " diplomat arrives\nin ");

			// Instruction address 0x0000:0x0055, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0065, size: 5
			this.oParent.CAPI.strcat(0xba06, "...\n Establish Embassy\n Investigate City\n Steal Technology\n Industrial Sabotage\n Incite a Revolt\n Meet with King\n");

			if (playerID != this.oParent.GameData.HumanPlayerID)
				goto L010c;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)this.oParent.GameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26))] & 0x40) != 0)
				goto L0090;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)), 0x0);
			if (this.oCPU.Flags.NE) goto L0096;

		L0090:
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0xb276, 0x1);

		L0096:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.TEST_UInt8(this.oParent.GameData.Cities[cityID].StatusFlag, 0x20);
			if (this.oCPU.Flags.E) goto L00aa;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xb276, this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xb276), 0x4));

		L00aa:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.TEST_UInt16(this.oParent.GameData.Cities[cityID].ImprovementFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L00be;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xb276, this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xb276), 0x10));

		L00be:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)), 0x0);
			if (this.oCPU.Flags.NE) goto L00c9;
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xb276, this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xb276), 0x20));

		L00c9:
			// Instruction address 0x0000:0x00d2, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.AX.UInt16);

		L00dd:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L014c;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L012d;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x2);
			if (this.oCPU.Flags.NE) goto L00f1;
			goto L017a;

		L00f1:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x3);
			if (this.oCPU.Flags.NE) goto L00f9;
			goto L02d5;

		L00f9:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x4);
			if (this.oCPU.Flags.NE) goto L0101;
			goto L0442;

		L0101:
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x5);
			if (this.oCPU.Flags.NE) goto L0109;
			goto L05eb;

		L0109:
			goto L0633;

		L010c:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0x2);
			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L00dd;

			this.oCPU.SI.UInt16 = (ushort)playerID;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)this.oParent.GameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			if ((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[playerID] & 2) == 0)
				goto L00dd;

			goto L013b;

		L012d:
			// Instruction address 0x0000:0x0133, size: 5
			this.oParent.Segment_1ade.F0_1ade_03ea(cityID);

		L013b:
			// Instruction address 0x0000:0x0141, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);
			
			goto L0633;

		L014c:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.BX.UInt16 = (ushort)this.oParent.GameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26))] |= 0x40;

			// Instruction address 0x0000:0x0164, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);

			this.oParent.Overlay_14.F14_0000_1164(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)));

			goto L0633;

		L017a:
			if (playerID != this.oParent.GameData.HumanPlayerID) goto L01d0;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.TEST_UInt8(this.oParent.GameData.Cities[cityID].StatusFlag, 0x20);
			if (this.oCPU.Flags.E) goto L0194;
			goto L0633;

		L0194:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			
			// Instruction address 0x0000:0x01a2, size: 5
			this.oParent.Segment_29f3.F0_29f3_0c9e(this.oParent.GameData.Cities[cityID].PlayerID);
			
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L01b0;
			goto L0633;

		L01b0:
			// Instruction address 0x0000:0x01c6, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(this.oParent.GameData.HumanPlayerID, this.oParent.GameData.Cities[cityID].PlayerID, 2);
			
			goto L01e2;

		L01d0:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.TEST_UInt8(this.oParent.GameData.Cities[cityID].StatusFlag, 0x20);
			if (this.oCPU.Flags.E) goto L01e2;
			goto L02d5;

		L01e2:
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x01eb, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(72));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0x0);
			goto L0200;

		L01fd:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22))));

		L0200:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), 0x48);
			if (this.oCPU.Flags.L) goto L0209;
			goto L02c0;

		L0209:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28));
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = 0x48;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.DX.UInt16);

			if (playerID == 0) goto L01fd;

			// Instruction address 0x0000:0x0222, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)),
				(TechnologyEnum)((short)this.oCPU.DX.UInt16)) ? 1 : 0);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E)
				goto L01fd;

			// Instruction address 0x0000:0x0234, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				(TechnologyEnum)this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))) ? 1 : 0);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE)
				goto L01fd;

			// Instruction address 0x0000:0x0249, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(playerID,
				(TechnologyEnum)this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)));

			// Instruction address 0x0000:0x025e, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[playerID].Nation);

			// Instruction address 0x0000:0x026e, size: 5
			this.oParent.CAPI.strcat(0xba06, " steal\n");

			// Instruction address 0x0000:0x0284, size: 5
			this.oParent.CAPI.strcat(0xba06,
				this.oParent.GameData.TechnologyTypes[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4))].Name);

			// Instruction address 0x0000:0x0294, size: 5
			this.oParent.CAPI.strcat(0xba06, ".\n");

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.SpiesReport;

			// Instruction address 0x0000:0x02ab, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oParent.GameData.Cities[cityID].StatusFlag |= 0x20;

		L02c0:
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xba06), 0x0);
			if (this.oCPU.Flags.E) goto L02ca;
			goto L013b;

		L02ca:
			if (playerID == this.oParent.GameData.HumanPlayerID)
				goto L038a;

		L02d5:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28), 0x0);

			// Instruction address 0x0000:0x02de, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(2));

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L02fc;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt16((ushort)this.oParent.GameData.Cities[cityID].ShieldsCount, 0x0);
			if (this.oCPU.Flags.E) goto L02fc;
			goto L03a3;

		L02fc:
			// Instruction address 0x0000:0x0300, size: 5
			this.oCPU.AX.UInt16 = (ushort)(this.oParent.CAPI.RNG.Next(24));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28)), 0x63);
			if (this.oCPU.Flags.GE) goto L0341;
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L02fc;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = this.oParent.GameData.Cities[cityID].ImprovementFlags0;
			this.oCPU.DX.UInt16 = this.oParent.GameData.Cities[cityID].ImprovementFlags1;
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.BX.UInt16 = this.oCPU.CX.UInt16;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.CX.UInt16 = this.oCPU.DX.UInt16;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.BX.UInt16, this.oCPU.AX.UInt16);
			this.oCPU.CX.UInt16 = this.oCPU.AND_UInt16(this.oCPU.CX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.CX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.CX.UInt16, this.oCPU.BX.UInt16);
			if (this.oCPU.Flags.E) goto L02fc;

		L0341:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28)), 0x63);
			if (this.oCPU.Flags.GE) goto L039e;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = this.oCPU.NOT_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oParent.GameData.Cities[cityID].ImprovementFlags0 &= this.oCPU.AX.UInt16;
			this.oParent.GameData.Cities[cityID].ImprovementFlags1 &= this.oCPU.DX.UInt16;

			// Instruction address 0x0000:0x0370, size: 5
			this.oParent.CAPI.strcpy(0xba06,
				this.oParent.GameData.GetImprovementType(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)) + 1).Name);

			// Instruction address 0x0000:0x0380, size: 5
			this.oParent.CAPI.strcat(0xba06, " destroyed\n");
			goto L03a3;

		L038a:
			// Instruction address 0x0000:0x0393, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x5231, 80, 80);

			goto L0633;

		L039e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28), 0x0);

		L03a3:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x28)), 0x0);
			if (this.oCPU.Flags.NE) goto L03fd;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oParent.GameData.Cities[cityID].ShieldsCount = 0;
			this.oCPU.CMP_UInt8((byte)this.oParent.GameData.Cities[cityID].CurrentProductionID, 0x0);
			if (this.oCPU.Flags.L) goto L03c9;

			// Instruction address 0x0000:0x03e5, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.UnitTypes[this.oParent.GameData.Cities[cityID].CurrentProductionID].Name);

			goto L03e0;

		L03c9:
			// Instruction address 0x0000:0x03e5, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.GetImprovementType(-this.oParent.GameData.Cities[cityID].CurrentProductionID).Name);

		L03e0:
			// Instruction address 0x0000:0x03f5, size: 5
			this.oParent.CAPI.strcat(0xba06, " production sabotaged\n");

		L03fd:
			// Instruction address 0x0000:0x0405, size: 5
			this.oParent.CAPI.strcat(0xba06, "in ");

			// Instruction address 0x0000:0x0410, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0420, size: 5
			this.oParent.CAPI.strcat(0xba06, ".\n");

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.SpiesReport;

			// Instruction address 0x0000:0x0437, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			goto L013b;

		L0442:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0459, size: 5
			this.oParent.Segment_2517.F0_2517_0d97(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)),
				this.oParent.GameData.Cities[cityID].Position.X, this.oParent.GameData.Cities[cityID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L046b;
			goto L0633;

		L046b:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = (byte)this.oParent.GameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26))].Coins;
			this.oCPU.AX.UInt16 += 0x3e8;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.BX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.BX.UInt16, 0x3);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.UInt16);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);
			this.oCPU.TEST_UInt8(this.oParent.GameData.Cities[cityID].StatusFlag, 0x1);
			if (this.oCPU.Flags.E) goto L04a4;
			this.oCPU.CX.UInt16 = 0x2;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);

		L04a4:
			// Instruction address 0x0000:0x04ac, size: 5
			this.oParent.CAPI.strcpy(0xba06, "Dissidents in ");

			// Instruction address 0x0000:0x04b7, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x04c7, size: 5
			this.oParent.CAPI.strcat(0xba06, "\nwill revolt for $");

			// Instruction address 0x0000:0x04e7, size: 5
			this.oParent.CAPI.strcat(0xba06,
				this.oParent.CAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 10));

			// Instruction address 0x0000:0x04f7, size: 5
			this.oParent.CAPI.strcat(0xba06, ".\n");

			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Players[playerID].Coins;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L054b;

			// Instruction address 0x0000:0x0517, size: 5
			this.oParent.CAPI.strcat(0xba06, " Forget it.\n Incite revolt\n");

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, (ushort)this.oParent.GameData.Players[playerID].Coins);
			if (this.oCPU.Flags.G) goto L054b;

			this.oCPU.DI.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oParent.GameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26))] & 2) != 0)
			{
				// Instruction address 0x0000:0x0543, size: 5
				this.oParent.CAPI.strcat(0xba06, " Subvert city ($x2)\n");
			}

		L054b:
			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.SpiesReport;

			// Instruction address 0x0000:0x055d, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.GE) goto L0570;
			goto L0633;

		L0570:
			if (this.oCPU.Flags.NE) goto L059e;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26));
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = (ushort)playerID;
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			if ((this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26))].Diplomacy[playerID] & 2) != 0)
			{
				// Instruction address 0x0000:0x0593, size: 5
				this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)), playerID, 2);

				this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26))].Diplomacy[playerID] |= 8;
			}

		L059e:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)));
			this.oParent.GameData.Players[playerID].Coins -= (short)this.oCPU.AX.UInt16;

			F22_0000_0af5(cityID, playerID);

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x05ce, size: 5
			this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(this.oParent.GameData.Cities[cityID].Position.X, this.oParent.GameData.Cities[cityID].Position.Y);

			// Instruction address 0x0000:0x05dc, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);
			
			// Instruction address 0x0000:0x05e4, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

			goto L0633;

		L05eb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)), 0x0);
			if (this.oCPU.Flags.E) goto L061e;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			this.oParent.MeetWithKing.F6_0000_0000(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x26)),
				this.oParent.GameData.Players[playerID].Units[unitID].Position.X, this.oParent.GameData.Players[playerID].Units[unitID].Position.Y, 1);

		L061e:
			this.oParent.GameData.Players[playerID].Units[unitID].RemainingMoves = 0;

		L0633:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F22_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="playerID1"></param>
		public void F22_0000_0639(short playerID, short unitID, short playerID1)
		{
			this.oCPU.Log.EnterBlock($"F22_0000_0639({playerID}, {unitID}, {playerID1})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0xc);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x064b, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 2);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.LE) goto L065b;
			goto L0961;

		L065b:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x067a, size: 5
			this.oParent.Segment_2517.F0_2517_0d97(playerID,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.X, this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)(0x22 * this.oParent.GameData.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Players[playerID].Coins;
			this.oCPU.AX.UInt16 += 0x2ee;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.CX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.CX.UInt16);
			this.oCPU.CX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.CX.UInt16);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)((short)this.oParent.GameData.UnitTypes[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].Cost));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

			if (this.oParent.GameData.Players[playerID].Units[unitID].TypeID != 0)
			{
				this.oCPU.CX.UInt16 = 0x2;
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			}

			if (playerID1 == this.oParent.GameData.HumanPlayerID) goto L06d6;

			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Players[playerID1].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SAR_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)));
			if (this.oCPU.Flags.GE) goto L06d6;
			goto L0961;

		L06d6:
			// Instruction address 0x0000:0x06e3, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x06f3, size: 5
			this.oParent.CAPI.strcat(0xba06, " ");

			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0719, size: 5
			this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.UnitTypes[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].Name);

			// Instruction address 0x0000:0x0729, size: 5
			this.oParent.CAPI.strcat(0xba06, "\nwill desert for ");

			// Instruction address 0x0000:0x0749, size: 5
			this.oParent.CAPI.strcat(0xba06,
				this.oParent.CAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), 10));

			// Instruction address 0x0000:0x0759, size: 5
			this.oParent.CAPI.strcat(0xba06, "$.\nTreasury: ");

			// Instruction address 0x0000:0x0781, size: 5
			this.oParent.CAPI.strcat(0xba06,
				this.oParent.CAPI.itoa(this.oParent.GameData.Players[playerID1].Coins, 10));

			// Instruction address 0x0000:0x0791, size: 5
			this.oParent.CAPI.strcat(0xba06, "$\n");

			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Players[playerID1].Coins;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L07b0;

			// Instruction address 0x0000:0x07a8, size: 5
			this.oParent.CAPI.strcat(0xba06, " Forget it.\n Pay\n");

		L07b0:
			if (playerID1 != this.oParent.GameData.HumanPlayerID) goto L07d4;

			// Instruction address 0x0000:0x07c4, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.E) goto L07d4;
			goto L0961;

		L07d4:
			if (playerID != this.oParent.GameData.HumanPlayerID)
				goto L0898;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0806, size: 5
			this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(playerID,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.X - 8,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.Y - 6);

			// Instruction address 0x0000:0x081b, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x082b, size: 5
			this.oParent.CAPI.strcat(0xba06, " ");

			// Instruction address 0x0000:0x0841, size: 5
			this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.UnitTypes[this.oParent.GameData.Players[playerID].Units[unitID].TypeID].Name);

			// Instruction address 0x0000:0x0851, size: 5
			this.oParent.CAPI.strcat(0xba06, " unit\nbribed by ");

			// Instruction address 0x0000:0x0866, size: 5
			this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Players[playerID1].Nation);

			// Instruction address 0x0000:0x0876, size: 5
			this.oParent.CAPI.strcat(0xba06, "!\n");

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.SpiesReport;

			// Instruction address 0x0000:0x0890, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 40);

		L0898:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Players[playerID].Units[unitID].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			
			// Instruction address 0x0000:0x08b6, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, unitID);

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			
			this.oParent.GameData.Players[playerID].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))]--;

			// Instruction address 0x0000:0x08e1, size: 5
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.Segment_1866.F0_1866_0cf5_CreateUnit(playerID1, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oParent.GameData.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameData.Players[playerID].Units[unitID].Position.Y));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xffff);
			if (this.oCPU.Flags.E) goto L0918;
			this.oCPU.AX.UInt16 = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oParent.GameData.Players[playerID1].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))]++;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)));
			this.oCPU.BX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.BX.UInt16, this.oCPU.AX.UInt16);

			this.oParent.GameData.Players[playerID1].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))].VisibleByPlayer |= 
				(ushort)(1 << playerID);

		L0918:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oParent.GameData.Players[playerID1].Coins -= (short)this.oCPU.AX.UInt16;

			if (playerID != this.oParent.GameData.HumanPlayerID)
				goto L0961;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0948, size: 5
			this.oParent.MapManagement.F0_2aea_11d4_DrawCellWithUnit(this.oParent.GameData.Players[playerID].Units[unitID].Position.X, this.oParent.GameData.Players[playerID].Units[unitID].Position.Y);

			// Instruction address 0x0000:0x0950, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

			// Instruction address 0x0000:0x0959, size: 5
			this.oParent.CommonTools.F0_1182_0134_WaitTimer(30);

		L0961:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F22_0000_0639");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F22_0000_0967(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F22_0000_0967({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x3a);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x098d, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x5318, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a), 0x0);

		L099f:
			// Instruction address 0x0000:0x09ca, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a)) % 7) * 0x2d) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a)) / 7) * 0x2d) + 1),
				0x2c, 0x2c);

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x38), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a)), 0x1c);
			if (this.oCPU.Flags.L) goto L099f;

			// Instruction address 0x0000:0x09f0, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos - this.oParent.Var_d4cc_MapViewX);

			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x42);
			xPos = (short)this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = (ushort)((short)yPos);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, (ushort)((short)this.oParent.Var_d75e_MapViewY));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x6);
			yPos = (short)this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0a1c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(xPos, 80, 276);

			xPos = (short)this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0a32, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(yPos, 8, 0x9c);

			yPos = (short)this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0a41, size: 5
			this.oParent.CommonTools.F0_1000_0a32_PlayTune(0x2a, 0);

			// Instruction address 0x0000:0x0a62, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, xPos, yPos, 44, 44, this.oParent.Var_19d4_Rectangle, xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a), 0x0);
			goto L0abe;

		L0a71:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a));
			this.oCPU.SI.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SI.UInt16, 0x7);

		L0a77:
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			// Instruction address 0x0000:0x0a86, size: 5
			this.oParent.CommonTools.F0_1000_0797_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				xPos, yPos, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x38)));

			// Instruction address 0x0000:0x0a92, size: 5
			this.oParent.CommonTools.F0_1182_0134_WaitTimer(5);

			// Instruction address 0x0000:0x0ab3, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, xPos, yPos, 44, 44, this.oParent.Var_aa_Rectangle, xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a))));

		L0abe:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a)), 0x23);
			if (this.oCPU.Flags.GE) goto L0acf;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a)), 0x1c);
			if (this.oCPU.Flags.GE) goto L0a71;
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x3a));
			goto L0a77;

		L0acf:
			// Instruction address 0x0000:0x0ad2, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x38)), 0);

			// Instruction address 0x0000:0x0aeb, size: 5
			this.oParent.Segment_1238.F0_1238_1beb();

			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F22_0000_0967");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="playerID"></param>
		public void F22_0000_0af5(short cityID, short playerID)
		{
			this.oCPU.Log.EnterBlock($"F22_0000_0af5({cityID}, {playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x1c);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Cities[cityID].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Cities[cityID].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Cities[cityID].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), 0xffff);
			
			if (playerID != -1)
				goto L0bed;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);
			goto L0bac;

		L0b41:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0b67, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.oParent.GameData.Cities[cityID].Position.X,
				this.oParent.GameData.Cities[cityID].Position.Y,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Position.X,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0b79, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), -1);

			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.Var_70e2);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, (ushort)((short)this.oParent.Var_70e4));
			this.oCPU.CX.LowUInt8 = 0x5;
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8));
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.LE) goto L0ba9;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), this.oCPU.AX.UInt16);

		L0ba9:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L0bac:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x80);
			if (this.oCPU.Flags.GE) goto L0bd7;
			this.oCPU.AX.UInt16 = (ushort)cityID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0bd7;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt8(this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0bd7;
			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].PlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			if (this.oCPU.Flags.E) goto L0bd7;
			goto L0b41;

		L0bd7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe)), 0x0);
			if (this.oCPU.Flags.E) goto L0bed;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))].PlayerID;
			playerID = (short)this.oCPU.AX.UInt16;

		L0bed:
			if (playerID == -1) goto L0ea9;

			this.oParent.GameData.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)),
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))] |= (ushort)(1 << playerID);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x0);

		L0c18:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.AX.UInt16 = (ushort)((short)(this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].X +
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))));

			this.oCPU.BX.UInt16 = (ushort)((short)(this.oParent.CityOffsets[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Y +
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12))));

			this.oParent.GameData.MapVisibility[this.oCPU.AX.UInt16, this.oCPU.BX.UInt16] |= (ushort)(1 << playerID);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), 0x14);
			if (this.oCPU.Flags.L) goto L0c18;

			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0c77;

			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0c77;

			this.oCPU.SI.UInt16 = (ushort)this.oParent.GameData.HumanPlayerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))] & 0x40) != 0)
				goto L0c77;

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			if ((this.oParent.GameData.Players[this.oParent.GameData.HumanPlayerID].Diplomacy[playerID] & 0x40) == 0)
				goto L0d4d;

		L0c77:
			this.oCPU.AX.UInt16 = this.oParent.GameData.MapVisibility[this.oParent.GameData.Cities[cityID].Position.X, this.oParent.GameData.Cities[cityID].Position.Y];
			this.oCPU.DX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = (byte)(this.oParent.GameData.HumanPlayerID & 0xff);
			this.oCPU.DX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.TEST_UInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			if (this.oCPU.Flags.E) goto L0cbe;

			// Instruction address 0x0000:0x0cb6, size: 5
			this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID,
				this.oParent.GameData.Cities[cityID].Position.X - 8,
				this.oParent.GameData.Cities[cityID].Position.Y - 5);

		L0cbe:
			// Instruction address 0x0000:0x0ccb, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Nation);

			if (playerID == 0)
			{
				// Instruction address 0x0000:0x0ce6, size: 5
				this.oParent.CAPI.strcat(0xba06, " declare\nindependence in\n");
			}
			else
			{
				// Instruction address 0x0000:0x0ce6, size: 5
				this.oParent.CAPI.strcat(0xba06, " rebel!\nCivil War in\n");
			}

			// Instruction address 0x0000:0x0cf1, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			if (playerID == 0) goto L0d29;

			// Instruction address 0x0000:0x0d07, size: 5
			this.oParent.CAPI.strcat(0xba06, ".\n");

			// Instruction address 0x0000:0x0d1c, size: 5
			this.oParent.CAPI.strcat(0xba06, this.oParent.GameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x0d31, size: 5
			this.oParent.CAPI.strcat(0xba06, " influence\nsuspected.\n");

			goto L0d2c;

		L0d29:
			// Instruction address 0x0000:0x0d31, size: 5
			this.oParent.CAPI.strcat(0xba06, "\n");

		L0d2c:
			// Instruction address 0x0000:0x0d45, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 32);

		L0d4d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0x0);

		L0d52:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0d74, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)),
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.X,
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);

			if (this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].TypeID == -1)
				goto L0e45;

			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x1);
			if (this.oCPU.Flags.LE) goto L0d91;
			goto L0e45;

		L0d91:
			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0db0;

			// Instruction address 0x0000:0x0da1, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.X,
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.Y);

			this.oCPU.TEST_UInt8(this.oCPU.AX.LowUInt8, 0x1);
			if (this.oCPU.Flags.E) goto L0db0;
			goto L0e45;

		L0db0:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);
			
			// Instruction address 0x0000:0x0dce, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			
			// Instruction address 0x0000:0x0de5, size: 5
			this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(playerID,
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.X,
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.Y);

			// Instruction address 0x0000:0x0df9, size: 5
			this.oParent.MapManagement.F0_2aea_1511_ActiveUnitSetFlag8(
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.X,
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.Y);

			// Instruction address 0x0000:0x0e13, size: 5
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.Segment_1866.F0_1866_0cf5_CreateUnit(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)),
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.X,
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Position.Y));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xffff);
			if (this.oCPU.Flags.E) goto L0e45;
			
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);
			
			this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))].VisibleByPlayer |= 
				(ushort)(1 << this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)));

			this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))].HomeCityID = cityID;

		L0e45:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), 0x80);
			if (this.oCPU.Flags.GE) goto L0e52;
			goto L0d52;

		L0e52:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), (ushort)this.oParent.GameData.GameSettingFlags.Value);
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x28bc, 0x1);

			if (this.oCPU.ReadInt16(this.oCPU.DS.UInt16, 0xdeba) > 1) goto L0e6a;

			//this.oParent.CivState.GameSettingFlags.Value &= 0x7ff7;
			this.oParent.GameData.GameSettingFlags.Animations = false;

		L0e6a:
			// Instruction address 0x0000:0x0e76, size: 5
			this.oParent.Segment_2459.F0_2459_0000(playerID, cityID, 1);

			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, 0x28bc, 0x0);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18));
			this.oParent.GameData.GameSettingFlags.Value = (short)this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0ea1, size: 5
			this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(playerID,
				this.oParent.GameData.Cities[cityID].Position.X, this.oParent.GameData.Cities[cityID].Position.Y);

		L0ea9:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F22_0000_0af5");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F22_0000_0eaf(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F22_0000_0eaf({cityID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x10);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);

			// Instruction address 0x0000:0x0ecd, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x0ed2, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x0ee4, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x536e, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x0);

		L0ef1:
			// Instruction address 0x0000:0x0f07, size: 5
			this.oParent.Graphics.F0_VGA_0b85_ScreenToBitmap(1, 1,
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)) << 4) + 1),
				0x2f, 0xf);

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x8), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x4);
			if (this.oCPU.Flags.L) goto L0ef1;

			// Instruction address 0x0000:0x0f2d, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x537b, 0);

			// Instruction address 0x0000:0x0f48, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x0f54, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x5384, 1);

			// Instruction address 0x0000:0x0f74, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x0f84, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0f94, size: 5
			this.oParent.CAPI.strcat(0xba06, " founded: ");

			// Instruction address 0x0000:0x0f9c, size: 5
			this.oParent.Segment_1238.F0_1238_1720_GetCurrentYearAsString();

			// Instruction address 0x0000:0x0fa9, size: 5
			this.oParent.CAPI.strcat(0xba06, ".");

			this.oParent.Var_aa_Rectangle.FontID = 6;

			// Instruction address 0x0000:0x0fc9, size: 5
			this.oParent.DrawStringTools.F0_1182_00b3_DrawCenteredStringToScreen0(0xba06, 160, 4, 0);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x0000:0x0ff5, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 120, 320, 40, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), 0x0);

			// Instruction address 0x0000:0x1002, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x50);
			goto L1011;

		L100e:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa))));

		L1011:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)), 0x78);
			if (this.oCPU.Flags.L) goto L101a;
			goto L10cc;

		L101a:
			// Instruction address 0x0000:0x101a, size: 5
			this.oParent.CommonTools.F0_1000_033e_ResetWaitTimer();

			// Instruction address 0x0000:0x103a, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 40, this.oParent.Var_19d4_Rectangle, 0, 120);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), 0x0);

		L1047:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)));
			this.oCPU.SI.UInt16 = this.oCPU.AND_UInt16(this.oCPU.SI.UInt16, 0x3);
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			// Instruction address 0x0000:0x1070, size: 5
			this.oParent.CommonTools.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_19d4_Rectangle,
				(13 * this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))) +
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)),
				((10 * this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))) & 0xf) + 120,
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x8)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x4);
			if (this.oCPU.Flags.L) goto L1047;

			// Instruction address 0x0000:0x109f, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 120, 320, 40, this.oParent.Var_aa_Rectangle, 0, 120);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))));

		L10aa:
			this.oCPU.AX.UInt16 = this.oParent.Var_5c_TickCount;
			this.oCPU.DoEvents();
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0xa);
			if (this.oCPU.Flags.L) goto L10aa;

			// Instruction address 0x0000:0x10b4, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			// Instruction address 0x0000:0x10b9, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L10cc;
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.NE) goto L10cc;
			goto L100e;

		L10cc:
			// Instruction address 0x0000:0x10d3, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x539a);

			this.oCPU.CMP_UInt16(this.oParent.Var_d762, 0x0);
			if (this.oCPU.Flags.E) goto L1104;

			// Instruction address 0x0000:0x10fc, size: 5
			this.oParent.CommonTools.F0_1000_04d4_TransformPaletteToColor(10, Color.FromRgb(0, 0, 0));

		L1104:
			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			// Instruction address 0x0000:0x1109, size: 5
			this.oParent.CAPI.kbhit();

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L1123;

			this.oParent.CityView.F19_0000_0000(cityID, -3);

			goto L1143;

		L1123:
			// Instruction address 0x0000:0x1136, size: 5
			this.oParent.CommonTools.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x0000:0x113e, size: 5
			this.oParent.Segment_1238.F0_1238_1beb();

		L1143:
			// Instruction address 0x0000:0x1143, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x1148, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F22_0000_0eaf");
		}
	}
}
