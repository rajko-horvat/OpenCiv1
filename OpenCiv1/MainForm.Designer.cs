namespace OpenCiv1
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// tmrRefresh
			// 
			this.tmrRefresh.Enabled = true;
			this.tmrRefresh.Interval = 50;
			this.tmrRefresh.Tick += this.tmrRefresh_Tick;
			// 
			// MainForm
			// 
			this.AutoScaleMode = AutoScaleMode.None;
			this.BackColor = Color.Black;
			this.ClientSize = new Size(580, 340);
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.Text = "OpenCiv1";
			this.FormClosing += this.MainForm_FormClosing;
			this.Shown += this.MainForm_Shown;
			this.Paint += this.Form_Paint;
			this.KeyDown += this.Form_KeyDown;
			this.KeyPress += this.Form_KeyPress;
			this.MouseDown += this.Form_MouseDown;
			this.MouseMove += this.Form_MouseMove;
			this.MouseUp += this.Form_MouseUp;
			this.ResumeLayout(false);
		}

		#endregion
		private System.Windows.Forms.Timer tmrRefresh;
	}
}