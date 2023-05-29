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
        private IRepository _repository;
        private Roster _roster;
        public MainWindow()
        {
            InitializeComponent();
            LoadSettings();
        }
        private void LoadSettings()
        {
            _repository = FileRepository.GetInstance(ConfigurationManager.AppSettings.Get("ArmyRoute"), ConfigurationManager.AppSettings.Get("PathToSave"));
            WindowState = (WindowState)int.Parse(ConfigurationManager.AppSettings.Get("WindowState"));
        }
        private void CreateRoster(object sender, RoutedEventArgs e)
        {
            ChooseArmy armySwitcher = new(_repository.GetArmyLists());
            if (armySwitcher.ShowDialog() == true)
            {
                _roster = new(armySwitcher.Army, armySwitcher.PointsLimit, armySwitcher.RosterName);
                RosterBox.ItemsSource = _roster.Units;
                FillUI();
            }
        }
        private void LoadRoster(object sender, RoutedEventArgs e)
        {
            string[] allRosters = _repository.GetAllRosters();
            if(allRosters.Length == 0)
                MessageBox.Show(UserMessages.NoRosters);

            ChooseRoster rosterSwitcher = new(allRosters);
            if (rosterSwitcher.ShowDialog() == true)
            {
                _roster = _repository.OpenRoster(rosterSwitcher.ChoosedRoster);
                RosterBox.ItemsSource = _roster.Units;
                FillUI();
            }
        }
        private void FillUI()
        {
            ListOfUnit.ItemsSource = _repository.GetArmilistContent(_roster.Army).Units;
            MaxPoints.Content = _roster.PointsLimit;
            CurrentPoints.Content = _roster.CurentPoints;
        }

        private void AddUnitToRoster(object sender, RoutedEventArgs e)
        {
            var unit = ((Button)sender).DataContext as Unit;
            _roster.AddUnit(unit);
            CurrentPoints.Content = _roster.CurentPoints;
        }
        private void DeleteUnitFromRoster(object sender, RoutedEventArgs e)
        {
            var selection = ((Button)sender).DataContext as SelectedOptions;
            _roster.RemoveSelection(selection);
            CurrentPoints.Content = _roster.CurentPoints;
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            _repository.SaveRoster(_roster);
            MessageBox.Show(UserMessages.Saved);
            //TODO: Show some validation erros if they exists
        }
    }
}
