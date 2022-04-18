using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Domain;

namespace WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Walk>? Walks { get; set; }
        public DbSet<Region>? Regions { get; set; }
        public DbSet<WalkDifficulty>? WalkDifficulties { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Role>? Roles { get; set; }
    }
}
