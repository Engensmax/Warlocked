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
using log4net;

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class CollisionSystem : EntitySystem
    {

        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CollisionSystem()
            : base(Aspect.All(typeof(Position), typeof(Collision)))
        {
        }

        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            foreach (int i in entities.Keys)
            {

                if (entities[i].GetComponent<Position>().position.X >= 800-32 && entities[i].GetComponent<Velocity>().velocity.X > 0)
                    entities[i].GetComponent<Velocity>().velocity.X = 0;

                if (entities[i].GetComponent<Position>().position.X <= 32 && entities[i].GetComponent<Velocity>().velocity.X < 0)
                    entities[i].GetComponent<Velocity>().velocity.X = 0;


                if (entities[i].GetComponent<Position>().position.Y >= 416-48 && entities[i].GetComponent<Velocity>().velocity.Y > 0)
                    entities[i].GetComponent<Velocity>().velocity.Y = 0;

                if (entities[i].GetComponent<Position>().position.Y <= 64 && entities[i].GetComponent<Velocity>().velocity.Y < 0)
                    entities[i].GetComponent<Velocity>().velocity.Y = 0;



                foreach (int j in entities.Keys)
                {
                    if (j > i)
                    {
                        var distance = entities[i].GetComponent<Position>().position - entities[j].GetComponent<Position>().position;
                        if (distance.Length() <= entities[i].GetComponent<Collision>().radius + entities[j].GetComponent<Collision>().radius)
                        {
                            if (Math.Abs(distance.X) > Math.Abs(distance.Y))
                            {
                                if (Math.Sign(distance.X) > 0)
                                {
                                    if (entities[i].GetComponent<Velocity>().velocity.X < 0)
                                        entities[i].GetComponent<Velocity>().velocity.X = 0;
                                    if (entities[j].GetComponent<Velocity>().velocity.X > 0)
                                        entities[j].GetComponent<Velocity>().velocity.X = 0;
                                }
                                else
                                {
                                    if (entities[i].GetComponent<Velocity>().velocity.X > 0)
                                        entities[i].GetComponent<Velocity>().velocity.X = 0;
                                    if (entities[j].GetComponent<Velocity>().velocity.X < 0)
                                        entities[j].GetComponent<Velocity>().velocity.X = 0;
                                }
                            }
                            else
                            {
                                if (Math.Sign(distance.Y) > 0)
                                {
                                    if (entities[i].GetComponent<Velocity>().velocity.Y < 0)
                                        entities[i].GetComponent<Velocity>().velocity.Y = 0;
                                    if (entities[j].GetComponent<Velocity>().velocity.Y > 0)
                                        entities[j].GetComponent<Velocity>().velocity.Y = 0;
                                }
                                else
                                {
                                    if (entities[i].GetComponent<Velocity>().velocity.Y > 0)
                                        entities[i].GetComponent<Velocity>().velocity.Y = 0;
                                    if (entities[j].GetComponent<Velocity>().velocity.Y < 0)
                                        entities[j].GetComponent<Velocity>().velocity.Y = 0;
                                }
                            }
                        }
                    }
                }                       
            }
        }


    }
}
