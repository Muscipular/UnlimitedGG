using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data
{
    internal class EnemyData
    {
        public string Id { get; set; }

        public int Attack { get; set; }

        public int AttackDelta { get; set; }

        public uint BaseAttackFrame { get; set; }
        
        public int HP { get; set; }

        public int Level { get; set; }

        public int MaxHP { get; set; }

        public string Name { get; set; }

        public int Defence { get; set; }

        public int ReduceDamage { get; set; }
    }
}