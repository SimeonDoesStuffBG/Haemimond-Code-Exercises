namespace Coursera_Exercise.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Instructor_id { get; set; }
        public short Total_Time { get; set; }
        public short Credit {  get; set; }
        public DateTime Time_created { get; set; }
    }
}
