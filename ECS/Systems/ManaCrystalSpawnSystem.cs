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
    internal class ManaCrystalSpawnSystem : ProcessingSystem
    {
        private Timer manaSpawnTimer;

        public ManaCrystalSpawnSystem()
        {
            this.manaSpawnTimer = new Timer(new TimeSpan(5000));
            this.manaSpawnTimer.IsReached(4000);
        }
        
        public override void ProcessSystem()
        {
            if (manaSpawnTimer.IsReached(EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime").ElapsedGameTime.Milliseconds))
            {
                SpawnCrystal(new List<int> { 32, 368, 64, 384 });
                SpawnCrystal(new List<int> { 432, 768, 64, 384 });

                manaSpawnTimer.Reset();
            }

        }

        private void SpawnCrystal(List<int> boundaries)
        {
            var entity = EntityWorld.CreateEntityFromTemplate(ManaCrystalTemplate.Name);

            entity.GetComponent<Position>().position =
                new Vector2(RandomManager.Instance.Next(boundaries[0], boundaries[1] - 
                            entity.GetComponent<Appearance>().image.sourceRect.Width),
                            RandomManager.Instance.Next(boundaries[2], boundaries[3] - 
                            entity.GetComponent<Appearance>().image.sourceRect.Height));
        }
    }
}
