using System;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Segment_29f3
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Segment_29f3(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_29f3_000e(short playerID1, short unitID1, short playerID2, short unitID2, ushort flag)
		{
			this.oCPU.Log.EnterBlock("'F0_29f3_000e'(Cdecl, Far) at 0x29f3:0x000e");

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
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0057); // stack management - push return offset
			// Instruction address 0x29f3:0x0052, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), 0x0);
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113e));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0086); // stack management - push return offset
			// Instruction address 0x29f3:0x0081, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
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
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140)));
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
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4)), 0x8);
			if (this.oCPU.Flags.E) goto L00e8;
			this.oCPU.CX.Word = 0xc;
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140)));
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
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140)));
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
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1138));
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0152;
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0x2);
			if (this.oCPU.Flags.NE) goto L0165;

		L0152:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140));
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
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x018b); // stack management - push return offset
			// Instruction address 0x29f3:0x0186, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0195;
			goto L0229;

		L0195:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x01a6); // stack management - push return offset
			// Instruction address 0x29f3:0x01a1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].BuildingFlags0, 0x80);
			if (this.oCPU.Flags.E) goto L01f2;
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113e)), 0xc);
			if (this.oCPU.Flags.E) goto L01f2;
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1138)), 0x1);
			if (this.oCPU.Flags.E) goto L01f2;
			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28f));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1140)));
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
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4)), 0x20);
			if (this.oCPU.Flags.E) goto L024b;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)), this.oCPU.AX.Word));

		L024b:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4)), 0x20);
			if (this.oCPU.Flags.E) goto L026d;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), this.oCPU.AX.Word));

		L026d:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d8));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x3);
			if (this.oCPU.Flags.GE) goto L0295;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L0295:
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
			
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x02ee); // stack management - push return offset
			// Instruction address 0x29f3:0x02eb, size: 3
			F0_29f3_0c9e(playerID2);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L030f;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81da), 0xff);
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
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81dd));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NE) goto L03b4;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81dd));
			this.oCPU.CBW(this.oCPU.AX);
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
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)this.oParent.GameState.HumanPlayerID);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x03e3); // stack management - push return offset
			// Instruction address 0x29f3:0x03de, size: 5
			this.oParent.Segment_1866.F0_1866_16a9();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x03eb); // stack management - push return offset
			// Instruction address 0x29f3:0x03e6, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x040c); // stack management - push return offset
			// Instruction address 0x29f3:0x0407, size: 5
			this.oParent.Segment_2aea.F0_2aea_03ba();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0416;
			goto L071c;

		L0416:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L043f;
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113e)), 0x4);
			if (this.oCPU.Flags.G) goto L043a;
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140)), 0x2);
			if (this.oCPU.Flags.LE) goto L045d;

		L043a:
			this.oCPU.AX.Word = 0x1;
			goto L045f;

		L043f:
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x113e)), 0x4);
			if (this.oCPU.Flags.G) goto L043a;
			this.oCPU.AX.Word = 0x22;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1140)), 0x2);
			if (this.oCPU.Flags.G) goto L043a;

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
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.E) goto L0481;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L048f;

		L0481:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L049f;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID2, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L049f;

		L048f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x0);
			if (this.oCPU.Flags.NE) goto L049a;
			this.oCPU.AX.Word = 0x26;
			goto L04ad;

		L049a:
			this.oCPU.AX.Word = 0x28;
			goto L04ad;

		L049f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x0);
			if (this.oCPU.Flags.NE) goto L04aa;
			this.oCPU.AX.Word = 0x27;
			goto L04ad;

		L04aa:
			this.oCPU.AX.Word = 0x29;

		L04ad:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x04b3); // stack management - push return offset
			// Instruction address 0x29f3:0x04ae, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord((ushort)unitID2);
			this.oCPU.PushWord((ushort)playerID2);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x04c1); // stack management - push return offset
			// Instruction address 0x29f3:0x04bc, size: 5
			this.oParent.Segment_2aea.F0_2aea_0e29();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Low);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0xff);
			if (this.oCPU.Flags.E) goto L04ec;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)playerID1);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x04e9); // stack management - push return offset
			// Instruction address 0x29f3:0x04e4, size: 5
			this.oParent.Segment_2aea.F0_2aea_0e29();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L04ec:
			// Instruction address 0x29f3:0x050a, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x50, 0, 0xf0, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0x50, 0);

			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4cc));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0532); // stack management - push return offset
			// Instruction address 0x29f3:0x052d, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CX.Low = 0x4;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x50);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd75e));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.CX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = (ushort)Math.Sign((short)this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.CX.High = 0;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
			this.oCPU.AX.Word = (ushort)Math.Sign((short)this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5)), 0x0);
			if (this.oCPU.Flags.NE) goto L05a3;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)), 0x4f);
			if (this.oCPU.Flags.E) goto L05d1;

		L05a3:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d5)), 0x4f);
			if (this.oCPU.Flags.NE) goto L05d9;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d5)), 0x0);
			if (this.oCPU.Flags.NE) goto L05d9;

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
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)(this.oCPU.SI.Word + 0x1),
				(short)(this.oCPU.DI.Word + 0x1),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt8(this.oCPU.DS.Word,
						(ushort)(((0x600 * playerID1) +
							(0xc * unitID1)) + 0x81d7)) +
						(playerID1 << 5) + 0x40) << 1) + 0xd4ce)));

			// Instruction address 0x29f3:0x062a, size: 5
			this.oParent.Segment_1182.F0_1182_0134(2);

			// Instruction address 0x29f3:0x0643, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.SI.Word, this.oCPU.DI.Word, 16, 16,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.SI.Word, this.oCPU.DI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0xa);
			if (this.oCPU.Flags.LE) goto L05de;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0675); // stack management - push return offset
			// Instruction address 0x29f3:0x0670, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0699); // stack management - push return offset
			// Instruction address 0x29f3:0x0694, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

			// Instruction address 0x29f3:0x06b4, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x100, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

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
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)(this.oCPU.SI.Word + 0x1),
				(short)(this.oCPU.DI.Word + 0x1),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) + 0x20) << 1) + 0xd4ce)));

			// Instruction address 0x29f3:0x06f2, size: 5
			this.oParent.Segment_1182.F0_1182_0134(4);

			// Instruction address 0x29f3:0x070b, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.SI.Word, this.oCPU.DI.Word, 16, 16,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.SI.Word, this.oCPU.DI.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x8);
			if (this.oCPU.Flags.L) goto L06c1;

		L071c:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0721); // stack management - push return offset
			// Instruction address 0x29f3:0x071c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

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
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x3);

			// Instruction address 0x29f3:0x0790, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_2aae);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x29f3:0x07a5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)));

			// Instruction address 0x29f3:0x07b5, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2abf);

			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x07ce); // stack management - push return offset
			// Instruction address 0x29f3:0x07c9, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			
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
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x5);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x29f3:0x0829, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x29f3:0x0839, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2ac9);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x29f3:0x084e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x29f3:0x085e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2ae4);

			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0877); // stack management - push return offset
			// Instruction address 0x29f3:0x0872, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

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

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x08f0); // stack management - push return offset
			// Instruction address 0x29f3:0x08ed, size: 3
			F0_29f3_0d4d(playerID1,
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
				this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L08f3:
			this.oCPU.AX.Word = 0x1;
			goto L0b60;

		L08f9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0x0);
			if (this.oCPU.Flags.NE) goto L0902;
			goto L0b1b;

		L0902:
			this.oCPU.CMPWord((ushort)playerID2, 0x0);
			if (this.oCPU.Flags.NE) goto L0953;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0x1a);
			if (this.oCPU.Flags.NE) goto L0953;

			this.oParent.GameState.Players[playerID1].Coins += 100;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID1, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0953;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x2ae7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x093f); // stack management - push return offset
			// Instruction address 0x29f3:0x093a, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0950); // stack management - push return offset
			// Instruction address 0x29f3:0x094b, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L0953:
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
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x097d); // stack management - push return offset
			// Instruction address 0x29f3:0x0978, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x20);
			if (this.oCPU.Flags.E) goto L0987;
			goto L0a24;

		L0987:
			this.oCPU.AX.Word = 0x2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)unitID2);
			this.oCPU.PushWord((ushort)playerID2);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0996); // stack management - push return offset
			// Instruction address 0x29f3:0x0991, size: 5
			this.oParent.Segment_1866.F0_1866_1251();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.AX.Word);

			this.oCPU.DI.Word = (ushort)playerID1;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID2;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID1].UnitsDestroyed[playerID2] += (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xf10;
			this.oCPU.DX.Word = 0x1866;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)unitID2);
			this.oCPU.PushWord((ushort)playerID2);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x09bf); // stack management - push return offset
			// Instruction address 0x29f3:0x09ba, size: 5
			this.oParent.Segment_1866.F0_1866_144b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
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
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2aef);

			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0a1e); // stack management - push return offset
			// Instruction address 0x29f3:0x0a19, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
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
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de)), 0xff);
			if (this.oCPU.Flags.E) goto L0a47;
			goto L0ad2;

		L0a47:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x8);

		L0a4c:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID2);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID2);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d5));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0a84); // stack management - push return offset
			// Instruction address 0x29f3:0x0a7f, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0aaf;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0aaf;
			this.oCPU.AX.Word = 0x1593;
			this.oCPU.DX.Word = 0x1866;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0aac); // stack management - push return offset
			// Instruction address 0x29f3:0x0aa7, size: 5
			this.oParent.Segment_1866.F0_1866_144b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);

		L0aaf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			if (this.oCPU.Flags.NS) goto L0a4c;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;

			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].PlayerID == this.oParent.GameState.HumanPlayerID)
			{
				this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
				this.oCPU.PushWord(0); // stack management - push return segment, ignored
				this.oCPU.PushWord(0x0acf); // stack management - push return offset
											// Instruction address 0x29f3:0x0aca, size: 5
				this.oParent.Segment_25fb.F0_25fb_3e9c();
				this.oCPU.PopDWord(); // stack management - pop return offset and segment
				this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			}

		L0ad2:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0add); // stack management - push return offset
			// Instruction address 0x29f3:0x0ad8, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID2, unitID2);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
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
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4)), 0x20));
			goto L08f3;

		L0b1b:
			this.oCPU.SI.Word = (ushort)playerID2;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = (ushort)playerID1;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID2].UnitsDestroyed[playerID1]++;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0b36); // stack management - push return offset
			// Instruction address 0x29f3:0x0b31, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID1, unitID1);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

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
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d4)), 0x20));

		L0b5e:
			this.oCPU.AX.Word = 0;

		L0b60:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_29f3_000e'");
		}

		public void F0_29f3_0b66(ushort param1, ushort param2, ushort param3)
		{
			this.oCPU.Log.EnterBlock("'F0_29f3_0b66'(Cdecl, Far) at 0x29f3:0x0b66");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param3);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x81de);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word), 0xff);
			if (this.oCPU.Flags.NE) goto L0b9c;
			this.oCPU.AX.Low = (byte)param2;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)param3;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de), this.oCPU.AX.Low);
			goto L0bc5;

		L0b9c:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param3);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, 0x81de);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de), this.oCPU.AX.Low);
			this.oCPU.AX.Low = (byte)param2;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word, this.oCPU.AX.Low);

		L0bc5:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_29f3_0b66'");
		}

		public void F0_29f3_0bc9(ushort param1, ushort param2)
		{
			this.oCPU.Log.EnterBlock("'F0_29f3_0bc9'(Cdecl, Far) at 0x29f3:0x0bc9");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.NE) goto L0bf0;
			goto L0c99;

		L0bf0:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x81de);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, param2);
			if (this.oCPU.Flags.NE) goto L0c11;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, this.oCPU.SI.Word, 0xff);
			goto L0c84;

		L0c11:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L0c16:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x20);
			if (this.oCPU.Flags.GE) goto L0c56;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
			if (this.oCPU.Flags.E) goto L0c56;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.CMPWord(this.oCPU.AX.Word, param2);
			if (this.oCPU.Flags.NE) goto L0c16;

		L0c56:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x20);
			if (this.oCPU.Flags.GE) goto L0c84;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xffff);
			if (this.oCPU.Flags.E) goto L0c84;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de), this.oCPU.CX.Low);

		L0c84:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de), 0xff);

		L0c99:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_29f3_0bc9'");
		}

		public void F0_29f3_0c9e(short playerID)
		{
			this.oCPU.Log.EnterBlock("'F0_29f3_0c9e'(Cdecl, Far) at 0x29f3:0x0c9e");

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
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_2b02);

			// Instruction address 0x29f3:0x0cd1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)));

			// Instruction address 0x29f3:0x0ce1, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2b2a);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x5);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0cfd); // stack management - push return offset
			// Instruction address 0x29f3:0x0cf8, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
			if (this.oCPU.Flags.E) goto L0d0a;

		L0d05:
			this.oCPU.AX.Word = 0xffff;
			goto L0d4a;

		L0d0a:
			if (this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType < 4) goto L0d43;

			// Instruction address 0x29f3:0x0d1f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_2b4c);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x4);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0d3e); // stack management - push return offset
			// Instruction address 0x29f3:0x0d39, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
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
			this.oCPU.Log.ExitBlock("'F0_29f3_0c9e'");
		}

		public void F0_29f3_0d4d(short playerID, short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock("'F0_29f3_0d4d'(Cdecl, Far) at 0x29f3:0x0d4d");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0d9b;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x3);

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x29f3:0x0d6f, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

			// Instruction address 0x29f3:0x0d7f, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2b77);

			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0d98); // stack management - push return offset
			// Instruction address 0x29f3:0x0d93, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L0d9b:
			this.oParent.Overlay_22.F22_0000_0967(xPos, yPos);
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x8);

		L0dae:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)xPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0dd0); // stack management - push return offset
			// Instruction address 0x29f3:0x0dcb, size: 5
			this.oParent.Segment_2aea.F0_2aea_1458();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0de1); // stack management - push return offset
			// Instruction address 0x29f3:0x0ddc, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0e4d;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0df3); // stack management - push return offset
			// Instruction address 0x29f3:0x0dee, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].BuildingFlags1, 0x1);
			if (this.oCPU.Flags.E) goto L0e4d;

			// Instruction address 0x29f3:0x0e11, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_2b8e);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0e21); // stack management - push return offset
			// Instruction address 0x29f3:0x0e1c, size: 5
			this.oParent.Segment_2459.F0_2459_08c6(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x29f3:0x0e2c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2b9c);

			this.oCPU.AX.Word = 0x64;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0e45); // stack management - push return offset
			// Instruction address 0x29f3:0x0e40, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0xffff);

		L0e4d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0xffff);
			if (this.oCPU.Flags.E) goto L0ea9;
			this.oCPU.AX.Word = 0x2;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0e63); // stack management - push return offset
			// Instruction address 0x29f3:0x0e5e, size: 5
			this.oParent.Segment_1866.F0_1866_1251();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0);
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			this.oParent.GameState.Players[playerID].UnitsDestroyed[this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0)] += (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = 0xf10;
			this.oCPU.DX.Word = 0x1866;
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd7f0));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0e8e); // stack management - push return offset
			// Instruction address 0x29f3:0x0e89, size: 5
			this.oParent.Segment_1866.F0_1866_144b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
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
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0ebb); // stack management - push return offset
			// Instruction address 0x29f3:0x0eb8, size: 3
			F0_29f3_0ec3(xPos, yPos);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_29f3_0d4d'");
		}

		public void F0_29f3_0ec3(short xPos, short yPos)
		{
			this.oCPU.Log.EnterBlock("'F0_29f3_0ec3'(Cdecl, Far) at 0x29f3:0x0ec3");

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
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0eec); // stack management - push return offset
			// Instruction address 0x29f3:0x0ee7, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
			if (this.oCPU.Flags.E) goto L0f02;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0eff); // stack management - push return offset
			// Instruction address 0x29f3:0x0efa, size: 5
			this.oParent.Segment_1d12.F0_1d12_6d33();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);

		L0f02:
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0f0d); // stack management - push return offset
			// Instruction address 0x29f3:0x0f08, size: 5
			this.oParent.Segment_2aea.F0_2aea_11d4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0f13:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x8);
			if (this.oCPU.Flags.G) goto L0f73;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)xPos);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0f2b); // stack management - push return offset
			// Instruction address 0x29f3:0x0f26, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, (ushort)yPos);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0f44); // stack management - push return offset
			// Instruction address 0x29f3:0x0f3f, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.E) goto L0ed1;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0f56); // stack management - push return offset
			// Instruction address 0x29f3:0x0f51, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
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
			this.oCPU.Log.ExitBlock("'F0_29f3_0ec3'");
		}
	}
}
