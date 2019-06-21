using System;
using System.Collections.Generic;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.Data
{
    enum ItemType
    {
        None,

        Potion,

        Equip,

        Misc
    }

    [Flags]
    enum EquipCategory
    {
        Head = 1,

        Hand = 2,

        OffHand = 4,

        Body = 8,

        Foot = 16,

        Necklace = 32,

        Ring = 64,
    }

    class Item : IHasId
    {
        private ItemData ItemData;

        public Item(ItemData data)
        {
            var id = Id;
            DataId = data.Id;
            this.Populate(data);
            ItemData = data;
            Id = id;
        }

        public Item()
        {
        }

        public string DataId { get; set; }

        public ItemType Type { get; set; } = ItemType.None;

        public long Category { get; set; }

        public Stats Stats { get; set; }

        public ItemData Data
        {
            get
            {
                if (ItemData == null)
                {
                    Config<ItemData>.TryGetData(DataId, out ItemData);
                }
                return ItemData;
            }
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }

        public bool CanStack { get; set; }

        public int Count { get; set; } = 1;

        public int MaxCount { get; set; } = 1;
    }
}