using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Extensions.EnumExtensions;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;

namespace Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

public class StockEditPageViewModel : BaseViewModel
{
    public StockViewModel Stock { get; set; } = new();

    public ObservableCollection<string> Products { get; } 
        = new(ProductBLL.GetProducts().Select(p => p.Name ?? ""));
    public ObservableCollection<string> Units { get; } = EUnitExtension.ToStringCollection();
    
    public string Title { get; } = "Add Stock";
    
    public string Product
    {
        get => Stock.Product.Name;
        set
        {
            Stock.Product = (from p in ProductBLL.GetProducts().Select(p => p.ToViewModel())
                where p.Name == value 
                select p).FirstOrDefault() ?? new ProductViewModel();
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
    
    private bool _productHasError;
    public bool ProductHasError
    {
        get => _productHasError;
        private set
        {
            _productHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _quantityHasError;
    public bool QuantityHasError
    {
        get => _quantityHasError;
        private set
        {
            _quantityHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _unitHasError;
    public bool UnitHasError
    {
        get => _unitHasError;
        private set
        {
            _unitHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _supplyDateHasError;
    public bool SupplyDateHasError
    {
        get => _supplyDateHasError;
        private set
        {
            _supplyDateHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _expiryDateHasError;
    public bool ExpiryDateHasError
    {
        get => _expiryDateHasError;
        private set
        {
            _expiryDateHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _purchasePriceHasError;
    public bool PurchasePriceHasError
    {
        get => _purchasePriceHasError;
        private set
        {
            _purchasePriceHasError = value;
            OnPropertyChanged();
        }
    }
    
    public StockEditPageViewModel()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            ErrorMessage = "";
            ProductHasError = 
                QuantityHasError = 
                    UnitHasError = 
                        SupplyDateHasError = 
                            ExpiryDateHasError = 
                                PurchasePriceHasError = 
                                    false;

            if (Stock.Quantity <= 0)
            {
                ErrorMessage = "Quantity is required!";
                QuantityHasError = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(Stock.Unit))
            {
                ErrorMessage = "Unit is required!";
                UnitHasError = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(Stock.SupplyDate))
            {
                ErrorMessage = "Supply Date is required!";
                SupplyDateHasError = true;
                return;
            }
            
            if (Stock.PurchasePrice <= 0)
            {
                ErrorMessage = "Purchase Price is required!";
                PurchasePriceHasError = true;
                return;
            }
            
            StockBLL.AddStock(Stock.ToDTO());
            
            var page = o as StockEditPage;
            page?.NavigationService?.Navigate(new StockPage());
        });
        
        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as StockEditPage;
            page?.NavigationService?.Navigate(new StockPage());
        });
    }
}