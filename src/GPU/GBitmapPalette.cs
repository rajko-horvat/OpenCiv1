﻿using Avalonia.Media;
using System;

namespace OpenCiv1.GPU
{
	public class GBitmapPalette
	{
		#region Default palette
		public static readonly Color[] DefaultPalette = new Color[] {
			Color.FromUInt32(0x000000),
			Color.FromUInt32(0x00002a),
			Color.FromUInt32(0x002a00),
			Color.FromUInt32(0x002a2a),
			Color.FromUInt32(0x2a0000),
			Color.FromUInt32(0x2a002a),
			Color.FromUInt32(0x2a1500),
			Color.FromUInt32(0x2a2a2a),
			Color.FromUInt32(0x151515),
			Color.FromUInt32(0x15153f),
			Color.FromUInt32(0x153f15),
			Color.FromUInt32(0x153f3f),
			Color.FromUInt32(0x3f1515),
			Color.FromUInt32(0x3f153f),
			Color.FromUInt32(0x3f3f15),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x000000),
			Color.FromUInt32(0x0a0a0a),
			Color.FromUInt32(0x151515),
			Color.FromUInt32(0x1f1f1f),
			Color.FromUInt32(0x2a2a2a),
			Color.FromUInt32(0x353535),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x150000),
			Color.FromUInt32(0x1f0a0a),
			Color.FromUInt32(0x2a1515),
			Color.FromUInt32(0x2a0000),
			Color.FromUInt32(0x2a0a00),
			Color.FromUInt32(0x350a0a),
			Color.FromUInt32(0x35150a),
			Color.FromUInt32(0x351f1f),
			Color.FromUInt32(0x3f1515),
			Color.FromUInt32(0x3f2a2a),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x150a00),
			Color.FromUInt32(0x1f150a),
			Color.FromUInt32(0x2a1f15),
			Color.FromUInt32(0x2a1500),
			Color.FromUInt32(0x351f0a),
			Color.FromUInt32(0x352a1f),
			Color.FromUInt32(0x3f2a15),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x151500),
			Color.FromUInt32(0x1f1f0a),
			Color.FromUInt32(0x151f00),
			Color.FromUInt32(0x2a2a15),
			Color.FromUInt32(0x35351f),
			Color.FromUInt32(0x352a0a),
			Color.FromUInt32(0x3f3f2a),
			Color.FromUInt32(0x3f3f15),
			Color.FromUInt32(0x001500),
			Color.FromUInt32(0x151f15),
			Color.FromUInt32(0x0a1f0a),
			Color.FromUInt32(0x1f2a1f),
			Color.FromUInt32(0x152a15),
			Color.FromUInt32(0x1f2a0a),
			Color.FromUInt32(0x002a00),
			Color.FromUInt32(0x002a15),
			Color.FromUInt32(0x1f351f),
			Color.FromUInt32(0x1f350a),
			Color.FromUInt32(0x0a350a),
			Color.FromUInt32(0x0a351f),
			Color.FromUInt32(0x2a3f2a),
			Color.FromUInt32(0x2a3f15),
			Color.FromUInt32(0x153f15),
			Color.FromUInt32(0x153f2a),
			Color.FromUInt32(0x001515),
			Color.FromUInt32(0x0a1f1f),
			Color.FromUInt32(0x152a2a),
			Color.FromUInt32(0x002a2a),
			Color.FromUInt32(0x1f3535),
			Color.FromUInt32(0x0a3535),
			Color.FromUInt32(0x2a3f3f),
			Color.FromUInt32(0x153f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x000015),
			Color.FromUInt32(0x0a0a1f),
			Color.FromUInt32(0x15152a),
			Color.FromUInt32(0x00152a),
			Color.FromUInt32(0x00002a),
			Color.FromUInt32(0x15002a),
			Color.FromUInt32(0x0a0a35),
			Color.FromUInt32(0x0a1f35),
			Color.FromUInt32(0x1f0a35),
			Color.FromUInt32(0x1f1f35),
			Color.FromUInt32(0x15153f),
			Color.FromUInt32(0x152a3f),
			Color.FromUInt32(0x2a153f),
			Color.FromUInt32(0x2a2a3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x150a15),
			Color.FromUInt32(0x150015),
			Color.FromUInt32(0x1f151f),
			Color.FromUInt32(0x1f0a1f),
			Color.FromUInt32(0x2a152a),
			Color.FromUInt32(0x2a002a),
			Color.FromUInt32(0x351f35),
			Color.FromUInt32(0x350a35),
			Color.FromUInt32(0x3f153f),
			Color.FromUInt32(0x3f2a3f),
			Color.FromUInt32(0x3f3f3f),
			Color.FromUInt32(0x2a0a15),
			Color.FromUInt32(0x2a0015),
			Color.FromUInt32(0x35151f),
			Color.FromUInt32(0x350a1f),
			Color.FromUInt32(0x3f152a)
		};
		#endregion

		private GBitmap oParent;
		private Color[] oPalette;

		internal GBitmapPalette(GBitmap bitmap)
		{
			this.oParent = bitmap;

			this.oPalette = new Color[256];

			for (int i = 0; i < DefaultPalette.Length; i++)
			{
				this.oPalette[i] = DefaultPalette[i];
			}

			for (int i = DefaultPalette.Length; i < 256; i++)
			{
				this.oPalette[i] = Color.FromUInt32(0);
			}
		}

		public int Length
		{
			get => this.oPalette.Length;
		}

		public Color this[byte colorIndex]
		{
			get => this.oPalette[colorIndex];
			set => this.oPalette[colorIndex] = value;
		}
	}
}
