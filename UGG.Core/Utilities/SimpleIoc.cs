using System;
using System.Collections.Generic;
using System.Linq;

namespace UGG.Core.Utilities
{
    public class SimpleIoc
    {
        public static readonly SimpleIoc Instance = new SimpleIoc();

        private class Container<T>
        {
            internal static List<T> cache = new List<T>();
        }

        public void Register<T>(T instance)
        {
            var list = Container<T>.cache;
            list.Add(instance);
        }

        public T GetService<T>()
        {
            var list = Container<T>.cache;
            return list.Count > 0 ? list[list.Count - 1] : default(T);
        }

        public IReadOnlyList<T> GetServices<T>()
        {
            return Container<T>.cache;
        }
    }
}