using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    abstract class SummoningSpell : Spell
    {
        protected Entity entity;

        protected SummoningSpell(int coolDown, string iconPath) : base(coolDown, iconPath)
        { }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);
            entity = entityWorld.CreateEntityFromTemplate(MonsterTemplate.Name);
            entity.GetComponent<Team>().team = caster.GetComponent<Team>().team;
            entity.GetComponent<Position>().position = caster.GetComponent<Position>().position;
            entity.GetComponent<SpawnPoint>().position = entity.GetComponent<Position>().position;
            entity.GetComponent<SpawnPoint>().image.position = entity.GetComponent<Position>().position;
        }
    }
}
