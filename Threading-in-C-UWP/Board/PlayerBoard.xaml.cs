using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Threading_in_C_UWP.Board.placeable;
using Threading_in_C_UWP.Equipment;
using Threading_in_C_UWP.Forms;
using Threading_in_C_UWP.Players;
using Windows.ApplicationModel.Core;
using Windows.Storage.Pickers;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Threading_in_C_UWP.Converters.TileConverter;

namespace Threading_in_C_UWP.Board
{
    public sealed partial class PlayerBoard : Page
    {
        public Button[,] tileArray;
        public int gridheight = 9;
        public int gridwidth = 16;
        private int tileSize = 80;
        private Button selectedButton = null;
        public static PlayerBoard instance;
        public static CoreApplicationView playerBoardView;
        public PlayerBoard()
        {
            this.InitializeComponent();
            PlayerBoard.instance = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            playerBoardView = (CoreApplicationView)e.Parameter;
            base.OnNavigatedTo(e);
        }

        private void setUpBoard()
        {
            {
                //creates the tiles in the board, based on the display size that is used for the game
                //the board that will be created is a grid of 16 by 9, with all the tiles being 80*80 pixels large

                int initialX = 0;
                int initialY = 0;

                //initialize tile array with the correct dimensions
                tileArray = new Button[gridheight, gridwidth];

                // Get the Grid control from XAML by its name
                Grid boardCanvas = (Grid)FindName("myGrid");

                //creates the buttons for the board and fills tile array with empty tiles
                for (int i = 0; i < gridheight; i++)
                {
                    for (int j = 0; j < gridwidth; j++)
                    {
                        //creates button and sets all attributes
                        Button button = new Button();
                        button.Height = tileSize;
                        button.Width = tileSize;
                        button.Margin = new Thickness(initialX, initialY, 0, 0);
                        button.Click += boardClick;
                        button.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                        button.Content = "test";
                        button.HorizontalAlignment = HorizontalAlignment.Left;
                        button.VerticalAlignment = VerticalAlignment.Top;

                        Tile tile = new Tile(j, i);
                        button.Tag = tile;

                        //adds button with tag to the array
                        tileArray[i, j] = button;

                        //create a border control with a black stroke and add the button to the border
                        Border border = new Border();
                        border.BorderThickness = new Thickness(1);
                        border.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
                        border.Child = button;

                        //adds border with button to the Grid control
                        myGrid.Children.Add(border);

                        initialX += tileSize;
                    }
                    initialX = 0;
                    initialY += tileSize;
                }
            }
        }

