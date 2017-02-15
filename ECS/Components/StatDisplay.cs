using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class StatsDisplay : ComponentPoolable
    {
        public string stats, font;
        public Vector2 position;

        public StatsDisplay()
        {
            this.font = "StatsFont";
        }
        
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
