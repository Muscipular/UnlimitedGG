using System;
using System.Collections.Generic;
using System.Text;
using FSMSharp;
using MonoGame.Extended.Input.InputListeners;

namespace UGG.Core.Component
{
    interface IStateComponent<T>
    {
        T State { get; }
    }

    interface IClickable
    {
        bool OnClicked(MouseButton button);

        bool OnDoubleClicked(MouseButton button);

        event EventHandler<MouseButton> Clicked;

        event EventHandler<MouseButton> DoubleClicked;
    }
}