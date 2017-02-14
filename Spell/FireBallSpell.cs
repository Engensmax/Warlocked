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

        public FireBallSpell()
        {
            this.manaCost = 2;
            this.castTime = 400; // in milliseconds
            this.coolDown = 5000;  // in milliseconds
        }

        public override void Cast(Entity entity)
        {
            LOGGER.Debug("FireBall");
            entity.GetComponent<Health>().currentHealth -= 1;
            entity.GetComponent<Mana>().currentMana -= this.manaCost;
        }

    }
}
