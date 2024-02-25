using IRB.VirtualCPU;

namespace OpenCiv1
{
    public class Help
    {
        private OpenCiv1 oParent;
        private CPU oCPU;

        public Help(OpenCiv1 parent)
        {
            this.oParent = parent;
            this.oCPU = parent.CPU;
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="stringPtr"></param>
        public void F4_0000_0000(ushort stringPtr)
        {
            this.oCPU.Log.EnterBlock($"F4_0000_0000(0x{stringPtr:x4})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x18);

            // Instruction address 0x0000:0x000e, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x18), "*");

            // Instruction address 0x0000:0x0019, size: 5
            this.oParent.MSCAPI.strupr(stringPtr);

            // Instruction address 0x0000:0x0026, size: 5
            this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);

            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x003b, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_01ad(0x34b2, (ushort)(this.oCPU.BP.Word - 0x18));

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L00a5;

            // Instruction address 0x0000:0x0047, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0);

            // Instruction address 0x0000:0x0065, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 2);

            // Instruction address 0x0000:0x007c, size: 5
            this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0((ushort)(this.oCPU.BP.Word - 0x18), 160, 192, 0);

            // Instruction address 0x0000:0x008e, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(32, 32, 32, 15);

            // Instruction address 0x0000:0x0096, size: 5
            this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x0000:0x00a0, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

        L00a5:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9c, 0x0);
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F4_0000_0000");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="param2"></param>
        public void F4_0000_00af(short playerID, ushort param2)
        {
            this.oCPU.Log.EnterBlock($"F4_0000_00af({playerID}, {param2})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
            this.oCPU.PushWord(this.oCPU.DI.Word);
            this.oCPU.PushWord(this.oCPU.SI.Word);
            this.oCPU.CMPWord(param2, 0x80);
            if (this.oCPU.Flags.L) goto L00c1;
            goto L02cd;

        L00c1:
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

            // Instruction address 0x0000:0x00dd, size: 5
            this.oParent.Segment_2aea.F0_2aea_134a(
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
            this.oCPU.AX.Word = 0x13;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
            this.oCPU.DI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x291));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.CX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0x290));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.CX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.L) goto L0108;
            this.oCPU.AX.Word = 0x1;
            goto L010a;

        L0108:
            this.oCPU.AX.Word = 0;

        L010a:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

