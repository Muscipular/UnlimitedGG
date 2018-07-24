using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;

namespace UGG.Core.Component.UI
{
    internal abstract class UIBase : IDisposable, IDrawable
    {
        public bool HitTest = true;

        public Rectangle Rectangle;

        public Rectangle RectangleAbs;

        public UIContainerBase Parent;

        public SpriteBatch SpriteBatch;

        public bool IsMouseHover;

        public bool IsLeftPressed;

        public bool IsRightPressed;

        protected UIBase(SpriteBatch spriteBatch, Rectangle rectangle)
        {
            SpriteBatch = spriteBatch;
            Rectangle = rectangle;
            RectangleAbs = rectangle;
        }

        protected UIBase(SpriteBatch spriteBatch, Point location, Point size) : this(spriteBatch, new Rectangle(location, size))
        {
        }

        public float Depth = 1;

        public int DrawOrder { get; set; }

        public bool Visible { get; set; } = true;

        public virtual void Attach(UIContainerBase parent)
        {
            Parent = parent;
            RectangleAbs.Offset(parent.ChildArea.Location);
            Depth = parent.Depth * 100 + 1;
        }

        public virtual void Detach()
        {
            RectangleAbs = Rectangle;
            Parent = null;
        }

        public virtual void Dispose()
        {
        }

        public virtual void Draw(GameTime time)
        {
        }

        public event EventHandler<EventArgs> DrawOrderChanged;

        public event EventHandler<EventArgs> VisibleChanged;

        public virtual void Update(GameTime time)
        {
        }

        public virtual bool DoHitTest(ref MouseState state, ref bool handled, ref UIBase target)
        {
            if (HitTest)
            {
                if (RectangleAbs.Contains(state.Position))
                {
                    IsMouseHover = true;
                    target = this;
                    handled = true;
                    return true;
                }

                IsMouseHover = false;
            }

            return false;
        }
    }
}