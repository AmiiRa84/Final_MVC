using Company.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Company.DAL.Data.DBContexts
{
    public class CompanyDBContext : DbContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQLEXPRESS;Database=Final_MVC;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //        .HasOne(e => e.Department)
        //        .WithMany(d => d.Employees)
        //        .HasForeignKey(e => e.DepartmentId)
        //        .OnDelete(DeleteBehavior.Restrict);
        //}


    }
}