using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GG.CoreEngine
{
    internal class EventManager
    {
        private class EventHandlers<T> where T : IEvent
        {
            public static List<IEventHandler<T>> Handlers = new List<IEventHandler<T>>();
        }

        private readonly Engine _engine;

        private ReaderWriterLockSlim rwLock;

        public EventManager(Engine engine)
        {
            _engine = engine;
            rwLock = new ReaderWriterLockSlim();
        }

        public void RegisterEvent<T>(IEventHandler<T> handler) where T : IEvent
        {
            rwLock.EnterWriteLock();
            var list = EventHandlers<T>.Handlers;
            if (!list.Contains(handler))
            {
                list.Add(handler);
                list.Sort((a, b) => a.Order - b.Order);
            }
            rwLock.ExitWriteLock();
        }

        public void PublishEvent<T>(T args) where T : IEvent
        {
            rwLock.EnterReadLock();
            var list = EventHandlers<T>.Handlers;
            for (var index = 0; index < list.Count; index++)
            {
                var handler = list[index];
                if (!handler.IsAlive)
                {
                    list.RemoveAt(index--);
                    continue;
                }
                if (handler.IsOnce)
                {
                    list.RemoveAt(index--);
                    continue;
                }
                handler.OnEvent(_engine, args);
            }
            rwLock.ExitReadLock();
        }
    }
}