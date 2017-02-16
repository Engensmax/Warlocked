using Artemis;
using Artemis.Attributes;
using Artemis.Interface;

using Microsoft.Xna.Framework;

namespace Warlocked
{  
    /// <summary>The player template.</summary>
    [ArtemisEntityTemplate(Name)]
    public class PlayerTemplate : IEntityTemplate
    {
        public const string Name = "Player";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.AddComponentFromPool<Health>();
            entity.GetComponent<Health>().maxHealth = 20;
            entity.GetComponent<Health>().currentHealth = 20;
            entity.AddComponentFromPool<Team>();
            entity.AddComponentFromPool<Mana>();
            entity.AddComponentFromPool<Damage>();
            entity.AddComponentFromPool<Spells>();
            entity.AddComponentFromPool<Position>();
            entity.AddComponentFromPool<Velocity>();
            entity.AddComponentFromPool<Collision>();
            entity.AddComponentFromPool<Input>();
            entity.AddComponentFromPool<Appearance>();

            entity.GetComponent<Spells>().spells.Add(new SummonDinoGoblinSpell());


            entity.AddComponentFromPool<Velocity>().moveSpeed = 3;
            entity.GetComponent<Appearance>().Initialize("Images/FireCaster.xml");

            entity.GetComponent<Appearance>().image.isActive = true;
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = false;

            entity.GetComponent<Appearance>().animationsMap["CastDown"] = 2;
            entity.GetComponent<Appearance>().animationsMap["CastLeft"] = 1;
            entity.GetComponent<Appearance>().animationsMap["CastUp"] = 0;
            entity.GetComponent<Appearance>().animationsMap["CastRight"] = 3;
                                                           
            entity.GetComponent<Appearance>().animationsMap["MoveUp"] =  8;
            entity.GetComponent<Appearance>().animationsMap["MoveLeft"] =  9;
            entity.GetComponent<Appearance>().animationsMap["MoveDown"] =  10;
            entity.GetComponent<Appearance>().animationsMap["MoveRight"] =  11;
                                                           
            entity.GetComponent<Appearance>().animationsMap["AttackUp"] =  12;
            entity.GetComponent<Appearance>().animationsMap["AttackLeft"] =  13;
            entity.GetComponent<Appearance>().animationsMap["AttackDown"] =  14;
            entity.GetComponent<Appearance>().animationsMap["AttackRight"] =  15;
                                                           
            entity.GetComponent<Appearance>().animationsMap["Spawn"] =  2;
            entity.GetComponent<Appearance>().animationsMap["Die"] =  16;

            entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y =
                entity.GetComponent<Appearance>().animationsMap["Spawn"];
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = true;
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isContinuous = false;
            entity.GetComponent<Appearance>().image.isActive = true;

            entity.Refresh();
                        
            return entity;
        }
    }
}