using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Config
{
    public class LootData
    {
        public int Gold { get; set; }

        public int Exp { get; set; }

        public LootItem[] Item { get; set; }
    }

    public class LootItem
    {
        public string Id { get; set; }

        public double Rate { get; set; }
    }

    internal class EnemyData : IHasId
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

        public LootData Loot { get; set; }
    }
}