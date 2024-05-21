﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;
using Wpf.Ui.Controls;

namespace Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectPageViewModels;

public class ProductPageViewModel
{
    public ObservableCollection<ProductViewModel> Products { get; set; } 
        = new(ProductBLL.GetProducts().Select(p => p.ToViewModel()));
    
    public ICommand AddNewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }
    
    public ProductPageViewModel()
    {
        AddNewCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not ProductPage currentPage)
            {
                return;
            }
        
            var productEditPage = new ProductEditPage();
        
            currentPage.NavigationService?.Navigate(productEditPage);
        });
        
        EditCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not object[] values) return;

            if (values[0] is not ProductViewModel product || values[1] is not ProductPage currentPage)
            {
                return;
            }
        
            var productEditPage = new ProductEditPage(product);
        
            currentPage.NavigationService?.Navigate(productEditPage);
            
        });
        RemoveCommand = new RelayCommand<object>(Remove);
    }
    
    private void Remove(object? obj)
    {
        if (obj is not ProductViewModel product)
        {
            return;
        }
        
        var dialog = new MessageBox
        {
            Title = "Confirmation",
            Content = "Are you sure you want to delete this producer?",
            PrimaryButtonText = "Yes",
            CloseButtonText = "No"
        };
        
        var result = dialog.ShowDialogAsync().Result;

        if (result != MessageBoxResult.Primary) return;
        
        if (ProductBLL.DeleteProduct(product.ToDTO()))
        {
            Products.Remove(product);
        }
    }
}