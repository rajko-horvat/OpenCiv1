using IRB.Collections.Generic;
using OpenCiv1.GPU;
using System.Runtime.InteropServices;
using OpenCiv1.Contracts;

namespace OpenCiv1.UI.Windows;

public partial class MainForm : Form, IMainForm
{
	private delegate void InitializeControlsDelegate();
	private delegate void ScreenCountChangeDelegate();
	private delegate void CloseFormDelegate();
	private InitializeControlsDelegate oInitializeControls;
	private ScreenCountChangeDelegate oScreenCountChange;
	private CloseFormDelegate oCloseForm;

	private bool bClosing = false;
	private Thread? oGameThread = null;
	private OpenCiv1? oGame = null;
	private GSize oScreenSize = new GSize(640, 400);
	private GRectangle oMouseRect = new GRectangle();
	private GPoint oMouseLocation = new GPoint();
	private Input.MouseButtons oMouseButtons = global::OpenCiv1.Input.MouseButtons.None;
	private int iScreenColumns = 1;
	private int iScreenRows = 1;
	private Font oFont;
	private Font oLargeFont;

	public MainForm()
	{
		InitializeComponent();

		this.SetStyle(ControlStyles.Opaque, true);
		this.SetStyle(ControlStyles.UserPaint, true);
		//this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
		this.oInitializeControls = new InitializeControlsDelegate(InitializeControlsMethod);
		this.oScreenCountChange = new ScreenCountChangeDelegate(ScreenCountChangeMethod);
		this.oCloseForm = new CloseFormDelegate(CloseFormMethod);

		this.oFont = new Font("Verdana", 10.0f, FontStyle.Regular, GraphicsUnit.Pixel);
		this.oLargeFont = new Font("Verdana", 40.0f, FontStyle.Bold, GraphicsUnit.Pixel);
	}

	public GPoint ScreenMouseLocation
	{
		get { return this.oMouseLocation; }
	}

	public global::OpenCiv1.Input.MouseButtons ScreenMouseButtons
	{
		get { return this.oMouseButtons; }
	}

	private void InitializeControlsMethod()
	{
		ScreenCountChangeMethod();
	}

