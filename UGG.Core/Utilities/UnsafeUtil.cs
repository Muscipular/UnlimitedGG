using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace UGG.Core.Utilities
{
    static class UnsafeUtil
    {
        public static byte[] Copy8(this IntPtr p, int size)
        {
            var s = new byte[size];
            Marshal.Copy(p, s, 0, size);
            return s;
        }

        public static short[] Copy16(this IntPtr p, int size)
        {
            var s = new short[size];
            Marshal.Copy(p, s, 0, size);
            return s;
        }
        
        public static int[] Copy32(this IntPtr p, int size)
        {
            var s = new int[size];
            Marshal.Copy(p, s, 0, size);
            return s;
        }

        public static long[] Copy64(this IntPtr p, int size)
        {
            var s = new long[size];
            Marshal.Copy(p, s, 0, size);
            return s;
        }
    }
}