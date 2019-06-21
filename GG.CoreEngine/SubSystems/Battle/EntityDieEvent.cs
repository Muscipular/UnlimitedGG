using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;

namespace GG.CoreEngine.SubSystems.Battle
{
    internal class EntityDieEvent : IEvent, IFormattable
    {
        public bool Handled { get; set; }
        
        public IEntity Entity { get; set; }

        public override string ToString()
        {
            return $"{nameof(Entity)}: {Entity}";
        }

        public string ToString(string format, IFormatProvider formatProvider) => ToString();
    }
}