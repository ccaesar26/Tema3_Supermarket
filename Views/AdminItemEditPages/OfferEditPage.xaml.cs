using System.Windows.Controls;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.ViewModels.PageViewModels.ObjectEditPageViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class OfferEditPage : Page
{
    public OfferEditPage()
    {
        InitializeComponent();
    }
    
    public OfferEditPage(OfferViewModel offer)
    {
        InitializeComponent();
        DataContext = new OfferEditPageViewModel(offer);
    }
}