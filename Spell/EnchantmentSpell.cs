using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    public abstract class EnchantmentSpell : Spell
    {
        protected Entity entity;

        protected EnchantmentSpell(int coolDown, string iconPath) : base(coolDown, iconPath)
        { }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);


            foreach (Entity entity in entityWorld.EntityManager.GetEntities(Aspect.One(typeof(Enchantment))))
            {
                if (entity.GetComponent<Team>().team == caster.GetComponent<Team>().team)
                {
                    if (entity.GetComponent<Enchantment>().enchantmentSlot != 1 ||
                        entity.GetComponent<Enchantment>().enchantmentSlot != 3)
                        entity.GetComponent<Enchantment>().enchantmentSlot++;
                    else
                        entity.Delete();
                }
            }


            entity = entityWorld.CreateEntityFromTemplate(EnchantmentTemplate.Name);
            entity.GetComponent<Team>().team = caster.GetComponent<Team>().team;
            entity.GetComponent<Enchantment>().enchantmentSlot = 0;
        }

        public override void Update()
        {
            base.Update();
        } 

    }
}
