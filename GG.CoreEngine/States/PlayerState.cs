using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;

namespace GG.CoreEngine.States
{
    class PlayerState : IState
    {
        public string Name { get; } = typeof(PlayerState).Name;

        public Player PlayerInfo { get; set; } = new Player();

        public bool ShouldEncounter { get; set; } = true;
    }
}