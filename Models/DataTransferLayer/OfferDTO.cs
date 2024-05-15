namespace Supermarket.Models.DataTransferLayer;

public class OfferDTO
{
    public int? Id { get; set; }
    public string? ProductName { get; set; }
    public int? DiscountPercentage { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public string? Reason { get; set; }
}