using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Health : ComponentPoolable
    {
        public float maxHealth { get; private set; }
        public float currentHealth;
        public float regenRate;

        public Health()
        {
            this.maxHealth = 1;
            this.currentHealth = 1;
            this.regenRate = 0;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
