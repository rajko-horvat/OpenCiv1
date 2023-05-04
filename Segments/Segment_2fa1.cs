using Disassembler;

namespace Civilization1
{
	public class Segment_2fa1
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_2fa1(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_2fa1_000a()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_000a'(Cdecl) at 0x2fa1:0x000a, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x1a);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0x1a));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x001b); // stack management - push return offset
			// Instruction address 0x2fa1:0x0018, size: 3
			F0_2fa1_0728();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0048;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0030); // stack management - push return offset
			// Instruction address 0x2fa1:0x002d, size: 3
			F0_2fa1_085a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0041;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x003e); // stack management - push return offset
			// Instruction address 0x2fa1:0x003b, size: 3
			F0_2fa1_066e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L0041:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_000a'");
			return;

		L0048:
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI._dos_open(CPUMemory.ToLinearAddress(this.oCPU.DS.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6))),
				this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)),
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0068;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0065); // stack management - push return offset
			// Instruction address 0x2fa1:0x0062, size: 3
			F0_2fa1_066e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L0068:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_000a'");
		}

		public void F0_2fa1_009e()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_009e'(Cdecl) at 0x2fa1:0x009e, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L00c2;
			this.oCPU.AX.Word = (ushort)this.oParent.MSCAPI._dos_close((short)this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L00c2;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x00bf); // stack management - push return offset
			// Instruction address 0x2fa1:0x00bc, size: 3
			F0_2fa1_066e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L00c2:
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_009e'");
		}

		public void F0_2fa1_01a2()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_01a2'(Cdecl) at 0x2fa1:0x01a2, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x01b4); // stack management - push return offset
			// Instruction address 0x2fa1:0x01b1, size: 3
			F0_2fa1_000a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x01bf); // stack management - push return offset
			// Instruction address 0x2fa1:0x01bc, size: 3
			F0_2fa1_05e0();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x01ca); // stack management - push return offset
			// Instruction address 0x2fa1:0x01c5, size: 5
			this.oParent.Segment_1000.F0_1000_108e();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x0);
			if (this.oCPU.Flags.GE) goto L01d9;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68e4, 0x0);

		L01d9:
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			this.oCPU.DI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			goto L0207;

		L01e0:
			this.oCPU.AX.Word = 0xe17e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x01e9); // stack management - push return offset
			// Instruction address 0x2fa1:0x01e4, size: 5
			this.oParent.Segment_1000.F0_1000_1208();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68e2));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.ADDWord(this.oCPU.AX.Word, this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.AX.Word = 0xe17e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x0203); // stack management - push return offset
			// Instruction address 0x2fa1:0x01fe, size: 5
			this.oParent.Segment_1000.F0_1000_07f4();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);

		L0207:
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68e4));
			if (this.oCPU.Flags.L) goto L01e0;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0217); // stack management - push return offset
			// Instruction address 0x2fa1:0x0214, size: 3
			F0_2fa1_009e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_01a2'");
		}

		public void F0_2fa1_0220()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_0220'(Cdecl) at 0x2fa1:0x0220, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0235); // stack management - push return offset
			// Instruction address 0x2fa1:0x0232, size: 3
			F0_2fa1_01a2();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0220'");
		}

		public void F0_2fa1_0254()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_0254'(Cdecl) at 0x2fa1:0x0254, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0266); // stack management - push return offset
			// Instruction address 0x2fa1:0x0263, size: 3
			F0_2fa1_01a2();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0254'");
		}

		public void F0_2fa1_026c()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_026c'(Cdecl) at 0x2fa1:0x026c, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0282); // stack management - push return offset
			// Instruction address 0x2fa1:0x027f, size: 3
			F0_2fa1_01a2();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_026c'");
		}

		public void F0_2fa1_0288()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_0288'(Cdecl) at 0x2fa1:0x0288, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = 0xffff;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x029d); // stack management - push return offset
			// Instruction address 0x2fa1:0x029a, size: 3
			F0_2fa1_01a2();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0288'");
		}

		public void F0_2fa1_044c()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_044c'(Cdecl) at 0x2fa1:0x044c, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x045d); // stack management - push return offset
			// Instruction address 0x2fa1:0x045a, size: 3
			F0_2fa1_000a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0468); // stack management - push return offset
			// Instruction address 0x2fa1:0x0465, size: 3
			F0_2fa1_05e0();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x0473); // stack management - push return offset
			// Instruction address 0x2fa1:0x046e, size: 5
			this.oParent.Segment_1000.F0_1000_108e();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68e4));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68e2));
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x0483); // stack management - push return offset
			// Instruction address 0x2fa1:0x047e, size: 5
			this.oParent.Segment_1000.F0_1000_0864();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.SI.Word = this.oCPU.SUBWord(this.oCPU.SI.Word, this.oCPU.SI.Word);
			goto L04a3;

		L048a:
			this.oCPU.AX.Word = 0xe17e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x0493); // stack management - push return offset
			// Instruction address 0x2fa1:0x048e, size: 5
			this.oParent.Segment_1000.F0_1000_1208();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0xe17e;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x049f); // stack management - push return offset
			// Instruction address 0x2fa1:0x049a, size: 5
			this.oParent.Segment_1000.F0_1000_085d();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.SI.Word = this.oCPU.INCWord(this.oCPU.SI.Word);

		L04a3:
			this.oCPU.CMPWord(this.oCPU.SI.Word, this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68e4));
			if (this.oCPU.Flags.L) goto L048a;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.SI.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x04b3); // stack management - push return offset
			// Instruction address 0x2fa1:0x04b0, size: 3
			F0_2fa1_009e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x04bb); // stack management - push return offset
			// Instruction address 0x2fa1:0x04b6, size: 5
			this.oParent.Segment_1000.F0_1000_0856();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_044c'");
		}

		public void F0_2fa1_04c0()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_04c0'(Cdecl) at 0x2fa1:0x04c0, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x04cd); // stack management - push return offset
			// Instruction address 0x2fa1:0x04ca, size: 3
			F0_2fa1_0220();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_04c0'");
		}

		public void F0_2fa1_05e0()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_05e0'(Cdecl) at 0x2fa1:0x05e0, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68da, this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x5528);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xb26e, this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd91a, 0x644);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xd91c, 0x2fa1);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_05e0'");
		}

		public void F0_2fa1_0644()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_0644'(Cdecl) at 0x2fa1:0x0644, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = this.oParent.MSCAPI._dos_read((short)this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68da), 
				CPUMemory.ToLinearAddress(this.oCPU.DS.Word, 0xd936), 
				0x200,
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0xb26e, 0xd936);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0644'");
		}

		public void F0_2fa1_066e()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_066e'(Cdecl) at 0x2fa1:0x066e, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = 0x3;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0679); // stack management - push return offset
			// Instruction address 0x2fa1:0x0676, size: 3
			F0_2fa1_0696();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x0684); // stack management - push return offset
			// Instruction address 0x2fa1:0x067f, size: 5
			this.oParent.MSCAPI.perror();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.AX.Word = 0x63;
			this.oParent.MSCAPI.exit((short)this.oCPU.AX.Word);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_066e'");
		}

		public void F0_2fa1_0696()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_0696'(Cdecl) at 0x2fa1:0x0696, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x10);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x58fb);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10), this.oCPU.AX.Word);
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xd), 0x0);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteByte(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), this.oCPU.AX.Low);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.AX.Word = 0x10;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x06bd); // stack management - push return offset
			// Instruction address 0x2fa1:0x06b8, size: 5
			this.oParent.MSCAPI.int86();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x10));
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x58fb, this.oCPU.AX.Word);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0696'");
		}

		public void F0_2fa1_0728()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_0728'(Cdecl) at 0x2fa1:0x0728, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(this.oCPU.SI.Word);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a), 0xffff);
			if (this.oCPU.Flags.NE) goto L0740;

		L0737:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0728'");
			return;

		L0740:
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x074c); // stack management - push return offset
			// Instruction address 0x2fa1:0x0749, size: 3
			F0_2fa1_085a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L075d;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x075a); // stack management - push return offset
			// Instruction address 0x2fa1:0x0757, size: 3
			F0_2fa1_066e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L075d:
			this.oCPU.AX.Word = this.oParent.MSCAPI._dos_read((short)this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a),
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)),
				0x2,
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xa);

			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L0784;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0781); // stack management - push return offset
			// Instruction address 0x2fa1:0x077e, size: 3
			F0_2fa1_066e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L0784:
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)), 0x0);
			if (this.oCPU.Flags.NE) goto L07e8;
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x68e0, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68e0)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0x68e0);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4)), this.oCPU.AX.Word);
			if (this.oCPU.Flags.L) goto L0737;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L07de;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DS.Word);
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

		L07ac:
			this.oCPU.AX.Word = this.oParent.MSCAPI._dos_read((short)this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a),
				CPUMemory.ToLinearAddress(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))),
				0x18,
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L07d4;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x07d1); // stack management - push return offset
			// Instruction address 0x2fa1:0x07ce, size: 3
			F0_2fa1_066e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L07d4:
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L07ac;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SI.Word);

		L07de:
			this.oCPU.AX.Word = 0x1;
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0728'");
			return;

		L07e8:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.DECWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L07f5;
			goto L0737;

		L07f5:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.DS.Word);
			this.oCPU.DI.Word = this.oCPU.AX.Word;
			this.oCPU.SI.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));

		L0803:
			this.oCPU.AX.Word = this.oParent.MSCAPI._dos_read((short)this.oCPU.ReadWord(this.oCPU.DS.Word, 0x552a),
				CPUMemory.ToLinearAddress(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8))),
				0x18,
				CPUMemory.ToLinearAddress(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.E) goto L082b;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0828); // stack management - push return offset
			// Instruction address 0x2fa1:0x0825, size: 3
			F0_2fa1_066e();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);

		L082b:
			this.oCPU.AX.Word = 0xc;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.DI.Word);
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x0838); // stack management - push return offset
			// Instruction address 0x2fa1:0x0833, size: 5
			this.oParent.MSCAPI.strnicmp();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L084c;
			this.oCPU.AX.Word = 0x1;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SI.Word);
			this.oCPU.SI.Word = this.oCPU.PopWord();
			this.oCPU.DI.Word = this.oCPU.PopWord();
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_0728'");
			return;

		L084c:
			this.oCPU.AX.Word = this.oCPU.SI.Word;
			this.oCPU.SI.Word = this.oCPU.DECWord(this.oCPU.SI.Word);
			this.oCPU.AX.Word = this.oCPU.ORWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			if (this.oCPU.Flags.NE) goto L0803;
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.SI.Word);
			goto L0737;
		}

		public void F0_2fa1_085a()
		{
			this.oParent.LogWriteLine("Entering function 'F0_2fa1_085a'(Cdecl) at 0x2fa1:0x085a, stack: 0x0");
			this.oCPU.CS.Word = 0x2fa1; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0xe);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe), 0x4200);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xc), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xa), this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x8), this.oCPU.AX.Word);
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord((ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.PushWord(0x2fa1); // stack management - push return segment
			this.oCPU.PushWord(0x0884); // stack management - push return offset
			// Instruction address 0x2fa1:0x087f, size: 5
			this.oParent.MSCAPI.intdos();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x2fa1; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)), 0x0);
			if (this.oCPU.Flags.NE) goto L0894;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_085a'");
			return;

		L0894:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0xe));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_2fa1_085a'");
		}
	}
}
