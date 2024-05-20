using System.Collections.ObjectModel;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.DataAccessLayer;
using Supermarket.Models.DataTransferLayer;

namespace Supermarket.Models.BusinessLogicLayer;

public static class OfferBLL
{
    public static ObservableCollection<OfferDTO> GetOffers()
    {
        var offers = new ObservableCollection<OfferDTO>();
        foreach (var offer in OfferDAL.GetOffers())
        {
            offers.Add(offer.ToDTO());
        }
        return offers;
    }
    
    public static bool AddOffer(OfferDTO offerDTO)
    {
        ArgumentNullException.ThrowIfNull(offerDTO);
        ArgumentNullException.ThrowIfNull(offerDTO.Product);
        ArgumentNullException.ThrowIfNull(offerDTO.DiscountPercentage);
        ArgumentNullException.ThrowIfNull(offerDTO.StartDate);
        ArgumentNullException.ThrowIfNull(offerDTO.EndDate);
        ArgumentNullException.ThrowIfNull(offerDTO.Reason);
        
        OfferDAL.InsertOffer(offerDTO.ToEntity());
        return true;
    }
    
    public static bool EditOffer(OfferDTO offerDTO)
    {
        ArgumentNullException.ThrowIfNull(offerDTO);
        ArgumentNullException.ThrowIfNull(offerDTO.Id);
        ArgumentNullException.ThrowIfNull(offerDTO.Product);
        ArgumentNullException.ThrowIfNull(offerDTO.DiscountPercentage);
        ArgumentNullException.ThrowIfNull(offerDTO.StartDate);
        ArgumentNullException.ThrowIfNull(offerDTO.EndDate);
        ArgumentNullException.ThrowIfNull(offerDTO.Reason);
        
        OfferDAL.UpdateOffer(offerDTO.ToEntity());
        return true;
    }
    
    public static bool DeleteOffer(OfferDTO offerDTO)
    {
        ArgumentNullException.ThrowIfNull(offerDTO);
        ArgumentNullException.ThrowIfNull(offerDTO.Id);
        
        OfferDAL.DeleteOffer(offerDTO.ToEntity());
        return true;
    }
}