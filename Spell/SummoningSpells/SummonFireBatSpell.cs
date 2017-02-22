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
    class SummonFireBatSpell : SummoningSpell
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly int coolDownTime = 2000;

        public SummonFireBatSpell() : base(coolDownTime, "Images/Icons/FireBat.xml")
        {
            this.manaCost = 3;
            this.castTime = 500; // in milliseconds
        }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);

            LOGGER.Debug("DinoGoblin");

            entity.GetComponent<Health>().health = 2;
            entity.GetComponent<Damage>().damage = 4;
            entity.GetComponent<Velocity>().moveSpeed = 3;
            entity.GetComponent<Health>().currentHealth = entity.GetComponent<Health>().health;
            entity.GetComponent<Damage>().currentDamage = entity.GetComponent<Damage>().damage;
            entity.GetComponent<Velocity>().currentMoveSpeed = entity.GetComponent<Velocity>().moveSpeed;

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

            entity.Refresh();

        }
    }
}
