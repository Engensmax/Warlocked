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
using log4net;

namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 1)]
    internal class InputSystem : EntityProcessingSystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private SpellBook spellbook;

        public InputSystem()
            : base(Aspect.All(typeof(Input), typeof(SpellBook)))
        {
        }

        public override void Process(Entity entity)
        {
            this.spellbook = entity.GetComponent<SpellBook>();

            HandleSpellMenu(entity);
            
            if (entity.GetComponent<Input>().isActive)
                HandleAttacking(entity);
            if (entity.GetComponent<Input>().isActive)
                HandleMovement(entity);

                if (entity.GetComponent<SpellBook>().isCasting)
            {
                if (!entity.GetComponent<Appearance>().image.isActive)
                {
                    spellbook.spells[spellbook.currentSpell].Cast(entity, entityWorld);

                    spellbook.isCasting = false;

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


        private void HandleSpellMenu(Entity entity)
        {
            
            if (spellbook.currentMenu == -1) // Means we are in the normal menu
            {
                if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MenuButton1]))
                {
                    LOGGER.Info("EffectSpells Menu");
                    spellbook.currentMenu = 0;
                    ChangeMenu();
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MenuButton2]))
                {
                    LOGGER.Info("SummoningSpells Menu");
                    spellbook.currentMenu = 1;
                    ChangeMenu();
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MenuButton3]))
                {
                    spellbook.spellMenu = new List<int>();
                    LOGGER.Info("EnchantmentSpells Menu");
                    spellbook.currentMenu = 2;
                    ChangeMenu();
                }
            }
            else
            {
                if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MenuButton1]))
                {
                    CastSpell(entity, 0);
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MenuButton2]))
                {
                    CastSpell(entity, 1);
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.MenuButton3]))
                {
                    CastSpell(entity, 2);
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.NextButton]))
                {
                    if (spellbook.spellMap[spellbook.currentMenu].Count > spellbook.currentSelection + 1)
                    {
                        spellbook.currentSelection += 3;
                        ChangeMenu();
                        // TODO: Draw an arrow if this is possible
                    }
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.BackButton]))
                {
                    if (spellbook.currentSelection > 0)
                    {
                        spellbook.currentSelection -= 3;
                        ChangeMenu();
                        // TODO: Draw an arrow if this is possible
                    }
                }
                else if (InputManager.Instance.KeyPressed(entity.GetComponent<Input>().
                            actionKeysMap[Input.Action.EscapeButton]))
                {
                   LOGGER.Info("Back");
                   spellbook.currentMenu = -1;

                }
            }



        }

        private void ChangeMenu()
        {
            if (spellbook.spellMap[spellbook.currentMenu].Count > spellbook.currentSelection)
            {
                spellbook.spellMenu = new List<int>();

                for (int i = spellbook.currentSelection; i < (spellbook.currentSelection + 3) && i < spellbook.spellMap[spellbook.currentMenu].Count; i++)
                    spellbook.spellMenu.Add(spellbook.spellMap[spellbook.currentMenu][i]);
                LOGGER.Debug("Changed Menu to");
                foreach (int id in spellbook.spellMenu)
                {
                    LOGGER.Info(id);
                }
            }
        }

        private void CastSpell(Entity entity, int spellNumber)
        {
            LOGGER.Info("Casting Spell! CurrentMenu: " + spellbook.currentMenu + ", spellNumber: " + spellbook.spellMenu[spellNumber]);

            if (spellbook.spellMenu.Count > spellNumber && 
                spellbook.spells[spellbook.spellMenu[spellNumber]].manaCost <= entity.GetComponent<Mana>().currentMana && 
                !spellbook.spells[spellbook.spellMenu[spellNumber]].isCoolingDown && 
                entity.GetComponent<Input>().isActive)
            {
                entity.GetComponent<Mana>().currentMana -= spellbook.spells[spellbook.spellMenu[spellNumber]].manaCost;
                entity.GetComponent<Input>().isActive = false;
                spellbook.isCasting = true;
                spellbook.currentSpell = spellbook.spellMenu[spellNumber];
                spellbook.currentMenu = -1;
                entity.GetComponent<Appearance>().Animate(Appearance.Animation.CastDown, entity.GetComponent<SpellBook>().spells[0].castTime, false);
                entity.GetComponent<Velocity>().velocity.X = 0;
                entity.GetComponent<Velocity>().velocity.Y = 0;
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
