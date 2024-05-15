using System.Collections.ObjectModel;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.ViewModels;

public class ProducerViewModel
{
    public ObservableCollection<ProducerDTO> Producers { get; set; } = ProducerBLL.GetProducers();
}