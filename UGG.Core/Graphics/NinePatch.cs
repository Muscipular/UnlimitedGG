using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UGG.Core.Graphics
{
    static class NinePatch
    {
        public static void DrawNinePatch(this SpriteBatch batch, Texture2D texture, Color color, Rectangle rectangle, Rectangle innerSize, Rectangle? sourceRectangle = null, float depth = 0)
        {
            var source = sourceRectangle ?? new Rectangle(0, 0, texture.Width, texture.Height);
            var rWidth = (source.Width - innerSize.Right);
            var dInnerWidth = rectangle.Width - innerSize.Left - rWidth;
            var bHeight = (source.Height - innerSize.Bottom);
            var dInnerHeight = rectangle.Height - innerSize.Top - bHeight;
            //TL
            batch.Draw(texture,
                new Rectangle(rectangle.Left, rectangle.Top, innerSize.Left, innerSize.Top),
                new Rectangle(source.Left, source.Top, innerSize.Left, innerSize.Top),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //TM
            batch.Draw(texture,
                new Rectangle(innerSize.Left + rectangle.Left, rectangle.Top, dInnerWidth, innerSize.Top),
                new Rectangle(source.Left + innerSize.Left, source.Top, innerSize.Width, innerSize.Top),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //TR
            batch.Draw(texture,
                new Rectangle(innerSize.Left + rectangle.Left + dInnerWidth, rectangle.Top, rWidth, innerSize.Top),
                new Rectangle(source.Left + innerSize.Left + innerSize.Width, source.Top, rWidth, innerSize.Top),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //ML
            batch.Draw(texture,
                new Rectangle(rectangle.Left, rectangle.Top + innerSize.Top, innerSize.Left, dInnerHeight),
                new Rectangle(source.Left, source.Top + innerSize.Top, innerSize.Left, innerSize.Height),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //MM
            batch.Draw(texture,
                new Rectangle(innerSize.Left + rectangle.Left, rectangle.Top + innerSize.Top, dInnerWidth, dInnerHeight),
                new Rectangle(source.Left + innerSize.Left, source.Top + innerSize.Top, innerSize.Width, innerSize.Height),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //MR
            batch.Draw(texture,
                new Rectangle(innerSize.Left + rectangle.Left + dInnerWidth, rectangle.Top + innerSize.Top, rWidth, dInnerHeight),
                new Rectangle(source.Left + innerSize.Left + innerSize.Width, source.Top + innerSize.Top, rWidth, innerSize.Height),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //BL
            batch.Draw(texture,
                new Rectangle(rectangle.Left, rectangle.Top + innerSize.Top + dInnerHeight, innerSize.Left, bHeight),
                new Rectangle(source.Left, source.Top + innerSize.Bottom, innerSize.Left, bHeight),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //BM
            batch.Draw(texture,
                new Rectangle(innerSize.Left + rectangle.Left, rectangle.Top + innerSize.Top + dInnerHeight, dInnerWidth, bHeight),
                new Rectangle(source.Left + innerSize.Left, source.Top + innerSize.Bottom, innerSize.Width, bHeight),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
            //BR
            batch.Draw(texture,
                new Rectangle(innerSize.Left + rectangle.Left + dInnerWidth, rectangle.Top + innerSize.Top + dInnerHeight, rWidth, bHeight),
                new Rectangle(source.Left + innerSize.Left + innerSize.Width, source.Top + innerSize.Bottom, rWidth, bHeight),
                color, 0, Vector2.Zero, SpriteEffects.None, depth
            );
        }
    }
}