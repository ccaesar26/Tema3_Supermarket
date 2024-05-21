using System.Collections.ObjectModel;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.ObjectViewModels;

namespace Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

public class ReceiptPageViewModel : BaseViewModel
{
    public ObservableCollection<ReceiptViewModel> Receipts { get; } 
        = new(ReceiptBLL.GetReceipts().Select(r => r.ToViewModel()));
}