namespace Coursera_Exercise.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Time_created { get; set; } = DateTime.Now;
    }
}
