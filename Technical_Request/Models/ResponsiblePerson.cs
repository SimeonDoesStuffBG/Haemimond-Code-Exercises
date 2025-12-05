using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Request.Models
{
    [PrimaryKey(nameof(ServiceId), nameof(EmployeeID))]
    [Index(nameof(EmployeeID), nameof(ServiceId), nameof(Activity), IsUnique =true)]
    public class ResponsiblePerson
    {
        public static readonly string[] Activities =
        {
            "creation",
            "confirmation",
            "approval",
            "verification"
        };

        [ForeignKey(nameof(ServiceRef))]
        public int ServiceId { get; set; }
        
        [ForeignKey(nameof(EmployeeRef))]
        public int EmployeeID { get; set; }

        [DataType("nvarchar(100)")]
        public string Activity { get; set; }
        private TechnicalService ServiceRef { get; set; }
        private Employee EmployeeRef { get; set; }
    }
}
