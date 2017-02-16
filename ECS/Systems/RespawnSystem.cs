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
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 2)]
    internal class RespawnSystem : EntityProcessingSystem
    {

        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public RespawnSystem()
            : base(Aspect.All(typeof(SpawnPoint)))
        {

        }

        public override void Process(Entity entity)
        {
            if (entity.GetComponent<SpawnPoint>().isRespawning)
            {
                entity.GetComponent<Damage>().isAttacking = false;
                entity.GetComponent<AI>().isEngagedWith = -1;
                if (entity.GetComponent<SpawnPoint>().RespawnTimer.IsReached(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime").ElapsedGameTime.Milliseconds))
                {
                    LOGGER.Info("Respawn");
                    entity.GetComponent<SpawnPoint>().isRespawning = false;
                    entity.GetComponent<Position>().position = entity.GetComponent<SpawnPoint>().position;
                    entity.GetComponent<SpawnPoint>().RespawnTimer.Reset();
                }
            }


        }


    }
}
