using System;
using System.Collections.Generic;
using System.Linq;

namespace GG.CoreEngine.Data.Skills
{
    interface IDurableEffect
    {
        int Turn { get; }

        int TurnLeft { get; }
    }
}