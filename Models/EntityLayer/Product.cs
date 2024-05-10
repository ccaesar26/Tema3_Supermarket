using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Models.EntityLayer;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Barcode { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
    
    [Required]
    public int ProducerId { get; set; }
    
    [StringLength(200)]
    public string Image { get; set; }
    
    [DefaultValue(1)]
    public bool IsActive { get; set; } 
    
    [ForeignKey("CategoryId")]
    public virtual Category Category { get; set; }
    
    [ForeignKey("ProducerId")]
    public virtual Producer Producer { get; set; }
    
    public virtual ICollection<Offer> Offers { get; set; }
    public virtual ICollection<Stock> Stocks { get; set; }
    
    [NotMapped]
    public virtual ICollection<Receipt> Receipts { get; set; }
    // public virtual ICollection<ProductReceipt> ProductReceipts { get; set; }
}