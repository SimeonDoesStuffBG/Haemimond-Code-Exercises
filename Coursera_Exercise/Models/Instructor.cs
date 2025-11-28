using Microsoft.EntityFrameworkCore;

namespace Coursera_Exercise.Models
{
    [Index(nameof(First_name), nameof(Last_name), IsUnique=true)]
    public class Instructor
    {
        public int Id { get; set; }
        public required string First_name { get; set; }
        public required string Last_name { get; set; }
        public DateTime Time_created { get; set; } = DateTime.Now;
    }
}
