using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Threading;

using CommunityToolkit.Mvvm.ComponentModel;

using IRB.Collections.Generic;

using MsBox.Avalonia;

using OpenCiv1.GPU;
using OpenCiv1.UI.Converters;
using OpenCiv1.UI.Extensions;

namespace OpenCiv1.UI.ViewModels;

public sealed partial class MainViewModel : ViewModelBase, Contracts.IMainForm, IDisposable
{
	[ObservableProperty]
	private WriteableBitmap _bitmap;
	private bool _disposed;
	private const int BitmapWidth = 320;
	private const int BitmapHeight = 200;
	private const int BitmapDpi = 96;
	private bool bClosing = false;
	private Thread? oGameThread;
	private Thread? oDrawThread;
	private OpenCiv1? oGame = null;
	private GSize oScreenSize = new GSize(BitmapWidth, BitmapHeight);

	[ObservableProperty]
	public Size _clientSize;

	private GRectangle oMouseRect = new GRectangle();
	private GPoint oMouseLocation = new GPoint();
	private Input.MouseButtons oMouseButtons = global::OpenCiv1.Input.MouseButtons.None;
	private int iScreenColumns = 1;
	private int iScreenRows = 1;

	private DispatcherTimer _timer;

	public Action? InvalidateBitmap { get; internal set; }
	public GPU.GPoint ScreenMouseLocation { get; } = new(0, 0);
	public Input.MouseButtons ScreenMouseButtons { get; } = Input.MouseButtons.None;

	private bool oDrawingRequired = false;

	private event EventHandler? OnAppOpen;

	public MainViewModel()
	{
		Bitmap = new WriteableBitmap(new PixelSize(BitmapWidth, BitmapHeight), new Vector(BitmapDpi, BitmapDpi), PixelFormat.Bgra8888, AlphaFormat.Opaque);
		_timer = new DispatcherTimer();
		_timer.Interval = TimeSpan.FromMilliseconds(50);
		_timer.Tick += Timer_Tick;
		this.oDrawThread = new Thread(new ThreadStart(DrawThread));
		this.oDrawThread.Start();
		this.oGameThread = new Thread(new ThreadStart(GameThread));
		this.oGameThread.Start();
		_timer.Start();
		OnAppOpen += MainViewModel_OnAppOpen;
		OnAppOpen?.Invoke(this, EventArgs.Empty);
	}

	private async void MainViewModel_OnAppOpen(object? sender, EventArgs e)
	{
		if(!Debugger.IsAttached)
		{
			return;
		}
		var box = MessageBoxManager.GetMessageBoxStandard("Warning", "This Alpha Release of OpenCiv1(OpenCiv1) project " +
			"most certainly has bugs, but most functions should work normally, and has no sound at this point. " +
			"It is compatible with old civ.exe and can save/load original game files.\n" +
			"The Debug mode can be toggled by pressing Alt + D Key.\n\n" +
			"Technicalities:\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR " +
			"IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, " +
			"FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE " +
			"AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER " +
			"LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, " +
			"OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.",
			MsBox.Avalonia.Enums.ButtonEnum.Ok,
			MsBox.Avalonia.Enums.Icon.Warning);
		await box.ShowAsync();
	}

	public void DrawThread()
	{
		while(!bClosing)
		{
			if (oDrawingRequired && this.oGame != null && this.oGame.Graphics != null)
			{
				lock (this.oGame.Graphics.GLock)
				{
					RedrawScreen();
					Dispatcher.UIThread.Post(() =>
					{
						InvalidateBitmap?.Invoke();
						oDrawingRequired = false;
					});
				}
			}
			else
			{
				Thread.Sleep(1);
			}
		}
	}

