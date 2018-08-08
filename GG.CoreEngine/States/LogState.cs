using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.States
{
    class LogState : IState
    {
        public string Name { get; } = typeof(LogState).Name;

        public List<(string Msg, object Data)> Logs = new List<(string Msg, object Data)>();
    }
}