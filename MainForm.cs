using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using IRB.Collections.Generic;

namespace OpenCiv1
{
	public partial class MainForm : Form
	{
		private delegate void InitializeControlsDelegate();
		private delegate void ScreenCountChangeDelegate();
		private delegate void CloseFormDelegate();
		private InitializeControlsDelegate oInitializeControls;
		private ScreenCountChangeDelegate oScreenCountChange;
		private CloseFormDelegate oCloseForm;

		private bool bClosing = false;
		private Thread oGameThread = null;
		private OpenCiv1 oGame = null;
		private Size oScreenSize;
		private Rectangle oMouseRect = Rectangle.Empty;
		private Point oMouseLocation = Point.Empty;
		private MouseButtons oMouseButtons = MouseButtons.None;
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

		public Point ScreenMouseLocation
		{
			get { return this.oMouseLocation; }
		}

		public MouseButtons ScreenMouseButtons
		{
			get { return this.oMouseButtons; }
		}

		private void InitializeControlsMethod()
		{
			ScreenCountChangeMethod();

			this.cmdPause.Enabled = true;
			this.cmdRun.Enabled = true;
			this.tsScreens.Enabled = true;

			this.cmdPause.Visible = true;
			this.cmdRun.Visible = false;
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
			if (this.oGame != null && this.oGame.VGADriver != null)
			{
				lock (this.oGame.VGADriver.VGALock)
				{
					int iScreenCount = 0;
					// update screen list
					this.lblScreens.Text = $"Screens ({this.oGame.VGADriver.Screens.Count})";

					this.tsScreens.DropDownItems.Clear();
					for (int i = 0; i < this.oGame.VGADriver.Screens.Count; i++)
					{
						BKeyValuePair<int, VGABitmap> item = this.oGame.VGADriver.Screens[i];

						ToolStripMenuItem menuItem = new ToolStripMenuItem($"Screen ({item.Key})");
						//menuItem.Checked = true;
						menuItem.CheckState = item.Value.Visible ? CheckState.Checked : CheckState.Unchecked;
						menuItem.Tag = item.Key;
						//menuItem.CheckOnClick = true;
						menuItem.Click += MenuItem_Clicked;

						this.tsScreens.DropDownItems.Add(menuItem);

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
							this.oScreenSize = new Size(640, 400);
							break;

						case 2:
							this.iScreenColumns = 2;
							this.iScreenRows = 1;
							this.oScreenSize = new Size(320, 200);
							break;

						case 3:
							this.iScreenColumns = 2;
							this.iScreenRows = 2;
							this.oScreenSize = new Size(320, 200);
							break;

						case 4:
							this.iScreenColumns = 2;
							this.iScreenRows = 2;
							this.oScreenSize = new Size(320, 200);
							break;

						case 5:
							this.iScreenColumns = 3;
							this.iScreenRows = 2;
							this.oScreenSize = new Size(320, 200);
							break;

						case 6:
							this.iScreenColumns = 3;
							this.iScreenRows = 2;
							this.oScreenSize = new Size(320, 200);
							break;

						case 7:
							this.iScreenColumns = 3;
							this.iScreenRows = 3;
							this.oScreenSize = new Size(320, 200);
							break;

						case 8:
							this.iScreenColumns = 3;
							this.iScreenRows = 3;
							this.oScreenSize = new Size(320, 200);
							break;
					}
					this.ClientSize = new Size(this.oScreenSize.Width * this.iScreenColumns + 1 + this.iScreenColumns,
						this.tsMain.Height + this.oScreenSize.Height * this.iScreenRows + 1 + this.iScreenRows);
					this.oMouseRect = new Rectangle(Point.Empty, this.oScreenSize);
					this.Invalidate();
				}
			}
			else
			{
				this.iScreenColumns = 1;
				this.iScreenRows = 1;
				this.oScreenSize = new Size(640, 400);

				this.ClientSize = new Size(this.oScreenSize.Width * this.iScreenColumns + 1 + this.iScreenColumns,
					this.tsMain.Height + this.oScreenSize.Height * this.iScreenRows + 1 + this.iScreenRows);
				this.oMouseRect = new Rectangle(Point.Empty, this.oScreenSize);
				this.Invalidate();
			}
		}

		private void CloseFormMethod()
		{
			this.Close();
		}

		private void MenuItem_Clicked(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
				int iScreen = Convert.ToInt32(menuItem.Tag);

				if (this.oGame != null && this.oGame.VGADriver != null)
				{
					if (this.oGame.VGADriver.Screens.ContainsKey(iScreen))
					{
						VGABitmap screen = this.oGame.VGADriver.Screens.GetValueByKey(iScreen);

						screen.Visible = !screen.Visible;

						OnScreenCountChange();
					}
				}
			}
		}

