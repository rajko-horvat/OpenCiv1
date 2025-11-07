using System;
using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class UnitGoTo
	{
		private CivGame oParent;
		private VCPU oCPU;

		private short Var_6590_XPos = -1;
		private short Var_6592_YPos = -1;

		public UnitGoTo(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_2e31_000e_GetNextMove(short playerID, short unitID)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_000e({playerID}, {unitID})");
			CivGame.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oParent.CivState.HumanPlayerID);

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2a);

			GPoint move = this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition - this.oParent.CivState.Players[playerID].Units[unitID].Position;
			GPoint absMove = GPoint.Abs(move);

			if (playerID == this.oParent.CivState.HumanPlayerID && absMove.X < 2 && absMove.Y < 2)
			{
				move.X = (absMove.X >= 40) ? -Math.Sign(move.X) : Math.Sign(move.X);
				move.Y = Math.Sign(move.Y);

				this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition = new GPoint(-1);

				this.oCPU.AX.Word = 0;

				for (int i = 1; i < 9; i++)
				{
					if (this.oParent.MoveOffsets[i] == move)
					{
						this.oCPU.AX.Word = (ushort)i;
						break;
					}
				}
			}
			else
			{
				// !!! Illegal memory access
				if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory == UnitCategoryEnum.Air)
				{
					this.Var_6590_XPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X;
					this.Var_6592_YPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y;

					goto L0208;
				}

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

				if (absMove.Y > 6 || (absMove.X > 6 && absMove.X < 74))
				{
					this.Var_6590_XPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X;
					this.Var_6592_YPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y;

					// Instruction address 0x2e31:0x01bf, size: 3
					F0_2e31_0c1d(playerID, unitID, 0x3e7);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
					if (this.oCPU.Flags.NE)
					{
						this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));

						goto L05e0;
					}
				
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x1);
				}

				// Instruction address 0x2e31:0x01df, size: 3
				F0_2e31_05e6(playerID, unitID);

				this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE) goto L01ef;

				this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x0);
				if (this.oCPU.Flags.NE) goto L0208;

			L01ef:
				// Instruction address 0x2e31:0x01fa, size: 3
				F0_2e31_0c1d(playerID, unitID, 999);

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
				this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
				if (this.oCPU.Flags.NE)
				{
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));

					goto L05e0;
				}

			L0208:
				move.X = this.Var_6590_XPos - this.oParent.CivState.Players[playerID].Units[unitID].Position.X;
				move.Y = this.Var_6592_YPos - this.oParent.CivState.Players[playerID].Units[unitID].Position.Y;

				absMove = GPoint.Abs(move);

				if (absMove.X > absMove.Y)
				{
					// Instruction address 0x2e31:0x0271, size: 5
					this.oParent.MSCAPI.abs((short)move.X);
				}
				else
				{
					// Instruction address 0x2e31:0x0271, size: 5
					this.oParent.MSCAPI.abs((short)move.Y);
				}

				this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)((short)absMove.X));
				this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)((short)absMove.Y));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

				if (move.X == 0 && move.Y == 0)
				{
					this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X = -1;
					this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection = -1;
					this.oParent.CivState.Players[playerID].Units[unitID].RemainingMoves = 0;

					this.oCPU.AX.Word = 0xffff;
				}
				else
				{
					// Instruction address 0x2e31:0x02c8, size: 5
					this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
						this.oParent.CivState.Players[playerID].Units[unitID].Position.X, this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

					this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, 0x8);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

					// Instruction address 0x2e31:0x02e5, size: 5
					this.oParent.Segment_1866.F0_1866_1725(playerID,
						this.oParent.CivState.Players[playerID].Units[unitID].Position.X, this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x270f);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x1);

					goto L0324;

				L02f7:
					// Instruction address 0x2e31:0x02fa, size: 5
					this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

				L02fa:
					this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)((short)absMove.X));
					this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, (ushort)((short)absMove.Y));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

					if (playerID != this.oParent.CivState.HumanPlayerID)
						goto L03b1;

					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.G) goto L0321;
					goto L03b1;

				L0321:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

				L0324:
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x9);
					if (this.oCPU.Flags.L) goto L032d;
					goto L0571;

				L032d:
					GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))];

					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), (short)(this.oParent.CivState.Players[playerID].Units[unitID].Position.X + direction.X));
					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), (short)(this.oParent.CivState.Players[playerID].Units[unitID].Position.Y + direction.Y));
					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), (short)(move.X - direction.X));
					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), (short)(move.Y - direction.Y));

					// Instruction address 0x2e31:0x0371, size: 5
					this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

					absMove.Y = (short)this.oCPU.AX.Word;

					// Instruction address 0x2e31:0x037f, size: 5
					this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

					absMove.X = (short)this.oCPU.AX.Word;

					// Instruction address 0x2e31:0x038d, size: 5
					this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);

					// Instruction address 0x2e31:0x039b, size: 5
					this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
					if (this.oCPU.Flags.G) goto L03ab;
					goto L02f7;

				L03ab:
					// Instruction address 0x2e31:0x02fa, size: 5
					this.oParent.MSCAPI.abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
					goto L02fa;

				L03b1:
					// Instruction address 0x2e31:0x03b7, size: 5
					this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

					// Instruction address 0x2e31:0x03c8, size: 5
					this.oParent.MapManagement.F0_2aea_14e0_GetCellUnitPlayerID(
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
					if (this.oCPU.Flags.E)
						goto L03e0;

					this.oCPU.AX.Word = (ushort)playerID;
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.NE)
						goto L0455;

				L03e0:
					// !!! Illegal memory access
					if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID == -1 ||
						this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory != UnitCategoryEnum.Ocean)
					{
						this.oCPU.AX.Word = 0;
					}
					else
					{
						this.oCPU.AX.Word = 0x1;
					}

					if ((short)this.oCPU.AX.Word != (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)) != 0xa ? 0 : 1))
						goto L0436;

					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x0);
					if (this.oCPU.Flags.E)
						goto L0480;

					// Instruction address 0x2e31:0x042a, size: 5
					this.oParent.Segment_1866.F0_1866_1725(playerID,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

					this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
					if (this.oCPU.Flags.E) goto L0480;

				L0436:
					// !!! Illegal memory access
					if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID != -1 &&
						this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory == UnitCategoryEnum.Air)
						goto L0480;

				L0455:
					// Instruction address 0x2e31:0x045b, size: 5
					this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

					this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
					if (this.oCPU.Flags.NE) goto L046a;
					goto L0321;

				L046a:
					// Instruction address 0x2e31:0x0470, size: 5
					this.oParent.MapManagement.F0_2aea_1369_GetCityOwner(
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, (ushort)playerID);
					if (this.oCPU.Flags.E) goto L0480;
					goto L0321;

				L0480:
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0xa);
					if (this.oCPU.Flags.NE) goto L049c;

					// Instruction address 0x2e31:0x048c, size: 5
					this.oParent.MapManagement.F0_2aea_195d(
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x5);
					if (this.oCPU.Flags.GE) goto L049c;
					goto L0321;

				L049c:
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
					if (this.oCPU.Flags.E) goto L04b4;

					// Instruction address 0x2e31:0x04a8, size: 5
					this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

					this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x8);
					if (this.oCPU.Flags.NE) goto L04eb;

				L04b4:
					// !!! Illegal memory access
					if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID == -1 ||
						this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].MoveCount <= 1)
						goto L04e3;

					this.oCPU.AX.Low = 0x3;
					this.oCPU.IMUL_UInt8(this.oCPU.AX, 
						(byte)this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))].MovementCost);

					goto L04e6;

				L04e3:
					this.oCPU.AX.Word = 0x3;

				L04e6:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
					goto L04f0;

				L04eb:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);

				L04f0:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
						this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
							(ushort)((short)((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) * 4) +
								Math.Abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))) +
								Math.Abs(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)))))));

					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a),
						this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection);

					if (this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection != -1)
					{
						this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
							(short)Math.Abs(this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));

						if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) > 4)
						{
							this.oCPU.AX.Word = 0x8;
							this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
							this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
						}

						this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
						this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.AX.Word);
						this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
							this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word));
					}

					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.L) goto L0562;
					goto L0321;

				L0562:
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
					goto L0321;

				L0571:
					if (this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection != -1)
					{
						if ((this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection ^ 0x4) ==
							this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)))
						{
							this.oParent.CivState.Players[playerID].Units[unitID].RemainingMoves = 0;

							this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0);
						}
					}

					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x0);
					if (this.oCPU.Flags.E)
					{
						this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X = -1;
						this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection = -1;

						this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0xffff);

						this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
					}
					else
					{
						this.oParent.CivState.Players[playerID].Units[unitID].GoToNextDirection = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));

						this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
					}
				}
			}

		L05e0:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oParent.GoToLog.ExitBlock("F0_2e31_000e", this.oCPU.AX.Word);

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_2e31_05e6(short playerID, short unitID)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_05e6({playerID}, {unitID})");
			CivGame.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oParent.CivState.HumanPlayerID);

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x3a);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID == -1 ||
				this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X == -1)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[unitID].Position.X);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.oCPU.AX.Word);

				this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

				this.Var_6590_XPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X;
				this.Var_6592_YPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y;

				// !!! Illegal memory access
				// Instruction address 0x2e31:0x063a, size: 3
				F0_2e31_0a2c(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)),
					(ushort)((this.oParent.CivState.Players[playerID].Units[unitID].TypeID == -1 || this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory != UnitCategoryEnum.Ocean) ? 0 : 1));

				if (this.oCPU.AX.Word == 0)
				{
					this.Var_6590_XPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X;
					this.Var_6592_YPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y;
				}
				else
				{
					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.Var_6590_XPos);
					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.Var_6592_YPos);

					// Instruction address 0x2e31:0x06a7, size: 3
					F0_2e31_0a2c(
						this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X,
						this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y,
						(ushort)((this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory != UnitCategoryEnum.Ocean) ? 0 : 1));

					// Instruction address 0x2e31:0x06b8, size: 5
					this.oParent.MSCAPI.memset(0xd816, 0, 0x104);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

					// Illegal memory access, this.Var_6590_XPos == -1
					this.oCPU.WriteInt8(this.oCPU.DS.Word, 0x6594, (sbyte)this.Var_6590_XPos);

					this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

					this.oCPU.WriteInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6694), (sbyte)this.Var_6592_YPos);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
						this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

					this.oCPU.DI.Word = (ushort)((short)(13 * this.Var_6590_XPos));

					this.oCPU.BX.Word = (ushort)this.Var_6592_YPos;

					// !!! Illegal memory access, this.Var_6590_XPos = -1
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0xd816), 0x1);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

					if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory != UnitCategoryEnum.Ocean)
					{
						this.oCPU.AX.Word = 0;
					}
					else
					{
						this.oCPU.AX.Word = 0x1;
					}

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

				L070d:
					this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6594));
					this.oCPU.CBW(this.oCPU.AX);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6694));
					this.oCPU.CBW(this.oCPU.AX);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.NE) goto L0738;
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.NE) goto L0738;
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);
					goto L0815;

				L0738:
					// Illegal memory access, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) == -1
					this.oCPU.AX.Word = 0xd;
					this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
					this.oCPU.SI.Word = this.oCPU.AX.Word;

					this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));

					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xd816));
					this.oCPU.CBW(this.oCPU.AX);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
					this.oCPU.AX.High = 0;
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x0);
					if (this.oCPU.Flags.E) goto L076a;
					
					this.oCPU.AX.Word = 0xd;
					this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
					this.oCPU.SI.Word = this.oCPU.AX.Word;

					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x7f38));
					goto L0776;

				L076a:
					if ((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)) < this.oParent.CivState.LandPathfinding.Length)
					{
						this.oCPU.AX.Low =
							this.oParent.CivState.LandPathfinding[(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c))];
					}
					else
					{
						this.oCPU.AX.Low = 0;
					}

				L0776:
					this.oCPU.CBW(this.oCPU.AX);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x1);

				L077f:
					this.oCPU.AX.Word = 0x1;
					this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
					this.oCPU.CX.Low = this.oCPU.DEC_UInt8(this.oCPU.CX.Low);
					this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
					this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
					if (this.oCPU.Flags.E) goto L07f8;

					GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))];

					this.oCPU.AX.Word = (ushort)((short)direction.X);
					this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Word);

					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x14);
					if (this.oCPU.Flags.E)
					{
						this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), 0x0);
					}

					if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)) == -1)
					{
						this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), 0x13);
					}

					this.oCPU.AX.Word = (ushort)((short)direction.Y);
					this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

					this.oCPU.AX.Word = 0xd;
					this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
					this.oCPU.SI.Word = this.oCPU.AX.Word;
					this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
					this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, 0xd816);

					this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
					if (this.oCPU.Flags.NE) goto L07f8;
					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
					this.oCPU.AX.Low = this.oCPU.INC_UInt8(this.oCPU.AX.Low);
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.AX.Low);

					this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30));
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6594), this.oCPU.AX.Low);
					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6694), this.oCPU.AX.Low);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
					this.oCPU.AX.High = 0;
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

				L07f8:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x8);
					if (this.oCPU.Flags.G) goto L0804;
					goto L077f;

				L0804:
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
					if (this.oCPU.Flags.NE) goto L0815;
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.E) goto L0815;
					goto L070d;

				L0815:
					this.Var_6590_XPos = -1;

					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
					if (this.oCPU.Flags.NE) goto L0824;
					goto L09fc;

				L0824:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x63);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

					this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.CivState.Players[playerID].Units[unitID].TypeID));
					this.oCPU.BX.Word = this.oCPU.AX.Word;

					if (this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory != UnitCategoryEnum.Ocean)
						goto L085e;

					this.oCPU.AX.Word = 0xd;
					this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
					this.oCPU.SI.Word = this.oCPU.AX.Word;

					this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));

					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x7f38));
					goto L086d;

				L085e:
					this.oCPU.AX.Low = this.oParent.CivState.LandPathfinding[(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))];

				L086d:
					this.oCPU.CBW(this.oCPU.AX);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x1);
					goto L08d2;

				L0878:
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.NE) goto L08cf;

					// Instruction address 0x2e31:0x08b0, size: 5
					this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
						this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X,
						this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)) * 4 + 1,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) * 4 + 1);

					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.GE) goto L08cf;
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));

				L08cc:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

				L08cf:
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))));

				L08d2:
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x8);
					if (this.oCPU.Flags.LE) goto L08db;
					goto L0981;

				L08db:
					this.oCPU.AX.Word = 0x1;
					this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
					this.oCPU.CX.Low = this.oCPU.DEC_UInt8(this.oCPU.CX.Low);
					this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
					this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
					if (this.oCPU.Flags.E) goto L08cf;

					direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))];

					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), (short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) + direction.X));

					this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), (short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)) + direction.Y));

					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)), 0x14);
					if (this.oCPU.Flags.E)
					{
						this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), 0x0);
					}

					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)), 0xffff);
					if (this.oCPU.Flags.NE) goto L0919;
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), 0x13);

				L0919:
					this.oCPU.AX.Word = 0xd;
					this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
					this.oCPU.DI.Word = this.oCPU.AX.Word;

					this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));

					this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0xd816));
					this.oCPU.CBW(this.oCPU.AX);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
					this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
					if (this.oCPU.Flags.E) goto L08cf;
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
					if (this.oCPU.Flags.L) goto L093b;
					goto L0878;

				L093b:
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

					// Instruction address 0x2e31:0x0976, size: 5
					this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
						this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X,
						this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)) * 4 + 1,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) * 4 + 1);

					goto L08cc;

				L0981:
					this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
					if (this.oCPU.Flags.E) goto L09fc;

					direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))];

					// Instruction address 0x2e31:0x099d, size: 3
					this.Var_6590_XPos = (short)F0_2e31_119b_AdjustXPosition(((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) + direction.X) * 4) + 1);
					this.Var_6592_YPos = (short)(((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)) + direction.Y) * 4) + 1);

					// Instruction address 0x2e31:0x09ba, size: 5
					this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(this.Var_6590_XPos, this.Var_6592_YPos);

					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
					if (this.oCPU.Flags.NE) goto L09cc;
					this.oCPU.AX.Word = 0x1;
					goto L09ce;

				L09cc:
					this.oCPU.AX.Word = 0;

				L09ce:
					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
					if (this.oCPU.Flags.E) goto L09fc;

					this.Var_6590_XPos++;

					// Instruction address 0x2e31:0x09df, size: 5
					this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(this.Var_6590_XPos, this.Var_6592_YPos);

					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
					if (this.oCPU.Flags.NE) goto L09f1;
					this.oCPU.AX.Word = 0x1;
					goto L09f3;

				L09f1:
					this.oCPU.AX.Word = 0;

				L09f3:
					this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
					if (this.oCPU.Flags.E) goto L09fc;

					this.Var_6592_YPos++;

				L09fc:
					if (this.Var_6590_XPos == -1)
					{
						this.Var_6590_XPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X;
						this.Var_6592_YPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y;
					}

					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
				}
			}

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oParent.GoToLog.ExitBlock("F0_2e31_05e6", this.oCPU.AX.Word);

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F0_2e31_0a2c(int xPos, int yPos, ushort flag)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_0a2c({xPos}, {yPos}, {flag})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x14);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = (ushort)((short)xPos);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)yPos);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);

			if (flag != 0)
			{
				this.oCPU.AX.Word = 13;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));

				if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x7f38)) != 0)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
				}
			}
			else
			{
				this.oCPU.AX.Word = 13;
				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));

				if (this.oParent.CivState.LandPathfinding[(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))] != 0x0)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
				}
			}

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.E) goto L0a96;
			goto L0bf1;

		L0a96:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x63);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x1);
			goto L0ad8;

		L0aa2:
			this.oCPU.AX.Word = 0;

		L0aa4:
			if (this.oCPU.AX.Word != flag)
				goto L0b7f;

		L0aac:
			// Instruction address 0x2e31:0x0ac0, size: 3
			F0_2e31_111c(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				xPos, yPos, flag, 18);

			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0ad5;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

		L0ad5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

		L0ad8:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8);
			if (this.oCPU.Flags.LE) goto L0ae1;
			goto L0bf1;

		L0ae1:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))];

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), (short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) + direction.X));

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), (short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) + direction.Y));

			if (flag == 0) goto L0b12;
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x7f38)), 0x0);
			if (this.oCPU.Flags.NE) goto L0b2a;

		L0b12:
			if (flag != 0) goto L0ad5;

			this.oCPU.AX.Word = 13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));

			// !!! Illegal memory access
			int iTemp = ((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			if (iTemp < 0 || iTemp >= this.oParent.CivState.LandPathfinding.Length ||
				this.oParent.CivState.LandPathfinding[(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) * 13) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] == 0)
				goto L0ad5;

		L0b2a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word <<= 2;

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.DI.Word <<= 2;

			// Instruction address 0x2e31:0x0b43, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0208_GetShortestDistance(
				xPos - (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) * 4) - 1,
				yPos - (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) * 4) - 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0b59;
			goto L0ad5;

		L0b59:
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.SI.Word + 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			// LEA
			this.oCPU.AX.Word = (ushort)(this.oCPU.DI.Word + 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x2e31:0x0b69, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0b79;
			goto L0aa2;

		L0b79:
			this.oCPU.AX.Word = 0x1;
			goto L0aa4;

		L0b7f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x2e31:0x0b88, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0b9a;
			this.oCPU.AX.Word = 0x1;
			goto L0b9c;

		L0b9a:
			this.oCPU.AX.Word = 0;

		L0b9c:
			if (this.oCPU.AX.Word == flag)
				goto L0aac;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

			// Instruction address 0x2e31:0x0bad, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0bbf;
			this.oCPU.AX.Word = 0x1;
			goto L0bc1;

		L0bbf:
			this.oCPU.AX.Word = 0;

		L0bc1:
			if (this.oCPU.AX.Word == flag)
				goto L0aac;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2),
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			// Instruction address 0x2e31:0x0bd2, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0be4;
			this.oCPU.AX.Word = 0x1;
			goto L0be6;

		L0be4:
			this.oCPU.AX.Word = 0;

		L0be6:
			if (this.oCPU.AX.Word == flag) goto L0aac;
			goto L0ad5;

		L0bf1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.E) goto L0c15;
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))];

			this.Var_6590_XPos = (short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) + direction.X);
			this.Var_6592_YPos = (short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) + direction.Y);

			this.oCPU.AX.Word = 0x1;
			goto L0c17;

		L0c15:
			this.oCPU.AX.Word = 0;

		L0c17:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();

			// Far return
			this.oParent.GoToLog.ExitBlock("F0_2e31_0a2c", this.oCPU.AX.Word);

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F0_2e31_0c1d(short playerID, short unitID, ushort param3)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_0c1d({playerID}, {unitID}, {param3})");
			CivGame.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oParent.CivState.HumanPlayerID);

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x4a);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[unitID].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.CivState.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), (short)(this.Var_6590_XPos - 8));

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), (short)(this.Var_6592_YPos - 8));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6794, 0x0);
			
			if (this.Var_6590_XPos != this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6796) ||
				this.Var_6592_YPos != this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6798))
				goto L0c89;

			// !!! Doesn't work well should offset at 0xb780, but due to negative value accesses player.ActiveUnits
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));

			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oCPU.CMP_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb780)), 0x0);
			if (this.oCPU.Flags.NE)
				goto L0d8b;

		L0c89:
			this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x6796, this.Var_6590_XPos);
			this.oCPU.WriteInt16(this.oCPU.DS.Word, 0x6798, this.Var_6592_YPos);

			// Instruction address 0x2e31:0x0ca0, size: 5
			this.oParent.MSCAPI.memset(0xb780, 0, 0x100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

			this.oCPU.WriteInt8(this.oCPU.DS.Word, 0x6594, (sbyte)this.Var_6590_XPos);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.WriteInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6694), (sbyte)this.Var_6592_YPos);

			this.oCPU.DI.Word = (ushort)this.Var_6590_XPos;
			this.oCPU.DI.Word = this.oCPU.SUB_UInt16(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.SUB_UInt16(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));

			this.oCPU.BX.Word = (ushort)this.Var_6592_YPos;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0xb780), 0x1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6794, param3);

			if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID != -1 &&
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory != UnitCategoryEnum.Ocean)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 0x1;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);

			// !!! Illegal memory access
			if (this.oParent.CivState.Players[playerID].Units[unitID].TypeID != -1 && 
				this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].MoveCount == 1)
			{
				this.oCPU.AX.Word = 0x1;
			}
			else
			{
				this.oCPU.AX.Word = 0;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L0d21:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6594));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6694));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb780));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6794);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0d7c;

			// Instruction address 0x2e31:0x0d63, size: 3
			F0_2e31_119b_AdjustXPosition(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			if (this.oCPU.Flags.NE) goto L0da8;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0da8;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6794, this.oCPU.AX.Word);

		L0d7c:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0d8b;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xe1);
			if (this.oCPU.Flags.L) goto L0d21;

			L0d8b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0xffff);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6794);
			this.oCPU.CMP_UInt16(param3, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0d9b;
			goto L10ed;

		L0d9b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x63);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x1);
			goto L0f29;

		L0da8:
			// Instruction address 0x2e31:0x0daf, size: 3
			F0_2e31_119b_AdjustXPosition(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));

			// Instruction address 0x2e31:0x0db6, size: 5
			this.oParent.MapManagement.F0_2aea_1570(
				(short)this.oCPU.AX.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x1);
			goto L0dea;

		L0dc8:
			this.oCPU.AX.Word = 0;

		L0dca:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			if (this.oCPU.Flags.NE) goto L0dd2;
			goto L0e70;

		L0dd2:
			// Instruction address 0x2e31:0x0dd8, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0de7;
			goto L0e70;

		L0de7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));

		L0dea:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x8);
			if (this.oCPU.Flags.G) goto L0d7c;
			
			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))];

			this.oCPU.AX.Word = (ushort)((short)direction.X);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.Var_6590_XPos);

			// Instruction address 0x2e31:0x0e04, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.GE) goto L0de7;

			// Instruction address 0x2e31:0x0e15, size: 3
			F0_2e31_119b_AdjustXPosition(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)direction.Y);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.Var_6592_YPos);

			// Instruction address 0x2e31:0x0e32, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.GE) goto L0de7;

			// Instruction address 0x2e31:0x0e45, size: 5
			this.oParent.MapManagement.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0de7;

			// Instruction address 0x2e31:0x0e57, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0e6a;
			goto L0dc8;

		L0e6a:
			this.oCPU.AX.Word = 0x1;
			goto L0dca;

		L0e70:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L0e8e;

			// Instruction address 0x2e31:0x0e7c, size: 5
			this.oParent.MapManagement.F0_2aea_1570(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0e8e;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			goto L0ead;

		L0e8e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.E) goto L0e9c;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x3);
			goto L0ead;

		L0e9c:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = 0x3;
			this.oCPU.IMUL_UInt8(this.oCPU.AX, 
				(byte)this.oParent.CivState.Terrains[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e))].MovementCost);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

		L0ead:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb780));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0ed7;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0ed7;
			goto L0de7;

		L0ed7:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb780), this.oCPU.AX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6594), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x6694), this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			goto L0de7;

		L0f0d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x50));

		L0f11:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.Var_6590_XPos);

			// Instruction address 0x2e31:0x0f19, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L0f61;

			L0f26:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))));

		L0f29:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x8);
			if (this.oCPU.Flags.LE) goto L0f32;
			goto L10e2;

		L0f32:
			direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c))];

			this.oCPU.AX.Word = (ushort)((short)direction.X);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.Var_6590_XPos);

			// Instruction address 0x2e31:0x0f46, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x48);
			if (this.oCPU.Flags.L) goto L0f11;

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)) <= this.Var_6590_XPos)
				goto L0f0d;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x50));
			goto L0f11;

		L0f61:
			// Instruction address 0x2e31:0x0f65, size: 3
			F0_2e31_119b_AdjustXPosition(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)direction.Y);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, (ushort)this.Var_6592_YPos);

			// Instruction address 0x2e31:0x0f82, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.GE) goto L0f26;

			// Instruction address 0x2e31:0x0f95, size: 5
			this.oParent.MapManagement.F0_2aea_134a_GetTerrainType(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			if (((this.oParent.CivState.UnitDefinitions[this.oParent.CivState.Players[playerID].Units[unitID].TypeID].TerrainCategory != UnitCategoryEnum.Ocean) ? 0 : 1) == ((this.oCPU.AX.Word != 0xa) ? 0 : 1))
				goto L0fec;

			// Instruction address 0x2e31:0x0fdd, size: 5
			this.oParent.MapManagement.F0_2aea_1585_GetTerrainImprovements(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.TEST_UInt8(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0fec;
			goto L0f26;

		L0fec:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ADD_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));
			this.oCPU.BX.Word = this.oCPU.SUB_UInt16(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb780));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L100b;
			goto L0f26;

		L100b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L106e;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

			// Instruction address 0x2e31:0x1025, size: 5
			this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1050;

			// Instruction address 0x2e31:0x103f, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 2);

			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			goto L1055;

		L1050:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L1055:
			// Instruction address 0x2e31:0x1063, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.Var_6590_XPos,
				this.Var_6592_YPos,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word));

		L106e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1079;
			goto L0f26;

		L1079:
			// Instruction address 0x2e31:0x107f, size: 5
			this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L10aa;

			// Instruction address 0x2e31:0x1099, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 2);

			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			goto L10af;

		L10aa:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 0x0);

		L10af:
			// Instruction address 0x2e31:0x10bd, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.Var_6590_XPos,
				this.Var_6592_YPos,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L10d3;
			goto L0f26;

		L10d3:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			goto L0f26;

		L10e2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0xffff);
			if (this.oCPU.Flags.E) goto L10ed;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			goto L1116;

		L10ed:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1113;

			this.Var_6590_XPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.X;
			this.Var_6592_YPos = (short)this.oParent.CivState.Players[playerID].Units[unitID].GoToPosition.Y;

		L1113:
			this.oCPU.AX.Word = 0xffff;

		L1116:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oParent.GoToLog.ExitBlock("F0_2e31_0c1d", this.oCPU.AX.Word);

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <param name="flag"></param>
		/// <param name="param6"></param>
		/// <returns></returns>
		public ushort F0_2e31_111c(int xPos, int yPos, int xPos1, int yPos1, ushort flag, ushort param6)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_111c({xPos}, {yPos}, {xPos1}, {yPos1}, {flag}, {param6})");

			// function body
			if (Math.Abs(xPos - xPos1) <= 7 && Math.Abs(yPos - yPos1) <= 7)
			{
				// Temporary unit...
				this.oParent.CivState.Players[0].Units[127].TypeID = (short)((flag == 0) ? 1 : 0x10);
				this.oParent.CivState.Players[0].Units[127].Position.X = xPos;
				this.oParent.CivState.Players[0].Units[127].Position.Y = yPos;
				this.oParent.CivState.Players[0].Units[127].GoToPosition.X = xPos1;
				this.oParent.CivState.Players[0].Units[127].GoToPosition.Y = yPos1;

				this.Var_6590_XPos = (short)xPos1;
				this.Var_6592_YPos = (short)yPos1;

				// Instruction address 0x2e31:0x117c, size: 3
				F0_2e31_0c1d(0, 127, param6);

				this.oParent.CivState.Players[0].Units[127].TypeID = -1;
				this.oParent.CivState.Players[0].Units[127].Position.X = -1;
				this.oParent.CivState.Players[0].Units[127].Position.Y = -1;
				this.oParent.CivState.Players[0].Units[127].GoToPosition.X = -1;
				this.oParent.CivState.Players[0].Units[127].GoToPosition.Y = -1;

				if (this.oCPU.AX.Word == 0xffff)
				{
					this.oCPU.AX.Word = 0xffff;
				}
				else
				{
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6794);
				}
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}

			// Far return
			this.oParent.GoToLog.ExitBlock("F0_2e31_111c", this.oCPU.AX.Word);

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// Wrap X position
		/// </summary>
		/// <param name="xPos"></param>
		/// <returns></returns>
		public int F0_2e31_119b_AdjustXPosition(int xPos)
		{
			// function body
			while (xPos < 0)
			{
				xPos += 80;
			}

			while (xPos >= 80)
			{
				xPos -= 80;
			}

			this.oCPU.AX.Word = (ushort)((short)xPos);

			return xPos;
		}
	}
}
