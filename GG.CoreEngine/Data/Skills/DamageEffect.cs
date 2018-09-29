using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.Data.Skills
{
    enum EntityStateType
    {
        Attack,

        Str,

        Int,

        HP,

        MaxHP,
    }

    static class EntityExtensions
    {
        public static double GetValueByState(this IEntity entity, EntityStateType type)
        {
            switch (type)
            {
                case EntityStateType.Str:
                    return 0;
                case EntityStateType.HP:
                    return entity.HP;
                case EntityStateType.MaxHP:
                    return entity.MaxHP;
                case EntityStateType.Attack:
                    return entity.Attack + Rand.Int(entity.AttackDelta);
                default:
                    return 0;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double CalcDefenceReduceRate(this IEntity target)
        {
            var x = (double)target.Defence;
            return x / (Math.Abs(x) + Math.Pow(Math.Abs(x), 0.25F) * 3 + 30);
        }
    }

    class DamageEffect : IDamageEffect
    {
        public string Description { get; set; }

        public string Name { get; set; }

        public EffectType Type => EffectType.Damage;

        public int Index { get; set; } = int.MaxValue;

        public double[] Value { get; set; }

        public EntityStateType StateType { get; set; }

        public int CalcDamange(IEntity entity)
        {
            if (Value?.Length <= 0)
            {
                return (int)entity.GetValueByState(StateType);
            }
            return Rand.Int((int)Value[0], (int)Value[1]) + (int)Math.Floor((entity.Attack + Rand.Int(entity.AttackDelta)) * Rand.Double(Value[2], Value[3]));
        }
    }
}