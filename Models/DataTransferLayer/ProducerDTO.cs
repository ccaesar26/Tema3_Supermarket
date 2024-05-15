using System.ComponentModel;

namespace Supermarket.Models.DataTransferLayer;

public class ProducerDTO
{
    [DisplayName("Producer Name")]
    public string Name { get; set; }
    [DisplayName("Origin Country")]
    public string OriginCountry { get; set; }
}