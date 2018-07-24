using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;

namespace UGG.Core.Component.UI
{
    abstract class ButtonBase : UIBase, IStateComponent<ButtonState>, IClickable
    {
        private ButtonState state;

        protected ButtonBase(SpriteBatch spriteBatch, Rectangle rectangle) : base(spriteBatch, rectangle)
        {
        }

        protected ButtonBase(SpriteBatch spriteBatch, Point location, Point size) : base(spriteBatch, location, size)
        {
        }


        public sealed override void Draw(GameTime time)
        {
            switch (state)
            {
                case ButtonState.Normal:
                    DrawNormal(time);
                    break;
                case ButtonState.Hover:
                    DrawHover(time);
                    break;
                case ButtonState.Pressed:
                    DrawPressed(time);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected abstract void DrawNormal(GameTime time);

        protected virtual void DrawHover(GameTime time)
        {
            DrawNormal(time);
        }

        protected virtual void DrawPressed(GameTime time)
        {
            DrawNormal(time);
        }

        public sealed override void Update(GameTime time)
        {
            state = IsMouseHover ? Mouse.GetState().LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed ? ButtonState.Pressed : ButtonState.Hover : ButtonState.Normal;
            OnUpdate(time);
        }

        public virtual void OnUpdate(GameTime time)
        {
        }

        public ButtonState State => state;

        internal void SetState(ButtonState state) => this.state = state;

        public void OnClicked(MouseButton button)
        {
            if (EnsureButtonClicked(button))
            {
                Clicked?.Invoke(this, button);
            }
        }

        private bool EnsureButtonClicked(MouseButton button)
        {
            return button == MouseButton.Left && IsLeftPressed || button == MouseButton.Right && IsRightPressed;
        }

        public void OnDoubleClicked(MouseButton button)
        {
            if (EnsureButtonClicked(button))
            {
                DoubleClicked?.Invoke(this, button);
            }
        }

        public event EventHandler<MouseButton> Clicked;

        public event EventHandler<MouseButton> DoubleClicked;
    }
}