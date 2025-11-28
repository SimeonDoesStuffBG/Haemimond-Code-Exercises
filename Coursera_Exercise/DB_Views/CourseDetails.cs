namespace Coursera_Exercise.DB_Views
{
    public class CourseDetails
    {
        public int Course_id { get; set; }
        public required string Course_name {  get; set; }
        public short Total_time {  get; set; }
        public short Credit {  get; set; }
        public required string Instructor_name { get; set; }

    }
}
