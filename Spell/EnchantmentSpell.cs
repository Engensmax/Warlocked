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
        protected EnchantmentSpell(int coolDown) : base(coolDown)
        { }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);
        }
    }
}
