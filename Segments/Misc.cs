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
			this.oParent.LogEnterBlock("'F0_0000_0042'(Cdecl, Far) at 0x0000:0x0042");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = 0x1;
			this.oCPU.INT(0x21);
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0042'");
		}

		public void F0_0000_0047()
		{
			this.oParent.LogEnterBlock("'F0_0000_0047'(Cdecl, Far) at 0x0000:0x0047");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.High = this.oCPU.SUBByte(this.oCPU.AX.High, this.oCPU.AX.High);
			this.oCPU.INT(0x16);
			// Far return
			this.oParent.LogExitBlock("'F0_0000_0047'");
		}
	}
}
