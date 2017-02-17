using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;

namespace Warlocked
{
    public class SpriteSheetEffect : ImageEffect
    {
        public bool isContinuous;
        [XmlIgnore]
        public int frameCounter;
        [XmlIgnore]
        public int switchFrame;
        [XmlIgnore]
        public Vector2 currentFrame;
        [XmlElement ("item")]
        public List<int> amountOfFramesPerLine;
        public int frameWidth
        {
            get
            {
                if (image.texture != null)
                    return image.texture.Width / (int)amountOfFramesPerLine.Max(e => e);
                return 0;
            }
        }

        public int frameHeight
        {
            get
            {
                if (image.texture != null)
                    return image.texture.Height / (int)amountOfFramesPerLine.Count;
                return 0;
            }
        }

        public SpriteSheetEffect()
        {
            currentFrame = new Vector2(0, 0);
            switchFrame = 100;
            frameCounter = 0;
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
            if (image.isActive)
            {
                frameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (frameCounter >= switchFrame)
                {
                    frameCounter = 0;
                    currentFrame.X++;
                    if (currentFrame.Y >= amountOfFramesPerLine.Count)
                        currentFrame.Y = 0;
                    if (currentFrame.X >= amountOfFramesPerLine[(int)currentFrame.Y])
                    {
                        currentFrame.X = 0;
                        image.isActive = isContinuous;
                    }
                }
            }
            else
            {
                currentFrame.X = 0;
            }
            image.sourceRect = new Rectangle((int)currentFrame.X * frameWidth,
                (int)currentFrame.Y * frameHeight, frameWidth, frameHeight);
        }

    }
}
