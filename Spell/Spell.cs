using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using log4net;

namespace Warlocked
{
    public abstract class Spell
    {
        
        public int manaCost;
        public int castTime; // in milliseconds
        public int coolDown;  // in milliseconds


        public virtual void Cast(Entity entity) { }
    }
}
