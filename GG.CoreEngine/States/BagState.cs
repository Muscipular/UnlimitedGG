using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.States
{
    class BagState : IState
    {
        public string Name { get; } = typeof(BagState).Name;

        private Dictionary<string, Item> Bag { get; set; } = new Dictionary<string, Item>();

        public int MaxCount { get; set; } = 50;

        public int Count => Bag.Count;

        public Item this[string id] => Bag.TryGetValue(id, out var item) ? item : null;

        public bool Add(Item item)
        {
            if (item.CanStack)
            {
                while (item.Count > 0)
                {
                    var value = Bag.Values.FirstOrDefault(e => e.DataId == item.DataId && e.Count < e.MaxCount);
                    if (value == null)
                    {
                        value = new Item().Populate(item);
                        value.Count = 0;
                        DoAdd(value);
                    }
                    var i = value.MaxCount - value.Count;
                    value.Count += i;
                    item.Count -= i;
                }
                return true;
            }
            return DoAdd(item);
        }

        private bool DoAdd(Item item)
        {
            if (Count >= MaxCount)
            {
                return false;
            }
            return Bag.TryAdd(item.Id, item);
        }

        public bool Remove(Item item, int count = 1)
        {
            if (item.CanStack && item.Count > 1)
            {
                item.Count--;
                return true;
            }
            return Bag.Remove(item.Id);
        }

        public bool Remove(string itemId, int count = 1)
        {
            var item = this[itemId];
            if (item == null)
            {
                return false;
            }
            return Remove(item, count);
        }

        public List<Item> RemoveByType(string dataId, int count = 1)
        {
            var items = new List<Item>();
            while (count > 0)
            {
                var item = Bag.Values.FirstOrDefault(e => e.DataId == dataId);
                if (item == null)
                {
                    break;
                }
                if (!item.CanStack || item.Count <= count)
                {
                    items.Add(item);
                    count -= item.CanStack ? item.Count : 1;
                    continue;
                }
                var clone = new Item().Populate(item);
                clone.Count = count;
                item.Count -= count;
                items.Add(clone);
                break;
            }
            return items;
        }

        public bool HasItem(Item item)
        {
            return Bag.ContainsKey(item.Id);
        }

        public bool HasItem(string itemId)
        {
            return Bag.ContainsKey(itemId);
        }
    }
}