using Artemis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warlocked
{
    public abstract class EffectSpell : ISpell
    {
        public abstract void Cast();
        public abstract void Cast(Entity entity);
    }
}
