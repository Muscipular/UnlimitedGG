using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace UGG.Core.Component.UI
{
    abstract class UIContainerBase : UIBase
    {
        public bool ChildHitTest = true;

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

        public override bool DoHitTest(ref MouseState state, ref bool handled, ref UIBase target)
        {
            if (ChildHitTest)
            {
                var count = Children.Count;
                for (int i = count - 1; i >= 0; i--)
                {
                    var child = Children[i];
                    if (child.DoHitTest(ref state, ref handled, ref target) || handled)
                    {
                        handled = true;
                        return false;
                    }
                }
            }

            return base.DoHitTest(ref state, ref handled, ref target);
        }
    }
}