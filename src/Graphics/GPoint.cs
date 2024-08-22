using System;
using System.ComponentModel;

namespace OpenCiv1.Graphics
{
	/// <summary>Represents an X and Y coordinate that define a point in a two-dimensional plane</summary>
	[Serializable]
	public class GPoint
	{
		private int x;
		private int y;

		/// <summary>Initializes a new instance of the GPoint class with the X and Y coordinates set to 0</summary>
		public GPoint()
		{
			this.x = 0;
			this.y = 0;
		}

		/// <summary>Initializes a new instance of the GPoint class with one value for horizontal and vertical position</summary>
		/// <param name="xy">The horizontal and vertical position of the point</param>
		public GPoint(int xy)
		{
			this.x = xy;
			this.y = xy;
		}

		/// <summary>Initializes a new instance of the GPoint class with the specified coordinates</summary>
		/// <param name="x">The horizontal position of the point</param>
		/// <param name="y">The vertical position of the point</param>
		public GPoint(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>Initializes a new instance of the GPoint class from a GSize class</summary>
		/// <param name="sz">A GSize class that specifies the coordinates for the new GPoint class</param>
		public GPoint(GSize sz)
		{
			this.x = sz.Width;
			this.y = sz.Height;
		}

		/// <summary>Clones a current GPoint class into new GPoint class</summary>
		/// <returns>A new GPoint class with the same X and Y coordinates</returns>
		public GPoint Clone()
		{
			return new GPoint(this.x, this.y);
		}

		/// <summary>Tests if GPoint X and Y coordinates are zero</summary>
		[Browsable(false)]
		public bool IsZero => this.x == 0 && this.y == 0;

		/// <summary>Gets or sets the x-coordinate of this GPoint class</summary>
		/// <returns>The x-coordinate of this GPoint</returns>
		public int X
		{
			get => this.x;
			set => this.x = value;
		}

		/// <summary>Gets or sets the y-coordinate of this GPoint class</summary>
		/// <returns>The y-coordinate of this GPoint</returns>
		public int Y
		{
			get => this.y;
			set => this.y = value;
		}

		/// <summary>Converts the specified GPoint class to a GSize class</summary>
		/// <returns>The GSize that results from the conversion</returns>
		/// <param name="p">The GPoint to be converted</param>
		public static explicit operator GSize(GPoint pt) => new GSize(pt.X, pt.Y);

		/// <summary>Adds the X and Y coordinate of one GPoint class with the X and Y coordinate of another GPoint class</summary>
		/// <returns>A GPoint class that is the result of the addition operation</returns>
		/// <param name="pt1">The first GPoint to add</param>
		/// <param name="pt2">The second GPoint to add</param>
		public static GPoint operator +(GPoint pt1, GPoint pt2) => GPoint.Add(pt1, pt2);

		/// <summary>Translates a GPoint by a given GSize</summary>
		/// <returns>The translated GPoint</returns>
		/// <param name="pt">The GPoint to translate</param>
		/// <param name="sz">A GSize that specifies the pair of numbers to add to the coordinates of <paramref name="pt" /></param>
		public static GPoint operator +(GPoint pt, GSize sz) => GPoint.Add(pt, sz);

		/// <summary>Subtracts the X and Y coordinate of one GPoint class with the X and Y coordinate of another GPoint class</summary>
		/// <returns>A GPoint class that is the result of the subtract operation</returns>
		/// <param name="left">The GPoint class on the left side of the subtraction operator</param>
		/// <param name="right">The GPoint class on the right side of the subtraction operator</param>
		public static GPoint operator -(GPoint left, GPoint right) => GPoint.Subtract(left, right);

		/// <summary>Translates a GPoint by the negative of a given GSize</summary>
		/// <returns>A GPoint structure that is translated by the negative of a given GSize structure</returns>
		/// <param name="pt">The GPoint to translate</param>
		/// <param name="sz">A GSize that specifies the pair of numbers to subtract from the coordinates of <paramref name="pt" /></param>
		public static GPoint operator -(GPoint pt, GSize sz) => GPoint.Subtract(pt, sz);

		/// <summary>Compares two GPoint objects. The result specifies whether the values of the GPoint.X and GPoint.Y properties of the two GPoint objects are equal</summary>
		/// <returns>true if the GPoint.X and GPoint.Y values of <paramref name="left" /> and <paramref name="right" /> are equal; otherwise, false</returns>
		/// <param name="left">A GPoint to compare</param>
		/// <param name="right">A GPoint to compare</param>
		public static bool operator ==(GPoint left, GPoint right) => (left.X == right.X && left.Y == right.Y);

		/// <summary>Compares two GPoint objects. The result specifies whether the values of the GPoint.X or GPoint.Y properties of the two GPoint objects are unequal</summary>
		/// <returns>true if the values of either the GPoint.X properties or the GPoint.Y properties of <paramref name="left" /> and <paramref name="right" /> differ; otherwise, false</returns>
		/// <param name="left">A GPoint to compare</param>
		/// <param name="right">A GPoint to compare</param>
		public static bool operator !=(GPoint left, GPoint right) => !(left == right);

		/// <summary>Adds the X and Y coordinate of one GPoint class with the X and Y coordinate of another GPoint class</summary>
		/// <returns>A GPoint class that is the result of the addition operation</returns>
		/// <param name="pt1">The first GPoint class to add</param>
		/// <param name="pt2">The second GPoint class to add</param>
		public static GPoint Add(GPoint pt1, GPoint pt2) => new GPoint(pt1.X + pt2.X, pt1.Y + pt2.Y);

		/// <summary>Adds the specified GSize to the specified GPoint</summary>
		/// <returns>The GPoint that is the result of the addition operation</returns>
		/// <param name="pt">The GPoint to add</param>
		/// <param name="sz">The GSize to add</param>
		public static GPoint Add(GPoint pt, GSize sz) => new GPoint(pt.X + sz.Width, pt.Y + sz.Height);

		/// <summary>Subtracts the X and Y coordinate of one GPoint class with the X and Y coordinate of another GPoint class</summary>
		/// <returns>A GPoint class that is the result of the subtract operation</returns>
		/// <param name="left">The GPoint class on the left side of the subtraction operator</param>
		/// <param name="right">The GPoint class on the right side of the subtraction operator</param>
		public static GPoint Subtract(GPoint left, GPoint right) => new GPoint(left.X - right.X, left.Y - right.Y);

		/// <summary>Returns the result of subtracting specified GSize from the specified GPoint</summary>
		/// <returns>The GPoint that is the result of the subtraction operation</returns>
		/// <param name="pt">The GPoint to be subtracted from</param>
		/// <param name="sz">The GSize to subtract from the GPoint</param>
		public static GPoint Subtract(GPoint pt, GSize sz) => new GPoint(pt.X - sz.Width, pt.Y - sz.Height);

		/// <summary>Translates this GPoint by the specified amount</summary>
		/// <param name="dx">The amount to offset the x-coordinate</param>
		/// <param name="dy">The amount to offset the y-coordinate</param>
		public void Offset(int dx, int dy)
		{
			this.X += dx;
			this.Y += dy;
		}

		/// <summary>Translates this GPoint by the specified GPoint</summary>
		/// <param name="pt">The GPoint used to offset this GPoint</param>
		public void Offset(GPoint pt)
		{
			this.Offset(pt.X, pt.Y);
		}

		/// <summary>Returns new GPoint class containing absoulte X and Y coordinates</summary>
		/// <returns>A GPoint class containing absolute coordinates</returns>
		/// <param name="pt">The GPoint class to contert to absolute coordinates</param>
		public static GPoint Abs(GPoint pt) => new GPoint(Math.Abs(pt.X), Math.Abs(pt.Y));

		/// <summary>Specifies whether this GPoint contains the same coordinates as the specified <see cref="T:System.Object" /></summary>
		/// <returns>true if <paramref name="obj" /> is a GPoint and has the same coordinates as this GPoint</returns>
		/// <param name="obj">The <see cref="T:System.Object" /> to test</param>
		public override bool Equals(object? obj) => obj != null && obj is GPoint GPoint && GPoint.X == this.X && GPoint.Y == this.Y;

		/// <summary>Returns a hash code for this GPoint</summary>
		/// <returns>An integer value that specifies a hash value for this GPoint</returns>
		public override int GetHashCode()
		{
			return this.x ^ this.y;
		}

		/// <summary>Converts this GPoint to a human-readable string</summary>
		/// <returns>A string that represents this GPoint</returns>
		public override string ToString()
		{
			return $"{{X={this.X}, Y={this.Y}}}";
		}
	}
}
