using EStore.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EStore.Data.Database;

public class EStoreContext : DbContext
{
    public EStoreContext()
    {
    }

    public EStoreContext(DbContextOptions<EStoreContext> options)
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
            entity.HasKey(e => e.MemberId).HasName("PK__Member__0CF04B1869A5D88F");

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
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCFB7F26B4D");

            entity.ToTable("Order");

            entity.Property(e => e.Freight).HasColumnType("money");

            entity.HasOne(d => d.Member).WithMany(p => p.Orders)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Order_Member");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D36C57CC404F");

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
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BBA4D5CFC");
            
            entity.ToTable("Category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(40)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD91D95288");

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
