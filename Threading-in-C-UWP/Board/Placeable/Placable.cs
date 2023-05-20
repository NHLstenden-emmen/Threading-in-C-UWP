using System.Xml.Serialization;
using Threading_in_C_UWP.Players;

namespace Threading_in_C_UWP.Board.placeable
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
