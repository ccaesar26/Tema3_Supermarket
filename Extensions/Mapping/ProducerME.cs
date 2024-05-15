using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Extensions.Mapping;

public static class ProducerME
{
    public static ProducerDTO ToDTO(this Producer producer)
    {
        return new ProducerDTO
        {
            Id = producer.ProducerId,
            Name = producer.Name,
            OriginCountry = producer.OriginCountry
        };
    }
    
    public static Producer ToEntity(this ProducerDTO producerDTO)
    {
        return new Producer
        {
            ProducerId = producerDTO.Id,
            Name = producerDTO.Name ?? "",
            OriginCountry = producerDTO.OriginCountry ?? ""
        };
    }
}