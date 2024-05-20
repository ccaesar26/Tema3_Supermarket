using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Extensions.EnumExtensions;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;

namespace Supermarket.ViewModels.PageViewModels.ObjectEditPageViewModels;

public class OfferEditPageViewModel : BaseViewModel
{
    public OfferViewModel Offer { get; set; }

    public ObservableCollection<string> Reasons { get; set; }
        = EReasonExtension.ToStringCollection();
    
    public ObservableCollection<ProductViewModel> Products { get; set; }
        = new(ProductBLL.GetProducts().Select(p => p.ToViewModel()));
    
    private readonly string? _title;
    public string Title
    {
        get => _title ?? "";
        private init
        {
            _title = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand? SaveCommand { get; private set; }
    public ICommand? CancelCommand { get; private set; }

    private string? _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage ?? "";
        private set
        {
            _errorMessage = value;
            OnPropertyChanged();
        }
    }
    
    private bool _productNameHasError;
    public bool ProductNameHasError
    {
        get => _productNameHasError;
        private set
        {
            _productNameHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _discountPercentageHasError;
    public bool DiscountPercentageHasError
    {
        get => _discountPercentageHasError;
        private set
        {
            _discountPercentageHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _startDateHasError;
    public bool StartDateHasError
    {
        get => _startDateHasError;
        private set
        {
            _startDateHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _endDateHasError;
    public bool EndDateHasError
    {
        get => _endDateHasError;
        private set
        {
            _endDateHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _reasonHasError;
    public bool ReasonHasError
    {
        get => _reasonHasError;
        private set
        {
            _reasonHasError = value;
            OnPropertyChanged();
        }
    }
    
    public OfferEditPageViewModel()
    {
        Offer = new OfferViewModel();
        Title = "Add Offer";
        InitializeCommands();
    }
    
    public OfferEditPageViewModel(OfferViewModel offer)
    {
        Offer = offer;
        Title = "Edit Offer";
        InitializeCommands();
    }
    
    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(obj =>
        {
            ErrorMessage = "";
            ProductNameHasError =
                DiscountPercentageHasError =
                    StartDateHasError =
                        EndDateHasError =
                            ReasonHasError =
                                false;

            if (string.IsNullOrWhiteSpace(Offer.Product.Name))
            {
                ErrorMessage = "Product name is required!";
                ProductNameHasError = true;
                return;
            }

            if (Offer.DiscountPercentage <= 0)
            {
                ErrorMessage = "Discount percentage is required!";
                DiscountPercentageHasError = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(Offer.StartDate))
            {
                ErrorMessage = "Start date is required!";
                StartDateHasError = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(Offer.EndDate))
            {
                ErrorMessage = "End date is required!";
                EndDateHasError = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(Offer.Reason))
            {
                ErrorMessage = "Reason is required!";
                ReasonHasError = true;
                return;
            }
            
            if (string.Compare(Offer.StartDate, Offer.EndDate, StringComparison.Ordinal) > 0)
            {
                ErrorMessage = "Start date must be before end date!";
                StartDateHasError = true;
                EndDateHasError = true;
                return;
            }
            
            if (Offer.Id == null)
            {
                OfferBLL.AddOffer(Offer.ToDTO());
            }
            else
            {
                OfferBLL.EditOffer(Offer.ToDTO());
            }

            var page = obj as OfferEditPage;
            page?.NavigationService?.Navigate(new OfferPage());
        });
        
        CancelCommand = new RelayCommand<object>(obj =>
        {
            var page = obj as OfferEditPage;
            page?.NavigationService?.Navigate(new OfferPage());
        });
    }
}