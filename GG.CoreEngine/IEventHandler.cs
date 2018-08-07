using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine
{
    public interface IEventHandler
    {
        void OnEvent(Engine engine, object arg);
    }

    public interface IWeakEventHandler : IEventHandler
    {
        bool IsAlive { get; }
    }
}