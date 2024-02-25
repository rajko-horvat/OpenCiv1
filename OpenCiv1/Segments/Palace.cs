using IRB.VirtualCPU;

namespace OpenCiv1
{
    public class Palace
    {
        private OpenCiv1 oParent;
        private CPU oCPU;

        public Palace(OpenCiv1 parent)
        {
            this.oParent = parent;
            this.oCPU = parent.CPU;
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F17_0000_0000()
        {
            this.oCPU.Log.EnterBlock("F17_0000_0000()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x110);
            this.oCPU.PushWord(this.oCPU.DI.Word);
            this.oCPU.PushWord(this.oCPU.SI.Word);

            // Instruction address 0x0000:0x0009, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x0017, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_044f(0x4ade);

            // Instruction address 0x0000:0x0028, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x100), 0xba06);

            // Instruction address 0x0000:0x003a, size: 5
            this.oParent.Segment_11a8.F0_11a8_02a4(2, 1);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);

            F17_0000_07ec(0);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

            // Instruction address 0x0000:0x006d, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 0);

            // Instruction address 0x0000:0x0075, size: 5
            this.oParent.Segment_2dc4.F0_2dc4_065f();

            this.oCPU.AX.Word = 0x3a;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
                (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics);
            this.oCPU.BX.Word = this.oCPU.AX.Word;

            // Instruction address 0x0000:0x0091, size: 5
            this.oParent.Segment_1000.F0_1000_0a32(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x151a)), 3);

            // Instruction address 0x0000:0x009d, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4ae6, 1);

            // Instruction address 0x0000:0x00bd, size: 5
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x0000:0x00d2, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031((ushort)(this.oCPU.BP.Word - 0x100), 20, 16, 1);

            // Instruction address 0x0000:0x00fa, size: 5
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0x14, 0x10, 0x118, 0x2c,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0x14, 0x10);

