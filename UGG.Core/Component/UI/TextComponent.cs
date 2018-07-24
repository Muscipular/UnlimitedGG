using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpFont;
using UGG.Core.Graphics;

namespace UGG.Core.Component.UI
{
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