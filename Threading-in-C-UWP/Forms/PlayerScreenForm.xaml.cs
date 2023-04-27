using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    
    public sealed partial class PlayerScreenForm : Page
    {
        private List<int> comboBoxValues = new List<int>(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
        public PlayerScreenForm()
        {
            //comboBoxValues.AddRange(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 });
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
        }
    }
}
