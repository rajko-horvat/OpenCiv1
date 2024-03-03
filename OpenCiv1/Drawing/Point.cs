﻿using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace OpenCiv1.Drawing;

/// <summary>
/// Represents an ordered pair of x and y coordinates that define a point in a two-dimensional plane.
/// </summary>
[Serializable]
public struct Point : IEquatable<Point>
{
    /// <summary>
    /// Creates a new instance of the <see cref='System.Drawing.Point'/> class with member data left uninitialized.
    /// </summary>
    public static readonly Point Empty;

    private int x; // Do not rename (binary serialization)
    private int y; // Do not rename (binary serialization)

    /// <summary>
    /// Initializes a new instance of the <see cref='System.Drawing.Point'/> class with the specified coordinates.
    /// </summary>
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref='System.Drawing.Point'/> class from a <see cref='System.Drawing.Size'/> .
    /// </summary>
    public Point(Size sz)
    {
        x = sz.Width;
        y = sz.Height;
    }

    /// <summary>
    /// Initializes a new instance of the Point class using coordinates specified by an integer value.
    /// </summary>
    public Point(int dw)
    {
        x = LowInt16(dw);
        y = HighInt16(dw);
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref='System.Drawing.Point'/> is empty.
    /// </summary>
    [Browsable(false)]
    public readonly bool IsEmpty => x == 0 && y == 0;

    /// <summary>
    /// Gets the x-coordinate of this <see cref='System.Drawing.Point'/>.
    /// </summary>
    public int X
    {
        readonly get => x;
        set => x = value;
    }

    /// <summary>
    /// Gets the y-coordinate of this <see cref='System.Drawing.Point'/>.
    /// </summary>
    public int Y
    {
        readonly get => y;
        set => y = value;
    }

    /// <summary>
    /// Creates a <see cref='System.Drawing.Size'/> with the coordinates of the specified <see cref='System.Drawing.Point'/> .
    /// </summary>
    public static explicit operator Size(Point p) => new Size(p.X, p.Y);

    /// <summary>
    /// Translates a <see cref='System.Drawing.Point'/> by a given <see cref='System.Drawing.Size'/> .
    /// </summary>
    public static Point operator +(Point pt, Size sz) => Add(pt, sz);

    /// <summary>
    /// Translates a <see cref='System.Drawing.Point'/> by the negative of a given <see cref='System.Drawing.Size'/> .
    /// </summary>
    public static Point operator -(Point pt, Size sz) => Subtract(pt, sz);

    /// <summary>
    /// Compares two <see cref='System.Drawing.Point'/> objects. The result specifies whether the values of the
    /// <see cref='System.Drawing.Point.X'/> and <see cref='System.Drawing.Point.Y'/> properties of the two
    /// <see cref='System.Drawing.Point'/> objects are equal.
    /// </summary>
    public static bool operator ==(Point left, Point right) => left.X == right.X && left.Y == right.Y;

    /// <summary>
    /// Compares two <see cref='System.Drawing.Point'/> objects. The result specifies whether the values of the
    /// <see cref='System.Drawing.Point.X'/> or <see cref='System.Drawing.Point.Y'/> properties of the two
    /// <see cref='System.Drawing.Point'/>  objects are unequal.
    /// </summary>
    public static bool operator !=(Point left, Point right) => !(left == right);

    /// <summary>
    /// Translates a <see cref='System.Drawing.Point'/> by a given <see cref='System.Drawing.Size'/> .
    /// </summary>
    public static Point Add(Point pt, Size sz) => new Point(unchecked(pt.X + sz.Width), unchecked(pt.Y + sz.Height));

    /// <summary>
    /// Translates a <see cref='System.Drawing.Point'/> by the negative of a given <see cref='System.Drawing.Size'/> .
    /// </summary>
    public static Point Subtract(Point pt, Size sz) => new Point(unchecked(pt.X - sz.Width), unchecked(pt.Y - sz.Height));

    /// <summary>
    /// Specifies whether this <see cref='System.Drawing.Point'/> contains the same coordinates as the specified
    /// <see cref='object'/>.
    /// </summary>
    public override readonly bool Equals([NotNullWhen(true)] object? obj) => obj is Point && Equals((Point)obj);

    public readonly bool Equals(Point other) => this == other;

    /// <summary>
    /// Returns a hash code.
    /// </summary>
    public override readonly int GetHashCode() => HashCode.Combine(X, Y);

    /// <summary>
    /// Translates this <see cref='System.Drawing.Point'/> by the specified amount.
    /// </summary>
    public void Offset(int dx, int dy)
    {
        unchecked
        {
            X += dx;
            Y += dy;
        }
    }

    /// <summary>
    /// Translates this <see cref='System.Drawing.Point'/> by the specified amount.
    /// </summary>
    public void Offset(Point p) => Offset(p.X, p.Y);

    /// <summary>
    /// Converts this <see cref='System.Drawing.Point'/> to a human readable string.
    /// </summary>
    public override readonly string ToString() => $"{{X={X},Y={Y}}}";

    private static short HighInt16(int n) => unchecked((short)((n >> 16) & 0xffff));

    private static short LowInt16(int n) => unchecked((short)(n & 0xffff));
}