using Microsoft.EntityFrameworkCore;
using Technical_Request.Models;

namespace Technical_Request.Data
{
    public class TechnicalRequestContext:DbContext
    {
        public TechnicalRequestContext(DbContextOptions<TechnicalRequestContext> options): base(options) { }
        
        public DbSet<TechnicalService> TechnicalServices { get; set; }
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Models.System> Systems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<ServiceBlock> ServiceBlocks { get; set; }
        public DbSet<ServiceSystem> ServiceSystems { get; set; }
        public DbSet<ResponsiblePerson> ResponsiblePersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TechnicalService>().HasData(
                new TechnicalService { Id = 1, Name = "Service 1", Description = "Desc", TimeOfCreation = DateTime.Now },
                new TechnicalService { Id = 2, Name = "Service 2", Description = "Descr", TimeOfCreation = DateTime.Now },
                new TechnicalService { Id = 3, Name = "Service 3", Description = "Descri", TimeOfCreation = DateTime.Now },
                new TechnicalService { Id = 4, Name = "Service 4", Description = "Descrip", TimeOfCreation = DateTime.Now },
                new TechnicalService { Id = 5, Name = "Service 5", Description = "Descript", TimeOfCreation = DateTime.Now }
            );

            modelBuilder.Entity<Block>().HasData(
                new Block { Id = 1, Name = "Block-1", Code = "2344" },
                new Block { Id = 2, Name = "Block-2", Code = "24312" },
                new Block { Id = 3, Name = "Block-3", Code = "2554" },
                new Block { Id = 4, Name = "Block-4", Code = "2332" },
                new Block { Id = 5, Name = "Block-5", Code = "2445" }
            );

            modelBuilder.Entity<Models.System>().HasData(
                new Models.System { Id = 1, Name = "System 1", Code = "2245", Parent = null },
                new Models.System { Id = 2, Name = "System 2", Code = "2145", Parent = null },
                new Models.System { Id = 3, Name = "System 3", Code = "2945", Parent = 1 },
                new Models.System { Id = 4, Name = "System 4", Code = "2545", Parent = null },
                new Models.System { Id = 5, Name = "System 5", Code = "3245", Parent = 3 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "John", Surname = "Leo", LastName = "Connor", PIN = "2245666422" },
                new Employee { Id = 2, FirstName = "Anton", Surname = "Tsvyatkov", LastName = "Milev", PIN = "2243211422" },
                new Employee { Id = 3, FirstName = "Hristo", Surname = "Pavlov", LastName = "Kirilov", PIN = "2245663222" },
                new Employee { Id = 4, FirstName = "John", Surname = "Johnathan", LastName = "Johnson", PIN = "2245556422" },//Doer of Job at place
                new Employee { Id = 5, FirstName = "Mathew", Surname = "Jacob", LastName = "Powel", PIN = "2245006422" }
            );

        }
    }
}
