﻿using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data.Skills;

namespace GG.CoreEngine.Data
{
    internal class PlayerEntity : IEntity
    {
        public PlayerEntity()
        {
            Name = "Player";
        }

        public int Exp { get; set; }

        public int Gold { get; set; }

        public int Attack { get; set; } = 1;

        public int AttackDelta { get; set; } = 3;

        public int Defence { get; set; }

        public uint BaseActionFrame { get; set; } = 60;

        public uint FrameToAction { get; set; } = 0;

        public int HP { get; set; } = 100;

        public int Level { get; set; } = 1;

        public int MaxHP { get; set; } = 100;

        public string Name { get; set; }

        public int Speed { get; set; }

        public int ReduceDamage { get; set; }

        public List<IEffect> Effects { get; set; }
    }
}