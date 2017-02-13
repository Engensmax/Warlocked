using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Warlocked
{
    public class GameScreen
    {
        protected ContentManager content;
        [XmlIgnore]
        public Type type;

        public string XmlPath;

        public GameScreen()
        {
            type = this.GetType();
            XmlPath = "Load/" + type.ToString().Replace("NinjaStriker.", "") + ".xml";
        }

        public virtual void LoadContent()
        {
            content = new ContentManager(
                ScreenManager.Instance.Content.ServiceProvider, "Content");
        }

        public virtual void UnloadContent()
        {
            content.Unload();
        }

        public virtual void Update(GameTime gameTime)
        {
            InputManager.Instance.Update();
        }

        public virtual void Draw()
        {
        }
    }
}
