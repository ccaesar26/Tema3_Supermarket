namespace Supermarket.Models.DataTransferLayer;

public class ProductDTO
{
    public int? Id { get; init; }
    public string? Name { get; init; }
    public string? Barcode { get; init; }
    public CategoryDTO? Category { get; init; }
    public ProducerDTO? Producer { get; init; }
    public string? Image { get; init; }
    public OfferDTO? Offer { get; init; }
}