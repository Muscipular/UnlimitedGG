using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.States;
using GG.CoreEngine.SubSystems.Encounter;
using GG.CoreEngine.Utility;

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
            
            player.Populate(playerState.PlayerInfo);
            player.Stats += playerState.PlayerInfo.Head?.Stats;
            player.Stats += playerState.PlayerInfo.Body?.Stats;
            player.Stats += playerState.PlayerInfo.MainHand?.Stats;
            player.Stats += playerState.PlayerInfo.OffHand?.Stats;
            player.Stats += playerState.PlayerInfo.Foot?.Stats;
            player.Stats += playerState.PlayerInfo.Necklace?.Stats;
            player.Stats += playerState.PlayerInfo.Ring1?.Stats;
            player.Stats += playerState.PlayerInfo.Ring2?.Stats;
            
            foreach (var entity in battleState.PlayerTeam)
            {
                entity.ApplyStats();
                entity.HP = entity.MaxHP;
                entity.FrameToAction = BattleSystem.CalcFrameToAction(entity);
            }
            battleState.EnemyTeam.Clear();
            battleState.EnemyTeam.AddRange(arg.EnemyTeam);
            foreach (var entity in battleState.EnemyTeam)
            {
                entity.ApplyStats();
                entity.HP = player.MaxHP;
                entity.FrameToAction = BattleSystem.CalcFrameToAction(entity);
            }
            battleState.StateMode = BattleStateMode.InBattle;
            battleState.WaitFrame = 60;
        }

        public bool IsOnce { get; set; }

        public bool IsAlive { get; set; } = true;

        public int Order => 1;
    }
}