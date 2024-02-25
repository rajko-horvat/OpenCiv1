using IRB.VirtualCPU;

namespace OpenCiv1
{
    public class Segment_2c84
    {
        private OpenCiv1 oParent;
        private CPU oCPU;

        public Segment_2c84(OpenCiv1 parent)
        {
            this.oParent = parent;
            this.oCPU = parent.CPU;
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="unitID"></param>
        /// <param name="flag"></param>
        public void F0_2c84_0000(short playerID, short unitID, short flag)
        {
            this.oCPU.Log.EnterBlock($"F0_2c84_0000({playerID}, {unitID}, {flag})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0xffff);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0x0);

            if (flag == -1)
            {
                // Instruction address 0x2c84:0x0026, size: 5
                flag = (short)this.oParent.Segment_2dc4.F0_2dc4_007c_CheckValueRange((short)this.oParent.Var_db3c / 60, 0, 4);
            }

            // Instruction address 0x2c84:0x0031, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0, 320, 200,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0);

            // Instruction address 0x2c84:0x003b, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            switch (flag)
            {
                case 0:
                    // Instruction address 0x2c84:0x005e, size: 3
                    F0_2c84_00ad();
                    break;

                case 1:
                    // Instruction address 0x2c84:0x006a, size: 3
                    F0_2c84_01d8(playerID, unitID);
                    break;

                case 2:
                    // Instruction address 0x2c84:0x0073, size: 3
                    F0_2c84_0615();
                    break;

                case 3:
                    // Instruction address 0x2c84:0x0079, size: 3
                    F0_2c84_06e4();
                    break;

                case 4:
                    // Instruction address 0x2c84:0x007f, size: 3
                    F0_2c84_07af();
                    break;
            }

            // Instruction address 0x2c84:0x0082, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x654a);
            this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.NE) goto L0099;
            this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
            if (this.oCPU.Flags.NE) goto L0099;

            // Instruction address 0x2c84:0x0094, size: 5
            this.oParent.Segment_1238.F0_1238_1b44();

        L0099:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x654a);
            this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
            this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L00a6;

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

        L00a6:
            // Instruction address 0x2c84:0x00a6, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_2c84_0000");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_2c84_00ad()
        {
            this.oCPU.Log.EnterBlock("F0_2c84_00ad()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);

            if (oParent.GameState.TurnCount != 0) goto L00c0;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x10);

        L00c0:
            // Instruction address 0x2c84:0x00c8, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, " Tax Rate\n Luxuries Rate\n FindCity\n Options\n Save Game\n REVOLUTION!\n \n Retire\n QUIT to DOS\n");

            this.oCPU.TESTWord((ushort)this.oParent.GameState.SpaceshipFlags, 0x100);
            if (this.oCPU.Flags.E) goto L00e8;

            // Instruction address 0x2c84:0x00e0, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " View Replay\n");

        L00e8:
            // Instruction address 0x2c84:0x00f4, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 16, 8, 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

            // Instruction address 0x2c84:0x00ff, size: 5
            this.oParent.Segment_1403.F0_1403_4545();

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x9);
            if (this.oCPU.Flags.BE) goto L010f;
            goto L01d4;

        L010f:
            switch (this.oCPU.AX.Word)
            {
                case 0:
                    goto L0120;
                case 1:
                    goto L0129;
                case 2:
                    goto L0132;
                case 3:
                    goto L013b;
                case 4:
                    goto L019b;
                case 5:
                    goto L0117;
                case 6:
                    goto L01d4;
                case 7:
                    goto L01a3;
                case 8:
                    goto L01b1;
                case 9:
                    goto L01b9;
            }

        L0117:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0xfffe);
            goto L01d4;

        L0120:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x3d);
            goto L01d4;

