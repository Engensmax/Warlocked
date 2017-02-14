using Artemis;
using Artemis.Attributes;
using Artemis.Interface;

using Microsoft.Xna.Framework;

namespace Warlocked
{  
    /// <summary>The player template.</summary>
    [ArtemisEntityTemplate(Name)]
    public class ManaShardTemplate : IEntityTemplate
    {
        /// <summary>The name.</summary>
        public const string Name = "ManaShard";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.AddComponentFromPool<Position>();
            entity.AddComponentFromPool<Pickupable>();
            entity.GetComponent<Pickupable>().currentValue = 0.2f;
            entity.GetComponent<Pickupable>().maxValue = 0;
            entity.AddComponentFromPool<Appearance>();

            entity.Refresh();
            
            return entity;
        }
    }
}