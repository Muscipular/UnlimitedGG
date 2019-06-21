using System;
using System.Collections.Generic;

namespace GG.CoreEngine.Data.Config
{
    class ItemData : IHasId
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ItemType Type { get; set; } = ItemType.None;

        public long Category { get; set; }


        public bool CanStack { get; set; }

        public int Count { get; set; } = 1;

        public int MaxCount { get; set; } = 1;
        
        public int Price { get; set; }
        
        public Stats Stats { get; set; }
    }
}