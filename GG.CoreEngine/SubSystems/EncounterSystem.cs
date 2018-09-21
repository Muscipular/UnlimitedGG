using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.States;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.SubSystems
{
    class EncounterSystem : ISubSystem
    {
        private readonly Engine _engine;

        public EncounterSystem(Engine engine)
        {
            _engine = engine;
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
            var rate = mapState.SumEncounterRate;
            var d = Rand.Double(0, rate);
            EncounterSet set = null;
            foreach (var (setId, _rate) in mapState.CurrentMap.EncounterSets)
            {
                if (Config<EncounterSet>.Configs.TryGetValue(setId, out var _set))
                {
                    set = _set;
                }
                d -= _rate;
                if (d <= 0)
                {
                    break;
                }
            }
            var player = playerState.PlayerEntity;
            player.HP = player.MaxHP;
            player.FrameToAttack = 0;
            var enemyTeam = battleState.EnemyTeam;
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

            battleState.LootData = GetLootData(set, enemyTeam.OfType<Enemy>());
            battleState.PlayerTeam.Clear();
            battleState.PlayerTeam.Add(player);
            battleState.StateMode = BattleStateMode.InBattle;
            battleState.WaitFrame = 60;
        }

        private LootData GetLootData(EncounterSet set, IEnumerable<Enemy> enemyTeam)
        {
            var lootData = new LootData();
            var items = new List<LootItem>();
            if (set.Loot?.ItemMode != LootMode.Override)
            {
                foreach (var enemy in enemyTeam)
                {
                    if (enemy.Data.Loot?.Item.Length > 0)
                    {
                        items.AddRange(enemy.Data.Loot.Item);
                    }
                }
            }
            if (set.Loot?.GoldMode != LootMode.Override)
            {
                lootData.Gold = (int)enemyTeam.Sum(c => (c.Data.Loot?.Gold ?? c.Data.Level * 10) * Rand.Double(0.9, 1.1));
            }
            if (set.Loot?.ExpMode != LootMode.Override)
            {
                lootData.Exp = enemyTeam.Sum(c => c.Data.Loot?.Exp ?? c.Data.Level * c.Data.Level);
            }
            if (set.Loot != null)
            {
                if (set.Loot.Item?.Length > 0)
                {
                    items.AddRange(set.Loot.Item);
                }
                if (set.Loot.ItemFactory.HasValue)
                {
                    var f = set.Loot.ItemFactory.Value;
                    foreach (var lootItem in items)
                    {
                        lootItem.Rate = Math.Min(1, lootItem.Rate * f);
                    }
                }
                lootData.Exp += set.Loot.Exp ?? 0;
                lootData.Gold += set.Loot.Gold ?? 0;
                lootData.Exp = (int)(lootData.Exp * (set.Loot.ExpFactory ?? 1));
                lootData.Gold = (int)(lootData.Gold * (set.Loot.GoldFactory ?? 1));
            }
            if (items.Count > 0)
            {
                lootData.Item = items.ToArray();
            }
            return lootData;
        }
    }
}