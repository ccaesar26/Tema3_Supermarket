namespace Supermarket.Models.DataTransferLayer;

public class ReceiptItemDTO
{
    public ProductDTO? Product { get; set; }
    public int? Quantity { get; set; }
    public string? Unit { get; set; }
    public float? Price => Subtotal / Quantity;
    public float Subtotal { get; set; }
    public float Discount => Product?.Offer?.DiscountPercentage * Subtotal / 100 * -1 ?? 0;
}