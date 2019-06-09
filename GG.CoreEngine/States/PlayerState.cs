using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;

namespace GG.CoreEngine.States
{
    class PlayerState : IState
    {
        public string Name { get; } = typeof(PlayerState).Name;

        public PlayerEntity PlayerEntity { get; set; } = new PlayerEntity();

        public PlayerInfo PlayerInfo { get; set; }

        public long Gold { get; set; }

        public long Exp { get; set; }

        public bool ShouldEncounter { get; set; } = true;

        public List<Item> Bag { get; set; } = new List<Item>();

        public bool ShouldUpdate { get; set; } = false;
    }
}