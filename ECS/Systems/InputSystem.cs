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
            if (entity.GetComponent<Input>().isActive)
                HandleCasting(entity);
            if (entity.GetComponent<Input>().isActive)
                HandleAttacking(entity);
            if (entity.GetComponent<Input>().isActive)
                HandleMovement(entity);

                if (entity.GetComponent<Spells>().isCasting)
            {
                if (!entity.GetComponent<Appearance>().image.isActive)
                {
                    entity.GetComponent<Spells>().spells[0].Cast(entity, entityWorld);
                    entity.GetComponent<Spells>().isCasting = false;
                    entity.GetComponent<Input>().isActive = true;
                }  
            }
                if (entity.GetComponent<Damage>().isAttacking)
            {
                if (!entity.GetComponent<Appearance>().image.isActive)
                {
                    entity.GetComponent<Damage>().isAttacking = false;

                    entity.GetComponent<Damage>().isHitting = true;

                    entity.GetComponent<Input>().isActive = true;
                }
            }

        }

        private void HandleAttacking(Entity entity)
        {
            if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                           actionKeysMap[Input.Action.Attack]))
            {
                entity.GetComponent<Input>().isActive = false;
                entity.GetComponent<Damage>().isAttacking = true;

                if (entity.Id == 0)
                    entity.GetComponent<Appearance>().Animate(Appearance.Animation.AttackRight, entity.GetComponent<Damage>().attackTime, false);
                if (entity.Id == 1)
                    entity.GetComponent<Appearance>().Animate(Appearance.Animation.AttackLeft, entity.GetComponent<Damage>().attackTime, false);
                entity.GetComponent<Velocity>().velocity.X = 0;
                entity.GetComponent<Velocity>().velocity.Y = 0;
            }
        }

        private void HandleCasting(Entity entity)
        {
            if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.SpellButton1]))
            {
                if (entity.GetComponent<Spells>().spells[0].manaCost <= entity.GetComponent<Mana>().currentMana && !entity.GetComponent<Spells>().spells[0].isCoolingDown)
                {
                    entity.GetComponent<Mana>().currentMana -= entity.GetComponent<Spells>().spells[0].manaCost;
                    entity.GetComponent<Input>().isActive = false;
                    entity.GetComponent<Spells>().isCasting = true;
                    entity.GetComponent<Appearance>().Animate(Appearance.Animation.CastDown, entity.GetComponent<Spells>().spells[0].castTime, false);
                    entity.GetComponent<Velocity>().velocity.X = 0;
                    entity.GetComponent<Velocity>().velocity.Y = 0;
                }
            }



        }

        private static void HandleMovement(Entity entity)
        {
            if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MoveRight]))
            {
                entity.GetComponent<Velocity>().velocity.X =
                    entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().Animate(Appearance.Animation.MoveRight, 500, true);
            }
            else if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveLeft]))
            {
                entity.GetComponent<Velocity>().velocity.X =
                    -entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().Animate(Appearance.Animation.MoveLeft, 500, true);
            }
            else
                entity.GetComponent<Velocity>().velocity.X = 0;


            if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveUp]))
            {
                entity.GetComponent<Velocity>().velocity.Y =
                    -entity.GetComponent<Velocity>().moveSpeed;
                entity.GetComponent<Appearance>().Animate(Appearance.Animation.MoveUp, 500, true);
            }
            else if (InputManager.Instance.KeyDown(entity.GetComponent<Input>().
                actionKeysMap[Input.Action.MoveDown]))
            {
                entity.GetComponent<Appearance>().Animate(Appearance.Animation.MoveDown, 500, true);
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
                entity.GetComponent<Appearance>().image.isActive = false;

            if (entity.GetComponent<Velocity>().velocity.X != 0 || entity.GetComponent<Velocity>().velocity.Y != 0)
                entity.GetComponent<Appearance>().image.isActive = true;
        }
    }
}
