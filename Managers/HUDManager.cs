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
using log4net;

namespace Warlocked
{
    public class HUDManager
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        GameTime gameTime;
        Dictionary<string, Image> images;
        private static HUDManager instance;
        private static readonly int barLength = 188; 

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

        public void Update()
        {
            gameTime = EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime"); 
            foreach (Image image in this.images.Values)
            {
                image.Update(gameTime);
            }
        }
        public void Draw(Entity player1, Entity player2)
        {
            if (player1.IsActive)
                DrawImages(player1);
            if (player2.IsActive)
                DrawImages(player2);
            
            int j = 0;
            foreach (int i in player1.GetComponent<SpellBook>().spellMenu)
            {
                player1.GetComponent<SpellBook>().spells[i].icon.position = new Vector2(190 + j * 70, 418);
                player1.GetComponent<SpellBook>().spells[i].icon.Draw();
                j++;
            }

            j = 0;
            foreach (int i in player2.GetComponent<SpellBook>().spellMenu)
            {
                player2.GetComponent<SpellBook>().spells[i].icon.position = new Vector2(191 + 210 + j * 70, 418);
                player2.GetComponent<SpellBook>().spells[i].icon.Draw();
                j++;
            }

            foreach (Image image in this.images.Values)
            {
                image.Draw();
            }
        }

        private void DrawImages(Entity player)
        {
            images[string.Concat("HealthBarFilling", (player.Id+1).ToString())].scale.X = barLength * player.GetComponent<Health>().currentHealth / 20;

            images[string.Concat("MaxManaBarFilling", (player.Id + 1).ToString())].scale.X = barLength * player.GetComponent<Mana>().maxMana / 10;
            images[string.Concat("ManaBarFilling", (player.Id + 1).ToString())].scale.X = barLength * player.GetComponent<Mana>().currentMana / 10;



        }
    }
}
