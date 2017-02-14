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

        public SummonDinoGoblinSpell()
        {
            this.manaCost = 1;
            this.castTime = 400; // in milliseconds
            this.coolDown = 5000;  // in milliseconds
        }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            LOGGER.Debug("DinoGoblin");

            var goblin = entityWorld.CreateEntityFromTemplate(MonsterTemplate.Name);
            goblin.GetComponent<Health>().currentHealth = 1;
            goblin.GetComponent<Damage>().damage = 1;

            goblin.GetComponent<Position>().position = caster.GetComponent<Position>().position;
            goblin.GetComponent<Appearance>().Initialize("Images/DinoGoblin.xml");
            goblin.GetComponent<Appearance>().image.isActive = true;
            goblin.GetComponent<Appearance>().image.spriteSheetEffect.isActive = true;


            goblin.GetComponent<Velocity>().moveSpeed = 3;

            if (caster.Id == 0)
                goblin.GetComponent<Velocity>().velocity.X = goblin.GetComponent<Velocity>().moveSpeed;
            if (caster.Id == 1)
                goblin.GetComponent<Velocity>().velocity.X = - goblin.GetComponent<Velocity>().moveSpeed;

            goblin.Refresh();

        }
    }
}