	private void GameThread()
	{
		try
		{
			this.oGame = new OpenCiv1(this);

			this.oGame.Start(this);
		}
		catch (ApplicationExitException)
		{
		}
		catch (ResourceMissingException ex)
		{
			var box = MessageBoxManager.GetMessageBoxStandard("Error", $"OpenCiv1 resource error: {ex.GetBaseException().Message}", MsBox.Avalonia.Enums.ButtonEnum.Ok, MsBox.Avalonia.Enums.Icon.Error);
			box.ShowAsync().GetAwaiter().GetResult();
		}
		catch (Exception e)
		{
			if (Debugger.IsAttached)
			{
				if (this.oGame != null && this.oGame.Log != null)
				{
					this.oGame.Log.WriteLine("");
					this.oGame.Log.WriteLine($"Exception message: {e.Message}");
					this.oGame.Log.WriteLine($"Exception source: {e.Source}");
					this.oGame.Log.WriteLine($"Exception stack trace: {e.StackTrace}");
				}

			var box = MessageBoxManager.GetMessageBoxStandard("Error",
				"There was an error(Exception) in the OpenCiv1 application, " +
					"the details about the error should be in a Log.txt file."
					,
				  MsBox.Avalonia.Enums.ButtonEnum.Ok,
					MsBox.Avalonia.Enums.Icon.Error);
				box.ShowAsync().GetAwaiter().GetResult();
			}

		}

		if (!this.bClosing)
		{
			this.bClosing = true;

			CloseApp?.Invoke(this, EventArgs.Empty);
		}
	}

	public event EventHandler? CloseApp;

	private void Timer_Tick(object? sender, EventArgs e)
	{
		oDrawingRequired = true;
	}

	private unsafe void RedrawScreen()
	{
		int iColumn = 0;
		int iRow = 0;

		if (this.oGame != null)
		{
			for (int i = 0; i < this.oGame.Graphics.Screens.Count; i++)
			{
				BKeyValuePair<int, GBitmap> item = this.oGame.Graphics.Screens[i];

				if (item.Value.Visible)
				{
					if (item.Value.Modified)
					{
						GBitmap gbmp = item.Value;

						// Draw the bitmap to the screen
						using var pixels = Bitmap.Lock();

						var frameBuffer = new Span<uint>((void*)pixels.Address, pixels.Size.Width * pixels.Size.Height);

						int iPixelAddress = 0;
						int iBitmapAddress = 0;

						for (int y = 0; y < gbmp.Height; y++)
						{
							for (int x = 0; x < gbmp.Width; x++)
							{
								Drawing.Color color = gbmp.Palette[gbmp.Pixels[iPixelAddress]];

								frameBuffer[iBitmapAddress] = Avalonia.Media.Color.FromArgb(color.A, color.R, color.G, color.B).ToUInt32();

								iPixelAddress++;
								iBitmapAddress++;
							}
						}


						item.Value.Modified = false;
					}

					iColumn++;
					if (iColumn >= this.iScreenColumns)
					{
						iColumn = 0;
						iRow++;
					}
				}
			}

			if (this.oGame.Graphics.CPU.Pause)
			{
				Status = "Game paused";
			}
			else
			{
				Status = null;
			}
		}
	}

	[ObservableProperty]
	private string? _status;

	public void OnScreenCountChange()
	{
		ScreenCountChangeMethod();
	}

	private void ScreenCountChangeMethod()
	{
		if (this.oGame != null && this.oGame.Graphics != null)
		{
			lock (this.oGame.Graphics.GLock)
			{
				int iScreenCount = 0;

				// update screen list
				for (int i = 0; i < this.oGame.Graphics.Screens.Count; i++)
				{
					BKeyValuePair<int, GBitmap> item = this.oGame.Graphics.Screens[i];

					if (item.Value.Visible)
					{
						iScreenCount++;
					}
				}

				switch (iScreenCount)
				{
					case 1:
						this.iScreenColumns = 1;
						this.iScreenRows = 1;
						this.oScreenSize = new GSize(640, 400);
						break;

					case 2:
						this.iScreenColumns = 2;
						this.iScreenRows = 1;
						this.oScreenSize = new GSize(320, 200);
						break;

					case 3:
						this.iScreenColumns = 2;
						this.iScreenRows = 2;
						this.oScreenSize = new GSize(320, 200);
						break;

					case 4:
						this.iScreenColumns = 2;
						this.iScreenRows = 2;
						this.oScreenSize = new GSize(320, 200);
						break;

					case 5:
						this.iScreenColumns = 3;
						this.iScreenRows = 2;
						this.oScreenSize = new GSize(320, 200);
						break;

					case 6:
						this.iScreenColumns = 3;
						this.iScreenRows = 2;
						this.oScreenSize = new GSize(320, 200);
						break;

					case 7:
						this.iScreenColumns = 3;
						this.iScreenRows = 3;
						this.oScreenSize = new GSize(320, 200);
						break;

					case 8:
						this.iScreenColumns = 3;
						this.iScreenRows = 3;
						this.oScreenSize = new GSize(320, 200);
						break;
				}
				this.ClientSize = new Size(this.oScreenSize.Width * this.iScreenColumns + 1 + this.iScreenColumns,
					this.oScreenSize.Height * this.iScreenRows + 1 + this.iScreenRows);
				this.oMouseRect = new GRectangle(0, 0, this.oScreenSize);
				this.InvalidateBitmap?.Invoke();
			}
		}
		else
		{
			this.iScreenColumns = 1;
			this.iScreenRows = 1;
			this.oScreenSize = new GSize(640, 400);

			this.ClientSize = new Size(this.oScreenSize.Width * this.iScreenColumns + this.iScreenColumns + 1,
				this.oScreenSize.Height * this.iScreenRows + this.iScreenRows + 1);
			this.oMouseRect = new GRectangle(0, 0, this.oScreenSize);
			this.InvalidateBitmap?.Invoke();
		}
	}

