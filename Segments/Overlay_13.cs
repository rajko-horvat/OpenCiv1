using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class Overlay_13
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Overlay_13(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F13_0000_0000(short playerID)
		{
			this.oCPU.Log.EnterBlock("'F13_0000_0000'(Cdecl, Far) at 0x0000:0x0000");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x000c); // stack management - push return offset
			// Instruction address 0x0000:0x0007, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x0024, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x0040, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 1);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x005d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)),
				128, 4, 15);

			// Instruction address 0x0000:0x0078, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0x10,
				0x4,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((((playerID << 5) + 0x40) << 1) + 0xd4ce)));

			// Instruction address 0x0000:0x0088, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4684);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[playerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x009e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1966)));

			// Instruction address 0x0000:0x00b6, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, 24, 15);

			// Instruction address 0x0000:0x00c6, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4691);

			this.oCPU.PushWord((ushort)playerID);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x00d6); // stack management - push return offset
			// Instruction address 0x0000:0x00d1, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_02cd();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x00e9, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, 32, 15);

			// Instruction address 0x0000:0x00f9, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_469e);

			// Instruction address 0x0000:0x011a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].Coins, 10));

			// Instruction address 0x0000:0x012a, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_46aa);

			// Instruction address 0x0000:0x014b, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].TaxRate, 10));

			// Instruction address 0x0000:0x015b, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_46bc);

			// Instruction address 0x0000:0x017c, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].ScienceTaxRate, 10));

			// Instruction address 0x0000:0x0194, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 16, 40, 15);

			// Instruction address 0x0000:0x01ac, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x46be, 16, 50, 15);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x01d2, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].UnitCount, 10));

			// Instruction address 0x0000:0x01e2, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_46da);

			// Instruction address 0x0000:0x0203, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].CityCount, 10));

			// Instruction address 0x0000:0x0213, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_46dc);

			// Instruction address 0x0000:0x0234, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].SettlerCount, 10));

			// Instruction address 0x0000:0x0244, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_46de);

			// Instruction address 0x0000:0x0265, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].LandCount, 10));

			// Instruction address 0x0000:0x0275, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_46e0);

			// Instruction address 0x0000:0x028d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 192, 48, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L029f:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x5;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Attack == 0)
				goto L0379;

			// Instruction address 0x0000:0x02bd, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_46e2);

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Strategy == 2)
			{
				// Instruction address 0x0000:0x02e0, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_46e9);
			}

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Strategy == 1)
			{
				// Instruction address 0x0000:0x0303, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_46f0);
			}

			if (this.oParent.GameState.Players[playerID].Continents[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Strategy == 5)
			{
				// Instruction address 0x0000:0x0326, size: 5
				this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_46f7);
			}
		
			// Instruction address 0x0000:0x0336, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4701);

			// Instruction address 0x0000:0x0356, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 10));

			// Instruction address 0x0000:0x036d, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 256, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8));

		L0379:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0xf);
			if (this.oCPU.Flags.GE) goto L0385;
			goto L029f;

		L0385:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x18);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);
			goto L03f5;

		L0391:
			this.oCPU.AX.Word = 0x4716;

		L0394:
			// Instruction address 0x0000:0x0399, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

		L03a1:
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 8) != 0)
			{
				// Instruction address 0x0000:0x03bc, size: 5
				this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_471e);
			}

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 0xb) == 0)
				goto L03f2;

			// Instruction address 0x0000:0x03e6, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06, 192, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 7);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8));

		L03f2:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L03f5:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.GE) goto L0464;
			this.oCPU.AX.Word = (ushort)playerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L03f2;

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			// Instruction address 0x0000:0x0410, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));

			this.oCPU.BX.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, this.oCPU.CX.Low);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 0xb) == 0x1)
			{
				// Instruction address 0x0000:0x0431, size: 5
				this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4703);
			}
		
			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.CX.Low = 0x4;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, this.oCPU.CX.Low);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 2) == 0)
				goto L03a1;

			if ((this.oParent.GameState.Players[playerID].Diplomacy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))] & 4) == 0)
				goto L0391;

			this.oCPU.AX.Word = 0x470d;
			goto L0394;

		L0464:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x38);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x0);

			// Instruction address 0x0000:0x047e, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x4729, 16, 56, 15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L04d6;

		L0491:
			this.oCPU.AX.Word = 0x7;

		L0494:
			// Instruction address 0x0000:0x04b0, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				((this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) % 3) * 100) + 8,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)),
				this.oCPU.AX.Word);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa))));
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x3;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L04cc;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8));

		L04cc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0xc0);
			if (this.oCPU.Flags.G) goto L0525;

		L04d3:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L04d6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x48);
			if (this.oCPU.Flags.GE) goto L0525;

			// Instruction address 0x0000:0x04e2, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L04d3;

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x04fc, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.AX.Low = (byte)this.oParent.GameState.TechnologyFirstDiscoveredBy[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))];
			this.oCPU.AX.High = 0;
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
			if (this.oCPU.Flags.E) goto L051f;
			goto L0491;

		L051f:
			this.oCPU.AX.Word = 0xf;
			goto L0494;

		L0525:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x052a); // stack management - push return offset
			// Instruction address 0x0000:0x0525, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x0542, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x054f); // stack management - push return offset
			// Instruction address 0x0000:0x054a, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F13_0000_0000'");
		}

		public void F13_0000_0554()
		{
			this.oCPU.Log.EnterBlock("'F13_0000_0554'(Cdecl, Far) at 0x0000:0x0554");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xe);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0560); // stack management - push return offset
			// Instruction address 0x0000:0x055b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x0578, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xc5;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x13d;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0595); // stack management - push return offset
			// Instruction address 0x0000:0x0590, size: 5
			this.oParent.Segment_2d05.F0_2d05_096c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x12);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);

		L05a7:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x1);

		L05b1:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] != 0)
				goto L05cc;
			
			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] == 0)
				goto L05d1;

		L05cc:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L05d1:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L05b1;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0641;

			// Instruction address 0x0000:0x05f2, size: 5
			this.oParent.VGADriver.F0_VGA_0599_DrawLine(
				new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa))),
				(short)0x24,
				(short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) - 1),
				(short)0x13f,
				(short)((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) - 1),
				9);

			// Instruction address 0x0000:0x0618, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe)) & 1) << 4) + 2),
				(short)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)) - 4),
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) + 0x60) << 1) + 0xd4ce)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe))));

			// Instruction address 0x0000:0x0635, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(
				(ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)) * 0x22) + 0x112a),
				36, 
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 
				15);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));

		L0641:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x1c);
			if (this.oCPU.Flags.GE) goto L064d;
			goto L05a7;

		L064d:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L0657;

		L0654:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L0657:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x5);
			if (this.oCPU.Flags.L) goto L0654;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L075e;

		L0665:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L0668:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x1c);
			if (this.oCPU.Flags.L) goto L0671;
			goto L075b;

		L0671:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L067b:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			
			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] != 0)
				goto L0696;

			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] == 0)
				goto L069b;

		L0696:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L069b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L067b;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.E) goto L0665;
			
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			
			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] != 0)
				goto L06c8;
			
			if (this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))] != 0)
				goto L06c8;

			goto L0754;

		L06c8:
			// Instruction address 0x0000:0x06d0, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_4737);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = 0x38;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

			// Instruction address 0x0000:0x06fe, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].ActiveUnits[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))], 10));

			// Instruction address 0x0000:0x070e, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_4738);

			// Instruction address 0x0000:0x072f, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].UnitsInProduction[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))], 10));

			// Instruction address 0x0000:0x074c, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) * 30) + 88,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)),
				15);

		L0754:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8));
			goto L0665;

		L075b:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L075e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x8);
			if (this.oCPU.Flags.L) goto L0767;
			goto L07f7;

		L0767:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x078a, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].Ranking, 10));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.E) goto L07b7;

			// Instruction address 0x0000:0x07af, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) * 30) + 84,
				1,
				15);

		L07b7:
			// Instruction address 0x0000:0x07d0, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)((0x1e * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))) + 0x5a),
				2,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)) << 5) + 0x40) << 1) + 0xd4ce)));

			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L07ea;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L07ea;
			goto L075b;

		L07ea:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), 0x12);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), 0x0);
			goto L0668;

		L07f7:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x07fc); // stack management - push return offset
			// Instruction address 0x0000:0x07f7, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x0814, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0821); // stack management - push return offset
			// Instruction address 0x0000:0x081c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			F13_0000_082a();

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F13_0000_0554'");
		}

		public void F13_0000_082a()
		{
			this.oCPU.Log.EnterBlock("'F13_0000_082a'(Cdecl, Far) at 0x0000:0x082a");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0837); // stack management - push return offset
			// Instruction address 0x0000:0x0832, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x0850, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 4);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);

		L085d:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			this.oCPU.AX.Word = 0x28;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.DI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x0877, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawTextWithShadow(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) * 40,
				8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1946)));

			// Instruction address 0x0000:0x088f, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(short)this.oCPU.DI.Word,
				0x10,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word,
					(ushort)((((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) << 5) + 0x40) << 1) + 0xd4ce)));

			// Instruction address 0x0000:0x08ad, size: 5
			this.oParent.Segment_1182.F0_1182_0086_DrawTextWithShadow(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)),
				4,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) * 12 + 32,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1946)));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.L) goto L085d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
			goto L0984;

		L08c6:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));

		L08c9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.L) goto L08d2;
			goto L0981;

		L08d2:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L08c6;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
			if (this.oCPU.Flags.NE) goto L08ee;
			this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L08ee;
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L08c6;

		L08ee:
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0918, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(
					this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].UnitsDestroyed[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))],
					10));

			// Instruction address 0x0000:0x0928, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_473a);

			this.oCPU.SI.Word = (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) << 1);

			// Instruction address 0x0000:0x0955, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(
					this.oParent.GameState.Players[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))].UnitsDestroyed[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))],
					10));

			// Instruction address 0x0000:0x0976, size: 5
			this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0xba06,
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)) * 40,
				(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)) * 12) + 32,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1946)));

			goto L08c6;

		L0981:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

		L0984:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x8);
			if (this.oCPU.Flags.GE) goto L0992;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);
			goto L08c9;

		L0992:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0997); // stack management - push return offset
			// Instruction address 0x0000:0x0992, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x09a1); // stack management - push return offset
			// Instruction address 0x0000:0x099c, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F13_0000_082a'");
		}
	}
}