	public void OnScreenCountChange()
	{
		if (this.InvokeRequired)
		{
			this.Invoke(oScreenCountChange);
		}
		else
		{
			ScreenCountChangeMethod();
		}
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
				this.Invalidate();
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
			this.Invalidate();
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

	private void CloseFormMethod()
	{
		this.Close();
	}

	private void tmrRefresh_Tick(object sender, EventArgs e)
	{
		if (this.oGame != null && this.oGame.Graphics != null)
		{
			lock (this.oGame.Graphics.GLock)
			{
				Graphics g = Graphics.FromHwnd(this.Handle);
				RedrawScreens(g, false);
				g.Flush();
				g.Dispose();
			}
		}
	}

	private void Form_Paint(object sender, PaintEventArgs e)
	{
		Graphics g = e.Graphics;
		g.FillRectangle(Brushes.Black, this.ClientRectangle);

		if (this.oGame != null && this.oGame.Graphics != null)
		{
			lock (this.oGame.Graphics.GLock)
			{
				RedrawScreens(g, true);
			}
		}
	}

	private void RedrawScreens(Graphics g, bool forceRedraw)
	{
		int iColumn = 0;
		int iRow = 0;

		if (this.oGame != null)
		{
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

			for (int i = 0; i < this.oGame.Graphics.Screens.Count; i++)
			{
				BKeyValuePair<int, GBitmap> item = this.oGame.Graphics.Screens[i];

				if (item.Value.Visible)
				{
					if (item.Value.Modified || forceRedraw)
					{
						GBitmap gbmp = item.Value;

						// construct byte array from out indexed bitmap
						int iBitmapMemoryStride = (int)(Math.Ceiling((double)gbmp.Width / 4.0) * 4.0) * 4;
						byte[] aBitmapMemory = new byte[iBitmapMemoryStride * gbmp.Height];

						int iPixelAddress = 0;
						int iBitmapAddress0 = 0;

						for (int y = 0; y < gbmp.Height; y++)
						{
							int iBitmapAddress = iBitmapAddress0;

							for (int x = 0; x < gbmp.Width; x++)
							{
								global::OpenCiv1.Drawing.Color color = gbmp.Palette[gbmp.Pixels[iPixelAddress]];

								aBitmapMemory[iBitmapAddress] = color.B;
								aBitmapMemory[iBitmapAddress + 1] = color.G;
								aBitmapMemory[iBitmapAddress + 2] = color.R;
								aBitmapMemory[iBitmapAddress + 3] = color.A;

								iPixelAddress++;
								iBitmapAddress += 4;
							}

							iBitmapAddress0 += iBitmapMemoryStride;

							for (; iBitmapAddress < iBitmapAddress0; iBitmapAddress++)
							{
								aBitmapMemory[iBitmapAddress] = 0;
							}
						}

						// Draw the bitmap to the screen
						GCHandle handle = GCHandle.Alloc(aBitmapMemory, GCHandleType.Pinned);
						Bitmap bmp = new Bitmap(gbmp.Width, gbmp.Height, iBitmapMemoryStride, System.Drawing.Imaging.PixelFormat.Format32bppArgb,
							Marshal.UnsafeAddrOfPinnedArrayElement(aBitmapMemory, 0));
						handle.Free();

						Rectangle rect = new Rectangle((iColumn * this.oScreenSize.Width) + (iColumn + 1),
							(iRow * this.oScreenSize.Height) + (iRow + 1),
							this.oScreenSize.Width, this.oScreenSize.Height);
						g.DrawImage(bmp, rect);
						g.DrawString($"{item.Key}", this.oFont, Brushes.White, rect.Left + 5.0f, rect.Top + 5.0f);
						g.DrawRectangle(Pens.Purple, (iColumn * this.oScreenSize.Width) + iColumn,
							(iRow * this.oScreenSize.Height) + iRow,
							this.oScreenSize.Width + 1, this.oScreenSize.Height + 1);

						g.Flush();
						bmp.Dispose();

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
				string sTemp = "Game paused";
				SizeF size = g.MeasureString(sTemp, this.oLargeFont);
				g.DrawString(sTemp, this.oLargeFont, Brushes.White,
					(float)((this.oScreenSize.Width * this.iScreenColumns) - size.Width) / 2.0f,
					(float)((this.oScreenSize.Height * this.iScreenRows) - size.Height) / 2.0f);
			}
		}
	}

	private void Form_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (this.oGame != null)
		{
			lock (this.oGame.Graphics.GLock)
			{
				this.oGame.Graphics.Keys.Enqueue(e.KeyChar);
			}
		}
	}

	private void Form_KeyDown(object sender, KeyEventArgs e)
	{
		if (this.oGame != null)
		{
			lock (this.oGame.Graphics.GLock)
			{
				if (e.Modifiers == Keys.None)
				{
					switch (e.KeyCode)
					{
						case Keys.NumPad0:
							// for testing
							this.oGame.Graphics.Keys.Enqueue(0x475c);
							break;

						case Keys.F1:
							this.oGame.Graphics.Keys.Enqueue(0x3b00);
							break;

						case Keys.F2:
							this.oGame.Graphics.Keys.Enqueue(0x3c00);
							break;

						case Keys.F3:
							this.oGame.Graphics.Keys.Enqueue(0x3d00);
							break;

						case Keys.F4:
							this.oGame.Graphics.Keys.Enqueue(0x3e00);
							break;

						case Keys.F5:
							this.oGame.Graphics.Keys.Enqueue(0x3f00);
							break;

						case Keys.F6:
							this.oGame.Graphics.Keys.Enqueue(0x4000);
							break;

						case Keys.F7:
							this.oGame.Graphics.Keys.Enqueue(0x4100);
							break;

						case Keys.F8:
							this.oGame.Graphics.Keys.Enqueue(0x4200);
							break;

						case Keys.F9:
							this.oGame.Graphics.Keys.Enqueue(0x4300);
							break;

						case Keys.F10:
							this.oGame.Graphics.Keys.Enqueue(0x4400);
							break;

						case Keys.Down:
							this.oGame.Graphics.Keys.Enqueue(0x5000);
							break;

						case Keys.Left:
							this.oGame.Graphics.Keys.Enqueue(0x4b00);
							break;

						case Keys.Right:
							this.oGame.Graphics.Keys.Enqueue(0x4d00);
							break;

						case Keys.Up:
							this.oGame.Graphics.Keys.Enqueue(0x4800);
							break;

						case Keys.Home:
							this.oGame.Graphics.Keys.Enqueue(0x4700);
							break;

						case Keys.End:
							this.oGame.Graphics.Keys.Enqueue(0x4f00);
							break;

						case Keys.PageUp:
							this.oGame.Graphics.Keys.Enqueue(0x4900);
							break;

						case Keys.PageDown:
							this.oGame.Graphics.Keys.Enqueue(0x5100);
							break;
					}
				}
				else if ((e.Modifiers & Keys.Shift) == Keys.Shift)
				{
					switch (e.KeyCode)
					{
						case Keys.Down:
							this.oGame.Graphics.Keys.Enqueue(0x5032);
							break;

						case Keys.Left:
							this.oGame.Graphics.Keys.Enqueue(0x4b34);
							break;

						case Keys.Right:
							this.oGame.Graphics.Keys.Enqueue(0x4d36);
							break;

						case Keys.Up:
							this.oGame.Graphics.Keys.Enqueue(0x4838);
							break;

						case Keys.Home:
							this.oGame.Graphics.Keys.Enqueue(0x4737);
							break;

						case Keys.End:
							this.oGame.Graphics.Keys.Enqueue(0x4f31);
							break;

						case Keys.PageUp:
							this.oGame.Graphics.Keys.Enqueue(0x4939);
							break;

						case Keys.PageDown:
							this.oGame.Graphics.Keys.Enqueue(0x5133);
							break;
					}
				}
				else if ((e.Modifiers & Keys.Alt) == Keys.Alt)
				{
					e.Handled = true;
					e.SuppressKeyPress = true;

					switch (e.KeyCode)
					{
						case Keys.D1:
							ToggleScreen(0);
							break;

						case Keys.D2:
							ToggleScreen(1);
							break;

						case Keys.D3:
							ToggleScreen(2);
							break;

						case Keys.A:
							this.oGame.Graphics.Keys.Enqueue(0x1e00);
							break;

						case Keys.C:
							this.oGame.Graphics.Keys.Enqueue(0x2e00);
							break;

						case Keys.D:
							this.oGame.Graphics.Keys.Enqueue(0x2000);
							break;

						case Keys.G:
							this.oGame.Graphics.Keys.Enqueue(0x2200);
							break;

						case Keys.H:
							this.oGame.Graphics.Keys.Enqueue(0x2300);
							break;

						case Keys.M:
							this.oGame.Graphics.Keys.Enqueue(0x3200);
							break;

						case Keys.O:
							this.oGame.Graphics.Keys.Enqueue(0x1800);
							break;

						case Keys.P:
							this.oGame.CPU.Pause = !this.oGame.CPU.Pause;
							break;

						case Keys.Q:
							this.oGame.Graphics.Keys.Enqueue(0x1000);
							break;

						case Keys.R:
							this.oGame.Graphics.Keys.Enqueue(0x1300);
							break;

						case Keys.V:
							this.oGame.Graphics.Keys.Enqueue(0x2f00);
							break;

						case Keys.W:
							this.oGame.Graphics.Keys.Enqueue(0x1100);
							break;
					}
				}
			}
		}
	}

	private void Form_MouseMove(object sender, MouseEventArgs e)
	{
		GPoint location = new GPoint(e.Location.X, e.Location.Y);

		if (this.oMouseRect.Contains(location))
		{
			this.oMouseLocation = new GPoint(location.X / (this.oScreenSize.Width / 320),
				location.Y / (this.oScreenSize.Height / 200));
			this.oMouseButtons = (Input.MouseButtons)e.Button;
		}
	}

	private void Form_MouseDown(object sender, MouseEventArgs e)
	{
		GPoint location = new GPoint(e.Location.X, e.Location.Y);

		if (this.oMouseRect.Contains(location))
		{
			if (e.Button == MouseButtons.Left)
			{
				this.oMouseButtons |= global::OpenCiv1.Input.MouseButtons.Left;
			}
			else if (e.Button == MouseButtons.Right)
			{
				this.oMouseButtons |= global::OpenCiv1.Input.MouseButtons.Right;
			}
		}
	}

	private void Form_MouseUp(object sender, MouseEventArgs e)
	{
		GPoint location = new GPoint(e.Location.X, e.Location.Y);

		if (this.oMouseRect.Contains(location))
		{
			if (e.Button == MouseButtons.Left)
			{
				this.oMouseButtons |= global::OpenCiv1.Input.MouseButtons.Left;
				this.oMouseButtons ^= global::OpenCiv1.Input.MouseButtons.Left;
			}
			else if (e.Button == MouseButtons.Right)
			{
				this.oMouseButtons |= global::OpenCiv1.Input.MouseButtons.Right;
				this.oMouseButtons ^= global::OpenCiv1.Input.MouseButtons.Right;
			}
		}
	}

	private void MainForm_Shown(object sender, EventArgs e)
	{
#if !DEBUG
		MessageBox.Show("This Alpha Release of OpenCiv1 (OpenCiv1) project " +
			"most certainly has bugs, but most functions should work normally, and has no sound at this point. " +
			"It is compatible with old civ.exe and can save/load original game files.\n" +
			"The Debug mode can be toggled by pressing Alt + D Key.\n\n" +
			"Technicalities:\n\nTHE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR " +
			"IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, " +
			"FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE " +
			"AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER " +
			"LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, " +
			"OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.",
			"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
		if (this.oGameThread == null)
		{
			this.oGameThread = new Thread(new ThreadStart(GameThread));
			this.oGameThread.Start();
		}
	}

	private void GameThread()
	{
		try
		{
			this.oGame = new OpenCiv1(this);

			if (this.InvokeRequired)
			{
				this.Invoke(this.oInitializeControls);
			}
			else
			{
				this.InitializeControlsMethod();
			}

			this.oGame.Start(this);
		}
		catch (ApplicationExitException)
		{
		}
		catch (ResourceMissingException ex)
		{
			MessageBox.Show(ex.Message, "OpenCiv1 resource error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
#if !DEBUG
		catch (Exception e)
		{
			if (this.oGame != null && this.oGame.Log != null)
			{
				this.oGame.Log.WriteLine("");
				this.oGame.Log.WriteLine($"Exception message: {e.Message}");
				this.oGame.Log.WriteLine($"Exception source: {e.Source}");
				this.oGame.Log.WriteLine($"Exception stack trace: {e.StackTrace}");
			}

			MessageBox.Show("There was an error (Exception) in the OpenCiv1 application, "+
				"the details about the error should be in a Log.txt file.");
		}
#endif
		if (!this.bClosing)
		{
			this.bClosing = true;

			try
			{
				if (this.InvokeRequired)
				{
					this.Invoke(this.oCloseForm);
				}
				else
				{
					this.Close();
				}
			}
			catch { }
		}
	}

	private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (this.bClosing || MessageBox.Show("Are you sure you want to quit?", "Exiting application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) ==
			DialogResult.OK)
		{
			this.bClosing = true;

			if (this.oGame != null && this.oGame.CPU != null)
			{
				this.oGame.CPU.OnApplicationExit();
			}
		}
		else
		{
			e.Cancel = true;
		}
	}

	public object? GetObject(string name) => Resources.Properties.Resources.ResourceManager.GetObject(name);
}
