using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class NSound
	{
		private OpenCiv1Game oParent;
		private VCPU oCPU;
		private GameData oGameData;

		private ushort usBufferPosition = 0;

		public NSound(OpenCiv1Game parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
			this.oGameData = parent.GameData;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_0048_InitSound()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0048_InitSound'(Cdecl, Far) at 0x0000:0x0048");

			// function body
			usBufferPosition = 0x0;
			this.oCPU.AX.UInt16 = 0x0;

			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0048_InitSound'");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_0055_SoundWorker()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0055_SoundWorker'(Cdecl, Far) at 0x0000:0x0055");

			// function body
			usBufferPosition++;
			
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0055_SoundWorker'");

			return 0;
		}

		/// <summary>
		/// ?
		/// </summary>
		public void F0_0000_005c_FastSoundWorker()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_005c_FastSoundWorker'(Cdecl, Far) at 0x0000:0x005c");

			// function body
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_005c_FastSoundWorker'");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_005d_SoundTimer()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_005d_SoundTimer'(Cdecl, Far) at 0x0000:0x005d");

			// function body
			this.oCPU.AX.UInt16 = usBufferPosition;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_005d_SoundTimer'");

			return this.oCPU.AX.UInt16;
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <param name="tune"></param>
		/// <param name="param2"></param>
		public void F0_0000_0062_PlayTune(short tune, ushort param2)
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_0062_PlayTune'(Cdecl, Far) at 0x0000:0x0062");

			// function body
			usBufferPosition = 0x0;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_0062_PlayTune'");
		}

		/// <summary>
		/// ?
		/// </summary>
		/// <returns></returns>
		public ushort F0_0000_006a_CloseSound()
		{
			//this.oCPU.Log.EnterBlock("'F0_0000_006a_CloseSound'(Cdecl, Far) at 0x0000:0x006a");

			// function body
			this.oCPU.AX.UInt16 = 0x0;
			// Far return
			//this.oCPU.Log.ExitBlock("'F0_0000_006a_CloseSound'");

			return this.oCPU.AX.UInt16;
		}
	}
}
