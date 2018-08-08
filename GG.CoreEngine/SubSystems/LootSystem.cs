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
            if (battleState.StateMode == BattleStateMode.Loot)
            {
                var playerState = _engine.State.Get<PlayerState>();
                playerState.PlayerInfo.Exp += battleState.EnemyTeam.Sum(c => c.Level);
                playerState.PlayerInfo.Gold += battleState.EnemyTeam.Sum(c => c.Level) * 2;
                if (playerState.PlayerInfo.Exp >= playerState.PlayerInfo.Level * 5)
                {
                    playerState.PlayerInfo.Exp -= playerState.PlayerInfo.Level * 5;
                    playerState.PlayerInfo.Level += 1;
                    playerState.PlayerInfo.Attack += 1;
                    playerState.PlayerInfo.Speed += 2;
                    playerState.PlayerInfo.MaxHP += 3;
                }
                battleState.StateMode = BattleStateMode.Encounter;
            }
        }
    }
}