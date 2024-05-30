using IRB.VirtualCPU;
using OpenCiv1.GPU;

namespace OpenCiv1
{
	public class Segment_2459
	{
		private Game oParent;
		private CPU oCPU;

		public Segment_2459(Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="cityID"></param>
		/// <param name="flag"></param>
		public void F0_2459_0000(short playerID, short cityID, ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F0_2459_0000({playerID}, {cityID}, {flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[cityID].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[cityID].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].ContactPlayerCountdown = -2;
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			}

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L00c5;
			
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.NE) goto L005c;
			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].CurrentProductionID, 0xff);
			if (this.oCPU.Flags.NE) goto L00c5;

		L005c:
			this.oCPU.CMPWord(flag, 0x0);
			if (this.oCPU.Flags.NE) goto L00c5;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L00c5;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].CityCount <= 4 ||
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Ranking >=
				this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Ranking) goto L00c5;

			this.oParent.Overlay_15.F15_0000_0000(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L00c5;
			this.oCPU.AX.Low = (byte)playerID;
			this.oParent.GameState.Cities[cityID].PlayerID = (sbyte)this.oCPU.AX.Low;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x00ab); // stack management - push return offset
			this.oParent.Overlay_15.F15_0000_08ba(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].CurrentProductionID = -1;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oParent.GameState.Cities[cityID].PlayerID = (sbyte)this.oCPU.AX.Low;

		L00c5:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.TESTWord(this.oParent.GameState.Cities[cityID].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L00de;

			// Instruction address 0x2459:0x00d8, size: 3
			F0_2459_05ee(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L00de:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
			{
				this.oParent.GameState.Players[playerID].ContactPlayerCountdown = -1;
			}

			// Instruction address 0x2459:0x0101, size: 3
			F0_2459_0687(cityID);

			// Instruction address 0x2459:0x0108, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				(short)this.oCPU.AX.Word,
				0,
				this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Coins);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.CMPWord((ushort)playerID, 0x0);
			if (this.oCPU.Flags.NE) goto L016c;

			// Instruction address 0x2459:0x011f, size: 5
			short unitIDTemp = (short)this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.CX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)((short)(0x22 * this.oParent.GameState.Players[playerID].Units[unitIDTemp].TypeID));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.UnitDefinitions[this.oParent.GameState.Players[playerID].Units[unitIDTemp].TypeID].AttackStrength > 2)
				goto L016c;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x28bc), 0x0);
			if (this.oCPU.Flags.NE) goto L016c;

			// Instruction address 0x2459:0x0155, size: 5
			this.oParent.Segment_1ade.F0_1ade_018e(
				cityID,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Cities[cityID].ActualSize = 0;
			goto L01dc;

		L016c:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Cities[cityID].ShieldsCount = 0;
			this.oParent.GameState.Cities[cityID].StatusFlag &= 0xae;
			this.oParent.GameState.Cities[cityID].BuildingFlags0 &= 0xfbb6;

			this.oCPU.CMPWord(flag, 0x0);
			if (this.oCPU.Flags.NE) goto L01a8;

			// Instruction address 0x2459:0x018f, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xaaaa;
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.DX.Word = 0;
			this.oParent.GameState.Cities[cityID].BuildingFlags0 &= this.oCPU.AX.Word;
			this.oParent.GameState.Cities[cityID].BuildingFlags1 &= this.oCPU.DX.Word;

		L01a8:
			if (flag == 0)
				goto L01bd;
			
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[cityID].ActualSize <= 1)
				goto L01dc;

		L01bd:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Cities[cityID].ActualSize--;
			if (this.oParent.GameState.Cities[cityID].ActualSize < 1)
			{
				// Instruction address 0x2459:0x01d4, size: 5
				this.oParent.Segment_1ade.F0_1ade_018e(
					cityID,
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			}

		L01dc:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Coins -= (short)this.oCPU.AX.Word;

			this.oCPU.CMPWord((ushort)playerID, 0x0);
			if (this.oCPU.Flags.E) goto L01f7;
			this.oParent.GameState.Players[playerID].Coins += (short)this.oCPU.AX.Word;

		L01f7:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].ActualSize, 0x0);
			if (this.oCPU.Flags.NE) goto L0209;
			goto L028f;

		L0209:
			// Instruction address 0x2459:0x0221, size: 5
			this.oParent.Segment_1866.F0_1866_250e_AddReplayData(9, (byte)playerID, this.oParent.GameState.Cities[cityID].NameID,
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			// Instruction address 0x2459:0x0239, size: 5
			this.oParent.Segment_25fb.F0_25fb_3401(playerID, 0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				4);
			
			this.oParent.GameState.Cities[cityID].StatusFlag &= 0x9b;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);

		L024b:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			GPoint direction = this.oParent.MoveOffsets[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))];

			// Instruction address 0x2459:0x0258, size: 5
			this.oParent.UnitGoTo.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + direction.X);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc),
				(short)(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)) + direction.Y));

			// Instruction address 0x2459:0x027e, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) + 80,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				(ushort)playerID);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x14);
			if (this.oCPU.Flags.L) goto L024b;

		L028f:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)playerID;
			this.oParent.GameState.Cities[cityID].PlayerID = (sbyte)this.oCPU.AX.Low;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L02ae;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L02ae;
			goto L03f7;

		L02ae:
			// Instruction address 0x2459:0x02b4, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x2459:0x02cb, size: 5
				this.oParent.Segment_1866.F0_1866_16a9(this.oParent.GameState.HumanPlayerID,
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			}
		
			// Instruction address 0x2459:0x02d9, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x2459:0x02ee, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.Players[playerID].Nation);

			// Instruction address 0x2459:0x02fe, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " capture\n");

			// Instruction address 0x2459:0x030a, size: 3
			F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x2459:0x0318, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ". ");

			// Instruction address 0x2459:0x0338, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 10));

			// Instruction address 0x2459:0x0348, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " gold\npieces plundered.\n");

			// Instruction address 0x2459:0x035d, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(this.oParent.GameState.Nations[this.oParent.GameState.Players[playerID].NationalityID].ShortTune, 0);

			this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x8);
			if (this.oCPU.Flags.E) goto L03b7;

			// Instruction address 0x2459:0x036c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.CityView.F19_0000_0000(cityID, -2);
			
			// Instruction address 0x2459:0x0380, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x2459:0x038c, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(1, 1);

			this.oParent.CityView.F19_0000_167b(playerID);

			// Instruction address 0x2459:0x03a8, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

			// Instruction address 0x2459:0x03b0, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L03c2;

		L03b7:
			this.oParent.Overlay_21.F21_0000_0000(cityID);

		L03c2:
			// Instruction address 0x2459:0x03c6, size: 5
			this.oParent.Segment_1000.F0_1000_0a32_PlayTune(1, 0);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L03da;
			this.oCPU.AX.Low = 0;
			goto L03e6;

		L03da:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;

		L03e6:
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[cityID].VisibleSize = (sbyte)this.oCPU.CX.Low;
			goto L04bc;

		L03f7:
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[playerID] & 0x40) != 0)
				goto L041a;

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))] & 0x40) == 0)
				goto L04bc;

		L041a:
			this.oParent.Var_2f9e_Unknown = 0x0;

			// Instruction address 0x2459:0x0428, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Spies report:\n");

			// Instruction address 0x2459:0x043d, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.Players[playerID].Nation);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[cityID].ActualSize != 0)
			{
				// Instruction address 0x2459:0x0461, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " capture\nthe ");
			}
			else
			{
				// Instruction address 0x2459:0x0461, size: 5
				this.oParent.MSCAPI.strcat(0xba06, " destroy\nthe ");
			}

			// Instruction address 0x2459:0x0476, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Nationality);

			// Instruction address 0x2459:0x0486, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " city\nof ");

			// Instruction address 0x2459:0x0492, size: 3
			F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x2459:0x04a0, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x2459:0x04b4, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L04bc:
			// Instruction address 0x2459:0x04c3, size: 3
			F0_2459_06f2(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			// Instruction address 0x2459:0x04d2, size: 5
			this.oParent.Segment_2aea.F0_2aea_138c_MapSetCityOwner(
				playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);

		L04df:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].TypeID == -1 ||
				this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].HomeCityID != cityID)
				goto L0531;
			
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			if ((this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].Position.X !=
				this.oParent.GameState.Cities[cityID].Position.X) ||
				(this.oParent.GameState.Players[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].Units[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].Position.Y !=
				this.oParent.GameState.Cities[cityID].Position.Y) ||
				(this.oParent.GameState.Cities[cityID].ActualSize == 0))
			{
				// Instruction address 0x2459:0x0529, size: 5
				this.oParent.Segment_1866.F0_1866_0f10(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			}

		L0531:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x80);
			if (this.oCPU.Flags.L) goto L04df;
			
			if (playerID == this.oParent.GameState.HumanPlayerID &&
				this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType < 4)
			{
				this.oParent.GameState.Cities[cityID].StatusFlag |= 1;
			}

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].ActualSize, 0x0);
			if (this.oCPU.Flags.E) goto L05da;

			this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].CurrentProductionID, 0x0);
			if (this.oCPU.Flags.L) goto L0586;

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].CurrentProductionID;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].UnitsInProduction[this.oParent.GameState.Cities[cityID].CurrentProductionID]--;

		L0586:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L05a6;

			// Instruction address 0x2459:0x0597, size: 5
			this.oParent.Segment_1d12.F0_1d12_0045(cityID, 1);

			// Instruction address 0x2459:0x059f, size: 5
			this.oParent.Segment_1238.F0_1238_1b44();

			goto L05da;

		L05a6:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Cities[cityID].CurrentProductionID = 0;

			// Instruction address 0x2459:0x05bb, size: 5
			this.oParent.Segment_1ade.F0_1ade_0421(playerID, cityID);
			
			this.oParent.GameState.Cities[cityID].CurrentProductionID = (sbyte)this.oCPU.AX.Low;
			
			this.oCPU.AX.Low = this.oCPU.ORByte(this.oCPU.AX.Low, this.oCPU.AX.Low);
			if (this.oCPU.Flags.L) goto L05da;
			
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oParent.GameState.Players[playerID].UnitsInProduction[this.oParent.GameState.Cities[cityID].CurrentProductionID]++;

		L05da:
			this.oParent.StartGameMenu.F5_0000_0e6c(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), playerID);

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2459_0000");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		public void F0_2459_05ee(short playerID)
		{
			this.oCPU.Log.EnterBlock($"F0_2459_05ee({playerID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x2459:0x05fe, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.Players[playerID].Nationality);

			// Instruction address 0x2459:0x060e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " spaceship\n");

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.SpaceshipFlags);
			if (this.oCPU.Flags.E) goto L065e;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.SpaceshipFlags & this.oCPU.AX.Word) != 0)
			{
				// Instruction address 0x2459:0x0642, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "returns to Earth.\n");
			}
			else
			{
				// Instruction address 0x2459:0x0642, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "construction cancelled.\n");
			}

			// Instruction address 0x2459:0x0656, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L065e:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oParent.GameState.SpaceshipFlags &= (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ADDByte(this.oCPU.CX.Low, 0x8);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oParent.GameState.SpaceshipFlags &= (short)this.oCPU.AX.Word;

			this.oParent.StartGameMenu.F5_0000_1d1a_InitSpaceshipData(playerID);
			
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2459_05ee");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		/// <returns></returns>
		public ushort F0_2459_0687(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_2459_0687({cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x7d00;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Coins);
			if (this.oCPU.Flags.LE) goto L06ca;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Coins;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TotalCitySize;
			this.oCPU.CX.Word = this.oCPU.INCWord(this.oCPU.CX.Word);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			goto L06ec;

		L06ca:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].TotalCitySize;
			this.oCPU.BX.Word = this.oCPU.INCWord(this.oCPU.BX.Word);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);

		L06ec:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2459_0687");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID1"></param>
		/// <param name="playerID2"></param>
		public void F0_2459_06f2(short playerID1, short playerID2)
		{
			this.oCPU.Log.EnterBlock($"F0_2459_06f2({playerID1}, {playerID2})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x9a);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord((ushort)playerID1, 0x0);
			if (this.oCPU.Flags.NE) goto L0703;
			goto L08c1;

		L0703:
			this.oCPU.CMPWord((ushort)playerID2, 0x0);
			if (this.oCPU.Flags.NE) goto L070c;
			goto L08c1;

		L070c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

			// Instruction address 0x2459:0x0719, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, "Select one...\n ");

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x96), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98), 0x47);

		L072d:
			// Instruction address 0x2459:0x0734, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID1,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L07b9;

			// Instruction address 0x2459:0x0747, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L07b9;

			// Instruction address 0x2459:0x0762, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.GameState.TechnologyDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98))].Name);

			// Instruction address 0x2459:0x0772, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\n ");

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x94), this.oCPU.AX.Word);

			// Instruction address 0x2459:0x0791, size: 5
			this.oParent.Segment_1ade.F0_1ade_2317(playerID1, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x96)));
			if (this.oCPU.Flags.LE) goto L07b9;

			// Instruction address 0x2459:0x07a6, size: 5
			this.oParent.Segment_1ade.F0_1ade_2317(playerID1, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x96), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L07b9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x98))));
			if (this.oCPU.Flags.S) goto L07c2;
			goto L072d;

		L07c2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L07cb;
			goto L08c1;

		L07cb:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0823;

		L07d3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.NE) goto L07ed;

			// Instruction address 0x2459:0x07e6, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 32);

			goto L07fe;

		L07ed:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x07fe); // stack management - push return offset
			this.oParent.MeetWithKing.F6_0000_251d(0xba06, 0x14, 0x8b);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L07fe:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x9a), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L07d3;

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x2459:0x0818, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(playerID1,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x94)),
				playerID2);
			
			goto L08c1;

		L0823:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L08a1;

			// Instruction address 0x2459:0x0838, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oParent.GameState.Players[playerID1].Nation);

			// Instruction address 0x2459:0x0848, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " take\n");

			// Instruction address 0x2459:0x085e, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.GameState.TechnologyDefinitions[this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Name);

			// Instruction address 0x2459:0x086e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3934), 0xffff);
			if (this.oCPU.Flags.NE) goto L088d;

			// Instruction address 0x2459:0x0886, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			goto L08a1;

		L088d:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x089e); // stack management - push return offset
			this.oParent.MeetWithKing.F6_0000_251d(0xba06, 0x14, 0x8b);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L08a1:
			// Instruction address 0x2459:0x08aa, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(playerID1,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				playerID2);
			
			// Instruction address 0x2459:0x08b9, size: 5
			this.oParent.Segment_25fb.F0_25fb_3459(playerID1, 0xffff);

		L08c1:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2459_06f2");
		}

		/// <summary>
		/// Appends buffer at 0xba06 with city name
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_2459_08c6_GetCityName(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_2459_08c6_GetCityName({cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			if (cityID != -1)
			{
				byte ubCityNameID = this.oParent.GameState.Cities[cityID].NameID;
				ushort usStringOffset = (ushort)(0xba06 + this.oParent.MSCAPI.strlen(0xba06));

				for (int i = 0; i < 0xd; i++)
				{
					this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(usStringOffset + i), (byte)this.oParent.GameState.CityNames[ubCityNameID][i]);
				}
			}
			else
			{
				// Instruction address 0x2459:0x08d7, size: 5
				this.oParent.MSCAPI.strcat(0xba06, "NONE");
			}

			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_2459_08c6_GetCityName");
		}

		/// <summary>
		/// Waits for Key press or Mouse click
		/// </summary>
		public void F0_2459_0918_WaitForKeyPressOrMouseClick()
		{
			this.oCPU.Log.EnterBlock("F0_2459_0918_WaitForKeyPressOrMouseClick()");

			// function body
			// Instruction address 0x2459:0x0918, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

		L091d:
			// Instruction address 0x2459:0x091d, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L0932;

			// Instruction address 0x2459:0x0929, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L091d;

		L0932:
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L0947;

			// Instruction address 0x2459:0x0939, size: 5
			this.oParent.MSCAPI.getch();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0947;

			// Instruction address 0x2459:0x0942, size: 5
			this.oParent.MSCAPI.getch();

		L0947:
			// Far return
			this.oCPU.Log.ExitBlock("F0_2459_0918_WaitForKeyPressOrMouseClick");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="cityID"></param>
		/// <returns></returns>
		public ushort F0_2459_0948(short playerID, short unitID, short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_2459_0948({playerID}, {unitID}, {cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);

			this.oCPU.WriteInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6),
				(short)this.oParent.GameState.Players[playerID].Units[unitID].HomeCityID);

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x2459:0x098e, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289_GetShortestDistance(
				this.oParent.GameState.Cities[cityID].Position.X,
				this.oParent.GameState.Cities[cityID].Position.Y,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.X,
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.Y);

			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xa);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CX.Word = 0x18;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

			// Instruction address 0x2459:0x09c4, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x2459:0x09db, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942(
				this.oParent.GameState.Cities[cityID].Position.X,
				this.oParent.GameState.Cities[cityID].Position.Y);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			if (this.oCPU.Flags.NE) goto L09f4;
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L09f4:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L0a12;
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

		L0a12:
			// Instruction address 0x2459:0x0a24, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, (int)TechnologyEnum.Railroad);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L0a3c;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L0a3c:
			// Instruction address 0x2459:0x0a4e, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.Cities[cityID].PlayerID, (int)TechnologyEnum.Flight);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L0a66;

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word));

		L0a66:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oParent.GameState.Players[playerID].Coins += (short)this.oCPU.AX.Word;
			this.oParent.GameState.Players[playerID].ResearchProgress += (short)this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0a81;
			goto L0b23;

		L0a81:
			this.oCPU.BX.Word = (ushort)unitID;
			this.oCPU.BX.Word = this.oCPU.ANDWord(this.oCPU.BX.Word, 0x7);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x2459:0x0a91, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1972)));

			// Instruction address 0x2459:0x0aa1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, " caravan from ");

			// Instruction address 0x2459:0x0aad, size: 3
			F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			// Instruction address 0x2459:0x0abb, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\narrives in ");

			// Instruction address 0x2459:0x0ac7, size: 3
			F0_2459_08c6_GetCityName(cityID);

			// Instruction address 0x2459:0x0ad5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, "\nTrade route established\nRevenue: $");

			// Instruction address 0x2459:0x0af5, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 10));

			// Instruction address 0x2459:0x0b05, size: 5
			this.oParent.MSCAPI.strcat(0xba06, ".\n");

			// Instruction address 0x2459:0x0b16, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 80);

			// Instruction address 0x2459:0x0b1e, size: 5
			this.oParent.Segment_1238.F0_1238_107e();

		L0b23:
			// Instruction address 0x2459:0x0b29, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, unitID);
			
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[cityID].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L0b4e;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x1));

		L0b4e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);
			goto L0b9c;

		L0b5a:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xff);
			if (this.oCPU.Flags.NE) goto L0b68;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0xffff);
			goto L0b85;

		L0b68:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].BaseTrade;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L0b85;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.SHLWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x1));

		L0b85:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0b99;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

		L0b99:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0b9c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x3);
			if (this.oCPU.Flags.GE) goto L0bc3;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))];
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

			this.oCPU.AX.Word = (ushort)cityID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0b5a;

		L0bbe:
			this.oCPU.AX.Word = 0x1;
			goto L0bdd;

		L0bc3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xffff);
			if (this.oCPU.Flags.E) goto L0bbe;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Low = (byte)cityID;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].TradeCityIDs[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))] = (sbyte)this.oCPU.AX.Low;
			goto L0bbe;

		L0bdd:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_2459_0948");

			return this.oCPU.AX.Word;
		}
	}
}
