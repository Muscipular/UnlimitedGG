using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.States;

namespace GG.CoreEngine.Commands
{
    public class EnterMapCommand : ICommand
    {
        public EnterMapCommand(string mapId)
        {
            if (!Config<MapData>.Configs.ContainsKey(mapId))
            {
                throw new Exception("mapId not found : " + mapId);
            }
            MapId = mapId;
        }

        public string MapId { get; }

        void ICommand.Execute(Engine engine)
        {
            var map = Config<MapData>.Configs[MapId];
            var mapState = engine.State.Get<MapState>();
            mapState.CurrentMap = map;
            mapState.ShouldEncounter = map.EncounterSets?.Count > 0;
            mapState.SumEncounterRate = map.EncounterSets?.Sum(c => c.Value) ?? 0;
        }
    }
}