using IRB.VirtualCPU;

namespace OpenCiv1
{
    public class Overlay_23
    {
        private OpenCiv1 oParent;
        private CPU oCPU;

        public Overlay_23(OpenCiv1 parent)
        {
            this.oParent = parent;
            this.oCPU = parent.CPU;
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="cityID"></param>
        /// <returns></returns>
        public ushort F23_0000_0000(short cityID)
        {
            this.oCPU.Log.EnterBlock($"F23_0000_0000({cityID})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);

            // Instruction address 0x0000:0x0006, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0);

        L0010:
            // Instruction address 0x0000:0x0025, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 80, 80, 160, 32, 15);

            // Instruction address 0x0000:0x003e, size: 5
            this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(80, 80, 160, 32, 11);

            // Instruction address 0x0000:0x0055, size: 5
            this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x539e, 88, 82, 0);

            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            // Instruction address 0x0000:0x0065, size: 5
            this.oParent.Segment_2459.F0_2459_08c6_GetCityName(cityID);

            F23_0000_0414(0x58, 0x60, 0xc);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);

            // Instruction address 0x0000:0x0087, size: 5
            this.oParent.MSCAPI.strlen(0xba06);

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L0096;
            goto L0010;

        L0096:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
            if (this.oCPU.Flags.E) goto L00c5;

            uint uiCityNameID = this.oParent.GameState.Cities[cityID].NameID;
            char[] acCityName = this.oParent.GameState.CityNames[uiCityNameID].ToCharArray();

            for (int i = 0; i < 0xd; i++)
            {
                acCityName[i] = (char)this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(0xba06 + i));
            }
            this.oParent.GameState.CityNames[uiCityNameID] = new string(acCityName);

        L00c5:
            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

            // Instruction address 0x0000:0x00ca, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();

            // Far return
            this.oCPU.Log.ExitBlock("F23_0000_0000");

            return this.oCPU.AX.Word;
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F23_0000_00d6()
        {
            this.oCPU.Log.EnterBlock("F23_0000_00d6()");

            // function body
            // Instruction address 0x0000:0x00d6, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            // Instruction address 0x0000:0x00f3, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 158, 88, 160, 32, 15);

            // Instruction address 0x0000:0x010f, size: 5
            this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(158, 88, 160, 32, 11);

            // Instruction address 0x0000:0x0126, size: 5
            this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x53ab, 166, 90, 0);

            this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            // Instruction address 0x0000:0x013c, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

            F23_0000_0414(0xa6, 0x68, 0xd);

