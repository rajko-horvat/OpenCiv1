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

		private void VGACardForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			aKeys.Enqueue(e.KeyChar);
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
	}
}
