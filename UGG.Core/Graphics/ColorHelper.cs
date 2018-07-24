using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;

namespace UGG.Core.Graphics
{
    static class C
    {
        internal static uint HexToByte(char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (uint)(c - '0');
            }
            if (c >= 'A' && c <= 'F')
            {
                return (uint)(c - 'A' + 10);
            }
            if (c >= 'a' && c <= 'f')
            {
                return (uint)(c - 'a' + 10);
            }
            throw new ArgumentOutOfRangeException(nameof(c));
        }

        /// <summary>
        /// RGBA
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        internal static Color Parse(string s)
        {
            if (s[0] != '#')
            {
                throw new ArgumentException($"{s}不是合法的HexColor");
            }
            uint c = 0;
            uint v = 0;
            switch (s.Length)
            {
                case 4:
                    c = 255;
                    v = HexToByte(s[3]);
                    c = (c << 8) | (v << 4) | v;
                    v = HexToByte(s[2]);
                    c = (c << 8) | (v << 4) | v;
                    v = HexToByte(s[1]);
                    c = (c << 8) | (v << 4) | v;
                    break;
                case 5:
                    v = HexToByte(s[4]);
                    c = (v << 4) | v;
                    v = HexToByte(s[3]);
                    c = (c << 8) | (v << 4) | v;
                    v = HexToByte(s[2]);
                    c = (c << 8) | (v << 4) | v;
                    v = HexToByte(s[1]);
                    c = (c << 8) | (v << 4) | v;
                    break;
                case 7:
                    c = 255;
                    c = (c << 8) | (HexToByte(s[5]) << 4) | HexToByte(s[6]);
                    c = (c << 8) | (HexToByte(s[3]) << 4) | HexToByte(s[4]);
                    c = (c << 8) | (HexToByte(s[1]) << 4) | HexToByte(s[2]);
                    break;
                case 9:
                    c = (HexToByte(s[7]) << 4) | HexToByte(s[8]);
                    c = (c << 8) | (HexToByte(s[5]) << 4) | HexToByte(s[6]);
                    c = (c << 8) | (HexToByte(s[3]) << 4) | HexToByte(s[4]);
                    c = (c << 8) | (HexToByte(s[1]) << 4) | HexToByte(s[2]);
                    break;
                default:
                    throw new ArgumentException($"{s}不是合法的HexColor");
            }
            return new Color(c);
        }

        internal static HslColor ToHSL(this Color color) => HslColor.FromColor(color);

        internal static Color Darken(this Color color, float value) => HslColor.FromColor(color).Darken(value).ToColor();

        internal static Color Lighten(this Color color, float value) => HslColor.FromColor(color).Lighten(value).ToColor();
    }
}