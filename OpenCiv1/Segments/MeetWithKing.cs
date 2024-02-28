using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class MeetWithKing
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public MeetWithKing(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="param4"></param>
		public void F6_0000_0000(short playerID, int xPos, int yPos, ushort param4)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_0000({playerID}, {xPos}, {yPos}, {param4})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x36);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x000e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(xPos, yPos);

			// Instruction address 0x0000:0x001c, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(xPos, yPos);
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].ContactPlayerCountdown;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[playerID].LeaderGraphics == 14)
			{
				// Instruction address 0x0000:0x003f, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19b4), "Empress");

				// Instruction address 0x0000:0x004f, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19b6), "Empress");
			}

			this.oCPU.CMPWord(param4, 0x0);
			if (this.oCPU.Flags.E)
			{
				this.oParent.GameState.Players[playerID].ContactPlayerCountdown = this.oParent.GameState.TurnCount;
			}

			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd804, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.AX.Word = param4;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3934, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x1);
			goto L01da;

		L008f:
			this.oCPU.AX.Word = 0;

		L0091:
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].CityCount, this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L010c;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Attack;
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense;

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.LE) goto L010c;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Attack;
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.CX.Word;
			
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense;

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.CX.Word;
			
			if (this.oParent.GameState.DifficultyLevel == 0) goto L00fe;
			this.oCPU.AX.Word = 0x2;
			goto L0101;

		L00fe:
			this.oCPU.AX.Word = 0x4;

		L0101:
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.DI.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), this.oCPU.AX.Word));
			goto L01d7;

		L010c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Attack == 0)
				goto L0131;

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Attack == 0)
				goto L0131;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x1);

		L0131:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].CityCount == 0)
				goto L0182;

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].CityCount, 0x1);
			if (this.oCPU.Flags.LE) goto L0170;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense;

			this.oCPU.CX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.CX.Word));
			goto L01d7;

		L0170:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense;
			goto L01d4;

		L0182:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].CityCount == 0)
				goto L01ac;

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			this.oCPU.AX.Word = (ushort)(this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Attack -
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			goto L01d4;

		L01ac:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			this.oCPU.AX.Word = (ushort)(this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense-
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))].Defense);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);

		L01d4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));

		L01d7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26))));

		L01da:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0xf);
			if (this.oCPU.Flags.GE) goto L01f5;
			if (this.oParent.GameState.Players[playerID].CityCount > 1) goto L01ef;
			goto L008f;

		L01ef:
			this.oCPU.AX.Word = 0x1;
			goto L0091;

		L01f5:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Ranking != 7 ||
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].CityCount <= 4 ||
				this.oParent.GameState.Players[playerID].CityCount <= 1 ||
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ActiveUnits[25] != 0 ||
				this.oParent.GameState.TurnCount <= 200)
			{
				this.oCPU.AX.Word = 0;
			}
			else
			{
				this.oCPU.AX.Word = 1;
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0267;

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 8) == 0)
				goto L02a0;

			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Players[playerID].MilitaryPower);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].MilitaryPower);
			if (this.oCPU.Flags.LE) goto L02a0;

		L0267:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ActiveUnits[25];

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L02a0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x1);

			// Instruction address 0x0000:0x0290, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				10 * this.oParent.GameState.Players[playerID].Ranking, 9999);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);

		L02a0:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.GameState.Players[playerID].ActiveUnits[25] == 0) 
				goto L02c1;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] |= 0x80;

		L02c1:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.GameState.Players[playerID].ActiveUnits[25] == 0) goto L02fb;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ActiveUnits[25];

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L02fb;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x1);

			// Instruction address 0x0000:0x02f0, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 100, 9999);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L02fb:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.HumanPlayerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ActiveUnits[25] == 0)
				goto L034c;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].ActiveUnits[25];

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0321;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x4);
			goto L034c;

		L0321:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.HumanPlayerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].ActiveUnits[25];
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].ActiveUnits[25];
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L034c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x0);
			if (this.oCPU.Flags.E) goto L035c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L035c:
			// Instruction address 0x0000:0x0364, size: 5
			this.oParent.Segment_1d12.F0_1d12_6c97(this.oParent.GameState.HumanPlayerID, 7);
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0384;

			// Instruction address 0x0000:0x0378, size: 5
			this.oParent.Segment_1d12.F0_1d12_6c97(this.oParent.GameState.HumanPlayerID, 0x12);
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0397;

		L0384:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xfffe);
			if (this.oCPU.Flags.NE) goto L0397;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), 0xffff);

		L0397:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 8) == 0)
				goto L03b0;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x1));
			goto L03c2;

		L03b0:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)), 0xfffe);
			if (this.oCPU.Flags.NE) goto L03c2;
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L03c2:
			// Instruction address 0x0000:0x03e2, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) *
					(this.oParent.GameState.DifficultyLevel + 1)) / 32,
				0, 20);

			this.oCPU.CX.Word = 0x32;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.LE) goto L0417;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0417;
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.L) goto L0417;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L0417:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.GameState.Players[playerID].ActiveUnits[25] == 0)
				goto L0464;

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 0x80) != 0)
				goto L0452;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0452;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x32;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L0452:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] |= 0x80;

		L0464:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L0482;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, 
				(ushort)this.oParent.GameState.Players[playerID].MilitaryPower);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].MilitaryPower);
			if (this.oCPU.Flags.GE) goto L0487;

		L0482:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L0487:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0492;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x2);

		L0492:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L04b1;
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 0x4) != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			}

		L04b1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), 0x0);
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 0x8) != 0)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), 0xfffe);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 0x1);

		L04df:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0544;
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))] & 3) == 1)
			{
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].MilitaryPower;
				this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x2);
				this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[playerID].MilitaryPower, this.oCPU.AX.Word);
				if (this.oCPU.Flags.L)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a),
						this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a))));
				}

				if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].MilitaryPower >
					this.oParent.GameState.Players[playerID].MilitaryPower)
				{
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a),
						this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a))));
				}

				this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
				this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

				this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
				this.oCPU.CX.Low = 0x4;
				this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

				if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))] & 0x2) != 0)
				{
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Word);
				}
			}

		L0544:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0x8);
			if (this.oCPU.Flags.L) goto L04df;

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1512));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), 
				this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)), this.oCPU.AX.Word));

			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].MilitaryPower <
				 this.oParent.GameState.Players[playerID].MilitaryPower)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), 
					this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a))));
			}
		
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			// if bit 2 is 0 CX=1, otherwise CX=0
			this.oCPU.CX.Word = (ushort)((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0 ? 1 : 0);
			this.oCPU.CMPWord(this.oCPU.CX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
			if (this.oCPU.Flags.GE) goto L05b3;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L05b3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

			// Instruction address 0x0000:0x05a2, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L05b3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L05b3:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			if (this.oParent.GameState.Players[(ushort)playerID].GovernmentType < 4)
				goto L0606;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0606;
			
			this.oCPU.DI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 8) != 0)
				goto L0606;

			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].MilitaryPower);
			this.oCPU.CX.Word = (ushort)this.oParent.GameState.Players[playerID].MilitaryPower;
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.LE) goto L05f7;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.NE) goto L05f7;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			goto L0606;

		L05f7:
			// Instruction address 0x0000:0x05fe, size: 5
			this.oParent.Segment_2517.F0_2517_04a1(playerID, 2);

		L0606:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L064f;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L064f;
			
			if (this.oParent.GameState.Players[playerID].MilitaryPower <
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].MilitaryPower)
				goto L0640;

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 8) == 0)
				goto L064f;

		L0640:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L064f:
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);

		L0666:
			// Instruction address 0x0000:0x066d, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));
			}
		
			// Instruction address 0x0000:0x0682, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32),
					this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32))));
			}
		
			// Instruction address 0x0000:0x0698, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
			{
				// Instruction address 0x0000:0x06aa, size: 5
				this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
				this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
				if (this.oCPU.Flags.NE)
				{
					this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
					this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
				}
			}
		
			// Instruction address 0x0000:0x06c3, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L0709;

			// Instruction address 0x0000:0x06d5, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0709;

			// Instruction address 0x0000:0x06e7, size: 5
			this.oParent.Segment_1ade.F0_1ade_2317(playerID, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)));
			if (this.oCPU.Flags.L) goto L0709;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x06fe, size: 5
			this.oParent.Segment_1ade.F0_1ade_2317(playerID, this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);

		L0709:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0x48);
			if (this.oCPU.Flags.GE) goto L0715;
			goto L0666;

		L0715:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 0x20) != 0)
				goto L072f;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0738;

		L072f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32)), 0x6);
			if (this.oCPU.Flags.LE) goto L0738;
			goto L0822;

		L0738:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x32));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0743;
			goto L0822;

		L0743:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xffff);
			if (this.oCPU.Flags.NE) goto L074c;
			goto L0822;

		L074c:
			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0762;
			goto L0822;

		L0762:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x077b, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0787, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x3776);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0822;

			// Instruction address 0x0000:0x07ad, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x07b7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x1);

			// Instruction address 0x0000:0x07cf, size: 5
			this.oParent.Segment_2459.F0_2459_06f2(playerID, oParent.GameState.HumanPlayerID);
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ec);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x1);

			// Instruction address 0x0000:0x07ee, size: 5
			this.oParent.Segment_2459.F0_2459_06f2(this.oParent.GameState.HumanPlayerID, playerID);
			
			// Instruction address 0x0000:0x07f6, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ec);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x1);

			// Instruction address 0x0000:0x0810, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x081a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			goto L064f;

		L0822:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L084e;
			this.oCPU.CMPWord(param4, 0x0);
			if (this.oCPU.Flags.NE) goto L084e;
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) != 2)
				goto L084e;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x2);
			if (this.oCPU.Flags.LE) goto L084e;
			goto L165d;

		L084e:
			this.oCPU.TESTByte((byte)(this.oParent.GameState.DebugFlags & 0xff), 0x1);
			if (this.oCPU.Flags.NE) goto L0869;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);

		L0869:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0872;
			goto L0952;

		L0872:
			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0888;
			goto L0952;

		L0888:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L0891;
			goto L0952;

		L0891:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x08a3, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30ba), this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L08b6;
			
			// Instruction address 0x0000:0x08be, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), "demand");

			goto L08b9;

		L08b6:
			// Instruction address 0x0000:0x08be, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), "request");

		L08b9:
			// Instruction address 0x0000:0x08ca, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x378f);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L08dd;
			this.oCPU.AX.Word = 0x2;
			goto L08e0;

		L08dd:
			this.oCPU.AX.Word = 0x1;

		L08e0:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L08fb;

			// Instruction address 0x0000:0x08f3, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

		L08fb:
			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0952;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

			// Instruction address 0x0000:0x091c, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L092d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L092d:
			// Instruction address 0x0000:0x0938, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)),
				2);
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30))].Diplomacy[this.oParent.GameState.HumanPlayerID] |= 8;

		L0952:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L095b;
			goto L0a28;

		L095b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x2);
			if (this.oCPU.Flags.E) goto L0964;
			goto L0a28;

		L0964:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins, this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0976;
			goto L0a28;

		L0976:
			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L098c;
			goto L0a28;

		L098c:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x09a9, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 10));

			// Instruction address 0x0000:0x09b9, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30bc), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x09ca, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x3797);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			// Instruction address 0x0000:0x09e8, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0a23;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins -= (short)this.oCPU.AX.Word;
			this.oParent.GameState.Players[playerID].Coins += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L0a23:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x3e7);

		L0a28:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.NE) goto L0a31;
			goto L0ad0;

		L0a31:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0a3a;
			goto L0ad0;

		L0a3a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x3e7);
			if (this.oCPU.Flags.NE) goto L0a44;
			goto L0ad0;

		L0a44:
			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0ad0;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0a6a, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0a76, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x37a0);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			// Instruction address 0x0000:0x0a94, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0acb;

			// Instruction address 0x0000:0x0abe, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				this.oParent.GameState.HumanPlayerID);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0x0);

		L0acb:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x3e7);

		L0ad0:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L0ad9;
			goto L0b5f;

		L0ad9:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L0b5f;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x32);
			if (this.oCPU.Flags.LE) goto L0b5f;

			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0b54;

			// Instruction address 0x0000:0x0b0a, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			
			// Instruction address 0x0000:0x0b1b, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x37a9);

		L0b1a:
			// Instruction address 0x0000:0x0b27, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0000(0x28);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_251d(0xba06, 0x14, 0x8b);

			goto L0c13;

		L0b54:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0bee, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x37b2);

			goto L0bed;

		L0b5f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0b98;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x3e7);
			if (this.oCPU.Flags.NE) goto L0b98;

			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0b82;
			goto L0c29;

		L0b82:
			// Instruction address 0x0000:0x0b86, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			
			// Instruction address 0x0000:0x0b1b, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x37bb);

			goto L0b1a;

		L0b98:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L0ba1;
			goto L0c29;

		L0ba1:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 1) == 0)
				goto L0bbb;

			this.oCPU.CMPWord(param4, 0x0);
			if (this.oCPU.Flags.E) goto L0c29;

		L0bbb:
			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0be5;

			// Instruction address 0x0000:0x0bd2, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			
			// Instruction address 0x0000:0x0b1b, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x37c3);

			goto L0b1a;

		L0be5:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0bee, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x37c8);

		L0bed:
			// Instruction address 0x0000:0x0bfa, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0000(0x28);

			// Instruction address 0x0000:0x0c0e, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 40, 100);

		L0c13:
			// Instruction address 0x0000:0x0c21, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(oParent.GameState.HumanPlayerID, playerID, 2);

		L0c29:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0c32;
			goto L1097;

		L0c32:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L0c4f;

			this.oCPU.CMPWord(param4, 0x0);
			if (this.oCPU.Flags.NE) goto L0c4f;
			goto L1097;

		L0c4f:
			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0c65;
			goto L1097;

		L0c65:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0c6e, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x37cd);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0cc6;

			F6_0000_1a3f(playerID);

			F6_0000_1a99(playerID);

			this.oParent.GameState.Players[playerID].ContactPlayerCountdown = 
				(short)(oParent.GameState.TurnCount + 16);
			goto L1097;

		L0cc6:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType < 4) goto L0d03;

			// Instruction address 0x0000:0x0cdb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "You are overruled by the Senate.\nTreaty signed.\n");

			F6_0000_251d(0xba06, 0x14, 0x8b);

			F6_0000_1a99(playerID);
			
			goto L1097;

		L0d03:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L0d2a;

			// Instruction address 0x0000:0x0d22, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(this.oParent.GameState.HumanPlayerID, playerID, 2);

		L0d2a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x4);
			if (this.oCPU.Flags.GE) goto L0d33;
			goto L0e0e;

		L0d33:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0d3c;
			goto L0e0e;

		L0d3c:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 0xa) != 0)
				goto L0e0e;

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x0d61, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), this.oCPU.AX.Word);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0d72, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x3805);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0e0e;

			// Instruction address 0x0000:0x0d9e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x0da8, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x0dad, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x1);

			// Instruction address 0x0000:0x0dc8, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), playerID);
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ec);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0dda, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);

			// Instruction address 0x0000:0x0de5, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x0def, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			F6_0000_1a3f(playerID);

			F6_0000_1a99(playerID);
			
			this.oCPU.AX.Word = (ushort)oParent.GameState.TurnCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

		L0e0e:
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 0xa) != 0)
				goto L0eed;

			// Instruction address 0x0000:0x0e43, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)) * 2) - 4,
				0, this.oParent.GameState.Players[playerID].Coins / 50);

			this.oCPU.CX.Word = 0x32;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0e5a;
			goto L0eed;

		L0e5a:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0e77, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 10));

			// Instruction address 0x0000:0x0e87, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30bc), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0e98, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x380e);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L0eed;

			F6_0000_1a3f(playerID);

			F6_0000_1a99(playerID);
			
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins += (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), this.oCPU.AX.Word));
			this.oCPU.AX.Word = (ushort)oParent.GameState.TurnCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

		L0eed:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), 0x0);
			if (this.oCPU.Flags.NE) goto L0ef6;
			goto L1041;

		L0ef6:
			if (this.oParent.GameState.Players[playerID].CityCount <= 1) goto L0f05;
			goto L1041;

		L0f05:
			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[(ushort)playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 0xa) != 0)
				goto L1041;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0f3a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].Coins, 10));

			// Instruction address 0x0000:0x0f4a, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30bc), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0f5b, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x3818);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0f8a;
			goto L1041;

		L0f8a:
			F6_0000_1a3f(playerID);

			F6_0000_1a99(playerID);

			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins +=
				this.oParent.GameState.Players[playerID].Coins;
			this.oParent.GameState.Players[playerID].Coins = 0;

			// Instruction address 0x0000:0x0fb2, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x0fbc, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x0fc1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 0x0);

		L0fd1:
			// Instruction address 0x0000:0x0fd8, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L100e;

			// Instruction address 0x0000:0x0fea, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L100e;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3c62, 0x1);
			
			// Instruction address 0x0000:0x1006, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(this.oParent.GameState.HumanPlayerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
				playerID);

		L100e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0x48);
			if (this.oCPU.Flags.L) goto L0fd1;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ec);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1021, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);

			// Instruction address 0x0000:0x102c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x1036, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = (ushort)oParent.GameState.TurnCount;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34), this.oCPU.AX.Word);

		L1041:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) != 0)
				goto L1097;

			// Instruction address 0x0000:0x1059, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x106a, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x3820);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0x4);

			F6_0000_251d(0xba06, 0x14, 0x8b);

		L1097:
			if (this.oParent.GameState.Players[playerID].LeaderGraphics == 14)
			{
				// Instruction address 0x0000:0x10ab, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19b4), this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x33aa));

				// Instruction address 0x0000:0x10bb, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19b6), this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x33a8));
			}
		
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L10d2;
			goto L11d6;

		L10d2:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) != 2)
				goto L11d6;

			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1102;
			goto L11d6;

		L1102:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x0);
			if (this.oCPU.Flags.E) goto L112f;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x3e7);
			if (this.oCPU.Flags.E) goto L112f;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0x4);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x1124, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x382a);

			goto L11c3;

		L112f:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			// Instruction address 0x0000:0x1143, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "We welcome the friendship of the\n");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1159, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			// Instruction address 0x0000:0x1169, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " people and their most\nwise and munificent leader:\n");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1185, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x1195, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x11ab, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			// Instruction address 0x0000:0x11bb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

		L11c3:
			F6_0000_251d(0xba06, 0x14, 0x8b);

		L11d6:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b8e, 0x1);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 2) == 0)
				goto L15e2;

			F6_0000_16cd(playerID, xPos, yPos);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1209;
			goto L15e2;

		L1209:
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1216, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x1227, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x388f);

			this.oCPU.AX.Word = (ushort)oParent.GameState.TurnCount;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x34)));
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x10);
			if (this.oCPU.Flags.L) goto L1247;
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType < 4) goto L124d;

		L1247:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x4);

		L124d:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.ActiveCivilizations);
			if (this.oCPU.Flags.NE) goto L126b;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xb276, this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xb276), 0x2));

		L126b:
			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L1289;
			goto L13a5;

		L1289:
			this.oCPU.SI.Word = (ushort)(playerID << 1);

			// Instruction address 0x0000:0x129f, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
				0, this.oParent.GameState.Players[playerID].Coins / 50);

			this.oCPU.CX.Word = 0x32;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1332;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x12d0, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 10));

			// Instruction address 0x0000:0x12e0, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30bc), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x12f1, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x3897);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins += (short)this.oCPU.AX.Word;
			this.oParent.GameState.Players[playerID].Coins -= 
				(short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oParent.GameState.Players[playerID].ContactPlayerCountdown = this.oParent.GameState.TurnCount;
			goto L13a5;

		L1332:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x0);
			if (this.oCPU.Flags.E) goto L1376;

			// Instruction address 0x0000:0x133c, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(0x21, 0);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x134d, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x38a1);

			// Instruction address 0x0000:0x1360, size: 5
			this.oParent.Segment_2517.F0_2517_0aa1_ClearDiplomacyFlags(this.oParent.GameState.HumanPlayerID, playerID, 2);
			
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);
			goto L1392;

		L1376:
			// Instruction address 0x0000:0x137e, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "We ignore your feeble threats.\n");

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0x4);

		L1392:
			F6_0000_251d(0xba06, 0x14, 0x8b);

		L13a5:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)), 0x1);
			if (this.oCPU.Flags.E) goto L13ae;
			goto L15e2;

		L13ae:
			// Instruction address 0x0000:0x13b6, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "You must attack the evil:\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 0x1);
			goto L1400;

		L13ca:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1e), this.oCPU.AX.Word);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x13e5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x0000:0x13f5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

		L13fd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))));

		L1400:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0x8);
			if (this.oCPU.Flags.GE) goto L1426;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L13fd;
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L13fd;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.ActiveCivilizations);
			if (this.oCPU.Flags.NE) goto L13ca;
			goto L13fd;

		L1426:
			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L144a;
			goto L15e2;

		L144a:
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x1e));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x1460, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0x4);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))] & 1) != 0)
				goto L1487;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x15c7, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x38e9);

			goto L15cf;

		L1487:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))] & 2) != 0)
				goto L14c1;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x14a3, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x38f4);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			goto L1209;

		L14c1:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			// Instruction address 0x0000:0x14f1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				((this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))].MilitaryPower / 2) *
					(this.oParent.GameState.Players[playerID].Coins / 100)) / 50,
				2, 9999);

			this.oCPU.CX.Word = 0x32;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x151e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 10));

			// Instruction address 0x0000:0x152e, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30bc), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x153f, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x38fb);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1562;
			goto L15e2;

		L1562:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L15be;

			this.oParent.GameState.Players[playerID].Coins += (short)this.oCPU.AX.Word;
			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Coins -= (short)this.oCPU.AX.Word;

			// Instruction address 0x0000:0x1584, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			// Instruction address 0x0000:0x1594, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " declare war\non the ");

			// Instruction address 0x0000:0x15a4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1992)));

			// Instruction address 0x0000:0x15b4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");
			goto L15cf;

		L15be:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x15c7, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x391e);

		L15cf:
			F6_0000_251d(0xba06, 0x14, 0x8b);

		L15e2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0x0);
			if (this.oCPU.Flags.E) goto L15fa;
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] |= 0x100;

		L15fa:
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] &= 0xffdf;

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[playerID] &= 0xffdf;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.E) goto L165d;
			
			if (this.oParent.GameState.Players[playerID].CityCount <= 4)
				goto L165d;

			if ((this.oParent.GameState.Players[oParent.GameState.HumanPlayerID].Ranking + 1) >=
				this.oParent.GameState.Players[playerID].Ranking)
				goto L165d;
			
			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[playerID] & 2) != 0)
				goto L165d;

			// Instruction address 0x0000:0x1649, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30ba), this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1992)));

			this.oParent.Help.F4_0000_02d3(0x392b);

		L165d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.E) goto L1668;

			F6_0000_16ac();

		L1668:
			if (this.oParent.GameState.Players[playerID].LeaderGraphics == 14)
			{
				// Instruction address 0x0000:0x167c, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19b4), this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x33aa));

				// Instruction address 0x0000:0x168c, size: 5
				this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19b6), this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x33a8));
			}

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd804, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3934, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0xffff);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F6_0000_16ac()
		{
			this.oCPU.Log.EnterBlock("F6_0000_16ac()");

			// function body
			F6_0000_233c();

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);

			// Instruction address 0x0000:0x16b9, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0xffff);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3934, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd804, this.oCPU.AX.Word);

			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_16ac");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F6_0000_16cd(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_16cd({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd804), 0x0);
			if (this.oCPU.Flags.E) goto L16de;

		L16d8:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934);
			goto L1871;

		L16de:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd804, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0x0);
			if (this.oCPU.Flags.E) goto L16ee;
			goto L17c7;

		L16ee:
			if (xPos == -1)
				goto L170d;

			// Instruction address 0x0000:0x1705, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008(oParent.GameState.HumanPlayerID, xPos - 8, yPos - 2);

		L170d:
			// Instruction address 0x0000:0x1715, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "An emissary from the\n");

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x172a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			// Instruction address 0x0000:0x173a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " wishes to\nspeak with you.\n");

			// Instruction address 0x0000:0x174a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Will you receive him?\n Yes.\n No.\n");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[playerID] & 0x40) == 0)
				goto L1771;

			// Instruction address 0x0000:0x1769, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Check Intelligence\n");

		L1771:
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x1787, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1518)), 3);

			// Instruction address 0x0000:0x178f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0280();

			// Instruction address 0x0000:0x17a0, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3934, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x17ad, size: 5
			this.oParent.Segment_11a8.F0_11a8_0294();

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xfffe);
			if (this.oCPU.Flags.NE) goto L17c7;
			
			this.oParent.Overlay_14.F14_0000_1164(playerID);
			
			goto L170d;

		L17c7:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.NE) goto L17d1;
			goto L16d8;

		L17d1:
			// Instruction address 0x0000:0x17d1, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			
			F6_0000_1d2b(playerID);

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Players[playerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x1802, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x151a)), 3);

			// Instruction address 0x0000:0x180a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].LeaderGraphics;
			this.oCPU.ES.Word = 0x36fa; // segment
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.ES.Word, (ushort)(this.oCPU.BX.Word + 0x0));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67ec, this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E)
			{
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67ec, 0x3);
			}
		
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ec);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd2dc, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67e8, 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7ef4, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);

			F6_0000_1874(playerID);
			
			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			goto L16d8;

		L1871:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_16cd");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F6_0000_1874(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_1874({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oParent.GameState.HumanPlayerID] & 8) != 0)
			{
				// Instruction address 0x0000:0x189c, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "O most untrustworthy leader of the\ninfidels, hear now ");
			}
			else
			{
				// Instruction address 0x0000:0x189c, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, "Greetings from ");
			}

			// Instruction address 0x0000:0x18a8, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(4));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L18cc;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L192a;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L18c1;
			goto L196a;

		L18c1:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L18c9;
			goto L19bb;

		L18c9:
			goto L19e6;

		L18cc:
			// Instruction address 0x0000:0x18d4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "the most exalted\n");

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x18ef, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x18ff, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ": ");

			// Instruction address 0x0000:0x190f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)));

			// Instruction address 0x0000:0x191f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			goto L19e6;

		L192a:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1937, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)));

			// Instruction address 0x0000:0x1947, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ", ruler\nand ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x195d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x191f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			goto L19e6;

		L196a:
			// Instruction address 0x0000:0x1972, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "our most wise\n");

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x198d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x199d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ": ");

			// Instruction address 0x0000:0x19ad, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)));

			// Instruction address 0x0000:0x191f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			goto L19e6;

		L19bb:
			// Instruction address 0x0000:0x19c3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "he who makes mortals\ntremble: ");

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x19d8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			// Instruction address 0x0000:0x191f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " ");

			goto L19e6;

		L19e6:
			// Instruction address 0x0000:0x19ee, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "of the ");

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1a03, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x0000:0x1a13, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "...\n");

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Players[playerID].ActiveUnits[25] != 0)
			{
				// Instruction address 0x0000:0x1a32, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "Our words are backed\nwith NUCLEAR WEAPONS!\n");
			}

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_1874");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F6_0000_1a3f(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_1a3f({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1a4f, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1a65, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8), this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, 0xc);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x1a7c, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x3a8c);

			F6_0000_251d(0xba06, 0x14, 0x8b);
			
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_1a3f");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F6_0000_1a99(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_1a99({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x1aab, size: 5
			this.oParent.Segment_2517.F0_2517_0a30_SetDiplomacyFlags(this.oParent.GameState.HumanPlayerID, playerID, 2);

			this.oParent.GameState.Players[playerID].ContactPlayerCountdown = (short)(this.oParent.GameState.TurnCount + 16);

			if (this.oParent.GameState.DifficultyLevel != 0) goto L1b2e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

		L1ace:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L1b24;

			// Instruction address 0x0000:0x1af1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID !=
				this.oParent.GameState.HumanPlayerID) goto L1b24;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a), 0x2);
			if (this.oCPU.Flags.G) goto L1b24;

			// Instruction address 0x0000:0x1b1c, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

		L1b24:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x80);
			if (this.oCPU.Flags.L) goto L1ace;

		L1b2e:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_1a99");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F6_0000_1b33()
		{
			this.oCPU.Log.EnterBlock("F6_0000_1b33()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7ef4, 0xffff);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd76c), 0x0);
			if (this.oCPU.Flags.E) goto L1b50;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x0);
			if (this.oCPU.Flags.NE) goto L1b50;
			goto L1cc0;

		L1b50:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3ab8)), 0x0);
			if (this.oCPU.Flags.E) goto L1b9a;
			if (this.oCPU.Flags.LE) goto L1b64;

		L1b5d:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4)));
			goto L1c64;

		L1b64:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3ab8));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xfffd);
			if (this.oCPU.Flags.E) goto L1b91;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xfffe);
			if (this.oCPU.Flags.E) goto L1b88;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1b7f;
			goto L1c64;

		L1b7f:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, 0x0);
			goto L1c64;

		L1b88:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, 0x6);
			goto L1c64;

		L1b91:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, 0xe);
			goto L1c64;

		L1b9a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3936);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1bb2;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L1c08;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L1c16;
			goto L1bce;

		L1bb2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b8e), 0x0);
			if (this.oCPU.Flags.E) goto L1bbd;
			this.oCPU.AX.Low = 0x4;
			goto L1bbf;

		L1bbd:
			this.oCPU.AX.Low = 0x2;

		L1bbf:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x3a9a, this.oCPU.AX.Low);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x6);
			if (this.oCPU.Flags.E) goto L1bce;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x3);

		L1bce:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd76c), 0x0);
			if (this.oCPU.Flags.E) goto L1be1;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x0);
			if (this.oCPU.Flags.E) goto L1be1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L1be1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
			if (this.oCPU.Flags.E) goto L1c44;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x0);
			if (this.oCPU.Flags.NE) goto L1bf4;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, this.oCPU.AX.Word);

		L1bf4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x6);
			if (this.oCPU.Flags.NE) goto L1bfe;
			goto L1b5d;

		L1bfe:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0xe);
			if (this.oCPU.Flags.NE) goto L1c64;
			goto L1b5d;

		L1c08:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x0);
			if (this.oCPU.Flags.E) goto L1bce;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L1bce;

		L1c16:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b8e), 0x0);
			if (this.oCPU.Flags.E) goto L1c21;
			this.oCPU.AX.Low = 0xb;
			goto L1c23;

		L1c21:
			this.oCPU.AX.Low = 0x7;

		L1c23:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x3ab4, this.oCPU.AX.Low);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b8e), 0x0);
			if (this.oCPU.Flags.E) goto L1c31;
			this.oCPU.AX.Low = 0xb;
			goto L1c33;

		L1c31:
			this.oCPU.AX.Low = 0x7;

		L1c33:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x3ab7, this.oCPU.AX.Low);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0xe);
			if (this.oCPU.Flags.E) goto L1bce;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xc);
			goto L1bce;

		L1c44:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7ef4, 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0xe);
			if (this.oCPU.Flags.NE) goto L1c57;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7ef4, 0x1);

		L1c57:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x6);
			if (this.oCPU.Flags.NE) goto L1c64;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7ef4, 0x2);

		L1c64:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f6), 0x0);
			if (this.oCPU.Flags.NE) goto L1caa;

			// Instruction address 0x0000:0x1c6f, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(12));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1caa;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3ab8)), 0x0);
			if (this.oCPU.Flags.NE) goto L1caa;
			this.oCPU.BX.Word = this.oCPU.ORWord(this.oCPU.BX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.NE) goto L1c90;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, 0x1);

		L1c90:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x6);
			if (this.oCPU.Flags.NE) goto L1c9d;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, 0xa);

		L1c9d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0xe);
			if (this.oCPU.Flags.NE) goto L1caa;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, 0x11);

		L1caa:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3a94));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3aa6));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			goto L1d02;

		L1cc0:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f4), 0x0);
			if (this.oCPU.Flags.E) goto L1ccc;
			this.oCPU.AX.Word = 0x5;
			goto L1ccf;

		L1ccc:
			this.oCPU.AX.Word = 0xffff;

		L1ccf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1cd6, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1ce7;
			this.oCPU.AX.Word = 0x9;
			goto L1ce9;

		L1ce7:
			this.oCPU.AX.Word = 0;

		L1ce9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xd76c), 0x3);
			if (this.oCPU.Flags.NE) goto L1cf8;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x8);

		L1cf8:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76c, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd76c)));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f6, 0x4);

		L1d02:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f6), 0x0);
			if (this.oCPU.Flags.E) goto L1d0d;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f6, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f6)));

		L1d0d:
			F6_0000_2362(
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x7ef4));

			// Instruction address 0x0000:0x1d22, size: 5
			this.oParent.Segment_1182.F0_1182_0134_WaitTime(10);

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_1b33");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F6_0000_1d2b(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_1d2b({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x16);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f2, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f0, 0x0);
			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.E) goto L1d49;
			goto L1e2c;

		L1d49:
			// Instruction address 0x0000:0x1d51, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(2, 0);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1d60;
			goto L1e3e;

		L1d60:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f0, 0x1);

			// Instruction address 0x0000:0x1d66, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x1d7a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_03ce_FillRectangleWithPattern(0, 128, 320, 72);

			// Instruction address 0x0000:0x1d99, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a66_DrawShadowRectangle(0, 128, 319, 71, 15, 8);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x1dae, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)));

			// Instruction address 0x0000:0x1dbe, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ": ");

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x1dd4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x1de4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " of the ");

			// Instruction address 0x0000:0x1df4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			// Instruction address 0x0000:0x1e04, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".");

			// Instruction address 0x0000:0x1e1c, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 8, 130, 15);

			// Instruction address 0x0000:0x1e24, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			goto L21a6;

		L1e2c:
			// Instruction address 0x0000:0x1e36, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(2, 1);

		L1e3e:
			// Instruction address 0x0000:0x1e4b, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "govt0a.pic");

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Low);

			// Instruction address 0x0000:0x1e6f, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x14);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67ee, this.oCPU.AX.Word);
			
			if (this.oParent.GameState.Players[playerID].GovernmentType != 3) goto L1e85;

			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x33);
			goto L1e90;

		L1e85:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ee), 0x0);
			if (this.oCPU.Flags.E) goto L1e90;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), 0x6d);

		L1e90:
			// Instruction address 0x0000:0x1e98, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);

		L1ea5:
			// Instruction address 0x0000:0x1ebd, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((0x50 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))) + 1),
				0x65, 0x4e, 0x63);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x6;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x804e), this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x4);
			if (this.oCPU.Flags.L) goto L1ea5;
			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].LeaderGraphics;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3938));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f8, this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x1f00, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4((ushort)((this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8) / 7) + 4), 1);

			// Instruction address 0x0000:0x1f10, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "king00.pic");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb)), this.oCPU.DX.Low));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Low));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L1f46;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8), 0x0);
			if (this.oCPU.Flags.E) goto L1f42;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8), 0x3);
			if (this.oCPU.Flags.NE) goto L1f46;

		L1f42:
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd), 0x6b);

		L1f46:
			// Instruction address 0x0000:0x1f4e, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			// Instruction address 0x0000:0x1f6a, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, 0xb5, 0x43, 0x8b, 0x85);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb1e6, this.oCPU.AX.Word);

			F6_0000_21ac(playerID);
			
			// Instruction address 0x0000:0x1f8c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x804e), 0x3aee);
			
			// Instruction address 0x0000:0x1fa1, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);

		L1fb3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x8);
			if (this.oCPU.Flags.E) goto L1fbf;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xb);
			if (this.oCPU.Flags.NE) goto L1fc3;

		L1fbf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x2));

		L1fc3:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x5;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.AX.Word = this.oCPU.DX.Word;
			this.oCPU.CX.Word = 0x3c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x5;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CX.Word = 0x32;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x2001, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, (ushort)(this.oCPU.DI.Word + 0x1), 0x3b, 0x14);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7efe), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x2021, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, this.oCPU.SI.Word, (ushort)(this.oCPU.DI.Word + 0x15), 0x3b, 0x1d);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7f00), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xe);
			if (this.oCPU.Flags.GE) goto L203f;
			goto L1fb3;

		L203f:
			// Instruction address 0x0000:0x2057, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x2067, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(2, 0);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L2076;
			goto L217a;

		L2076:
			// Instruction address 0x0000:0x207e, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "govt0a.pic");

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Low);
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L20a6;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x33);
			goto L20b1;

		L20a6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ee), 0x0);
			if (this.oCPU.Flags.E) goto L20b1;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xb), 0x6d);

		L20b1:
			// Instruction address 0x0000:0x20b9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
			goto L210f;

		L20c8:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L20cb:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x3);
			if (this.oCPU.Flags.GE) goto L210c;

			// Instruction address 0x0000:0x20ef, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)((0x1d * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))) + 0xa1),
				(ushort)((0x19 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))) + 1),
				0x1c, 0x18);

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x6;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x804e), this.oCPU.CX.Word);
			goto L20c8;

		L210c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

		L210f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x4);
			if (this.oCPU.Flags.GE) goto L211c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L20cb;

		L211c:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67fa, 0x1);

			// Instruction address 0x0000:0x213f, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x2150, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x0000:0x2170, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);
			goto L21a0;

		L217a:
			// Instruction address 0x0000:0x2192, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67fa, 0x0);

		L21a0:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67ea, 0x1);

		L21a6:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_1d2b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F6_0000_21ac(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_21ac({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1e);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f0), 0x0);
			if (this.oCPU.Flags.E) goto L21bd;
			goto L2337;

		L21bd:
			// Instruction address 0x0000:0x21bd, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x21ca, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0xe), "back0a.pic");

			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Low);
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L21f2;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x33);
			goto L21fd;

		L21f2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ee), 0x0);
			if (this.oCPU.Flags.E) goto L21fd;
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x9), 0x6d);

		L21fd:
			// Instruction address 0x0000:0x2205, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0xe), 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			goto L2244;

		L2214:
			// Instruction address 0x0000:0x2239, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.ReadInt16(this.oCPU.DS.Word,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)) << 1) + 0x3afe)),
				34,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)) +
					playerID) & 3) * 6) + 0x804e)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e))));

		L2244:
			this.oCPU.AX.Word = (ushort)((this.oParent.GameState.Players[playerID].Ranking + 1) >> 1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			if (this.oCPU.Flags.G) goto L2214;
			
			// Instruction address 0x0000:0x2267, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				90, 0,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb1e6));

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67f4, 0x0);

			// Instruction address 0x0000:0x227d, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x7), "pal");

			// Instruction address 0x0000:0x228d, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x1c), "king00.pal");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0xa;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x17), this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x17)), this.oCPU.DX.Low));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Low));

			// Instruction address 0x0000:0x22b2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x1c), 0xc1d6);

			// Instruction address 0x0000:0x22c2, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, (ushort)(this.oCPU.BP.Word - 0xe), 0xbdee);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0xc0);

		L22cf:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e));
			this.oCPU.SI.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xc1dc));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xbdf4), this.oCPU.AX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), 0x1b0);
			if (this.oCPU.Flags.L) goto L22cf;

			// Instruction address 0x0000:0x22e6, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();

			// Instruction address 0x0000:0x22fe, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 0);
			
			// Instruction address 0x0000:0x230a, size: 5
			this.oParent.VGADriver.F0_VGA_0162_SetColorsFromColorStruct(0xbdee);
			
			// Instruction address 0x0000:0x232a, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x2332, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L2337:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F6_0000_21ac'");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F6_0000_233c()
		{
			this.oCPU.Log.EnterBlock("F6_0000_233c()");

			// function body
			// Instruction address 0x0000:0x2340, size: 5
			this.oParent.Segment_1000.F0_1000_0a32(1, 0);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ea), 0x0);
			if (this.oCPU.Flags.E) goto L235b;

			// Instruction address 0x0000:0x2353, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x7efe), 0);

		L235b:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67ea, 0x0);
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_233c");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		/// <param name="param3"></param>
		public void F6_0000_2362(ushort param1, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_2362({param1}, {param2}, {param3})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xe);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f0), 0x0);
			if (this.oCPU.Flags.E) goto L2374;
			goto L2517;

		L2374:
			// Instruction address 0x0000:0x2374, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.AX.Word = param3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f2)].GovernmentType;
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.CX.Word);
			if (this.oCPU.Flags.NE) goto L23a4;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x6);
			goto L23af;

		L23a4:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67ee), 0x0);
			if (this.oCPU.Flags.E) goto L23af;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3));

		L23af:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.NE) goto L23b8;
			goto L2485;

		L23b8:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67e8);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L23c3;
			goto L2485;

		L23c3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67fa), 0x0);
			if (this.oCPU.Flags.NE) goto L23cd;
			goto L2485;

		L23cd:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L246d;

		L23d5:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f2));
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x3);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x3afe));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.ES.Word = 0x36fa; // segment
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x80));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.CX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x82));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xa0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0xf0));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x64);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = 0x19;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0xf2));
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.CX.Word));

			// Instruction address 0x0000:0x245c, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 34,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) << 1) +
					(0x6 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))) + 0x804e)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x67e8, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L246d:
			this.oCPU.AX.Word = (ushort)((this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f2)].Ranking + 1) >> 1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			if (this.oCPU.Flags.LE) goto L2485;
			goto L23d5;

		L2485:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x67f8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x5a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Low = 0x2;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);
			this.oCPU.ES.Word = 0x36fa; // segment
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x10));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0xb4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x48));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x40);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.ES.Word, (ushort)(this.oCPU.SI.Word + 0x4a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));
			this.oCPU.CMPWord(param1, 0xffff);
			if (this.oCPU.Flags.E) goto L24eb;
			
			// Instruction address 0x0000:0x24e3, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) - 2,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((param1 << 2) + 0x7efe)));

		L24eb:
			this.oCPU.CMPWord(param2, 0xffff);
			if (this.oCPU.Flags.E) goto L2512;
			
			// Instruction address 0x0000:0x250a, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((param2 << 2) + 0x7f00)));

		L2512:
			// Instruction address 0x0000:0x2512, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L2517:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_2362");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="stringPtr"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F6_0000_251d(ushort stringPtr, ushort xPos, ushort yPos)
		{
			this.oCPU.Log.EnterBlock($"F6_0000_251d(0x{stringPtr:x4}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x2523, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			// Instruction address 0x0000:0x2546, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x80, 0x140, 0x48,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x80);

			this.oCPU.CMPWord(xPos, 0x14);
			if (this.oCPU.Flags.NE) goto L2559;
			xPos = 0x24;

		L2559:
			// Instruction address 0x0000:0x2559, size: 5
			this.oParent.Segment_11a8.F0_11a8_0280();

			// Instruction address 0x0000:0x2567, size: 5
			this.oParent.Segment_2d05.F0_2d05_0031(stringPtr, (short)xPos, (short)yPos, 1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x2572, size: 5
			this.oParent.Segment_11a8.F0_11a8_0294();

			// Instruction address 0x0000:0x2595, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x80, 0x140, 0x48,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x80);

			// Instruction address 0x0000:0x259d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));

			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F6_0000_251d");

			return this.oCPU.AX.Word;
		}
	}
}
