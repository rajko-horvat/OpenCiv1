using Disassembler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Civilization1
{
	public class LogWrapper
	{
		private StreamWriter oLog;
		private int iLogTabLevel = 0;
		private CPU oCPU = null;

		public LogWrapper(string path)
		{
			this.oLog = new StreamWriter(path);
		}

		public void EnterBlock(string text)
		{
			if (this.oLog != null)
			{
				WriteTabs(this.iLogTabLevel);
				this.oLog.Write($"{text}");
				if (this.oCPU != null)
					this.oLog.Write($" // Stack: 0x{this.oCPU.SS.Word:x4}:0x{this.oCPU.SP.Word:x4}, DS 0x{this.oCPU.DS.Word:x4}, BP 0x{this.oCPU.BP.Word:x4}");
				this.oLog.WriteLine();

				WriteTabs(this.iLogTabLevel);
				this.oLog.WriteLine("{");
				this.oLog.Flush();
				this.iLogTabLevel++;
			}
		}

		public void ExitBlock(string text)
		{
			if (this.oLog != null)
			{
				this.iLogTabLevel = Math.Max(0, this.iLogTabLevel - 1);
				WriteTabs(this.iLogTabLevel);
				this.oLog.Write("}");
				if (this.oCPU != null)
					this.oLog.Write($" // Stack: 0x{this.oCPU.SS.Word:x4}:0x{this.oCPU.SP.Word:x4}, DS 0x{this.oCPU.DS.Word:x4}, BP 0x{this.oCPU.BP.Word:x4}");
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

		public CPU CPU
		{
			get { return this.oCPU; }
			set { this.oCPU = value; }
		}
	}
}
