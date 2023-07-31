using Civilization1;
using IRB.Collections.Generic;
using IRB.Collections.Generic.Trees;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Disassembler
{
	public partial class VGAForm : Form
	{
		private VGADriver oDriver = null;
		private delegate void ScreenCountChange();
		private ScreenCountChange oScreenCountChange;
		private Size oScreenSize;
		private Rectangle oMouseRect = Rectangle.Empty;
		private Point oMouseLocation = Point.Empty;
		private MouseButtons oMouseButtons = MouseButtons.None;
		private int iScreenColumns = 1;
		private int iScreenRows = 1;
		private Font oFont;
		private Font oLargeFont;

		public VGAForm()
		{
			InitializeComponent();
		}

		public VGAForm(VGADriver driver)
		{
			this.oDriver = driver;

			InitializeComponent();
			this.SetStyle(ControlStyles.Opaque, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			//this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.oScreenCountChange = new ScreenCountChange(ScreenCountChangeMethod);
			ScreenCountChangeMethod();
			this.oFont = new Font("Verdana", 10.0f, FontStyle.Regular, GraphicsUnit.Pixel);
			this.oLargeFont = new Font("Verdana", 40.0f, FontStyle.Bold, GraphicsUnit.Pixel);

			if (this.oDriver.CPU.Pause)
			{
				this.cmdPause.Visible = false;
				this.cmdRun.Visible = true;
			}
			else
			{
				this.cmdPause.Visible = true;
				this.cmdRun.Visible = false;
			}
		}

		public Point ScreenMouseLocation
		{
			get { return this.oMouseLocation; }
		}

		public MouseButtons ScreenMouseButtons
		{
			get { return this.oMouseButtons; }
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
			lock (this.oDriver.VGALock)
			{
				int iScreenCount = 0;
				// update screen list
				this.lblScreens.Text = $"Screens ({this.oDriver.Screens.Count})";

				this.tsScreens.DropDownItems.Clear();
				for (int i = 0; i < this.oDriver.Screens.Count; i++)
				{
					BKeyValuePair<int, VGABitmap> item = this.oDriver.Screens[i];

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
				this.ClientSize = new Size(this.oScreenSize.Width * this.iScreenColumns + 1 + this.iScreenColumns + 1,
					this.tsMain.Height + this.oScreenSize.Height * this.iScreenRows + 1 + this.iScreenRows + 1);
				this.oMouseRect = new Rectangle(Point.Empty, this.oScreenSize);
				this.Invalidate();
			}
		}

		private void MenuItem_Clicked(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
				int iScreen = Convert.ToInt32(menuItem.Tag);

				if (this.oDriver.Screens.ContainsKey(iScreen))
				{
					VGABitmap screen = this.oDriver.Screens.GetValueByKey(iScreen);

					screen.Visible = !screen.Visible;

					OnScreenCountChange();
				}
			}
		}

		private void tmrRefresh_Tick(object sender, EventArgs e)
		{
			lock (this.oDriver.VGALock)
			{
				Graphics g = Graphics.FromHwnd(this.Handle);
				RedrawScreens(g, false);
				g.Flush();
				g.Dispose();
			}
		}

		private void VGACardForm_Paint(object sender, PaintEventArgs e)
		{
			lock (this.oDriver.VGALock)
			{
				Graphics g = e.Graphics;
				g.FillRectangle(Brushes.Black, this.ClientRectangle);
				RedrawScreens(g, true);
			}
		}

		private void RedrawScreens(Graphics g, bool forceRedraw)
		{
			int iColumn = 0;
			int iRow = 0;

			for (int i = 0; i < this.oDriver.Screens.Count; i++)
			{
				BKeyValuePair<int, VGABitmap> item = this.oDriver.Screens[i];

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
			
			if (this.oDriver.CPU.Pause)
			{
				string sTemp = "Game paused";
				SizeF size = g.MeasureString(sTemp, this.oLargeFont);
				g.DrawString(sTemp, this.oLargeFont, Brushes.White,
					(float)((this.oScreenSize.Width * this.iScreenColumns) - size.Width) / 2.0f,
					(float)((this.oScreenSize.Height * this.iScreenRows) - size.Height) / 2.0f);
			}
		}

		private void VGACardForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			lock (this.oDriver.VGALock)
			{
				this.oDriver.Keys.Enqueue(e.KeyChar);
			}
		}

		private void VGACardForm_KeyDown(object sender, KeyEventArgs e)
		{
			lock (this.oDriver.VGALock)
			{
				if (e.Modifiers == Keys.None)
				{
					switch (e.KeyCode)
					{
						case Keys.NumPad0:
							// for testing
							this.oDriver.Keys.Enqueue(0x475c);
							break;

						case Keys.F1:
							this.oDriver.Keys.Enqueue(0x3b00);
							break;

						case Keys.F2:
							this.oDriver.Keys.Enqueue(0x3c00);
							break;

						case Keys.F3:
							this.oDriver.Keys.Enqueue(0x3d00);
							break;

						case Keys.F4:
							this.oDriver.Keys.Enqueue(0x3e00);
							break;

						case Keys.F5:
							this.oDriver.Keys.Enqueue(0x3f00);
							break;

						case Keys.F6:
							this.oDriver.Keys.Enqueue(0x4000);
							break;

						case Keys.F7:
							this.oDriver.Keys.Enqueue(0x4100);
							break;

						case Keys.F8:
							this.oDriver.Keys.Enqueue(0x4200);
							break;

						case Keys.F9:
							this.oDriver.Keys.Enqueue(0x4300);
							break;

						case Keys.F10:
							this.oDriver.Keys.Enqueue(0x4400);
							break;

						case Keys.Down:
							this.oDriver.Keys.Enqueue(0x5000);
							break;

						case Keys.Left:
							this.oDriver.Keys.Enqueue(0x4b00);
							break;

						case Keys.Right:
							this.oDriver.Keys.Enqueue(0x4d00);
							break;

						case Keys.Up:
							this.oDriver.Keys.Enqueue(0x4800);
							break;

						case Keys.Home:
							this.oDriver.Keys.Enqueue(0x4700);
							break;

						case Keys.End:
							this.oDriver.Keys.Enqueue(0x4f00);
							break;

						case Keys.PageUp:
							this.oDriver.Keys.Enqueue(0x4900);
							break;

						case Keys.PageDown:
							this.oDriver.Keys.Enqueue(0x5100);
							break;
					}
				}
				else if ((e.Modifiers & Keys.Shift) == Keys.Shift)
				{
					switch (e.KeyCode)
					{
						case Keys.Down:
							this.oDriver.Keys.Enqueue(0x5032);
							break;

						case Keys.Left:
							this.oDriver.Keys.Enqueue(0x4b34);
							break;

						case Keys.Right:
							this.oDriver.Keys.Enqueue(0x4d36);
							break;

						case Keys.Up:
							this.oDriver.Keys.Enqueue(0x4838);
							break;

						case Keys.Home:
							this.oDriver.Keys.Enqueue(0x4737);
							break;

						case Keys.End:
							this.oDriver.Keys.Enqueue(0x4f31);
							break;

						case Keys.PageUp:
							this.oDriver.Keys.Enqueue(0x4939);
							break;

						case Keys.PageDown:
							this.oDriver.Keys.Enqueue(0x5133);
							break;
					}
				}
				else if ((e.Modifiers & Keys.Alt) == Keys.Alt)
				{
					switch (e.KeyCode)
					{
						case Keys.H:
							this.oDriver.Keys.Enqueue(0x2300);
							break;

						case Keys.Q:
							this.oDriver.Keys.Enqueue(0x1000);
							break;

						case Keys.W:
							this.oDriver.Keys.Enqueue(0x1100);
							break;

						case Keys.R:
							this.oDriver.Keys.Enqueue(0x1300);
							break;

						case Keys.O:
							this.oDriver.Keys.Enqueue(0x1800);
							break;

						case Keys.A:
							this.oDriver.Keys.Enqueue(0x1e00);
							break;

						case Keys.G:
							this.oDriver.Keys.Enqueue(0x2200);
							break;

						case Keys.C:
							this.oDriver.Keys.Enqueue(0x2e00);
							break;

						case Keys.V:
							this.oDriver.Keys.Enqueue(0x2f00);
							break;

						case Keys.M:
							this.oDriver.Keys.Enqueue(0x3200);
							break;
					}
				}
			}
		}

		private void VGAForm_MouseMove(object sender, MouseEventArgs e)
		{
			Point location = new Point(e.Location.X, e.Location.Y - this.tsMain.Height);

			if (this.oMouseRect.Contains(location))
			{
				this.oMouseLocation = new Point(location.X / (this.oScreenSize.Width / 320),
					location.Y / (this.oScreenSize.Height / 200));
				this.oMouseButtons = e.Button;
			}
		}

		private void VGAForm_MouseDown(object sender, MouseEventArgs e)
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

		private void VGAForm_MouseUp(object sender, MouseEventArgs e)
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
			if (!this.oDriver.CPU.Pause)
			{
				this.oDriver.CPU.Pause = true;
				this.cmdPause.Visible = false;
				this.cmdRun.Visible = true;

				lock (this.oDriver.VGALock)
				{
					Graphics g = Graphics.FromHwnd(this.Handle);
					RedrawScreens(g, true);
					g.Flush();
					g.Dispose();
				}
			}
		}

		private void cmdRun_Click(object sender, EventArgs e)
		{
			if (this.oDriver.CPU.Pause)
			{
				this.oDriver.CPU.Pause = false;
				this.cmdPause.Visible = true;
				this.cmdRun.Visible = false;

				lock (this.oDriver.VGALock)
				{
					Graphics g = Graphics.FromHwnd(this.Handle);
					RedrawScreens(g, true);
					g.Flush();
					g.Dispose();
				}
			}
		}
	}
}
