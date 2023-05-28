using CWC_2_RosterEditor.FileService;
using CWC_2_RosterEditor.FileService.Models;
using CWC_2_RosterEditor.RosterCalculation;
using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CWC_2_RosterEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRepository _repository;
        private Roster _roster;
        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
            CreateRoster();
            FillListOfUnits();
        }
        private void LoadSettings()
        {
            _repository = FileRepository.GetInstance(ConfigurationManager.AppSettings.Get("ArmyRoute"));
            WindowState = (WindowState)int.Parse(ConfigurationManager.AppSettings.Get("WindowState"));
        }
        private void CreateRoster()
        {
            ChooseArmy armySwitcher = new(_repository.GetArmyLists());
            armySwitcher.ShowDialog();
            _roster = new(armySwitcher.Army, armySwitcher.PointsLimit);
            //RosterBox.ItemsSource = _roster.Units;
        }
        private void FillListOfUnits()
        {
            ListOfUnit.ItemsSource = _repository.GetArmilistContent(_roster.Army).Units;
        }

        private void AddUnitToRoster(object sender, RoutedEventArgs e)
        {
            var unit = ((Button)sender).DataContext as Unit;
            RosterEditor.AddUnit(_roster, unit);
        }
    }
}