        L0129:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x2d);
            goto L01d4;

        L0132:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x3f);
            goto L01d4;

        L013b:
            // Instruction address 0x2c84:0x0143, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, "Options:\n Instant Advice\n AutoSave\n End of Turn\n Animations\n Sound\n Enemy Moves\n Civilopedia Text\n Palace\n");

        L014b:
            this.oCPU.AX.Word = (ushort)this.oParent.GameState.GameSettingFlags;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd7f2, this.oCPU.AX.Word);

            // Instruction address 0x2c84:0x015d, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 24, 16, 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L0180;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c), 0x0);
            if (this.oCPU.Flags.NE) goto L0180;
            this.oCPU.AX.Word = 0x1;
            this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
            this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
            oParent.GameState.GameSettingFlags ^= (short)this.oCPU.AX.Word;

        L0180:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
            if (this.oCPU.Flags.E) goto L018c;
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);

        L018c:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0xffff);
            if (this.oCPU.Flags.NE) goto L014b;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c), 0x0);
            if (this.oCPU.Flags.NE) goto L014b;
            goto L01d4;

        L019b:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x53);
            goto L01d4;

        L01a3:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x2);

        L01a9:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0x1000);
            goto L01d4;

        L01b1:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x1);
            goto L01a9;

        L01b9:
            this.oParent.GameReplay.F9_0000_0000();

        L01d4:
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_2c84_00ad");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="playerID"></param>
        /// <param name="unitID"></param>
        public void F0_2c84_01d8(short playerID, short unitID)
        {
            this.oCPU.Log.EnterBlock($"F0_2c84_01d8({playerID}, {unitID})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x30);
            this.oCPU.PushWord(this.oCPU.DI.Word);
            this.oCPU.PushWord(this.oCPU.SI.Word);

            if (unitID != -1) goto L01e9;
            goto L060f;

        L01e9:
            if (unitID != 128) goto L01f3;
            goto L060f;

        L01f3:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d5));
            this.oCPU.AX.High = 0;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24), this.oCPU.AX.Word);
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d6));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26), this.oCPU.AX.Word);

            // Instruction address 0x2c84:0x0221, size: 5
            this.oParent.Segment_2aea.F0_2aea_1585(
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c), this.oCPU.AX.Word);

            // Instruction address 0x2c84:0x0232, size: 5
            this.oParent.Segment_2aea.F0_2aea_134a(
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a), this.oCPU.AX.Word);

            // Instruction address 0x2c84:0x0245, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " No Orders \x008fspace\n");

            this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x22), 0x20);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x0);
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x81d7)), 0x0);
            if (this.oCPU.Flags.E) goto L0267;
            goto L042d;

        L0267:
            if ((this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)) & 1) != 0)
            {
                // Instruction address 0x2c84:0x027a, size: 5
                this.oParent.MSCAPI.strcat(0xba06, 0x2cbc);
            }
            else
            {
                // Instruction address 0x2c84:0x027a, size: 5
                this.oParent.MSCAPI.strcat(0xba06, 0x2ccd);
            }

            this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x22), 0x62);
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x8);
            if (this.oCPU.Flags.NE) goto L02ae;

            // Instruction address 0x2c84:0x029a, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Build Road \x008fr\n");

            this.oCPU.DI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x22), 0x72);
            goto L02e1;

        L02ae:
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x10);
            if (this.oCPU.Flags.NE) goto L02e1;

            // Instruction address 0x2c84:0x02bb, size: 5
            this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x31);
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E)
                goto L02e1;

            // Instruction address 0x2c84:0x02cf, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Build RailRoad \x008fr\n");

            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x72);

        L02e1:
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x2);
            if (this.oCPU.Flags.E) goto L02ea;
            goto L038e;

        L02ea:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x44a)), 0xfffe);
            if (this.oCPU.Flags.NE) goto L0329;

            // Instruction address 0x2c84:0x0301, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Build Irrigation");

            // Instruction address 0x2c84:0x030f, size: 5
            this.oParent.Segment_1403.F0_1403_3fd0(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x24)),
                this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x26)));

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L0365;
            this.oCPU.AX.Word = 0x1;
            this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276), this.oCPU.AX.Word));
            goto L0365;

        L0329:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x44a);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
            if (this.oCPU.Flags.L) goto L0365;

            // Instruction address 0x2c84:0x0342, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Change to ");

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word);
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.AX.Word = 0x13;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2ba6)));
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x282);
            // Instruction address 0x2c84:0x035d, size: 5
            this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

        L0365:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x44a)), 0xffff);
            if (this.oCPU.Flags.E) goto L038e;
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x69);

            // Instruction address 0x2c84:0x0386, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " \x008fi\n");

        L038e:
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x4);
            if (this.oCPU.Flags.NE) goto L040d;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x44e)), 0xfffe);
            if (this.oCPU.Flags.G) goto L03a8;

            // Instruction address 0x2c84:0x03dc, size: 5
            this.oParent.MSCAPI.strcat(0xba06, 0x2d28);

            goto L03e4;

        L03a8:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.SI.Word = this.oCPU.ADDWord(this.oCPU.SI.Word, 0x44e);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word), 0x0);
            if (this.oCPU.Flags.L) goto L03e4;

            // Instruction address 0x2c84:0x03c1, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Change to ");

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.SI.Word);
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.AX.Word = 0x13;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x2ba6)));
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x282);
            // Instruction address 0x2c84:0x03dc, size: 5
            this.oParent.MSCAPI.strcat(0xba06, this.oCPU.AX.Word);

        L03e4:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2a)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x44e)), 0xffff);
            if (this.oCPU.Flags.E) goto L040d;
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x6d);

            // Instruction address 0x2c84:0x0405, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " \x008fm\n");

        L040d:
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x40);
            if (this.oCPU.Flags.E) goto L042d;

            // Instruction address 0x2c84:0x041b, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Clean up Pollution \x008fp\n");

            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x70);

        L042d:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7)), 0x0);
            if (this.oCPU.Flags.NE) goto L0475;

            // Instruction address 0x2c84:0x044c, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Build Fortress \x008ff\n");

            // Instruction address 0x2c84:0x045b, size: 5
            this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(playerID, 0x2d);
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE)
                goto L04a4;

            this.oCPU.AX.Word = 0x1;
            this.oCPU.CX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, this.oCPU.ORWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xb276), this.oCPU.AX.Word));
            goto L04a4;

        L0475:
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
            if (this.oCPU.Flags.NE) goto L04a4;

            // Instruction address 0x2c84:0x049c, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Fortify \x008ff\n");

        L04a4:
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
            if (this.oCPU.Flags.NE) goto L04cd;
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x66);

        L04cd:
            // Instruction address 0x2c84:0x04d5, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Wait \x008fw\n Sentry \x008fs\n GoTo\n");

            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x77);
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x73);
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x67);
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x1e);
            if (this.oCPU.Flags.E) goto L053a;
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Low);
            this.oCPU.CMPByte(this.oCPU.AX.Low, 0x1a);
            if (this.oCPU.Flags.GE) goto L053a;
            this.oCPU.CMPByte(this.oCPU.AX.Low, 0xe);
            if (this.oCPU.Flags.E) goto L053a;

            // Instruction address 0x2c84:0x0528, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Pillage \x008fP\n");

            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x50);

        L053a:
            this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2c)), 0x1);
            if (this.oCPU.Flags.E) goto L055a;

            // Instruction address 0x2c84:0x0548, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Home City \x008fh\n");

            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x68);

        L055a:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81d7));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30), this.oCPU.AX.Low);
            this.oCPU.AX.Low = 0x22;
            this.oCPU.IMULByte(this.oCPU.AX, this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)));
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1148)), 0x5);
            if (this.oCPU.Flags.E) goto L0585;
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x30)), 0x17);
            if (this.oCPU.Flags.NE) goto L05b6;

            L0585:
            this.oCPU.AX.Word = 0xc;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)unitID);
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.AX.Word = 0x600;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, (ushort)playerID);
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word + 0x81de)), 0xff);
            if (this.oCPU.Flags.E) goto L05b6;

            // Instruction address 0x2c84:0x05a4, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Unload \x008fu\n");

            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x75);

        L05b6:
            // Instruction address 0x2c84:0x05be, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " \n Disband Unit \x008fD\n");

            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x0);
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
            this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22), 0x44);

            // Instruction address 0x2c84:0x05e6, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 72, 8, 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e), this.oCPU.AX.Word);
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.L) goto L0609;
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.GE) goto L0609;
            this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2e));
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x22));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, this.oCPU.AX.Word);
            goto L060f;

        L0609:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4ca, 0xffff);

        L060f:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.DI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_2c84_01d8");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_2c84_0615()
        {
            this.oCPU.Log.EnterBlock("F0_2c84_0615()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);

            // Instruction address 0x2c84:0x0623, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, " City Status (F1)\n Military Advisor (F2)\n Intelligence Advisor (F3)\n Attitude Advisor (F4)\n");

            // Instruction address 0x2c84:0x0633, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Trade Advisor (F5)\n Science Advisor (F6)\n");

            // Instruction address 0x2c84:0x0647, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 112, 8, 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

            // Instruction address 0x2c84:0x0652, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x2c84:0x065c, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0xffff);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L06ca;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.E) goto L0694;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.E) goto L06b4;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
            if (this.oCPU.Flags.E) goto L06bf;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
            if (this.oCPU.Flags.E) goto L0689;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5);
            if (this.oCPU.Flags.E) goto L06d5;

            goto L06e0;

        L0689:
            this.oParent.Overlay_14.F14_0000_07f1(this.oParent.GameState.HumanPlayerID);

            goto L06e0;


        L0694:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd806), 0x0);
            if (this.oCPU.Flags.E) goto L06a9;

            this.oParent.Overlay_13.F13_0000_0554();

            goto L06e0;

        L06a9:
            this.oParent.Overlay_14.F14_0000_03ad(this.oParent.GameState.HumanPlayerID);

            goto L06e0;

        L06b4:
            this.oParent.Overlay_14.F14_0000_0d43();

            goto L06e0;

        L06bf:
            this.oParent.Overlay_14.F14_0000_15f4(this.oParent.GameState.HumanPlayerID);

            goto L06e0;

        L06ca:
            this.oParent.Overlay_14.F14_0000_186f(this.oParent.GameState.HumanPlayerID);

            goto L06e0;

        L06d5:
            this.oParent.Overlay_14.F14_0000_014b(this.oParent.GameState.HumanPlayerID);

        L06e0:
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_2c84_0615");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_2c84_06e4()
        {
            this.oCPU.Log.EnterBlock("F0_2c84_06e4()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
            this.oCPU.TESTWord((ushort)this.oParent.GameState.SpaceshipFlags, 0xfe00);
            if (this.oCPU.Flags.NE) goto L06f8;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb276, 0x20);

        L06f8:
            // Instruction address 0x2c84:0x0700, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, " Wonders of the World (F7)\n Top 5 Cities (F8)\n Civilization Score (F9)\n");

            // Instruction address 0x2c84:0x0710, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " World Map (F10)\n Demographics\n SpaceShips\n");

            // Instruction address 0x2c84:0x0724, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 144, 8, 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

            // Instruction address 0x2c84:0x072f, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x2c84:0x0739, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0xffff);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0766;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.E) goto L078f;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.E) goto L077b;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
            if (this.oCPU.Flags.E) goto L0796;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
            if (this.oCPU.Flags.E) goto L076d;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x5);
            if (this.oCPU.Flags.E) goto L07a6;
            goto L07ab;

        L0766:
            this.oParent.WorldMap.F12_0000_080d();

            goto L07ab;

        L076d:
            this.oParent.WorldMap.F12_0000_0d6d(this.oParent.GameState.HumanPlayerID);

            goto L07ab;

        L077b:
            this.oParent.Overlay_20.F20_0000_0ca9(this.oParent.GameState.HumanPlayerID, true);

            goto L07ab;

        L078f:
            this.oParent.HallOfFame.F3_0000_09ac();

            goto L07ab;

        L0796:
            this.oParent.WorldMap.F12_0000_0000(1);

            goto L07ab;

        L07a6:
            this.oParent.Overlay_18.F18_0000_1527();

        L07ab:
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_2c84_06e4");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_2c84_07af()
        {
            this.oCPU.Log.EnterBlock("F0_2c84_07af()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

            // Instruction address 0x2c84:0x07bd, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, " Complete\n Civilization Advances\n City Improvements\n Military Units\n Terrain Types\n");

            // Instruction address 0x2c84:0x07cd, size: 5
            this.oParent.MSCAPI.strcat(0xba06, " Miscellaneous\n");

            // Instruction address 0x2c84:0x07e1, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 182, 8, 0);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L0806;

            this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
            this.oParent.Civilopedia.F8_0000_0000(this.oCPU.AX.Word);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0xffff);
            goto L080c;

        L0806:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x654a, 0x1);

        L080c:
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_2c84_07af");
        }
    }
}
