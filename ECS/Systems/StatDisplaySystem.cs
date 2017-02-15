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
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 2)]
    internal class StatDisplaySystem : EntityProcessingSystem
    {
        public StatDisplaySystem()
            : base(Aspect.All(typeof(StatsDisplay)))
        {
        }
        
        public override void Process(Entity entity)
        {
            entity.GetComponent<StatsDisplay>().stats = "(" + entity.GetComponent<Damage>().damage.ToString() + "/" + entity.GetComponent<Health>().currentHealth.ToString() + ")";
            entity.GetComponent<StatsDisplay>().position = entity.GetComponent<Position>().position + new Vector2(0, entity.GetComponent<Appearance>().image.sourceRect.Height);

            EntitySystem.BlackBoard.GetEntry<SpriteBatch>("SpriteBatch").DrawString(EntitySystem.BlackBoard.GetEntry<ContentManager>("ContentManager").Load<SpriteFont>(entity.GetComponent<StatsDisplay>().font), entity.GetComponent<StatsDisplay>().stats, entity.GetComponent<StatsDisplay>().position, Color.YellowGreen);
        }
    }
}
