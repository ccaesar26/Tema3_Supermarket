using System.Collections.ObjectModel;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.ViewModels.ObjectViewModels;

namespace Supermarket.Extensions.Mapping;

public static class ReceiptME
{
    public static ReceiptDTO BuildDTO(this Receipt receipt, IEnumerable<ProductReceipt> productReceipts)
    {
        return new ReceiptDTO
        {
            Id = receipt.ReceiptId,
            Cashier = receipt.User?.ToDTO(),
            IssueDate = receipt.IssueDate.ToString("d"),
            AmountReceived = (float?) receipt.AmountReceived,
            Items = new ObservableCollection<ReceiptItemDTO>(productReceipts.Select(
                productReceipt => productReceipt.ToDTO()))
        };
    }
    
    public static ReceiptDTO ToDTO(this ReceiptViewModel receiptViewModel)
    {
        var items = new ObservableCollection<ReceiptItemDTO>(receiptViewModel.ReceiptItems.Select(
            item => item.ToDTO()));
        var receipt = new ReceiptDTO
        {
            Id = receiptViewModel.Id,
            Cashier = receiptViewModel.Cashier.ToDTO(),
            IssueDate = receiptViewModel.IssueDate,
            AmountReceived = receiptViewModel.AmountReceived,
            Items = new ObservableCollection<ReceiptItemDTO>(receiptViewModel.ReceiptItems.Select(
                item => item.ToDTO()))
        };
        
        foreach (var item in receipt.Items)
        {
            var stock = StockBLL.GetStocks().FirstOrDefault(
                stock => stock.Product?.Id == item.Product?.Id);
            
            if (stock == null)
                continue;
            
            stock.Quantity -= item.Quantity;
            StockBLL.EditStock(stock);
        }

        return receipt;
    }
    
    public static ReceiptViewModel ToViewModel(this ReceiptDTO receiptDTO)
    {
        return new ReceiptViewModel
        {
            Id = receiptDTO.Id,
            Cashier = receiptDTO.Cashier?.ToViewModel() 
                      ?? throw new ArgumentNullException(nameof(receiptDTO.Cashier)),
            IssueDate = receiptDTO.IssueDate ?? "",
            AmountReceived = receiptDTO.AmountReceived ?? 0,
            ReceiptItems = new ObservableCollection<ReceiptItemViewModel>(receiptDTO.Items?.Select(
                item => item.ToViewModel()) ?? new List<ReceiptItemViewModel>())
        };
    }
    
    public static Receipt ToEntity(this ReceiptDTO receiptDTO)
    {
        return new Receipt
        {
            ReceiptId = receiptDTO.Id,
            UserId = receiptDTO.Cashier?.Id 
                     ?? throw new ArgumentNullException(nameof(receiptDTO.Cashier.Id)),
            IssueDate = DateTime.Parse(receiptDTO.IssueDate 
                                       ?? throw new ArgumentNullException(nameof(receiptDTO.IssueDate))),
            AmountReceived = (decimal?) receiptDTO.AmountReceived
                                ?? throw new ArgumentNullException(nameof(receiptDTO.AmountReceived)),
            User = receiptDTO.Cashier?.ToEntity(),
            Products = new List<Product?>(receiptDTO.Items?.Select(
                item => item.Product?.ToEntity()) ?? new List<Product?>())
        };
    }
}