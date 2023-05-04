using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Threading_in_C_UWP.Board;
using Threading_in_C_UWP.Forms;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Hosting;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static System.Net.Mime.MediaTypeNames;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Threading_in_C_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int turnCounter;
        public static MainPage Instance { get; private set; }
        public MainPage()
        {
            turnCounter= 0;
            Instance= this;
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(960, 1080);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            StartPlayerboard();
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        // List of ValueTuple holding the Navigation Tag and the relative Navigation Page
        private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
        {
            ("Home", typeof(Home)),
            ("Players", typeof(PlayerScreenForm)),
            ("Map", typeof(MapScreenForm)),
            ("NPC", typeof(NpcScreenForm)),
            ("Monsters", typeof(MonstersScreenForm)),
            ("Loot", typeof(LootScreenForm)),
            ("settings", typeof(SettingsScreenForm))
        };

        private void NavView_ItemInvoked(NavigationView sender,
                                 NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }
        }

        private void NavView_Navigate(
            string navItemTag,
            Windows.UI.Xaml.Media.Animation.NavigationTransitionInfo transitionInfo)
        {
            Type _page = null;
            if (navItemTag == "TurnCounter")
            {
                AddTurn();
                return;
            }
            else
            {
                var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
                _page = item.Page;
            }
            // Get the page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFrame.CurrentSourcePageType;

            // Only navigate if the selected page isn't currently loaded.
            if (!(_page is null) && !Type.Equals(preNavPageType, _page))
            {
                ContentFrame.Navigate(_page, null, transitionInfo);
            }
        }

        private async void StartPlayerboard()
        {
            AppWindow appWindow = await AppWindow.TryCreateAsync();
            Frame appWindowContentFrame = new Frame();
            appWindowContentFrame.Navigate(typeof(PlayerBoard));
            ElementCompositionPreview.SetAppWindowContent(appWindow, appWindowContentFrame);
            appWindow.Presenter.RequestPresentation(AppWindowPresentationKind.FullScreen);
            await appWindow.TryShowAsync();
        }

        private void AddTurn()
        {
            turnCounter++;
            TurnCounter.Content = turnCounter.ToString();
        }

        internal void ResetTurnCounter()
        {
            turnCounter = 0;
            TurnCounter.Content = turnCounter.ToString();
        }

        private void ContentFrame_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Content = new Home();
        }
    }
}
