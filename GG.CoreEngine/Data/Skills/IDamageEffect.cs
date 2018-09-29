using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Skills
{
    interface IDamageEffect : IEffect
    {
        int CalcDamange(IEntity entity);
    }
}