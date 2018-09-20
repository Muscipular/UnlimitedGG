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
}