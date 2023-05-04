using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Threading_in_C_UWP.ApiGenerators;
using Threading_in_C_UWP.Board;
using Threading_in_C_UWP.OpenFiveApi;
using Threading_in_C_UWP.Players;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Threading_in_C_UWP.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NpcScreenForm : Page
    {
        private List<NPC> npcs = new List<NPC>();
        private int numThreads = 0;
        private Mutex dbMutex = new Mutex();
        ApiNpcGenerator apiNpcGenerator = new ApiNpcGenerator();

        public NpcScreenForm()
        {
            InitializeComponent();
            RetrieveNpcsFromDatabase();
            AddNpcsToList();

            for (int i = 1; i <= 100; i++)
            {
                AmountOfNPCs.Items.Add(i);
            }
            AmountOfNPCs.SelectedIndex = 0;
        }

        // Retrieves all the npcs from the db and puts them in the npcs list
        private void RetrieveNpcsFromDatabase()
        {
            OpenFiveApiRequest.con.Open();
            npcs.Clear();
            SavedNpcsListBox.Items.Clear();

            string retrieveSQL = "SELECT * FROM NPCs";
            using (SqliteCommand command = new SqliteCommand(retrieveSQL, OpenFiveApiRequest.con))
            {
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        List<string> traits = new List<string>();
                        string[] traitStrings = reader["Traits"].ToString().Split(';');
                        foreach (string traitString in traitStrings)
                        {
                            traits.Add(traitString);
                        }

                        NPC npc = new NPC
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
                            reader["Race"].ToString(),
                            reader["Class"].ToString(),
                            reader["Backstory"].ToString(),
                            traits
                        );
                        npcs.Add(npc);
                    }
                }
            }

            OpenFiveApiRequest.con.Close();
        }

        // Displays all the npcs in the npcs list in the list box
        private void AddNpcsToList()
        {
            foreach (NPC npc in npcs)
            {
                // Add the player to the ListBox control
                SavedNpcsListBox.Items.Add(npc.ToString());
            }
        }

        private void RefreshSavedNpcs_Click(object sender, EventArgs e)
        {
            RetrieveNpcsFromDatabase();
            AddNpcsToList();
        }

        private void GenerateNPCButton_Click(object sender, RoutedEventArgs e)
        {
            CreateThreads((int)AmountOfNPCs.SelectedIndex + 1);
            CleanupThreads();
        }

        private bool NpcExistsInDatabase(string NpcName)
        {
            bool npcExists = false;
            dbMutex.WaitOne(); // acquire the mutex
            try
            {
                OpenFiveApiRequest.con.Open();
                string retrieveSQL = "SELECT * FROM NPCs WHERE Name = @NpcName";
                using (SqliteCommand command = new SqliteCommand(retrieveSQL, OpenFiveApiRequest.con))
                {
                    command.Parameters.AddWithValue("@NpcName", NpcName);
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            npcExists = true;
                        }
                    }
                }
                OpenFiveApiRequest.con.Close();
            }
            finally
            {
                dbMutex.ReleaseMutex(); // release the mutex
            }
            return npcExists;
        }

        // Method that tries to get a unique enemy up to three times
        private void PutNewNpcInDatabase(NPC npc)
        {
            bool npcExist = NpcExistsInDatabase(npc.Name);
            if (!npcExist)
            {
                ApiNpcGenerator.PutNPCInDatabase(npc);
            }
            else
            {
                int attempts = 0;
                NPC newNpc;
                do
                {
                    newNpc = ApiNpcGenerator.Parse();
                    npcExist = NpcExistsInDatabase(newNpc.Name);
                    attempts++;
                } while (npcExist && attempts < 3);

                if (!npcExist)
                {
                    ApiNpcGenerator.PutNPCInDatabase(newNpc);
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
            var npc = ApiNpcGenerator.Parse();
            dbMutex.WaitOne(); // acquire the mutex
            try
            {
                // tries to get a unique enemy up to three times
                PutNewNpcInDatabase(npc);
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
                RetrieveNpcsFromDatabase();
                AddNpcsToList();
            }
        }

        private void DeleteNPC_Click(object sender, RoutedEventArgs e)
        {
            string deleteSQL = "DELETE FROM NPCs";
            using (SqliteCommand command = new SqliteCommand(deleteSQL, OpenFiveApiRequest.con))
            {
                OpenFiveApiRequest.con.Open();
                command.ExecuteNonQuery();
                OpenFiveApiRequest.con.Close();
            }
            RetrieveNpcsFromDatabase();
            AddNpcsToList();
        }

        private void NpcScreenForm_Load(object sender, EventArgs e)
        {

        }

        private void SavedNPCsListBox_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            PlayerBoard.instance.placePlaceableOnPossibleTile(npcs[index]);
        }
    }
}
