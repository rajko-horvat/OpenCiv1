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
			this.oParent.LogWriteLine("Entering function 'F0_0000_0048'(Cdecl) at 0x0000:0x0048, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, 0x0);
			this.oCPU.PushWord(0x0052); // stack management - push return offset
			// Instruction address 0x0000:0x004f, size: 3
			F0_0000_006d();
			this.oCPU.PopWord(); // stack management - pop return offset
			this.oCPU.AX.Word = 0x0;
			this.oParent.LogWriteLine("Exiting function 'F0_0000_0048'");
		}

		public void F0_0000_0055()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_0055'(Cdecl) at 0x0000:0x0055, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x74)));
			this.oCPU.AX.Word = 0x0;
			this.oParent.LogWriteLine("Exiting function 'F0_0000_0055'");
		}

		public void F0_0000_005c()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_005c'(Cdecl) at 0x0000:0x005c, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oParent.LogWriteLine("Exiting function 'F0_0000_005c'");
		}

		public void F0_0000_005d()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_005d'(Cdecl) at 0x0000:0x005d, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x74);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_005d'");
		}

		public void F0_0000_0062()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_0062'(Cdecl) at 0x0000:0x0062, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, 0x0);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_0062'");
		}

		public void F0_0000_006a()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_006a'(Cdecl) at 0x0000:0x006a, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			this.oParent.LogWriteLine("Exiting function 'F0_0000_006a'");
		}

		public void F0_0000_006d()
		{
			this.oParent.LogWriteLine("Entering function 'F0_0000_006d'(Cdecl) at 0x0000:0x006d, stack: 0x0");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Low = this.oCPU.INByte(0x61);
			this.oCPU.AX.Low = this.oCPU.ANDByte(this.oCPU.AX.Low, 0xfc);
			this.oCPU.OUTByte(0x61, this.oCPU.AX.Low);
			this.oParent.LogWriteLine("Exiting function 'F0_0000_006d'");
		}
	}
}
