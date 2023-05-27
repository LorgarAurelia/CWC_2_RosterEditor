using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для ChooseArmy.xaml
    /// </summary>
    public partial class ChooseArmy : Window
    {
        public string Army { get; private set; }
        public ushort PointsLimit { get; private set; }
        public ChooseArmy(Dictionary<string, string> armyLists)
        {
            InitializeComponent();
            List<string> armyNames = new();

            foreach (var army in armyLists)
                armyNames.Add(army.Key);

            ArmySwitcher.ItemsSource= armyNames;
        }

        private void ApplyRosterSettings(object sender, RoutedEventArgs e)
        {
            if (ArmySwitcher.Text == string.Empty || IsText(PointsBox.Text))
                MessageBox.Show(UserMessages.ErrorsDuringRosterCreation);
            else
            {
                Army = ArmySwitcher.Text;
                PointsLimit = ushort.Parse(PointsBox.Text);
                DialogResult = true;
            }
        }
        private static bool IsText(string content)
        {
            Regex regex = new("[^0-9.-]+");
            return regex.IsMatch(content);
        }
        //private void ArmySwitcher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
            
        //}

        //private void Points_TextChanged(object sender, TextChangedEventArgs e)
        //{
            
        //}
    }
}
