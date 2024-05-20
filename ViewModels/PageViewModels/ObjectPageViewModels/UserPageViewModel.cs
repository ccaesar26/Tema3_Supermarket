using System.Collections.ObjectModel;
using System.Windows.Input;
using Supermarket.Extensions.Mapping;
using Supermarket.Models.BusinessLogicLayer;
using Supermarket.ViewModels.Commands;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.Views.AdminItemEditPages;
using Supermarket.Views.AdminItemPageViews;
using Wpf.Ui.Controls;

namespace Supermarket.ViewModels.PageViewModels.ObjectPageViewModels;

public class UserPageViewModel
{
    public ObservableCollection<UserViewModel> Users { get; set; } 
        = new(UserBLL.GetUsers().Select(u => u.ToViewModel()));
    public ICommand AddNewCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand RemoveCommand { get; }
    
    public UserPageViewModel()
    {
        AddNewCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not UserPage currentPage)
            {
                return;
            }
        
            var userEditPage = new UserEditPage();
        
            currentPage.NavigationService?.Navigate(userEditPage);
        });
        
        EditCommand = new RelayCommand<object>(obj =>
        {
            if (obj is not object[] values) return;

            if (values[0] is not UserViewModel user || values[1] is not UserPage currentPage)
            {
                return;
            }
        
            var userEditPage = new UserEditPage(user);
        
            currentPage.NavigationService?.Navigate(userEditPage);
        });
        
        RemoveCommand = new RelayCommand<object>(Remove);
    }
    
    private void Remove(object? obj)
    {
        if (obj is not UserViewModel user)
        {
            return;
        }
        
        var dialog = new MessageBox
        {
            Title = "Confirmation",
            Content = "Are you sure you want to delete this producer?",
            PrimaryButtonText = "Yes",
            CloseButtonText = "No"
        };
        
        var result = dialog.ShowDialogAsync().Result;

        if (result != MessageBoxResult.Primary) return;
        
        if (UserBLL.DeleteUser(user.ToDTO()))
        {
            Users.Remove(user);
        }
    }
}