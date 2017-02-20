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
            entity.AddComponentFromPool<SpellBook>();
            entity.AddComponentFromPool<Position>();
            entity.AddComponentFromPool<Velocity>();
            entity.AddComponentFromPool<Collision>();
            entity.AddComponentFromPool<Input>();
            entity.AddComponentFromPool<Appearance>();

            entity.GetComponent<SpellBook>().spells.Add(new SummonDinoGoblinSpell());
            entity.GetComponent<SpellBook>().spells.Add(new SummonDinoGoblinSpell());
            entity.GetComponent<SpellBook>().spells.Add(new SummonDinoGoblinSpell());
            entity.GetComponent<SpellBook>().spells.Add(new FireBallSpell());
            entity.GetComponent<SpellBook>().spells.Add(new FireBallSpell());
            entity.GetComponent<SpellBook>().spells.Add(new FireBallSpell());
            entity.GetComponent<SpellBook>().spells.Add(new FireBallSpell());
            entity.GetComponent<SpellBook>().spells.Add(new FireBallSpell());

            entity.GetComponent<SpellBook>().Load();

            entity.AddComponentFromPool<Velocity>().moveSpeed = 3;
            entity.AddComponentFromPool<Velocity>().currentMoveSpeed = 3;
            entity.GetComponent<Appearance>().Initialize("Images/FireCaster.xml");

            entity.GetComponent<Appearance>().image.isActive = true;
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = false;

            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.CastDown] = 2;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.CastLeft] = 1;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.CastUp] = 0;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.CastRight] = 3;

            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveUp] =  8;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveLeft] =  9;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveDown] =  10;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.MoveRight] =  11;

            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackUp] =  12;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackLeft] =  13;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackDown] =  14;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.AttackRight] =  15;

            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.Spawn] =  2;
            entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.Die] =  16;

            entity.GetComponent<Appearance>().image.spriteSheetEffect.currentFrame.Y =
                entity.GetComponent<Appearance>().animationsMap[Appearance.Animation.Spawn];
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isActive = true;
            entity.GetComponent<Appearance>().image.spriteSheetEffect.isContinuous = false;
            entity.GetComponent<Appearance>().image.isActive = true;

            entity.Refresh();
                        
            return entity;
        }
    }
}