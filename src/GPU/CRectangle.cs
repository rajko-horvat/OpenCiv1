using IRB.VirtualCPU;

namespace OpenCiv1.GPU
{
	public class CRectangle
	{
		public short ScreenID = 0;
		public short Left = 0;
		public short Top = 0;
		public short Width = 320;
		public short Height = 200;
		public ushort Flags = 0;
		public byte FrontColor = 0;
		public byte PixelMode = 0;
		public byte BackColor = 15;
		public byte Undefined0 = 0;
		public short FontID = 0;

		public CRectangle()
		{
		}

		public CRectangle(short screenID, short left, short top, short width, short height,
			ushort flags, byte frontColor, byte pixelMode, byte backColor, byte undefined0, short fontID)
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

		/// <summary>Converts this CRectangle to a human-readable string</summary>
		/// <returns>A string that represents this CRectangle</returns>
		public override string ToString()
		{
			return $"{{Screen={this.ScreenID}, Left={this.Left}, Top={this.Top}, Width={this.Width}, Height={this.Height}}}";
		}
	}
}
