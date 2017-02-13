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

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class ManaRegenSystem : EntityProcessingSystem
    {
        public ManaRegenSystem()
            : base(Aspect.All(typeof(Mana)))
        {
        }
        
        public override void Process(Entity entity)
        {
            entity.GetComponent<Mana>().currentMana += entity.GetComponent<Mana>().regenRate;
        }
    }
}
