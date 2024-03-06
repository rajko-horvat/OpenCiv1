using System;
using System.ComponentModel;

namespace OpenCiv1.GPU
{
	/// <summary>Represents a location and size of an object in a two-dimensional plane</summary>
	[Serializable]
	public class GRectangle
	{
		private int x;
		private int y;
		private int width;
		private int height;

		/// <summary>Initializes a new instance of the GRectangle class with location and size set to 0</summary>
		public GRectangle()
		{
			this.x = 0;
			this.y = 0;
			this.width = 0;
			this.height = 0;
		}

		/// <summary>Initializes a new instance of the GRectangle class with the specified location and size</summary>
		/// <param name="x">The x-coordinate of the upper-left corner of the GRectangle</param>
		/// <param name="y">The y-coordinate of the upper-left corner of the GRectangle</param>
		/// <param name="width">The width of the GRectangle</param>
		/// <param name="height">The height of the GRectangle</param>
		public GRectangle(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		/// <summary>Initializes a new instance of the GRectangle class with the specified location and size</summary>
		/// <param name="x">The x-coordinate of the upper-left corner of the GRectangle</param>
		/// <param name="y">The y-coordinate of the upper-left corner of the GRectangle</param>
		/// <param name="GSize">A GSize that represents the width and height of the rectangular region</param>
		public GRectangle(int x, int y, GSize size)
		{
			this.x = x;
			this.y = y;
			this.width = size.Width;
			this.height = size.Height;
		}

		/// <summary>Initializes a new instance of the GRectangle class with the specified location and size</summary>
		/// <param name="location">A GPoint that represents the upper-left corner of the rectangular region</param>
		/// <param name="GSize">A GSize that represents the width and height of the rectangular region</param>
		public GRectangle(GPoint location, GSize size)
		{
			this.x = location.X;
			this.y = location.Y;
			this.width = size.Width;
			this.height = size.Height;
		}

		/// <summary>Initializes a new instance of the GRectangle class with the specified location and size</summary>
		/// <param name="location">A GPoint that represents the upper-left corner of the rectangular region</param>
		/// <param name="width">The width of the GRectangle</param>
		/// <param name="height">The height of the GRectangle</param>
		public GRectangle(GPoint location, int width, int height)
		{
			this.x = location.X;
			this.y = location.Y;
			this.width = width;
			this.height = height;
		}

		/// <summary>Clones a current Rectange class into new GRectangle class</summary>
		/// <returns>New GRectangle class with the same coordinates</returns>
		public GRectangle Clone()
		{
			return new GRectangle(this.x, this.y, this.width, this.height);
		}

		/// <summary>Creates a GRectangle class with the specified edge locations</summary>
		/// <returns>The new GRectangle that this method creates</returns>
		/// <param name="left">The x-coordinate of the upper-left corner of this GRectangle class</param>
		/// <param name="top">The y-coordinate of the upper-left corner of this GRectangle class</param>
		/// <param name="right">The x-coordinate of the lower-right corner of this GRectangle class</param>
		/// <param name="bottom">The y-coordinate of the lower-right corner of this GRectangle class</param>
		public static GRectangle FromLTRB(int left, int top, int right, int bottom) => new GRectangle(left, top, right - left, bottom - top);

		/// <summary>Tests if all GRectangle coordinates are zero</summary>
		[Browsable(false)]
		public bool IsZero => this.x == 0 && this.y == 0 && this.width == 0 && this.height == 0;

		/// <summary>Gets or sets the coordinates of the upper-left corner of this GRectangle class</summary>
		/// <returns>A GPoint that represents the upper-left corner of this GRectangle class</returns>
		[Browsable(false)]
		public GPoint Location
		{
			get => new GPoint(this.X, this.Y);
			set
			{
				this.X = value.X;
				this.Y = value.Y;
			}
		}

		/// <summary>Gets or sets the size of this GRectangle</summary>
		/// <returns>A GSize that represents the width and height of this GRectangle class</returns>
		[Browsable(false)]
		public GSize Size
		{
			get => new GSize(this.Width, this.Height);
			set
			{
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		/// <summary>Gets or sets the x-coordinate of the upper-left corner of this GRectangle class</summary>
		/// <returns>The x-coordinate of the upper-left corner of this GRectangle class</returns>
		public int X
		{
			get => this.x;
			set => this.x = value;
		}

		/// <summary>Gets or sets the y-coordinate of the upper-left corner of this GRectangle class</summary>
		/// <returns>The y-coordinate of the upper-left corner of this GRectangle class</returns>
		public int Y
		{
			get => this.y;
			set => this.y = value;
		}

		/// <summary>Gets or sets the width of this GRectangle class</summary>
		/// <returns>The width of this GRectangle class</returns>
		public int Width
		{
			get => this.width;
			set => this.width = value;
		}

		/// <summary>Gets or sets the height of this GRectangle class</summary>
		/// <returns>The height of this GRectangle class</returns>
		public int Height
		{
			get => this.height;
			set => this.height = value;
		}

		/// <summary>Gets the x-coordinate of the left edge of this GRectangle class</summary>
		/// <returns>The x-coordinate of the left edge of this GRectangle class</returns>
		[Browsable(false)]
		public int Left => this.x;

		/// <summary>Gets the y-coordinate of the top edge of this GRectangle class</summary>
		/// <returns>The y-coordinate of the top edge of this GRectangle class</returns>
		[Browsable(false)]
		public int Top => this.y;

		/// <summary>Gets the x-coordinate that is the sum of GRectangle.X and GRectangle.Width property values of this GRectangle class</summary>
		/// <returns>The x-coordinate that is the sum of GRectangle.X and GRectangle.Width of this GRectangle</returns>
		[Browsable(false)]
		public int Right => this.x + this.width;

		/// <summary>Gets the y-coordinate that is the sum of the GRectangle.Y and GRectangle.Height property values of this GRectangle class</summary>
		/// <returns>The y-coordinate that is the sum of GRectangle.Y and GRectangle.Height of this GRectangle</returns>
		[Browsable(false)]
		public int Bottom => this.y + this.height;

		/// <summary>Tests whether two GRectangle classes have equal location and size</summary>
		/// <returns>This operator returns true if the two GRectangle classes have equal GRectangle.IsEmpty, GRectangle.X, GRectangle.Y, GRectangle.Width, and GRectangle.Height properties</returns>
		/// <param name="left">The GRectangle class that is to the left of the equality operator</param>
		/// <param name="right">The GRectangle class that is to the right of the equality operator</param>
		public static bool operator ==(GRectangle left, GRectangle right) => left.X == right.X && left.Y == right.Y &&
			left.Width == right.Width && left.Height == right.Height;

		/// <summary>Tests whether two GRectangle classes differ in location or size</summary>
		/// <returns>This operator returns true if any of the GRectangle.IsEmpty, GRectangle.X, GRectangle.Y, GRectangle.Width or GRectangle.Height properties of the two GRectangle classes are unequal; otherwise false</returns>
		/// <param name="left">The GRectangle class that is to the left of the inequality operator</param>
		/// <param name="right">The GRectangle class that is to the right of the inequality operator</param>
		public static bool operator !=(GRectangle left, GRectangle right) => !(left == right);

		/// <summary>Determines if the specified GPoint is contained within this GRectangle class</summary>
		/// <returns>This method returns true if the GPoint defined by <paramref name="x" /> and <paramref name="y" /> is contained within this GRectangle class; otherwise false</returns>
		/// <param name="x">The x-coordinate of the GPoint to test</param>
		/// <param name="y">The y-coordinate of the GPoint to test</param>
		public bool Contains(int x, int y)
		{
			return this.X <= x && x < this.X + this.Width && this.Y <= y && y < this.Y + this.Height;
		}

		/// <summary>Determines if the specified GPoint is contained within this GRectangle class</summary>
		/// <returns>This method returns true if the GPoint represented by <paramref name="pt" /> is contained within this GRectangle class; otherwise false</returns>
		/// <param name="pt">The GPoint to test</param>
		public bool Contains(GPoint pt)
		{
			return this.Contains(pt.X, pt.Y);
		}

		/// <summary>Determines if the rectangular region represented by <paramref name="rect" /> is entirely contained within this GRectangle class</summary>
		/// <returns>This method returns true if the rectangular region represented by <paramref name="rect" /> is entirely contained within this GRectangle class; otherwise false</returns>
		/// <param name="rect">The GRectangle to test</param>
		public bool Contains(GRectangle rect)
		{
			return this.X <= rect.X && rect.X + rect.Width <= this.X + this.Width && this.Y <= rect.Y && rect.Y + rect.Height <= this.Y + this.Height;
		}

		/// <summary>Enlarges this GRectangle by the specified amount</summary>
		/// <param name="width">The amount to inflate this GRectangle horizontally</param>
		/// <param name="height">The amount to inflate this GRectangle vertically</param>
		public void Inflate(int width, int height)
		{
			this.X -= width;
			this.Y -= height;
			this.Width += 2 * width;
			this.Height += 2 * height;
		}

		/// <summary>Enlarges this GRectangle by the specified amount</summary>
		/// <param name="GSize">The amount to inflate this GRectangle</param>
		public void Inflate(GSize size)
		{
			this.Inflate(size.Width, size.Height);
		}

		/// <summary>Creates and returns an enlarged copy of the specified GRectangle class. 
		/// The copy is enlarged by the specified amount. The original GRectangle class remains unmodified</summary>
		/// <returns>The enlarged GRectangle</returns>
		/// <param name="rect">The GRectangle with which to start. This GRectangle is not modified</param>
		/// <param name="x">The amount to inflate this GRectangle horizontally</param>
		/// <param name="y">The amount to inflate this GRectangle vertically</param>
		public static GRectangle Inflate(GRectangle rect, int x, int y)
		{
			GRectangle GRectangle = rect.Clone();
			GRectangle.Inflate(x, y);

			return GRectangle;
		}

		/// <summary>Replaces this GRectangle with the intersection of itself and the specified GRectangle</summary>
		/// <param name="rect">The GRectangle with which to intersect</param>
		public void Intersect(GRectangle rect)
		{
			GRectangle GRectangle = GRectangle.Intersect(rect, this);
			this.X = GRectangle.X;
			this.Y = GRectangle.Y;
			this.Width = GRectangle.Width;
			this.Height = GRectangle.Height;
		}

		/// <summary>Returns a new GRectangle class that represents the intersection of two GRectangle classes. 
		/// If there is no intersection, a GRectangle with all coordinates set to zero is returned</summary>
		/// <returns>A new GRectangle that represents the intersection of <paramref name="a" /> and <paramref name="b" /></returns>
		/// <param name="a">A GRectangle to intersect</param>
		/// <param name="b">A GRectangle to intersect</param>
		public static GRectangle Intersect(GRectangle a, GRectangle b)
		{
			int x = Math.Max(a.X, b.X);
			int num1 = Math.Min(a.X + a.Width, b.X + b.Width);
			int y = Math.Max(a.Y, b.Y);
			int num2 = Math.Min(a.Y + a.Height, b.Y + b.Height);

			return num1 >= x && num2 >= y ? new GRectangle(x, y, num1 - x, num2 - y) : new GRectangle(0, 0, 0, 0);
		}

		/// <summary>Determines if this GRectangle intersects with <paramref name="rect" /></summary>
		/// <returns>This method returns true if there is any intersection, otherwise false</returns>
		/// <param name="rect">The GRectangle to test</param>
		public bool IntersectsWith(GRectangle rect)
		{
			return rect.X < this.X + this.Width && this.X < rect.X + rect.Width && rect.Y < this.Y + this.Height && this.Y < rect.Y + rect.Height;
		}

		/// <summary>Gets a GRectangle class that contains the union of two GRectangle classes</summary>
		/// <returns>A GRectangle class that bounds the union of the two GRectangle classes</returns>
		/// <param name="a">A GRectangle to union</param>
		/// <param name="b">A GRectangle to union</param>
		public static GRectangle Union(GRectangle a, GRectangle b)
		{
			int x = Math.Min(a.X, b.X);
			int num1 = Math.Max(a.X + a.Width, b.X + b.Width);
			int y = Math.Min(a.Y, b.Y);
			int num2 = Math.Max(a.Y + a.Height, b.Y + b.Height);

			return new GRectangle(x, y, num1 - x, num2 - y);
		}

		/// <summary>Adjusts the location of this GRectangle by the specified amount</summary>
		/// <param name="pos">Amount to offset the location</param>
		public void Offset(GPoint pos)
		{
			this.Offset(pos.X, pos.Y);
		}

		/// <summary>Adjusts the location of this GRectangle by the specified amount</summary>
		/// <param name="x">The horizontal offset</param>
		/// <param name="y">The vertical offset</param>
		public void Offset(int x, int y)
		{
			this.X += x;
			this.Y += y;
		}

		/// <summary>Tests whether <paramref name="obj" /> is a GRectangle class with the same location and size of this GRectangle class</summary>
		/// <returns>This method returns true if <paramref name="obj" /> is a GRectangle class and its GRectangle.IsEmpty, GRectangle.X, GRectangle.Y, GRectangle.Width, and GRectangle.Height properties are equal to the corresponding properties of this GRectangle class; otherwise, false</returns>
		/// <param name="obj">The <see cref="T:System.Object" /> to test</param>
		public override bool Equals(object? obj) => obj != null && obj is GRectangle GRectangle &&
			GRectangle.X == this.X && GRectangle.Y == this.Y && GRectangle.Width == this.Width && GRectangle.Height == this.Height;

		/// <summary>Returns the hash code for this GRectangle class. For information about the use of hash codes, see <see cref="M:System.Object.GetHashCode" /></summary>
		/// <returns>An integer that represents the hash code for this GRectangle</returns>
		public override int GetHashCode()
		{
			return this.X ^ (this.Y << 13 | (int)((uint)this.Y >> 19)) ^ (this.Width << 26 | (int)((uint)this.Width >> 6)) ^ (this.Height << 7 | (int)((uint)this.Height >> 25));
		}

		/// <summary>Converts the attributes of this GRectangle to a human-readable string</summary>
		/// <returns>A string that contains the position, width, and height of this GRectangle class ¾ for example, {X=20, Y=20, Width=100, Height=50} </returns>
		public override string ToString()
		{
			return $"{{X={this.X}, Y={this.Y}, Width={this.Width}, Height={this.Height}}}";
		}
	}
}
