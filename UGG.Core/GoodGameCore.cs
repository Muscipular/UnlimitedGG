using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Input.InputListeners;
using SharpFont;
using UGG.Core.Graphics;
using UGG.Core.Component;
using UGG.Core.Utilities;
using UGG.Core.Utilities.Platform;
using ButtonState = UGG.Core.Component.ButtonState;

//[assembly: InternalsVisibleTo("UGG.Test")]

namespace UGG
{
    public class GoodGameCore : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;

        private InputListenerComponent _inputListenerComponent;


        public GoodGameCore()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            FontUtil.Init(GraphicsDevice);
            _inputListenerComponent = new InputListenerComponent(this);
            var item = new KeyboardListener();
            item.KeyReleased += KeyReleased;
            _inputListenerComponent.Listeners.Add(item);
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _inputListenerComponent.Update(gameTime);
            base.Update(gameTime);
        }

        private void KeyReleased(object sender, KeyboardEventArgs e)
        {
            if (e.Key == Keys.Q && (e.Modifiers & KeyboardModifiers.Alt) == KeyboardModifiers.Alt)
            {
                Exit();
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            Mouse.SetCursor(MouseCursor.Arrow);
            GraphicsDevice.Clear(C.Parse("#054"));
            spriteBatch.Begin();
            var p2 = new Panel(spriteBatch, new Rectangle(0, 0, 300, 300), Color.Aqua, new BorderDefine(1, Color.Black));
            p2.Depth = 1;
            p2.AddChild(new TextComponent(spriteBatch, "asdasdASDASD134132das_c.:;,?!啊\n啊啊啊啊撒旦鬼地方鬼地方广泛的啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊啊^", Color.Red, FontUtil.FontDefault, Point.Zero));
            p2.Draw(gameTime);
            var panel = new Panel(spriteBatch, new Rectangle(10, 50, 300, 300), Color.Aqua, new BorderDefine(1, Color.Black));
            p2.Depth = 2;
            panel.AddChild(new TextComponent(spriteBatch, "asdsdASD啊实打实cda12313F:ASD<?123213", Color.Blue, FontUtil.RequestFace(16), new Point(20, 20)));
            var textButton = new TextButton(spriteBatch, new Point(100, 100), new Point(100, 32), "AAAA");
            panel.AddChild(textButton);
            textButton = new TextButton(spriteBatch, new Point(100, 140), new Point(100, 32), "AAAA");
            textButton.SetState(ButtonState.Hover);
            panel.AddChild(textButton);
            textButton = new TextButton(spriteBatch, new Point(100, 180), new Point(100, 32), "AAAA");
            textButton.SetState(ButtonState.Pressed);
            panel.AddChild(textButton);
            panel.Draw(gameTime);

            spriteBatch.End();

            // spriteBatch.Begin(SpriteSortMode.BackToFront);
            // var s = "啊实打实ABCDabcd_;'../,./\\\"|[]{}-=_+旦鬼地方鬼地方广泛\t\n\basdsadasdsad31123213213jkhjiortwencFGHrty";
            // spriteBatch.DrawStringEx(s, FontUtil.FontDefault, Color.Red, 0, 400, graphics.GraphicsDevice.Viewport.Width);
            // spriteBatch.End();
            base.Draw(gameTime);
            Window.Title = $"GG({SimpleIoc.Instance.GetService<IPlatformTool>().RendererType}) FPS:{(1 / gameTime.GetElapsedSeconds()):0} Draw:{GraphicsDevice.Metrics.DrawCount} Primitive:{GraphicsDevice.Metrics.PrimitiveCount} Texture:{GraphicsDevice.Metrics.TextureCount} Target:{GraphicsDevice.Metrics.TargetCount} Sprite:{GraphicsDevice.Metrics.SpriteCount}";
        }
    }
}