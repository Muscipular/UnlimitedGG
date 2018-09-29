using System;
using System.Collections.Generic;
using System.Text;
using GG.CoreEngine.Data;
using GG.CoreEngine.Data.Skills;

namespace GG.CoreEngine.SubSystems.Battle
{
    class DamageEvent
    {
        public int Damage { get; set; }

        public ISkill Skill { get; set; }

        public IEntity Form { get; set; }

        public IEntity To { get; set; }
    }
}