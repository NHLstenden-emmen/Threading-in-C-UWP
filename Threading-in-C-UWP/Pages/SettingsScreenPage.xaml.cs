using Threading_in_C_UWP.Board;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Threading_in_C_UWP.Forms
{
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
            await PlayerBoard.instance.importBoard();
        }

        private async void ExportGameButton_Click(object sender, RoutedEventArgs e)
        {
            await PlayerBoard.instance.exportBoard();
        }
    }
}
