using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
            while (running)
            {
                if (ms > 0)
                {
                    Thread.Sleep((int)Math.Ceiling(ms));
                }
                var now = DateTime.Now;
                Execute(now);
                ms = Math.Max(Engine.FrameTime - (DateTime.Now - now).TotalMilliseconds, 1);
                // Console.WriteLine("delta: " + ms);
            }
        }
    }
}