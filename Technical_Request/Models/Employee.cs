using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Technical_Request.Models
{
    [Index(nameof(PIN), IsUnique = true )]
    public class Employee
    {
        public int Id { get; set; }
        [DataType("nvarchar(100)")]
        public string FirstName { get; set; }
        [DataType("nvarchar(100)")]
        public string Surname { get; set; }
        [DataType("nvarchar(100)")]
        public string LastName {  get; set; }
        [DataType("nvarchar(20")]
        public string PIN {  get; set; }
    }
}
