using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Threading_in_C_UWP.Equipment;
using Threading_in_C_UWP.OpenFiveApi;
using Newtonsoft.Json.Linq;
using Microsoft.Data.Sqlite;
using System.Diagnostics;
using System.IO.Ports;

namespace Threading_in_C_UWP.ApiGenerators
{
    internal class ApiItemGenerator
    {
        public ApiItemGenerator()
        {
            OpenFiveApiRequest.con.Open();
            String CreateTableSql = "CREATE TABLE IF NOT EXISTS Items (" +
                "Name           NVARCHAR (20)   PRIMARY KEY," +
                "Rarity         VARCHAR(50)     DEFAULT((0)) NOT NULL," +
                "Value          INT             DEFAULT((0)) NOT NULL," +
                "Description    VARCHAR(255)    NULL," +
                "Properties     VARCHAR(255)    NULL," +
                "Drawbacks      VARCHAR(255)    NULL," +
                "Requirements   VARCHAR(255)    NULL," +
                "History        VARCHAR(255)    NULL," +
                "Type           VARCHAR(255)    NULL);";
            using (SqliteCommand command = new SqliteCommand(CreateTableSql, OpenFiveApiRequest.con))
            {
                SqliteDataReader reader = command.ExecuteReader();
                Debug.WriteLine(reader.ToString());
            }
            OpenFiveApiRequest.con.Close();
        }

        // TODO, first check if rarity is available, if not, use getRarity method
        public static Item Parse(string rarity = null)
        {
            Random random = new Random();
            var itemJson = randomItem(random, rarity);

            string name = (string)itemJson["name"];
            string type = (string)itemJson["type"];

            // If the retrieved item has a rarity, it will be used, else it will be random.
            var rarityToken = itemJson.SelectToken("rarity");
            string itemRarity = (string)rarityToken;
            if (rarityToken == null) itemRarity = GetRarity(random.Next(0, 5));

            int value = getValue(itemRarity, random);
            string description = (string)itemJson["description"] ?? null; // TODO: See where we can get this from
            List<string> properties = ExtractProperties(itemJson);
            List<string> drawbacks = itemJson["drawbacks"]?.ToObject<List<string>>() ?? new List<string>(); // TODO: See where we can get this from
            List<string> requirements = ExtractRequirements(itemJson, type, random);
            string history = (string)itemJson["history"] ?? null;

            return new Item(name, type, itemRarity, value, description, properties, drawbacks, requirements, history);
        }

        private static int getValue(string itemRarity, Random random)
        {
            if (itemRarity == null)
            {
                itemRarity = GetRarity(random.Next(0, 5));
            }
            itemRarity = itemRarity.ToLower();

            // Based on the rarity, gets a value that fits
            switch (itemRarity)
            {
                case "common":
                    return random.Next(50, 100);
                case "uncommon":
                    return random.Next(101, 500);
                case "rare":
                    return random.Next(501, 5000);
                case "very Rare":
                    return random.Next(5001, 50000);
                case "legendary":
                    return random.Next(50000, 1000000);
                case "artifact":
                    return 0;
                default:
                    return 0;
            }
        }

        private static string GetRarity(int randomRarity)
        {
            // If no rarity is declared, get a random rarity
            String[] rarityList = new string[] { "Common", "Uncommon", "Rare", "Very Rare", "Legendary", "Artifact" };

            // If no random rarity is specified, return null
            return rarityList[randomRarity];
        }

