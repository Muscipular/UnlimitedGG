using System;
using System.Collections.Generic;
using System.Linq;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Config;

namespace GG.CoreEngine.SubSystems.Encounter
{
    class EncounterEvent : IEvent
    {
        public EncounterSet Set { get; }

        public List<IEntity> EnemyTeam { get; }

        public EncounterEvent(EncounterSet set, List<IEntity> enemyTeam)
        {
            Set = set;
            EnemyTeam = enemyTeam;
        }

        public bool Handled { get; set; }
    }
}