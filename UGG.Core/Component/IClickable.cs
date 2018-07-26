using System;
using System.Collections.Generic;
using System.Linq;
using MonoGame.Extended.Input.InputListeners;

namespace UGG.Core.Component
{
    interface IClickable
    {
        bool OnClicked(MouseButton button);

        bool OnDoubleClicked(MouseButton button);

        event EventHandler<MouseButton> Clicked;

        event EventHandler<MouseButton> DoubleClicked;
    }

    interface IHoverable
    {
        bool OnHover();

        event EventHandler Hovered;
    }
}