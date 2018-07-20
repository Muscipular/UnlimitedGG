using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SharpFont;
using TestGame;

namespace UGG.Core.Component
{
    internal abstract class UIBase : IDisposable, IDrawable
    {
        public Rectangle Rectangle;

        public Rectangle RectangleAbs;

        public UIContainerBase Parent;

        public SpriteBatch SpriteBatch;

        protected UIBase(SpriteBatch spriteBatch, Rectangle rectangle)
        {
            SpriteBatch = spriteBatch;
            Rectangle = rectangle;
            RectangleAbs = rectangle;
        }

        public int DrawOrder { get; set; }

        public bool Visible { get; set; } = true;

        public virtual void Attach(UIContainerBase parent)
        {
            Parent = parent;
            RectangleAbs.Offset(parent.ChildArea.Location);
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
    }

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

    class TextComponent : UIBase
    {
        public string Text;

        public Face FontFace;

        public Color Color;

        public TextComponent(SpriteBatch spriteBatch, string text, Color color, Face fontFace, Point position) : this(spriteBatch, text, color, fontFace, new Rectangle(position, new Point(-1, -1)))
        {
        }

        public TextComponent(SpriteBatch spriteBatch, string text, Color color, Face fontFace, Rectangle rectangle) : base(spriteBatch, rectangle)
        {
            Text = text;
            FontFace = fontFace;
            Color = color;
        }

        public override void Draw(GameTime time)
        {
            int? width = Parent?.ChildArea.Width;
            int? height = Parent?.ChildArea.Height;
            if (RectangleAbs.Width > 0)
            {
                width = Rectangle.Width;
            }
            if (width.HasValue)
            {
                width -= Rectangle.X;
            }
            if (RectangleAbs.Height > 0)
            {
                height = Rectangle.Height;
            }
            if (height.HasValue)
            {
                height -= Rectangle.Y;
            }
            SpriteBatch.DrawStringEx(Text, FontFace, Color, RectangleAbs.X, RectangleAbs.Y, width, height);
        }
    }
}