            this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            // Instruction address 0x0000:0x0165, size: 5
            this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)), 0xba06);

            // Instruction address 0x0000:0x016d, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            // Far return
            this.oCPU.Log.ExitBlock("F23_0000_00d6");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F23_0000_0173()
        {
            this.oCPU.Log.EnterBlock("F23_0000_0173()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);

            // Instruction address 0x0000:0x0179, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            // Instruction address 0x0000:0x0196, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 158, 88, 160, 32, 15);

            // Instruction address 0x0000:0x01b2, size: 5
            this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(158, 88, 160, 32, 11);

            // Instruction address 0x0000:0x01c9, size: 5
            this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x53b8, 166, 90, 0);

            this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            // Instruction address 0x0000:0x01df, size: 5
            this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)));

            F23_0000_0414(0xa6, 0x68, 0xb);

            this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            // Instruction address 0x0000:0x0208, size: 5
            this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1992)), 0xba06);

            // Instruction address 0x0000:0x0214, size: 5
            this.oParent.MSCAPI.strlen(0xba06);

            this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x73);
            if (this.oCPU.Flags.NE) goto L022e;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

        L022e:
            this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            // Instruction address 0x0000:0x023c, size: 5
            this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982)), 0xba06);

            this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
            this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1982));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xa), 0x0);

            // Instruction address 0x0000:0x0252, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F23_0000_0173");
        }

        /// <summary>
        /// ?
        /// </summary>
        public void F23_0000_025b()
        {
            this.oCPU.Log.EnterBlock("F23_0000_025b()");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
            this.oCPU.PushWord(this.oCPU.DI.Word);
            this.oCPU.PushWord(this.oCPU.SI.Word);

            // Instruction address 0x0000:0x0263, size: 5
            this.oParent.Segment_11a8.F0_11a8_0268();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0);

            F23_0000_0319(0x53ce);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, 0xffff);
            if (this.oCPU.Flags.E) goto L02cd;

            this.oCPU.AX.Low = (byte)this.oParent.GameState.MapVisibility[this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X,
                this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y];
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.DX.Word = 0x1;
            this.oCPU.CX.Low = (byte)(this.oParent.GameState.HumanPlayerID & 0xff);
            this.oCPU.DX.Word = this.oCPU.SHLWord(this.oCPU.DX.Word, this.oCPU.CX.Low);
            this.oCPU.TESTWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
            if (this.oCPU.Flags.E) goto L02cd;

            // Instruction address 0x0000:0x02c3, size: 5
            this.oParent.Segment_2aea.F0_2aea_0008(this.oParent.GameState.HumanPlayerID,
                this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.X - 7,
                this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))].Position.Y - 6);

            goto L030e;

        L02cd:
            // Instruction address 0x0000:0x02e5, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 64, 78, 224, 10, 15);

            // Instruction address 0x0000:0x02fc, size: 5
            this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(0x53f3, 82, 80, 0);

            // Instruction address 0x0000:0x0304, size: 5
            this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();

            this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
                0, 0, 0x140, 0xc8,
                this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                0, 0);

        L030e:
            // Instruction address 0x0000:0x030e, size: 5
            this.oParent.Segment_11a8.F0_11a8_0250();

            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.DI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F23_0000_025b");
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="stringPtr"></param>
        /// <returns></returns>
        public ushort F23_0000_0319(ushort stringPtr)
        {
            this.oCPU.Log.EnterBlock($"F23_0000_0319(0x{stringPtr:x4})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x14);
            this.oCPU.PushWord(this.oCPU.SI.Word);

            // Instruction address 0x0000:0x0338, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), 64, 78, 224, 24, 15);

            // Instruction address 0x0000:0x0353, size: 5
            this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(64, 78, 224, 24, 0);

            // Instruction address 0x0000:0x0369, size: 5
            this.oParent.Segment_1182.F0_1182_005c_DrawStringToScreen0(stringPtr, 66, 80, 0);

            this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

            F23_0000_0414(0x42, 0x59, 0x10);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), 0x0);
            goto L03bc;

        L0390:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))));

        L0393:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)), 0x80);
            if (this.oCPU.Flags.GE) goto L03b9;
            this.oCPU.AX.Word = 0x1c;
            this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12)));
            this.oCPU.SI.Word = this.oCPU.AX.Word;
            this.oCPU.CMPByte(this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].StatusFlag, 0xff);
            if (this.oCPU.Flags.E) goto L0390;
            this.oCPU.AX.Low = this.oParent.GameState.Cities[this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12))].NameID;
            this.oCPU.AX.High = 0;
            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)));
            if (this.oCPU.Flags.NE) goto L0390;
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12));
            goto L040f;

        L03b9:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14))));

        L03bc:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14)), 0x100);
            if (this.oCPU.Flags.GE) goto L040c;

            int uiCityNameID = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x14));
            ushort usStringOffset = (ushort)(this.oCPU.BP.Word - 0x10);

            for (int i = 0; i < 13; i++)
            {
                this.oCPU.Memory.WriteUInt8(this.oCPU.SS.Word, (ushort)(usStringOffset + i), this.oParent.GameState.CityNames[uiCityNameID][i]);
            }

            // Instruction address 0x0000:0x03e8, size: 5
            this.oParent.MSCAPI.strlen(0xba06);

            // Instruction address 0x0000:0x03f9, size: 5
            this.oParent.MSCAPI.strnicmp(0xba06, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L03b9;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x12), 0x0);
            goto L0393;

        L040c:
            this.oCPU.AX.Word = 0xffff;

        L040f:
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();

            // Far return
            this.oCPU.Log.ExitBlock("F23_0000_0319");

            return this.oCPU.AX.Word;
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public ushort F23_0000_0414(short xPos, short yPos, ushort width)
        {
            this.oCPU.Log.EnterBlock($"F23_0000_0414({xPos}, {yPos}, {width})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x48);
            this.oCPU.PushWord(this.oCPU.SI.Word);

            // Instruction address 0x0000:0x0434, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), xPos, yPos, (7 * width), 11, 15);

            // Instruction address 0x0000:0x0456, size: 5
            this.oParent.Segment_2d05.F0_2d05_0a05_DrawRectangle(xPos, yPos - 1, width * 8 + 8, 13, 0);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xe), 0xf);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, 0x0);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x1);

            // Instruction address 0x0000:0x0476, size: 5
            this.oParent.MSCAPI.strlen(0xba06);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
            goto L048e;

        L0483:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

        L048e:
            this.oCPU.AX.Word = width;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.L) goto L0483;
            this.oCPU.BX.Word = this.oCPU.AX.Word;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

            F23_0000_06c1(xPos, yPos, this.oCPU.AX.Word);

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x1);
            goto L0525;

        L04b2:
            this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
            if (this.oCPU.Flags.NE) goto L052e;

            // Instruction address 0x0000:0x04d6, size: 5
            this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68d0),
                yPos + 1,
                this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68ce), 10, 15, 11);

            // Instruction address 0x0000:0x04e2, size: 5
            this.oParent.Segment_1182.F0_1182_0134_WaitTime(10);

            // Instruction address 0x0000:0x0503, size: 5
            this.oParent.VGADriver.F0_VGA_009a_ReplaceColor(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
                this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68d0),
                yPos + 1,
                this.oCPU.ReadInt16(this.oCPU.DS.Word, 0x68ce), 10, 11, 15);

            // Instruction address 0x0000:0x050b, size: 5
            this.oParent.MSCAPI.kbhit();

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L0520;

            // Instruction address 0x0000:0x0518, size: 5
            this.oParent.Segment_1182.F0_1182_0134_WaitTime(10);

        L0520:
            // Instruction address 0x0000:0x0520, size: 5
            this.oParent.Segment_11a8.F0_11a8_0223();

        L0525:
            // Instruction address 0x0000:0x0525, size: 5
            this.oParent.MSCAPI.kbhit();

            this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.E) goto L04b2;

            L052e:
            this.oCPU.CMPWord(this.oParent.Var_db3a, 0x0);
            if (this.oCPU.Flags.E) goto L053c;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0xd);
            goto L0544;

        L053c:
            // Instruction address 0x0000:0x053c, size: 5
            this.oParent.MSCAPI.getch();

            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

        L0544:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
            if (this.oCPU.Flags.NE) goto L0555;

            // Instruction address 0x0000:0x054a, size: 5
            this.oParent.MSCAPI.getch();

            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x80);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.AX.Word);

        L0555:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd);
            if (this.oCPU.Flags.NE) goto L0565;

            L055b:
            this.oCPU.AX.Word = width;
            this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
            goto L069d;

        L0565:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x1b);
            if (this.oCPU.Flags.NE) goto L0572;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46), 0x0);
            goto L055b;

        L0572:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xcb);
            if (this.oCPU.Flags.NE) goto L0584;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc), 0x0);
            if (this.oCPU.Flags.E) goto L0584;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

        L0584:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xcd);
            if (this.oCPU.Flags.NE) goto L0599;

            this.oCPU.AX.Word = width;
            this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc));
            if (this.oCPU.Flags.LE) goto L0599;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

        L0599:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd2);
            if (this.oCPU.Flags.NE) goto L05d7;

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba06);
            // Instruction address 0x0000:0x05ab, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x40), this.oCPU.AX.Word);

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
            this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba07);
            // Instruction address 0x0000:0x05be, size: 5
            this.oParent.MSCAPI.strcpy(this.oCPU.AX.Word, (ushort)(this.oCPU.BP.Word - 0x40));

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
            this.oCPU.BX.Word = width;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

        L05d7:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd3);
            if (this.oCPU.Flags.NE) goto L060a;

            // Instruction address 0x0000:0x05ec, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba06),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba07));

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
            this.oCPU.BX.Word = width;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x20);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

        L060a:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
            if (this.oCPU.Flags.NE) goto L063e;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc), 0x0);
            if (this.oCPU.Flags.E) goto L063e;

            // Instruction address 0x0000:0x0625, size: 5
            this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba05),
                (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc) + 0xba06));

            this.oCPU.BX.Word = width;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05), 0x20);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

        L063e:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x80);
            if (this.oCPU.Flags.GE) goto L0682;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x20);
            if (this.oCPU.Flags.L) goto L0682;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42)), 0x0);
            if (this.oCPU.Flags.E) goto L066b;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), 0x0);
            goto L0663;

        L0658:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x20);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

        L0663:
            this.oCPU.AX.Word = width;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.L) goto L0658;

            L066b:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), this.oCPU.AX.Low);
            this.oCPU.AX.Word = width;
            this.oCPU.AX.Word = this.oCPU.DECWord(this.oCPU.AX.Word);
            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
            if (this.oCPU.Flags.LE) goto L0682;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68cc, this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc)));

        L0682:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x42), 0x0);

            F23_0000_06c1(xPos, yPos, width);

            goto L0525;

        L069a:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.DECWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44))));

        L069d:
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44)), 0x0);
            if (this.oCPU.Flags.LE) goto L06b4;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
            this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x20);
            if (this.oCPU.Flags.NE) goto L06b4;
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);
            goto L069a;

        L06b4:
            // Instruction address 0x0000:0x06b4, size: 5
            this.oParent.Segment_1403.F0_1403_4545();

            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x46));
            this.oCPU.SI.Word = this.oCPU.PopWord();
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();

            // Far return
            this.oCPU.Log.ExitBlock("F23_0000_0414");

            return this.oCPU.AX.Word;
        }

        /// <summary>
        /// ?
        /// </summary>
        /// <param name="xPos"></param>
        /// <param name="yPos"></param>
        /// <param name="width"></param>
        public void F23_0000_06c1(short xPos, short yPos, ushort width)
        {
            this.oCPU.Log.EnterBlock($"F23_0000_06c1({xPos}, {yPos}, {width})");

            // function body
            this.oCPU.PushWord(this.oCPU.BP.Word);
            this.oCPU.BP.Word = this.oCPU.SP.Word;
            this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
            xPos += 2;
            yPos += 2;
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
            goto L0777;

        L06d7:
            // Instruction address 0x0000:0x06ea, size: 5
            this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa), xPos, yPos, 8, 8, 15);

            // Instruction address 0x0000:0x06f6, size: 5
            this.oParent.MSCAPI.strlen(0xba06);

            this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
            if (this.oCPU.Flags.LE) goto L0774;
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07));
            this.oCPU.CBW(this.oCPU.AX);
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07), 0x0);

            // Instruction address 0x0000:0x0722, size: 5
            this.oParent.Segment_1182.F0_1182_002a_DrawString((ushort)(0xba06 + this.oCPU.BX.Word), xPos, yPos, 0);

            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
            this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba07), this.oCPU.AX.Low);
            this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x68cc);
            this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
            if (this.oCPU.Flags.NE) goto L0759;
            this.oCPU.AX.Word = (ushort)xPos;
            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68d0, this.oCPU.AX.Word);
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06));

            // Instruction address 0x0000:0x074e, size: 5
            this.oParent.VGADriver.F0_VGA_115d_GetCharWidth(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0x10)), this.oCPU.AX.Low);

            this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x68ce, this.oCPU.AX.Word);

        L0759:
            this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
            this.oCPU.AX.Low = this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06));

            // Instruction address 0x0000:0x0769, size: 5
            this.oParent.VGADriver.F0_VGA_115d_GetCharWidth(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa) + 0x10)), this.oCPU.AX.Low);

            xPos += (short)this.oCPU.AX.Word;

        L0774:
            this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));

        L0777:
            this.oCPU.AX.Word = width;
            this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
            if (this.oCPU.Flags.GE) goto L0782;
            goto L06d7;

        L0782:
            this.oCPU.SP.Word = this.oCPU.BP.Word;
            this.oCPU.BP.Word = this.oCPU.PopWord();
            // Far return
            this.oCPU.Log.ExitBlock("F23_0000_06c1");
        }
    }
}
