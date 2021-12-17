using HTTPLessonApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace HTTPLessonApi.DAL
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }
    
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-D3L48SP\\SQLEXPRESS;Database=HelperASP;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(builder =>
            {
                builder.ToTable("Products")
                    .HasKey(k => k.Id);

                builder.Property(p => p.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Id");

                builder.Property(p => p.Name)
                    .HasColumnName("Name");
                
                builder.Property(p => p.Description)
                    .HasColumnName("Description");
                
                builder.Property(p => p.Price)
                    .HasColumnName("Price");
            });
        }
    }
}