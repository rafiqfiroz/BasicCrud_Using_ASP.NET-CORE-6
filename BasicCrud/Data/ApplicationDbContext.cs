using BasicCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace BasicCrud.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
