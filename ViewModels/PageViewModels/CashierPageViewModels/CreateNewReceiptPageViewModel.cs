﻿using System.Collections.ObjectModel;
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
    public ObservableCollection<string> OriginalItems { get; set; }
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

    public CreateNewReceiptPageViewModel()
    {
        Receipt = new ReceiptViewModel()
        {
            IssueDate = DateTime.Now.ToString("d"),
            Cashier = UserSession.Instance.LoggedInUser ?? new UserViewModel()
        };
        
        OriginalItems = new ObservableCollection<string>(StockBLL.GetStocks()
            .Select(s => s.Product?.Name ?? ""));
        
        SuggestionChosenCommand = new RelayCommand<object>(OnSuggestionChosen);
    }
    
    private void OnSuggestionChosen(object obj)
    {
        if (obj is not string selectedText)
        {
            return;
        }

        var result = (StockBLL.GetStocks()
            .FirstOrDefault(s => s.Product?.Name == selectedText) ?? new StockDTO()).ToViewModel();
        
        ResultedItem = new ResultItemViewModel()
        {
            Stock = result,
            Offer = OfferBLL.GetOffers().FirstOrDefault(o => o.Product?.Id == result.Product.Id)?.ToViewModel() 
                    ?? new OfferViewModel()
        };
    }
}