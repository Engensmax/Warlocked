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
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected Entity entity;

        protected EnchantmentSpell(int coolDown, string iconPath) : base(coolDown, iconPath)
        { }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);

            foreach (Entity e in entityWorld.EntityManager.GetEntities(Aspect.One(typeof(Enchantment))))
            {
                if (e.GetComponent<Team>().team == caster.GetComponent<Team>().team)
                {
                    if (e.GetComponent<Enchantment>().enchantmentSlot != 1 ||
                        e.GetComponent<Enchantment>().enchantmentSlot != 3)
                        e.GetComponent<Enchantment>().enchantmentSlot++;
                    else
                        e.Delete();
                }
            }


            entity = entityWorld.CreateEntityFromTemplate(EnchantmentTemplate.Name);
            entity.GetComponent<Team>().team = caster.GetComponent<Team>().team;
            LOGGER.Debug(caster.GetComponent<Team>().team);
            if (entity.GetComponent<Team>().team == 1)
                entity.GetComponent<Enchantment>().enchantmentSlot = 0;
            else
                entity.GetComponent<Enchantment>().enchantmentSlot = 2;

            entity.GetComponent<Enchantment>().spellBookSlot = caster.GetComponent<SpellBook>().currentSpell;


            entity.GetComponent<Appearance>().Initialize("Images/FireCaster.xml");

        }


    }
}
