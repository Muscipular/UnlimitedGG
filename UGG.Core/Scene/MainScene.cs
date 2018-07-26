using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UGG.Core.Component;
using UGG.Core.Component.UI;

namespace UGG.Core.Scene
{
    class MainScene : SceneBase
    {
        public MainScene(GoodGameCore game) : base(game)
        {
            var viewport = spriteBatch.GraphicsDevice.Viewport;
            var button = new TextButton(spriteBatch, new Point(viewport.Width / 2 - 50, viewport.Height / 2 - 16), new Point(100, 32), "AAAAA");
            var button2 = new TextButton(spriteBatch, new Point(viewport.Width / 2 - 0, viewport.Height / 2 - 16), new Point(100, 32), "AAAAA");
            var p = new TooltipComponent(spriteBatch, this, button2, new Panel(spriteBatch, new Rectangle(0, 0, 100, 50), new ColorBrush(Color.Black)), TooltipComponent.PosistionMode.Parent, new Point(0, 10));
            this.Panel.Add(button);
            this.Panel.Add(p);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}