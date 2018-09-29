using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Skills
{
    internal interface ISkill
    {
        SkillType SkillType { get; set; }

        string Name { get; set; }

        string Description { get; set; }

        SkillTarget Target { get; set; }

        int TargetCount { get; set; }

        void DoSkill(IEntity owner, IEntity ownerTeam, IEntity caster, IEntity casterTeam, IEntity[] target, IEntity[] targetTeam);
    }

    abstract class SkillBase : ISkill
    {
        public SkillType SkillType { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public SkillTarget Target { get; set; }

        public int TargetCount { get; set; } = 1;

        public abstract void DoSkill(IEntity owner, IEntity ownerTeam, IEntity caster, IEntity casterTeam, IEntity[] target, IEntity[] targetTeam);
    }

    class Attack : SkillBase
    {
        public override void DoSkill(IEntity owner, IEntity ownerTeam, IEntity caster, IEntity casterTeam, IEntity[] target, IEntity[] targetTeam)
        {
            foreach (var entity in target)
            {
                
            }
        }
    }

    enum SkillTarget
    {
        Enemy,

        SelfTeam,
    }

    enum SkillType
    {
        Active,

        Passive,

        Aura,
    }
}