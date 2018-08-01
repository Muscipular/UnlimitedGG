using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using UGG.Core.Component.Logical;

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

    public interface IUpdate
    {
        void Update(GameTime time);
    }

    internal enum MouseButton
    {
        None,

        Left,

        Right
    }
}