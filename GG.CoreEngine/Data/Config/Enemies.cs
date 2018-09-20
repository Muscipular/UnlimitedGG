using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GG.CoreEngine.Utility;
using Newtonsoft.Json;

namespace GG.CoreEngine.Data
{
    class Enemies
    {
        private static Dictionary<string, EnemyData> configs = new Dictionary<string, EnemyData>();

        public static void Load(Stream stream)
        {
            var datas = new JsonSerializer().Deserialize<EnemyData[]>(new JsonTextReader(new StreamReader(stream)));
            configs = datas.ToDictionary(c => c.Id, c => c);
        }

        public static void Load(EnemyData[] datas)
        {
            configs = datas.ToDictionary(c => c.Id, c => c);
        }

        public static Enemy CreateEnemy(string eid)
        {
            if (configs.TryGetValue(eid, out var data))
            {
                return new Enemy(data);
            }
            return null;
        }
    }
}