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
        void OnClicked(MouseButton button);

        void OnDoubleClicked(MouseButton button);

        event EventHandler<MouseButton> Clicked;

        event EventHandler<MouseButton> DoubleClicked;
    }
}