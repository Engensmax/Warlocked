using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Warlocked
{
    // This is used to Load Dictionaries via Xml (f.e. see Content/Load/HUD.xml)
    public class Dictionary
    {
        [XmlElement("item")]
        public List<DictionaryItem> dictionary;
    }
}
