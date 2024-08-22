using System;
using System.ComponentModel;

namespace OpenCiv1.Graphics
{
	/// <summary>Represents an Width and Height of an object in a two-dimensional plane</summary>
	[Serializable]
	public class GSize
	{
		private int width;
		private int height;

		/// <summary>Initializes a new instance of the GSize class with the Width and Height set to 0</summary>
		internal GSize()
		{
			this.width = 0;
			this.height = 0;
		}

		/// <summary>Initializes a new instance of the GSize class with one value for width and height dimension</summary>
		/// <param name="xy">The width and height dimension</param>
		public GSize(int wh)
		{
			this.width = wh;
			this.height = wh;
		}

		/// <summary>Initializes a new instance of the GSize class from the specified GPoint class</summary>
		/// <param name="pt">The GPoint class from which to initialize this GSize class</param>
		public GSize(GPoint pt)
		{
			this.width = pt.X;
			this.height = pt.Y;
		}

		/// <summary>Initializes a new instance of the GSize class from the specified dimensions</summary>
		/// <param name="width">The width component of the new GSize</param>
		/// <param name="height">The height component of the new GSize</param>
		public GSize(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		/// <summary>Clones a current GSize class into new GSize class</summary>
		/// <returns>A new GSize class with the same Width and Height</returns>
		public GSize Clone()
		{
			return new GSize(this.width, this.height);
		}

		/// <summary>Tests if GSize Width and Height are zero</summary>
		[Browsable(false)]
		public bool IsZero => this.width == 0 && this.height == 0;

		/// <summary>Gets or sets the horizontal component of this GSize class</summary>
		/// <returns>The horizontal component of this GSize class, typically measured in pixels</returns>
		public int Width
		{
			get => this.width;
			set => this.width = value;
		}

		/// <summary>Gets or sets the vertical component of this GSize class</summary>
		/// <returns>The vertical component of this GSize class, typically measured in pixels</returns>
		public int Height
		{
			get => this.height;
			set => this.height = value;
		}

		/// <summary>Converts the specified GSize class to a GPoint class</summary>
		/// <returns>The GPoint class to which this operator converts</returns>
		/// <param name="GSize">The GSize class to convert</param>
		public static explicit operator GPoint(GSize GSize) => new GPoint(GSize.Width, GSize.Height);

		/// <summary>Adds the width and height of one GSize class to the width and height of another GSize class</summary>
		/// <returns>A GSize class that is the result of the addition operation</returns>
		/// <param name="sz1">The first GSize to add</param>
		/// <param name="sz2">The second GSize to add</param>
		public static GSize operator +(GSize sz1, GSize sz2) => GSize.Add(sz1, sz2);

		/// <summary>Subtracts the width and height of one GSize class from the width and height of another GSize class</summary>
		/// <returns>A GSize class that is the result of the subtraction operation</returns>
		/// <param name="left">The GSize class on the left side of the subtraction operator</param>
		/// <param name="right">The GSize class on the right side of the subtraction operator</param>
		public static GSize operator -(GSize left, GSize right) => GSize.Subtract(left, right);

		/// <summary>Tests whether two GSize structures are equal</summary>
		/// <returns>true if <paramref name="left" /> and <paramref name="right" /> have equal width and height; otherwise, false</returns>
		/// <param name="left">The GSize class on the left side of the equality operator</param>
		/// <param name="right">The GSize class on the right of the equality operator</param>
		public static bool operator ==(GSize left, GSize right) => left.Width == right.Width && left.Height == right.Height;

		/// <summary>Tests whether two GSize structures are different</summary>
		/// <returns>true if <paramref name="left" /> and <paramref name="right" /> differ either in width or height; false if <paramref name="left" /> and <paramref name="right" /> are equal</returns>
		/// <param name="left">The GSize class on the left of the inequality operator</param>
		/// <param name="right">The GSize class on the right of the inequality operator</param>
		public static bool operator !=(GSize left, GSize right) => !(left == right);

		/// <summary>Adds the width and height of one GSize class to the width and height of another GSize class</summary>
		/// <returns>A GSize class that is the result of the addition operation</returns>
		/// <param name="sz1">The first GSize class to add</param>
		/// <param name="sz2">The second GSize class to add</param>
		public static GSize Add(GSize sz1, GSize sz2) => new GSize(sz1.Width + sz2.Width, sz1.Height + sz2.Height);

		/// <summary>Subtracts the width and height of one GSize class from the width and height of another GSize class</summary>
		/// <returns>A GSize class that is a result of the subtraction operation</returns>
		/// <param name="left">The GSize class on the left side of the subtraction operator</param>
		/// <param name="right">The GSize class on the right side of the subtraction operator</param>
		public static GSize Subtract(GSize left, GSize right) => new GSize(left.Width - right.Width, left.Height - right.Height);

		/// <summary>Tests to see whether the specified object is a GSize class with the same dimensions as this GSize class</summary>
		/// <returns>true if <paramref name="obj" /> is a GSize and has the same width and height as this GSize; otherwise, false</returns>
		/// <param name="obj">The <see cref="T:System.Object" /> to test</param>
		public override bool Equals(object? obj) => obj != null && obj is GSize GSize && GSize.width == this.width && GSize.height == this.height;

		/// <summary>Returns a hash code for this GSize class</summary>
		/// <returns>An integer value that specifies a hash value for this GSize class</returns>
		public override int GetHashCode() => this.width ^ this.height;

		/// <summary>Creates a human-readable string that represents this GSize class</summary>
		/// <returns>A string that represents this GSize</returns>
		public override string ToString() => $"{{Width={this.width}, Height={this.height}}}";
	}
}
