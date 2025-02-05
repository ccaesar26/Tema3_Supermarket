﻿using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using Supermarket.Views.PageViews;
using Supermarket.Views.PageViews.CashierPageViews;

namespace Supermarket.ViewModels.PageViewModels.CashierPageViewModels;

public class CashierPageViewModel : BaseViewModel
{
    public ICommand LogOutCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not CashierPage page)
        {
            return;
        }
        
        page.NavigationService?.Navigate(new LoginPage());
    });
    
    public ICommand NavigateToHomeCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not CashierPage page)
        {
            return;
        }
        
        var navigationView = page.CashierNavigationView;

        CashierHomePageViewModel.NavigationView = navigationView;
        CreateNewReceiptPageViewModel.NavigationView = navigationView;
        
        navigationView.Navigate("Home");
    });
}