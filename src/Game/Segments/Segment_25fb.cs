using System;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_25fb
	{
		private Game oParent;
		private CPU oCPU;

		public Segment_25fb(Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_25fb_0004(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_0004({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x68);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0x0);

		L0011:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].CityCount = 0;
			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Defense = 0;
			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Attack = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x10);
			if (this.oCPU.Flags.L) goto L0011;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0);
			goto L005e;

		L003b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52))));

		L003e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0xd);
			if (this.oCPU.Flags.GE) goto L005b;
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438), 0x0);
			goto L003b;

		L005b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));

		L005e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x14);
			if (this.oCPU.Flags.GE) goto L006b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 0x0);
			goto L003e;

		L006b:
			this.oParent.GameState.Players[playerID].MilitaryPower = 0;
			this.oParent.GameState.Players[playerID].SettlerCount = 0;
			this.oParent.GameState.Players[playerID].UnitCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0);
			goto L01b7;

		L0084:
			this.oParent.GameState.Players[playerID].UnitCount++;

		L008d:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].MilitaryPower +=
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID].AttackStrength;
			this.oParent.GameState.Players[playerID].MilitaryPower += 
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID].DefenseStrength;

			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Status &= 0xef;

			// Instruction address 0x25fb:0x00ca, size: 5
			this.oParent.Segment_1866.F0_1866_1750(playerID,
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L00db;

			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Status |= 0x10;

		L00db:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x00f7, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0148;

			// Instruction address 0x25fb:0x0110, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x64), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))].Attack +=
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID].DefenseStrength;
			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))].Defense +=
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID].AttackStrength;

			goto L016c;

		L0148:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID].TerrainCategory == 0)
			{
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Status |= 0x10;
			}

		L016c:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148));
			this.oCPU.AX.Low = 0x2;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x2);
			this.oCPU.BX.Word = 0xd;
			this.oCPU.MULWord(this.oCPU.DX, this.oCPU.AX, this.oCPU.BX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x2);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);

			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438), 
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438)), this.oCPU.CX.Low));

		L01b4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));

		L01b7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x80);
			if (this.oCPU.Flags.GE) goto L01f0;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x64), this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID == -1 ||
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID == 25)
				goto L01b4;

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID != 0)
				goto L0084;

			this.oParent.GameState.Players[playerID].SettlerCount++;

			goto L008d;

		L01f0:
			// Instruction address 0x25fb:0x0210, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.GameState.Players[playerID].UnitCount / 8, 3, 99);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oParent.GameState.Players[playerID].TotalCitySize = 0;
			this.oParent.GameState.Players[playerID].CityCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0);

		L0228:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))] = 0;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x1c);
			if (this.oCPU.Flags.L) goto L0228;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0x0);
			goto L03ed;

		L024c:
			this.oCPU.AX.Word = 0x5;

		L024f:
			// Instruction address 0x25fb:0x0264, size: 3
			F0_25fb_304d(playerID,
				(short)this.oParent.GameState.Cities[this.oCPU.SI.Word / 28].Position.X,
				(short)this.oParent.GameState.Cities[this.oCPU.SI.Word / 28].Position.Y,
				1, (short)this.oCPU.AX.Word);

			goto L0397;

		L026d:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oParent.GameState.Players[playerID].CityCount++;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x028a, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			this.oParent.GameState.Players[playerID].Continents[this.oCPU.AX.Word].CityCount++;

			this.oParent.GameState.Players[playerID].TotalCitySize +=
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].ActualSize;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].CurrentProductionID < 0)
				goto L02c8;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oParent.GameState.Players[playerID].UnitsInProduction[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].CurrentProductionID]++;

		L02c8:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.WriteUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438), this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438)), 0x1));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 0x0);

		L0304:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))], 0xff);
			if (this.oCPU.Flags.E) goto L038b;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))];
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x3f);
			this.oCPU.CX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x64), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].MilitaryPower += 
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))] & 0x3f].AttackStrength;
			this.oParent.GameState.Players[playerID].MilitaryPower +=
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))] & 0x3f].DefenseStrength;

			// Instruction address 0x25fb:0x0346, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))];
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x3f);
			this.oCPU.CX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x66), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x68), this.oCPU.AX.Word);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x66));

			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))].Attack =
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))] & 0x3f].DefenseStrength;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x66));

			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))].Defense +=
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))] & 0x3f].AttackStrength;

		L038b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c))));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x2);
			if (this.oCPU.Flags.GE) goto L0397;
			goto L0304;

		L0397:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x03ab, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L03ea;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Unknown[0], 0xff);
			if (this.oCPU.Flags.NE) goto L03ea;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L03cc;
			this.oCPU.AX.Word = 0x4;
			goto L03cf;

		L03cc:
			this.oCPU.AX.Word = 0x2;

		L03cf:
			// Instruction address 0x25fb:0x03e4, size: 3
			F0_25fb_304d(playerID,
				(short)this.oParent.GameState.Cities[this.oCPU.SI.Word / 28].Position.X,
				(short)this.oParent.GameState.Cities[this.oCPU.SI.Word / 28].Position.Y,
				2, (short)this.oCPU.AX.Word);

		L03ea:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));

		L03ed:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x80);
			if (this.oCPU.Flags.L) goto L03f7;
			goto L049d;

		L03f7:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L03ea;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].PlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NE) goto L041d;
			goto L026d;

		L041d:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.TurnCount;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.DifficultyLevel);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xc8);
			if (this.oCPU.Flags.G) goto L0458;

			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L0458;
			this.oCPU.CMPWord((ushort)this.oParent.GameState.HumanPlayerID, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NE) goto L0458;
			goto L0397;

		L0458:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.DI.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].PlayerID;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			
			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].PlayerID] & 0x102) == 2)
				goto L0397;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, (byte)(this.oParent.GameState.TurnCount & 0xff));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x3);
			if (this.oCPU.Flags.NE) goto L048d;
			goto L0397;

		L048d:
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].BuildingFlags0, 0x80);
			if (this.oCPU.Flags.NE) goto L0497;
			goto L024c;

		L0497:
			this.oCPU.AX.Word = 0x3;
			goto L024f;

		L049d:
			this.oParent.GameState.Players[playerID].LandCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 0x0);
			goto L04dd;

		L04af:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52))));

		L04b2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)), 0xd);
			if (this.oCPU.Flags.GE) goto L04da;
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438)), 0x0);
			if (this.oCPU.Flags.E) goto L04af;
			this.oParent.GameState.Players[playerID].LandCount++;
			goto L04af;

		L04da:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50))));

		L04dd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)), 0x14);
			if (this.oCPU.Flags.GE) goto L04ea;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), 0x0);
			goto L04b2;

		L04ea:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oParent.GameState.Players[playerID].Continents[0].Strategy = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe6b6), 0x0);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2a6e, this.oCPU.ANDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2a6e), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6ed4, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), 0x1);

		L0516:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))] & 3) == 1)
			{
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6ed4, 0x1);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), 0x8);
			if (this.oCPU.Flags.L) goto L0516;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), 0x1);
			goto L07cc;

		L0548:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L054b:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack == 0)
				goto L05a1;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L05a1;

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))] & 2) == 0)
				goto L05a1;
			
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x68), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Defense;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word,
				(ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Defense);
			if (this.oCPU.Flags.GE) goto L05a1;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L05a1:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c)), this.oCPU.AX.Word));

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack == 0)
				goto L05e2;

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))] & 2) != 0)
			{
				this.oCPU.AX.Word = 0x1;
			}
			else
			{
				this.oCPU.AX.Word = 0x2;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62), this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62)), this.oCPU.AX.Word));

		L05e2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));

		L05e5:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x8);
			if (this.oCPU.Flags.L) goto L05ee;
			goto L068d;

		L05ee:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack == 0)
				goto L054b;

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Defense;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word,
				(ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Defense);
			if (this.oCPU.Flags.L) goto L062d;

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount != 0) goto L062d;
			goto L054b;

		L062d:
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))] & 3) == 1 ||
				(this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))] & 0x100) != 0)
				goto L064f;
			goto L054b;

		L064f:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x68), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack <
				this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Defense)
				goto L0687;

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Defense <
				this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack)
				goto L0687;
			
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount != 0)
				goto L0548;

		L0687:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e))));
			goto L054b;

		L068d:
			if (this.oParent.GameState.Players[0].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e),
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e))));
			}

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack;

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xdcfe)));
			if (this.oCPU.Flags.G) goto L06ef;
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount;

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c)));
			this.oCPU.CX.Word = 0x6;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].BuildSiteCount);
			if (this.oCPU.Flags.LE) goto L0707;

		L06ef:
			// Instruction address 0x25fb:0x06f6, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 7);
			if (this.oCPU.AX.Word != 0)
			{
				this.oCPU.AX.Word = 0x5;
				goto L0709;
			}

		L0707:
			this.oCPU.AX.Word = 0;

		L0709:
			this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Strategy = 
				(short)this.oCPU.AX.Word;
			
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e)) != 0)
			{
				this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Strategy = 1;
			}

			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) != 0)
			{
				this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Strategy = 2;
			}

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack == 0 &&
				this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount == 0 &&
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62)) != 1)
			{
				this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Strategy = 1;
			}

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), this.oCPU.SI.Word);
			if (this.oCPU.Flags.GE) goto L076d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.SI.Word);

		L076d:
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Strategy !=
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x60)))
			{
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)playerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
				if (this.oCPU.Flags.NE) goto L079d;

				// Instruction address 0x25fb:0x0797, size: 3
				F0_25fb_3459(playerID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)));
			}

		L079d:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Attack != 0 &&
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].CityCount > 1)
			{
				this.oCPU.AX.Word = 0x1;
				this.oCPU.CX.Low = (byte)playerID;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2a6e, this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2a6e), this.oCPU.AX.Word));
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))));

		L07cc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), 0xf);
			if (this.oCPU.Flags.GE) goto L0802;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 
				(ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Strategy;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x60), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0x1);
			goto L05e5;

		L0802:
			if (playerID == 0x0)
				goto L0c97;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L081c;
			goto L0c97;

		L081c:
			if (this.oParent.GameState.Players[playerID].SettlerCount != 0 ||			
				this.oParent.GameState.Players[playerID].CityCount != 0 ||
				playerID == this.oParent.GameState.HumanPlayerID) goto L0845;

			this.oParent.StartGameMenu.F5_0000_0e6c(playerID, 0);

		L0845:
			this.oCPU.AX.Low = (byte)playerID;
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, (byte)(this.oParent.GameState.TurnCount & 0xff));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x7);
			if (this.oCPU.Flags.NE) goto L08c1;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe3c2), 0x0);
			if (this.oCPU.Flags.G) goto L08b2;

			// Instruction address 0x25fb:0x085e, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x2c);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L0876;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdb42), 0x0);
			if (this.oCPU.Flags.L) goto L0876;

			// Instruction address 0x25fb:0x08b9, size: 5
			this.oParent.Segment_2517.F0_2517_04a1(playerID, 4);
			
			goto L08c1;

		L0876:
			// Instruction address 0x25fb:0x087d, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x2b);
			if (this.oCPU.AX.Word == 0 ||
				this.oParent.GameState.Players[playerID].CityCount <= 10)
				goto L089a;

			// Instruction address 0x25fb:0x08b9, size: 5
			this.oParent.Segment_2517.F0_2517_04a1(playerID, 3);

			goto L08c1;

		L089a:
			// Instruction address 0x25fb:0x08a1, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 5);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L08c1;

			// Instruction address 0x25fb:0x08b9, size: 5
			this.oParent.Segment_2517.F0_2517_04a1(playerID, 2);

			goto L08c1;

		L08b2:
			// Instruction address 0x25fb:0x08b9, size: 5
			this.oParent.Segment_2517.F0_2517_04a1(playerID, 1);

		L08c1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), 0x0);

		L08c6:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), 0x20);
			if (this.oCPU.Flags.L) goto L08c6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 0x0);
			goto L09f8;

		L08e2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), 0x270f);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62), 0xffff);
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50),
				(short)this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52),
				(short)this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			// Instruction address 0x25fb:0x0910, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54));
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, (byte)(this.oParent.GameState.TurnCount & 0xff));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0xf);
			if (this.oCPU.Flags.NE)
				goto L0a2c;

			// Instruction address 0x25fb:0x0938, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID].CancelTechnology);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0980;

			if (this.oParent.GameState.Players[playerID].GovernmentType > 1)
				goto L0966;

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))].Strategy != 5)
				goto L0a2c;

		L0966:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID != 1)
				goto L0a2c;

		L0980:
			// Instruction address 0x25fb:0x0989, size: 5
			this.oParent.Segment_1866.F0_1866_1750(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0998;
			goto L0a2c;

		L0998:
			// Instruction address 0x25fb:0x099e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L09c1;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].NextUnitID == -1)
				goto L0a2c;

		L09c1:
			// Instruction address 0x25fb:0x09c7, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0a2c;
			
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a))].Strategy == 2)
				goto L0a2c;

			// Instruction address 0x25fb:0x09ed, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));

		L09f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));

		L09f8:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x80);
			if (this.oCPU.Flags.L) goto L0a02;
			goto L0c97;

		L0a02:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID == -1 ||
				(this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Status & 0x10) != 0 ||
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID == 25)
				goto L09f5;

			goto L08e2;

		L0a2c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), 0x0);
			goto L0ad2;

		L0a34:
			this.oCPU.AX.Word = 0x4;

		L0a37:
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb2be));
			goto L0a7a;

		L0a43:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)));

			// Instruction address 0x25fb:0x0a5f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe598)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe798)));

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x44));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2be));

		L0a7a:
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Status & 0xc) == 0)
				goto L0c0e;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb2be));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x68), this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x2);
			if (this.oCPU.Flags.L) goto L0acf;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)));
			if (this.oCPU.Flags.L) goto L0ac0;
			goto L0be3;

		L0ac0:
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0acf;
			goto L0be3;

		L0acf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))));

		L0ad2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), 0x20);
			if (this.oCPU.Flags.L) goto L0adb;
			goto L0c4d;

		L0adb:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c2)), 0xff);
			if (this.oCPU.Flags.E) goto L0acf;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c2));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0b28;

			// Instruction address 0x25fb:0x0b1b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe598)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe798)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)));
			if (this.oCPU.Flags.E) goto L0b6c;

		L0b28:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x68), this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID != 15)
				goto L0acf;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xe2c2));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x66), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x68)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x66));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b6c;
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x3);
			if (this.oCPU.Flags.E) goto L0b6c;
			goto L0acf;

		L0b6c:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID != 15)
				goto L0a43;

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)));
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb2be)), 0x1);
			if (this.oCPU.Flags.E)
				goto L0acf;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.CX.Word = (ushort)this.oParent.GameState.TurnCount;
			this.oCPU.CX.Word = this.oCPU.SARWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E)
				goto L0acf;

			// Instruction address 0x25fb:0x0bc0, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xe598)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xe798)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].TypeID].MoveCount >=
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)))
				goto L0bdd;

			goto L0a34;

		L0bdd:
			this.oCPU.AX.Word = 0x2;
			goto L0a37;

		L0be3:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x0bff, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.X,
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Position.Y);

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0c0e;
			goto L0acf;

		L0c0e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0c19;
			goto L0acf;

		L0c19:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb2be));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0c3e;
			goto L0acf;

		L0c3e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62), this.oCPU.AX.Word);
			goto L0acf;

		L0c4d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0c56;
			goto L09f5;

		L0c56:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62)));
			
			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].GoToPosition.X =
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xe598));

			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].GoToPosition.Y =
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xe798));

			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Status |= 0x10;
			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))].Status &= 0xf0;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x62));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.BP.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x44), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x44))));
			goto L09f5;

		L0c97:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_0004");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_25fb_0c9d(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_0c9d({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x5e);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.CMPWord((ushort)playerID, 0x0);
			if (this.oCPU.Flags.NE) goto L0ccf;

			// Instruction address 0x25fb:0x0cc6, size: 3
			F0_25fb_362d(playerID, unitID);

			goto L2fd0;

		L0ccf:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].TypeID != 15 ||
				this.oParent.GameState.Players[playerID].Units[unitID].SpecialMoves > 0)
				goto L0cf3;

		L0ced:
			this.oCPU.AX.Word = 0x68;
			goto L2fd0;

		L0cf3:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].TypeID != 14 ||
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X != -1)
				goto L0f13;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].MoveCount);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			if ((short)this.oCPU.CX.Word >= this.oParent.GameState.Players[playerID].Units[unitID].RemainingMoves)
				goto L0ced;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x0);

		L0d47:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.HumanPlayerID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].TypeID != 15)
				goto L0db5;

			this.oCPU.AX.Word = this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].VisibleByPlayer;
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)((sbyte)playerID);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0db5;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x0d96, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oParent.GameState.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.Y,
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0db5;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L0db5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x80);
			if (this.oCPU.Flags.L) goto L0d47;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0dc8;
			goto L0f13;

		L0dc8:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1);
			if (this.oCPU.Flags.G) goto L0dd1;
			goto L0f13;

		L0dd1:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].MoveCount <= 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)))
				goto L0e16;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.HumanPlayerID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y;

			goto L0f13;

		L0e16:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x0);
			goto L0e70;

		L0e27:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			
			// Instruction address 0x25fb:0x0e55, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oParent.GameState.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.Y,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y);

			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].MoveCount >= (short)this.oCPU.CX.Word)
				goto L0e92;

		L0e6d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L0e70:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x80);
			if (this.oCPU.Flags.GE) goto L0ee2;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0e6d;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L0e27;
			goto L0e6d;

		L0e92:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.HumanPlayerID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x0ec1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X,
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0e6d;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);
			goto L0e6d;

		L0ee2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0eeb;
			goto L16b3;

		L0eeb:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].Position.Y;

		L0f13:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x0f32, size: 5
			this.oParent.Segment_1866.F0_1866_1725(playerID,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0x0);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30),
				(short)this.oParent.GameState.Players[playerID].Units[unitID].Position.X);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36),
				(short)this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
				(short)this.oParent.GameState.Players[playerID].Units[unitID].TypeID);

			// Instruction address 0x25fb:0x0f60, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].TypeID = -1;

			// Instruction address 0x25fb:0x0f82, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0177(playerID, unitID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].TypeID =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));


			// Instruction address 0x25fb:0x0fa0, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x0fc0, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.AX.Word].Strategy;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)((sbyte)playerID);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x19);
			if (this.oCPU.Flags.E) goto L0ff1;
			goto L12a3;

		L0ff1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L10ff;

		L0ffe:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L100c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x2));
			goto L1010;

		L100c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x63));

		L1010:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L1013:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.G) goto L106e;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x1044, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1010;
			
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			
			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))] & 0x82) != 0x80)
				goto L0ffe;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))));
			goto L1010;

		L106e:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x2;
			this.oCPU.IDIVByte(this.oCPU.AX, this.oCPU.CX.Low);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), this.oCPU.AX.Word));

		L1083:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L10fc;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x0);
			goto L109a;

		L1097:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))));

		L109a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x80);
			if (this.oCPU.Flags.GE) goto L10ea;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L1097;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L1097;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			
			// Instruction address 0x25fb:0x10d8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x10);
			if (this.oCPU.Flags.G) goto L1097;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e), 0x1);

		L10ea:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3e)), 0x0);
			if (this.oCPU.Flags.E) goto L10fc;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

		L10fc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L10ff:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x80);
			if (this.oCPU.Flags.L) goto L1109;
			goto L11ad;

		L1109:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L1123;
			goto L1083;

		L1123:
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BuildingFlags1, 0x1);
			if (this.oCPU.Flags.E) goto L112e;
			goto L1083;

		L112e:
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.DI.Word = (ushort)this.oParent.GameState.Players[this.oCPU.AX.Word].MilitaryPower;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].MilitaryPower;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.L) goto L1176;
			
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.SI.Word >> 1] & 8) != 0)
				goto L1176;

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))].ActiveUnits[25] != 0)
				goto L1083;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5e)), this.oCPU.DI.Word);
			if (this.oCPU.Flags.L) goto L1176;
			goto L1083;

		L1176:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			
			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))] & 0x82) != 0x80)
				goto L1083;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].ActualSize, this.oCPU.CX.Low);
			if (this.oCPU.Flags.G) goto L11a0;
			goto L1083;

		L11a0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x0);
			goto L1013;

		L11ad:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0xa);
			if (this.oCPU.Flags.GE) goto L11b6;
			goto L16b3;

		L11b6:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.GameState.Players[playerID].ActiveUnits[25] <= 1)
				goto L16b3;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x1);

			goto L1200;

		L11fd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L1200:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.LE) goto L1209;
			goto L16b3;

		L1209:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1882)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x18e4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x123c, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L11fd;

			// Instruction address 0x25fb:0x1253, size: 5
			this.oParent.Segment_2aea.F0_2aea_1412(playerID, unitID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oParent.GameState.Players[playerID].Units[unitID].Position.X = 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oParent.GameState.Players[playerID].Units[unitID].Position.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));

			// Instruction address 0x25fb:0x1275, size: 5
			this.oParent.Segment_2aea.F0_2aea_13cb(playerID, unitID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID == this.oParent.GameState.HumanPlayerID)
			{
				this.oParent.GameState.Players[playerID].ContactPlayerCountdown = -2;
			}
		
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.AX.Low = this.oCPU.XORByte(this.oCPU.AX.Low, 0x4);
			goto L2fd0;

		L12a3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x1a);
			if (this.oCPU.Flags.NE) goto L1307;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X == -1)
				goto L12c5;

		L12c0:
			this.oCPU.AX.Word = 0;
			goto L2fd0;

		L12c5:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L12f9;

		L12d7:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.SI.Word / 28].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.SI.Word / 28].Position.Y;

			this.oCPU.AX.Word = 0;

			goto L2fd0;

		L12f9:
			// Instruction address 0x25fb:0x12ff, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

		L1307:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L1321;

			// Instruction address 0x25fb:0x131b, size: 3
			F0_25fb_3401(playerID, 0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				0);

		L1321:
			// Instruction address 0x25fb:0x132f, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1341;
			goto L1434;

		L1341:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x3);
			if (this.oCPU.Flags.L) goto L134a;
			goto L1434;

		L134a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x1);
			goto L1359;

		L1356:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L1359:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.G) goto L13d9;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x25fb:0x136c, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x138d, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L13ac;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);

		L13ac:
			// Instruction address 0x25fb:0x13b8, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			// Instruction address 0x25fb:0x13c1, size: 5
			this.oParent.Segment_2aea.F0_2aea_1894(
				this.oCPU.AX.Word,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1356;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.E) goto L1356;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			goto L2fd0;

		L13d9:
			if (this.oParent.GameState.TurnCount != 0) goto L13f1;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd76a), 0x0);
			if (this.oCPU.Flags.E) goto L13f1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0xf);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0x0);

		L13f1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0x8);
			if (this.oCPU.Flags.L) goto L1434;
			this.oCPU.AX.Word = 0xf;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));
			if (this.oCPU.Flags.G) goto L1434;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x0);
			if (this.oCPU.Flags.NE) goto L1434;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L141d;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x0);
			if (this.oCPU.Flags.E) goto L1417;
			goto L2fcd;

		L1417:
			this.oCPU.AX.Word = 0x62;
			goto L2fd0;

		L141d:
			// Instruction address 0x25fb:0x142e, size: 3
			F0_25fb_3251_AddStrategicLocation(playerID, 
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				0, 2);

		L1434:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L14ac;
			if (this.oParent.GameState.DifficultyLevel == 0) goto L14ac;

			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) < 128)
			{
				this.oCPU.SI.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			}
			else
			{
				this.oCPU.SI.Word = 0xffff;
			}
			this.oCPU.CMPWord((ushort)this.oParent.GameState.HumanPlayerID, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NE) goto L14ac;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x0);
			if (this.oCPU.Flags.NE) goto L14ac;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x1);
			if (this.oCPU.Flags.LE) goto L14ac;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L14ac;
			
			this.oCPU.DI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			if (this.oParent.GameState.Players[playerID].DiscoveredTechnologyCount >= this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].DiscoveredTechnologyCount)
				goto L14ac;

			// Instruction address 0x25fb:0x148e, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)) + 0x32);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.L) goto L14ac;
			this.oCPU.AX.Word = 0xe;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			if (this.oCPU.Flags.G) goto L14ac;
			goto L1417;

		L14ac:
			// Instruction address 0x25fb:0x14b2, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L14c1;
			goto L166c;

		L14c1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x2);
			if (this.oCPU.Flags.E) goto L14ca;
			goto L168f;

		L14ca:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID != -1)
				goto L14e7;

		L14e1:
			this.oCPU.AX.Word = 0x66;
			goto L2fd0;

		L14e7:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 
				(short)this.oParent.GameState.Players[playerID].Units[unitID].TypeID);

			this.oParent.GameState.Players[playerID].Units[unitID].TypeID = 26;

			// Instruction address 0x25fb:0x150c, size: 5
			this.oParent.Segment_1866.F0_1866_1089(playerID, unitID);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].TypeID =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)) != -1)
			{
				if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].TypeID].DefenseStrength <
					this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].DefenseStrength)
					goto L14e1;
			}

			// Instruction address 0x25fb:0x154e, size: 5
			this.oParent.Segment_1866.F0_1866_1750(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L155f;
			this.oCPU.AX.Word = 0x3;
			goto L1562;

		L155f:
			this.oCPU.AX.Word = 0x4;

		L1562:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L1579;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			goto L1582;

		L1579:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L1582;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L1582:
			// Instruction address 0x25fb:0x158c, size: 5
			this.oParent.Segment_1866.F0_1866_1380(playerID, unitID, 2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			if (this.oCPU.Flags.LE) goto L15c5;

			// Instruction address 0x25fb:0x15bf, size: 3
			F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				2, 2);

		L15c5:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)));
			if (this.oCPU.Flags.L) goto L15e1;
			goto L14e1;

		L15e1:
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a),
				this.oParent.GameState.Players[playerID].Units[unitID].Status);
			
			this.oParent.GameState.Players[playerID].Units[unitID].Status |= 8;

			// Instruction address 0x25fb:0x1604, size: 5
			this.oParent.Segment_1866.F0_1866_1089(playerID, unitID);

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)unitID);
			if (this.oCPU.Flags.NE) goto L1645;

			// Instruction address 0x25fb:0x161b, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 4);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.LE) goto L1645;

			this.oParent.GameState.Players[playerID].Units[unitID].Status = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));

			goto L14e1;

		L1645:
			this.oParent.GameState.Players[playerID].Units[unitID].Status = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));

			this.oCPU.AX.Low = (byte)((sbyte)unitID);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, (byte)(this.oParent.GameState.TurnCount & 0xff));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x7);
			if (this.oCPU.Flags.E)
			{
				this.oParent.GameState.Players[playerID].Units[unitID].Status &= 0xf2;
			}

		L166c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x5);
			if (this.oCPU.Flags.E) goto L167b;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x3);
			if (this.oCPU.Flags.E) goto L167b;
			goto L1f44;

		L167b:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 
				(short)this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID);

			if (this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID == -1)
				goto L1752;

			goto L16b9;

		L168f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x0);
			if (this.oCPU.Flags.LE) goto L166c;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.E) goto L166c;

			// Instruction address 0x25fb:0x16ad, size: 3
			F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				2, 4);

		L16b3:
			this.oCPU.AX.Word = 0x20;
			goto L2fd0;

		L16b9:
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L16c4;
			goto L1752;

		L16c4:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if ((this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].Status & 0x8) != 0)
				goto L16f8;

			this.oCPU.DI.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].TypeID));

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1148));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), this.oCPU.AX.Word));

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].TypeID].TerrainCategory != 0)
				goto L1732;
			goto L172f;

		L16f8:
			// !!! Why the index goes out of range here?
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) >= 0x80 ||
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) != 0x5)
				goto L1732;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x5;
			this.oCPU.IDIVByte(this.oCPU.AX, this.oCPU.CX.Low);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c))));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.GE) goto L1732;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].Status &= 0xf7;

		L172f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));

		L1732:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			short nextUnitID = (short)this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].NextUnitID;
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), nextUnitID);

			if (nextUnitID == -1)
				goto L1752;

			goto L16b9;

		L1752:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x0);
			if (this.oCPU.Flags.E) goto L175d;
			this.oCPU.AX.Word = 0x1;
			goto L1760;

		L175d:
			this.oCPU.AX.Word = 0x3;

		L1760:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			if (this.oCPU.Flags.G) goto L176e;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x1);
			if (this.oCPU.Flags.E) goto L176e;
			goto L198e;

		L176e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x5);
			if (this.oCPU.Flags.E) goto L1777;
			goto L198e;

		L1777:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L17d4;

		L1783:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x179d, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x17b4, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.AX.Word].Attack >= 16)
				goto L1800;

		L17d1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L17d4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x80);
			if (this.oCPU.Flags.L) goto L17de;
			goto L18d1;

		L17de:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L17d1;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L17d1;
			this.oCPU.TESTByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].StatusFlag, 0x2);
			if (this.oCPU.Flags.NE) goto L1783;
			goto L17d1;

		L1800:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x1814, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1846;

			// Instruction address 0x25fb:0x182e, size: 5
			this.oParent.Segment_1866.F0_1866_1380(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 5);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1);
			this.oCPU.CX.Word = this.oCPU.SBBWord(this.oCPU.CX.Word, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.NEGWord(this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1846;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x10));

		L1846:
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Strategy == 5)
				goto L185f;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x10));
			goto L1880;

		L185f:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Defense;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word));

		L1880:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L188b;
			goto L17d1;

		L188b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y;
			
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Strategy;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			goto L17d1;

		L18d1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x5);
			if (this.oCPU.Flags.NE) goto L18dc;
			this.oCPU.AX.Word = 0x4;
			goto L18df;

		L18dc:
			this.oCPU.AX.Word = 0x2;

		L18df:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			if (this.oCPU.Flags.GE) goto L18f0;
			goto L1f44;

		L18f0:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x0);
			if (this.oCPU.Flags.E) goto L1922;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x191c, size: 3
			F0_25fb_304d(playerID,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y,
				0, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L1922:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x2);
			if (this.oCPU.Flags.E) goto L1955;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x194f, size: 3
			F0_25fb_304d(playerID,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y,
				2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L1955:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x1);
			if (this.oCPU.Flags.NE) goto L195e;
			goto L1f44;

		L195e:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x1985, size: 3
			F0_25fb_304d(playerID,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y,
				1, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			goto L1f44;

		L198e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x5);
			if (this.oCPU.Flags.E) goto L1997;
			goto L1c37;

		L1997:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x1);
			goto L1a68;

		L199f:
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Strategy != 1)
				goto L19ca;

			// Instruction address 0x25fb:0x19c4, size: 3
			F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				3, 5);

		L19ca:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].RemainingMoves = 0;
			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X = -1;

			this.oCPU.AX.Word = 0x75;

			goto L2fd0;

		L19ea:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.TurnCount & 0xff), 0x3);
			if (this.oCPU.Flags.NE) goto L1a06;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X = -1;

		L1a06:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].RemainingMoves > 3)
				goto L1c37;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.X);
			this.oCPU.CX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.CX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X == -1)
				goto L1c37;

			// Instruction address 0x25fb:0x1a52, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1a62;
			goto L1c22;

		L1a62:
			goto L1c37;

		L1a65:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L1a68:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.G) goto L1a06;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x25fb:0x1a7b, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x1a94, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x1aa5, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L1a65;

			// Instruction address 0x25fb:0x1ab8, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1a65;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0xffff);
			if (this.oCPU.Flags.E) goto L1ad2;
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1a65;

		L1ad2:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1b00;

			// Instruction address 0x25fb:0x1ae4, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			// Instruction address 0x25fb:0x1af0, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, (short)this.oCPU.AX.Word, 2);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.L) goto L1b00;
			goto L1a65;

		L1b00:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L1b3d;

			// Instruction address 0x25fb:0x1b1a, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.HumanPlayerID);
			if (this.oCPU.Flags.NE) goto L1b3d;

			// Instruction address 0x25fb:0x1b2e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0xf);
			if (this.oCPU.Flags.E) goto L1b3d;
			goto L1a65;

		L1b3d:
			// Instruction address 0x25fb:0x1b43, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x0);
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Attack >= 16)
				goto L1b6c;
			
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Strategy != 5)
				goto L1b87;

		L1b6c:
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Strategy;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x6);
			if (this.oCPU.Flags.E) goto L1b8c;

		L1b87:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x1);

		L1b8c:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X == -1)
				goto L1bc1;

			// Instruction address 0x25fb:0x1baf, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)));
			if (this.oCPU.Flags.NE) goto L1bc1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c), 0x1);

		L1bc1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3c)), 0x0);
			if (this.oCPU.Flags.NE) goto L1bca;
			goto L19ea;

		L1bca:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			if (this.oParent.GameState.Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].BuildSiteCount < 5)
				goto L19ea;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x1);
			if (this.oCPU.Flags.G) goto L1be2;
			goto L19ea;

		L1be2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x30);
			if (this.oCPU.Flags.L) goto L1beb;
			goto L19ea;

		L1beb:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].RemainingMoves <= 3)
				goto L199f;

			// Instruction address 0x25fb:0x1c0f, size: 3
			F0_25fb_3521(playerID, 
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L1c1f;
			goto L199f;

		L1c1f:
			goto L2fd0;

		L1c22:
			// Instruction address 0x25fb:0x1c31, size: 3
			F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
				3, 3);

		L1c37:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x0);
			if (this.oCPU.Flags.E) goto L1c46;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x5);
			if (this.oCPU.Flags.E) goto L1c46;
			goto L1f44;

		L1c46:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X != -1)
				goto L1d49;

			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x2);
			if (this.oCPU.Flags.NE) goto L1c6f;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x1);
			if (this.oCPU.Flags.E) goto L1c6f;
			goto L1d49;

		L1c6f:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].TypeID == 16)
				goto L1d49;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x3e7);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.TurnCount;
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			goto L1d3f;

		L1c9a:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].StatusFlag == 0xff)
				goto L1d3b;

			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1d3b;

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			
			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a))] & 0x102) == 2)
				goto L1d3b;

			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Ranking < 7)
				goto L1ce8;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1d3b;

		L1ce8:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x1d02, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1d3b;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y;

		L1d3b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8));

		L1d3f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x80);
			if (this.oCPU.Flags.GE) goto L1d49;
			goto L1c9a;

		L1d49:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X != -1 ||
				this.oParent.GameState.Players[playerID].Units[unitID].TypeID == 16)
				goto L1e78;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0xffff);

			// Instruction address 0x25fb:0x1d7d, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L1d90;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L1d90:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x0);

		L1d95:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].StatusFlag == 0xff)
				goto L1e6b;

			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1dba;
			goto L1e6b;

		L1dba:
			// Instruction address 0x25fb:0x1dcc, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.GE) goto L1ddf;
			goto L1e6b;

		L1ddf:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x1df3, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1e6b;
			
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Strategy == 5)
				goto L1e6b;

			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4a))].Strategy;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x7);
			if (this.oCPU.Flags.NE) goto L1e35;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x1));

		L1e35:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1e6b;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))].Position.Y;

		L1e6b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x80);
			if (this.oCPU.Flags.GE) goto L1e78;
			goto L1d95;

		L1e78:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X != -1)
				goto L1f44;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x2);
			goto L1e9c;

		L1e99:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L1e9c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x18);
			if (this.oCPU.Flags.L) goto L1ea5;
			goto L1f44;

		L1ea5:
			// Instruction address 0x25fb:0x1ea9, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(9));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			// Instruction address 0x25fb:0x1ed9, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				(this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1882)) *
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))) +
					this.oParent.GameState.Players[playerID].Units[unitID].Position.X);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x18e4));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)));
			this.oCPU.CX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.LE) goto L1e99;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2f);
			if (this.oCPU.Flags.GE) goto L1e99;

			// Instruction address 0x25fb:0x1f04, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L1e99;

			// Instruction address 0x25fb:0x1f17, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			
			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.AX.Word].CityCount != 0)
				goto L1e99;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));

		L1f44:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].MoveCount >= 2)
				goto L1fb2;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x4);
			if (this.oCPU.Flags.GE) goto L1fb2;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L1fb2;
			
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[playerID] & 2) != 0)
				goto L1fb2;

			// Instruction address 0x25fb:0x1f98, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x6);
			if (this.oCPU.Flags.E) goto L1fb2;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L1fb2;
			this.oCPU.AX.Word = 0x50;
			goto L2fd0;

		L1fb2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.E) goto L1fbb;
			goto L2520;

		L1fbb:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xa);
			if (this.oCPU.Flags.NE) goto L1fc4;
			goto L241e;

		L1fc4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x2);
			if (this.oCPU.Flags.L) goto L1fdf;

			// Instruction address 0x25fb:0x1fd9, size: 3
			F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)),
				2, 2);

		L1fdf:
			// Instruction address 0x25fb:0x1fe6, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 5);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.SI.Word = 0x5;
			}
			else
			{
				this.oCPU.SI.Word = 0x4;
			}
		
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x44a)), 0x0);
			if (this.oCPU.Flags.NE) goto L2014;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x5);
			if (this.oCPU.Flags.E) goto L2014;
			goto L213b;

		L2014:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x0);
			if (this.oCPU.Flags.G) goto L201d;
			goto L213b;

		L201d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x2);
			if (this.oCPU.Flags.LE) goto L2026;
			goto L213b;

		L2026:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L203b;
			goto L213b;

		L203b:
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].ActualSize, 0x3);
			if (this.oCPU.Flags.GE) goto L2060;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x4);
			if (this.oCPU.Flags.NE) goto L2060;

			// Instruction address 0x25fb:0x2051, size: 5
			this.oParent.Segment_2aea.F0_2aea_1836(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2060;
			goto L213b;

		L2060:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
			if (this.oCPU.Flags.NE) goto L206a;
			goto L213b;

		L206a:
			// Instruction address 0x25fb:0x2070, size: 5
			this.oParent.Segment_1403.F0_1403_3f68(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L20c0;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L20db;

			// Instruction address 0x25fb:0x2088, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x6);
			if (this.oCPU.Flags.E) goto L20f6;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x8);
			if (this.oCPU.Flags.NE) goto L20f6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x2);
			if (this.oCPU.Flags.G) goto L20f6;

		L20a5:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X = -1;

		L20ba:
			this.oCPU.AX.Word = 0x72;
			goto L2fd0;

		L20c0:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			
			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X = -1;

			this.oCPU.AX.Word = 0x69;

			goto L2fd0;

		L20db:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X = -1;

			this.oCPU.AX.Word = 0x6d;

			goto L2fd0;

		L20f6:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x18);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x18);
			if (this.oCPU.Flags.E) goto L213b;
			
			// Instruction address 0x25fb:0x2106, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x31);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L213b;

			// Instruction address 0x25fb:0x211c, size: 5
			this.oParent.Segment_1d12.F0_1d12_6abc(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)), 1);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x8);
			if (this.oCPU.Flags.E) goto L2131;
			this.oCPU.AX.Word = 0x1;
			goto L2134;

		L2131:
			this.oCPU.AX.Word = 0x2;

		L2134:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.G) goto L213b;
			goto L20a5;

		L213b:
			// Instruction address 0x25fb:0x2141, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x40);
			if (this.oCPU.Flags.E) goto L2153;
			this.oCPU.AX.Word = 0x70;
			goto L2fd0;

		L2153:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X == -1)
				goto L219c;
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1514));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))].BuildSiteCount);
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))].CityCount;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.LE) goto L219c;
			goto L12c0;

		L219c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x1);
			if (this.oCPU.Flags.LE) goto L21a5;
			goto L230b;

		L21a5:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L21ba;
			goto L230b;

		L21ba:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x2);
			if (this.oCPU.Flags.NE) goto L21c4;
			goto L230b;

		L21c4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x1);
			goto L22a6;

		L21cc:
			// Instruction address 0x25fb:0x21d2, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.CX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x21ea, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 5);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.BX.Word = 0x5;
			}
			else
			{
				this.oCPU.BX.Word = 0x4;
			}
		
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x44a)), 0x0);
			if (this.oCPU.Flags.NE) goto L220a;
			goto L22a3;

		L220a:
			// Instruction address 0x25fb:0x2210, size: 5
			this.oParent.Segment_1403.F0_1403_3f68(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L221f;
			goto L22a3;

		L221f:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].ActualSize, 0x3);
			if (this.oCPU.Flags.GE) goto L2257;

			// Instruction address 0x25fb:0x2234, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.NE) goto L2257;

			// Instruction address 0x25fb:0x224b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1836(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L22a3;

		L2257:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x2275, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0208_CombinePosition(
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)) -
					this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].Position.X),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) -
					this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].Position.Y));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.G) goto L22a3;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));

			goto L12c0;

		L22a3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L22a6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.G) goto L230b;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.TurnCount);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x22d6, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L22e9;
			goto L21cc;

		L22e9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L22a3;

			// Instruction address 0x25fb:0x22fa, size: 5
			this.oParent.Segment_1866.F0_1866_1331(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2309;
			goto L21cc;

		L2309:
			goto L22a3;

		L230b:
			// Instruction address 0x25fb:0x2311, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L2320;
			goto L241e;

		L2320:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xb);
			if (this.oCPU.Flags.NE) goto L233c;

			// Instruction address 0x25fb:0x232d, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x13);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L233c;

			goto L241e;

		L233c:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)) < 128)
			{
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L2351;
			goto L241e;

		L2351:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x2);
			if (this.oCPU.Flags.G) goto L2369;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x1);
			if (this.oCPU.Flags.NE) goto L2360;
			goto L20ba;

		L2360:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x2);
			if (this.oCPU.Flags.NE) goto L2369;
			goto L20ba;

		L2369:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x1);

		L2379:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x25fb:0x238e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)) + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L23cf;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.CX.Low = this.oCPU.DECByte(this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54))));

			// Instruction address 0x25fb:0x23be, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) * 2 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)) * 2 + this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x8);
			if (this.oCPU.Flags.E) goto L23cf;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), 0x1);

		L23cf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.LE) goto L2379;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ANDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x4);
			if (this.oCPU.Flags.GE) goto L2400;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.E) goto L23f1;
			goto L20ba;

		L23f1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x1);
			if (this.oCPU.Flags.NE) goto L2400;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x2);
			if (this.oCPU.Flags.G) goto L2400;
			goto L20ba;

		L2400:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)), 0x1);
			if (this.oCPU.Flags.NE) goto L241e;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a)), 0x0);
			if (this.oCPU.Flags.E) goto L241e;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28e)), 0x1);
			if (this.oCPU.Flags.NE) goto L241e;
			goto L20ba;

		L241e:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X != -1)
				goto L12c0;

			// Instruction address 0x25fb:0x243c, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(20));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x3a));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.X);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1882)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x18e4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438)), 0x3);
			if (this.oCPU.Flags.NE)
				goto L2520;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1882)) * 4) + this.oParent.GameState.Players[playerID].Units[unitID].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x18e4)) * 4) + this.oParent.GameState.Players[playerID].Units[unitID].Position.Y;

			// Instruction address 0x25fb:0x24c1, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L250b;

			// Instruction address 0x25fb:0x24d9, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y);

			this.oCPU.CX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x291)), 0x0);
			if (this.oCPU.Flags.E) goto L250b;

			// Instruction address 0x25fb:0x24fb, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X,
				this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			if (this.oCPU.Flags.NE) goto L250b;
			goto L12c0;

		L250b:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X = -1;

		L2520:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X == -1)
				goto L2558;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x3);
			if (this.oCPU.Flags.E) goto L2540;
			goto L12c0;

		L2540:
			// Instruction address 0x25fb:0x2549, size: 5
			this.oParent.Segment_1866.F0_1866_18d0(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2558;
			goto L12c0;

		L2558:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x2);
			if (this.oCPU.Flags.NE) goto L2594;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xa);
			if (this.oCPU.Flags.E) goto L2594;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x1);
			if (this.oCPU.Flags.LE) goto L2585;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x3);
			if (this.oCPU.Flags.G) goto L2585;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L2585;
			goto L14e1;

		L2585:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x0);
			if (this.oCPU.Flags.E) goto L2594;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x0);
			if (this.oCPU.Flags.E) goto L2594;
			goto L14e1;

		L2594:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L25f2;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))].BuildSiteCount;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))].CityCount, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L25f2;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), 0x0);
			if (this.oCPU.Flags.NE) goto L25d6;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].ActualSize, 0xa);
			if (this.oCPU.Flags.GE) goto L25d6;
			goto L1417;

		L25d6:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L25f2;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].ActualSize, 0xa);
			if (this.oCPU.Flags.GE) goto L25f2;
			goto L12d7;

		L25f2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0xfc19);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), 0x0);

			// Instruction address 0x25fb:0x260a, size: 5
			this.oParent.Segment_1866.F0_1866_1750(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L262d;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToNextDirection = -1;

			goto L2632;

		L262d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c), 0x1);

		L2632:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x1);
			if (this.oCPU.Flags.NE) goto L2643;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1);
			if (this.oCPU.Flags.NE) goto L2643;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56), 0x1);

		L2643:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 0x1);
			goto L267b;

		L264a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2653;
			goto L2857;

		L2653:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L265e;
			goto L2857;

		L265e:
			// Instruction address 0x25fb:0x2668, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 2);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.GE) goto L2678;
			goto L2857;

		L2678:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

		L267b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0x8);
			if (this.oCPU.Flags.LE) goto L2684;
			goto L2f94;

		L2684:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x25fb:0x2691, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x26aa, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2678;

			// Instruction address 0x25fb:0x26bc, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x26cd, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L26ff;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory == 0)
				goto L2678;

		L26ff:
			// Instruction address 0x25fb:0x2705, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L277d;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))].TypeID != 26)
				goto L277d;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);

		L2733:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			short nextUnitID1 = (short)this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].NextUnitID;
			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), nextUnitID1);

			if (nextUnitID1 == -1)
				goto L2771;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2771;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].TypeID == 26)
				goto L2733;

		L2771:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0xffff);
			if (this.oCPU.Flags.E) goto L277d;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);

		L277d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x0);
			if (this.oCPU.Flags.E) goto L27cd;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 0)
				goto L27cd;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.NE)
				goto L27cd;

			// Instruction address 0x25fb:0x27b3, size: 5
			this.oParent.Segment_1866.F0_1866_1725(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L27cd;

			if (this.oParent.GameState.Players[playerID].Units[unitID].TypeID >= 26)
				goto L27cd;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xa);
			if (this.oCPU.Flags.E)
				goto L27cd;

			goto L2678;

		L27cd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xa);
			if (this.oCPU.Flags.NE) goto L2803;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 0)
				goto L2803;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.E) goto L2803;
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2803;
			goto L2678;

		L2803:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 2)
				goto L264a;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)), 0xa);
			if (this.oCPU.Flags.NE) goto L282e;
			goto L264a;

		L282e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2837;
			goto L2678;

		L2837:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2842;
			goto L2678;

		L2842:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x16);
			if (this.oCPU.Flags.NE) goto L284b;
			goto L2678;

		L284b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xa);
			if (this.oCPU.Flags.NE) goto L2854;
			goto L264a;

		L2854:
			goto L2678;

		L2857:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L2886;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xa);
			if (this.oCPU.Flags.E) goto L286b;
			goto L29ed;

		L286b:
			// Instruction address 0x25fb:0x2874, size: 5
			this.oParent.Segment_1866.F0_1866_1750(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2883;
			goto L29ed;

		L2883:
			goto L2678;

		L2886:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].VisibleByPlayer != 0)
				goto L28eb;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0xa);
			if (this.oCPU.Flags.E) goto L28eb;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x1);
			if (this.oCPU.Flags.NE) goto L28ce;

			// Instruction address 0x25fb:0x28ad, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28e));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);

		L28c6:
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.CX.Word);
			goto L29bf;

		L28ce:
			// Instruction address 0x25fb:0x28d2, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			goto L28c6;

		L28eb:
			// Instruction address 0x25fb:0x28ef, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(5));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.NE) goto L2903;
			goto L29ab;

		L2903:
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L290e;
			goto L29ab;

		L290e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x1);
			if (this.oCPU.Flags.NE) goto L2947;

			// Instruction address 0x25fb:0x291e, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 2);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.CX.Word;

			// Instruction address 0x25fb:0x2935, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 1);

			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));

		L2947:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L2975;

			// Instruction address 0x25fb:0x2957, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 1);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));

		L2975:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x2);
			if (this.oCPU.Flags.NE) goto L29bf;

			// Instruction address 0x25fb:0x2985, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 1);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.CX.Word;

			// Instruction address 0x25fb:0x299c, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 3);

			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			goto L29bc;

		L29ab:
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);

		L29bc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));

		L29bf:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 1)
				goto L29ed;

			// Instruction address 0x25fb:0x29e2, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L29ed:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToNextDirection != -1)
			{
				this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa),
					(short)Math.Abs(this.oParent.GameState.Players[playerID].Units[unitID].GoToNextDirection -
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40))));

				if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) > 4)
				{
					this.oCPU.AX.Word = 0x8;
					this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
				}

				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.AX.Word);
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x0);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.E)
				goto L2d85;

			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2a49;
			goto L2d64;

		L2a49:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L2a57;
			goto L2678;

		L2a57:
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[this.oCPU.AX.Word].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))] & 2) != 0)
				goto L2c6a;

			// Instruction address 0x25fb:0x2a72, size: 5
			this.oParent.Segment_1866.F0_1866_1122(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))].TypeID].TerrainCategory != 1)
				goto L2ac8;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].TypeID == 14)
				goto L2ac8;

			// Instruction address 0x25fb:0x2ab9, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L2ac8;
			goto L2678;

		L2ac8:
			// Instruction address 0x25fb:0x2ad8, size: 5
			this.oParent.Segment_29f3.F0_29f3_000e(playerID, unitID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				0);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x2aec, size: 5
			this.oParent.Segment_1866.F0_1866_1251(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0);

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1142));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x2b26, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L2b3b;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);

		L2b3b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x1);
			if (this.oCPU.Flags.NE) goto L2b50;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1);
			if (this.oCPU.Flags.NE) goto L2b50;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.AX.Word);

		L2b50:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x1);
			if (this.oCPU.Flags.NE) goto L2b8f;

			// Instruction address 0x25fb:0x2b60, size: 5
			this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 3);

			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].AttackStrength);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.GE) goto L2b8f;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a), this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)), 0x1));

		L2b8f:
			this.oCPU.CMPWord((ushort)playerID, 0x0);
			if (this.oCPU.Flags.E) goto L2b9a;
			this.oCPU.AX.Word = 0x6;
			goto L2b9d;

		L2b9a:
			this.oCPU.AX.Word = 0xc;

		L2b9d:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a)));
			if (this.oCPU.Flags.G) goto L2baf;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5a));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			goto L2dbd;

		L2baf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x3e7));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x1);
			if (this.oCPU.Flags.E) goto L2bbd;
			goto L2dbd;

		L2bbd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1);
			if (this.oCPU.Flags.E) goto L2bc6;
			goto L2dbd;

		L2bc6:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 0)
				goto L2dbd;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if ((this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))].Status & 0x28) == 0)
				goto L2dbd;

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28f)), 0x4);
			if (this.oCPU.Flags.GE) goto L2c14;
			goto L2dbd;

		L2c14:
			// Instruction address 0x25fb:0x2c1e, size: 5
			this.oParent.Segment_1866.F0_1866_1251(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 2);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.L) goto L2c2e;
			goto L2dbd;

		L2c2e:
			// Instruction address 0x25fb:0x2c32, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(4));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2c41;
			goto L2dbd;

		L2c41:
			// Instruction address 0x25fb:0x2c47, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L2c56;
			goto L2dbd;

		L2c56:
			this.oParent.Overlay_22.F22_0000_0639(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				playerID);
			
			goto L2dbd;

		L2c6a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x1);
			if (this.oCPU.Flags.E) goto L2c73;
			goto L2678;

		L2c73:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1);
			if (this.oCPU.Flags.E) goto L2c7c;
			goto L2678;

		L2c7c:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 0)
				goto L2678;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			if ((this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24))].Status & 0x8) == 0)
				goto L2678;

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 3) != 1)
				goto L2678;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58))].Diplomacy[this.oParent.GameState.HumanPlayerID] & 3) == 1)
				goto L2678;

			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))].CityCount == 0)
				goto L2678;

			// Instruction address 0x25fb:0x2d05, size: 5
			this.oParent.Segment_1866.F0_1866_1251(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 2);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.L) goto L2d15;
			goto L2678;

		L2d15:
			// Instruction address 0x25fb:0x2d19, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(8));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2d3b;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34))].PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L2678;

		L2d3b:
			// Instruction address 0x25fb:0x2d41, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L2d50;
			goto L2678;

		L2d50:
			this.oParent.Overlay_22.F22_0000_0639(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
				playerID);
			
			goto L2678;

		L2d64:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 
					(ushort)((short)this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].DefenseStrength)));
			goto L2dbd;

		L2d85:
			// Instruction address 0x25fb:0x2d8b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L2da4;
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x58)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2da4;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x3e7);

		L2da4:
			// Instruction address 0x25fb:0x2dad, size: 5
			this.oParent.Segment_2aea.F0_2aea_1894(
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2dbd;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x14));

		L2dbd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x5c)), 0x0);
			if (this.oCPU.Flags.E)
				goto L2f15;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x36)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0xd;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);

			this.oCPU.ES.Word = 0x3772; // segment
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x2438)), 0x0);
			if (this.oCPU.Flags.NE) goto L2e47;

			// Instruction address 0x25fb:0x2e24, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L2e47;

			// Instruction address 0x25fb:0x2e37, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2e47;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8));

		L2e47:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x1);

		L2e4c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x25fb:0x2e59, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x2e72, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2e81;
			goto L2f09;

		L2e81:
			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))];
			
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x50)));
			if (this.oCPU.Flags.NE) goto L2ed1;

			// Instruction address 0x25fb:0x2ea1, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L2ecd;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 2)
				goto L2ed1;

		L2ecd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x2));

		L2ed1:
			// Instruction address 0x25fb:0x2ed7, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L2ee6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x2));

		L2ee6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x56)), 0x0);
			if (this.oCPU.Flags.NE) goto L2f09;

			// Instruction address 0x25fb:0x2ef2, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.CX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x290));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));

		L2f09:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0x8);
			if (this.oCPU.Flags.G) goto L2f15;
			goto L2e4c;

		L2f15:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) != 0)
			{
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				if (this.oParent.GameState.Players[playerID].Units[unitID].RemainingMoves < 3)
				{
					// Instruction address 0x25fb:0x2f44, size: 5
					this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 3);

					// Instruction address 0x25fb:0x2f4d, size: 5
					this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((short)this.oCPU.AX.Word, 1, 99);

					this.oCPU.CX.Word = this.oCPU.AX.Word;
					this.oCPU.SI.Word = this.oCPU.CX.Word;

					// Instruction address 0x25fb:0x2f63, size: 5
					this.oParent.Segment_1866.F0_1866_1251(playerID, unitID, 1);

					this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
					this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
					this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
				}
			}

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L2f7f;
			goto L2678;

		L2f7f:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52), this.oCPU.AX.Word);
			goto L2678;

		L2f94:
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x52)) != 0)
			{
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
				this.oCPU.BX.Word = this.oCPU.AX.Word;

				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				if (this.oParent.GameState.Players[playerID].Units[unitID].RemainingMoves < 3)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), 0x0);
				}
			}

			this.oParent.GameState.Players[playerID].Units[unitID].GoToNextDirection =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));

		L2fcd:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));

		L2fd0:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_0c9d");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_25fb_2fd7(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_2fd7({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L2fe3:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c2), 0xff);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2be), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x20);
			if (this.oCPU.Flags.L) goto L2fe3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L3005:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			if (this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Active == -1 ||
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Active > 2)
				goto L303f;

			// Instruction address 0x25fb:0x3039, size: 3
			F0_25fb_304d(playerID,
				(short)this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X,
				(short)this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y,
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Active,
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Policy);

		L303f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x10);
			if (this.oCPU.Flags.L) goto L3005;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_2fd7");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="active"></param>
		/// <param name="policy"></param>
		public void F0_25fb_304d(short playerID, int xPos, int yPos, short active, short policy)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_304d({playerID}, {xPos}, {yPos}, {active}, {policy})");
			
			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L305f;

		L305c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L305f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x20);
			if (this.oCPU.Flags.GE) goto L309a;
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			if (this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe598)) != xPos)
				goto L305c;

			if (this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe798)) != yPos)
				goto L305c;

			if (this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c2)) != active)
				goto L305c;

			if (this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2be)) > policy)
				goto L305c;

			goto L31ce;

		L309a:
			if (playerID == this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6b90))
				goto L30a5;

			goto L3170;

		L30a5:
			if (playerID != this.oParent.GameState.HumanPlayerID)
				goto L30b0;

			goto L3170;

		L30b0:
			if (active == 3 || active == 4)
				goto L30bf;

			goto L3170;

		L30bf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L30c9;

		L30c6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L30c9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x80);
			if (this.oCPU.Flags.L) goto L30d3;
			goto L3170;

		L30d3:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].TypeID == -1 ||
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].RemainingMoves == 0)
				goto L30c6;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)active;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L30c6;

			// Instruction address 0x25fb:0x3108, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(xPos, yPos);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x311e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X,
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NE) goto L30c6;

			// Instruction address 0x25fb:0x313c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X,
				xPos,
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y,
				yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].RemainingMoves < (short)this.oCPU.CX.Word)
				goto L30c6;

			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].GoToPosition.X = xPos;
			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].GoToPosition.Y = yPos;
			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Status |= 0x10;
			this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Status &= 0xf0;

		L3170:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L317a;

		L3177:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L317a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x20);
			if (this.oCPU.Flags.GE)
				goto L31ce;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c2)), 0xff);
			if (this.oCPU.Flags.E)
				goto L319b;

			if (this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2be)) >= policy)
				goto L3177;

		L319b:
			// Instruction address 0x25fb:0x31a2, size: 3
			F0_25fb_31d4(playerID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe598), (byte)((sbyte)xPos));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe798), (byte)((sbyte)yPos));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c2), (byte)((sbyte)active));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2be), (byte)((sbyte)policy));

		L31ce:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_304d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		public void F0_25fb_31d4(short playerID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_31d4({playerID}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1e);
			goto L3216;

		L31e2:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2be)), 0x0);
			if (this.oCPU.Flags.E) goto L3213;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe598));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe599), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe798));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe799), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c2));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xe2c3), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2be));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb2bf), this.oCPU.AX.Low);

		L3213:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L3216:
			this.oCPU.AX.Word = param2;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L31e2;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_31d4");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_25fb_3223_ClearStrategicLocations(short playerID)
		{
			for (int i = 0; i < 16; i++)
			{
				this.oParent.GameState.Players[playerID].StrategicLocations[i].Active = -1;
				this.oParent.GameState.Players[playerID].StrategicLocations[i].Policy = 0;
			}
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="active"></param>
		/// <param name="policy"></param>
		public void F0_25fb_3251_AddStrategicLocation(short playerID, ushort xPos, ushort yPos, ushort active, ushort policy)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3251_AddStrategicLocation({playerID}, {xPos}, {yPos}, {active}, {policy})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L3262;

		L325f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L3262:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x10);
			if (this.oCPU.Flags.GE) goto L329c;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, xPos);
			if (this.oCPU.Flags.NE) goto L325f;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, yPos);
			if (this.oCPU.Flags.NE) goto L325f;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Active;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, active);
			if (this.oCPU.Flags.NE) goto L325f;

			this.oCPU.AX.Low = this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Policy;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, policy);
			if (this.oCPU.Flags.G) goto L325f;
			goto L32fa;

		L329c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L32a6;

		L32a3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L32a6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x10);
			if (this.oCPU.Flags.GE) goto L32fa;

			if (this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Active == -1)
				goto L32c7;

			this.oCPU.AX.Low = this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Policy;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, policy);
			if (this.oCPU.Flags.GE) goto L32a3;

		L32c7:
			// Instruction address 0x25fb:0x32ce, size: 3
			F0_25fb_32ff_AppendStrategicLocation(playerID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X = (sbyte)xPos;
			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y = (sbyte)yPos;
			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Active = (sbyte)active;
			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Policy = (byte)policy;

		L32fa:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3251_AddStrategicLocation");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="position"></param>
		public void F0_25fb_32ff_AppendStrategicLocation(short playerID, ushort position)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_32ff_AppendStrategicLocation({playerID}, {position})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xe);

			goto L3341;

		L330d:
			if (this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Policy == 0)
					goto L333e;

			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 1].Position.X =
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X;

			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 1].Position.Y =
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y;

			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 1].Active =
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Active;

			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 1].Policy =
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Policy;

		L333e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L3341:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), position);
			if (this.oCPU.Flags.GE) goto L330d;

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_32ff_AppendStrategicLocation");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param5"></param>
		public void F0_25fb_3401(short playerID, ushort param2, int xPos, int yPos, ushort param5)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3401({playerID}, {param2}, {xPos}, {yPos}, {param5})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L340d:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Active;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, param2);
			if (this.oCPU.Flags.NE) goto L344b;

			// Instruction address 0x25fb:0x3433, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				xPos,
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.X,
				yPos,
				this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = param5;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L344b;

			this.oParent.GameState.Players[playerID].StrategicLocations[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Active = -1;

		L344b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x10);
			if (this.oCPU.Flags.L) goto L340d;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3401");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		public void F0_25fb_3459(short playerID, ushort param2)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3459({playerID}, {param2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L3465:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L34a7;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L34a7;
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.E) goto L349d;

			// Instruction address 0x25fb:0x3490, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, param2);
			if (this.oCPU.Flags.NE) goto L34a7;

		L349d:
			// Instruction address 0x25fb:0x34a1, size: 3
			F0_25fb_34b6(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

		L34a7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.L) goto L3465;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3459");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_25fb_34b6(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_34b6({cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (byte)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			
			if (this.oParent.GameState.Cities[cityID].CurrentProductionID < 0)
				goto L34ea;
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].UnitsInProduction[this.oParent.GameState.Cities[cityID].CurrentProductionID]--;

		L34ea:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x34fc, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), cityID);
			
			this.oParent.GameState.Cities[cityID].CurrentProductionID = (sbyte)this.oCPU.AX.Low;

			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.L) goto L351b;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].UnitsInProduction[this.oParent.GameState.Cities[cityID].CurrentProductionID]++;

		L351b:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_34b6");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F0_25fb_3521(short playerID, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3521({playerID}, {param2}, {param3})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L35d0;

		L353a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L353f:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x355c, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L35b0;

			// Instruction address 0x25fb:0x356f, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L35b0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L35b0;

			// Instruction address 0x25fb:0x359f, size: 5
			this.oParent.Graphics.F0_VGA_038c_GetPixel(2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.HumanPlayerID);
			if (this.oCPU.Flags.NE) goto L35b0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L35b0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8);
			if (this.oCPU.Flags.LE) goto L353f;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L35cd;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

		L35cd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L35d0:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.G) goto L3624;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, param2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, param3);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x35f8, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L35cd;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x0);
			if (this.oCPU.Flags.NE) goto L360e;
			goto L353a;

		L360e:
			// Instruction address 0x25fb:0x3614, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L3622;
			goto L353a;

		L3622:
			goto L35cd;

		L3624:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3521");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_25fb_362d(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_362d({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x54);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), 
				(short)this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);

			if (this.oParent.GameState.Players[playerID].Units[unitID].Position.Y < 2)
				goto L3654;

			if (this.oParent.GameState.Players[playerID].Units[unitID].Position.Y < 0x30)
				goto L3665;

		L3654:
			// Instruction address 0x25fb:0x365a, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);
			
			goto L3e96;

		L3665:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x3684, size: 5
			this.oParent.Segment_1866.F0_1866_1725(playerID,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x0);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8),
				(short)this.oParent.GameState.Players[playerID].Units[unitID].TypeID);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), 0x5);
			if (this.oCPU.Flags.NE)
				goto L395c;

			if (this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID != -1)
				goto L36d9;

		L36c5:
			// Instruction address 0x25fb:0x36cb, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);

		L36d3:
			this.oCPU.AX.Word = 0x20;
			goto L3e96;

		L36d9:
			// Instruction address 0x25fb:0x36df, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), 0x1);
			goto L370c;

		L36f1:
			// Instruction address 0x25fb:0x36f7, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L3709;

		L3703:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38));
			goto L3e96;

		L3709:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))));

		L370c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)), 0x8);
			if (this.oCPU.Flags.LE) goto L3715;
			goto L38a2;

		L3715:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x25fb:0x3722, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a), 0x8);
			if (this.oCPU.Flags.G) goto L36f1;

			// Instruction address 0x25fb:0x3742, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L36f1;

			// Instruction address 0x25fb:0x3755, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L36f1;

			// Instruction address 0x25fb:0x3767, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L3775;
			goto L36f1;

		L3775:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0x1);
			if (this.oCPU.Flags.G) goto L377e;
			goto L36f1;

		L377e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0x30);
			if (this.oCPU.Flags.L) goto L3787;
			goto L36f1;

		L3787:
			this.oCPU.AX.Word = this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))];
			
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L37ac;
			goto L386f;

		L37ac:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID != this.oParent.GameState.HumanPlayerID)
				goto L386f;

			// Instruction address 0x25fb:0x37ce, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x37de, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L37ed;
			goto L386f;

		L37ed:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			
			this.oParent.GameState.Players[playerID].Units[unitID].VisibleByPlayer |= (ushort)(1 << this.oParent.GameState.HumanPlayerID);

			// Instruction address 0x25fb:0x3813, size: 5
			this.oParent.Segment_1866.F0_1866_16a9(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x3);

			// Instruction address 0x25fb:0x3829, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Barbarian raiding party\nlands near ");

			// Instruction address 0x25fb:0x3837, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x3843, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName((short)this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x3853, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\nCitizens are alarmed.\n");


			// Instruction address 0x25fb:0x3867, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 32);

		L386f:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].VisibleByPlayer |= 
				this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))];

			this.oParent.GameState.Players[playerID].Units[unitID].RemainingMoves = 0;

			this.oCPU.AX.Word = 0x75;

			goto L3e96;

		L38a2:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X != -1)
				goto L3957;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L38c6:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L391c;

			// Instruction address 0x25fb:0x38e7, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.CX.Word;

			// Instruction address 0x25fb:0x38f7, size: 5
			this.oParent.Segment_2459.F0_2459_0687(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x32);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.DI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L391c;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);

		L391c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x80);
			if (this.oCPU.Flags.L) goto L38c6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x0);
			if (this.oCPU.Flags.NE) goto L392f;
			goto L36c5;

		L392f:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.Y;

		L3957:
			this.oCPU.AX.Word = 0;
			goto L3e96;

		L395c:
			// Instruction address 0x25fb:0x3962, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a), 0x0);
			if (this.oCPU.Flags.NE) goto L39a0;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID == -1)
				goto L399a;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), 0x2);
			if (this.oCPU.Flags.NE) goto L39a0;

		L399a:
			this.oCPU.AX.Word = 0x66;
			goto L3e96;

		L39a0:
			this.oCPU.AX.Word = 0xfffe;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			this.oCPU.AX.Low = (byte)((sbyte)unitID);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, (byte)(this.oParent.GameState.TurnCount & 0xff));
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x3);
			if (this.oCPU.Flags.NE) goto L39f1;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x39c8, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.Y);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x39d8, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L39e7;
			goto L36c5;

		L39e7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a), 0x8);
			if (this.oCPU.Flags.LE) goto L39f1;
			goto L36c5;

		L39f1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0xffff);
			if (this.oCPU.Flags.E) goto L3a60;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x3a0b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.Y);

			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x3a1b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.NE) goto L3a60;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L3a60;
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.X);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
			this.oCPU.AX.Word = (ushort)Math.Sign((short)this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
			this.oCPU.AX.Word = (ushort)Math.Sign((short)this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);

		L3a60:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].PlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.SI.Word);
			if (this.oCPU.Flags.E) goto L3a86;

			if (this.oParent.GameState.Players[this.oCPU.SI.Word].CityCount >= 2 ||
				this.oParent.GameState.Players[this.oCPU.SI.Word].Coins >= 100) goto L3a8f;

		L3a86:
			this.oCPU.AX.Word = 0xfffe;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);

		L3a8f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40)), 0xfffe);
			if (this.oCPU.Flags.E) goto L3acf;
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e))].Position.Y;
			
			// Instruction address 0x25fb:0x3ac3, size: 5
			this.oParent.Segment_2e31.F0_2e31_000e(playerID, unitID);
			
			this.oParent.GameState.Players[playerID].Units[unitID].GoToNextDirection = (sbyte)this.oCPU.AX.Low;

		L3acf:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X = -1;

			if (this.oParent.GameState.Players[playerID].Units[unitID].TypeID != 26)
				goto L3b9b;

			// Instruction address 0x25fb:0x3afc, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oParent.GameState.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID == -1)
				goto L3b25;

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L3b25;
			
			if (this.oParent.GameState.Players[playerID].Units[this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID].TypeID != 26)
				goto L36d3;

		L3b25:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0xa);
			if (this.oCPU.Flags.E) goto L3bac;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			// Instruction address 0x25fb:0x3b55, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0177(playerID, unitID,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.X,
				this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a), 0x3);
			if (this.oCPU.Flags.G) goto L3b8a;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))].TypeID == 26)
				goto L3b8a;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.X =
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))].Position.X;

			this.oParent.GameState.Players[playerID].Units[unitID].GoToPosition.Y =
				this.oParent.GameState.Players[playerID].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))].Position.Y;

			this.oCPU.AX.Word = 0;

			goto L3e96;

		L3b8a:
			this.oCPU.AX.Word = (ushort)oParent.GameState.TurnCount;
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			if (this.oCPU.Flags.G) goto L3b9b;
			goto L36c5;

		L3b9b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0xfc19);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), 0x1);
			goto L3bda;

		L3bac:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0x3);
			if (this.oCPU.Flags.GE) goto L3b9b;
			goto L36c5;

		L3bb5:
			this.oCPU.AX.Word = 0;

		L3bb7:
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54), this.oCPU.CX.Word);

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 2)
				goto L3bd0;

			this.oCPU.AX.Word = 0x1;
			goto L3bd2;

		L3bd0:
			this.oCPU.AX.Word = 0;

		L3bd2:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x54)));
			if (this.oCPU.Flags.E) goto L3c34;

		L3bd7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38))));

		L3bda:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)), 0x9);
			if (this.oCPU.Flags.L) goto L3be3;
			goto L3e4a;

		L3be3:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			// Instruction address 0x25fb:0x3c03, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oParent.GameState.Players[playerID].Units[unitID].Position.X +
					this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1882)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Players[playerID].Units[unitID].Position.Y);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x18e4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), this.oCPU.AX.Word);

			// Instruction address 0x25fb:0x3c1f, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE)
				goto L3bb5;

			this.oCPU.AX.Word = 0x1;

			goto L3bb7;

		L3c34:
			// Instruction address 0x25fb:0x3c3a, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L3bd7;

			// Instruction address 0x25fb:0x3c4c, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].TypeID != 26)
				goto L3cc7;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0xffff);
			if (this.oCPU.Flags.E) goto L3c8c;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L3c86;
			this.oCPU.AX.Word = 0x63;
			goto L3c89;

		L3c86:
			this.oCPU.AX.Word = 0xff9d;

		L3c89:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));

		L3c8c:
			// Instruction address 0x25fb:0x3c92, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			// Instruction address 0x25fb:0x3c9e, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(4));

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28e));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));
			goto L3e30;

		L3cc7:
			// Instruction address 0x25fb:0x3ccd, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L3d05;

			// Instruction address 0x25fb:0x3cdf, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L3d05;

			// Instruction address 0x25fb:0x3cf2, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L3d02;
			goto L3bd7;

		L3d02:
			goto L3703;

		L3d05:
			// Instruction address 0x25fb:0x3d09, size: 5
			this.oCPU.SI.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(6));

			// Instruction address 0x25fb:0x3d19, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x6);
			if (this.oCPU.Flags.E) goto L3d2a;
			this.oCPU.AX.Word = 0x6;
			goto L3d2c;

		L3d2a:
			this.oCPU.AX.Word = 0;

		L3d2c:
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x25fb:0x3d34, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L3d45;
			this.oCPU.AX.Word = 0;
			goto L3d48;

		L3d45:
			this.oCPU.AX.Word = 0x4;

		L3d48:
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0xffff);
			if (this.oCPU.Flags.E) goto L3dab;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L3d79;

			// Instruction address 0x25fb:0x3d63, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L3d73;
			goto L3bd7;

		L3d73:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x14));
			goto L3dab;

		L3d79:
			// Instruction address 0x25fb:0x3d7f, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L3d8f;
			goto L3bd7;

		L3d8f:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0)].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e))].TypeID != 26)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
					this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x63));
			}

		L3dab:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0x0);
			if (this.oCPU.Flags.E) goto L3dee;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitID].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitID].TypeID].TerrainCategory != 0)
				goto L3dee;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0xffff);
			if (this.oCPU.Flags.NE) goto L3dee;

			// Instruction address 0x25fb:0x3ddf, size: 5
			this.oParent.Segment_1866.F0_1866_1725(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L3dee;
			goto L3bd7;

		L3dee:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].GoToNextDirection == this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38)))
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10),
					this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x6));
			}

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x40));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1882)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L3e1e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x2));

		L3e1e:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x18e4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L3e30;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x2));

		L3e30:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L3e3b;
			goto L3bd7;

		L3e3b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x38));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			goto L3bd7;

		L3e4a:
			// Instruction address 0x25fb:0x3e50, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L3e7c;
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].Units[unitID].NextUnitID != -1)
				goto L3e7c;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x63);
			if (this.oCPU.Flags.GE) goto L3e7c;
			goto L36d3;

		L3e7c:
			this.oParent.GameState.Players[playerID].Units[unitID].GoToNextDirection = this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));

		L3e96:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_362d");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_25fb_3e9c(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_25fb_3e9c({cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[cityID].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[cityID].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			goto L3f63;

		L3ec3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L3ecd;

		L3eca:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L3ecd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.L) goto L3ed7;
			goto L3f60;

		L3ed7:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TypeID == -1)
				goto L3eca;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1146)), 0x0);
			if (this.oCPU.Flags.E) goto L3eca;

			if (this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NextUnitID == -1)
				goto L3eca;

			// Instruction address 0x25fb:0x3f10, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X,
				this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L3eca;

			// Instruction address 0x25fb:0x3f2f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TypeID].MoveCount * 3 <=
				(short)this.oCPU.CX.Word)
				goto L3eca;

			this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].GoToPosition.X =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

			this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].GoToPosition.Y =
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));

			goto L3eca;

		L3f60:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L3f63:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L3f88;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L3f60;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L3ec3;

			goto L3f60;

		L3f88:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_25fb_3e9c");
		}
	}
}
