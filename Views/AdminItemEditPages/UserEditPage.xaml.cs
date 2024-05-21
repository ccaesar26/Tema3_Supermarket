using System.Windows.Controls;
using Supermarket.Models.DataTransferLayer;
using Supermarket.ViewModels.ObjectViewModels;
using Supermarket.ViewModels.PageViewModels.AdminPageViewModels.ObjectEditPageViewModels;

namespace Supermarket.Views.AdminItemEditPages;

public partial class UserEditPage : Page
{
    public UserEditPage()
    {
        InitializeComponent();
    }
    
    public UserEditPage(UserViewModel user)
    {
        InitializeComponent();
        DataContext = new UserEditPageViewModel(user);
    }
}