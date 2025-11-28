namespace Coursera_Exercise.Models
{
    public class ReportParameters
    {
        public int MinCredit { get; set; } = -1;
        public required string[] Students { get; set; } = [];
        public DateTime StartDate { get; set; } = DateTime.UnixEpoch;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
