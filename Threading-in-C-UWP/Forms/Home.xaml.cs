using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Threading_in_C_UWP.ApiGenerators;
using Threading_in_C_UWP.OpenFiveApi;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Threading_in_C_UWP.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        private readonly OpenFiveApiRequest apiRequest = new OpenFiveApiRequest();
        private ApiEnemyGenerator apiEnemyGenerator = new ApiEnemyGenerator();
        private ApiNpcGenerator apiNpcGenerator = new ApiNpcGenerator();
        private ApiItemGenerator apiItemGenerator = new ApiItemGenerator();
        int createdGroupBoxes = 1;
        Random rand = new Random();
        Dictionary<string, Dictionary<string, List<int>>> rollValues = new Dictionary<string, Dictionary<string, List<int>>>();
        List<Thread> threads = new List<Thread>();


        public Home()
        {
            InitializeComponent();
            InitateComboBoxes();
            UpdateComboBoxValue();
        }

        private void InitateComboBoxes()
        {
            foreach (UIElement item in HomeGrid.Children)
            {
                if (item.GetType() == typeof(Grid)) { 
                    Grid itemGrid= (Grid)item;
                    foreach (UIElement itemInGrid in itemGrid.Children)
                    {
                        if (itemInGrid.GetType() == typeof(ComboBox))
                        {
                            ComboBox comboBox = (ComboBox)itemInGrid;
                            for (int i = 0; i < 100; i++)
                            {
                                comboBox.Items.Add(i);
                            }
                            comboBox.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void UpdateComboBoxValue()
        {
            comboBoxDiceRoll1.Items.Clear();
            // Fill the combobox with the enemies
            SqliteConnection connection = OpenFiveApiRequest.con;
            connection.Open();
            SqliteCommand allEnemiesAndNPCs = new SqliteCommand("SELECT Name FROM Enemies UNION SELECT Name FROM NPCs", connection);
            SqliteDataReader reader = allEnemiesAndNPCs.ExecuteReader();
            while (reader.Read())
            {
                // Add each player name to the ComboBox
                string playerName = reader.GetString(0);
                comboBoxDiceRoll1.Items.Add(playerName);
            }
            // Close the connection and dispose of the command and reader objects
            reader.Close();
            allEnemiesAndNPCs.Dispose();
            connection.Close();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnRollDice_Click(object sender, RoutedEventArgs e)
        {
            rollValues.Clear();

            for (int i = 1; i <= createdGroupBoxes; i++)
            {
                string nameComboBox = "comboBoxDiceRoll" + i.ToString();
                ComboBox comboBox = (ComboBox)this.FindName(nameComboBox);
                String comboBoxName = "";
                if (comboBox.SelectedValue != null)
                {
                    comboBoxName = comboBox.SelectedValue.ToString();
                }

                int[] diceValues = { 4, 6, 8, 10, 12, 20, 100 };

                // check if any of the dice have a value
                bool hasValue = false;
                foreach (int diceValue in diceValues)
                {
                    string comboBoxDiceName = "comboBoxD" + diceValue.ToString() + "Roll" + i.ToString();
                    int value = (int)((ComboBox)this.FindName(comboBoxDiceName)).SelectedIndex;
                    if (value > 0)
                    {
                        if (!rollValues.ContainsKey(comboBoxName))
                        {
                            rollValues.Add(comboBoxName, new Dictionary<string, List<int>>());
                        }
                        hasValue = true;
                        int tag = Convert.ToInt32(((ComboBox)this.FindName(comboBoxDiceName)).Tag);

                        // nieuwe thread for nieuwe dice rolls
                        Thread thread = new Thread(() => RollDice(comboBoxName, diceValue, i, value, tag));
                        threads.Add(thread);
                        thread.Start();
                    }
                }

                // if none of the dice have a value, skip the comboBox
                if (!hasValue)
                {
                    continue;
                }
            }

            // wait for all the threads to finish before moving on
            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            DisplayRollValueText();
        }

        private void DisplayRollValueText()
        {
            //create a new string builder to store the results
            StringBuilder sb = new StringBuilder();


            // loop through the rollValues dictionary
            foreach (string comboBoxName in rollValues.Keys)
            {
                sb.AppendLine(comboBoxName + ":");

                foreach (string dice in rollValues[comboBoxName].Keys)
                {
                    sb.AppendLine("" + dice + ": " + string.Join(", ", rollValues[comboBoxName][dice]));
                }

                sb.AppendLine();
            }

            // display the results in a multi-line text box or list box
            RichEditBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, sb.ToString());
        }

        // method to roll the dice and add the values to the dictionary
        private void RollDice(string comboBoxName, int diceValue, int i, int value, int tag)
        {
            Random rand = new Random();
            List<int> rolls = new List<int>();

            // generate the random numbers
            for (int k = 0; k < value; k++)
            {
                int roll = rand.Next(1, tag);
                rolls.Add(roll);
            }

            // add the rolls to the dictionary
            lock (rollValues)
            {
                if (!rollValues[comboBoxName].ContainsKey("D" + tag))
                {
                    rollValues[comboBoxName].Add("D" + tag, new List<int>());
                }

                rollValues[comboBoxName]["D" + tag].AddRange(rolls);
            }
        }

        private async void btnAddNewDiceRoll_Click(object sender, RoutedEventArgs e)
        {
            Grid gridCopy = new Grid();
            if (createdGroupBoxes < 4)
            {
                // Left row
                gridCopy.Margin= new Thickness(ComboboxGrid1.Margin.Left, ComboboxGrid1.Margin.Top + 130 * createdGroupBoxes, ComboboxGrid1.Margin.Right, ComboboxGrid1.Margin.Bottom) ;
            }
            else if (createdGroupBoxes < 8)
            {
                // Right row
                gridCopy.Margin = new Thickness(ComboboxGrid1.Margin.Left + 450, ComboboxGrid1.Margin.Top + 130 * (createdGroupBoxes - 4), ComboboxGrid1.Margin.Right - 400, ComboboxGrid1.Margin.Bottom - 130 * (createdGroupBoxes - 4));
            }
            else
            {
                ContentDialog maxRollsDialog = new ContentDialog()
                {
                    Title = "Error!",
                    Content = "New group can't be added \r\nMax amount of groups reached",
                    CloseButtonText = "Ok"
                };
                await maxRollsDialog.ShowAsync();
                return;
            }
            createdGroupBoxes++;

            gridCopy.Height = ComboboxGrid1.Height;
            gridCopy.Width = ComboboxGrid1.Width;
            gridCopy.HorizontalAlignment = ComboboxGrid1.HorizontalAlignment;
            gridCopy.VerticalAlignment = ComboboxGrid1.VerticalAlignment;
            gridCopy.Name = "ComboboxGrid" + createdGroupBoxes;

            HomeGrid.Children.Add(gridCopy);
            foreach (UIElement itemInGrid in ComboboxGrid1.Children)
            {
                UIElement newItem = (UIElement)Activator.CreateInstance(itemInGrid.GetType());
                if (newItem.GetType() == typeof(ComboBox)) 
                {
                    ((ComboBox)newItem).Margin = ((ComboBox)itemInGrid).Margin;
                    ((ComboBox)newItem).Name = ((ComboBox)itemInGrid).Name.Substring(0, ((ComboBox)itemInGrid).Name.Length - 1) + createdGroupBoxes;
                    ((ComboBox)newItem).Tag = ((ComboBox)itemInGrid).Tag;
                    ((ComboBox)newItem).Width = ((ComboBox)itemInGrid).Width;
                    ((ComboBox)newItem).Height = ((ComboBox)itemInGrid).Height;
                    ((ComboBox)newItem).HorizontalAlignment = ((ComboBox)itemInGrid).HorizontalAlignment;
                    ((ComboBox)newItem).VerticalAlignment = ((ComboBox)itemInGrid).VerticalAlignment;
                    foreach (var dropdownItem in ((ComboBox)itemInGrid).Items)
                    {
                        ((ComboBox)newItem).Items.Add(dropdownItem);
                    }
                    ((ComboBox)newItem).SelectedIndex = 0;
                }else if (newItem.GetType() == typeof(Image))
                {
                    ((Image)newItem).Margin = ((Image)itemInGrid).Margin;
                    ((Image)newItem).Width = ((Image)itemInGrid).Width;
                    ((Image)newItem).Height = ((Image)itemInGrid).Height;
                    ((Image)newItem).HorizontalAlignment = ((Image)itemInGrid).HorizontalAlignment;
                    ((Image)newItem).VerticalAlignment = ((Image)itemInGrid).VerticalAlignment;
                    ((Image)newItem).Source = ((Image)itemInGrid).Source;
                }

                gridCopy.Children.Add(newItem);
            }
        }
    }
}