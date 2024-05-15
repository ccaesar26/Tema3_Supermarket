namespace Supermarket.Models.DataTransferLayer;

public class StockDTO
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public string Unit { get; set; }
    public string SupplyDate { get; set; }
    public string ExpirynDate { get; set; }
    public float PurchasePrice { get; set; }
    public float SellingPrice { get; set; }
}