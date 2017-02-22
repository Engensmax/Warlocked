using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Warlocked
{
    class SummonDinoGoblinSpell : SummoningSpell
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly int coolDownTime = 2000;

        public SummonDinoGoblinSpell() : base(coolDownTime, "Images/Icons/DinoGoblin.xml")
        {
            this.manaCost = 1;
            this.castTime = 400; // in milliseconds
        }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);

            LOGGER.Debug("DinoGoblin");

            entity.GetComponent<Health>().health = 2;
            entity.GetComponent<Health>().currentHealth = 2;
            entity.GetComponent<Damage>().damage = 1;
            entity.GetComponent<Damage>().currentDamage = 1;

            entity.GetComponent<Velocity>().moveSpeed = 2;
            entity.GetComponent<Velocity>().currentMoveSpeed = 2;

            entity.GetComponent<AI>().ai = AI.Behavior.Aggressive;
            
            entity.GetComponent<Appearance>().Initialize("Images/DinoGoblin.xml");
            entity.GetComponent<Appearance>().image.isActive = true;
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = true;
            entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 0;

            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveRight] = 2;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveLeft] = 0;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackRight] = 3;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackLeft] = 1;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.Spawn] = 1;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.Respawn] = 1;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.Die] = 1;

            // probably obsolete by now
            //if (caster.Id == 0)
            //    entity.GetComponent<Velocity>().velocity.X = entity.GetComponent<Velocity>().currentMoveSpeed;
            //if (caster.Id == 1)
            //    entity.GetComponent<Velocity>().velocity.X = - entity.GetComponent<Velocity>().currentMoveSpeed;

            entity.Refresh();

        }
    }
}
