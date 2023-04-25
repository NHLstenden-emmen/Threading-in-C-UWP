using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Threading_in_C_UWP.Board.Placeable.Entities
{
    public class Player : Character
    {
        [XmlIgnore]
        public int PlayerIndex;

        [XmlElement("PlayerIndex")]
        public string PlayerIndexAsText
        {
            get { return PlayerIndex.ToString(); }
            set { PlayerIndex = int.Parse(value); }
        }

        [XmlElement("PlayerLevel")]
        public int PlayerLevel;

        public override string ToString()
        {
            return $"{Name} (H: {Health} M: {Movement} STR: {Strength} DEX: {Dexterity} CON: {Constitution} INT: {Intelligence} WIS: {Wisdom} CHA: {Charisma} AR: {AR} BP: {BP})";
        }

        public Player(int playerIndex, string name, int health, int movement, int playerLevel, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int ar, int bp, string race, string characterClass)
        {
            PlayerIndex = playerIndex;
            Name = name;
            Health = health;
            Movement = movement;
            PlayerLevel = playerLevel;
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
            Wisdom = wisdom;
            Charisma = charisma;
            AR = ar;
            BP = bp;
            Race = race;
            Class = characterClass;
        }
        public Player()
        {
        }
    }
}