using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;
using Wpf.Ui.Controls;

namespace Supermarket.ViewModels.PageViewModels.ObjectPageViewModels;

public class OfferPageViewModel : BaseViewModel
{
    public ObservableCollection<OfferViewModel> Offers { get; set; } 
        = new(OfferBLL.GetOffers().Select(o => o.ToViewModel()));
    public ICommand AddNewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }
    
    public OfferPageViewModel()
    {
        AddNewCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not OfferPage currentPage)
            {
                return;
            }
        
            var offerEditPage = new OfferEditPage();
        
            currentPage.NavigationService?.Navigate(offerEditPage);
        });
        
        EditCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not object[] values) return;

            if (values[0] is not OfferViewModel offer || values[1] is not OfferPage currentPage)
            {
                return;
            }
        
            var offerEditPage = new OfferEditPage(offer);
        
            currentPage.NavigationService?.Navigate(offerEditPage);
        });
        
        RemoveCommand = new RelayCommand<object>(Remove);
    }
    
    private void Remove(object? obj)
    {
        if (obj is not OfferViewModel offer)
        {
            return;
        }
        
        var dialog = new MessageBox
        {
            Title = "Remove Offer",
            Content = "Are you sure you want to remove this offer?",
            PrimaryButtonText = "Yes",
            CloseButtonText = "No"
        };
        
        var result = dialog.ShowDialogAsync().Result;

        if (result != MessageBoxResult.Primary) return;
        
        if (OfferBLL.DeleteOffer(offer.ToDTO()))
        {
            Offers.Remove(offer);
        }
    }
}