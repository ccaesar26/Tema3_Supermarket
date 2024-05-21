using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Azure;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Services;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.PageViews.CashierPageViews;

namespace Supermarket.ViewModels.PageViewModels.CashierPageViewModels;

public class CreateNewReceiptPageViewModel : BaseViewModel
{
    private readonly ReceiptViewModel? _receipt;
    public ReceiptViewModel Receipt
    {
        get => _receipt ?? new ReceiptViewModel();
        private init
        {
            _receipt = value;
            OnPropertyChanged();
        }
    }

    public ICommand? AddNewCommand { get; private set; } = new RelayCommand<object>(obj =>
    {
        if (obj is not Page page)
        {
            return;
        }
        
        page.NavigationService?.Navigate(new CreateNewReceiptPage());
    });
    public ObservableCollection<ResultItemViewModel> OriginalItems { get; set; }
    public ObservableCollection<string> Filters { get; } =
    [
        "Product Name",
        "Barcode",
        "Category",
        "Producer",
        "Expiration Date"
    ];
    
    private string? _selectedFilter;
    public string SelectedFilter
    {
        get => _selectedFilter ?? "Product Name";
        set
        {
            _selectedFilter = value;
            ResultItemViewModel.ToStringFunc = value switch
            {
                "Product Name" => r => r.Stock.Product.Name,
                "Barcode" => r => r.Stock.Product.Barcode,
                "Category" => r => r.Stock.Product.Category.Name,
                "Producer" => r => r.Stock.Product.Producer.Name,
                "Expiration Date" => r => r.Stock.ExpiryDate,
                _ => r => r.Stock.Product.Name
            };
            OnPropertyChanged();
        }
    }
    
    private ResultItemViewModel? _resultedItem;
    public ResultItemViewModel ResultedItem
    {
        get => _resultedItem ?? new ResultItemViewModel();
        set
        {
            _resultedItem = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand? AddItemCommand { get; private set; } = new RelayCommand<object>(obj =>
    {
    });
    
    public ICommand? SaveCommand { get; private set; } = new RelayCommand<object>(obj =>
    {
    });

    
    public ICommand? CancelCommand { get; private set; } = new RelayCommand<object>(obj =>
    {
    });

    public ICommand SuggestionChosenCommand { get; set; }
    
    private Visibility _resultVisibility = Visibility.Collapsed;
    public Visibility ResultVisibility
    {
        get => _resultVisibility;
        set
        {
            _resultVisibility = value;
            OnPropertyChanged();
        }
    }

    public CreateNewReceiptPageViewModel()
    {
        Receipt = new ReceiptViewModel
        {
            IssueDate = DateTime.Now.ToString("d"),
            Cashier = UserSession.Instance.LoggedInUser ?? new UserViewModel()
        };
        
        // populate the original items with the stocks that expires first (if multiple for same product)
        OriginalItems = new ObservableCollection<ResultItemViewModel>(
            StockBLL.GetStocks()
                .GroupBy(s => s.Product?.Name)
                .Select(g => g.MinBy(s => s.ExpiryDate))
                .Select(s => new ResultItemViewModel()
                {
                    Stock = (s ?? new StockDTO()).ToViewModel(),
                    Offer = OfferBLL.GetOffers().FirstOrDefault(o => o.Product?.Id == s?.Product?.Id)?.ToViewModel() 
                            ?? new OfferViewModel()
                })
        );
        
        SuggestionChosenCommand = new RelayCommand<object>(OnSuggestionChosen);
    }
    
    private void OnSuggestionChosen(object obj)
    {
        if (obj is not ResultItemViewModel selectedProduct)
        {
            return;
        }

        ResultedItem = selectedProduct;
        
        ResultVisibility = Visibility.Visible;
    }
}