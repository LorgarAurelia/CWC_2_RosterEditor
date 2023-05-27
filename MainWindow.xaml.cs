using CWC_2_RosterEditor.FileService;
using CWC_2_RosterEditor.FileService.Models;
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
        private FileRepository _repository;
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
        }
        private void FillListOfUnits()
        {
            foreach (var unit in _repository.GetArmilistContent(_roster.Army).Units)
                ListOfUnit.Items.Add(unit);
        }

        private void AddUnitToRoster(object sender, RoutedEventArgs e)
        {
            var unit = ((Button)sender).DataContext as Unit;
            _roster.Units.Add(new() { Name = unit.Name, TotalCost = unit.Points });
        }
    }
}
