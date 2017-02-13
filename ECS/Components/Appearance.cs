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

        public Appearance()
        {
        }

        public void Initialize(string xmlPath)
        {
            this.image = new XmlManager<Image>().Load(xmlPath);
            this.image.LoadContent();
        }

        public void Cleanup()
        {
        }
    }
}
