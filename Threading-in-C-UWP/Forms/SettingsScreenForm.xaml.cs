using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Threading_in_C_UWP.Board;
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

        private void ImportGameButton_Click(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = System.IO.Path.GetFullPath(System.IO.Path.Combine(Application.StartupPath, "../../Resources/XML"));
            //openFileDialog1.Title = "Import Game";
            //openFileDialog1.DefaultExt = "xml";
            //openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            //openFileDialog1.CheckFileExists = true;
            //openFileDialog1.CheckPathExists = true;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    PlayerBoard.instance.importBoard(openFileDialog1.FileName);
            //}
        }

        private void ExportGameButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerBoard.instance.exportBoard();
        }
    }
}
