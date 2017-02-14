﻿using Artemis;
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

        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            LOGGER.Debug("FireBall");
            caster.GetComponent<Health>().currentHealth -= 1;
            caster.GetComponent<Mana>().currentMana -= this.manaCost;
        }

    }
}
