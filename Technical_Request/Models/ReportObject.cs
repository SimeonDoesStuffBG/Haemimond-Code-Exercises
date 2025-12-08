namespace Technical_Request.Models
{
    public class ReportObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Block> Blocks { get; set; }
        public List<System> Systems { get; set; }
        public List<EmployeeView> ResponsiblePersons { get; set; }
        public DateTime TimeOfCreation { get; set; }
    }
}
