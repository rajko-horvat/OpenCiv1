using System;
using System.Collections.Generic;
using System.IO;
using IRB.VirtualCPU;

namespace OpenCiv1
{
	public class LogWrapper
	{
		private StreamWriter oLog;
		private int iLogTabLevel = 0;
		private CPU? oCPU = null;
		private Stack<ushort> aStack = new Stack<ushort>();

		public LogWrapper(string path)
		{
			this.oLog = new StreamWriter(path);
		}

		public CPU? CPU
		{
			get { return this.oCPU; }
			set { this.oCPU = value; }
		}

		public void EnterBlock(string text)
		{
			EnterBlock(text, false);
		}

		public void EnterBlock(string text, bool showRegisters)
		{
			if (this.oLog != null)
			{
				if (this.aStack.Count != this.iLogTabLevel)
					throw new Exception("Unbalanced EnterBlock or ExitBlock");

				if (this.oCPU != null)
					this.aStack.Push(this.oCPU.SP.Word);

				WriteTabs(this.iLogTabLevel);
				this.oLog.Write($"{text}");

				if (this.oCPU != null && showRegisters)
					this.oLog.Write($" // Stack: 0x{this.oCPU.SS.Word:x4}:0x{this.oCPU.SP.Word:x4}, DS 0x{this.oCPU.DS.Word:x4}, BP 0x{this.oCPU.BP.Word:x4}");

				this.oLog.WriteLine();

				WriteTabs(this.iLogTabLevel);
				this.oLog.WriteLine("{");
				this.oLog.Flush();
				this.iLogTabLevel++;
			}
		}

		public void ExitBlock(string text, int returnValue)
		{
			if (this.oLog != null)
			{
				this.WriteLine($"// Function returns: {returnValue} (0x{returnValue:x})");

				this.ExitBlock(text);
			}
		}

		public void ExitBlock(string text)
		{
			if (this.oLog != null)
			{
				if (this.aStack.Count != this.iLogTabLevel)
					throw new Exception("Unbalanced EnterBlock or ExitBlock");

				this.iLogTabLevel = Math.Max(0, this.iLogTabLevel - 1);
				WriteTabs(this.iLogTabLevel);
				this.oLog.Write("}");

				//if (this.oCPU != null)
				//	this.oLog.Write($" // Stack: 0x{this.oCPU.SS.Word:x4}:0x{this.oCPU.SP.Word:x4}, DS 0x{this.oCPU.DS.Word:x4}, BP 0x{this.oCPU.BP.Word:x4}");

				ushort usStack = this.aStack.Pop();
				// _setargv pushes permanent data on the stack!
				if (this.oCPU != null &&
					!text.Equals("_setargv", StringComparison.InvariantCultureIgnoreCase) &&
					!text.Equals("start", StringComparison.InvariantCultureIgnoreCase) &&
					this.oCPU.SP.Word != usStack)
				{
					this.oLog.Write($", Error: Stack leak detected in function '{text}', " +
						$"stack position should be 0x{usStack:x4}, but is 0x{this.oCPU.SP.Word:x4}");
				}

				this.oLog.WriteLine();

				this.oLog.Flush();
			}
		}

		public void WriteLine(string text)
		{
			if (this.oLog != null)
			{
				WriteTabs(this.iLogTabLevel);
				this.oLog.WriteLine(text);
				this.oLog.Flush();
			}
		}

		public void Write(string text)
		{
			if (this.oLog != null)
			{
				this.oLog.Write(text);
				this.oLog.Flush();
			}
		}

		private void WriteTabs(int level)
		{
			this.oLog.Write($"{new string('\t', level)}");
		}
	}
}
