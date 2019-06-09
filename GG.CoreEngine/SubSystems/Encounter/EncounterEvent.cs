using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.SubSystems.Encounter
{
    class EncounterEvent : IEvent
    {
        public bool Handled { get; set; }
    }
}