        private static JObject randomItem(Random random, string rarity = null)
        {

            // Declaring every possible type of item, and getting a random one
            string[] itemTypes = new string[] { "armor", "weapons", "magicitems" };
            string itemType = itemTypes[random.Next(itemTypes.Length)];

            // Make the request and return a JArray of the item
            OpenFiveApiRequest apiRequest = new OpenFiveApiRequest();
            string itemResponse;
            if (rarity != null && itemType == "magicitems") { itemResponse = apiRequest.MakeOpenFiveApiRequest(itemType, null, null, rarity); }
            else { itemResponse = apiRequest.MakeOpenFiveApiRequest(itemType); }
            JObject responseJson = JObject.Parse(itemResponse);
            JArray itemsJson = (JArray)responseJson["results"];

            // Choose a random enemy from the response
            int randomIndex = new Random().Next(0, itemsJson.Count);
            JObject itemJson = (JObject)itemsJson[randomIndex];

            if (itemType == "armor" || itemType == "weapons")
            {
                itemJson["type"] = itemType.Replace("s", "");
            }
            if (itemType != "magicitems")
            {
                itemJson["rarity"] = rarity;
            }

            return itemJson;
        }

        // Possible TO DO: add it so that if no properties are found, you can generate them
        private static List<string> ExtractProperties(JToken itemJson)
        {
            // Gets properties from an item
            JToken propertiesToken = itemJson["properties"];
            if (propertiesToken != null && propertiesToken.Any())
            {
                return ((JArray)propertiesToken).Select(p => (string)p).ToList();
            }
            else
            {
                return new List<string>();
            }
        }

        // Possible TO DO: add it so that if no requirements are found, you can generate them
        // TODO: Improve code
        private static List<string> ExtractRequirements(JToken itemJson, string Type, Random random)
        {
            // Gets requirements from an item
            JToken requirementsToken = null;

            List<string> requirementsList = new List<string>();

            // check if these exist
            requirementsToken = itemJson["requires_attunement"];
            if (requirementsToken != null)
            {
                if (requirementsToken.ToString() == "") { requirementsToken = "Yes"; }
                requirementsList.Add($"Requires Attunement: {requirementsToken}");
            }

            requirementsToken = itemJson["strength_requirement"];
            if (requirementsToken != null)
            {
                if (requirementsToken.ToString() == "") { requirementsToken = random.Next(0, 30); }
                requirementsList.Add($"Strength Requirement: {requirementsToken}");
            }

            requirementsToken = itemJson["category"];
            if (requirementsToken != null)
            {
                requirementsList.Add($"Your character should be able to wield: '{requirementsToken}'");
            }

            // If they do exist, return them in a list
            if (requirementsList.Count > 0)
            {
                return requirementsList;
            }

            return new List<string>();
        }

        public void PutItemInDatabase(Item item)
        {
            OpenFiveApiRequest.con.Open();

            string insertSql = "INSERT INTO Items ([Name], [Type], [Rarity], [Value], [Description], [Properties], [Drawbacks], [Requirements], [History]) " +
                   "VALUES (@Name, @Type, @Rarity, @Value, @Description, @Properties, @Drawbacks, @Requirements, @History)";

            using (SqliteCommand command = new SqliteCommand(insertSql, OpenFiveApiRequest.con))
            {
                command.Connection = OpenFiveApiRequest.con;

                command.Parameters.AddWithValue("@Name", item.Name);
                command.Parameters.AddWithValue("@Type", item.Type);
                command.Parameters.AddWithValue("@Rarity", item.Rarity != null ? string.Join(",", item.Description) : "");
                command.Parameters.AddWithValue("@Value", item.Value);
                command.Parameters.AddWithValue("@Description", item.Description != null ? string.Join(",", item.Description) : "");
                command.Parameters.AddWithValue("@Properties", string.Join(", ", item.Properties));
                command.Parameters.AddWithValue("@Drawbacks", item.Drawbacks != null ? string.Join(",", item.Drawbacks) : "");
                command.Parameters.AddWithValue("@Requirements", string.Join(", ", item.Requirements));
                command.Parameters.AddWithValue("@History", item.History != null ? string.Join(",", item.History) : "");

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqliteException ex)
                {
                    Debug.WriteLine("An error occurred while inserting data: " + ex.Message);
                }
            }

            OpenFiveApiRequest.con.Close();
        }
    }
}
