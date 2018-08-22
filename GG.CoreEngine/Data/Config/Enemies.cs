using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GG.CoreEngine.Data
{
    class Enemies
    {
        private static Dictionary<string, EnemyData> configs = new Dictionary<string, EnemyData>();

        public static void Load(Stream stream)
        {
            var dictionary = new JsonSerializer().Deserialize<EnemyData[]>(new JsonTextReader(new StreamReader(stream)));
            configs = dictionary.ToDictionary(c => c.Id, c => c);
        }

        public static Enemy CreateEnemy(string eid)
        {
            var enemy = new Enemy();
            return enemy;
        }
    }
}
