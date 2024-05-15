namespace Supermarket.Models.DataTransferLayer;

public class ProductDTO
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public CategoryDTO? Category { get; set; }
    public ProducerDTO? Producer { get; set; }
    public string? Image { get; set; }
}