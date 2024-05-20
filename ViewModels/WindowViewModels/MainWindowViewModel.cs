using Supermarket.ViewModels.PageViewModels;
using Supermarket.Views.PageViews;
using Wpf.Ui;

namespace Supermarket.ViewModels.WindowViewModels;

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
        CurrentPage = new LoginPage();
    }
}