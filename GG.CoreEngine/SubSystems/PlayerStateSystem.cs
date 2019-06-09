using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.States;

namespace GG.CoreEngine.SubSystems
{
    class PlayerStateSystem : ISubSystem
    {
        private readonly Engine _engine;

        public PlayerStateSystem(Engine engine)
        {
            _engine = engine;
        }

        public void Process(ulong frame)
        {
            var playerState = _engine.State.Get<PlayerState>();
            if (!playerState.ShouldUpdate)
            {
                return;
            }
            CheckLevelUp(playerState);
            playerState.ShouldUpdate = false;
        }

        private static void CheckLevelUp(PlayerState playerState)
        {
            if (playerState.Exp < playerState.PlayerEntity.Level * 5)
            {
                return;
            }
            playerState.Exp -= playerState.PlayerEntity.Level * 5;
            playerState.PlayerEntity.Level += 1;
            playerState.PlayerEntity.Stats += new Stats()
            {
                Attack = 1, 
                Speed = 2,
                MaxHP = 3,
            };
        }
    }
}