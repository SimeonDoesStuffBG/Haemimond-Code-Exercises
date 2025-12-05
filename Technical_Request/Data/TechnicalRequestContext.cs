using Microsoft.EntityFrameworkCore;
using Technical_Request.Models;

namespace Technical_Request.Data
{
    public class TechnicalRequestContext:DbContext
    {
        public TechnicalRequestContext(DbContextOptions<TechnicalRequestContext> options): base(options) { }
        
        DbSet<TechnicalService> TechnicalServices { get; set; }
        DbSet<Block> Blocks { get; set; }
        DbSet<Models.System> Systems { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<ServiceBlock> ServiceBlocks { get; set; }
        DbSet<ServiceSystem> ServiceSystems { get; set; }
        DbSet<ResponsiblePerson> ResponsiblePersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
