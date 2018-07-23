using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpFont;
using UGG.Core.Graphics;

namespace UGG.Core.Component
{
    abstract class ButtonBase : UIBase, IStateComponent<ButtonState>
    {
        private ButtonState state;

        protected ButtonBase(SpriteBatch spriteBatch, Rectangle rectangle) : base(spriteBatch, rectangle)
        {
        }

        protected ButtonBase(SpriteBatch spriteBatch, Point location, Point size) : base(spriteBatch, location, size)
        {
        }


        public sealed override void Draw(GameTime time)
        {
            switch (state)
            {
                case ButtonState.Normal:
                    DrawNormal(time);
                    break;
                case ButtonState.Hover:
                    DrawHover(time);
                    break;
                case ButtonState.Pressed:
                    DrawPressed(time);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected abstract void DrawNormal(GameTime time);

        protected virtual void DrawHover(GameTime time)
        {
            DrawNormal(time);
        }

        protected virtual void DrawPressed(GameTime time)
        {
            DrawNormal(time);
        }

        public sealed override void Update(GameTime time)
        {
            OnUpdate(time);
        }

        public virtual void OnUpdate(GameTime time)
        {
        }

        public event EventHandler OnPressed;

        public ButtonState State => state;

        internal void SetState(ButtonState state) => this.state = state;

        protected virtual void OnOnPressed()
        {
            OnPressed?.Invoke(this, EventArgs.Empty);
        }
    }

    class TextButton : ButtonBase
    {
        public string Text;

        public static StateStyle DefaultStyle = new StateStyle()
        {
            Color = C.Parse("#000"),
            BgColor = C.Parse("#efefef"),
            Border = new BorderDefine(1, C.Parse("#eee")),
            Texture = null,
        };

        public static StateStyle DefaultHoverStyle = new StateStyle()
        {
            Color = C.Parse("#000"),
            BgColor = C.Parse("#e3e3e3"),
            Border = new BorderDefine(1, C.Parse("#ddd")),
            Texture = null,
        };

        public static StateStyle DefaultPressStyle = new StateStyle()
        {
            Color = C.Parse("#000"),
            BgColor = C.Parse("#cccccc"),
            Border = new BorderDefine(1, C.Parse("#aaa")),
            Texture = null,
        };

        public class StateStyle
        {
            public Color Color;

            public Face Font;

            public Color BgColor;

            public Texture2D Texture;

            public BorderDefine? Border;

            public string Text;

            public Vector4 Padding;
        }

        public readonly Dictionary<ButtonState, StateStyle> Style = new Dictionary<ButtonState, StateStyle>();

        public TextButton(SpriteBatch spriteBatch, Point location, Point size, string text) : base(spriteBatch, location, size)
        {
            Text = text;
        }

        protected override void DrawNormal(GameTime time)
        {
            Draw(ButtonState.Normal, DefaultStyle);
        }

        protected override void DrawHover(GameTime time)
        {
            Draw(ButtonState.Hover, DefaultHoverStyle);
        }

        protected override void DrawPressed(GameTime time)
        {
            Draw(ButtonState.Pressed, DefaultPressStyle);
        }

        private void Draw(ButtonState buttonState, StateStyle defaultStyle)
        {
            if (!Style.TryGetValue(buttonState, out var style))
            {
                style = defaultStyle;
            }
            if (style.BgColor.A > 0)
            {
                SpriteBatch.FillRectangle(RectangleAbs, style.BgColor, 0);
            }
            var textRect = RectangleAbs;
            if (style.Border.HasValue && style.Border.Value.Width > 0 && style.Border.Value.Color.A > 0)
            {
                var thickness = style.Border.Value.Width;
                SpriteBatch.DrawRectangle(RectangleAbs, style.Border.Value.Color, thickness);
                textRect.Offset(thickness, thickness);
                textRect.Inflate(thickness << 1, thickness << 1);
            }
            textRect.Offset(style.Padding.W, style.Padding.X);
            textRect.Inflate(-style.Padding.Y - style.Padding.W, -style.Padding.X - style.Padding.Z);
            SpriteBatch.DrawStringEx(style.Text ?? Text, style.Font ?? FontUtil.FontDefault, style.Color, textRect);
        }
    }
}