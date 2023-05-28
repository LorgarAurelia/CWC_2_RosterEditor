namespace CWC_2_RosterEditor.FileService.Models
{
    public class SelectedOptions
    {
        public string Name { get; set; }
        public byte Count { get; set; }
        public ushort TotalCost { get; set; }
        public SelectedOptions(string name, ushort cost)
        {
            Count = 1;
            Name = name;
            TotalCost = cost;
        }
    }
}
