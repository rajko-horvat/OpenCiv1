using System;
using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class Segment_29f3
	{
		private Game oParent;
		private CPU oCPU;

		public Segment_29f3(Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID1"></param>
		/// <param name="unitID1"></param>
		/// <param name="playerID2"></param>
		/// <param name="unitID2"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F0_29f3_000e(short playerID1, short unitID1, short playerID2, short unitID2, ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F0_29f3_000e({playerID1}, {unitID1}, {playerID2}, {unitID2}, {flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x26);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
				(short)this.oParent.GameState.Players[playerID1].Units[unitID1].TypeID);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe),
				(short)this.oParent.GameState.Players[playerID2].Units[unitID2].TypeID);

			// Instruction address 0x29f3:0x0052, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].AttackStrength);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x0081, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L00ac;

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);

			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, 
				(ushort)((short)this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].DefenseStrength));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);

			goto L0105;

		L00ac:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.GameState.Players[playerID2].Units[unitID2].Status & 0x8) == 0)
				goto L00e8;

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);

			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, 
				(ushort)((short)this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].DefenseStrength));

			this.oCPU.CX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			goto L0105;

		L00e8:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)((short)this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].DefenseStrength));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);

		L0105:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.CMPWord((ushort)playerID1, 0x0);
			if (this.oCPU.Flags.NE) goto L013c;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0130;
			this.oCPU.CX.Word = (ushort)this.oParent.GameState.DifficultyLevel;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			goto L0139;

		L0130:
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

		L0139:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L013c:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].TerrainCategory == 1)
				goto L0152;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].TerrainCategory != 2)
				goto L0165;

		L0152:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].DefenseStrength);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

		L0165:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x0186, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0195;
			goto L0229;

		L0195:
			// Instruction address 0x29f3:0x01a1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BuildingFlags0, 0x80);
			if (this.oCPU.Flags.E) goto L01f2;

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].AttackStrength == 12)
				goto L01f2;
			
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].TerrainCategory == 1)
				goto L01f2;

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)((short)this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].DefenseStrength));
			this.oCPU.CX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

		L01f2:
			this.oCPU.CMPWord((ushort)playerID1, 0x0);
			if (this.oCPU.Flags.NE) goto L0229;

			if (this.oParent.GameState.Players[playerID2].CityCount == 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			}

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L0224;
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L0224:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x1);

		L0229:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.GameState.Players[playerID1].Units[unitID1].Status & 0x20) != 0)
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
					this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			}

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.GameState.Players[playerID2].Units[unitID2].Status & 0x20) != 0)
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
				this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
				this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
				this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 
					this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), this.oCPU.AX.Word));
			}

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oParent.GameState.Players[playerID1].Units[unitID1].RemainingMoves);

			if (this.oParent.GameState.Players[playerID1].Units[unitID1].RemainingMoves < 3)
			{
				this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10),
					(short)((this.oParent.GameState.Players[playerID1].Units[unitID1].RemainingMoves * this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))) / 3));
			}

			this.oCPU.CMPWord(flag, 0x0);
			if (this.oCPU.Flags.NE) goto L02ac;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			goto L0b60;

		L02ac:
			this.oCPU.CMPWord((ushort)playerID1, 0x0);
			if (this.oCPU.Flags.E) goto L02df;
			if (this.oParent.GameState.DifficultyLevel > 1) goto L02cd;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L02cd;
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L02cd:
			if (this.oParent.GameState.DifficultyLevel != 0) goto L02df;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L02df;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x1));

		L02df:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L030f;
			
			// Instruction address 0x29f3:0x02eb, size: 3
			F0_29f3_0c9e(playerID2);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L030f;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID1].Units[unitID1].GoToPosition.X = -1;

			this.oCPU.AX.Word = 0xffff;

			goto L0b60;

		L030f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

			// Instruction address 0x29f3:0x0317, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))));

			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x29f3:0x0324, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.LE) goto L0335;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x10);

		L0335:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x0);
			if (this.oCPU.Flags.E) goto L0362;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0362;

			// Instruction address 0x29f3:0x0344, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))));

			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x29f3:0x0351, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L0362;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L0362:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L03b4;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L03b4;
			this.oCPU.SI.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oParent.GameState.Players[playerID1].Units[unitID1].VisibleByPlayer;
			
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NE) goto L03b4;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oParent.GameState.Players[playerID2].Units[unitID2].VisibleByPlayer;
			
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NE) goto L03b4;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L03b4;
			goto L0721;

		L03b4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb278), 0x1);
			if (this.oCPU.Flags.NE) goto L03be;
			goto L0721;

		L03be:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x03de, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(this.oParent.GameState.HumanPlayerID,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

			// Instruction address 0x29f3:0x03e6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x0407, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oParent.GameState.Players[playerID1].Units[unitID1].Position.X, this.oParent.GameState.Players[playerID1].Units[unitID1].Position.Y);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0416;
			goto L071c;

		L0416:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L043f;

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].AttackStrength > 4)
				goto L043a;

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].DefenseStrength <= 2)
				goto L045d;

		L043a:
			this.oCPU.AX.Word = 0x1;
			goto L045f;

		L043f:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].AttackStrength > 4)
				goto L043a;

			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].DefenseStrength > 2)
				goto L043a;

		L045d:
			this.oCPU.AX.Word = 0;

		L045f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0473;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0xf);
			if (this.oCPU.Flags.NE) goto L0473;
			this.oCPU.AX.Word = 0x2b;
			goto L04ad;

		L0473:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) == 0)
				goto L0481;

			if (playerID1 == this.oParent.GameState.HumanPlayerID)
				goto L048f;

		L0481:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)) != 0 ||
				playerID2 != this.oParent.GameState.HumanPlayerID)
				goto L049f;

		L048f:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) != 0)
			{
				this.oCPU.AX.Word = 40;
			}
			else
			{
				this.oCPU.AX.Word = 38;
			}
			goto L04ad;

		L049f:
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) != 0)
			{
				this.oCPU.AX.Word = 41;
			}
			else
			{
				this.oCPU.AX.Word = 39;
			}

		L04ad:
			// Instruction address 0x29f3:0x04ae, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune((short)this.oCPU.AX.Word, 0);

			// Instruction address 0x29f3:0x04bc, size: 5
			this.oParent.Segment_2aea.F0_2aea_0e29(playerID2, unitID2);

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 
				(short)this.oParent.GameState.Players[playerID1].Units[unitID1].NextUnitID);

			if (this.oParent.GameState.Players[playerID1].Units[unitID1].NextUnitID == -1)
				goto L04ec;

			// Instruction address 0x29f3:0x04e4, size: 5
			this.oParent.Segment_2aea.F0_2aea_0e29(playerID1, this.oParent.GameState.Players[playerID1].Units[unitID1].NextUnitID);

		L04ec:
			// Instruction address 0x29f3:0x050a, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 80, 0, 240, 200, this.oParent.Var_19d4_Rectangle, 80, 0);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x052d, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oParent.GameState.Players[playerID1].Units[unitID1].Position.X - this.oParent.Var_d4cc_XPos);

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID1].Units[unitID1].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, (ushort)this.oParent.Var_d75e_YPos);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X);
			this.oCPU.CX.Word = (ushort)((short)this.oParent.GameState.Players[playerID1].Units[unitID1].Position.X);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = (ushort)Math.Sign((short)this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);
			this.oCPU.CX.Word = (ushort)((short)this.oParent.GameState.Players[playerID1].Units[unitID1].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = (ushort)Math.Sign((short)this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X != 0)
				goto L05a3;

			if (this.oParent.GameState.Players[playerID1].Units[unitID1].Position.X == 79)
				goto L05d1;

		L05a3:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X != 79)
				goto L05d9;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID1].Units[unitID1].Position.X != 0)
				goto L05d9;

		L05d1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

		L05d9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x0);

		L05de:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			// Instruction address 0x29f3:0x061e, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(short)this.oCPU.SI.Word + 1, (short)this.oCPU.DI.Word + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(((this.oParent.GameState.Players[playerID1].Units[unitID1].TypeID +
					(playerID1 << 5) + 0x40) << 1) + 0xd4ce)));

			// Instruction address 0x29f3:0x062a, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(2);

			// Instruction address 0x29f3:0x0643, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
				(short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word, 16, 16, this.oParent.Var_aa_Rectangle, (short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0xa);
			if (this.oCPU.Flags.LE) goto L05de;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x0670, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oParent.GameState.Players[playerID1].Units[unitID1].Position.X,
				this.oParent.GameState.Players[playerID1].Units[unitID1].Position.Y);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x0694, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

			// Instruction address 0x29f3:0x06b4, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_aa_Rectangle, 0, 0, 256, 200, this.oParent.Var_19d4_Rectangle, 0, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x0);

		L06c1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			// Instruction address 0x29f3:0x06e6, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(this.oParent.Var_aa_Rectangle,
				(short)this.oCPU.SI.Word + 1, (short)this.oCPU.DI.Word + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) + 0x20) << 1) + 0xd4ce)));

			// Instruction address 0x29f3:0x06f2, size: 5
			this.oParent.Segment_1000.F0_1182_0134_WaitTimer(4);

			// Instruction address 0x29f3:0x070b, size: 5
			this.oParent.Graphics.F0_VGA_07d8_DrawImage(this.oParent.Var_19d4_Rectangle,
				(short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word, 16, 16, this.oParent.Var_aa_Rectangle, (short)this.oCPU.SI.Word, (short)this.oCPU.DI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x8);
			if (this.oCPU.Flags.L) goto L06c1;

		L071c:
			// Instruction address 0x29f3:0x071c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L0721:
			this.oCPU.SI.Word = (ushort)playerID1;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID1].Diplomacy[playerID2] |= 0x20;

			this.oCPU.SI.Word = (ushort)playerID2;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID2].Diplomacy[playerID1] |= 0x20;

			this.oCPU.CMPWord((ushort)playerID1, 0x0);
			if (this.oCPU.Flags.E) goto L0753;
			this.oCPU.CMPWord((ushort)playerID2, 0x0);
			if (this.oCPU.Flags.E) goto L0753;
			this.oParent.GameState.PeaceTurnCount = 0;

		L0753:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L076e;
			
			this.oCPU.SI.Word = (ushort)playerID2;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID2].Diplomacy[playerID1] & 2) != 0)
				goto L0782;

		L076e:
			this.oCPU.SI.Word = (ushort)playerID1;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID1].Diplomacy[playerID2] & 0x200) == 0)
				goto L07e2;

		L0782:
			this.oParent.Var_2f9e_Unknown = 0x3;

			// Instruction address 0x29f3:0x0790, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Sneak attack by\n");

			// Instruction address 0x29f3:0x07a5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.Players[playerID1].Nationality);

			// Instruction address 0x29f3:0x07b5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " forces!\n");

			// Instruction address 0x29f3:0x07c9, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			
			this.oCPU.SI.Word = (ushort)playerID1;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID1].Diplomacy[playerID2] &= 0xfdff;

		L07e2:
			this.oCPU.SI.Word = (ushort)playerID2;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID2].Diplomacy[playerID1] & 2) != 0)
				goto L0809;

			this.oCPU.SI.Word = (ushort)playerID1;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID1].Diplomacy[playerID2] & 2) == 0)
				goto L08ae;

		L0809:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0816;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L087a;

		L0816:
			this.oParent.Var_2f9e_Unknown = 0x5;

			// Instruction address 0x29f3:0x0829, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.Players[playerID2].Nation);

			// Instruction address 0x29f3:0x0839, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " cancel\npeace treaty\nwith ");

			// Instruction address 0x29f3:0x084e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.Players[playerID1].Nation);

			// Instruction address 0x29f3:0x085e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x29f3:0x0872, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L087a:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L089c;

			this.oCPU.SI.Word = (ushort)playerID2;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = (ushort)playerID1;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if ((this.oParent.GameState.Players[playerID2].Diplomacy[playerID1] & 2) != 0)
			{
				this.oParent.GameState.Players[playerID2].Diplomacy[playerID1] |= 8;
			}

		L089c:
			// Instruction address 0x29f3:0x08a6, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(playerID1, playerID2, 2);

		L08ae:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L08c7;
			
			this.oCPU.SI.Word = (ushort)playerID2;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID2].Diplomacy[playerID1] &= 0xfdff;

		L08c7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x19);
			if (this.oCPU.Flags.NE) goto L08f9;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x08ed, size: 3
			F0_29f3_0d4d(playerID1,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

		L08f3:
			this.oCPU.AX.Word = 0x1;
			goto L0b60;

		L08f9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L0902;
			goto L0b1b;

		L0902:
			if (playerID2 == 0)
			{
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				if (this.oParent.GameState.Players[playerID2].Units[unitID2].TypeID == 26)
				{
					this.oParent.GameState.Players[playerID1].Coins += 100;

					if (playerID1 == this.oParent.GameState.HumanPlayerID)
					{
						this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

						// Instruction address 0x29f3:0x093a, size: 5
						this.oParent.Segment_2f4d.F0_2f4d_044f(0x2ae7);

						// Instruction address 0x29f3:0x094b, size: 5
						this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);
					}
				}
			}

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
			if (this.oCPU.Flags.E) goto L095c;
			goto L0a24;

		L095c:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x0978, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X,
				this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y);

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L0987;
			goto L0a24;

		L0987:
			// Instruction address 0x29f3:0x0991, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID2, unitID2, 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);

			this.oCPU.DI.Word = (ushort)playerID1;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID1].UnitsDestroyed[playerID2] += (short)this.oCPU.AX.Word;

			// Instruction address 0x29f3:0x09ba, size: 5
			this.oParent.Segment_1866.F0_1866_144b(playerID2, unitID2, 0xf10);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x1);
			if (this.oCPU.Flags.G) goto L09cb;
			goto L0af0;

		L09cb:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L09db;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L09db;
			goto L0af0;

		L09db:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x29f3:0x09f8, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 10));

			// Instruction address 0x29f3:0x0a08, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " units destroyed.\n");

			// Instruction address 0x29f3:0x0a19, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			goto L0af0;

		L0a24:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0a2d;
			goto L0ad2;

		L0a2d:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID2].Units[unitID2].NextUnitID != -1)
				goto L0ad2;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x8);

		L0a4c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))];

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), (short)(this.oParent.GameState.Players[playerID2].Units[unitID2].Position.X + direction.X));

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), (short)(this.oParent.GameState.Players[playerID2].Units[unitID2].Position.Y + direction.Y));

			// Instruction address 0x29f3:0x0a7f, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0aaf;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0aaf;

			// Instruction address 0x29f3:0x0aa7, size: 5
			this.oParent.Segment_1866.F0_1866_144b(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0x1593);

		L0aaf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			if (this.oCPU.Flags.NS) goto L0a4c;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].PlayerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x29f3:0x0aca, size: 5
				this.oParent.Segment_25fb.F0_25fb_3e9c(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			}

		L0ad2:
			// Instruction address 0x29f3:0x0ad8, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID2, unitID2);
			
			this.oCPU.SI.Word = (ushort)playerID1;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID1].UnitsDestroyed[playerID2]++;

		L0af0:
			// Instruction address 0x29f3:0x0af4, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0b03;
			goto L08f3;

		L0b03:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID1].Units[unitID1].Status |= 0x20;

			goto L08f3;

		L0b1b:
			this.oCPU.SI.Word = (ushort)playerID2;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID2].UnitsDestroyed[playerID1]++;

			// Instruction address 0x29f3:0x0b31, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID1, unitID1);

			// Instruction address 0x29f3:0x0b3d, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b5e;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID2].Units[unitID2].Status |= 0x20;

		L0b5e:
			this.oCPU.AX.Word = 0;

		L0b60:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_29f3_000e");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="nextUnitID"></param>
		public void F0_29f3_0b66(short playerID, short unitID, short nextUnitID)
		{
			this.oCPU.Log.EnterBlock($"F0_29f3_0b66({playerID}, {unitID}, {nextUnitID})");

			// function body
			if (this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID == -1)
			{
				this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID = unitID;
				this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID = nextUnitID;
			}
			else
			{
				this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID = this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID;
				this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID = unitID;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_29f3_0b66");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_29f3_0bc9(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_29f3_0bc9({playerID}, {unitID})");

			// function body
			short nextUnitID = (short)this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID;

			if (this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID != -1)
			{
				if (this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID == unitID)
				{
					this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID = -1;
				}
				else
				{
					int count = 0;

					do
					{
						nextUnitID = this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID;
						count++;
					} while (nextUnitID != -1 && count < 32 && this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID != unitID);

					if (count < 32 && nextUnitID != -1)
					{
						this.oParent.GameState.Players[playerID].Units[nextUnitID].NextUnitID =
							this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID;
					}
				}

				this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID = -1;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_29f3_0bc9");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <returns></returns>
		public ushort F0_29f3_0c9e(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_29f3_0c9e({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[playerID] & 2) == 0)
				goto L0d48;

			// Instruction address 0x29f3:0x0cc1, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "We have signed a\npeace treaty with\nthe ");

			// Instruction address 0x29f3:0x0cd1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.Players[playerID].Nation);

			// Instruction address 0x29f3:0x0ce1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n Cancel action.\n Break treaty.\n");

			this.oParent.Var_2f9e_Unknown = 0x5;

			// Instruction address 0x29f3:0x0cf8, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0d0a;

		L0d05:
			this.oCPU.AX.Word = 0xffff;
			goto L0d4a;

		L0d0a:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType < 4) goto L0d43;

			// Instruction address 0x29f3:0x0d1f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Overruled by\nthe Senate.\nAction canceled.\n");

			this.oParent.Var_2f9e_Unknown = 0x4;

			// Instruction address 0x29f3:0x0d39, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			goto L0d05;

		L0d43:
			this.oCPU.AX.Word = 0x1;
			goto L0d4a;

		L0d48:
			this.oCPU.AX.Word = 0;

		L0d4a:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_29f3_0c9e");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_29f3_0d4d(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_29f3_0d4d({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0d9b;

			this.oParent.Var_2f9e_Unknown = 0x3;

			// Instruction address 0x29f3:0x0d6f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.Players[playerID].Nation);

			// Instruction address 0x29f3:0x0d7f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " use\nnuclear weapons!\n");

			// Instruction address 0x29f3:0x0d93, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L0d9b:
			this.oParent.Overlay_22.F22_0000_0967(xPos, yPos);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x8);

		L0dae:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))];

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), (short)(xPos + direction.X));

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), (short)(yPos + direction.Y));

			// Instruction address 0x29f3:0x0dcb, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			// Instruction address 0x29f3:0x0ddc, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0e4d;

			// Instruction address 0x29f3:0x0dee, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].BuildingFlags1, 0x1);
			if (this.oCPU.Flags.E) goto L0e4d;

			// Instruction address 0x29f3:0x0e11, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "SDI protects ");

			// Instruction address 0x29f3:0x0e1c, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			// Instruction address 0x29f3:0x0e2c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x29f3:0x0e40, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0xffff);

		L0e4d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xffff);
			if (this.oCPU.Flags.E) goto L0ea9;

			// Instruction address 0x29f3:0x0e5e, size: 5
			this.oParent.Segment_1866.F0_1866_1251(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID].UnitsDestroyed[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0)] += (short)this.oCPU.AX.Word;

			// Instruction address 0x29f3:0x0e89, size: 5
			this.oParent.Segment_1866.F0_1866_144b(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xf10);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0ea9;
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0)].Diplomacy[playerID] |= 0x88;

		L0ea9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			if (this.oCPU.Flags.S) goto L0eb1;
			goto L0dae;

		L0eb1:
			// Instruction address 0x29f3:0x0eb8, size: 3
			F0_29f3_0ec3(xPos, yPos);
			
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_29f3_0d4d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_29f3_0ec3(int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_29f3_0ec3({xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0f13;

		L0ed1:
			// Instruction address 0x29f3:0x0ed5, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0f02;

			// Instruction address 0x29f3:0x0ee7, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0f02;

			// Instruction address 0x29f3:0x0efa, size: 5
			this.oParent.Segment_1d12.F0_1d12_6d33(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

		L0f02:
			// Instruction address 0x29f3:0x0f08, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0f13:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x8);
			if (this.oCPU.Flags.G) goto L0f73;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))];

			// Instruction address 0x29f3:0x0f26, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(xPos + direction.X);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), (short)(yPos + direction.Y));

			// Instruction address 0x29f3:0x0f3f, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0ed1;

			// Instruction address 0x29f3:0x0f51, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x2;
			this.oCPU.IDIVByte(this.oCPU.AX, this.oCPU.CX.Low);
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ActualSize -= (sbyte)this.oCPU.AX.Low;
			goto L0f02;

		L0f73:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_29f3_0ec3");
		}
	}
}
