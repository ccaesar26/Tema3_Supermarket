namespace Supermarket.Models.DataTransferLayer;

public class ProductDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public string? CategoryName { get; set; }
    public string? ProducerName { get; set; }
    public string? Image { get; set; }
}