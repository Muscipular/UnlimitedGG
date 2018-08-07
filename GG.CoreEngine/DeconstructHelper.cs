using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine
{
    static class DeconstructHelper
    {
        public static void Deconstruct<T, V>(this KeyValuePair<T, V> p, out T t, out V v)
        {
            t = p.Key;
            v = p.Value;
        }
    }
}