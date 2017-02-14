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
    internal class PickupSystem : EntitySystem
    {

        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        public PickupSystem()
            : base(Aspect.One(typeof(Input), typeof(Pickupable)))
        {
        }

        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            foreach (int i in entities.Keys)
            {
                if (entities[i].HasComponent<Input>())
                {
                    foreach (int j in entities.Keys)
                    {
                        if (entities[j].HasComponent<Pickupable>())
                        {
                            if (CollisionExists(entities[i], entities[j]))
                            {
                                if (entities[i].GetComponent<Mana>().maxMana < 10)
                                    entities[i].GetComponent<Mana>().maxMana += entities[j].GetComponent<Pickupable>().maxValue;
                                entities[i].GetComponent<Mana>().currentMana += entities[j].GetComponent<Pickupable>().currentValue;
                                entities[j].Delete();
                                LOGGER.Info("Pickup, MaxMana: " + entities[i].GetComponent<Mana>().maxMana);


                            }
                        }
                    }
                }
            }
        }

        private bool CollisionExists(Entity entity1, Entity entity2)
        {
            return (Vector2.Distance(entity1.GetComponent<Position>().position, entity2.GetComponent<Position>().position) <= entity1.GetComponent<Collision>().radius + entity2.GetComponent<Pickupable>().radius);
        }

    }
}
