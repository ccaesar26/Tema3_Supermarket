using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Supermarket.Models.EntityLayer.Enums;
using Supermarket.Services;

namespace Supermarket.Models.EntityLayer;

public class Stock
{
    [Key]
    public int StockId { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public EUnit Unit { get; set; }
    
    [Required]
    public DateTime SupplyDate { get; set; }
    
    [Required]
    public DateTime ExpiryDate { get; set; }
    
    [Required]
    public decimal PurchasePrice { get; set; }
    
    [NotMapped]
    public decimal SellingPrice => PurchasePrice * decimal.Parse(ConfigurationManager.GetSetting("ProfitPercentage") ?? "1.0");
    
    [DefaultValue(1)]
    public bool IsActive { get; set; }
    
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}