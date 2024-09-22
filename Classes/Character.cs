using System.Xml.Serialization;

namespace DnDcharacterCreator.Classes
{
    [XmlRoot("Character")]
    public class Character
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Race")]
        public string Race { get; set; }
        [XmlElement("Class")]
        public string Class { get; set; }
        [XmlElement("SubClass")]
        public string SubClass { get; set; }
        [XmlElement("HitPoints")]
        public int HitPoints { get; set; }
        [XmlElement("Spellcasting")]
        public string Spellcasting { get; set; }
        [XmlElement("Stats")]
        public Stats Stats { get; set; }
        [XmlElement("Alignment")]
        public string Alignment { get; set; }
        [XmlElement("Background")]
        public string Background { get; set; }
        [XmlElement("Description")]
        public string Description { get; set; }
        [XmlElement("PersonalityTraits")]
        public string PersonalityTraits { get; set; }
        [XmlElement("Ideals")]
        public string Ideals { get; set; }
        [XmlElement("Bonds")]
        public string Bonds { get; set; }
        [XmlElement("Flaws")]
        public string Flaws { get; set; }
        [XmlElement("About")]
        public string About { get; set; }
        [XmlArray("Skills")]
        [XmlArrayItem("Skill")]
        public string[] Skills { get; set; }
        [XmlElement("Inventory")]
        public Inventory Inventory { get; set; }
    }
}
