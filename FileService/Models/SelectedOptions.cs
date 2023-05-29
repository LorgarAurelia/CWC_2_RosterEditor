namespace CWC_2_RosterEditor.FileService.Models
{
    public class SelectedOptions
    {
        public string Name { get; set; }
        public ushort Cost { get; set; }
        public SelectedOptions(string name, ushort cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
