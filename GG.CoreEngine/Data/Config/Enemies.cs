using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace GG.CoreEngine.Data.Config
{
    class Config<T> where T : IHasId
    {
        public static Dictionary<string, T> Configs { get; private set; } = new Dictionary<string, T>();

        public static void Load(Stream stream)
        {
            var datas = new JsonSerializer().Deserialize<T[]>(new JsonTextReader(new StreamReader(stream)));
            Configs = datas.ToDictionary(c => c.Id, c => c);
        }

        public static void Load(T[] datas)
        {
            Configs = datas.ToDictionary(c => c.Id, c => c);
        }
    }

    class Enemies
    {
        public static Enemy CreateEnemy(string eid)
        {
            if (Config<EnemyData>.Configs.TryGetValue(eid, out var data))
            {
                return new Enemy(data);
            }
            return null;
        }
    }
}