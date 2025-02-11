using BusinessModel.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessModel.Data
{
    public class DeliveryDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DeliveryDbContext()
        {            
        }

        public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options) 
            : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>()
                .Property(o => o.Ingredients)
                .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<Recipe>()
                .Property(o => o.Instructions)
                .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));
            modelBuilder.Entity<Recipe>()
                .Property(o => o.Tags)
                .HasConversion(v => string.Join('\n', v), v => v.Split('\n', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Recipe>()
                .HasMany(o => o.OrderItems)
                .WithOne(o => o.Recipe)
                .HasForeignKey(o => o.RecipeId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId);

            Seed.SeedData(modelBuilder);
        }

    }
}
