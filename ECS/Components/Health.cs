using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.Utils;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Health : ComponentPoolable
    {
        public float health, maxHealth, currentHealth, regenRate;
        public Timer DeathTimer;

        public Health()
        {
            this.DeathTimer = new Timer(new TimeSpan(300));
            this.currentHealth = this.health = 1;
            this.regenRate = 0;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
