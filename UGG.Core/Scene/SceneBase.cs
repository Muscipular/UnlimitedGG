using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UGG.Core.Component;
using UGG.Core.Component.Logical;
using UGG.Core.Component.UI;

namespace UGG.Core.Scene
{
    abstract class SceneBase
    {
        protected readonly SpriteBatch spriteBatch;

        public List<UIBase> Backgroup;

        public List<UIBase> Panel;

        public List<UIBase> Pop;

        public List<UIBase> Context;

        private readonly GoodGameCore game;

        private HitTestManager hitTestManager;

        protected SceneBase(GoodGameCore game)
        {
            this.game = game;
            hitTestManager = new HitTestManager(game, this);
            spriteBatch = game.spriteBatch;
            Backgroup = new List<UIBase>();
            Panel = new List<UIBase>();
            Pop = new List<UIBase>();
            Context = new List<UIBase>();
        }

        public virtual void Update(GameTime gameTime)
        {
            hitTestManager.Update(gameTime);
            for (var i = 0; i < Context.Count; i++)
            {
                var uiBase = Context[i];
                uiBase.Update(gameTime);
            }   
            
            for (var i = 0; i < Pop.Count; i++)
            {
                var uiBase = Pop[i];
                uiBase.Update(gameTime);
            }

            for (var i = 0; i < Panel.Count; i++)
            {
                var uiBase = Panel[i];
                uiBase.Update(gameTime);
            }

            for (var i = 0; i < Backgroup.Count; i++)
            {
                Backgroup[i].Update(gameTime);
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (var i = 0; i < Backgroup.Count; i++)
            {
                Backgroup[i].Draw(gameTime);
            }

            spriteBatch.End();
            spriteBatch.Begin();
            for (var i = 0; i < Panel.Count; i++)
            {
                Panel[i].Draw(gameTime);
            }

            spriteBatch.End();
            for (var i = 0; i < Pop.Count; i++)
            {
                spriteBatch.Begin();
                Pop[i].Draw(gameTime);
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