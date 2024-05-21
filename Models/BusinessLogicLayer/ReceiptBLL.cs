using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Microsoft.IdentityModel.Abstractions;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public static class ReceiptBLL
{
    public static ObservableCollection<ReceiptDTO> GetReceipts()
    {
        var receipts = new ObservableCollection<ReceiptDTO>();
        foreach (var receipt in ReceiptDAL.GetReceipts())
        {
            var productReceipts = ProductReceiptDAL.GetProductReceiptsByReceipt(receipt);
            receipts.Add(receipt.BuildDTO(productReceipts));
        }
        return receipts;
    }
    
    public static bool AddReceipt(ReceiptDTO receiptDTO)
    {
        ArgumentNullException.ThrowIfNull(receiptDTO);
        ArgumentNullException.ThrowIfNull(receiptDTO.Cashier);
        ArgumentNullException.ThrowIfNull(receiptDTO.IssueDate);
        ArgumentNullException.ThrowIfNull(receiptDTO.AmountReceived);
        
        var receiptId = ReceiptDAL.InsertReceipt(receiptDTO.ToEntity());
        
        return ProductReceiptDAL.InsertProductReceipt(receiptDTO.Items?
            .Select(s => s.ToEntity(receiptId)).FirstOrDefault() ?? new ProductReceipt());
    }
    
    public static bool EditReceipt(ReceiptDTO receiptDTO)
    {
        ArgumentNullException.ThrowIfNull(receiptDTO);
        ArgumentNullException.ThrowIfNull(receiptDTO.Id);
        ArgumentNullException.ThrowIfNull(receiptDTO.Cashier);
        ArgumentNullException.ThrowIfNull(receiptDTO.IssueDate);
        ArgumentNullException.ThrowIfNull(receiptDTO.AmountReceived);

        ReceiptDAL.UpdateReceipt(receiptDTO.ToEntity());
        return true;
    }
    
    public static bool DeleteReceipt(ReceiptDTO receiptDTO)
    {
        ArgumentNullException.ThrowIfNull(receiptDTO);
        ArgumentNullException.ThrowIfNull(receiptDTO.Id);

        ReceiptDAL.DeleteReceipt(receiptDTO.ToEntity());
        return true;
    }
}