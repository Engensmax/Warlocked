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

        public void Draw(Entity player1, Entity player2)
        {
            images["HealthBarFilling1"].scale.X = 188 * player1.GetComponent<Health>().currentHealth / 20;
            images["HealthBarFilling2"].scale.X = 188 * player2.GetComponent<Health>().currentHealth / 20;

            images["ManaBarFilling1"].scale.X = 188 * player1.GetComponent<Mana>().currentMana / 10;
            images["ManaBarFilling2"].scale.X = 188 * player2.GetComponent<Mana>().currentMana / 10;

            foreach (Image image in this.images.Values)
            {
                image.Draw();
            }
        }
    }
}
