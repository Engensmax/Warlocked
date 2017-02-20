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
    class Velocity : ComponentPoolable
    {
        public Vector2 velocity;
        public float moveSpeed;
        public float currentMoveSpeed;

        public Velocity()
        {
            this.velocity = Vector2.Zero;
        }
        //obligatory for poolable Components
        public void Cleanup()
        {
        }
    }
}
