using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

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
                var block = Expression.Block(set.Select(c => Expression.Assign(Expression.Property(vTo, c), Expression.Property(vFrom, c))));
                var lambda = Expression.Lambda<Action<T, T2>>(block, vFrom, vTo);
                fn = lambda.Compile();
            }
        }

        public static T Populate<T, T2>(this T a, T2 b)
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
    }
}