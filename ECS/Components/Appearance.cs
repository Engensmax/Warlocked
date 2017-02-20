using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using Microsoft.Xna.Framework;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class Appearance : ComponentPoolable
    {
        public Image image;
        public Dictionary<Animation, int> animationsMap;
        private Animation previousAnimation;


        public enum Animation
        {
            MoveUp,
            MoveDown,
            MoveLeft,
            MoveRight,
            AttackUp,
            AttackDown,
            AttackLeft,
            AttackRight,
            CastUp,
            CastDown,
            CastLeft,
            CastRight,
            Spawn,
            Respawn,
            Die
        }


        public Appearance()
        {
            animationsMap = new Dictionary<Animation, int>();
            animationsMap.Add(Animation.MoveUp, 0);
            animationsMap.Add(Animation.MoveDown, 0);
            animationsMap.Add(Animation.MoveLeft, 0);
            animationsMap.Add(Animation.MoveRight, 0);
            animationsMap.Add(Animation.AttackUp, 0);
            animationsMap.Add(Animation.AttackDown, 0);
            animationsMap.Add(Animation.AttackLeft, 0);
            animationsMap.Add(Animation.AttackRight, 0);
            animationsMap.Add(Animation.CastUp, 0);
            animationsMap.Add(Animation.CastDown, 0);
            animationsMap.Add(Animation.CastLeft, 0);
            animationsMap.Add(Animation.CastRight, 0);
            animationsMap.Add(Animation.Spawn, 0);
            animationsMap.Add(Animation.Respawn, 0);
            animationsMap.Add(Animation.Die, 0);
        }

        /// <summary>
        ///  Loads the image via xmlPath.
        /// </summary>
        /// <param name="xmlPath"></param>
        public void Initialize(string xmlPath)
        {
            this.image = new XmlManager<Image>().Load(xmlPath);
            this.image.LoadContent();

        }

        public void Cleanup()
        {
            this.image.UnloadContent();
        }

        /// <summary>
        /// Sets spritesheetEffect.currentFrame.X to 0 which restarts an animation.
        /// </summary>
        public void Animate(Animation animation, int animationDuration, bool isContinuous)
        {
            if (this.previousAnimation != animation || !this.image.isActive)
            {
                this.previousAnimation = animation;
                this.image.spriteSheetEffect.currentFrame.X = 0;
                this.image.isActive = true;
                this.image.spriteSheetEffect.currentFrame.Y = this.animationsMap[animation];
                this.image.spriteSheetEffect.isContinuous = isContinuous;
                this.image.spriteSheetEffect.switchFrame = 
                animationDuration / 
                this.image.spriteSheetEffect.amountOfFramesPerLine[(int)this.image.spriteSheetEffect.currentFrame.Y];
            }
        }
    }
}
