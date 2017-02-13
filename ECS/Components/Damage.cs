using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Damage : ComponentPoolable
    {
        public float damage;

        public Damage()
        {
            this.damage = 1;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
