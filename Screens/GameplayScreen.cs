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
        private Entity player1, player2;
        

        public GameplayScreen()
        {
            HUDManager.Instance.Initialize();
            this.world = new EntityWorld();

            this.world.InitializeAll(true);

            //player1 = world.CreateEntityFromTemplate(PlayerTemplate.Name);


        }

        public override void LoadContent()
        {
            HUDManager.Instance.LoadContent();
            base.LoadContent();
            
        }

        public override void UnloadContent()
        {
            HUDManager.Instance.UnloadContent();
            world.UnloadContent();
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            EntitySystem.BlackBoard.SetEntry<GameTime>("GameTime", gameTime);
            world.Update();
            if (InputManager.Instance.KeyPressed(Keys.Escape))
                Warlocked.Instance.Exit();
            base.Update(gameTime);
        }

        public override void Draw()
        {
            HUDManager.Instance.Draw(new List<Entity>());
            world.Draw();
            base.Draw();
        }
    }
}
