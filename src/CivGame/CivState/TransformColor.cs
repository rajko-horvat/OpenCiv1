using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1
{
	public class TransformColor
	{
		public HSVColor FromHSV;
		public HSVColor ToHSV;
		private double AStep;
		private double HStep;
		private double SStep;
		private double VStep;

		public TransformColor(HSVColor from, HSVColor to, double steps)
		{
			this.FromHSV = from;
			this.ToHSV = to;

			if (to.Value == 0.0)
			{
				// special case for black color
				this.AStep = (to.Alpha - from.Alpha) / steps;
				this.HStep = 0.0;
				this.SStep = 0.0;
				this.VStep = (to.Value - from.Value) / steps;
			}
			else
			{
				this.AStep = (to.Alpha - from.Alpha) / steps;
				this.HStep = (to.Hue - from.Hue) / steps;
				this.SStep = (to.Saturation - from.Saturation) / steps;
				this.VStep = (to.Value - from.Value) / steps;
			}
		}

		public HSVColor GetNextColor(double step)
		{
			if (this.FromHSV.Value == 0.0)
			{
				// special case for transition from black color
				return new HSVColor(this.FromHSV.Alpha + this.AStep * step,
					this.ToHSV.Hue,
					this.ToHSV.Saturation,
					this.FromHSV.Value + this.VStep * step);
			}
			else
			{
				return new HSVColor(this.FromHSV.Alpha + this.AStep * step,
					this.FromHSV.Hue + this.HStep * step,
					this.FromHSV.Saturation + this.SStep * step,
					this.FromHSV.Value + this.VStep * step);
			}
		}
	}
}
