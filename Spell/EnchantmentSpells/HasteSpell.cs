using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    public class HasteSpell : EnchantmentSpell
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly int coolDownTime = 2000;

        public HasteSpell() : base(coolDownTime, "Images/Icons/Haste.xml")
        {
            this.manaCost = 5;
            this.castTime = 2000; // in milliseconds
        }

        public override void Enchant(Entity enchantment, EntityWorld entityWorld)
        {
            foreach (Entity e in entityWorld.EntityManager.GetEntities(Aspect.One(typeof(Damage))))
            {
                if (e.GetComponent<Team>().team == enchantment.GetComponent<Team>().team)
                {
                    e.GetComponent<Damage>().currentDamage = e.GetComponent<Damage>().damage + 1;
                    e.GetComponent<Velocity>().currentMoveSpeed = e.GetComponent<Velocity>().moveSpeed + 1;
                }
            }
        }
    }
}
