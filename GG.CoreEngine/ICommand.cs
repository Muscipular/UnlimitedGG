using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine
{
    public interface ICommand
    {
        void Execute(Engine engine);
    }
}