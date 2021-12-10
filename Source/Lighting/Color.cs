using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Lighting
{
    [DebuggerDisplay("R = {R}, G = {G}, B = {B}")]
    public struct Color : IEquatable<Color>
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Color(int rgb)
            : this(r: (byte)((rgb >> 16) & 0xFF),
                   g: (byte)((rgb >> 8) & 0xFF),
                   b: (byte)((rgb >> 0) & 0xFF))
        {
        }

        public static Color Random(Random random)
        {
            int value = byte.MaxValue - random.Next(256);
            if (value < 85)
                return new Color(255 - value * 3, 0, value * 3);

            if (value < 170)
            {
                value -= 85;
                return new Color(0, value * 3, 255 - value * 3);
            }

            value -= 170;
            return new Color(value * 3, 255 - value * 3, 0);
        }

        private Color(int r, int g, int b)
            : this((byte)r, (byte)g, (byte)b)
        {
        }

        public Color(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public static implicit operator Color(int rgb) => new Color(rgb);

        public override string ToString()
        {
            return $"R = {R}, G = {G}, B = {B}";
        }

        public override int GetHashCode()
        {
            return R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode();
        }

        public static bool Equals(Color left, Color right)
        {
            return left.R == right.R &&
                left.G == right.G &&
                left.B == right.B;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Color))
                return false;

            return Equals(this, (Color)obj);
        }

        public bool Equals(Color other)
        {
            return Equals(this, other);
        }

        public static bool operator ==(Color left, Color right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Color left, Color right)
        {
            return !Equals(left, right);
        }

        public double Distance(Color other)
        {
            var left = (R * .30) + (G * .59) + (B * .11);
            var right = (other.R * .30) + (other.G * .59) + (other.B * .11);
            return ((right - left) * 100) / 255;
        }

        public static Color AliceBlue => 0xF0F8FF;
        public static Color Amethyst => 0x9966CC;
        public static Color AntiqueWhite => 0xFAEBD7;
        public static Color Aqua => 0x00FFFF;
        public static Color Aquamarine => 0x7FFFD4;
        public static Color Azure => 0xF0FFFF;
        public static Color Beige => 0xF5F5DC;
        public static Color Bisque => 0xFFE4C4;
        public static Color Black => 0x000000;
        public static Color BlanchedAlmond => 0xFFEBCD;
        public static Color Blue => 0x0000FF;
        public static Color BlueViolet => 0x8A2BE2;
        public static Color Brown => 0xA52A2A;
        public static Color BurlyWood => 0xDEB887;
        public static Color CadetBlue => 0x5F9EA0;
        public static Color Chartreuse => 0x7FFF00;
        public static Color Chocolate => 0xD2691E;
        public static Color Coral => 0xFF7F50;
        public static Color CornflowerBlue => 0x6495ED;
        public static Color Cornsilk => 0xFFF8DC;
        public static Color Crimson => 0xDC143C;
        public static Color Cyan => 0x00FFFF;
        public static Color DarkBlue => 0x00008B;
        public static Color DarkCyan => 0x008B8B;
        public static Color DarkGoldenrod => 0xB8860B;
        public static Color DarkGray => 0xA9A9A9;
        public static Color DarkGrey => 0xA9A9A9;
        public static Color DarkGreen => 0x006400;
        public static Color DarkKhaki => 0xBDB76B;
        public static Color DarkMagenta => 0x8B008B;
        public static Color DarkOliveGreen => 0x556B2F;
        public static Color DarkOrange => 0xFF8C00;
        public static Color DarkOrchid => 0x9932CC;
        public static Color DarkRed => 0x8B0000;
        public static Color DarkSalmon => 0xE9967A;
        public static Color DarkSeaGreen => 0x8FBC8F;
        public static Color DarkSlateBlue => 0x483D8B;
        public static Color DarkSlateGray => 0x2F4F4F;
        public static Color DarkSlateGrey => 0x2F4F4F;
        public static Color DarkTurquoise => 0x00CED1;
        public static Color DarkViolet => 0x9400D3;
        public static Color DeepPink => 0xFF1493;
        public static Color DeepSkyBlue => 0x00BFFF;
        public static Color DimGray => 0x696969;
        public static Color DimGrey => 0x696969;
        public static Color DodgerBlue => 0x1E90FF;
        public static Color FireBrick => 0xB22222;
        public static Color FloralWhite => 0xFFFAF0;
        public static Color ForestGreen => 0x228B22;
        public static Color Fuchsia => 0xFF00FF;
        public static Color Gainsboro => 0xDCDCDC;
        public static Color GhostWhite => 0xF8F8FF;
        public static Color Gold => 0xFFD700;
        public static Color Goldenrod => 0xDAA520;
        public static Color Gray => 0x808080;
        public static Color Grey => 0x808080;
        public static Color Green => 0x008000;
        public static Color GreenYellow => 0xADFF2F;
        public static Color Honeydew => 0xF0FFF0;
        public static Color HotPink => 0xFF69B4;
        public static Color IndianRed => 0xCD5C5C;
        public static Color Indigo => 0x4B0082;
        public static Color Ivory => 0xFFFFF0;
        public static Color Khaki => 0xF0E68C;
        public static Color Lavender => 0xE6E6FA;
        public static Color LavenderBlush => 0xFFF0F5;
        public static Color LawnGreen => 0x7CFC00;
        public static Color LemonChiffon => 0xFFFACD;
        public static Color LightBlue => 0xADD8E6;
        public static Color LightCoral => 0xF08080;
        public static Color LightCyan => 0xE0FFFF;
        public static Color LightGoldenrodYellow => 0xFAFAD2;
        public static Color LightGreen => 0x90EE90;
        public static Color LightGrey => 0xD3D3D3;
        public static Color LightPink => 0xFFB6C1;
        public static Color LightSalmon => 0xFFA07A;
        public static Color LightSeaGreen => 0x20B2AA;
        public static Color LightSkyBlue => 0x87CEFA;
        public static Color LightSlateGray => 0x778899;
        public static Color LightSlateGrey => 0x778899;
        public static Color LightSteelBlue => 0xB0C4DE;
        public static Color LightYellow => 0xFFFFE0;
        public static Color Lime => 0x00FF00;
        public static Color LimeGreen => 0x32CD32;
        public static Color Linen => 0xFAF0E6;
        public static Color Magenta => 0xFF00FF;
        public static Color Maroon => 0x800000;
        public static Color MediumAquamarine => 0x66CDAA;
        public static Color MediumBlue => 0x0000CD;
        public static Color MediumOrchid => 0xBA55D3;
        public static Color MediumPurple => 0x9370DB;
        public static Color MediumSeaGreen => 0x3CB371;
        public static Color MediumSlateBlue => 0x7B68EE;
        public static Color MediumSpringGreen => 0x00FA9A;
        public static Color MediumTurquoise => 0x48D1CC;
        public static Color MediumVioletRed => 0xC71585;
        public static Color MidnightBlue => 0x191970;
        public static Color MintCream => 0xF5FFFA;
        public static Color MistyRose => 0xFFE4E1;
        public static Color Moccasin => 0xFFE4B5;
        public static Color NavajoWhite => 0xFFDEAD;
        public static Color Navy => 0x000080;
        public static Color OldLace => 0xFDF5E6;
        public static Color Olive => 0x808000;
        public static Color OliveDrab => 0x6B8E23;
        public static Color Orange => 0xFFA500;
        public static Color OrangeRed => 0xFF4500;
        public static Color Orchid => 0xDA70D6;
        public static Color PaleGoldenrod => 0xEEE8AA;
        public static Color PaleGreen => 0x98FB98;
        public static Color PaleTurquoise => 0xAFEEEE;
        public static Color PaleVioletRed => 0xDB7093;
        public static Color PapayaWhip => 0xFFEFD5;
        public static Color PeachPuff => 0xFFDAB9;
        public static Color Peru => 0xCD853F;
        public static Color Pink => 0xFFC0CB;
        public static Color Plaid => 0xCC5533;
        public static Color Plum => 0xDDA0DD;
        public static Color PowderBlue => 0xB0E0E6;
        public static Color Purple => 0x800080;
        public static Color Red => 0xFF0000;
        public static Color RosyBrown => 0xBC8F8F;
        public static Color RoyalBlue => 0x4169E1;
        public static Color SaddleBrown => 0x8B4513;
        public static Color Salmon => 0xFA8072;
        public static Color SandyBrown => 0xF4A460;
        public static Color SeaGreen => 0x2E8B57;
        public static Color Seashell => 0xFFF5EE;
        public static Color Sienna => 0xA0522D;
        public static Color Silver => 0xC0C0C0;
        public static Color SkyBlue => 0x87CEEB;
        public static Color SlateBlue => 0x6A5ACD;
        public static Color SlateGray => 0x708090;
        public static Color SlateGrey => 0x708090;
        public static Color Snow => 0xFFFAFA;
        public static Color SpringGreen => 0x00FF7F;
        public static Color SteelBlue => 0x4682B4;
        public static Color Tan => 0xD2B48C;
        public static Color Teal => 0x008080;
        public static Color Thistle => 0xD8BFD8;
        public static Color Tomato => 0xFF6347;
        public static Color Turquoise => 0x40E0D0;
        public static Color Violet => 0xEE82EE;
        public static Color Wheat => 0xF5DEB3;
        public static Color White => 0xFFFFFF;
        public static Color WhiteSmoke => 0xF5F5F5;
        public static Color Yellow => 0xFFFF00;
        public static Color YellowGreen => 0x9ACD32;

        public static Color FairyLight => 0xFFE42D;
        public static Color FairyLightNCC => 0xFF9D2;
    }
}
