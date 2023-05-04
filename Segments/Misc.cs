using Disassembler;

namespace Civilization1
{
	public class Misc
	{
		private Civilization oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

		public Misc(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F0_0000_0042()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_0042'(Cdecl) at 0x0000:0x0042, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = 0x1;
			this.oCPU.INT(0x21);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_0042'");
		}

		public void F0_0000_0047()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_0047'(Cdecl) at 0x0000:0x0047, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.INT(0x16);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_0047'");
		}

		public void F0_0000_004c()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_004c'(Cdecl) at 0x0000:0x004c, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = 0x1;
			this.oCPU.INT(0x16);
			if (this.oCPU.Flags.E) goto L0055;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_004c'");
			return;

		L0055:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.NOTWord(this.oCPU.AX.Word);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_004c'");
		}

		public void F0_0000_005a()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_005a'(Cdecl) at 0x0000:0x005a, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.ES.Word, 0x417);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xf0);
			this.oCPU.WriteByte(this.oCPU.ES.Word, 0x417, this.oCPU.AX.Low);
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_0000_005a'");
		}

		public void F0_0000_006c()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_006c'(Cdecl) at 0x0000:0x006c, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = this.oCPU.SP.Word;
			this.oCPU.DX.Word = 0x201;
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.AX.Low = this.oCPU.NOTByte(this.oCPU.AX.Low);
			this.oCPU.CX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x4));
			this.oCPU.CX.Word = this.oCPU.ADDWord(this.oCPU.CX.Word, 0x4);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, this.oCPU.CX.Low);
			this.oCPU.AX.Word = this.oCPU.ANDWord(this.oCPU.AX.Word, 0x1);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_006c'");
		}

		public void F0_0000_0080()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_0080'(Cdecl) at 0x0000:0x0080, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x15; // Segment
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(0x0089); // stack management - push return offset
			// Instruction address 0x0000:0x0086, size: 3
			F0_0000_00c4();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = 0x0;
			this.oCPU.PushWord(0x008f); // stack management - push return offset
			// Instruction address 0x0000:0x008c, size: 3
			F0_0000_0097();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = 0x1;
			this.oCPU.PushWord(0x0095); // stack management - push return offset
			// Instruction address 0x0000:0x0092, size: 3
			F0_0000_0097();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_0000_0080'");
		}

		public void F0_0000_0097()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_0097'(Cdecl) at 0x0000:0x0097, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x78));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x70), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x60), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x68), this.oCPU.AX.Word);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_0097'");
		}

		public void F0_0000_00aa()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_00aa'(Cdecl) at 0x0000:0x00aa, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x15; // Segment
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.PushWord(0x00b3); // stack management - push return offset
			// Instruction address 0x0000:0x00b0, size: 3
			F0_0000_00c4();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = 0x0;
			this.oCPU.PushWord(0x00b9); // stack management - push return offset
			// Instruction address 0x0000:0x00b6, size: 3
			F0_0000_00f1();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.BX.Word = 0x1;
			this.oCPU.PushWord(0x00bf); // stack management - push return offset
			// Instruction address 0x0000:0x00bc, size: 3
			F0_0000_00f1();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x80);
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_0000_00aa'");
		}

		public void F0_0000_00c4()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_00c4'(Cdecl) at 0x0000:0x00c4, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BX.Word = 0x0;
			this.oCPU.BP.Word = 0x0;
			this.oCPU.CX.Word = 0xffff;
			this.oCPU.DX.Word = 0x201;
			this.oCPU.OUTByte(this.oCPU.DX.Word, this.oCPU.AX.Low);

		L00d5:
			this.oCPU.AX.Low = this.oCPU.INByte(this.oCPU.DX.Word);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0x3);
			if (this.oCPU.Flags.E) goto L00e6;
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BX.Word = this.oCPU.ADCWord(this.oCPU.BX.Word, 0x0);
			this.oCPU.AX.Low = this.oCPU.SHRByte(this.oCPU.AX.Low, 0x1);
			this.oCPU.BP.Word = this.oCPU.ADCWord(this.oCPU.BP.Word, 0x0);
			if (this.oCPU.Loop(this.oCPU.CX)) goto L00d5;

		L00e6:
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x78, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x7a, this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_0000_00c4'");
		}

		public void F0_0000_00f1()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_00f1'(Cdecl) at 0x0000:0x00f1, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.BX.Word = this.oCPU.SHLWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x78));
			this.oCPU.DX.Word = this.oCPU.AX.Word;
			this.oCPU.DX.Word = this.oCPU.SUBWord(this.oCPU.DX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x70)));
			if (this.oCPU.Flags.B) goto L0106;
			if (this.oCPU.Flags.A) goto L0128;
			this.oCPU.AX.High = 0x0;
			goto L0143;

		L0106:
			this.oCPU.DX.Word = this.oCPU.NEGWord(this.oCPU.DX.Word);
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x60)));
			if (this.oCPU.Flags.A) goto L011b;
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x60), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x50), this.oCPU.DX.Word);
			this.oCPU.AX.High = 0x81;
			goto L0143;

		L011b:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x50)));
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.AX.Word = this.oCPU.NEGWord(this.oCPU.AX.Word);
			goto L0143;

		L0128:
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x68)));
			if (this.oCPU.Flags.B) goto L013b;
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x68), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x58), this.oCPU.DX.Word);
			this.oCPU.AX.High = 0x7f;
			goto L0143;

		L013b:
			this.oCPU.AX.Word = 0x0;
			this.oCPU.DIVWord(this.oCPU.AX, this.oCPU.DX, this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x58)));
			this.oCPU.AX.Word = this.oCPU.SHRWord(this.oCPU.AX.Word, 0x1);

		L0143:
			this.oCPU.BX.Word = this.oCPU.SHRWord(this.oCPU.BX.Word, 0x1);
			this.oCPU.WriteByte(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x80), this.oCPU.AX.High);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_00f1'");
		}
	}
}
