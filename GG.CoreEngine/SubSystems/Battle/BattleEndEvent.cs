using System;
using System.Linq;
using GG.CoreEngine.Data;


namespace GG.CoreEngine.SubSystems.Battle
{
    public enum BattleEndState
    {
        Win,

        Lose,

        Tie
    }

    public class BattleEndEvent : IEvent
    {
        public bool Handled { get; set; }

        public BattleEndState State { get; set; }
    }

    internal class EntityDieEvent : IEvent
    {
        public bool Handled { get; set; }
        
        public IEntity Entity { get; set; }
    }

    internal class DamagedEvent : IEvent
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
    }
}