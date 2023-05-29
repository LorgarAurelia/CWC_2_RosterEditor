using CWC_2_RosterEditor.FileService.Models;
using System.Collections.Generic;

namespace CWC_2_RosterEditor.FileService
{
    public interface IRepository
    {
        ArmyList GetArmilistContent(string army);
        Dictionary<string, string> GetArmyLists();
        void SaveRoster(Roster roster);
        string[] GetAllRosters();
        Roster OpenRoster(string path);
    }
}