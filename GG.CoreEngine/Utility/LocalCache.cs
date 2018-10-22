using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace GG.CoreEngine.Utility
{
    public class LocalCache<T>
    {
        public TimeSpan CacheTime { get; }

        private readonly Func<T> factory;

        private T cache;

        private long t;

        private int init;

        public T Value
        {
            get
            {
                bool isInit = init == 0;
                var l = t;
                if (l > DateTime.Now.Ticks && !isInit)
                {
                    return cache;
                }
                bool take = false;
                try
                {
                    if (isInit)
                    {
                        Monitor.Enter(this, ref take);
                    }
                    else
                    {
                        Monitor.TryEnter(this, ref take);
                    }
                    if (take)
                    {
                        if (isInit)
                        {
                            if (Interlocked.CompareExchange(ref init, 0, 0) != 0)
                            {
                                return cache;
                            }
                        }
                        if (Interlocked.CompareExchange(ref t, 0, 0) != l)
                        {
                            return cache;
                        }
                        if (isInit)
                        {
                            Interlocked.Exchange(ref init, 1);
                        }
                        var f = factory();

                        cache = f;
                        Interlocked.Exchange(ref t, DateTime.Now.Add(CacheTime).Ticks);
                        return f;
                    }
                    return cache;
                }
                finally
                {
                    if (take)
                    {
                        Monitor.Exit(this);
                    }
                }
            }
        }

        public LocalCache(TimeSpan cacheTime, Func<T> factory)
        {
            CacheTime = cacheTime;
            this.factory = factory;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator T(LocalCache<T> d)
        {
            return d.Value;
        }

        public void InvalidCache()
        {
            Interlocked.Exchange(ref t, 0L);
        }

        public void ForceUpdate()
        {
            lock (this)
            {
                var f = factory();
                cache = f;
                init = 1;
                t = DateTime.Now.Add(CacheTime).Ticks;
            }
        }
    }
}