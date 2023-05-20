using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Threading_in_C_UWP.ApiGenerators;
using Threading_in_C_UWP.Board;
using Threading_in_C_UWP.Equipment;
using Threading_in_C_UWP.OpenFiveApi;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Threading_in_C_UWP.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LootScreenForm : Page
    {
        private List<Item> items = new List<Item>();
        private ManualResetEvent threadExitEvent = new ManualResetEvent(false);
        private int numThreads = 0;
        private Mutex dbMutex = new Mutex();
        ApiItemGenerator apiItemGenerator = new ApiItemGenerator();

        public LootScreenForm()
        {
            this.InitializeComponent();
            RetrieveItemsFromDatabase();
            AddItemsToList();

            for (int i = 1; i <= 100; i++)
            {
                AmountOfItems.Items.Add(i);
            }
            AmountOfItems.SelectedIndex = 0;
        }

        // Retrieves all the items from the db and puts them in the items list
        private void RetrieveItemsFromDatabase()
        {
            OpenFiveApiRequest.con.Open();
            items.Clear();
            SavedItemsListBox.Items.Clear();

            string retrieveSQL = "SELECT * FROM Items";
            using (SqliteCommand command = new SqliteCommand(retrieveSQL, OpenFiveApiRequest.con))
            {
                try
                {
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            List<string> properties = new List<string>();
                            string[] propertiesStrings = reader["Properties"].ToString().Split(';');
                            foreach (string propertiesString in propertiesStrings)
                            {
                                properties.Add(propertiesString);
                            }

                            List<string> drawbacks = new List<string>();
                            string[] drawbacksStrings = reader["Drawbacks"].ToString().Split(';');
                            foreach (string drawbacksString in drawbacksStrings)
                            {
                                drawbacks.Add(drawbacksString);
                            }

                            List<string> requirements = new List<string>();
                            string[] requirementsStrings = reader["Requirements"].ToString().Split(';');
                            foreach (string requirementsString in requirementsStrings)
                            {
                                requirements.Add(requirementsString);
                            }

                            Item item = new Item
                            (
                                reader["Name"].ToString(),
                                reader["Type"].ToString(),
                                reader["Rarity"].ToString(),
                                (int)(long)reader["Value"],
                                reader["Description"].ToString(),
                                properties,
                                drawbacks,
                                requirements,
                                reader["history"].ToString()
                            );
                            items.Add(item);
                        }
                    }
                }
                catch (SqliteException e)
                {
                }
            }

            OpenFiveApiRequest.con.Close();
        }

        // Displays all the items in the items list in the list box
        private void AddItemsToList()
        {
            foreach (Item item in items)
            {
                // Add the item to the ListBox control
                SavedItemsListBox.Items.Add(item.ToString());
            }
        }

        private void RefreshSavedItems_Click(object sender, EventArgs e)
        {
            RetrieveItemsFromDatabase();
            AddItemsToList();
        }

        private void GenerateItemButton_Click(object sender, RoutedEventArgs e)
        {
            CreateThreads(AmountOfItems.SelectedIndex + 1);
            CleanupThreads();
        }

        private bool ItemExistsInDatabase(string ItemName)
        {
            bool itemExists = false;
            dbMutex.WaitOne(); // acquire the mutex
            try
            {
                OpenFiveApiRequest.con.Open();
                string retrieveSQL = "SELECT * FROM Items WHERE Name = @ItemName";
                using (SqliteCommand command = new SqliteCommand(retrieveSQL, OpenFiveApiRequest.con))
                {
                    command.Parameters.AddWithValue("@ItemName", ItemName);
                    try
                    {
                        using (SqliteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                itemExists = true;
                            }
                        }
                    }
                    catch (SqliteException e)
                    {
                        return false;
                    }
                }
                OpenFiveApiRequest.con.Close();
            }
            finally
            {
                dbMutex.ReleaseMutex(); // release the mutex
            }
            return itemExists;
        }

        // Method that tries to get a unique item up to three times
        private void PutNewItemInDatabase(Item item)
        {
            bool itemExist = ItemExistsInDatabase(item.Name);
            if (!itemExist)
            {
                apiItemGenerator.PutItemInDatabase(item);
            }
            else
            {
                int attempts = 0;
                Item newItem;
                do
                {
                    newItem = ApiItemGenerator.Parse();
                    itemExist = ItemExistsInDatabase(item.Name);
                    attempts++;
                } while (itemExist && attempts < 3);

                if (!itemExist)
                {
                    apiItemGenerator.PutItemInDatabase(newItem);
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
            // create item
            var item = ApiItemGenerator.Parse();
            dbMutex.WaitOne(); // acquire the mutex
            try
            {
                // tries to get a unique item up to three times
                PutNewItemInDatabase(item);
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
                RetrieveItemsFromDatabase();
                AddItemsToList();
            }
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            string deleteSQL = "DELETE FROM Items";
            using (SqliteCommand command = new SqliteCommand(deleteSQL, OpenFiveApiRequest.con))
            {
                OpenFiveApiRequest.con.Open();
                command.ExecuteNonQuery();
                OpenFiveApiRequest.con.Close();
            }
            RetrieveItemsFromDatabase();
            AddItemsToList();
        }

        private async void SavedItemsListBox_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            await PlayerBoard.instance.DisplayLootTextAsync(items, this.SavedItemsListBox.SelectedIndex);
        }
    }
}
