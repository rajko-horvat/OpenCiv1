using Disassembler;

namespace Civilization1
{
	public class Segment_3045
	{
		private Civilization oParent;
		private CPU oCPU;

		public Segment_3045(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void Start()
		{
			this.oCPU.Log.EnterBlock("'Start'(Cdecl, Far) at 0x3045:0x2e7f");
			this.oCPU.CS.Word = 0x3045; // set this function segment

			// function body
			this.oCPU.PushWord(this.oCPU.DS.Word);
			this.oCPU.AX.Word = 0x3b01;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.AX.High = 0x30;
			this.oCPU.INT(0x21);
			this.oCPU.CMPByte(this.oCPU.AX.Low, 0x2);
			if (this.oCPU.Flags.AE) goto L2e98;
			this.oCPU.DX.Word = 0x61a6;
			this.oCPU.PushWord(0x2e93); // stack management - push return offset
			// Instruction address 0x3045:0x2e90, size: 3
			this.oParent.MSCAPI.F0_3045_2b12();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.AX.Word = 0x0;
			this.oCPU.PushWord(this.oCPU.AX.Word);
			// Far return
			this.oCPU.Log.ExitBlock("'Start'");
			return;

		L2e98:
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x592c, 0x1);
			this.oCPU.DI.Word = 0x63db;
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.WriteByte(this.oCPU.DS.Word, 0x592d, this.oCPU.AX.Low);
			this.oCPU.PushWord(this.oCPU.ES.Word);
			this.oCPU.AX.High = 0x35;
			this.oCPU.INT(0x21);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x592e, this.oCPU.BX.Word);
			this.oCPU.WriteWord(this.oCPU.DS.Word, 0x5930, this.oCPU.ES.Word);
			this.oCPU.AX.Low = this.oCPU.ReadByte(this.oCPU.DS.Word, this.oCPU.DI.Word);
			this.oCPU.DX.Word = this.oCPU.CS.Word;
			this.oCPU.DS.Word = this.oCPU.DX.Word;
			this.oCPU.DX.Word = 0x2d5a;
			this.oCPU.AX.High = 0x25;
			this.oCPU.INT(0x21);
			this.oCPU.AX.Word = 0x3b01;
			this.oCPU.DS.Word = this.oCPU.AX.Word;
			this.oCPU.ES.Word = this.oCPU.PopWord();
			this.oCPU.PushWord(0x2ec8); // stack management - push return offset
			// Instruction address 0x3045:0x2ec5, size: 3
			this.oParent.MSCAPI.F0_3045_2ed2();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.DS.Word = this.oCPU.PopWord();
			this.oCPU.AX.Word = this.oCPU.DS.Word;
			this.oCPU.ES.Word = this.oCPU.AX.Word;
			// Instruction address 0x3045:0x2ecd, size: 5
			this.oParent.MSCAPI.F0_3045_0014();
			this.oCPU.Log.ExitBlock("'Start'");
			return;
		}
	}
}
