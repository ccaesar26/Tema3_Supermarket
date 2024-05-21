using System.Collections.ObjectModel;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.DataTransferLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public static class ProducerBLL
{
    public static ObservableCollection<ProducerDTO> GetProducers()
    {
        var producers = new ObservableCollection<ProducerDTO>();
        foreach (var producer in ProducerDAL.GetProducers())
        {
            producers.Add(producer.ToDTO());
        }
        return producers;
    }
    
    public static bool AddProducer(ProducerDTO producerDTO)
    {
        ArgumentNullException.ThrowIfNull(producerDTO);
        ArgumentNullException.ThrowIfNull(producerDTO.Name);
        ArgumentNullException.ThrowIfNull(producerDTO.OriginCountry);

        ProducerDAL.InsertProducer(producerDTO.ToEntity());
        return true;
    }
    
    public static bool EditProducer(ProducerDTO producerDTO)
    {
        ArgumentNullException.ThrowIfNull(producerDTO);
        ArgumentNullException.ThrowIfNull(producerDTO.Id);
        ArgumentNullException.ThrowIfNull(producerDTO.Name);
        ArgumentNullException.ThrowIfNull(producerDTO.OriginCountry);

        ProducerDAL.UpdateProducer(producerDTO.ToEntity());
        return true;
    }
    
    public static bool DeleteProducer(ProducerDTO producerDTO)
    {
        ArgumentNullException.ThrowIfNull(producerDTO);
        ArgumentNullException.ThrowIfNull(producerDTO.Id);

        ProducerDAL.DeleteProducer(producerDTO.ToEntity());
        return true;
    }
}