using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Models.EntityLayer;
using Supermarket.Models.EntityLayer.Enums;
using Supermarket.ViewModels.ObjectViewModels;

namespace Supermarket.Extensions.Mapping;

public static class OfferME
{
    public static OfferDTO ToDTO(this Offer offer)
    {
        return new OfferDTO
        {
            Id = offer.OfferId,
            Product = offer.Product?.ToDTO(),
            DiscountPercentage = offer.DiscountPercentage,
            StartDate = offer.StartDate.ToString("d"),
            EndDate = offer.EndDate.ToString("d"),
            Reason = offer.Reason.ToString()
        };
    }
    
    public static OfferDTO ToDTO(this OfferViewModel offerViewModel)
    {
        return new OfferDTO
        {
            Id = offerViewModel.Id,
            Product = offerViewModel.Product.ToDTO(),
            DiscountPercentage = offerViewModel.DiscountPercentage,
            StartDate = offerViewModel.StartDate,
            EndDate = offerViewModel.EndDate,
            Reason = offerViewModel.Reason
        };
    }
    
    public static Offer ToEntity(this OfferDTO offerDTO)
    {
        return new Offer
        {
            OfferId = offerDTO.Id,
            ProductId = offerDTO.Product?.Id
                        ?? ProductBLL.GetProducts().FirstOrDefault(p => p.Name == offerDTO.Product?.Name)?.Id 
                        ?? throw new ArgumentNullException(nameof(offerDTO.Product.Id)),
            DiscountPercentage = offerDTO.DiscountPercentage 
                                ?? throw new ArgumentNullException(nameof(offerDTO.DiscountPercentage)),
            StartDate = DateTime.Parse(offerDTO.StartDate 
                                      ?? throw new ArgumentNullException(nameof(offerDTO.StartDate))),
            EndDate = DateTime.Parse(offerDTO.EndDate 
                                    ?? throw new ArgumentNullException(nameof(offerDTO.EndDate))),
            Reason = Enum.Parse<EReason>(offerDTO.Reason 
                    ?? throw new ArgumentNullException(nameof(offerDTO.Reason))),
            Product = offerDTO.Product?.ToEntity()
        };
    }
    
    public static OfferViewModel ToViewModel(this OfferDTO offerDTO)
    {
        return new OfferViewModel
        {
            Id = offerDTO.Id ?? 0,
            Product = offerDTO.Product?.ToViewModel() ?? new ProductViewModel(),
            DiscountPercentage = offerDTO.DiscountPercentage ?? 0,
            StartDate = offerDTO.StartDate ?? "",
            EndDate = offerDTO.EndDate ?? "",
            Reason = offerDTO.Reason ?? ""
        };
    }
}