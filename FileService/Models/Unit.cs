namespace CWC_2_RosterEditor.FileService.Models
{
    public class Unit
    {
        public string Name { get; set; }
        public ushort Points { get; set; }
        public UnitType Type { get; set; }
        public byte Move { get; set; }
        public string AP { get; set; }
        public string AT { get; set; }
        public byte Hits { get; set; }
        public byte Save { get; set; }
        public Limitation Limitation { get; set; }
        public string Note { get; set; }
        public Category Category { get; set; }
    }
}
