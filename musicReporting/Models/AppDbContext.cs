using Microsoft.EntityFrameworkCore;
using musicReporting.Models.Entities;

namespace musicReporting.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
