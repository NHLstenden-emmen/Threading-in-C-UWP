using Microsoft.Data.Sqlite;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using Threading_in_C_UWP.OpenFiveApi;
using Threading_in_C_UWP.Players;

namespace Threading_in_C_UWP.ApiGenerators
{
    internal class ApiEnemyGenerator
    {
        public ApiEnemyGenerator()
        {
            OpenFiveApiRequest.con.Open();
            String CreateTableSql = "CREATE TABLE IF NOT EXISTS Enemies (" +
                "Name            NVARCHAR (20) PRIMARY KEY," +
                "Health          INT           DEFAULT ((0)) NOT NULL," +
                "Movement        INT           DEFAULT ((0)) NOT NULL," +
                "Strength        INT           DEFAULT ((0)) NOT NULL," +
                "Dexterity       INT           DEFAULT ((0)) NOT NULL," +
                "Constitution    INT           DEFAULT ((0)) NOT NULL," +
                "Intelligence    INT           DEFAULT ((0)) NOT NULL," +
                "Wisdom          INT           DEFAULT ((0)) NOT NULL," +
                "Charisma        INT           DEFAULT ((0)) NOT NULL," +
                "ArmorRating     INT           DEFAULT ((0)) NOT NULL," +
                "Proficiency     INT           DEFAULT ((0)) NOT NULL," +
                "Size            VARCHAR (50)  DEFAULT ((1)) NOT NULL," +
                "Type            VARCHAR (50)  NULL," +
                "ChallengeRating VARCHAR (50) NULL);";
            using (SqliteCommand command = new SqliteCommand(CreateTableSql, OpenFiveApiRequest.con))
            {
                SqliteDataReader reader = command.ExecuteReader();
                Debug.WriteLine(reader.ToString());
            }
            OpenFiveApiRequest.con.Close();
        }

        // Changes the API response into an enemy
        public static Enemy Parse(int? ChallengeRating = null)
        {
            Random random = new Random();
            OpenFiveApiRequest apiRequest = new OpenFiveApiRequest();
            string enemyResponse;

            if (ChallengeRating != null) { enemyResponse = apiRequest.MakeOpenFiveApiRequest("monsters", null, ChallengeRating); }
            else { enemyResponse = apiRequest.MakeOpenFiveApiRequest("monsters", random.Next(1, 50)); }

            JObject responseJson = JObject.Parse(enemyResponse);
            JArray enemiesJson = (JArray)responseJson["results"];

            // Choose a random enemy from the response
            int randomIndex = new Random().Next(0, enemiesJson.Count);
            JObject enemyJson = (JObject)enemiesJson[randomIndex];

            string name = (string)enemyJson["name"];

            int health = (int)enemyJson["hit_points"];
            int movement = (int)enemyJson["speed"]["walk"];

            int strength = (int)enemyJson["strength"];
            int dexterity = (int)enemyJson["dexterity"];
            int constitution = (int)enemyJson["constitution"];
            int intelligence = (int)enemyJson["intelligence"];
            int wisdom = (int)enemyJson["wisdom"];
            int charisma = (int)enemyJson["charisma"];

            int ar = (int)enemyJson["armor_class"];
            int bp = 0; // TODO consult Kevin to talk about proficiency

            string cr = (string)enemyJson["challenge_rating"];

            string size = (string)enemyJson["size"];
            string type = (string)enemyJson["type"];

            // Return the chosen enemy
            return new Enemy(name, health, movement, strength, dexterity, constitution, intelligence, wisdom, charisma, ar, bp, cr, size, type);
        }


        public void PutEnemyInDatabase(Enemy enemy)
        {
            OpenFiveApiRequest.con.Open();

            string insertSql = "INSERT INTO Enemies ([Name], [Health], [Movement], [Strength], [Dexterity], [Constitution], [Intelligence], [Wisdom], [Charisma], [ArmorRating], [Proficiency], [Size], [Type], [ChallengeRating]) " +
                   "VALUES (@Name, @Health, @Movement, @Strength, @Dexterity, @Constitution, @Intelligence, @Wisdom, @Charisma, @ArmorRating, @Proficiency, @Size, @Type, @ChallengeRating)";


            using (SqliteCommand command = new SqliteCommand(insertSql, OpenFiveApiRequest.con))
            {
                command.Connection = OpenFiveApiRequest.con;

                command.Parameters.AddWithValue("@Name", enemy.Name);
                command.Parameters.AddWithValue("@Health", enemy.Health);
                command.Parameters.AddWithValue("@Movement", enemy.Movement);
                command.Parameters.AddWithValue("@Strength", enemy.Strength);
                command.Parameters.AddWithValue("@Dexterity", enemy.Dexterity);
                command.Parameters.AddWithValue("@Constitution", enemy.Constitution);
                command.Parameters.AddWithValue("@Intelligence", enemy.Intelligence);
                command.Parameters.AddWithValue("@Wisdom", enemy.Wisdom);
                command.Parameters.AddWithValue("@Charisma", enemy.Charisma);
                command.Parameters.AddWithValue("@ArmorRating", enemy.AR);
                command.Parameters.AddWithValue("@Proficiency", enemy.BP);
                command.Parameters.AddWithValue("@Size", enemy.Size);
                command.Parameters.AddWithValue("@Type", enemy.Type);
                command.Parameters.AddWithValue("@ChallengeRating", enemy.CR);

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
