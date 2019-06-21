using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.States;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.SubSystems.Encounter
{
    class EncounterSystem : ISubSystem
    {
        private readonly Engine _engine;

        public EncounterSystem(Engine engine)
        {
            _engine = engine;
        }

        public void OnInitial(Engine engine)
        {
            
        }

        public void Process(ulong frame)
        {
            var battleState = _engine.State.Get<BattleState>();
            if (battleState.StateMode != BattleStateMode.Encounter)
            {
                return;
            }
            var playerState = _engine.State.Get<PlayerState>();
            if (!playerState.ShouldEncounter)
            {
                return;
            }
            var mapState = _engine.State.Get<MapState>();
            if (!mapState.ShouldEncounter)
            {
                return;
            }
            var set = GetEncounterSet(mapState);
            var enemyTeam = SetupEnemyTeam(set);

            _engine.PublishEvent(new EncounterEvent(set, enemyTeam));
        }

        private List<IEntity> SetupEnemyTeam(EncounterSet set)
        {
            var enemyTeam = new List<IEntity>();
            enemyTeam.Clear();
            int max = set?.MaxCount ?? 10;
            int min = 1;
            while (enemyTeam.Count < min && enemyTeam.Count < max)
            {
                foreach (var (enemyId, c) in set.Enemies)
                {
                    var c1 = Rand.Int(c.Min ?? 1, Math.Min(c.Max ?? max, max - enemyTeam.Count));
                    for (int i = 0; i < c1; i++)
                    {
                        var entity = Enemies.CreateEnemy(enemyId);
                        if (entity == null)
                        {
                            break;
                        }
                        enemyTeam.Add(entity);
                    }

                    if (enemyTeam.Count >= max)
                    {
                        break;
                    }
                }
            }
            return enemyTeam;
        }

        private EncounterSet GetEncounterSet(MapState mapState)
        {
            var rate = mapState.SumEncounterRate;
            var d = Rand.Double(0, rate);
            EncounterSet set = null;
            foreach (var (setId, _rate) in mapState.CurrentMap.EncounterSets)
            {
                if (Config<EncounterSet>.TryGetData(setId, out var _set))
                {
                    set = _set;
                }
                d -= _rate;
                if (d <= 0)
                {
                    break;
                }
            }
            return set;
        }
    }
}