using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Extensions;
using Supermarket.Extensions.EnumExtensions;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;

namespace Supermarket.ViewModels.PageViewModels.ObjectEditPageViewModels;

public class UserEditPageViewModel : BaseViewModel
{
    public UserViewModel User { get; set; }
    public ObservableCollection<string> Roles { get; set; } = EUserTypeExtension.ToStringCollection();
    
    private readonly string? _title;
    public string Title
    {
        get => _title ?? "";
        private init
        {
            _title = value;
            OnPropertyChanged();
        }
    }
    
    public ICommand? SaveCommand { get; private set; }
    public ICommand? CancelCommand { get; private set; }
    
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
    
    private bool _usernameHasError;
    public bool UsernameHasError
    {
        get => _usernameHasError;
        private set
        {
            _usernameHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _passwordHasError;
    public bool PasswordHasError
    {
        get => _passwordHasError;
        private set
        {
            _passwordHasError = value;
            OnPropertyChanged();
        }
    }
    
    private bool _roleHasError;
    public bool RoleHasError
    {
        get => _roleHasError;
        private set
        {
            _roleHasError = value;
            OnPropertyChanged();
        }
    }
    
    private string? _initialUsername;
    public UserEditPageViewModel(UserViewModel user)
    {
        User = user;
        Title = "Edit User";
        _initialUsername = user.Username;
        InitializeCommands();
    }
    
    public UserEditPageViewModel()
    {
        User = new UserViewModel();
        Title = "Add User";
        InitializeCommands();
    }
    
    private void InitializeCommands()
    {
        SaveCommand = new RelayCommand<object>(o =>
        {
            ErrorMessage = "";
            UsernameHasError = false;
            PasswordHasError = false;
            RoleHasError = false;
            
            if (string.IsNullOrWhiteSpace(User.Username))
            {
                ErrorMessage = "Username is required!";
                UsernameHasError = true;
                return;
            }
            
            if (User.Username.Length is < 3 or > 20)
            {
                ErrorMessage = "Username must be between 3 and 20 characters!";
                UsernameHasError = true;
                return;
            }
            
            if (UserBLL.GetUsers().Any(u => u.Username == User.Username))
            {
                if (User.Username != _initialUsername)
                {
                    ErrorMessage = "Username already exists!";
                    UsernameHasError = true;
                    return;
                }
            }
            
            if (string.IsNullOrWhiteSpace(User.Password))
            {
                ErrorMessage = "Password is required!";
                PasswordHasError = true;
                return;
            }
            
            if (User.Password.Length is < 3 or > 20)
            {
                ErrorMessage = "Password must be between 3 and 20 characters!";
                PasswordHasError = true;
                return;
            }
            
            if (string.IsNullOrWhiteSpace(User.UserType))
            {
                ErrorMessage = "Role is required!";
                RoleHasError = true;
                return;
            }
            
            if (User.Id == null)
            {
                UserBLL.AddUser(User.ToDTO());
            }
            else
            {
                UserBLL.EditUser(User.ToDTO());
            }
            
            var page = o as UserEditPage;
            page?.NavigationService?.Navigate(new UserPage());
        });
        
        CancelCommand = new RelayCommand<object>(o =>
        {
            var page = o as UserEditPage;
            page?.NavigationService?.Navigate(new UserPage());
        });
    }
}