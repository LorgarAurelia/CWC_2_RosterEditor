using CWC_2_RosterEditor.FileService.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CWC_2_RosterEditor.FileService
{
    public class FileRepository
    {
        private static FileRepository? _instance;
        private Dictionary<string, string> _armies;
        public string RepositoryPath { get; private set; }
        private FileRepository(string path)
        {
            RepositoryPath = path;
            _armies = ParseArmyLists(Directory.GetFiles(RepositoryPath, "*.json"));
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
        public static FileRepository GetInstance(string path)
        {
            _instance ??= new(path);
            return _instance;
        }

        public void SetPath(string path) => RepositoryPath = path;

        public Dictionary<string, string> GetArmyLists() => _armies;

        public ArmyList GetArmilistContent(string army)
        {
            string json = File.ReadAllText(_armies[army]);
            return JsonConvert.DeserializeObject<ArmyList>(json);
        }
    }
}
