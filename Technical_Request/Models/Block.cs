using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Technical_Request.Models
{
    [Index(nameof(Code), IsUnique = true)]
    public class Block
    {
        public int Id { get; set; }
        [DataType("nvarchar(100)")]
        public string Name { get; set; }
        [DataType("nvarchar(10)")]
        public string Code { get; set; }
    }
}
