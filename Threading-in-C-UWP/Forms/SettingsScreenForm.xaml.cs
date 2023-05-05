using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Threading_in_C_UWP.Board;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers;
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
    public sealed partial class SettingsScreenForm : Page
    {
        public SettingsScreenForm()
        {
            InitializeComponent();
        }

        private void btnResetTurnCounter_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Instance.ResetTurnCounter();
        }

        private async void ImportGameButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker filePicker = new Windows.Storage.Pickers.FileOpenPicker(); 
            filePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            //filePicker.SuggestedStartLocation = "../../Assets/XML/DND";
            //filePicker.InitialDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "../../Resources/XML"));
            filePicker.FileTypeFilter.Add(".xml");
            Windows.Storage.StorageFile file = await filePicker.PickSingleFileAsync();
            Debug.WriteLine(file.Path);
            PlayerBoard.instance.importBoard(file.Path);
        }

        private void ExportGameButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerBoard.instance.exportBoard();
        }
    }
}
