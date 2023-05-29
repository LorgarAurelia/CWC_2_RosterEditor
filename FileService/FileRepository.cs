using CWC_2_RosterEditor.FileService.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CWC_2_RosterEditor.FileService
{
    public class FileRepository : IRepository
    {
        private static FileRepository? _instance;
        private Dictionary<string, string> _armies;
        public string PathToArmylist { get; private set; }
        public string PathToRosters { get; private set; }
        private FileRepository(string pathToArmylist, string pathToRosters)
        {
            PathToArmylist = pathToArmylist;
            PathToRosters = pathToRosters;
            _armies = ParseArmyLists(Directory.GetFiles(PathToArmylist, "*.json"));//TODO: Вынести в метод GetArmyLists
        }
        private static Dictionary<string, string> ParseArmyLists(string[] armyLists)
        {
            Dictionary<string, string> result = new();

            foreach (string root in armyLists)
            {
                string pattern = @"army(\D*).json";
                RegexOptions options = RegexOptions.Multiline;
                string armyName = Regex.Matches(root, pattern, options).First().Groups[1].Value;
                result.Add(armyName, root);
            }

            return result;
        }
        public static IRepository GetInstance(string pathToArmylist, string pathToRosters)
        {
            _instance ??= new(pathToArmylist, pathToRosters);
            return _instance;
        }

        public void SetPath(string path) => PathToArmylist = path;

        public Dictionary<string, string> GetArmyLists() => _armies;

        public ArmyList GetArmilistContent(string army)
        {
            string json = File.ReadAllText(_armies[army]);
            return JsonConvert.DeserializeObject<ArmyList>(json);
        }

        public void SaveRoster(Roster roster)
        {
            var json = JsonConvert.SerializeObject(roster);
            File.WriteAllText(PathToRosters + roster.RosterName + ".json",json);
        }

        public string[] GetAllRosters() => Directory.GetFiles(PathToRosters, "*.json");

        public Roster OpenRoster(string path)
        {
            var json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Roster>(json);
        }
    }
}
