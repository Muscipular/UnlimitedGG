using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GG.CoreEngine
{
    internal class EventManager
    {
        private readonly Engine _engine;

        private Dictionary<string, List<IEventHandler>> Events;

        private ReaderWriterLockSlim rwLock;

        public EventManager(Engine engine)
        {
            _engine = engine;
            Events = new Dictionary<string, List<IEventHandler>>();
            rwLock = new ReaderWriterLockSlim();
        }

        public void RegisterEvent(string eventName, IEventHandler handler)
        {
            rwLock.EnterWriteLock();
            if (!Events.TryGetValue(eventName, out var list))
            {
                Events.Add(eventName, list = new List<IEventHandler>() { });
            }
            if (!list.Contains(handler))
            {
                list.Add(handler);
            }
            rwLock.ExitWriteLock();
        }

        public void PublishEvent(string eventName, object args)
        {
            rwLock.EnterReadLock();
            if (Events.TryGetValue(eventName, out var list))
            {
                for (var index = 0; index < list.Count; index++)
                {
                    var handler = list[index];
                    if (handler is IWeakEventHandler weakEventHandler)
                    {
                        if (!weakEventHandler.IsAlive)
                        {
                            list.RemoveAt(index--);
                        }
                    }
                    handler.OnEvent(_engine, args);
                }
            }
            rwLock.ExitReadLock();
        }
    }
}