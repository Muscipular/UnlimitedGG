using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GG.CoreEngine.Data.Buffers;
using GG.CoreEngine.Data.Skills;

namespace GG.CoreEngine.Data
{
    interface IEntity
    {
        int Attack { get; set; }

        int AttackDelta { get; set; }

        int Defence { get; set; }

        int BaseActionFrame { get; set; }

        int FrameToAction { get; set; }

        int HP { get; set; }

        int Level { get; set; }

        int MaxHP { get; set; }

        string Name { get; set; }

        int Speed { get; set; }

        int ReduceDamage { get; set; }

        Stats Stats { get; set; }

        Stats TempStats { get; set; }

        Stats MultStats { get; set; }

        IBuffer[] Buffers { get; set; }
    }
}