        //updates the drawables on all tiles
        public async Task updateBoard()
        {
            await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                for (int i = 0; i < gridheight; i++)
                {
                    for (int j = 0; j < gridwidth; j++)
                    {
                        Tile tile = (Tile)tileArray[i, j].Tag;
                        if (tile.getPlaceable() == null)
                        {
                            tileArray[i, j].Content = "";
                        }
                        else
                        {
                            tileArray[i, j].Content = tile.getPlaceable().getDrawAble();
                        }
                    }
                }

                foreach (Button button in tileArray)
                {
                    Tile tile = (Tile)button.Tag;
                    if (tile.getPlaceable() == null)
                    {
                        button.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    }
                    else if (tile.getPlaceable() is Obstacle)
                    {
                        Obstacle obstacle = (Obstacle)tile.getPlaceable();
                        switch (obstacle.type)
                        {
                            case "Wall":
                                button.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
                                break;
                            case "Tree":
                                button.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                                break;
                            case "Rock":
                                button.Background = new SolidColorBrush(Windows.UI.Colors.Brown);
                                break;
                        }
                    }
                }
            });
        }


        private async void boardClick(object sender, RoutedEventArgs e)
        {
            if (MapScreenForm.instance == null || !await MapScreenForm.instance.isMasterOverrideText())
            {
                //catch off any sender object that is not a button
                if (!(sender is Button))
                {
                    return;
                }

                //parse to button to enable all useses and fields
                Button button = (Button)sender;

                //get the tile from the button
                Tile tile = (Tile)button.Tag;

                //check if the tile is empty at first selection
                if (selectedButton == null && tile.getPlaceable() == null)
                {
                    return;
                }

                //Check if the object is movable
                if (selectedButton == null && !tile.getPlaceable().GetType().IsSubclassOf(typeof(Moveable)))
                {
                    return;
                }

                //select the pressed button if none other is selected
                if (selectedButton == null)
                {
                    selectedButton = button;
                    showAllPosibleMoves((Entity)tile.getPlaceable(), tile);
                    button.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    return;
                }

                //unselect a button if the selected button is pressed again
                if (selectedButton == button)
                {
                    selectedButton = null;
                    DesellectAllPosibleMoves((Entity)tile.getPlaceable(), tile);
                    return;
                }

                //check if tile is empty
                if (tile.getPlaceable() != null)
                {
                    return;
                }

                Tile selectedTile = (Tile)selectedButton.Tag;
                DesellectAllPosibleMoves((Entity)selectedTile.getPlaceable(), selectedTile);
                tile.setPlaceable(selectedTile.getPlaceable());
                selectedTile.setPlaceable(null);
                selectedButton.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                selectedButton = null;

            }
            else
            {
                Button button = (Button)sender;

                //get the tile from the button
                Tile tile = (Tile)button.Tag;
                if (selectedButton == null)
                {
                    selectedButton = button;
                    button.Background = new SolidColorBrush(Windows.UI.Colors.Green);
                    return;
                }

                if (selectedButton == button)
                {
                    selectedButton = null;
                    button.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                    return;
                }

                Tile selectedTile = (Tile)selectedButton.Tag;
                tile.setPlaceable(selectedTile.getPlaceable());
                selectedTile.setPlaceable(null);
                selectedButton.Background = new SolidColorBrush(Windows.UI.Colors.Gray);
                selectedButton = null;
            }

            await updateBoard();
        }

        public async Task initiateBasicSetup()
        {
            // Get the selected screen
            
            //Screen selectedScreen = Screen.AllScreens[SelectedScreen];

            //// Set the form to the size of the selected screen
            //this.Location = selectedScreen.Bounds.Location;
            //this.Size = selectedScreen.Bounds.Size;

            setUpBoard();

            Tile tile = (Tile)tileArray[0, 0].Tag;
            tile.setPlaceable(new Player(0, "Roan", 10, 10, 3, 10, 10, 10, 10, 10, 10, 10, 10, "Demon", "test"));
            Tile tile2 = (Tile)tileArray[0, 1].Tag;
            tile2.setPlaceable(new Player(0, "Simchaja", 10, 3, 10, 10, 10, 10, 10, 10, 10, 10, 10, "Demon", "test"));
            Tile tile3 = (Tile)tileArray[5, 4].Tag;
            tile3.setPlaceable(new Obstacle("Tree"));

            await updateBoard();
        }

        private List<Tile> getAllPosibleMoves(Moveable moveable, Tile location)
        {
            List<Tile> posibleMoves = new List<Tile>();
            List<Tile> upNext = new List<Tile>();

            upNext.Add(location);

            for (int i = 0; i <= moveable.getMovement(); i++)
            {
                //add all upnext moves to the possible move list
                foreach (Tile temptile in upNext)
                {
                    posibleMoves.Add(temptile);
                }

                //create a seperate list to store the temporary tiles that where just stored
                List<Tile> temp = new List<Tile>();

                foreach (Tile tile in upNext)
                {
                    temp.Add(tile);
                }

                upNext.Clear();

                foreach (Tile temptile in temp)
                {
                    Tile sideTile;

                    //check if tile upwards is posible
                    if (temptile.getY() > 0)
                    {
                        //find upwards tile
                        sideTile = (Tile)tileArray[temptile.getY() - 1, temptile.getX()].Tag;
                        if (!posibleMoves.Contains(sideTile) && !upNext.Contains(sideTile))
                        {
                            if (sideTile.getPlaceable() == null)
                            {
                                upNext.Add(sideTile);
                            }
                            else if (!sideTile.getPlaceable().GetType().IsSubclassOf(typeof(InMovable)))
                            {
                                upNext.Add(sideTile);
                            }
                        }
                    }

                    //check if tile downwards is posible
                    if (temptile.getY() < tileArray.GetLength(0) - 1)
                    {
                        //find downwards tile
                        sideTile = (Tile)tileArray[temptile.getY() + 1, temptile.getX()].Tag;
                        if (!posibleMoves.Contains(sideTile) && !upNext.Contains(sideTile))
                        {
                            if (sideTile.getPlaceable() == null)
                            {
                                upNext.Add(sideTile);
                            }
                            else if (!sideTile.getPlaceable().GetType().IsSubclassOf(typeof(InMovable)))
                            {
                                upNext.Add(sideTile);
                            }
                        }
                    }

                    //check if tile to the left is posible
                    if (temptile.getX() > 0)
                    {
                        //find tile to the left
                        sideTile = (Tile)tileArray[temptile.getY(), temptile.getX() - 1].Tag;
                        if (!posibleMoves.Contains(sideTile) && !upNext.Contains(sideTile))
                        {
                            if (sideTile.getPlaceable() == null)
                            {
                                upNext.Add(sideTile);
                            }
                            else if (!sideTile.getPlaceable().GetType().IsSubclassOf(typeof(InMovable)))
                            {
                                upNext.Add(sideTile);
                            }
                        }
                    }

                    //check if tile to the right is posible
                    if (temptile.getX() < tileArray.GetLength(1) - 1)
                    {
                        //find tile to the right
                        sideTile = (Tile)tileArray[temptile.getY(), temptile.getX() + 1].Tag;
                        if (!posibleMoves.Contains(sideTile) && !upNext.Contains(sideTile))
                        {
                            if (sideTile.getPlaceable() == null)
                            {
                                upNext.Add(sideTile);
                            }
                            else if (!sideTile.getPlaceable().GetType().IsSubclassOf(typeof(InMovable)))
                            {
                                upNext.Add(sideTile);
                            }
                        }
                    }
                }
            }

            return posibleMoves;
        }

        private void showAllPosibleMoves(Moveable moveable, Tile location)
        {
            foreach (Tile tile in getAllPosibleMoves(moveable, location))
            {
                tileArray[tile.getY(), tile.getX()].Background = new SolidColorBrush(Windows.UI.Colors.Blue);
            }
        }

        private void DesellectAllPosibleMoves(Moveable moveable, Tile location)
        {
            foreach (Tile tile in getAllPosibleMoves(moveable, location))
            {
                tileArray[tile.getY(), tile.getX()].Background = new SolidColorBrush(Windows.UI.Colors.Gray);
            }
        }

        public async Task placePlaceableOnPossibleTile(Placeable placeable)
        {
            await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                foreach (Button button in tileArray)
                {
                    Tile tile = (Tile)button.Tag;
                    if (tile.getPlaceable() == null)
                    {
                        tile.setPlaceable(placeable);
                        await updateBoard();
                        return;
                    }
                }
            });
        }

        //export the drawables on all tiles
        public async Task exportBoard()
        {
            using (var stringWriter = new System.IO.StringWriter())
            {
                var serializer = new XmlSerializer(typeof(Tile));
                stringWriter.Write("<TileList xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">");
                // loop through playerboard
                await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    for (int i = 0; i < gridheight; i++)
                    {
                        for (int j = 0; j < gridwidth; j++)
                        {
                            // if the tile isn't empty convert tile to xml and add to the xml string
                            Tile tile = (Tile)tileArray[i, j].Tag;
                            if (tile.getPlaceable() != null && tile.getPlaceable().getDrawAble() != null)
                            {
                                serializer.Serialize(stringWriter, tile);
                            }
                        }
                    }
                });

                // remove all <xml> tags
                String replace = "<?xml version=\"1.0\" encoding=\"utf-16\"?>";
                stringWriter.GetStringBuilder().Replace(replace, "");
                stringWriter.Write("</TileList>");

                // Code for saving to file
                var savePicker = new Windows.Storage.Pickers.FileSavePicker();
                savePicker.SuggestedStartLocation =
                    Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
                // Dropdown of file types the user can save the file as
                savePicker.FileTypeChoices.Add("DND-Save", new List<string>() { ".xml" });
                // Default file name if the user does not type one in or select a file to replace
                DateTime now = DateTime.Now;
                savePicker.SuggestedFileName = "DND" + now.ToString("yyyyMMdd_hhmmss");

                Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
                if (file != null)
                {
                    Windows.Storage.CachedFileManager.DeferUpdates(file);
                    // write to file
                    await Windows.Storage.FileIO.WriteTextAsync(file, stringWriter.ToString());
                    Windows.Storage.Provider.FileUpdateStatus status =
                        await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                    if (status != Windows.Storage.Provider.FileUpdateStatus.Complete)
                    {
                        ContentDialog exportFailedDialog = new ContentDialog()
                        {
                            Title = "Export Failed!",
                            Content = "Game export Failed" +
                            "Please try again.",
                            CloseButtonText = "Ok"
                        };
                        await exportFailedDialog.ShowAsync();
                    }
                }
            }
        }

        public async Task importBoard()
        {
            String xmlString = "";

            // open file picker for user to select save game to import
            FileOpenPicker filePicker = new Windows.Storage.Pickers.FileOpenPicker();
            filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            filePicker.FileTypeFilter.Add(".xml");
            Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();
            if (file != null && file.Name != null && file.Name.Substring(file.Name.Length - 4) == ".xml")
            {
                // convert file into xml string so it can be passed as parameter to playerboard
                String nextLine;
                using (StreamReader reader = new StreamReader(await file.OpenStreamForReadAsync()))
                {
                    while ((nextLine = await reader.ReadLineAsync()) != null)
                    {
                        xmlString += nextLine;
                    }
                }

                // clear board
                await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    foreach (Button button in tileArray)
                    {
                        Tile tile = button.Tag as Tile;
                        tile.setPlaceable(null);
                    }
                });

                // check if string not empty
                if (xmlString == null || xmlString == "")
                {
                    ContentDialog importFailedDialog = new ContentDialog()
                    {
                        Title = "Import Failed!",
                        Content = "Game Import Failed" +
                        "Please select a DND save game.",
                        CloseButtonText = "Ok"
                    };
                    await importFailedDialog.ShowAsync();
                    return;
                }

                // read string into playerboard
                XmlSerializer serializer = new XmlSerializer(typeof(TileList));
                using (TextReader reader = new StringReader(xmlString))
                {
                    await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                    {
                        TileList tileList = (TileList)serializer.Deserialize(reader);
                        List<Tile> tiles = tileList.Tiles;

                        // loop through all the tile found in the xml array and add them to the board
                        foreach (Tile tile in tiles)
                        {
                            tileArray[tile.y, tile.x].Tag = tile;
                        }
                    });
                }

            } else
            {
                await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                {
                    ContentDialog importFailedDialog = new ContentDialog()
                    {
                        Title = "Import Failed!",
                        Content = "Game Import Failed" +
                        "Please select a DND save game.",
                        CloseButtonText = "Ok"
                    };
                    await importFailedDialog.ShowAsync();
                });
            }

            updateBoard();
        }

        public async Task<List<Player>> getPlayers()
        {
            List<Player> playerList = new List<Player>();

            await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                foreach (Button button in tileArray)
                {
                    Tile tile = button.Tag as Tile;
                    if (tile.getPlaceable() != null && tile.getPlaceable().GetType() == typeof(Player))
                    {
                        playerList.Add((Player)tile.getPlaceable());
                    };
                }
            });

            return playerList;
        }

        public async void removeEntity(Entity entity)
        {
            await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                foreach (Button button in tileArray)
                {
                    Tile tile = button.Tag as Tile;
                    if (tile.getPlaceable() != null && tile.getPlaceable().GetType() == entity.GetType() && tile.getPlaceable() == entity)
                    {
                        tile.setPlaceable(null);
                        await updateBoard();
                        return;
                    };
                }
            });
        }

        public async Task DisplayLootTextAsync(List<Item> items, int index)
        {
            await playerBoardView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                ContentDialog lootItemDialog = new ContentDialog()
                {
                    Title = "Loot found!",
                    Content = items[index].ToString(),
                    CloseButtonText = "Ok"
                };
                await lootItemDialog.ShowAsync();
            });
        }


        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await initiateBasicSetup();
        }
    }
}
