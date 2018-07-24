using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace UGG.Core.Graphics
{
    public struct HslColor
    {
        private const float D1_6 = (1.0f / 6.0f);

        private const float D1_3 = (1.0f / 3.0f);

        private const float D2_3 = (2.0f / 3.0f);

        // value from 0 to 1 
        public float A;
        // value from 0 to 360 
        public float H;
        // value from 0 to 1 
        public float S;
        // value from 0 to 1 
        public float L;

        private const float TOLERANCE = 0.000001f;


        private static float ByteToPct(byte v)
        {
            float d = v;
            d /= 255;
            return d;
        }

        private static byte PctToByte(float pct)
        {
            pct *= 255;
            pct += .5f;
            if (pct > 255) pct = 255;
            if (pct < 0) pct = 0;
            return (byte)pct;
        }

        public static HslColor FromColor(Color c)
        {
            return FromArgb(c.A, c.R, c.G, c.B);
        }

        public static HslColor FromArgb(byte A, byte R, byte G, byte B)
        {
            HslColor c = FromRgb(R, G, B);
            c.A = ByteToPct(A);
            return c;
        }

        public static HslColor FromRgb(byte R, byte G, byte B)
        {
            HslColor c = new HslColor();
            c.A = 1;
            float r = ByteToPct(R);
            float g = ByteToPct(G);
            float b = ByteToPct(B);
            float max = Math.Max(b, Math.Max(r, g));
            float min = Math.Min(b, Math.Min(r, g));
            float deltaMinMax = max - min;
            if (Math.Abs(deltaMinMax) < TOLERANCE)
            {
                c.H = 0;
            }
            else if (Math.Abs(max - r) < TOLERANCE && g >= b)
            {
                c.H = 60 * ((g - b) / deltaMinMax);
            }
            else if (Math.Abs(max - r) < TOLERANCE && g < b)
            {
                c.H = 60 * ((g - b) / deltaMinMax) + 360;
            }
            else if (Math.Abs(max - g) < TOLERANCE)
            {
                c.H = 60 * ((b - r) / deltaMinMax) + 120;
            }
            else if (Math.Abs(max - b) < TOLERANCE)
            {
                c.H = 60 * ((r - g) / deltaMinMax) + 240;
            }

            c.L = .5f * (max + min);
            if (Math.Abs(deltaMinMax) < TOLERANCE)
            {
                c.S = 0;
            }
            else if (c.L <= .5)
            {
                c.S = deltaMinMax / (2 * c.L);
            }
            else if (c.L > .5)
            {
                c.S = deltaMinMax / (2 - 2 * c.L);
            }
            return c;
        }

        public HslColor Lighten(float pct)
        {
            HslColor c = new HslColor();
            c.A = this.A;
            c.H = this.H;
            c.S = this.S;
            c.L = Math.Min(Math.Max(this.L + pct, 0), 1);
            return c;
        }

        public HslColor Darken(float pct)
        {
            return Lighten(-pct);
        }

        private float norm(float d)
        {
            if (d < 0) d += 1;
            if (d > 1) d -= 1;
            return d;
        }

        private float getComponent(float tc, float p, float q)
        {
            if (tc < D1_6)
            {
                return p + ((q - p) * 6 * tc);
            }
            if (tc < .5)
            {
                return q;
            }
            if (tc < D2_3)
            {
                return p + ((q - p) * 6 * (D2_3 - tc));
            }
            return p;
        }

        public Color ToColor()
        {
            float q = 0;
            if (L < .5)
            {
                q = L * (1 + S);
            }
            else
            {
                q = L + S - (L * S);
            }
            float p = (2 * L) - q;
            float hk = H / 360f;
            float r = getComponent(norm(hk + D1_3), p, q);
            float g = getComponent(norm(hk), p, q);
            float b = getComponent(norm(hk - D1_3), p, q);
            return new Color(PctToByte(A), PctToByte(r), PctToByte(g), PctToByte(b));
        }

    }
}