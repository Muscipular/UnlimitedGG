using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.States;
using GG.CoreEngine.SubSystems.Encounter;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.SubSystems
{
    class LootSystem : ISubSystem
    {
        class SetBattleLootHandler : IEventHandler<EncounterEvent>
        {
            private LootData GetLootData(EncounterSet set)
            {
                var lootData = new LootData();
                var items = new List<LootItem>();
                var enemyDatas = set.Enemies.Select((p) => Config<EnemyData>.TryGetData(p.Key, out var d) ? d : null).Where(e => e != null).ToList();

                if (set.Loot?.ItemMode != LootMode.Override)
                {
                    foreach (var enemy in enemyDatas)
                    {
                        if (enemy.Loot?.Item.Length > 0)
                        {
                            items.AddRange(enemy.Loot.Item);
                        }
                    }
                }
                if (set.Loot?.GoldMode != LootMode.Override)
                {
                    lootData.Gold = (int)enemyDatas.Sum(c => (c.Loot?.Gold ?? c.Level * 10) * Rand.Double(0.9, 1.1));
                }
                if (set.Loot?.ExpMode != LootMode.Override)
                {
                    lootData.Exp = enemyDatas.Sum(c => c.Loot?.Exp ?? c.Level * c.Level);
                }
                if (set.Loot != null)
                {
                    if (set.Loot.Item?.Length > 0)
                    {
                        items.AddRange(set.Loot.Item);
                    }
                    if (set.Loot.ItemMult.HasValue)
                    {
                        var f = set.Loot.ItemMult.Value;
                        foreach (var lootItem in items)
                        {
                            lootItem.Rate = Math.Min(1, lootItem.Rate * f);
                        }
                    }
                    lootData.Exp += set.Loot.Exp ?? 0;
                    lootData.Gold += set.Loot.Gold ?? 0;
                    lootData.Exp = (int)(lootData.Exp * (set.Loot.ExpMult ?? 1));
                    lootData.Gold = (int)(lootData.Gold * (set.Loot.GoldMult ?? 1));
                }
                if (items.Count > 0)
                {
                    lootData.Item = items.ToArray();
                }
                return lootData;
            }

            public Type HandleType { get; set; }

            public void OnEvent(Engine engine, EncounterEvent arg)
            {
                var set = arg.Set;
                var battleState = engine.State.Get<BattleState>();
                battleState.LootData = GetLootData(set);
            }

            public bool IsOnce { get; set; }

            public bool IsAlive { get; set; } = true;

            public int Order { get; set; }
        }

        private readonly Engine _engine;

        public LootSystem(Engine engine)
        {
            _engine = engine;
        }

        public void OnInitial(Engine engine)
        {
            engine.RegisterEvent(new SetBattleLootHandler());
        }

        public void Process(ulong frame)
        {
            var battleState = _engine.State.Get<BattleState>();
            if (battleState.StateMode != BattleStateMode.Loot)
            {
                return;
            }
            var playerState = _engine.State.Get<PlayerState>();
            var lootData = battleState.LootData;
            playerState.PlayerInfo.Exp += lootData.Exp;
            playerState.PlayerInfo.Gold += lootData.Gold;
            List<Item> loop = lootData.Item?.Where(e => Rand.Bool(e.Rate)).Select(e => GenerateItem(e.Id)).ToList();
            Logger.Verbose("Loot", $"Exp: {lootData.Exp}, Gold: {lootData.Gold}, Items: {string.Join("; ", loop.Select(e => $"{e.Name}/{e.Id}"))}");
            var bagState = _engine.State.Get<BagState>();
            foreach (var item in loop)
            {
                bagState.Add(item);
            }
            playerState.ShouldUpdate = true;
            battleState.StateMode = BattleStateMode.Encounter;
        }

        private Item GenerateItem(string itemId)
        {
            if (Config<ItemData>.TryGetData(itemId, out var data))
            {
                return new Item(data)
                {
                    Id = Guid.NewGuid().ToString("N")
                };
            }
            return null;
        }
    }
}