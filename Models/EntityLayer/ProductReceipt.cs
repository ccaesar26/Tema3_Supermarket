using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.EntityLayer;

[PrimaryKey(nameof(ProductId), nameof(ReceiptId))]
public class ProductReceipt
{
    [Key]
    public int ReceiptId { get; set; }
    
    [Key]
    public int ProductId { get; set; }
    
    [Required]
    public int Quantity { get; set; }
    
    [Required]
    public EUnit Unit { get; set; }
    
    [Required]
    public decimal Subtotal { get; set; }
    
    [DefaultValue(1)]
    public bool IsActive { get; set; }
    
    [ForeignKey("ReceiptId")]
    public virtual Receipt Receipt { get; set; }
    
    [ForeignKey("ProductId")]
    public virtual Product Product { get; set; }
}