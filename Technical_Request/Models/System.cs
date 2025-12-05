using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Request.Models
{
    [Index(nameof(Code), IsUnique =true)]
    public class System
    {
        public int Id { get; set; }
        [DataType("nvarchar(100)")]
        public string Name { get; set; }
        [DataType("nvarchar(10)")]
        public string Code { get; set; }

        [ForeignKey(nameof(ParentSystem))]
        public int? Parent { get; set; }
        
        private System ParentSystem { get; set; }
    }
}
