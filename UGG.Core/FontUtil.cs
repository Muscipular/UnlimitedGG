using System;
using System.Collections.Generic;
using System.Linq;
using Color = Microsoft.Xna.Framework.Color;
using Point = Microsoft.Xna.Framework.Point;

namespace UGG.Core.Utilities
{
    static class FontUtil
    {
        // public static string FontPath = @"D:\Users\Source\UGG\UGG\Content\fonts\SourceHanSans-Regular.ttc";
        public static string FontPath = @"D:\Users\Source\UGG\UGG\Content\fonts\SourceHanSans-Regular2.ttf";

        private class CharCache
        {
            public Texture2D Texture;

            public Microsoft.Xna.Framework.Rectangle Rectangle;
        }

        private class FontDesc : IEquatable<FontDesc>
        {
            public readonly string fontFamily;

            public readonly float fontSize;

            public FontDesc(string fontFamily, int fontSize)
            {
                this.fontFamily = fontFamily;
                this.fontSize = fontSize;
            }

            public FontDesc(Font font)
            {
                this.fontFamily = font.FontFamily.Name;
                this.fontSize = font.Size;
            }

            public FontDesc(Face font)
            {
                this.fontFamily = font.FamilyName;
                this.fontSize = font.Size.Metrics.NominalHeight;
            }

            public bool Equals(FontDesc other)
            {
                return string.Equals(fontFamily, other.fontFamily) && Math.Abs(fontSize - other.fontSize) < 0.01;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj is FontDesc && Equals((FontDesc)obj);
            }

            /// <summary>返回此实例的哈希代码。</summary>
            /// <returns>一个 32 位带符号整数，它是此实例的哈希代码。</returns>
            public override int GetHashCode()
            {
                unchecked
                {
                    return ((fontFamily != null ? fontFamily.GetHashCode() : 0) * 397) ^ fontSize.GetHashCode();
                }
            }

            public static bool operator ==(FontDesc left, FontDesc right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(FontDesc left, FontDesc right)
            {
                return !left.Equals(right);
            }
        }

        private static List<TextureCache> textures = new List<TextureCache>();

        private static Dictionary<FontDesc, Dictionary<char, CharCache>> caches = new Dictionary<FontDesc, Dictionary<char, CharCache>>();

        public static void DrawString(this SpriteBatch batch, string text, Font font, Color color, int x, int y, int? width = null, int? height = null)
        {
            var fontDesc = new FontDesc(font);
            if (!caches.TryGetValue(fontDesc, out var dic2))
            {
                caches.Add(fontDesc, dic2 = new Dictionary<char, CharCache>());
            }
            width = width ?? batch.GraphicsDevice.Viewport.Width;
            int sx = 0;
            int sy = 0;
            var warp = width.HasValue;
            height = height ?? batch.GraphicsDevice.Viewport.Height;
            foreach (var s in text)
            {
                if (!dic2.TryGetValue(s, out var cache))
                {
                    cache = BuildCache(batch.GraphicsDevice, s, font);
                    dic2.Add(s, cache);
                }
                if (warp && sx + cache.Rectangle.Width > width)
                {
                    sy += cache.Rectangle.Height;
                    sx = 0;
                }
                if (sy > height)
                {
                    return;
                }
                if (!warp && sx > width)
                {
                    return;
                }
                batch.Draw(cache.Texture, new Microsoft.Xna.Framework.Vector2(sx + x, sy + y), cache.Rectangle, color);
                sx += cache.Rectangle.Width;
            }
        }

        public static void Preload(this GraphicsDevice device, string text, Font font)
        {
            var fontDesc = new FontDesc(font);
            if (!caches.TryGetValue(fontDesc, out var dic2))
            {
                caches.Add(fontDesc, dic2 = new Dictionary<char, CharCache>());
            }
            foreach (var s in text)
            {
                if (!dic2.TryGetValue(s, out var cache))
                {
                    cache = BuildCache(device, s, font);
                    dic2.Add(s, cache);
                }
            }
        }

        public static void Preload(this GraphicsDevice device, string text, SharpFont.Face font)
        {
            var fontDesc = new FontDesc(font);
            if (!caches.TryGetValue(fontDesc, out var dic2))
            {
                caches.Add(fontDesc, dic2 = new Dictionary<char, CharCache>());
            }
            foreach (var s in text)
            {
                if (!dic2.TryGetValue(s, out var cache))
                {
                    cache = BuildCache(device, s, font);
                    dic2.Add(s, cache);
                }
            }
        }

