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
        

        public SummonDinoGoblinSpell() : base(400, "Images/Icons/DinoGoblin.xml")
        {
            this.manaCost = 1;
            this.castTime = 400; // in milliseconds
        }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            LOGGER.Debug("DinoGoblin");

            var goblin = entityWorld.CreateEntityFromTemplate(MonsterTemplate.Name);
            goblin.GetComponent<Health>().currentHealth = 2;
            goblin.GetComponent<Damage>().damage = 1;


            goblin.GetComponent<AI>().ai = AI.Behavior.Aggressive;
            goblin.GetComponent<Team>().team = caster.GetComponent<Team>().team;

            goblin.GetComponent<Position>().position = caster.GetComponent<Position>().position;
            goblin.GetComponent<SpawnPoint>().position = goblin.GetComponent<Position>().position;
            goblin.GetComponent<SpawnPoint>().image.position = goblin.GetComponent<Position>().position;

            goblin.GetComponent<Appearance>().Initialize("Images/DinoGoblin.xml");
            goblin.GetComponent<Appearance>().image.isActive = true;
            goblin.GetComponent<Appearance>().image.spriteSheetEffect.isActive = true;
            goblin.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 0;

            goblin.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveRight] = 2;
            goblin.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveLeft] = 0;
            goblin.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackRight] = 3;
            goblin.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackLeft] = 1;


            goblin.GetComponent<Velocity>().moveSpeed = 2;
            goblin.GetComponent<Velocity>().currentMoveSpeed = 2;

            // probably obsolete by now
            if (caster.Id == 0)
                goblin.GetComponent<Velocity>().velocity.X = goblin.GetComponent<Velocity>().currentMoveSpeed;
            if (caster.Id == 1)
                goblin.GetComponent<Velocity>().velocity.X = - goblin.GetComponent<Velocity>().currentMoveSpeed;

            goblin.Refresh();

            base.Cast(caster, entityWorld);
        }
    }
}
