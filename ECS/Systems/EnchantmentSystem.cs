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
    internal class EnchantmentSystem : EntityProcessingSystem
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EnchantmentSystem()
            : base(Aspect.All(typeof(Enchantment)))
        {
        }

        public override void Process(Entity entity)
        {
            if (entity.GetComponent<Enchantment>().enchantmentSlot == 0 ||
                entity.GetComponent<Enchantment>().enchantmentSlot == 1)
                entityWorld.EntityManager.ActiveEntities[0].GetComponent<SpellBook>().spells[entity.GetComponent<Enchantment>().spellBookSlot].Enchant(entityWorld);

            if (entity.GetComponent<Enchantment>().enchantmentSlot == 2 ||
                entity.GetComponent<Enchantment>().enchantmentSlot == 3)
                entityWorld.EntityManager.ActiveEntities[1].GetComponent<SpellBook>().spells[entity.GetComponent<Enchantment>().spellBookSlot].Enchant(entityWorld);

            if (entity.GetComponent<Enchantment>().enchantmentSlot == 0)
                entity.GetComponent<Position>().position = new Vector2(250, 32);

            if (entity.GetComponent<Enchantment>().enchantmentSlot == 1)
                entity.GetComponent<Position>().position = new Vector2(350, 32);

            if (entity.GetComponent<Enchantment>().enchantmentSlot == 2)
                entity.GetComponent<Position>().position = new Vector2(450, 32);

            if (entity.GetComponent<Enchantment>().enchantmentSlot == 3)
                entity.GetComponent<Position>().position = new Vector2(550, 32);
        }
    }
}