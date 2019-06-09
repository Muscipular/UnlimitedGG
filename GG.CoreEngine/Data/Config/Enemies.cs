using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Config
{
    class Enemies
    {
        public static Enemy CreateEnemy(string eid)
        {
            if (Config<EnemyData>.TryGetData(eid, out var data))
            {
                return new Enemy(data);
            }
            return null;
        }
    }
}