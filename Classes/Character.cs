using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDcharacterCreator.Classes
{
    public class Character
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public int HitPoints { get; set; }
        public string Spellcasting { get; set; }
        public Stats Stats { get; set; }
        public string Alignment { get; set; }
        public string Background { get; set; }
        public string Description { get; set; }
        public string PersonalityTraits { get; set; }
        public string Ideals { get; set; }
        public string Bonds { get; set; }
        public string Flaws { get; set; }
        public string About { get; set; }
        public string[] Skills { get; set; }
        public Inventory Inventory { get; set; }

    }
}
