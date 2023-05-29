using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CWC_2_RosterEditor.FileService.Models
{
    public class Roster
    {
        public ObservableCollection<SelectedOptions> Units { get; set; }
        public ushort PointsLimit { get; set; }
        public ushort CurentPoints { get; set; }
        public string Army { get; set; }
        public string RosterName { get; set; }
        public Roster(string army, ushort pointsLimit, string rosterName)
        {
            Army = army;
            PointsLimit = pointsLimit;
            Units = new();
            RosterName = rosterName;
            }
        public void AddUnit(Unit unit)
        {
            Units.Add(new(unit.Name, unit.Points));
            CurentPoints += unit.Points;
        }
        public void RemoveSelection(SelectedOptions option) 
        { 
            Units.Remove(option);
            CurentPoints -= option.Cost;
        }
    }
}
