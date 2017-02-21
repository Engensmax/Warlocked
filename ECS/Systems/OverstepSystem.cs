using System;
using System.Collections.Generic;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using log4net;
using Microsoft.Xna.Framework;


namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 3)]
    internal class OverstepSystem : EntityProcessingSystem
    {

        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public OverstepSystem()
            : base(Aspect.One(typeof(Input)))
        {
        }

        public override void Process(Entity entity)
        {
            if ((entity.GetComponent<Team>().team == 0 &&
                entity.GetComponent<Position>().position.X < ScreenManager.Instance.Dimensions.X / 2) ||
                (entity.GetComponent<Team>().team == 1 &&
                entity.GetComponent<Position>().position.X > ScreenManager.Instance.Dimensions.X / 2))
            {
                entity.GetComponent<Velocity>().currentMoveSpeed = 0.8f * entity.GetComponent<Velocity>().moveSpeed;


                if (entity.GetComponent<Input>().overstepTimer.IsReached(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime").ElapsedGameTime.Milliseconds))
                {
                    entity.GetComponent<Health>().currentHealth -= 1;
                    entity.GetComponent<Input>().overstepTimer.Reset();
                }
            }
            else
            {
                entity.GetComponent<Velocity>().currentMoveSpeed = entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Input>().overstepTimer.Reset();
            }
        }
    }
}
