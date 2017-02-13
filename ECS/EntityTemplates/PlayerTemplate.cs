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
            entity.AddComponentFromPool<Mana>();
            entity.AddComponentFromPool<Spells>();
            entity.AddComponentFromPool<Position>();
            entity.AddComponentFromPool<Velocity>();
            entity.AddComponentFromPool<Collision>();
            entity.AddComponentFromPool<Input>();
            entity.AddComponentFromPool<Appearance>();

            entity.GetComponent<Spells>().spells.Add(new FireBallSpell());


            entity.AddComponentFromPool<Velocity>().moveSpeed = 3;
            entity.GetComponent<Appearance>().Initialize("Images/FireCaster.xml");

            entity.GetComponent<Appearance>().image.isActive = true;
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = false;

            entity.GetComponent<Appearance>().animationsMap.Add("CastDown", 2);
            entity.GetComponent<Appearance>().animationsMap.Add("CastLeft", 1);
            entity.GetComponent<Appearance>().animationsMap.Add("CastUp", 0);
            entity.GetComponent<Appearance>().animationsMap.Add("CastRight", 3);

            entity.GetComponent<Appearance>().animationsMap.Add("MoveUp", 8);
            entity.GetComponent<Appearance>().animationsMap.Add("MoveLeft", 9);
            entity.GetComponent<Appearance>().animationsMap.Add("MoveDown", 10);
            entity.GetComponent<Appearance>().animationsMap.Add("MoveRight", 11);

            entity.GetComponent<Appearance>().animationsMap.Add("AttackUp", 8);
            entity.GetComponent<Appearance>().animationsMap.Add("AttackLeft", 9);
            entity.GetComponent<Appearance>().animationsMap.Add("AttackDown", 10);
            entity.GetComponent<Appearance>().animationsMap.Add("AttackRight", 11);

            entity.GetComponent<Appearance>().animationsMap.Add("Die", 16);
            entity.Refresh();
            
            return entity;
        }
    }
}