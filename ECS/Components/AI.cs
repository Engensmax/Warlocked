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
        public enum Behavior
        {
            Aggressive,
            Passive,
            Defensive
        }

        public Behavior ai = new Behavior();
        public int isEngagedWith = -1;

        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
