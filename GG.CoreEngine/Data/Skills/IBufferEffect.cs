using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Skills
{
    interface IBufferEffect : IDurableEffect
    {
        void DoBuffer(IEntity entity);
    }
}