using CWC_2_RosterEditor.FileService.Models;
using System.Collections.Generic;

namespace CWC_2_RosterEditor.FileService
{
    public interface IRepository
    {
        //string RepositoryPath { get; }

        ArmyList GetArmilistContent(string army);
        Dictionary<string, string> GetArmyLists();
        //void SetPath(string path);
    }
}