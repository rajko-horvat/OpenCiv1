using Disassembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Civilization1
{
	public class MainRegistersCheck
	{
		private ushort usSI = 0;
		private ushort usDI = 0;
		private ushort usBP = 0;
		private ushort usSP = 0;
		private ushort usES = 0;
		private ushort usDS = 0;
		private ushort usSS = 0;

		public MainRegistersCheck(CPU cpu)
		{
			this.usSI = cpu.SI.Word;
			this.usDI = cpu.DI.Word;
			this.usBP = cpu.BP.Word;
			this.usSP = cpu.SP.Word;
			this.usES = cpu.ES.Word;
			this.usDS = cpu.DS.Word;
			this.usSS = cpu.SS.Word;
		}

		public bool CheckMainRegisters(CPU cpu)
		{
			bool bReturn = true;

			if (this.usSI != cpu.SI.Word)
			{
				Console.WriteLine($"Register SI was 0x{this.usSI:x4}, is 0x{cpu.SI.Word:x4}");
				bReturn = false;
			}
			if (this.usDI != cpu.DI.Word)
			{
				Console.WriteLine($"Register DI was 0x{this.usDI:x4}, is 0x{cpu.DI.Word:x4}");
				bReturn = false;
			}
			if (this.usBP != cpu.BP.Word)
			{
				Console.WriteLine($"Register BP was 0x{this.usBP:x4}, is 0x{cpu.BP.Word:x4}");
				bReturn = false;
			}
			if (this.usSP != cpu.SP.Word)
			{
				Console.WriteLine($"Register SP was 0x{this.usSP:x4}, is 0x{cpu.SP.Word:x4}");
				bReturn = false;
			}
			// ignore ES for now
			/*if (this.usES != cpu.ES.Word)
			{
				Console.WriteLine($"Register ES was 0x{this.usES:x4}, is 0x{cpu.ES.Word:x4}");
				bReturn = false;
			}*/
			if (this.usDS != cpu.DS.Word)
			{
				Console.WriteLine($"Register DS was 0x{this.usDS:x4}, is 0x{cpu.DS.Word:x4}");
				bReturn = false;
			}
			if (this.usSS != cpu.SS.Word)
			{
				Console.WriteLine($"Register SS was 0x{this.usSS:x4}, is 0x{cpu.SS.Word:x4}");
				bReturn = false;
			}

			return bReturn;
		}
	}
}
