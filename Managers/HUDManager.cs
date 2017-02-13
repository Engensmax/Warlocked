using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Artemis.System;
using Artemis;

namespace Warlocked
{
    public class HUDManager
    {
        
        Dictionary<string, Image> images;
        private static HUDManager instance;

        public static HUDManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new HUDManager();

                return instance;
            }
        }

        public void Initialize()
        {
            var dictionary = new XmlManager<Dictionary>().Load("HUD.xml");
            images = new Dictionary<string, Image>();
            foreach (DictionaryItem item in dictionary.dictionary)
            {
                this.images.Add(item.Key, item.Value);
            }
        }

        public void LoadContent()
        {
            foreach (Image image in this.images.Values)
            {
                image.LoadContent();
            }
        }

        public void UnloadContent()
        {
            foreach (Image image in this.images.Values)
            {
                image.UnloadContent();
            }
        }

        public void Draw(List<Entity> players)
        {
            foreach (Image image in this.images.Values)
            {
                image.Draw();
            }
        }
    }
}
