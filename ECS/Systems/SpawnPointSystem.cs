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
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 0)]
    internal class SpawnPointSystem : EntityProcessingSystem
    {
        public SpawnPointSystem()
            : base(Aspect.All(typeof(SpawnPoint)))
        {
        }
        
        public override void Process(Entity entity)
        {
            entity.GetComponent<SpawnPoint>().image.Draw();
        }
    }
}
