using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using Artemis.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class CollisionSystem : EntitySystem
    {
        public CollisionSystem()
            : base(Aspect.All(typeof(Position), typeof(Collision)))
        {
        }

        public override void Process()
        {
            base.Process();



        }

        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            foreach (int i in entities.Keys)
            {
                for (int j = i+1; j < entities.Count(); j++)
                {
                    if (CollisionExists(entities[i], entities[j]))
                    {
                        System.Diagnostics.Debug.WriteLine("Collision!!");
                    }
                }                       
            }
        }

        private bool CollisionExists(Entity entity1, Entity entity2)
        {
            return (Vector2.Distance(entity1.GetComponent<Position>().position, entity2.GetComponent<Position>().position) <= entity1.GetComponent<Collision>().radius + entity2.GetComponent<Collision>().radius);
        }

    }
}
