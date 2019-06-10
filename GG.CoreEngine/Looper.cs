using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine
{
    internal class Looper
    {
        private Action<DateTime> Execute;

        private double ms = 0;

        private Thread thread;

        private bool running;

        public Looper(Action<DateTime> execute)
        {
            Execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }


        public bool Running
        {
            get { return running; }
        }

        public void Start()
        {
            if (running)
            {
                throw new InvalidOperationException("loop is running");
            }
            running = true;
            thread = new Thread(Loop);
            thread.Start();
        }

        public void Stop()
        {
            if (!running)
            {
                throw new InvalidOperationException("loop is not running");
            }
            running = false;
            if (thread.ManagedThreadId != Thread.CurrentThread.ManagedThreadId)
            {
                thread.Join();
            }
        }

        public void Loop()
        {
            var sw = Stopwatch.StartNew();
            while (running)
            {
                if (ms > 0)
                {
                    while (ms > 0)
                    {
                        sw.Restart();
                        Thread.Sleep(1);
                        sw.Stop();
                        ms -= sw.Elapsed.TotalMilliseconds;
                    }
                }
                var now = DateTime.Now;
                sw.Restart();
                Execute(now);
                sw.Stop();
                var d = sw.Elapsed.TotalMilliseconds;
                ms += Engine.FrameTime - d;
            }
        }
    }
}