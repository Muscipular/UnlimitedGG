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
using UGG.Core.Scene;
using UGG.Core.Utilities;
using UGG.Core.Utilities.Platform;
using ButtonState = UGG.Core.Component.ButtonState;

//[assembly: InternalsVisibleTo("UGG.Test")]

namespace UGG
{
    public class GoodGameCore : Game
    {
        internal GraphicsDeviceManager graphics;

        internal SpriteBatch spriteBatch;

        private InputListenerComponent _inputListenerComponent;

        internal static GoodGameCore Instance = null;

        public GoodGameCore()
        {
            Instance = this;
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
            if (Scene == null)
            {
                SwitchToScene(new MainScene(this));
            }
            _inputListenerComponent.Update(gameTime);
            Scene?.Update(gameTime);
            base.Update(gameTime);
        }

        private void KeyReleased(object sender, KeyboardEventArgs e)
        {
            if (e.Key == Keys.Q && (e.Modifiers & KeyboardModifiers.Alt) == KeyboardModifiers.Alt)
            {
                Exit();
            }
        }

        private SceneBase Scene;

        internal void SwitchToScene(SceneBase scene, object arg = null)
        {
            Scene?.OnLeave(arg);
            Scene = scene;
            scene?.OnEnter(arg);
        }


        protected override void Draw(GameTime gameTime)
        {
            Mouse.SetCursor(MouseCursor.Arrow);
            GraphicsDevice.Clear(C.Parse("#054"));
            Scene?.Draw(gameTime);
            base.Draw(gameTime);
            Window.Title = $"GG({Services.GetService<IPlatformTool>().RendererType}) FPS:{(1 / gameTime.GetElapsedSeconds()):0} Draw:{GraphicsDevice.Metrics.DrawCount} Primitive:{GraphicsDevice.Metrics.PrimitiveCount} Texture:{GraphicsDevice.Metrics.TextureCount} Target:{GraphicsDevice.Metrics.TargetCount} Sprite:{GraphicsDevice.Metrics.SpriteCount}";
        }
    }
}