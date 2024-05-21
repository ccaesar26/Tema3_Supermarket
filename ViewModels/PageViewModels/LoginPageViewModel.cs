using System.Windows.Input;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Models.DataTransferLayer;
using Supermarket.Services;
using Supermarket.Views.PageViews;
using Supermarket.Views.PageViews.AdminPageViews;
using Supermarket.Views.PageViews.CashierPageViews;
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

        if (obj is not LoginPage page) return;
        
        if (UserBLL.IsValidAdmin(Username, Password))
        {
            page.NavigationService?.Navigate(new AdminPage());
        }
        else
        {
            var user = (UserBLL.GetUsers().FirstOrDefault(u => u.Username == Username) ?? new UserDTO()).ToViewModel();
            UserSession.Instance.SetUser(user);
            page.NavigationService?.Navigate(new CashierPage());
        }
    }
}