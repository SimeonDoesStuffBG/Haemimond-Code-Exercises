using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Request.Models
{
    [PrimaryKey(nameof(ServiceId), nameof(SystemId))]
    public class ServiceSystem
    {
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        [ForeignKey(nameof(System))]
        public int SystemId { get; set; }
        private TechnicalService Service { get; set; }
        private System System {  get; set; }
    }
}
