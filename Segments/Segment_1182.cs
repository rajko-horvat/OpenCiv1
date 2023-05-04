using Disassembler;

namespace Civilization1
{
	public class Segment_1182
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_1182(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_1182_000a()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_000a'(Cdecl) at 0x1182:0x000a, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x1182); // stack management - push return segment
			this.oCPU.PushWord(0x0025); // stack management - push return offset
			// Instruction address 0x1182:0x0020, size: 5
			this.oParent.Segment_1000.F0_1000_100a();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_000a'");
		}

		public void F0_1182_002a()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_002a'(Cdecl) at 0x1182:0x002a, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xc), this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.CMPWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0x6b8c), 0x0);
			if (this.oCPU.Flags.E) goto L004e;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));
			this.oCPU.AX.Word = this.oCPU.SHLWord(this.oCPU.AX.Word, 0x1);
			goto L0051;

		L004e:
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8));

		L0051:
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.BX.Word);
			this.oCPU.PushWord(0x1182); // stack management - push return segment
			this.oCPU.PushWord(0x0058); // stack management - push return offset
			// Instruction address 0x1182:0x0053, size: 5
			this.oParent.Segment_1000.F0_1000_0802();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_002a'");
		}

		public void F0_1182_005c()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_005c'(Cdecl) at 0x1182:0x005c, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xa), 0x0);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x0078); // stack management - push return offset
			// Instruction address 0x1182:0x0075, size: 3
			F0_1182_002a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xa), 0x1);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_005c'");
		}

		public void F0_1182_0086()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_0086'(Cdecl) at 0x1182:0x0086, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x009b); // stack management - push return offset
			// Instruction address 0x1182:0x0098, size: 3
			F0_1182_005c();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x00ae); // stack management - push return offset
			// Instruction address 0x1182:0x00ab, size: 3
			F0_1182_005c();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_0086'");
		}

		public void F0_1182_00b3()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_00b3'(Cdecl) at 0x1182:0x00b3, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x00bd); // stack management - push return offset
			// Instruction address 0x1182:0x00ba, size: 3
			F0_1182_00ef();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x2);
			this.oCPU.CWD(this.oCPU.AX, this.oCPU.DX);
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.DX.Word);
			this.oCPU.AX.Word = this.oCPU.SARWord(this.oCPU.AX.Word, 0x1);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8), this.oCPU.SUBWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)), this.oCPU.AX.Word));
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xa), 0x0);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.CS.Word);
			this.oCPU.PushWord(0x00e1); // stack management - push return offset
			// Instruction address 0x1182:0x00de, size: 3
			F0_1182_002a();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x8);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.WriteWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0xa), 0x1);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_00b3'");
		}

		public void F0_1182_00ef()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_00ef'(Cdecl) at 0x1182:0x00ef, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.SP.Word = this.oCPU.SUBWord(this.oCPU.SP.Word, 0x6);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.AX.Word);
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.DS.Word, (ushort)(this.oCPU.BX.Word + 0x10));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2), this.oCPU.AX.Word);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), 0x0); // Segment
			goto L0125;

		L010c:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4), this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4))));
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word);
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x2)));
			this.oCPU.PushWord(0x1182); // stack management - push return segment
			this.oCPU.PushWord(0x011f); // stack management - push return offset
			// Instruction address 0x1182:0x011a, size: 5
			this.oParent.Segment_1000.F0_1000_078b();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0x4);
			this.oCPU.WriteWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6), this.oCPU.ADDWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6)), this.oCPU.AX.Word));

		L0125:
			this.oCPU.BX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x4));
			this.oCPU.CMPByte(this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.BX.Word), 0x0);
			if (this.oCPU.Flags.NE) goto L010c;
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word - 0x6));
			this.oCPU.SP.Word = this.oCPU.BP.Word;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_00ef'");
		}

		public void F0_1182_0134()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_0134'(Cdecl) at 0x1182:0x0134, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(0x1182); // stack management - push return segment
			this.oCPU.PushWord(0x013c); // stack management - push return offset
			// Instruction address 0x1182:0x0137, size: 5
			this.oParent.Segment_1000.F0_1000_033e();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment

		L013c:
			this.oCPU.PushWord(0x1182); // stack management - push return segment
			this.oCPU.PushWord(0x0141); // stack management - push return offset
			// Instruction address 0x1182:0x013c, size: 5
			this.oParent.Segment_1000.F0_1000_033a();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment
			this.oCPU.CMPWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			if (this.oCPU.Flags.L) goto L013c;
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_0134'");
		}

		public void F0_1182_0148()
		{
			this.oParent.LogWriteLine("Entering function 'F0_1182_0148'(Cdecl) at 0x1182:0x0148, stack: 0x0");
			this.oCPU.CS.Word = 0x1182; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.BP.Word);
			this.oCPU.BP.Word = this.oCPU.SP.Word;
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xe)));
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xc));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0xa));
			this.oCPU.AX.Word = this.oCPU.SUBWord(this.oCPU.AX.Word, this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.AX.Word = this.oCPU.INCWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.AX.Word);
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x8)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.SS.Word, (ushort)(this.oCPU.BP.Word + 0x6)));
			this.oCPU.PushWord(this.oCPU.ReadWord(this.oCPU.DS.Word, 0xaa));
			this.oCPU.PushWord(0x1182); // stack management - push return segment
			this.oCPU.PushWord(0x016d); // stack management - push return offset
			// Instruction address 0x1182:0x0168, size: 5
			this.oParent.Segment_1000.F0_1000_0bfa();
			this.oCPU.PopDWord(); // stack management - pop return offset, segment
			this.oCPU.CS.Word = 0x1182; // restore this function segment
			this.oCPU.SP.Word = this.oCPU.ADDWord(this.oCPU.SP.Word, 0xc);
			this.oCPU.BP.Word = this.oCPU.PopWord();
			this.oParent.LogWriteLine("Exiting function 'F0_1182_0148'");
		}
	}
}
