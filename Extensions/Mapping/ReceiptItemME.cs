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
            Product = receiptItemViewModel.Product.ToDTO(),
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
    
    public static ProductReceipt ToEntity(this ReceiptItemDTO receiptItemDTO, int receiptId)
    {
        return new ProductReceipt
        {
            ReceiptId = receiptId,
            ProductId = receiptItemDTO.Product?.Id 
                        ?? throw new ArgumentNullException(nameof(receiptItemDTO.Product.Id)),
            Quantity = receiptItemDTO.Quantity 
                       ?? throw new ArgumentNullException(nameof(receiptItemDTO.Quantity)),
            Unit = Enum.Parse<EUnit>(receiptItemDTO.Unit 
                                     ?? throw new ArgumentNullException(nameof(receiptItemDTO.Unit))),
            Subtotal = (decimal?) receiptItemDTO.Subtotal 
                       ?? throw new ArgumentNullException(nameof(receiptItemDTO.Subtotal)),
            Product = receiptItemDTO.Product?.ToEntity()
        };
    }
}