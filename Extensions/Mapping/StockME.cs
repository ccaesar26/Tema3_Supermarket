using System.Globalization;
using System.Runtime.Serialization;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;
using Supermarket.ViewModels.ObjectViewModels;

namespace Supermarket.Extensions.Mapping;

public static class StockME
{
    public static StockDTO ToDTO(this Stock stock)
    {
        return new StockDTO
        {
            Id = stock.StockId,
            Product = stock.Product?.ToDTO(),
            Quantity = stock.Quantity,
            Unit = stock.Unit.ToString(),
            SupplyDate = stock.SupplyDate.ToString("d"),
            ExpiryDate = stock.ExpiryDate?.ToString("d"),
            PurchasePrice = (float) stock.PurchasePrice
        };
    }
    
    public static StockDTO ToDTO(this StockViewModel stockViewModel)
    {
        return new StockDTO
        {
            Id = stockViewModel.Id,
            Product = stockViewModel.Product?.ToDTO(),
            Quantity = stockViewModel.Quantity,
            Unit = stockViewModel.Unit,
            SupplyDate = stockViewModel.SupplyDate,
            ExpiryDate = stockViewModel.ExpiryDate,
            PurchasePrice = stockViewModel.PurchasePrice
        };
    }
    
    public static Stock ToEntity(this StockDTO stockDTO)
    {
        return new Stock
        {
            StockId = stockDTO.Id,
            ProductId = stockDTO.Product?.Id 
                        ?? throw new ArgumentNullException(nameof(stockDTO.Product.Id)),
            Quantity = stockDTO.Quantity 
                       ?? throw new ArgumentNullException(nameof(stockDTO.Quantity)),
            Unit = Enum.Parse<EUnit>(stockDTO.Unit 
                                     ?? throw new ArgumentNullException(nameof(stockDTO.Unit))),
            SupplyDate = DateTime.ParseExact(stockDTO.SupplyDate 
                                        ?? throw new ArgumentNullException(nameof(stockDTO.SupplyDate)), "d", new CultureInfo("ro-RO")),
            ExpiryDate = stockDTO.ExpiryDate is null or ""
                         ? null 
                         : DateTime.ParseExact(stockDTO.ExpiryDate, "d", new CultureInfo("ro-RO")),
            PurchasePrice = (decimal?) stockDTO.PurchasePrice 
                            ?? throw new ArgumentNullException(nameof(stockDTO.PurchasePrice)),
            Product = stockDTO.Product?.ToEntity()
        };
    }
    
    public static StockViewModel ToViewModel(this StockDTO stockDTO)
    {
        return new StockViewModel
        {
            Id = stockDTO.Id ?? 0,
            Product = stockDTO.Product?.ToViewModel(),
            Quantity = stockDTO.Quantity ?? 0,
            Unit = stockDTO.Unit ?? "",
            SupplyDate = stockDTO.SupplyDate ?? "",
            ExpiryDate = stockDTO.ExpiryDate ?? "",
            PurchasePrice = stockDTO.PurchasePrice ?? 0
        };
    }
}