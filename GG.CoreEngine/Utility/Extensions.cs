using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GG.CoreEngine.Data;

namespace GG.CoreEngine.Utility
{
    static class Extensions
    {
        class PopulateClass<T, T2>
        {
            public static Action<T, T2> fn;

            static PopulateClass()
            {
                var tForm = typeof(T);
                var tTo = typeof(T2);
                var vFrom = Expression.Variable(tForm);
                var vTo = Expression.Variable(tTo);
                var set = new HashSet<string>(tForm.GetProperties().Where(c => c.CanRead).Select(c => c.Name));
                set.IntersectWith(tTo.GetProperties().Where(c => c.CanWrite).Select(c => c.Name));
                var block = Expression.Block(set.Select(c => Expression.Assign(Expression.Property(vTo, c),
                    Expression.Convert(Expression.Property(vFrom, c), tTo.GetProperty(c).PropertyType))));
                var lambda = Expression.Lambda<Action<T, T2>>(block, vFrom, vTo);
                fn = lambda.Compile();
            }
        }

        public static T Populate<T, T2>(this T a, T2 b) where T : class
        {
            PopulateClass<T2, T>.fn(b, a);
            return a;
        }

        public static bool EqualsAs(this float a, float b, float delta = 0.0001f)
        {
            return Math.Abs(a - b) < delta;
        }

        public static bool EqualsAs(this decimal a, decimal b, decimal delta = 0.0001m)
        {
            return Math.Abs(a - b) < delta;
        }

        public static bool EqualsAs(this double a, double b, double delta = 0.0001d)
        {
            return Math.Abs(a - b) < delta;
        }

        public static IEntity ApplyStats(this IEntity entity)
        {
            var stats = (entity.Stats + entity.TempStats) * entity.MultStats;
            entity.Attack = (int)stats.Attack;
            entity.AttackDelta = (int)stats.AttackDelta;
            entity.Defence = (int)stats.Defence;
            entity.BaseActionFrame = (int)stats.BaseActionFrame;
            entity.MaxHP = (int)stats.MaxHP;
            entity.Speed = (int)stats.Speed;
            entity.ReduceDamage = (int)stats.ReduceDamage;
            return entity;
        }
    }
}