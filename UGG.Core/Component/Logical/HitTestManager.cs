using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.ViewportAdapters;
using UGG.Core.Scene;

namespace UGG.Core.Component.Logical
{
    class HitTestManager : IUpdate
    {
        private readonly GoodGameCore game;

        private readonly SceneBase scene;

        private readonly MouseListener listener;

        /// <summary>
        ///   初始化 <see cref="T:System.Object" /> 类的新实例。
        /// </summary>
        public HitTestManager(GoodGameCore game, SceneBase scene)
        {
            this.game = game;
            this.scene = scene;
            listener = new MouseListener(new DefaultViewportAdapter(game.GraphicsDevice));
            listener.MouseClicked += this.MouseClicked;
            listener.MouseDoubleClicked += this.MouseDoubleClicked;
            listener.MouseDown += this.MouseButtonStateChange;
            listener.MouseUp += this.MouseButtonStateChange;
        }

        private void MouseButtonStateChange(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButton.Left && currentHover != null)
            {
                currentHover.IsLeftPressed = e.CurrentState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
            }

            if (e.Button == MouseButton.Right && currentHover != null)
            {
                currentHover.IsRightPressed = e.CurrentState.RightButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed;
            }
        }

        private void MouseClicked(object sender, MouseEventArgs e)
        {
            if (currentHover is IClickable clickable)
            {
                clickable.OnClicked(e.Button);
            }
        }

        private void MouseDoubleClicked(object sender, MouseEventArgs e)
        {
            if (currentHover is IClickable clickable)
            {
                clickable.OnClicked(e.Button);
            }
        }

        private UIBase currentHover;

        public void Update(GameTime gameTime)
        {
            bool hitHandle = false;
            UIBase target = null;
            var state = Mouse.GetState();
            var list = scene.Pop;
            var count = list.Count;
            for (var i = 0; i < count && !hitHandle; i++)
            {
                var uiBase = list[i];
                uiBase.DoHitTest(ref state, ref hitHandle, ref target);
            }

            if (!hitHandle)
            {
                list = scene.Panel;
                count = scene.Panel.Count;
                for (var i = 0; i < count && !hitHandle; i++)
                {
                    var uiBase = list[i];
                    uiBase.DoHitTest(ref state, ref hitHandle, ref target);
                }
            }


            if (target != currentHover && currentHover != null)
            {
                currentHover.IsMouseHover = false;
                currentHover.IsLeftPressed = false;
                currentHover.IsRightPressed = false;
            }

            currentHover = target;
            listener.Update(gameTime);
        }
    }
}