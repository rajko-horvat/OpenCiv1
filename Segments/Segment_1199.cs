using Disassembler;
using System;

namespace OpenCiv1
{
	public class Segment_1199
	{
		private OpenCiv1 oParent;
		private CPU oCPU;

		public Segment_1199(OpenCiv1 parent)
		{
			this.oParent = parent;
			this.oCPU = parent.CPU;
		}

		public void F0_1199_00a1_WriteToConsole(int left, int top, string text)
		{
			this.oCPU.Log.EnterBlock($"F0_1199_00a1_WriteToConsole({left}, {top}, '{text}')");

			// function body
			if (left < Console.WindowWidth && top < Console.WindowHeight)
			{
				Console.SetCursorPosition(left, top);
			}

			text = text.Replace("\r\n", "\n").Replace("\n\r", "\n").Replace("\n", "\r\n");

			for (int i = 0; i < text.Length; i++)
			{
				char ch = text[i];
				if (ch == '\x00ff')
				{
					Console.ForegroundColor = (ConsoleColor)((int)text[i + 1] & 0xf);
					Console.BackgroundColor = (ConsoleColor)(((int)text[i + 1] & 0xf0) >> 4);
					i++;
				}
				else
				{
					Console.Write(ch);
				}
			}

			// Far return
			this.oCPU.Log.ExitBlock("F0_1199_00a1_WriteToConsole");
		}

		public void F0_1199_00ec_WriteToConsole(string text)
		{
			this.oCPU.Log.EnterBlock($"F0_1199_00ec_WriteToConsole('{text}')");

			// function body
			ConsoleColor foreColor = Console.ForegroundColor;
			ConsoleColor backColor = Console.BackgroundColor;

			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			text = text.Replace("\r\n", "\n").Replace("\n\r", "\n").Replace("\n", "\r\n");
			Console.Write(text);

			Console.ForegroundColor = foreColor;
			Console.BackgroundColor = backColor;

			// Far return
			this.oCPU.Log.ExitBlock("F0_1199_00ec_WriteToConsole");
		}
	}
}
