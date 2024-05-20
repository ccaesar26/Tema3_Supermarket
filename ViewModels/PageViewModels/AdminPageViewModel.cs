
using System.Windows.Input;
using Supermarket.ViewModels.Commands;
using Supermarket.Views.PageViews;
using Wpf.Ui;

namespace Supermarket.ViewModels.PageViewModels;

public class AdminPageViewModel : BaseViewModel
{
    public ICommand LogOutCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not AdminPage page)
        {
            return;
        }
        
        page.NavigationService?.Navigate(new LoginPage());
    });
    
    public ICommand NavigateToHomeCommand { get; } = new RelayCommand<object?>(obj =>
    {
        if (obj is not AdminPage page)
        {
            return;
        }
        
        var navigationView = page.NavigationView;
        
        navigationView.Navigate("Home");
    });
}