﻿using System;
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
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Draw, Layer = 3)]
    internal class DrawSystem : EntityProcessingSystem
    {
        public DrawSystem()
            : base(Aspect.All(typeof(Appearance)))
        {
        }
        
        public override void Process(Entity entity)
        {
            AdjustImagePosition(entity);
            
            entity.GetComponent<Appearance>().image.Draw();

        }

        private static void AdjustImagePosition(Entity entity)
        {
            entity.GetComponent<Appearance>().image.position =
                            entity.GetComponent<Position>().position -
                            new Vector2(entity.GetComponent<Appearance>().image.sourceRect.Width,
                                        entity.GetComponent<Appearance>().image.sourceRect.Height);
        }
    }
}
