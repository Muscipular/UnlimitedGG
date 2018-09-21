using System;
using System.Collections.Generic;
using System.Text;
using GG.CoreEngine.Data.Config;

namespace GG.CoreEngine.States
{
    class MapState : IState
    {
        public string Name { get; } = nameof(MapState);

        public MapData CurrentMap { get; set; }

        public bool ShouldEncounter { get; set; }

        public double SumEncounterRate { get; set; }
    }
}