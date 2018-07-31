using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpFont;
using UGG.Core.Graphics;

namespace UGG.Core.Component.UI
{
    class TextButton : ButtonBase
    {
        public string Text;

        public static StateStyle DefaultStyle = new StateStyle()
        {
            Color = C.Parse("#000"),
            Bg = new ColorBrush(C.Parse("#efefef")),
            Border = new BorderDefine(1, C.Parse("#eee")),
        };

        public static StateStyle DefaultHoverStyle = new StateStyle()
        {
            Color = C.Parse("#000"),
            Bg = new ColorBrush(C.Parse("#f00")),
            Border = new BorderDefine(1, C.Parse("#eee").Darken(0.1f)),
        };

        public static StateStyle DefaultPressStyle = new StateStyle()
        {
            Color = C.Parse("#000"),
            Bg = new ColorBrush(C.Parse("#ff0")),
            Border = new BorderDefine(1, C.Parse("#eee").Darken(0.2f)),
        };

        public class StateStyle
        {
            public Color Color;

            public Face Font;

            public IDrawBrush Bg;

            public BorderDefine? Border;

            public string Text;

            public Vector4 Padding;

            public StateStyle Override(Color? color = null, Face font = null, IDrawBrush bg = null, BorderDefine? border = null, string text = null, Vector4? padding = null)
            {
                return new StateStyle()
                {
                    Color = color ?? Color,
                    Font = font ?? Font,
                    Bg = bg ?? Bg,
                    Border = border ?? Border,
                    Text = text ?? Text,
                    Padding = padding ?? Padding,
                };
            }
        }

        public Dictionary<ButtonState, StateStyle> Style;

        public TextButton(SpriteBatch spriteBatch, Point location, Point size, string text, StateStyle normal = null, StateStyle hover = null, StateStyle pressed = null) : base(spriteBatch, location, size)
        {
            void AddStyle(ButtonState buttonState1, StateStyle stateStyle)
            {
                if (stateStyle != null)
                {
                    Style = Style ?? new Dictionary<ButtonState, StateStyle>();
                    Style.Add(buttonState1, stateStyle);
                }
            }

            Text = text;
            AddStyle(ButtonState.Normal, normal);
            AddStyle(ButtonState.Hover, hover);
            AddStyle(ButtonState.Pressed, pressed);
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
            StateStyle style = null;
            if (Style?.TryGetValue(buttonState, out style) != true)
            {
                style = defaultStyle;
            }

            if (style.Bg?.Visible == true)
            {
                style.Bg.Draw(SpriteBatch, RectangleAbs);
            }

            var textRect = RectangleAbs;
            if (style.Border.HasValue && style.Border.Value.Width > 0 && style.Border.Value.Color.A > 0)
            {
                var thickness = style.Border.Value.Width;
                SpriteBatch.DrawRectangle(RectangleAbs, style.Border.Value.Color, thickness);
                textRect.Offset(thickness, thickness);
                textRect.Inflate(-(thickness << 1), -(thickness << 1));
            }

            textRect.Offset(style.Padding.W, style.Padding.X);
            textRect.Inflate(-style.Padding.Y - style.Padding.W, -style.Padding.X - style.Padding.Z);
            SpriteBatch.DrawStringEx(style.Text ?? Text, style.Font ?? FontUtil.FontDefault, style.Color, textRect);
        }
    }
}