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
			//this.oCPU.Log.EnterBlock("'F0_0000_0048'(Cdecl, Far) at 0x0000:0x0048");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, 0x0);
			this.oCPU.AX.Word = 0x0;

			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0048'");
		}

		public void F0_0000_0055()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0055'(Cdecl, Far) at 0x0000:0x0055");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, this.oCPU.INCWord(this.oCPU.ReadWord(this.oCPU.CS.Word, 0x74)));
			this.oCPU.AX.Word = 0x0;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0055'");
		}

		public void F0_0000_005c()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_005c'(Cdecl, Far) at 0x0000:0x005c");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_005c'");
		}

		public void F0_0000_005d()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_005d'(Cdecl, Far) at 0x0000:0x005d");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = this.oCPU.ReadWord(this.oCPU.CS.Word, 0x74);
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_005d'");
		}

		public void F0_0000_0062()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0062'(Cdecl, Far) at 0x0000:0x0062");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.WriteWord(this.oCPU.CS.Word, 0x74, 0x0);
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0062'");
		}

		public void F0_0000_006a()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_006a'(Cdecl, Far) at 0x0000:0x006a");
			this.oCPU.CS.Word = this.usSegment; // set this function segment

			// function body
			this.oCPU.AX.Word = 0x0;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_006a'");
		}
	}
}
