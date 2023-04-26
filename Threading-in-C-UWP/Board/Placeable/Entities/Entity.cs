using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Threading_in_C_UWP.Board.placeable;

namespace Threading_in_C_UWP.Players
{
    [XmlInclude(typeof(Enemy))]
    public class Entity : Moveable
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Health")]
        public string HealthAsText
        {
            get { return Health.ToString(); }
            set { Health = int.Parse(value); }
        }
        [XmlIgnore]
        public int Health { get; set; }
        [XmlElement("Movement")]
        public string MovementAsText
        {
            get { return Movement.ToString(); }
            set { Movement = int.Parse(value); }
        }
        [XmlIgnore]
        public int Movement { get; set; }
        [XmlElement("Strength")]
        public string StrengthAsText
        {
            get { return Strength.ToString(); }
            set { Strength = int.Parse(value); }
        }
        [XmlIgnore]
        public int Strength { get; set; }
        [XmlElement("Dexterity")]
        public string DexterityAsText
        {
            get { return Dexterity.ToString(); }
            set { Dexterity = int.Parse(value); }
        }
        [XmlIgnore]
        public int Dexterity { get; set; }
        [XmlElement("Constitution")]
        public string ConstitutionAsText
        {
            get { return Constitution.ToString(); }
            set { Constitution = int.Parse(value); }
        }
        [XmlIgnore]
        public int Constitution { get; set; }
        [XmlElement("Intelligence")]
        public string IntelligenceAsText
        {
            get { return Intelligence.ToString(); }
            set { Intelligence = int.Parse(value); }
        }
        [XmlIgnore]
        public int Intelligence { get; set; }
        [XmlElement("Wisdom")]
        public string WisdomAsText
        {
            get { return Wisdom.ToString(); }
            set { Wisdom = int.Parse(value); }
        }
        [XmlIgnore]
        public int Wisdom { get; set; }
        [XmlElement("Charisma")]
        public string CharismaAsText
        {
            get { return Charisma.ToString(); }
            set { Charisma = int.Parse(value); }
        }
        [XmlIgnore]
        public int Charisma { get; set; }
        [XmlElement("AR")]
        public string ARAsText
        {
            get { return AR.ToString(); }
            set { AR = int.Parse(value); }
        }
        [XmlIgnore]
        public int AR { get; set; }
        [XmlElement("BP")]
        public string BPAsText
        {
            get { return BP.ToString(); }
            set { BP = int.Parse(value); }
        }
        [XmlIgnore]
        public int BP { get; set; }

        public override string getDrawAble()
        {
            return Name;
        }

        public override int getMovement()
        {
            return this.Movement;
        }
    }
}
