using System.Numerics;

namespace Coursera_Exercise.DB_Views
{
    public class StudentCredit
    {
        public required string Student_PIN { get; set; }
        public required string Student_Name { get; set; }
        public int Total_Credit { get; set; }
    }
}
