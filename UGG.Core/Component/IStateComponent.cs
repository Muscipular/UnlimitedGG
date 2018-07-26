using System;
using System.Collections.Generic;
using System.Text;
using FSMSharp;

namespace UGG.Core.Component
{
    interface IStateComponent<T>
    {
        T State { get; }
    }
}