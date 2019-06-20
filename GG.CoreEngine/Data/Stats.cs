using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data
{
    struct Stats
    {
        public double Attack { get; set; }

        public double AttackDelta { get; set; }

        public double Defence { get; set; }

        public double BaseActionFrame { get; set; }

        public double MaxHP { get; set; }

        public double Speed { get; set; }

        public double ReduceDamage { get; set; }

        internal static Stats BaseMult => new Stats()
        {
            Attack = 1,
            AttackDelta = 1,
            Defence = 1,
            BaseActionFrame = 1,
            Speed = 1,
            MaxHP = 1,
            ReduceDamage = 1,
        };

        internal static Stats BaseStats => new Stats()
        {
            Attack = 1,
            AttackDelta = 4,
            Defence = 0,
            BaseActionFrame = 60,
            Speed = 0,
            MaxHP = 100,
            ReduceDamage = 0,
        };

        internal void Add(Stats _stats)
        {
            this.Attack += _stats.Attack;
            this.AttackDelta += _stats.AttackDelta;
            this.Defence += _stats.Defence;
            this.BaseActionFrame += _stats.BaseActionFrame;
            this.MaxHP += _stats.MaxHP;
            this.Speed += _stats.Speed;
            this.ReduceDamage += _stats.ReduceDamage;
        }

        public static Stats operator +(Stats left, Stats right)
        {
            return new Stats
            {
                Attack = left.Attack + right.Attack,
                AttackDelta = left.AttackDelta + right.AttackDelta,
                Defence = left.Defence + right.Defence,
                BaseActionFrame = left.BaseActionFrame + right.BaseActionFrame,
                MaxHP = left.MaxHP + right.MaxHP,
                Speed = left.Speed + right.Speed,
                ReduceDamage = left.ReduceDamage + right.ReduceDamage,
            };
        }

        public static Stats operator +(Stats left, Stats? right)
        {
            return right.HasValue ? left + right.Value : left;
        }

        public static Stats operator +(Stats? right, Stats left)
        {
            return right.HasValue ? left + right.Value : left;
        }

        public static Stats operator -(Stats left, Stats right)
        {
            return new Stats
            {
                Attack = left.Attack - right.Attack,
                AttackDelta = left.AttackDelta - right.AttackDelta,
                Defence = left.Defence - right.Defence,
                BaseActionFrame = left.BaseActionFrame - right.BaseActionFrame,
                MaxHP = left.MaxHP - right.MaxHP,
                Speed = left.Speed - right.Speed,
                ReduceDamage = left.ReduceDamage - right.ReduceDamage,
            };
        }

        public static Stats operator -(Stats left, Stats? right)
        {
            return right.HasValue ? left - right.Value : left;
        }


        public static Stats operator -(Stats? right, Stats left)
        {
            return right.HasValue ? left - right.Value : left;
        }

        public static Stats operator -(Stats left)
        {
            return left * new Stats()
            {
                Attack = -1,
                AttackDelta = -1,
                Defence = -1,
                BaseActionFrame = -1,
                MaxHP = -1,
                Speed = -1,
                ReduceDamage = -1,
            };
        }

        public static Stats operator *(Stats left, Stats right)
        {
            return new Stats
            {
                Attack = left.Attack * right.Attack,
                AttackDelta = left.AttackDelta * right.AttackDelta,
                Defence = left.Defence * right.Defence,
                BaseActionFrame = left.BaseActionFrame * right.BaseActionFrame,
                MaxHP = left.MaxHP * right.MaxHP,
                Speed = left.Speed * right.Speed,
                ReduceDamage = left.ReduceDamage * right.ReduceDamage,
            };
        }

        public static Stats operator *(Stats left, Stats? right)
        {
            return right.HasValue ? left * right.Value : left;
        }

        public static Stats operator *(Stats? right, Stats left)
        {
            return right.HasValue ? left * right.Value : left;
        }

        public override string ToString()
        {
            return $"{nameof(Attack)}: {Attack}, {nameof(AttackDelta)}: {AttackDelta}, {nameof(Defence)}: {Defence}, {nameof(BaseActionFrame)}: {BaseActionFrame}, {nameof(MaxHP)}: {MaxHP}, {nameof(Speed)}: {Speed}, {nameof(ReduceDamage)}: {ReduceDamage}";
        }
    }
}