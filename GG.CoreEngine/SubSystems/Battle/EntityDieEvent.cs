using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;

namespace GG.CoreEngine.SubSystems.Battle
{
    internal class EntityDieEvent : IEvent
    {
        public bool Handled { get; set; }
        
        public IEntity Entity { get; set; }
    }
}