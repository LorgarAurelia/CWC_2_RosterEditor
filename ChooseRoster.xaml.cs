using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CWC_2_RosterEditor
{
    /// <summary>
    /// Логика взаимодействия для ChooseRoster.xaml
    /// </summary>
    public partial class ChooseRoster : Window
    {
        public string ChoosedRoster { get; private set; }
        public ChooseRoster(string[] rosters)
        {
            InitializeComponent();
            RostersLits.ItemsSource = rosters;
        }

        private void ApplyRoster(object sender, RoutedEventArgs e)
        {
            if (RostersLits.SelectedItem is null)
                MessageBox.Show(UserMessages.UnselectedRoster);
            else
                ChoosedRoster = RostersLits.Text;

            DialogResult = true;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
