using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;
using IRB.Collections.Generic;
using IRB.VirtualCPU;
using OpenCiv1.GPU;
using System.Diagnostics;
using System.Runtime.InteropServices;
using ThreadState = System.Threading.ThreadState;

namespace OpenCiv1.UI
{
	public partial class MainWindow : Window
	{
		private bool bClosing = false;

		private CivGame oCivGame;
		private DispatcherTimer oTimer;
		private Thread oGameThread;
		private Exception? oGameException = null;

		// track how many screens, columns and rows we have to show
		private int iScreenCount = 0;
		private int iScreenColumns = 1;
		private int iScreenRows = 1;

		// Main screen dimensions
		private GSize oScreenSize = new GSize(320, 200);
		private GSize oImageSize = new GSize(320, 200);

		// Mouse region
		private GRectangle oMouseRect = new GRectangle();

		// We have two interchangeable buffer bitmaps
		private int iBitmapIndex = 0;
		private WriteableBitmap[] aBitmaps = new WriteableBitmap[2];

		public MainWindow()
		{
			InitializeComponent();

#if !DEBUG
			MessageBox.Show("This Alpha Release of OpenCiv1 project " +
				"most certainly has bugs, but most functions should work normally, and has no sound at this point. " +
				"It is compatible with old civ.exe and can save/load original game files.\n\n\n" +
				"Technicalities:\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR " +
				"IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, " +
				"FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE " +
				"AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER " +
				"LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, " +
				"OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.",
				"Warning", MessageBoxIcon.Warning, MessageBoxButtons.OK);
#endif

			// Initialize Game game state
			this.oCivGame = new CivGame();

			// Main Windows events
			this.Closing += this.MainWindow_Closing;
			this.KeyDown += this.MainWindow_KeyDown;
			this.PointerMoved += this.MainWindow_PointerMoved;
			this.PointerPressed += this.MainWindow_PointerPressed;
			this.PointerReleased += this.MainWindow_PointerReleased;

			// Initialize Widnows refresh timer
			this.oTimer = new DispatcherTimer(DispatcherPriority.Normal);
			this.oTimer.Interval = TimeSpan.FromMilliseconds(20);
			this.oTimer.Tick += this.Timer_Tick;
			this.oTimer.Start();

			// Initialize game thread where we have all the fun ;)
			this.oGameThread = new Thread(new ThreadStart(GameThread));
			this.oGameThread.Start();
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			if (!this.bClosing && this.oGameThread.ThreadState == ThreadState.Stopped)
			{
				if (this.oGameException != null)
				{
					Exception ex = this.oGameException;
					if (ex is ResourceMissingException)
					{
						MessageBox.Show(this, ex.Message, "Game resource error", MessageBoxIcon.Error, MessageBoxButtons.OK);
					}
					else
					{
						MessageBox.Show(this, "There was an error in the OpenCiv1 game engine, " +
							"the details about the error should are in the Log.txt file.", "Game engine error", MessageBoxIcon.Error, MessageBoxButtons.OK);
					}
				}

				this.bClosing = true;
				this.Close();
			}

			if (!this.bClosing)
			{
				if (this.oCivGame.Graphics.CPU.Pause && !this.gamePaused.IsVisible)
				{
					this.gamePaused.IsVisible = true;
				}
				else if (!this.oCivGame.Graphics.CPU.Pause && this.gamePaused.IsVisible)
				{
					this.gamePaused.IsVisible = false;
				}

				RedrawScreens(false);
			}
		}

