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
        
        private static readonly int manaCost = 1;

        public override void Cast()
        {
        }

        public override void Cast(Entity entity)
        {
            LOGGER.Debug("FireBallSpell is cast.");
            entity.GetComponent<Health>().currentHealth -= 1;
            entity.GetComponent<Mana>().currentMana -= manaCost;
        }

    }
}
