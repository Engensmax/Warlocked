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
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 3)]
    internal class UpdateEffectsSystem : EntityProcessingSystem
    {
        public UpdateEffectsSystem()
            : base(Aspect.All(typeof(Appearance)))
        {
        }

        public override void Process(Entity entity)
        {
            entity.GetComponent<Appearance>().image.Update(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime"));
            //if (entity.HasComponent<SpawnPoint>())  // SpawnPoint has no effects yet, so it doesn't need an update
            //    entity.GetComponent<SpawnPoint>().image.Update(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime"));

        }

    }
}
