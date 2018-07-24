﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UGG.Core.Component;

namespace UGG.Core.Scene
{
    class MainScene : SceneBase
    {
        public MainScene(GoodGameCore game) : base(game)
        {
            var viewport = spriteBatch.GraphicsDevice.Viewport;
            var button = new TextButton(spriteBatch, new Point(viewport.Width / 2 - 50, viewport.Height / 2 - 16), new Point(100, 32), "AAAAA");
            button.Clicked += this.Button_Clicked;
            this.Panel.Add(button);
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