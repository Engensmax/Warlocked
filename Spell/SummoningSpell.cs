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
        protected SummoningSpell(int coolDown) : base(coolDown)
        { }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);
        }
    }
}
