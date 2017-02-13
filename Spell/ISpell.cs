using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace Warlocked
{
    interface ISpell
    {
        void Cast();
        void Cast(Entity entity);
    }
}