		private void tmrRefresh_Tick(object sender, EventArgs e)
		{
			if (this.oGame != null && this.oGame.VGADriver != null)
			{
				lock (this.oGame.VGADriver.VGALock)
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

			if (this.oGame != null && this.oGame.VGADriver != null)
			{
				lock (this.oGame.VGADriver.VGALock)
				{
					RedrawScreens(g, true);
				}
			}
		}

		private void RedrawScreens(Graphics g, bool forceRedraw)
		{
			int iColumn = 0;
			int iRow = 0;

			for (int i = 0; i < this.oGame.VGADriver.Screens.Count; i++)
			{
				BKeyValuePair<int, VGABitmap> item = this.oGame.VGADriver.Screens[i];

				if (item.Value.Visible)
				{
					if (item.Value.Modified || forceRedraw)
					{
						Rectangle rect = new Rectangle((iColumn * this.oScreenSize.Width) + (iColumn + 1),
							this.tsMain.Height + (iRow * this.oScreenSize.Height) + (iRow + 1),
							this.oScreenSize.Width, this.oScreenSize.Height);
						g.DrawImage(item.Value.Bitmap, rect);
						g.DrawString($"{item.Key}", this.oFont, Brushes.White, rect.Left + 5.0f, rect.Top + 5.0f);
						g.DrawRectangle(Pens.Purple, (iColumn * this.oScreenSize.Width) + iColumn,
							this.tsMain.Height + (iRow * this.oScreenSize.Height) + iRow,
							this.oScreenSize.Width + 1, this.oScreenSize.Height + 1);

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

			if (this.oGame.VGADriver.CPU.Pause)
			{
				string sTemp = "Game paused";
				SizeF size = g.MeasureString(sTemp, this.oLargeFont);
				g.DrawString(sTemp, this.oLargeFont, Brushes.White,
					(float)((this.oScreenSize.Width * this.iScreenColumns) - size.Width) / 2.0f,
					(float)((this.oScreenSize.Height * this.iScreenRows) - size.Height) / 2.0f);
			}
		}

		private void Form_KeyPress(object sender, KeyPressEventArgs e)
		{
			lock (this.oGame.VGADriver.VGALock)
			{
				this.oGame.VGADriver.Keys.Enqueue(e.KeyChar);
			}
		}

		private void Form_KeyDown(object sender, KeyEventArgs e)
		{
			lock (this.oGame.VGADriver.VGALock)
			{
				if (e.Modifiers == Keys.None)
				{
					switch (e.KeyCode)
					{
						case Keys.NumPad0:
							// for testing
							this.oGame.VGADriver.Keys.Enqueue(0x475c);
							break;

						case Keys.F1:
							this.oGame.VGADriver.Keys.Enqueue(0x3b00);
							break;

						case Keys.F2:
							this.oGame.VGADriver.Keys.Enqueue(0x3c00);
							break;

						case Keys.F3:
							this.oGame.VGADriver.Keys.Enqueue(0x3d00);
							break;

						case Keys.F4:
							this.oGame.VGADriver.Keys.Enqueue(0x3e00);
							break;

						case Keys.F5:
							this.oGame.VGADriver.Keys.Enqueue(0x3f00);
							break;

						case Keys.F6:
							this.oGame.VGADriver.Keys.Enqueue(0x4000);
							break;

						case Keys.F7:
							this.oGame.VGADriver.Keys.Enqueue(0x4100);
							break;

						case Keys.F8:
							this.oGame.VGADriver.Keys.Enqueue(0x4200);
							break;

						case Keys.F9:
							this.oGame.VGADriver.Keys.Enqueue(0x4300);
							break;

						case Keys.F10:
							this.oGame.VGADriver.Keys.Enqueue(0x4400);
							break;

						case Keys.Down:
							this.oGame.VGADriver.Keys.Enqueue(0x5000);
							break;

						case Keys.Left:
							this.oGame.VGADriver.Keys.Enqueue(0x4b00);
							break;

						case Keys.Right:
							this.oGame.VGADriver.Keys.Enqueue(0x4d00);
							break;

						case Keys.Up:
							this.oGame.VGADriver.Keys.Enqueue(0x4800);
							break;

						case Keys.Home:
							this.oGame.VGADriver.Keys.Enqueue(0x4700);
							break;

						case Keys.End:
							this.oGame.VGADriver.Keys.Enqueue(0x4f00);
							break;

						case Keys.PageUp:
							this.oGame.VGADriver.Keys.Enqueue(0x4900);
							break;

						case Keys.PageDown:
							this.oGame.VGADriver.Keys.Enqueue(0x5100);
							break;
					}
				}
				else if ((e.Modifiers & Keys.Shift) == Keys.Shift)
				{
					switch (e.KeyCode)
					{
						case Keys.Down:
							this.oGame.VGADriver.Keys.Enqueue(0x5032);
							break;

						case Keys.Left:
							this.oGame.VGADriver.Keys.Enqueue(0x4b34);
							break;

						case Keys.Right:
							this.oGame.VGADriver.Keys.Enqueue(0x4d36);
							break;

						case Keys.Up:
							this.oGame.VGADriver.Keys.Enqueue(0x4838);
							break;

						case Keys.Home:
							this.oGame.VGADriver.Keys.Enqueue(0x4737);
							break;

						case Keys.End:
							this.oGame.VGADriver.Keys.Enqueue(0x4f31);
							break;

						case Keys.PageUp:
							this.oGame.VGADriver.Keys.Enqueue(0x4939);
							break;

						case Keys.PageDown:
							this.oGame.VGADriver.Keys.Enqueue(0x5133);
							break;
					}
				}
				else if ((e.Modifiers & Keys.Alt) == Keys.Alt)
				{
					e.Handled = true;
					e.SuppressKeyPress = true;

					switch (e.KeyCode)
					{
						case Keys.A:
							this.oGame.VGADriver.Keys.Enqueue(0x1e00);
							break;

						case Keys.C:
							this.oGame.VGADriver.Keys.Enqueue(0x2e00);
							break;

						case Keys.D:
							this.oGame.VGADriver.Keys.Enqueue(0x2000);
							break;

						case Keys.G:
							this.oGame.VGADriver.Keys.Enqueue(0x2200);
							break;

						case Keys.H:
							this.oGame.VGADriver.Keys.Enqueue(0x2300);
							break;

						case Keys.M:
							this.oGame.VGADriver.Keys.Enqueue(0x3200);
							break;

						case Keys.O:
							this.oGame.VGADriver.Keys.Enqueue(0x1800);
							break;

						case Keys.Q:
							this.oGame.VGADriver.Keys.Enqueue(0x1000);
							break;

						case Keys.R:
							this.oGame.VGADriver.Keys.Enqueue(0x1300);
							break;

						case Keys.V:
							this.oGame.VGADriver.Keys.Enqueue(0x2f00);
							break;

						case Keys.W:
							this.oGame.VGADriver.Keys.Enqueue(0x1100);
							break;
					}
				}
			}
		}

		private void Form_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = new Point(e.Location.X, e.Location.Y - this.tsMain.Height);

			if (this.oMouseRect.Contains(location))
			{
				this.oMouseLocation = new Point(location.X / (this.oScreenSize.Width / 320),
					location.Y / (this.oScreenSize.Height / 200));
				this.oMouseButtons = e.Button;
			}
		}

		private void Form_MouseDown(object sender, MouseEventArgs e)
		{
			Point location = new Point(e.Location.X, e.Location.Y - this.tsMain.Height);

			if (this.oMouseRect.Contains(location))
			{
				if (e.Button == MouseButtons.Left)
				{
					this.oMouseButtons |= MouseButtons.Left;
				}
				else if (e.Button == MouseButtons.Right)
				{
					this.oMouseButtons |= MouseButtons.Right;
				}
			}
		}

		private void Form_MouseUp(object sender, MouseEventArgs e)
		{
			Point location = new Point(e.Location.X, e.Location.Y - this.tsMain.Height);

			if (this.oMouseRect.Contains(location))
			{
				if (e.Button == MouseButtons.Left)
				{
					this.oMouseButtons |= MouseButtons.Left;
					this.oMouseButtons ^= MouseButtons.Left;
				}
				else if (e.Button == MouseButtons.Right)
				{
					this.oMouseButtons |= MouseButtons.Right;
					this.oMouseButtons ^= MouseButtons.Right;
				}
			}
		}

		private void cmdPause_Click(object sender, EventArgs e)
		{
			if (this.oGame != null && this.oGame.CPU != null)
			{
				if (!this.oGame.VGADriver.CPU.Pause)
				{
					this.oGame.VGADriver.CPU.Pause = true;
					this.cmdPause.Visible = false;
					this.cmdRun.Visible = true;

					lock (this.oGame.VGADriver.VGALock)
					{
						Graphics g = Graphics.FromHwnd(this.Handle);
						RedrawScreens(g, true);
						g.Flush();
						g.Dispose();
					}
				}
			}
		}

		private void cmdRun_Click(object sender, EventArgs e)
		{
			if (this.oGame != null && this.oGame.CPU != null)
			{
				if (this.oGame.VGADriver.CPU.Pause)
				{
					this.oGame.VGADriver.CPU.Pause = false;
					this.cmdPause.Visible = true;
					this.cmdRun.Visible = false;

					lock (this.oGame.VGADriver.VGALock)
					{
						Graphics g = Graphics.FromHwnd(this.Handle);
						RedrawScreens(g, true);
						g.Flush();
						g.Dispose();
					}
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

				this.oGame.Start();
			}
			catch (ApplicationExitException)
			{
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

					/*if (this.oGameThread != null)
					{
						while (this.oGameThread.ThreadState == ThreadState.Running ||
							this.oGameThread.ThreadState == ThreadState.WaitSleepJoin)
						{
							Thread.Sleep(200);
						}
					}*/
				}
			}
			else
			{
				e.Cancel = true;
			}
		}
	}
}