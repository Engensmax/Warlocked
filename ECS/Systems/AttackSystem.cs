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
    internal class AttackSystem : EntitySystem
    {

        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<int> collisionList = new List<int>();

        public AttackSystem()
            : base(Aspect.All(typeof(Damage), typeof(Health)))
        {
        }

        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            foreach (int i in entities.Keys)
            {
                if (entities[i].HasComponent<Damage>() && entities[i].GetComponent<Damage>().isHitting)
                {
                    foreach (int j in entities.Keys)
                    {
                        // This does splash damage around the attacker at the moment. TODO : Improve
                        if (entities[i].GetComponent<Team>() != entities[j].GetComponent<Team>() && 
                            entities[i].GetComponent<Damage>().attackRange > Vector2.Distance(entities[i].GetComponent<Position>().position, entities[j].GetComponent<Position>().position))
                        {
                            LOGGER.Info("Attack");
                            entities[j].GetComponent<Health>().currentHealth -= entities[i].GetComponent<Damage>().currentDamage;
                            if (entities[i].HasComponent<SpawnPoint>())
                                entities[i].GetComponent<SpawnPoint>().isRespawning = true;
                            
                        }
                    }
                    entities[i].GetComponent<Damage>().isHitting = false;
                }           
            }

        }


    }
}
