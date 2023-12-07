using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class MainIntro
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public MainIntro(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F2_0000_0000()
		{
			this.oCPU.Log.EnterBlock("'F2_0000_0000'(Cdecl, Far) at 0x0000:0x0000");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4e);
			this.oCPU.PushWord(this.oCPU.SI.Word);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdeba, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x1);

		L0012:
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x001e); // stack management - push return offset
			// Instruction address 0x0000:0x0019, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0035;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdeba, this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x8);
			if (this.oCPU.Flags.L) goto L0012;

		L0035:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), 0x0);

		L003a:
			// Instruction address 0x0000:0x0041, size: 5
			this.oParent.Segment_1000.F0_1000_066a_FileExists(0x324a);
			
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0051;
			this.oCPU.AX.Word = 0x1;
			goto L0053;

		L0051:
			this.oCPU.AX.Word = 0;

		L0053:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c), this.oCPU.AX.Word);
			
			// Instruction address 0x0000:0x005d, size: 5
			/*Console.SetCursorPosition(0, 12);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x1);

		L006a:
			// Instruction address 0x0000:0x006e, size: 5
			this.oParent.Segment_1199.F0_1199_00ec_WriteToConsole(OpenCiv1.String_3185);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xc);
			if (this.oCPU.Flags.LE) goto L006a;

			// Instruction address 0x0000:0x008a, size: 5
			//this.oParent.Segment_1199.F0_1199_00a1_WriteToConsole(0, 13, OpenCiv1.String_3253);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x0);
			if (this.oCPU.Flags.E) goto L00ae;

			// Instruction address 0x0000:0x00a4, size: 5
			//this.oParent.Segment_1199.F0_1199_00a1_WriteToConsole(27, 16, OpenCiv1.String_3256);
			goto L00e5;

		L00ae:
			// Instruction address 0x0000:0x00b6, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_326b);

			this.oCPU.AX.Word = 0x6;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xdeba);
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba19, this.oCPU.ADDByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0xba19), this.oCPU.AX.Low));

			// Instruction address 0x0000:0x00d8, size: 5
			this.oParent.Segment_1199.F0_1199_00a1_WriteToConsole(29, 16, 
				this.oCPU.ReadString(CPU.ToLinearAddress(this.oCPU.DS.Word, 0xba06)));

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x00e5); // stack management - push return offset
			// Instruction address 0x0000:0x00e0, size: 5
			this.oParent.MSCAPI.getch();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment*/

		//L00e5:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4c)), 0x0);
			if (this.oCPU.Flags.NE) goto L00ee;
			goto L003a;

		L00ee:
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x1a22), 0x6d);
			if (this.oCPU.Flags.E) goto L00fc;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x1a22), 0x4d);
			if (this.oCPU.Flags.NE) goto L0101;

		L00fc:
			this.oCPU.AX.Word = 0x1;
			goto L0103;

		L0101:
			this.oCPU.AX.Word = 0;

		L0103:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xd762, this.oCPU.AX.Word);
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x1a22), 0x65);
			if (this.oCPU.Flags.E) goto L0114;
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, 0x1a22), 0x45);
			if (this.oCPU.Flags.NE) goto L0119;

		L0114:
			this.oCPU.AX.Word = 0x1;
			goto L011b;

		L0119:
			this.oCPU.AX.Word = 0;

		L011b:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xb20e, this.oCPU.AX.Word);

			// Change Num-Lock state			
			/*this.oCPU.BX.Word = 0;
			this.oCPU.ES.Word = this.oCPU.BX.Word;
			this.oCPU.BX.Word = 0x417;
			this.oCPU.WriteUInt8(this.oCPU.ES.Word, this.oCPU.BX.Word, 
				this.oCPU.ANDByte(this.oCPU.ReadUInt8(this.oCPU.ES.Word, this.oCPU.BX.Word), 0xdf));*/

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);
			
			// Instruction address 0x0000:0x0166, size: 5
			//this.oParent.VGADriver.F0_VGA_04e8_InitVGA(0);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6dfc, 0x0);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0180;
			this.oCPU.AX.Word = 0x3;
			goto L0183;

		L0180:
			this.oCPU.AX.Word = 0x4;

		L0183:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x0);
			goto L0196;

		L018d:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6dfc, 0x1);

		L0193:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L0196:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L01be;
			
			// Instruction address 0x0000:0x01a1, size: 5
			this.oParent.VGADriver.F0_VGA_04ae_AllocateScreen(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x32d6, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L018d;

			goto L0193;

		L01be:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x01c3); // stack management - push return offset
			// Instruction address 0x0000:0x01be, size: 5
			this.oParent.Segment_1000.F0_1000_0a2b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x01c8); // stack management - push return offset
			// Instruction address 0x0000:0x01c3, size: 5
			this.oParent.Segment_1000.F0_1000_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x01cd); // stack management - push return offset
			// Instruction address 0x0000:0x01c8, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0042();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x01e0, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L020a;

			// Instruction address 0x0000:0x0202, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19fc),
				0, 0, 0x140, 0xc8, 0);

		L020a:
			// Instruction address 0x0000:0x020e, size: 5
			this.oParent.VGADriver.F0_VGA_010c_SetColorsByIndexArray(0x19fe);
			
			// Instruction address 0x0000:0x0223, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x328a, 1);

			// Instruction address 0x0000:0x023e, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1, 0, 64, 320, 80);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0256, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x3293, 1);

			// Instruction address 0x0000:0x027c, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x4c, 0x140, 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0);

			// Instruction address 0x0000:0x028c, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(2, 0, 0, 0x329e, 1);

			// Instruction address 0x0000:0x02b2, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0, 0x4c, 0x140, 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0, 0xb0);

			// Instruction address 0x0000:0x02be, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x32a9, 1);

			// Instruction address 0x0000:0x02dc, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0xc, 0x140, 0xb0, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x02f9); // stack management - push return offset
			// Instruction address 0x0000:0x02f4, size: 5
			this.oParent.Segment_1000.F0_1000_0382(1, 14, 146, 152);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L031c;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x1);

		L0308:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0310); // stack management - push return offset
			// Instruction address 0x0000:0x030b, size: 5
			this.oParent.Segment_1000.F0_1000_03fa(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x3);
			if (this.oCPU.Flags.LE) goto L0308;

		L031c:
			this.oParent.GameState.GameSettingFlags |= 0x10;

			// Instruction address 0x0000:0x0329, size: 5
			this.oParent.MSCAPI.fopen(OpenCiv1.String_32b5, OpenCiv1.String_32b2);

			this.oParent.Var_d768 = this.oCPU.AX.Word;
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0339); // stack management - push return offset
			// Instruction address 0x0000:0x0334, size: 5
			this.oParent.Segment_1000.F0_1000_033e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.AX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0342); // stack management - push return offset
			// Instruction address 0x0000:0x033d, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x0);
			goto L04d2;

		L0352:
			this.oCPU.AX.Word = 0x7;

		L0355:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0367); // stack management - push return offset
			// Instruction address 0x0000:0x0362, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xb8, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0376;
			this.oCPU.AX.Word = 0xf8;
			goto L0379;

		L0376:
			this.oCPU.AX.Word = 0xf;

		L0379:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x038b); // stack management - push return offset
			// Instruction address 0x0000:0x0386, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xb6, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L039a;
			this.oCPU.AX.Word = 0xfa;
			goto L039d;

		L039a:
			this.oCPU.AX.Word = 0xf;

		L039d:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x03af); // stack management - push return offset
			// Instruction address 0x0000:0x03aa, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xb7, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L03bb:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L03d4;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x0);
			if (this.oCPU.Flags.E) goto L03cf;
			this.oCPU.AX.Word = 0;
			goto L03d2;

		L03cf:
			this.oCPU.AX.Word = 0x3;

		L03d2:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L03d4:
			this.oCPU.AX.Word = 0x140;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x03f4, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x40,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.SI.Word, 0xc);

			// Instruction address 0x0000:0x041a, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0, 0x140, 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x4c);

			// Instruction address 0x0000:0x043a, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x58, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x58,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.SI.Word, 0x64);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L0476;
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			// Instruction address 0x0000:0x045c, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(0,
				0, 0);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0473); // stack management - push return offset
			// Instruction address 0x0000:0x046e, size: 5
			this.oParent.Segment_1000.F0_1000_0846(this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L0476:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x047b); // stack management - push return offset
			// Instruction address 0x0000:0x0476, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x15;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.GE) goto L04a0;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x1);
			if (this.oCPU.Flags.NE) goto L04a0;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L04a0:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x04a5); // stack management - push return offset
			// Instruction address 0x0000:0x04a0, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x15;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.G) goto L04a0;

			// Instruction address 0x0000:0x04c1, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04cf;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x3e7);

		L04cf:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L04d2:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x140);
			if (this.oCPU.Flags.L) goto L04dc;
			goto L0635;

		L04dc:
			this.oCPU.AX.Word = 0x140;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;

			// Instruction address 0x0000:0x04f7, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0, this.oCPU.SI.Word, 0x18, 0);

			// Instruction address 0x0000:0x051a, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x40, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.SI.Word, 0xb0);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xa);
			if (this.oCPU.Flags.NE) goto L053c;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x5);
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L053c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x32);
			if (this.oCPU.Flags.NE) goto L0547;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L0547:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x46);
			if (this.oCPU.Flags.NE) goto L0558;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0558:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x78);
			if (this.oCPU.Flags.NE) goto L0569;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0569:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xa0);
			if (this.oCPU.Flags.NE) goto L0575;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L0575:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xaa);
			if (this.oCPU.Flags.NE) goto L0587;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0587:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xbe);
			if (this.oCPU.Flags.NE) goto L0599;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0599:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd2);
			if (this.oCPU.Flags.NE) goto L05ab;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L05ab:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xe6);
			if (this.oCPU.Flags.NE) goto L05bd;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L05bd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xfa);
			if (this.oCPU.Flags.NE) goto L05cf;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L05cf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x10e);
			if (this.oCPU.Flags.NE) goto L05e1;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L05e1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x122);
			if (this.oCPU.Flags.NE) goto L05f3;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L05f3:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x136);
			if (this.oCPU.Flags.NE) goto L0605;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0605:
			// Instruction address 0x0000:0x0609, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0618;
			goto L03bb;

		L0618:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L062f;
			goto L0352;

		L062f:
			this.oCPU.AX.Word = 0xfc;
			goto L0355;

		L0635:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x0);
			goto L083b;

		L063d:
			this.oCPU.AX.Word = 0x7;

		L0640:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0652); // stack management - push return offset
			// Instruction address 0x0000:0x064d, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xb8, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0661;
			this.oCPU.AX.Word = 0xf8;
			goto L0664;

		L0661:
			this.oCPU.AX.Word = 0xf;

		L0664:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0676); // stack management - push return offset
			// Instruction address 0x0000:0x0671, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xb6, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0685;
			this.oCPU.AX.Word = 0xfa;
			goto L0688;

		L0685:
			this.oCPU.AX.Word = 0xf;

		L0688:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x069a); // stack management - push return offset
			// Instruction address 0x0000:0x0695, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText(0xba06, 0xa0, 0xb7, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L06a6:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L06bf;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x0);
			if (this.oCPU.Flags.E) goto L06ba;
			this.oCPU.AX.Word = 0;
			goto L06bd;

		L06ba:
			this.oCPU.AX.Word = 0x3;

		L06bd:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L06bf:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x140);
			if (this.oCPU.Flags.GE) goto L06ee;

			// Instruction address 0x0000:0x06e6, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)),
				0,
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))),
				0x40,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0xc);

		L06ee:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
			if (this.oCPU.Flags.E) goto L071a;

			// Instruction address 0x0000:0x0712, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0, 0, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x40,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))), 0xc);

		L071a:
			// Instruction address 0x0000:0x0738, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0, 0x140, 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x4c);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x140);
			if (this.oCPU.Flags.GE) goto L0770;

			// Instruction address 0x0000:0x0768, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x58,
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))), 0x58,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x64);

		L0770:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
			if (this.oCPU.Flags.E) goto L079c;

			// Instruction address 0x0000:0x0794, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0, 0x58, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x58,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))), 0x64);

		L079c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L07d0;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			// Instruction address 0x0000:0x07b6, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(0,
				0, 0);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x07cd); // stack management - push return offset
			// Instruction address 0x0000:0x07c8, size: 5
			this.oParent.Segment_1000.F0_1000_0846(this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L07d0:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x07d5); // stack management - push return offset
			// Instruction address 0x0000:0x07d0, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x15;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1a40);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.GE) goto L07fd;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x1);
			if (this.oCPU.Flags.NE) goto L07fd;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L07fd:
			// Instruction address 0x0000:0x07fd, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L082a;
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x080b); // stack management - push return offset
			// Instruction address 0x0000:0x0806, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CX.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = 0x15;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x1a40);
			this.oCPU.BX.Word = this.oCPU.CX.Word;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CX.Word = 0x2;
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.XORWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.BX.Word);
			if (this.oCPU.Flags.G) goto L07fd;

		L082a:
			// Instruction address 0x0000:0x082a, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0838;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x3e7);

		L0838:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L083b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x140);
			if (this.oCPU.Flags.L) goto L0845;
			goto L09d7;

		L0845:
			if (this.oCPU.Flags.GE) goto L0870;

			// Instruction address 0x0000:0x0868, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x40,
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))), 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0);

		L0870:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x0);
			if (this.oCPU.Flags.E) goto L089f;

			// Instruction address 0x0000:0x0897, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19e8),
				0, 0x40, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))), 0xb0);

		L089f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xa);
			if (this.oCPU.Flags.NE) goto L08b0;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L08b0:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x1e);
			if (this.oCPU.Flags.NE) goto L08c1;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L08c1:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x32);
			if (this.oCPU.Flags.NE) goto L08cc;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L08cc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x40);
			if (this.oCPU.Flags.NE) goto L08dd;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L08dd:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x54);
			if (this.oCPU.Flags.NE) goto L08ee;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L08ee:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x74);
			if (this.oCPU.Flags.NE) goto L08f9;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L08f9:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x82);
			if (this.oCPU.Flags.NE) goto L090b;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L090b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x96);
			if (this.oCPU.Flags.NE) goto L091d;

			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L091d:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xaa);
			if (this.oCPU.Flags.NE) goto L092f;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L092f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xbe);
			if (this.oCPU.Flags.NE) goto L0941;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0941:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xd2);
			if (this.oCPU.Flags.NE) goto L0953;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0953:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xe6);
			if (this.oCPU.Flags.NE) goto L0965;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0965:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0xfa);
			if (this.oCPU.Flags.NE) goto L0977;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0977:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x10e);
			if (this.oCPU.Flags.NE) goto L0989;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L0989:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x122);
			if (this.oCPU.Flags.NE) goto L099b;
			
			this.oParent.MSCAPI.fscanf((short)this.oParent.Var_d768, OpenCiv1.String_337b, 0xba06);

		L099b:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x136);
			if (this.oCPU.Flags.NE) goto L09a7;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

		L09a7:
			// Instruction address 0x0000:0x09ab, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L09ba;
			goto L06a6;

		L09ba:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x44), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L09d1;
			goto L063d;

		L09d1:
			this.oCPU.AX.Word = 0xfc;
			goto L0640;

		L09d7:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0xfffe);

			// Instruction address 0x0000:0x09dd, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0a0f;
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0xffff);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x09f1); // stack management - push return offset
			// Instruction address 0x0000:0x09ec, size: 5
			this.oParent.Segment_2d05.F0_2d05_0ac9();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4e);
			if (this.oCPU.Flags.E) goto L0a09;
			if (this.oCPU.Flags.G) goto L0a3d;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x43);
			if (this.oCPU.Flags.E) goto L0a35;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x45);
			if (this.oCPU.Flags.E) goto L0a2d;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x4c);
			if (this.oCPU.Flags.E) goto L0a25;
			goto L0a0f;

		L0a09:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0x0);

		L0a0f:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x6b32), 0xfffe);
			if (this.oCPU.Flags.E) goto L0a19;
			goto L0b26;

		L0a19:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0a1e); // stack management - push return offset
			// Instruction address 0x0000:0x0a19, size: 5
			this.oParent.Segment_1000.F0_1000_0a4e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xd00); // !!! was 0xd87
			if (this.oCPU.Flags.GE) goto L0a53;
			goto L0a19;

		L0a25:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0x1);
			goto L0a0f;

		L0a2d:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0x2);
			goto L0a0f;

		L0a35:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0x3);
			goto L0a0f;

		L0a3d:
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x63);
			if (this.oCPU.Flags.E) goto L0a35;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x65);
			if (this.oCPU.Flags.E) goto L0a2d;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x6c);
			if (this.oCPU.Flags.E) goto L0a25;
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x6e);
			if (this.oCPU.Flags.E) goto L0a09;
			goto L0a0f;

		L0a53:
			// Instruction address 0x0000:0x0a6b, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x0a81, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x40,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0ab4;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0aa5); // stack management - push return offset
			// Instruction address 0x0000:0x0aa0, size: 5
			this.oParent.Segment_1000.F0_1000_0382(4, 14, 224, 239);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0ab1); // stack management - push return offset
			// Instruction address 0x0000:0x0aac, size: 5
			this.oParent.Segment_1000.F0_1000_03fa(4);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L0ab4:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x0);

		L0ab9:
			// Instruction address 0x0000:0x0ad7, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x40, 0x4, 0x50,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x40);

			// Instruction address 0x0000:0x0ae3, size: 5
			this.oParent.Segment_1182.F0_1182_0134(1);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 
				this.oCPU.ADDWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x4));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x140);
			if (this.oCPU.Flags.L) goto L0ab9;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x0);
			goto L0b0c;

		L0afd:
			// Instruction address 0x0000:0x0b01, size: 5
			this.oParent.Segment_1182.F0_1182_0134(5);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L0b0c:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x64);
			if (this.oCPU.Flags.GE) goto L0b1b;

			// Instruction address 0x0000:0x0b12, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0afd;

		L0b1b:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0b20); // stack management - push return offset
			// Instruction address 0x0000:0x0b1b, size: 5
			this.oParent.Segment_1403.F0_1403_4545();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0x6b32, 0xffff);

		L0b26:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0b4a;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), 0x1);
			goto L0b37;

		L0b34:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48))));

		L0b37:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)), 0x4);
			if (this.oCPU.Flags.G) goto L0b52;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0b45); // stack management - push return offset
			// Instruction address 0x0000:0x0b40, size: 5
			this.oParent.Segment_1000.F0_1000_042b(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x48)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			goto L0b34;

		L0b4a:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

		L0b52:
			// Instruction address 0x0000:0x0b65, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8, 0);

			// Instruction address 0x0000:0x0b7b, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x40,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));

			// Instruction address 0x0000:0x0b8b, size: 5
			this.oParent.VGADriver.F0_VGA_06b7_DrawScreenToMainScreen(1, 0x14);

			// Instruction address 0x0000:0x0bab, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0bbb); // stack management - push return offset
			// Instruction address 0x0000:0x0bb6, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4e)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0bcf); // stack management - push return offset
			// Instruction address 0x0000:0x0bca, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F2_0000_0000'");
		}

		public void F2_0000_0bd7(short playerID)
		{
			this.oCPU.Log.EnterBlock("'F2_0000_0bd7'(Cdecl, Far) at 0x0000:0x0bd7");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x246);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0bee); // stack management - push return offset
			// Instruction address 0x0000:0x0be9, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			// Instruction address 0x0000:0x0bf9, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x32d8, 0);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), 0x0);

		L0c0c:
			// Instruction address 0x0000:0x0c39, size: 5
			this.oParent.VGADriver.F0_VGA_0b85_ScreenToBitmap(1,
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)) % 6) * 0x32) + 1),
				(ushort)(((this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)) / 6) * 0x32) + 1),
				0x31, 0x31);

			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x238), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x18);
			if (this.oCPU.Flags.L) goto L0c0c;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0c60); // stack management - push return offset
			// Instruction address 0x0000:0x0c5b, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0c6c;
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x246), 0xec);
			// Instruction address 0x0000:0x0c83, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0xec);

			goto L0c6e;

		L0c6c:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x246), 0);
			// Instruction address 0x0000:0x0c83, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0);

		L0c6e:			
			// Instruction address 0x0000:0x0c93, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x32e4, 1);

			// Instruction address 0x0000:0x0cb6, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x18, 0x140, 0xb0,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0);

			// Instruction address 0x0000:0x0cdc, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x20, 0x140, 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0cf2); // stack management - push return offset
			// Instruction address 0x0000:0x0ced, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L0d17;

			// Instruction address 0x0000:0x0d0f, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19fc),
				0, 0, 0x140, 0xc8, 0);

		L0d17:
			// Instruction address 0x0000:0x0d2b, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x246)));

			// Instruction address 0x0000:0x0d4a, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0xc, 0x140, 0xb0,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x246)));

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].GovernmentType;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0d66, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19b2)));

			// Instruction address 0x0000:0x0d76, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_32f0);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x0d8c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			// Instruction address 0x0000:0x0d9c, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8), 0xba06);

			this.oCPU.SI.Word = (ushort)playerID;
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			// Instruction address 0x0000:0x0db1, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30ba), 
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1982)));

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0dd7, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].SpaceshipPopulation, 10));

			// Instruction address 0x0000:0x0de7, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30bc), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0e0d, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Players[playerID].SpaceshipLaunchYear, 10));

			// Instruction address 0x0000:0x0e1d, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);

			// Instruction address 0x0000:0x0e43, size: 5
			this.oParent.MSCAPI.strcat(0xba06,
				this.oParent.MSCAPI.itoa(this.oParent.GameState.Year, 10));

			// Instruction address 0x0000:0x0e53, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30c0), 0xba06);

			if (playerID != this.oParent.GameState.HumanPlayerID) goto L0e68;
			this.oCPU.AX.Word = 0x32f2;
			goto L0e6b;

		L0e68:
			this.oCPU.AX.Word = 0x32f9;

		L0e6b:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3301;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0e75); // stack management - push return offset
			// Instruction address 0x0000:0x0e70, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_01ad();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0e7d); // stack management - push return offset
			// Instruction address 0x0000:0x0e78, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0471();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x0e86, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x200), 0xba06);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x242), 0xfff6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x244), 0x5c);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23c), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x0eb2, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240), this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0ec7); // stack management - push return offset
			// Instruction address 0x0000:0x0ec2, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), 0x0);
			goto L10cc;

		L0ed8:
			this.oCPU.AX.Word = 0x7;

		L0edb:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0ef1); // stack management - push return offset
			// Instruction address 0x0000:0x0eec, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23c))),
				0xa0, 0xb8, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L0f00;
			this.oCPU.AX.Word = 0x3c;
			goto L0f03;

		L0f00:
			this.oCPU.AX.Word = 0xf;

		L0f03:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x0f19); // stack management - push return offset
			// Instruction address 0x0000:0x0f14, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23c))),
				0xa0, 0xb7, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23a));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L0f26:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x208), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x208))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x208)), 0x17);
			if (this.oCPU.Flags.L) goto L0f37;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x208), 0x0);

		L0f37:
			// Instruction address 0x0000:0x0f4d, size: 5
			this.oParent.Segment_1000.F0_1000_084d_DrawBitmapToScreen(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0x87, 0x33,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 
					(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x208)) << 1) - 0x238)));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L0f6e;
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x0);
			if (this.oCPU.Flags.E) goto L0f69;
			this.oCPU.AX.Word = 0;
			goto L0f6c;

		L0f69:
			this.oCPU.AX.Word = 0x3;

		L0f6c:
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);

		L0f6e:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x140);
			if (this.oCPU.Flags.GE) goto L0f95;

			// Instruction address 0x0000:0x0f8d, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0xc, 0x13f, 0x14,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x246)));

		L0f95:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x0);
			if (this.oCPU.Flags.E) goto L0fc4;

			// Instruction address 0x0000:0x0fbc, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x14,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))), 0xc);

		L0fc4:
			// Instruction address 0x0000:0x0fe2, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0, 0x140, 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x20);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x140);
			if (this.oCPU.Flags.GE) goto L1015;

			// Instruction address 0x0000:0x100d, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0x38,
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))),
				0x84,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x246)));

		L1015:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x0);
			if (this.oCPU.Flags.E) goto L1047;

			// Instruction address 0x0000:0x103f, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0,0x2c, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x84,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))), 0x38);

		L1047:
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x1);
			if (this.oCPU.Flags.E) goto L106f;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x242), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x242))));

			// Instruction address 0x0000:0x1067, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x242)) - this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)),
				this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x244)),
				15);

		L106f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x242), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x242))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L10a9;
			
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			// Instruction address 0x0000:0x108e, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(0,
				0, 0);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23a));
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x10a6); // stack management - push return offset
			// Instruction address 0x0000:0x10a1, size: 5
			this.oParent.Segment_1000.F0_1000_0846(this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L10a9:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0xc);
			if (this.oCPU.Flags.LE) goto L10be;
			this.oCPU.TESTByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x1);
			if (this.oCPU.Flags.NE) goto L10be;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))));

		L10be:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x5c);
			this.oCPU.CMPWord(this.oCPU.AX.Word, 0x8);
			if (this.oCPU.Flags.L) goto L10be;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))));

		L10cc:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x140);
			if (this.oCPU.Flags.L) goto L10d7;
			goto L119f;

		L10d7:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x10dc); // stack management - push return offset
			// Instruction address 0x0000:0x10d7, size: 5
			this.oParent.Segment_1000.F0_1000_033e();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x140);
			if (this.oCPU.Flags.GE) goto L1107;

			// Instruction address 0x0000:0x10ff, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0xb0,
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))),
				0x18,
				this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x246)));

		L1107:
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x0);
			if (this.oCPU.Flags.E) goto L1139;

			// Instruction address 0x0000:0x1131, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x14, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x18,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				(ushort)(0x140 - this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))), 0xb0);

		L1139:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e));
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.CX.Word = 0x16;
			this.oCPU.IDIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.CX.Word);
			this.oCPU.DX.Word = this.oCPU.ORWord(this.oCPU.DX.Word, this.oCPU.DX.Word);
			if (this.oCPU.Flags.NE) goto L1174;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23c), this.oCPU.AX.Word);

		L1150:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204))));
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x5e);
			if (this.oCPU.Flags.E) goto L1167;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1150;

		L1167:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L1174;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L1174:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1181;
			goto L0f26;

		L1181:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23a), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L1199;
			goto L0ed8;

		L1199:
			this.oCPU.AX.Word = 0x38;
			goto L0edb;

		L119f:
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x238)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x11a8); // stack management - push return offset
			// Instruction address 0x0000:0x11a3, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_0523();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
			
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x11bb); // stack management - push return offset
			// Instruction address 0x0000:0x11b6, size: 5
			this.oParent.Segment_1000.F0_1000_0846(0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba07);
			// Instruction address 0x0000:0x11cb, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x200), this.oCPU.AX.Word);

			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240), this.oCPU.SUBWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240)), this.oCPU.AX.Word));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204), 0xffff);

			if (playerID == this.oParent.GameState.HumanPlayerID) goto L11ed;
			goto L1350;

		L11ed:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x11fc); // stack management - push return offset
			// Instruction address 0x0000:0x11f7, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			// Instruction address 0x0000:0x1207, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x330a, 0);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1218); // stack management - push return offset
			// Instruction address 0x0000:0x1213, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L1233;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1230); // stack management - push return offset
			// Instruction address 0x0000:0x122b, size: 5
			this.oParent.Segment_1000.F0_1000_04d4(5, 0, 0, 0);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

		L1233:
			// Instruction address 0x0000:0x1246, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0);

			// Instruction address 0x0000:0x1252, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(-1, 0, 0, 0x3316, 1);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1268); // stack management - push return offset
			// Instruction address 0x0000:0x1263, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = 0x22;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1274); // stack management - push return offset
			// Instruction address 0x0000:0x126f, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x128f, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L12a1;
			goto L137e;

		L12a1:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x12b6); // stack management - push return offset
			// Instruction address 0x0000:0x12b1, size: 5
			this.oParent.Segment_1000.F0_1000_0382(1, 15, 16, 31);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x12ce); // stack management - push return offset
			// Instruction address 0x0000:0x12c9, size: 5
			this.oParent.Segment_1000.F0_1000_0382(2, 100, 32, 34);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x12e6); // stack management - push return offset
			// Instruction address 0x0000:0x12e1, size: 5
			this.oParent.Segment_1000.F0_1000_0382(3, 42, 35, 40);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x12fe); // stack management - push return offset
			// Instruction address 0x0000:0x12f9, size: 5
			this.oParent.Segment_1000.F0_1000_0382(4, 300, 41, 47);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1316); // stack management - push return offset
			// Instruction address 0x0000:0x1311, size: 5
			this.oParent.Segment_1000.F0_1000_0382(5, 60, 48, 53);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x132e); // stack management - push return offset
			// Instruction address 0x0000:0x1329, size: 5
			this.oParent.Segment_1000.F0_1000_0382(6, 37, 54, 63);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), 0x1);

		L1337:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1340); // stack management - push return offset
			// Instruction address 0x0000:0x133b, size: 5
			this.oParent.Segment_1000.F0_1000_03fa(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x6);
			if (this.oCPU.Flags.LE) goto L1337;
			goto L137e;

		L1350:
			this.oParent.Overlay_17.F17_0000_07ec(1);

			// Instruction address 0x0000:0x1376, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

		L137e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23c), this.oCPU.AX.Word);

		L1387:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204))));
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x200)), 0x5e);
			if (this.oCPU.Flags.E) goto L139e;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240));
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L1387;

		L139e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L13b1;
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.WriteUInt8(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + this.oCPU.SI.Word - 0x200), 0x0);

		L13b1:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L13be;
			goto L145f;

		L13be:
			// Instruction address 0x0000:0x13d6, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0x20,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x13f8); // stack management - push return offset
			// Instruction address 0x0000:0x13f3, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(this.oCPU.BP.Word + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23c)) - 0x200),
				0xa0, 5, 0xb);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1415); // stack management - push return offset
			// Instruction address 0x0000:0x1410, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(this.oCPU.BP.Word + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23c)) - 0x200),
				0xa0, 4, 0xf);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			// Instruction address 0x0000:0x1428, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(0x118,
				0x20, 15);

			// Instruction address 0x0000:0x1434, size: 5
			this.oParent.Segment_1182.F0_1182_0134(80);

			// Instruction address 0x0000:0x144b, size: 5
			this.oParent.Segment_1000.F0_1000_104f_SetPixel(0x118,
				0x20, 0);

			// Instruction address 0x0000:0x1457, size: 5
			this.oParent.Segment_1182.F0_1182_0134(80);

		L145f:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x240));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L146c;
			goto L137e;

		L146c:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1471); // stack management - push return offset
			// Instruction address 0x0000:0x146c, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			if (playerID != this.oParent.GameState.HumanPlayerID) goto L149d;

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L149d;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), 0x1);

		L1486:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x148f); // stack management - push return offset
			// Instruction address 0x0000:0x148a, size: 5
			this.oParent.Segment_1000.F0_1000_042b(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e))));

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x23e)), 0x6);
			if (this.oCPU.Flags.LE) goto L1486;

		L149d:
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x14ae); // stack management - push return offset
			// Instruction address 0x0000:0x14a9, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			
			// Instruction address 0x0000:0x14b5, size: 5
			this.oParent.MSCAPI.fclose((short)this.oParent.Var_d768);

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.NE) goto L1500;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x7;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x14dc); // stack management - push return offset
			// Instruction address 0x0000:0x14d7, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			// Instruction address 0x0000:0x14e7, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(3, 0, 0, 0x3322, 0);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x14fd); // stack management - push return offset
			// Instruction address 0x0000:0x14f8, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

		L1500:
			// Instruction address 0x0000:0x1513, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1520); // stack management - push return offset
			// Instruction address 0x0000:0x151b, size: 5
			this.oParent.Segment_1238.F0_1238_1beb();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1525); // stack management - push return offset
			// Instruction address 0x0000:0x1520, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_05dd();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F2_0000_0bd7'");
		}

		public void F2_0000_152a()
		{
			this.oCPU.Log.EnterBlock("'F2_0000_152a'(Cdecl, Far) at 0x0000:0x152a");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1535); // stack management - push return offset
			// Instruction address 0x0000:0x1530, size: 5
			this.oParent.Segment_2dc4.F0_2dc4_065f();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x6;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1544); // stack management - push return offset
			// Instruction address 0x0000:0x153f, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			// Instruction address 0x0000:0x155a, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0);

			this.oCPU.AX.Word = 0x23;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x156b); // stack management - push return offset
			// Instruction address 0x0000:0x1566, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x1576, size: 5
			this.oParent.ImageTools.F0_2fa1_01a2_LoadBitmapOrPalette(1, 0, 0, 0x332e, 1);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.PushWord(this.oCPU.DX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x158c); // stack management - push return offset
			// Instruction address 0x0000:0x1587, size: 5
			this.oParent.Segment_11a8.F0_11a8_02a4();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			// Instruction address 0x0000:0x15a7, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0, 0x140, 0xc8,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0);

			this.oCPU.BX.Word = (ushort)this.oParent.GameState.HumanPlayerID;
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			// Instruction address 0x0000:0x15bd, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x19a2)));

			// Instruction address 0x0000:0x15c9, size: 5
			this.oParent.MSCAPI.strupr(0xba06);

			// Instruction address 0x0000:0x15d9, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30b8), 0xba06);

			// Instruction address 0x0000:0x15e9, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3337);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0);

		L15f6:
			// Instruction address 0x0000:0x15fd, size: 5
			this.oCPU.AX.Word = this.oParent.Segment_1ade.F0_1ade_22b5_PlayerHasTechnology(this.oParent.GameState.HumanPlayerID, this.oCPU.ReadInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E)
				goto L161f;

			this.oCPU.AX.Word = 0x16;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x4da);
			// Instruction address 0x0000:0x1617, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

		L161f:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x48);
			if (this.oCPU.Flags.L) goto L15f6;

			// Instruction address 0x0000:0x1630, size: 5
			this.oParent.MSCAPI.strcpy(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x30be), 0xba06);

			this.oCPU.WriteUInt8(this.oCPU.DS.Word, 0xba06, 0x0);
			this.oCPU.AX.Word = 0x3342;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0x3348;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x164a); // stack management - push return offset
			// Instruction address 0x0000:0x1645, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_01ad();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1652); // stack management - push return offset
			// Instruction address 0x0000:0x164d, size: 5
			this.oParent.Segment_2f4d.F0_2f4d_0471();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x6);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x0000:0x1668, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

		L1673:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

		L167a:
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06)), 0x5e);
			if (this.oCPU.Flags.E) goto L168e;
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L167a;

		L168e:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.BX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L169a;
			this.oCPU.WriteUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba06), 0x0);

		L169a:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L16a5;
			goto L1762;

		L16a5:
			// Instruction address 0x0000:0x16c3, size: 5
			this.oParent.VGADriver.F0_VGA_07d8_DrawImage(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0x19d4),
				0, 0x6, 0x140, 0x14,
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 6);

			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd762), 0x0);
			if (this.oCPU.Flags.E) goto L170d;

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x16ea); // stack management - push return offset
			// Instruction address 0x0000:0x16e5, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))),
				0xa0, 7, 0xf);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1705); // stack management - push return offset
			// Instruction address 0x0000:0x1700, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))),
				0xa0, 9, 0xd);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.AX.Word = 0xe;
			goto L172b;

		L170d:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1725); // stack management - push return offset
			// Instruction address 0x0000:0x1720, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))),
				0xa0, 9, 1);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.AX.Word = 0x9;

		L172b:
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1740); // stack management - push return offset
			// Instruction address 0x0000:0x173b, size: 5
			this.oParent.Segment_1182.F0_1182_00b3_DrawCenteredText((ushort)(0xba06 + this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))),
				0xa0, 8, this.oCPU.AX.Word);
			this.oCPU.PopDWord(); // stack management - pop return offset and segment

			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.CMPByte(this.oCPU.ReadUInt8(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xba05)), 0x21);
			if (this.oCPU.Flags.E) goto L1762;

			// Instruction address 0x0000:0x174d, size: 5
			this.oParent.MSCAPI.kbhit();

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L1762;

			// Instruction address 0x0000:0x175a, size: 5
			this.oParent.Segment_1182.F0_1182_0134(200);

		L1762:
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.GE) goto L176d;
			goto L1673;

		L176d:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1776); // stack management - push return offset
			// Instruction address 0x0000:0x1771, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			this.oCPU.AX.Word = 0x3a;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX,
				(ushort)this.oParent.GameState.Players[this.oParent.GameState.HumanPlayerID].LeaderGraphics);
			this.oCPU.BX.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x1518)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1791); // stack management - push return offset
			// Instruction address 0x0000:0x178c, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x1798, size: 5
			this.oParent.Segment_1182.F0_1182_0134(300);

			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x17a9); // stack management - push return offset
			// Instruction address 0x0000:0x17a4, size: 5
			this.oParent.Segment_11a8.F0_11a8_046c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

			// Instruction address 0x0000:0x17bf, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa_FillRectangle(
				this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa),
				0, 0, 0x140, 0xc8, 0);

			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x17cc); // stack management - push return offset
			// Instruction address 0x0000:0x17c7, size: 5
			this.oParent.Segment_1238.F0_1238_1beb();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.BX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10), 0x1);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F2_0000_152a'");
		}

		public void F2_0000_17d9()
		{
			this.oCPU.Log.EnterBlock("'F2_0000_17d9'(Cdecl, Far) at 0x0000:0x17d9");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x17e5); // stack management - push return offset
			// Instruction address 0x0000:0x17e0, size: 5
			this.oParent.Segment_11a8.F0_11a8_0268();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd4cc);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x7);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xd75e);
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x6);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x1);

		L17fc:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x180e); // stack management - push return offset
			// Instruction address 0x0000:0x1809, size: 5
			this.oParent.Segment_2e31.F0_2e31_119b();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadUInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc)));
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1827); // stack management - push return offset
			// Instruction address 0x0000:0x1822, size: 5
			this.oParent.Segment_2aea.F0_2aea_134a();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);

			this.oCPU.AX.Word = 0x13;
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x282);
			// Instruction address 0x0000:0x183d, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1853); // stack management - push return offset
			// Instruction address 0x0000:0x184e, size: 5
			this.oParent.Segment_2aea.F0_2aea_1836();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L186c;

			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0x366);
			// Instruction address 0x0000:0x1864, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, this.oCPU.AX.Word);

		L186c:
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x187a); // stack management - push return offset
			// Instruction address 0x0000:0x1875, size: 5
			this.oParent.Segment_2aea.F0_2aea_1894();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L1891;

			// Instruction address 0x0000:0x1889, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3351);

		L1891:
			this.oCPU.SI.Word = this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SI.Word = this.oCPU.SHLWord(this.oCPU.SI.Word, 0x1);

			F2_0000_195a(
				(short)((this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) << 4) + 200),
				(short)((this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)) << 4) + 112),
				(short)((this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x1882)) << 6) + 170),
				(short)((this.oCPU.ReadInt16(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x18e4)) * 48) + 100));

			this.oCPU.WriteUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 
				this.oCPU.INCWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6))));
			this.oCPU.CMPWord(this.oCPU.ReadUInt16(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), 0x8);
			if (this.oCPU.Flags.G) goto L18d6;
			goto L17fc;

		L18d6:
			// Instruction address 0x0000:0x18de, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3359);

			F2_0000_195a(160, 6, 200, 16);

			// Instruction address 0x0000:0x1905, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_3362);

			F2_0000_195a(48, 32, 88, 24);

			// Instruction address 0x0000:0x192c, size: 5
			this.oParent.MSCAPI.strcpy(0xba06, OpenCiv1.String_336d);

			F2_0000_195a(40, 128, 88, 170);
			
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1950); // stack management - push return offset
			// Instruction address 0x0000:0x194b, size: 5
			this.oParent.Segment_11a8.F0_11a8_0250();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x1955); // stack management - push return offset
			// Instruction address 0x0000:0x1950, size: 5
			this.oParent.Segment_2459.F0_2459_0918_WaitForKeyPressOrMouseClick();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F2_0000_17d9'");
		}

		public void F2_0000_195a(short xPos1, short yPos1, short xPos2, short yPos2)
		{
			this.oCPU.Log.EnterBlock("'F2_0000_195a'(Cdecl, Far) at 0x0000:0x195a");

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			
			// Instruction address 0x0000:0x1971, size: 5
			this.oParent.VGADriver.F0_VGA_0599_DrawLine(
				new CivRectangle(this.oCPU, CPU.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.ReadUInt16(this.oCPU.DS.Word, 0xaa))),
				xPos1, yPos1, xPos2, (short)(yPos2 + 6), 15);

			// Instruction address 0x0000:0x1981, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_3379);

			this.oCPU.WriteUInt16(this.oCPU.DS.Word, 0xdb38, 0x1);

			this.oCPU.PushWord((ushort)yPos2);
			this.oCPU.PushWord((ushort)xPos2);
			this.oCPU.AX.Word = 0xba06;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0); // stack management - push return segment, ignored
			this.oCPU.PushWord(0x199e); // stack management - push return offset
			// Instruction address 0x0000:0x1999, size: 5
			this.oParent.Segment_2d05.F0_2d05_0018();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);

			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F2_0000_195a'");
		}
	}
}
