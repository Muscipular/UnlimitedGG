using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UGG.Core.Component;
using UGG.Core.Utilities.Platform;

namespace UGG.Core.Scene
{
    abstract class SceneBase
    {
        protected readonly SpriteBatch spriteBatch;

        public List<UIBase> Backgroup;

        public List<UIBase> Panel;

        public List<UIBase> Pop;

        private readonly GoodGameCore game;

        protected SceneBase(GoodGameCore game)
        {
            this.game = game;
            spriteBatch = game.spriteBatch;
            Backgroup = new List<UIBase>();
            Panel = new List<UIBase>();
            Pop = new List<UIBase>();
        }

        public virtual void Update(GameTime time)
        {
            for (var i = 0; i < Pop.Count; i++)
            {
                Pop[i].Update(time);
            }
            for (var i = 0; i < Panel.Count; i++)
            {
                Panel[i].Update(time);
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