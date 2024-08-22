using Avalonia.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCiv1.Graphics
{
	public class PaletteCycleSlot
	{
		public bool Active = false;
		public int Speed;
		public int SpeedCount;
		public byte StartPosition;
		public int CurrentPosition = 0;
		public Color[] Palette;

		public PaletteCycleSlot(int speed, byte startPosition, Color[] colors)
		{
			this.Speed = speed;
			this.StartPosition = startPosition;
			this.Palette = colors;
		}
	}
}
