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
    internal class Input2System : EntityProcessingSystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Input2System()
            : base(Aspect.All(typeof(Input)))
        {
        }

        public override void Process(Entity entity)
        {
            if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                           actionKeysMap[Input.Action.Attack]))
            {
                EntityWorld.SystemManager.GetSystem<Attack2System>().AddToQueue(entity);
                EntityWorld.EntityManager.GetEntity(1).Tag = "helloe";


            }
        }

    }
}