		private void MainWindow_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
		{
			lock (this.oCivGame.Graphics.GLock)
			{
				e.Handled = true;

				if (e.KeyModifiers == KeyModifiers.None)
				{
					switch (e.Key)
					{
						/*case Key.NumPad0:
							// for testing
							this.oGame.CPU.Keys.Enqueue(0x475c);
							break;*/

						case Key.F1:
							this.oCivGame.CPU.Keys.Enqueue(0x3b00);
							break;

						case Key.F2:
							this.oCivGame.CPU.Keys.Enqueue(0x3c00);
							break;

						case Key.F3:
							this.oCivGame.CPU.Keys.Enqueue(0x3d00);
							break;

						case Key.F4:
							this.oCivGame.CPU.Keys.Enqueue(0x3e00);
							break;

						case Key.F5:
							this.oCivGame.CPU.Keys.Enqueue(0x3f00);
							break;

						case Key.F6:
							this.oCivGame.CPU.Keys.Enqueue(0x4000);
							break;

						case Key.F7:
							this.oCivGame.CPU.Keys.Enqueue(0x4100);
							break;

						case Key.F8:
							this.oCivGame.CPU.Keys.Enqueue(0x4200);
							break;

						case Key.F9:
							this.oCivGame.CPU.Keys.Enqueue(0x4300);
							break;

						case Key.F10:
							this.oCivGame.CPU.Keys.Enqueue(0x4400);
							break;

						case Key.Down:
							this.oCivGame.CPU.Keys.Enqueue(0x5000);
							break;

						case Key.Left:
							this.oCivGame.CPU.Keys.Enqueue(0x4b00);
							break;

						case Key.Right:
							this.oCivGame.CPU.Keys.Enqueue(0x4d00);
							break;

						case Key.Up:
							this.oCivGame.CPU.Keys.Enqueue(0x4800);
							break;

						case Key.Home:
							this.oCivGame.CPU.Keys.Enqueue(0x4700);
							break;

						case Key.End:
							this.oCivGame.CPU.Keys.Enqueue(0x4f00);
							break;

						case Key.PageUp:
							this.oCivGame.CPU.Keys.Enqueue(0x4900);
							break;

						case Key.PageDown:
							this.oCivGame.CPU.Keys.Enqueue(0x5100);
							break;

						default:
							if (e.KeySymbol != null && e.KeySymbol.Length > 0)
							{
								this.oCivGame.CPU.Keys.Enqueue((int)e.KeySymbol[0]);
							}
							else
							{
								e.Handled = false;
							}
							break;
					}
				}
				else if ((e.KeyModifiers & KeyModifiers.Shift) == KeyModifiers.Shift)
				{
					switch (e.Key)
					{
						case Key.Down:
							this.oCivGame.CPU.Keys.Enqueue(0x5032);
							break;

						case Key.Left:
							this.oCivGame.CPU.Keys.Enqueue(0x4b34);
							break;

						case Key.Right:
							this.oCivGame.CPU.Keys.Enqueue(0x4d36);
							break;

						case Key.Up:
							this.oCivGame.CPU.Keys.Enqueue(0x4838);
							break;

						case Key.Home:
							this.oCivGame.CPU.Keys.Enqueue(0x4737);
							break;

						case Key.End:
							this.oCivGame.CPU.Keys.Enqueue(0x4f31);
							break;

						case Key.PageUp:
							this.oCivGame.CPU.Keys.Enqueue(0x4939);
							break;

						case Key.PageDown:
							this.oCivGame.CPU.Keys.Enqueue(0x5133);
							break;

						default:
							if (e.KeySymbol != null && e.KeySymbol.Length > 0)
							{
								this.oCivGame.CPU.Keys.Enqueue((int)e.KeySymbol[0]);
							}
							else
							{
								e.Handled = false;
							}
							break;
					}
				}
				else if ((e.KeyModifiers & KeyModifiers.Alt) == KeyModifiers.Alt)
				{
					switch (e.Key)
					{
						case Key.D1:
							ToggleScreen(0);
							break;

						case Key.D2:
							ToggleScreen(1);
							break;

						case Key.D3:
							ToggleScreen(2);
							break;

						case Key.A:
							this.oCivGame.CPU.Keys.Enqueue(0x1e00);
							break;

						case Key.C:
							this.oCivGame.CPU.Keys.Enqueue(0x2e00);
							break;

						case Key.D:
							this.oCivGame.CPU.Keys.Enqueue(0x2000);
							break;

						case Key.G:
							this.oCivGame.CPU.Keys.Enqueue(0x2200);
							break;

						case Key.H:
							this.oCivGame.CPU.Keys.Enqueue(0x2300);
							break;

						case Key.M:
							this.oCivGame.CPU.Keys.Enqueue(0x3200);
							break;

						case Key.O:
							this.oCivGame.CPU.Keys.Enqueue(0x1800);
							break;

						case Key.P:
							this.oCivGame.CPU.Pause = !this.oCivGame.CPU.Pause;
							break;

						case Key.Q:
							this.oCivGame.CPU.Keys.Enqueue(0x1000);
							break;

						case Key.R:
							this.oCivGame.CPU.Keys.Enqueue(0x1300);
							break;

						case Key.V:
							this.oCivGame.CPU.Keys.Enqueue(0x2f00);
							break;

						case Key.W:
							this.oCivGame.CPU.Keys.Enqueue(0x1100);
							break;

						default:
							e.Handled = false;
							break;
					}
				}
			}
		}

