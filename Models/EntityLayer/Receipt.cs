using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Models.EntityLayer;

public class Receipt
{
    [Key]
    public int ReceiptId { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public DateTime IssueDate { get; set; }
    
    [Required]
    public decimal AmountReceived { get; set; }
    
    [DefaultValue(1)]
    public bool IsActive { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
    
    [NotMapped]
    public virtual ICollection<Product> Products { get; set; }
    // public virtual ICollection<ProductReceipt> ProductReceipts { get; set; }
}