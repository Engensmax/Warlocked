using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Microsoft.Xna.Framework;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Appearance : ComponentPoolable
    {
        public Image image;
        public Dictionary<string, int> animationsMap; // MAX: All animations run through the SpriteSheetEffect. The int defines the row while it cycles through the columns.

        public Appearance()
        {
            animationsMap = new Dictionary<string, int>();
            animationsMap.Add("MoveUp", 0);
            animationsMap.Add("MoveDown", 0);
            animationsMap.Add("MoveLeft", 0);
            animationsMap.Add("MoveRight", 0);
            animationsMap.Add("AttackUp", 0);
            animationsMap.Add("AttackDown", 0);
            animationsMap.Add("AttackLeft", 0);
            animationsMap.Add("AttackRight", 0);
            animationsMap.Add("CastUp", 0);
            animationsMap.Add("CastDown", 0);
            animationsMap.Add("CastLeft", 0);
            animationsMap.Add("CastRight", 0);
            animationsMap.Add("Spawn", 0);
            animationsMap.Add("Die", 0);
        }

        public void Initialize(string xmlPath)
        {
            this.image = new XmlManager<Image>().Load(xmlPath);
            this.image.LoadContent();

        }

        public void Cleanup()
        {
            this.image.UnloadContent();
        }
    }
}
