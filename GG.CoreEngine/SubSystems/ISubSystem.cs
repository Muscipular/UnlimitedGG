using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.SubSystems
{
    public interface ISubSystem
    {
        void Process(ulong frame);
    }
}