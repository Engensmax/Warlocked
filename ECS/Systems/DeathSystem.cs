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
    internal class DeathSystem : EntityProcessingSystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public DeathSystem()
            : base(Aspect.All(typeof(Health)))
        {
        }
        
        public override void Process(Entity entity)
        {
            
            if (entity.GetComponent<Health>().currentHealth <= 0)
            {
                if (entity.HasComponent<Input>())
                { }
                else
                {
                    entity.GetComponent<Appearance>().Animate(Appearance.Animation.Die, 300, false);
                    if (entity.GetComponent<Health>().DeathTimer.IsReached(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime").ElapsedGameTime.Milliseconds))
                    {
                        LOGGER.Info("Death");
                        entity.Delete();
                    }
                }
            }
        }
    }
}
