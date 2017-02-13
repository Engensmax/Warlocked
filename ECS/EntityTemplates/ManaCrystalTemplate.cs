using Artemis;
using Artemis.Attributes;
using Artemis.Interface;
using System;

using Microsoft.Xna.Framework;

namespace Warlocked
{  
    /// <summary>The player template.</summary>
    [ArtemisEntityTemplate(Name)]
    public class ManaCrystalTemplate : IEntityTemplate
    {
        /// <summary>The name.</summary>
        public const string Name = "ManaCrystal";

        /// <summary>The build entity.</summary>
        /// <param name="entity">The entity.</param>
        /// <param name="entityWorld">The entityWorld.</param>
        /// <param name="args">The args.</param>
        /// <returns>The <see cref="Entity" />.</returns>
        public Entity BuildEntity(Entity entity, EntityWorld entityWorld, params object[] args)
        {
            entity.AddComponentFromPool<Position>();
            entity.AddComponentFromPool<Appearance>();
            entity.GetComponent<Appearance>().Initialize("Images/ManaCrystal.xml");
            entity.Refresh();
            
            return entity;
        }
    }
}