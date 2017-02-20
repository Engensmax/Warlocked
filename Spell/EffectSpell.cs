using Artemis;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    public abstract class EffectSpell : Spell
    {
        protected EffectSpell(int coolDown, string iconPath) : base(coolDown, iconPath)
        { }
        public override void Cast(Entity caster, EntityWorld entityWorld)
        {
            base.Cast(caster, entityWorld);
        }
    }
}
