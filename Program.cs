using Disassembler;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Forms;

namespace OpenCiv1
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			OpenCiv1 oGame = null;

#if !DEBUG
            System.Windows.MessageBox.Show("This Alpha prerelease version is a preview version of Open Civilization 1 (OpenCiv1) project.\n" +
				"It most certainly has bugs, but most functions should work normally, and has no sound at this point. " +
				"It is compatible with old civ.exe and can save/load original game files.\n" +
				"The Debug mode can be toggled by pressing Alt + D Key.\n\n" +
				"Technicalities:\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR " +
				"IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, " +
				"FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE " +
				"AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER " +
				"LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, " +
				"OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.",
				"Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
#endif

			try
			{
				oGame = new OpenCiv1();
				oGame.Start();
			}
			catch (Exception e)
			{
				if (oGame != null && oGame.Log != null)
				{
					oGame.Log.WriteLine($"Message: {e.Message}");
					oGame.Log.WriteLine($"Source: {e.Source}");
					oGame.Log.WriteLine($"Stack trace: {e.StackTrace}");
				}
				try
				{
					if (oGame != null && oGame.VGADriver != null && oGame.VGADriver.Form != null)
					{
						oGame.VGADriver.Form.CloseForm();
						System.Windows.Forms.Application.DoEvents();
					}
				}
				catch { }

				Console.WriteLine("There was an error in the application, "+
					"the details should be in a log.txt file, press any key to exit...");
				while (Console.KeyAvailable)
				{
					Console.ReadKey();
				}

				while (!Console.KeyAvailable)
				{
					Thread.Sleep(200);
				}
			}
		}
	}
}
