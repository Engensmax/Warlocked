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
        public int FrameCounter;
        [XmlIgnore]
        public int SwitchFrame;
        [XmlIgnore]
        public Vector2 CurrentFrame;
        [XmlElement ("item")]
        public List<int> AmountOfFramesPerLine;
        public int FrameWidth
        {
            get
            {
                if (image.Texture != null)
                    return image.Texture.Width / (int)AmountOfFramesPerLine.Max(e => e);
                return 0;
            }
        }

        public int FrameHeight
        {
            get
            {
                if (image.Texture != null)
                    return image.Texture.Height / (int)AmountOfFramesPerLine.Count;
                return 0;
            }
        }

        public SpriteSheetEffect()
        {
            CurrentFrame = new Vector2(0, 0);
            SwitchFrame = 100;
            FrameCounter = 0;
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
                image.isVisible = true;
                FrameCounter += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
                if (FrameCounter >= SwitchFrame)
                {
                    FrameCounter = 0;
                    CurrentFrame.X++;
                    if (CurrentFrame.Y >= AmountOfFramesPerLine.Count)
                        CurrentFrame.Y = 0;
                    if (CurrentFrame.X >= AmountOfFramesPerLine[(int)CurrentFrame.Y])
                    {
                        if (isContinuous)
                            CurrentFrame.X = 0;
                        else
                            image.isActive = false;
                    }
                }
            }
            else
            {
                image.isVisible = false;
                CurrentFrame.X = 0;
            }
            image.SourceRect = new Rectangle((int)CurrentFrame.X * FrameWidth,
                (int)CurrentFrame.Y * FrameHeight, FrameWidth, FrameHeight);
        }

    }
}
