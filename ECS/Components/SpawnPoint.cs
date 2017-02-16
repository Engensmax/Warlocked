using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.Utils;
using Microsoft.Xna.Framework;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class SpawnPoint : ComponentPoolable
    {
        public Image image;
        public Vector2 position; // MAX: All animations run through the SpriteSheetEffect. The int defines the row while it cycles through the columns.
        public Timer RespawnTimer;
        public bool isRespawning = false;

        public SpawnPoint()
        {
            this.image = new XmlManager<Image>().Load("Images/SpawnPoint.xml");
            this.image.LoadContent();
            this.RespawnTimer = new Timer(new TimeSpan(300));
        }

        public void Cleanup()
        {
            this.image.UnloadContent();
        }
    }
}
