using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Threading_in_C_UWP.Board.Placeable.Entities
{
    public class Character : Entity
    {
        [XmlIgnore] // ignore Race for now
        public string Race { get; set; }

        [XmlElement("Class")]
        public string Class { get; set; }
    }
}
