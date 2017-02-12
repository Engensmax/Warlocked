using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace Warlocked
{
    public class BlinkEffect : ImageEffect
    {
        public double blinkInterval;
        public double elapsedTimeSinceBlink;

        public BlinkEffect()
        {
            this.blinkInterval = 0.1;
            this.elapsedTimeSinceBlink = 0;
        }
        public override void LoadContent(ref Image Image)
        {
            base.LoadContent(ref Image);
        }
        public override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            elapsedTimeSinceBlink += gameTime.ElapsedGameTime.TotalSeconds; 

            if (elapsedTimeSinceBlink >= blinkInterval)
            {
                elapsedTimeSinceBlink -= blinkInterval;

                if (image.isVisible)
                    image.isVisible = false;
                else
                    image.isVisible = true;
            }
        }

    }
}
