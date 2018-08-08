using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine
{
    public interface IEventHandler
    {
        void OnEvent(Engine engine, object arg);

        bool IsOnce { get; }
        bool IsAlive { get; }
    }
}