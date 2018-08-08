using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.States;

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
            var player = playerState.PlayerInfo;
            player.HP = player.MaxHP;
            player.FrameToAttack = 0;
            battleState.EnemyTeam.Clear();
            battleState.EnemyTeam.Add(new Enemy());
            battleState.PlayerTeam.Clear();
            battleState.PlayerTeam.Add(player);
            battleState.StateMode = BattleStateMode.InBattle;
            battleState.WaitFrame = 60;
        }
    }
}