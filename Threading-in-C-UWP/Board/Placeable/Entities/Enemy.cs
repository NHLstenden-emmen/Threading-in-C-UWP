using System.Xml.Serialization;

namespace Threading_in_C_UWP.Board.Placeable.Entities
{
    public class Enemy : Entity
    {
        public override string ToString()
        {
            return $"{Name} (H: {Health} M: {Movement} STR: {Strength} DEX: {Dexterity} CON: {Constitution} INT: {Intelligence} WIS: {Wisdom} CHA: {Charisma} AR: {AR} BP: {BP}, CR: {CR}, SIZE: {Size}, TP: {Type})";
        }

        [XmlIgnore]
        public string CR { get; set; }
        [XmlElement("CR")]
        public string CRAsText
        {
            get { return CR.ToString(); }
            set { CR = (value); }
        }
        [XmlIgnore]
        public string Size { get; set; }
        [XmlElement("Size")]
        public string SizeAsText
        {
            get { return Size.ToString(); }
            set { Size = (value); }
        }
        [XmlElement("Type")]
        public string Type { get; set; }
        public Enemy()
        {
        }

        public Enemy(string name, int health, int movement, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int ar, int bp, string cr, string size, string type)
        {
            Name = name;
            Health = health;
            Movement = movement;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            AR = ar;
            BP = bp;
            CR = cr;
            Size = size;
            Type = type;
        }
    }
}
