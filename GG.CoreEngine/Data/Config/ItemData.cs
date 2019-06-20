using System;
using System.Collections.Generic;
using System.Text;

namespace GG.CoreEngine.Data.Config
{
    class ItemData : IHasId
    {
        public string Id { get; set; }

        public ItemType Type { get; set; } = ItemType.None;

        public long Category { get; set; }

        public Stats Stats { get; set; }
    }
}