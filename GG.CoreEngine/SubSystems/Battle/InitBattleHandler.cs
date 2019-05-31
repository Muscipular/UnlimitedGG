using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.SubSystems
{
    class InitBattleHandler : IEventHandler<EncounterEvent>
    {
        public Type HandleType { get; set; }

        public void OnEvent(Engine engine, EncounterEvent arg)
        {
        }

        public bool IsOnce { get; set; }

        public bool IsAlive { get; set; }

        public int Order => 1;
    }
}