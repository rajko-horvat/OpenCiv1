using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace OpenCiv1.Drawing;
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

[DebuggerDisplay("{NameAndARGBValue}")]
    [Serializable]
    public readonly struct Color : IEquatable<Color>
    {
        public static readonly Color Empty;

        //
        //  end "web" colors
        // -------------------------------------------------------------------

        // NOTE : The "zero" pattern (all members being 0) must represent
        //      : "not set". This allows "Color c;" to be correct.

        private const short StateKnownColorValid = 0x0001;
        private const short StateARGBValueValid = 0x0002;
        private const short StateValueMask = StateARGBValueValid;
        private const short StateNameValid = 0x0008;
        private const long NotDefinedValue = 0;

        // Shift counts and bit masks for A, R, G, B components in ARGB mode

        internal const int ARGBAlphaShift = 24;
        internal const int ARGBRedShift = 16;
        internal const int ARGBGreenShift = 8;
        internal const int ARGBBlueShift = 0;
        internal const uint ARGBAlphaMask = 0xFFu << ARGBAlphaShift;
        internal const uint ARGBRedMask = 0xFFu << ARGBRedShift;
        internal const uint ARGBGreenMask = 0xFFu << ARGBGreenShift;
        internal const uint ARGBBlueMask = 0xFFu << ARGBBlueShift;

        // User supplied name of color. Will not be filled in if
        // we map to a "knowncolor"
        private readonly string? name; // Do not rename (binary serialization)

        // Standard 32bit sRGB (ARGB)
        private readonly long value; // Do not rename (binary serialization)

        // Ignored, unless "state" says it is valid
        private readonly short knownColor; // Do not rename (binary serialization)

        // State flags.
        private readonly short state; // Do not rename (binary serialization)
        private Color(long value, short state, string? name)
        {
            this.value = value;
            this.state = state;
            this.name = name;
        }

        public byte R => unchecked((byte)(Value >> ARGBRedShift));

        public byte G => unchecked((byte)(Value >> ARGBGreenShift));

        public byte B => unchecked((byte)(Value >> ARGBBlueShift));

        public byte A => unchecked((byte)(Value >> ARGBAlphaShift));

        public bool IsKnownColor => (state & StateKnownColorValid) != 0;

        public bool IsEmpty => state == 0;

        public bool IsNamedColor => ((state & StateNameValid) != 0) || IsKnownColor;

        // Used for the [DebuggerDisplay]. Inlining in the attribute is possible, but
        // against best practices as the current project language parses the string with
        // language specific heuristics.

        private string NameAndARGBValue => $"{{Name = {Name}, ARGB = ({A}, {R}, {G}, {B})}}";

        public string Name
        {
            get
            {
                if ((state & StateNameValid) != 0)
                {
                    Debug.Assert(name != null);
                    return name;
                }

                // if we reached here, just encode the value
                //
                return value.ToString("x");
            }
        }

        private long Value
        {
            get
            {
                if ((state & StateValueMask) != 0)
                {
                    return value;
                }

                return NotDefinedValue;
            }
        }

        private static void CheckByte(int value, string name)
        {
            static void ThrowOutOfByteRange(int v, string n) =>
                throw new ArgumentException($"Out of range, range: {byte.MinValue}, {byte.MaxValue}");

            if (unchecked((uint)value) > byte.MaxValue)
                ThrowOutOfByteRange(value, name);
        }

        private static Color FromArgb(uint argb) => new Color(argb, StateARGBValueValid, null);

        public static Color FromArgb(int argb) => FromArgb(unchecked((uint)argb));

        public static Color FromArgb(int alpha, int red, int green, int blue)
        {
            CheckByte(alpha, nameof(alpha));
            CheckByte(red, nameof(red));
            CheckByte(green, nameof(green));
            CheckByte(blue, nameof(blue));

            return FromArgb(
                (uint)alpha << ARGBAlphaShift |
                (uint)red << ARGBRedShift |
                (uint)green << ARGBGreenShift |
                (uint)blue << ARGBBlueShift
            );
        }

        public static Color FromArgb(int alpha, Color baseColor)
        {
            CheckByte(alpha, nameof(alpha));

            return FromArgb(
                (uint)alpha << ARGBAlphaShift |
                (uint)baseColor.Value & ~ARGBAlphaMask
            );
        }

        public static Color FromArgb(int red, int green, int blue) => FromArgb(byte.MaxValue, red, green, blue);

        public static Color Black => new Color(0, StateARGBValueValid, "Black");

        public static Color FromName(string name)
        {
            // otherwise treat it as a named color
            return new Color(NotDefinedValue, StateNameValid, name);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void GetRgbValues(out int r, out int g, out int b)
        {
            uint value = (uint)Value;
            r = (int)(value & ARGBRedMask) >> ARGBRedShift;
            g = (int)(value & ARGBGreenMask) >> ARGBGreenShift;
            b = (int)(value & ARGBBlueMask) >> ARGBBlueShift;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void MinMaxRgb(out int min, out int max, int r, int g, int b)
        {
            if (r > g)
            {
                max = r;
                min = g;
            }
            else
            {
                max = g;
                min = r;
            }
            if (b > max)
            {
                max = b;
            }
            else if (b < min)
            {
                min = b;
            }
        }

        public float GetBrightness()
        {
            GetRgbValues(out int r, out int g, out int b);

            MinMaxRgb(out int min, out int max, r, g, b);

            return (max + min) / (byte.MaxValue * 2f);
        }

        public float GetHue()
        {
            GetRgbValues(out int r, out int g, out int b);

            if (r == g && g == b)
                return 0f;

            MinMaxRgb(out int min, out int max, r, g, b);

            float delta = max - min;
            float hue;

            if (r == max)
                hue = (g - b) / delta;
            else if (g == max)
                hue = (b - r) / delta + 2f;
            else
                hue = (r - g) / delta + 4f;

            hue *= 60f;
            if (hue < 0f)
                hue += 360f;

            return hue;
        }

        public float GetSaturation()
        {
            GetRgbValues(out int r, out int g, out int b);

            if (r == g && g == b)
                return 0f;

            MinMaxRgb(out int min, out int max, r, g, b);

            int div = max + min;
            if (div > byte.MaxValue)
                div = byte.MaxValue * 2 - max - min;

            return (max - min) / (float)div;
        }

        public int ToArgb() => unchecked((int)Value);

        public override string ToString() =>
            IsNamedColor ? $"{nameof(Color)} [{Name}]" :
            (state & StateValueMask) != 0 ? $"{nameof(Color)} [A={A}, R={R}, G={G}, B={B}]" :
            $"{nameof(Color)} [Empty]";

        public static bool operator ==(Color left, Color right) =>
            left.value == right.value
                && left.state == right.state
                && left.knownColor == right.knownColor
                && left.name == right.name;

        public static bool operator !=(Color left, Color right) => !(left == right);

        public override bool Equals([NotNullWhen(true)] object? obj) => obj is Color other && Equals(other);

        public bool Equals(Color other) => this == other;

        public override int GetHashCode()
        {
            // Three cases:
            // 1. We don't have a name. All relevant data, including this fact, is in the remaining fields.
            // 2. We have a known name. The name will be the same instance of any other with the same
            // knownColor value, so we can ignore it for hashing. Note this also hashes different to
            // an unnamed color with the same ARGB value.
            // 3. Have an unknown name. Will differ from other unknown-named colors only by name, so we
            // can usefully use the names hash code alone.
            if (name != null && !IsKnownColor)
                return name.GetHashCode();

            return HashCode.Combine(value.GetHashCode(), state.GetHashCode(), knownColor.GetHashCode());
        }
    }
