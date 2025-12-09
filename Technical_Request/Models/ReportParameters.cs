namespace Technical_Request.Models
{
    public class ReportParameters
    {
        public string? ResponsiblePerson { get; set; } = null;
        public List<string>? Blocks { get; set; } = null;
        public List<string>? Systems { get; set; } = null;
        public DateTime? TimeOfCreation { get; set; } = null;
    }
}
