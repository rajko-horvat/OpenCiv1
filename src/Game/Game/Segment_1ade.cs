using IRB.VirtualCPU;
using OpenCiv1.Graphics;

namespace OpenCiv1
{
	public class Segment_1ade
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		public Segment_1ade(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_1ade_0006(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_0006({playerID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xa);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			
			this.oParent.Var_db42 = 0;
			this.oParent.Var_e3c2 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0);
			goto L0027;

		L001e:
			this.oParent.Var_b1e8 = 0;

		L0024:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0027:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.L) goto L0031;
			goto L00b2;

		L0031:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0024;

			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID != playerID)
				goto L0024;

		L004a:
			// Instruction address 0x1ade:0x0051, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0070;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ActualSize, 0x5);
			if (this.oCPU.Flags.LE) goto L0070;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x1));

		L0070:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0x1);
			if (this.oCPU.Flags.E) goto L0083;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.OR_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x2));

		L0083:
			if (this.oParent.Var_b1e8 == 0) goto L0024;

			// Instruction address 0x1ade:0x0093, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 1);

			// Instruction address 0x1ade:0x009b, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			if (this.oParent.Var_b1e8 == 2) goto L00aa;
			goto L001e;

		L00aa:
			this.oParent.Var_b1e8 = 0;
			goto L004a;

		L00b2:
			if (playerID == this.oGameData.HumanPlayerID)
				goto L0188;

			this.oCPU.TEST_UInt8((byte)(this.oGameData.DebugFlags & 0xff), 0x4);
			if (this.oCPU.Flags.NE) goto L00c7;
			goto L0188;

		L00c7:
			this.oCPU.DI.Word = (ushort)this.oGameData.Players[playerID].ScienceTaxRate;
			this.oCPU.DI.Word += (ushort)this.oGameData.Players[playerID].TaxRate;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x2);
			if (this.oCPU.Flags.E) goto L00ea;
			this.oCPU.CMP_UInt16(this.oCPU.DI.Word, 0x6);
			if (this.oCPU.Flags.LE) goto L00ea;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L00ea:
			this.oCPU.TEST_UInt8((byte)(this.oGameData.TurnCount & 0xff), 0x3);
			if (this.oCPU.Flags.NE) goto L010c;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L010c;
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[playerID].TaxRate;
			this.oCPU.AX.Word += (ushort)this.oGameData.Players[playerID].ScienceTaxRate;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.GE) goto L010c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.DEC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L010c:
			// Instruction address 0x1ade:0x0116, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0, 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			if (this.oGameData.Players[playerID].NationalityID != -1)
			{
				this.oCPU.CX.Word = (ushort)this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Ideology;
			}
			else
			{
				this.oCPU.CX.Word = 0;
			}

			this.oCPU.AX.Word = 0xa;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oGameData.Players[playerID].ScienceTaxRate = (short)this.oCPU.CX.Word;
			this.oCPU.AX.Word = (ushort)this.oGameData.TurnCount;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0x64);
			this.oCPU.CMP_UInt16((ushort)this.oGameData.Players[playerID].Coins, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0156;
			this.oGameData.Players[playerID].ScienceTaxRate++;

		L0156:
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Robotics);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oGameData.Players[playerID].ScienceTaxRate = 0;
			}

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[playerID].ScienceTaxRate;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xa);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oGameData.Players[playerID].TaxRate = (short)this.oCPU.AX.Word;

		L0188:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_0006");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_1ade_018e(short cityID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_018e({cityID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0xa);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x01b7, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(1, 0xff, (byte)this.oGameData.Cities[cityID].NameID, (byte)((sbyte)xPos), (byte)((sbyte)yPos));

			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[cityID].CurrentProductionID, 0x0);
			if (this.oCPU.Flags.L) goto L01db;
			
			this.oCPU.AX.Low = 0x38;
			this.oCPU.IMUL_UInt8(this.oCPU.AX, (byte)this.oGameData.Cities[cityID].PlayerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);

			this.oGameData.Players[this.oGameData.Cities[cityID].PlayerID].UnitsInProduction[this.oGameData.Cities[cityID].CurrentProductionID]--;

		L01db:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oGameData.Players[this.oGameData.Cities[cityID].PlayerID].CityCount--;
			this.oGameData.Cities[cityID].StatusFlag = 0xff;

			// Instruction address 0x1ade:0x01fe, size: 5
			this.oParent.MapManagement.F0_2aea_1653_ClearOrSetImprovements(xPos, yPos, 0, 0);

			if (!this.oGameData.Map[xPos, yPos].IsVisibleTo(this.oGameData.HumanPlayerID)) goto L0236;

			// Instruction address 0x1ade:0x022e, size: 5
			this.oParent.MapManagement.F0_2aea_1601_UpdateVisiblemprovements(xPos, yPos);

		L0236:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0266;

		L023d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0240:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3);
			if (this.oCPU.Flags.GE) goto L0263;

			if (cityID != this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))])
				goto L023d;

			this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))] = -1;
			goto L023d;

		L0263:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0266:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0274;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L0240;

		L0274:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);

		L0279:
			if (cityID != this.oGameData.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))])
				goto L028d;

			this.oGameData.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))] = 128;

		L028d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x15);
			if (this.oCPU.Flags.LE) goto L0279;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L029b:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.SI.Word = (ushort)this.oGameData.Cities[cityID].PlayerID;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.AX.Word);

			if (this.oGameData.Players[this.oGameData.Cities[cityID].PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].TypeID != -1)
			{				
				if (this.oGameData.Players[this.oGameData.Cities[cityID].PlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))].HomeCityID == cityID)
				{
					// Instruction address 0x1ade:0x02ce, size: 5
					this.oParent.Segment_1866.F0_1866_0f10((short)this.oCPU.SI.Word,
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
				}
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x80);
			if (this.oCPU.Flags.L) goto L029b;

			// Instruction address 0x1ade:0x02e6, size: 5
			this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0317;

			// Instruction address 0x1ade:0x030f, size: 5
			this.oParent.Segment_1866.F0_1866_144b(this.oGameData.Cities[cityID].PlayerID, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x1643);

		L0317:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L031c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			GPoint direction = TerrainMap.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];

			// Instruction address 0x1ade:0x0329, size: 5
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Map.WrapXPosition(xPos + direction.X));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), (short)(yPos + direction.Y));

			// Instruction address 0x1ade:0x0342, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x14);
			if (this.oCPU.Flags.LE) goto L035a;
			
			if (this.oParent.Var_6c9a <= 3) goto L0385;

		L035a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, 0x50);

			// Instruction address 0x1ade:0x0370, size: 5
			//this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
			//	this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 80,
			//	this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) + 50);

			// Instruction address 0x1ade:0x037d, size: 5
			//this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 80,
			//	this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
			//	this.oCPU.AX.Word);

			this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Layer2_PlayerOwnership = 
				this.oGameData.Map[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Layer4_BuildSites;

		L0385:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x2d);
			if (this.oCPU.Flags.L) goto L031c;
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_018e");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_1ade_03ea(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_03ea({cityID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x1ade:0x03f1, size: 3
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oParent.Var_6b64 = 0;

			// Instruction address 0x1ade:0x0403, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(cityID, 1);

			if (this.oParent.Var_6b64 == 0) goto L0419;

			// Instruction address 0x1ade:0x0412, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L041d;

		L0419:
			// Instruction address 0x1ade:0x041a, size: 3
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L041d:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_03ea");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="cityID"></param>
		/// <returns></returns>
		public ushort F0_1ade_0421(short playerID, short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_0421({playerID}, {cityID})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x14a);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12e), 0x2a);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x1ade:0x043f, size: 5
			this.oParent.CityWorker.F0_1d12_0045_ProcessCityState(cityID, -1);

		L0447:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xde), this.oCPU.AX.Word);

			// Instruction address 0x1ade:0x0465, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "What shall we build in ");

			// Instruction address 0x1ade:0x0470, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x1ade:0x0480, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "?\n ");

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13a)), 0x2);
			if (this.oCPU.Flags.NE) goto L0492;
			goto L05f4;

		L0492:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 0x0);
			goto L05c5;

		L049b:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x04ac, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, 
				(int)this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].RequiresTechnology);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L05c1;

			// Instruction address 0x1ade:0x04c1, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID,
				(int)this.oGameData.Static.Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].ObsoletesAfterTechnology);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L05c1;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x2);
			if (this.oCPU.Flags.NE) goto L04e7;

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].MovementType == UnitMovementTypeEnum.Air)
				goto L05c1;

		L04e7:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x04f8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].Name);

			// Instruction address 0x1ade:0x0508, size: 3
			F0_1ade_14ed(cityID, this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].Price);

			// Instruction address 0x1ade:0x0516, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ", ADM:");

			// Instruction address 0x1ade:0x0537, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].AttackStrength, 10));

			// Instruction address 0x1ade:0x0547, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "/");

			// Instruction address 0x1ade:0x0568, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].DefenseStrength, 10));

			// Instruction address 0x1ade:0x0578, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "/");

			// Instruction address 0x1ade:0x0599, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].MoveCount, 10));

			// Instruction address 0x1ade:0x05a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")\n ");

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0xde), this.oCPU.AX.Word);

		L05c1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))));

		L05c5:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x1c);
			if (this.oCPU.Flags.GE) goto L05f4;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x19);
			if (this.oCPU.Flags.E) goto L05d6;
			goto L049b;

		L05d6:
			if (this.oGameData.WonderCityID[17] == -1) goto L05c1;

			// Instruction address 0x1ade:0x05e5, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.NuclearFission);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L05f2;

			goto L049b;

		L05f2:
			goto L05c1;

		L05f4:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x136), this.oCPU.AX.Word);

			// Instruction address 0x1ade:0x05ff, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x138), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

			// Instruction address 0x1ade:0x0617, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(playerID, (int)WonderEnum.HooverDam);
			
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L066b;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oGameData.WonderCityID[15]);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x0640, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
				this.oGameData.Cities[this.oGameData.WonderCityID[15]].Position.X,
				this.oGameData.Cities[this.oGameData.WonderCityID[15]].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x146), this.oCPU.AX.Word);

			// Instruction address 0x1ade:0x0658, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
				this.oGameData.Cities[cityID].Position.X,
				this.oGameData.Cities[cityID].Position.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x146)));
			if (this.oCPU.Flags.NE) goto L066b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L066b:
			this.oCPU.TEST_UInt8((byte)(this.oGameData.DebugFlags & 0xff), 0x4);
			if (this.oCPU.Flags.NE) goto L0675;
			goto L082f;

		L0675:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 0x1);
			goto L06a3;

		L067d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x15);
			if (this.oCPU.Flags.G) goto L0687;
			goto L07e3;

		L0687:
			this.oCPU.CMP_UInt16((ushort)this.oGameData.WonderCityID[19], 0xffff);
			if (this.oCPU.Flags.E) goto L069f;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.NE) goto L069f;
			goto L07e3;

		L069f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))));

		L06a3:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x18);
			if (this.oCPU.Flags.LE) goto L06ad;
			goto L082f;

		L06ad:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x06be, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, 
				(int)this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).RequiresTechnology);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L069f;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oGameData.Cities[cityID].ImprovementFlags0;
			this.oCPU.DX.Word = this.oGameData.Cities[cityID].ImprovementFlags1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x148), this.oCPU.DX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.CX.Low = this.oCPU.DEC_UInt8(this.oCPU.CX.Low);
			this.oCPU.UInt32ToTwoUInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.TwoUInt16ToUInt32(this.oCPU.AX.Word, this.oCPU.DX.Word) << this.oCPU.CX.Low);

			this.oCPU.AX.Word = this.oCPU.AND_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14a)));
			this.oCPU.DX.Word = this.oCPU.AND_UInt16(this.oCPU.DX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x148)));
			this.oCPU.DX.Word = this.oCPU.OR_UInt16(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L069f;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x7);
			if (this.oCPU.Flags.NE) goto L0709;
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14a)), 0x1);
			if (this.oCPU.Flags.NE) goto L069f;

		L0709:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0xf);
			if (this.oCPU.Flags.NE) goto L0723;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x8000);
			if (this.oCPU.Flags.E) goto L0723;
			goto L069f;

		L0723:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0xa);
			if (this.oCPU.Flags.NE) goto L074e;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x10);
			if (this.oCPU.Flags.NE) goto L074e;
	
			// Instruction address 0x1ade:0x0741, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, (int)this.oGameData.Static.ImprovementDefinitions((int)ImprovementEnum.MarketPlace).RequiresTechnology);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L074e;

			goto L069f;

		L074e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0xc);
			if (this.oCPU.Flags.NE) goto L0779;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x20);
			if (this.oCPU.Flags.NE) goto L0779;
	
			// Instruction address 0x1ade:0x076c, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, (int)this.oGameData.Static.ImprovementDefinitions((int)ImprovementEnum.Library).RequiresTechnology);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L0779;

			goto L069f;

		L0779:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x14);
			if (this.oCPU.Flags.NE) goto L0792;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x8);
			if (this.oCPU.Flags.NE) goto L0792;
			goto L069f;

		L0792:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x13);
			if (this.oCPU.Flags.NE) goto L07ac;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x4000);
			if (this.oCPU.Flags.NE) goto L07ac;
			goto L069f;

		L07ac:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x13);
			if (this.oCPU.Flags.E) goto L07c4;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x14);
			if (this.oCPU.Flags.E) goto L07c4;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x15);
			if (this.oCPU.Flags.E) goto L07c4;
			goto L067d;

		L07c4:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L07cd;
			goto L069f;

		L07cd:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags1, 0x1c);
			if (this.oCPU.Flags.NE) goto L07e0;
			goto L067d;

		L07e0:
			goto L069f;

		L07e3:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x07f4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).Name);

			// Instruction address 0x1ade:0x0804, size: 3
			F0_1ade_14ed(cityID, 
				this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).Price);

			// Instruction address 0x1ade:0x0812, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")\n ");

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0xde), this.oCPU.AX.Word);
			goto L069f;

		L082f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 0x19);

		L0835:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x0846, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID,
				(int)this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).RequiresTechnology);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L08cf;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			
			if (this.oGameData.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)) - 24] != -1)
				goto L08cf;

			if (this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).ObsoletesAfterTechnology == TechnologyEnum.None ||
				(this.oGameData.TechnologyFirstDiscoveredBy[(int)this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).ObsoletesAfterTechnology] & 7) == 0)
				goto L0886;

			// Instruction address 0x1ade:0x087e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "*");

		L0886:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x0897, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).Name);

			// Instruction address 0x1ade:0x08a7, size: 3
			F0_1ade_14ed(cityID,
				this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))).Price);

			// Instruction address 0x1ade:0x08b5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")\n ");

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0xde), this.oCPU.AX.Word);

		L08cf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x2d);
			if (this.oCPU.Flags.G) goto L08dd;
			goto L0835;

		L08dd:
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L092a;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x10);
			if (this.oCPU.Flags.NE) goto L092a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x1e);
			if (this.oCPU.Flags.LE) goto L092a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13a)), 0x0);
			if (this.oCPU.Flags.NE) goto L090a;

		L0901:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13a), 0x1);
			goto L0447;

		L090a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x138));
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, 0xba06);
			// Instruction address 0x1ade:0x0916, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.AX.Word, "more...\n");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x136));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xde), 0x63);

		L092a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13a)), 0x2);
			if (this.oCPU.Flags.NE) goto L094f;

			// Instruction address 0x1ade:0x0939, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "more...\n");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xde), 0x62);

		L094f:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x0963, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(this.oGameData.Cities[cityID].Position.X, this.oGameData.Cities[cityID].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13e), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[playerID].Continents[this.oCPU.AX.Word].Strategy;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x142), this.oCPU.AX.Word);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L098c;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L0991;

		L098c:
			this.oCPU.AX.Word = 0x1;
			goto L0993;

		L0991:
			this.oCPU.AX.Word = 0;

		L0993:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13c), this.oCPU.AX.Word);
			
			if (this.oParent.Var_8078 == 0) goto L09ab;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x142)), 0x5);
			if (this.oCPU.Flags.NE) goto L09ab;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13c), 0x1);

		L09ab:
			if (this.oGameData.Players[playerID].GovernmentType <= 1) goto L09bc;
			this.oCPU.AX.Word = 0x2;
			goto L09bf;

		L09bc:
			this.oCPU.AX.Word = 0x1;

		L09bf:
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)((short)this.oParent.Var_e3c6));
			this.oCPU.CX.Word = (ushort)((short)this.oParent.Array_70da[0]);
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SUB_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 0x0);

		L09e3:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x11a), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x44), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x1c);
			if (this.oCPU.Flags.L) goto L09e3;

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[playerID].UnitCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x140), this.oCPU.AX.Word);
			this.oGameData.Players[playerID].UnitCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), 0x0);

		L0a19:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			
			if (this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].StatusFlag == 0xff ||
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].PlayerID != playerID) goto L0aa5;

			// Instruction address 0x1ade:0x0a3e, size: 5
			this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Position.X,
				this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Position.Y);

			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13e)));
			if (this.oCPU.Flags.NE) goto L0aa5;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].CurrentProductionID, 0x0);
			if (this.oCPU.Flags.L) goto L0a68;
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0a68;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x11a), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x11a))));

		L0a68:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11c), 0x0);

		L0a6e:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11c));
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11c))];
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14a), this.oCPU.AX.Low);
			this.oCPU.CMP_UInt8(this.oCPU.AX.Low, 0xff);
			if (this.oCPU.Flags.E) goto L0a9a;

			this.oGameData.Players[playerID].UnitCount++;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.AND_UInt16(this.oCPU.SI.Word, 0x3f);
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44))));

		L0a9a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11c), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11c))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11c)), 0x2);
			if (this.oCPU.Flags.L) goto L0a6e;

		L0aa5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)), 0x80);
			if (this.oCPU.Flags.GE) goto L0ab2;
			goto L0a19;

		L0ab2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 0x0);

		L0ab8:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)));
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].TypeID != -1)
			{
				this.oGameData.Players[playerID].UnitCount++;

				// Instruction address 0x1ade:0x0ae5, size: 5
				this.oParent.MapManagement.F0_2aea_1942_GetGroupID(
					this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].Position.X,
					this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].Position.Y);

				this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13e)));
				if (this.oCPU.Flags.E)
				{
					this.oCPU.DI.Word = (ushort)((short)this.oGameData.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))].TypeID);
					this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x44),
						this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x44))));
				}
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 0x80);
			if (this.oCPU.Flags.L) goto L0ab8;
			if (this.oGameData.Players[playerID].UnitCount != 0) goto L0b2c;

			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b2c;
			if (this.oGameData.Players[playerID].GovernmentType > 1) goto L0b2c;
			this.oCPU.AX.Word = 0x1;
			goto L14e7;

		L0b2c:
			this.oCPU.CMP_UInt16((ushort)playerID, 0x0);
			if (this.oCPU.Flags.NE) goto L0b4a;
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.TEST_UInt8(this.oCPU.ReadUInt8(this.oCPU.ES.Word, 0x520), 0x7);
			if (this.oCPU.Flags.NE) goto L0b44;
			this.oCPU.AX.Word = 0x3;
			goto L14e7;

		L0b44:
			this.oCPU.AX.Word = 0x7;
			goto L14e7;

		L0b4a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x0b63, size: 5
			this.oParent.MapManagement.F0_2aea_1458_GetCellActiveUnitID(this.oGameData.Cities[cityID].Position.X, this.oGameData.Cities[cityID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0b7b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x2);
			goto L0baf;

		L0b7b:
			// Instruction address 0x1ade:0x0b86, size: 5
			this.oParent.Segment_1866.F0_1866_1380(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), 2);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Low = 0x4;
			this.oCPU.IDIV_UInt8(this.oCPU.AX, this.oCPU.DX.Low);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13c)));
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.LE) goto L0baf;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);

		L0baf:
			this.oCPU.AX.Word = 0x3e7;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x130), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), 0x1);
			goto L0f57;

		L0bcf:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L0be1;
			goto L0ed5;

		L0be1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0xfffc);
			goto L0ed5;

		L0bea:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Var_d2e0);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);

		L0bef:
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xc);

		L0bf2:
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);

		L0bf4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			goto L0ed5;

		L0bfb:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L0c0d;
			goto L0ed5;

		L0c0d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0xfffe);
			goto L0ed5;

		L0c16:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L0c28;
			goto L0ed5;

		L0c28:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0xffff);
			goto L0ed5;

		L0c31:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0x5);

		L0c37:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x132), 0x1);
			goto L0ed5;

		L0c40:
			if (this.oParent.Array_70da[1] < 3)
				goto L0c4c;

		L0c47:
			this.oCPU.AX.Word = 0x4;
			goto L0bf4;

		L0c4c:
			this.oCPU.AX.Word = 0x8;
			goto L0bf4;

		L0c51:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_70da[1]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xd);
			goto L0bf2;

		L0c5e:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_70da[1]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x5;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			goto L0bef;

		L0c69:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_70da[1]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			goto L0bef;

		L0c7d:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_70da[2]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xa);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x1);
			if (this.oCPU.Flags.NE) goto L0ca0;
			goto L0ed5;

		L0ca0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0xfffd);
			goto L0ed5;

		L0ca9:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_70da[2]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

		L0cb2:
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xa);
			goto L0bf2;

		L0cb8:
			this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_70da[2]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			goto L0cb2;

		L0ccb:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x2;
			this.oCPU.IDIV_UInt8(this.oCPU.AX, this.oCPU.CX.Low);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xa);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x1);
			if (this.oCPU.Flags.NE) goto L0cf0;
			goto L0c37;

		L0cf0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.SUB_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x4));
			goto L0c37;

		L0cf8:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oGameData.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.LE) goto L0d1d;
			goto L0ed5;

		L0d1d:
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xe);
			goto L0bf2;

		L0d27:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oGameData.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHL_UInt16(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L0d43;
			goto L0ed5;

		L0d43:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ADD_UInt8(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.SpaceshipFlags);
			if (this.oCPU.Flags.NE) goto L0d54;
			goto L0c47;

		L0d54:
			this.oCPU.AX.Word = 0x2;
			goto L0bf4;

		L0d5a:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[cityID].TradeCityIDs[2], 0xff);
			if (this.oCPU.Flags.NE) goto L0da7;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.Array_70da[2]);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xa);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[cityID].TradeCityIDs[0], 0xff);
			if (this.oCPU.Flags.E) goto L0d86;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x2));

		L0d86:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[cityID].TradeCityIDs[1], 0xff);
			if (this.oCPU.Flags.E) goto L0d9a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x2));

		L0d9a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x3);
			if (this.oCPU.Flags.GE) goto L0da7;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0x3);

		L0da7:
			this.oCPU.AX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CMP_UInt16((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0db2;
			goto L0ed5;

		L0db2:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x10);
			if (this.oCPU.Flags.NE) goto L0dc4;
			goto L0ed5;

		L0dc4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0x3e7);
			goto L0ed5;

		L0dcd:
			if (this.oGameData.HumanPlayerID <= 0)
				goto L0ed5;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.HumanPlayerID] & 2) != 0)
				goto L0ed5;

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Players[playerID].UnitsInProduction[27] > 0)
				goto L0ed5;

			// Instruction address 0x1ade:0x0e04, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(5));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2a6e));
			if (this.oCPU.Flags.NE) goto L0e20;
			goto L0ed5;

		L0e20:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.DI.Word = this.oGameData.Players[playerID].DiscoveredTechnologyFlags[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))];

			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oGameData.HumanPlayerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oGameData.Players[this.oGameData.HumanPlayerID].DiscoveredTechnologyFlags[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))];
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NE) goto L0e47;
			goto L0ed5;

		L0e47:
			// Instruction address 0x1ade:0x0e66, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oGameData.Players[playerID].DiscoveredTechnologyCount -
				this.oGameData.Players[this.oGameData.HumanPlayerID].DiscoveredTechnologyCount + 10,
				5, 10);
			goto L0bf4;

		L0ed5:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x190);
			if (this.oCPU.Flags.GE) goto L0f1c;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x132));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13c)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0eec;
			this.oCPU.AX.Word = 0x14;
			goto L0eef;

		L0eec:
			this.oCPU.AX.Word = 0xa;

		L0eef:
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			
			this.oCPU.CX.Word = (ushort)this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Ideology;
			this.oCPU.CX.Word = this.oCPU.ADD_UInt16(this.oCPU.CX.Word, 0x3);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);

			goto L0f22;

		L0f1c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0x3fff);

		L0f22:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt16(this.oGameData.Cities[cityID].ImprovementFlags0, 0x2);
			if (this.oCPU.Flags.NE) goto L0f34;
			goto L1206;

		L0f34:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.ADD_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), this.oCPU.AX.Word));
			goto L1206;

		L0f4d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x17);
			if (this.oCPU.Flags.NE) goto L0f9d;

		L0f53:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0))));

		L0f57:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0f63;
			goto L1268;

		L0f63:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xde));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0f79;
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x1a);
			if (this.oCPU.Flags.L) goto L0f4d;

		L0f79:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x132), 0x0);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xffe5);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x31);
			if (this.oCPU.Flags.BE) goto L0f95;
			goto L0ed5;

		L0f95:
			switch(this.oCPU.AX.Word)
			{
				case 0:
					goto L0d5a;
				case 1:
					goto L0dcd;
				case 2:
					goto L0ed5;
				case 3:
					goto L0ed5;
				case 4:
					goto L0ed5;
				case 5:
					goto L0ed5;
				case 6:
					goto L0ed5;
				case 7:
					goto L0ed5;
				case 8:
					goto L0ed5;
				case 9:
					goto L0ed5;
				case 10:
					goto L0ed5;
				case 11:
					goto L0ed5;
				case 12:
					goto L0ed5;
				case 13:
					goto L0ed5;
				case 14:
					goto L0ed5;
				case 15:
					goto L0ed5;
				case 16:
					goto L0ed5;
				case 17:
					goto L0ed5;
				case 18:
					goto L0ed5;
				case 19:
					goto L0ed5;
				case 20:
					goto L0ed5;
				case 21:
					goto L0ed5;
				case 22:
					goto L0ed5;
				case 23:
					goto L0ed5;
				case 24:
					goto L0ed5;
				case 25:
					goto L0ed5;
				case 26:
					goto L0ed5;
				case 27:
					goto L0ed5;
				case 28:
					goto L0ed5;
				case 29:
					goto L0c31;
				case 30:
					goto L0c40;
				case 31:
					goto L0bcf;
				case 32:
					goto L0c7d;
				case 33:
					goto L0ca9;
				case 34:
					goto L0bea;
				case 35:
					goto L0ccb;
				case 36:
					goto L0cf8;
				case 37:
					goto L0ca9;
				case 38:
					goto L0bfb;
				case 39:
					goto L0cb8;
				case 40:
					goto L0ed5;
				case 41:
					goto L0c16;
				case 42:
					goto L0c51;
				case 43:
					goto L0c69;
				case 44:
					goto L0ed5;
				case 45:
					goto L0c69;
				case 46:
					goto L0c5e;
				case 47:
					goto L0c51;
				case 48:
					goto L0c69;
				case 49:
					goto L0d27;
			}

		L0f9d:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x0);
			if (this.oCPU.Flags.NE) goto L0fd2;
			if (this.oGameData.Players[playerID].GovernmentType <= 1) goto L0fb4;
			this.oCPU.AX.Word = 0x2;
			goto L0fb7;

		L0fb4:
			this.oCPU.AX.Word = 0x1;

		L0fb7:
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			if (this.oCPU.Flags.L) goto L0fd2;
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oGameData.Players[playerID].ActiveUnits[0] != 0x0)
				goto L0f53;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11a)), 0x1);
			if (this.oCPU.Flags.G) goto L0f53;

		L0fd2:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x1);
			if (this.oCPU.Flags.NE) goto L0fe7;
			if (this.oGameData.Players[playerID].GovernmentType <= 1) goto L0fe7;
			goto L0f53;

		L0fe7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x19);
			if (this.oCPU.Flags.NE) goto L1009;

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			
			if (this.oGameData.Players[playerID].ActiveUnits[25] >= 4)
				goto L0f53;

			if (this.oGameData.Players[playerID].UnitsInProduction[25] >= 2)
				goto L0f53;

		L1009:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0xe);
			if (this.oCPU.Flags.NE) goto L1054;
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)this.oGameData.HumanPlayerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			//this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb3dc));
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].ActiveUnits[15];

			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = (ushort)this.oGameData.Players[playerID].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))];
			this.oCPU.CX.Word += (ushort)this.oGameData.Players[playerID].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))];
			this.oCPU.CMP_UInt16(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L103d;
			goto L0f53;

		L103d:
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			if ((this.oGameData.Players[playerID].Diplomacy[this.oGameData.HumanPlayerID] & 2) != 0)
				goto L0f53;

		L1054:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].MovementType != UnitMovementTypeEnum.Land)
				goto L1075;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x11a));
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word - 0x44)));
			goto L10c7;

		L1075:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13e));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			if (this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13e))].Attack < 8)
				goto L0f53;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.ADD_UInt16(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.CX.Word = (ushort)this.oGameData.Players[playerID].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))];
			this.oCPU.CX.Word = this.oCPU.SHL_UInt16(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word += (ushort)this.oGameData.Players[playerID].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))];
			
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.DX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13e));
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oGameData.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13e))].Attack;
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = (ushort)this.oGameData.Players[playerID].UnitCount;
			this.oCPU.CX.Word = this.oCPU.INC_UInt16(this.oCPU.CX.Word);
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

		L10c7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L10f0;

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].UnitCategory != 2)
				goto L0f53;

			this.oCPU.AX.Word = 0x2;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);

		L10f0:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.SI.Word = (ushort)((short)this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].UnitCategory);

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].UnitCategory != 2 &&
				this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].UnitCategory != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134),
					this.oCPU.SHL_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x1));

				if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x142)) !=
					this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].UnitCategory)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134),
						this.oCPU.SHL_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x1));
				}
			}

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].UnitCategory != 5)
				goto L113c;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x142)), 0x5);
			if (this.oCPU.Flags.E) goto L112c;
			goto L0f53;

		L112c:
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);

		L113c:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x0);
			if (this.oCPU.Flags.E)
			{
				if ((this.oGameData.Cities[cityID].ImprovementFlags0 & 0x4) != 0)
				{
					this.oCPU.AX.Word = 0x4;
				}
				else
				{
					this.oCPU.AX.Word = 0x6;
				}

				this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word,
					(ushort)this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Ideology);
			}
			else
			{
				this.oCPU.AX.Word = 0x10;
			}

			this.oCPU.CX.Word = (ushort)((short)this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].Price);
			this.oCPU.CX.Word = this.oCPU.INC_UInt16(this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.INC_UInt16(this.oCPU.CX.Word);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)((short)this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].AttackStrength);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word,
				(ushort)((short)this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].DefenseStrength));
			this.oCPU.BX.Word = (ushort)((short)this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].MoveCount);

			this.oCPU.BX.Word = this.oCPU.INC_UInt16(this.oCPU.BX.Word);
			this.oCPU.DI.Word = this.oCPU.DX.Word;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.DX.Word = this.oCPU.DI.Word;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].UnitCategory == 3)
			{
				if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13c)) != 0)
				{
					this.oCPU.AX.Word = 0x4;
				}
				else
				{
					this.oCPU.AX.Word = 0x2;
				}

				this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)));
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			}

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].MovementType != UnitMovementTypeEnum.Water)
				goto L11d9;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.SHL_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x1));

		L11d9:
			if (this.oGameData.Players[playerID].UnitCount > 120)
			{
				this.oCPU.CX.Low = 0x2;
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), 
					this.oCPU.SHL_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), this.oCPU.CX.Low));
			}

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13c)), 0x0);
			if (this.oCPU.Flags.NE) goto L11fb;

			if (this.oParent.Array_70da[1] <= this.oParent.Var_deb8)
				goto L1202;

		L11fb:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6ed4), 0x0);
			if (this.oCPU.Flags.NE) goto L1206;

		L1202:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.SHL_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x1));

		L1206:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L121e;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x144), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), this.oCPU.AX.Word);

		L121e:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x0);
			if (this.oCPU.Flags.L) goto L122a;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x1a);
			if (this.oCPU.Flags.L) goto L1249;

		L122a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x130));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1237;
			goto L0f53;

		L1237:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x130), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);
			goto L0f53;

		L1249:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11e));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1256;
			goto L0f53;

		L1256:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x11e), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe0));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			goto L0f53;

		L1268:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x140));
			this.oGameData.Players[playerID].UnitCount = 
				(short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TEST_UInt16(this.oCPU.AX.Word, (ushort)this.oGameData.HumanPlayerBitFlag);
			if (this.oCPU.Flags.NE) goto L12a5;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMP_UInt8((byte)this.oGameData.Cities[cityID].CurrentProductionID, 0xff);
			if (this.oCPU.Flags.NE) goto L1298;
			this.oCPU.AX.Word = 0xffff;
			goto L14e7;

		L1298:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x144));

		L129c:
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xde));
			goto L14e7;

		L12a5:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TEST_UInt8(this.oGameData.Cities[cityID].StatusFlag, 0x10);
			if (this.oCPU.Flags.E) goto L12cd;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xffff);
			if (this.oCPU.Flags.E) goto L12c7;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x130)), 0x1f4);
			if (this.oCPU.Flags.G) goto L12c7;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			goto L129c;

		L12c7:
			this.oCPU.AX.Word = 0x63;
			goto L14e7;

		L12cd:
			this.oCPU.TEST_UInt8((byte)(this.oGameData.GameSettingFlags & 0xff), 0x1);
			if (this.oCPU.Flags.NE) goto L12d7;
			goto L1438;

		L12d7:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.E) goto L12e0;
			goto L1438;

		L12e0:
			this.oParent.Var_aa_Rectangle.FontID = 2;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xffff);
			if (this.oCPU.Flags.NE) goto L12f2;
			goto L1388;

		L12f2:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xde));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L130f;

			// Instruction address 0x1ade:0x1323, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x12d), 
				this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134))].Name);

			goto L131d;

		L130f:
			// Instruction address 0x1ade:0x1323, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x12d), 
				this.oGameData.Static.ImprovementDefinitions(-this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134))).Name);

		L131d:
			// Instruction address 0x1ade:0x1333, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Military Advisor:\n");

			// Instruction address 0x1ade:0x1344, size: 5
			this.oParent.LanguageTools.F0_2f4d_01ad_GetTextBySectionAndKey("PRODUCE", (ushort)(this.oCPU.BP.Word - 0x12e));

			// Instruction address 0x1ade:0x1355, size: 5
			this.oParent.Array_30b8[3] = this.oCPU.ReadString(this.oCPU.DS.Word, (ushort)(this.oCPU.BP.Word - 0x12d));

			// Instruction address 0x1ade:0x135d, size: 5
			this.oCPU.WriteString(VCPU.ToLinearAddress(this.oCPU.DS.Word, 0xba06),
				this.oParent.LanguageTools.F0_2f4d_0471_ReplaceKeywords(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, 0xba06))));

			// Instruction address 0x1ade:0x1366, size: 5
			this.oParent.LanguageTools.F0_2f4d_0000_AdjustLineWidth(50);

			this.oParent.Var_db38 = 1;

			// Instruction address 0x1ade:0x1380, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 8, 160, 1);

		L1388:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1391;
			goto L1427;

		L1391:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xde));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L13ae;

			// Instruction address 0x1ade:0x13c2, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x12d),
				this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134))].Name);

			goto L13bc;

		L13ae:
			// Instruction address 0x1ade:0x13c2, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x12d),
				this.oGameData.Static.ImprovementDefinitions(-this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134))).Name);

		L13bc:
			// Instruction address 0x1ade:0x13d2, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Domestic Advisor:\n");

			// Instruction address 0x1ade:0x13e3, size: 5
			this.oParent.LanguageTools.F0_2f4d_01ad_GetTextBySectionAndKey("PRODUCE", (ushort)(this.oCPU.BP.Word - 0x12e));

			// Instruction address 0x1ade:0x13f4, size: 5
			this.oParent.Array_30b8[3] = this.oCPU.ReadString(this.oCPU.DS.Word, (ushort)(this.oCPU.BP.Word - 0x12d));

			// Instruction address 0x1ade:0x13fc, size: 5
			this.oCPU.WriteString(VCPU.ToLinearAddress(this.oCPU.DS.Word, 0xba06),
				this.oParent.LanguageTools.F0_2f4d_0471_ReplaceKeywords(this.oCPU.ReadString(VCPU.ToLinearAddress(this.oCPU.DS.Word, 0xba06))));

			// Instruction address 0x1ade:0x1405, size: 5
			this.oParent.LanguageTools.F0_2f4d_0000_AdjustLineWidth(50);

			this.oParent.Var_db38 = 1;

			// Instruction address 0x1ade:0x141f, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 164, 160, 1);

		L1427:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			goto L0447;

		L1438:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x14);
			if (this.oCPU.Flags.G) goto L1445;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13a)), 0x0);
			if (this.oCPU.Flags.E) goto L144e;

		L1445:
			this.oParent.Var_aa_Rectangle.FontID = 2;

		L144e:
			this.oParent.MenuBoxDialog.Var_2fa0 = 1;

			// Instruction address 0x1ade:0x1460, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 80, 8, 1);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0xdc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0x63);
			if (this.oCPU.Flags.NE) goto L1482;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x13a), 0x2);
			goto L0447;

		L1482:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x62);
			if (this.oCPU.Flags.NE) goto L148c;
			goto L0901;

		L148c:
			this.oParent.Var_aa_Rectangle.FontID = 1;

			if (this.oParent.Var_2f9c == 0) goto L14e3;

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x1);
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 0x0);
			if (this.oCPU.Flags.L) goto L14bd;

			this.oParent.Civilopedia.F8_0000_062a(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134)), 2);

			goto L14c8;

		L14bd:
			this.oParent.Civilopedia.F8_0000_062a((ushort)(-this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134))), 1);

		L14c8:
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oParent.Var_6b64 = 1;

			goto L0447;

		L14e3:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x134));

		L14e7:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_0421");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <param name="cost"></param>
		public void F0_1ade_14ed(short cityID, int cost)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_14ed({cityID}, {cost})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x2);
			
			// Instruction address 0x1ade:0x150b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.Array_70da[1] - this.oParent.Var_d2f6, 1, 99);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x152d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(((10 * cost) - this.oGameData.Cities[cityID].ShieldsCount - 1) / (short)this.oCPU.CX.Word) + 1,
				1, 999);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x1ade:0x1540, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " (");

			// Instruction address 0x1ade:0x1560, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 10));

			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) != 1)
			{
				// Instruction address 0x1ade:0x157b, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " turns");
			}
			else
			{
				// Instruction address 0x1ade:0x157b, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " turn");
			}

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_14ed");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="playerID1"></param>
		public ushort F0_1ade_1584(short playerID, short playerID1)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_1584({playerID}, {playerID1})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x46);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			if (playerID != 0)
				goto L1597;

		L1591:
			this.oCPU.AX.Word = 0xffff;
			goto L1d29;

		L1597:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x0);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x0);

		L15aa:
			// Instruction address 0x1ade:0x15b1, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L162c;

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x15cd, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, 
				(int)this.oGameData.Static.Technologies[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].RequiresTechnology1);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L162c;

			// Instruction address 0x1ade:0x15e1, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, 
				(int)this.oGameData.Static.Technologies[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].RequiresTechnology2);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) 
				goto L162c;

			// Instruction address 0x1ade:0x15f2, size: 3
			F0_1ade_2317(playerID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));

			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, 0x1);
			
			// Instruction address 0x1ade:0x15fd, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oCPU.AX.Word));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L162c;
			this.oCPU.AX.Word = (ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1620;
			
			if (playerID == this.oGameData.HumanPlayerID)
				goto L162c;

		L1620:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

		L162c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x48);
			if (this.oCPU.Flags.GE) goto L1638;
			goto L15aa;

		L1638:			
			if (playerID != this.oGameData.HumanPlayerID)
				goto L1647;

			if (this.oGameData.TurnCount != 0) 
				goto L16a5;

		L1647:
			if (this.oGameData.TurnCount == 0) goto L167a;
			if (this.oGameData.DifficultyLevel != 0) goto L167a;

			// Instruction address 0x1ade:0x165d, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) 
				goto L167a;

			// Instruction address 0x1ade:0x166b, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L167a;
			goto L1591;

		L167a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0xffff);
			if (this.oCPU.Flags.E) goto L169f;

			// Instruction address 0x1ade:0x168a, size: 3
			F0_1ade_1d2e(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				playerID1);
			
			// Instruction address 0x1ade:0x1697, size: 5
			this.oParent.Segment_25fb.F0_25fb_3459(playerID, 0xffff);

		L169f:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			goto L1d29;

		L16a5:
			if (this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID != -1) goto L16af;
			goto L19d4;

		L16af:
			this.oParent.Civilopedia.F8_0000_16c4((ushort)this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x0);
			
			if (this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID == 71) goto L16f1;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeba), 0x3);
			if (this.oCPU.Flags.LE) goto L16f1;

			this.oCPU.TEST_UInt8((byte)(this.oGameData.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.E) goto L16f1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x1);

		L16f1:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x0);
			if (this.oCPU.Flags.NE) goto L16fa;
			goto L178c;

		L16fa:
			// Instruction address 0x1ade:0x1707, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "discovr1.pic");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);

			// Instruction address 0x1ade:0x171d, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, (int)TechnologyEnum.Electricity);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) 
				goto L1730;

			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x9), 0x32);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x1);

		L1730:
			// Instruction address 0x1ade:0x1738, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			// Instruction address 0x1ade:0x1753, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, 0);

			// Instruction address 0x1ade:0x175b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x1ade:0x1764, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 1);

			// Instruction address 0x1ade:0x1784, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

		L178c:
			// Instruction address 0x1ade:0x1799, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nationality);

			// Instruction address 0x1ade:0x17aa, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, (int)TechnologyEnum.Invention);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x1ade:0x17c1, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " scientists");
			}
			else
			{
				// Instruction address 0x1ade:0x17c1, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " wise men");
			}

			// Instruction address 0x1ade:0x17d1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\ndiscover the secret\nof ");

			// Instruction address 0x1ade:0x17e8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Static.Technologies[this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID].Name);

			if (this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID != 71) goto L182c;

			// Instruction address 0x1ade:0x17ff, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			this.oGameData.Players[this.oGameData.HumanPlayerID].FutureTechnologyCount++;

			// Instruction address 0x1ade:0x1824, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oGameData.Players[this.oGameData.HumanPlayerID].FutureTechnologyCount, 10));

		L182c:
			// Instruction address 0x1ade:0x1834, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");
			
			// Instruction address 0x1ade:0x184e, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].ShortTune, 0);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x0);
			if (this.oCPU.Flags.NE) goto L185f;
			goto L19a5;

		L185f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.NE) goto L186e;

			this.oParent.Var_aa_Rectangle.FontID = 6;

		L186e:
			this.oParent.Var_db38 = 1;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.E) goto L187f;
			this.oCPU.AX.Word = 25;
			goto L1882;

		L187f:
			this.oCPU.AX.Word = 1;

		L1882:
			// Instruction address 0x1ade:0x188b, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 96, (short)this.oCPU.AX.Word, 1);

			this.oParent.Var_aa_Rectangle.FontID = 1;

			// Instruction address 0x1ade:0x18a4, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "iconpg1.pic");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x9;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba0c, this.oCPU.ADD_UInt8(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba0c), this.oCPU.AX.Low));

			// Instruction address 0x1ade:0x18d3, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0xba06, 0);

			this.oParent.Civilopedia.F8_0000_16f7(
				(ushort)(((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)) % 3) * 111) + 1),
				(ushort)((((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)) % 9) / 3) * 69) + 1),
				110,
				68,
				174,
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) != 0 ? 87 : 96));

			// Instruction address 0x1ade:0x1948, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x8), ".pal");

			// Instruction address 0x1ade:0x1958, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0xc1d6);

			// Instruction address 0x1ade:0x1968, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, "iconpg1.pal", 0xc5be);

			// Instruction address 0x1ade:0x197c, size: 5
			this.oParent.MSCAPI.memcpy(0xc5c4, 0xc1dc, 0xff);

			// Instruction address 0x1ade:0x198c, size: 5
			this.oParent.Segment_1000.F0_1000_04aa_TransformPalette(30, 0xc5be);

			// Instruction address 0x1ade:0x1994, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x1ade:0x199e, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0626();

			goto L19b1;

		L19a5:
			this.oParent.Overlay_21.F21_0000_0000(-1);

		L19b1:
			// Instruction address 0x1ade:0x19bc, size: 3
			F0_1ade_1d2e(playerID,
				this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID,
				playerID1);
			
			// Instruction address 0x1ade:0x19c6, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID = -1;

		L19d4:
			if (this.oGameData.Players[playerID].DiscoveredTechnologyCount <= 1)
			{
				this.oParent.Help.F4_0000_02d3(0x231d);
			}

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 320, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.TEST_UInt8((byte)(this.oGameData.GameSettingFlags & 0xff), 0x1);
			if (this.oCPU.Flags.NE) goto L1a05;
			goto L1b3d;

		L1a05:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1a0e;
			goto L1b3d;

		L1a0e:
			if (this.oGameData.DifficultyLevel == 0) goto L1a18;
			goto L1b3d;

		L1a18:
			// Instruction address 0x1ade:0x1a20, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Science Advisor:\nI recommend we\ndevelop ");

			// Instruction address 0x1ade:0x1a36, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Static.Technologies[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Name);

			// Instruction address 0x1ade:0x1a46, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x1ade:0x1a52, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);

			// Instruction address 0x1ade:0x1a6a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "So we can build:\n-");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);

		L1a77:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))].RequiresTechnology ==
				(TechnologyEnum)this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)))
			{
				// Instruction address 0x1ade:0x1a92, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))].Name);

				// Instruction address 0x1ade:0x1aa2, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\n-");

				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x1c);
			if (this.oCPU.Flags.L) goto L1a77;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0x0);

		L1abb:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((int)this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))).RequiresTechnology != this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)))
				goto L1af1;

			// Instruction address 0x1ade:0x1ad6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, 
				this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))).Name);

			// Instruction address 0x1ade:0x1ae6, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n-");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

		L1af1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 0x18);
			if (this.oCPU.Flags.L) goto L1abb;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.NE) goto L1b08;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L1b08:
			this.oParent.Var_aa_Rectangle.FontID = 2;

			this.oParent.Var_db38 = 1;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, 0xa8);
			this.oCPU.AX.Word = this.oCPU.NEG_UInt16(this.oCPU.AX.Word);
			// Instruction address 0x1ade:0x1b2c, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 8, (short)this.oCPU.AX.Word, 1);

			this.oParent.Var_aa_Rectangle.FontID = 1;

		L1b3d:
			// Instruction address 0x1ade:0x1b45, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Which discovery should our\n");

			// Instruction address 0x1ade:0x1b56, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, (int)TechnologyEnum.Invention);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				// Instruction address 0x1ade:0x1b6d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "scientists");
			}
			else
			{
				// Instruction address 0x1ade:0x1b6d, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "wise men");
			}

			// Instruction address 0x1ade:0x1b7d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " be pursuing, sire?\nPick one...\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x0);

		L1b8f:
			// Instruction address 0x1ade:0x1b96, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L1ba3;

			goto L1c46;

		L1ba3:
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1ade:0x1bb5, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, 
				(int)this.oGameData.Static.Technologies[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].RequiresTechnology1);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L1bc2;

			goto L1c46;

		L1bc2:
			// Instruction address 0x1ade:0x1bcc, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID,
				(int)this.oGameData.Static.Technologies[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].RequiresTechnology2);

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L1c46;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x0);
			if (this.oCPU.Flags.NE) goto L1bff;
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1);
			if (this.oCPU.Flags.LE) goto L1c12;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.AX.Word -= (ushort)this.oGameData.Players[playerID].DiscoveredTechnologyCount;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.OR_UInt16(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L1c12;
			if (this.oGameData.DifficultyLevel == 0) goto L1c12;

		L1bff:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x0);
			if (this.oCPU.Flags.E) goto L1c46;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x3a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1c46;

		L1c12:
			// Instruction address 0x1ade:0x1c20, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Static.Technologies[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))].Name);

			// Instruction address 0x1ade:0x1c30, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x3a), this.oCPU.AX.Word);

		L1c46:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0x48);
			if (this.oCPU.Flags.GE) goto L1c52;
			goto L1b8f;

		L1c52:
			this.oParent.Var_2f9e = 6;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x0);
			if (this.oCPU.Flags.E) goto L1cca;

			this.oParent.MenuBoxDialog.Var_2fa0 = 1;

			// Instruction address 0x1ade:0x1c70, size: 5
			this.oParent.MenuBoxDialog.F0_2d05_0031_ShowMenuBox(0xba06, 80, 64, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);

			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle, 0, 0, 320, 200, this.oParent.Var_aa_Rectangle, 0, 0);

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1c95;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x0);

		L1c95:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x3a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);

			if (this.oParent.Var_2f9c == 0) goto L1cc2;

			this.oParent.Civilopedia.F8_0000_062a(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), 0);
			
			// Instruction address 0x1ade:0x1cb5, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0x1);
			goto L1638;

		L1cc2:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID = (short)this.oCPU.AX.Word;
			goto L1d26;

		L1cca:
			// Instruction address 0x1ade:0x1cd2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Future Technology ");

			// Instruction address 0x1ade:0x1cf4, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(this.oGameData.Players[this.oGameData.HumanPlayerID].FutureTechnologyCount + 1), 10));

			// Instruction address 0x1ade:0x1d04, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n");

			// Instruction address 0x1ade:0x1d18, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oGameData.Players[this.oGameData.HumanPlayerID].CurrentResearchID = 71;

		L1d26:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));

		L1d29:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_1584");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="technologyID"></param>
		/// <param name="playerID1"></param>
		public void F0_1ade_1d2e(short playerID, short technologyID, short playerID1)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_1d2e({playerID}, {technologyID}, {playerID1})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUB_UInt16(this.oCPU.SP.Word, 0x8);
			this.oCPU.PUSH_UInt16(this.oCPU.DI.Word);
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			// Instruction address 0x1ade:0x1d3d, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, technologyID);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L1d4a;

			goto L22af;

		L1d4a:
			if (technologyID == 0x47) goto L1d9e;

			this.oCPU.AX.Word = (ushort)technologyID;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x10;
			this.oCPU.IDIV_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.AX.Word = this.oCPU.SHL_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)technologyID;
			this.oCPU.SI.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SAR_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XOR_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUB_UInt16(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, 0x1);

			this.oGameData.Players[playerID].DiscoveredTechnologyFlags[this.oCPU.AX.Word] |= this.oCPU.SI.Word;
			this.oGameData.Players[playerID].TechnologyAcquiredFrom[technologyID] = playerID1;

		L1d9e:
			if (this.oGameData.TurnCount == 0)
				goto L22af;

			this.oGameData.Players[playerID].DiscoveredTechnologyCount++;

			if (playerID == this.oGameData.HumanPlayerID) goto L1dce;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHL_UInt16(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID] & 0x40) == 0)
				goto L1f47;

		L1dce:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1ade:0x1de0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID].Nation);

			if (playerID == playerID1 ||
				playerID1 == 0)
			{
				// Instruction address 0x1ade:0x1e01, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " develop\n");
			}
			else
			{
				// Instruction address 0x1ade:0x1e01, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " acquire\n");
			}

			// Instruction address 0x1ade:0x1e17, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Technologies[technologyID].Name);

			if (playerID == playerID1) goto L1e5c;
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1e5c;

			// Instruction address 0x1ade:0x1e33, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " from\nthe ");

			if (playerID1 != -2) goto L1e47;

			// Instruction address 0x1ade:0x1e54, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Great Library");
			goto L1e5c;

		L1e47:
			// Instruction address 0x1ade:0x1e54, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Players[playerID1].Nation);

		L1e5c:
			// Instruction address 0x1ade:0x1e64, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n ");

			if (playerID == this.oGameData.HumanPlayerID)
				goto L1ef9;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L1e7c:
			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((int)this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))).RequiresTechnology != technologyID)
				goto L1eaf;

			// Instruction address 0x1ade:0x1e97, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oGameData.Static.ImprovementDefinitions(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))).Name);

			// Instruction address 0x1ade:0x1ea7, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

		L1eaf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x18);
			if (this.oCPU.Flags.L) goto L1e7c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L1ebd:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].RequiresTechnology == (TechnologyEnum)technologyID)
			{
				// Instruction address 0x1ade:0x1ed8, size: 5
				this.oParent.MSCAPI.strcat(0xba06,
					this.oGameData.Static.Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Name);

				// Instruction address 0x1ade:0x1ee8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "\n ");
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INC_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1c);
			if (this.oCPU.Flags.L) goto L1ebd;

		L1ef9:
			if (playerID != this.oGameData.HumanPlayerID) goto L1f0a;

			if (playerID1 != -2)
				goto L2013;

		L1f0a:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.E) goto L1f14;
			goto L2013;

		L1f14:
			this.oParent.Var_d206 = 1;

			if (playerID == this.oGameData.HumanPlayerID) goto L1f2a;

			this.oParent.Var_2f9e = 0;

			goto L1f30;

		L1f2a:
			this.oParent.Var_2f9e = 6;

		L1f30:
			// Instruction address 0x1ade:0x1f3c, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			goto L2013;

		L1f47:
			this.oCPU.TEST_UInt8((byte)this.oGameData.TechnologyFirstDiscoveredBy[technologyID], 0x7);
			if (this.oCPU.Flags.E) goto L1f5b;
			goto L2013;

		L1f5b:
			// Instruction address 0x1ade:0x1f63, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(playerID, (int)TechnologyEnum.Navigation);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L1f70;

			goto L2013;

		L1f70:
			// Instruction address 0x1ade:0x1f78, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology(this.oGameData.HumanPlayerID, technologyID);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L1f85;

			goto L2013;

		L1f85:
			// Instruction address 0x1ade:0x1f89, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2013;

			this.oParent.MeetWithKing.F6_0000_16cd(playerID, -1, 0);
			
			this.oCPU.AX.Word = this.oCPU.INC_UInt16(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2013;
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3934, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd804, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1ade:0x1fc4, size: 5
			this.oParent.Array_30b8[0] = this.oGameData.Players[playerID].Nation;

			// Instruction address 0x1ade:0x1fda, size: 5
			this.oParent.Array_30b8[3] = this.oGameData.Static.Technologies[technologyID].Name;

			// Instruction address 0x1ade:0x1fe6, size: 5
			this.oParent.LanguageTools.F0_2f4d_044f_GetAndAdjustLanguageItemFromKingSection(0x240e);

			this.oParent.Var_3936 = 2;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			this.oParent.MeetWithKing.F6_0000_251d(0xba06, 0x14, 0x8b);

			this.oParent.MeetWithKing.F6_0000_16ac();

		L2013:
			if (playerID != this.oGameData.HumanPlayerID) goto L2065;

			if (technologyID == 0x47) goto L202f;

			this.oParent.Civilopedia.F8_0000_062a((ushort)technologyID, 0);

		L202f:
			if (technologyID != 0x14) goto L203f;

			this.oParent.StartGameMenu.F5_0000_1af6_LoadGovernmentImage();

			// Instruction address 0x1ade:0x203a, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

		L203f:
			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.E) goto L2049;
			goto L20d9;

		L2049:
			// Instruction address 0x1ade:0x2049, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();
			
			if (technologyID != 0x5)
				goto L20d9;

			this.oParent.Help.F4_0000_02d3(0x2414);
			
			goto L20d9;

		L2065:
			if (this.oGameData.DifficultyLevel != 0 ||
				technologyID != 0x16) goto L20d9;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			this.oCPU.DI.Word = (ushort)this.oGameData.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHL_UInt16(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADD_UInt16(this.oCPU.DI.Word, this.oCPU.SI.Word);

			// Exchange of Ambassadors, rule is never invoked!
			// This piece of code is always skipped, as the result is always 0 or 1, and bit 0x40 is always 0!
			//
			// this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.DI.Word), 0x1);
			// this.oCPU.AX.Word = this.oCPU.SBBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			// this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			// this.oCPU.TESTByte(this.oCPU.AX.Low, 0x40);
			if (((this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID] == 0 ? 1 : 0) & 0x40) == 0)
				goto L20d9;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.NE) goto L20d9;

			this.oGameData.Players[this.oGameData.HumanPlayerID].Diplomacy[playerID] |= 0x40;

			// Instruction address 0x1ade:0x20a2, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Players[playerID].Nation);

			// Instruction address 0x1ade:0x20b2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " agree to\nan exchange of ambassadors.\n");

			this.oParent.Var_2f9e = 1;

			// Instruction address 0x1ade:0x20cc, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 100);

			this.oParent.Overlay_14.F14_0000_0d43();

		L20d9:
			if (technologyID != 0x22 && technologyID != 0x25)
				goto L2174;

			for (int i = 0; i < 128; i++)
			{
				if (this.oGameData.Cities[i].StatusFlag != 0xff &&
					this.oGameData.Cities[i].PlayerID == playerID)
				{
					this.oGameData.Cities[i].ImprovementFlags0 &= 0xfffd;
				}
			}

			if (playerID != this.oGameData.HumanPlayerID)
				goto L2174;

			this.oCPU.CMP_UInt16(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.NE) goto L2174;

			// Instruction address 0x1ade:0x212c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Development of ");

			// Instruction address 0x1ade:0x2142, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oGameData.Static.Technologies[technologyID].Name);

			// Instruction address 0x1ade:0x2152, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\nmakes existing Barracks\nobsolete.\n");

			this.oParent.Var_2f9e = 3;

			// Instruction address 0x1ade:0x216c, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 100);

		L2174:
			this.oCPU.TEST_UInt8((byte)this.oGameData.TechnologyFirstDiscoveredBy[technologyID], 0x7);
			if (this.oCPU.Flags.E) goto L2188;
			goto L2234;

		L2188:
			this.oGameData.TechnologyFirstDiscoveredBy[technologyID] = playerID;

			// Instruction address 0x1ade:0x21a1, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(5, (byte)playerID, (byte)technologyID);

			for (int i = 1; i < 22; i++)
			{
				if (this.oGameData.WonderCityID[i] != -1 &&
					this.oGameData.Static.Wonders[i].ObsoletesAfterTechnology == (TechnologyEnum)technologyID)
				{
					if (this.oGameData.Cities[this.oGameData.WonderCityID[i]].PlayerID == this.oGameData.HumanPlayerID)
					{
						// Instruction address 0x1ade:0x21de, size: 5
						this.oParent.MSCAPI.strcpy(0xba06, this.oGameData.Static.Technologies[technologyID].Name);

						// Instruction address 0x1ade:0x21ee, size: 5
						this.oParent.MSCAPI.strcat(0xba06, " cancels\nthe effect of\n");

						// Instruction address 0x1ade:0x2204, size: 5
						this.oParent.MSCAPI.strcat(0xba06,
							this.oGameData.Static.Wonders[i].Name);

						// Instruction address 0x1ade:0x2214, size: 5
						this.oParent.MSCAPI.strcat(0xba06, ".\n");

						this.oParent.Overlay_21.F21_0000_0000(-1);
					}
				}
			}

		L2234:
			this.oCPU.AX.Word = (ushort)this.oGameData.WonderCityID[5];
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMP_UInt16(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L22af;

			this.oCPU.AX.Word = (ushort)this.oGameData.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x1ade:0x2254, size: 3
			this.oCPU.AX.Word = F0_1ade_22b5_PlayerHasTechnology((short)this.oCPU.AX.Word, technologyID);
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L22af;

			// Instruction address 0x1ade:0x2265, size: 5
			this.oParent.CityWorker.F0_1d12_6c97_PlayerHasWonder(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), (int)WonderEnum.GreatLibrary);
			
			this.oCPU.AX.Word = this.oCPU.OR_UInt16(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L22af;

			int iCount = 0;

			for (int i = 1; i < 8; i++)
			{
				// Instruction address 0x1ade:0x2282, size: 3
				if (F0_1ade_22b5_PlayerHasTechnology((short)i, technologyID) != 0)
				{
					iCount++;
				}
			}

			if (iCount >= 2)
			{
				// Instruction address 0x1ade:0x22a9, size: 3
				F0_1ade_1d2e(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), technologyID, -2);
			}

		L22af:
			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.DI.Word = this.oCPU.POP_UInt16();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_1d2e");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="technologyID"></param>
		/// <returns></returns>
		public ushort F0_1ade_22b5_PlayerHasTechnology(short playerID, int technologyID)
		{
			// Everyone has TechnologyEnum.None (-1) technology,
			// PlayerID == 0 (Barbarians can't have any technology)
			// TechnologyID can be in the range [0-70]
			// DiscoveredTechnologyFlags holds the bit if technology is discovered

			return (ushort)((technologyID == -1 ||
				(playerID != 0 && (technologyID >= 0 && technologyID < 71) &&
					(this.oGameData.Players[playerID].DiscoveredTechnologyFlags[technologyID >> 4] & (1 << (technologyID & 0xf))) != 0)) ? 1 : 0);

			//return (ushort)((technologyID == -1 || (technologyID >= 0 && (technologyID >= 71 || playerID == 0 ||
			//	(this.oParent.CivState.Players[playerID].DiscoveredTechnologyFlags[technologyID >> 4] & (1 << (technologyID & 0xf))) == 0))) ? 0 : 1);
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		public ushort F0_1ade_2317(short playerID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_1ade_2317({playerID}, {param2})");

			// function body
			this.oCPU.PUSH_UInt16(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PUSH_UInt16(this.oCPU.SI.Word);

			this.oCPU.SI.Word = param2;
			this.oCPU.SI.Word = this.oCPU.SHL_UInt16(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb0a));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb0b));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oGameData.Static.Nations[this.oGameData.Players[playerID].NationalityID].Ideology;
			this.oCPU.IMUL_UInt16(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.ADD_UInt16(this.oCPU.AX.Word, this.oCPU.CX.Word);

			this.oCPU.SI.Word = this.oCPU.POP_UInt16();
			this.oCPU.BP.Word = this.oCPU.POP_UInt16();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1ade_2317");

			return this.oCPU.AX.Word;
		}
	}
}
