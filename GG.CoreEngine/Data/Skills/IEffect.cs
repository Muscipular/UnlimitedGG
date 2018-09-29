using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Skills
{
    interface IEffect
    {
        string Description { get; }

        string Name { get; }

        EffectType Type { get; }

        int Index { get; }
    }
}