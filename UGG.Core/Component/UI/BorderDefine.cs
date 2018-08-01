﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace UGG.Core.Component.UI
{
    struct BorderDefine
    {
        public int Width;

        public Color Color;

        public static BorderDefine None = new BorderDefine(0, Color.Transparent);

        public BorderDefine(int width, Color color)
        {
            Width = width;
            Color = color;
        }

        // public int Radius;
    }
}