using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using UGG.Core.Component;

namespace UGG.Core.Scene
{
    abstract class SceneBase
    {
        public List<UIContainerBase> Components;

        protected SceneBase()
        {
            Components = new List<UIContainerBase>();
        }

        public virtual void Update(GameTime time)
        {
            for (var i = 0; i < Components.Count; i++)
            {
                Components[i].Update(time);
            }
        }

        public virtual void Draw(GameTime time)
        {
            for (var i = 0; i < Components.Count; i++)
            {
                Components[i].Draw(time);
            }
        }
    }

    class MainScene : SceneBase
    {
        public MainScene()
        {

        }
    }
}