		private void MainWindow_PointerMoved(object? sender, PointerEventArgs e)
		{
			lock (this.oCivGame.Graphics.GLock)
			{
				PointerPoint pointer = e.GetCurrentPoint(this.mainImage);
				Point point = pointer.Position;
				GPoint location = new GPoint((int)point.X, (int)point.Y);

				if (this.oMouseRect.Contains(location))
				{
					this.oCivGame.CPU.MouseLocation = new GPoint(location.X / (this.oScreenSize.Width / 320),
						location.Y / (this.oScreenSize.Height / 200));

					this.oCivGame.CPU.MouseButtons = (pointer.Properties.IsLeftButtonPressed ? MouseButtonsEnum.Left : MouseButtonsEnum.None) |
						(pointer.Properties.IsRightButtonPressed ? MouseButtonsEnum.Right : MouseButtonsEnum.None);
				}
			}

			e.Handled = true;
		}

		private void MainWindow_PointerPressed(object? sender, PointerPressedEventArgs e)
		{
			lock (this.oCivGame.Graphics.GLock)
			{
				PointerPoint pointer = e.GetCurrentPoint(this.mainImage);
				Point point = pointer.Position;
				GPoint location = new GPoint((int)point.X, (int)point.Y);

				if (this.oMouseRect.Contains(location))
				{
					this.oCivGame.CPU.MouseLocation = new GPoint(location.X / (this.oScreenSize.Width / 320),
						location.Y / (this.oScreenSize.Height / 200));

					this.oCivGame.CPU.MouseButtons = (pointer.Properties.IsLeftButtonPressed ? MouseButtonsEnum.Left : MouseButtonsEnum.None) |
						(pointer.Properties.IsRightButtonPressed ? MouseButtonsEnum.Right : MouseButtonsEnum.None);
				}
			}

			e.Handled = true;
		}

		private void MainWindow_PointerReleased(object? sender, PointerReleasedEventArgs e)
		{
			lock (this.oCivGame.Graphics.GLock)
			{
				PointerPoint pointer = e.GetCurrentPoint(this.mainImage);
				Point point = pointer.Position;
				GPoint location = new GPoint((int)point.X, (int)point.Y);

				if (this.oMouseRect.Contains(location))
				{
					this.oCivGame.CPU.MouseLocation = new GPoint(location.X / (this.oScreenSize.Width / 320),
						location.Y / (this.oScreenSize.Height / 200));

					this.oCivGame.CPU.MouseButtons = (pointer.Properties.IsLeftButtonPressed ? MouseButtonsEnum.Left : MouseButtonsEnum.None) |
						(pointer.Properties.IsRightButtonPressed ? MouseButtonsEnum.Right : MouseButtonsEnum.None);
				}
			}

			e.Handled = true;
		}

		private void MainWindow_Closing(object? sender, WindowClosingEventArgs e)
		{
			if (!this.bClosing)
			{
				if (MessageBox.Show(this, "Are you sure you want to exit OpenCiv1?\nCurrent game, if any, will not be automatically saved!", "Exit application",
					MessageBoxIcon.Question, MessageBoxButtons.OKCancel, MessageBoxDefaultButton.Button2) == MessageBoxResult.OK)
				{
					this.bClosing = true;
					this.oCivGame.CPU.OnApplicationExit();
				}
				else
				{
					e.Cancel = true;
				}
			}
		}

		private void ResizeWindowAndImage()
		{
			lock (this.oCivGame.Graphics.GLock)
			{
				switch (this.iScreenCount)
				{
					case 0:
					case 1:
						this.iScreenColumns = 1;
						this.iScreenRows = 1;
						break;

					case 2:
						this.iScreenColumns = 2;
						this.iScreenRows = 1;
						break;

					case 3:
						this.iScreenColumns = 2;
						this.iScreenRows = 2;
						break;
				}
				this.oImageSize = new GSize(this.oScreenSize.Width * this.iScreenColumns, this.oScreenSize.Height * this.iScreenRows);

				this.mainImage.Width = this.oImageSize.Width;
				this.mainImage.Height = this.oImageSize.Height;

				this.oMouseRect = new GRectangle(0, 0, this.oScreenSize);

				this.aBitmaps[0] = new WriteableBitmap(new PixelSize(this.oImageSize.Width, this.oImageSize.Height), new Vector(96, 96), PixelFormat.Bgra8888);
				this.aBitmaps[1] = new WriteableBitmap(new PixelSize(this.oImageSize.Width, this.oImageSize.Height), new Vector(96, 96), PixelFormat.Bgra8888);
			}
		}

