using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Enchantment : ComponentPoolable
    {
        public int enchantmentSlot; // 0, 1, 2 or 3
        public EnchantmentSpell spell;

        public Enchantment()
        {
            this.enchantmentSlot = 0;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
