using Disassembler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Civilization1
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[MTAThread]
		static void Main()
		{
			Civilization oCivilization = new Civilization();

			Console.WriteLine("Exiting, press any key...");

			while (Console.KeyAvailable)
			{
				Console.ReadKey();
			}

			while (!Console.KeyAvailable)
			{
				Thread.Sleep(200);
				Application.DoEvents();
			}
		}
	}
}
