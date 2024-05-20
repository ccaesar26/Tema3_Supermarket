using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.ObjectViewModels;

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
    
    public static ProducerDTO ToDTO(this ProducerViewModel producerViewModel)
    {
        return new ProducerDTO
        {
            Id = producerViewModel.Id,
            Name = producerViewModel.Name,
            OriginCountry = producerViewModel.OriginCountry
        };
    }
    
    public static Producer ToEntity(this ProducerDTO producerDTO)
    {
        return new Producer
        {
            ProducerId = producerDTO.Id,
            Name = producerDTO.Name 
                   ?? throw new ArgumentException("Invalid producer name"),
            OriginCountry = producerDTO.OriginCountry
                            ?? throw new ArgumentException("Invalid producer origin country")
        };
    }
    
    public static ProducerViewModel ToViewModel(this ProducerDTO producerDTO)
    {
        return new ProducerViewModel
        {
            Id = producerDTO.Id ?? 0,
            Name = producerDTO.Name ?? "",
            OriginCountry = producerDTO.OriginCountry ?? ""
        };
    }
}