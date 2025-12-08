using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Request.Models
{
    [PrimaryKey(nameof(ServiceId),nameof(BlockId))]
    public class ServiceBlock
    {
        [ForeignKey(nameof(Service))]
        public int ServiceId { get; set; }
        [ForeignKey(nameof(Block))]
        public int BlockId { get; set; }

        private Block Block { get; set; }
        private TechnicalService Service { get; set; }
    }
}
