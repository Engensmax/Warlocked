using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    public class FireLanceSpell : EffectSpell
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly int coolDownTime = 2000;

        public FireLanceSpell() : base(coolDownTime, "Images/Icons/FireLance.xml")
        {
            this.manaCost = 3;
            this.castTime = 500; // in milliseconds
        }

        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            LOGGER.Debug("FireLance");

            foreach (Entity entity in entityWorld.EntityManager.GetEntities(Aspect.One(typeof(Health))))
            {
                LOGGER.Debug(entity.Id);

                if (entity.GetComponent<Team>().team != caster.GetComponent<Team>().team)
                {
                    if (Math.Abs(entity.GetComponent<Position>().position.Y - caster.GetComponent<Position>().position.Y) < 64)
                        entity.GetComponent<Health>().currentHealth -= 2;
                }
            }

            base.Cast(caster, entityWorld);
        }

    }
}
