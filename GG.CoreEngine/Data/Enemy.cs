using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data.Buffers;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.Data.Skills;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.Data
{
    internal class Enemy : IEntity
    {
        public Enemy()
        {
        }

        public Enemy(EnemyData data)
        {
            this.Populate(data);
            this.Data = data;
            this.Stats = new Stats()
            {
                Attack = data.Attack,
                AttackDelta = data.AttackDelta,
                Defence = data.Defence,
                Speed = data.Speed,
                ReduceDamage = data.ReduceDamage,
                BaseActionFrame = data.BaseActionFrame,
                MaxHP = data.MaxHP,
            };
        }

        public EnemyData Data { get; set; }

        public int Attack { get; set; }

        public int AttackDelta { get; set; }

        public int Defence { get; set; }

        public int BaseActionFrame { get; set; }

        public int FrameToAction { get; set; }

        public int HP { get; set; }

        public int Level { get; set; }

        public int MaxHP { get; set; }

        public string Name { get; set; }

        public int Speed { get; set; }

        public int ReduceDamage { get; set; }

        public Stats Stats { get; set; }

        public Stats TempStats { get; set; }

        public Stats MultStats { get; set; } = Stats.BaseMult;

        public IBuffer[] Buffers { get; set; } = Array.Empty<IBuffer>();

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return $"{nameof(Level)}: {Level}, {nameof(Name)}: {Name}, {nameof(HP)}: {HP}";
        }
    }
}