using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;

namespace GG.CoreEngine.States
{
    class PlayerState : IState
    {
        public string Name { get; } = typeof(PlayerState).Name;

        public PlayerEntity PlayerEntity { get; set; } = new PlayerEntity();

        public PlayerInfo PlayerInfo { get; set; } = new PlayerInfo();

        public bool ShouldEncounter { get; set; } = true;

        public bool ShouldUpdate { get; set; } = false;
    }
}