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
	public partial class VGACardForm : Form
	{
		private VGACard oGPU = null;
		private Queue<char> aKeys = new Queue<char>();
		private Graphics oGraphics;

		public VGACardForm()
		{
			InitializeComponent();
		}

		public VGACardForm(VGACard gpu)
		{
			this.oGPU = gpu;

			InitializeComponent();
			this.SetStyle(ControlStyles.Opaque, true);
			this.SetStyle(ControlStyles.UserPaint, true);
			//this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);

			this.oGraphics = Graphics.FromHwnd(this.Handle);
		}

		public Queue<char> Keys
		{
			get { return this.aKeys; }
		}

		private void tmrRefresh_Tick(object sender, EventArgs e)
		{
			if (this.oGPU.BitmapChanged)
			{
				lock (this.oGPU.oBitmapLock)
				{
					Graphics g = Graphics.FromHwnd(this.Handle);
					Rectangle rect = this.ClientRectangle;
					//rect.Inflate(-1, -1);
					g.DrawImage(this.oGPU.ScreenBitmap, rect);
					//g.DrawRectangle(Pens.Purple, rect);
					g.Flush();
					g.Dispose();
					this.oGPU.BitmapChanged = false;
				}
			}
		}

		private void VGACardForm_Paint(object sender, PaintEventArgs e)
		{
			lock (this.oGPU.oBitmapLock)
			{
				Graphics g = e.Graphics;
				Rectangle rect = this.ClientRectangle;
				//rect.Inflate(-1, -1);
				g.DrawImage(this.oGPU.ScreenBitmap, rect);
				//g.DrawRectangle(Pens.Purple, rect);
				g.Flush();
				this.oGPU.BitmapChanged = false;
			}
		}

		private void VGACardForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			aKeys.Enqueue(e.KeyChar);
		}

		private void VGACardForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Modifiers == System.Windows.Forms.Keys.None)
			{
				switch (e.KeyCode)
				{
					case System.Windows.Forms.Keys.F1:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x3b');
						break;

					case System.Windows.Forms.Keys.F2:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x3c');
						break;

					case System.Windows.Forms.Keys.F3:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x3d');
						break;

					case System.Windows.Forms.Keys.F4:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x3e');
						break;

					case System.Windows.Forms.Keys.F5:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x3f');
						break;

					case System.Windows.Forms.Keys.F6:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x40');
						break;

					case System.Windows.Forms.Keys.F7:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x41');
						break;

					case System.Windows.Forms.Keys.F8:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x42');
						break;

					case System.Windows.Forms.Keys.F9:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x43');
						break;

					case System.Windows.Forms.Keys.F10:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x44');
						break;

					case System.Windows.Forms.Keys.Down:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x50');
						break;

					case System.Windows.Forms.Keys.Left:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x4b');
						break;

					case System.Windows.Forms.Keys.Right:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x4d');
						break;

					case System.Windows.Forms.Keys.Up:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x48');
						break;

					case System.Windows.Forms.Keys.Home:
						aKeys.Enqueue('\x0');
						aKeys.Enqueue('\x47');
						break;
				}
			}
		}
	}
}
