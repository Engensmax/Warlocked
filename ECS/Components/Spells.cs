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
        public List<string> spells;
        
        public Spells()
        {
        }

        public void Cleanup()
        {
        }
    }
}
