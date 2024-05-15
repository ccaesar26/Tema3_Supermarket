using System.Collections.ObjectModel;
using System.Windows.Documents;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

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
}