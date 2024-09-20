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
        public string Description { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public string Spellcasting { get; set; }
        public Stats Stats { get; set; }
    }
}
