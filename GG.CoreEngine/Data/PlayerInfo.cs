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

        public Dictionary<EquipCategory, int> EquipSlot { get; set; } = new[]
        {
            EquipCategory.Head, EquipCategory.Body, EquipCategory.Foot,
            EquipCategory.Hand, EquipCategory.OffHand,
            EquipCategory.Necklace, EquipCategory.Ring, EquipCategory.Ring
        }.ToLookup(e => e, e => e).ToDictionary(e => e.Key, e => e.Count());

        public Dictionary<string, Item> Equips { get; set; } = new Dictionary<string, Item>();
    }
}