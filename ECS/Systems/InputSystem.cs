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
using log4net;

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class InputSystem : EntityProcessingSystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public InputSystem()
            : base(Aspect.All(typeof(Input)))
        {
        }

        public override void Process(Entity entity)
        {
            HandleCasting(entity);

            if  (!entity.GetComponent<Spells>().isCasting)
                HandleMovement(entity);

        }

        private void HandleCasting(Entity entity)
        {
            if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.SpellButton1]))
            {
                entity.GetComponent<Spells>().spells[0].Cast(entity);
                entity.GetComponent<Spells>().isCasting = true;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.X = 0;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y =
                entity.GetComponent<Appearance>().animationsMap["CastDown"];
                entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = true;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.isContinuous = false;
            }
            if (!entity.GetComponent<Appearance>().image.spriteSheetEffect.isContinuous)
                entity.GetComponent<Spells>().isCasting = entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive;
        }

        private static void HandleMovement(Entity entity)
        {
            if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MoveRight]))
            {
                entity.GetComponent<Velocity>().velocity.X =
                    entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 
                    entity.GetComponent<Appearance>().animationsMap["MoveRight"];
            }
            else if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveLeft]))
            {
                entity.GetComponent<Velocity>().velocity.X =
                    -entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 
                    entity.GetComponent<Appearance>().animationsMap["MoveLeft"];
            }
            else
                entity.GetComponent<Velocity>().velocity.X = 0;


            if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveUp]))
            {
                entity.GetComponent<Velocity>().velocity.Y =
                    -entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 
                    entity.GetComponent<Appearance>().animationsMap["MoveUp"];
            }
            else if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveDown]))
            {
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 
                    entity.GetComponent<Appearance>().animationsMap["MoveDown"];
                entity.GetComponent<Velocity>().velocity.Y =
                    entity.GetComponent<Velocity>().moveSpeed;
            }
            else
                entity.GetComponent<Velocity>().velocity.Y = 0;

            if (entity.GetComponent<Velocity>().velocity.X != 0 && entity.GetComponent<Velocity>().velocity.Y != 0)
            {
                entity.GetComponent<Velocity>().velocity.X =
                    Math.Sign(entity.GetComponent<Velocity>().velocity.X) *
                    0.707f * entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Velocity>().velocity.Y =
                    Math.Sign(entity.GetComponent<Velocity>().velocity.Y) *
                    0.707f * entity.GetComponent<Velocity>().moveSpeed;
            }


            if (entity.GetComponent<Velocity>().velocity.X == 0 && entity.GetComponent<Velocity>().velocity.Y == 0)
                entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = false;
            else
            {
                entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = true;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.isContinuous = true;
            }

        }
    }
}
