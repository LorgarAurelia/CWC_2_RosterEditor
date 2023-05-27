using System.Collections.Generic;

namespace CWC_2_RosterEditor.FileService.Models
{
    public class ArmyList
    {
        public string ArmyName { get; set; }
        public List<Unit> Units { get; set; }
        public ArmyList()
        {
            Units = new List<Unit>();
        }
    }
}
