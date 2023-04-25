using System.Xml.Serialization;
using Threading_in_C_UWP.Board.Placeable.Entities;

namespace Threading_in_C_UWP.Board.Placeable
{
    [XmlInclude(typeof(Player))]
    [XmlInclude(typeof(Obstacle))]
    public abstract class Placeable
    {

        [XmlElement("name")]
        private string name;

        public abstract string getDrawAble();
    }
}
