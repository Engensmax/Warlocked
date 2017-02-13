using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Artemis.System;

namespace Warlocked
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        public Image image;
        [XmlIgnore]
        public Vector2 Dimensions { private set; get; }
        [XmlIgnore]
        public ContentManager Content { private set; get; }
        XmlManager<GameScreen> xmlGameScreenManager;

        GameScreen currentScreen, newScreen;
        [XmlIgnore]
        public GraphicsDevice graphicsDevice;
        [XmlIgnore]
        public SpriteBatch SpriteBatch;

        [XmlIgnore]
        public bool IsTransitioning { get; private set; }

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                {
                    XmlManager<ScreenManager> xml = new XmlManager<ScreenManager>();
                    instance = xml.Load("ScreenManager.xml");
                }
                return instance;
            }
        }

        public void ChangeScreens(string screenName)
        {
            newScreen = (GameScreen)Activator.CreateInstance(Type.GetType("Warlocked." + screenName));
            image.isActive = true;
            image.fadeEffect.increase = true;
            image.alpha = 0.1f;
            IsTransitioning = true;
        }
        void Transition(GameTime gameTime)
        {
            if (IsTransitioning)
            {
                image.Update(gameTime);
                if (image.alpha == 1.0f)
                {
                    currentScreen.UnloadContent();
                    currentScreen = newScreen;
                    xmlGameScreenManager.Type = currentScreen.type;
                    if (File.Exists(currentScreen.XmlPath))
                        currentScreen = xmlGameScreenManager.Load(currentScreen.XmlPath);
                    currentScreen.LoadContent();
                }
                else if (image.alpha == 0.0f)
                {
                    image.isActive = false;
                    IsTransitioning = false;
                }
            }
        }

        public ScreenManager()
        {
            
            Dimensions = new Vector2(800,480);
            currentScreen = new LoadingScreen();
            xmlGameScreenManager = new XmlManager<GameScreen>();
            xmlGameScreenManager.Type = currentScreen.type;
            currentScreen = xmlGameScreenManager.Load("LoadingScreen.xml");


        }
        public void LoadContent(ContentManager Content)
        {
            this.Content = new ContentManager(
                Content.ServiceProvider, "Content");
            currentScreen.LoadContent();
            image.LoadContent();
        }

        public void UnloadContent()
        {
            currentScreen.UnloadContent();
            image.UnloadContent();
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
            Transition(gameTime);
        }

        public void Draw()
        {
            SpriteBatch spriteBatch = 
                EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch");
            currentScreen.Draw();
            if(IsTransitioning)
                image.Draw();
        }
    }

}
