using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UGG.Core.Scene;

namespace UGG.Core.Component.UI
{
    class TooltipComponent : UIBase
    {
        private readonly SceneBase scene;

        private readonly UIBase target;

        private readonly UIBase element;

        private Point preLocation = Point.Zero;

        private bool isAttach;

        private Point offset;

        private PosistionMode mode;

        public enum PosistionMode
        {
            Mouse,

            Parent,
        }

        public TooltipComponent(SpriteBatch spriteBatch,
                                SceneBase scene,
                                UIBase target,
                                UIBase element,
                                PosistionMode mode = PosistionMode.Mouse,
                                Point offset = default(Point))
            : base(spriteBatch, Rectangle.Empty)
        {
            element.HitTest = false;
            if (element is UIContainerBase container)
            {
                container.ChildHitTest = false;
            }
            this.scene = scene;
            this.target = target;
            this.element = element;
            this.mode = mode;
            this.offset = offset;
        }

        public override void Draw(GameTime time)
        {
            target.Draw(time);
        }

        public override void Attach(UIContainerBase parent)
        {
            target.Attach(parent);
        }

        public override void Detach()
        {
            target.Detach();
        }

        public override void Dispose()
        {
            target.Dispose();
            element.Dispose();
        }

        public override bool DoHitTest(ref MouseState state, ref bool handled, ref UIBase target)
        {
            return this.target.DoHitTest(ref state, ref handled, ref target);
        }

        public override void Update(GameTime time)
        {
            target.Update(time);
            if (target.IsMouseHover)
            {
                if (mode == PosistionMode.Mouse)
                {
                    var position = Mouse.GetState().Position;
                    if (preLocation != position)
                    {
                        var rectangle = element.Rectangle;
                        rectangle.Offset(position + offset);
                        element.RectangleAbs = rectangle;
                    }
                }
                else
                {
                    var point = target.RectangleAbs.Location;
                    var rectangle = element.Rectangle;
                    if (target is UIContainerBase container)
                    {
                        point = container.ChildArea.Location;
                    }
                    rectangle.Offset(point + offset);
                    element.RectangleAbs = rectangle;
                }
                if (!isAttach)
                {
                    isAttach = true;
                    scene.Context.Add(element);
                }
            }
            else
            {
                if (isAttach)
                {
                    isAttach = false;
                    preLocation = Point.Zero;
                    scene.Context.Remove(element);
                }
            }
        }
    }
}