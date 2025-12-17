using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Schizm
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;

		public Schizm(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F15_0000_0000(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F15_0000_0000({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0x48);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x1);
			goto L0017;

		L0014:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L0017:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x8);
			if (this.oCPU.Flags.GE) goto L0036;

			if (this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].UnitCount != 0) goto L0014;

			this.oCPU.CMP_UInt16((ushort)this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].CityCount, 0x0);
			if (this.oCPU.Flags.NE) goto L0014;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16), this.oCPU.AX.UInt16);

		L0036:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), 0xffff);
			if (this.oCPU.Flags.NE) goto L003f;
			goto L0100;

		L003f:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);

		L0044:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x44), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x10);
			if (this.oCPU.Flags.L) goto L0044;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);

		L0061:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt8(this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L00ed;
			if (this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].PlayerID != playerID) goto L00ed;

			// Instruction address 0x0000:0x0086, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.AX.LowUInt8 = (byte)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x44), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x44)), this.oCPU.AX.UInt16));
			this.oCPU.TEST_UInt16(this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].ImprovementFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L00ed;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0xffff);
			if (this.oCPU.Flags.E) goto L00b8;
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X);
			this.oCPU.CMP_UInt16((ushort)this.oParent.GameData.Players[playerID].XStart, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L00ed;

		L00b8:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x00cc, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), this.oCPU.AX.UInt16);

		L00ed:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x80);
			if (this.oCPU.Flags.GE) goto L00fa;
			goto L0061;

		L00fa:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0105;

		L0100:
			this.oCPU.AX.UInt16 = 0;
			goto L0879;

		L0105:
			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.AIOpponentCount;
			this.oCPU.AX.UInt16 = this.oCPU.INC_UInt16(this.oCPU.AX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.LE) goto L0113;
			this.oCPU.AX.UInt16 = 0x1;
			goto L0115;

		L0113:
			this.oCPU.AX.UInt16 = 0;

		L0115:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oCPU.AX.UInt16 = this.oCPU.NOT_UInt16(this.oCPU.AX.UInt16);
			oParent.GameData.ActiveCivilizations &= (short)this.oCPU.AX.UInt16;

			this.oParent.StartGameMenu.F5_0000_07c7(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));

			this.oCPU.AX.UInt16 = this.oCPU.OR_UInt16(this.oCPU.AX.UInt16, this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0100;
			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			oParent.GameData.ActiveCivilizations |= (short)this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xc)), 0x0);
			if (this.oCPU.Flags.NE) goto L0166;
			this.oCPU.SI.UInt16 = (ushort)this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].NationalityID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)), 0x7);
			if (this.oCPU.Flags.E) goto L015b;
			this.oCPU.AX.UInt16 = 0x1;
			goto L015d;

		L015b:
			this.oCPU.AX.UInt16 = 0;

		L015d:
			this.oCPU.TEST_UInt16(this.oCPU.AX.UInt16, this.oCPU.SI.UInt16);
			if (this.oCPU.Flags.NE) goto L0166;
			this.oCPU.CMP_UInt16(this.oCPU.SI.UInt16, 0xf);
			if (this.oCPU.Flags.LE) goto L019f;

		L0166:
			// Instruction address 0x0000:0x0173, size: 5
			if (this.oParent.CAPI.RNG.Next(2) != 0)
			{
				this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			}
			else
			{
				this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
				this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, 0x8);
			}
		
			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].NationalityID = (short)this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, 0x8);
			if (this.oCPU.Flags.L) goto L01a9;
			this.oCPU.AX.UInt16 = 0x1;
			this.oCPU.CX.LowUInt8 = this.oCPU.ReadUInt8(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, this.oCPU.CX.LowUInt8);
			this.oParent.GameData.PlayerIdentityFlags |= (short)this.oCPU.AX.UInt16;
			goto L01a9;

		L019f:
			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].NationalityID ^= 8;

		L01a9:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			// Instruction address 0x0000:0x01bd, size: 5
			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Name =
				this.oParent.GameData.Nations[this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].NationalityID].Leader;

			// Instruction address 0x0000:0x01d4, size: 5
			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Nationality =
				this.oParent.GameData.Nations[this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].NationalityID].Nationality;

			// Instruction address 0x0000:0x01eb, size: 5
			this.oParent.CAPI.strcpy(0xba06, 
				this.oParent.GameData.Nations[this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].NationalityID].Nation);

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.UInt16, 0xba06), 0x0);
			if (this.oCPU.Flags.NE) goto L021a;

			// Instruction address 0x0000:0x0202, size: 5
			this.oParent.CAPI.strcpy(0xba06, this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Nationality);

			// Instruction address 0x0000:0x0212, size: 5
			this.oParent.CAPI.strcat(0xba06, "s");

		L021a:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			// Instruction address 0x0000:0x0227, size: 5
			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Nation =
				this.oCPU.ReadString(this.oCPU.DS.UInt16, 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.UInt16, 0xba06, 0x0);

			this.oCPU.DI.UInt16 = (ushort)playerID;
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			// Instruction address 0x0000:0x0241, size: 5
			this.oParent.CAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x30b8), this.oParent.GameData.Players[playerID].Nationality);

			// Instruction address 0x0000:0x0251, size: 5
			this.oParent.CAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0x30ba), 
				this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Nationality);
		
			// Instruction address 0x0000:0x026a, size: 5
			this.oParent.LanguageTools.F0_2f4d_044f((ushort)((playerID == this.oParent.GameData.HumanPlayerID) ? 0x4a18 : 0x4a20));

			this.oParent.Var_2f9e_MessageBoxStyle = ReportTypeEnum.ForeignMinister;

			// Instruction address 0x0000:0x0281, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Players[playerID].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SAR_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Coins = (short)this.oCPU.AX.UInt16;
			this.oParent.GameData.Players[playerID].Coins -= (short)this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = (ushort)this.oParent.GameData.Players[playerID].MilitaryPower;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, this.oCPU.DX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.SAR_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].MilitaryPower = (short)this.oCPU.AX.UInt16;

			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].ResearchProgress = 
				this.oParent.GameData.Players[playerID].ResearchProgress;

			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].DiscoveredTechnologyCount =
				this.oParent.GameData.Players[playerID].DiscoveredTechnologyCount;

			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].GovernmentType =
				this.oParent.GameData.Players[playerID].GovernmentType;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);

		L02c4:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.AX.UInt16 = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = this.oParent.GameData.Players[playerID].DiscoveredTechnologyFlags[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))];
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oParent.GameData.Players[playerID].DiscoveredTechnologyFlags[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))] = this.oCPU.CX.UInt16;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x5);
			if (this.oCPU.Flags.L) goto L02c4;

			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);

			this.oCPU.AX.UInt16 = (ushort)oParent.GameData.TurnCount;
			this.oCPU.AX.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.AX.UInt16, 0x8);
			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].ContactPlayerCountdown = 
				(short)this.oCPU.AX.UInt16;

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, this.oCPU.CX.LowUInt8);

			this.oParent.GameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))] |= 1;

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.CX.LowUInt8 = 0x4;
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, this.oCPU.CX.LowUInt8);

			this.oCPU.BX.UInt16 = (ushort)playerID;
			this.oCPU.BX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.BX.UInt16, 0x1);

			this.oParent.GameData.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))] |= 9;

			this.oCPU.DI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1e), this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			goto L0343;

		L032d:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.BP.UInt16);
			this.oCPU.SI.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SI.UInt16, 0x44);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), this.oCPU.AX.UInt16));
			this.oCPU.WriteUInt16(this.oCPU.DS.UInt16, this.oCPU.SI.UInt16, 0x2);

		L0340:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L0343:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x10);
			if (this.oCPU.Flags.GE) goto L0383;
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x44)), 0x0);
			if (this.oCPU.Flags.E) goto L0340;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1e));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L0364;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L032d;

		L0364:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x24));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0377;
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1e), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1e)), this.oCPU.AX.UInt16));

		L0377:
			this.oCPU.SI.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.SI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.SI.UInt16, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.SI.UInt16 - 0x44), 0x1);
			goto L0340;

		L0383:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22));
			this.oCPU.AX.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.AX.UInt16, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1e)));
			if (this.oCPU.Flags.LE) goto L03f5;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1e));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.G) goto L03f5;
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			goto L039f;

		L039c:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L039f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x80);
			if (this.oCPU.Flags.L) goto L03a9;
			goto L0498;

		L03a9:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt8(this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L039c;
			if (this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].PlayerID != playerID)
				goto L039c;

			// Instruction address 0x0000:0x03ce, size: 5
			this.oCPU.AX.Int16 = (short)this.oParent.MapManagement.F0_2aea_1942_GetCellGroupID(
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x18), this.oCPU.AX.UInt16);
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.DI.UInt16 = this.oCPU.SHL_UInt16(this.oCPU.DI.UInt16, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 + this.oCPU.DI.UInt16 - 0x44)), 0x2);
			if (this.oCPU.Flags.NE) goto L039c;

			F15_0000_087f_SetCityOwner(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			
			goto L039c;

		L03f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), 0x0);
			goto L047a;

		L03fc:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);

		L0406:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			if (this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].StatusFlag != 0xff &&
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].PlayerID == playerID)
			{
				// Instruction address 0x0000:0x0431, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
					this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
					this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y,
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xe)),
					this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x12)));

				this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), this.oCPU.AX.UInt16);

				if (this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)) > this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa)))
				{
					this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
					this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);
					this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
					this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);
				}
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x80);
			if (this.oCPU.Flags.L) goto L0406;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.LowUInt8 = (byte)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)), this.oCPU.AX.UInt16));

			F15_0000_087f_SetCityOwner(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));

		L047a:
			this.oCPU.AX.UInt16 = 0x9;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x22)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.DS.UInt16, 0xdc6a);
			this.oCPU.CX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.CX.UInt16, 0x3);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.UInt16);
			this.oCPU.CMP_UInt16(this.oCPU.AX.UInt16, (ushort)this.oParent.GameData.Players[playerID].TotalCitySize);
			if (this.oCPU.Flags.GE) goto L0498;
			goto L03fc;

		L0498:
			this.oParent.GameData.Players[playerID].TotalCitySize +=
				this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].TotalCitySize;

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 0x0);
			goto L0720;

		L04b2:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.CMP_UInt16((ushort)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))].PlayerID, 
				this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			if (this.oCPU.Flags.E) goto L04c7;
			goto L071d;

		L04c7:
			// Instruction address 0x0000:0x04cd, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x04f1, size: 5
			this.oParent.MapManagement.F0_2aea_1511_ActiveUnitSetFlag8(
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			// Instruction address 0x0000:0x050b, size: 5
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.Segment_1866.F0_1866_0cf5_CreateUnit(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;

			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Status =
				(short)(this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Status & 0xfe);

			goto L071d;

		L0533:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);
			
			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c),
				(short)this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].HomeCityID].PlayerID);

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), 
				(short)this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].NextUnitID);

			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L0566;
			goto L0717;

		L0566:
			// Instruction address 0x0000:0x056c, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			
			// Instruction address 0x0000:0x0583, size: 5
			this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)),
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);
			
			// Instruction address 0x0000:0x0597, size: 5
			this.oParent.MapManagement.F0_2aea_1511_ActiveUnitSetFlag8(
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			// Instruction address 0x0000:0x05b1, size: 5
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.Segment_1866.F0_1866_0cf5_CreateUnit(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.DI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.DI.UInt16, this.oCPU.AX.UInt16);

			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Status =
				(short)(this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Status & 0xfe);

			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].HomeCityID =
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].HomeCityID;

		L05de:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L05e7;
			goto L071d;

		L05e7:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.NE) goto L05f2;
			goto L071d;

		L05f2:
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.DI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.DI.UInt16, this.oCPU.SI.UInt16);
			
			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20), 
				(short)this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))].NextUnitID);

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2),
				(short)this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))].TypeID);

			// Instruction address 0x0000:0x061a, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)));
			
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.AX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.AX.UInt16, this.oCPU.SI.UInt16);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x46), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x063e, size: 5
			this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)),
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)), 0xffff);
			if (this.oCPU.Flags.E) goto L06c4;

			// Instruction address 0x0000:0x065b, size: 5
			this.oParent.MapManagement.F0_2aea_1511_ActiveUnitSetFlag8(
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			// Instruction address 0x0000:0x0678, size: 5
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.Segment_1866.F0_1866_0cf5_CreateUnit(
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)),
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2)),
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));
			this.oCPU.CX.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.CX.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.CX.UInt16, this.oCPU.AX.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x48), this.oCPU.CX.UInt16);

			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Status =
				(short)(this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Status & 0xfe);

			if (this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))].HomeCityID].PlayerID ==
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)))
				goto L06c4;

			this.oParent.GameData.Players[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].HomeCityID =
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].HomeCityID;

		L06c4:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), this.oCPU.AX.UInt16);
			goto L05de;

		L06cd:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.E) goto L071d;
			
			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.DI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.DI.UInt16, this.oCPU.SI.UInt16);

			this.oCPU.WriteInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20), 
				(short)this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))].NextUnitID);

			if (this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))].HomeCityID].PlayerID == 
				this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1c)))
				goto L0711;

			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a))].HomeCityID =
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].HomeCityID;

		L0711:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a), this.oCPU.AX.UInt16);

		L0717:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x1a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L06cd;

		L071d:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))));

		L0720:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)), 0x80);
			if (this.oCPU.Flags.L) goto L072a;
			goto L07f5;

		L072a:
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.BX.UInt16 = this.oCPU.AX.UInt16;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			if (this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].TypeID == -1)
				goto L071d;

			this.oCPU.AX.UInt16 = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			this.oCPU.SI.UInt16 = this.oCPU.ADD_UInt16(this.oCPU.SI.UInt16, this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			// Instruction address 0x0000:0x0765, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetVisibleTerrainImprovements(
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			this.oCPU.TEST_UInt8(this.oCPU.AX.LowUInt8, 0x1);
			if (this.oCPU.Flags.NE) goto L0774;
			goto L0533;

		L0774:
			// Instruction address 0x0000:0x0780, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba_GetCityID(
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;

			if (this.oParent.GameData.Cities[this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].HomeCityID].PlayerID ==
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))].PlayerID) 
				goto L04b2;

			// Instruction address 0x0000:0x07b8, size: 5
			this.oParent.Segment_1866.F0_1866_0f10_DeleteUnit(playerID, this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14)));
			
			// Instruction address 0x0000:0x07cc, size: 5
			this.oParent.MapManagement.F0_2aea_1511_ActiveUnitSetFlag8(
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y);

			// Instruction address 0x0000:0x07e7, size: 5
			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.Segment_1866.F0_1866_0cf5_CreateUnit(
				this.oCPU.ReadInt8(this.oCPU.DS.UInt16, this.oCPU.DI.UInt16),
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].TypeID,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.X,
				this.oParent.GameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x14))].Position.Y));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), this.oCPU.AX.UInt16);
			goto L071d;

		L07f5:
			F15_0000_08ba(this.oCPU.ReadInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))].ImprovementFlags0 |= 1;

			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))].Position.X);
			this.oParent.GameData.Players[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x16))].XStart = (short)this.oCPU.AX.UInt16;

			if (playerID != this.oParent.GameData.HumanPlayerID) goto L0839;

			// Instruction address 0x0000:0x082f, size: 5
			this.oParent.MapManagement.F0_2aea_0008_DrawVisibleMap(this.oParent.GameData.HumanPlayerID, this.oParent.Var_d4cc_MapViewX, this.oParent.Var_d75e_MapViewY);

			goto L0876;

		L0839:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].PlayerID = -1;

			this.oCPU.PUSH_UInt16(0); // stack management - push return segment, ignored
			this.oCPU.PUSH_UInt16(0x084f); // stack management - push return offset
			F15_0000_08ba(playerID);
			this.oCPU.POP_UInt32(); // stack management - pop return offset and segment
			
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;
			this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))].ImprovementFlags0 |= 1;

			this.oCPU.AX.UInt16 = (ushort)((short)this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x10))].Position.X);
			this.oParent.GameData.Players[playerID].XStart = (short)this.oCPU.AX.UInt16;

			this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].PlayerID = playerID;

		L0876:
			this.oCPU.AX.UInt16 = 0x1;

		L0879:
			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F15_0000_0000");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="playerID"></param>
		public void F15_0000_087f_SetCityOwner(short cityID, short playerID)
		{
			this.oCPU.Log.EnterBlock($"F15_0000_087f_TransferCityToAnotherPlayer({cityID}, {playerID})");

			// function body
			this.oParent.GameData.Cities[cityID].PlayerID = playerID;

			// Instruction address 0x0000:0x08a1, size: 5
			this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(playerID, 
				this.oParent.GameData.Cities[cityID].Position.X, this.oParent.GameData.Cities[cityID].Position.Y);

			this.oParent.GameData.Players[playerID].TotalCitySize += this.oParent.GameData.Cities[cityID].ActualSize;

			// Far return
			this.oCPU.Log.ExitBlock("F15_0000_087f_TransferCityToAnotherPlayer");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F15_0000_08ba(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F15_0000_08ba({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.UInt16);
			this.oCPU.BP.UInt16 = this.oCPU.SP.UInt16;
			this.oCPU.SP.UInt16 = this.oCPU.SUB_UInt16(this.oCPU.SP.UInt16, 0xa);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.UInt16);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.UInt16);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), 0x7fff);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 0x0);
			goto L094c;

		L08d3:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 0x0);
			goto L0913;

		L08df:
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.DI.UInt16 = this.oCPU.AX.UInt16;

			// Instruction address 0x0000:0x0905, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Position.X,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].Position.Y,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Position.X,
				this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16));

		L0910:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))));

		L0913:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)), 0x80);
			if (this.oCPU.Flags.GE) goto L0935;

			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;
			
			if (this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].PlayerID != playerID)
				goto L0910;

			this.oCPU.CMP_UInt8(this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x8))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L08df;

			goto L0910;

		L0935:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4)), this.oCPU.AX.UInt16);
			if (this.oCPU.Flags.GE) goto L0949;
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x2), this.oCPU.AX.UInt16);
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa), this.oCPU.AX.UInt16);

		L0949:
			this.oCPU.WriteUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))));

		L094c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)), 0x80);
			if (this.oCPU.Flags.GE) goto L0971;
			this.oCPU.AX.UInt16 = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6)));
			this.oCPU.SI.UInt16 = this.oCPU.AX.UInt16;

			if (this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].PlayerID != playerID)
				goto L0949;

			this.oCPU.CMP_UInt8(this.oParent.GameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0x6))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0949;
			goto L08d3;

		L0971:
			this.oCPU.AX.UInt16 = this.oCPU.ReadUInt16(this.oCPU.SS.UInt16, (ushort)(this.oCPU.BP.UInt16 - 0xa));

			this.oCPU.SI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.DI.UInt16 = this.oCPU.POP_UInt16();
			this.oCPU.SP.UInt16 = this.oCPU.BP.UInt16;
			this.oCPU.BP.UInt16 = this.oCPU.POP_UInt16();

			// Far return
			this.oCPU.Log.ExitBlock("F15_0000_08ba");

			return this.oCPU.AX.UInt16;
		}
	}
}
