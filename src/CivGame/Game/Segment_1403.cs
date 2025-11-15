using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class Segment_1403
	{
		private CivGame oParent;
		private VCPU oCPU;

		public Segment_1403(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_1403_000e(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_1403_000e({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x52);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b90, (ushort)((short)playerID));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), (ushort)((short)this.oParent.CivState.PlayerFlags));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

			if (playerID == this.oParent.CivState.HumanPlayerID)
			{
				this.oParent.CivState.PlayerFlags = (short)(1 << this.oParent.CivState.HumanPlayerID);

				if (this.oParent.CivState.TurnCount == 20 || this.oParent.CivState.TurnCount == 60)
				{
					this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x1e60);
				}

				if (this.oParent.CivState.TurnCount == 40 || this.oParent.CivState.TurnCount == 80)
				{
					this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x1e67);
				}
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0x0);
			goto L008f;

		L008c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))));

		L008f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L0099;
			goto L0128;

		L0099:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1)
				goto L0125;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdf60), 0x1);
			if (this.oCPU.Flags.NE) goto L00bd;
			goto L0125;

		L00bd:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves =
				(short)(this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].MoveCount * 3);

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 2)
				goto L0125;

			// Instruction address 0x1403:0x00e9, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID, (int)WonderEnum.Lighthouse);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L00f9;
			goto L0110;

		L00f9:
			// Instruction address 0x1403:0x0100, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID, (int)WonderEnum.MagellansExpedition);
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L0110;
			goto L0125;

		L0110:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves += 3;

		L0125:
			goto L008c;

		L0128:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x7f);

		L013c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0x0);
			goto L014c;

		L0149:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))));

		L014c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L0156;
			goto L3e4e;

		L0156:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1ae0), 0x0);
			if (this.oCPU.Flags.NE) goto L0160;
			goto L0165;

		L0160:
			// Instruction address 0x1403:0x0160, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

		L0165:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.NE) goto L016f;
			goto L0177;

		L016f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0x80);
			goto L0149;

		L0177:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0182;
			goto L0187;

		L0182:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x1);

		L0187:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1)
				goto L0149;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID >= 28)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID = 1;
			}

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L01cc;
			goto L01fc;

		L01cc:
			// Instruction address 0x1403:0x01f4, size: 5
			this.oParent.Segment_1866.F0_1866_01dc(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y,
				playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				0);

		L01fc:
			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0x9) != 0)
				goto L0149;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves == 0)
				goto L0149;

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0x4) == 0)
				goto L0356;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xfb;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 0x8;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x0265, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L02d7;

			// Instruction address 0x1403:0x0286, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E)
				goto L02d7;

			// Instruction address 0x1403:0x02b3, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))].ActualSize < 3)
				goto L02d7;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));

		L02d7:
			// Instruction address 0x1403:0x02f5, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E)
				goto L0149;

			// Instruction address 0x1403:0x0312, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID != 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)))
				goto L0149;

			// Instruction address 0x1403:0x0338, size: 5
			this.oParent.Segment_1866.F0_1866_18d0(playerID,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L0149;

			// Instruction address 0x1403:0x034b, size: 5
			this.oParent.Segment_1866.F0_1866_00c6(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));

			goto L0149;

		L0356:
			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L043b;

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0xc2) != 0)
				goto L043b;

			if (this.oParent.Var_d4cc_XPos >= 
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X)
				goto L03bb;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e),
				(short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.AX.Word = (ushort)this.oParent.Var_d75e_YPos;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.A) goto L03a0;
			goto L03bb;

		L03a0:
			if (this.oParent.Var_d4cc_XPos + 14 <
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X)
				goto L03bb;

			this.oCPU.AX.Word = (ushort)this.oParent.Var_d75e_YPos;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0xa);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));
			if (this.oCPU.Flags.BE) goto L03bb;
			goto L043b;

		L03bb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x0);
			if (this.oCPU.Flags.E) goto L03c4;
			goto L03cf;

		L03c4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			goto L0149;

		L03cf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb278), 0x1);
			if (this.oCPU.Flags.NE) goto L03d9;
			goto L03e5;

		L03d9:
			// Instruction address 0x1403:0x03dd, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(30);

		L03e5:
			// Instruction address 0x1403:0x040c, size: 5
			this.oParent.MapManagement.F0_2aea_0008(playerID,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X - 7,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y - 6);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x7f);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);
			if (this.oParent.CivState.TurnCount == 0) goto L042d;
			goto L043b;

		L042d:
			// Instruction address 0x1403:0x0433, size: 5
			F0_1403_4060(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

		L043b:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L044c;
			goto L0451;

		L044c:
			// Instruction address 0x1403:0x044c, size: 5
			F0_1403_4545();

		L0451:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0x0);
			if (this.oCPU.Flags.NE) goto L045f;
			goto L0473;

		L045f:
			// Instruction address 0x1403:0x046b, size: 5
			this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4dc));

		L0473:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);

		L047f:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L0490;
			goto L04ed;

		L0490:
			// Instruction address 0x1403:0x0496, size: 5
			this.oParent.Segment_25fb.F0_25fb_0c9d(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0x0);
			if (this.oCPU.Flags.NE) goto L04aa;
			goto L04bf;

		L04aa:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

		L04bf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x4);
			if (this.oCPU.Flags.G) goto L04cb;
			goto L04ea;

		L04cb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x20);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;

		L04ea:
			goto L0d0a;

		L04ed:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L04f7;
			goto L05cc;

		L04f7:
			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0xc2) != 0)
				goto L051b;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X == -1)
				goto L05cc;

		L051b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x72);

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0x40) == 0)
				goto L0550;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
				goto L054a;

			this.oCPU.AX.Word = 0x6d;
			goto L054d;

		L054a:
			this.oCPU.AX.Word = 0x69;

		L054d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);

		L0550:
			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0x80) == 0)
				goto L05a2;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x6d);

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0x40) != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x66);
			}

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status & 0x2) != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x70);
			}

		L05a2:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 1)
				goto L05c9;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x68);

		L05c9:
			goto L0d00;

		L05cc:
			// Instruction address 0x1403:0x05d2, size: 5
			F0_1403_4060(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			if (this.oParent.CivState.TurnCount == 0) goto L05e4;
			goto L0613;

		L05e4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L05ed;
			goto L0613;

		L05ed:
			// Instruction address 0x1403:0x05fa, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8),
				this.oParent.CivState.Players[playerID].Nation);

			this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x1e6e);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);

		L0613:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)) < 128)
			{
				if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
					goto L062d;
			}
			goto L0649;

		L062d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L0636;
			goto L0649;

		L0636:
			this.oParent.Help.F4_0000_00af(playerID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);

		L0649:
			// Instruction address 0x1403:0x0655, size: 5
			this.oParent.Segment_1866.F0_1866_0ad6(playerID, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.NE) goto L0667;
			goto L066c;

		L0667:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L066c:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.E) goto L0676;
			goto L06b4;

		L0676:
			// Instruction address 0x1403:0x0676, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0xd);
			if (this.oCPU.Flags.E) goto L0687;
			goto L06b1;

		L0687:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L0690;
			goto L06b1;

		L0690:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oParent.Var_db3c_MouseXPos = 0x50;
			this.oParent.Var_db3e_MouseYPos = 0x8;
			this.oParent.Var_db3a_MouseButton = 0x1;
			goto L09cf;

		L06b1:
			goto L0d00;

		L06b4:
			// Instruction address 0x1403:0x06cd, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				(((short)this.oParent.Var_db3c_MouseXPos - 80) / 16) + this.oParent.Var_d4cc_XPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_db3e_MouseYPos;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.Var_d75e_YPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oParent.Var_db3e_MouseYPos, 0x8);
			if (this.oCPU.Flags.L) goto L06fd;
			goto L073a;

		L06fd:
			// Instruction address 0x1403:0x0707, size: 5
			this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), -1);

			// Instruction address 0x1403:0x070f, size: 5
			F0_1403_4545();

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4ca), 0xffff);
			if (this.oCPU.Flags.NE) goto L071e;
			goto L0737;

		L071e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4ca);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L072e;
			goto L0734;

		L072e:
			goto L0d0a;

		L0734:
			goto L3365;

		L0737:
			goto L3c40;

		L073a:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3c_MouseXPos, 0x50);
			if (this.oCPU.Flags.L) goto L0744;
			goto L0846;

		L0744:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3e_MouseYPos, 0x3a);
			if (this.oCPU.Flags.L) goto L074e;
			goto L078c;

		L074e:
			// Instruction address 0x1403:0x0775, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				(short)this.oParent.Var_db3c_MouseXPos + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6ed6) - 7);

			// Instruction address 0x1403:0x0781, size: 5
			this.oParent.MapManagement.F0_2aea_0008(playerID,
				(short)this.oCPU.AX.Word,
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((short)this.oParent.Var_db3e_MouseYPos + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x70ea) - 14, 0, 49));

			goto L0840;

		L078c:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3e_MouseYPos, 0x48);
			if (this.oCPU.Flags.L) goto L0796;
			goto L0833;

		L0796:
			// Instruction address 0x1403:0x0796, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.Palace.F17_0000_07ec(0);
			
			this.oParent.Var_aa_Rectangle.ScreenID = 0;

			// Instruction address 0x1403:0x07af, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x1403:0x07cc, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x1403:0x07d8, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x1e79, 1);

			// Instruction address 0x1403:0x0800, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			// Instruction address 0x1403:0x0808, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1403:0x080d, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x1403:0x081e, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x1403:0x0826, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			// Instruction address 0x1403:0x082b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			goto L0840;

		L0833:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.E) goto L083d;
			goto L0840;

		L083d:
			goto L3ea1;

		L0840:
			this.oParent.Var_db3a_MouseButton = 0x0;

		L0846:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x2);
			if (this.oCPU.Flags.E) goto L0850;
			goto L096c;

		L0850:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L085a;
			goto L096c;

		L085a:
			// Instruction address 0x1403:0x085a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.E) goto L0869;
			goto L085a;

		L0869:
			// Instruction address 0x1403:0x0882, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				((short)this.oParent.Var_db3c_MouseXPos - 80) / 16 + this.oParent.Var_d4cc_XPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oParent.Var_db3e_MouseYPos;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x8);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.Var_d75e_YPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			
			// Instruction address 0x1403:0x08d0, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0208_GetShortestDistance(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) -
					this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)) -
					this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)Math.Abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) -
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4f);
			if (this.oCPU.Flags.E) goto L08f7;
			goto L0918;

		L08f7:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.CX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Word);
			
			// Instruction address 0x1403:0x0903, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.LE) goto L0913;
			goto L0918;

		L0913:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x1);

		L0918:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x1);
			if (this.oCPU.Flags.E) goto L0921;
			goto L0966;

		L0921:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;

			this.oParent.Var_db3a_MouseButton = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 0x0);

			// Instruction address 0x1403:0x095b, size: 5
			this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4dc));

			goto L096c;

		L0966:
			this.oParent.Var_db3a_MouseButton = 0x2;

		L096c:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x2);
			if (this.oCPU.Flags.E) goto L0976;
			goto L09cf;

		L0976:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))];

			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L099b;
			goto L09a5;

		L099b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L09a5;
			goto L09cf;

		L09a5:
			// Instruction address 0x1403:0x09a5, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			
			// Instruction address 0x1403:0x09b4, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oParent.Civilopedia.F8_0000_062a(this.oCPU.AX.Word, 3);
			
			// Instruction address 0x1403:0x09c5, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			// Instruction address 0x1403:0x09ca, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L09cf:
			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x1);
			if (this.oCPU.Flags.E) goto L09d9;
			goto L0ce5;

		L09d9:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0x0);
			if (this.oCPU.Flags.NE) goto L09e2;
			goto L0b3c;

		L09e2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L09ec;
			goto L0b3c;

		L09ec:
			// Instruction address 0x1403:0x09f2, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0x2);
			if (this.oCPU.Flags.NE) goto L0a06;
			goto L0ab8;

		L0a06:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))];

			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0a2b;
			goto L0adb;

		L0a2b:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 2)
				goto L0a56;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.NE) goto L0a56;
			goto L0ab8;

		L0a56:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 0)
				goto L0a81;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.E) goto L0a81;
			goto L0ab8;

		L0a81:
			// Instruction address 0x1403:0x0a87, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE)
				goto L0ab8;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 1)
				goto L0adb;

		L0ab8:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;

		L0adb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), 0x0);

			// Instruction address 0x1403:0x0aec, size: 5
			this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4dc));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L0afd;
			goto L0b39;

		L0afd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0b26;
			goto L0b34;

		L0b26:
			// Instruction address 0x1403:0x0b2c, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L0b34:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L0b39:
			goto L0ce5;

		L0b3c:
			// Instruction address 0x1403:0x0b42, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0b51;
			goto L0bf4;

		L0b51:
			// Instruction address 0x1403:0x0b57, size: 5
			this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.HumanPlayerID);
			if (this.oCPU.Flags.NE) goto L0b68;
			goto L0b72;

		L0b68:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L0b72;
			goto L0bf4;

		L0b72:
			// Instruction address 0x1403:0x0b78, size: 5
			this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x0b89, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.AX.Word);
			
			// Instruction address 0x1403:0x0b9a, size: 5
			this.oParent.Segment_1ade.F0_1ade_03ea(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)));
			
			// Instruction address 0x1403:0x0ba2, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L0bb5;
			goto L0bf1;

		L0bb5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0bde;
			goto L0bec;

		L0bde:
			// Instruction address 0x1403:0x0be4, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L0bec:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L0bf1:
			goto L0ce5;

		L0bf4:
			// Instruction address 0x1403:0x0bfa, size: 5
			this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L0c0f;
			goto L0c27;

		L0c0f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0c18;
			goto L0c27;

		L0c18:
			this.oParent.Overlay_10.F10_0000_0477(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

		L0c27:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0xffff);
			if (this.oCPU.Flags.E)
				goto L0ccc;

			if (playerID != this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0))
				goto L0ccc;

			// Instruction address 0x1403:0x0c42, size: 5
			this.oParent.Segment_1866.F0_1866_1f69(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))].Status & 0x9) != 0)
				goto L0cc9;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x7f);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L0c8a;
			goto L0cc6;

		L0c8a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0cb3;
			goto L0cc1;

		L0cb3:
			// Instruction address 0x1403:0x0cb9, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L0cc1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L0cc6:
			goto L3c40;

		L0cc9:
			goto L0ce5;

		L0ccc:
			// Instruction address 0x1403:0x0cdd, size: 5
			this.oParent.MapManagement.F0_2aea_0008(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) - 7,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)) - 6);

		L0ce5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0xffff);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
			if (this.oCPU.Flags.NE) goto L0cf3;
			goto L0cfb;

		L0cf3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L0d00;

		L0cfb:
			// Instruction address 0x1403:0x0cfb, size: 5
			F0_1403_4545();

		L0d00:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L0d0a;
			goto L1b5e;

		L0d0a:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)) > 127)
				goto L0d24;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X == -1)
				goto L0d38;

		L0d24:
			// Instruction address 0x1403:0x0d2a, size: 5
			this.oParent.UnitGoTo.F0_2e31_000e_GetNextMove(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			goto L0d4d;

		L0d38:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;

		L0d4d:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)) < 128)
			{
				this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);

				this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Word);
			}
			else
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), 0);
			}

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			goto L1aed;

		L0d75:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x0d90, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			goto L1b5e;

		L0d9b:
			// Instruction address 0x1403:0x0da1, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0db0;
			goto L0dd9;

		L0db0:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x1a);
			if (this.oCPU.Flags.L) goto L0dd0;
			goto L0dd9;

		L0dd0:
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0xe);
			if (this.oCPU.Flags.E) goto L0dd9;
			goto L0deb;

		L0dd9:
			// Instruction address 0x1403:0x0ddd, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1e83);

			goto L1b5e;

		L0deb:
			// Instruction address 0x1403:0x0df1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves == 0)
				goto L0f1c;

			// Instruction address 0x1403:0x0e24, size: 5
			this.oParent.Segment_29f3.F0_29f3_0c9e(this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID);
			
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0e32;
			goto L0f1c;

		L0e32:
			// Instruction address 0x1403:0x0e38, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x6);
			if (this.oCPU.Flags.NE) goto L0e4c;
			goto L0e61;

		L0e4c:
			// Instruction address 0x1403:0x0e56, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(6,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			goto L0e91;

		L0e61:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x10);
			if (this.oCPU.Flags.NE) goto L0e6a;
			goto L0e7f;

		L0e6a:
			// Instruction address 0x1403:0x0e74, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(0x10,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			goto L0e91;

		L0e7f:
			// Instruction address 0x1403:0x0e89, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

		L0e91:
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID != this.oParent.CivState.HumanPlayerID)
				goto L0eb5;

			// Instruction address 0x1403:0x0ead, size: 5
			this.oParent.MapManagement.F0_2aea_1601(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

		L0eb5:
			// Instruction address 0x1403:0x0ebb, size: 5
			F0_1403_3ed7(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x0edb, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(this.oParent.CivState.HumanPlayerID,
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID, 2);

			if (playerID != this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID)
			{
				// Instruction address 0x1403:0x0eff, size: 5
				this.oParent.Segment_25fb.F0_25fb_304d(
					this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
					1, 4);
			}

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

		L0f1c:
			goto L1b5e;

		L0f1f:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			goto L1b5e;

		L0f37:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x1);
			goto L1b5e;

		L0f44:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 1;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x0f64, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			goto L1b5e;

		L0f6f:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.AX.Word);

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TransportCapacity != 0)
				goto L0fa0;

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), 0x17);
			if (this.oCPU.Flags.E) goto L0fa0;
			goto L0ffa;

		L0fa0:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].NextUnitID == -1)
				goto L0ffa;

			// Instruction address 0x1403:0x0fc8, size: 5
			this.oParent.Segment_1866.F0_1866_144b(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x14f6);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x1);

			// Instruction address 0x1403:0x0fe0, size: 5
			F0_1403_4562(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			this.oCPU.AX.Word = this.oCPU.DEC_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x7f);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L0ffa:
			goto L1b5e;

		L0ffd:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L1007;
			goto L108b;

		L1007:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0x0);
			if (this.oCPU.Flags.E) goto L1010;
			goto L1043;

		L1010:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L1019;
			goto L1040;

		L1019:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

		L1040:
			goto L1088;

		L1043:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L104c;
			goto L1088;

		L104c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L1075;
			goto L1083;

		L1075:
			// Instruction address 0x1403:0x107b, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L1083:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L1088:
			goto L10b3;

		L108b:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) != 0)
			{
				this.oCPU.BX.Word = 0x7;
			}
			else
			{
				this.oCPU.BX.Word = 0x2;
			}

			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x1403:0x10ab, size: 5
			this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd4ce)));

		L10b3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.oCPU.XOR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 0x1));
			goto L1b5e;

		L10bb:
			// Instruction address 0x1403:0x10c1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			
			if (this.oParent.Var_6c9a == 0) goto L10d6;
			goto L10f0;

		L10d6:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));

			goto L1b5e;

		L10f0:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 1)
				goto L1b5e;

			// Instruction address 0x1403:0x1118, size: 5
			this.oParent.Segment_1866.F0_1866_226d(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L112c;
			goto L1137;

		L112c:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 2;

			goto L1c10;

		L1137:
			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L115a;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xfd;

			goto L1b5e;

		L115a:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x1175, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			goto L1b5e;

		L1180:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
				goto L11a9;

			// Instruction address 0x1403:0x119e, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1e8c);

			goto L1b5e;

		L11a9:
			// Instruction address 0x1403:0x11af, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x40);
			if (this.oCPU.Flags.E) goto L11c3;
			goto L11f1;

		L11c3:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x7d;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

			// Instruction address 0x1403:0x11e6, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			goto L1b5e;

		L11f1:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 0x82;

			// Instruction address 0x1403:0x120c, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves++;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves < 4)
				goto L1b5e;

			// Instruction address 0x1403:0x123e, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(0x40,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x124c, size: 5
			this.oParent.MapManagement.F0_2aea_1601(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			
			oParent.CivState.PollutedSquareCount--;

			// Instruction address 0x1403:0x125e, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x7d;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

			goto L1b5e;

		L1283:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 0)
				goto L13fd;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
				goto L130e;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 0x4;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x12bf, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L130b;

			// Instruction address 0x1403:0x12d8, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L12e7;
			goto L130b;

		L12e7:
			// Instruction address 0x1403:0x12ed, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID = 
				(short)this.oCPU.CX.Word;

		L130b:
			goto L13fd;

		L130e:
			// Instruction address 0x1403:0x1314, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x21);
			if (this.oCPU.Flags.E) goto L1323;
			goto L133a;

		L1323:
			// Instruction address 0x1403:0x132a, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Construction);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E)
				goto L133a;

			goto L1368;

		L133a:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x3f;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

			// Instruction address 0x1403:0x135d, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			goto L1b5e;

		L1368:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 0xc0;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x1388, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].MovementCost;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x4);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves++;

			if ((short)this.oCPU.CX.Word > 
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves)
				goto L1b5e;

			// Instruction address 0x1403:0x13bf, size: 5
			this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum.Fortress,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			
			// Instruction address 0x1403:0x13db, size: 5
			this.oParent.Segment_1866.F0_1866_01dc(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				1);
			
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x3f;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

		L13fd:
			goto L1b5e;

		L1400:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
				goto L1429;

			// Instruction address 0x1403:0x141e, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1e96);

			goto L1b5e;

		L1429:
			// Instruction address 0x1403:0x142f, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.NE) goto L1443;
			goto L1463;

		L1443:
			// Instruction address 0x1403:0x144a, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Railroad);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE)
				goto L145a;

			goto L146c;

		L145a:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.E) goto L1463;
			goto L146c;

		L1463:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x10);
			if (this.oCPU.Flags.NE) goto L146c;
			goto L149a;

		L146c:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xfd;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

			// Instruction address 0x1403:0x148f, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			goto L1b5e;

		L149a:
			// Instruction address 0x1403:0x14a0, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xb);
			if (this.oCPU.Flags.E) goto L14b4;
			goto L14ce;

		L14b4:
			// Instruction address 0x1403:0x14bb, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.BridgeBuilding);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E)
				goto L14cb;

			goto L14ce;

		L14cb:
			goto L1b5e;

		L14ce:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 2;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x14ee, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.NE) goto L14ff;
			goto L1505;

		L14ff:
			this.oCPU.AX.Word = 0x4;
			goto L1508;

		L1505:
			this.oCPU.AX.Word = 0x2;

		L1508:
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].MovementCost;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves++;

			if ((short)this.oCPU.CX.Word > this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves)
				goto L1b5e;

			// Instruction address 0x1403:0x154b, size: 5
			this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(
				((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)) & 8) != 0) ? TerrainImprovementFlagsEnum.RailRoad : TerrainImprovementFlagsEnum.Road,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			
			// Instruction address 0x1403:0x1567, size: 5
			this.oParent.Segment_1866.F0_1866_01dc(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				1);
			
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xfd;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

			goto L1b5e;

		L158c:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != 0)
				goto L15c5;

			this.oCPU.TEST_UInt8((byte)(this.oParent.CivState.DebugFlags & 0xff), 0x2);
			if (this.oCPU.Flags.NE) goto L15b0;
			goto L15c5;

		L15b0:
			// Instruction address 0x1403:0x15b6, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x2);
			if (this.oCPU.Flags.NE) goto L15c5;
			goto L162c;

		L15c5:
			// Instruction address 0x1403:0x15ce, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
				goto L15ff;

			// Instruction address 0x1403:0x15f4, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ea0);

			goto L1614;

		L15ff:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

		L1614:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xbf;

			goto L1b5e;

		L162c:
			// Instruction address 0x1403:0x1632, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.AX.Word);
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.TerrainModifications[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].IrrigationEffect;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xffff);
			if (this.oCPU.Flags.E) goto L1655;
			goto L168a;

		L1655:
			// Instruction address 0x1403:0x165e, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x166a, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1eaa);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xbf;

			goto L1b5e;

		L168a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xfffe);
			if (this.oCPU.Flags.E) goto L1693;
			goto L16de;

		L1693:
			// Instruction address 0x1403:0x1699, size: 5
			F0_1403_3fd0(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E) goto L16a9;
			goto L16de;

		L16a9:
			// Instruction address 0x1403:0x16b2, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x16be, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1eb1);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xbf;

			goto L1b5e;

		L16de:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 0x40;

			// Instruction address 0x1403:0x16f9, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves++;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.TerrainModifications[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].IrrigationCost > 
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves)
				goto L1b5e;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x0);
			if (this.oCPU.Flags.GE) goto L1736;
			goto L1775;

		L1736:
			// Instruction address 0x1403:0x1743, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));

			this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30))] |= 1;

			// Instruction address 0x1403:0x176a, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(6,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			goto L1799;

		L1775:
			// Instruction address 0x1403:0x177f, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(4,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x1791, size: 5
			this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum.Irrigation,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

		L1799:
			// Instruction address 0x1403:0x179f, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xbf;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

			goto L1b5e;

		L17c4:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != 0)
				goto L17f3;

			// Instruction address 0x1403:0x17e4, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x4);
			if (this.oCPU.Flags.NE) goto L17f3;
			goto L185a;

		L17f3:
			// Instruction address 0x1403:0x17fc, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
				goto L182d;

			// Instruction address 0x1403:0x1822, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1eba);

			goto L1842;

		L182d:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;

		L1842:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x7f;

			goto L1b5e;

		L185a:
			// Instruction address 0x1403:0x1860, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.TerrainModifications[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].MiningEffect;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xffff);
			if (this.oCPU.Flags.E) goto L1883;
			goto L18b8;

		L1883:
			// Instruction address 0x1403:0x188c, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x1898, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ec4);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x7f;

			goto L1b5e;

		L18b8:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 0x80;

			// Instruction address 0x1403:0x18d3, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves++;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.TerrainModifications[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].MiningCost > 
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves)
				goto L1b5e;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x0);
			if (this.oCPU.Flags.GE) goto L1910;
			goto L1970;

		L1910:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves++;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves <= 5)
				goto L1b5e;

			// Instruction address 0x1403:0x193e, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));

			this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30))] |= 1;

			// Instruction address 0x1403:0x1965, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(6,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			goto L1994;

		L1970:
			// Instruction address 0x1403:0x197a, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x198c, size: 5
			this.oParent.MapManagement.F0_2aea_1653_SetTerrainImprovements(TerrainImprovementFlagsEnum.Mines,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

		L1994:
			// Instruction address 0x1403:0x199a, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x7f;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves = 0;
			
			goto L1b5e;

		L19bf:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 0)
				goto L19e8;

			// Instruction address 0x1403:0x19dd, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ecc);

			goto L1b5e;

		L19e8:
			// Instruction address 0x1403:0x19ee, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L19fe;
			goto L1a10;

		L19fe:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)), 0x2);
			if (this.oCPU.Flags.GE) goto L1a07;
			goto L1a10;

		L1a07:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)), 0x30);
			if (this.oCPU.Flags.GE) goto L1a10;
			goto L1a13;

		L1a10:
			goto L1b5e;

		L1a13:
			// Instruction address 0x1403:0x1a19, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L1a28;
			goto L1a92;

		L1a28:
			// Instruction address 0x1403:0x1a2e, size: 5
			this.oParent.MapManagement.F0_2aea_175a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt8((byte)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize, 0xa);
			if (this.oCPU.Flags.L) goto L1a4d;
			goto L1a83;

		L1a4d:
			this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize++;
			
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			// Instruction address 0x1403:0x1a6a, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			// Instruction address 0x1403:0x1a78, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			goto L1a8f;

		L1a83:
			// Instruction address 0x1403:0x1a87, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1ed6);

		L1a8f:
			goto L1b5e;

		L1a92:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			this.oParent.Overlay_20.F20_0000_0000(playerID,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1acb;
			goto L1ae7;

		L1acb:
			// Instruction address 0x1403:0x1ad1, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			// Instruction address 0x1403:0x1adf, size: 5
			F0_1403_3f13(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

		L1ae7:
			goto L1b5e;

		L1aed:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x68);
			if (this.oCPU.Flags.NE) goto L1af5;
			goto L10bb;

		L1af5:
			if (this.oCPU.Flags.LE) goto L1afa;
			goto L1b2d;

		L1afa:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x20);
			if (this.oCPU.Flags.NE) goto L1b02;
			goto L0f1f;

		L1b02:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x44);
			if (this.oCPU.Flags.NE) goto L1b0a;
			goto L0d75;

		L1b0a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x50);
			if (this.oCPU.Flags.NE) goto L1b12;
			goto L0d9b;

		L1b12:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x62);
			if (this.oCPU.Flags.NE) goto L1b1a;
			goto L19bf;

		L1b1a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x66);
			if (this.oCPU.Flags.NE) goto L1b22;
			goto L1283;

		L1b22:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x67);
			if (this.oCPU.Flags.NE) goto L1b2a;
			goto L0ffd;

		L1b2a:
			goto L1b5e;

		L1b2d:
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x69);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xe);
			if (this.oCPU.Flags.BE) goto L1b38;
			goto L1b5e;

		L1b38:
			switch(this.oCPU.AX.Word)
			{
				case 0:
					goto L158c;
				case 1:
					goto L1b5e;
				case 2:
					goto L1b5e;
				case 3:
					goto L1b5e;
				case 4:
					goto L17c4;
				case 5:
					goto L1b5e;
				case 6:
					goto L1b5e;
				case 7:
					goto L1180;
				case 8:
					goto L1b5e;
				case 9:
					goto L1400;
				case 10:
					goto L0f44;
				case 11:
					goto L1b5e;
				case 12:
					goto L0f6f;
				case 13:
					goto L1b5e;
				case 14:
					goto L0f37;
			}

		L1b5e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.GE) goto L1b68;
			goto L1b71;

		L1b68:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L1b71;
			goto L3365;

		L1b71:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			goto L32e4;

		L1b77:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L1b80;
			goto L1b9c;

		L1b80:
			// Instruction address 0x1403:0x1b91, size: 5
			this.oParent.MapManagement.F0_2aea_0008(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) - 7,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) - 6);

			goto L1bb5;

		L1b9c:
			// Instruction address 0x1403:0x1bad, size: 5
			this.oParent.MapManagement.F0_2aea_0008(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)) - 7,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)) - 6);

		L1bb5:
			goto L3365;

		L1bb8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x8);
			goto L1c10;

		L1bc3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x1);
			goto L1c10;

		L1bce:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x2);
			goto L1c10;

		L1bd9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x7);
			goto L1c10;

		L1be4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x3);
			goto L1c10;

		L1bef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x6);
			goto L1c10;

		L1bfa:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x5);
			goto L1c10;

		L1c05:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x4);

		L1c10:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L1c19;
			goto L1cb0;

		L1c19:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L1c3d;
			goto L1c4b;

		L1c3d:
			// Instruction address 0x1403:0x1c43, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L1c4b:
			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))];

			// Instruction address 0x1403:0x1c58, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(direction.X + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x1c73, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				direction.Y + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				0, 49);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x1c84, size: 5
			F0_1403_4508(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E)
			{
				// Instruction address 0x1403:0x1ca5, size: 5
				this.oParent.MapManagement.F0_2aea_0008(playerID,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) - 8,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) - 7);
			}

			goto L3365;

		L1cb0:
			if (playerID != 0)
				goto L1d96;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 26)
				goto L1d96;

			// Instruction address 0x1403:0x1cdb, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.E) goto L1cef;
			goto L1d96;

		L1cef:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x6);
			if (this.oCPU.Flags.NE) goto L1cf8;
			goto L1d96;

		L1cf8:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 3)
				goto L1d96;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 7)
				goto L1d96;

			// Instruction address 0x1403:0x1d0e, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			if (this.oParent.CivState.Cities[this.oCPU.AX.Word].PlayerID == this.oParent.CivState.HumanPlayerID) goto L1d2b;
			goto L1d96;

		L1d2b:
			// Instruction address 0x1403:0x1d35, size: 5
			this.oParent.MapManagement.F0_2aea_16ee(6,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L1d62;
			goto L1d7e;

		L1d62:
			// Instruction address 0x1403:0x1d68, size: 5
			this.oParent.MapManagement.F0_2aea_1601(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			// Instruction address 0x1403:0x1d76, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

		L1d7e:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			goto L3365;

		L1d96:
			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))];

			// Instruction address 0x1403:0x1da3, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(direction.X + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x1dbe, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				direction.Y + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				0, 49);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x1dcf, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x1de0, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x1df1, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x1e02, size: 5
			this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			
			// !!! Illegal memory access this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1 ||
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 0)
				goto L219c;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.E) goto L1e38;
			goto L1ed2;

		L1e38:
			// Instruction address 0x1403:0x1e41, size: 5
			this.oParent.Segment_1866.F0_1866_1725(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L1e51;
			goto L1ed2;

		L1e51:
			// Instruction address 0x1403:0x1e5a, size: 5
			this.oParent.Segment_1866.F0_1866_1725(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L1e6a;
			goto L1ed2;

		L1e6a:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID >= 26)
				goto L1ed2;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xa);
			if (this.oCPU.Flags.NE) goto L1e8d;
			goto L1ed2;

		L1e8d:
			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L1ea4;

			// Instruction address 0x1403:0x1e9c, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(0x25, 0);

		L1ea4:
			if (this.oParent.CivState.GameSettingFlags.InstantAdvice) goto L1eae;
			goto L1eba;

		L1eae:
			// Instruction address 0x1403:0x1eb2, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1edf);

		L1eba:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			goto L3365;

		L1ed2:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID < 26)
				goto L219c;

			// Instruction address 0x1403:0x1ef2, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1f06;
			goto L2157;

		L1f06:
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID == playerID)
				goto L1f27;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xa);
			if (this.oCPU.Flags.E) goto L1f24;
			goto L1f27;

		L1f24:
			goto L3365;

		L1f27:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != 26)
				goto L1fb8;

			if (playerID == this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID)
				goto L1fb8;

			if (this.oParent.CivState.HumanPlayerID != this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID)
				goto L1fa4;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer |=
				(ushort)(1 << this.oParent.CivState.HumanPlayerID);

			// Instruction address 0x1403:0x1f7f, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(this.oParent.CivState.HumanPlayerID,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			// Instruction address 0x1403:0x1f8b, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(30);

			// Instruction address 0x1403:0x1f9c, size: 5
			this.oParent.Segment_1866.F0_1866_1d55(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));

		L1fa4:
			this.oParent.Overlay_22.F22_0000_0000(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			goto L3365;

		L1fb8:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != 27)
				goto L2154;

			// Instruction address 0x1403:0x1fee, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oParent.CivState.Cities[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID].Position.X,
				this.oParent.CivState.Cities[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID != playerID)
				goto L2066;

			this.oCPU.CMP_UInt8((byte)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].CurrentProductionID, 0xe8);
			if (this.oCPU.Flags.GE) goto L2018;
			goto L2066;

		L2018:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xa);
			if (this.oCPU.Flags.L) goto L2021;
			goto L2066;

		L2021:
			// Instruction address 0x1403:0x2047, size: 5
			ushort usTemp = this.oParent.MapManagement.F0_2aea_1942(
				this.oParent.CivState.Cities[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID].Position.X,
				this.oParent.CivState.Cities[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].HomeCityID].Position.Y);

			// Instruction address 0x1403:0x2057, size: 5
			this.oParent.MapManagement.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			if (this.oCPU.AX.Word == usTemp)
				goto L2154;

		L2066:
			// Instruction address 0x1403:0x206e, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Will you?\n Keep moving\n Establish trade route\n");

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID != playerID)
				goto L20b4;

			this.oCPU.CMP_UInt8((byte)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].CurrentProductionID, 0xe8);
			if (this.oCPU.Flags.L) goto L2095;
			goto L20b4;

		L2095:
			// Instruction address 0x1403:0x209d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Help build WONDER.\n");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xa);
			if (this.oCPU.Flags.L) goto L20ae;
			goto L20b4;

		L20ae:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x2);

		L20b4:
			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID == playerID)
				goto L20d1;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 0x1);
			goto L20e8;

		L20d1:
			// Instruction address 0x1403:0x20dd, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

		L20e8:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x1);
			if (this.oCPU.Flags.E) goto L20f1;
			goto L210d;

		L20f1:
			// Instruction address 0x1403:0x20fa, size: 5
			this.oParent.Segment_2459.F0_2459_0948(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L210a;
			goto L210d;

		L210a:
			goto L3365;

		L210d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x2);
			if (this.oCPU.Flags.E) goto L2116;
			goto L2154;

		L2116:
			this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ShieldsCount +=
				(short)(10 * this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].Cost);
			
			// Instruction address 0x1403:0x2149, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			goto L3365;

		L2154:
			goto L219c;

		L2157:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != 26)
				goto L219c;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.NE) goto L217a;
			goto L219c;

		L217a:
			if (playerID == this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a))
				goto L219c;

			this.oParent.Overlay_22.F22_0000_0639(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)),
				playerID);
			
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

		L219c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.E) goto L21a5;
			goto L2209;

		L21a5:
			// !!! Illegal memory access this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1 ||
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 0)
				goto L2209;

			if (playerID != this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a))
				goto L2203;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.E)
				goto L2203;

			// Instruction address 0x1403:0x21e1, size: 5
			this.oParent.Segment_1866.F0_1866_13d5(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.LE)
				goto L2203;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status |= 1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xf3;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 3;

			goto L2206;

		L2203:
			goto L3365;

		L2206:
			goto L267b;

		L2209:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2212;
			goto L267b;

		L2212:
			if (playerID == this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a))
				goto L267b;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xa);
			if (this.oCPU.Flags.E) goto L2226;
			goto L225c;

		L2226:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 0)
				goto L225c;

			// Instruction address 0x1403:0x224c, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1f28);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			goto L3365;

		L225c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.NE) goto L2265;
			goto L2282;

		L2265:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 22)
				goto L3365;

		L2282:
			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L22b2;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].AttackStrength != 0)
				goto L22b2;

			goto L3365;

		L22b2:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 26)
				goto L3365;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))].TypeID].TerrainCategory != 1)
				goto L2329;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 14)
				goto L2329;

			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.E) goto L2315;
			goto L2329;

		L2315:
			// Instruction address 0x1403:0x2319, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1f30);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			goto L3365;

		L2329:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves >= 3)
				goto L23d5;

			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L23b8;

			// Instruction address 0x1403:0x2356, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Attack at\n");

			// Instruction address 0x1403:0x2379, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves, 10));

			// Instruction address 0x1403:0x2389, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "/3 strength?\n Cancel\n Attack\n");

			// Instruction address 0x1403:0x239d, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 16);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E)
				goto L23d5;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			goto L3365;

		L23b8:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves < 2)
				goto L3365;

		L23d5:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L23e1;
			goto L23f3;

		L23e1:
			// Instruction address 0x1403:0x23eb, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(this.oParent.CivState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

		L23f3:
			// Instruction address 0x1403:0x23fa, size: 5
			this.oParent.Segment_1866.F0_1866_1122(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);

			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L241c;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L241c;
			goto L2422;

		L241c:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x70d8, 0x1);

		L2422:
			// Instruction address 0x1403:0x2437, size: 5
			this.oParent.Segment_29f3.F0_29f3_000e(playerID, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)),
				1);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x70d8, 0x0);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xffff);
			if (this.oCPU.Flags.E) goto L2466;
			goto L2469;

		L2466:
			goto L3365;

		L2469:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != -1)
				goto L248e;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			goto L3c40;

		L248e:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves -= 3;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves < 0)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;
			}

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves == 15)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;
			}

			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.NE) goto L24d8;
			goto L3365;

		L24d8:
			// Instruction address 0x1403:0x24de, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			if (this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID != this.oParent.CivState.HumanPlayerID)
			{
				this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].StatusFlag |= 0x10;
			}

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1)
				goto L255b;

			this.oCPU.TEST_UInt16(this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ImprovementFlags0, 0x80);
			if (this.oCPU.Flags.E) goto L2530;
			goto L255b;

		L2530:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xa);
			if (this.oCPU.Flags.NE) goto L2539;
			goto L255b;

		L2539:
			if (this.oParent.CivState.DifficultyLevel == 0) goto L2543;
			goto L254f;

		L2543:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L254f;
			goto L255b;

		L254f:
			this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize--;

		L255b:
			this.oCPU.CMP_UInt8((byte)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize, 0x0);
			if (this.oCPU.Flags.E) goto L256d;
			goto L25cf;

		L256d:
			// Instruction address 0x1403:0x2576, size: 5
			this.oParent.Segment_1ade.F0_1ade_018e(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oParent.StartGameMenu.F5_0000_0e6c(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a), playerID);

			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L25cf;

			// Instruction address 0x1403:0x259e, size: 5
			this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.NE) goto L25b2;
			goto L25cf;

		L25b2:
			this.oParent.CivState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))].VisibleByPlayer |=
				(ushort)(1 << this.oParent.CivState.HumanPlayerID);

		L25cf:
			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L25f0;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L25e6;
			goto L25f0;

		L25e6:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L25f0;
			goto L260e;

		L25f0:
			this.oCPU.AX.Low = (byte)this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize;
			this.oParent.CivState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].VisibleSize = (sbyte)this.oCPU.AX.Low;

			// Instruction address 0x1403:0x2606, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

		L260e:
			// Instruction address 0x1403:0x2614, size: 5
			this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2622;
			goto L2649;

		L2622:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L262e;
			goto L2649;

		L262e:
			// Instruction address 0x1403:0x2634, size: 5
			this.oParent.MapManagement.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			// Instruction address 0x1403:0x2641, size: 5
			this.oParent.Segment_25fb.F0_25fb_3459(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a), this.oCPU.AX.Word);

		L2649:
			goto L3365;

		L267b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.NE) goto L2684;
			goto L26b7;

		L2684:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.E) goto L268d;
			goto L26b7;

		L268d:
			// !!! Illegal memory access
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1 ||
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 2)
				goto L26b7;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			goto L3365;

		L26b7:
			// !!! Illegal memory access
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != -1 &&
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory == 0)
				goto L273b;

			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.NE) goto L26e2;
			goto L273b;

		L26e2:
			// Instruction address 0x1403:0x26e8, size: 5
			this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L26f8;
			goto L273b;

		L26f8:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == 25)
				goto L2719;

			// Instruction address 0x1403:0x2706, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x1f62);

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			goto L3365;

		L2719:
			// Instruction address 0x1403:0x271f, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			// Instruction address 0x1403:0x2730, size: 5
			this.oParent.Segment_29f3.F0_29f3_0d4d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			
			goto L3365;

		L273b:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves == 0)
				goto L3365;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 0)
				goto L2850;

			// Instruction address 0x1403:0x2780, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.AX.Low = this.oCPU.AND_UInt8(this.oCPU.AX.Low, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E)
				goto L27e4;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves == 0)
				goto L27e4;

			// Instruction address 0x1403:0x27a2, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x10);
			if (this.oCPU.Flags.E)
				goto L27db;

			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L27db;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X != -1)
				goto L27db;

			this.oCPU.AX.Low = 0x0;
			goto L27dd;

		L27db:
			this.oCPU.AX.Low = 0x1;

		L27dd:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves -= (sbyte)this.oCPU.AX.Low;

			goto L284d;

		L27e4:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves == 3)
				goto L2829;

			this.oCPU.AX.Low = 0x3;
			this.oCPU.IMUL_UInt8(this.oCPU.AX, 
				(byte)this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].MovementCost);

			if (this.oParent.MSCAPI.RNG.Next(this.oCPU.AX.Word) <= 
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves)
				goto L2829;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			goto L3365;

		L2829:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = 0x3;
			this.oCPU.IMUL_UInt8(this.oCPU.AX, 
				(byte)this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].MovementCost);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves -= 
				(short)this.oCPU.CX.Word;

		L284d:
			goto L2865;

		L2850:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves -= 3;

		L2865:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves < 0)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;
			}

			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L28ff;

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection == -1) ||
				((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection ^ 0x4) !=
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))))
				goto L28e8;

			// Instruction address 0x1403:0x28c3, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 2);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.G)
				goto L28e8;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			goto L3365;

		L28e8:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));

		L28ff:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2908;
			goto L29a0;

		L2908:
			if (playerID != this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd20a) ||
				playerID == this.oParent.CivState.HumanPlayerID)
				goto L29a0;

			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.E) goto L2927;
			goto L29a0;

		L2927:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory == 0)
				goto L295d;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 1 ||
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves == 0)
				goto L29a0;

		L295d:
			// Instruction address 0x1403:0x2967, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves == 0)
				goto L2992;

			this.oCPU.AX.Word = 0x4;
			goto L2995;

		L2992:
			this.oCPU.AX.Word = 0x2;

		L2995:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			if (this.oCPU.Flags.LE) goto L299d;
			goto L29a0;

		L299d:
			goto L3365;

		L29a0:
			// Instruction address 0x1403:0x29ae, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) + 80,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L29c2;
			goto L2b06;

		L29c2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.L) goto L29cb;
			goto L2b06;

		L29cb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.NE) goto L29d4;
			goto L2acb;

		L29d4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xa);
			if (this.oCPU.Flags.NE) goto L29dd;
			goto L2acb;

		L29dd:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID >= 26)
				goto L2acb;

			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0xf);
			if (this.oCPU.Flags.NE) goto L2a00;
			goto L2acb;

		L2a00:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2a0b;
			goto L2acb;

		L2a0b:
			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L2a21;

			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2a21;
			goto L2acb;

		L2a21:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 0)
				goto L2acb;

			// Instruction address 0x1403:0x2a49, size: 5
			this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L2a59;
			goto L2acb;

		L2a59:
			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L2a92;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;

			// Instruction address 0x1403:0x2a6c, size: 5
			this.oParent.Segment_29f3.F0_29f3_0c9e(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2a7a;
			goto L2a7d;

		L2a7a:
			goto L3365;

		L2a7d:
			// Instruction address 0x1403:0x2a87, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 2);
			
			goto L2acb;

		L2a92:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.HumanPlayerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2a9d;
			goto L2acb;

		L2a9d:
			if ((this.oParent.CivState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Diplomacy[playerID] & 2) == 0)
				goto L2acb;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			goto L3365;

		L2acb:
			if (playerID == this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)))
				goto L2b06;

			// Instruction address 0x1403:0x2adc, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0xe);
			if (this.oCPU.Flags.NE) goto L2aeb;
			goto L2b06;

		L2aeb:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer |=
				(ushort)(1 << this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

		L2b06:
			// Instruction address 0x1403:0x2b0c, size: 5
			this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);
			
			if (playerID != 0)
				goto L2b9d;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.NE) goto L2b29;
			goto L2b9d;

		L2b29:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30))];
			
			if ((this.oCPU.AX.Word & (1 << this.oParent.CivState.HumanPlayerID)) == 0)
				goto L2b9d;

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer & (1 << this.oParent.CivState.HumanPlayerID)) != 0)
				goto L2b9d;

			// Instruction address 0x1403:0x2b78, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			if (this.oParent.CivState.Cities[this.oCPU.AX.Word].PlayerID == this.oParent.CivState.HumanPlayerID)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer |=
					this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
						this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30))];
			}

		L2b9d:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.NE) goto L2ba6;
			goto L2c18;

		L2ba6:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2bb1;
			goto L2c18;

		L2bb1:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L2bd6;
			goto L2c18;

		L2bd6:
			if ((this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Diplomacy[playerID] & 0x40) != 0)
				goto L2bfc;

			if ((this.oParent.CivState.Players[this.oParent.CivState.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))] & 0x40) == 0)
				goto L2c18;

		L2bfc:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer |= 
				(ushort)(1 << this.oParent.CivState.HumanPlayerID);

		L2c18:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.E) goto L2c21;
			goto L2c51;

		L2c21:
			// Instruction address 0x1403:0x2c27, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x2);
			if (this.oCPU.Flags.NE) goto L2c36;
			goto L2c51;

		L2c36:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer |=
				(ushort)(1 << this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
		L2c51:
			this.oCPU.AX.Word = this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer;
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L2c76;
			goto L2c94;

		L2c76:
			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L2c94;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L2c8b;
			goto L2cdd;

		L2c8b:
			if (playerID == 0)
				goto L2cdd;

		L2c94:
			if (!this.oParent.CivState.GameSettingFlags.EnemyMoves) goto L2c9e;
			goto L2ca9;

		L2c9e:
			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L2ccf;

		L2ca9:
			// Instruction address 0x1403:0x2cb3, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(this.oParent.CivState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			// Instruction address 0x1403:0x2cc4, size: 5
			this.oParent.Segment_1866.F0_1866_1d55(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));

			goto L2cdd;

		L2ccf:
			// Instruction address 0x1403:0x2cd5, size: 5
			this.oParent.MapManagement.F0_2aea_03ba_DrawCell(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

		L2cdd:			
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				(short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].NextUnitID);

			// Instruction address 0x1403:0x2d01, size: 5
			this.oParent.MapManagement.F0_2aea_1412(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x2d21, size: 5
			this.oParent.MapManagement.F0_2aea_13cb(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X = 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer = 0;

			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L2d6e;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory == 1)
				goto L2d6e;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0x30;

		L2d6e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L2d77;
			goto L2da5;

		L2d77:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.L) goto L2d80;
			goto L2da5;

		L2d80:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2d8b;
			goto L2da5;

		L2d8b:
			// Instruction address 0x1403:0x2d9d, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) + 80,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				0);

		L2da5:
			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X !=
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))) ||
				(this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.Y !=
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))))
				goto L2deb;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToNextDirection = -1;

			if (playerID != this.oParent.CivState.HumanPlayerID)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;
			}

		L2deb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xa);
			if (this.oCPU.Flags.E) goto L2df4;
			goto L2e24;

		L2df4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.NE) goto L2dfd;
			goto L2e24;

		L2dfd:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 1)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;
			}

		L2e24:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.AX.Word);

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TransportCapacity != 0)
				goto L2e55;

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x17);
			if (this.oCPU.Flags.E) goto L2e55;
			goto L2ff4;

		L2e55:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2e5e;
			goto L2ff4;

		L2e5e:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.AX.Word);

		L2e67:			
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 
				(short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].NextUnitID);

			this.oCPU.CX.Word =
				(ushort)((this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TransportCapacity < 1) ? 1 : 0);

			if ((short)this.oCPU.CX.Word != this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].TypeID].TerrainCategory)
				goto L2f9d;

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Status & 0x1) != 0)
				goto L2eef;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xa);
			if (this.oCPU.Flags.E)
				goto L2eef;

			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L2f9d;

			if ((this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Status & 0xc) != 0)
				goto L2f9d;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].NextUnitID == -1)
				goto L2f9d;

		L2eef:
			// Instruction address 0x1403:0x2efb, size: 5
			this.oParent.MapManagement.F0_2aea_1412(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));

			// Instruction address 0x1403:0x2f0f, size: 5
			this.oParent.MapManagement.F0_2aea_13cb(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].VisibleByPlayer = 0;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].GoToNextDirection = -1;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TransportCapacity != 0)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Status |= 1;
			}

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].TypeID].TurnsOutside != 0)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].SpecialMoves =
					(short)(this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].TypeID].TurnsOutside - 1);
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));

		L2f9d:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)), 0x14);
			if (this.oCPU.Flags.L) goto L2faf;
			goto L2ff4;

		L2faf:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2fb8;
			goto L2ff4;

		L2fb8:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.AX.Word);

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TransportCapacity > 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)))
				goto L2e67;

			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0x17);
			if (this.oCPU.Flags.NE) goto L2feb;
			goto L2e67;

		L2feb:
			if (playerID == 0)
				goto L2e67;

		L2ff4:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.NE) goto L2ffd;
			goto L3054;

		L2ffd:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L3008;
			goto L3054;

		L3008:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer |=
				(ushort)(1 << this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));

			// Instruction address 0x1403:0x3029, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x303e, size: 5
			this.oParent.Segment_2459.F0_2459_0000(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0);

			// Instruction address 0x1403:0x304c, size: 5
			this.oParent.MapManagement.F0_2aea_1511_ActiveUnitSetFlag8(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

		L3054:
			// Instruction address 0x1403:0x305d, size: 5
			this.oParent.MapManagement.F0_2aea_138c_SetCityOwner(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			// Instruction address 0x1403:0x3079, size: 5
			this.oParent.Segment_1866.F0_1866_01dc(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)),
				1);
			
			// Instruction address 0x1403:0x308a, size: 5
			this.oParent.MapManagement.F0_2aea_1894(
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L309a;
			goto L30bd;

		L309a:
			// Instruction address 0x1403:0x30a0, size: 5
			this.oParent.Segment_1866.F0_1866_1931(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))] |= 1;

		L30bd:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.E) goto L30c6;
			goto L30fe;

		L30c6:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 2)
			{
				// Instruction address 0x1403:0x30f6, size: 5
				this.oParent.Segment_1866.F0_1866_144b(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x1560);
			}

		L30fe:
			if (playerID != 0)
				goto L3184;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0xa);
			if (this.oCPU.Flags.NE) goto L3110;
			goto L3184;

		L3110:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))];
			
			if ((this.oCPU.AX.Word & (1 << this.oParent.CivState.HumanPlayerID)) == 0)
				goto L3184;

			this.oCPU.AX.Word = this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer;
			
			if ((this.oCPU.AX.Word & (1 << this.oParent.CivState.HumanPlayerID)) != 0)
				goto L3184;

			// Instruction address 0x1403:0x315f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			if (this.oParent.CivState.Cities[this.oCPU.AX.Word].PlayerID == this.oParent.CivState.HumanPlayerID)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer |=
					this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
						this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))];
			}

		L3184:
			this.oCPU.AX.Word = this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].VisibleByPlayer;
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L31a9;
			goto L31c7;

		L31a9:
			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L31c7;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L31be;
			goto L3242;

		L31be:
			if (playerID == 0)
				goto L3242;

		L31c7:
			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L31dc;

			if (this.oParent.CivState.GameSettingFlags.EnemyMoves) goto L31dc;
			goto L3220;

		L31dc:
			// Instruction address 0x1403:0x31e6, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(this.oParent.CivState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			// Instruction address 0x1403:0x31f4, size: 5
			this.oParent.MapManagement.F0_2aea_0e29(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			if (playerID == this.oParent.CivState.HumanPlayerID)
				goto L321d;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb278), 0x1);
			if (this.oCPU.Flags.NE) goto L3211;
			goto L321d;

		L3211:
			// Instruction address 0x1403:0x3215, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(30);

		L321d:
			goto L3242;

		L3220:
			// Instruction address 0x1403:0x3226, size: 5
			this.oParent.MapManagement.F0_2aea_0e29(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L3236;
			goto L3242;

		L3236:
			// Instruction address 0x1403:0x323a, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(10);

		L3242:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x1);
			if (this.oCPU.Flags.NE) goto L3250;
			goto L3281;

		L3250:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TurnsOutside != 0)
			{
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xfd;
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].GoToPosition.X = -1;
			}

		L3281:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TurnsOutside == 0 ||
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TerrainCategory != 1)
				goto L32e1;

			// Instruction address 0x1403:0x32b7, size: 5
			this.oParent.Segment_1866.F0_1866_1331(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 23);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.E)
				goto L32e1;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Status &= 0xfd;
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves = 0;

			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves =
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TurnsOutside;

		L32e1:
			goto L3365;

		L32e4:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.NE) goto L32ec;
			goto L1bb8;

		L32ec:
			if (this.oCPU.Flags.LE) goto L32f1;
			goto L3312;

		L32f1:
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x6);
			if (this.oCPU.Flags.BE) goto L32fc;
			goto L3365;

		L32fc:
			switch(this.oCPU.AX.Word)
			{
				case 0:
					goto L1bc3;
				case 1:
					goto L1bce;
				case 2:
					goto L1be4;
				case 3:
					goto L1c05;
				case 4:
					goto L1bfa;
				case 5:
					goto L1bef;
				case 6:
					goto L1bd9;
			}

		L3312:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4900);
			if (this.oCPU.Flags.NE) goto L331a;
			goto L1bce;

		L331a:
			if (this.oCPU.Flags.LE) goto L331f;
			goto L333a;

		L331f:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x63);
			if (this.oCPU.Flags.NE) goto L3327;
			goto L1b77;

		L3327:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4700);
			if (this.oCPU.Flags.NE) goto L332f;
			goto L1bb8;

		L332f:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.NE) goto L3337;
			goto L1bc3;

		L3337:
			goto L3365;

		L333a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4b00);
			if (this.oCPU.Flags.NE) goto L3342;
			goto L1bd9;

		L3342:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4d00);
			if (this.oCPU.Flags.NE) goto L334a;
			goto L1be4;

		L334a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4f00);
			if (this.oCPU.Flags.NE) goto L3352;
			goto L1bef;

		L3352:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.NE) goto L335a;
			goto L1bfa;

		L335a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5100);
			if (this.oCPU.Flags.NE) goto L3365;
			goto L1c05;

		L3365:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			goto L3abd;

		L336b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L3375;
			goto L337d;

		L3375:
			this.oParent.Overlay_10.F10_0000_0000();

			goto L3c40;

		L337d:
			this.oParent.Overlay_14.F14_0000_186f_CityStatus(this.oParent.CivState.HumanPlayerID);

			goto L3c40;

		L338c:
			this.oParent.Overlay_14.F14_0000_03ad_MilitaryStatus(this.oParent.CivState.HumanPlayerID);
			
			goto L3c40;

		L339b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L33a5;
			goto L33cf;

		L33a5:
			// Instruction address 0x1403:0x33a5, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			
			// Instruction address 0x1403:0x33ae, size: 5
			this.oParent.Segment_1000.F0_1000_0846(2);
			
			// Instruction address 0x1403:0x33b6, size: 5
			this.oParent.MSCAPI.getch();

			// Instruction address 0x1403:0x33bf, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);
			
			// Instruction address 0x1403:0x33c7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			goto L33db;

		L33cf:
			this.oParent.Overlay_14.F14_0000_0d43_IntelligenceReport();

		L33db:
			goto L3c40;

		L33de:
			this.oParent.Overlay_14.F14_0000_15f4_AttitudeSurvey(this.oParent.CivState.HumanPlayerID);

			goto L3c40;

		L33ed:
			this.oParent.Overlay_14.F14_0000_07f1_TradeReport(this.oParent.CivState.HumanPlayerID);
			
			goto L3c40;

		L33fc:
			this.oParent.Overlay_14.F14_0000_014b_ScienceReport(this.oParent.CivState.HumanPlayerID);

			goto L3c40;

		L340b:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L3415;
			goto L343a;

		L3415:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x1);
			goto L3420;

		L341d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));

		L3420:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x8);
			if (this.oCPU.Flags.L) goto L3429;
			goto L3437;

		L3429:
			this.oParent.Overlay_13.F13_0000_0000(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)));
			
			goto L341d;

		L3437:
			goto L343f;

		L343a:
			this.oParent.WorldMap.F12_0000_080d_ShowWondersOfTheWorldPopup();

		L343f:
			goto L3c40;

		L3442:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L344c;
			goto L3459;

		L344c:
			this.oParent.WorldMap.F12_0000_0573();

			this.oParent.GameReplay.F9_0000_0000();

			goto L345e;

		L3459:
			this.oParent.HallOfFame.F3_0000_09ac_ShowTopFiveCitiesPopup();

		L345e:
			goto L3c40;

		L3461:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L346b;
			goto L3473;

		L346b:
			this.oParent.WorldMap.F12_0000_03ac();

			goto L3c40;

		L3473:
			this.oParent.Overlay_20.F20_0000_0ca9_ShowCivilizationScorePopup(this.oParent.CivState.HumanPlayerID, true);

			goto L3c40;

		L348a:
			this.oParent.WorldMap.F12_0000_0000_ShowWorldMapPopup(1);

			goto L3c40;

		L349d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x1);
			goto L34dd;

		L34a5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x2);
			goto L34dd;

		L34ad:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x3);
			goto L34dd;

		L34b5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x4);
			goto L34dd;

		L34bd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x5);
			goto L34dd;

		L34c5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x6);
			goto L34dd;

		L34cd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x7);
			goto L34dd;

		L34d5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x8);

		L34dd:
			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))];

			this.oCPU.AX.Word = (ushort)((short)direction.X);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_d4cc_XPos += (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)direction.Y);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oParent.Var_d75e_YPos += (short)this.oCPU.AX.Word;

			// Instruction address 0x1403:0x3506, size: 5
			this.oParent.MapManagement.F0_2aea_0008(this.oParent.CivState.HumanPlayerID,
				this.oParent.Var_d4cc_XPos,
				this.oParent.Var_d75e_YPos);

			goto L3c40;

		L3511:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.E) goto L351b;
			goto L351e;

		L351b:
			goto L3ea1;

		L351e:
			goto L3c40;

		L3521:
			this.oParent.Overlay_23.F23_0000_025b_FindCityDialog();

			goto L3c40;

		L3529:
			if (this.oParent.CivState.TurnCount != 0) goto L3533;
			goto L353f;

		L3533:
			this.oParent.GameLoadAndSave.F11_0000_036a(0xffff);

		L353f:
			goto L3c40;

		L3542:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1403:0x354b, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x1f6a);

			// Instruction address 0x1403:0x355f, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 64, 80);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L356f;
			goto L3572;

		L356f:
			goto L3c40;

		L3572:
			this.oParent.CivState.Players[playerID].GovernmentType = 0;

			// Instruction address 0x1403:0x3585, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "The ");

			// Instruction address 0x1403:0x3595, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.Players[playerID].Nation);

			// Instruction address 0x1403:0x35a5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " are\nrevolting! Citizens\ndemand new govt.\n");

			this.oParent.Overlay_21.F21_0000_0000(-1);
			
			this.oParent.StartGameMenu.F5_0000_1af6();

			// Instruction address 0x1403:0x35be, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L3c40;

		L35c6:
			// Instruction address 0x1403:0x35c6, size: 5
			this.oParent.Segment_1000.F0_1000_163e_InitMouse();

			goto L3c40;

		L35ce:
			// Instruction address 0x1403:0x35d6, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Select new Tax rate:\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 0x0);
			goto L35e9;

		L35e6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))));

		L35e9:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[playerID].TaxRate;
			this.oCPU.AX.Word += (ushort)this.oParent.CivState.Players[playerID].ScienceTaxRate;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			if (this.oCPU.Flags.GE) goto L35fe;
			goto L3673;

		L35fe:
			// Instruction address 0x1403:0x361a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(10 * (short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))), 10));

			// Instruction address 0x1403:0x362a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% Tax, (");

			// Instruction address 0x1403:0x3658, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)((this.oParent.CivState.Players[playerID].TaxRate +
					this.oParent.CivState.Players[playerID].ScienceTaxRate -
					(short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))) * 10), 10));

			// Instruction address 0x1403:0x3668, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% Science)\n ");
			goto L35e6;

		L3673:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[playerID].TaxRate;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);

			// Instruction address 0x1403:0x368b, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L369f;
			goto L36b6;

		L369f:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[playerID].TaxRate;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oParent.CivState.Players[playerID].ScienceTaxRate += 
				(short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oParent.CivState.Players[playerID].TaxRate = (short)this.oCPU.AX.Word;

			// Instruction address 0x1403:0x36b1, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

		L36b6:
			goto L3c40;

		L36b9:
			// Instruction address 0x1403:0x36c1, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Select new Luxuries rate:\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 0x0);
			goto L36d4;

		L36d1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))));

		L36d4:
			this.oCPU.AX.Word = 10;
			this.oCPU.AX.Word -= (ushort)this.oParent.CivState.Players[playerID].TaxRate;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			if (this.oCPU.Flags.GE) goto L36ea;
			goto L375e;

		L36ea:
			// Instruction address 0x1403:0x3706, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(10 * (short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))), 10));

			// Instruction address 0x1403:0x3716, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% Luxuries, (");

			// Instruction address 0x1403:0x3743, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(-((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)) +
				this.oParent.CivState.Players[playerID].TaxRate - 10) * 10), 10));

			// Instruction address 0x1403:0x3753, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "% Science)\n ");
			goto L36d1;

		L375e:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[playerID].TaxRate;
			this.oCPU.AX.Word += (ushort)this.oParent.CivState.Players[playerID].ScienceTaxRate;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xa);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);

			// Instruction address 0x1403:0x377f, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L3793;
			goto L37a8;

		L3793:
			this.oCPU.AX.Word = (ushort)this.oParent.CivState.Players[playerID].TaxRate;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 10);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oParent.CivState.Players[playerID].ScienceTaxRate = (short)this.oCPU.AX.Word;

			// Instruction address 0x1403:0x37a3, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

		L37a8:
			goto L3c40;

		L37ab:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdcfc, 0x1);

			// Instruction address 0x1403:0x37bc, size: 5
			this.oParent.MapManagement.F0_2aea_0008(playerID,
				this.oParent.Var_d4cc_XPos,
				this.oParent.Var_d75e_YPos);

			// Instruction address 0x1403:0x37c4, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdcfc, 0x0);

			// Instruction address 0x1403:0x37da, size: 5
			this.oParent.MapManagement.F0_2aea_0008(playerID,
				this.oParent.Var_d4cc_XPos,
				this.oParent.Var_d75e_YPos);

			goto L3c40;

		L37e5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 0x0);
			goto L37f0;

		L37ed:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))));

		L37f0:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x10);
			if (this.oCPU.Flags.L) goto L37f9;
			goto L3837;

		L37f9:
			// Instruction address 0x1403:0x3805, size: 5
			this.oParent.CivState.Nations[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))].Mood =
				(short)(this.oParent.MSCAPI.RNG.Next(3) - 1); // -1 = Friendly, 0 = Neutral, 1 = Aggressive

			// Instruction address 0x1403:0x3816, size: 5
			this.oParent.CivState.Nations[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))].Policy = 
				(short)(this.oParent.MSCAPI.RNG.Next(3) - 1); // -1 = Perfectionist, 0 = Neutral, 1 = Expansionistic

			// Instruction address 0x1403:0x3827, size: 5
			this.oParent.CivState.Nations[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))].Ideology = 
				(short)(this.oParent.MSCAPI.RNG.Next(3) - 1); // -1 = Militaristic, 0 = Neutral, 1 = Civilized

			goto L37ed;

		L3837:
			// Instruction address 0x1403:0x3843, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0x2003, 100, 80);

			goto L3c40;

		L384e:
			this.oParent.CivState.GameSettingFlags.Sound ^= true;

			// Instruction address 0x1403:0x385c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Sounds ");

			if (this.oParent.CivState.GameSettingFlags.Sound)
			{
				// Instruction address 0x1403:0x387c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "ON\n");
			}
			else
			{
				// Instruction address 0x1403:0x387c, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "OFF\n");
			}
		
			// Instruction address 0x1403:0x3890, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			goto L3c40;

		L389b:
			this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x2029);
			
			this.oParent.Help.F4_0000_02d3_ShowInstantAdvicePopup(0x2030);
			
			goto L3c40;

		L38b6:
			// Instruction address 0x1403:0x38be, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Are you sure you\nwant to Quit?\n Keep Playing\n Yes, Quit\n");

			// Instruction address 0x1403:0x38d2, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L38e2;
			goto L38eb;

		L38e2:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x0);
			goto L3c40;

		L38eb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.E) goto L38f5;
			goto L38fb;

		L38f5:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x1);

		L38fb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0x80);
			goto L3c40;

		L3903:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L390d;
			goto L3952;

		L390d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L3916;
			goto L3952;

		L3916:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L393f;
			goto L394d;

		L393f:
			// Instruction address 0x1403:0x3945, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L394d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

		L3952:
			goto L3c40;

		L3955:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L395f;
			goto L3a38;

		L395f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L3968;
			goto L39a2;

		L3968:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L398c;
			goto L399a;

		L398c:
			// Instruction address 0x1403:0x3992, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L399a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);
			goto L3a33;

		L39a2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.NE) goto L39ac;
			goto L39ef;

		L39ac:
			// Instruction address 0x1403:0x39ca, size: 5
			F0_1403_4508(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L39da;
			goto L39ef;

		L39da:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe),
				(ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12),
				(ushort)((short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y));

			goto L3a01;

		L39ef:
			this.oCPU.AX.Word = (ushort)this.oParent.Var_d4cc_XPos;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)this.oParent.Var_d75e_YPos;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

		L3a01:
			this.oCPU.AX.Word = this.oParent.CivState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);

			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L3a25;
			goto L3a33;

		L3a25:
			// Instruction address 0x1403:0x3a2b, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L3a33:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.XOR_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x1));

		L3a38:
			goto L3c40;

		L3a3b:
			// Instruction address 0x1403:0x3a45, size: 5
			this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0);

			goto L3aa4;

		L3a50:
			// Instruction address 0x1403:0x3a5a, size: 5
			this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 1);

			goto L3aa4;

		L3a65:
			// Instruction address 0x1403:0x3a6f, size: 5
			this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 2);

			goto L3aa4;

		L3a7a:
			// Instruction address 0x1403:0x3a84, size: 5
			this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 3);

			goto L3aa4;

		L3a8f:
			// Instruction address 0x1403:0x3a99, size: 5
			this.oParent.Segment_2c84.F0_2c84_0000_ShowTopMenu(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 4);

			goto L3aa4;

		ToggleDebugMode:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd806, (ushort)(~this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L34dd;

		L3aa4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4ca), 0xffff);
			if (this.oCPU.Flags.NE) goto L3aae;
			goto L3ab7;

		L3aae:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4ca);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			goto L0d0a;

		L3ab7:
			goto L3c40;

		L3abd:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2300); // Alt + H
			if (this.oCPU.Flags.NE) goto L3ac5;
			goto L389b;

		L3ac5:
			if (this.oCPU.Flags.LE) goto L3aca;
			goto L3b7d;

		L3aca:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3d); // '='
			if (this.oCPU.Flags.NE) goto L3ad2;
			goto L35ce;

		L3ad2:
			if (this.oCPU.Flags.LE) goto L3ad7;
			goto L3b22;

		L3ad7:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1b); // ESC
			if (this.oCPU.Flags.NE) goto L3adf;
			goto L3903;

		L3adf:
			if (this.oCPU.Flags.LE) goto L3ae4;
			goto L3aff;

		L3ae4:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xfffe); // ??
			if (this.oCPU.Flags.NE) goto L3aec;
			goto L3542;

		L3aec:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x9); // Tab
			if (this.oCPU.Flags.NE) goto L3af4;
			goto L3955;

		L3af4:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xd); // Enter
			if (this.oCPU.Flags.NE) goto L3afc;
			goto L3511;

		L3afc:
			goto L3c40;

		L3aff:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x20); // Space
			if (this.oCPU.Flags.NE) goto L3b07;
			goto L3511;

		L3b07:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2b); // '+'
			if (this.oCPU.Flags.NE) goto L3b0f;
			goto L35ce;

		L3b0f:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2d); // '-'
			if (this.oCPU.Flags.NE) goto L3b17;
			goto L36b9;

		L3b17:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2f); // '/'
			if (this.oCPU.Flags.NE) goto L3b1f;
			goto L3521;

		L3b1f:
			goto L3c40;

		L3b22:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1000); // Alt + Q
			if (this.oCPU.Flags.NE) goto L3b2a;
			goto L38b6;

		L3b2a:
			if (this.oCPU.Flags.LE) goto L3b2f;
			goto L3b52;

		L3b2f:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3f); // '?'
			if (this.oCPU.Flags.NE) goto L3b37;
			goto L3521;

		L3b37:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x53); // 'S'
			if (this.oCPU.Flags.NE) goto L3b3f;
			goto L3529;

		L3b3f:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5f); // '_'
			if (this.oCPU.Flags.NE) goto L3b47;
			goto L36b9;

		L3b47:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x74); // 't'
			if (this.oCPU.Flags.NE) goto L3b4f;
			goto L37ab;

		L3b4f:
			goto L3c40;

		L3b52:
			if (this.oCPU.AX.Word == 0x2000) // Alt + D
				goto ToggleDebugMode;

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1100); // Alt + W
			if (this.oCPU.Flags.NE) goto L3b5a;
			goto L3a7a;

		L3b5a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1300); // Alt + R
			if (this.oCPU.Flags.NE) goto L3b62;
			goto L37e5;

		L3b62:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1800); // Alt + O
			if (this.oCPU.Flags.NE) goto L3b6a;
			goto L3a50;

		L3b6a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1e00); // Alt + A
			if (this.oCPU.Flags.NE) goto L3b72;
			goto L3a65;

		L3b72:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2200); // Alt + G
			if (this.oCPU.Flags.NE) goto L3b7a;
			goto L3a3b;

		L3b7a:
			goto L3c40;

		L3b7d:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4100); // F7
			if (this.oCPU.Flags.NE) goto L3b85;
			goto L340b;

		L3b85:
			if (this.oCPU.Flags.LE) goto L3b8a;
			goto L3bdd;

		L3b8a:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3b00); // F1
			if (this.oCPU.Flags.NE) goto L3b92;
			goto L336b;

		L3b92:
			if (this.oCPU.Flags.LE) goto L3b97;
			goto L3bb2;

		L3b97:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2e00); // Alt + C
			if (this.oCPU.Flags.NE) goto L3b9f;
			goto L3a8f;

		L3b9f:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2f00); // Alt + V
			if (this.oCPU.Flags.NE) goto L3ba7;
			goto L384e;

		L3ba7:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3200); // Alt + M
			if (this.oCPU.Flags.NE) goto L3baf;
			goto L35c6;

		L3baf:
			goto L3c40;

		L3bb2:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3c00); // F2
			if (this.oCPU.Flags.NE) goto L3bba;
			goto L338c;

		L3bba:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3d00); // F3
			if (this.oCPU.Flags.NE) goto L3bc2;
			goto L339b;

		L3bc2:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3e00); // F4
			if (this.oCPU.Flags.NE) goto L3bca;
			goto L33de;

		L3bca:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x3f00); // F5
			if (this.oCPU.Flags.NE) goto L3bd2;
			goto L33ed;

		L3bd2:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4000); // F6
			if (this.oCPU.Flags.NE) goto L3bda;
			goto L33fc;

		L3bda:
			goto L3c40;

		L3bdd:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4838); // Shift + Up
			if (this.oCPU.Flags.NE) goto L3be5;
			goto L349d;

		L3be5:
			if (this.oCPU.Flags.LE) goto L3bea;
			goto L3c0d;

		L3bea:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4200); // F8
			if (this.oCPU.Flags.NE) goto L3bf2;
			goto L3442;

		L3bf2:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4300); // F9
			if (this.oCPU.Flags.NE) goto L3bfa;
			goto L3461;

		L3bfa:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4400); // F10
			if (this.oCPU.Flags.NE) goto L3c02;
			goto L348a;

		L3c02:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4737); // Shift + Home
			if (this.oCPU.Flags.NE) goto L3c0a;
			goto L34d5;

		L3c0a:
			goto L3c40;

		L3c0d:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4939); // Shift + PageUp
			if (this.oCPU.Flags.NE) goto L3c15;
			goto L34a5;

		L3c15:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4b34); // Shift + Left
			if (this.oCPU.Flags.NE) goto L3c1d;
			goto L34cd;

		L3c1d:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4d36); // Shift + Right
			if (this.oCPU.Flags.NE) goto L3c25;
			goto L34ad;

		L3c25:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x4f31); // Shift + End
			if (this.oCPU.Flags.NE) goto L3c2d;
			goto L34c5;

		L3c2d:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5032); // Shift + Down
			if (this.oCPU.Flags.NE) goto L3c35;
			goto L34bd;

		L3c35:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5133); // Shift + PageDown
			if (this.oCPU.Flags.NE) goto L3c40;
			goto L34b5;

		L3c40:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L3c4a;
			goto L3c77;

		L3c4a:
			// !!! Illegal memory access, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)) == -1
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)) == -1 ||
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves <= 0)
				goto L3c77;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0x0);
			if (this.oCPU.Flags.E) goto L3c6d;
			goto L3c77;

		L3c6d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.NE) goto L3c77;
			goto L047f;

		L3c77:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x80);
			if (this.oCPU.Flags.L) goto L3c81;
			goto L3e2c;

		L3c81:
			// !!! Illegal memory access this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)) == -1
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)) == -1 ||
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID == -1)
				goto L0149;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].RemainingMoves <= 0)
				goto L3cc0;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			goto L3e2c;

		L3cc0:
			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TurnsOutside == 0)
				goto L3d71;

			// Instruction address 0x1403:0x3cf0, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y);

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L3cff;
			goto L3d19;

		L3cff:
			// Instruction address 0x1403:0x3d09, size: 5
			this.oParent.Segment_1866.F0_1866_1331(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 23);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L3d19;
			goto L3d39;

		L3d19:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves =
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID].TurnsOutside;

		L3d39:
			this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves--;

			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].SpecialMoves < 0)
			{
				// Instruction address 0x1403:0x3d5d, size: 5
				this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

				// Instruction address 0x1403:0x3d69, size: 5
				F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x2070);
			}

		L3d71:
			if (this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].TypeID != 16 ||
				playerID != this.oParent.CivState.HumanPlayerID)
				goto L3e2c;

			// Instruction address 0x1403:0x3d9a, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x0);
			if (this.oCPU.Flags.NE) goto L3daa;
			goto L3e2c;

		L3daa:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x1);
			goto L3dba;

		L3db7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));

		L3dba:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x8);
			if (this.oCPU.Flags.LE) goto L3dc3;
			goto L3e09;

		L3dc3:
			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))];

			// Instruction address 0x1403:0x3dee, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.X + direction.X,
				this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))].Position.Y + direction.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L3dfe;
			goto L3e06;

		L3dfe:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), 0x1);
			goto L3e09;

		L3e06:
			goto L3db7;

		L3e09:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)), 0x0);
			if (this.oCPU.Flags.E) goto L3e12;
			goto L3e2c;

		L3e12:
			// Instruction address 0x1403:0x3e18, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			
			// Instruction address 0x1403:0x3e24, size: 5
			F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x2076);

		L3e2c:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L3e3d;
			goto L3e4b;

		L3e3d:
			// Instruction address 0x1403:0x3e43, size: 5
			F0_1403_4060(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));

		L3e4b:
			goto L0149;

		L3e4e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x0);
			if (this.oCPU.Flags.E) goto L3e57;
			goto L3e61;

		L3e57:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.NE) goto L3e61;
			goto L013c;

		L3e61:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
			if (this.oCPU.Flags.E) goto L3e6b;
			goto L3ea1;

		L3e6b:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oParent.CivState.PlayerFlags);
			if (this.oCPU.Flags.NE) goto L3e7c;
			goto L3ea1;

		L3e7c:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L3e85;
			goto L3e8f;

		L3e85:
			if (this.oParent.CivState.GameSettingFlags.EndOfTurn) goto L3e8f;
			goto L3ea1;

		L3e8f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), 0x80);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			goto L043b;

		L3ea1:
			if (playerID != this.oParent.CivState.HumanPlayerID)
				goto L3ece;

			// Instruction address 0x1403:0x3eac, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1403:0x3ec1, size: 5
			this.oParent.Segment_1238.F0_1238_1bb2_FillRectangleWithShadow(0, 97, 80, 103);

			// Instruction address 0x1403:0x3ec9, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L3ece:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_000e");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_1403_3ed7(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1403_3ed7({xPos}, {yPos})");

			// function body
			if ((this.oParent.CivState.MapVisibility[xPos, yPos] & (1 << this.oParent.CivState.HumanPlayerID)) != 0 || 
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd806) != 0)
			{
				// Instruction address 0x1403:0x3f09, size: 5
				this.oParent.MapManagement.F0_2aea_11d4(xPos, yPos);
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_3ed7");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1403_3f13(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1403_3f13({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			if (playerID == this.oParent.CivState.HumanPlayerID) goto L3f41;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oParent.CivState.Players[playerID].Units[unitID].VisibleByPlayer;
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.CivState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L3f65;

		L3f41:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1403:0x3f5d, size: 5
			this.oParent.MapManagement.F0_2aea_11d4(
				this.oParent.CivState.Players[playerID].Units[unitID].Position.X,
				this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

		L3f65:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_3f13");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public ushort F0_1403_3f68(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1403_3f68({xPos}, {yPos})");

			// function body
			// Instruction address 0x1403:0x3f74, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(xPos, yPos);

			if ((this.oCPU.AX.Low & 0x7) != 0)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				// Instruction address 0x1403:0x3f8a, size: 5
				ushort usTemp = this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(xPos, yPos);

				if (this.oParent.CivState.TerrainModifications[usTemp].MiningEffect <= -3)
				{
					this.oCPU.AX.Word = 2;
				}
				else
				{
					if (this.oParent.CivState.TerrainModifications[usTemp].IrrigationEffect != -2)
					{
						this.oCPU.AX.Word = 0;
					}
					else
					{
						// Instruction address 0x1403:0x3fbf, size: 3
						if (F0_1403_3fd0(xPos, yPos) == 0)
						{
							this.oCPU.AX.Word = 0;
						}
						else
						{
							this.oCPU.AX.Word = 1;
						}
					}
				}
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_3f68");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_1403_3fd0(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1403_3fd0({xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xc);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x1403:0x3fdd, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(xPos, yPos);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xb);
			if (this.oCPU.Flags.NE) goto L3fef;

		L3fea:
			this.oCPU.AX.Word = 0x1;
			goto L405b;

		L3fef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			goto L4005;

		L3ffb:
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2);
			if (this.oCPU.Flags.NE) goto L3fea;

		L4001:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x2));

		L4005:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x8);
			if (this.oCPU.Flags.G) goto L4058;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))];

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), (short)(xPos + direction.X));
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), (short)(yPos + direction.Y));

			// Instruction address 0x1403:0x4028, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x4039, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x1);
			if (this.oCPU.Flags.NE) goto L4001;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xb);
			if (this.oCPU.Flags.E) goto L3fea;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xa);
			if (this.oCPU.Flags.NE) goto L3ffb;
			goto L3fea;

		L4058:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));

		L405b:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_3fd0");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1403_4060(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1403_4060({playerID}, {unitID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x12);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x1403:0x4068, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x1403:0x407c, size: 5
			this.oParent.Segment_1238.F0_1238_1bb2_FillRectangleWithShadow(0, 97, 80, 103);

			if (unitID != 128) goto L40ca;

			// Instruction address 0x1403:0x409a, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("End of Turn", 4, 124, 0);

			// Instruction address 0x1403:0x40b1, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Press Enter", 4, 136, 0);

			// Instruction address 0x1403:0x44f5, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("to continue", 4, 144, 0);

			goto L44fd;

		L40ca:
			if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID == -1)
				goto L44fd;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x63);

			// Instruction address 0x1403:0x40dc, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.Players[playerID].Nationality);

			// Instruction address 0x1403:0x40f3, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 4, 99, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1403:0x411d, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].Name);

			// Instruction address 0x1403:0x4133, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

			if ((this.oParent.CivState.Players[playerID].Units[unitID].Status & 0x20) == 0)
				goto L4160;

			// Instruction address 0x1403:0x4154, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("Veteran", 8, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

		L4160:
			// Instruction address 0x1403:0x4184, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.CivState.Players[playerID].Units[unitID].RemainingMoves / 3, 0, 99);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			// Instruction address 0x1403:0x4197, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Moves: ");

			// Instruction address 0x1403:0x41b7, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 10));

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc),
				(short)(this.oParent.CivState.Players[playerID].Units[unitID].RemainingMoves % 3));

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) != 0)
			{
				// Instruction address 0x1403:0x41d8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ".");

				// Instruction address 0x1403:0x41f8, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.MSCAPI.itoa(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 10));
			}

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TurnsOutside != 0)
			{
				// Instruction address 0x1403:0x4227, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "(");

				this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[unitID].TypeID));
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].MoveCount);
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.CivState.Players[playerID].Units[unitID].SpecialMoves);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe),
					this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word));

				// Instruction address 0x1403:0x425f, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oParent.MSCAPI.itoa(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 10));

				// Instruction address 0x1403:0x426f, size: 5
				this.oParent.MSCAPI.strcat(0xba06, ")");
			}

			// Instruction address 0x1403:0x4285, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);
			
			// Instruction address 0x1403:0x42ac, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oParent.CivState.Players[playerID].Units[unitID].HomeCityID);

			// Instruction address 0x1403:0x42c2, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

			// Instruction address 0x1403:0x42d6, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "(");

			// Instruction address 0x1403:0x42ea, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oParent.CivState.Players[playerID].Units[unitID].Position.X,
				this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

			// Instruction address 0x1403:0x42ff, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.CivState.Terrains[this.oCPU.AX.Word].Name);

			// Instruction address 0x1403:0x430f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			// Instruction address 0x1403:0x4325, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

			// Instruction address 0x1403:0x433d, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oParent.CivState.Players[playerID].Units[unitID].Position.X,
				this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x10);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x1403:0x4371, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("(RailRoad)", 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa),
					this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

			}
			else
			{
				this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8);
				if (this.oCPU.Flags.NE)
				{
					// Instruction address 0x1403:0x4371, size: 5
					this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("(Road)", 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa),
						this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));
				}
			}

			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x2);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x1403:0x43a6, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("(Irrigation)", 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa),
					this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

			}
			else
			{
				this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x4);
				if (this.oCPU.Flags.NE)
				{
					// Instruction address 0x1403:0x43a6, size: 5
					this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("(Mining)", 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa),
						this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));
				}
			}
		
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x40);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x1403:0x43c6, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("(Pollution)", 4, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
					this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x4));

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);
			
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				(short)this.oParent.CivState.Players[playerID].Units[unitID].NextUnitID);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x8);

			// Instruction address 0x1403:0x43ff, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oParent.CivState.Players[playerID].Units[unitID].Position.X,
				this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L440e;
			goto L44d2;

		L440e:
			// Instruction address 0x1403:0x441a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oParent.CivState.Players[playerID].Units[unitID].Position.X,
				this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// enumerate units on this square on status panel
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L442a:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));

			this.oCPU.AX.Low = (byte)this.oParent.CivState.Cities[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Unknown[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))];
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Low);
			
			if (this.oCPU.AX.Low != 0xff)
			{
				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
				this.oCPU.AX.Low = this.oCPU.AND_UInt8(this.oCPU.AX.Low, 0x3f);

				this.oParent.CivState.Players[playerID].Units[127].Status = 8;
				this.oParent.CivState.Players[playerID].Units[127].TypeID = (sbyte)this.oCPU.AX.Low;
				this.oParent.CivState.Players[playerID].Units[127].GoToPosition.X = -1;

				// Instruction address 0x1403:0x4468, size: 5
				this.oParent.MapManagement.F0_2aea_0fb3(playerID, 127,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

				this.oParent.CivState.Players[playerID].Units[127].TypeID = -1;

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
					this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 16));
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x2);
			if (this.oCPU.Flags.L) goto L442a;

			goto L44d2;

		L4484:
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L44d8;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xb8);
			if (this.oCPU.Flags.GE) goto L44d8;

			// Instruction address 0x1403:0x449f, size: 5
			this.oParent.MapManagement.F0_2aea_0fb3(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x10));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x40);
			if (this.oCPU.Flags.LE) goto L44ba;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x10));

		L44ba:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				(short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].NextUnitID);

		L44d2:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) != -1)
				goto L4484;

		L44d8:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) != -1 &&
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) != unitID)
			{
				// Instruction address 0x1403:0x44f5, size: 5
				this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0("+", 74, 192, 0);
			}

		L44fd:
			// Instruction address 0x1403:0x44fd, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_4060");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_1403_4508(int xPos, int yPos)
		{
			this.oParent.Log.EnterBlock($"F0_1403_4508({xPos}, {yPos})");

			// function body
			if (xPos < 16 && this.oParent.Var_d4cc_XPos >= 65)
			{
				xPos += 80;
			}

			if (xPos < this.oParent.Var_d4cc_XPos || xPos >= this.oParent.Var_d4cc_XPos + 15 ||
				yPos < this.oParent.Var_d75e_YPos || yPos >= this.oParent.Var_d75e_YPos + 12)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}

			this.oParent.Log.ExitBlock("F0_1403_4508");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1403_4545()
		{
			this.oCPU.Log.EnterBlock("F0_1403_4545()");

			// function body
			goto L454c;

		L4547:
			// Instruction address 0x1403:0x4547, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

		L454c:
			// Instruction address 0x1403:0x454c, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L4547;

		L4555:
			// Instruction address 0x1403:0x4555, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223_UpdateMouse();

			this.oCPU.CMP_UInt16(this.oParent.Var_db3a_MouseButton, 0x0);
			if (this.oCPU.Flags.NE) goto L4555;

			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_4545");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_1403_4562(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock("F0_1403_4562()");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xa);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				(short)this.oParent.CivState.Players[playerID].Units[unitID].NextUnitID);

			if (this.oParent.CivState.Players[playerID].Units[unitID].NextUnitID != -1)
				goto L458c;

			this.oCPU.AX.Word = (ushort)unitID;

			goto L4617;

		L458c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), unitID);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x3e7);

		L459c:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].TypeID].TerrainCategory == 2)
				goto L45eb;

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) <= unitID)
				goto L45cb;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)unitID);

			goto L45d4;

		L45cb:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)unitID);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x80);

		L45d4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L45eb;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L45eb:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				(short)this.oParent.CivState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].NextUnitID);
			
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) == unitID)
				goto L4614;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x10);
			if (this.oCPU.Flags.L) goto L459c;

		L4614:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

		L4617:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_4562");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Shows civilization note warning message if current player is human
		/// </summary>
		/// <param name="stringPtr"></param>
		public void F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(ushort stringPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1403_461c_ShowInstantWarningPopupToHumanPlayer(0x{stringPtr:x4})");

			// function body
			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6b90) == this.oParent.CivState.HumanPlayerID)
			{
				this.oParent.Help.F4_0000_03aa_ShowInstantWarningPopup(stringPtr);
			}
		
			// Far return
			this.oCPU.Log.ExitBlock("F0_1403_461c_ShowInstantWarningPopupToHumanPlayer");
		}
	}
}
