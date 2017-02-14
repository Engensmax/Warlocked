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
using log4net;

namespace Warlocked
{
    class GameplayScreen : GameScreen
    {

        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private EntityWorld world;
        private Entity player1, player2;


        public GameplayScreen()
        {
            HUDManager.Instance.Initialize();
            this.world = new EntityWorld();

            this.world.InitializeAll(true);

            player1 = world.CreateEntityFromTemplate(PlayerTemplate.Name);
            player2 = world.CreateEntityFromTemplate(PlayerTemplate.Name);
            player1.GetComponent<Input>().Initialize(1);
            player2.GetComponent<Input>().Initialize(2);
            player1.GetComponent<Position>().position = new Vector2(200-32, 208-32);
            player2.GetComponent<Position>().position = new Vector2(600-32, 208-32);

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
            HUDManager.Instance.Draw( player1, player2 );
            world.Draw();
            base.Draw();
        }
    }
}
