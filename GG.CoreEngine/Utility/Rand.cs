using System;
using System.Collections.Generic;
using System.Threading;

namespace GG.CoreEngine.Utility
{
    static class Rand
    {
        private static ThreadLocal<Random> random = new ThreadLocal<Random>(() => new Random());

        public static int Int(int max) => random.Value.Next(max + 1);

        public static int Int(int min, int max) => random.Value.Next(min, max + 1);

        public static bool Bool(double rate = 0.5) => random.Value.NextDouble() >= (1 - rate);

        public static double Double(double min, double max)
        {
            return random.Value.NextDouble() * max + min;
        }
    }
}