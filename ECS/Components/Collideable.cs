using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Collision : ComponentPoolable
    {
        public int radius;

        public Collision()
        {
            this.radius = 20;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