            // Instruction address 0x0000:0x011a, size: 5
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdb38, 0x1);

            // Instruction address 0x0000:0x0134, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0x4af0, 40, 16, 1);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), 0x0);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0x1);

        L0148:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)), 0x4);
            if (this.oCPU.Flags.GE) goto L01bc;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)), 0x0);
            if (this.oCPU.Flags.G) goto L016a;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd920)), 0x0);
            if (this.oCPU.Flags.G) goto L016a;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)), 0x0);
            if (this.oCPU.Flags.L) goto L01bc;

            L016a:
            this.oCPU.AX.Word = 0x30;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)));
            this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x24);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104), this.oCPU.AX.Word);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x0196, size: 5
            this.oParent.MSCAPI.strcat(0xba06,
                this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 10));

            // Instruction address 0x0000:0x01ae, size: 5
            this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(
                0xba06,
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)),
                144,
                14);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), 0x1);

        L01bc:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108),
                this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x8);
            if (this.oCPU.Flags.L) goto L0148;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0x0);

        L01cd:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd930)), 0x3);
            if (this.oCPU.Flags.GE) goto L0217;

            // Instruction address 0x0000:0x01e2, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, "A");

            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06,
                this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba06), this.oCPU.AX.Low));

            // Instruction address 0x0000:0x0209, size: 5
            this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(
                0xba06,
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)) * 120 + 40,
                160,
                14);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), 0x1);

        L0217:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108),
                this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x3);
            if (this.oCPU.Flags.L) goto L01cd;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102)), 0x0);
            if (this.oCPU.Flags.NE) goto L022c;
            goto L0792;

        L022c:
            // Instruction address 0x0000:0x022c, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

        L0231:
            // Instruction address 0x0000:0x0231, size: 5
            this.oParent.Segment_11a8.F0_11a8_0223();

            this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
            if (this.oCPU.Flags.NE) goto L0246;

            // Instruction address 0x0000:0x023d, size: 5
            this.oParent.MSCAPI.kbhit();

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0231;

            L0246:
            // Instruction address 0x0000:0x0246, size: 5
            this.oParent.MSCAPI.kbhit();

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L02a0;
            this.oCPU.CMPWord(this.oParent.Var_db3e, 0x9a);
            if (this.oCPU.Flags.GE) goto L0292;
            this.oCPU.AX.Word = this.oParent.Var_db3c;
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xc);
            this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
            this.oCPU.CX.Word = 0x30;
            this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);

        L0264:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), this.oCPU.AX.Word);

        L0268:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd91e)), 0x4);
            if (this.oCPU.Flags.GE) goto L0231;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x9);
            if (this.oCPU.Flags.L) goto L0289;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd91e)), 0x3);
            if (this.oCPU.Flags.GE) goto L0231;

            L0289:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x9);
            if (this.oCPU.Flags.GE) goto L030e;
            goto L02e6;

        L0292:
            this.oCPU.AX.Word = this.oParent.Var_db3c;
            this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
            this.oCPU.CX.Word = 0x6b;
            this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x9);
            goto L0264;

        L02a0:
            // Instruction address 0x0000:0x02a0, size: 5
            this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x38);
            if (this.oCPU.Flags.GE) goto L02b5;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x30));
            goto L02ba;

        L02b5:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x58));

        L02ba:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x1);
            if (this.oCPU.Flags.GE) goto L02c4;
            goto L0231;

        L02c4:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0xb);
            if (this.oCPU.Flags.LE) goto L0268;
            goto L0231;

        L02ce:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd920)), 0x0);
            if (this.oCPU.Flags.G) goto L0307;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)), 0xffff);
            if (this.oCPU.Flags.NE) goto L0307;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e))));

        L02e6:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x4);
            if (this.oCPU.Flags.L) goto L02ce;
            goto L0307;

        L02ef:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)), 0x0);
            if (this.oCPU.Flags.G) goto L030e;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)), 0xffff);
            if (this.oCPU.Flags.NE) goto L030e;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e))));

        L0307:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x4);
            if (this.oCPU.Flags.G) goto L02ef;

            L030e:
            // Instruction address 0x0000:0x030e, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            // Instruction address 0x0000:0x032b, size: 5
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x0000:0x0347, size: 5
            this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange(
                this.oCPU.ReadInt16(this.oCPU.DS.Word,
                    (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word,
                        (ushort)(this.oCPU.BP.Word - 0x10e)) << 1) + 0xd91e)) + 1,
                1, 4);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x9);
            if (this.oCPU.Flags.L) goto L035d;
            goto L0747;

        L035d:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0x1);

        L0363:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Low = 0xff;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb25f), this.oCPU.AX.Low);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb25e), this.oCPU.AX.Low);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x8);
            if (this.oCPU.Flags.L) goto L0363;

            F17_0000_0cfe(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0x1);

        L0393:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
            this.oCPU.DI.Word = this.oCPU.SHLWord(this.oCPU.DI.Word, 0x1);
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb25e));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb25e), this.oCPU.AX.Low);
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb25f));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb25f), this.oCPU.AX.Low);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x3);
            if (this.oCPU.Flags.LE) goto L0393;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6828, 0xffff);

            F17_0000_0e95(
                (ushort)(1 << this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110))),
                0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), 0x5c);

            // Instruction address 0x0000:0x03fd, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 16, 2, 288, 102, 9);

            // Instruction address 0x0000:0x0415, size: 5
            this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredStringToScreen0(0x4b13, 160, 3, 15);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0x1);
            goto L0587;

        L0426:
            // Instruction address 0x0000:0x043e, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 10,
                80, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)), 1);

        L0429:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104),
                this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 0x10));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), 0x2);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x4);
            if (this.oCPU.Flags.GE) goto L0478;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), 0x1);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd91c)), 0xffff);
            if (this.oCPU.Flags.E) goto L0472;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x1);
            if (this.oCPU.Flags.NE) goto L0478;

            L0472:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), 0x0);

        L0478:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x4);
            if (this.oCPU.Flags.LE) goto L049f;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), 0x1);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd920)), 0xffff);
            if (this.oCPU.Flags.E) goto L0499;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x7);
            if (this.oCPU.Flags.NE) goto L049f;

            L0499:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), 0x3);

        L049f:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L04c1;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.NE) goto L04af;
            goto L05af;

        L04af:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.NE) goto L04b7;
            goto L0609;

        L04b7:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
            if (this.oCPU.Flags.NE) goto L04bf;
            goto L062d;

        L04bf:
            goto L053e;

        L04c1:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x1);
            if (this.oCPU.Flags.E) goto L0502;

            // Instruction address 0x0000:0x04fa, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)) + this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x4b32),
                this.oCPU.ReadInt8(this.oCPU.DS.Word,
                    (ushort)((0xf * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110))) +
                    (5 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))) + 0x4b32)) + 1,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word,
                    (ushort)(this.oCPU.BP.Word - 0x108)) << 2) + 0xb23e)));

        L0502:
            // Instruction address 0x0000:0x052f, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)),
                this.oCPU.ReadInt8(this.oCPU.DS.Word,
                (ushort)((0xf * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110))) +
                    (0x5 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))) + 0x4b34)) + 1,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word,
                    (ushort)(this.oCPU.BP.Word - 0x108)) << 2) + 0xb23c)));

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b32);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), this.oCPU.AX.Word));

        L053e:
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x055c, size: 5
            this.oParent.MSCAPI.strcat(0xba06,
                this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 10));

            // Instruction address 0x0000:0x057b, size: 5
            this.oParent.Segment_1182.F0_1182_0086_DrawStringWithShadow(
                0xba06,
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)) * 100 - 44,
                12,
                15);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108),
                this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))));

        L0587:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x3);
            if (this.oCPU.Flags.LE) goto L0591;
            goto L06ae;

        L0591:
            this.oCPU.AX.Word = 0x64;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)));
            this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x50);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
            if (this.oCPU.Flags.E) goto L05a9;
            goto L0426;

        L05a9:
            // Instruction address 0x0000:0x043e, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 10,
                80, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)), 3);

            goto L0429;

        L05af:
            // Instruction address 0x0000:0x05dc, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)),
                this.oCPU.ReadInt8(this.oCPU.DS.Word,
                    (ushort)(((0x5 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))) +
                    (0xf * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)))) + 0x4b32)) + 1,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word,
                    (ushort)(this.oCPU.BP.Word - 0x108)) << 2) + 0xb23c)));

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), this.oCPU.AX.Word));
            this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.DI.Word + 0xb23e)));
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x4b33));

        L05f3:
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
            this.oCPU.PushWord(this.oCPU.AX.Word);
            this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)));

        L05fa:
            // Instruction address 0x0000:0x05fe, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                (short)this.oCPU.PopWord(),
                (short)this.oCPU.PopWord(),
                this.oCPU.PopWord());
            goto L053e;

        L0609:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb23c)));
            this.oCPU.AX.Word = 0xf;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0x5;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)));
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x4b31));
            goto L05f3;

        L062d:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x7);
            if (this.oCPU.Flags.E) goto L0670;

            // Instruction address 0x0000:0x0661, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)),
                this.oCPU.ReadInt8(this.oCPU.DS.Word,
                    (ushort)((0xf * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110))) +
                    (0x5 * this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108))) + 0x4b32)) + 1,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word,
                    (ushort)(this.oCPU.BP.Word - 0x108)) << 2) + 0xb23c)));

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), this.oCPU.AX.Word));

        L0670:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb23e)));
            this.oCPU.AX.Word = 0xf;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0x5;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)));
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x4b35));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
            this.oCPU.PushWord(this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x2);
            if (this.oCPU.Flags.NE) goto L06a1;
            this.oCPU.AX.Word = 0x3;
            goto L06a4;

        L06a1:
            this.oCPU.AX.Word = 0x2;

        L06a4:
            this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104));
            this.oCPU.CX.Word = this.oCPU.SUBWord(this.oCPU.CX.Word, this.oCPU.AX.Word);
            this.oCPU.PushWord(this.oCPU.CX.Word);
            goto L05fa;

        L06ae:
            // Instruction address 0x0000:0x06b6, size: 5
            this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6828), 0x4b27);

            // Instruction address 0x0000:0x06be, size: 5
            this.oParent.Segment_1403.F0_1403_4545();

            // Instruction address 0x0000:0x06c3, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

        L06c8:
            // Instruction address 0x0000:0x06c8, size: 5
            this.oParent.Segment_11a8.F0_11a8_0223();

            this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
            if (this.oCPU.Flags.NE) goto L06dd;

            // Instruction address 0x0000:0x06d4, size: 5
            this.oParent.MSCAPI.kbhit();

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L06c8;

            L06dd:
            // Instruction address 0x0000:0x06dd, size: 5
            this.oParent.MSCAPI.kbhit();

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L06f5;
            this.oCPU.AX.Word = this.oParent.Var_db3c;
            this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
            this.oCPU.CX.Word = 0x6b;
            this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), this.oCPU.AX.Word);
            goto L070a;

        L06f5:
            // Instruction address 0x0000:0x06f5, size: 5
            this.oParent.Segment_2d05.F0_2d05_0ac9_GetNavigationKey();

            this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x31);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), this.oCPU.AX.Word);
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.L) goto L06c8;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.G) goto L06c8;

            L070a:
            // Instruction address 0x0000:0x070a, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);

            F17_0000_07ec(0);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

            // Instruction address 0x0000:0x073f, size: 5
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.BX.Word,
                0, 0);

        L0747:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110));
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e), this.oCPU.AX.Word);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a));
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb222), this.oCPU.AX.Word);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);

            F17_0000_07ec(0);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

            // Instruction address 0x0000:0x0780, size: 5
            this.oParent.VGADriver.F0_VGA_06b7_DrawScreenToMainScreen(1, 0x14);

            // Instruction address 0x0000:0x0788, size: 5
            this.oParent.Segment_1403.F0_1403_4545();

            // Instruction address 0x0000:0x078d, size: 5
            this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

        L0792:
            // Instruction address 0x0000:0x0795, size: 5
            this.oParent.Segment_1000.F0_1000_0846(0);

            // Instruction address 0x0000:0x07a1, size: 5
            this.oParent.Segment_1000.F0_1000_0a32(1, 0);

            // Instruction address 0x0000:0x07b2, size: 5
            this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
            if (this.oCPU.Flags.NE) goto L07dc;

            // Instruction address 0x0000:0x07d4, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 0);

        L07dc:
            // Instruction address 0x0000:0x07dc, size: 5
            this.oParent.Segment_1238.F0_1238_1b44();

            // Instruction address 0x0000:0x07e1, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.DI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F17_0000_0000");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="flag"></param>
        public void F17_0000_07ec(ushort flag)
        {
            this.oCPU.Log.EnterBlock($"F17_0000_07ec({flag})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2e);
            this.oCPU.PushWord(this.oCPU.SI.Word);

            // Instruction address 0x0000:0x07fd, size: 5
            this.oParent.Segment_11a8.F0_11a8_02a4(2, 1);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6828, 0xffff);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x0);

        L081d:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd91e));
            this.oCPU.CMPWord(this.oCPU.SI.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L0835;
            this.oCPU.AX.Word = 0x1;
            this.oCPU.CX.Word = this.oCPU.SI.Word;
            this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), this.oCPU.AX.Word));

        L0835:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x9);
            if (this.oCPU.Flags.L) goto L081d;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x1);

        L0843:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Low = 0xff;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb25f), this.oCPU.AX.Low);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb25e), this.oCPU.AX.Low);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)), 0xffff);
            if (this.oCPU.Flags.E) goto L0869;

            F17_0000_0cfe(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 1);

        L0869:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22),
                this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x8);
            if (this.oCPU.Flags.L) goto L0843;

            F17_0000_0e95(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)),
                1);

            this.oCPU.CMPWord(flag, 0x0);
            if (this.oCPU.Flags.E) goto L0897;

            // Instruction address 0x0000:0x089f, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4b81, 0);

            goto L089a;

        L0897:
            // Instruction address 0x0000:0x089f, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x4b89, 0);

        L089a:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd932), 0x0);
            if (this.oCPU.Flags.LE) goto L08e0;

            // Instruction address 0x0000:0x08b6, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "cbacks0.pic");

            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xd932);
            this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Low);

            // Instruction address 0x0000:0x08d8, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0x87, (ushort)(this.oCPU.BP.Word - 0x10), 0);

        L08e0:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), 0x10);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd922), 0xffff);
            if (this.oCPU.Flags.NE) goto L08f0;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x18));

        L08f0:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb22a), 0x1);
            if (this.oCPU.Flags.NE) goto L08fa;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));

        L08fa:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20), 0x24);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x8);
            goto L090c;

        L0906:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);

        L090c:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd91e)), 0xffff);
            if (this.oCPU.Flags.E) goto L0906;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), 0x1);
            goto L0b05;

        L0923:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3);
            if (this.oCPU.Flags.NE) goto L0945;

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) + this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b32)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
                1);

        L0945:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb222)), 0x1);
            if (this.oCPU.Flags.NE) goto L0957;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3);
            if (this.oCPU.Flags.NE) goto L096d;

            L0957:
            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
                0);

        L096d:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b32);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x3);
            if (this.oCPU.Flags.NE) goto L097f;
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word));

        L097f:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.AX.Word);
            goto L0b02;

        L0988:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
            if (this.oCPU.Flags.NE) goto L09c6;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb222));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb222)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L09c6;

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) +
                    this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e) - 17),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)) - 2),
                0);

        L09c6:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
            this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)));
            if (this.oCPU.Flags.NE) goto L0a05;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb222));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb222)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L0a05;

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) +
                    this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e) - 17),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)) - 2),
                1);

        L0a05:
            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
                0);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c),
                this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word));

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
                1);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e);
            goto L0af9;

        L0a3e:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb22a), 0x1);
            if (this.oCPU.Flags.NE) goto L0a48;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));

        L0a48:
            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) - 2),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
                0);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2c);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb22a), 0x1);
            if (this.oCPU.Flags.E) goto L0a71;
            goto L0b02;

        L0a71:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c))));
            goto L0b02;

        L0a77:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x5);
            if (this.oCPU.Flags.NE) goto L0a99;

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
                0);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b2e);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word));

        L0a99:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb222)), 0x1);
            if (this.oCPU.Flags.NE) goto L0ac9;
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.LE) goto L0ac9;

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) - 3),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)) -
                    this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)) +
                    this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)) + 1),
                1);

            goto L0ae9;

        L0ac9:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)) -
                    ((this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb222)) == 1) ? 3 : 2)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20)),
                1);

        L0ae9:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x4b34);

        L0af9:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), this.oCPU.AX.Word));
            goto L0b02;

        L0afe:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c), this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1c)), 0x30));

        L0b02:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22))));

        L0b05:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x8);
            if (this.oCPU.Flags.GE) goto L0b87;
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)), 0xffff);
            if (this.oCPU.Flags.E) goto L0afe;
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x2);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x4);
            if (this.oCPU.Flags.GE) goto L0b40;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)), 0xffff);
            if (this.oCPU.Flags.E) goto L0b3b;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x1);
            if (this.oCPU.Flags.NE) goto L0b40;

            L0b3b:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x0);

        L0b40:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x4);
            if (this.oCPU.Flags.LE) goto L0b62;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x1);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd920)), 0xffff);
            if (this.oCPU.Flags.E) goto L0b5d;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x22)), 0x7);
            if (this.oCPU.Flags.NE) goto L0b62;

            L0b5d:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), 0x3);

        L0b62:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26));
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L0b6c;
            goto L0923;

        L0b6c:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.NE) goto L0b74;
            goto L0988;

        L0b74:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.NE) goto L0b7c;
            goto L0a3e;

        L0b7c:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
            if (this.oCPU.Flags.NE) goto L0b84;
            goto L0a77;

        L0b84:
            goto L0b02;

        L0b87:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb222)), 0x1);
            if (this.oCPU.Flags.NE) goto L0bc0;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x3);
            if (this.oCPU.Flags.E) goto L0bc0;

            F17_0000_0e2f(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)),
                (ushort)((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)) * 48) - 36),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd920)) -
                    this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e)) +
                    this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x20))),
                0);

        L0bc0:
            // Instruction address 0x0000:0x0bc8, size: 5
            this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6828), 0x4b9f);

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd930), 0x0);
            if (this.oCPU.Flags.NE) goto L0be1;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd934), 0x0);
            if (this.oCPU.Flags.NE) goto L0be1;
            goto L0c94;

        L0be1:
            // Instruction address 0x0000:0x0bee, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "cbrush0.pic");

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd930), 0x0);
            if (this.oCPU.Flags.E) goto L0c36;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xd930);
            this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
            this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x2e);
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Low);

            // Instruction address 0x0000:0x0c0b, size: 5
            this.oParent.ImageTools.F0_2fa1_044c_LoadIcon((ushort)(this.oCPU.BP.Word - 0x10));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);

            // Instruction address 0x0000:0x0c2e, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0,
                ((this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd930) <= 1) ? 105 : 94),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));

        L0c36:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd934), 0x0);
            if (this.oCPU.Flags.E) goto L0c77;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xd934);
            this.oCPU.AX.Low = this.oCPU.SHLByte(this.oCPU.AX.Low, 0x1);
            this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x2f);
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Low);

            // Instruction address 0x0000:0x0c4b, size: 5
            this.oParent.ImageTools.F0_2fa1_044c_LoadIcon((ushort)(this.oCPU.BP.Word - 0x10));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);

            // Instruction address 0x0000:0x0c6f, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                184,
                ((this.oCPU.ReadInt16(this.oCPU.DS.Word, 0xd934) <= 1) ? 105 : 94),
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)));

        L0c77:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd930), 0x0);
            if (this.oCPU.Flags.E) goto L0c88;
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a));
            goto L0c8b;

        L0c88:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c));

        L0c8b:
            // Instruction address 0x0000:0x0c8c, size: 5
            this.oParent.Segment_2dc4.F0_2dc4_0523_FreeResource(this.oCPU.AX.Word, 0);

        L0c94:
            this.oCPU.CMPWord(flag, 0x0);
            if (this.oCPU.Flags.E) goto L0cf9;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
            if (this.oCPU.Flags.E) goto L0cc1;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeba), 0x7);
            if (this.oCPU.Flags.LE) goto L0cc1;

            // Instruction address 0x0000:0x0cb9, size: 5
            this.oParent.Segment_1000.F0_1000_04d4(5, 0, 0, 0);

        L0cc1:
            // Instruction address 0x0000:0x0cd4, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 0);

            // Instruction address 0x0000:0x0ce0, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x4bb0, 1);

            // Instruction address 0x0000:0x0cf1, size: 5
            this.oParent.Segment_11a8.F0_11a8_02a4(0, 1);

        L0cf9:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F17_0000_07ec");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="flag"></param>
        public void F17_0000_0cfe(ushort param1, ushort flag)
        {
            this.oCPU.Log.EnterBlock($"F17_0000_0cfe({param1}, {flag})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
            this.oCPU.PushWord(this.oCPU.SI.Word);
            this.oCPU.SI.Word = param1;
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x2);
            this.oCPU.CMPWord(param1, 0x4);
            if (this.oCPU.Flags.GE) goto L0d33;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)), 0xffff);
            if (this.oCPU.Flags.E) goto L0d2e;
            this.oCPU.CMPWord(param1, 0x1);
            if (this.oCPU.Flags.NE) goto L0d33;

            L0d2e:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

        L0d33:
            this.oCPU.CMPWord(param1, 0x4);
            if (this.oCPU.Flags.LE) goto L0d55;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x1);
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd920)), 0xffff);
            if (this.oCPU.Flags.E) goto L0d50;
            this.oCPU.CMPWord(param1, 0x7);
            if (this.oCPU.Flags.NE) goto L0d55;

            L0d50:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x3);

        L0d55:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0d6e;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.E) goto L0d9f;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.E) goto L0ddd;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
            if (this.oCPU.Flags.E) goto L0de9;
            goto L0e2a;

        L0d6e:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25e), 0x3);
            this.oCPU.CMPWord(param1, 0x3);
            if (this.oCPU.Flags.E) goto L0d87;
            this.oCPU.CMPWord(flag, 0x0);
            if (this.oCPU.Flags.E) goto L0d87;
            goto L0e2a;

        L0d87:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
            if (this.oCPU.Flags.E) goto L0d91;
            this.oCPU.AX.Low = 0x1;
            goto L0d93;

        L0d91:
            this.oCPU.AX.Low = 0x2;

        L0d93:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25f), this.oCPU.AX.Low);
            goto L0e2a;

        L0d9f:
            this.oCPU.SI.Word = param1;
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.G) goto L0dbb;
            this.oCPU.CMPWord(param1, 0x5);
            if (this.oCPU.Flags.E) goto L0dbb;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91a)), 0xffff);
            if (this.oCPU.Flags.NE) goto L0dc7;

            L0dbb:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25e), 0x1);
            goto L0dd1;

        L0dc7:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25e), 0x2);

        L0dd1:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25f), 0x2);
            goto L0e2a;

        L0ddd:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25e), 0x0);
            goto L0e2a;

        L0de9:
            this.oCPU.CMPWord(param1, 0x5);
            if (this.oCPU.Flags.E) goto L0df5;
            this.oCPU.CMPWord(flag, 0x0);
            if (this.oCPU.Flags.NE) goto L0e20;

            L0df5:
            this.oCPU.SI.Word = param1;
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91c)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.G) goto L0e0a;
            this.oCPU.CMPWord(param1, 0x5);
            if (this.oCPU.Flags.NE) goto L0e16;

            L0e0a:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25e), 0x1);
            goto L0e20;

        L0e16:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25e), 0x2);

        L0e20:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb25f), 0x4);

        L0e2a:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F17_0000_0cfe");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        /// <param name="flag"></param>
        public void F17_0000_0e2f(ushort param1, ushort param2, ushort param3, ushort param4, ushort flag)
        {
            this.oCPU.Log.EnterBlock($"F17_0000_0e2f({param1}, {param2}, {param3}, {param4}, {flag})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
            this.oCPU.PushWord(this.oCPU.DI.Word);
            this.oCPU.PushWord(this.oCPU.SI.Word);
            this.oCPU.SI.Word = param2;
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xd91e));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0xb222));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

            this.oCPU.BX.Word = flag;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb25e));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.DI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0x5;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
            this.oCPU.DI.Word = this.oCPU.ADDWord(this.oCPU.DI.Word, this.oCPU.AX.Word);
            this.oCPU.AX.Word = 0xf;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, param1);
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.DI.Word + 0x4b36));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, param4);
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, param1);
            // Instruction address 0x0000:0x0e87, size: 5
            this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                (short)param3,
                (short)this.oCPU.AX.Word,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)((flag << 1) + (param2 << 2) + 0xb23c)));

            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.DI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F17_0000_0e2f");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public void F17_0000_0e95(ushort param1, ushort param2)
        {
            this.oCPU.Log.EnterBlock($"F17_0000_0e95({param1}, {param2})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1a);
            this.oCPU.PushWord(this.oCPU.SI.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), 0x0);
            goto L104e;

        L0ea4:
            // Instruction address 0x0000:0x0eb8, size: 5
            this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
                this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + 1),
                0x34, 0x63);

        L0eb4:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb23c), this.oCPU.AX.Word);

        L0ed0:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb25e)), 0xff);
            if (this.oCPU.Flags.E) goto L0ef6;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6828), 0xffff);
            if (this.oCPU.Flags.NE) goto L0ef6;
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb23c));
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6828, this.oCPU.AX.Word);

        L0ef6:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

        L0ef9:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x2);
            if (this.oCPU.Flags.L) goto L0f02;
            goto L0fdf;

        L0f02:
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0xb25e));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0ea4;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.E) goto L0f29;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.E) goto L0f40;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
            if (this.oCPU.Flags.E) goto L0f55;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
            if (this.oCPU.Flags.E) goto L0f99;
            goto L0ed0;

        L0f29:
            // Instruction address 0x0000:0x0eb8, size: 5
            this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) + 0x35),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + 1),
                0x18, 0x63);

        L0f3c:
            goto L0eb4;

        L0f40:
            // Instruction address 0x0000:0x0eb8, size: 5
            this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) + 0x4e),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + 1),
                0x18, 0x63);
            goto L0f3c;

        L0f55:
            this.oCPU.CMPWord(param2, 0x0);
            if (this.oCPU.Flags.E) goto L0f67;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb222)), 0x1);
            if (this.oCPU.Flags.NE) goto L0f73;

            L0f67:
            this.oCPU.CMPWord(param2, 0x0);
            if (this.oCPU.Flags.NE) goto L0f88;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x2);
            if (this.oCPU.Flags.E) goto L0f88;

            L0f73:
            // Instruction address 0x0000:0x0eb8, size: 5
            this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) + 0x67),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + 1),
                0x1c, 0x63);
            goto L0f3c;

        L0f88:
            // Instruction address 0x0000:0x0eb8, size: 5
            this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, 0xa0, 0x65, 0x23, 0x63);
            goto L0f3c;

        L0f99:
            this.oCPU.CMPWord(param2, 0x0);
            if (this.oCPU.Flags.E) goto L0fab;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb222)), 0x1);
            if (this.oCPU.Flags.NE) goto L0fb7;

            L0fab:
            this.oCPU.CMPWord(param2, 0x0);
            if (this.oCPU.Flags.NE) goto L0fcd;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x2);
            if (this.oCPU.Flags.E) goto L0fcd;

            L0fb7:
            // Instruction address 0x0000:0x0eb8, size: 5
            this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16)) + 0x84),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18)) + 1),
                0x1b, 0x63);
            goto L0f3c;

        L0fcd:
            // Instruction address 0x0000:0x0eb8, size: 5
            this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, 0xc4, 0x65, 0x23, 0x63);
            goto L0f3c;

        L0fdf:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

        L0fe2:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x8);
            if (this.oCPU.Flags.GE) goto L104b;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xd91e)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0ffc;
            this.oCPU.CMPWord(param2, 0x0);
            if (this.oCPU.Flags.NE) goto L0fdf;

            L0ffc:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xb222));
            this.oCPU.AX.Word = this.oCPU.SI.Word;
            this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
            this.oCPU.CX.Word = 0xa0;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
            this.oCPU.AX.Word = this.oCPU.SI.Word;
            this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x2);
            this.oCPU.CX.Word = 0x32;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);
            this.oCPU.CMPWord(param2, 0x0);
            if (this.oCPU.Flags.NE) goto L1043;
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
            this.oCPU.AX.Word = this.oCPU.SI.Word;
            this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
            this.oCPU.CX.Word = 0xa0;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x16), this.oCPU.AX.Word);
            this.oCPU.AX.Word = this.oCPU.SI.Word;
            this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x2);
            this.oCPU.CX.Word = 0x32;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x18), this.oCPU.AX.Word);

        L1043:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
            goto L0ef9;

        L104b:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a))));

        L104e:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a)), 0x5);
            if (this.oCPU.Flags.GE) goto L1091;
            this.oCPU.AX.Word = 0x1;
            this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
            this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
            this.oCPU.TESTWord(this.oCPU.AX.Word, param1);
            if (this.oCPU.Flags.E) goto L104b;

            // Instruction address 0x0000:0x1069, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x10), "castle0.pic");

            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x1a));
            this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x30);
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Low);

            // Instruction address 0x0000:0x1081, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, (ushort)(this.oCPU.BP.Word - 0x10), 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x1);
            goto L0fe2;

        L1091:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F17_0000_0e95");
        }
    }
}
