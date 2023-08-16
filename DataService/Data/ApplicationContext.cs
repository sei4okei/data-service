using DataService.Models;
using Microsoft.EntityFrameworkCore;

namespace DataService.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Deal> Deal { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
