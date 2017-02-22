using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    public class RageSpell : EnchantmentSpell
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly int coolDownTime = 2000;

        public RageSpell() : base(coolDownTime, "Images/Icons/FireBall.xml")
        {
            this.manaCost = 0;
            this.castTime = 2000; // in milliseconds
        }

        public override void Enchant(EntityWorld entityWorld)
        {
            foreach (Entity e in entityWorld.EntityManager.GetEntities(Aspect.One(typeof(Damage))))
            {
                e.GetComponent<Damage>().currentDamage = e.GetComponent<Damage>().damage + 1;
            }
        }
    }
}
