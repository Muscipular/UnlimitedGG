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
                var type1 = typeof(T);
                var type2 = typeof(T2);
                var v1 = Expression.Variable(type1);
                var v2 = Expression.Variable(type2);
                var set = new HashSet<string>(type1.GetProperties().Where(c => c.CanRead).Select(c => c.Name));
                set.IntersectWith(type1.GetProperties().Where(c => c.CanWrite).Select(c => c.Name));
                var block = Expression.Block(set.Select(c => Expression.Assign(Expression.Property(v2, c), Expression.Property(v1, c))));
                var lambda = Expression.Lambda<Action<T, T2>>(block, v1, v2);
                fn = lambda.Compile();
            }
        }

        public static void Populate<T, T2>(T a, T2 b)
        {
            PopulateClass<T, T2>.fn(a, b);
        }
    }
}