using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GG.CoreEngine.Data.Config
{
    class Config<T> where T : IHasId
    {
        private static Dictionary<string, T> _configs = new Dictionary<string, T>();

        public static bool TryGetData(string name, out T data) => _configs.TryGetValue(name, out data);

        public static int Count => _configs.Count;

        public static bool HasKey(string name) => _configs.ContainsKey(name);

        public static void Load(Stream stream)
        {
            var datas = new JsonSerializer().Deserialize<T[]>(new JsonTextReader(new StreamReader(stream)));
            _configs = datas.ToDictionary(c => c.Id, c => c);
        }

        public static void Load(T[] datas)
        {
            _configs = datas.ToDictionary(c => c.Id, c => c);
        }

        public static void Load(IDataLoader loader)
        {
            Load(loader.Load(typeof(T).Name));
        }
    }
}