using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Threading_in_C_UWP.Board;
using Threading_in_C_UWP.Players;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
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
    
    public sealed partial class PlayerScreenForm : Page
    {
        private List<Player> players = new List<Player>();
        private int playerIndex = 0;
        public PlayerScreenForm()
        {
            this.InitializeComponent();
            InitateComboBoxes();
        }


        private void InitateComboBoxes()
        {
            foreach (UIElement item in PlayerGrid.Children)
            {
                if (item.GetType() == typeof(ComboBox))
                {
                    
                    ComboBox comboBox = (ComboBox)item;
                    for (int i = 0; i <= 20; i++)
                    {
                        comboBox.Items.Add(i);
                    }
                    comboBox.SelectedIndex = 0;
                }
            }
            for (int i = 21; i <= 30; i++)
            {
                InputLevel.Items.Add(i);
            }
            
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            var existingPlayer = players.FirstOrDefault(p => p.Name == InputName.Text);

            if (existingPlayer != null)
            {
                if ((String)AddPlayerButton.Content == "Register Character")
                {
                    return;
                }
                var player = players[PlayerListbox.SelectedIndex];
                PlayerListbox.Items.Remove(player.ToString());

                existingPlayer.Health = InputHealth.SelectedIndex;
                existingPlayer.Movement = InputMovement.SelectedIndex;
                existingPlayer.PlayerLevel = InputLevel.SelectedIndex;
                existingPlayer.Strength = InputStrength.SelectedIndex;
                existingPlayer.Dexterity = InputDexterity.SelectedIndex;
                existingPlayer.Constitution = InputConstitution.SelectedIndex;
                existingPlayer.Intelligence = InputIntelligence.SelectedIndex;
                existingPlayer.Wisdom = InputWisdom.SelectedIndex;
                existingPlayer.Charisma = InputCharisma.SelectedIndex;
                existingPlayer.AR = InputArmorRating.SelectedIndex;
                existingPlayer.BP = InputProficiency.SelectedIndex;
                existingPlayer.Race = InputRace.Text;
                existingPlayer.Class = InputClass.Text;

                AddPlayerButton.Content = "Register Character";
                PlayerListbox.Items.Insert(player.PlayerIndex, player.ToString());
                ClearPlayerFields();
            }
            else
            {
                // cancel if playername is empty
                if (InputName.Text.Length < 1)
                {
                    return;
                };
                var player = new Player(playerIndex, InputName.Text,
                    InputHealth.SelectedIndex,
                    InputMovement.SelectedIndex,
                    InputLevel.SelectedIndex,
                    InputStrength.SelectedIndex,
                    InputDexterity.SelectedIndex,
                    InputConstitution.SelectedIndex,
                    InputIntelligence.SelectedIndex,
                    InputWisdom.SelectedIndex,
                    InputCharisma.SelectedIndex,
                    InputArmorRating.SelectedIndex,
                    InputProficiency.SelectedIndex,
                    null,
                    null);

                if (InputRace.Text != null)
                {
                    player.Race = InputRace.Text;
                }
                if (InputClass.Text != null)
                {
                    player.Class = InputClass.Text;
                }

                // Add the player to the ListBox control
                players.Add(player);
                playerIndex++;
                PlayerListbox.Items.Insert(player.PlayerIndex, player.ToString());
                ClearPlayerFields();

                //PlayerBoard.instance.placePlaceableOnPossibleTile(player);
            }
        }

        private void EditPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerListbox.SelectedIndex >= 0)
            {
                var player = players[PlayerListbox.SelectedIndex];

                InputName.Text = player.Name;
                InputHealth.SelectedIndex = player.Health;
                InputMovement.SelectedIndex = player.Movement;
                InputLevel.SelectedIndex = player.PlayerLevel;
                InputStrength.SelectedIndex = player.Strength;
                InputDexterity.SelectedIndex = player.Dexterity;
                InputConstitution.SelectedIndex = player.Constitution;
                InputConstitution.SelectedIndex = player.Intelligence;
                InputWisdom.SelectedIndex = player.Wisdom;
                InputCharisma.SelectedIndex = player.Charisma;
                InputArmorRating.SelectedIndex = player.AR;
                InputProficiency.SelectedIndex = player.BP;
                InputRace.Text = player.Race;
                InputClass.Text = player.Class;

                AddPlayerButton.Content = "Update Player";
            }
        }

        private void ClearPlayerFields()
        {
            InputName.Text = "";
            InputHealth.SelectedIndex = 0;
            InputMovement.SelectedIndex = 0;
            InputLevel.SelectedIndex = 0;
            InputStrength.SelectedIndex = 0;
            InputDexterity.SelectedIndex = 0;
            InputConstitution.SelectedIndex = 0;
            InputIntelligence.SelectedIndex = 0;
            InputWisdom.SelectedIndex = 0;
            InputCharisma.SelectedIndex = 0;
            InputArmorRating.SelectedIndex = 0;
            InputProficiency.SelectedIndex = 0;
            InputRace.Text = "";
            InputClass.Text = "";
        }

        private void PlayerListbox_Loaded(object sender, RoutedEventArgs e)
        {
            //players = PlayerBoard.instance.getPlayers();      TODO
            playerIndex = 0;
            foreach (Player player in players)
            {
                player.PlayerIndex = playerIndex;
                PlayerListbox.Items.Insert(player.PlayerIndex, player.ToString());
                this.playerIndex++;
            }
        }

        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            if(PlayerListbox.SelectedItem != null)
            {
                Player player = players[PlayerListbox.SelectedIndex];
                players.Remove(player);
                PlayerListbox.Items.Remove(player.ToString());
                //PlayerBoard.instance.removeEntity(player);    TODO
            }
        }
    }
}