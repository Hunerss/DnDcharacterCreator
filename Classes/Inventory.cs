using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DnDcharacterCreator.Classes
{
    public class Inventory
    {
        [XmlElement("Gold")]
        public int Gold { get; set; }
        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<string> Items { get; set; }
    }
}
