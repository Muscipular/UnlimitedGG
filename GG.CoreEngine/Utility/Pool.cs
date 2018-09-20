using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Extensions.ObjectPool;

namespace GG.CoreEngine.Utility
{
    // interface IPoolObject : IDisposable
    // {
    //     bool Released { get; set; }
    // }

    class Pool<T> where T : class
    {
        class Policy : IPooledObjectPolicy<T>
        {
            private static Func<T> fn;

            static Policy()
            {
                fn = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
            }

            public T Create()
            {
                return fn();
            }

            public bool Return(T obj)
            {
                return true;
            }
        }

        private static IPooledObjectPolicy<T> policy = new Policy();

        private DefaultObjectPool<T> pool;


        public Pool(int maxCount)
        {
            pool = new DefaultObjectPool<T>(policy, maxCount);
        }

        internal static Pool<T> Default { get; } = new Pool<T>(20);

        public T Get()
        {
            return pool.Get();
        }

        public void Return(T obj)
        {
            pool.Return(obj);
        }
    }
}