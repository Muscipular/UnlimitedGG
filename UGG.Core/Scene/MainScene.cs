using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UGG.Core.Component;
using UGG.Core.Component.GameUI.Panels;
using UGG.Core.Component.UI;
using UGG.Core.Graphics;

namespace UGG.Core.Scene
{
    class MainScene : SceneBase
    {
        public MainScene(GoodGameCore game) : base(game)
        {
            var viewport = spriteBatch.GraphicsDevice.Viewport;
            //var normal = TextButton.DefaultStyle.Override(
            //    bg: new NinePatchTextureBrush(game.Content.Load<Texture2D>("tex"), new Rectangle(2, 2, 2, 2), Color.White, new Rectangle(0, 0, 6, 6)),
            //    border: BorderDefine.None,
            //    padding: new Vector4(10, 10, 10, 10),
            //    color: Color.Black
            //);
            //var button = new TextButton(spriteBatch, new Point(0, 0), new Point(100, 32), "啊收到了吗", normal, normal.Override(
            //    bg: new NinePatchTextureBrush(game.Content.Load<Texture2D>("tex"), new Rectangle(2, 2, 2, 2), Color.Red, new Rectangle(0, 0, 6, 6))
            //    ), 
            //    normal.Override(
            //    bg: new NinePatchTextureBrush(game.Content.Load<Texture2D>("tex"), new Rectangle(2, 2, 2, 2), Color.Yellow, new Rectangle(0, 0, 6, 6))
            //    ));
            //var button2 = new TextButton(spriteBatch, new Point(0, 32), new Point(100, 32), "AAAAA", TextButton.DefaultStyle.Override(border: BorderDefine.None));
            //var p = new TooltipComponent(spriteBatch, this, button2, new Panel(spriteBatch, new Rectangle(0, 0, 100, 50), new ColorBrush(Color.Black.FadeTo(0.5f))), TooltipComponent.PosistionMode.Parent, new Point(1, 10));
            //this.Panel.Add(button);
            //this.Panel.Add(p);
            this.Panel.Add(new InfoPanel(game.spriteBatch, new Rectangle(2, 2, 350, 200)));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}