namespace Technical_Request.Models
{
    public class TechnicalService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[]? Blocks { get; set; } = null!;
        public int[]? Systems { get; set; } = null!;
        public int[]? ResponsiblePersons { get; set; } = null!;
        public DateTime TimeOfCreation { get; set; }
    }
}