        public static void DrawString(this SpriteBatch batch, string text, SharpFont.Face font, Color color, int x, int y, int? width = null, int? height = null)
        {
            var fontDesc = new FontDesc(font);
            if (!caches.TryGetValue(fontDesc, out var dic2))
            {
                caches.Add(fontDesc, dic2 = new Dictionary<char, CharCache>());
            }
            width = width ?? batch.GraphicsDevice.Viewport.Width;
            int sx = 0;
            int sy = 0;
            var warp = width.HasValue;
            height = height ?? batch.GraphicsDevice.Viewport.Height;
            foreach (var s in text)
            {
                if (!dic2.TryGetValue(s, out var cache))
                {
                    cache = BuildCache(batch.GraphicsDevice, s, font);
                    dic2.Add(s, cache);
                }
                if (warp && sx + cache.Rectangle.Width > width)
                {
                    sy += cache.Rectangle.Height;
                    sx = 0;
                }
                if (sy > height)
                {
                    return;
                }
                if (!warp && sx > width)
                {
                    return;
                }
                batch.Draw(cache.Texture, new Microsoft.Xna.Framework.Vector2(sx + x, sy + y), cache.Rectangle, color);
                sx += cache.Rectangle.Width;
            }
        }

        private class TextureCache
        {
            public FontDesc FontDesc;

            public int Count;

            public List<char> chars = new List<char>();

            public Texture2D Texture;

            public int x;

            public int y;

            public bool full;

            public static int Width = 1024;

            public static int Height = 1024;

            public int maxHeight = 0;

            public TextureCache(GraphicsDevice device, FontDesc fontDesc)
            {
                FontDesc = fontDesc;
                switch (device.GraphicsProfile)
                {
                    case GraphicsProfile.HiDef:
                        Height = Width = 4096;
                        break;
                    case GraphicsProfile.Reach:
                        Width = 2048;
                        Height = 1024;
                        break;
                }
                Texture = new Texture2D(device, Width, Height, false, SurfaceFormat.Color);
            }

            public CharCache AddChar(char ch, Font font, FontDesc fontDesc)
            {
                using (var bitmap = new Bitmap((int)(FontDesc.fontSize * 2), (int)FontDesc.fontSize * 2))
                {
                    SizeF size;
                    RectangleF f;
                    using (var g = Graphics.FromImage(bitmap))
                    {
                        g.CompositingQuality = CompositingQuality.HighQuality;
                        g.SmoothingMode = SmoothingMode.HighQuality;
                        g.CompositingMode = CompositingMode.SourceOver;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        var text = ch.ToString();
                        g.PageUnit = GraphicsUnit.Pixel;
                        var stringFormat = new StringFormat();
                        // stringFormat.Alignment = StringAlignment.Near;
                        // stringFormat.LineAlignment = StringAlignment.Near;
                        // stringFormat.FormatFlags = StringFormatFlags.LineLimit;
                        // stringFormat.Trimming = StringTrimming.None;
                        stringFormat.SetMeasurableCharacterRanges(new[] { new CharacterRange(0, 1), });

                        var region = g.MeasureCharacterRanges(text, font, new RectangleF(0, 0, FontDesc.fontSize * 2, FontDesc.fontSize * 2), stringFormat)[0];
                        f = region.GetBounds(g);
                        if (f.IsEmpty)
                        {
                            var layoutArea = new SizeF(FontDesc.fontSize * 2, FontDesc.fontSize * 2);
                            size = g.MeasureString(text, font, layoutArea, stringFormat);
                            f = new RectangleF(0, 0, size.Width, size.Height);
                        }
                        // g.Clear(System.Drawing.Color.Bisque);
                        g.DrawString(text, font, Brushes.Transparent, 0f, 0f, stringFormat);
                    }
                    var cache = this;
                    var w = (int)Math.Ceiling(f.Width);
                    var h = (int)Math.Ceiling(f.Height);
                    if (x + f.Width > Width)
                    {
                        y += h;
                        x = 0;
                    }
                    if (y > Height - f.Height)
                    {
                        full = true;
                        cache = new TextureCache(Texture.GraphicsDevice, fontDesc);
                        textures.Add(cache);
                    }
                    return cache.AddChar(ch, bitmap, w, h, (int)Math.Ceiling(f.X), (int)Math.Ceiling(f.Y));
                }
            }