            // Instruction address 0x0000:0x0120, size: 5
            this.oParent.VGADriver.F0_VGA_038c_GetPixel(2,
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)) + 80,
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xa);
            if (this.oCPU.Flags.GE) goto L0135;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

        L0135:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x1);

        L013a:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.DI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
            this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);

            // Instruction address 0x0000:0x016c, size: 5
            this.oParent.VGADriver.F0_VGA_038c_GetPixel(2,
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(0x81d5 + this.oCPU.DI.Word)) +
                    this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(0x1882 + this.oCPU.SI.Word)) + 80,
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(0x81d6 + this.oCPU.DI.Word)) +
                    this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)));

            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
            if (this.oCPU.Flags.LE) goto L017e;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

        L017e:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)), 0x8);
            if (this.oCPU.Flags.LE) goto L013a;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
            if (this.oCPU.Flags.E) goto L01c3;
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

            // Instruction address 0x0000:0x01b5, size: 5
            this.oParent.Segment_2aea.F0_2aea_0008(this.oParent.GameState.HumanPlayerID,
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)) - 7,
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)) - 6);

            F4_0000_02d3(0x34bb);

            goto L02cd;

        L01c3:
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

            // Instruction address 0x0000:0x01df, size: 5
            this.oParent.Segment_2dc4.F0_2dc4_0102(
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.NE) goto L01f2;
            goto L02cd;

        L01f2:
            this.oCPU.AX.Word = 0x1c;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = (ushort)this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))].PlayerID;
            this.oCPU.CMPWord(this.oCPU.AX.Word, (ushort)playerID);
            if (this.oCPU.Flags.E) goto L0207;
            goto L02cd;

        L0207:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6c9a), 0x1);
            if (this.oCPU.Flags.E) goto L0211;
            goto L02cd;

        L0211:
            // Instruction address 0x0000:0x021d, size: 5
            this.oParent.Segment_2aea.F0_2aea_1585(
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x0230, size: 5
            this.oParent.Segment_2459.F0_2459_08c6_GetCityName(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));

            // Instruction address 0x0000:0x0240, size: 5
            this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8), 0xba06);

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x4);
            if (this.oCPU.Flags.NE) goto L025f;
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x6);
            if (this.oCPU.Flags.NE) goto L025f;

            F4_0000_02d3(0x34c6);

        L025f:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0x1);
            if (this.oCPU.Flags.NE) goto L0298;
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param2);
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);

            // Instruction address 0x0000:0x0281, size: 5
            this.oParent.Segment_1403.F0_1403_3fd0(
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5)),
                this.oCPU.ReadInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6)));

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0298;
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x6);
            if (this.oCPU.Flags.NE) goto L0298;

            F4_0000_02d3(0x34ce);

            goto L02cd;

        L0298:
            this.oCPU.AX.Word = 0x13;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x28e)), 0x1);
            if (this.oCPU.Flags.NE) goto L02cd;
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)), 0x8);
            if (this.oCPU.Flags.NE) goto L02cd;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)), 0xb);
            if (this.oCPU.Flags.E) goto L02cd;
            this.oCPU.AX.Word = 0x38;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.BX.Word = this.oCPU.AX.Word;

            if (this.oParent.GameState.Players[playerID].ActiveUnits[0] >= 2)
                goto L02cd;

            F4_0000_02d3(0x34d8);

        L02cd:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.DI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F4_0000_00af");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="stringPtr"></param>
        public void F4_0000_02d3(ushort stringPtr)
        {
            this.oCPU.Log.EnterBlock($"F4_0000_02d3(0x{stringPtr:x4})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
            this.oCPU.PushWord(this.oCPU.SI.Word);

            this.oCPU.TESTByte((byte)(this.oParent.GameState.GameSettingFlags & 0xff), 0x1);
            if (this.oCPU.Flags.NE) goto L02e4;
            goto L03a5;

        L02e4:
            if (this.oParent.GameState.Year < 0) goto L02ee;
            goto L03a5;

        L02ee:
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x02fa, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_01ad(0x34de, stringPtr);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

            // Instruction address 0x0000:0x0305, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_0471();

            // Instruction address 0x0000:0x030a, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0);

            this.oCPU.AX.Word = 0x6;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0xa);

            // Instruction address 0x0000:0x0334, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 56, 16, 208, (short)this.oCPU.SI.Word, 2);

            // Instruction address 0x0000:0x034d, size: 5
            this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(56, 16, 208, (short)this.oCPU.SI.Word, 10);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x2);

            // Instruction address 0x0000:0x036d, size: 5
            this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x34e7, 160, 19, 0);

            // Instruction address 0x0000:0x0385, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(32, 64, 25, 15);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);

            // Instruction address 0x0000:0x0396, size: 5
            this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x0000:0x03a0, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

        L03a5:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();

            // Far return
            this.oCPU.Log.ExitBlock("F4_0000_02d3");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="stringPtr"></param>
        public void F4_0000_03aa(ushort stringPtr)
        {
            this.oCPU.Log.EnterBlock($"F4_0000_03aa(0x{stringPtr:x4})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
            this.oCPU.PushWord(this.oCPU.SI.Word);
            this.oCPU.AX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b90), this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L03bd;
            goto L0474;

        L03bd:
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x03c9, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_01ad(0x3501, stringPtr);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

            // Instruction address 0x0000:0x03d4, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_0471();

            // Instruction address 0x0000:0x03d9, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0);

            this.oCPU.AX.Word = 0x6;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0xa);

            // Instruction address 0x0000:0x0403, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 56, 16, 208, (short)this.oCPU.SI.Word, 4);

            // Instruction address 0x0000:0x041c, size: 5
            this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(56, 16, 208, (short)this.oCPU.SI.Word, 12);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x2);

            // Instruction address 0x0000:0x043c, size: 5
            this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x350b, 160, 19, 0);

            // Instruction address 0x0000:0x0454, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_0088_DrawTextBlock(32, 64, 25, 15);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);

            // Instruction address 0x0000:0x0465, size: 5
            this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x0000:0x046f, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

        L0474:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F4_0000_03aa");
        }
    }
}
