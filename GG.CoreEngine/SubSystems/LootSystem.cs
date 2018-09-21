using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.States;

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
            playerState.PlayerEntity.Exp += lootData.Exp;
            playerState.PlayerEntity.Gold += lootData.Gold;
            CheckLevelUp(playerState);
            battleState.StateMode = BattleStateMode.Encounter;
        }

        private static void CheckLevelUp(PlayerState playerState)
        {
            if (playerState.PlayerEntity.Exp < playerState.PlayerEntity.Level * 5)
            {
                return;
            }
            playerState.PlayerEntity.Exp -= playerState.PlayerEntity.Level * 5;
            playerState.PlayerEntity.Level += 1;
            playerState.PlayerEntity.Attack += 1;
            playerState.PlayerEntity.Speed += 2;
            playerState.PlayerEntity.MaxHP += 3;
        }
    }
}