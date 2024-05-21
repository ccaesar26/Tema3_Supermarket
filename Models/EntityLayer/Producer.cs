using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Supermarket.Models.EntityLayer
{
    public sealed class Producer
    {
        [Key]
        public int? ProducerId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        
        [Required]
        [StringLength(50)]
        public string? OriginCountry { get; set; }
        
        [DefaultValue(1)]
        public bool? IsActive { get; set; }
        
        public ICollection<Product?>? Products { get; init; }
    }
}