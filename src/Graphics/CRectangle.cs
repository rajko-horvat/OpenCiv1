using IRB.VirtualCPU;

namespace OpenCiv1.Graphics
{
	public class CRectangle
	{
		public int ScreenID = 0;
		public int Left = 0;
		public int Top = 0;
		public int Width = 320;
		public int Height = 200;
		public ushort Flags = 0;
		public byte FrontColor = 0;
		public byte PixelMode = 0;
		public byte BackColor = 15;
		public byte Undefined0 = 0;
		public int FontID = 0;

		public CRectangle()
		{
		}

		public CRectangle(int screenID, int left, int top, int width, int height,
			ushort flags, byte frontColor, byte pixelMode, byte backColor, byte undefined0, int fontID)
		{
			this.ScreenID = screenID;
			this.Left = left;
			this.Top = top;
			this.Width = width;
			this.Height = height;
			this.Flags = flags;
			this.FrontColor = frontColor;
			this.PixelMode = pixelMode;
			this.BackColor = backColor;
			this.Undefined0 = undefined0;
			this.FontID = fontID;
		}
	}
}
