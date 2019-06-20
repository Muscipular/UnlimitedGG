using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;

namespace GG.CoreEngine.States
{
    class PlayerState : IState
    {
        public string Name { get; } = typeof(PlayerState).Name;

        public PlayerEntity PlayerEntity { get; set; } = new PlayerEntity();

        public PlayerInfo PlayerInfo { get; set; } = new PlayerInfo();

        public bool ShouldEncounter { get; set; } = true;

        public Dictionary<string, Item> Bag { get; set; } = new List<Item>()
        {
            new Item(new ItemData()
            {
                Type = ItemType.Equip,
                Category = (long)EquipCategory.Head,
                Stats = new Stats()
                {
                    Defence = 1,
                }
            })
            {
                Id = "1"
            },
            new Item(new ItemData()
            {
                Type = ItemType.Equip,
                Category = (long)EquipCategory.Hand,
                Stats = new Stats()
                {
                    Attack = 1,
                }
            })
            {
                Id = "2"
            },
            new Item(new ItemData()
            {
                Type = ItemType.Equip,
                Category = (long)EquipCategory.Body,
                Stats = new Stats()
                {
                    Defence = 1,
                }
            })
            {
                Id = "3"
            },
        }.ToDictionary(e => e.Id, e => e);

        public bool ShouldUpdate { get; set; } = false;
    }
}