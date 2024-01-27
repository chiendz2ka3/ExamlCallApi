using Examl.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamAPI.Entity
{
    public class DbContextorder : DbContext
    {
        public DbContextorder()
        {
        }

        public DbContextorder(DbContextOptions<DbContextorder> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseSqlServer("Data Source=localhost,1433; Database=OrderSystem;User Id=sa;Password=anhchien2003;TrustServerCertificate=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.HasKey(e => e.orderidId);
                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .HasColumnName("name");
                entity.Property(o => o.ItemQty)
                    .HasColumnName("ItemQty");
                entity.Property(e => e.ItemName)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity
               .Property(o => o.OrderDelivery)
               .IsRequired();

                entity
                    .Property(o => o.OrderAddress)
                    .IsRequired();

                entity
                    .Property(o => o.PhoneNumber)
                    .IsRequired();
            });
            // Configure the Order entity

            base.OnModelCreating(modelBuilder);
        }

    }
}
