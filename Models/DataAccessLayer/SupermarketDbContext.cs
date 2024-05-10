using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.DataAccessLayer;

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
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-A3VTMLH;Initial Catalog=dbSupermarket;User Id=sa;Password=1q2w3e;TrustServerCertificate=True;");
    }
}
