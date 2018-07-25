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
            button.Clicked += this.Button_Clicked;
            // button.DoubleClicked += Button_DoubleClicked;
            this.Panel.Add(button);
            this.Panel.Add(button2);
        }

        private void Button_DoubleClicked(object sender, MonoGame.Extended.Input.InputListeners.MouseButton e)
        {
            (this.Panel[0] as TextButton).Text = (count++).ToString() + "DB";
        }

        private int count;

        private void Button_Clicked(object sender, MonoGame.Extended.Input.InputListeners.MouseButton e)
        {
            (this.Panel[0] as TextButton).Text = (count++).ToString();
        }

        private void StartPressed(object sender, EventArgs e)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}