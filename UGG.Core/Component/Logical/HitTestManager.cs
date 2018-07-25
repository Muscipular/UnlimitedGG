using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Input.InputListeners;
using MonoGame.Extended.ViewportAdapters;
using UGG.Core.Component.UI;
using UGG.Core.Scene;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace UGG.Core.Component.Logical
{
    class HitTestManager : IUpdate
    {
        private readonly GoodGameCore game;

        private readonly SceneBase scene;

        // private readonly MouseListener listener;

        private int PreFrameButtonState;

        private DateTime LastClick = DateTime.MinValue;

        private UIBase LastClickTarget;

        /// <summary>
        ///   初始化 <see cref="T:System.Object" /> 类的新实例。
        /// </summary>
        public HitTestManager(GoodGameCore game, SceneBase scene)
        {
            this.game = game;
            this.scene = scene;
            // listener = new MouseListener(new DefaultViewportAdapter(game.GraphicsDevice));
            // listener.MouseClicked += this.MouseClicked;
            // listener.MouseDoubleClicked += this.MouseDoubleClicked;
            // listener.MouseDown += this.MouseButtonStateChange;
            // listener.MouseUp += this.MouseButtonStateChange;
        }

        private bool MouseClicked(MouseButton button)
        {
            if (currentHover is IClickable clickable)
            {
                var b = clickable.OnClicked(button);
                // currentHover.IsLeftPressed = false;
                // currentHover.IsRightPressed = false;
                return b;
            }
            return false;
        }

        private bool MouseDoubleClicked(MouseButton button)
        {
            if (currentHover is IClickable clickable)
            {
                var b = clickable.OnDoubleClicked(button);
                // if (b)
                // {
                //     currentHover.IsLeftPressed = false;
                //     currentHover.IsRightPressed = false;
                // }
                return b;
            }
            return false;
        }

        private UIBase currentHover;

        public void Update(GameTime gameTime)
        {
            if (!game.IsActive)
            {
                return;
            }
            var state = Mouse.GetState(game.Window);
            CheckHitTest(ref state);

            if (!CheckClick(MouseButton.Left, state.LeftButton))
            {
                CheckClick(MouseButton.Right, state.RightButton);
            }

            if (LastClickTarget != null)
            {
                LastClickTarget.IsLeftPressed = state.LeftButton == ButtonState.Pressed;
                LastClickTarget.IsRightPressed = state.RightButton == ButtonState.Pressed;
            }

            PreFrameButtonState = ToFlag(MouseButton.Left, state.LeftButton) | ToFlag(MouseButton.Right, state.RightButton);
            // listener.Update(gameTime);
        }

        private void CheckHitTest(ref MouseState state)
        {
            bool hitHandle = false;
            UIBase target = null;
            var list = scene.Context;
            var count = list.Count;
            for (var i = 0; i < count && !hitHandle; i++)
            {
                var uiBase = list[i];
                uiBase.DoHitTest(ref state, ref hitHandle, ref target);
            }

            if (!hitHandle)
            {
                list = scene.Pop;
                count = list.Count;
                for (var i = 0; i < count && !hitHandle; i++)
                {
                    var uiBase = list[i];
                    uiBase.DoHitTest(ref state, ref hitHandle, ref target);
                }
            }

            if (!hitHandle)
            {
                list = scene.Panel;
                count = list.Count;
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
        }

        private bool CheckClick(MouseButton button, ButtonState buttonState)
        {
            switch (buttonState)
            {
                case ButtonState.Released:
                    if ((PreFrameButtonState & ToFlag(button, ButtonState.Pressed)) != 0 && currentHover == LastClickTarget && currentHover != null)
                    {
                        var now = DateTime.Now;
                        if ((now - LastClick).TotalMilliseconds < 300)
                        {
                            if (MouseDoubleClicked(button))
                            {
                                LastClick = DateTime.MinValue;
                            }
                            else
                            {
                                MouseClicked(button);
                                LastClick = now;
                            }
                        }
                        else
                        {
                            MouseClicked(button);
                            LastClick = now;
                        }
                        PreFrameButtonState = 0;
                        LastClickTarget.IsLeftPressed = false;
                        LastClickTarget.IsRightPressed = false;
                        LastClickTarget = null;
                        return true;
                    }
                    break;
                case ButtonState.Pressed:
                    if ((PreFrameButtonState & ToFlag(button, ButtonState.Pressed)) == 0)
                    {
                        if (currentHover != LastClickTarget)
                        {
                            if (LastClickTarget != null)
                            {
                                LastClickTarget.IsLeftPressed = false;
                                LastClickTarget.IsRightPressed = false;
                            }
                            LastClickTarget = currentHover;
                        }
                    }
                    break;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int ToFlag(MouseButton button, ButtonState state) => (int)state << ((int)button - 1);
    }
}