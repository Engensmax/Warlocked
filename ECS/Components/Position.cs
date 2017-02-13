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
    class Position : ComponentPoolable
    {
        public Vector2 position;

        public Position()
        {
            this.position = Vector2.Zero;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
