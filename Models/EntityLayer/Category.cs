﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Models.EntityLayer;
public sealed class Category
{
    [Key]
    public int? CategoryId { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    
    [StringLength(200)]
    public string? Image { get; set; }

    [DefaultValue(true)] 
    public bool? IsActive { get; set; }
    
    public ICollection<Product?>? Products { private get; set; }
}
