using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Mana : ComponentPoolable
    {
        public float maxMana;
        public float currentMana;
        public float regenRate;

        public Mana()
        {
            this.maxMana = 0;
            this.currentMana = 0;
            this.regenRate = 0.25f; // Mana per second
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
