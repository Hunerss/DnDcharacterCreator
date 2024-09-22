using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnDcharacterCreator.Classes
{
    public class Proficiencies
    {
        [XmlArray("Weapons")]
        [XmlArrayItem("Weapon")]
        public string[] Weapons {  get; set; }
        [XmlArray("Armors")]
        [XmlArrayItem("Armor")]
        public string[] Armor { get; set; }
        [XmlArray("Tools")]
        [XmlArrayItem("Tool")]
        public string[] Tools { get; set; }
        [XmlArray("Languages")]
        [XmlArrayItem("Language")]
        public string[] Languages { get; set; }
    }
}