	private void ToggleScreen(int screen)
	{
		if (this.oGame != null && this.oGame.Graphics != null)
		{
			if (this.oGame.Graphics.Screens.ContainsKey(screen))
			{
				GBitmap oScreen = this.oGame.Graphics.Screens.GetValueByKey(screen);

				oScreen.Visible = !oScreen.Visible;

				OnScreenCountChange();
			}
		}
	}

	internal void OnPointerMoved(PointerEventArgs e, Image image)
	{
		var pointerPoint = e.GetCurrentPoint(image);
		this.oMouseLocation = pointerPoint.Position.ToGPoint();
		if(pointerPoint.Properties.IsLeftButtonPressed)
		{
			this.oMouseButtons |= Input.MouseButtons.Left;
		}
		if(pointerPoint.Properties.IsRightButtonPressed)
		{
			this.oMouseButtons |= Input.MouseButtons.Right;
		}
		if(pointerPoint.Properties.IsMiddleButtonPressed)
		{
			this.oMouseButtons |= Input.MouseButtons.Middle;
		}
	}

	internal void OnPointerPressed(PointerPressedEventArgs e, Image image)
	{
		var pointerPoint = e.GetCurrentPoint(image);
		this.oMouseLocation = pointerPoint.Position.ToGPoint();
		if(pointerPoint.Properties.IsLeftButtonPressed)
		{
			this.oMouseButtons |= Input.MouseButtons.Left;
		}
		if(pointerPoint.Properties.IsRightButtonPressed)
		{
			this.oMouseButtons |= Input.MouseButtons.Right;
		}
		if(pointerPoint.Properties.IsMiddleButtonPressed)
		{
			this.oMouseButtons |= Input.MouseButtons.Middle;
		}
	}

	internal void OnPointerReleased(PointerReleasedEventArgs e, Image image)
	{
		var pointerPoint = e.GetCurrentPoint(image);
		if (pointerPoint.Properties.IsLeftButtonPressed)
		{
			this.oMouseButtons |= global::OpenCiv1.Input.MouseButtons.Left;
			this.oMouseButtons ^= global::OpenCiv1.Input.MouseButtons.Left;
		}
		else if (pointerPoint.Properties.IsRightButtonPressed)
		{
			this.oMouseButtons |= global::OpenCiv1.Input.MouseButtons.Right;
			this.oMouseButtons ^= global::OpenCiv1.Input.MouseButtons.Right;
		}
	}

