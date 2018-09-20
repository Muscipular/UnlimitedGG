using System;
using System.Collections.Generic;
using System.Text;

namespace GG.CoreEngine.Utility
{
    static class Rand
    {
        private static Random random = new Random();

        public static int Int(int max) => random.Next(max + 1);

        public static int Int(int min, int max) => random.Next(min, max + 1);

        public static bool Bool(float rate = 0.5f) => random.NextDouble() >= rate;
    }
}