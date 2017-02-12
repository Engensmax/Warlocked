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
        private Image background;
        

        public GameplayScreen()
        {
            this.background = new XmlManager<Image>().Load("background.xml");
            
            this.world = new EntityWorld();

            this.world.InitializeAll(true);

            //var shuriken = world.CreateEntityFromTemplate(ShurikenTemplate.Name);
            //System.Diagnostics.Debug.WriteLine(shuriken.GetComponent<Damage>().damage);
            //shuriken.AddComponentFromPool<Velocity>();
            
        }

        public override void LoadContent()
        {
            background.LoadContent();
            base.LoadContent();
        }

        public override void UnloadContent()
        {
            background.UnloadContent();
            world.UnloadContent();
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            background.Update(gameTime);
            EntitySystem.BlackBoard.SetEntry<GameTime>("GameTime", gameTime);
            world.Update();
            if (InputManager.Instance.KeyPressed(Keys.Escape))
                Warlocked.Instance.Exit();
        }

        public override void Draw()
        {
            background.Draw();
            base.Draw();
            world.Draw();
        }
    }
}
