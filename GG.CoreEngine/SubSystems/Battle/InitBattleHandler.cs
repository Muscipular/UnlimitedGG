using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.States;
using GG.CoreEngine.SubSystems.Encounter;

namespace GG.CoreEngine.SubSystems.Battle
{
    class InitBattleHandler : IEventHandler<EncounterEvent>
    {
        public Type HandleType { get; set; }

        public void OnEvent(Engine engine, EncounterEvent arg)
        {
            var battleState = engine.State.Get<BattleState>();
            var playerState = engine.State.Get<PlayerState>();
            var player = playerState.PlayerEntity;
            battleState.PlayerTeam.Clear();
            battleState.PlayerTeam.Add(player);
            battleState.WaitFrame = 60;
            foreach (var entity in battleState.PlayerTeam)
            {
                player.HP = player.MaxHP;
                entity.FrameToAction = BattleSystem.CalcFrameToAction(entity);
            }
            battleState.EnemyTeam.Clear();
            battleState.EnemyTeam.AddRange(arg.EnemyTeam);
            foreach (var entity in battleState.EnemyTeam)
            {
                entity.FrameToAction = BattleSystem.CalcFrameToAction(entity);
            }
            battleState.StateMode = BattleStateMode.InBattle;
        }

        public bool IsOnce { get; set; }

        public bool IsAlive { get; set; }

        public int Order => 1;
    }
}