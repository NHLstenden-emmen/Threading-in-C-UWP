using System;
using System.Xml.Serialization;

namespace Threading_in_C_UWP.Board.Placeable
{
    public class Obstacle : InMovable
    {
        [XmlElement("type")]
        public String type;
        public Obstacle(String type)
        {
            this.type = type;
        }
        public Obstacle()
        {
        }

        public override string getDrawAble()
        {
            return this.type;
        }
    }
}
