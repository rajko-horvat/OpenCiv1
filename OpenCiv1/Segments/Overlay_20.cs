using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class Overlay_20
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Overlay_20(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="param2"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="citySize"></param>
		/// <returns></returns>
		public ushort F20_0000_0000(short playerID, ushort param2, int xPos, int yPos, ushort citySize)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_0000({playerID}, {param2}, {xPos}, {yPos}, {citySize})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x14);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x0000:0x0017, size: 5
			this.oParent.Segment_25fb.F0_25fb_3401(playerID, 0, xPos, yPos, 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0029;

		L0026:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0029:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.L) goto L0033;
			goto L0502;

		L0033:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L0026;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].LeaderGraphics;
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x7);
			if (this.oCPU.Flags.L) goto L0057;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

		L0057:
			this.oCPU.CX.Low = 0x4;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.CX.Low));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L0062:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);

			if (this.oParent.GameState.CityPositions[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].X == -1)
				goto L00ab;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			if (this.oCPU.Flags.NE) goto L008e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0xe0);

		L008e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x100);
			if (this.oCPU.Flags.NE) goto L00ab;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3e7);
			if (this.oCPU.Flags.NE) goto L00a6;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);

		L00a6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x3e7);

		L00ab:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x0);
			if (this.oCPU.Flags.E) goto L0062;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID = this.oCPU.AX.Low;

			this.oParent.GameState.CityPositions[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))] = new GPoint(xPos, yPos);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L0118;
			
			this.oParent.Overlay_23.F23_0000_0000(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L00fe;

		L00f8:
			this.oCPU.AX.Word = 0xffff;
			goto L053b;

		L00fe:
			byte ubCityNameID = this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID;
			char[] acCityName = this.oParent.GameState.CityNames[ubCityNameID].ToCharArray();
			acCityName[12] = '\0';
			this.oParent.GameState.CityNames[ubCityNameID] = new string(acCityName);

		L0118:
			ubCityNameID = this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0xb);

			while (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) > 0 &&
				this.oParent.GameState.CityNames[ubCityNameID][this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] == ' ')
			{
				acCityName = this.oParent.GameState.CityNames[ubCityNameID].ToCharArray();
				acCityName[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] = '\0';
				this.oParent.GameState.CityNames[ubCityNameID] = new string(acCityName);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc),
					this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			}

			// Instruction address 0x0000:0x016f, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(1, (byte)playerID,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].NameID,
				(byte)xPos, (byte)yPos);

			// Instruction address 0x0000:0x0181, size: 5
			this.oParent.Segment_2aea.F0_2aea_16ee(0x24, xPos, yPos);

			// Instruction address 0x0000:0x0193, size: 5
			this.oParent.Segment_2aea.F0_2aea_1653(9, xPos, yPos);

			// Instruction address 0x0000:0x01a1, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(xPos, yPos);

			this.oCPU.CX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x44a)), 0xffff);
			if (this.oCPU.Flags.GE) goto L01c9;

			// Instruction address 0x0000:0x01c1, size: 5
			this.oParent.Segment_2aea.F0_2aea_1653(2, xPos, yPos);

		L01c9:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag = 0;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X = xPos;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y = yPos;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].ActualSize = (sbyte)citySize;
			this.oCPU.AX.Low = 0;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].VisibleSize = 0;
			
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].WorkerFlags0 = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].WorkerFlags1 = this.oCPU.DX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BaseTrade = (sbyte)this.oCPU.AX.Low;
			this.oCPU.CBW(this.oCPU.AX);
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].FoodCount = (short)this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].ShieldsCount = (short)this.oCPU.AX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BuildingFlags0 = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BuildingFlags1 = this.oCPU.DX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = 1;

			// Instruction address 0x0000:0x021d, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x22);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = 4;
			}
		
			// Instruction address 0x0000:0x0235, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x40);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
			{
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = 5;
			}
		
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Unknown[0] = -1;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Unknown[1] = -1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L026a:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID != playerID) goto L0289;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0289;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L0289:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x80);
			if (this.oCPU.Flags.L) goto L026a;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L02ad;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BuildingFlags0 = 1;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BuildingFlags1 = 0;

		L02ad:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].BaseTrade = 0;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].PlayerID = playerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L02c6:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] = -1;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x3);
			if (this.oCPU.Flags.L) goto L02c6;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].WorkerFlags2 = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);

		L02f2:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x0307, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)) + yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0349;

			// Instruction address 0x0000:0x0327, size: 5
			this.oParent.Segment_2aea.F0_2aea_195d(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos,
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)) + yPos);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x100);
			if (this.oCPU.Flags.G) goto L033c;

			if (playerID != this.oParent.GameState.HumanPlayerID)
				goto L0349;

		L033c:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag |= 2;

		L0349:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xb);
			if (this.oCPU.Flags.E) goto L0355;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x5);
			if (this.oCPU.Flags.NE) goto L0362;

		L0355:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag |= 8;

		L0362:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x8);
			if (this.oCPU.Flags.LE) goto L02f2;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x0);
			if (this.oCPU.Flags.E) goto L0385;

			if (playerID != this.oParent.GameState.HumanPlayerID) goto L0385;

			this.oParent.Help.F4_0000_02d3(0x4f66);

		L0385:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L0411;

		L038d:
			// Instruction address 0x0000:0x039b, size: 5
			this.oParent.VGADriver.F0_VGA_038c_GetPixel(2, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L03bf;

			// Instruction address 0x0000:0x03b7, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				8);

		L03bf:
			if (playerID == this.oParent.GameState.HumanPlayerID) goto L040e;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x18);
			if (this.oCPU.Flags.G) goto L040e;

			// Instruction address 0x0000:0x03d3, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L040e;

			// Instruction address 0x0000:0x03e5, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.HumanPlayerID);
			if (this.oCPU.Flags.NE) goto L040e;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].VisibleSize = 1;
			
			// Instruction address 0x0000:0x0406, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(xPos, yPos);

		L040e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L0411:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x2d);
			if (this.oCPU.Flags.GE) goto L0456;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x0424, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x14);
			if (this.oCPU.Flags.LE) goto L0442;
			goto L038d;

		L0442:
			// Instruction address 0x0000:0x03b7, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 0x50,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				(ushort)playerID);

			goto L03bf;

		L0456:
			if (playerID != this.oParent.GameState.HumanPlayerID) goto L0499;

			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.E) goto L0484;

			// Instruction address 0x0000:0x046d, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(1, 0);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0484;
			
			this.oParent.Overlay_22.F22_0000_0eaf(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

		L0484:
			// Instruction address 0x0000:0x048a, size: 5
			this.oParent.Segment_1ade.F0_1ade_03ea(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			// Instruction address 0x0000:0x0492, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L04fd;

		L0499:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x04a7, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].CurrentProductionID = (sbyte)this.oCPU.AX.Low;

			// Instruction address 0x0000:0x04bb, size: 5
			this.oParent.Segment_1d12.F0_1d12_6c97(this.oParent.GameState.HumanPlayerID, 0x13);
			
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04fd;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)this.oParent.GameState.HumanPlayerID;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oParent.GameState.MapVisibility[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y] |= (sbyte)this.oCPU.CX.Low;

			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].VisibleSize = 1;

			// Instruction address 0x0000:0x04f5, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y);

		L04fd:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			goto L053b;

		L0502:
			if (playerID != this.oParent.GameState.HumanPlayerID)
				goto L00f8;

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x4);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x051c, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4f74);

			// Instruction address 0x0000:0x0530, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 64, 80);

			goto L00f8;

		L053b:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_0000");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F20_0000_0540(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_0540({cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0552:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0575, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oParent.GameState.Cities[cityID].Position.X + this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)),
				this.oParent.GameState.Cities[cityID].Position.Y + this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)));

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
			if (this.oCPU.Flags.LE) goto L0552;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0598, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x05a8, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x05b9, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(10));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x9);
			if (this.oCPU.Flags.BE) goto L05c9;
			goto L0bc6;

		L05c9:
			switch(this.oCPU.AX.Word)
			{
				case 0:
					goto L05d1;
				case 1:
					goto L0698;
				case 2:
					goto L0703;
				case 3:
					goto L0750;
				case 4:
					goto L07a4;
				case 5:
					goto L07fe;
				case 6:
					goto L08b1;
				case 7:
					goto L08e8;
				case 8:
					goto L08e8;
				case 9:
					goto L08e8;
			}

		L05d1:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x10);
			if (this.oCPU.Flags.NE) goto L05da;
			goto L0bc6;

		L05da:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0xfffe);
			if (this.oCPU.Flags.NE) goto L05ed;
			goto L0bc6;

		L05ed:
			// Instruction address 0x0000:0x05f1, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(24));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L05ed;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oParent.GameState.Cities[cityID].BuildingFlags0;
			this.oCPU.DX.Word = this.oParent.GameState.Cities[cityID].BuildingFlags1;
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L05ed;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oParent.GameState.Cities[cityID].BuildingFlags0 &= this.oCPU.AX.Word;
			this.oParent.GameState.Cities[cityID].BuildingFlags1 &= this.oCPU.DX.Word;

			// Instruction address 0x0000:0x064c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Earthquake in ");

			// Instruction address 0x0000:0x0657, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0667, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\n");

			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xbb8);
			// Instruction address 0x0000:0x067d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x068d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " destroyed.\n");

			goto L0bc6;

		L0698:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x06aa, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, 10);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L06b9;

			goto L0bc6;

		L06b9:
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x100);
			if (this.oCPU.Flags.E) goto L06c4;
			goto L0bc6;

		L06c4:
			// Instruction address 0x0000:0x06ce, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xcc4));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L06dd;

			goto L0bc6;

		L06dd:
			// Instruction address 0x0000:0x06e1, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4f99);

			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].ActualSize, 0x0);
			if (this.oCPU.Flags.NE) goto L06f3;
			goto L0bc6;

		L06f3:
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x4;

		L06fa:
			this.oCPU.IDIVByte(this.oCPU.AX, this.oCPU.CX.Low);
			this.oParent.GameState.Cities[cityID].ActualSize -= (sbyte)this.oCPU.AX.Low;
			goto L0bc6;

		L0703:
			this.oCPU.TESTWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x800);
			if (this.oCPU.Flags.NE) goto L070d;
			goto L0bc6;

		L070d:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x80);
			if (this.oCPU.Flags.E) goto L071f;
			goto L0bc6;

		L071f:
			// Instruction address 0x0000:0x0729, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xca6));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0738;

			goto L0bc6;

		L0738:
			// Instruction address 0x0000:0x073c, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4f9d);

			if (this.oParent.GameState.Cities[cityID].ActualSize > 1)
				goto L06f3;

			goto L0bc6;

		L0750:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x20);
			if (this.oCPU.Flags.NE) goto L0759;
			goto L0bc6;

		L0759:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x8);
			if (this.oCPU.Flags.E) goto L076b;
			goto L0bc6;

		L076b:
			// Instruction address 0x0000:0x0775, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xc2e));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0784;

			goto L0bc6;

		L0784:
			// Instruction address 0x0000:0x0788, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fa1);

			if (this.oParent.GameState.Cities[cityID].ActualSize > 1)
				goto L079a;

			goto L0bc6;

		L079a:
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x3;
			goto L06fa;

		L07a4:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].ActualSize, 0x0);
			if (this.oCPU.Flags.NE) goto L07b6;
			goto L0bc6;

		L07b6:
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x4);
			if (this.oCPU.Flags.E) goto L07c0;
			goto L0bc6;

		L07c0:
			// Instruction address 0x0000:0x07ca, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xc10));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L07d9;

			goto L0bc6;

		L07d9:
			// Instruction address 0x0000:0x07dd, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fa5);

			this.oParent.GameState.Cities[cityID].FoodCount = 0;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Low = 0x3;
			this.oCPU.IDIVByte(this.oCPU.AX, this.oCPU.CX.Low);
			this.oParent.GameState.Cities[cityID].ActualSize -= (sbyte)this.oCPU.AX.Low;

			// Instruction address 0x0000:0x068d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Citizens demand GRANARY.\n");

			goto L0bc6;

		L07fe:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0xfffe);
			if (this.oCPU.Flags.NE) goto L0811;
			goto L0bc6;

		L0811:
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x100);
			if (this.oCPU.Flags.E) goto L081c;
			goto L0bc6;

		L081c:
			// Instruction address 0x0000:0x0826, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xcc4));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L0835;

			goto L0bc6;

		L0835:
			// Instruction address 0x0000:0x0839, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(24));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0835;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oParent.GameState.Cities[cityID].BuildingFlags0;
			this.oCPU.DX.Word = this.oParent.GameState.Cities[cityID].BuildingFlags1;
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.DX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ANDWord(this.oCPU.CX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = this.oCPU.ORWord(this.oCPU.CX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.E) goto L0835;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oParent.GameState.Cities[cityID].BuildingFlags0 &= this.oCPU.AX.Word;
			this.oParent.GameState.Cities[cityID].BuildingFlags1 &= this.oCPU.DX.Word;

			this.oCPU.AX.Word = 0x1e;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xbb8);
			// Instruction address 0x0000:0x089a, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x08a6, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fc3);

			goto L0bc6;

		L08b1:
			this.oCPU.TESTWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x400);
			if (this.oCPU.Flags.NE) goto L08bb;
			goto L0bc6;

		L08bb:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x2);
			if (this.oCPU.Flags.E) goto L08cd;
			goto L0bc6;

		L08cd:
			// Instruction address 0x0000:0x08d1, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x4fc7);

			this.oParent.GameState.Cities[cityID].FoodCount = 0;
			this.oParent.GameState.Cities[cityID].ShieldsCount = 0;
			goto L0bc6;

		L08e8:
			// Instruction address 0x0000:0x08ef, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045(cityID, -1);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e4);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e2), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0908;
			goto L0bc6;

		L0908:
			// Instruction address 0x0000:0x090c, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(3));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0924;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0963;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.E) goto L0968;
			goto L0934;

		L0924:
			// Instruction address 0x0000:0x092c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Rioting in ");

		L0934:
			// Instruction address 0x0000:0x0937, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0947, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "!\nCitizens demand ");

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x8);
			if (this.oCPU.Flags.NE) goto L096d;
			
			// Instruction address 0x0000:0x09c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "TEMPLE\n");

			goto L09c3;

		L0963:
			// Instruction address 0x0000:0x092c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Corruption in ");

			goto L0934;

		L0968:
			// Instruction address 0x0000:0x092c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Scandal in ");

			goto L0934;

		L096d:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x40);
			if (this.oCPU.Flags.NE) goto L0981;
			
			// Instruction address 0x0000:0x09c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "COURTHOUSE\n");

			goto L09c3;

		L0981:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x10);
			if (this.oCPU.Flags.NE) goto L0995;
			
			// Instruction address 0x0000:0x09c8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "MARKETPLACE\n");

			goto L09c3;

		L0995:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			if (this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, 0x1d) != 0 &&
				(this.oParent.GameState.Cities[cityID].BuildingFlags0 & 0x400) == 0)
			{
				// Instruction address 0x0000:0x09c8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "CATHEDRAL\n");
			}
			else
			{
				// Instruction address 0x0000:0x09c8, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "lower taxes.\n");
			}

		L09c3:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L0a14;

			// Instruction address 0x0000:0x09f3, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			// Instruction address 0x0000:0x0a07, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oParent.GameState.Cities[cityID].Position.X, this.oParent.GameState.Cities[cityID].Position.Y);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L0a14:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[cityID].FoodCount = 0;
			this.oParent.GameState.Cities[cityID].ShieldsCount = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e4);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e2), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0a3e;
			goto L0bc6;

		L0a3e:
			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L0a48;
			goto L0bc6;

		L0a48:
			if (this.oParent.GameState.Players[this.oParent.GameState.Cities[cityID].PlayerID].CityCount > 3)
				goto L0a5b;
			goto L0bc6;

		L0a5b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0acd;

		L0a62:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0a88, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oParent.GameState.Cities[cityID].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X,
				this.oParent.GameState.Cities[cityID].Position.Y,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0a9a, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), -1);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e2);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e4));
			this.oCPU.CX.Low = 0x5;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0aca;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

		L0aca:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0acd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L0aee;
			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0aee;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0aee;
			goto L0a62;

		L0aee:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0af7;
			goto L0bc6;

		L0af7:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].PlayerID !=
				this.oParent.GameState.Cities[cityID].PlayerID) goto L0b14;
			goto L0bc6;

		L0b14:
			this.oCPU.AX.Low = (byte)this.oParent.GameState.MapVisibility[this.oParent.GameState.Cities[cityID].Position.X,
				this.oParent.GameState.Cities[cityID].Position.Y];
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0b92;

			// Instruction address 0x0000:0x0b43, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Residents of ");

			// Instruction address 0x0000:0x0b4e, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x0000:0x0b5e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " admire\nthe prosperity of ");

			// Instruction address 0x0000:0x0b69, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

			// Instruction address 0x0000:0x0b79, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x0000:0x0b8a, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

		L0b92:
			this.oParent.Overlay_22.F22_0000_0af5(cityID, 
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))].PlayerID);
			
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L0bc6:
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), 0x0);
			if (this.oCPU.Flags.NE) goto L0bd0;
			goto L0ca3;

		L0bd0:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.PlayerFlags);
			if (this.oCPU.Flags.E) goto L0c18;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x4);

			// Instruction address 0x0000:0x0bf9, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

			// Instruction address 0x0000:0x0c0d, size: 5
			this.oParent.Segment_1403.F0_1403_3ed7(this.oParent.GameState.Cities[cityID].Position.X, this.oParent.GameState.Cities[cityID].Position.Y);

			goto L0ca3;

		L0c18:
			this.oCPU.AX.Low = (byte)this.oParent.GameState.MapVisibility[this.oParent.GameState.Cities[cityID].Position.X,
				this.oParent.GameState.Cities[cityID].Position.Y];
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0ca3;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L0c4c:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0xa);
			if (this.oCPU.Flags.NE) goto L0c4c;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x2);

			// Instruction address 0x0000:0x0c73, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 64);

			// Instruction address 0x0000:0x0c9b, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008(oParent.GameState.HumanPlayerID,
				this.oParent.GameState.Cities[cityID].Position.X - 10,
				this.oParent.GameState.Cities[cityID].Position.Y - 6);

		L0ca3:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_0540");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="flag"></param>
		/// <returns></returns>
		public ushort F20_0000_0ca9(short playerID, bool flag)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_0ca9({playerID}, {flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1a);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			
			if (!flag) goto L0cc3;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);

		L0cc3:
			if (!flag) goto L0cd9;

			this.oParent.Overlay_14.F14_0000_0000(0x506b, 3);

		L0cd9:
			this.oParent.GameState.Players[0].Score = 0;
			
			if (!flag) goto L0d3e;

			this.oCPU.TESTWord((ushort)this.oParent.GameState.SpaceshipFlags, 0x100);
			if (this.oCPU.Flags.E) goto L0d3e;

			// Instruction address 0x0000:0x0cfd, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0("SCORING COMPLETED", 160, 100, 15);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			// Instruction address 0x0000:0x0d22, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x0d2a, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x0d2f, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x0d34, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			this.oCPU.AX.Word = 0;
			goto L13f3;

		L0d3e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x1a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1a);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x3e7);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb25c, 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb2bc, 0x1a);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].TaxRate;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oParent.GameState.Players[playerID].TaxRate = (short)(6 - this.oParent.GameState.Players[playerID].ScienceTaxRate);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);
			goto L0e3c;

		L0d85:
			F20_0000_13f8((ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) & 1));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0d96:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e2);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0d85;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0db8;

		L0da5:
			F20_0000_13f8((ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) & 1) + 2));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0db8:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e4));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe8b8));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			if (this.oCPU.Flags.G) goto L0da5;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0df1;

		L0ddd:
			F20_0000_13f8((ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)) & 1) + 4));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0df1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e4);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0ddd;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0e19;

		L0e00:
			// Instruction address 0x0000:0x0e03, size: 5
			this.oParent.Segment_1d12.F0_1d12_6da1(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));

			F20_0000_13f8((ushort)(this.oCPU.AX.Word + 5));
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0e19:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xe8b8);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0e00;

		L0e21:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e2));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70e4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L0e39:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

		L0e3c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x80);
			if (this.oCPU.Flags.GE) goto L0e79;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0e39;
			
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID != playerID)
				goto L0e39;

			// Instruction address 0x0000:0x0e63, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), -1);

			if (!flag) goto L0e21;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0d96;

		L0e79:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oParent.GameState.Players[playerID].TaxRate = (short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd766, this.oCPU.AX.Word);
			// Instruction address 0x0000:0x0e93, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));

			// Instruction address 0x0000:0x0ea3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Citizens (");

			// Instruction address 0x0000:0x0ec4, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd766), 10));

			// Instruction address 0x0000:0x0ed4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			if (!flag) goto L0ef9;

			// Instruction address 0x0000:0x0ef1, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06,
				16,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				15);

		L0ef9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x10);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd764, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x1);

		L0f15:
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))];
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0f26;
			goto L0fb9;

		L0f26:
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x80);
			if (this.oCPU.Flags.NE) goto L0f2f;
			goto L0fb9;

		L0f2f:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			
			if (this.oParent.GameState.Cities[this.oCPU.SI.Word].PlayerID != playerID) goto L0fb9;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x98));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x12c);
			if (this.oCPU.Flags.LE) goto L0f6a;

			// Instruction address 0x0000:0x0f5a, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x5116) + 2, 8, 99);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x10);

		L0f6a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x18);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			if (!flag) goto L0fb4;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xb4);
			if (this.oCPU.Flags.GE) goto L0fb4;

			// Instruction address 0x0000:0x0f8c, size: 5
			this.oParent.Segment_1d12.F0_1d12_7045(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) - 2));
			
			// Instruction address 0x0000:0x0fac, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0((ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) * 0x1e) + 0xe6a),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) + 20,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				11);

		L0fb4:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd764, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd764), 0x14));

		L0fb9:
			if (this.oParent.GameState.WonderCityID[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))] != -1)
				goto L0fca;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L0fca:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x15);
			if (this.oCPU.Flags.G) goto L0fd6;
			goto L0f15;

		L0fd6:
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0fe3, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			// Instruction address 0x0000:0x0ff3, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " Achievements (");

			// Instruction address 0x0000:0x1014, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd764), 10));

			// Instruction address 0x0000:0x1024, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			if (!flag) goto L1049;

			// Instruction address 0x0000:0x1041, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 15);

		L1049:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd764);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd766));
			this.oParent.GameState.Players[0].Score = (short)this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xa));
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[oParent.GameState.HumanPlayerID].SpaceshipPopulation;
			this.oCPU.SI.Word = this.oCPU.ORWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NE) goto L1068;
			goto L1118;

		L1068:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipSuccessRate != 0) goto L1072;
			goto L1118;

		L1072:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].SpaceshipSuccessRate;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.SI.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1088;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);

		L1088:
			// Instruction address 0x0000:0x1090, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "SpaceShip: (");

			// Instruction address 0x0000:0x10b0, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 10));
			
			if (this.oParent.GameState.Players[oParent.GameState.HumanPlayerID].SpaceshipETAYear != oParent.GameState.Year) goto L10d0;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oParent.GameState.Players[0].Score += (short)this.oCPU.AX.Word;
			goto L10e0;

		L10d0:
			// Instruction address 0x0000:0x10d8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " possible");

		L10e0:
			// Instruction address 0x0000:0x10e8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			if (!flag) goto L1114;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xb8);
			if (this.oCPU.Flags.GE) goto L1114;

			// Instruction address 0x0000:0x110c, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 15);

		L1114:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xa));

		L1118:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			if (this.oParent.GameState.PollutedSquareCount == 0) goto L1174;

			// Instruction address 0x0000:0x112c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Pollution: (");

			// Instruction address 0x0000:0x1151, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(-10 * this.oParent.GameState.PollutedSquareCount), 10));

			// Instruction address 0x0000:0x1161, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")   ");

			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.PollutedSquareCount);
			this.oParent.GameState.Players[0].Score -= (short)this.oCPU.AX.Word;

		L1174:
			if (oParent.GameState.Year <= 0) goto L11e3;
			if (this.oParent.GameState.PeaceTurnCount == 0) goto L11e3;

			// Instruction address 0x0000:0x1191, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.GameState.PeaceTurnCount * 3, 0, 100);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x11a4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Peace: (+");

			// Instruction address 0x0000:0x11c4, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 10));

			// Instruction address 0x0000:0x11d4, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ") ");

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oParent.GameState.Players[0].Score += (short)this.oCPU.AX.Word;

		L11e3:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].FutureTechnologyCount == 0) goto L123a;

			// Instruction address 0x0000:0x11f2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "Future Tech: (+");

			// Instruction address 0x0000:0x1217, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)(5 * this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].FutureTechnologyCount), 10));

			// Instruction address 0x0000:0x1227, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ")");

			this.oCPU.AX.Word = 0x5;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].FutureTechnologyCount);
			this.oParent.GameState.Players[0].Score += (short)this.oCPU.AX.Word;

		L123a:
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), 0x0);
			if (this.oCPU.Flags.E) goto L1269;
			
			if (!flag) goto L1269;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xb8);
			if (this.oCPU.Flags.GE) goto L1269;

			// Instruction address 0x0000:0x125d, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xa));

		L1269:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), 0xffff);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb884), 0x0);
			if (this.oCPU.Flags.E) goto L128e;
			this.oCPU.AX.Word = 0x64;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)this.oParent.GameState.AIOpponentCount);
			this.oCPU.CX.Word = 0x226;
			this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, (ushort)this.oParent.GameState.TurnCount);
			this.oCPU.CX.Word = this.oCPU.SHLWord(this.oCPU.CX.Word, 0x1);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x190);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.CX.Word);

		L128e:
			if (this.oParent.GameState.Players[0].Score < 0)
			{
				this.oParent.GameState.Players[0].Score = 0;
			}

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[0].Score;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L12d6;

			// Instruction address 0x0000:0x12ab, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Total Score: ");

			// Instruction address 0x0000:0x12cc, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[0].Score, 10));
			goto L130c;

		L12d6:
			// Instruction address 0x0000:0x12de, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Bonus Score: ");

			// Instruction address 0x0000:0x12fe, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)), 10));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
			this.oParent.GameState.Players[0].Score = (short)this.oCPU.AX.Word;

		L130c:
			if (!flag) goto L1330;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xba);
			if (this.oCPU.Flags.GE) goto L1330;

			// Instruction address 0x0000:0x1328, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(0xba06, 16, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 15);

		L1330:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xba);
			if (this.oCPU.Flags.L) goto L1348;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x5116, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5116)));

			// Instruction address 0x0000:0x1340, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			goto L0cc3;

		L1348:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[0].Score;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb77e, this.oCPU.AX.Word);

			if (!flag)
				goto L13f0;

			// Instruction address 0x0000:0x136f, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 35, 192, 250, 7, 8);

			if (this.oParent.GameState.Players[0].Score > 0)
			{
				// Instruction address 0x0000:0x139f, size: 5
				this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(this.oParent.GameState.Players[0].Score / 4, 0, 250);

				// Instruction address 0x0000:0x13b4, size: 5
				this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 35, 192, (short)this.oCPU.AX.Word, 7, 11);
			}

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			// Instruction address 0x0000:0x13d9, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x0000:0x13e1, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

			// Instruction address 0x0000:0x13e6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x0000:0x13eb, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

		L13f0:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[0].Score;

		L13f3:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_0ca9");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		public void F20_0000_13f8(ushort param1)
		{
			this.oCPU.Log.EnterBlock($"F20_0000_13f8({param1})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb25c, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb25c), 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb25c), 0x124);
			if (this.oCPU.Flags.LE) goto L141d;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5116);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb2bc, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc), this.oCPU.AX.Word));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x10);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb25c, this.oCPU.AX.Word);

		L141d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb2bc), 0xa0);
			if (this.oCPU.Flags.G) goto L1442;

			// Instruction address 0x0000:0x143a, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb25c),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xb2bc),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((param1 << 1) + 0x6e96)));

		L1442:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F20_0000_13f8");
		}
	}
}
