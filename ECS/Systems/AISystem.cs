using System;
using System.Collections.Generic;
using Artemis;
using Artemis.Attributes;
using Artemis.Manager;
using Artemis.System;
using log4net;
using Microsoft.Xna.Framework;


namespace Warlocked
{
    [ArtemisEntitySystem(GameLoopType = GameLoopType.Update, Layer = 3)]
    internal class AISystem : EntitySystem
    {

        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<int> collisionList = new List<int>();

        public AISystem()
            : base(Aspect.One(typeof(AI), typeof(Input)))
        {
        }

        protected override void ProcessEntities(IDictionary<int, Entity> entities)
        {
            foreach (int i in entities.Keys)
            {
                if (entities[i].HasComponent<AI>())
                {
                    if (!entities[i].GetComponent<Damage>().isAttacking && entities[i].GetComponent<AI>().isEngagedWith == -1)
                    {
                        if (entities[i].GetComponent<Team>().team == 0)
                            entities[i].GetComponent<Appearance>().Animate(Appearance.Animation.MoveLeft, 500, true);
                        if (entities[i].GetComponent<Team>().team == 1)
                            entities[i].GetComponent<Appearance>().Animate(Appearance.Animation.MoveRight, 500, true);

                        switch (entities[i].GetComponent<AI>().ai)
                        {
                            case AI.Behavior.Aggressive:
                                ActAggressive(entities[i], entities);
                                break;

                            case AI.Behavior.Defensive:
                                ActDefensive(entities[i]);
                                break;

                            case AI.Behavior.Passive:
                                ActPassive(entities[i]);
                                break;
                                //case AI.behavior.Fearful:
                                //    ActFearful(entities[i]);
                                //    break;
                        }
                    }

                    if (entities[i].GetComponent<Damage>().isAttacking)
                    {
                        if (entities[i].GetComponent<Team>().team == 0)
                            entities[i].GetComponent<Appearance>().Animate(Appearance.Animation.AttackRight, entities[i].GetComponent<Damage>().attackTime, false);
                        if (entities[i].GetComponent<Team>().team == 1)
                            entities[i].GetComponent<Appearance>().Animate(Appearance.Animation.AttackLeft, entities[i].GetComponent<Damage>().attackTime, false);
                        entities[i].GetComponent<Velocity>().velocity.X = 0;
                        entities[i].GetComponent<Velocity>().velocity.Y = 0;
                        entities[i].GetComponent<Damage>().isAttacking = false;
                    }

                    if (entities[i].GetComponent<AI>().isEngagedWith != -1 && !entities[i].GetComponent<Appearance>().image.isActive)
                    {
                        LOGGER.Debug("IsEngaged");
                        entities[i].GetComponent<Damage>().isHitting = true;
                        entities[i].GetComponent<AI>().isEngagedWith = -1;
                    }
                }
                
            }
        }

        private void ActAggressive(Entity entity, IDictionary<int, Entity> entities)
        {
            var target = entities[entity.GetComponent<Team>().team]; // sets the enemy caster as initial target
            foreach (int i in entities.Keys) // searches for closer targets
            {
                if (i != entity.Id && entities[i].GetComponent<Team>().team != entity.GetComponent<Team>().team && (entities[i].HasComponent<Input>() || entities[i].GetComponent<AI>().isEngagedWith == -1))
                {
                    var xToEntity = entities[i].GetComponent<Position>().position.X - entity.GetComponent<Position>().position.X;
                    var xToTarget = target.GetComponent<Position>().position.X - entity.GetComponent<Position>().position.X;

                    if (Math.Sign(xToEntity) == Math.Sign(xToTarget) && Math.Abs(xToEntity) < Math.Abs(xToTarget))
                    {
                        target = entities[i]; // finds closest target
                    }
                }
            }
            
            // move towards target
            var direction = target.GetComponent<Position>().position - entity.GetComponent<Position>().position;
            entity.GetComponent<Velocity>().velocity = entity.GetComponent<Velocity>().moveSpeed * direction / direction.Length();


            // if target is within range, engage in combat
            if (direction.Length() < entity.GetComponent<Damage>().attackRange)
            {
                entity.GetComponent<AI>().isEngagedWith = target.Id;
                entity.GetComponent<Damage>().isAttacking = true;
                if (target.HasComponent<AI>())
                {
                    target.GetComponent<AI>().isEngagedWith = entity.Id;
                    target.GetComponent<Damage>().isAttacking = true;
                }
            }

        }
        private void ActDefensive(Entity entity)
        {
            throw new NotImplementedException();
        }

        private void ActPassive(Entity entity)
        {
            throw new NotImplementedException();
        }

    }
}
