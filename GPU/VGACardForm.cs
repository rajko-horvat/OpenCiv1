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
		Queue<char> aKeys = new Queue<char>();

		public VGACardForm()
		{
			InitializeComponent();
		}

		public VGACardForm(VGACard gpu)
		{
			this.oGPU = gpu;

			InitializeComponent();
		}

		public delegate void RefreshScreenDelegate();

		public void RefreshScreen()
		{
			this.imgScreen.Image = this.oGPU.Screen;
		}

		private void VGACardForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			aKeys.Enqueue(e.KeyChar);
		}

		public Queue<char> Keys
		{
			get { return this.aKeys; }
		}
	}
}
