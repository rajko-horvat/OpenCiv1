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
				if (e.Modifiers == System.Windows.Forms.Keys.None)
				{
					switch (e.KeyCode)
					{
						case Keys.NumPad0:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x3b');
							break;

						case System.Windows.Forms.Keys.F1:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x3b');
							break;

						case System.Windows.Forms.Keys.F2:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x3c');
							break;

						case System.Windows.Forms.Keys.F3:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x3d');
							break;

						case System.Windows.Forms.Keys.F4:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x3e');
							break;

						case System.Windows.Forms.Keys.F5:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x3f');
							break;

						case System.Windows.Forms.Keys.F6:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x40');
							break;

						case System.Windows.Forms.Keys.F7:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x41');
							break;

						case System.Windows.Forms.Keys.F8:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x42');
							break;

						case System.Windows.Forms.Keys.F9:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x43');
							break;

						case System.Windows.Forms.Keys.F10:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x44');
							break;

						case System.Windows.Forms.Keys.Down:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x50');
							break;

						case System.Windows.Forms.Keys.Left:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x4b');
							break;

						case System.Windows.Forms.Keys.Right:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x4d');
							break;

						case System.Windows.Forms.Keys.Up:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x48');
							break;

						case System.Windows.Forms.Keys.Home:
							this.oDriver.Keys.Enqueue('\x0');
							this.oDriver.Keys.Enqueue('\x47');
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
	}
}
