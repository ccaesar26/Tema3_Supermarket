using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Supermarket.Models.EntityLayer
{
    public class Producer
    {
        [Key]
        public int? ProducerId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string OriginCountry { get; set; }
        
        [DefaultValue(1)]
        public bool? IsActive { get; set; }
        
        public virtual ICollection<Product> Products { get; set; }
    }
}