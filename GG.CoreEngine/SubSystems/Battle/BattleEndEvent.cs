using System;
using System.Linq;

namespace GG.CoreEngine.SubSystems.Battle
{
    public class BattleEndEvent : IEvent, IFormattable
    {
        public bool Handled { get; set; }

        public BattleEndState State { get; set; }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return State.ToString();
        }
    }
}