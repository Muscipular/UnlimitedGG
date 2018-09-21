using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Config
{
    class MapData : IHasId
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Dictionary<string, double> EncounterSets { get; set; }
    }
}