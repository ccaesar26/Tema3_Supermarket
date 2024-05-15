using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Extensions.Mapping;

public static class StockME
{
    public static StockDTO ToDTO(this Stock stock)
    {
        return new StockDTO
        {
            Id = stock.StockId,
            Product = ProductBLL.GetProducts()
                .First(product => product.Id == stock.ProductId),
            Quantity = stock.Quantity,
            Unit = stock.Unit.ToString(),
            SupplyDate = stock.SupplyDate.ToString("yyyy-MM-dd"),
            ExpiryDate = stock.ExpiryDate.ToString("yyyy-MM-dd"),
            PurchasePrice = (float) stock.PurchasePrice,
            SellingPrice = (float) stock.SellingPrice
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
            SupplyDate = DateTime.Parse(stockDTO.SupplyDate 
                                        ?? throw new ArgumentNullException(nameof(stockDTO.SupplyDate))),
            ExpiryDate = DateTime.Parse(stockDTO.ExpiryDate 
                                        ?? throw new ArgumentNullException(nameof(stockDTO.ExpiryDate))),
            PurchasePrice = (decimal?) stockDTO.PurchasePrice 
                            ?? throw new ArgumentNullException(nameof(stockDTO.PurchasePrice)),
        };
    }
}