	internal void OnKeyDown(KeyEventArgs e)
	{
		if (this.oGame != null)
		{
			lock (this.oGame.Graphics.GLock)
			{
				this.oGame.Graphics.Keys.Enqueue(AvaloniaKeyScanCodeConverter.GetPressedKeyAsciiCode(e.Key));
			}
		}

		if (this.oGame != null)
		{
			lock (this.oGame.Graphics.GLock)
			{
				if (e.KeyModifiers == KeyModifiers.None)
				{
					switch (e.Key)
					{
						case Key.NumPad0:
							// for testing
							this.oGame.Graphics.Keys.Enqueue(0x475c);
							break;

						case Key.F1:
							this.oGame.Graphics.Keys.Enqueue(0x3b00);
							break;

						case Key.F2:
							this.oGame.Graphics.Keys.Enqueue(0x3c00);
							break;

						case Key.F3:
							this.oGame.Graphics.Keys.Enqueue(0x3d00);
							break;

						case Key.F4:
							this.oGame.Graphics.Keys.Enqueue(0x3e00);
							break;

						case Key.F5:
							this.oGame.Graphics.Keys.Enqueue(0x3f00);
							break;

						case Key.F6:
							this.oGame.Graphics.Keys.Enqueue(0x4000);
							break;

						case Key.F7:
							this.oGame.Graphics.Keys.Enqueue(0x4100);
							break;

						case Key.F8:
							this.oGame.Graphics.Keys.Enqueue(0x4200);
							break;

						case Key.F9:
							this.oGame.Graphics.Keys.Enqueue(0x4300);
							break;

						case Key.F10:
							this.oGame.Graphics.Keys.Enqueue(0x4400);
							break;

						case Key.Down:
							this.oGame.Graphics.Keys.Enqueue(0x5000);
							break;

						case Key.Left:
							this.oGame.Graphics.Keys.Enqueue(0x4b00);
							break;

						case Key.Right:
							this.oGame.Graphics.Keys.Enqueue(0x4d00);
							break;

						case Key.Up:
							this.oGame.Graphics.Keys.Enqueue(0x4800);
							break;

						case Key.Home:
							this.oGame.Graphics.Keys.Enqueue(0x4700);
							break;

						case Key.End:
							this.oGame.Graphics.Keys.Enqueue(0x4f00);
							break;

						case Key.PageUp:
							this.oGame.Graphics.Keys.Enqueue(0x4900);
							break;

						case Key.PageDown:
							this.oGame.Graphics.Keys.Enqueue(0x5100);
							break;
					}
				}
				else if ((e.KeyModifiers & KeyModifiers.Shift) == KeyModifiers.Shift)
				{
					switch (e.Key)
					{
						case Key.Down:
							this.oGame.Graphics.Keys.Enqueue(0x5032);
							break;

						case Key.Left:
							this.oGame.Graphics.Keys.Enqueue(0x4b34);
							break;

						case Key.Right:
							this.oGame.Graphics.Keys.Enqueue(0x4d36);
							break;

						case Key.Up:
							this.oGame.Graphics.Keys.Enqueue(0x4838);
							break;

						case Key.Home:
							this.oGame.Graphics.Keys.Enqueue(0x4737);
							break;

						case Key.End:
							this.oGame.Graphics.Keys.Enqueue(0x4f31);
							break;

						case Key.PageUp:
							this.oGame.Graphics.Keys.Enqueue(0x4939);
							break;

						case Key.PageDown:
							this.oGame.Graphics.Keys.Enqueue(0x5133);
							break;
					}
				}
				else if ((e.KeyModifiers & KeyModifiers.Alt) == KeyModifiers.Alt)
				{
					e.Handled = true;

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
							this.oGame.Graphics.Keys.Enqueue(0x1e00);
							break;

						case Key.C:
							this.oGame.Graphics.Keys.Enqueue(0x2e00);
							break;

						case Key.D:
							this.oGame.Graphics.Keys.Enqueue(0x2000);
							break;

						case Key.G:
							this.oGame.Graphics.Keys.Enqueue(0x2200);
							break;

						case Key.H:
							this.oGame.Graphics.Keys.Enqueue(0x2300);
							break;

						case Key.M:
							this.oGame.Graphics.Keys.Enqueue(0x3200);
							break;

						case Key.O:
							this.oGame.Graphics.Keys.Enqueue(0x1800);
							break;

						case Key.P:
							this.oGame.CPU.Pause = !this.oGame.CPU.Pause;
							break;

						case Key.Q:
							this.oGame.Graphics.Keys.Enqueue(0x1000);
							break;

						case Key.R:
							this.oGame.Graphics.Keys.Enqueue(0x1300);
							break;

						case Key.V:
							this.oGame.Graphics.Keys.Enqueue(0x2f00);
							break;

						case Key.W:
							this.oGame.Graphics.Keys.Enqueue(0x1100);
							break;
					}
				}
			}
		}
	}

	public object? GetObject(string name)
	{
		return Resources.Properties.Resources.ResourceManager.GetObject(name);
	}

	private void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
			{
				this.bClosing = true;

				if (this.oGame != null && this.oGame.CPU != null)
				{
					this.oGame.CPU.OnApplicationExit();
				}

				if(oDrawThread != null && oDrawThread.IsAlive)
				{
					oDrawThread.Join();
				}

				Bitmap.Dispose();

				if (oGameThread != null && oGameThread.IsAlive)
				{
					oGameThread.Join();
				}
			}
			_disposed = true;
		}
	}

	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
	}
}
