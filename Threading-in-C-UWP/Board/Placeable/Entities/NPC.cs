using System.Collections.Generic;
using System.Xml.Serialization;

namespace Threading_in_C_UWP.Players
{
    public class NPC : Character
    {
        public override string ToString()
        {
            return $"{Name} (H: {Health} M: {Movement} STR: {Strength} DEX: {Dexterity} CON: {Constitution} INT: {Intelligence} WIS: {Wisdom} CHA: {Charisma} AR: {AR} BP: {BP}, Race: {Race}, Class: {Class}, Backstory: {Backstory}, Traits: {string.Join(", ", Traits)})";
        }
        [XmlElement("Backstory")]
        public string Backstory { get; set; }
        [XmlIgnore]
        public List<string> Traits { get; set; }

        public NPC() { }
        public NPC(string name, int health, int movement, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int ar, int bp, string race, string characterClass, string backstory, List<string> traits)
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
            Race = race;
            Class = characterClass;
            Backstory = backstory;
            Traits = traits;
        }
    }
}
