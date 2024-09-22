using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnDcharacterCreator.Classes
{
    public class SavingThrows
    {
        [XmlElement("Strength Saving Thorw")]
        public bool Strength { get; set; }
        [XmlElement("Dexterity Saving Thorw")]
        public bool Dexterity { get; set; }
        [XmlElement("Constitution Saving Thorw")]
        public bool Constitution { get; set; }
        [XmlElement("boolelligence Saving Thorw")]
        public bool Intelligence { get; set; }
        [XmlElement("Wisdom Saving Thorw")]
        public bool Wisdom { get; set; }
        [XmlElement("Charisma Saving Thorw")]
        public bool Charisma { get; set; }
    }
}
