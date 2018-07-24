using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace UGG.Core.Component.UI
{
    interface IDrawBrush
    {
        bool Visible { get; }

        void Draw(SpriteBatch batch, Rectangle rectangle, float depth = 0);
    }

    class TextureBrush : IDrawBrush, IDisposable
    {
        public Texture2D Texture;

        public Color Color;

        public Rectangle? SoucreRectangle;

        public TextureBrush(Texture2D texture, Color color) : this(texture, color, null)
        {
        }

        public TextureBrush(Texture2D texture, Color color, Rectangle? soucreRectangle)
        {
            Texture = texture;
            Color = color;
            SoucreRectangle = soucreRectangle;
        }

        public bool Visible => Color.A > 0 && Texture != null && (!SoucreRectangle.HasValue || !SoucreRectangle.Value.IsEmpty);

        public void Draw(SpriteBatch batch, Rectangle rectangle, float depth = 0)
        {
            batch.Draw(Texture, rectangle, SoucreRectangle, Color, 0, Vector2.Zero, SpriteEffects.None, depth);
        }

        public void Dispose()
        {
            Texture?.Dispose();
        }
    }

    class ColorBrush : IDrawBrush
    {
        public Color Color;

        public ColorBrush(Color color)
        {
            Color = color;
        }

        public bool Visible => Color.A > 0;

        public void Draw(SpriteBatch batch, Rectangle rectangle, float depth = 0)
        {
            batch.FillRectangle(rectangle, Color);
        }
    }
}