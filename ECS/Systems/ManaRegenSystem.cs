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
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using log4net;

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class ManaRegenSystem : EntitySystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Timer manaTimer;

        public ManaRegenSystem()
            : base(Aspect.All(typeof(Mana)))
        {
            this.manaTimer = new Timer(new TimeSpan(8)); 
        }
        
        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            if (manaTimer.IsReached(1))
            {
                foreach (Entity entity in entities.Values)
                {
                    if (entity.GetComponent<Mana>().currentMana < entity.GetComponent<Mana>().maxMana)
                        entity.GetComponent<Mana>().currentMana += entity.GetComponent<Mana>().regenRate / 4;

                    if (entity.GetComponent<Mana>().currentMana > entity.GetComponent<Mana>().maxMana)
                        entity.GetComponent<Mana>().currentMana = entity.GetComponent<Mana>().maxMana;

                }
            }
        }
    }
}
