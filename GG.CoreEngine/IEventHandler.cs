using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Type HandleType { get; }

        void OnEvent(Engine engine, TEvent arg);

        bool IsOnce { get; }

        bool IsAlive { get; }

        int Order { get; }
    }

    public interface IEvent
    {
        bool Handled { get; set; }
    }
}