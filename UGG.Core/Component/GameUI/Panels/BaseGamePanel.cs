using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UGG.Core.Component.UI;
using UGG.Core.Graphics;

namespace UGG.Core.Component.GameUI.Panels
{
    class BaseGamePanel : Panel
    {
        public BaseGamePanel(SpriteBatch batch, Rectangle rectangle)
            : base(batch, rectangle,
                   new NinePatchTextureBrush(
                       GoodGameCore.Instance.Content.Load<Texture2D>("tex"),
                       new Rectangle(5, 5, 2, 2),
                       Color.LightGray,
                       new Rectangle(0, 6, 12, 12))
                   , null)
        {

        }
    }

    class InfoPanel : BaseGamePanel
    {
        public InfoPanel(SpriteBatch batch, Rectangle rectangle) : base(batch, rectangle)
        {
            this.AddChild(new TextComponent(batch, "名字:", Color.Black, FontUtil.RequestFace(32), new Rectangle(8, 8, 40, 80)));
            this.AddChild(new TextComponent(batch, "撒的:", Color.Black, FontUtil.FontDefault, new Rectangle(40, 40, 40, 20)));
        }
    }
}
