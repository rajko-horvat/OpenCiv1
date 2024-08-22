using System;
using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class UnitGoTo
	{
		private CivGame oParent;
		private VCPU oCPU;
		private CivStateData oGameData;
		private CivStaticData oStaticGameData;

		private int Var_6590_XPos = 0;
		private int Var_6592_YPos = 0;
		private int[] Var_6594 = new int[256];
		private int[] Var_6694 = new int[256];
		private int Var_6794 = 0;
		private int Var_6796 = 0;
		private int Var_6798 = 0;
		public int[,] Var_7f38_AuxPathFind = new int[20, 13];
		private int[,] Var_b780 = new int[16, 16];
		private int[,] Var_d816 = new int[20, 13];

		public UnitGoTo(CivGame parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
			this.oStaticGameData = parent.StaticGameData;

			for (int i = 0; i < this.Var_6594.Length; i++)
			{
				this.Var_6594[i] = 0;
			}

			for (int i = 0; i < this.Var_6694.Length; i++)
			{
				this.Var_6694[i] = 0;
			}

			for (int i = 0; i < this.Var_7f38_AuxPathFind.GetLength(0); i++)
			{
				for (int j = 0; j < this.Var_7f38_AuxPathFind.GetLength(1); j++)
				{
					this.Var_7f38_AuxPathFind[i, j] = 0;
				}
			}

			for (int i = 0; i < this.Var_b780.GetLength(0); i++)
			{
				for (int j = 0; j < this.Var_b780.GetLength(1); j++)
				{
					this.Var_b780[i, j] = 0;
				}
			}

			for (int i = 0; i < this.Var_d816.GetLength(0); i++)
			{
				for (int j = 0; j < this.Var_d816.GetLength(1); j++)
				{
					this.Var_d816[i, j] = 0;
				}
			}
		}

		/// <summary>
		/// Calculates next move for a given unit (which has GoTo command selected)
		/// The calculation is different based on a unit MovementType (Land, Sea, Air)
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns>Index into MoveOffsets array, or -1 if there is no more moves available</returns>
		public ushort F0_2e31_000e_GetNextGoToMove(short playerID, short unitID)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_000e({playerID}, {unitID})");
			CivGame.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oGameData.HumanPlayerID);

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_a;
			int local_c;
			int local_e;
			int local_10;
			int local_12;
			int local_14;
			int local_16;
			int local_18 = 0;
			int local_1a;
			int local_1c;
			int local_22;
			int local_24;
			int local_2a;

			GPoint move = this.oGameData.Players[playerID].Units[unitID].GoToPosition - this.oGameData.Players[playerID].Units[unitID].Position;
			GPoint absMove = GPoint.Abs(move);

			if (playerID == this.oGameData.HumanPlayerID && absMove.X < 2 && absMove.Y < 2)
			{
				move.X = (absMove.X >= 40) ? -Math.Sign(move.X) : Math.Sign(move.X);
				move.Y = Math.Sign(move.Y);

				this.oGameData.Players[playerID].Units[unitID].GoToPosition = new GPoint(-1);

				this.oCPU.AX.Word = 0;

				for (int i = 1; i < 9; i++)
				{
					if (this.oStaticGameData.MoveOffsets[i] == move)
					{
						this.oCPU.AX.Word = (ushort)i;
						break;
					}
				}
			}
			else
			{
				// !!! Illegal memory access
				if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Sea)
				{
					this.Var_6590_XPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.X;
					this.Var_6592_YPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y;
				}
				else
				{
					local_e = 0;

					if (absMove.Y > 6 || (absMove.X > 6 && absMove.X < 74))
					{
						this.Var_6590_XPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.X;
						this.Var_6592_YPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y;

						// Instruction address 0x2e31:0x01bf, size: 3
						local_14 = F0_2e31_0c1d(playerID, unitID, 999);

						if (local_14 != -1)
						{
							this.oCPU.AX.Word = (ushort)((short)local_14);

							goto L05e0;
						}

						local_e = 1;
					}

					// Instruction address 0x2e31:0x01df, size: 3
					if (F0_2e31_05e6(playerID, unitID) != 0 || local_e == 0)
					{
						// Instruction address 0x2e31:0x01fa, size: 3
						local_14 = F0_2e31_0c1d(playerID, unitID, 999);

						if (local_14 != -1)
						{
							this.oCPU.AX.Word = (ushort)((short)local_14);

							goto L05e0;
						}
					}
				}

				move.X = this.Var_6590_XPos - this.oGameData.Players[playerID].Units[unitID].Position.X;
				move.Y = this.Var_6592_YPos - this.oGameData.Players[playerID].Units[unitID].Position.Y;

				absMove = GPoint.Abs(move);

				if (absMove.X > absMove.Y)
				{
					// Instruction address 0x2e31:0x0271, size: 5
					local_a = Math.Abs(move.X) + absMove.X + absMove.Y;
				}
				else
				{
					// Instruction address 0x2e31:0x0271, size: 5
					local_a = Math.Abs(move.Y) + absMove.X + absMove.Y;
				}

				if (move.X == 0 && move.Y == 0)
				{
					this.oGameData.Players[playerID].Units[unitID].GoToPosition.X = -1;
					this.oGameData.Players[playerID].Units[unitID].GoToNextDirection = -1;
					this.oGameData.Players[playerID].Units[unitID].RemainingMoves = 0;

					this.oCPU.AX.Word = 0xffff;
				}
				else
				{
					// Instruction address 0x2e31:0x02c8, size: 5
					local_c = (short)this.oParent.Segment_2aea.F0_2aea_1585_GetImprovements(
						this.oGameData.Players[playerID].Units[unitID].Position.X, this.oGameData.Players[playerID].Units[unitID].Position.Y) + 8;

					// Instruction address 0x2e31:0x02e5, size: 5
					local_1c = (short)this.oParent.Segment_1866.F0_1866_1725(playerID,
						this.oGameData.Players[playerID].Units[unitID].Position.X, this.oGameData.Players[playerID].Units[unitID].Position.Y);

					local_24 = 9999;
					local_14 = 0;

					for (int i = 1; i < 9; i++)
					{
						GPoint direction = this.oStaticGameData.MoveOffsets[i];

						local_10 = this.oGameData.Players[playerID].Units[unitID].Position.X + direction.X;
						local_12 = this.oGameData.Players[playerID].Units[unitID].Position.Y + direction.Y;
						local_2 = move.X - direction.X;
						local_4 = move.Y - direction.Y;

						// Instruction address 0x2e31:0x037f, size: 5
						absMove.X = Math.Abs(local_2);

						// Instruction address 0x2e31:0x0371, size: 5
						absMove.Y = Math.Abs(local_4);

						// Instruction address 0x2e31:0x038d, size: 5
						local_2a = Math.Abs(local_4);

						// Instruction address 0x2e31:0x039b, size: 5
						if (Math.Abs(local_2) <= local_2a)
						{
							// Instruction address 0x2e31:0x02fa, size: 5
							local_16 = Math.Abs(local_4) + absMove.X + absMove.Y;
						}
						else
						{
							// Instruction address 0x2e31:0x02fa, size: 5
							local_16 = Math.Abs(local_2) + absMove.X + absMove.Y;
						}

						if (playerID != this.oGameData.HumanPlayerID || local_16 <= local_a)
						{
							// Instruction address 0x2e31:0x03b7, size: 5
							local_1a = (short)this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(local_10, local_12);

							// Instruction address 0x2e31:0x03c8, size: 5
							local_22 = (short)this.oParent.Segment_2aea.F0_2aea_14e0(local_10, local_12);

							// Instruction address 0x2e31:0x042a, size: 5
							// Instruction address 0x2e31:0x045b, size: 5
							// Instruction address 0x2e31:0x0470, size: 5
							if (((local_22 == -1 || local_22 == playerID) &&
								((((this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air) ? 0 : 1) == (local_1a != 10 ? 0 : 1) &&
								(local_1c == 0 || (short)this.oParent.Segment_1866.F0_1866_1725(playerID, local_10, local_12) == 0)) ||
								(this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Sea))) ||
								((this.oParent.Segment_2aea.F0_2aea_1585_GetImprovements(local_10, local_12) & 0x1) != 0 &&
								(short)this.oParent.Segment_2aea.F0_2aea_1369(local_10, local_12) == playerID))
							{
								// Instruction address 0x2e31:0x048c, size: 5
								if (local_1a != 10 || this.oParent.Segment_2aea.F0_2aea_195d_GetGroupSize(local_10, local_12) >= 5)
								{
									// Instruction address 0x2e31:0x04a8, size: 5
									if (local_c == 0 || (this.oParent.Segment_2aea.F0_2aea_1585_GetImprovements(local_10, local_12) & 0x8) == 0)
									{
										// !!! Illegal memory access
										if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MoveCount > 1)
										{
											local_8 = this.oStaticGameData.Terrains[local_1a].MovementCost * 3;
										}
										else
										{
											local_8 = 3;
										}
									}
									else
									{
										local_8 = 1;
									}

									local_8 += (local_16 * 4) + Math.Abs(local_2) + Math.Abs(local_4);

									local_2a = this.oGameData.Players[playerID].Units[unitID].GoToNextDirection;

									if (this.oGameData.Players[playerID].Units[unitID].GoToNextDirection != -1)
									{
										local_6 = Math.Abs(this.oGameData.Players[playerID].Units[unitID].GoToNextDirection - local_18);

										if (local_6 > 4)
										{
											local_6 = 8 - local_6;
										}

										local_8 += local_6 * local_6;
									}

									if (local_8 < local_24)
									{
										local_14 = local_18;
										local_24 = local_8;
									}
								}
							}
						}
					}

					if (this.oGameData.Players[playerID].Units[unitID].GoToNextDirection != -1)
					{
						if ((this.oGameData.Players[playerID].Units[unitID].GoToNextDirection ^ 0x4) == local_14)
						{
							this.oGameData.Players[playerID].Units[unitID].RemainingMoves = 0;

							local_14 = 0;
						}
					}

					if (local_14 == 0)
					{
						this.oGameData.Players[playerID].Units[unitID].GoToPosition.X = -1;
						this.oGameData.Players[playerID].Units[unitID].GoToNextDirection = -1;

						local_14 = -1;
					}
					else
					{
						this.oGameData.Players[playerID].Units[unitID].GoToNextDirection = (short)local_14;
					}

					this.oCPU.AX.Word = (ushort)((short)local_14);
				}
			}

		L05e0:
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
		private ushort F0_2e31_05e6(short playerID, short unitID)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_05e6({playerID}, {unitID})");
			CivGame.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oGameData.HumanPlayerID);

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_a = 0;
			int local_c;
			int local_e;
			int local_10;
			int local_12;
			int local_14;
			int local_16;
			int local_2c;
			int local_2e;
			int local_30;
			int local_34;
			int local_36;
			int local_3a;

			local_36 = this.oGameData.Players[playerID].Units[unitID].Position.X;
			local_3a = this.oGameData.Players[playerID].Units[unitID].Position.Y;

			this.Var_6590_XPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.X;
			this.Var_6592_YPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y;

			// !!! Illegal memory access
			// Instruction address 0x2e31:0x063a, size: 3
			F0_2e31_0a2c(local_36, local_3a,
				((this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air) ? 0 : 1));

			if (this.oCPU.AX.Word == 0)
			{
				this.Var_6590_XPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.X;
				this.Var_6592_YPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y;
			}
			else
			{
				local_36 = this.Var_6590_XPos;
				local_3a = this.Var_6592_YPos;

				// Instruction address 0x2e31:0x06a7, size: 3
				F0_2e31_0a2c(
					this.oGameData.Players[playerID].Units[unitID].GoToPosition.X,
					this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y,
					((this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air) ? 0 : 1));

				// Instruction address 0x2e31:0x06b8, size: 5
				for (int i = 0; i < this.Var_d816.GetLength(0); i++)
				{
					for (int j = 0; j < this.Var_d816.GetLength(1); j++)
					{
						this.Var_d816[i, j] = 0;
					}
				}

				local_2 = 0;
				local_4 = 0;

				this.Var_6594[0] = this.Var_6590_XPos;
				this.Var_6694[local_2] = this.Var_6592_YPos;

				local_2++;

				this.Var_d816[this.Var_6590_XPos, this.Var_6592_YPos] = 1;

				local_c = 0;

				if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
				{
					local_16 = 0;
				}
				else
				{
					local_16 = 1;
				}

			L070d:
				local_14 = this.Var_6594[local_4];
				local_2c = this.Var_6694[local_4];

				if (local_14 != local_36 || local_2c != local_3a) goto L0738;

				local_c = 1;
				goto L0815;

			L0738:
				// Illegal memory access, local_14 == -1
				local_a = this.Var_d816[local_14, local_2c];
				
				local_4++;
				local_4 %= 256;

				if (local_16 != 0)
				{
					local_10 = this.Var_7f38_AuxPathFind[local_14, local_2c];
				}
				else
				{
					local_10 = this.oGameData.PathFind[local_14, local_2c];
				}

				local_2e = 1;

			L077f:
				if ((local_10 & (1 << (local_2e - 1))) == 0) goto L07f8;

				GPoint direction = this.oStaticGameData.MoveOffsets[local_2e];

				local_30 = direction.X + local_14;

				if (local_30 == 20)
				{
					local_30 = 0;
				}

				if (local_30 == -1)
				{
					local_30 = 19;
				}

				local_34 = direction.Y + local_2c;

				if (this.Var_d816[local_30, local_34] != 0) goto L07f8;
				
				this.Var_d816[local_30, local_34] = local_a + 1;
				this.Var_6594[local_2] = local_30;
				this.Var_6694[local_2] = local_34;

				local_2++;
				local_2 %= 256;

			L07f8:
				local_2e++;

				if (local_2e > 8) goto L0804;
				goto L077f;

			L0804:
				if (local_c != 0) goto L0815;
				if (local_4 == local_2) goto L0815;

				goto L070d;

			L0815:
				this.Var_6590_XPos = -1;

				if (local_c != 0) goto L0824;

				goto L09fc;

			L0824:
				local_8 = 99;
				local_e = -1;

				if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType == UnitMovementTypeEnum.Air)
				{
					local_10 = this.Var_7f38_AuxPathFind[local_36, local_3a];
				}
				else
				{
					local_10 = this.oGameData.PathFind[local_36, local_3a];
				}

				local_2e = 1;

				goto L08d2;

			L0878:
				if (local_6 != local_8) goto L08cf;

				// Instruction address 0x2e31:0x08b0, size: 5
				local_12 = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
					this.oGameData.Players[playerID].Units[unitID].GoToPosition.X,
					this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y,
					local_30 * 4 + 1, local_34 * 4 + 1);

				if (local_12 >= local_a) goto L08cf;
				
				local_e = local_2e;
				local_a = local_12;

			L08cf:
				local_2e++;

			L08d2:
				if (local_2e <= 8) goto L08db;

				goto L0981;

			L08db:
				if ((local_10 & (1 << (local_2e - 1))) == 0) goto L08cf;

				direction = this.oStaticGameData.MoveOffsets[local_2e];

				local_30 = local_36 + direction.X;
				local_34 = local_3a + direction.Y;

				if (local_30 == 20)
				{
					local_30 = 0;
				}

				if (local_30 == -1)
				{
					local_30 = 19;
				}
			
				local_6 = this.Var_d816[local_30, local_34];

				if (local_6==0) goto L08cf;

				if (local_6 < local_8) goto L093b;

				goto L0878;

			L093b:
				local_8 = local_6;
				local_e = local_2e;

				// Instruction address 0x2e31:0x0976, size: 5
				local_a = this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
					this.oGameData.Players[playerID].Units[unitID].GoToPosition.X,
					this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y,
					local_30 * 4 + 1, local_34 * 4 + 1);

				goto L08cf;

			L0981:
				if (local_e == -1) goto L09fc;

				direction = this.oStaticGameData.MoveOffsets[local_e];

				// Instruction address 0x2e31:0x099d, size: 3
				this.Var_6590_XPos = F0_2e31_119b_AdjustXPosition(((local_36 + direction.X) * 4) + 1);
				this.Var_6592_YPos = ((local_3a + direction.Y) * 4) + 1;

				// Instruction address 0x2e31:0x09ba, size: 5
				if (this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(this.Var_6590_XPos, this.Var_6592_YPos) == TerrainTypeEnum.Water)
				{
					this.oCPU.AX.Word = 0x1;
				}
				else
				{
					this.oCPU.AX.Word = 0;
				}

				if (this.oCPU.AX.Word == local_16) goto L09fc;

				this.Var_6590_XPos++;

				// Instruction address 0x2e31:0x09df, size: 5
				if (this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(this.Var_6590_XPos, this.Var_6592_YPos) == TerrainTypeEnum.Water)
				{
					this.oCPU.AX.Word = 0x1;
				}
				else
				{
					this.oCPU.AX.Word = 0;
				}

				if (this.oCPU.AX.Word == local_16) goto L09fc;

				this.Var_6592_YPos++;

			L09fc:
				if (this.Var_6590_XPos == -1)
				{
					this.Var_6590_XPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.X;
					this.Var_6592_YPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y;
				}

				this.oCPU.AX.Word = (ushort)((short)local_c);
			}

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
		private ushort F0_2e31_0a2c(int xPos, int yPos, int flag)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_0a2c({xPos}, {yPos}, {flag})");

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_a;
			int local_c;
			int local_e;
			int local_12;
			int local_14;

			local_12 = xPos / 4; // 80 / 4 = 20
			local_14 = yPos / 4; // 50 / 4 = 12.5
			local_e = -1;

			if (flag != 0)
			{
				if (this.Var_7f38_AuxPathFind[local_12, local_14] != 0)
				{
					local_e = 0;
				}
			}
			else
			{
				if (this.oGameData.PathFind[local_12, local_14] != 0)
				{
					local_e = 0;
				}
			}

			if (local_e == -1)
			{
				local_6 = 99;

				for (int i = 1; i < 9; i++)
				{
					GPoint direction = this.oStaticGameData.MoveOffsets[i];

					local_a = local_12 + direction.X;
					local_c = local_14 + direction.Y;

					if ((flag != 0 && this.Var_7f38_AuxPathFind[local_a, local_c] != 0) || (flag == 0 && this.oGameData.PathFind[local_a, local_c] != 0))
					{
						// Instruction address 0x2e31:0x0b43, size: 5
						local_4 = this.oParent.Segment_2dc4.F0_2dc4_0208_GetShortestDistance(xPos - (local_a * 4) - 1, yPos - (local_c * 4) - 1);

						if (local_4 < local_6)
						{
							local_2 = local_a * 4 + 1;
							local_8 = local_c * 4 + 1;

							if ((flag == ((this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(local_2, local_8) == TerrainTypeEnum.Water) ? 1 : 0) && F0_2e31_111c_CreateBarbarianUnit(local_2, local_8, xPos, yPos, flag, 18) != -1) ||
								(flag == ((this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(local_2 + 1, local_8) == TerrainTypeEnum.Water) ? 1 : 0) && F0_2e31_111c_CreateBarbarianUnit(local_2 + 1, local_8, xPos, yPos, flag, 18) != -1) ||
								(flag == ((this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(local_2 + 1, local_8 + 1) == TerrainTypeEnum.Water) ? 1 : 0) && F0_2e31_111c_CreateBarbarianUnit(local_2 + 1, local_8 + 1, xPos, yPos, flag, 18) != -1) ||
								(flag == ((this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(local_2, local_8 + 1) == TerrainTypeEnum.Water) ? 1 : 0) && F0_2e31_111c_CreateBarbarianUnit(local_2, local_8 + 1, xPos, yPos, flag, 18) != -1))
							{
								local_6 = local_4;
								local_e = i;
							}
						}
					}
				}
			}

			if (local_e != -1)
			{
				GPoint direction = this.oStaticGameData.MoveOffsets[local_e];

				this.Var_6590_XPos = local_12 + direction.X;
				this.Var_6592_YPos = local_14 + direction.Y;

				this.oCPU.AX.Word = 0x1;
			}
			else
			{
				this.oCPU.AX.Word = 0;
			}

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
		private int F0_2e31_0c1d(short playerID, short unitID, int param3)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_0c1d({playerID}, {unitID}, {param3})");
			CivGame.LogUnit(this.oParent, this.oParent.GoToLog, playerID, unitID, this.oGameData.HumanPlayerID);

			// function body
			int local_2;
			int local_4;
			int local_6;
			int local_8;
			int local_a;
			int local_c;
			int local_e = 0;
			int local_10;
			int local_12;
			int local_16;
			int local_1a;
			int local_1c;
			int local_1e;
			int local_20;
			int local_36;
			int local_38;
			int local_3a;
			int local_3c;
			int local_3e;
			int local_40;
			int local_44;
			int local_46;
			int local_4a;

			local_46 = this.oGameData.Players[playerID].Units[unitID].Position.X;
			local_4a = this.oGameData.Players[playerID].Units[unitID].Position.Y;

			local_20 = this.Var_6590_XPos - 8;
			local_3a = this.Var_6592_YPos - 8;

			this.Var_6794 = 0;

			if (this.Var_6590_XPos != this.Var_6796 || this.Var_6592_YPos != this.Var_6798)
				goto L0c89;

			if (this.Var_b780[local_46 - local_20, local_4a - local_3a] != 0)
				goto L0d8b;

		L0c89:
			this.Var_6796 = this.Var_6590_XPos;
			this.Var_6798 = this.Var_6592_YPos;

			// Instruction address 0x2e31:0x0ca0, size: 5
			for (int i = 0; i < this.Var_b780.GetLength(0); i++)
			{
				for (int j = 0; j < this.Var_b780.GetLength(1); j++)
				{
					this.Var_b780[i, j] = 0;
				}
			}

			local_2 = 0;
			local_4 = 0;

			this.Var_6594[0] = this.Var_6590_XPos;

			this.Var_6694[local_2] = this.Var_6592_YPos;
			local_2++;

			this.Var_b780[this.Var_6590_XPos - local_20, this.Var_6592_YPos - local_3a] = 1;

			this.Var_6794 = param3;

			if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air)
			{
				local_1e = 0;
			}
			else
			{
				local_1e = 1;
			}

			if (this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MoveCount == 1)
			{
				local_10 = 1;
			}
			else
			{
				local_10 = 0;
			}

		L0d21:
			local_1c = this.Var_6594[local_4];
			local_36 = this.Var_6694[local_4];

			local_4++;
			local_4 %= 256;

			local_e = this.Var_b780[local_1c - local_20, local_36 - local_3a];

			if (local_e > this.Var_6794) goto L0d7c;

			// Instruction address 0x2e31:0x0d63, size: 3
			if (F0_2e31_119b_AdjustXPosition(local_1c) != local_46) goto L0da8;

			if (local_36 != local_4a) goto L0da8;
			this.Var_6794 = local_e;

		L0d7c:
			if (local_4 == local_2) goto L0d8b;

			if (local_4 < 225) goto L0d21;

		L0d8b:
			local_16 = -1;

			if (param3 > this.Var_6794)
				goto L0d9b;

			goto L10ed;

		L0d9b:
			local_a = 99;
			local_3c = 1;

			goto L0f29;

		L0da8:
			// Instruction address 0x2e31:0x0daf, size: 3
			// Instruction address 0x2e31:0x0db6, size: 5
			local_8 = this.oParent.Segment_2aea.F0_2aea_1570(F0_2e31_119b_AdjustXPosition(local_1c), local_36);
			local_3c = 1;

			goto L0dea;

		L0dc8:
			if (local_1e != 0) goto L0dd2;
			goto L0e70;

		L0dd2:
			// Instruction address 0x2e31:0x0dd8, size: 5
			if ((this.oParent.Segment_2aea.F0_2aea_1585_GetImprovements(local_c, local_44) & 0x1) == 0) goto L0de7;
			goto L0e70;

		L0de7:
			local_3c++;

		L0dea:
			if (local_3c > 8) goto L0d7c;

			GPoint direction = this.oStaticGameData.MoveOffsets[local_3c];

			local_40 = direction.X + local_1c;

			// Instruction address 0x2e31:0x0e04, size: 5
			if (Math.Abs(local_40 - this.Var_6590_XPos) >= 8) goto L0de7;

			// Instruction address 0x2e31:0x0e15, size: 3
			local_c = F0_2e31_119b_AdjustXPosition(local_40);

			local_44 = direction.Y + local_36;

			// Instruction address 0x2e31:0x0e32, size: 5
			if (Math.Abs(local_44 - this.Var_6592_YPos) >= 8) goto L0de7;

			// Instruction address 0x2e31:0x0e45, size: 5
			if (this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(local_c, local_44) == 0) goto L0de7;

			// Instruction address 0x2e31:0x0e57, size: 5
			local_3e = (short)this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(local_c, local_44);

			if (local_3e == 10) goto L0e6a;
			goto L0dc8;

		L0e6a:
			if (local_1e != 1) goto L0dd2;

		L0e70:
			// Instruction address 0x2e31:0x0e7c, size: 5
			if (local_8 != 0 && this.oParent.Segment_2aea.F0_2aea_1570(local_c, local_44) != 0)
			{
				local_1a = local_e + 1;
			}
			else
			{
				if (local_10 != 0)
				{
					local_1a = local_e + 3;
				}
				else
				{
					local_1a = (this.oStaticGameData.Terrains[local_3e].MovementCost * 3) + local_e;
				}
			}

			local_38 = this.Var_b780[local_40 - local_20, local_44 - local_3a];

			if (local_38 == 0 || local_38 > local_1a)
			{
				this.Var_b780[local_40 - local_20, local_44 - local_3a] = local_1a;

				this.Var_6594[local_2] = local_40;
				this.Var_6694[local_2] = local_44;

				local_2++;
				local_2 %= 256;
			}

			goto L0de7;

		L0f0d:
			local_40 += 80;

		L0f11:
			// Instruction address 0x2e31:0x0f19, size: 5
			if (Math.Abs(local_40 - this.Var_6590_XPos) < 8) goto L0f61;

		L0f26:
			local_3c++;

		L0f29:
			if (local_3c <= 8) goto L0f32;

			goto L10e2;

		L0f32:
			direction = this.oStaticGameData.MoveOffsets[local_3c];
			local_40 = direction.X + local_46;

			// Instruction address 0x2e31:0x0f46, size: 5
			if (Math.Abs(local_40 - this.Var_6590_XPos) < 72) goto L0f11;

			if (local_40 <= this.Var_6590_XPos)
				goto L0f0d;

			local_40 -= 80;
			goto L0f11;

		L0f61:
			// Instruction address 0x2e31:0x0f65, size: 3
			local_c = F0_2e31_119b_AdjustXPosition(local_40);

			local_44 = direction.Y + local_4a;

			// Instruction address 0x2e31:0x0f82, size: 5
			if (Math.Abs(local_44 - this.Var_6592_YPos) >= 8) goto L0f26;

			// Instruction address 0x2e31:0x0f95, size: 5
			if (((this.oStaticGameData.UnitDefinitions[this.oGameData.Players[playerID].Units[unitID].TypeID].MovementType != UnitMovementTypeEnum.Air) ? 0 : 1) ==
				((this.oParent.Segment_2aea.F0_2aea_134a_GetMapLayer1_TerrainType(local_c, local_44) != TerrainTypeEnum.Water) ? 0 : 1))
				goto L0fec;

			// Instruction address 0x2e31:0x0fdd, size: 5
			if ((this.oParent.Segment_2aea.F0_2aea_1585_GetImprovements(local_c, local_44) & 0x1) != 0) goto L0fec;

			goto L0f26;

		L0fec:
			local_6 = this.Var_b780[local_40 - local_20, local_44 - local_3a];

			if (local_6 != 0)
			{
				if (local_6 < local_a)
				{
					local_a = local_6;
					local_16 = local_3c;

					// Instruction address 0x2e31:0x1025, size: 5
					local_12 = (short)this.oParent.Segment_2aea.F0_2aea_1458(local_c, local_44);

					if (local_12 != -1)
					{
						// Instruction address 0x2e31:0x103f, size: 5
						local_e = (short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_12, 2) * 4;
					}
					else
					{
						local_e = 0;
					}

					// Instruction address 0x2e31:0x1063, size: 5
					local_e += this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(this.Var_6590_XPos, this.Var_6592_YPos, local_c, local_44);
				}

				if (local_6 == local_a)
				{
					// Instruction address 0x2e31:0x107f, size: 5
					local_12 = (short)this.oParent.Segment_2aea.F0_2aea_1458(local_c, local_44);

					if (local_12 != -1)
					{
						// Instruction address 0x2e31:0x1099, size: 5
						local_1a = (short)this.oParent.Segment_1866.F0_1866_1251(playerID, (short)local_12, 2) * 4;
					}
					else
					{
						local_1a = 0;
					}

					// Instruction address 0x2e31:0x10bd, size: 5
					local_1a += this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(this.Var_6590_XPos, this.Var_6592_YPos, local_c, local_44);

					if (local_1a < local_e)
					{
						local_16 = local_3c;
						local_e = local_1a;
					}
				}
			}

			goto L0f26;

		L10e2:
			if (local_16 == -1) goto L10ed;

			this.oCPU.AX.Word = (ushort)((short)local_16);

			goto L1116;

		L10ed:
			if (local_16 != -1) goto L1113;

			this.Var_6590_XPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.X;
			this.Var_6592_YPos = this.oGameData.Players[playerID].Units[unitID].GoToPosition.Y;

		L1113:
			this.oCPU.AX.Word = 0xffff;

		L1116:
			// Far return
			this.oParent.GoToLog.ExitBlock("F0_2e31_0c1d", this.oCPU.AX.Word);

			return (short)this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="xPos1"></param>
		/// <param name="yPos1"></param>
		/// <param name="unitType"></param>
		/// <param name="param6"></param>
		/// <returns></returns>
		public int F0_2e31_111c_CreateBarbarianUnit(int xPos, int yPos, int xPos1, int yPos1, int unitType, int param6)
		{
			this.oParent.GoToLog.EnterBlock($"F0_2e31_111c_CreateBarbarianUnit({xPos}, {yPos}, {xPos1}, {yPos1}, {unitType}, {param6})");

			// function body
			if (Math.Abs(xPos - xPos1) <= 7 && Math.Abs(yPos - yPos1) <= 7)
			{
				// Temporary unit...
				this.oGameData.Players[0].Units[127].TypeID = (short)((unitType == 0) ? UnitTypeEnum.Militia : UnitTypeEnum.Trireme);
				this.oGameData.Players[0].Units[127].Position.X = xPos;
				this.oGameData.Players[0].Units[127].Position.Y = yPos;
				this.oGameData.Players[0].Units[127].GoToPosition.X = xPos1;
				this.oGameData.Players[0].Units[127].GoToPosition.Y = yPos1;

				this.Var_6590_XPos = xPos1;
				this.Var_6592_YPos = yPos1;

				// Instruction address 0x2e31:0x117c, size: 3
				if (F0_2e31_0c1d(0, 127, param6) == -1)
				{
					this.oCPU.AX.Word = 0xffff;
				}
				else
				{
					this.oCPU.AX.Word = (ushort)((short)this.Var_6794);
				}

				this.oGameData.Players[0].Units[127].TypeID = -1;
				this.oGameData.Players[0].Units[127].Position.X = -1;
				this.oGameData.Players[0].Units[127].Position.Y = -1;
				this.oGameData.Players[0].Units[127].GoToPosition.X = -1;
				this.oGameData.Players[0].Units[127].GoToPosition.Y = -1;
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}

			// Far return
			this.oParent.GoToLog.ExitBlock("F0_2e31_111c_CreateBarbarianUnit", this.oCPU.AX.Word);

			return (short)this.oCPU.AX.Word;
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
