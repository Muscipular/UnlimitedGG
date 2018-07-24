using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UGG.Core.Graphics;

namespace UGG.Core.Component.UI
{
    class Panel : UIContainerBase
    {
        public BorderDefine? Border;

        public IDrawBrush Bg;

        public Panel(SpriteBatch batch, Rectangle rectangle, IDrawBrush background, BorderDefine? border = null) : base(batch, rectangle)
        {
            Bg = background;
            Border = border;
        }

        public override Rectangle ChildArea
        {
            get
            {
                if (Border.HasValue)
                {
                    var width = Border.Value.Width;
                    return new Rectangle(RectangleAbs.X + width, RectangleAbs.Y + width, RectangleAbs.Width - width * 2, RectangleAbs.Height - width * 2);
                }
                return RectangleAbs;
            }
        }

        public override void Draw(GameTime time)
        {
            var rectangleAbs = RectangleAbs;
            if (Bg!=null && Bg.Visible)
            {
                Bg.Draw(SpriteBatch, rectangleAbs);
            }
            if (Border.HasValue)
            {
                SpriteBatch.DrawRectangle(rectangleAbs, Border.Value.Color, Border.Value.Width);
            }
            base.Draw(time);
        }

        public override void Dispose()
        {
            (Bg as IDisposable)?.Dispose();
        }
    }
}