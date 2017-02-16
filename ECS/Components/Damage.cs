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
        public int attackTime;
        public int attackRange;
        public bool isAttacking;
        public bool isHitting;

        public Damage()
        {
            this.damage = 1;
            this.attackTime = 250; // in milliseconds
            this.attackRange = 50; // in pixels
            this.isAttacking = false;
            this.isHitting = false;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
