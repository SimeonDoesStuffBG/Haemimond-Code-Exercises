namespace Technical_Request.Models
{
    public class TechnicalService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] Blocks { get; set; }
        public int[] Systems { get; set; }
        public int[] ResponsiblePersons { get; set; }
        public DateTime TimeOfCreation { get; set; }
    }
}
