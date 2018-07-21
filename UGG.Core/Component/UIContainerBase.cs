using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace UGG.Core.Component
{
    abstract class UIContainerBase : UIBase
    {
        public virtual Rectangle ChildArea => RectangleAbs;

        protected List<UIBase> Children;

        protected UIContainerBase(SpriteBatch spriteBatch, Rectangle rectangle) : base(spriteBatch, rectangle)
        {
            Children = new List<UIBase>();
        }

        public IReadOnlyList<UIBase> GetChildren() => Children;

        public virtual void AddChild(UIBase child)
        {
            if (child.Parent != null)
            {
                throw new ArgumentException();
            }
            Children.Add(child);
            child.Attach(this);
        }

        public virtual void RemoveChild(UIBase child)
        {
            if (Children.Remove(child))
            {
                child.Detach();
            }
        }

        public override void Draw(GameTime time)
        {
            foreach (var child in Children)
            {
                child.Draw(time);
            }
        }
    }
}