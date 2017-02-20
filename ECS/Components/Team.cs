using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;

namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Team : ComponentPoolable
    {
        public int team;

        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
