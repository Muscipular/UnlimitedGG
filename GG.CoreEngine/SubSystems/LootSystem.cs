using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;
using GG.CoreEngine.States;
using GG.CoreEngine.Utility;

namespace GG.CoreEngine.SubSystems
{
    class LootSystem : ISubSystem
    {
        private readonly Engine _engine;

        public LootSystem(Engine engine)
        {
            _engine = engine;
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
            if (lootData.Item?.Length > 0)
            {
                foreach (var item in lootData.Item)
                {
                    if (Rand.Bool(item.Rate))
                    {
                        var generateItem = GenerateItem(item.Id);
                        if (generateItem != null)
                        {
                            playerState.Bag.Add(generateItem);
                        }
                    }
                }
            }
            playerState.ShouldUpdate = true;
            battleState.StateMode = BattleStateMode.Encounter;
        }

        private Item GenerateItem(string itemId)
        {
            if (Config<ItemData>.TryGetData(itemId, out var data))
            {
                return new Item(data);
            }
            return null;
        }
    }
}