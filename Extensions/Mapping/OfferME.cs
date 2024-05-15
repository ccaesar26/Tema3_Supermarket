using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;

namespace Supermarket.Extensions.Mapping;

public static class OfferME
{
    public static OfferDTO ToDTO(this Offer offer)
    {
        return new OfferDTO
        {
            Id = offer.OfferId,
            Product = ProductBLL.GetProducts()
                .First(product => product.Id == offer.ProductId),
            DiscountPercentage = offer.DiscountPercentage,
            StartDate = offer.StartDate.ToString("yyyy-MM-dd"),
            EndDate = offer.EndDate.ToString("yyyy-MM-dd"),
            Reason = offer.Reason.ToString()
        };
    }
    
    public static Offer ToEntity(this OfferDTO offerDTO)
    {
        return new Offer
        {
            OfferId = offerDTO.Id,
            ProductId = offerDTO.Id 
                        ?? throw new ArgumentNullException(nameof(offerDTO.Product.Id)),
            DiscountPercentage = offerDTO.DiscountPercentage 
                                ?? throw new ArgumentNullException(nameof(offerDTO.DiscountPercentage)),
            StartDate = DateTime.Parse(offerDTO.StartDate 
                                      ?? throw new ArgumentNullException(nameof(offerDTO.StartDate))),
            EndDate = DateTime.Parse(offerDTO.EndDate 
                                    ?? throw new ArgumentNullException(nameof(offerDTO.EndDate))),
            Reason = Enum.Parse<EReason>(offerDTO.Reason 
                    ?? throw new ArgumentNullException(nameof(offerDTO.Reason)))
        };
    }
}