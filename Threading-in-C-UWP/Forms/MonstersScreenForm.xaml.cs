using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Threading;
using Threading_in_C_UWP.ApiGenerators;
using Threading_in_C_UWP.Board;
using Threading_in_C_UWP.OpenFiveApi;
using Threading_in_C_UWP.Players;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Threading_in_C_UWP.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MonstersScreenForm : Page
    {
        private List<Enemy> enemies = new List<Enemy>();
        private int numThreads = 0;
        private Mutex dbMutex = new Mutex();
        ApiEnemyGenerator apiEnemyGenerator;

        public MonstersScreenForm()
        {
            apiEnemyGenerator= new ApiEnemyGenerator();
            InitializeComponent();
            RetrieveEnemiesFromDatabase();
            AddEnemiesToList();
        }

        // Retrieves all the enemies from the db and puts them in the enemies list
        private void RetrieveEnemiesFromDatabase()
        {
            OpenFiveApiRequest.con.Open();
            enemies.Clear();
            SavedMonstersListBox.Items.Clear();

            string retrieveSqlite = "SELECT * FROM Enemies";
            using (SqliteCommand command = new SqliteCommand(retrieveSqlite, OpenFiveApiRequest.con))
            {
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Enemy enemy = new Enemy
                        (
                            reader["Name"].ToString(),
                            (int)(long)reader["Health"],
                            (int)(long)reader["Movement"],
                            (int)(long)reader["Strength"],
                            (int)(long)reader["Dexterity"],
                            (int)(long)reader["Constitution"],
                            (int)(long)reader["Intelligence"],
                            (int)(long)reader["Wisdom"],
                            (int)(long)reader["Charisma"],
                            (int)(long)reader["ArmorRating"],
                            (int)(long)reader["Proficiency"],
                            reader["ChallengeRating"].ToString(),
                            reader["Size"].ToString(),
                            reader["Type"].ToString()
                        );
                        enemies.Add(enemy);
                    }
                }
            }

            OpenFiveApiRequest.con.Close();
        }

        // Displays all the enemies in the enemies list in the list box
        private void AddEnemiesToList()
        {
            foreach (Enemy enemy in enemies)
            {
                // Add the player to the ListBox control
                SavedMonstersListBox.Items.Add(enemy.ToString());
            }
        }

        private void RefreshSavedEnemies_Click(object sender, EventArgs e)
        {
            RetrieveEnemiesFromDatabase();
            AddEnemiesToList();
        }

        private void GenerateMonsterButton_Click(object sender, RoutedEventArgs e)
        {
            CreateThreads((int)Int32.Parse(AmountOfMonsters.Text));
            CleanupThreads();
        }

        private bool EnemyExistsInDatabase(string enemyName)
        {
            bool enemyExists = false;
            dbMutex.WaitOne(); // acquire the mutex
            try
            {
                OpenFiveApiRequest.con.Open();
                string retrieveSqlite = "SELECT * FROM Enemies WHERE Name = @EnemyName";
                using (SqliteCommand command = new SqliteCommand(retrieveSqlite, OpenFiveApiRequest.con))
                {
                    command.Parameters.AddWithValue("@EnemyName", enemyName);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            enemyExists = true;
                        }
                    }
                }
                OpenFiveApiRequest.con.Close();
            }
            finally
            {
                dbMutex.ReleaseMutex(); // release the mutex
            }
            return enemyExists;
        }

        // Method that tries to get a unique enemy up to three times
        private void PutNewEnemyInDatabase(Enemy enemy)
        {
            bool enemyExist = EnemyExistsInDatabase(enemy.Name);
            if (!enemyExist)
            {
                apiEnemyGenerator.PutEnemyInDatabase(enemy);
            }
            else
            {
                int attempts = 0;
                Enemy newEnemy;
                do
                {
                    newEnemy = ApiEnemyGenerator.Parse();
                    enemyExist = EnemyExistsInDatabase(newEnemy.Name);
                    attempts++;
                } while (enemyExist && attempts < 3);

                if (!enemyExist)
                {
                    apiEnemyGenerator.PutEnemyInDatabase(newEnemy);
                }
            }
        }

        private void CreateThreads(int numThreadsToCreate)
        {
            for (int i = 0; i < numThreadsToCreate; i++)
            {
                Interlocked.Increment(ref numThreads);
                ManualResetEventSlim threadExitEvent = new ManualResetEventSlim(false);
                Thread t = new Thread(() => PerformTask(threadExitEvent));
                t.Start();
            }
        }

        private void PerformTask(ManualResetEventSlim threadExitEvent)
        {
            // create enemy
            var enemy = ApiEnemyGenerator.Parse();
            dbMutex.WaitOne(); // acquire the mutex
            try
            {
                // tries to get a unique enemy up to three times
                PutNewEnemyInDatabase(enemy);
            }
            finally
            {
                dbMutex.ReleaseMutex(); // release the mutex
            }

            // Signal the thread to exit
            Interlocked.Decrement(ref numThreads);
            threadExitEvent.Set();
        }

        private void CleanupThreads()
        {
            // Wait for all threads to exit
            while (numThreads > 0)
            {
                Thread.Sleep(10);
            }

            if (numThreads == 0)
            {
                RetrieveEnemiesFromDatabase();
                AddEnemiesToList();
            }
        }

        private void DeleteMonster_Click(object sender, RoutedEventArgs e)
        {
            string deleteSqlite = "DELETE FROM Enemies";
            using (SqliteCommand command = new SqliteCommand(deleteSqlite, OpenFiveApiRequest.con))
            {
                OpenFiveApiRequest.con.Open();
                command.ExecuteNonQuery();
                OpenFiveApiRequest.con.Close();
            }
            RetrieveEnemiesFromDatabase();
            AddEnemiesToList();
        }
        private void SavedMonstersListBox_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            PlayerBoard.instance.placePlaceableOnPossibleTile(enemies[index]);
        }
    }
}
