namespace Supermarket.Models.DataTransferLayer;

public class OfferDTO
{
    public int? Id { get; init; }
    public ProductDTO? Product { get; init; }
    public int? DiscountPercentage { get; init; }
    public string? StartDate { get; init; }
    public string? EndDate { get; init; }
    public string? Reason { get; init; }
}