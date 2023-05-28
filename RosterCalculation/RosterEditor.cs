using CWC_2_RosterEditor.FileService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWC_2_RosterEditor.RosterCalculation
{
    public class RosterEditor
    {
        public static void AddUnit(Roster roster, Unit unit)
        {
            if (roster.Units.Where(u => u.Name == unit.Name).Any())
            {
                var currentOption = roster.Units.Where(u => u.Name == unit.Name).First();
                currentOption.Count++;
                currentOption.TotalCost += unit.Points;
            }
            else
                roster.Units.Add(new(unit.Name, unit.Points));
            
            roster.CurentPoints += unit.Points;
        }
    }
}
