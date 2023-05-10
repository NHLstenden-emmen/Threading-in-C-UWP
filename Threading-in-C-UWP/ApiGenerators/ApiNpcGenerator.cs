using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Threading_in_C_UWP.OpenFiveApi;
using Threading_in_C_UWP.Players;

namespace Threading_in_C_UWP.ApiGenerators
{
    internal class ApiNpcGenerator
    {
        public ApiNpcGenerator()
        {
            OpenFiveApiRequest.con.Open();
            String CreateTableSql = "CREATE TABLE IF NOT EXISTS NPCs (" +
                "Name           NVARCHAR (20)   PRIMARY KEY," +
                "Health         INT             DEFAULT((0)) NOT NULL," +
                "Movement       INT             DEFAULT((0)) NOT NULL," +
                "Strength       INT             DEFAULT((0)) NOT NULL," +
                "Dexterity      INT             DEFAULT((0)) NOT NULL," +
                "Constitution   INT             DEFAULT((0)) NOT NULL," +
                "Intelligence   INT             DEFAULT((0)) NOT NULL," +
                "Wisdom         INT             DEFAULT((0)) NOT NULL," +
                "Charisma       INT             DEFAULT((0)) NOT NULL," +
                "ArmorRating    INT             DEFAULT((0)) NOT NULL," +
                "Proficiency    INT             DEFAULT((0)) NOT NULL," +
                "Race           VARCHAR(255)    NULL," +
                "Class          VARCHAR(50)    NULL," +
                "Backstory      VARCHAR(255)    NULL," +
                "Traits         VARCHAR(255)    NULL);";
            using (SqliteCommand command = new SqliteCommand(CreateTableSql, OpenFiveApiRequest.con))
            {
                SqliteDataReader reader = command.ExecuteReader();
            }
            OpenFiveApiRequest.con.Close();
        }
        public static NPC Parse()
        {
            string name = GenerateName();

            var (randomRace, randomSpeed, randomTraits) = GetRandomRace();

            Random random = new Random();
            int health = random.Next(401);
            int movement = randomSpeed;
            int strength = random.Next(31);
            int dexterity = random.Next(31);
            int constitution = random.Next(31);
            int intelligence = random.Next(31);
            int wisdom = random.Next(31);
            int charisma = random.Next(31);

            int ar = random.Next(31);
            int bp = 0;

            string race = randomRace;
            string characterClass = GetRandomClassAspects();
            string backstory = getBackstory();
            List<string> traits = randomTraits;

            NPC randomNPC = new NPC(name, health, movement, strength, dexterity, constitution, intelligence, wisdom, charisma, ar, bp, race, characterClass, backstory, traits);

            // Returns a NPC
            return randomNPC;
        }

        public static string getBackstory()
        {
            // At the moment the open five api only has 3 backstories
            OpenFiveApiRequest apiRequest = new OpenFiveApiRequest();
            var backstoryResponse = apiRequest.MakeOpenFiveApiRequest("backgrounds");

            // Parse the available backstories
            var backstories = JObject.Parse(backstoryResponse)["results"].Select(c => (string)c["desc"]).ToList();

            return backstories[new Random().Next(backstories.Count)];
        }

        // New method, now also using LINQ
        public static string GetRandomClassAspects()
        {
            OpenFiveApiRequest apiRequest = new OpenFiveApiRequest();
            var classResponse = apiRequest.MakeOpenFiveApiRequest("classes");
            var classes = JObject.Parse(classResponse)["results"].Select(c => (string)c["name"]).ToList();

            /* Select, Using the Select method to extract the "name" property of each object in the "results" array.
             * is a linq method, aswell as converting the result into a List using ToList. */
            return classes[new Random().Next(classes.Count)];
        }

