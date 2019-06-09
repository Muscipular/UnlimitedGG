using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Config
{
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