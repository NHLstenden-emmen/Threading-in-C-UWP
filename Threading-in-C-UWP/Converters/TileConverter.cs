using System.Collections.Generic;
using System.Xml.Serialization;
using Threading_in_C_UWP.Board;

namespace Threading_in_C_UWP.Converters
{
    public class TileConverter
    {
        [XmlRoot("TileList")]
        public class TileList
        {
            [XmlElement("Tile")]
            public List<Tile> Tiles { get; set; }
        }
    }
}