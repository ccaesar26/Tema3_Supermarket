namespace Supermarket.Models.DataTransferLayer;

public class ProductDTO
{
    public int? Id { get; init; }
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public CategoryDTO? Category { get; set; }
    public ProducerDTO? Producer { get; set; }
    public string? Image { get; set; }
    public OfferDTO? Offer { get; set; }
}