using DB.Models;
using Microsoft.EntityFrameworkCore;

namespace DB.Data
{
  public class ShopContext : DbContext
  {
    public ShopContext(DbContextOptions<ShopContext> options) : base(options)
    {
      
    }

    public DbSet<Good> Goods { get; set; }
    public DbSet<Purchase> Purchases { get; set; } 
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Dealer> Dealers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Good>().ToTable("Good");

      modelBuilder.Entity<Purchase>().ToTable("Purchase")
        .HasOne(p => p.Good).WithMany(s => s.Purchases);
      // .HasKey(e => e.GoodID);
      modelBuilder.Entity<Customer>().ToTable("Customer")
        .HasMany(p => p.Cart).WithOne(p => p.Customer);
      modelBuilder.Entity<Dealer>().ToTable("Dealer");
    }
  }
}