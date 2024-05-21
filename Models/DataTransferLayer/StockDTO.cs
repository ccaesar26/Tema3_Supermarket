using Supermarket.Services;

namespace Supermarket.Models.DataTransferLayer;

public class StockDTO
{
    public int? Id { get; init; }
    public ProductDTO? Product { get; init; }
    public int? Quantity { get; set; }
    public string? Unit { get; init; }
    public string? SupplyDate { get; init; }
    public string? ExpiryDate { get; init; }
    public float? PurchasePrice { get; init; }
    public float? SellingPrice => PurchasePrice * float.Parse(ConfigurationManager.GetSetting("ProfitPercentage") ?? "1.0");
}