        // Returns a tuple containing a random race, its speed, and its traits.
        public static (string race, int speed, List<string> traits) GetRandomRace()
        {
            OpenFiveApiRequest apiRequest = new OpenFiveApiRequest();
            var raceResponse = apiRequest.MakeOpenFiveApiRequest("races");

            var races = new List<string>();
            var parsedResponse = JObject.Parse(raceResponse);

            // Loop through each race 
            foreach (var race in parsedResponse["results"])
            {
                var raceName = (string)race["name"];
                races.Add(raceName);

                // If the race has subraces add it to the list of races.
                if (race["subraces"].Any())
                {
                    foreach (var subrace in race["subraces"])
                    {
                        var subraceName = (string)subrace["name"];
                        races.Add($"{raceName} - {subraceName}");
                    }
                }
            }

            // Select a random race 
            var selectedRace = races[new Random().Next(races.Count)];

            // Acceses the results, first or default is a LING method to search the array for an object with an equal name to the selected race           
            var raceObject = parsedResponse["results"].FirstOrDefault(r => (string)r["name"] == selectedRace);
            var speed = (int)(raceObject?["speed"]["walk"] ?? 20);
            var traits = new List<string>();

            // It can take a while to get all the traits, maybe implement waiting functionality
            if (raceObject != null)
            {
                traits.Add((string)raceObject["traits"]);
                foreach (var subrace in raceObject["subraces"])
                {
                    traits.Add((string)subrace["traits"]);
                }
            }

            return (selectedRace, speed, traits);
        }

        public static string GenerateName()
        {
            Random rand = new Random();

            // Define arrays of vowels and consonants
            string[] vowels = { "a", "e", "i", "o", "u" };
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string firstName = "";
            string lastName = "";

            // Generate a random length
            int firstNameLength = rand.Next(5, 10);
            int lastNameLength = rand.Next(5, 10);

            // Generate a random vowel 
            bool firstIsVowel = rand.Next(2) == 0;
            bool secondIsVowel = rand.Next(2) == 0;

            // Loop through the characters and add a vowel or consonant based on isVowel
            for (int i = 0; i < firstNameLength; i++)
            {
                if (firstIsVowel) firstName += vowels[rand.Next(vowels.Length)];
                else firstName += consonants[rand.Next(consonants.Length)];

                firstIsVowel = !firstIsVowel;
            }

            for (int i = 0; i < lastNameLength; i++)
            {
                if (secondIsVowel) lastName += vowels[rand.Next(vowels.Length)];
                else lastName += consonants[rand.Next(consonants.Length)];

                secondIsVowel = !secondIsVowel;
            }

            // character uppercase
            return char.ToUpper(firstName[0]) + firstName.Substring(1) + " " + char.ToUpper(lastName[0]) + lastName.Substring(1);
        }

        public static void PutNPCInDatabase(NPC npc)
        {
            OpenFiveApiRequest.con.Open();

            string insertsqlite = "INSERT INTO NPCs ([Name], [Health], [Movement], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [ArmorRating], [Proficiency], [Race], [Class], [Backstory]) " +
                   "VALUES (@Name, @Health, @Movement, @Strength, @Dexterity, @Constitution, @Intelligence, @Wisdom, @Charisma, @ArmorRating, @Proficiency, @Race, @Class, @Backstory)";

            using (SqliteCommand command = new SqliteCommand(insertsqlite, OpenFiveApiRequest.con))
            {
                command.Connection = OpenFiveApiRequest.con;

                command.Parameters.AddWithValue("@Name", npc.Name);
                command.Parameters.AddWithValue("@Health", npc.Health);
                command.Parameters.AddWithValue("@Movement", npc.Movement);
                command.Parameters.AddWithValue("@Strength", npc.Strength);
                command.Parameters.AddWithValue("@Dexterity", npc.Dexterity);
                command.Parameters.AddWithValue("@Constitution", npc.Constitution);
                command.Parameters.AddWithValue("@Intelligence", npc.Intelligence);
                command.Parameters.AddWithValue("@Wisdom", npc.Wisdom);
                command.Parameters.AddWithValue("@Charisma", npc.Charisma);
                command.Parameters.AddWithValue("@ArmorRating", npc.AR);
                command.Parameters.AddWithValue("@Proficiency", npc.BP);
                command.Parameters.AddWithValue("@Race", npc.Race);
                command.Parameters.AddWithValue("@Class", npc.Class);
                command.Parameters.AddWithValue("@Backstory", npc.Backstory);

                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqliteException ex)
                {
                    Console.WriteLine("An error occurred while inserting data: " + ex.Message);
                }
            }

            OpenFiveApiRequest.con.Close();
        }
    }
}
