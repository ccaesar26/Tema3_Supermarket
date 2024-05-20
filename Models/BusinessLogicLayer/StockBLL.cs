using System.Collections.ObjectModel;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.DataTransferLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public static class StockBLL
{
    public static ObservableCollection<StockDTO> GetStocks()
    {
        var stocks = new ObservableCollection<StockDTO>();
        foreach (var stock in StockDAL.GetStocks())
        {
            stocks.Add(stock.ToDTO());
        }
        return stocks;
    }
    
    public static bool AddStock(StockDTO stockDTO)
    {
        ArgumentNullException.ThrowIfNull(stockDTO);
        ArgumentNullException.ThrowIfNull(stockDTO.Product);
        ArgumentNullException.ThrowIfNull(stockDTO.Quantity);
        ArgumentNullException.ThrowIfNull(stockDTO.Unit);
        ArgumentNullException.ThrowIfNull(stockDTO.SupplyDate);
        ArgumentNullException.ThrowIfNull(stockDTO.PurchasePrice);

        StockDAL.InsertStock(stockDTO.ToEntity());
        return true;
    }
    
    public static bool EditStock(StockDTO stockDTO)
    {
        ArgumentNullException.ThrowIfNull(stockDTO);
        ArgumentNullException.ThrowIfNull(stockDTO.Id);
        ArgumentNullException.ThrowIfNull(stockDTO.Product);
        ArgumentNullException.ThrowIfNull(stockDTO.Quantity);
        ArgumentNullException.ThrowIfNull(stockDTO.Unit);
        ArgumentNullException.ThrowIfNull(stockDTO.SupplyDate);
        ArgumentNullException.ThrowIfNull(stockDTO.PurchasePrice);

        StockDAL.UpdateStock(stockDTO.ToEntity());
        return true;
    }
    
    public static bool DeleteStock(StockDTO stockDTO)
    {
        ArgumentNullException.ThrowIfNull(stockDTO);
        ArgumentNullException.ThrowIfNull(stockDTO.Id);

        StockDAL.DeleteStock(stockDTO.ToEntity());
        return true;
    }
}