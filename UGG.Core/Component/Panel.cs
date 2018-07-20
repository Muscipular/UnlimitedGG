using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace UGG.Core.Component
{
    class Panel : UIContainerBase
    {
        public BorderDefine? Border;

        public Color? BgColor;

        public IDrawable BgDrawable;

        public Panel(SpriteBatch batch, Rectangle rectangle, Color background, BorderDefine? border = null) : base(batch, rectangle)
        {
            BgColor = background;
            Border = border;
        }

        public Panel(SpriteBatch batch, Rectangle rectangle, IDrawable background, BorderDefine? border = null) : base(batch, rectangle)
        {
            BgDrawable = background;
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
            var rectangleF = RectangleAbs;
            if (BgColor.HasValue)
            {
                SpriteBatch.FillRectangle(rectangleF, BgColor.Value);
            }
            else if (BgDrawable?.Visible == true)
            {
                BgDrawable.Draw(time);
            }
            if (Border.HasValue)
            {
                SpriteBatch.DrawRectangle(rectangleF, Border.Value.Color, Border.Value.Width);
            }
            base.Draw(time);
        }

        public override void Dispose()
        {
            (BgDrawable as IDisposable)?.Dispose();
        }
    }
}