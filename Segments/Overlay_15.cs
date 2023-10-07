using Disassembler;

namespace OpenCiv1
{
	public class Overlay_15
	{
		private OpenCiv1 oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

		public Overlay_15(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F15_0000_0000(short playerID)
		{
			this.oCPU.Log.EnterBlock("'F15_0000_0000'(Cdecl, Far) at 0x0000:0x0000");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x48);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x1);
			goto L0017;

		L0014:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0017:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x8);
			if (this.oCPU.Flags.GE) goto L0036;

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].UnitCount != 0) goto L0014;

			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].CityCount, 0x0);
			if (this.oCPU.Flags.NE) goto L0014;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);

		L0036:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0xffff);
			if (this.oCPU.Flags.NE) goto L003f;
			goto L0100;

		L003f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);

		L0044:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x10);
			if (this.oCPU.Flags.L) goto L0044;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);

		L0061:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L00ed;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].PlayerID != playerID) goto L00ed;
			
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y);
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x008b); // stack management - push return offset
			// Instruction address 0x0000:0x0086, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x44), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x44)), this.oCPU.AX.Word));
			this.oCPU.TESTWord(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].BuildingFlags0, 0x1);
			if (this.oCPU.Flags.E) goto L00ed;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.E) goto L00b8;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X;
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Players[playerID].XStart, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L00ed;

		L00b8:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y);
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x00d1); // stack management - push return offset
			// Instruction address 0x0000:0x00cc, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Word);
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

		L00ed:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x80);
			if (this.oCPU.Flags.GE) goto L00fa;
			goto L0061;

		L00fa:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)), 0xffff);
			if (this.oCPU.Flags.NE) goto L0105;

		L0100:
			this.oCPU.AX.Word = 0;
			goto L0879;

		L0105:
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.AIOpponentCount;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0113;
			this.oCPU.AX.Word = 0x1;
			goto L0115;

		L0113:
			this.oCPU.AX.Word = 0;

		L0115:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			oParent.GameState.ActiveCivilizations &= (short)this.oCPU.AX.Word;

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x012e); // stack management - push return offset
			this.oParent.Overlay_5.F5_0000_07c7(this.oCPU.Memory.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0100;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			oParent.GameState.ActiveCivilizations |= (short)this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x0);
			if (this.oCPU.Flags.NE) goto L0166;
			this.oCPU.SI.Word = (ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].LeaderGraphics;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)), 0x7);
			if (this.oCPU.Flags.E) goto L015b;
			this.oCPU.AX.Word = 0x1;
			goto L015d;

		L015b:
			this.oCPU.AX.Word = 0;

		L015d:
			this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			if (this.oCPU.Flags.NE) goto L0166;
			this.oCPU.CMPWord(this.oCPU.SI.Word, 0xf);
			if (this.oCPU.Flags.LE) goto L019f;

		L0166:
			// Instruction address 0x0000:0x0173, size: 5
			if (this.oParent.MSCAPI.RNG.Next(2) != 0)
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			}
			else
			{
				this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
				this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x8);
			}
		
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].LeaderGraphics = (short)this.oCPU.AX.Word;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L01a9;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oParent.GameState.CivilizationIdentityFlags |= (short)this.oCPU.AX.Word;
			goto L01a9;

		L019f:
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].LeaderGraphics ^= 8;

		L01a9:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].LeaderGraphics);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14e2);
			// Instruction address 0x0000:0x01bd, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x19a2)),
				this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].LeaderGraphics);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1502);
			// Instruction address 0x0000:0x01d4, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)),
				this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].LeaderGraphics);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x14f2);
			// Instruction address 0x0000:0x01eb, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), 0x0);
			if (this.oCPU.Flags.NE) goto L021a;

			// Instruction address 0x0000:0x0202, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));

			// Instruction address 0x0000:0x0212, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4a16);

		L021a:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x0227, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1992)), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			this.oCPU.DI.Word = (ushort)playerID;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			// Instruction address 0x0000:0x0241, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8), 
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x1982)));

			// Instruction address 0x0000:0x0251, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30ba),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));

			if (playerID == this.oParent.GameState.HumanPlayerID)
			{
				this.oCPU.AX.Word = 0x4a18;
			}
			else
			{
				this.oCPU.AX.Word = 0x4a20;
			}
		
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x026f); // stack management - push return offset
			// Instruction address 0x0000:0x026a, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_044f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9e, 0x5);
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0286); // stack management - push return offset
			// Instruction address 0x0000:0x0281, size: 5
			this.oParent.Segment_1238.F0_1238_001e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].Coins;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].Coins = (short)this.oCPU.AX.Word;
			this.oParent.GameState.Players[playerID].Coins -= (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[playerID].MilitaryPower;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].MilitaryPower = (short)this.oCPU.AX.Word;

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].ResearchProgress = 
				this.oParent.GameState.Players[playerID].ResearchProgress;

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].DiscoveredTechnologyCount =
				this.oParent.GameState.Players[playerID].DiscoveredTechnologyCount;

			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].GovernmentType =
				this.oParent.GameState.Players[playerID].GovernmentType;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);

		L02c4:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xe3c8));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xa;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xe3c8), this.oCPU.CX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x5);
			if (this.oCPU.Flags.L) goto L02c4;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = (ushort)oParent.GameState.TurnCount;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x8);
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].ContactPlayerCountdown = 
				(short)this.oCPU.AX.Word;
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xe498),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xe498)), 0x1));
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, this.oCPU.CX.Low);
			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0xe498),
				this.oCPU.ORByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0xe498)), 0x9));
			this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0343;

		L032d:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.BP.Word);
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, 0x44);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word, 0x2);

		L0340:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0343:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x10);
			if (this.oCPU.Flags.GE) goto L0383;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44)), 0x0);
			if (this.oCPU.Flags.E) goto L0340;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L0364;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L032d;

		L0364:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0377;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)), this.oCPU.AX.Word));

		L0377:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x44), 0x1);
			goto L0340;

		L0383:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e)));
			if (this.oCPU.Flags.LE) goto L03f5;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1e));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.G) goto L03f5;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L039f;

		L039c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L039f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x80);
			if (this.oCPU.Flags.L) goto L03a9;
			goto L0498;

		L03a9:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L039c;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].PlayerID != playerID) goto L039c;

			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y);
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03d3); // stack management - push return offset
			// Instruction address 0x0000:0x03ce, size: 5
			this.oParent.Segment_2aea.F0_2aea_1942();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x44)), 0x2);
			if (this.oCPU.Flags.NE) goto L039c;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PushWord((ushort)playerID);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x03f0); // stack management - push return offset
			F15_0000_087f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			goto L039c;

		L03f5:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x0);
			goto L047a;

		L03fc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);

		L0406:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L0450;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].PlayerID != playerID) goto L0450;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.Y;
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)));
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))].Position.X;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0436); // stack management - push return offset
			// Instruction address 0x0000:0x0431, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L0450;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

		L0450:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x80);
			if (this.oCPU.Flags.L) goto L0406;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), this.oCPU.AX.Word));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PushWord((ushort)playerID);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0477); // stack management - push return offset
			F15_0000_087f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L047a:
			this.oCPU.AX.Word = 0x9;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc6a);
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x3);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)this.oParent.GameState.Players[playerID].TotalCitySize);
			if (this.oCPU.Flags.GE) goto L0498;
			goto L03fc;

		L0498:
			this.oParent.GameState.Players[playerID].TotalCitySize +=
				this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].TotalCitySize;

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
			goto L0720;

		L04b2:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID, 
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			if (this.oCPU.Flags.E) goto L04c7;
			goto L071d;

		L04c7:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04d2); // stack management - push return offset
			// Instruction address 0x0000:0x04cd, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.Memory.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x04f6); // stack management - push return offset
			// Instruction address 0x0000:0x04f1, size: 5
			this.oParent.Segment_2aea.F0_2aea_1511();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0510); // stack management - push return offset
			// Instruction address 0x0000:0x050b, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfe);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x81d4), this.oCPU.AX.Low);
			goto L071d;

		L0533:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x1c;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df))].PlayerID;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0566;
			goto L0717;

		L0566:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0571); // stack management - push return offset
			// Instruction address 0x0000:0x056c, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.Memory.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0588); // stack management - push return offset
			// Instruction address 0x0000:0x0583, size: 5
			this.oParent.Segment_2aea.F0_2aea_138c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x059c); // stack management - push return offset
			// Instruction address 0x0000:0x0597, size: 5
			this.oParent.Segment_2aea.F0_2aea_1511();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x05b6); // stack management - push return offset
			// Instruction address 0x0000:0x05b1, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d4));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfe);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d4), this.oCPU.AX.Low);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81df), this.oCPU.AX.Low);

		L05de:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L05e7;
			goto L071d;

		L05e7:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L05f2;
			goto L071d;

		L05f2:
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x061f); // stack management - push return offset
			// Instruction address 0x0000:0x061a, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.Memory.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0643); // stack management - push return offset
			// Instruction address 0x0000:0x063e, size: 5
			this.oParent.Segment_2aea.F0_2aea_138c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xffff);
			if (this.oCPU.Flags.E) goto L06c4;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0660); // stack management - push return offset
			// Instruction address 0x0000:0x065b, size: 5
			this.oParent.Segment_2aea.F0_2aea_1511();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x067d); // stack management - push return offset
			// Instruction address 0x0000:0x0678, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));
			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.CX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d4));
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfe);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81d4), this.oCPU.AX.Low);
			this.oCPU.AX.Low = 0x1c;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81df)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.CMPWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81df))].PlayerID,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			if (this.oCPU.Flags.E) goto L06c4;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81df));
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x81df), this.oCPU.AX.Low);

		L06c4:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);
			goto L05de;

		L06cd:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L071d;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.SI.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81de));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), this.oCPU.AX.Word);
			this.oCPU.AX.Low = 0x1c;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81df)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81df))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)));
			if (this.oCPU.Flags.E) goto L0711;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81df));
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x81df), this.oCPU.AX.Low);

		L0711:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.AX.Word);

		L0717:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L06cd;

		L071d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

		L0720:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x80);
			if (this.oCPU.Flags.L) goto L072a;
			goto L07f5;

		L072a:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0xff);
			if (this.oCPU.Flags.E) goto L071d;
			this.oCPU.AX.Word = 0x600;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0xc;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x076a); // stack management - push return offset
			// Instruction address 0x0000:0x0765, size: 5
			this.oParent.Segment_2aea.F0_2aea_1585();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.TESTByte(this.oCPU.AX.Low, 0x1);
			if (this.oCPU.Flags.NE) goto L0774;
			goto L0533;

		L0774:
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0785); // stack management - push return offset
			// Instruction address 0x0000:0x0780, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_00ba();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = 0x1c;
			this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df)));
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			if (this.oParent.GameState.Cities[this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81df))].PlayerID !=
				this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].PlayerID) goto L07b2;
			goto L04b2;

		L07b2:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07bd); // stack management - push return offset
			// Instruction address 0x0000:0x07b8, size: 5
			this.oParent.Segment_1866.F0_1866_0f10(playerID, this.oCPU.Memory.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07d1); // stack management - push return offset
			// Instruction address 0x0000:0x07cc, size: 5
			this.oParent.Segment_2aea.F0_2aea_1511();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
			this.oCPU.AX.High = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07ec); // stack management - push return offset
			// Instruction address 0x0000:0x07e7, size: 5
			this.oParent.Segment_1866.F0_1866_0cf5();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			goto L071d;

		L07f5:
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)));

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x07fc); // stack management - push return offset
			F15_0000_08ba();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].BuildingFlags0 |= 1;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].Position.X;
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16))].XStart = (short)this.oCPU.AX.Word;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord((ushort)playerID, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0839;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd75e));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4cc));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0834); // stack management - push return offset
			// Instruction address 0x0000:0x082f, size: 5
			this.oParent.Segment_2aea.F0_2aea_0008();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			goto L0876;

		L0839:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].PlayerID = -1;
			this.oCPU.PushWord((ushort)playerID);

			// Call to overlay
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x084f); // stack management - push return offset
			F15_0000_08ba();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].BuildingFlags0 |= 1;

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10))].Position.X;
			this.oParent.GameState.Players[playerID].XStart = (short)this.oCPU.AX.Word;

			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].PlayerID = playerID;

		L0876:
			this.oCPU.AX.Word = 0x1;

		L0879:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F15_0000_0000'");
		}

		public void F15_0000_087f()
		{
			this.oCPU.Log.EnterBlock("'F15_0000_087f'(Cdecl, Far) at 0x0000:0x087f");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))].PlayerID = (sbyte)this.oCPU.AX.Low;

			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))].Position.Y);
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))].Position.X);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x08a6); // stack management - push return offset
										// Instruction address 0x0000:0x08a1, size: 5
			this.oParent.Segment_2aea.F0_2aea_138c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Low = (byte)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))].ActualSize;
			this.oCPU.CBW(this.oCPU.AX);
			this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa))].TotalCitySize += (short)this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F15_0000_087f'");
		}

		public void F15_0000_08ba()
		{
			this.oCPU.Log.EnterBlock("'F15_0000_08ba'(Cdecl, Far) at 0x0000:0x08ba");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0xffff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x7fff);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);
			goto L094c;

		L08d3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L0913;

		L08df:
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.Y);
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.Y);
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].Position.X);
			this.oCPU.PushWord((ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].Position.X);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x090a); // stack management - push return offset
			// Instruction address 0x0000:0x0905, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0289();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = this.usSegment; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));

		L0910:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L0913:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x80);
			if (this.oCPU.Flags.GE) goto L0935;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			if (this.oCPU.Flags.NE) goto L0910;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))].StatusFlag, 0xff);
			if (this.oCPU.Flags.NE) goto L08df;
			goto L0910;

		L0935:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L0949;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);

		L0949:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L094c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x80);
			if (this.oCPU.Flags.GE) goto L0971;
			this.oCPU.AX.Word = 0x1c;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].PlayerID;
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			if (this.oCPU.Flags.NE) goto L0949;
			this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].StatusFlag, 0xff);
			if (this.oCPU.Flags.E) goto L096f;
			goto L08d3;

		L096f:
			goto L0949;

		L0971:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F15_0000_08ba'");
		}
	}
}
