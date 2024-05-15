using System.Windows;
using System.Windows.Input;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.Views;
using Supermarket.Views.WindowViews;
using Wpf.Ui.Input;

namespace Supermarket.ViewModels.WindowViewModels;

public class LoginWindowViewModel : BaseViewModel
{
    public ICommand LoginCommand { get; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    
    public LoginWindowViewModel()
    {
        LoginCommand = new RelayCommand<object>(Login);
    }
    
    private void Login(object? obj)
    {
        if (Username == "" || Password == "")
        {
            return;
        }
        
        if (!UserBLL.IsValidAdmin(Username, Password) && !UserBLL.IsValidCashier(Username, Password))
        {
            return;
        }

        var window = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
        
        if (window == null) return;

        window.DialogResult = true;
        window.Close();
    }
}