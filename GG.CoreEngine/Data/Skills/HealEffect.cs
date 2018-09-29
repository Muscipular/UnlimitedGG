using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.Data.Skills
{
    class HealEffect : IHealEffect
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public EffectType Type { get; set; }

        public int Index { get; } = 1000;

        public int CalcHeal(IEntity entity)
        {
            if (Value?.Length <= 0)
            {
                return 0;
            }
            return Rand.Int((int)Value[0], (int)Value[1]) + (int)Math.Floor((entity.Attack + Rand.Int(entity.AttackDelta)) * Rand.Double(Value[2], Value[3]));
        }

        public EntityStateType StateType { get; set; } = EntityStateType.Int;

        public double[] Value { get; set; }

        public int Turn { get; set; }

        public int TurnLeft { get; set; }
    }
}