using System;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_1866
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Segment_1866(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_1866_0006(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_0006({cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[cityID].PlayerID == this.oParent.GameState.HumanPlayerID)
			{
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x20f4, 0x1);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

			L002f:
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;
				this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))], 0xff);
				if (this.oCPU.Flags.E) goto L00a4;

				// Instruction address 0x1866:0x005e, size: 3
				F0_1866_0cf5(
					this.oParent.GameState.Cities[cityID].PlayerID,
					(short)(this.oParent.GameState.Cities[cityID].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 0x3f),
					this.oParent.GameState.Cities[cityID].Position.X,
					this.oParent.GameState.Cities[cityID].Position.Y);
				
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
				this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
				if (this.oCPU.Flags.E) goto L00a4;
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[cityID].PlayerID;
				this.oCPU.CX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
				this.oCPU.CX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
				this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x81d4);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.CX.Word);
				this.oCPU.BX.Word = this.oCPU.CX.Word;
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x8));
				this.oCPU.TESTByte((byte)this.oParent.GameState.Cities[cityID].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))], 0x40);
				if (this.oCPU.Flags.E) goto L0094;
				this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x20));

			L0094:
				this.oParent.GameState.Cities[cityID].Unknown[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] = -1;

			L00a4:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x2);
				if (this.oCPU.Flags.L) goto L002f;
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x20f4, 0x0);
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oParent.GameState.Cities[cityID].StatusFlag |= 4;
			}

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_0006");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="cityID"></param>
		public void F0_1866_00c6(short cityID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_00c6({cityID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[cityID].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), (ushort)this.oParent.GameState.HumanPlayerID);
			if (this.oCPU.Flags.E)
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70d8);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
				this.oCPU.AX.Word = 0;
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x70d8, this.oCPU.AX.Word);
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x20f4, 0x1);
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
				goto L014b;

			L0102:
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;
				this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].Unknown[1], 0xff);
				if (this.oCPU.Flags.E) goto L0116;
				goto L01bd;

			L0116:
				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
				this.oCPU.DI.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
				this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d7));
				this.oParent.GameState.Cities[cityID].Unknown[1] = (sbyte)this.oCPU.AX.Low;
				this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d4)), 0x20);
				if (this.oCPU.Flags.E) goto L0136;
				this.oParent.GameState.Cities[cityID].Unknown[1] |= 0x40;

			L0136:
				// Instruction address 0x1866:0x013d, size: 3
				F0_1866_0f10(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			L0143:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

			L0148:
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

			L014b:
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x80);
				if (this.oCPU.Flags.GE) goto L01bd;
				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
				this.oCPU.SI.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
				this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
				this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0xff);
				if (this.oCPU.Flags.E) goto L0148;
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
				this.oCPU.DI.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Low = (byte)((sbyte)this.oParent.GameState.Cities[cityID].Position.X);
				this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)), this.oCPU.AX.Low);
				if (this.oCPU.Flags.NE) goto L0148;
				this.oCPU.AX.Low = (byte)((sbyte)this.oParent.GameState.Cities[cityID].Position.Y);
				this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)), this.oCPU.AX.Low);
				if (this.oCPU.Flags.NE) goto L0148;
				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df));
				this.oCPU.CBW(this.oCPU.AX);
				this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)cityID);
				if (this.oCPU.Flags.NE) goto L0148;
				this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0x8);
				if (this.oCPU.Flags.E) goto L0148;
				this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
				if (this.oCPU.Flags.E) goto L0143;
				this.oCPU.CMPByte((byte)this.oParent.GameState.Cities[cityID].Unknown[0], 0xff);
				if (this.oCPU.Flags.E) goto L01a6;
				goto L0102;

			L01a6:
				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7));
				this.oParent.GameState.Cities[cityID].Unknown[0] = (sbyte)this.oCPU.AX.Low;
				this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0x20);
				if (this.oCPU.Flags.E) goto L0136;
				this.oParent.GameState.Cities[cityID].Unknown[0] |= 0x40;
				goto L0136;

			L01bd:
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x20f4, 0x0);
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
				this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x70d8, this.oCPU.AX.Word);
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)cityID);
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oParent.GameState.Cities[cityID].StatusFlag &= 0xfb;
			}
		
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_00c6");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="flag"></param>
		public void F0_1866_01dc(int xPos, int yPos, short playerID, short unitID, ushort flag)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_01dc({xPos}, {yPos}, {playerID}, {unitID}, {flag})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x16);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x1866:0x01ea, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			
			if (playerID != this.oParent.GameState.HumanPlayerID)
				goto L02af;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

		L0205:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x1866:0x0212, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x9);
			if (this.oCPU.Flags.L) goto L0266;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d7)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1144)), 0x2);
			if (this.oCPU.Flags.E) goto L02a3;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1138)), 0x2);
			if (this.oCPU.Flags.NE) goto L0266;

			// Instruction address 0x1866:0x0259, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L02a3;

		L0266:
			// Instruction address 0x1866:0x026c, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L02a3;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;

			this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))] |= (sbyte)this.oCPU.CX.Low;

			// Instruction address 0x1866:0x029b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L02a3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x19);
			if (this.oCPU.Flags.GE) goto L02af;
			goto L0205;

		L02af:
			// Instruction address 0x1866:0x02b5, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			goto L0381;

		L02c8:
			this.oCPU.AX.Word = 0x1;

		L02cb:
			// Instruction address 0x1866:0x02da, size: 5
			this.oParent.Segment_25fb.F0_25fb_304d(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0),
				(short)xPos, (short)yPos, 2, (short)this.oCPU.AX.Word);

		L02e2:
			// Instruction address 0x1866:0x02e8, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0329;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0), 0x0);
			if (this.oCPU.Flags.E) goto L0329;

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0)] & 2) != 0)
				goto L0329;

			// Instruction address 0x1866:0x0321, size: 5
			this.oParent.Segment_25fb.F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				3, 2);

		L0329:
			if (flag == 0)
				goto L037e;
			
			if (playerID == this.oParent.GameState.HumanPlayerID)
				goto L033e;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.E) goto L037e;

		L033e:
			// Instruction address 0x1866:0x0344, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			// Instruction address 0x1866:0x0358, size: 3
			this.oParent.VGADriver.F0_VGA_038c_GetPixel(2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E)
			{
				this.oCPU.AX.Word = 0x1;
			}
			else
			{
				this.oCPU.AX.Word = 0x2;
			}
		
			// Instruction address 0x1866:0x0376, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) + 0xf0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				this.oCPU.AX.Word);

		L037e:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L0381:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x9);
			if (this.oCPU.Flags.L) goto L038a;
			goto L06cc;

		L038a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x1866:0x0397, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x03b0, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L037e;

			if (playerID != 0)
			{
				this.oCPU.AX.Low = 0x1;
				this.oCPU.CX.Low = (byte)playerID;
				this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
				this.oCPU.CX.Word = this.oCPU.AX.Word;

				this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))] |= (sbyte)this.oCPU.CX.Low;
			}

			// Instruction address 0x1866:0x03e5, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x1);
			if (this.oCPU.Flags.NE) goto L03f9;
			goto L04bd;

		L03f9:
			// Instruction address 0x1866:0x03ff, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			if ((short)this.oCPU.AX.Word == playerID)
				goto L04bd;

			// Instruction address 0x1866:0x0415, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0426, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0433, size: 3
			F0_1866_0006((short)this.oCPU.AX.Word);

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				this.oCPU.AX.Word = 0x1c;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
				this.oCPU.SI.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].ActualSize;
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].VisibleSize = (sbyte)this.oCPU.AX.Low;
			}

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x0);
			if (this.oCPU.Flags.NE) goto L04bd;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dd),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dd)), this.oCPU.AX.Low));

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))] & 2) != 0)
				goto L04bd;

			// Instruction address 0x1866:0x049f, size: 5
			this.oParent.Segment_25fb.F0_25fb_304d(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				1, 4);

			// Instruction address 0x1866:0x04b5, size: 5
			this.oParent.Segment_25fb.F0_25fb_304d(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				2, 2);

		L04bd:
			// Instruction address 0x1866:0x04c3, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L04d6;
			goto L0329;

		L04d6:
			if (playerID == this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0))
				goto L0329;

			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x1);
			if (this.oCPU.Flags.NE) goto L0503;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd)), this.oCPU.AX.Low));

		L0503:
			// Instruction address 0x1866:0x0513, size: 3
			F0_1866_144b(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0), this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x14a2);

			// Instruction address 0x1866:0x051f, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0532;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xa);
			if (this.oCPU.Flags.E) goto L0548;

		L0532:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81da), 0xff);

		L0548:
			// Instruction address 0x1866:0x054e, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0580;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xa);
			if (this.oCPU.Flags.E) goto L0580;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x1);
			if (this.oCPU.Flags.NE) goto L0595;

		L0580:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81da), 0xff);

		L0595:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x1);
			if (this.oCPU.Flags.NE) goto L05b7;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd)), this.oCPU.AX.Low));

		L05b7:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x0);
			if (this.oCPU.Flags.E) goto L05d9;
			goto L02e2;

		L05d9:
			// Instruction address 0x1866:0x05df, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(xPos, yPos);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L05ef;
			goto L02e2;

		L05ef:
			// Instruction address 0x1866:0x05f5, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0605;
			goto L02e2;

		L0605:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x1);
			if (this.oCPU.Flags.NE) goto L0628;
			goto L02e2;

		L0628:
			// Instruction address 0x1866:0x0635, size: 5
			this.oParent.Segment_2517.F0_2517_0737(playerID, this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0), xPos, yPos);
			
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADDWord(this.oCPU.BX.Word, this.oCPU.AX.Word);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0)] & 2) != 0)
				goto L06a3;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0), 0x0);
			if (this.oCPU.Flags.E) goto L068b;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d7)), 0x1a);
			if (this.oCPU.Flags.E) goto L068b;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d4)), 0x8);
			if (this.oCPU.Flags.E) goto L0686;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), 0x2);
			if (this.oCPU.Flags.E) goto L068b;

		L0686:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x3);

		L068b:
			// Instruction address 0x1866:0x069b, size: 5
			this.oParent.Segment_25fb.F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				1, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

		L06a3:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0x1a);
			if (this.oCPU.Flags.NE) goto L06bd;
			goto L02e2;

		L06bd:
			if (playerID == 0)
				goto L02c8;

			this.oCPU.AX.Word = 0x2;
			goto L02cb;

		L06cc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x9);
			goto L08bc;

		L06d4:
			// Instruction address 0x1866:0x06e2, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) + 0xf0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				2);

		L06ea:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xffff);
			if (this.oCPU.Flags.NE) goto L06f3;
			goto L0857;

		L06f3:			
			if (playerID == this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0))
				goto L0857;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d7)), 0x16);
			if (this.oCPU.Flags.NE) goto L0718;
			goto L0857;

		L0718:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1144)), 0x2);
			if (this.oCPU.Flags.NE) goto L0743;
			goto L07f0;

		L0743:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1138)), 0x2);
			if (this.oCPU.Flags.NE) goto L0760;

			// Instruction address 0x1866:0x0750, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(xPos, yPos);

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0760;
			goto L07f0;

		L0760:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4),
				this.oCPU.ANDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0xfe));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81da), 0xff);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0x1);
			if (this.oCPU.Flags.NE) goto L079d;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81dd),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81dd)), this.oCPU.AX.Low));

		L079d:
			// Instruction address 0x1866:0x07a3, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L07b3;
			goto L0857;

		L07b3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0), 0x0);
			if (this.oCPU.Flags.NE) goto L07bd;
			goto L0857;

		L07bd:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0)] & 2) != 0)
				goto L0857;

			// Instruction address 0x1866:0x07e6, size: 5
			this.oParent.Segment_25fb.F0_25fb_304d(this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0),
				(short)xPos, (short)yPos, 3, 2);

			goto L0857;

		L07f0:
			if (this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0) != this.oParent.GameState.HumanPlayerID)
				goto L0857;

			// Instruction address 0x1866:0x07ff, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0857;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.MapVisibility[xPos, yPos];
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0857;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd)), this.oCPU.AX.Low));

			// Instruction address 0x1866:0x084f, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(xPos, yPos);

		L0857:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x1);
			if (this.oCPU.Flags.E) goto L08b9;

			// Instruction address 0x1866:0x0863, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			if ((short)this.oCPU.AX.Word != this.oParent.GameState.HumanPlayerID)
				goto L08b9;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.MapVisibility[xPos, yPos];
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L08b9;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd)), this.oCPU.AX.Low));

			// Instruction address 0x1866:0x08b1, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(xPos, yPos);

		L08b9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));

		L08bc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x19);
			if (this.oCPU.Flags.L) goto L08c5;
			goto L0a42;

		L08c5:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x1866:0x08d2, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x08eb, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L08b9;

			// Instruction address 0x1866:0x08fd, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x090e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d7)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1144)), 0x2);
			if (this.oCPU.Flags.NE) goto L093b;
			goto L06ea;

		L093b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1138)), 0x2);
			if (this.oCPU.Flags.NE) goto L0958;

			// Instruction address 0x1866:0x0948, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0958;
			goto L06ea;

		L0958:
			if (playerID != 0)
			{
				this.oCPU.AX.Low = 0x1;
				this.oCPU.CX.Low = (byte)playerID;
				this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
				this.oCPU.CX.Word = this.oCPU.AX.Word;

				this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
					this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))] |= (sbyte)this.oCPU.CX.Low;
			}

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xffff);
			if (this.oCPU.Flags.E) goto L09f9;

			if (playerID == this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd7f0))
				goto L09f9;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0x16);
			if (this.oCPU.Flags.E) goto L09f9;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x1);
			if (this.oCPU.Flags.NE) goto L09b2;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dd),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dd)), this.oCPU.AX.Low));

		L09b2:
			// Instruction address 0x1866:0x09b8, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L09f9;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0), 0x0);
			if (this.oCPU.Flags.E) goto L09f9;
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0)] & 2) != 0)
				goto L09f9;

			// Instruction address 0x1866:0x09f1, size: 5
			this.oParent.Segment_25fb.F0_25fb_304d(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				3, 2);

		L09f9:
			this.oCPU.CMPWord(flag, 0x0);
			if (this.oCPU.Flags.NE) goto L0a02;
			goto L06ea;

		L0a02:
			if (playerID != this.oParent.GameState.HumanPlayerID &&
				this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd806) == 0)
				goto L06ea;

			// Instruction address 0x1866:0x0a1a, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			// Instruction address 0x1866:0x0a2e, size: 3
			this.oParent.VGADriver.F0_VGA_038c_GetPixel(2,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0a3c;
			goto L06d4;

		L0a3c:
			// Instruction address 0x1866:0x06e2, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(2, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)) + 0xf0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				1);

			goto L06ea;

		L0a42:
			if (playerID != this.oParent.GameState.HumanPlayerID)
				goto L0ad0;

			this.oCPU.CMPWord(flag, 0x0);
			if (this.oCPU.Flags.E) goto L0ad0;

			// Instruction address 0x1866:0x0a59, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x9);

		L0a66:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x1866:0x0a73, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0a8c, size: 5
			this.oParent.Segment_2aea.F0_2aea_1326_CheckMapBounds(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0ac7;

			this.oCPU.AX.Low = (byte)this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))];
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0ac7;

			// Instruction address 0x1866:0x0abf, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));

		L0ac7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x31);
			if (this.oCPU.Flags.L) goto L0a66;

		L0ad0:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_01dc");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="param3"></param>
		/// <param name="param4"></param>
		public void F0_1866_0ad6(short playerID, short unitID, ushort param3, ushort param4)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_0ad6({playerID}, {unitID}, {param3}, {param4})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xe);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);
			this.oCPU.CMPWord(param3, 0xffff);
			if (this.oCPU.Flags.E) goto L0b2d;

			// Instruction address 0x1866:0x0af0, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				(short)param3 - this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4cc));

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = param4;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd75e));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x50);
			if (this.oCPU.Flags.L) goto L0b28;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x140);
			if (this.oCPU.Flags.GE) goto L0b28;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L0b28;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xc0);
			if (this.oCPU.Flags.LE) goto L0b2d;

		L0b28:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0xffff);

		L0b2d:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70ea);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0b36;
			this.oCPU.AX.Word = 0;

		L0b36:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70ea));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0b5b, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)) -
					this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x6ed6));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			if (unitID < 127)
			{
				this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			}
			else
			{
				this.oCPU.AX.Low = 0xff;
			}
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L0b75:
			// Instruction address 0x1866:0x0b75, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			if (unitID >= 128)
				goto L0bc9;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0b9d, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.L) goto L0be1;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x32);
			if (this.oCPU.Flags.GE) goto L0be1;

			// Instruction address 0x1866:0x0bbf, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 8,
				15);

			goto L0be1;

		L0bc9:
			// Instruction address 0x1866:0x0bd9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x20f6, 4, 124, 7);

		L0be1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
			if (this.oCPU.Flags.E) goto L0bfb;

			// Instruction address 0x1866:0x0bf3, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				15, 15, 15);

		L0bfb:
			// Instruction address 0x1866:0x0bfb, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1866:0x0c00, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0c0e;
			this.oCPU.AX.Word = 0x1;
			goto L0c11;

		L0c0e:
			this.oCPU.AX.Word = 0xa;

		L0c11:
			// Instruction address 0x1866:0x0c12, size: 5
			this.oParent.Segment_1182.F0_1182_0134_WaitTime((short)this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0c1a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			if (unitID >= 0x80)
				goto L0c86;

			// Instruction address 0x1866:0x0c2c, size: 5
			this.oParent.Segment_2aea.F0_2aea_0e29(playerID, unitID);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.L) goto L0c9d;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x32);
			if (this.oCPU.Flags.GE) goto L0c9d;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0c5c, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E)
			{
				this.oCPU.AX.Word = 0x1;
			}
			else
			{
				this.oCPU.AX.Word = 0x2;
			}

			// Instruction address 0x1866:0x0c7c, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 8,
				this.oCPU.AX.Word);

			goto L0c9d;

		L0c86:
			// Instruction address 0x1866:0x0c95, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x2102, 4, 124, 0);

		L0c9d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
			if (this.oCPU.Flags.E) goto L0cb9;

			// Instruction address 0x1866:0x0cb1, size: 5
			this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)),
				15, 15, 0);

		L0cb9:
			// Instruction address 0x1866:0x0cb9, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1866:0x0cbe, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0ccc;
			this.oCPU.AX.Word = 0x1;
			goto L0ccf;

		L0ccc:
			this.oCPU.AX.Word = 0xa;

		L0ccf:
			// Instruction address 0x1866:0x0cd0, size: 5
			this.oParent.Segment_1182.F0_1182_0134_WaitTime((short)this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0cd8, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			// Instruction address 0x1866:0x0cdd, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0cf0;
			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.NE) goto L0cf0;
			goto L0b75;

		L0cf0:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_0ad6");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_1866_0cf5(short playerID, short unitID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_0cf5({playerID}, {unitID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L0d06;

		L0d03:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0d06:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x7f);
			if (this.oCPU.Flags.L) goto L0d0f;
			goto L0ec8;

		L0d0f:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.NE) goto L0d03;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5), 0xff);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81de), 0xff);

			// Instruction address 0x1866:0x0d39, size: 5
			this.oParent.Segment_2aea.F0_2aea_138c_MapSetCityOwner(playerID, xPos, yPos);

			// Instruction address 0x1866:0x0d4d, size: 5
			this.oParent.Segment_2aea.F0_2aea_13cb(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), xPos, yPos);

			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.MapVisibility[xPos, yPos] |= (sbyte)this.oCPU.CX.Low;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4), 0x0);
			this.oCPU.AX.Low = (byte)xPos;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5), this.oCPU.AX.Low);
			this.oCPU.AX.Low = (byte)yPos;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6), this.oCPU.AX.Low);
			this.oCPU.AX.Low = (byte)unitID;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dd), this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81da), 0xff);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dc), 0xff);
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113c));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d9), this.oCPU.AX.Low);

			// Instruction address 0x1866:0x0db6, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(xPos, yPos);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x1c;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			// !!!
			if (this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df)) < 128)
			{
				this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df))].PlayerID;
			}
			else
			{
				this.oCPU.AX.Word = 0xffff;
			}
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L0dd9;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df), 0xff);

		L0dd9:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x81d9);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
			if (this.oCPU.Flags.E) goto L0df4;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.DECByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word)));

		L0df4:
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = (ushort)unitID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID].ActiveUnits[unitID]++;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x20f4), 0x0);
			if (this.oCPU.Flags.NE) goto L0e7d;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L0e3d;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0e3d;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81dd));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L0e64;

		L0e3d:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x0e5c, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

		L0e64:
			// Instruction address 0x1866:0x0e77, size: 3
			F0_1866_01dc(
				xPos,
				yPos,
				playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				1);

		L0e7d:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0ec3;
			if (this.oParent.GameState.TurnCount == 0) goto L0ec3;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x20f4), 0x0);
			if (this.oCPU.Flags.NE) goto L0ec3;

			if (this.oParent.GameState.Players[playerID].UnitCount != 0) goto L0eab;

			this.oParent.Help.F4_0000_02d3(0x210e);

		L0eab:
			if (this.oParent.GameState.Players[playerID].UnitCount != 1) goto L0ec3;

			this.oParent.Help.F4_0000_02d3(0x211a);

		L0ec3:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			goto L0f0b;

		L0ec8:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0f08;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd760), 0x0);
			if (this.oCPU.Flags.NE) goto L0f08;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x3);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x1866:0x0ee6, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f(0x2126);

			// Instruction address 0x1866:0x0efa, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 80, 64);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd760, 0x1);

		L0f08:
			this.oCPU.AX.Word = 0xffff;

		L0f0b:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_0cf5");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_0f10(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_0f10({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x70d8), 0x0);
			if (this.oCPU.Flags.E) goto L0f46;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);

			this.oParent.GameState.Players[playerID].LostUnits[this.oCPU.AX.Word]++;

		L0f46:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1146)), 0x0);
			if (this.oCPU.Flags.E) goto L0f9a;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81de)), 0xff);
			if (this.oCPU.Flags.E) goto L0f9a;

			// Instruction address 0x1866:0x0f78, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0f9a;

			// Instruction address 0x1866:0x0f94, size: 3
			F0_1866_144b(playerID, unitID, 0x1610);

		L0f9a:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0x17);
			if (this.oCPU.Flags.NE) goto L0fe6;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81de)), 0xff);
			if (this.oCPU.Flags.E) goto L0fe6;

			// Instruction address 0x1866:0x0fc4, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L0fe6;

			// Instruction address 0x1866:0x0fe0, size: 3
			F0_1866_144b(playerID, unitID, 0x1676);

		L0fe6:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);

			if (this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)) != -1)
				this.oParent.GameState.Players[playerID].ActiveUnits[this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7))]--;

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7), 0xff);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d8), 0x0);

			// Instruction address 0x1866:0x1027, size: 5
			this.oParent.Segment_2aea.F0_2aea_1412(playerID, unitID,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x20f4), 0x0);
			if (this.oCPU.Flags.NE) goto L1085;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3936), 0xffff);
			if (this.oCPU.Flags.NE) goto L1085;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L105e;

			if (playerID == this.oParent.GameState.HumanPlayerID)
				goto L105e;

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dd));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.E) goto L1085;

		L105e:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x107d, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

		L1085:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_0f10");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_1866_1089(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1089({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de)), 0xff);
			if (this.oCPU.Flags.NE) goto L10ad;
			this.oCPU.AX.Word = (ushort)unitID;
			goto L111c;

		L10ad:
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6530, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6534, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L10c3;

		L10c0:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L10c3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L1119;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L10c0;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d5)), this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L10c0;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d6)), this.oCPU.AX.Low);
			if (this.oCPU.Flags.NE) goto L10c0;

			// Instruction address 0x1866:0x1113, size: 3
			F0_1866_144b(playerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x1169);

		L1119:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6530);

		L111c:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1089");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_1866_1122(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1122({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de)), 0xff);
			if (this.oCPU.Flags.NE) goto L1142;
			this.oCPU.AX.Word = (ushort)unitID;
			goto L1166;

		L1142:
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6530, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6534, 0xffff);

			// Instruction address 0x1866:0x115d, size: 3
			F0_1866_144b(playerID, unitID, 0x1169);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6530);

		L1166:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1122");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1169(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1169({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1195, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L11b7;
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x2);
			if (this.oCPU.Flags.E) goto L11b7;
			goto L124b;

		L11b7:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1138)), 0x0);
			if (this.oCPU.Flags.NE) goto L1202;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d4)), 0x8);
			if (this.oCPU.Flags.E) goto L11e2;
			this.oCPU.AX.Word = 0x3;
			goto L11e5;

		L11e2:
			this.oCPU.AX.Word = 0x2;

		L11e5:
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1140)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.CX.Word;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.CX.Low = 0x3;
			goto L1210;

		L1202:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140));
			this.oCPU.CX.Low = 0x4;

		L1210:
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4)), 0x20);
			if (this.oCPU.Flags.E) goto L1237;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L1237:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6534);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L124b;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6534, this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6530, this.oCPU.AX.Word);

		L124b:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1169");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F0_1866_1251(short playerID, short unitID, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1251({playerID}, {unitID}, {param3})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6532, 0x0);
			this.oCPU.AX.Word = param3;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6536, this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6538, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1275, size: 3
			F0_1866_144b(playerID, unitID, 0x1280);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6532);
			this.oCPU.BP.Word = this.oCPU.PopWord();

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1251");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1280(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1280({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6536);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L12a5;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L12c7;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L1298;
			goto L132a;

		L1298:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.E) goto L12e5;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.E) goto L1303;
			goto L132e;

		L12a5:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1142));

		L12c1:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6532, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6532), this.oCPU.AX.Word));
			goto L132e;

		L12c7:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140));
			goto L12c1;

		L12e5:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113e));
			goto L12c1;

		L1303:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6538);
			this.oCPU.CMPWord((ushort)unitID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L132e;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), 0x2);
			if (this.oCPU.Flags.NE) goto L132e;

			L132a:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6532, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6532)));

		L132e:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1280");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F0_1866_1331(short playerID, short unitID, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1331({playerID}, {unitID}, {param3})");

			// function body			
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653a, param3);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653c, 0x0);

			// Instruction address 0x1866:0x134f, size: 3
			F0_1866_144b(playerID, unitID, 0x135a);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653c);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1331");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_135a(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_135a({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653a));
			if (this.oCPU.Flags.NE) goto L137d;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653c, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653c)));

		L137d:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_135a");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="param3"></param>
		/// <returns></returns>
		public ushort F0_1866_1380(short playerID, short unitID, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1380({playerID}, {unitID}, {param3})");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653a, param3);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653c, 0x0);

			// Instruction address 0x1866:0x139e, size: 3
			F0_1866_144b(playerID, unitID, 0x13a9);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653c);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1380");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_13a9(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_13a9({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653a);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L13d2;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653c, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653c)));

		L13d2:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_13a9");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <returns></returns>
		public ushort F0_1866_13d5(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_13d5({playerID}, {unitID})");

			// function body
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653c, 0x0);

			// Instruction address 0x1866:0x13ed, size: 3
			F0_1866_144b(playerID, unitID, 0x13f8);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653c);

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_13d5");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_13f8(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_13f8({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x0);
			if (this.oCPU.Flags.NE) goto L1420;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653c, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653c)));

		L1420:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d7)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1148)), 0x5);
			if (this.oCPU.Flags.NE) goto L1447;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1146));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x653c, this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x653c), this.oCPU.AX.Word));

		L1447:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_13f8");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="fnPtr"></param>
		/// <exception cref="Exception"></exception>
		public void F0_1866_144b(short playerID, short unitID, int fnPtr)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_144b({playerID}, {unitID}, 0x{fnPtr:x4})");

			// function body
			short oldUnitID = unitID;

			for (int i = 0; i < 10; i++)
			{
				this.oCPU.AX.Word = 0xc;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)oldUnitID);
				this.oCPU.BX.Word = this.oCPU.AX.Word;
				this.oCPU.AX.Word = 0x600;
				this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
				this.oCPU.SI.Word = this.oCPU.AX.Word;

				short newUnitID = this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de));

				// Instruction address 0x1866:0x147b, size: 3
				switch (fnPtr)
				{
					case 0xf10:
						F0_1866_0f10(playerID, oldUnitID);
						break;

					case 0x1169:
						F0_1866_1169(playerID, oldUnitID);
						break;

					case 0x1280:
						F0_1866_1280(playerID, oldUnitID);
						break;

					case 0x135a:
						F0_1866_135a(playerID, oldUnitID);
						break;

					case 0x13a9:
						F0_1866_13a9(playerID, oldUnitID);
						break;

					case 0x13f8:
						F0_1866_13f8(playerID, oldUnitID);
						break;

					case 0x14a2:
						F0_1866_14a2(playerID, oldUnitID);
						break;

					case 0x14f6:
						F0_1866_14f6(playerID, oldUnitID);
						break;

					case 0x1560:
						F0_1866_1560(playerID, oldUnitID);
						break;

					case 0x1593:
						F0_1866_1593(playerID, oldUnitID);
						break;

					case 0x1610:
						F0_1866_1610(playerID, oldUnitID);
						break;

					case 0x1643:
						F0_1866_1643(playerID, oldUnitID);
						break;

					case 0x1676:
						F0_1866_1676(playerID, oldUnitID);
						break;

					default:
						throw new Exception("Unknown function address");
				}

				oldUnitID = newUnitID;

				if (oldUnitID == -1 || oldUnitID == unitID)
					break;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_144b");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_14a2(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_14a2({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x14c2, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L14de;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x0);
			if (this.oCPU.Flags.E) goto L14f3;

			L14de:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4), 
				this.oCPU.ANDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4)), 0xfe));

		L14f3:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_14a2");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_14f6(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_14f6({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0x1);
			if (this.oCPU.Flags.E) goto L1542;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4),
				this.oCPU.ANDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0xfe));
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113a)));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d8), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113c));
			this.oCPU.DI.Word = this.oCPU.ORWord(this.oCPU.DI.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L1542;
			this.oCPU.AX.Word = this.oCPU.DI.Word;
			this.oCPU.AX.Low = this.oCPU.DECByte(this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d9), this.oCPU.AX.Low);

		L1542:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0xff;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81dc), this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81da), this.oCPU.AX.Low);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_14f6");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1560(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1560({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x2);
			if (this.oCPU.Flags.NE) goto L1590;

			// Instruction address 0x1866:0x158a, size: 3
			F0_1866_1593(playerID, unitID);

		L1590:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1560");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1593(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1593({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0xc2);
			if (this.oCPU.Flags.E) goto L15b3;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d9), 0x0);

		L15b3:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0xcb);
			if (this.oCPU.Flags.E) goto L15dd;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113a)));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d8), this.oCPU.AX.Low);

		L15dd:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4), 
				this.oCPU.ANDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0x30));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81da), 0xff);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L160d;

			// Instruction address 0x1866:0x1605, size: 5
			this.oParent.Segment_2aea.F0_2aea_0e29(playerID, unitID);

		L160d:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1593");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1610(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1610({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x0);
			if (this.oCPU.Flags.NE) goto L1640;

			// Instruction address 0x1866:0x163a, size: 3
			F0_1866_0f10(playerID, unitID);

		L1640:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1610");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1643(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1643({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x0);
			if (this.oCPU.Flags.E) goto L1673;
			
			// Instruction address 0x1866:0x166d, size: 3
			F0_1866_0f10(playerID, unitID);

		L1673:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1643");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1676(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1676({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x1);
			if (this.oCPU.Flags.NE) goto L16a6;

			// Instruction address 0x1866:0x16a0, size: 3
			F0_1866_0f10(playerID, unitID);

		L16a6:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1676");
		}

		/// <summary>
		/// ??? To be checked - Too many parameters calling F0_2aea_0008
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public void F0_1866_16a9(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_16a9({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

			if (xPos < 16 && this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4cc) > 64)
			{
				xPos += 80;
			}

			if (xPos < this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4cc) + 2 ||
				xPos > this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4cc) + 13)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			}

			if (yPos < this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd75e) + 2 ||
				yPos > this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd75e) + 9)
			{
				this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			}
		
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L1721;

			// Instruction address 0x1866:0x170d, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(xPos - 8);

			// Instruction address 0x1866:0x1719, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008(playerID, (short)this.oCPU.AX.Word, yPos - 6);

		L1721:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_16a9");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public ushort F0_1866_1725(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1725({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;

			// Instruction address 0x1866:0x172e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(xPos, yPos);

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L173e;
			this.oCPU.AX.Word = 0;
			goto L174e;

		L173e:
			// Instruction address 0x1866:0x1748, size: 3
			F0_1866_1750(playerID, xPos, yPos);

		L174e:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1725");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		public ushort F0_1866_1750(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1750({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x1866:0x175e, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(xPos, yPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x1);
			goto L1795;

		L1770:
			this.oCPU.AX.Word = 0;

		L1772:
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1866:0x177a, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L178c;
			this.oCPU.AX.Word = 0x1;
			goto L178e;

		L178c:
			this.oCPU.AX.Word = 0;

		L178e:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.DI.Word);
			if (this.oCPU.Flags.E) goto L17cb;

		L1792:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L1795:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x9);
			if (this.oCPU.Flags.L) goto L179e;
			goto L18c8;

		L179e:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x1866:0x17ab, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)), 0xa);
			if (this.oCPU.Flags.NE) goto L1770;
			this.oCPU.AX.Word = 0x1;
			goto L1772;

		L17cb:
			// Instruction address 0x1866:0x17d1, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1792;
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1792;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L17f4;
			goto L18c3;

		L17f4:
			// Instruction address 0x1866:0x17fa, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x81dd);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.DX.Word = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
			this.oCPU.TESTWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1856;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word, this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word), this.oCPU.AX.Low));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))] |= (sbyte)this.oCPU.CX.Low;

			// Instruction address 0x1866:0x184e, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L1856:
			// Instruction address 0x1866:0x185c, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L18c3;

			// Instruction address 0x1866:0x186e, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].ActualSize;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].VisibleSize = (sbyte)this.oCPU.AX.Low;
			
			// Instruction address 0x1866:0x188f, size: 5
			this.oParent.Segment_2aea.F0_2aea_1601(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oParent.GameState.MapVisibility[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))] |= (sbyte)this.oCPU.CX.Low;

			// Instruction address 0x1866:0x18bb, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

		L18c3:
			this.oCPU.AX.Word = 0x1;
			goto L18ca;

		L18c8:
			this.oCPU.AX.Word = 0;

		L18ca:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1750");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="xPos"></param>
		/// <param name="yPos"></param>
		/// <returns></returns>
		public ushort F0_1866_18d0(short playerID, int xPos, int yPos)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_18d0({playerID}, {xPos}, {yPos})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);
			goto L18e1;

		L18de:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L18e1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x9);
			if (this.oCPU.Flags.GE) goto L192a;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x1866:0x18f4, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) + xPos);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x190d, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L18de;
			
			if (this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) == playerID)
				goto L18de;

			this.oCPU.AX.Word = 0x1;
			goto L192c;

		L192a:
			this.oCPU.AX.Word = 0;

		L192c:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_18d0");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1931(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1931({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x12);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			if (playerID == 0)
				goto L1d4f;

			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x1);
			if (this.oCPU.Flags.NE) goto L1964;
			goto L1d4f;

		L1964:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1980, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0102(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1866:0x19a9, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				// !!! Added if city doesn't exist at that location
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) >= 0 && this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) < 128) ?
					this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.X : -1,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)),
				// !!! Added if city doesn't exist at that location
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) >= 0 && this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) < 128) ?
					this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))].Position.Y : -1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x19b8, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(4));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L19e7;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.NE) goto L19cc;
			goto L1a7f;

		L19cc:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L19d4;
			goto L1a8e;

		L19d4:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
			if (this.oCPU.Flags.NE) goto L19dc;
			goto L1b88;

		L19dc:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.NE) goto L19e4;
			goto L1b9a;

		L19e4:
			goto L1d4f;

		L19e7:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1a0b, size: 3
			this.oParent.VGADriver.F0_VGA_038c_GetPixel(2,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)) + 80,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x4);
			if (this.oCPU.Flags.GE) goto L1a20;
			goto L1b9a;

		L1a20:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
			if (this.oCPU.Flags.LE) goto L1a8e;

			// Instruction address 0x1866:0x1a2d, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_212c);

			if (playerID != this.oParent.GameState.HumanPlayerID)
				goto L1a51;

			// Instruction address 0x1866:0x1a49, size: 5
			this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);

		L1a51:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			
			this.oParent.Overlay_20.F20_0000_0000(playerID,
				0,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)),
				1);

			goto L1d30;

		L1a7f:
			if (this.oParent.GameState.TurnCount == 0) goto L1a8e;
			if (this.oParent.GameState.Year <= 1000) goto L1ac7;

			L1a8e:
			// Instruction address 0x1866:0x1a96, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_2184);

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1ab2, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}

			this.oParent.GameState.Players[playerID].Coins += 50;
			goto L1d4f;

		L1ac7:
			// Instruction address 0x1866:0x1acf, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_2154);

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1aeb, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}
		
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

			// Instruction address 0x1866:0x1afc, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(72));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);

		L1b07:
			// Instruction address 0x1866:0x1b0d, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE)
				goto L1b63;
			
			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			// Instruction address 0x1866:0x1b2a, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ee)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L1b63;

			// Instruction address 0x1866:0x1b3f, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4ef)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L1b63;
			
			// Instruction address 0x1866:0x1b54, size: 5
			this.oParent.Segment_1ade.F0_1ade_1d2e(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
				0);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0xffff);
			goto L1b72;

		L1b63:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x48;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.DX.Word);

		L1b72:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x3e7);
			if (this.oCPU.Flags.L) goto L1b7f;
			goto L1d4f;

		L1b7f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0xffff);
			if (this.oCPU.Flags.NE) goto L1b07;
			goto L1d4f;

		L1b88:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x4);
			if (this.oCPU.Flags.L) goto L1b9a;
			
			if (this.oParent.GameState.Players[playerID].CityCount != 0) goto L1bff;

		L1b9a:
			// Instruction address 0x1866:0x1ba2, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_21e6);

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1bbe, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}
		
			goto L1d28;

		L1bff:
			// Instruction address 0x1866:0x1c07, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_21bb);

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1c23, size: 5
				this.oParent.Segment_1238.F0_1238_001e_ShowDialog(0xba06, 100, 80);
			}

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x1);
			goto L1c91;

		L1c32:
			this.oCPU.AX.Word = 0x6;

		L1c35:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1c43, size: 3
			F0_1866_0cf5(
				0,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			
			this.oCPU.CX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1;
			this.oCPU.CX.Low = (byte)playerID;
			this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81dd), 
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81dd)), this.oCPU.AX.Low));

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1c69, size: 5
				this.oParent.Segment_2aea.F0_2aea_11d4(
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			}

		L1c71:
			// Instruction address 0x1866:0x1c86, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
				4 - this.oParent.GameState.Players[playerID].CityCount,	1, 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));

		L1c91:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), 0x8);
			if (this.oCPU.Flags.LE) goto L1c9a;
			goto L1d4f;

		L1c9a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1ccd, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1c71;

			// Instruction address 0x1866:0x1cde, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L1c71;

			// Instruction address 0x1866:0x1cf0, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1d00;
			goto L1c71;

		L1d00:
			// Instruction address 0x1866:0x1d06, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));

			this.oCPU.CX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28e)), 0x2);
			if (this.oCPU.Flags.G) goto L1d1f;
			goto L1c32;

		L1d1f:
			this.oCPU.AX.Word = 0x3;
			goto L1c35;

		L1d28:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1d2d, size: 3
			F0_1866_0cf5(
				playerID,
				(short)((this.oParent.MSCAPI.RNG.Next(2) != 0) ? 3 : 6),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

		L1d30:
			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				// Instruction address 0x1866:0x1d47, size: 5
				this.oParent.Segment_2aea.F0_2aea_11d4(
					this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
					this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));
			}

		L1d4f:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1931");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		/// <param name="param3"></param>
		public void F0_1866_1d55(short playerID, short unitID, ushort param3)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1d55({playerID}, {unitID}, {param3})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb278), 0x1);
			if (this.oCPU.Flags.NE) goto L1d8b;

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1d80, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

			goto L1f63;

		L1d8b:
			// Instruction address 0x1866:0x1d8b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);

			// Instruction address 0x1866:0x1dae, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1dbd;
			goto L1f5e;

		L1dbd:
			// Instruction address 0x1866:0x1dc9, size: 5
			this.oParent.Segment_1403.F0_1403_4508(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1dd8;
			goto L1f5e;

		L1dd8:
			this.oCPU.AX.Word = param3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			// Instruction address 0x1866:0x1dfa, size: 5
			this.oParent.Segment_1403.F0_1403_4508(
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1882)) + this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)),
				this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x18e4)) + this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1e09;
			goto L1f5e;

		L1e09:
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81de)), 0xff);
			if (this.oCPU.Flags.E) goto L1e61;

			// Instruction address 0x1866:0x1e1c, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.NE) goto L1e40;
			this.oCPU.AX.Low = 0xc;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81de)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138)), 0x2);
			if (this.oCPU.Flags.NE) goto L1e61;

		L1e40:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x1866:0x1e59, size: 5
			this.oParent.Segment_2aea.F0_2aea_0e29(playerID, this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de)));

		L1e61:
			// Instruction address 0x1866:0x1e7f, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x50, 0, 0xf0, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0x50, 0);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x1ea2, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b_AdjustXPosition(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)) -
					this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd4cc));

			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd75e));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L1ecb:
			this.oCPU.SI.Word = (ushort)(param3 << 1);
			// Instruction address 0x1866:0x1f0a, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) *
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) + 1,
				(this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)) *
						this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 1,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt8(this.oCPU.DS.Word,
							(ushort)(((0x600 * playerID) + (0xc * unitID)) + 0x81d7)) + (playerID << 5) + 0x40) << 1) + 0xd4ce)));

			// Instruction address 0x1866:0x1f16, size: 5
			this.oParent.Segment_1182.F0_1182_0134_WaitTime(1);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			
			// Instruction address 0x1866:0x1f4a, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.DI.Word,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)),
				0x10, 0x10,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.DI.Word, this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x10);
			if (this.oCPU.Flags.G) goto L1f5e;
			goto L1ecb;

		L1f5e:
			// Instruction address 0x1866:0x1f5e, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

		L1f63:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1d55");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_1f69(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_1f69({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x28);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x1866:0x1f71, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x1866:0x1f81, size: 3
			F0_1866_1089(playerID, unitID);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L1f9a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0xc);
			if (this.oCPU.Flags.GE) goto L1fd3;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L1fd3;
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1f9a;

		L1fd3:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x60);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);

		L1fe2:
			// Instruction address 0x1866:0x1ffc, size: 5
			this.oParent.Segment_2d05.F0_2d05_096c_FillRectangleWithDoubleShadow(100, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
				120, (this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)) << 4) + 5, 3);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 0x0);
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);

		L2018:
			// Instruction address 0x1866:0x2025, size: 5
			this.oParent.Segment_2aea.F0_2aea_0fb3(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)),
				106, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x112a);
			// Instruction address 0x1866:0x204b, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0x20);
			if (this.oCPU.Flags.E) goto L206a;

			// Instruction address 0x1866:0x2062, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2224);

		L206a:
			// Instruction address 0x1866:0x2079, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 128, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 15);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x209c, size: 5
			this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df)));
			
			// Instruction address 0x1866:0x20b7, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 128, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)) + 8, 14);

			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)), 0x10));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0xc);
			if (this.oCPU.Flags.GE) goto L20e4;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L20e4;
			this.oCPU.AX.Word = (ushort)unitID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L20e4;
			goto L2018;

		L20e4:
			// Instruction address 0x1866:0x20e4, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1866:0x20e9, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
			if (this.oCPU.Flags.E) goto L2110;

		L20f5:
			// Instruction address 0x1866:0x20f5, size: 5
			this.oParent.Segment_11a8.F0_11a8_0223();

			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
			if (this.oCPU.Flags.E) goto L2104;
			goto L21b7;

		L2104:
			// Instruction address 0x1866:0x2104, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L20f5;
			goto L21b7;

		L2110:
			// Instruction address 0x1866:0x2136, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 
				105,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) * 16) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)) + 4,
				112, 17, 3, 11);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x2144, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4800);
			if (this.oCPU.Flags.E) goto L2158;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5000);
			if (this.oCPU.Flags.E) goto L21a0;
			goto L2161;

		L2158:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L2161;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L2161:
			// Instruction address 0x1866:0x2187, size: 5
			this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 
				105,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) * 16) +
					this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)) + 4,
				112, 17, 11, 3);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xd);
			if (this.oCPU.Flags.E) goto L219b;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x20);
			if (this.oCPU.Flags.NE) goto L21ae;

		L219b:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			goto L21ef;

		L21a0:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			if (this.oCPU.Flags.LE) goto L2161;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			goto L2161;

		L21ae:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x1b);
			if (this.oCPU.Flags.E) goto L21b7;
			goto L2110;

		L21b7:
			// Instruction address 0x1866:0x21b7, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();

			this.oCPU.CMPWord(this.oParent.Var_db3a, 0x1);
			if (this.oCPU.Flags.E) goto L21c6;
			goto L2256;

		L21c6:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0x64);
			if (this.oCPU.Flags.G) goto L21d0;
			goto L2256;

		L21d0:
			this.oCPU.CMPWord(this.oParent.Var_db3c, 0xdc);
			if (this.oCPU.Flags.GE) goto L2256;
			this.oCPU.AX.Word = this.oParent.Var_db3e;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x5);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x4;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);

		L21ef:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L2256;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L2256;
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x1a));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0xc2);
			if (this.oCPU.Flags.E) goto L2233;
			this.oCPU.AX.Low = 0x22;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113a)));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d8), this.oCPU.AX.Low);

		L2233:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4),
				this.oCPU.ANDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4)), 0x30));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81da), 0xff);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x28)), 0x1);
			if (this.oCPU.Flags.LE) goto L2256;
			goto L1fe2;

		L2256:
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x1866:0x225a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();

			// Instruction address 0x1866:0x225f, size: 5
			this.oParent.Segment_1403.F0_1403_4545();

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_1f69");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="playerID"></param>
		/// <param name="unitID"></param>
		public void F0_1866_226d(short playerID, short unitID)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_226d({playerID}, {unitID})");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x16);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x3e7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			goto L2330;

		L2287:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			
			// Instruction address 0x1866:0x22b0, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x28);
			if (this.oCPU.Flags.LE) goto L22c9;
			this.oCPU.AX.Word = 0x50;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

		L22c9:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			
			// Instruction address 0x1866:0x22f0, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			if (this.oCPU.Flags.GE) goto L2306;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));

		L2306:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L232d;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)((short)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);

		L232d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L2330:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x80);
			if (this.oCPU.Flags.GE) goto L2355;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L232d;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].PlayerID != playerID)
				goto L232d;
			goto L2287;

		L2355:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);

		L235a:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0x17);
			if (this.oCPU.Flags.E) goto L2374;
			goto L2416;

		L2374:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			
			// Instruction address 0x1866:0x239d, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x28);
			if (this.oCPU.Flags.LE) goto L23b6;
			this.oCPU.AX.Word = 0x50;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

		L23b6:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6));
			this.oCPU.CX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			
			// Instruction address 0x1866:0x23df, size: 5
			this.oParent.MSCAPI.abs((short)this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			if (this.oCPU.Flags.GE) goto L23f5;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));

		L23f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L2416;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

		L2416:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.GE) goto L2423;
			goto L235a;

		L2423:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), 0x0);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x1866:0x244c, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0243(
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)) - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)) - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x1);

		L245c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);

			// Instruction address 0x1866:0x248f, size: 5
			this.oParent.Segment_2aea.F0_2aea_14e0(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L24a7;
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L24f9;

		L24a7:
			// Instruction address 0x1866:0x24ad, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L24cc;

			// Instruction address 0x1866:0x24bf, size: 5
			this.oParent.Segment_2aea.F0_2aea_1369(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.NE) goto L24f9;

		L24cc:
			// Instruction address 0x1866:0x24da, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0243(
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L24f9;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L24f9:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x8);
			if (this.oCPU.Flags.G) goto L2505;
			goto L245c;

		L2505:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_226d");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1})");

			// function body
			if (this.oParent.GameState.ReplayDataLength + 3 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameState.TurnCount & 0xfff));

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data1;
				this.oParent.GameState.ReplayDataLength++;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_250e_AddReplayData");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1, byte data2)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1}, {data2})");

			// function body
			if (this.oParent.GameState.ReplayDataLength + 4 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameState.TurnCount & 0xfff));

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data1;
				this.oParent.GameState.ReplayDataLength++;
				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data2;
				this.oParent.GameState.ReplayDataLength++;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_250e_AddReplayData");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		/// <param name="data3"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1, byte data2, byte data3)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1}, {data2}, {data3})");

			// function body
			if (this.oParent.GameState.ReplayDataLength + 5 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameState.TurnCount & 0xfff));

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data1;
				this.oParent.GameState.ReplayDataLength++;
				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data2;
				this.oParent.GameState.ReplayDataLength++;
				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data3;
				this.oParent.GameState.ReplayDataLength++;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_250e_AddReplayData");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="replayID"></param>
		/// <param name="data1"></param>
		/// <param name="data2"></param>
		/// <param name="data3"></param>
		/// <param name="data4"></param>
		public void F0_1866_250e_AddReplayData(ushort replayID, byte data1, byte data2, byte data3, byte data4)
		{
			this.oCPU.Log.EnterBlock($"F0_1866_250e_AddReplayData({replayID}, {data1}, {data2}, {data3}, {data4})");

			// function body
			if (this.oParent.GameState.ReplayDataLength + 6 < 0x1000)
			{
				ushort usTemp = (ushort)((replayID << 12) | ((ushort)this.oParent.GameState.TurnCount & 0xfff));

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)((usTemp & 0xff00) >> 8);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = (byte)(usTemp & 0xff);
				this.oParent.GameState.ReplayDataLength++;

				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data1;
				this.oParent.GameState.ReplayDataLength++;
				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data2;
				this.oParent.GameState.ReplayDataLength++;
				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data3;
				this.oParent.GameState.ReplayDataLength++;
				this.oParent.GameState.ReplayData[this.oParent.GameState.ReplayDataLength] = data4;
				this.oParent.GameState.ReplayDataLength++;
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_250e_AddReplayData");
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_1866_260e()
		{
			this.oCPU.Log.EnterBlock("F0_1866_260e()");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			// Instruction address 0x1866:0x261a, size: 5
			this.oCPU.AX.Word = (ushort)(this.oParent.MSCAPI.RNG.Next(2));

			this.oCPU.CX.Low = 0x5;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xc0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x78);

			// Instruction address 0x1866:0x2649, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				0x78, 8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			// Instruction address 0x1866:0x2670, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 8),
				0x78, 8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x138, 0);

			// Instruction address 0x1866:0x2698, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 0x18),
				0x78, 8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x138, 0xc0);

			// Instruction address 0x1866:0x26bf, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 0x10),
				0x78, 8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0xc0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L26cc:
			// Instruction address 0x1866:0x26f2, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 0x18),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 8),
				8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) << 3));

			// Instruction address 0x1866:0x2714, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 8),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 8),
				8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x138, (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) << 3));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x18);
			if (this.oCPU.Flags.L) goto L26cc;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L272a:
			// Instruction address 0x1866:0x274c, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 8),
				8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) << 3), 0);

			// Instruction address 0x1866:0x276e, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) + 0x10),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) + 8),
				8, 8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) << 3), 0xc0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x27);
			if (this.oCPU.Flags.L) goto L272a;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("F0_1866_260e");
		}
	}
}
