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
    internal class Input3System : EntityProcessingSystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public delegate void AttackedEventHandler(object Source, EventArgs args);
        public event EventHandler<int> Attacked;

        public Input3System()
            : base(Aspect.All(typeof(Input)))
        {
         }

        public override void Process(Entity entity)
        {
            if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                           actionKeysMap[Input.Action.Attack]))
            {
                OnAttacked(entity.Id);
            }
        }

        protected virtual void OnAttacked(int id)
        {
            if (Attacked != null)
                Attacked(this, id);
        }
    }
}
