using Threading_in_C_UWP.Board;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
            await PlayerBoard.instance.importBoard();
        }

        private async void ExportGameButton_Click(object sender, RoutedEventArgs e)
        {
            await PlayerBoard.instance.exportBoard();
        }
    }
}
