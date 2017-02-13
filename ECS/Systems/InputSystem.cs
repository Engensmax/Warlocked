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
    internal class InputSystem : EntityProcessingSystem
    {
        public InputSystem()
            : base(Aspect.All(typeof(Input)))
        {
        }

        public override void Process(Entity entity)
        {
            HandleMovement(entity);

        }

        private static void HandleMovement(Entity entity)
        {
            if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MoveRight]))
            {
                entity.GetComponent<Velocity>().velocity.X =
                    entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = entity.GetComponent<Appearance>().animationsMap["MoveRight"];
            }
            else if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveLeft]))
            {
                entity.GetComponent<Velocity>().velocity.X =
                    -entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 9;
            }
            else
                entity.GetComponent<Velocity>().velocity.X = 0;


            if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveUp]))
            {
                entity.GetComponent<Velocity>().velocity.Y =
                    -entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 8;
            }
            else if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveDown]))
            {
                entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y = 10;
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
            }

        }
    }
}
