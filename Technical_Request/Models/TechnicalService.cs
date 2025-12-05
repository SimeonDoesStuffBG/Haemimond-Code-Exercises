using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Technical_Request.Models
{
    public class TechnicalService
    {
        public int Id { get; set; }
        [DataType("nvarchar(500)")]
        public string Name { get; set; }
        [DataType("nvarchar(4000)")]
        public string Description { get; set; }
        public DateTime TimeOfCreation { get; set; }
    }
}
