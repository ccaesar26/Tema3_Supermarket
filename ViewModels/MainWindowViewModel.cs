using System.Windows;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;

namespace Supermarket.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private object? _currentPage;
    
    public object? CurrentPage
    {
        get => _currentPage;
        set
        {
            _currentPage = value;
            OnPropertyChanged();
        }
    }
    
    public MainWindowViewModel()
    {
        var loginWindow = new LoginWindow();
        var result = loginWindow.ShowDialog();

        if (!result.HasValue || !result.Value)
        {
            Application.Current.Shutdown();
        }
        else
        {
            if (loginWindow.DataContext is not LoginWindowViewModel loginContext)
            {
                Application.Current.Shutdown();
            }
            else
            {
                if (UserBLL.IsValidAdmin(loginContext.Username, loginContext.Password))
                {
                    CurrentPage = new AdminPage();
                }
                else if (UserBLL.IsValidCashier(loginContext.Username, loginContext.Password))
                {
                    CurrentPage = new CashierPage();
                }
            }
        }
    }
}