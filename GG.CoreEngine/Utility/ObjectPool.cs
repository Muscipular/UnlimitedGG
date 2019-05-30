using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Utility
{
    internal class ObjectPool<T> where T : class
    {
        private readonly Func<T> _factory;

        private readonly Func<T, bool> _returnFunc;

        private readonly int _maxSize;

        private readonly T[] _bag;

        public ObjectPool(Func<T> factory, Func<T, bool> returnFunc = null, int maxSize = 10)
        {
            _factory = factory;
            _returnFunc = returnFunc;
            _maxSize = maxSize;
            _bag = new T[maxSize];
        }

        public int Count { get; private set; }

        public int MaxSize => _maxSize;

        public T Take()
        {
            if (Count > 0)
            {
                var take = _bag[Count - 1];
                _bag[Count--] = null;
                return take;
            }
            return _factory();
        }

        public void Return(T v)
        {
            var dispose = false;
            try
            {
                if (v == null)
                {
                    return;
                }
                if (Count > _maxSize)
                {
                    dispose = v is IDisposable;
                    return;
                }
                if (_returnFunc?.Invoke(v) ?? true)
                {
                    _bag[Count++] = v;
                }
                else
                {
                    dispose = v is IDisposable;
                }
            }
            finally
            {
                if (dispose) ((IDisposable)v).Dispose();
            }
        }
    }
}