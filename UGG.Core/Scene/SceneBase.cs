using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.ViewportAdapters;
using UGG.Core.Component;
using UGG.Core.Utilities.Platform;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace UGG.Core.Scene
{
    abstract class SceneBase
    {
        protected readonly SpriteBatch spriteBatch;

        public List<UIBase> Backgroup;

        public List<UIBase> Panel;

        public List<UIBase> Pop;

        private readonly GoodGameCore game;

        private readonly MouseListener listener;

        protected SceneBase(GoodGameCore game)
        {
            this.game = game;
            spriteBatch = game.spriteBatch;
            Backgroup = new List<UIBase>();
            Panel = new List<UIBase>();
            Pop = new List<UIBase>();
            listener = new MouseListener(new DefaultViewportAdapter(game.GraphicsDevice));
            listener.MouseClicked += this.MouseClicked;
            listener.MouseDoubleClicked += this.MouseDoubleClicked;
            listener.MouseDown += this.MouseButtonStateChange;
            listener.MouseUp += this.MouseButtonStateChange;
        }

        private void MouseButtonStateChange(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButton.Left)
            {
                currentHover.IsLeftPressed = e.CurrentState.LeftButton == ButtonState.Pressed;
            }

            if (e.Button == MouseButton.Right)
            {
                currentHover.IsRightPressed = e.CurrentState.RightButton == ButtonState.Pressed;
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

        public virtual void Update(GameTime time)
        {
            bool hitHandle = false;
            var target = currentHover;
            var state = Mouse.GetState();
            for (var i = 0; i < Pop.Count && !hitHandle; i++)
            {
                var uiBase = Pop[i];
                uiBase.DoHitTest(ref state, ref hitHandle, ref target);
            }

            if (!hitHandle)
            {
                for (var i = 0; i < Panel.Count && !hitHandle; i++)
                {
                    var uiBase = Panel[i];
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
            listener.Update(time);

            for (var i = 0; i < Pop.Count; i++)
            {
                var uiBase = Pop[i];
                uiBase.Update(time);
            }

            for (var i = 0; i < Panel.Count; i++)
            {
                var uiBase = Panel[i];
                uiBase.Update(time);
            }

            for (var i = 0; i < Backgroup.Count; i++)
            {
                Backgroup[i].Update(time);
            }
        }

        public virtual void Draw(GameTime time)
        {
            spriteBatch.Begin();
            for (var i = 0; i < Backgroup.Count; i++)
            {
                Backgroup[i].Draw(time);
            }

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.BackToFront);
            for (var i = 0; i < Panel.Count; i++)
            {
                Panel[i].Draw(time);
            }

            spriteBatch.End();
            for (var i = 0; i < Pop.Count; i++)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront);
                Pop[i].Draw(time);
                spriteBatch.End();
            }
        }

        public virtual void OnEnter(object arg)
        {
        }

        public virtual void OnLeave(object arg)
        {
        }
    }
}