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
    internal class EnchantmentSystem : EntityProcessingSystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EnchantmentSystem()
            : base(Aspect.All(typeof(Enchantment)))
        {
        }

        public override void Process(Entity entity)
        {
            //entity.GetComponent<Enchantment>();
        }
    }
}
