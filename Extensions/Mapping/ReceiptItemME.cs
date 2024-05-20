using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;
using Supermarket.ViewModels.ObjectViewModels;

namespace Supermarket.Extensions.Mapping;

public static class ReceiptItemME
{
    public static ReceiptItemDTO ToDTO(this ProductReceipt productReceipt)
    {
        return new ReceiptItemDTO
        {
            Product = productReceipt.Product?.ToDTO() ?? new ProductDTO(),
            Quantity = productReceipt.Quantity,
            Unit = productReceipt.Unit.ToString(),
            Subtotal = (float) productReceipt.Subtotal
        };
    }
    
    public static ReceiptItemDTO ToDTO(this ReceiptItemViewModel receiptItemViewModel)
    {
        return new ReceiptItemDTO
        {
            Product = receiptItemViewModel.Product?.ToDTO() ?? new ProductDTO(),
            Quantity = receiptItemViewModel.Quantity,
            Unit = receiptItemViewModel.Unit,
            Subtotal = receiptItemViewModel.Subtotal
        };
    }
    
    public static ReceiptItemViewModel ToViewModel(this ReceiptItemDTO receiptItemDTO)
    {
        return new ReceiptItemViewModel
        {
            Product = receiptItemDTO.Product?.ToViewModel() ?? new ProductViewModel(),
            Quantity = receiptItemDTO.Quantity ?? 0,
            Unit = receiptItemDTO.Unit ?? "",
            Subtotal = receiptItemDTO.Subtotal
        };
    }
}