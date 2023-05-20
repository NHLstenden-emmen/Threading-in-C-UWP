using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threading_in_C_UWP.Equipment
{
    public class Item
    {
        public override string ToString()
        {
            return $"{Name} (Type: {Type}, Rarity: {Rarity}, Value: {Value}, Description: {Description}, Properties: {string.Join(",", Properties)}, Drawbacks: {string.Join(",", Drawbacks)}, Requirements: {string.Join(",", Requirements)}, History: {History})";
        }
        public string ToFancyString()
        {
            return $"You just found a {Name} " + Environment.NewLine +
            $"Type: {Type}, " + Environment.NewLine +
                $"Rarity: {Rarity}, " + Environment.NewLine +
                $"Value: {Value}, " + Environment.NewLine +
                $"Description: {Description}, " + Environment.NewLine +
                $"Properties: {string.Join(",", Properties)}, " + Environment.NewLine +
                $"Drawbacks: {string.Join(",", Drawbacks)}, " + Environment.NewLine +
                $"Requirements: {string.Join(",", Requirements)}, " + Environment.NewLine +
                $"History: {History}";
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Rarity { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
        public List<string> Properties { get; set; }
        public List<string> Drawbacks { get; set; }
        public List<string> Requirements { get; set; }
        public string History { get; set; }

        public Item(string name, string type, string rarity, int value, string description, List<string> properties, List<string> drawbacks, List<string> requirements, string history)
        {
            Name = name;
            Type = type;
            Rarity = rarity;
            Value = value;
            Description = description;
            Properties = properties;
            Drawbacks = drawbacks;
            Requirements = requirements;
            History = history;
        }
    }
}
