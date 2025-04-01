using EStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EStore.Data.Database;

public class EStoreDbContext : DbContext
{
    public EStoreDbContext()
    {
    }

    public EStoreDbContext(DbContextOptions<EStoreDbContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderDetail> OrderDetails { get; set; }

    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId);

            entity.ToTable("Member");

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false);
            
            entity.Property(e => e.CompanyName)
                .HasMaxLength(40)
                .IsUnicode(false);
            
            entity.Property(e => e.Country)
                .HasMaxLength(15)
                .IsUnicode(false);
            
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.ToTable("Order");

            entity.Property(e => e.Freight).HasColumnType("money");

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Member");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId);

            entity.ToTable("OrderDetail");

            entity.Property(e => e.UnitPrice).HasColumnType("money");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId);
            
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("Product");

            entity.Property(e => e.ProductName)
                .HasMaxLength(40)
                .IsUnicode(false);
            
            entity.Property(e => e.UnitPrice).HasColumnType("money");
            
            entity.Property(e => e.Weight)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

    }
}
