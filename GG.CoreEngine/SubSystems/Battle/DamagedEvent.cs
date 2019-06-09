using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;

namespace GG.CoreEngine.SubSystems.Battle
{
    internal class DamagedEvent : IEvent, IFormattable
    {
        public int Damage { get; }

        public IEntity From { get; }

        public IEntity To { get; }

        public DamagedEvent(int damage, IEntity from, IEntity to)
        {
            Damage = damage;
            From = from;
            To = to;
        }

        public bool Handled { get; set; }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{From.Name} deal {Damage} on {To.Name}({To.HP})";
        }
    }
}