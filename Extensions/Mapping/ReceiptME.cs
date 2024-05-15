using System.Collections.ObjectModel;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Extensions.Mapping;

public static class ReceiptME
{
    public static ReceiptDTO ToDTO(this Receipt receipt)
    {
        return new ReceiptDTO
        {
            Id = receipt.ReceiptId,
            Cashier = UserBLL.GetUsers()
                .First(user => user.Id == receipt.UserId),
            IssueDate = receipt.IssueDate.ToString("yyyy-MM-dd"),
            AmountReceived = (float) receipt.AmountReceived,
            //TODO Products = ... // Implement this
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
            //TODO Products = ... // Implement this
        };
    }
}