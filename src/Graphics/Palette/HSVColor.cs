using Avalonia.Media;

[Serializable]
public class HSVColor
{
	private double dAlpha = 1.0;
	private double dHue = 0.0;
	private double dSaturation = 0.0;
	private double dValue = 0.0;

	public HSVColor()
	{ }

	public HSVColor(HSVColor proto)
		: this(proto.Alpha, proto.Hue, proto.Saturation, proto.Value)
	{ }

	public HSVColor(double hue, double saturation, double value) : this(1.0, hue, saturation, value)
	{ }

	public HSVColor(double alpha, double hue, double saturation, double value)
	{
		this.dAlpha = Math.Max(0.0, Math.Min(alpha, 1.0));

		// normalize hue
		if (!double.IsNaN(hue) && !double.IsInfinity(hue))
		{
			if (hue < 0.0)
			{
				hue = 360.0 - (Math.Abs(hue) % 360.0);
			}
			else if (hue > 360.0)
			{
				hue = hue % 360.0;
			}
		}
		else
		{
			hue = 0.0;
		}
		this.dHue = hue;

		this.dSaturation = Math.Max(0.0, Math.Min(saturation, 1.0));
		this.dValue = Math.Max(0.0, Math.Min(value, 1.0));
	}

	public static HSVColor FromColor(Color color)
	{
		return HSVColor.FromRGB(color.A, color.R, color.G, color.B);
	}

	public static HSVColor FromRGB(byte r, byte g, byte b)
	{
		return HSVColor.FromRGB(255, r, g, b);
	}
	public static HSVColor FromRGB(byte a, byte r, byte g, byte b)
	{
		// Normalize the RGB values by scaling them to be between 0 and 1
		double alpha = (double)a / 255.0;
		double red = (double)r / 255.0;
		double green = (double)g / 255.0;
		double blue = (double)b / 255.0;

		double minValue = Math.Min(red, Math.Min(green, blue));
		double maxValue = Math.Max(red, Math.Max(green, blue));
		double delta = maxValue - minValue;

		double h = 0.0;
		double s = 0.0;
		double v = maxValue; // value it between 0 and 1

		// Calculate the hue (in degrees of a circle, between 0 and 360)
		if (maxValue == red)
		{
			if (green >= blue)
			{
				if (delta == 0.0)
				{
					h = 0.0;
				}
				else
				{
					h = 60.0 * (green - blue) / delta;
				}
			}
			else
			{
				h = 60.0 * (green - blue) / delta + 360.0;
			}
		}
		else if (maxValue == green)
		{
			h = 60.0 * (blue - red) / delta + 120.0;
		}
		else
		{
			h = 60.0 * (red - green) / delta + 240.0;
		}

		// Calculate the saturation (between 0 and 1)
		if (maxValue == 0.0)
		{
			s = 0.0;
		}
		else
		{
			s = 1.0 - (minValue / maxValue);
		}

		// Return a color in the new color space
		return new HSVColor(alpha, h, s, v);
	}

	public Color ToColor()
	{
		double a = this.dAlpha;
		double r = 0.0;
		double g = 0.0;
		double b = 0.0;

		if (this.dSaturation == 0.0)
		{
			// If the saturation is 0, then all colors are the same.
			// (This is some flavor of gray.)
			r = this.dValue;
			g = this.dValue;
			b = this.dValue;
		}
		else
		{
			// Calculate the appropriate sector of a 6-part color wheel
			double sectorPos = this.dHue / 60.0;
			int sectorNumber = Convert.ToInt32(Math.Floor(sectorPos));

			// Get the fractional part of the sector
			// (that is, how many degrees into the sector you are)
			double fractionalSector = sectorPos - sectorNumber;

			// Calculate values for the three axes of the color
			double p = this.dValue * (1.0 - this.dSaturation);
			double q = this.dValue * (1.0 - (this.dSaturation * fractionalSector));
			double t = this.dValue * (1.0 - (this.dSaturation * (1.0 - fractionalSector)));

			// Assign the fractional colors to red, green, and blue
			// components based on the sector the angle is in
			switch (sectorNumber)
			{
				case 0:
				case 6:
					r = this.dValue;
					g = t;
					b = p;
					break;
				case 1:
					r = q;
					g = this.dValue;
					b = p;
					break;
				case 2:
					r = p;
					g = this.dValue;
					b = t;
					break;
				case 3:
					r = p;
					g = q;
					b = this.dValue;
					break;
				case 4:
					r = t;
					g = p;
					b = this.dValue;
					break;
				case 5:
					r = this.dValue;
					g = p;
					b = q;
					break;
			}
		}

		// Scale the alpha, red, green, and blue values to be between 0 and 255
		a *= 255.0;
		r *= 255.0;
		g *= 255.0;
		b *= 255.0;

		// Return a color in the new color space
		return Color.FromArgb(Convert.ToByte(Math.Round(a, MidpointRounding.AwayFromZero)),
			Convert.ToByte(Math.Round(r, MidpointRounding.AwayFromZero)),
			Convert.ToByte(Math.Round(g, MidpointRounding.AwayFromZero)),
			Convert.ToByte(Math.Round(b, MidpointRounding.AwayFromZero)));
	}

	public double Alpha
	{
		get
		{
			return this.dAlpha;
		}
		set
		{
			this.dAlpha = Math.Max(0.0, Math.Min(value, 1.0));
		}
	}

	public double Hue
	{
		get
		{
			return this.dHue;
		}
		set
		{
			this.dHue = value;

			// normalize hue
			if (!double.IsNaN(this.dHue) && !double.IsInfinity(this.dHue))
			{
				if (this.dHue < 0.0)
				{
					this.dHue = 360.0 - (Math.Abs(this.dHue) % 360.0);
				}
				else if (this.dHue > 360.0)
				{
					this.dHue = this.dHue % 360.0;
				}
			}
			else
			{
				this.dHue = 0.0;
			}
		}
	}

	public double Saturation
	{
		get
		{
			return this.dSaturation;
		}
		set
		{
			this.dSaturation = Math.Max(0.0, Math.Min(value, 1.0));
		}
	}

	public double Value
	{
		get
		{
			return this.dValue;
		}
		set
		{
			this.dValue = Math.Max(0.0, Math.Min(value, 1.0));
		}
	}

	public override string ToString()
	{
		return $"{{A: {this.dAlpha}, H: {this.dHue}, S: {this.dSaturation}, V: {this.dValue}}}";
	}
}
