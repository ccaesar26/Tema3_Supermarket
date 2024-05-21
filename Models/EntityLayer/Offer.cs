using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Models.EntityLayer;

public sealed class Offer
{
    [Key]
    public int? OfferId { get; set; }
    
    [Required]
    public int ProductId { get; set; }
    
    [Required]
    public int DiscountPercentage { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    [Required]
    public DateTime EndDate { get; set; }
    
    [Required]
    public EReason Reason { get; set; }
    
    [DefaultValue(1)]
    public bool? IsActive { get; set; }
    
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}