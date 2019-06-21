using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.SubSystems
{
    public interface ISubSystem
    {
        void OnInitial(Engine engine);
        
        void Process(ulong frame);
    }
}