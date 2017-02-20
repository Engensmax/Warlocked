using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Artemis.System;
using Artemis.Utils;
using log4net;
using Microsoft.Xna.Framework;

namespace Warlocked
{
    public abstract class Spell
    {
        public Image icon;
        public Image castImage;
        public int manaCost;
        public int castTime; // in milliseconds
        public int coolDown;  // in milliseconds
        private Timer coolDownTimer;
        public bool isCoolingDown;
        private GameTime gameTime;

        protected Spell(int coolDown)
        {
            if (castImage != null)
                castImage.LoadContent();
            this.isCoolingDown = false;
            this.coolDown = coolDown;
            this.coolDownTimer = new Timer(new TimeSpan(coolDown));
        }

        public virtual void Cast(Entity entity, EntityWorld entityWorld)
        {
            this.coolDownTimer.Reset();
            this.isCoolingDown = true;
        }

        public void Update()
        {
            gameTime = EntitySystem.BlackBoard.GetEntry<GameTime>("GameTime");
            if (coolDownTimer.IsReached(gameTime.ElapsedGameTime.Milliseconds))
            {
                this.isCoolingDown = false;
            }
            if (castImage != null)
                castImage.Update(gameTime);

        }

        public void Draw()
        {
            if (castImage != null)
                castImage.Draw();
        }

    }
}
