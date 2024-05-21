namespace Supermarket.Models.DataTransferLayer;

public class ReceiptItemDTO
{
    public ProductDTO? Product { get; init; }
    public int? Quantity { get; init; }
    public string? Unit { get; init; }
    public float Subtotal { get; init; }
}