using System;

namespace GG.CoreEngine.Data.Buffers
{
    enum BufferType
    {
        Temp,

        Equip,

        Passive,
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

        bool CanUpdateDuration { get; set; }

        BufferCategory Category { get; set; }

        BufferType Type { get; set; }

        void OnAddBuffer(IEntity entity, Engine engine);

        void OnRemoveBuffer(IEntity entity, Engine engine);
    }

    abstract class Buffer : IBuffer
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Duration { get; set; }

        public int MaxStack { get; set; } = 1;

        public DurationMode DurationMode { get; set; }

        public int Order { get; set; }

        public bool CanUpdateDuration { get; set; }

        public BufferCategory Category { get; set; }

        public BufferType Type { get; set; }

        public virtual void OnAddBuffer(IEntity entity, Engine engine)
        {
        }

        public virtual void OnRemoveBuffer(IEntity entity, Engine engine)
        {
        }
    }

    class StateBuffer : Buffer
    {
        
    }
}