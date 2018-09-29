using GG.CoreEngine.Data.Skills;

namespace GG.CoreEngine.Data
{
    interface IEntity
    {
        int Attack { get; set; }

        int AttackDelta { get; set; }

        int Defence { get; set; }

        uint BaseActionFrame { get; set; }

        uint FrameToAction { get; set; }

        int HP { get; set; }

        int Level { get; set; }

        int MaxHP { get; set; }

        string Name { get; set; }

        int Speed { get; set; }

        int ReduceDamage { get; set; }
    }
}