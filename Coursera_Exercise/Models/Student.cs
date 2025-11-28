using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Coursera_Exercise.Models
{
    [PrimaryKey(nameof(PIN))]
    [Index(nameof(First_name), nameof(Last_name), IsUnique =true)]
    public class Student
    {
        [DataType("nchar(10)")]
        public string PIN { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Time_created { get; set; } = DateTime.Now;
    }
}
