using System;

namespace GG.CoreEngine.Data.Buffers
{
    enum BufferType
    {
        Damage,

        Health,

        State,

        None,
    }

    enum DurationMode
    {
        Turn,

        Frame,

        Count,
    }

    [Flags]
    enum BufferCategory
    {
    }

    internal interface IBuffer
    {
        string Name { get; set; }

        string Description { get; set; }

        int Duration { get; set; }

        int MaxStack { get; set; }

        DurationMode DurationMode { get; set; }

        int Order { get; set; }

        BufferCategory Category { get; set; }

        BufferType Type { get; set; }
    }

    abstract class Buffer : IBuffer
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int MaxStack { get; set; } = 1;

        public DurationMode DurationMode { get; set; }

        public int Order { get; set; }

        public BufferCategory Category { get; set; }

        public BufferType Type { get; set; }
    }

    class HealthBuffer : Buffer
    {
        public int Health { get; set; }
    }

    class DamageBuffer : Buffer
    {
        public int Damage { get; set; }
    }
}