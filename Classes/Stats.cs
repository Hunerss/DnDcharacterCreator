using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnDcharacterCreator.Classes
{
    public class Stats
    {
        [XmlElement("Strength")]
        public int Strength { get; set; }
        [XmlElement("Dexterity")]
        public int Dexterity { get; set; }
        [XmlElement("Constitution")]
        public int Constitution { get; set; }
        [XmlElement("Intelligence")]
        public int Intelligence { get; set; }
        [XmlElement("Wisdom")]
        public int Wisdom { get; set; }
        [XmlElement("Charisma")]
        public int Charisma { get; set; }
    }
}
