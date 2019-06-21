using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using GG.CoreEngine.Utility;
using Xunit;
using Xunit.Abstractions;

namespace GG.Engine.Test
{
    public class UnitTest1
    {
        public static ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            UnitTest1.output = output;
        }

        class A
        {
            public override string ToString()
            {
                return GetHashCode().ToString();
            }
        }

        [Fact]
        public void Test1()
        {
            int i = 1;
            DateTime tx = DateTime.MinValue;
            var cache = new LocalCache<A>(TimeSpan.FromSeconds(1), () =>
            {
                var now = DateTime.Now;
                var totalSeconds = (now - tx).TotalSeconds;
                if (tx != DateTime.MinValue && totalSeconds < 0.995)
                {
                    throw new Exception($"{Thread.CurrentThread.ManagedThreadId:D5} {totalSeconds}");
                }
                tx = now;
                output.WriteLine($"{Thread.CurrentThread.ManagedThreadId:D5} {DateTime.Now:hh:mm:ss.fffffff} ++");
                Thread.Sleep(100);
                output.WriteLine($"{Thread.CurrentThread.ManagedThreadId:D5} {DateTime.Now:hh:mm:ss.fffffff} ==");
                return new A();
            });
            int c = 0;
            var sw = Stopwatch.StartNew();
            Parallel.For(0, 100, (xx) =>
            {
                int ix = 5000000;
                DateTime t = DateTime.MinValue;
                A v = null;
                while (ix-- > 0)
                {
                    var x = cache.Value;
                    if (v != x)
                    {
                        var s = $"{Thread.CurrentThread.ManagedThreadId:D5} {DateTime.Now:hh:mm:ss.fffffff} {v} -> {x}";
                        output.WriteLine(s);
                        v = cache.Value;
                        t = DateTime.Now;
                    }
                }
            });
            output.WriteLine("ops: " + (5000000 * 100 / sw.Elapsed.TotalSeconds));
            output.WriteLine("mspo: " + (sw.Elapsed.TotalSeconds * 1000 / (5000000 * 100)));
        }

        [Fact]
        public void T2()
        {
            
        }
    }
}