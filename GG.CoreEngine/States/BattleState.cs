using System;
using System.Collections.Generic;
using System.Text;
using GG.CoreEngine.Data;

namespace GG.CoreEngine.States
{
    class BattleState : IState
    {
        public string Name { get; } = typeof(BattleState).Name;

        public BattleStateMode StateMode { get; set; } = BattleStateMode.Encounter;

        public List<BaseEntity> PlayerTeam { get; set; } = new List<BaseEntity>();

        public List<BaseEntity> EnemyTeam { get; set; } = new List<BaseEntity>();

        public int WaitFrame { get; set; }
    }
}