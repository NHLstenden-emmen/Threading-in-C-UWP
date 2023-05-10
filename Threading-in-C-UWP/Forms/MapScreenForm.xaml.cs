using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using Threading_in_C_UWP.Board;
using Threading_in_C_UWP.Board.placeable;
using Threading_in_C_UWP.Players;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Threading_in_C_UWP.Forms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MapScreenForm : Page
    {
        private RichEditBox[] richTextBoxes;
        public static MapScreenForm instance;
        public MapScreenForm()
        {
            InitializeComponent();
            MapScreenForm.instance = this;
            richTextBoxes = new RichEditBox[]
            {
                MapExampleOne,
                MapExampleTwo,
                MapExampleThree,
                MapExampleFour,
                MapExampleFive,
                MapExampleSix,
                MapExampleSeven,
                MapExampleEight,
                MapExampleNine
            };
            for (int i = 1;i <= richTextBoxes.Length;i++)
            {
                AmountOfMaps.Items.Add(i);
            }
            AmountOfMaps.SelectedIndex = 0;
        }

        public bool isMasterOverrideText()
        {
            
            if (masterOverrideCheckbox.IsChecked == null || masterOverrideCheckbox.IsChecked == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void obstacleButton_Click(object sender, EventArgs e)
        {
            PlayerBoard.instance.placePlaceableOnPossibleTile(new Obstacle(objectNameBox.Text));
        }

        public Placeable[,] generateRandomMap()
        {
            Debug.WriteLine("Generating map");
            ThreadLocal<Random> rand = new ThreadLocal<Random>(() => new Random());
            Random rnd = rand.Value;
            Placeable[,] map = new Placeable[PlayerBoard.instance.gridheight, PlayerBoard.instance.gridwidth];

            // Sleep for 20 ms so the random numbers are unique
            map = addrandomRoom(map);
            Thread.Sleep(20);
            map = addrandomRoom(map);
            Thread.Sleep(20);
            map = addrandomRoom(map);

            for (int i = 0; i < rnd.Next(1, 4); i++)
            {
                map[rnd.Next(0, PlayerBoard.instance.gridheight), rnd.Next(0, PlayerBoard.instance.gridwidth)] = new Obstacle("Tree");
            }

            for (int i = 0; i < rnd.Next(1, 4); i++)
            {
                map[rnd.Next(0, PlayerBoard.instance.gridheight), rnd.Next(0, PlayerBoard.instance.gridwidth)] = new Obstacle("Rock");
            }

            return map;
        }

        public static Placeable[,] addrandomRoom(Placeable[,] map)
        {

            Random rnd = new Random();
            List<Point> room = Rooms.getRandomRoom(rnd.Next(0, PlayerBoard.instance.gridwidth - 4), rnd.Next(0, PlayerBoard.instance.gridheight - 4));

            foreach (Point p in room)
            {
                if (p.X < PlayerBoard.instance.gridwidth && p.Y < PlayerBoard.instance.gridheight)
                {
                    map[p.Y, p.X] = new Obstacle("Wall");
                }
            }

            return map;
        }

        //create maps button click
        private void GenerateItemButton_Click(object sender, RoutedEventArgs e)
        {
            Placeable[,] result = new Placeable[PlayerBoard.instance.gridheight, PlayerBoard.instance.gridwidth];
            List<Placeable[,]> mapList = new List<Placeable[,]>();
            int numMaps = AmountOfMaps.SelectedIndex + 1;
            Object randLock = new Object();
            ManualResetEvent[] events = new ManualResetEvent[numMaps];

            for (int i = 0; i < numMaps; i++)
            {
                int mapId = i;
                events[mapId] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(new WaitCallback(
                    (_) =>
                    {
                        lock (randLock)
                        {
                            mapList.Add(generateRandomMap());
                        }
                        events[mapId].Set();
                    }
                ));
            }
            Thread waitThread = new Thread(() =>
            {
                WaitHandle.WaitAll(events);
            });

            waitThread.SetApartmentState(ApartmentState.MTA);
            waitThread.Start();
            waitThread.Join();

            Debug.WriteLine("Amount selected: " + AmountOfMaps.SelectedIndex);
            for (int mapId = 0; mapId < AmountOfMaps.SelectedIndex + 1; mapId++)
            {
                Debug.WriteLine("mapID: " + mapId);
                fillDisplayMap(richTextBoxes[mapId], mapList[mapId]);
            }
        }


        private void fillDisplayMap(RichEditBox richTextBox, Placeable[,] map)
        {
            String mapString = "";
            for (int i = 0; i < PlayerBoard.instance.gridheight; i++)
            {
                for (int j = 0; j < PlayerBoard.instance.gridwidth; j++)
                {
                    if (map[i, j] != null)
                    {
                        mapString += "■";
                    }
                    else
                    {
                        mapString += "□";
                    }
                }

                mapString += Environment.NewLine;
                richTextBox.Tag = map;
            }
            richTextBox.IsReadOnly= false;
            richTextBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, mapString);
            richTextBox.IsReadOnly = true;
        }

        private async void SelectMap(object sender, RoutedEventArgs e)
        {
            RichEditBox richTextBox = sender as RichEditBox;
            if (richTextBox.Tag == null)
            {
                return;
            }

            Placeable[,] map = (Placeable[,])richTextBox.Tag;

            await PlayerBoard.playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                for (int i = 0; i < PlayerBoard.instance.gridheight; i++)
                {
                    for (int j = 0; j < PlayerBoard.instance.gridwidth; j++)
                    {
                        Tile tile = (Tile)PlayerBoard.instance.tileArray[i, j].Tag;

                        if (map[i, j] != null)
                        {
                            checkForPlayer(PlayerBoard.instance.tileArray, map, i, j);
                        }
                        else
                        {
                            if (tile.getPlaceable() == null || tile.getPlaceable().GetType() != typeof(Player))
                            {
                                tile.setPlaceable(null);
                            }
                        }
                    }
                }
            });

            PlayerBoard.instance.updateBoard();
            foreach (RichEditBox textBox in richTextBoxes)
            {
                textBox.Tag = null;
                //textBox.Document.SetText(Windows.UI.Text.TextSetOptions.None, "");
            }
        }

        private void checkForPlayer(Button[,] oldMap, Placeable[,] newMap, int i, int j)
        {
            Tile tile = (Tile)oldMap[i, j].Tag;
            if (tile.getPlaceable() != null && tile.getPlaceable().GetType() == typeof(Player))
            {
                checkForPlayer(oldMap, newMap, i, j + 1);
                Tile nextTile = (Tile)oldMap[i, j + 1].Tag;
                nextTile.setPlaceable(tile.getPlaceable());
            }
            tile.setPlaceable(newMap[i, j]);
        }
    }
}
