using dotNetCoreWebAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dotNetCoreWebAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