		private void ToggleScreen(int screen)
		{
			if (this.oCivGame != null)
			{
				if (this.oCivGame.Graphics.Screens.ContainsKey(screen))
				{
					GBitmap oScreen = this.oCivGame.Graphics.Screens.GetValueByKey(screen);

					oScreen.Visible = !oScreen.Visible;
				}
			}
		}

		private void RedrawScreens(bool forceRedraw)
		{
			if (this.oCivGame != null)
			{
				lock (this.oCivGame.Graphics.GLock)
				{
					int iColumn = 0;
					int iRow = 0;

					int iNewScreenCount = 0;
					bool bNeedsRedraw = false;

					for (int i = 0; i < this.oCivGame.Graphics.Screens.Count; i++)
					{
						if (this.oCivGame.Graphics.Screens[i].Value.Visible)
						{
							iNewScreenCount++;

							if (this.oCivGame.Graphics.Screens[i].Value.Modified)
								bNeedsRedraw = true;
						}
					}

					if (this.iScreenCount != iNewScreenCount)
					{
						this.iScreenCount = iNewScreenCount;
						ResizeWindowAndImage();
						forceRedraw = true;
					}

					if (bNeedsRedraw || forceRedraw)
					{
						WriteableBitmap currentBitmap = this.aBitmaps[this.iBitmapIndex];
						int iPixelByteSize = 4;
						int iStride = this.oImageSize.Width * iPixelByteSize;

						using (ILockedFramebuffer l = currentBitmap.Lock())
						{
							for (int i = 0; i < this.oCivGame.Graphics.Screens.Count; i++)
							{
								BKeyValuePair<int, GBitmap> item = this.oCivGame.Graphics.Screens[i];

								if (item.Value.Visible)
								{
									int iBitmapAddress0 = ((iRow * this.oScreenSize.Height) * iStride) +
										((iColumn * this.oScreenSize.Width) * iPixelByteSize);

									GBitmap bitmap = item.Value;
									int iBitmapAddress = iBitmapAddress0;
									int iGBitmapAddress0 = 0;

									for (int y = 0; y < bitmap.Height; y++)
									{
										int iGBitmapAddress = iGBitmapAddress0;
										iBitmapAddress = iBitmapAddress0;

										for (int x = 0; x < bitmap.Width; x++)
										{
											Color color = bitmap.Palette[bitmap.Pixels[iGBitmapAddress]];

											Marshal.WriteInt32(l.Address, iBitmapAddress, (int)color.ToUInt32());
											iBitmapAddress += iPixelByteSize;

											iGBitmapAddress++;
										}

										iBitmapAddress0 += iStride;
										iGBitmapAddress0 += bitmap.Width;
									}

									item.Value.Modified = false;

									iColumn++;
									if (iColumn >= this.iScreenColumns)
									{
										iColumn = 0;
										iRow++;
									}
								}
							}
						}

						this.mainImage.Source = currentBitmap;

						this.iBitmapIndex++;
						this.iBitmapIndex %= 2;
					}
				}
			}
		}

		private void GameThread()
		{
			try
			{
				this.oCivGame.Start();
			}
			catch (ApplicationExitException)
			{
			}
			catch (ResourceMissingException ex)
			{
				// Show exceptions on UI Thread
				this.oGameException = ex;
			}
#if !DEBUG
			catch (Exception ex)
			{
				if (this.oCivGame != null && this.oCivGame.Log != null)
				{
					this.oCivGame.Log.WriteLine("");
					this.oCivGame.Log.WriteLine($"Exception message: {ex.Message}");
					this.oCivGame.Log.WriteLine($"Exception source: {ex.Source}");
					this.oCivGame.Log.WriteLine($"Exception stack trace: {ex.StackTrace}");
				}

				// Show exceptions on UI Thread
				this.oGameException = ex;
			}
#endif
		}
	}
}