            public CharCache AddChar(char ch, Face font, FontDesc fontDesc)
            {
                if (maxHeight == 0)
                {
                    maxHeight = font.Size.Metrics.Height.Ceiling();
                }
                var charIndex = font.GetCharIndex(ch);
                font.LoadGlyph(charIndex, LoadFlags.Default, LoadTarget.Normal);
                using (var glyph = font.Glyph.GetGlyph())
                {
                    glyph.ToBitmap(RenderMode.Normal, new FTVector26Dot6(0, 0), true);

                    using (var bitmapGlyph = glyph.ToBitmapGlyph())
                    {
                        var cache = this;

                        if (x + glyph.Advance.X.Ceiling() >= Width)
                        {
                            y += font.Size.Metrics.Height.Ceiling();
                            x = 0;
                        }
                        if (y >= Height - font.Size.Metrics.Height.Ceiling())
                        {
                            full = true;
                            cache = new TextureCache(Texture.GraphicsDevice, fontDesc);
                            textures.Add(cache);
                        }
                        return cache.AddChar(ch, font, glyph, bitmapGlyph);
                    }
                }
            }

            private CharCache AddChar(char ch, Face font, Glyph glyph, BitmapGlyph bitmapGlyph)
            {
                Count++;
                chars.Add(ch);
                if (!(bitmapGlyph.Bitmap.Width == 0 || bitmapGlyph.Bitmap.Rows == 0))
                {
                    var cBox = glyph.GetCBox(GlyphBBoxMode.Pixels);
                    var ascender = font.Size.Metrics.Ascender.Ceiling();
                    var rectangle = new Microsoft.Xna.Framework.Rectangle(x + cBox.Left, y + (ascender - cBox.Top), bitmapGlyph.Bitmap.Width, bitmapGlyph.Bitmap.Rows);
                    var color = bitmapGlyph.Bitmap.BufferData.Select(c =>
                    {
                        var color1 = (uint)(((c << 8) | (c << 16) | (c << 24)) | c);
                        return color1;
                    }).ToArray();
                    Texture.SetData(0, rectangle, color, 0, color.Length);
                }
                var advanceX = glyph.Advance.X.Ceiling();
                var cache = new CharCache()
                {
                    Rectangle = new Microsoft.Xna.Framework.Rectangle(x, y, advanceX, font.Size.Metrics.Height.Ceiling()),
                    Texture = Texture
                };
                x += advanceX;
                return cache;
            }

            private CharCache AddChar(char ch, Bitmap bitmap, int w, int h, int px, int py, Point offset = default(Point))
            {
                Count++;
                chars.Add(ch);
                var color = new Color[w * h];
                for (int j = 0; j < h; j++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        var pixel = bitmap.GetPixel(px + i, py + j);
                        color[i + j * w] = new Color(pixel.R, pixel.G, pixel.B, pixel.A);
                    }
                }
                var rectangle = new Microsoft.Xna.Framework.Rectangle(x + offset.X, y + offset.Y, w, h);
                Texture.SetData(0, rectangle, color, 0, color.Length);
                var cache = new CharCache()
                {
                    Rectangle = new Microsoft.Xna.Framework.Rectangle(x, y, w + offset.X, h + offset.Y),
                    Texture = Texture
                };
                x += w;
                return cache;
            }
        }

        private static CharCache BuildCache(GraphicsDevice device, char ch, Font font)
        {
            var fontDesc = new FontDesc(font);
            var textureCache = textures.FirstOrDefault(c => !c.full && c.FontDesc == fontDesc);
            if (textureCache == null)
            {
                textureCache = new TextureCache(device, fontDesc);
                textures.Add(textureCache);
            }

            return textureCache.AddChar(ch, font, fontDesc);
        }

        private static CharCache BuildCache(GraphicsDevice device, char ch, Face font)
        {
            var fontDesc = new FontDesc(font);
            var textureCache = textures.FirstOrDefault(c => !c.full && c.FontDesc == fontDesc);
            if (textureCache == null)
            {
                textureCache = new TextureCache(device, fontDesc);
                textures.Add(textureCache);
            }

            return textureCache.AddChar(ch, font, fontDesc);
        }
    }
}