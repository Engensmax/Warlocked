using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Microsoft.Xna.Framework;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Spells : ComponentPoolable
    {
        public List<Spell> spells;
        public bool isCasting;
        
        public Spells()
        {
            spells = new List<Spell>();
            isCasting = false;
        }

        public void Cleanup()
        {
        }
    }
}
