using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class NSound
	{
		private OpenCiv1 oParent;
		private CPU oCPU;
		private ushort usBufferPosition = 0;

		public NSound(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_0048()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0048'(Cdecl, Far) at 0x0000:0x0048");

			// function body
			usBufferPosition = 0x0;
			this.oCPU.AX.Word = 0x0;

			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0048'");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_0055()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0055'(Cdecl, Far) at 0x0000:0x0055");

			// function body
			usBufferPosition++;
			this.oCPU.AX.Word = 0x0;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0055'");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_0000_005c()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_005c'(Cdecl, Far) at 0x0000:0x005c");

			// function body
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_005c'");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_005d()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_005d'(Cdecl, Far) at 0x0000:0x005d");

			// function body
			this.oCPU.AX.Word = usBufferPosition;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_005d'");

			return this.oCPU.AX.Word;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="param1"></param>
		/// <param name="param2"></param>
		public void F0_0000_0062(ushort param1, ushort param2)
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0062'(Cdecl, Far) at 0x0000:0x0062");

			// function body
			usBufferPosition = 0x0;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0062'");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_006a()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_006a'(Cdecl, Far) at 0x0000:0x006a");

			// function body
			this.oCPU.AX.Word = 0x0;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_006a'");

			return this.oCPU.AX.Word;
		}
	}
}
