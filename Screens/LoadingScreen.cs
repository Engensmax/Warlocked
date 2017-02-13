using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Warlocked
{
    public class LoadingScreen : GameScreen
    {
        public Image image;

        public override void LoadContent()
        {
            base.LoadContent();
            image = new XmlManager<LoadingScreen>().Load("LoadingScreen.xml").image;
            image.LoadContent();
            image.fadeEffect.fadeSpeed = 0.5f;
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
            image.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            image.Update(gameTime);
            if (InputManager.Instance.KeyPressed(Keys.Enter))
            {
                ScreenManager.Instance.ChangeScreens("TitleScreen");
                System.Diagnostics.Debug.WriteLine("Changing to TitleScreen");
            }
        }
                
        public override void Draw()
        {
            base.Draw();
            image.Draw();
        }
    }
}
