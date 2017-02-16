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
    class AI : ComponentPoolable
    {
        public enum behavior
        {
            Aggressive,
            Passive,
            Defensive
        }

        public behavior ai = new behavior();
        public int isEngagedWith = -1;

        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
