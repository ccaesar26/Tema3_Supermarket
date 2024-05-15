namespace Supermarket.Models.DataTransferLayer;

public class StockDTO
{
    public int? Id { get; set; }
    public string? ProductName { get; set; }
    public int? Quantity { get; set; }
    public string? Unit { get; set; }
    public string? SupplyDate { get; set; }
    public string? ExpiryDate { get; set; }
    public float? PurchasePrice { get; set; }
    public float? SellingPrice { get; set; }
}