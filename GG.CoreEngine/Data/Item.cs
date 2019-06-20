using System;
using System.Collections.Generic;
using System.Text;
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
        Head,

        Hand,

        OffHand,

        Body,

        Foot,

        Necklace,

        Ring,
    }

    class Item : IHasId
    {
        private ItemData ItemData;

        public Item(ItemData data)
        {
            DataId = data.Id;
            this.Populate(data);
            ItemData = data;
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
    }
}