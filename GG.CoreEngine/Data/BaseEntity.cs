using System;
using System.Collections.Generic;
using System.Text;

namespace GG.CoreEngine.Data
{
    abstract class BaseEntity : IEntity
    {
        public string Name { get; set; }

        public int Level { get; set; } = 1;

        public int HP { get; set; } = 10;

        public int MaxHP { get; set; } = 10;

        public int Attack { get; set; } = 1;

        public int AttackDelta { get; set; } = 5;

        public uint BaseAttackFrame { get; set; } = 60;

        public int Speed { get; set; } = 0;

        public uint FrameToAttack { get; set; }
    }

    internal class PlayerEntity : IEntity
    {
        public PlayerEntity()
        {
            Name = "Player";
        }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public int Attack { get; set; }

        public int AttackDelta { get; set; }

        public uint BaseAttackFrame { get; set; }

        public uint FrameToAttack { get; set; }

        public int HP { get; set; }

        public int Level { get; set; }

        public int MaxHP { get; set; }

        public string Name { get; set; }

        public int Speed { get; set; }
    }

    internal class EnemyData : IEntity
    {
        public string Id { get; set; }

        public int Attack { get; set; }

        public int AttackDelta { get; set; }

        public uint BaseAttackFrame { get; set; }

        public uint FrameToAttack { get; set; }

        public int HP { get; set; }

        public int Level { get; set; }

        public int MaxHP { get; set; }

        public string Name { get; set; }

        public int Speed { get; set; }
    }

    internal class Enemy : IEntity
    {
        public Enemy(EnemyData data)
        {
            
        }

        public int Attack { get; set; }

        public int AttackDelta { get; set; }

        public uint BaseAttackFrame { get; set; }

        public uint FrameToAttack { get; set; }

        public int HP { get; set; }

        public int Level { get; set; }

        public int MaxHP { get; set; }

        public string Name { get; set; }

        public int Speed { get; set; }
    }
}