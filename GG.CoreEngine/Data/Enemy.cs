using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.Data
{
    internal class Enemy : IEntity
    {
        public Enemy()
        {
        }

        public Enemy(EnemyData data)
        {
            this.Populate(data);
            this.Data = data;
        }

        public EnemyData Data { get; set; }

        public int Attack { get; set; }

        public int AttackDelta { get; set; }

        public int Defence { get; set; }

        public uint BaseAttackFrame { get; set; }

        public uint FrameToAttack { get; set; }

        public int HP { get; set; }

        public int Level { get; set; }

        public int MaxHP { get; set; }

        public string Name { get; set; }

        public int Speed { get; set; }

        public int ReduceDamage { get; set; }
    }
}