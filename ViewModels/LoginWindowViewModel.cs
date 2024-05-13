using System.Windows;
using System.Windows.Input;
using Microsoft.VisualBasic.ApplicationServices;
using Supermarket.ViewModels.DataTransferObjects;
using Supermarket.Views;
using Wpf.Ui.Controls;
using Wpf.Ui.Input;

namespace Supermarket.ViewModels;

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

        var window = Application.Current.Windows.OfType<LoginWindow>().FirstOrDefault();
        
        if (window == null) return;

        window.DialogResult = true;
        window.Close();
    }
}