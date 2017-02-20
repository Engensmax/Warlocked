using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis;
using log4net;
using Microsoft.Xna.Framework;
namespace Warlocked
{
    [Artemis.Attributes.ArtemisComponentPool()]
    class SpellBook : ComponentPoolable
    {
        private static readonly ILog LOGGER = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public List<Spell> spells;
        public List<int>[] spellMap;
        public bool isCasting;

        public List<int> spellMenu;  // contains the castable Spells from the menu right now. Used in InputSystem
        public int currentSpell;
        public int currentMenu = -1;
        public int currentSelection = 0;

        public SpellBook()
        {
            spells = new List<Spell>();
            spellMenu = new List<int>();
            spellMap = new List<int>[3];
            for (int i= 0; i < 3; i++)
                spellMap[i] = new List<int>();
            isCasting = false;
        }

        public void Load()
        {

            for (int spellID = 0; spellID < spells.Count; spellID++)
            {
                LOGGER.Info(spells[spellID]);
                
                if (spells[spellID] is EffectSpell)
                {
                    spellMap[0].Add(spellID);
                }
                else if (spells[spellID] is SummoningSpell)
                {
                    spellMap[1].Add(spellID);
                }
                else if (spells[spellID] is EnchantmentSpell)
                {
                    spellMap[2].Add(spellID);
                }
            }
        }

        public void Cleanup()
        {
        }
    }
}
