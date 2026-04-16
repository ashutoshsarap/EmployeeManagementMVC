using EmployeeManagement.Models.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<EmployeeEntity> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the Employee entity
            modelBuilder.Entity<EmployeeEntity>().HasData(
                new EmployeeEntity { Id = 1, Name = "John Doe", Email = "johndoe@gmail.com", Position = "Software Engineer", Salary = 60000, IsActive = true },
                new EmployeeEntity { Id = 2, Name = "Jane Smith", Email = "janesmith@gmail.com", Position = "Project Manager", Salary = 75000, IsActive = true }
               );
        }
    }
}
