using Artemis;
using Artemis.Attributes;
using Artemis.Interface;

using Microsoft.Xna.Framework;

namespace Warlocked
{  
    /// <summary>The player template.</summary>
    [ArtemisEntityTemplate(Name)]
    public class MonsterTemplate : IEntityTemplate
    {
        /// <summary>The name.</summary>
        public const string Name = "Monster";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.AddComponentFromPool<Health>();
            entity.AddComponentFromPool<Damage>();
            entity.AddComponentFromPool<Position>();
            entity.AddComponentFromPool<Velocity>();
            entity.AddComponentFromPool<Collision>();
            entity.AddComponentFromPool<Appearance>();
            entity.AddComponentFromPool<SpawnPoint>();
            entity.AddComponentFromPool<StatsDisplay>();

            entity.Refresh();
            
            return entity;
        }
    }
}