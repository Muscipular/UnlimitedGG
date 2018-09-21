using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Config
{
    enum LootMode
    {
        Addition,

        Override,
    }

    class LootSetOverride
    {
        public double? GoldFactory { get; set; }

        public double? ExpFactory { get; set; }

        public double? ItemFactory { get; set; }

        public LootMode GoldMode { get; set; }

        public int? Gold { get; set; }

        public LootMode ExpMode { get; set; }

        public int? Exp { get; set; }

        public LootMode ItemMode { get; set; }

        public LootItem[] Item { get; set; }
    }

    class EncounterSet : IHasId
    {
        internal struct Count
        {
            public int? Min { get; set; }

            public int? Max { get; set; }
        }

        public string Id { get; set; }

        public Dictionary<string, Count> Enemies { get; set; }

        public int? MaxCount { get; set; }

        public LootSetOverride Loot { get; set; }
    }
}