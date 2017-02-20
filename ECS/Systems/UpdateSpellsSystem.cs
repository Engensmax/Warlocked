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

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class UpdateSpellsSystem : EntityProcessingSystem
    {
        public UpdateSpellsSystem()
            : base(Aspect.All(typeof(SpellBook)))
        {
        }

        public override void Process(Entity entity)
        {
            foreach (Spell spell in entity.GetComponent<SpellBook>().spells)
                spell.Update();

        }

    }
}
