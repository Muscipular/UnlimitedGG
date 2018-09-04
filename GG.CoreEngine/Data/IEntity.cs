namespace GG.CoreEngine.Data
{
    interface IEntity
    {
        int Attack { get; set; }
        int AttackDelta { get; set; }
        uint BaseAttackFrame { get; set; }
        uint FrameToAttack { get; set; }
        int HP { get; set; }
        int Level { get; set; }
        int MaxHP { get; set; }
        string Name { get; set; }
        int Speed { get; set; }
    }
}