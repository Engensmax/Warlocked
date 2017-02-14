using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Pickupable : ComponentPoolable
    {
        public int radius;
        public int value;

        public Pickupable()
        {
            this.radius = 20;
            this.value = 1;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
