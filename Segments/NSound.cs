using Disassembler;

namespace Civilization1
{
	public class NSound
	{
		private Civilization oParent;
		private CPU oCPU;
		private ushort usSegment = 0;

		public NSound(Civilization parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public ushort Segment
		{
			get { return this.usSegment; }
			set { this.usSegment = value; }
		}

		public void F0_0000_0048()
		{
			//this.oParent.LogEnterBlock("'F0_0000_0048'(Cdecl, Far) at 0x0000:0x0048");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, 0x0);
			this.oCPU.PushWord(0x0052); // stack management - push return offset
			// Instruction address 0x0000:0x004f, size: 3
			F0_0000_006d();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0x0;
			// Far return
			//this.oParent.LogExitBlock("'F0_0000_0048'");
		}

		public void F0_0000_0055()
		{
			//this.oParent.LogEnterBlock("'F0_0000_0055'(Cdecl, Far) at 0x0000:0x0055");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x74)));
			this.oCPU.AX.Word = 0x0;
			// Far return
			//this.oParent.LogExitBlock("'F0_0000_0055'");
		}

		public void F0_0000_005c()
		{
			//this.oParent.LogEnterBlock("'F0_0000_005c'(Cdecl, Far) at 0x0000:0x005c");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			// Far return
			//this.oParent.LogExitBlock("'F0_0000_005c'");
		}

		public void F0_0000_005d()
		{
			//this.oParent.LogEnterBlock("'F0_0000_005d'(Cdecl, Far) at 0x0000:0x005d");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x74);
			// Far return
			//this.oParent.LogExitBlock("'F0_0000_005d'");
		}

		public void F0_0000_0062()
		{
			//this.oParent.LogEnterBlock("'F0_0000_0062'(Cdecl, Far) at 0x0000:0x0062");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, 0x0);
			// Far return
			//this.oParent.LogExitBlock("'F0_0000_0062'");
		}

		public void F0_0000_006a()
		{
			//this.oParent.LogEnterBlock("'F0_0000_006a'(Cdecl, Far) at 0x0000:0x006a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			// Far return
			//this.oParent.LogExitBlock("'F0_0000_006a'");
		}

		public void F0_0000_006d()
		{
			//this.oParent.LogEnterBlock("'F0_0000_006d'(Cdecl, Near) at 0x0000:0x006d");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Low = this.oCPU.INByte(0x61);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfc);
			this.oCPU.OUTByte(0x61, this.oCPU.AX.Low);
			// Near return
			//this.oParent.LogExitBlock("'F0_0000_006d'");
		}
	}
}
