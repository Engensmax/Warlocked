using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Artemis.System;
using log4net;


[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Warlocked
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Warlocked : Game
    {
        private static readonly ILog LOGGER = LogManager.GetLogger("Warlocked");

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private static Warlocked instance;



        public static Warlocked Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Warlocked();
                }
                return instance;
            }
        }

        private Warlocked()
        {
            LOGGER.Info("Start Warlocked");
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = (int)ScreenManager.Instance.Dimensions.X;
            graphics.PreferredBackBufferHeight = (int)ScreenManager.Instance.Dimensions.Y;
            graphics.ApplyChanges();

            base.Initialize();
            // IsMouseVisible = true;
            System.Diagnostics.Debug.WriteLine("Initialization");

            EntitySystem.BlackBoard.SetEntry("ContentManager", this.Content);
            EntitySystem.BlackBoard.SetEntry("GraphicsDevice", this.GraphicsDevice);
            EntitySystem.BlackBoard.SetEntry("SpriteBatch", this.spriteBatch);

            // EntitySystem.BlackBoard.SetEntry("SpriteFont", this.font);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.graphicsDevice = GraphicsDevice;
            ScreenManager.Instance.SpriteBatch = spriteBatch;
            ScreenManager.Instance.LoadContent(this.Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            if (InputManager.Instance.KeyPressed(Keys.Escape))
               Warlocked.Instance.Exit();

            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }
        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();
            ScreenManager.Instance.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
