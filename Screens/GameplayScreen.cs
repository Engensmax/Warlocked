using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using Artemis;
using Artemis.Attributes;
using Artemis.Interface;
using Artemis.Manager;
using Artemis.System;
using Artemis.Utils;

namespace Warlocked
{
    class GameplayScreen : GameScreen
    {
        private EntityWorld world;
        

        public GameplayScreen()
        {
            
            this.world = new EntityWorld();

            this.world.InitializeAll(true);

            //var shuriken = world.CreateEntityFromTemplate(ShurikenTemplate.Name);
            //System.Diagnostics.Debug.WriteLine(shuriken.GetComponent<Damage>().damage);
            //shuriken.AddComponentFromPool<Velocity>();
            
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            world.UnloadContent();
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            EntitySystem.BlackBoard.SetEntry<GameTime>("GameTime", gameTime);
            world.Update();
            if (InputManager.Instance.KeyPressed(Keys.Escape))
                Warlocked.Instance.Exit();
        }

        public override void Draw()
        {
            base.Draw();
            world.Draw();
        }
    }
}
