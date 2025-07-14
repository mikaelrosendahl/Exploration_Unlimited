using ExplorationApi.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;


namespace ExplorationApi.Config
{

    public class ExplorationDbContext : DbContext
    {
        public ExplorationDbContext(DbContextOptions<ExplorationDbContext> options) : base(options) {}
        public DbSet<Login> Login { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings if needed
        }
    }


}
