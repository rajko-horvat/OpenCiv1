using Disassembler;

namespace OpenCiv1
{
	public class Segment_2f4d
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Segment_2f4d(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_2f4d_0000()
		{
			this.oCPU.Log.EnterBlock("'F0_2f4d_0000'(Cdecl, Far) at 0x2f4d:0x0000");
			this.oCPU.CS.Word = 0x2f4d; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			goto L005d;

		L0012:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0x5e);
			if (this.oCPU.Flags.NE) goto L002b;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), 0x20);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f9), 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xffff);

		L002b:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0xa);
			if (this.oCPU.Flags.NE) goto L0037;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0xffff);

		L0037:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2))));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.LE) goto L005a;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0x20);
			if (this.oCPU.Flags.NE) goto L005a;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45f9)), 0x20);
			if (this.oCPU.Flags.E) goto L005a;
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), 0xa);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), 0x0);

		L005a:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));

		L005d:
			// Instruction address 0x2f4d:0x0061, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.G) goto L0012;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.LE) goto L0084;

			// Instruction address 0x2f4d:0x007c, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_2fee);

		L0084:
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2f4d_0000'");
		}

		public void F0_2f4d_0088()
		{
			this.oCPU.Log.EnterBlock("'F0_2f4d_0088'(Cdecl, Far) at 0x2f4d:0x0088");
			this.oCPU.CS.Word = 0x2f4d; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);

			// Instruction address 0x2f4d:0x00a0, size: 5
			this.oParent.VGADriver.F0_VGA_11ae_GetTextHeight(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0x10)));

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), 0x0);
			goto L00b5;

		L00b2:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))));

		L00b5:
			// Instruction address 0x2f4d:0x00b9, size: 5
			this.oParent.MSCAPI.strlen(0xba06);

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8)));
			if (this.oCPU.Flags.G) goto L00c9;
			goto L017b;

		L00c9:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa));

			// Instruction address 0x2f4d:0x00d9, size: 5
			this.oParent.VGADriver.F0_VGA_115d_GetCharWidth(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa) + 0x10)), this.oCPU.AX.Low);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0x20);
			if (this.oCPU.Flags.E) goto L00fc;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0xa);
			if (this.oCPU.Flags.E) goto L00fc;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0x5e);
			if (this.oCPU.Flags.NE) goto L0101;

		L00fc:
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.AX.Word);

		L0101:
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0xa);
			if (this.oCPU.Flags.E) goto L011b;
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0x5e);
			if (this.oCPU.Flags.E) goto L011b;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CX.Low = 0x3;
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, this.oCPU.CX.Low);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			if (this.oCPU.Flags.GE) goto L00b2;

		L011b:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), 0x0);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba06);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0140); // stack management - push return offset
			// Instruction address 0x2f4d:0x013b, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2f4d; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa), this.oCPU.AX.Low);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), 0x0);
			this.oCPU.AX.Word = this.oCPU.BX.Word;
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word - 0x45fa)), 0x5e);
			if (this.oCPU.Flags.NE) goto L016b;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc))));

		L016b:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0xc0);
			if (this.oCPU.Flags.G) goto L017b;
			goto L00b2;

		L017b:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), 0x0);
			if (this.oCPU.Flags.LE) goto L01a6;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), 0xc0);
			if (this.oCPU.Flags.G) goto L01a6;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, 0xba06);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x019d); // stack management - push return offset
			// Instruction address 0x2f4d:0x0198, size: 5
			this.oParent.Segment_1182.F0_1182_005c();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2f4d; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)), this.oCPU.AX.Word));

		L01a6:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2f4d_0088'");
		}

		public void F0_2f4d_01ad()
		{
			this.oCPU.Log.EnterBlock("'F0_2f4d_01ad'(Cdecl, Far) at 0x2f4d:0x01ad");
			this.oCPU.CS.Word = 0x2f4d; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x110);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.AX.Word);
			goto L01d9;

		L01c5:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106));
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word));
			this.oCPU.CBW(this.oCPU.AX);
			this.oCPU.IMULWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102)), this.oCPU.AX.Word));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106))));

		L01d9:
			// Instruction address 0x2f4d:0x01dc, size: 5
			this.oParent.MSCAPI.strlen(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x106)));
			if (this.oCPU.Flags.G) goto L01c5;
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x101), 0x0);

		L01ef:
			// Instruction address 0x2f4d:0x01f6, size: 5
			this.oParent.MSCAPI.fopen(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 
				OpenCiv1.String_2ff0);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110), this.oCPU.AX.Word);

			// Instruction address 0x2f4d:0x0226, size: 5
			this.oParent.MSCAPI.fseek((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				(((int)((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102))) >> 5) +
					this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102))) << 1,
				0);

			// Instruction address 0x2f4d:0x023f, size: 5
			this.oParent.MSCAPI.fread((ushort)(this.oCPU.BP.Word - 0x104), 2, 1, 
				(short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));
			
			// Instruction address 0x2f4d:0x024b, size: 5
			this.oParent.MSCAPI.fclose((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));
			
			// Instruction address 0x2f4d:0x025a, size: 5
			this.oParent.MSCAPI.fopen(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 
				OpenCiv1.String_2ff3);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 0x1ff);
			if (this.oCPU.Flags.BE) goto L02bc;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 0x3030);
			if (this.oCPU.Flags.E) goto L02bc;

			// Instruction address 0x2f4d:0x0282, size: 5
			this.oParent.MSCAPI.fseek((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104)), 0);

			// Instruction address 0x2f4d:0x0297, size: 5
			this.oParent.MSCAPI.fscanf((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				OpenCiv1.String_2ff6, (ushort)(this.oCPU.BP.Word - 0x100));

			// Instruction address 0x2f4d:0x02a7, size: 5
			this.oParent.MSCAPI.stricmp((ushort)(this.oCPU.BP.Word - 0x100), 
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L02b6;
			goto L0392;

		L02b6:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e), 0x1);

		L02bc:
			this.oCPU.AX.Word = 0;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c), this.oCPU.AX.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0323;

			// Instruction address 0x2f4d:0x02d7, size: 5
			this.oParent.MSCAPI.fseek((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				0x200, (short)this.oCPU.AX.Word);

		L02df:
			// Instruction address 0x2f4d:0x02e3, size: 5
			this.oParent.MSCAPI.ftell((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x104), this.oCPU.AX.Word);

			// Instruction address 0x2f4d:0x02fc, size: 5
			this.oParent.MSCAPI.fscanf((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				OpenCiv1.String_2ffd, (ushort)(this.oCPU.BP.Word - 0x100));

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a), this.oCPU.AX.Word);

			// Instruction address 0x2f4d:0x0310, size: 5
			this.oParent.MSCAPI.stricmp((ushort)(this.oCPU.BP.Word - 0x100), 
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0323;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L02df;

		L0323:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a)), 0xffff);
			if (this.oCPU.Flags.NE) goto L032d;
			goto L03af;

		L032d:
			// Instruction address 0x2f4d:0x033a, size: 5
			this.oParent.MSCAPI.fscanf((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				OpenCiv1.String_3004, (ushort)(this.oCPU.BP.Word - 0x100));

			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100)), 0x2a);
			if (this.oCPU.Flags.E) goto L032d;

		L0349:
			// Instruction address 0x2f4d:0x0352, size: 5
			this.oParent.MSCAPI.strcat(0xba06, (ushort)(this.oCPU.BP.Word - 0x100));

			// Instruction address 0x2f4d:0x0362, size: 5
			this.oParent.MSCAPI.strcat(0xba06, OpenCiv1.String_300b);

			// Instruction address 0x2f4d:0x0377, size: 5
			this.oParent.MSCAPI.fscanf((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				OpenCiv1.String_300d, (ushort)(this.oCPU.BP.Word - 0x100));

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c))));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x100)), 0x2a);
			if (this.oCPU.Flags.NE) goto L0349;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0x1);
			goto L03b5;

		L0392:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102));
			this.oCPU.AX.High = 0;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102), this.oCPU.AX.Word);
			
			// Instruction address 0x2f4d:0x03a4, size: 5
			this.oParent.MSCAPI.fclose((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));
			goto L01ef;

		L03af:
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108), 0x0);

		L03b5:
			// Instruction address 0x2f4d:0x03b9, size: 5
			this.oParent.MSCAPI.fclose((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));

			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10e)), 0x0);
			if (this.oCPU.Flags.NE) goto L043a;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x0);
			if (this.oCPU.Flags.E) goto L043a;
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10a)), 0xffff);
			if (this.oCPU.Flags.E) goto L043a;

			// Instruction address 0x2f4d:0x03dd, size: 5
			this.oParent.MSCAPI.fopen(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 
				OpenCiv1.String_3014);

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110), this.oCPU.AX.Word);


			// Instruction address 0x2f4d:0x040d, size: 5
			this.oParent.MSCAPI.fseek((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)),
				((int)((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102))) >> 5 +
					this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x102))) << 1,
				0);

			// Instruction address 0x2f4d:0x0426, size: 5
			this.oParent.MSCAPI.fwrite((ushort)(this.oCPU.BP.Word - 0x104), 2, 1,
				(short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));
			
			// Instruction address 0x2f4d:0x0432, size: 5
			this.oParent.MSCAPI.fclose((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x110)));

		L043a:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x108)), 0x0);
			if (this.oCPU.Flags.E) goto L0447;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10c));
			goto L044a;

		L0447:
			this.oCPU.AX.Word = 0xffff;

		L044a:
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2f4d_01ad'");
		}

		public void F0_2f4d_044f()
		{
			this.oCPU.Log.EnterBlock("'F0_2f4d_044f'(Cdecl, Far) at 0x2f4d:0x044f");
			this.oCPU.CS.Word = 0x2f4d; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = 0x30a5;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x045d); // stack management - push return offset
			// Instruction address 0x2f4d:0x045a, size: 3
			F0_2f4d_01ad();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2f4d; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x0464); // stack management - push return offset
			// Instruction address 0x2f4d:0x0461, size: 3
			F0_2f4d_0471();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2f4d; // restore this function segment
			this.oCPU.AX.Word = 0x50;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x046c); // stack management - push return offset
			// Instruction address 0x2f4d:0x0469, size: 3
			F0_2f4d_0000();
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2f4d; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2f4d_044f'");
		}

		public void F0_2f4d_0471()
		{
			this.oCPU.Log.EnterBlock("'F0_2f4d_0471'(Cdecl, Far) at 0x2f4d:0x0471");
			this.oCPU.CS.Word = 0x2f4d; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x204);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204), 0x0);

		L0480:
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204));
			this.oCPU.SI.Word <<= 1;
			// Instruction address 0x2f4d:0x048e, size: 5
			this.oParent.MSCAPI.strstr(0xba06, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x30ae)));

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L04e0;

			// Instruction address 0x2f4d:0x04a3, size: 5
			this.oParent.MSCAPI.strcpy((ushort)(this.oCPU.BP.Word - 0x202), this.oCPU.AX.Word);

			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.WriteByte(this.oCPU.DS.Word, this.oCPU.BX.Word, 0x0);

			// Instruction address 0x2f4d:0x04b9, size: 5
			this.oParent.MSCAPI.strcat(0xba06, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x30b8)));

			// Instruction address 0x2f4d:0x04c5, size: 5
			this.oParent.MSCAPI.strlen(this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.SI.Word + 0x30ae)));

			this.oCPU.DI.Word = this.oCPU.AX.Word;
			// Instruction address 0x2f4d:0x04d8, size: 5
			this.oParent.MSCAPI.strcat(0xba06, (ushort)(this.oCPU.BP.Word + this.oCPU.DI.Word - 0x202));

		L04e0:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0480;

			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204), 
				this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204))));

			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x204)), 0x5);
			if (this.oCPU.Flags.L) goto L0480;

			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2f4d_0471'");
		}

		public void F0_2f4d_04f7()
		{
			this.oCPU.Log.EnterBlock("'F0_2f4d_04f7'(Cdecl, Far) at 0x2f4d:0x04f7");
			this.oCPU.CS.Word = 0x2f4d; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.SI.Word);
			goto L0537;

		L04fd:
			// Instruction address 0x2f4d:0x0500, size: 5
			this.oParent.MSCAPI.strlen(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x3)), 0x20);
			if (this.oCPU.Flags.E) goto L0525;

			// Instruction address 0x2f4d:0x0514, size: 5
			this.oParent.MSCAPI.strlen(this.oCPU.BX.Word);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x2), 0x2e);

		L0525:
			// Instruction address 0x2f4d:0x0526, size: 5
			this.oParent.MSCAPI.strlen(this.oCPU.BX.Word);

			this.oCPU.SI.Word = this.oCPU.AX.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + this.oCPU.SI.Word - 0x1), 0x0);

		L0537:
			this.oCPU.PushWord(this.oCPU.CS.Word); // stack management - push return segment
			this.oCPU.PushWord(0x053f); // stack management - push return offset
			// Instruction address 0x2f4d:0x053a, size: 5
			this.oParent.Segment_1182.F0_1182_00ef_GetStringWidth(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PopDWord(); // stack management - pop return offset and segment
			this.oCPU.CS.Word = 0x2f4d; // restore this function segment

			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			if (this.oCPU.Flags.G) goto L04fd;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.BP.Word = this.oCPU.PopWord();
			// Far return
			this.oCPU.Log.ExitBlock("'F0_2f4d_04f7'");
		}
	}
}
