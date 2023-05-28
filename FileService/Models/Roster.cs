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
        public Roster(string army, ushort pointsLimit)
        {
            Army = army;
            PointsLimit = pointsLimit;
            Units = new();
        }
    }
}
