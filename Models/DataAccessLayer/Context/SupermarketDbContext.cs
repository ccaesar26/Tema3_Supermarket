using Microsoft.EntityFrameworkCore;
using Supermarket.Models.EntityLayer;
using ConfigurationManager = Supermarket.Services.ConfigurationManager;

namespace Supermarket.Models.DataAccessLayer.Context;

public class SupermarketDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }
    public DbSet<Producer> Producer { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Stock> Stock { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Receipt> Receipt { get; set; }
    public DbSet<Offer> Offer { get; set; }
    public DbSet<ProductReceipt> ProductReceipt { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConfigurationManager.GetConnectionStringDbContext());
    }
}
