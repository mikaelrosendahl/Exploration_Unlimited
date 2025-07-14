using Microsoft.EntityFrameworkCore;
using ExplorationApi.Models;
using ExplorationApi.Classes;

namespace ExplorationApi.Data
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
        {
        }

        public DbSet<DiaryEntry> DiaryEntries { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<SavedEntry> SavedEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specifika inställningar för DiaryEntry
            modelBuilder.Entity<DiaryEntry>(entity =>
            {
                entity.ToTable("diaryentries", "public");

                // Ställ in Id som auto-genererat (Identity/Serial)
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IsPublished).HasColumnType("integer");
            });

            // Explicit mappning för SavedEntry till rätt tabellnamn och schema
            modelBuilder.Entity<SavedEntry>(entity =>
            {
                entity.ToTable("savedentries", "public");
            });

            // Explicit mappning för Series (om du vill)
            modelBuilder.Entity<Series>(entity =>
            {
                entity.ToTable("series", "public");
            });

            // Global konvention: tabell- och kolumnnamn till lowercase
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Sätt tabellnamn till lowercase
                entity.SetTableName(entity.GetTableName().ToLower());

                // Sätt kolumnnamn till lowercase
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(property.GetColumnName().ToLower());
                }
            }
        }
    }
}
