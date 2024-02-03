using IRB.VirtualCPU;

namespace OpenCiv1
{
    public class Segment_11a8
    {
        private OpenCiv1 oParent;
        private CPU oCPU;

        public Segment_11a8(OpenCiv1 parent)
        {
            this.oParent = parent;
            this.oCPU = parent.CPU;
        }

        /// <summary>
        /// Main game entry
        /// </summary>
        public void F0_11a8_0008_Main()
        {
            this.oCPU.Log.EnterBlock("F0_11a8_0008_Main()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xa);

            // Main menu selection
            // '1' - VGA; first letter of driver
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x1a22, 0x4d);
            // '1' - No sound 0x4e, '4' - Sound blaster 0x41, '5' - Roland MIDI board 0x52; first letter of driver
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x1a30, 0x4e);
            // '1' - Mouse and Keyboard 0x1, '2' - Keyboard only 0x0
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1a3c, 0x1);

            this.oParent.MainIntro.F2_0000_0000();

            // Instruction address 0x11a8:0x004a, size: 3
            F0_11a8_02a4(0, 1);

            this.oCPU.PushWord(0); // stack management - push return segment, ignored
            this.oCPU.PushWord(0x0055); // stack management - push return offset
                                        // Instruction address 0x11a8:0x0050, size: 5
            this.oParent.VGADriver.F0_VGA_0492_GetFreeMemory();
            this.oCPU.PopDWord(); // stack management - pop return offset and segment
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6dfc), 0x0);
            if (this.oCPU.Flags.E) goto L0064;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

        L0064:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
            if (this.oCPU.Flags.E) goto L0070;
            this.oCPU.AX.Word = 0x1f40;
            goto L0073;

        L0070:
            this.oCPU.AX.Word = 0xfa0;

        L0073:
            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
            if (this.oCPU.Flags.LE) goto L00ee;

            // Instruction address 0x11a8:0x008c, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 12);

            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x11a8:0x00b1, size: 5
            this.oParent.MSCAPI.strcat(0xba06,
                this.oParent.MSCAPI.itoa((short)this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 10));

            // Instruction address 0x11a8:0x00c1, size: 5
            this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), 0xba06);

            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x11a8:0x00d2, size: 5
            this.oParent.Segment_2f4d.F0_2f4d_044f(0x270);

            // Instruction address 0x11a8:0x00e6, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 64, 49, 1);

        L00ee:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
            if (this.oCPU.Flags.E) goto L0102;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x23be);
            if (this.oCPU.Flags.GE) goto L0102;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1a3e, 0x1);

        L0102:
            this.oCPU.PushWord(0); // stack management - push return segment, ignored
            this.oCPU.PushWord(0x0110); // stack management - push return offset
                                        // Instruction address 0x11a8:0x010b, size: 5
            this.oParent.ImageTools.F0_2fa1_044c_LoadIcon(0x277);
            this.oCPU.PopDWord(); // stack management - pop return offset and segment
                                  //this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6e92, this.oCPU.AX.Word);

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
            if (this.oCPU.Flags.E) goto L012a;

            // Instruction address 0x11a8:0x0122, size: 5
            this.oParent.Segment_1000.F0_1000_163e_InitMouse();

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1a3c, this.oCPU.AX.Word);

        L012a:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
            if (this.oCPU.Flags.E) goto L0145;

            // Instruction address 0x11a8:0x0139, size: 5
            this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6e92));

            // Instruction address 0x11a8:0x0142, size: 3
            F0_11a8_0250();

        L0145:
            // Game type, load, etc. menu
            // And then after menu Intro
            // Instruction address 0x11a8:0x0146, size: 3
            F0_11a8_0486_LogoAndMainGameMenu();

            // Start Game menu, level, tribe, name
            // Instruction address 0x11a8:0x014a, size: 3
            F0_11a8_087c_NewGameMenu();

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x1);
            if (this.oCPU.Flags.NE) goto L016f;

            this.oCPU.AX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].XStart;
            this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x7);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd4cc, this.oCPU.AX.Word);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd75e, 0x13);

            // Instruction address 0x11a8:0x016a, size: 5
            this.oParent.Segment_1238.F0_1238_1b44();

        L016f:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdc48, 0x0);

        L0175:
            // Instruction address 0x11a8:0x0175, size: 5
            this.oParent.Segment_1238.F0_1238_0092();

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdc48), 0x0);
            if (this.oCPU.Flags.E) goto L0175;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
            if (this.oCPU.Flags.E) goto L018d;

            // Instruction address 0x11a8:0x0188, size: 5
            this.oParent.Segment_1000.F0_1000_1687();

        L018d:
            // Instruction address 0x11a8:0x0191, size: 3
            this.oParent.Segment_1000.F0_1000_0a32(0, 0);

            // Instruction address 0x11a8:0x0197, size: 5
            this.oParent.Segment_1000.F0_1000_0a39();

            // Instruction address 0x11a8:0x019c, size: 5
            this.oParent.Segment_1000.F0_1000_0051();

            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_0008");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_11a8_0223()
        {
            // function body
            if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c) != 0)
            {
                // Instruction address 0x11a8:0x022a, size: 5
                this.oParent.Segment_1000.F0_1000_16d4();

                this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5872));
                this.oParent.Var_db3a = this.oCPU.AX.Word;
                this.oParent.Var_db3c = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x586e);
                this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5870);
                this.oParent.Var_db3e = this.oCPU.AX.Word;
            }
            else
            {
                this.oCPU.AX.Word = 0;
                this.oParent.Var_db3e = 0;
                this.oParent.Var_db3c = 0;
                this.oParent.Var_db3a = 0;
            }
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_11a8_0250()
        {
            this.oCPU.Log.EnterBlock("F0_11a8_0250()");

            // function body
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdeea,
                this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeea)));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
            if (this.oCPU.Flags.E) goto L0267;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeea), 0x1);
            if (this.oCPU.Flags.NE) goto L0267;

            // Instruction address 0x11a8:0x0262, size: 5
            this.oParent.Segment_1000.F0_1000_16db();

        L0267:
            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_0250");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_11a8_0268()
        {
            this.oCPU.Log.EnterBlock("F0_11a8_0268()");

            // function body
            if (this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c) != 0 && this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeea) == 1)
            {
                // Instruction address 0x11a8:0x0276, size: 5
                this.oParent.Segment_1000.F0_1000_170b();
            }

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdeea,
                this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeea)));

            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_0268");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_11a8_0280()
        {
            this.oCPU.Log.EnterBlock("F0_11a8_0280()");

            // function body
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeea);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x652e, this.oCPU.AX.Word);
            goto L028c;

        L0288:
            // Instruction address 0x11a8:0x0289, size: 3
            F0_11a8_0250();

        L028c:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeea), 0x1);
            if (this.oCPU.Flags.L) goto L0288;
            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_0280");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_11a8_0294()
        {
            this.oCPU.Log.EnterBlock("F0_11a8_0294()");

            // function body
            goto L029a;

        L0296:
            // Instruction address 0x11a8:0x0297, size: 3
            F0_11a8_0268();

        L029a:
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x652e);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeea), this.oCPU.AX.Word);
            if (this.oCPU.Flags.G) goto L0296;
            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_0294");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="flag"></param>
        public void F0_11a8_02a4(ushort param1, ushort flag)
        {
            this.oCPU.Log.EnterBlock($"F0_11a8_02a4({param1}, {flag})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x102);
            this.oCPU.CMPWord(flag, 0x0);
            if (this.oCPU.Flags.NE) goto L02d9;

            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

            // Instruction address 0x11a8:0x02bd, size: 5
            this.oParent.Segment_1000.F0_1000_066a_FileExists(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1ace)));

            this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L02d4;
            this.oCPU.AX.Word = param1;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe17c, this.oCPU.AX.Word);
            this.oCPU.AX.Word = 0x1;
            goto L03d5;

        L02d4:
            param1 = 0;

        L02d9:
            this.oCPU.BX.Word = param1;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);

            // Instruction address 0x11a8:0x02e5, size: 5
            this.oParent.Segment_1000.F0_1000_066a_FileExists(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1ace)));

            this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L02f9;
            this.oCPU.CMPWord(flag, 0xffff);
            if (this.oCPU.Flags.E) goto L02f9;
            goto L03cc;

        L02f9:
            // Instruction address 0x11a8:0x02ff, size: 5
            this.oParent.Segment_1000.F0_1000_0846(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa)));

            this.oCPU.CMPWord(flag, 0xffff);
            if (this.oCPU.Flags.NE) goto L0312;

            flag = 1;

        L0312:
            // Instruction address 0x11a8:0x0313, size: 3
            F0_11a8_0268();

            // Instruction address 0x11a8:0x032a, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 15);

            this.oCPU.AX.Word = param1;
            this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
            this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeba);
            this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.AX.Low = this.oCPU.ADDByte(this.oCPU.AX.Low, 0x31);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0x1ade, this.oCPU.AX.Low);

            // Instruction address 0x11a8:0x034a, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x100), "Please insert Disk ");

            // Instruction address 0x11a8:0x035b, size: 5
            this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x100), "A");

            // Instruction address 0x11a8:0x036c, size: 5
            this.oParent.MSCAPI.strcat((ushort)(this.oCPU.BP.Word - 0x100), ".\n \n    Press Return\n    to continue.\n");

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x3936);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), this.oCPU.AX.Word);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, 0xffff);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd206, 0x1);

            // Instruction address 0x11a8:0x0394, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031((ushort)(this.oCPU.BP.Word - 0x100), 100, 81, 1);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102));
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x3936, this.oCPU.AX.Word);

            // Instruction address 0x11a8:0x03b7, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 15);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x1ae0, 0x1);

            // Instruction address 0x11a8:0x03c6, size: 3
            F0_11a8_0250();

            goto L02d9;

        L03cc:
            this.oCPU.AX.Word = param1;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xe17c, this.oCPU.AX.Word);
            this.oCPU.AX.Word = flag;

        L03d5:
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_02a4");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_11a8_0486_LogoAndMainGameMenu()
        {
            this.oCPU.Log.EnterBlock("F0_11a8_0486_LogoAndMainGameMenu()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76a, 0x0);
            goto L04bb;

        L0494:
            // Instruction address 0x11a8:0x049c, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, " Start a New Game\n Load a Saved Game\n EARTH\n Customize World\n View Hall of Fame\n");

            // Instruction address 0x11a8:0x04b0, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 100, 140, 1);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, this.oCPU.AX.Word);

        L04bb:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0xffff);
            if (this.oCPU.Flags.E) goto L0494;

            L04c2:
            // Instruction address 0x11a8:0x04c2, size: 5
            this.oParent.Segment_1000.F0_1000_0a4e();

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1495);
            if (this.oCPU.Flags.LE) goto L04dc;
            this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, 0x1495);
            this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
            this.oCPU.CX.Word = 0x120;
            this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
            this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
            if (this.oCPU.Flags.NE) goto L04c2;

            L04dc:
            // Instruction address 0x11a8:0x04e1, size: 3
            this.oParent.Segment_1000.F0_1000_0a32(1, 0);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32);
            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0511;
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x1);
            if (this.oCPU.Flags.NE) goto L04f6;
            goto L07bd;

        L04f6:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x2);
            if (this.oCPU.Flags.NE) goto L04fe;
            goto L0795;

        L04fe:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x3);
            if (this.oCPU.Flags.NE) goto L0506;
            goto L0591;

        L0506:
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4);
            if (this.oCPU.Flags.NE) goto L050e;
            goto L07ee;

        L050e:
            goto L0810;

        L0511:
            // Instruction address 0x11a8:0x0512, size: 3
            F0_11a8_0268();

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);

        L051a:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x7ef6), 0x1);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x4);
            if (this.oCPU.Flags.L) goto L051a;

            L052e:
            // Intro...
            this.oCPU.Log = this.oParent.IntroLog;
            this.oCPU.Log.EnterBlock("'Intro start'");
            this.oParent.VGADriverLog.EnterBlock("'Intro start'");
            this.oParent.InterruptLog.EnterBlock("'Intro start'");

            this.oParent.GameInitAndIntro.F7_0000_0012_GameIntro();

            this.oParent.InterruptLog.ExitBlock("'Intro end'");
            this.oParent.VGADriverLog.ExitBlock("'Intro end'");
            this.oCPU.Log.ExitBlock("'Intro end'");
            this.oCPU.Log = this.oParent.Log;

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

            // Instruction address 0x11a8:0x053e, size: 5
            this.oParent.Segment_1000.F0_1000_0846(0);

            // Instruction address 0x11a8:0x054e, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1b33, 0);

        L0549:
            // Instruction address 0x11a8:0x0576, size: 5
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0xa0, 0x32, 0xa0, 0x96,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
                0xa0, 0x32);

            // Instruction address 0x11a8:0x0588, size: 3
            F0_11a8_02a4(0, 1);

            goto L0810;

        L0591:
            // Instruction address 0x11a8:0x0592, size: 3
            F0_11a8_0268();

            // Instruction address 0x11a8:0x05a0, size: 3
            F0_11a8_02a4(7, 1);

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
            if (this.oCPU.Flags.E) goto L05be;

            // Instruction address 0x11a8:0x05b6, size: 5
            this.oParent.Segment_1000.F0_1000_04d4(5, 0, 0, 0);

        L05be:
            // Instruction address 0x11a8:0x05d1, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 0);

            // Instruction address 0x11a8:0x05e1, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1b3d, 1);

            // Instruction address 0x11a8:0x05f3, size: 3
            F0_11a8_02a4(0, 1);

            // Instruction address 0x11a8:0x0611, size: 5
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x11a8:0x061a, size: 3
            F0_11a8_0250();

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, 0x1);

        L0623:
            // Instruction address 0x11a8:0x062b, size: 5
            this.oParent.Segment_1000.F0_1000_16ae(210, 11);

            // Instruction address 0x11a8:0x063b, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, "LAND MASS:\n Small\n Normal\n Large\n");

            // Instruction address 0x11a8:0x064f, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 200, 1, 1);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7ef6, this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L0623;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c), 0x0);
            if (this.oCPU.Flags.E) goto L067a;

            this.oParent.Help.F4_0000_0000(0x1b6a);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x7ef6);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
            goto L0623;

        L067a:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, 0x1);

        L0680:
            // Instruction address 0x11a8:0x0688, size: 5
            this.oParent.Segment_1000.F0_1000_16ae(210, 61);

            // Instruction address 0x11a8:0x0698, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, "TEMPERATURE:\n Cool\n Temperate\n Warm\n");

            // Instruction address 0x11a8:0x06ac, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 200, 51, 1);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7ef8, this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L0680;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c), 0x0);
            if (this.oCPU.Flags.E) goto L06d7;

            this.oParent.Help.F4_0000_0000(0x1b94);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x7ef8);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
            goto L0680;

        L06d7:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, 0x1);

        L06dd:
            // Instruction address 0x11a8:0x06e5, size: 5
            this.oParent.Segment_1000.F0_1000_16ae(210, 111);

            // Instruction address 0x11a8:0x06f5, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, "CLIMATE:\n Arid\n Normal\n Wet\n");

            // Instruction address 0x11a8:0x0709, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 200, 101, 1);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7efa, this.oCPU.AX.Word);

            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L06dd;

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c), 0x0);
            if (this.oCPU.Flags.E) goto L0734;

            this.oParent.Help.F4_0000_0000(0x1bbd);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x7efa);

        L072f:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, this.oCPU.AX.Word);
            goto L06dd;

        L0734:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f9a, 0x1);

        L073a:
            // Instruction address 0x11a8:0x0742, size: 5
            this.oParent.Segment_1000.F0_1000_16ae(210, 161);

            // Instruction address 0x11a8:0x0752, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, "AGE:\n 3 billion years\n 4 billion years\n 5 billion years\n");

            // Instruction address 0x11a8:0x0766, size: 5
            this.oParent.Segment_2d05.F0_2d05_0031(0xba06, 200, 151, 1);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x7efc, this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L073a;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x2f9c), 0x0);
            if (this.oCPU.Flags.E) goto L078e;

            this.oParent.Help.F4_0000_0000(0x1bfe);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x7efc);
            goto L072f;

        L078e:
            // Instruction address 0x11a8:0x078f, size: 3
            F0_11a8_0268();

            goto L052e;

        L0795:
            // Instruction address 0x11a8:0x0796, size: 3
            F0_11a8_0268();

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd76a, 0x1);

            this.oParent.GameInitAndIntro.F7_0000_0012_GameIntro();

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

            // Instruction address 0x11a8:0x07af, size: 5
            this.oParent.Segment_1000.F0_1000_0846(0);

            // Instruction address 0x11a8:0x054e, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1c02, 0);

            goto L0549;

        L07bd:
            this.oParent.GameLoadAndSave.F11_0000_0000(0xffff);

            this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L0807;

            // Instruction address 0x11a8:0x07cd, size: 3
            F0_11a8_0268();

            // Instruction address 0x11a8:0x07e4, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 7);
            goto L0810;

        L07ee:
            // Instruction address 0x11a8:0x07ef, size: 3
            F0_11a8_0268();

            this.oParent.HallOfFame.F3_0000_002b();

            this.oParent.HallOfFame.F3_0000_00d7(0xffff);

            // Instruction address 0x11a8:0x0804, size: 3
            F0_11a8_0250();

        L0807:
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0xffff);
            goto L04bb;

        L0810:
            this.oParent.StartGameMenu.F5_0000_1455();

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x2f98, 0x1);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
            if (this.oCPU.Flags.E) goto L0848;

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x0);
            if (this.oCPU.Flags.E) goto L0837;

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x2);
            if (this.oCPU.Flags.E) goto L0837;

            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0x3);
            if (this.oCPU.Flags.NE) goto L0848;

            L0837:
            // Instruction address 0x11a8:0x0840, size: 5
            this.oParent.Segment_1000.F0_1000_04d4(5, 0, 0, 0);

        L0848:
            // Instruction address 0x11a8:0x085b, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 0, 0, 320, 200, 0);

            // Instruction address 0x11a8:0x0867, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x1c0c, 1);

            // Instruction address 0x11a8:0x086f, size: 5
            this.oParent.Segment_2dc4.F0_2dc4_05dd();

            // Instruction address 0x11a8:0x0875, size: 3
            F0_11a8_0250();

            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_0486_LogoAndMainGameMenu");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F0_11a8_087c_NewGameMenu()
        {
            this.oCPU.Log.EnterBlock("F0_11a8_087c_NewGameMenu()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x1a3c), 0x0);
            if (this.oCPU.Flags.E) goto L0899;

            // Instruction address 0x11a8:0x0891, size: 5
            this.oParent.Segment_1000.F0_1000_1697(0, 0, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4dc));

        L0899:
            if (this.oParent.GameState.TurnCount != 0) goto L08c5;

            // Instruction address 0x11a8:0x08a8, size: 5
            this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x1c16, 1);

            // Instruction address 0x11a8:0x08ba, size: 3
            F0_11a8_02a4(0, 1);

            this.oParent.StartGameMenu.F5_0000_0000();

        L08c5:
            this.oParent.StartGameMenu.F5_0000_1af6();

            // Instruction address 0x11a8:0x08d4, size: 3
            F0_11a8_02a4(0, 1);

            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F0_11a8_087c_NewGameMenu");
        }
    }
}
