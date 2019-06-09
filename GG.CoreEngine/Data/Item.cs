using System;
using System.Collections.Generic;
using System.Text;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.Data
{
    class Item
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
    }
}