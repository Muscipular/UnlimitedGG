using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine
{
    internal class CommandScheduler
    {
        private readonly Engine _engine;

        private SortedList<ulong, ICommand> Schedules = new SortedList<ulong, ICommand>();

        public CommandScheduler(Engine engine)
        {
            _engine = engine;
        }

        private uint lastIndex = 0;

        public void ScheduleCommand(ICommand command, uint delay)
        {
            Schedules.Add(((ulong)delay << 32) | lastIndex++, command);
        }

        public void Process(ulong frame)
        {
            while (Schedules.Count > 0)
            {
                var (t, c) = Schedules.FirstOrDefault();
                if ((t >> 32) > frame)
                {
                    break;
                }
                c.Execute(_engine);
                Schedules.RemoveAt(0);
            }
        }
    }
}