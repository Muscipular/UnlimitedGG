using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data
{
    class PlayerInfo
    {
        public int MaxHP { get; set; }

        public int MaxMP { get; set; }

        public int Attack { get; set; }

        public int AttackDelta { get; set; }

        public int Defence { get; set; }

        public int Level { get; set; }

        public long Gold { get; set; }

        public long Exp { get; set; }

        public Item Head { get; set; } = new Item()
        {
            Stats = new Stats()
            {
                Defence = 2,
            }
        };

        public Item MainHand { get; set; } = new Item()
        {
            Stats = new Stats()
            {
                Attack = 1,
                AttackDelta = 2,
            }
        };

        public Item OffHand { get; set; } = new Item()
        {
            Stats = new Stats()
            {
                Defence = 1,
            }
        };

        public Item Foot { get; set; }

        public Item Body { get; set; }

        public Item Necklace { get; set; }

        public Item Ring1 { get; set; }

        public Item Ring2 { get; set; }
    }
}