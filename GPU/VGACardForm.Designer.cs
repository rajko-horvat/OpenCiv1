namespace Disassembler
{
	partial class VGACardForm
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
			this.imgScreen = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.imgScreen)).BeginInit();
			this.SuspendLayout();
			// 
			// imgScreen
			// 
			this.imgScreen.BackColor = System.Drawing.Color.Black;
			this.imgScreen.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgScreen.Location = new System.Drawing.Point(0, 0);
			this.imgScreen.Margin = new System.Windows.Forms.Padding(0);
			this.imgScreen.Name = "imgScreen";
			this.imgScreen.Size = new System.Drawing.Size(624, 384);
			this.imgScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.imgScreen.TabIndex = 0;
			this.imgScreen.TabStop = false;
			// 
			// VGACardForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(624, 384);
			this.ControlBox = false;
			this.Controls.Add(this.imgScreen);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "VGACardForm";
			this.ShowIcon = false;
			this.Text = "VGA display";
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VGACardForm_KeyPress);
			((System.ComponentModel.ISupportInitialize)(this.imgScreen)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		public System.Windows.Forms.PictureBox imgScreen;
	}
}