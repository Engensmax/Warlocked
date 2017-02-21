using Artemis;
using Artemis.Attributes;
using Artemis.Interface;

using Microsoft.Xna.Framework;

namespace Warlocked
{  
    /// <summary>The player template.</summary>
    [ArtemisEntityTemplate(Name)]
    public class EnchantmentTemplate : IEntityTemplate
    {
        /// <summary>The name.</summary>
        public const string Name = "Enchantment";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.AddComponentFromPool<Enchantment>();
            entity.AddComponentFromPool<Team>();
            entity.AddComponentFromPool<Position>();
            entity.AddComponentFromPool<Appearance>();

            entity.Refresh();
            
            return entity;
        }
    }
}