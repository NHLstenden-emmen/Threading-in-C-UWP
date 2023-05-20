using System.Collections.Generic;
using System.Xml.Serialization;
using Threading_in_C_UWP.Players;

namespace Threading_in_C_UWP.Converters
{
    public class EntityConverters
    {
        [XmlRoot("EntityList")]
        public class EntityList
        {
            [XmlElement("Entity")]
            public List<Entity> Entities { get; set; }
        }
    }
}
