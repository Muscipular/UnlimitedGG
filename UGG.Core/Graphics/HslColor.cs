using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace UGG.Core.Graphics
{
    public struct HslColor
    {
        private const double D1_6 = (1.0 / 6.0);

        private const double D1_3 = (1.0 / 3.0);

        private const double D2_3 = (2.0 / 3.0);

        // value from 0 to 1 
        public double A;
        // value from 0 to 360 
        public double H;
        // value from 0 to 1 
        public double S;
        // value from 0 to 1 
        public double L;

        private const double TOLERANCE = 0.0000000001f;


        private static double ByteToPct(byte v)
        {
            double d = v;
            d /= 255;
            return d;
        }

        private static byte PctToByte(double pct)
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
            double r = ByteToPct(R);
            double g = ByteToPct(G);
            double b = ByteToPct(B);
            double max = Math.Max(b, Math.Max(r, g));
            double min = Math.Min(b, Math.Min(r, g));
            double deltaMinMax = max - min;
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

        public HslColor Lighten(double pct)
        {
            HslColor c = new HslColor();
            c.A = this.A;
            c.H = this.H;
            c.S = this.S;
            c.L = Math.Min(Math.Max(this.L + pct, 0), 1);
            return c;
        }

        public HslColor Darken(double pct)
        {
            return Lighten(-pct);
        }

        private double norm(double d)
        {
            if (d < 0) d += 1;
            if (d > 1) d -= 1;
            return d;
        }

        private double getComponent(double tc, double p, double q)
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
            double q = 0;
            if (L < .5)
            {
                q = L * (1 + S);
            }
            else
            {
                q = L + S - (L * S);
            }
            double p = (2 * L) - q;
            double hk = H / 360f;
            double r = getComponent(norm(hk + D1_3), p, q);
            double g = getComponent(norm(hk), p, q);
            double b = getComponent(norm(hk - D1_3), p, q);
            return new Color(PctToByte(A), PctToByte(r), PctToByte(g), PctToByte(b));
        }

    }
}