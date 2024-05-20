using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views.PageViews;
using Wpf.Ui.Input;

namespace Supermarket.ViewModels.PageViewModels;

public class LoginPageViewModel: BaseViewModel
{
    public ICommand LoginCommand { get; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    
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
    
    private bool _hasError;
    public bool HasError
    {
        get => _hasError;
        private set
        {
            _hasError = value;
            OnPropertyChanged();
        }
    }
    
    public LoginPageViewModel()
    {
        LoginCommand = new RelayCommand<object>(Login);
    }
    
    private void Login(object? obj)
    {
        if (Username == "" || Password == "")
        {
            ErrorMessage = "Please enter username and password";
            HasError = true;
            return;
        }
        
        if (!UserBLL.IsValidAdmin(Username, Password) && !UserBLL.IsValidCashier(Username, Password))
        {
            ErrorMessage = "Invalid username or password";
            HasError = true;
            return;
        }

        if (obj is LoginPage page)
        {
            page.NavigationService?.Navigate(new AdminPage());
        }
    }
}