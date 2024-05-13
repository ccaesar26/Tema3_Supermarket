using System.Windows;
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
        CurrentPage = new AdminPage();
        var loginWindow = new LoginWindow();
        var result = loginWindow.ShowDialog();

        if (!result.HasValue || !result.Value)
        {
            Application.Current.Shutdown();
        }
    }
}