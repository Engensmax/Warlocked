using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    public class FireBallSpell : EffectSpell
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly int coolDownTime = 2000;

        public FireBallSpell() : base(coolDownTime, "Images/Icons/FireBall.xml")
        {
            this.manaCost = 1;
            this.castTime = 400; // in milliseconds
        }

        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            LOGGER.Debug("FireBall");
            Entity target;
            if (caster.Id == 1)
            {
                target = entityWorld.EntityManager.ActiveEntities[0];
            }
            else if (caster.Id == 0)
            {
                target = entityWorld.EntityManager.ActiveEntities[1];
            }
            else
                throw new InvalidOperationException("The caster does not seem to be a player");


            foreach (Entity entity in entityWorld.EntityManager.GetEntities(Aspect.One(typeof(Health))))
            {
                LOGGER.Debug(entity.Id);


                if (entity.GetComponent<Team>().team == target.GetComponent<Team>().team)
                {
                    if (Math.Abs(entity.GetComponent<Position>().position.X - caster.GetComponent<Position>().position.X) < Math.Abs(target.GetComponent<Position>().position.X - caster.GetComponent<Position>().position.X))
                        target = entity;
                }
            }
            target.GetComponent<Health>().currentHealth -= 1;

            base.Cast(caster, entityWorld);
        }

    }
}
